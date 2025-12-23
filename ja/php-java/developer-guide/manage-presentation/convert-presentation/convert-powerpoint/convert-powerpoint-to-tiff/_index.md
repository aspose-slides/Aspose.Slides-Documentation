---
title: PHPでPowerPointプレゼンテーションをTIFFに変換
titlelink: PowerPointからTIFFへ
type: docs
weight: 90
url: /ja/php-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーション を変換
- スライド を変換
- PPT を変換
- PPTX を変換
- PowerPoint を TIFF に変換
- プレゼンテーション を TIFF に変換
- スライド を TIFF に変換
- PPT を TIFF に変換
- PPTX を TIFF に変換
- PPT を TIFF として保存
- PPTX を TIFF として保存
- PPT を TIFF にエクスポート
- PPTX を TIFF にエクスポート
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint（PPT、PPTX）プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を、コード例とともに学びます。"
---

## **概要**

TIFF（**Tagged Image File Format**）は、広く使用されているロスレスラスター画像形式で、優れた画質とグラフィックの詳細な保存が特徴です。デザイナー、写真家、デスクトップパブリッシャーは、画像のレイヤー、カラー精度、元の設定を維持するために TIFF を選択することが多いです。

Aspose.Slides を使用すると、PowerPoint スライド（PPT、PPTX）や OpenDocument スライド（ODP）を直接高品質な TIFF 画像に簡単に変換でき、プレゼンテーションの視覚的忠実度を最大限に保つことができます。

## **プレゼンテーションを TIFF に変換する**

Using the [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) method provided by the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the default slide size.

このコードは PowerPoint プレゼンテーションを TIFF に変換する方法を示しています：
```php
// プレゼンテーションファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("presentation.pptx");
try {
    // プレゼンテーションを TIFF として保存します。
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```


## **プレゼンテーションを白黒 TIFF に変換する**

The method [setBwConversionMode](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setBwConversionMode) in the [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) class allows you to specify the algorithm used when converting a colored slide or image to a black-and-white TIFF. Note that this setting applies only when the [setCompressionType](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#getCompressionType) method is set to `CCITT4` or `CCITT3`.

例として、"sample.pptx" ファイルに以下のスライドがあるとします：

![プレゼンテーション スライド](slide_black_and_white.png)

このコードはカラー スライドを白黒 TIFF に変換する方法を示しています：
```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```


結果：

![白黒 TIFF](TIFF_black_and_white.png)

## **カスタムサイズでプレゼンテーションを TIFF に変換する**

If you require a TIFF image with specific dimensions, you can set your desired values using methods available in [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/). For instance, the [setImageSize](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#getImageSize) method allows you to define the size of the resulting image.

このコードは、カスタムサイズの TIFF 画像にプレゼンテーションを変換する方法を示しています：
```php
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // 圧縮タイプを設定します。
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    圧縮タイプ:
        Default - デフォルトの圧縮方式 (LZW) を指定します。
        None - 圧縮なしを指定します。
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // 深度は圧縮タイプに依存し、手動で設定できません。

    // 画像の DPI を設定します。
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // 画像サイズを設定します。
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // 指定したサイズでプレゼンテーションを TIFF として保存します。
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```


## **カスタム画像ピクセルフォーマットでプレゼンテーションを TIFF に変換する**

Using the [setPixelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#getPixelFormat) method from the [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) class, you can specify your preferred pixel format for the resulting TIFF image.

このコードは、カスタムピクセルフォーマットで TIFF 画像にプレゼンテーションを変換する方法を示しています：
```php
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat は以下の値を含みます（ドキュメントに記載されている通り）:
        Format1bppIndexed - 1 ビット/ピクセル、インデックスカラー。
        Format4bppIndexed - 4 ビット/ピクセル、インデックスカラー。
        Format8bppIndexed - 8 ビット/ピクセル、インデックスカラー。
        Format24bppRgb    - 24 ビット/ピクセル、RGB。
        Format32bppArgb   - 32 ビット/ピクセル、ARGB。
    */

    // 指定した画像サイズでプレゼンテーションを TIFF として保存します。
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="ヒント" color="primary" %}}
Aspose の[無料 PowerPoint からポスターへのコンバータ](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)をご覧ください。
{{% /alert %}}

## **FAQ**

**個々のスライドだけを TIFF に変換することはできますか？**

はい。Aspose.Slides を使用すると、PowerPoint および OpenDocument のプレゼンテーションから個々のスライドを別々に TIFF 画像に変換できます。

**プレゼンテーションを TIFF に変換する際にスライド数の制限はありますか？**

いいえ、Aspose.Slides にはスライド数に対する制限はありません。任意のサイズのプレゼンテーションを TIFF 形式に変換できます。

**PowerPoint のアニメーションやトランジション効果は TIFF に変換すると保持されますか？**

保持されません。TIFF は静的画像形式であるため、アニメーションやトランジション効果は保存されず、スライドの静止画がエクスポートされます。