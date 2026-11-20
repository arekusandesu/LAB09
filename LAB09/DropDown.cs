using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace LAB09
{
    public class DropDown : Widget, IClickable
    {
        public List<string> Items { get; set; }
        public string SelectedItem { get; set; }
        public DropDown(int width, int height, string caption, List<string> items) : base(width, height, caption)
        {
            Items = items;
            SelectedItem = "не выбран.";
        }
        public void Click()
        {
            Console.WriteLine("Список: ");
            if (Items.Count == 0)
            {
                Console.WriteLine("пусто.");
                return;
            }

            foreach (string item in Items)
            {
                Console.WriteLine($"{item}");
            }
        }
        public bool AddItem(string item)
        {
            if (item == null)
            {
                return false; 
            }

            foreach(string it in Items)
            {
                if (it == item)
                {
                    return false;
                }
            }

            Items.Add(item);
            return true;
        }
        public bool SelectItem(string item)
        {
            if (item == null)
            {
                return false;
            }

            foreach (string it in Items)
            {
                if (it == item)
                {
                    SelectedItem = item;
                    return true;
                }
            }

            return false;
        }
        public override string ToString()
        {
            string itemsText = "";
            foreach (string item in Items)
            {
                itemsText += item + ", ";
            }

            return base.ToString() + $", Список вариантов: {itemsText}" +
                $"Выбранный вариант: {SelectedItem}";                      
        }
    }
}
