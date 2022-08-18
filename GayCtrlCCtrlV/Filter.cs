using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GayCtrlCCtrlV
{
    internal static class Filter
    {

        public static List<int> FindUnpostedPostsIds()
        {
            string path = @"C:\Users\256bit.by\source\repos\GayCtrlCCtrlV\GayCtrlCCtrlV\PostedPostsList.txt";
            List<int> ids = new List<int>();
            List<PostModel> Posts = VkParser.ParsCurent(10);

            foreach (PostModel post in Posts)
            {
                bool IsPosted = false;
                string? line;
                using (StreamReader reader = new StreamReader(path))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == post.Id.ToString())
                        {
                            IsPosted = true;
                        }
                    }
                }
                if(IsPosted == false)
                {
                    ids.Add(Convert.ToInt32(post.Id));
                }
            }

            return ids;
        }
    }
}
