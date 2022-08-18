using RestSharp;
using System.Text.Json;
using System.Collections.Generic;


namespace GayCtrlCCtrlV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GachiConverter gachiConverter = new GachiConverter(@"Dict.txt");
            foreach (int id in IdsHendler.FindUnpostedPostsIds())
            {
                string str = VkParser.GetpostFromId(id).Text;
                Console.WriteLine(gachiConverter.ConvertToGachi(str));
            }
            Console.ReadLine();
            
        }
    }
}