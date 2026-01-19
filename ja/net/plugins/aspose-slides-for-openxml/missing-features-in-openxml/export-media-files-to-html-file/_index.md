---
title: HTMLファイルへのメディアファイルのエクスポート
type: docs
weight: 40
url: /ja/net/export-media-files-to-html-file/
---

メディア ファイルを HTML にエクスポートするには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成する
- スライドの参照を取得する
- トランジション効果を設定する
- プレゼンテーションを書き出して PPTX ファイルにする

以下の例では、メディア ファイルを HTML にエクスポートしています。
## **例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Loading a presentation

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Setting HTML options

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Saving the file

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **サンプルコードをダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **実行例をダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 
詳細については、[HTML ファイルへのメディア ファイルのエクスポート](/slides/ja/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide)をご覧ください。
{{% /alert %}}