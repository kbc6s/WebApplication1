using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Net.Http;
using WebApplication1.Models;
using System.Web.Script.Serialization;
using System.IO;

namespace WebApplication1
{
    public partial class _default : System.Web.UI.Page
    {
        const string channelAccessToken = "!!!!! 改成自己的ChannelAccessToken !!!!!";
        const string AdminUserId= "!!!改成你的AdminUserId!!!";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //var bot = new Bot(channelAccessToken);
            //bot.PushMessage(AdminUserId, $"測試 {DateTime.Now.ToString()} ! ");


            HttpClient client = new HttpClient();
            string URL = "http://kaiwen1995.com:8086/query?db=lineBot;q=select * from lineBot where LineID='U8168367ec76c449dbdd98410d9333b8'";
            var response = client.GetAsync(URL).Result;
            /*
            var UserInfoFromDBParseJSON = new UserInfoFromDBParseJSON();
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            UserInfoFromDBParseJSON routes_list =
                   (UserInfoFromDBParseJSON)json_serializer.DeserializeObject(response.Content.ToString());
            UserInfoFromDBParseJSON = response.Headers;
            */
            using (var reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
            {
                string responseContent;
                responseContent = reader.ReadToEndAsync().Result;
                dynamic parse = JsonConvert.DeserializeObject(responseContent);
                var wer = parse.results[0].series[0].values[0][0];
                //中斷點
                int www = 123;
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, 1,2);
        }
    }
}