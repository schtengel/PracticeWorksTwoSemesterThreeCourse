/*Редактор текста (операции с текстом)
Создайте ICommand, WriteTextCommand, DeleteTextCommand, UndoCommand, TextEditor, чтобы реализовать механизм редактирования текста с возможностью отмены.*/

using System;
using System.Collections.Generic;

public interface ICommand
{
    void Execute();
}

public class TextEditor
{
    private string _text = "";
    private Stack<string> _history = new Stack<string>();

    public Stack<string> History { get { return _history; } }

    public string Text
    {
        get { return _text; }
        set
        {
            _history.Push(_text);
            _text = value;
        }
    }

    public void Undo()
    {
        if(_history.Count > 0 )
        {
            _text = _history.Pop();
        }
        else
        {
            Console.WriteLine("Нет действия для отмены.");
        }
    }

    public void ShowText()
    {
        Console.WriteLine($"Текущий текст: {_text}");
    }
}

public class WriteTextCommand : ICommand
{
    private readonly TextEditor _editor;
    private string _newText;

    public WriteTextCommand(TextEditor editor, string newText)
    {
        _editor = editor;
        _newText = newText;
    }

    public void Execute()
    {
        _editor.Text = _newText;
        Console.WriteLine($"Запись текста: {_newText}");
    }
}

public class DeleteTextCommand : ICommand
{
    private TextEditor _editor;

    public DeleteTextCommand(TextEditor editor)
        { _editor = editor; }

    public void Execute()
    {
        _editor.Text = "";
        Console.WriteLine("Текст удалён");
    }
}

public class UndoCommand : ICommand
{
    private TextEditor _editor;

    public UndoCommand(TextEditor editor)
    { _editor = editor; }

    public void Execute()
    {
        _editor.Undo();
        Console.WriteLine("Отмена последнего действия.");
    }
}

public class Invoker
{
    private ICommand _command;

    public void SetCommand(ICommand command) 
    { _command = command; }

    public void ExecuteCommand()
        { _command?.Execute(); }
}

class Program
{
    static void Main(string[] args)
    {
        TextEditor editor = new TextEditor();
        Invoker invoker = new Invoker();

        Console.WriteLine("Введите начальный текст: ");
        string initialText = Console.ReadLine();
        editor.Text = initialText;

        

        while (true)
        {
            Console.WriteLine("Выберите команду: ");
            Console.WriteLine("1. Изменение текста");
            Console.WriteLine("2. Удаление текста");
            Console.WriteLine("3. Отмена действия");
            Console.WriteLine("4. Выход");

            int i = Console.Read();

            switch(i)
            {
                case 1:
                    Console.WriteLine("\nВведите новый текст для записи: ");
                    string newText = Console.ReadLine();

                    ICommand write = new WriteTextCommand(editor, newText);

                    invoker.SetCommand(write);
                    invoker.ExecuteCommand();
                    editor.ShowText();
                    break;
                case 2:
                    ICommand delete = new DeleteTextCommand(editor);
                    invoker.SetCommand(delete);
                    invoker.ExecuteCommand();
                    editor.ShowText();
                    break;
                case 3:
                    ICommand undo = new UndoCommand(editor);
                    invoker.SetCommand(undo);
                    invoker.ExecuteCommand();
                    editor.ShowText();
                    break;
                case 4:
                    Console.WriteLine("История изменений: ");
                    Console.WriteLine(editor.History.ToArray()); 
                    break;
                case 5:
                    Console.WriteLine("Выход с программы...");
                    Environment.Exit(0);
                    break;
                case 0:
                    Console.WriteLine("Введен неверный символ");
                    break;
            }
        }
    }
}