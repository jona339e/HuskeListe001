using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuskeListe001
{
    internal class SaveLoad
    {
        private string path;

        public SaveLoad(string path)
        {
            this.path = path;
        }

        public void SaveData(Data data)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(path, json);
        }

        public Data LoadData(Data data)
        {
            string json = File.ReadAllText(path);
            data = System.Text.Json.JsonSerializer.Deserialize<Data>(json);
            return data;

        }

        public bool PathExists()
        {
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
