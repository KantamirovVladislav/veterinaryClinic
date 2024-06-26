﻿using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Text.Json;

namespace veterinaryClinic.Model;

public class ConfigurationHelper
{
    private static readonly String _filePath = "configuration.Json";
    public static Configuraiton ReadFromJson()
    {
        if (CheckFileExists(_filePath))
        {
            using (FileStream fs = new FileStream(_filePath, FileMode.Open))
            {
                Configuraiton? conf = JsonSerializer.Deserialize<Configuraiton>(fs);
                if (conf == null)
                    throw new ArgumentException($"в файле {_filePath} не оказалось необходимого значения");
                return conf;
            }
            
        }
        WriteToJson(new Configuraiton());
        return new Configuraiton();
    }

    public static void WriteToJson(Configuraiton conf)
    {
        string jsonString = JsonSerializer.Serialize(conf);
        File.WriteAllText(_filePath, jsonString);
    }

    private static bool CheckFileExists(String filePath)
    {
        return File.Exists(filePath);
    }
}