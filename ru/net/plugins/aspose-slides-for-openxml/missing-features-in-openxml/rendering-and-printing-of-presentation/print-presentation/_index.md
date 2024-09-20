---
title: Печать презентации
type: docs
url: /net/print-the-presentation/
---

Aspose.Slides для .NET предоставляет четыре перегруженные метода для печати презентаций. Эти методы достаточно гибкие, чтобы печатать презентацию на默认ный принтер или на любой доступный принтер с настраиваемыми параметрами. Вам просто нужно выбрать подходящий метод печати в зависимости от требований.
## **Печать на стандартный принтер**
Печать презентации на стандартный принтер довольно проста в Aspose.Slides для .NET. Выполните следующие шаги, чтобы распечатать презентацию на стандартный принтер:

- Создайте экземпляр класса Presentation для загрузки презентации, которую необходимо распечатать
- Вызовите метод Print без параметров, который предоставляется объектом Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Загрузите презентацию

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Вызовите метод печати для распечатки всей презентации на стандартный принтер

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Загрузите презентацию

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Вызовите метод печати для распечатки всей презентации на нужном принтере

    asposePresentation.Print("LaserJet1100");


``` 
## **Печать на конкретный принтер**
Печать презентации на конкретный принтер требует имени принтера в качестве параметра для метода Print класса Presentation. Выполните следующие шаги, чтобы распечатать презентацию на нужном принтере:

- Создайте экземпляр класса Presentation для загрузки презентации, которую необходимо распечатать
- Вызовите метод Print класса Presentation с именем принтера в качестве строкового параметра метода Print

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Загрузите презентацию

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Вызовите метод печати для распечатки всей презентации на нужном принтере

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Скачать пример кода**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)