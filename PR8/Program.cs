/*Форматы документов и способы их сохранения
Создайте Document (абстракция) и SaveFormat (реализация), позволяя сохранять документы в разных форматах (TXT, PDF, DOCX).*/

public interface IDocument
{
    void Operation();
}

public class SaveTXT : IDocument
{
    public void Operation()
    {
        Console.WriteLine("txt");
    }
}

public class SavePDF : IDocument
{
    public void Operation()
    {
        Console.WriteLine("pdf");
    }
}

public class SaveDOCX : IDocument
{
    public void Operation()
    {
        Console.WriteLine("docx");
    }
}

public class Document
{
    protected IDocument document;

    public Document(IDocument document)
        => this.document = document;

    public virtual void Operation() 
        => document.Operation();
}

public class SaveFormat : Document
{
    public SaveFormat(IDocument document) : base(document) { }

    public override void Operation()
    {
        Console.Write("Документ сохранен в формате ");
        base.Operation();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IDocument txt = new SaveTXT();
        IDocument pdf = new SavePDF();
        IDocument docx = new SaveDOCX();

        Document documentA = new SaveFormat(txt);
        Document documentB = new SaveFormat(pdf);
        Document documentC = new SaveFormat(docx);

        documentA.Operation();
        documentB.Operation();
        documentC.Operation();
    }
}