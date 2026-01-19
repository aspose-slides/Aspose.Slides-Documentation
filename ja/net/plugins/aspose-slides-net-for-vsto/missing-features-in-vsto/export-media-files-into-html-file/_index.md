---
title: HTML ファイルへのメディア ファイルのエクスポート
type: docs
weight: 80
url: /ja/net/export-media-files-into-html-file/
---

メディア ファイルを HTML にエクスポートするには、以下の手順に従ってください:

- Presentation クラスのインスタンスを作成します
- スライドの参照を取得します
- トランジション効果を設定します
- プレゼンテーションを PPTX ファイルとして書き出します

以下の例では、メディア ファイルを HTML にエクスポートしています。
## **例**
``` 

 //Loading a presentation

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //Setting HTML options

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //Saving the file

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **実行サンプルのダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **サンプルコードのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)