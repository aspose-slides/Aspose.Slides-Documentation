---
title: ユーザー定義のサイズでTIFFとしてレンダリング
type: docs
weight: 40
url: /ja/net/rendered-as-tiff-by-user-defined-dimension/
---

次の例は、**TiffOptions**クラスを使用してカスタマイズされた画像サイズでプレゼンテーションをTIFFドキュメントに変換する方法を示しています。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "定義されたフォーマットとしてTiffに変換.tiff";

//プレゼンテーションファイルを表すPresentationオブジェクトを作成

Presentation pres = new Presentation(srcFileName);

//TiffOptionsクラスをインスタンス化

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//圧縮タイプを設定

opts.CompressionType = TiffCompressionTypes.Default;

//圧縮タイプ

//Default - デフォルトの圧縮方式を指定（LZW）。

//None - 圧縮なしを指定。

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - 圧縮タイプに依存し、手動で設定できません。

//解像度単位 - 常に「2」（ドット/インチ）に等しい。

//画像のDPIを設定

opts.DpiX = 200;

opts.DpiY = 100;

//画像サイズを設定

opts.ImageSize = new Size(1728, 1078);

//指定された画像サイズでプレゼンテーションをTIFFとして保存

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **サンプルコードをダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)