---
title: プレゼンテーションをXPSに変換
type: docs
weight: 60
url: /ja/net/convert-presentation-to-xps/
---

**XPS** フォーマットはデータ交換でも広く使用されています。Aspose.Slides for .NET はその重要性に対応し、プレゼンテーションを XPS ドキュメントに変換するための組み込みサポートを提供します。

**Presentation** クラスが提供する **Save** メソッドを使用して、プレゼンテーション全体を **XPS** ドキュメントに変換できます。さらに、**XpsOptions** クラスは **SaveMetafileAsPng** プロパティを公開しており、要件に応じて true または false に設定できます。
## **例**

``` 

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation("Conversion.ppt");

//Saving the presentation to TIFF document

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **実行例のダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **サンプルコードのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
詳細については、[Convert PowerPoint Presentations to XPS in .NET](/slides/ja/net/convert-powerpoint-to-xps/) をご覧ください。
{{% /alert %}}