---
title: OpenOffice文档的转换
type: docs
weight: 30
url: /zh/net/conversion-of-openoffice-document/
---

Aspose.Slides for .NET提供了**Presentation**类，该类表示一个演示文稿文件。**Presentation**类现在也可以通过演示文稿构造函数访问**ODP**，当对象被实例化时。

下面是从ODP转换为PPT/PPTX的示例。
## **示例**
```

 //实例化一个表示演示文稿文件的Presentation对象

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //保存PPTX演示文稿为PPTX格式

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

下面是从PPT/PPTX转换为ODP的示例。
## **示例**
``` 

 //实例化一个表示演示文稿文件的Presentation对象

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //保存PPTX演示文稿为PPTX格式

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **下载运行示例**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Conversion from ODP to PPTX/Converting From and To ODP/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **下载示例代码**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)