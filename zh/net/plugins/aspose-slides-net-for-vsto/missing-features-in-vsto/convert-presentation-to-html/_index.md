---
title: 转换演示文稿为 HTML
type: docs
weight: 40
url: /net/convert-presentation-to-html/
---

**HTML** 是用于交换数据的几种广泛使用格式之一。**Aspose.Slides for .NET** 提供了将演示文稿转换为 HTML 的支持。以下是一个代码片段，展示了如何进行转换。
## **示例**
``` 

 //实例化一个表示演示文稿文件的 Presentation 对象

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//保存演示文稿为 HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **下载运行示例**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Converting to HTML/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **下载示例代码**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

有关更多详细信息，请访问 [转换演示文稿为 HTML](/slides/net/convert-powerpoint-ppt-and-pptx-to-html/)。

{{% /alert %}}