using System;
using System.Collections.Generic;
using System.Text;

namespace LAB09
{
    public class Widget
    {
        private int width;
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Ширина должна быть положительной.");
                }
                width = value;
            }
        }
        private int height;
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Высота должна быть положительной.");
                }
                height = value;
            }
        }
        public string Caption { get; set; }
        public Widget(int width, int height, string caption)
        {
            Width = width;
            Height = height;
            Caption = caption;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: '{Caption}', " +
                $"Размер: {Width}x{Height}";
        }
    }
}
