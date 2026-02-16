/*Генератор пользовательского интерфейса
Создайте фабрику для UI-компонентов (кнопка, текстовое поле, чекбокс) в темной и светлой темах оформления.*/

using System;

//Конктретные фабрики
interface IButton { void Info(); }
interface ITextBox { void Info(); }
interface ICheckBox { void Info(); }

//Конкрентная продукция
class DarkButton : IButton
{
    public void Info() => Console.WriteLine("Темная Кнопка");
}

class DarkTextBox : ITextBox
{
    public void Info() => Console.WriteLine("Темный Текст");
}

class DarkCheckBox : ICheckBox
{
    public void Info() => Console.WriteLine("Темный Чекбокс");
}
class LightButton : IButton
{
    public void Info() => Console.WriteLine("Светлая Кнопка");
}

class LightTextBox : ITextBox
{
    public void Info() => Console.WriteLine("Светлый Текст");
}

class LightCheckBox : ICheckBox
{
    public void Info() => Console.WriteLine("Светлый Чекбокс");
}

//Абстрактная фабрика
interface IUiElementsFactory
{
    IButton CreateButton();
    ITextBox CreateTextBox();
    ICheckBox CreateCheckBox();
}

class DarkUiElementsFactory : IUiElementsFactory
{
    public IButton CreateButton() => new DarkButton();
    public ITextBox CreateTextBox() => new DarkTextBox();
    public ICheckBox CreateCheckBox() => new DarkCheckBox();
}

class LightUiElementsFactory : IUiElementsFactory
{
    public IButton CreateButton() => new LightButton();
    public ITextBox CreateTextBox() => new LightTextBox();
    public ICheckBox CreateCheckBox() => new LightCheckBox();
}

class UiElements
{
    public List<IButton> buttons = new List<IButton>();
    public List<ITextBox> textBoxes = new List<ITextBox>();
    public List<ICheckBox> checkBoxes = new List<ICheckBox>();

    public void AddButton(IButton button) => buttons.Add(button);
    public void AddTextBox(ITextBox textBox) => textBoxes.Add(textBox);
    public void AddCheckBox(ICheckBox checkBox) => checkBoxes.Add(checkBox);

    public void ShowInfo()
    {
        foreach (var button in buttons) button.Info();
        foreach (var textBox in textBoxes) textBox.Info();
        foreach (var checkBox in checkBoxes) checkBox.Info();
    }
}

class Ui
{
    public UiElements CreateUi (IUiElementsFactory factory)
    {
        var uiElements = new UiElements();
        uiElements.AddButton(factory.CreateButton());
        uiElements.AddTextBox(factory.CreateTextBox());
        uiElements.AddCheckBox(factory.CreateCheckBox());
        
        return uiElements;
    }
}

class Program
{
    static void Main()
    {
        Ui ui = new Ui();

        IUiElementsFactory darkFactory = new DarkUiElementsFactory();
        UiElements darkTheme = ui.CreateUi(darkFactory);

        IUiElementsFactory lightFactory = new LightUiElementsFactory();
        UiElements lightTheme = ui.CreateUi(lightFactory);

        Console.WriteLine("Темная тема:\n");
        darkTheme.ShowInfo();

        Console.WriteLine("\nСветлая тема:\n");
        lightTheme.ShowInfo();
    }
}




