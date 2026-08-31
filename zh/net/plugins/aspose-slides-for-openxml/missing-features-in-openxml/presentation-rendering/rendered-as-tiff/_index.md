---
title: 渲染为 Tiff
type: docs
weight: 30
url: /zh/net/rendered-as-tiff/
---
TIFF 格式以其能够容纳多页图像和数据的灵活性而闻名。鉴于 TIFF 格式的重要性和普及度，Aspose.Slides for .NET 提供了将演示文稿转换为 TIFF 文档的支持。
本文解释了不同的 TIFF 导出选项：

- 将演示文稿转换为默认大小的 TIFF。
- 将演示文稿转换为自定义大小的 TIFF。

**Presentation** 类公开的 **Save** 方法可供开发者调用，以将整个演示文稿转换为 **TIFF** 文档。此外，TiffOptions 类公开了 ImageSize 属性，允许开发者在需要时定义图像的大小。

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//实例化一个表示演示文稿文件的 Presentation 对象

using (Presentation pres = new Presentation(srcFileName))

{

    //将演示文稿保存为 TIFF 文档

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)