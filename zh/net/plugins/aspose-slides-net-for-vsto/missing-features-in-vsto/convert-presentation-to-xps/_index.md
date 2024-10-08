---
title: 将演示文稿转换为 XPS
type: docs
weight: 60
url: /zh/net/convert-presentation-to-xps/
---

**XPS** 格式也广泛用于数据交换。Aspose.Slides for .NET 充分重视其重要性，并提供内置支持将演示文稿转换为 XPS 文档。

**Save** 方法由 Presentation 类提供，可以用于将整个演示文稿转换为 **XPS** 文档。此外，**XpsOptions** 类暴露了 **SaveMetafileAsPng** 属性，可以根据需要设置为 true 或 false。
## **示例**

``` 

 //实例化一个表示演示文稿文件的 Presentation 对象

Presentation pres = new Presentation("Conversion.ppt");

//将演示文稿保存为 TIFF 文档

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **下载运行示例**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Converting to XPS/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **下载示例代码**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

有关更多细节，请访问 [转换为 XPS](/slides/zh/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)。

{{% /alert %}}