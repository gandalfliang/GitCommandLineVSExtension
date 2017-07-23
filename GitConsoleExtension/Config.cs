using System;
using System.IO;
using Newtonsoft.Json;

namespace GitConsoleExtension
{
    internal class ConfigModel
    {
        public string MinttyPath { get; set; }
    }

    internal class Config
    {
        private static Config _instance;
        public static Config Instance => _instance ?? (_instance = new Config());

        private ConfigModel _config;

        private string ConfigFile
        {
            get
            {
                var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var configFile = Path.Combine(appdata, "GitConsoleExtension", "Config.conf");
                if (!File.Exists(configFile))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(configFile));
                    File.Create(configFile);
                }
                return configFile;
            }
        }

        public string MinttyPath
        {
            get { return _config.MinttyPath; }
            set
            {
                if (_config.MinttyPath != value)
                {
                    _config.MinttyPath = value;
                    SaveConfig();
                }
            }
        }

        private Config()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            try
            {
                var configs = File.ReadAllText(ConfigFile);
                if (!string.IsNullOrEmpty(configs))
                {
                    _config = JsonConvert.DeserializeObject<ConfigModel>(configs);
                }
                else
                {
                    _config=new ConfigModel();
                }
            }
            catch (Exception)
            {
                _config = new ConfigModel();
            }
        }

        private void SaveConfig()
        {
            try
            {
                var configs = JsonConvert.SerializeObject(_config);
                File.WriteAllText(ConfigFile, configs);
            }
            catch (Exception)
            {
            }
        }
    }
}
