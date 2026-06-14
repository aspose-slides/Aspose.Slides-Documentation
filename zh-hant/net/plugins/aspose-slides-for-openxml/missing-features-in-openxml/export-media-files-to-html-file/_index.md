---
title: 將媒體檔案匯出為 HTML 檔案
type: docs
weight: 40
url: /zh-hant/net/export-media-files-to-html-file/
---
為了將媒體檔案匯出至 HTML，請遵循以下步驟：

- 建立 Presentation 類別的實例
- 取得投影片的參考
- 設定轉場效果
- 將簡報寫入為 PPTX 檔案

以下範例中，我們已將媒體檔案匯出至 HTML。
## **範例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//載入簡報

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //設定 HTML 選項

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //儲存檔案

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **下載執行範例**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 

如需更多資訊，請參閱 [將媒體檔案匯出為 html 檔案](/slides/zh-hant/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide)。

{{% /alert %}}