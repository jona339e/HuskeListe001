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
        public string path = @"C:\MyDir\HuskeListeData.json";
        public void SaveData(Data data)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(path, json);
        }

        public void LoadData(Data data)
        {
            string json = File.ReadAllText(path);
            data = System.Text.Json.JsonSerializer.Deserialize<Data>(json);

        }
    }
}
