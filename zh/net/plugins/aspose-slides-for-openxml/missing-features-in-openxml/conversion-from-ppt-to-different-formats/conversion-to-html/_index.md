---
title: 转换为 HTML
type: docs
weight: 20
url: /zh/net/conversion-to-html/
---

**HTML** 是几种广泛使用的数据交换格式之一。**Aspose.Slides for .NET** 提供将演示文稿转换为 HTML 的支持。下面的代码片段演示了如何操作。

``` csharp
 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Saving the presentation to HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);
``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)