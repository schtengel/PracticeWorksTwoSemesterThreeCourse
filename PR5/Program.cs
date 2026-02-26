/*Копирование документов
Создайте механизм клонирования документов (Document), содержащих текст, изображения и метаданные.*/

public interface IPrototype
{
    IPrototype Clone();
}

public class Document : IPrototype
{
    public string Title { get; set; }
    public int Pages { get; set; }
    public List<string> Content { get; set; } = new List<string>();

    public Document(string title, int pages)
    {
        Title = title; Pages = pages;
    }

    public IPrototype Clone()
    {
        Document clone = new Document(Title, Pages)
        {
            Content = new List<string>(Content)
        };

        return clone;
    }

    public void Display()
    {
        Console.WriteLine($"Документ: {Title}, Количество страниц: {Pages}, Контент: {string.Join(", ", Content)}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Document original = new Document("Пособие по облысению", 1489);
        original.Content.Add("kl");
        original.Content.Add(" g");

        Console.WriteLine("Оригинальный документ: ");
        original.Display();

        Document clone = (Document)original.Clone();
        clone.Title = "Пособие по безработице";
        clone.Content.Add("ji");
        clone.Content.Add("ji");

        Console.WriteLine("\nКлон документа: ");
        clone.Display();

        Console.WriteLine("\nОригинальный документ после клонирования: ");
        original.Display();
    }
}