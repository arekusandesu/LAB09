
using LAB09;

Grid window = new Grid(800, 600, "Main Window", 2, 2);

Button btnOk = new Button(100, 30, "btn1", "OK", true);
Button btnCancel = new Button(100, 30, "btn2", "Cancel", false);
TextView txt = new TextView(200, 50, "txt1", 50, "Hello");

List<string> items = new List<string> { "C#", "Java", "Python" };
DropDown dd = new DropDown(150, 30, "dd1", items);

Console.WriteLine("1. Добавление в сетку.");
try
{
    window.AddToGrid(btnOk, 0, 0);
    window.AddToGrid(btnCancel, 0, 1);
    window.AddToGrid(txt, 1, 0);
    window.AddToGrid(dd, 1, 1);
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка при добавлении: {ex.Message}");
}

Console.WriteLine("\n2. Вывод всех элементов сетки.");
window.ShowAllElements();

Console.WriteLine("\n3. Попытка занять уже занятую ячейку.");
try
{
    window.AddToGrid(new Button(50, 20, "btn3", "Extra", true), 0, 0);
}
catch (Exception ex)
{
    Console.WriteLine($"Поймано исключение: {ex.Message}");
}

Console.WriteLine("\n4. Попытка добавить вне границ.");
try
{
    window.AddToGrid(new Button(50, 20, "btn4", "OutOfBounds", true), 2, 2);
}
catch (Exception ex)
{
    Console.WriteLine($"Поймано исключение: {ex.Message}");
}

Console.WriteLine("\n5. Тестирование кнопок (Click).");
btnOk.Click();
btnOk.Click();
btnCancel.Click();

Console.WriteLine("\n6. Тестирование текстового поля (SetText).");
try
{
    txt.SetText("Короткий текст.");
    txt.SetText("Оооооооооооооооооооооооооооооооооочень длинный текст.");
}
catch (Exception ex)
{
    Console.WriteLine($"Поймано исключение: {ex.Message}");
}

Console.WriteLine("\n7. Тестирование DropDown.");
dd.Click();

Console.WriteLine($"Добавление C++: {dd.AddItem("C++")}");
Console.WriteLine($"Добавление C#: {dd.AddItem("C#")}");
Console.WriteLine($"Добавление null: {dd.AddItem(null)}");

Console.WriteLine($"Выбор Java: {dd.SelectItem("Java")}");
Console.WriteLine($"Выбор Ruby: {dd.SelectItem("Ruby")}"); 

dd.Click();

Console.WriteLine("\n8. Проверка NeedResize.");
Console.WriteLine($"Нужно ли менять на 1x1? {window.NeedResize(1, 1)}");
Console.WriteLine($"Нужно ли менять на 3x3? {window.NeedResize(3, 3)}");
Console.WriteLine($"Нужно ли менять на 2x2? {window.NeedResize(2, 2)}");

Console.WriteLine("\n9. Изменение размера окна и элементов.");
window.Resize(1024, 768);

Console.WriteLine("\n10. Вывод после изменений.");
window.ShowAllElements();

Console.WriteLine("\n11. Удаление элемента.");
window.DeleteFromGrid(btnCancel);
window.ShowAllElements();
