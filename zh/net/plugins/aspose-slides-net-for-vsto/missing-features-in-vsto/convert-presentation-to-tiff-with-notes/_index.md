---
title: 将演示文稿转换为带注释的 TIFF
type: docs
weight: 50
url: /zh/net/convert-presentation-to-tiff-with-notes/
---

TIFF 是 Aspose.Slides for .NET 支持的多种广泛使用的图像格式之一，用于将带注释的演示文稿转换为图像。您还可以在注释幻灯片视图中生成幻灯片缩略图。下面是两个代码片段，展示了如何在注释幻灯片视图中生成演示文稿的 TIFF 图像。

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类暴露的 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) 方法可用于将整个演示文稿在注释幻灯片视图中转换为 TIFF。您还可以为单个幻灯片生成注释幻灯片视图中的幻灯片缩略图。
## **示例**

``` 

  // 实例化一个表示演示文稿文件的 Presentation 对象

 Presentation pres = new Presentation("Conversion.pptx");

 // 将演示文稿保存为 TIFF 注释

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **下载运行示例**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Tiff conversion with note/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **下载示例代码**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

欲了解更多详情，请访问 [转换带注释的演示文稿](/slides/zh/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)。

{{% /alert %}}