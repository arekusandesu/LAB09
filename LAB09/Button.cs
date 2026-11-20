using System;
using System.Collections.Generic;
using System.Text;

namespace LAB09
{
    public class Button : Widget, IClickable, IResizable
    {
        public string Text { get; set; }
        public bool IsEnabled { get; set; }
        public Button(int width, int height, string caption, string text, bool isEnabled) : base(width, height, caption)
        {
            Text = text;
            IsEnabled = isEnabled;
        }
        public void Click()
        {
            if (!IsEnabled)
            {
                Console.WriteLine("Кнопка отключена.");
            }
            else
            {
                Console.WriteLine("Кнопка включена");
            }
        }
        public void Resize(int newWidth, int newHeight)
        {
            Width = newWidth; 
            Height = newHeight;
            Console.WriteLine($"Размер {Caption} изменён на {Width}x{Height}");
        }
        public override string ToString()
        {
            return base.ToString() + $", Текст на кнопке: {Text}" +
                $", Активна ли: {IsEnabled}";
        }
    }
}
