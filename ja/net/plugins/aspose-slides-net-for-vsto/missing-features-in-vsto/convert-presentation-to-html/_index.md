---
title: プレゼンテーションをHTMLに変換する
type: docs
weight: 40
url: /net/convert-presentation-to-html/
---

**HTML**はデータを交換するための広く使用されている形式の1つです。 **Aspose.Slides for .NET**は、プレゼンテーションをHTMLに変換するサポートを提供します。以下は、その方法を示すコードスニペットです。
## **例**
``` 

 //プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//プレゼンテーションをHTMLとして保存します

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **実行例のダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Converting to HTML/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **サンプルコードのダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

詳細については、[プレゼンテーションをHTMLに変換する](/slides/net/convert-powerpoint-ppt-and-pptx-to-html/)をご覧ください。

{{% /alert %}}