using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace Instagram.Sources
{
    class InstaHelper
    {

      

        public async Task<string> GetAccessToken()
        {


            String OAuthConsumerSecret = "J37DU9A32JMqqD3RoJc8kEkvsR0zn29OtDNcAMy6r53VEbyrKm";
            String OAuthConsumerKey = "2uOSZWoBGOND11pfU6UH0oAOr";
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.twitter.com/oauth2/token ");
            var customerInfo = Convert.ToBase64String(new UTF8Encoding().GetBytes(OAuthConsumerKey + ":" + OAuthConsumerSecret));
            request.Headers.Add("Authorization", "Basic " + customerInfo);
            request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage response = await httpClient.SendAsync(request);

            string json = await response.Content.ReadAsStringAsync();
            var serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(json);
            return item["access_token"];

            //string oauthUrl = string.Format("https://api.instagram.com/oauth/authorize/?client_id={0}&redirect_uri={1}&response_type=token", ClientID,RedirectURI);
            //WebClient client = new WebClient();

            //var accessToken = client.DownloadString(oauthUrl);

            //return accessToken;

        }


        public async Task<dynamic> getComments(string accessToken = null)
        {


            if (accessToken == null)
            {
                accessToken = await GetAccessToken();
            }


            // https://api.instagram.com/v1/media/{media-id}/comments?access_token=ACCESS-TOKEN
            var requestComments = "https://api.instagram.com/v1/media/{media-id}/comments?access_token=3959901571.ab21c51.19f116295fb743a4aadcc6c0bd5d28f2";
            WebClient httpClient = new WebClient();
            var result = httpClient.DownloadString(requestComments);

            dynamic userinfo = JsonConvert.DeserializeObject(result);
            return userinfo;
        }


    }


}
