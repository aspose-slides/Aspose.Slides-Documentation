---
title: JavaScript で PowerPoint プレゼンテーションを TIFF に変換する
titlelink: PowerPoint から TIFF へ
type: docs
weight: 90
url: /ja/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーションを変換
- スライドを変換
- PowerPoint から TIFF へ
- OpenDocument から TIFF へ
- プレゼンテーションから TIFF へ
- スライドから TIFF へ
- PPT から TIFF へ
- PPTX から TIFF へ
- ODP から TIFF へ
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js（Java 経由）を使用して、PowerPoint（PPT、PPTX）および OpenDocument（ODP）プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を学びます。コード例を含むステップバイステップのガイドです。"
---

## **概要**

TIFF (**Tagged Image File Format**) は、優れた画質とグラフィックの詳細保持で広く使用されているロスレスラスター画像フォーマットです。デザイナー、フォトグラファー、デスクトップパブリッシャーは、画像のレイヤー、色精度、元の設定を維持するために TIFF を選択することが多いです。

Aspose.Slides を使用すると、PowerPoint スライド (PPT、PPTX) および OpenDocument スライド (ODP) を直接高品質な TIFF 画像に簡単に変換でき、プレゼンテーションの視覚的な忠実度を最大限に保つことができます。

## **プレゼンテーションを TIFF に変換**

[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスが提供する[save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) メソッドを使用すると、PowerPoint プレゼンテーション全体をすばやく TIFF に変換できます。生成される TIFF 画像はデフォルトのスライドサイズに対応します。

この JavaScript コードは、PowerPoint プレゼンテーションを TIFF に変換する方法を示しています:
```js
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // プレゼンテーションを TIFF として保存します。
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```


## **プレゼンテーションを白黒 TIFF に変換**

[TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) クラスの[setBwConversionMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) メソッドを使用すると、カラー スライドや画像を白黒 TIFF に変換する際のアルゴリズムを指定できます。この設定は、[setCompressionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) メソッドが `CCITT4` または `CCITT3` に設定されている場合にのみ適用されます。

たとえば、以下の「sample.pptx」ファイルに次のスライドがあるとします:

![プレゼンテーション スライド](slide_black_and_white.png)

この JavaScript コードは、カラー スライドを白黒 TIFF に変換する方法を示しています:
```js
let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


結果:

![白黒 TIFF](TIFF_black_and_white.png)

## **カスタムサイズの TIFF にプレゼンテーションを変換**

特定の寸法の TIFF 画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) に用意されたメソッドで希望の値を設定できます。たとえば、[setImageSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setImageSize) メソッドを使用すると、生成される画像のサイズを指定できます。

この JavaScript コードは、PowerPoint プレゼンテーションをカスタム サイズの TIFF 画像に変換する方法を示しています:
```js
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // 圧縮タイプを設定します。
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    圧縮タイプ:
        Default - デフォルトの圧縮方式 (LZW) を指定します。
        None - 圧縮しません。
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // 深度は圧縮タイプに依存し、手動で設定できません。

    // 画像 DPI を設定します。
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // 画像サイズを設定します。
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 指定したサイズでプレゼンテーションを TIFF として保存します。
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


## **カスタム画像ピクセルフォーマットの TIFF にプレゼンテーションを変換**

[TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) クラスの[setPixelFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) メソッドを使用すると、生成される TIFF 画像のピクセルフォーマットを任意に指定できます。

この JavaScript コードは、PowerPoint プレゼンテーションをカスタム ピクセルフォーマットの TIFF 画像に変換する方法を示しています:
```js
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat には次の値が含まれます（ドキュメントに記載されているとおり）:
        Format1bppIndexed - 1 ビット/ピクセル、インデックス形式。
        Format4bppIndexed - 4 ビット/ピクセル、インデックス形式。
        Format8bppIndexed - 8 ビット/ピクセル、インデックス形式。
        Format24bppRgb    - 24 ビット/ピクセル、RGB。
        Format32bppArgb   - 32 ビット/ピクセル、ARGB。
    */

    /// 指定した画像サイズでプレゼンテーションを TIFF として保存します。
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="Tip" color="primary" %}}
Aspose の無料 PowerPoint からポスターへのコンバータをご覧ください。
{{% /alert %}}

## **FAQ**

**PowerPoint プレゼンテーション全体ではなく、個々のスライドを TIFF に変換できますか？**

はい。Aspose.Slides を使用すると、PowerPoint および OpenDocument プレゼンテーションから個々のスライドを別々に TIFF 画像に変換できます。

**プレゼンテーションを TIFF に変換する際、スライド数に制限はありますか？**

いいえ、Aspose.Slides はスライド数に制限を設けていません。任意のサイズのプレゼンテーションを TIFF 形式に変換できます。

**スライドを TIFF に変換すると、PowerPoint のアニメーションやトランジション効果は保持されますか？**

保持されません。TIFF は静止画像フォーマットであるため、アニメーションやトランジション効果は保存されず、スライドの静止スナップショットのみがエクスポートされます。