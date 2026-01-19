---
title: 转换为 PDF
type: docs
weight: 30
url: /zh/net/conversion-to-pdf/
---

PDF文档被广泛用作组织、政府部门和个人之间交换文档的标准格式。由于这种格式的流行，开发人员经常需要将Microsoft PowerPoint演示文稿文件转换为PDF文档。针对这种可能的需求，Aspose.Slides for .NET 支持在不使用任何其他组件的情况下将演示文稿转换为PDF文档。

**Aspose.Slides for .NET** 提供了表示演示文稿文件的 Presentation 类。**Presentation** 类公开了 Save 方法，可用于将整个演示文稿转换为 **PDF** 文档。**PdfOptions** 类提供了创建 **PDF** 时的选项，如 JpegQuality、TextCompression、Compliance 等。这些选项可用于获得所需的 PDF 标准。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Save the presentation to PDF with default options

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)