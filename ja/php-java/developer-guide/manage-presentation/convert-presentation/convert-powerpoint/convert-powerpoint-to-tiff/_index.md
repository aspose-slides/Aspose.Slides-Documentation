---
title: PowerPointをTIFFに変換
type: docs
weight: 90
url: /ja/php-java/convert-powerpoint-to-tiff/
keywords: "PowerPointプレゼンテーションの変換, PowerPointからTIFF, PPTからTIFF, PPTXからTIFF, Java, Aspose.Slides"
description: "PowerPointプレゼンテーションをTIFFに変換"

---

**TIFF**（Tagged Image File Format）は、ロスレスなラスタ形式で高品質の画像フォーマットです。プロフェッショナルはデザイン、写真、デスクトップパブリッシングの目的でTIFFを使用します。たとえば、デザインや画像のレイヤーと設定を保持したい場合は、自分の作業をTIFF画像ファイルとして保存することをお勧めします。

Aspose.Slidesを使用すると、PowerPointのスライドを直接TIFFに変換できます。

{{% alert title="ヒント" color="primary" %}}

Asposeの[無料PowerPointからポスターに変換するコンバータ](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)をチェックしてみてください。

{{% /alert %}}

## **PowerPointをTIFFに変換**

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスによって公開された[Save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save-java.lang.String-int-)メソッドを使用すると、PowerPointプレゼンテーション全体を迅速にTIFFに変換できます。結果として得られるTIFF画像は、スライドのデフォルトサイズに対応しています。

このPHPコードは、PowerPointをTIFFに変換する方法を示しています。

```php
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
  $pres = new Presentation("presentation.pptx");
  try {
    # プレゼンテーションをTIFFとして保存します
    $pres->save("tiff-image.tiff", SaveFormat::Tiff);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PowerPointを白黒TIFFに変換**

Aspose.Slides 23.10では、[TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/)クラスに新しいプロパティ（[BwConversionMode](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setBwConversionMode-int-)）が追加され、カラーのスライドまたは画像が白黒TIFFに変換される際に従うアルゴリズムを指定できるようになりました。この設定は、[CompressionType](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setCompressionType-int-)プロパティが`CCITT4`または`CCITT3`に設定されている場合にのみ適用されることに注意してください。

このPHPコードは、カラーのスライドまたは画像を白黒TIFFに変換する方法を示しています。

```php
  $tiffOptions = new TiffOptions();
  $tiffOptions->setCompressionType(TiffCompressionTypes.CCITT4);
  $tiffOptions->setBwConversionMode(BlackWhiteConversionMode->Dithering);
  $presentation = new Presentation("sample.pptx");
  try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **カスタムサイズでPowerPointをTIFFに変換**

定義された寸法のTIFF画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/)で提供されているプロパティを使用して好みの数値を定義できます。たとえば、[ImageSize](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-)プロパティを使用して、生成される画像のサイズを設定できます。

このPHPコードは、カスタムサイズでPowerPointをTIFF画像に変換する方法を示しています。

```php
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
  $pres = new Presentation("presentation.pptx");
  try {
    # TiffOptionsクラスをインスタンス化します
    $opts = new TiffOptions();
    # 圧縮タイプを設定します
    # 可能な値は：
    # Default - デフォルトの圧縮スキームを指定します（LZW）。
    # None - 圧縮なしを指定します。
    # CCITT3
    # CCITT4
    # LZW
    # RLE
    $opts->setCompressionType(TiffCompressionTypes.Default);
    # Depth – 圧縮タイプに依存しており、手動で設定することはできません。
    # 画像のDPIを設定します
    $opts->setDpiX(200);
    $opts->setDpiY(100);
    # 画像サイズを設定します
    $opts->setImageSize(new Java("java.awt.Dimension", 1728, 1078));
    $options = $opts->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    # 指定されたサイズでTIFFにプレゼンテーションを保存します
    $pres->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $opts);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **カスタム画像ピクセル形式でPowerPointをTIFFに変換**

[TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/)クラスの[PixelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setPixelFormat-int-)プロパティを使用して、生成されるTIFF画像の好みのピクセル形式を指定できます。

このPHPコードは、カスタムピクセル形式でPowerPointをTIFF画像に変換する方法を示しています。

```php
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
  $pres = new Presentation("presentation.pptx");
  try {
    $options = new TiffOptions();
    $options->setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /* ImagePixelFormatには、以下の値が含まれます（ドキュメントに記載されている通り）：
    Format1bppIndexed; // 1ビット/ピクセル、インデックス付き。
    Format4bppIndexed; // 4ビット/ピクセル、インデックス付き。
    Format8bppIndexed; // 8ビット/ピクセル、インデックス付き。
    Format24bppRgb;    // 24ビット/ピクセル、RGB。
    Format32bppArgb;   // 32ビット/ピクセル、ARGB。
     */
    # 指定された画像サイズでTIFFにプレゼンテーションを保存します
    $pres->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```