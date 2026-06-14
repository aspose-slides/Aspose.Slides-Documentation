---
title: 轉換簡報為HTML
type: docs
weight: 40
url: /zh-hant/net/convert-presentation-to-html/
---
**HTML** 是多種廣泛使用的資料交換格式之一。**Aspose.Slides for .NET** 提供將簡報轉換為 HTML 的支援。以下程式碼片段示範如何操作。
## **範例**
``` 

 //實例化一個代表簡報檔案的 Presentation 物件

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//將簡報儲存為 HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **下載執行範例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

如需更多資訊，請參閱 [將 PowerPoint 簡報轉換為 HTML in .NET](/slides/zh-hant/net/convert-powerpoint-to-html/).

{{% /alert %}}