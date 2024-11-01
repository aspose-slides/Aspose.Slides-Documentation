---
title: 转换为HTML
type: docs
weight: 20
url: /zh/net/conversion-to-html/
---

**HTML** 是用于交换数据的几种广泛使用格式之一。**Aspose.Slides for .NET** 提供支持将演示文稿转换为HTML。以下是演示如何使用的代码片段。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//实例化一个表示演示文稿文件的Presentation对象

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//保存演示文稿为HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **下载示例代码**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)