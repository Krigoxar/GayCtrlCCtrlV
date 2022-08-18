using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GayCtrlCCtrlV
{
    internal class GachiConverter
    {
        public GachiConverter(string path)
        {
            Dict = feelDict(path);
        }
        private MultikeyDict feelDict(string path)
        {
            MultikeyDict dict = new MultikeyDict();
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('=');
                    string value = parts[0];
                    string[] keys = parts[1].Split(',');
                    foreach(string key in keys)
                    {
                        dict.Add(key,value);
                    }
                }
            }
            return dict;
        }
        private MultikeyDict Dict;
        public string ConvertToGachi(string input)
        {
            string output = input;
            foreach(KeyNode keyNode in Dict.AllKeys)
            {
                output = output.Replace(keyNode.Key, keyNode.Value.Value);
            }
            return output;
        }

    }
    public class MultikeyDict
    {
        public List<KeyNode> AllKeys = new List<KeyNode>();
        private List<ValueNode> AllValues = new List<ValueNode>();
        private bool IsValueExist(List<ValueNode> valueNodes, string valueNode)
        {
            foreach(ValueNode node in valueNodes)
            {
                if(node.Value == valueNode)
                {
                    return true;
                }
            }
            return false;
        }
        public void Add(string Key,string Value)
        {
            if(IsValueExist(AllValues,Value))
            {
                AllKeys.Add(new KeyNode(Key, AllValues.Find(x => x.Value.Contains(Value))));
            }
            else
            {
                ValueNode valueNode = new ValueNode(Value);
                AllKeys.Add(new KeyNode(Key, valueNode));
                AllValues.Add(valueNode);
            }
        }
        public string GetFromKey(string Key)
        {
            foreach(KeyNode KeyNode in AllKeys)
            {
                if(KeyNode.Key == Key)
                {
                    return KeyNode.Value.Value;
                }
            }
            return null;
        }
    }
    public class KeyNode
    {
        public KeyNode(string Key, ValueNode valueNode)
        {
            this.Key = Key;
            this.Value = valueNode;
        }
        public string Key { get; set; }
        public ValueNode Value { get; set; }
    }
    public class ValueNode
    {
        public ValueNode(string Value)
        {
            this.Value = Value;
        }
        public string Value { get; set; }
    }
}
