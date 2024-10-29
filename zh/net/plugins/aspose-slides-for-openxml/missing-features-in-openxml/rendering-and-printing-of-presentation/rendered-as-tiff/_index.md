---
title: 作为 TIFF 渲染
type: docs
weight: 30
url: /zh/net/rendered-as-tiff/
---

TIFF 格式以其灵活性而闻名，可以容纳多页图像和数据。考虑到 TIFF 格式的重要性和受欢迎程度，Aspose.Slides for .NET 提供了将演示文稿转换为 TIFF 文档的支持。  
本文解释了不同的 TIFF 导出选项：

- 将演示文稿转换为默认大小的 TIFF。
- 将演示文稿转换为自定义大小的 TIFF。

**Presentation** 类暴露的 **Save** 方法可以被开发人员调用，以将整个演示文稿转换为 **TIFF** 文档。此外，TiffOptions 类暴露了 ImageSize 属性，使开发人员可以在需要时定义图像的大小。

```csharp

 string FilePath = @"..\..\..\样本文件\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "转换为 Tiff.tiff";

//实例化一个表示演示文稿文件的 Presentation 对象

using (Presentation pres = new Presentation(srcFileName))

{

    //保存演示文稿为 TIFF 文档

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **下载示例代码**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)