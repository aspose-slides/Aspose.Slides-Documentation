---
title: ユーザー定義の寸法で TIFF としてレンダリング
type: docs
weight: 40
url: /ja/net/rendered-as-tiff-by-user-defined-dimension/
---

以下の例は、**TiffOptions** クラスを使用してカスタマイズされた画像サイズでプレゼンテーションを TIFF ドキュメントに変換する方法を示しています。

``` csharp
 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation(srcFileName);

// TiffOptions クラスをインスタンス化します
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

// 圧縮タイプを設定
opts.CompressionType = TiffCompressionTypes.Default;

// 圧縮タイプ
// Default - デフォルトの圧縮方式 (LZW) を指定します。
// None - 圧縮しないことを指定します。
// CCITT3
// CCITT4
// LZW
// RLE
// Depth - 圧縮タイプに依存し、手動で設定できません。
// Resolution unit - 常に "2"（ドット毎インチ）です。

// 画像 DPI を設定
opts.DpiX = 200;
opts.DpiY = 100;

// 画像サイズを設定
opts.ImageSize = new Size(1728, 1078);

// 指定した画像サイズでプレゼンテーションを TIFF に保存
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);
``` 
## **サンプルコードのダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)