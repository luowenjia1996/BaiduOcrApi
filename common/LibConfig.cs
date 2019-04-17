using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaiDuApi.common
{
    public class LibConfig
    {
        /// <summary>
        /// 根据名称找到类库的配置文件
        /// </summary>
        /// <param name="fullName">根据指定的文件名</param>
        /// <returns></returns>
        public static Configuration InitConfig(string fullName)
        {
            string baesePath = AppDomain.CurrentDomain.RelativeSearchPath;          
            string path = string.Format(@"{0}\{1}.dll.config", baesePath, fullName);
            if (File.Exists(path) == false)
            {
                string msg = string.Format("{0}路径下的文件未找到 ", path);
                throw new FileNotFoundException(msg);
            }
            try
            {
                ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
                configFile.ExeConfigFilename = path;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
                return config;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 根据名称找到类库的配置文件
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static Configuration InitConfig()
        {
            string baesePath = AppDomain.CurrentDomain.BaseDirectory;
            string fullName = Assembly.GetExecutingAssembly().GetName().Name;
            string path = string.Format(@"{0}\{1}.dll.config", baesePath, fullName);
            if (File.Exists(path) == false)
            {
                string msg = string.Format("{0}路径下的文件未找到 ", path);
                throw new FileNotFoundException(msg);
            }
            try
            {
                ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
                configFile.ExeConfigFilename = path;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
                return config;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
