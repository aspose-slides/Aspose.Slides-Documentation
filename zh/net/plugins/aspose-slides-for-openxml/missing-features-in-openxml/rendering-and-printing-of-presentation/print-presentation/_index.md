---
title: 打印演示文稿
type: docs
url: /zh/net/print-the-presentation/
---

Aspose.Slides for .NET 提供了四个用于打印演示文稿的重载方法。这些方法足够灵活，可以将演示文稿打印到默认打印机或任何可用的打印机，并带有自定义设置。您只需根据需求选择合适的打印方法。
## **打印到默认打印机**
在 Aspose.Slides for .NET 中，打印演示文稿到默认打印机非常简单。请按照以下步骤将演示文稿打印到默认打印机：

- 创建一个 Presentation 类的实例，以加载要打印的演示文稿
- 调用 Presentation 对象暴露的无参数的 Print 方法

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //加载演示文稿

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //调用打印方法将整个演示文稿打印到默认打印机

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //加载演示文稿

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //调用打印方法将整个演示文稿打印到所需的打印机

    asposePresentation.Print("LaserJet1100");


``` 
## **打印到特定打印机**
将演示文稿打印到特定打印机需要将打印机的名称作为参数传递给 Presentation 的 Print 方法。请按照以下步骤将演示文稿打印到所需的打印机：

- 创建一个 Presentation 类的实例，以加载要打印的演示文稿
- 调用 Presentation 类的 Print 方法，并将打印机名称作为字符串参数传递给 Print 方法

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //加载演示文稿

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //调用打印方法将整个演示文稿打印到所需的打印机

    asposePresentation.Print("LaserJet1100");

}

``` 
## **下载示例代码**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)