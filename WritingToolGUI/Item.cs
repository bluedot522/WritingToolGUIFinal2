using System;
using System.Collections.Generic;
using System.Text;

namespace WritingToolGUI
{
    public class Item
    {
        public static List<string> itemType = new List<string>();
        public static List<Item> itemsTotal = new List<Item>();

        public static List<Item> itemsArchived = new List<Item>();

        public string Name
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public List<string> Tags
        {
            get; set;
        }

        public string Date
        {
            get; set;
        }
        public string Status
        {
            get; set;
        }
        public string Type
        {
            get; set;
        }
        public virtual void CreateNew()
        {

        }

        public static void Delete(Item item)
        {
            itemsTotal.Remove(item);
        }

        public static void Edit(Item item, string newName, string newDescription, List<string> newTags)
        {
            item.Name = newName;
            item.Description = newDescription;
            item.Tags = newTags;
        }
    }
}
