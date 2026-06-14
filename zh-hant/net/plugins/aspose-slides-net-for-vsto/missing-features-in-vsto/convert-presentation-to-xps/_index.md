---
title: 將簡報轉換為 XPS
type: docs
weight: 60
url: /zh-hant/net/convert-presentation-to-xps/
---
**XPS** 格式亦廣泛用於資料交換。Aspose.Slides for .NET 重視其重要性，並提供內建的支援，可將簡報轉換為 XPS 文件。

Presentation 類別所提供的 **Save** 方法可用於將整個簡報轉換為 **XPS** 文件。此外，**XpsOptions** 類別揭露 **SaveMetafileAsPng** 屬性，可根據需求設為 true 或 false。
## **Example**

``` 

 //實例化一個代表簡報檔的 Presentation 物件

Presentation pres = new Presentation("Conversion.ppt");

//將簡報儲存為 TIFF 文件

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Download Running Example**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

如需更多資訊，請參閱 [Convert PowerPoint Presentations to XPS in .NET](/slides/zh-hant/net/convert-powerpoint-to-xps/).

{{% /alert %}}