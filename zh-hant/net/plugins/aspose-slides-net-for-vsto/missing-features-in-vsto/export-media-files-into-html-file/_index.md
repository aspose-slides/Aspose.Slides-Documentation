---
title: 將媒體檔案匯出為 HTML 檔案
type: docs
weight: 80
url: /zh-hant/net/export-media-files-into-html-file/
---
為了將媒體檔案匯出為 HTML，請遵循以下步驟：

- 建立 Presentation 類別的實例
- 取得投影片的參考
- 設定過渡效果
- 將簡報寫入為 PPTX 檔案

在下方的範例中，我們已將媒體檔案匯出為 HTML。
## **範例**
```

 //載入簡報

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //設定 HTML 選項

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //儲存檔案

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **下載執行範例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)