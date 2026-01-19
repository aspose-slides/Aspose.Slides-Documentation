---
title: プレゼンテーションをHTMLに変換
type: docs
weight: 40
url: /ja/net/convert-presentation-to-html/
---

**HTML** は、データ交換に広く使用されているフォーマットのひとつです。**Aspose.Slides for .NET** は、プレゼンテーションを HTML に変換するサポートを提供します。以下は、その方法を示すコードスニペットです。
## **Example**
``` 

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Saving the presentation to HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **実行例のダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **サンプルコードのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

詳細については、[Convert PowerPoint Presentations to HTML in .NET](/slides/ja/net/convert-powerpoint-to-html/) をご覧ください。

{{% /alert %}}