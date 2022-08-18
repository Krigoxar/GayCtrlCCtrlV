using RestSharp;
using System.Text.Json;
using System.Collections.Generic;


namespace GayCtrlCCtrlV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach(int id in Filter.FindUnpostedPostsIds())
            {
                Console.WriteLine(id);
            }
        }
    }
}