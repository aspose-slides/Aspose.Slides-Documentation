---
title: 带注释的 Tiff 转换
type: docs
weight: 10
url: /zh/net/conversion-to-tiff-with-notes/
---

TIFF 是 Aspose.Slides for .NET 支持将带注释的演示文稿转换为图像的几种广泛使用的图像格式之一。您还可以在注释幻灯片视图中生成幻灯片缩略图。以下是两个代码片段，展示了如何在注释幻灯片视图中生成演示文稿的 TIFF 图像。

**Presentation** 类暴露的 **Save** 方法可用于将整个演示文稿在注释幻灯片视图中转换为 TIFF。您还可以为单个幻灯片在注释幻灯片视图中生成幻灯片缩略图。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "带注释的 Tiff 转换.pptx";

string destFileName = FilePath + "带注释的 Tiff 转换.tiff";

// 实例化表示演示文稿文件的 Presentation 对象

Presentation pres = new Presentation(srcFileName);

// 将演示文稿保存为 TIFF 注释

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **下载示例代码**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)