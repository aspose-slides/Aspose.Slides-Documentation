---
title: 在 VSTO 和 Aspose.Slides 中打开演示文稿
type: docs
weight: 120
url: /zh/net/opening-a-presentation-in-vsto-and-aspose-slides/
---

## **VSTO**
以下是打开演示文稿的代码片段：

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides for .NET 提供了用于打开现有演示文稿的 **Presentation** 类。它提供了几个重载构造函数，我们可以使用 **Presentation** 类的合适构造函数之一基于现有演示文稿创建对象。在下面的示例中，我们将要打开的演示文稿文件名传递给 Presentation 类的构造函数。文件打开后，我们获取演示文稿中幻灯片的总数并在屏幕上打印。

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **下载运行代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)