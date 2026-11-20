using System;
using System.Collections.Generic;
using System.Text;

namespace LAB09
{
    public class TextView : Widget, IResizable
    {
        public int MaxLength { get; set; }
        public string Text { get; set; }
        public TextView(int width, int height, string caption, int maxLength, string text) : base(width, height, caption)
        {
            MaxLength = maxLength;
            Text = text;
        }
        public void Resize(int newWidth, int newHeight)
        {
            Width = newWidth;
            Height = newHeight;
            Console.WriteLine($"Размер {Caption} изменён на {Width}x{Height}");
        }
        public void SetText(string newText)
        {
            if (newText.Length > MaxLength)
            {
                throw new ArgumentException($"Текст не может быть более {MaxLength} символов.");
            }
            else
            {
                Text = newText;
                Console.WriteLine($"Установлен текст: '{Text}'");
            }
        }
        public override string ToString()
        {
            return base.ToString() + $", Текст на поле: {Text}";
        }
    }
}
