---
title: 将演示文稿转换为带备注的 Tiff
type: docs
weight: 50
url: /zh/net/convert-presentation-to-tiff-with-notes/
---

TIFF 是 Aspose.Slides for .NET 支持的多种常用图像格式之一，可用于将带有备注的演示文稿转换为图像。您还可以在备注幻灯片视图中生成幻灯片缩略图。下面提供了两个代码片段，演示如何在备注幻灯片视图中生成演示文稿的 TIFF 图像。

[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) 方法由 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类提供，可用于将整个备注幻灯片视图的演示文稿转换为 TIFF。您也可以为单个幻灯片在备注幻灯片视图中生成缩略图。

## **示例**

``` 

  //Instantiate a Presentation object that represents a presentation file

 Presentation pres = new Presentation("Conversion.pptx");

 //Saving the presentation to TIFF notes

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 

## **下载运行示例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)

## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

欲了解更多详情，请访问 [Convert PowerPoint Presentations to TIFF with Notes in .NET](/slides/zh/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}