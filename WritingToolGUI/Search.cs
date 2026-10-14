using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.CodeDom.Compiler;

namespace WritingToolGUI
{
    public class Search
    {
        private static List<Item> searchList = new List<Item>();
        public static List<Item> OrderByAlphabet()
        {
            searchList = Item.itemsTotal.OrderBy(item => item.Name).ToList();
            return searchList;
        }

        public static List<Item> OrderByDate()
        {
            searchList = Item.itemsTotal.OrderByDescending(item => item.Date).ToList();
            return searchList;
        }

        public static List<Item> SearchArchive()
        {
            searchList.Clear();
            searchList.AddRange(Item.itemsArchived);
            return searchList;
        }

        public static List<Item> SearchCharacter()
        {
            searchList.Clear();
            searchList = Item.itemsTotal.Where(item => item.Type == "Character").ToList();
            return searchList;
        }

        public static List<Item> SearchProject()
        {
            searchList.Clear();
            searchList = Item.itemsTotal.Where(item => item.Type == "Project").ToList();
            return searchList;
        }

        public static List<Item> SearchKeyWord(string keyword)
        {
            searchList = Item.itemsTotal.Where(item => item.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) 
            || item.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
            return searchList;
        }

        public static List<Item> RestoreDefaultList()
        {
            searchList.Clear();
            searchList.AddRange(Item.itemsTotal);
            return searchList;
        }
    }
}
