---
title: PHPでPowerPointプレゼンテーションをTIFFに変換する
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
description: "Aspose.Slides for PHP via Java を使用し、コード例とともに PowerPoint（PPT、PPTX）プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を学びます。"
---
## **イントロダクション**

TIFF (**Tagged Image File Format**) は、広く使用されているロスレスラスタ画像形式で、卓越した品質とグラフィックの詳細な保存で知られています。デザイナー、写真家、デスクトップパブリッシャーは、レイヤー、カラー精度、元の設定を画像に保持するために TIFF を選択することが多いです。

Aspose.Slides を使用すると、PowerPoint スライド（PPT、PPTX）や OpenDocument スライド（ODP）を直接高品質な TIFF 画像に簡単に変換でき、プレゼンテーションの視覚的忠実度を最大限に保つことができます。

## **プレゼンテーションを TIFF に変換する**

[save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) メソッドを使用して、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスが提供する方法で、PowerPoint プレゼンテーション全体を簡単に TIFF に変換できます。生成される TIFF 画像はデフォルトのスライドサイズに対応します。

このコードは、PowerPoint プレゼンテーションを TIFF に変換する方法を示しています:

```php
// プレゼンテーションファイル（PPT、PPTX、ODP、など）を表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("presentation.pptx");
try {
    // プレゼンテーションを TIFF 形式で保存します。
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **プレゼンテーションを白黒 TIFF に変換する**

[TiffOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/) クラスの [setBwConversionMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/#setBwConversionMode) メソッドを使用すると、カラー スライドや画像を白黒 TIFF に変換する際に使用するアルゴリズムを指定できます。この設定は、[setCompressionType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/#getCompressionType) メソッドが `CCITT4` または `CCITT3` に設定されている場合にのみ適用されます。

{{% alert color="info" title="Note" %}}
[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/#setBwConversionMode) はエクスポートレベルの設定で、完全な TIFF 画像に対してピクセル変換アルゴリズムを選択します。個々のシェイプが白黒表示モードでどのように描画されるかを指定するには、[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#setBlackWhiteMode) を使用します。例については、[Control Black-and-White Rendering for Shapes](/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes) を参照してください。
{{% /alert %}}

たとえば、次のスライドを含む「sample.pptx」ファイルがあるとします:

![プレゼンテーションスライド](slide_black_and_white.png)

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

## **カスタムサイズの TIFF にプレゼンテーションを変換する**

特定のサイズの TIFF 画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/) に用意されているメソッドを使用して希望の値を設定できます。たとえば、[setImageSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/#getImageSize) メソッドを使用すると、生成される画像のサイズを定義できます。

このコードは、PowerPoint プレゼンテーションをカスタムサイズの TIFF 画像に変換する方法を示しています:

```php
// プレゼンテーションファイル（PPT、PPTX、ODP、など）を表す Presentation クラスのインスタンスを作成します。
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

## **カスタム画像ピクセル形式の TIFF にプレゼンテーションを変換する**

[TiffOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/) クラスの [setPixelFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/#getPixelFormat) メソッドを使用すると、生成される TIFF 画像のピクセル形式を好きなものに指定できます。

このコードは、カスタムピクセル形式の TIFF 画像に PowerPoint プレゼンテーションを変換する方法を示しています:

```php
// プレゼンテーションファイル（PPT、PPTX、ODP、など）を表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat には以下の値が含まれます（ドキュメントに記載されている通り）:
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
Aspose の [無料 PowerPoint からポスターへのコンバータ](https://products.aspose.app/slides/ja/conversion/convert-ppt-to-poster-online) をご覧ください。
{{% /alert %}}

## **FAQ**

**個々のスライドだけを TIFF に変換できますか？**

はい。Aspose.Slides を使用すると、PowerPoint や OpenDocument プレゼンテーションから個別のスライドを TIFF 画像として個別に変換できます。

**プレゼンテーションを TIFF に変換する際にスライド数の制限はありますか？**

いいえ、Aspose.Slides にはスライド数に制限はありません。サイズにかかわらず、任意のプレゼンテーションを TIFF 形式に変換できます。

**スライドを TIFF に変換するときに PowerPoint のアニメーションやトランジション効果は保持されますか？**

保持されません。TIFF は静止画像形式のため、アニメーションやトランジション効果は保存されず、スライドの静的なスナップショットのみがエクスポートされます。