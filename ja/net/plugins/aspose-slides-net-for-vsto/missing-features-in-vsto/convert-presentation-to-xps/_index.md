---
title: プレゼンテーションをXPSに変換
type: docs
weight: 60
url: /ja/net/convert-presentation-to-xps/
---

**XPS**フォーマットはデータ交換にも広く使用されています。Aspose.Slides for .NETはその重要性を考慮し、プレゼンテーションをXPSドキュメントに変換するための組み込みサポートを提供します。

Presentationクラスによって公開された**Save**メソッドを使用して、プレゼンテーション全体を**XPS**ドキュメントに変換できます。さらに、**XpsOptions**クラスは、要件に応じてtrueまたはfalseに設定できる**SaveMetafileAsPng**プロパティを公開しています。

## **例**

``` 

//プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化

Presentation pres = new Presentation("Conversion.ppt");

//プレゼンテーションをTIFFドキュメントとして保存

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **実行例のダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Converting to XPS/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **サンプルコードのダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

詳細については、[XPSへの変換](/slides/ja/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)をご覧ください。

{{% /alert %}}