using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiDuApi.entity.AccessToken
{
    public class AccessTokenEntity
    {
        /// <summary>
        ///  要获取的Access Token
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        ///  过期时间
        /// </summary>
        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }
        /// <summary>
        ///  错误码；关于错误码的详细信息请参考下方鉴权认证错误码。
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }
        /// <summary>
        ///  错误描述信息，帮助理解和解决发生的错误。
        /// </summary>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }


    }
}
