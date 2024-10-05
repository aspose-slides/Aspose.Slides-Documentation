---  
title: メディアファイルをHTMLファイルにエクスポート  
type: docs  
weight: 40  
url: /net/export-media-files-to-html-file/  
---  

メディアファイルをHTMLにエクスポートするには、以下の手順に従ってください：  

- Presentationクラスのインスタンスを作成する  
- スライドの参照を取得する  
- トランジション効果を設定する  
- プレゼンテーションをPPTXファイルとして書き出す  

以下の例では、メディアファイルをHTMLにエクスポートしています。  
## **例**  
``` csharp  

 string FilePath = @"..\..\..\Sample Files\";  

string srcFileName = FilePath + "Conversion.pptx";  

string destFileName =  "video.html";  

//プレゼンテーションの読み込み  

using (Presentation pres = new Presentation(srcFileName))  
{  

    const string baseUri = "http://www.example.com/";  

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);  

    //HTMLオプションの設定  

    HtmlOptions htmlOptions = new HtmlOptions(controller);  

    SVGOptions svgOptions = new SVGOptions(controller);  

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);  

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);  

    //ファイルの保存  

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);  

}  

```  
## **サンプルコードのダウンロード**  
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)  
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)  
## **実行例のダウンロード**  
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Export media files into html/)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)  
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)  

{{% alert color="primary" %}}  

詳細については、[メディアファイルをHTMLファイルにエクスポートする](/slides/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide)をご覧ください。  

{{% /alert %}}  