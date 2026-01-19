---
title: 转换为 XPS
type: docs
weight: 40
url: /zh/net/conversion-to-xps/
---

**XPS** 格式也被广泛用于数据交换。Aspose.Slides for .NET 重视其重要性，并提供内置支持，将演示文稿转换为 XPS 文档。

**Save** 方法由 Presentation 类公开，可用于将整个演示文稿转换为 **XPS** 文档。此外，**XpsOptions** 类公开 **SaveMetafileAsPng** 属性，可根据需求设置为 true 或 false。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF document

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)