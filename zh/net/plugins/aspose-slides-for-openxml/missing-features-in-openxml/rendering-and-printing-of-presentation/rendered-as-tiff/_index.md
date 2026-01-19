---
title: 渲染为 Tiff
type: docs
weight: 30
url: /zh/net/rendered-as-tiff/
---

TIFF 格式以其能够容纳多页图像和数据的灵活性而闻名。鉴于 TIFF 格式的重要性和流行度，Aspose.Slides for .NET 提供了将演示文稿转换为 TIFF 文档的支持。
本文介绍了不同的 TIFF 导出选项：

- 使用默认尺寸将演示文稿转换为 TIFF。
- 使用自定义尺寸将演示文稿转换为 TIFF。

**Presentation** 类公开的 **Save** 方法可供开发者调用，以将整个演示文稿转换为 **TIFF** 文档。此外，TiffOptions 类公开了 ImageSize 属性，允许开发者在需要时定义图像的尺寸。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Instantiate a Presentation object that represents a presentation file

using (Presentation pres = new Presentation(srcFileName))

{

    //Saving the presentation to TIFF document

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)