---
title: TIFFとしてレンダリング
type: docs
weight: 30
url: /ja/net/rendered-as-tiff/
---

TIFFフォーマットは、マルチページ画像やデータを取り扱う柔軟性で知られています。TIFFフォーマットの重要性と人気を考慮し、Aspose.Slides for .NETはプレゼンテーションをTIFFドキュメントに変換するサポートを提供しています。
この記事では、さまざまなTIFFエクスポートオプションについて説明します：

- デフォルトサイズでプレゼンテーションをTIFFに変換する。
- カスタムサイズでプレゼンテーションをTIFFに変換する。

**Presentation**クラスによって公開される**Save**メソッドは、開発者がプレゼンテーション全体を**TIFF**ドキュメントに変換するために呼び出すことができます。さらに、TiffOptionsクラスはImageSizeプロパティを公開し、必要に応じて画像のサイズを定義できるようにします。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します

using (Presentation pres = new Presentation(srcFileName))

{

    //プレゼンテーションをTIFFドキュメントとして保存します

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **サンプルコードをダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)