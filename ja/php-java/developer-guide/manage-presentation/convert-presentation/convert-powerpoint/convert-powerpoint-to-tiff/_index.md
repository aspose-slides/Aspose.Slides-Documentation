---
title: PHPでPowerPointプレゼンテーションをTIFFに変換
titlelink: PowerPointからTIFFへ
type: docs
weight: 90
url: /ja/php-java/convert-powerpoint-to-tiff/
keywords:
- PowerPointを変換
- OpenDocumentを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointからTIFFへ
- プレゼンテーションからTIFFへ
- スライドからTIFFへ
- PPTからTIFFへ
- PPTXからTIFFへ
- PPTをTIFFとして保存
- PPTXをTIFFとして保存
- PPTをTIFFにエクスポート
- PPTXをTIFFにエクスポート
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用し、コード例とともに、PowerPoint（PPT、PPTX）プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を学びます。"
---
## **はじめに**

TIFF（**Tagged Image File Format**）は、優れた品質とグラフィックの詳細な保存で知られる、広く使用されているロスレスラスター画像形式です。デザイナー、写真家、デスクトップパブリッシャーは、画像のレイヤー、色精度、元の設定を保持するために TIFF を選択することが多いです。

Aspose.Slides を使用すると、PowerPoint スライド（PPT、PPTX）や OpenDocument スライド（ODP）を直接高品質な TIFF 画像に簡単に変換でき、プレゼンテーションの視覚的忠実度を最大限に保つことができます。 

## **プレゼンテーションを TIFF に変換**

[save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) メソッド（[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスで提供）を使用すると、PowerPoint プレゼンテーション全体を TIFF にすばやく変換できます。生成される TIFF 画像はデフォルトのスライドサイズに対応します。

このコードは PowerPoint プレゼンテーションを TIFF に変換する方法を示しています:

```php
// プレゼンテーションファイル（PPT、PPTX、ODPなど）を表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("presentation.pptx");
try {
    // プレゼンテーションを TIFF として保存します。
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **プレゼンテーションを白黒 TIFF に変換**

[TiffOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/) クラスの [setBwConversionMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/#setBwConversionMode) メソッドを使用すると、カラー スライドや画像を白黒 TIFF に変換する際に使用されるアルゴリズムを指定できます。なお、この設定は [setCompressionType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/#getCompressionType) メソッドが `CCITT4` または `CCITT3` に設定されている場合にのみ適用されます。

{{% alert color="info" title="Note" %}}
[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/#setBwConversionMode) はエクスポートレベルの設定で、完全な TIFF 画像のピクセル変換アルゴリズムを選択します。個々のシェイプが白黒表示モードでどのように表示されるかを定義するには、[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#setBlackWhiteMode) を使用してください。例については、[Control Black-and-White Rendering for Shapes](/slides/ja/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes) を参照してください。
{{% /alert %}}

例えば、"sample.pptx" ファイルに以下のスライドがあるとします:

![プレゼンテーション スライド](slide_black_and_white.png)

このコードは、カラー スライドを白黒 TIFF に変換する方法を示しています:

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

結果:

![白黒 TIFF](TIFF_black_and_white.png)

## **カスタムサイズの TIFF にプレゼンテーションを変換**

特定のサイズの TIFF 画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/) で利用できるメソッドを使用して希望の値を設定できます。たとえば、[setImageSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/#getImageSize) メソッドを使用すると、生成される画像のサイズを定義できます。

このコードは、カスタムサイズの TIFF 画像に PowerPoint プレゼンテーションを変換する方法を示しています:

```php
// プレゼンテーションファイル（PPT、PPTX、ODPなど）を表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // 圧縮タイプを設定します。
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    圧縮タイプ:
        Default - デフォルトの圧縮方式（LZW）を指定します。
        None - 圧縮せずに指定します。
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

## **カスタム画像ピクセル形式の TIFF にプレゼンテーションを変換**

[TiffOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/) クラスの [setPixelFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/#getPixelFormat) メソッドを使用すると、生成される TIFF 画像のピクセル形式を指定できます。

このコードは、カスタムピクセル形式の TIFF 画像に PowerPoint プレゼンテーションを変換する方法を示しています:

```php
// プレゼンテーションファイル（PPT、PPTX、ODPなど）を表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat には以下の値が含まれています（ドキュメントに記載のとおり）:
        Format1bppIndexed - 1 ビット/ピクセル、インデックス形式。
        Format4bppIndexed - 4 ビット/ピクセル、インデックス形式。
        Format8bppIndexed - 8 ビット/ピクセル、インデックス形式。
        Format24bppRgb    - 24 ビット/ピクセル、RGB。
        Format32bppArgb   - 32 ビット/ピクセル、ARGB。
    */

    // 指定した画像サイズでプレゼンテーションを TIFF として保存します。
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose の [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/ja/conversion/convert-ppt-to-poster-online) をご確認ください。
{{% /alert %}}

## **よくある質問**

**PowerPoint プレゼンテーション全体ではなく、個々のスライドを TIFF に変換できますか？**

はい。Aspose.Slides を使用すると、PowerPoint および OpenDocument プレゼンテーションから個々のスライドを個別に TIFF 画像に変換できます。

**プレゼンテーションを TIFF に変換する際、スライドの枚数に制限はありますか？**

いいえ、Aspose.Slides はスライド数に制限を課していません。任意のサイズのプレゼンテーションを TIFF 形式に変換できます。

**PowerPoint のアニメーションやトランジション効果は、スライドを TIFF に変換すると保持されますか？**

いいえ、TIFF は静的画像形式です。そのため、アニメーションやトランジション効果は保持されず、スライドの静止スナップショットのみがエクスポートされます。