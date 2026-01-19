---
title: OpenOffice 文档转换
type: docs
weight: 30
url: /zh/net/conversion-of-openoffice-document/
---

Aspose.Slides for .NET 提供 **Presentation** 类，代表演示文稿文件。**Presentation** 类现在还可以通过实例化对象时的 Presentation 构造函数访问 **ODP**。

下面是将 ODP 转换为 PPT/PPTX 的示例。
## **示例**
```csharp
 //实例化一个表示演示文稿文件的 Presentation 对象

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //将 PPTX 演示文稿保存为 PPTX 格式

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}
``` 

下面是将 PPT/PPTX 转换为 ODP 的示例。
## **示例**
```csharp
 //实例化一个表示演示文稿文件的 Presentation 对象

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //将 PPTX 演示文稿保存为 PPTX 格式

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}
``` 
## **下载运行示例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)