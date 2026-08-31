---
title: TIFF としてレンダリング
type: docs
weight: 30
url: /ja/net/rendered-as-tiff/
---
TIFF 形式は、複数ページの画像やデータに対応できる柔軟性で知られています。TIFF 形式の重要性と人気を踏まえ、Aspose.Slides for .NET はプレゼンテーションを TIFF ドキュメントに変換するサポートを提供しています。
この記事では、さまざまな TIFF エクスポート オプションについて説明します。

- 既定サイズでプレゼンテーションを TIFF に変換する。
- カスタムサイズでプレゼンテーションを TIFF に変換する。

**Presentation** クラスが提供する **Save** メソッドを使用して、開発者はプレゼンテーション全体を **TIFF** ドキュメントに変換できます。さらに、TiffOptions クラスの ImageSize プロパティを使用すると、必要に応じて画像のサイズを指定できます。

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する

using (Presentation pres = new Presentation(srcFileName))

{

    //プレゼンテーションを TIFF ドキュメントとして保存する

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);
}
``` 
## **サンプルコードのダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)