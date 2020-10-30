using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLibrary.EncryptedConfiguration
{
    public class CustomConfigProvider : ConfigurationProvider, IConfigurationSource
    {
        public CustomConfigProvider()
        {
        }

        public override void Load()
        {
            Data = UnencryptMyConfiguration();
        }

        private IDictionary<string, string> UnencryptMyConfiguration()
        {
            // do whatever you need to do here, for example load the file and unencrypt key by key
            //Like:
            var configValues = new Dictionary<string, string>
       {
            {"key1", "unencryptedValue1"},
            {"key2", "unencryptedValue2"}
       };
            return configValues;
        }

        private IDictionary<string, string> CreateAndSaveDefaultValues(IDictionary<string, string> defaultDictionary)
        {
            var configValues = new Dictionary<string, string>
        {
            {"key1", "encryptedValue1"},
            {"key2", "encryptedValue2"}
        };
            return configValues;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new CustomConfigProvider();
        }
    }
    public static class CustomConfigProviderExtensions
    {
        public static IConfigurationBuilder AddEncryptedProvider(this IConfigurationBuilder builder)
        {
            return builder.Add(new CustomConfigProvider());
        }
    }

    public class JsonConfigurationProvider2 : JsonConfigurationProvider
    {
        public JsonConfigurationProvider2(JsonConfigurationSource2 source) : base(source)
        {
        }

        public override void Load(Stream stream)
        {
            // Let the base class do the heavy lifting.
            base.Load(stream);

            // Do decryption here, you can tap into the Data property like so:
            Data["ConnectionStrings:default"] = "toto";// Data["ConnectionStrings:default"];

            // But you have to make your own MyEncryptionLibrary, not included here
        }
    }

    public class JsonConfigurationSource2 : JsonConfigurationSource
    {
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            EnsureDefaults(builder);
            return new JsonConfigurationProvider2(this);
        }
    }

    public static class JsonConfigurationExtensions2
    {
        public static IConfigurationBuilder AddJsonFile2(this IConfigurationBuilder builder, string path, bool optional, bool reloadOnChange)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("File path must be a non-empty string.");
            }

            var source = new JsonConfigurationSource2
            {
                FileProvider = null,
                Path = path,
                Optional = optional,
                ReloadOnChange = reloadOnChange
            };

            source.ResolveFileProvider();
            builder.Add(source);
            return builder;
        }
    }
}
