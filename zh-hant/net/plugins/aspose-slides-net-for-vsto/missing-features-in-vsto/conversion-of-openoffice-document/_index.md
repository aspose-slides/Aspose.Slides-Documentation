---
title: OpenOffice 文件的轉換
type: docs
weight: 30
url: /zh-hant/net/conversion-of-openoffice-document/
---
Aspose.Slides for .NET 提供 **Presentation** 類別，代表簡報檔案。**Presentation** 類別現在也可以在建立物件時透過 Presentation 建構函式存取 **ODP**。

以下是將 ODP 轉換為 PPT/PPTX 的範例。
## **範例**
```

 //實例化一個代表簡報檔案的 Presentation 物件

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //將 PPTX 簡報儲存為 PPTX 格式

}

``` 

以下是將 PPT/PPTX 轉換為 ODP 的範例。
## **範例**
``` 

 //實例化一個代表簡報檔案的 Presentation 物件

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //將 PPTX 簡報儲存為 PPTX 格式

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **下載執行範例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)