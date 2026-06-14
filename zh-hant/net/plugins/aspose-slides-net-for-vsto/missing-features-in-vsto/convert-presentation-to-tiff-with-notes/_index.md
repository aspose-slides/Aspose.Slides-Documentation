---
title: 將簡報轉換為含備註的 Tiff
type: docs
weight: 50
url: /zh-hant/net/convert-presentation-to-tiff-with-notes/
---
TIFF 是 Aspose.Slides for .NET 支援的多種廣泛使用的影像格式之一，可用於將帶備註的簡報轉換為影像。您也可以在備註投影片視圖中產生投影片縮圖。以下兩個程式碼片段示範如何在備註投影片視圖中產生簡報的 TIFF 影像。

由 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別所公開的 [Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/methods/save) 方法可用於將整個簡報在備註投影片視圖中轉換為 TIFF。您也可以為個別投影片在備註投影片視圖中產生縮圖。
## **範例**

``` 

  //實例化一個代表簡報檔案的 Presentation 物件

 Presentation pres = new Presentation("Conversion.pptx");

 //將簡報儲存為含備註的 TIFF

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **下載執行範例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
欲取得更多資訊，請造訪 [Convert PowerPoint Presentations to TIFF with Notes in .NET](/slides/zh-hant/net/convert-powerpoint-to-tiff-with-notes/)。
{{% /alert %}}