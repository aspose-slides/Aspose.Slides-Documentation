---
title: Печать презентации
type: docs
url: /ru/net/print-the-presentation/
---

Aspose.Slides for .NET предоставляет четыре перегруженных метода для печати презентаций. Эти методы достаточно гибкие, чтобы печатать презентацию на принтере по умолчанию или на любом из доступных принтеров с пользовательскими настройками. Вам просто нужно выбрать соответствующий метод печати в соответствии с требованием.

## **Печать на принтер по умолчанию**
Печать презентации на принтер по умолчанию в Aspose.Slides for .NET достаточно проста. Выполните следующие шаги, чтобы распечатать презентацию на принтере по умолчанию:

- Создайте экземпляр класса Presentation, чтобы загрузить презентацию, которую требуется распечатать
- Вызовите метод Print без параметров, как предоставлено объектом Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Load the presentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Call the print method to print whole presentation to the default printer

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Load the presentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Call the print method to print whole presentation to the desired printer

    asposePresentation.Print("LaserJet1100");


``` 

## **Печать на конкретный принтер**
Печать презентации на конкретный принтер требует указания имени принтера в качестве параметра метода Print класса Presentation. Выполните следующие шаги, чтобы распечатать презентацию на нужном принтере:

- Создайте экземпляр класса Presentation, чтобы загрузить презентацию, которую требуется распечатать
- Вызовите метод Print класса Presentation, передав имя принтера в виде строки параметра

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Load the presentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Call the print method to print whole presentation to the desired printer

    asposePresentation.Print("LaserJet1100");

}

``` 

## **Скачать пример кода**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)