---
title: HTMLへの変換
type: docs
weight: 20
url: /ja/net/conversion-to-html/
---

**HTML**は、データを交換するために広く使用されている形式の一つです。**Aspose.Slides for .NET**は、プレゼンテーションをHTMLに変換するサポートを提供します。以下は、その方法を示すコードスニペットです。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "HTMLへの変換.html";

//プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//プレゼンテーションをHTMLとして保存

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)