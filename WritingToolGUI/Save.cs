using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace WritingToolGUI
{
    public class Save
    {
        public static void SaveAll()
        {

            string fileName = "All.json";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Item.itemsTotal, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static void SaveArchive()
        {
            string fileName = "Archive.json";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Item.itemsArchived, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
