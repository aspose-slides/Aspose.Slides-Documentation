---
title: 将演示文稿转换为 HTML
type: docs
weight: 40
url: /zh/net/convert-presentation-to-html/
---

**HTML** 是几种广泛使用的数据交换格式之一。**Aspose.Slides for .NET** 提供将演示文稿转换为 HTML 的支持。以下代码片段展示了如何操作。
## **示例**
``` 

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Saving the presentation to HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **下载运行示例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

如需详细信息，请访问 [将 PowerPoint 演示文稿转换为 HTML (.NET)](/slides/zh/net/convert-powerpoint-to-html/).

{{% /alert %}}