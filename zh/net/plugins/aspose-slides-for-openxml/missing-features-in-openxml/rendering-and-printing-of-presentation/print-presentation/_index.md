---
title: 打印演示文稿
type: docs
url: /zh/net/print-the-presentation/
---

Aspose.Slides for .NET 提供四个用于打印演示文稿的重载方法。这些方法足够灵活，可将演示文稿打印到默认打印机或任何可用的打印机，并使用自定义设置。您只需根据需求选择合适的打印方法。

## **打印到默认打印机**
在 Aspose.Slides for .NET 中，将演示文稿打印到默认打印机非常简单。执行以下步骤即可将演示文稿打印到默认打印机：

- 创建 Presentation 类的实例以加载要打印的演示文稿
- 调用 Presentation 对象公开的无参数 Print 方法

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

## **打印到特定打印机**
将演示文稿打印到特定打印机需要将打印机名称作为 Presentation 的 Print 方法的参数。执行以下步骤即可将演示文稿打印到所需的打印机：

- 创建 Presentation 类的实例以加载要打印的演示文稿
- 使用打印机名称作为字符串参数调用 Presentation 类的 Print 方法

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

## **下载示例代码**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)