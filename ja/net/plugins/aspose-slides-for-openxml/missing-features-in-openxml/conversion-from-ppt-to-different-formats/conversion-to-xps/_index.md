---
title: XPSへの変換
type: docs
weight: 40
url: /ja/net/conversion-to-xps/
---

**XPS**形式はデータの交換にも広く使用されています。Aspose.Slides for .NETはその重要性を考慮し、プレゼンテーションをXPS文書に変換するための組み込みサポートを提供します。

Presentationクラスで公開されている**Save**メソッドを使用すると、プレゼンテーション全体を**XPS**文書に変換できます。さらに、**XpsOptions**クラスは、要件に応じてtrueまたはfalseに設定できる**SaveMetafileAsPng**プロパティを公開しています。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "XPSへの変換.xps";

//プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化

Presentation pres = new Presentation(srcFileName);

//プレゼンテーションをTIFF文書として保存

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)