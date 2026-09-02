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
- PPT を変換
- PPTX を変換
- PowerPoint から TIFF へ
- プレゼンテーションを TIFF に変換
- スライドを TIFF に変換
- PPT を TIFF に変換
- PPTX を TIFF に変換
- PPT を TIFF として保存
- PPTX を TIFF として保存
- PPT を TIFF にエクスポート
- PPTX を TIFF にエクスポート
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用し、JavaScript のコード例とともに、PowerPoint（PPT、PPTX）プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を学びます。"
---
## **概要**

TIFF（**Tagged Image File Format**）は、卓越した品質とグラフィックの詳細な保存で知られる、広く使用されているロスレスラスター画像フォーマットです。デザイナー、写真家、デスクトップパブリッシャーは、画像のレイヤー、色精度、元の設定を維持するためにTIFFを選択することが多いです。

Aspose.Slides を使用すると、PowerPoint スライド（PPT、PPTX）や OpenDocument スライド（ODP）を直接高品質な TIFF 画像に簡単に変換でき、プレゼンテーションの視覚的忠実度を最大限に保つことができます。

## **プレゼンテーションをTIFFに変換**

[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスが提供する [save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) メソッドを使用すると、PowerPoint プレゼンテーション全体をすばやく TIFF に変換できます。生成される TIFF 画像はデフォルトのスライドサイズに対応します。

この JavaScript コードは、PowerPoint プレゼンテーションを TIFF に変換する方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantiate the Presentation class that represents a presentation file (PPT, PPTX, ODP, etc.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // プレゼンテーションを TIFF として保存します。
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **プレゼンテーションを白黒TIFFに変換**

[TiffOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/) クラスの [setBwConversionMode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) メソッドを使用すると、カラー スライドまたは画像を白黒 TIFF に変換する際に使用するアルゴリズムを指定できます。この設定は、[setCompressionType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) メソッドが `CCITT4` または `CCITT3` に設定されている場合にのみ適用されます。

{{% alert color="info" title="注" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) は、完全な TIFF 画像に対してピクセル変換アルゴリズムを選択するエクスポート レベルの設定です。個々のシェイプが白黒表示モードでどのように表示されるかを定義するには、[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) を使用します。例については [Control Black-and-White Rendering for Shapes](/slides/ja/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) を参照してください。
{{% /alert %}}

たとえば、次のようなスライドを含む「sample.pptx」ファイルがあるとします。

![プレゼンテーションのスライド](slide_black_and_white.png)

この JavaScript コードは、カラー スライドを白黒 TIFF に変換する方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

![白黒TIFF](TIFF_black_and_white.png)

## **カスタムサイズのTIFFにプレゼンテーションを変換**

特定の寸法の TIFF 画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/) で利用可能なメソッドを使用して希望の値を設定できます。たとえば、[setImageSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/#setImageSize) メソッドを使用すると、生成される画像のサイズを定義できます。

この JavaScript コードは、PowerPoint プレゼンテーションをカスタムサイズの TIFF 画像に変換する方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// プレゼンテーション ファイル（PPT、PPTX、ODP など）を表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // 圧縮タイプを設定します。
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    圧縮タイプ:
        Default - デフォルトの圧縮方式（LZW）を指定します。
        None - 圧縮なしを指定します。
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // カラーデプスはピクセル形式で制御されます（以下の例をご参照ください）。CCITT3 および CCITT4 は常に 1 ビット/ピクセルになります。

    // 画像の DPI を設定します。
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

## **カスタム画像ピクセル形式のTIFFにプレゼンテーションを変換**

[TiffOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/) クラスの [setPixelFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) メソッドを使用すると、生成される TIFF 画像のピクセル形式を好きなものに指定できます。

この JavaScript コードは、カスタムピクセル形式の TIFF 画像に PowerPoint プレゼンテーションを変換する方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// プレゼンテーション ファイル（PPT、PPTX、ODP など）を表す Presentation クラスのインスタンスを生成します。
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat には次の値が含まれます（ドキュメントに記載されている通り）:
        Format1bppIndexed - 1 ビット/ピクセル、インデックスカラー。
        Format4bppIndexed - 4 ビット/ピクセル、インデックスカラー。
        Format8bppIndexed - 8 ビット/ピクセル、インデックスカラー。
        Format24bppRgb    - 24 ビット/ピクセル、RGB。
        Format32bppArgb   - 32 ビット/ピクセル、ARGB。
    */

    /// 指定した画像サイズでプレゼンテーションを TIFF として保存します。
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="ヒント" color="info" %}}
Aspose の [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/ja/conversion/convert-ppt-to-poster-online) をぜひご利用ください。
{{% /alert %}}

## **よくある質問**

**個々のスライドだけを TIFF に変換できますか？**

はい。Aspose.Slides を使用すると、PowerPoint および OpenDocument プレゼンテーションから個々のスライドを別々の TIFF 画像として変換できます。

**プレゼンテーションを TIFF に変換する際、スライド数に制限はありますか？**

いいえ、Aspose.Slides はスライド数に制限を設けていません。任意のサイズのプレゼンテーションを TIFF 形式に変換できます。

**スライドを TIFF に変換すると、PowerPoint のアニメーションやトランジション効果は保持されますか？**

保持されません。TIFF は静的画像形式です。そのため、アニメーションやトランジション効果は保持されず、スライドの静止画がエクスポートされます。