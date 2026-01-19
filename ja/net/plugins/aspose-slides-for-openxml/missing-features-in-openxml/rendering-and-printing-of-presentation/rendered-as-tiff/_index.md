---
title: Tiff としてレンダリング
type: docs
weight: 30
url: /ja/net/rendered-as-tiff/
---

TIFF フォーマットは、複数ページの画像やデータに対応できる柔軟性で知られています。TIFF フォーマットの重要性と普及率を考慮し、Aspose.Slides for .NET はプレゼンテーションを TIFF ドキュメントに変換するサポートを提供しています。この記事では、さまざまな TIFF エクスポート オプションについて説明します：

- デフォルト サイズでプレゼンテーションを TIFF に変換する。
- カスタム サイズでプレゼンテーションを TIFF に変換する。

**Presentation** クラスで公開されている **Save** メソッドを使用すると、開発者はプレゼンテーション全体を **TIFF** ドキュメントに変換できます。さらに、TiffOptions クラスの ImageSize プロパティを使用すると、必要に応じて画像のサイズを指定できます。

``` csharp
 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Instantiate a Presentation object that represents a presentation file

using (Presentation pres = new Presentation(srcFileName))

{

    //Saving the presentation to TIFF document

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **サンプルコードのダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)