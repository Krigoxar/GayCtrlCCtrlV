using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Text.Json;

namespace GayCtrlCCtrlV
{
    internal static class VkParser
    {
        public static List<PostModel> ParsCurent(int count)
        {
            List<PostModel> list = new List<PostModel>();
            var options = new RestClientOptions("https://api.vk.com/method/wall.get?domain=studsovet_fksis&count=" + count + "&access_token=e47b8755e47b8755e47b875515e76bda39ee47be47b87558686bf8df746f8865cb20be1&v=5.131")
            {
                //FollowRedirects = false,
                Timeout = -1
            };
            var client = new RestClient(options);
            var request = new RestRequest();
            //request.AddHeader("Cookie", "remixaudio_show_alert_today=0; remixff=0; remixlang=0; remixlgck=51e5db992f1baa2967; remixstid=554277290_M0wQzeI3LdBz2U4PaCMVBwmGiCtky3inuZhEcmhgMr8; remixstlid=9085104395135144281_v2HofaDQHCZsFeP80wUtFWzWrCZFwXAftMQp3EhVYcz; remixua=-1%7C-1%7C-1%7C1578911645");
            RestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            if (response.Content != null)
            {
                ResponceModel person = JsonSerializer.Deserialize<ResponceModel>(response.Content);
                foreach (Dictionary<string, object> item in person.response.items)
                {
                    list.Add(new PostModel 
                    { 
                        Id = ((JsonElement)item["id"]).GetInt32(),
                        Text = ((JsonElement)item["text"]).GetString()
                    });
                }
            }
            else
            {
                return null;
            }
            return list;
        }
        public static PostModel GetpostFromId(int Id)
        {
            var options = new RestClientOptions("https://api.vk.com/method/wall.getById?&posts=-43180910_" + Id+"&access_token=e47b8755e47b8755e47b875515e76bda39ee47be47b87558686bf8df746f8865cb20be1&v=5.131")
            {
                //FollowRedirects = false,
                Timeout = -1
            };
            var client = new RestClient(options);
            var request = new RestRequest();
            request.AddHeader("Cookie", "remixaudio_show_alert_today=0; remixff=0; remixlang=0; remixlgck=51e5db992f1baa2967; remixstid=554277290_M0wQzeI3LdBz2U4PaCMVBwmGiCtky3inuZhEcmhgMr8; remixstlid=9085104395135144281_v2HofaDQHCZsFeP80wUtFWzWrCZFwXAftMQp3EhVYcz; remixua=-1%7C-1%7C-1%7C1578911645");
            RestResponse response = client.Execute(request);
            PostModel post = new PostModel();
            if (response.Content != null)
            {
                ResponceGetByid person = JsonSerializer.Deserialize<ResponceGetByid>(response.Content);
                foreach (Dictionary<string, object> item in person.response)
                {
                    post = new PostModel
                    {
                        Id = ((JsonElement)item["id"]).GetInt32(),
                        Text = ((JsonElement)item["text"]).GetString()
                    };
                }
            }
            else
            {
                return null;
            }
            IdsHendler.WriteId(post.Id);
            return post;
        }
    }
}
