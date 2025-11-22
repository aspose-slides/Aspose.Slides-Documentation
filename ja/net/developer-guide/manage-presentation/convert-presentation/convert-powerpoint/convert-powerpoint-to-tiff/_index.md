---
title: C# で PowerPoint プレゼンテーションを TIFF に変換する
titlelink: PowerPoint を TIFF に変換
type: docs
weight: 90
url: /ja/net/convert-powerpoint-to-tiff/
keywords:
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーションを変換
- スライドを変換
- PowerPoint を TIFF に
- OpenDocument を TIFF に
- プレゼンテーションを TIFF に
- スライドを TIFF に
- PPT を TIFF に
- PPTX を TIFF に
- ODP を TIFF に
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint (PPT、PPTX) および OpenDocument (ODP) プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を学びましょう。コード例付きのステップバイステップガイドです。"
---

## **概要**

TIFF（**Tagged Image File Format**）は、優れた画質とグラフィックの詳細な保持で知られる、広く使用されているロスレスラスタ画像フォーマットです。デザイナー、写真家、デスクトップパブリッシャーは、レイヤー、色精度、元の設定を画像に保持するために TIFF を選択することが多いです。

Aspose.Slides を使用すると、PowerPoint スライド（PPT、PPTX）や OpenDocument スライド（ODP）を高品質な TIFF 画像に簡単に変換でき、プレゼンテーションの視覚的忠実度を最大限に保つことができます。

## **プレゼンテーションを TIFF に変換する**

[保存](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドを [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスで使用すると、PowerPoint プレゼンテーション全体をすばやく TIFF に変換できます。生成される TIFF 画像はデフォルトのスライドサイズに対応しています。

この C# コードは、PowerPoint プレゼンテーションを TIFF に変換する方法を示しています:
```cs
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // プレゼンテーションを TIFF として保存します。
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```


## **プレゼンテーションを白黒 TIFF に変換する**

[TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) クラスのプロパティ [BwConversionMode](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/bwconversionmode/) を使用すると、カラーのスライドまたは画像を白黒 TIFF に変換する際に使用するアルゴリズムを指定できます。この設定は、[CompressionType](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) プロパティが `CCITT4` または `CCITT3` に設定されている場合にのみ適用されます。

たとえば、次のような「sample.pptx」ファイルがあるとします:

![プレゼンテーションスライド](slide_black_and_white.png)

この C# コードは、カラーのスライドを白黒 TIFF に変換する方法を示しています:
```cs
TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```


結果:

![白黒 TIFF](TIFF_black_and_white.png)

## **カスタムサイズの TIFF にプレゼンテーションを変換する**

特定のサイズの TIFF 画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) で利用できるプロパティを使用して希望の値を設定できます。たとえば、[ImageSize](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) プロパティを使用すると、生成される画像のサイズを定義できます。

この C# コードは、PowerPoint プレゼンテーションをカスタムサイズの TIFF 画像に変換する方法を示しています:
```cs
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // 圧縮タイプを設定します。
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    圧縮タイプ:
        Default - デフォルトの圧縮方式 (LZW) を指定します。
        None - 圧縮しないことを指定します。
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // 深度は圧縮タイプに依存し、手動で設定できません。

    // 画像の DPI を設定します。
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // 画像サイズを設定します。
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // 指定したサイズでプレゼンテーションを TIFF として保存します。
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```


## **カスタム画像ピクセル形式の TIFF にプレゼンテーションを変換する**

[TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions) クラスの [PixelFormat](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) プロパティを使用すると、生成される TIFF 画像のピクセル形式を指定できます。

この C# コードは、カスタムピクセル形式の TIFF 画像に PowerPoint プレゼンテーションを変換する方法を示しています:
```cs
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat には以下の値が含まれます（ドキュメントに記載のとおり）:
        Format1bppIndexed - 1 ピクセルあたり 1 ビット、インデックスカラー。
        Format4bppIndexed - 1 ピクセルあたり 4 ビット、インデックスカラー。
        Format8bppIndexed - 1 ピクセルあたり 8 ビット、インデックスカラー。
        Format24bppRgb    - 1 ピクセルあたり 24 ビット、RGB。
        Format32bppArgb   - 1 ピクセルあたり 32 ビット、ARGB。
    */

    // 指定した画像サイズでプレゼンテーションを TIFF として保存します。
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```


{{% alert title="Tip" color="primary" %}}

Aspose の [無料 PowerPoint からポスターへの変換ツール](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) をチェックしてください。

{{% /alert %}}

## **FAQ**

**個々のスライドだけを TIFF に変換できますか？**

はい。Aspose.Slides を使用すると、PowerPoint および OpenDocument プレゼンテーションから個別のスライドを TIFF 画像として個別に変換できます。

**プレゼンテーションを TIFF に変換する際、スライド数に制限はありますか？**

いいえ、Aspose.Slides にはスライド数に対する制限はありません。任意のサイズのプレゼンテーションを TIFF 形式に変換できます。

**スライドを TIFF に変換する際、PowerPoint のアニメーションやトランジション効果は保持されますか？**

いいえ、TIFF は静止画像形式です。そのため、アニメーションやトランジション効果は保持されず、スライドの静的なスナップショットのみがエクスポートされます。