using System;
using System.Collections.Generic;
using System.Text;

namespace LAB09
{
    public class Grid : Widget, IResizable
    {
        private int rows;
        public int Rows
        {
            get
            {
                return rows;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Размеры должны быть положительными");
                }
                rows = value;
            }
        }
        private int columns;
        public int Columns
        {
            get
            {
                return columns;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Размеры должны быть положительными");
                }
                columns = value;
            }
        }
        private Widget[,] elements;
        public Grid(int width, int height, string caption, int rows, int columns) : base(width, height, caption)
        {
            Rows = rows;
            Columns = columns;
            elements = new Widget[rows, columns];
        }
        public void AddToGrid(Widget w, int row, int column)
        {
            if (w == null)
            {
                throw new ArgumentException("Нельзя добавить пустой элемент.");
            }
            else if (row < 0 || row >= Rows || column < 0 || column >= Columns)
            {
                throw new ArgumentException("Элемент находится вне допустимых параметров.");
            }
            else if (elements[row, column] != null)
            {
                throw new ArgumentException("Ячейка уже занята.");
            }
            else
            {
                elements[row, column] = w;
                Console.WriteLine($"В {Caption} добавлен элемент {w.GetType().Name}");
            }
        }
        public void DeleteFromGrid(Widget w)
        {
            if (w == null)
            {
                throw new ArgumentException("Нельзя удалить null.");
            }

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (elements[i, j] == w)
                    {
                        elements[i, j] = null;
                        Console.WriteLine($"В {Caption} удален элемент {w.GetType().Name}.");
                        return;
                    }
                }
            }

            throw new ArgumentException("Элемент не найден.");
        }
        public void ShowAllElements()
        {
            Console.WriteLine($"---{Caption}---");

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Widget w = elements[i, j];
                    if (w == null)
                    {
                        Console.WriteLine($"[{i}, {j}]: пусто.");
                    }
                    else
                    {
                        Console.WriteLine($"[{i}, {j}]: {w}");
                    }
                }
            }
        }
        public bool NeedResize(int newRows, int newColumns)
        {
            if (newRows <= 0 || newColumns <= 0)
            {
                throw new ArgumentException("Размеры должны быть положительными.");
            }

            return newRows != Rows || newColumns != Columns;
        }
        public void Resize(int newWidth, int newHeight)
        {
            if (newWidth <= 0 || newHeight <= 0)
            {
                throw new ArgumentException("Размеры окна должны быть положительными.");
            }

            Width = newWidth;
            Height = newHeight;
            Console.WriteLine($"В {Caption} окно изменено до {Width}x{Height}.");

            foreach (Widget el in elements)
            {
                if (el is IResizable resizedEl)
                {
                    resizedEl.Resize(newWidth / Columns, newHeight / Rows);
                }
            }
        }
        public override string ToString()
        {
            return base.ToString() + $", Grid={Rows}x{Columns}";
        }
    }
}
