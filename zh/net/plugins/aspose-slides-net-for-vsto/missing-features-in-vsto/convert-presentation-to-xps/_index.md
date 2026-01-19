---
title: 将演示文稿转换为 XPS
type: docs
weight: 60
url: /zh/net/convert-presentation-to-xps/
---

**XPS** 格式也被广泛用于数据交换。Aspose.Slides for .NET 关注其重要性，并提供内置支持，将演示文稿转换为 XPS 文档。

Presentation 类公开的 **Save** 方法可用于将整个演示文稿转换为 **XPS** 文档。此外，**XpsOptions** 类公开 **SaveMetafileAsPng** 属性，可根据需求设置为 true 或 false。

## **示例**

``` 

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation("Conversion.ppt");

//Saving the presentation to TIFF document

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **下载运行示例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

欲了解更多详情，请访问 [将 PowerPoint 演示文稿转换为 XPS (.NET)](/slides/zh/net/convert-powerpoint-to-xps/).

{{% /alert %}}