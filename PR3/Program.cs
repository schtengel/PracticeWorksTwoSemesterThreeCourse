/*Создание документов
Реализуйте фабричный метод для генерации документов (PDFDocument, WordDocument, TextDocument).*/

interface IDocument
{
    void Info();
}

class Pdf : IDocument
{
    public void Info() => Console.WriteLine("PDF-Документ");
}

class Word : IDocument
{
    public void Info() => Console.WriteLine("Word-Документ");
}

class Text : IDocument
{
    public void Info() => Console.WriteLine("TXT-Документ");
}

abstract class DocumentFactory
{
    public abstract IDocument FactoryMethod();

    public void InfoGoods()
    {
        IDocument document = FactoryMethod();
        document.Info();
    }
}

class PdfFactory : DocumentFactory
{
    public override IDocument FactoryMethod()
    {
        return new Pdf();
    }
}

class WordFactory : DocumentFactory
{
    public override IDocument FactoryMethod()
    {
        return new Word();
    }
}

class TextFactory : DocumentFactory
{
    public override IDocument FactoryMethod()
    {
        return new Text();
    }
}

class Client
{
    public static void Main()
    {
        DocumentFactory pdfFactory = new PdfFactory();
        DocumentFactory wordFactory = new WordFactory();
        DocumentFactory textFactory = new TextFactory();

        pdfFactory.InfoGoods();
        wordFactory.InfoGoods();
        textFactory.InfoGoods();

    }
}