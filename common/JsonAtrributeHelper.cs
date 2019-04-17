using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaiDuApi.common
{
    public class JsonAtrributeHelper
    {
        public static List<KeyValuePair<string, string>> InputRequestParm<T>(T dto)
        {
            List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
            foreach (PropertyInfo item in dto.GetType().GetProperties())
            {
                var attribute = (JsonPropertyAttribute)item.GetCustomAttribute(typeof(JsonPropertyAttribute), false);
                var key = string.Empty;
                if (key != null)
                    key = attribute.PropertyName;
                else
                    key = item.Name;
                var value = Convert.ToString(item.GetValue(dto));
                if (!string.IsNullOrEmpty(value))
                {
                    paraList.Add(new KeyValuePair<string, string>(key, value));
                }
            }
            return paraList;
        }
    }
}
