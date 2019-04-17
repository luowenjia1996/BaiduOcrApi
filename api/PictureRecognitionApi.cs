using BaiDuApi.common;
using BaiDuApi.entity.PictrueRecognition;
using BaiDuApi.PictrueRecognition.entity;
using ICP.Framework.CommonLibrary;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace BaiDuApi.api
{
    public class PictureRecognitionApi
    {
        /// <summary>
        /// 网图接收数据
        /// </summary>
        /// <param name="dto">发送请求的实体</param>
        /// <param name="AccessToken">获取的AccessToken</param>
        /// <returns></returns>
        public static WebImageResponseEntity WebImageDiscriminate(WebImageDto dto,string AccessToken)
        {
            try
            {
                String authHost = "https://aip.baidubce.com/rest/2.0/ocr/v1/webimage" + "?access_token=" + AccessToken;
                using (HttpClient client = new HttpClient())
                {
                    var paraList = JsonAtrributeHelper.InputRequestParm(dto);
                    using (HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result)
                    {
                        String result = response.Content.ReadAsStringAsync().Result;
                        var reponseEntity = JsonConvert.DeserializeObject<WebImageResponseEntity>(result);
                        return reponseEntity;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                LogHelper.SaveLog(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 图片文字识别通用(精确版)
        /// </summary>
        /// <param name="dto">发送请求的实体</param>
        /// <param name="AccessToken">获取的AccessToken</param>
        /// <returns></returns>
        public static WebImageResponseEntity WebImagePrecise(WebImageDto dto, string AccessToken)
        {
            try
            {
                String authHost = "https://aip.baidubce.com/rest/2.0/ocr/v1/accurate_basic" + "?access_token=" + AccessToken;
                using (HttpClient client = new HttpClient())
                {
                    var paraList = JsonAtrributeHelper.InputRequestParm(dto);
                    using (HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result)
                    {
                        String result = response.Content.ReadAsStringAsync().Result;
                        var reponseEntity = JsonConvert.DeserializeObject<WebImageResponseEntity>(result);
                        return reponseEntity;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                LogHelper.SaveLog(ex.Message);
                return null;
            }
        }
    }
}
