---
title: ".NET で PowerPoint プレゼンテーションを TIFF に変換"
titlelink: "PowerPoint を TIFF に変換"
type: docs
weight: 90
url: /ja/net/convert-powerpoint-to-tiff/
keywords:
- "PowerPoint を変換"
- "OpenDocument を変換"
- "プレゼンテーションを変換"
- "スライドを変換"
- "PPT を変換"
- "PPTX を変換"
- "PowerPoint を TIFF に変換"
- "プレゼンテーションを TIFF に変換"
- "スライドを TIFF に変換"
- "PPT を TIFF に変換"
- "PPTX を TIFF に変換"
- "PPT を TIFF で保存"
- "PPTX を TIFF で保存"
- "PPT を TIFF にエクスポート"
- "PPTX を TIFF にエクスポート"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して、PowerPoint（PPT、PPTX）プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を学びます。C# コード例付き。"
---

## **Overview**

TIFF (**Tagged Image File Format**) は、優れた品質と詳細なグラフィック保存で広く使用されているロスレスラスター画像形式です。デザイナー、写真家、デスクトップパブリッシャーは、レイヤー、色精度、元の設定を保持するために TIFF を選択することが多いです。

Aspose.Slides を使用すれば、PowerPoint スライド (PPT、PPTX) と OpenDocument スライド (ODP) を直接高品質な TIFF 画像に簡単に変換でき、プレゼンテーションの視覚的忠実度を最大限に保つことができます。

## **Convert a Presentation to TIFF**

[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドを使用し、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスから PowerPoint プレゼンテーション全体を TIFF にすばやく変換できます。生成される TIFF 画像はデフォルトのスライド サイズに対応します。

この C# コードは、PowerPoint プレゼンテーションを TIFF に変換する方法を示しています:
```cs
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // プレゼンテーションを TIFF として保存します。
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```


## **Convert a Presentation to Black-and-White TIFF**

[TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) クラスの [BwConversionMode](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/bwconversionmode/) プロパティを使用すると、カラースライドや画像を白黒 TIFF に変換する際のアルゴリズムを指定できます。この設定は、[CompressionType](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) プロパティが `CCITT4` または `CCITT3` に設定されている場合にのみ適用されます。

例えば、次のような "sample.pptx" ファイルがあるとします:

![プレゼンテーションスライド](slide_black_and_white.png)

この C# コードは、カラー スライドを白黒 TIFF に変換する方法を示しています:
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

## **Convert a Presentation to TIFF with Custom Size**

特定のサイズの TIFF 画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) のプロパティを使用して希望の値を設定できます。例えば、[ImageSize](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) プロパティを使用すると、生成される画像のサイズを定義できます。

この C# コードは、PowerPoint プレゼンテーションをカスタムサイズの TIFF 画像に変換する方法を示しています:
```cs
// プレゼンテーションファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // 圧縮タイプを設定します。
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
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


## **Convert a Presentation to TIFF with Custom Image Pixel Format**

[TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions) クラスの [PixelFormat](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) プロパティを使用すると、生成される TIFF 画像のピクセル形式を指定できます。

この C# コードは、カスタムピクセル形式で TIFF 画像に変換する方法を示しています:
```cs
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat には以下の値が含まれます（ドキュメントに記載のとおり）：
        Format1bppIndexed - 1 ビット/ピクセル、インデックス形式。
        Format4bppIndexed - 4 ビット/ピクセル、インデックス形式。
        Format8bppIndexed - 8 ビット/ピクセル、インデックス形式。
        Format24bppRgb    - 24 ビット/ピクセル、RGB。
        Format32bppArgb   - 32 ビット/ピクセル、ARGB。
    */

    // 指定した画像サイズでプレゼンテーションを TIFF として保存します。
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```


{{% alert title="Tip" color="primary" %}}

Aspose の [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) をご確認ください。

{{% /alert %}}

## **FAQ**

**個々のスライドだけを TIFF に変換できますか？**

はい。Aspose.Slides を使用すると、PowerPoint および OpenDocument プレゼンテーションの個別スライドを TIFF 画像として個別に変換できます。

**プレゼンテーションを TIFF に変換する際、スライド数に制限はありますか？**

いいえ、Aspose.Slides はスライド数に制限を設けていません。任意のサイズのプレゼンテーションを TIFF 形式に変換できます。

**スライドを TIFF に変換すると、PowerPoint のアニメーションやトランジション効果は保持されますか？**

保持されません。TIFF は静止画像形式です。そのため、アニメーションやトランジション効果は保存されず、スライドの静的なスナップショットのみがエクスポートされます。