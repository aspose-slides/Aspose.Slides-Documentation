---
title: Печать презентации
type: docs
url: /ru/net/print-the-presentation/
---

Aspose.Slides for .NET предоставляет четыре перегруженных метода для печати презентаций. Эти методы достаточно гибки, чтобы печатать презентацию на принтере по умолчанию или на любом доступном принтере с пользовательскими настройками. Вам нужно лишь выбрать подходящий метод печати в соответствии с требованием.
## **Печать на принтер по умолчанию**
Печать презентации на принтер по умолчанию в Aspose.Slides for .NET довольно проста. Выполните следующие шаги, чтобы распечатать презентацию на принтере по умолчанию:

- Создайте экземпляр класса Presentation, чтобы загрузить презентацию, подлежащую печати
- Вызовите метод Print без параметров, предоставляемый объектом Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Загрузить презентацию

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Вызвать метод печати для печати всей презентации на принтере по умолчанию

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Загрузить презентацию

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Вызвать метод печати для печати всей презентации на выбранном принтере

    asposePresentation.Print("LaserJet1100");


``` 
## **Печать на конкретный принтер**
Печать презентации на конкретный принтер требует указания имени принтера в качестве параметра метода Print класса Presentation. Выполните следующие шаги, чтобы распечатать презентацию на нужном принтере:

- Создайте экземпляр класса Presentation, чтобы загрузить презентацию, подлежащую печати
- Вызовите метод Print класса Presentation, передав имя принтера в виде строкового параметра

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Загрузить презентацию

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Вызвать метод печати для печати всей презентации на выбранном принтере

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Скачать пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)