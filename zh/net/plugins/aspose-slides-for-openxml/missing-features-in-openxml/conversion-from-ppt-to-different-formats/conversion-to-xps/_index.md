---
title: 转换为 XPS
type: docs
weight: 40
url: /zh/net/conversion-to-xps/
---

**XPS** 格式在数据交换中也被广泛使用。Aspose.Slides for .NET 充分考虑了其重要性，并提供了将演示文稿转换为 XPS 文档的内置支持。

**Presentation** 类公开的 **Save** 方法可用于将整个演示文稿转换为 **XPS** 文档。此外，**XpsOptions** 类公开的 **SaveMetafileAsPng** 属性可以根据需要设置为 true 或 false。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//实例化一个表示演示文稿文件的 Presentation 对象

Presentation pres = new Presentation(srcFileName);

//保存演示文稿为 TIFF 文档

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **下载示例代码**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)