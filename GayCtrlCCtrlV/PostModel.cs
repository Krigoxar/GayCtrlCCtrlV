using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GayCtrlCCtrlV
{
    internal class ResponceModel
    {
        public ResponceModel()
        {
            
        }
        public Responce response { get; set; }
    }

    public class Responce 
    {
        public int count { get; set; }
        public Dictionary<string, object>[] items { get; set; }
    }

    public class PostModel
    {
        public PostModel()
        {

        }
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
