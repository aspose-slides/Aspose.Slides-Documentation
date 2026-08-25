---
title: "PowerPoint プレゼンテーションを .NET で TIFF に変換する"
titlelink: "PowerPoint から TIFF へ"
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
- "PowerPoint から TIFF へ"
- "プレゼンテーションを TIFF に変換"
- "スライドを TIFF に変換"
- "PPT を TIFF に変換"
- "PPTX を TIFF に変換"
- "PPT を TIFF として保存"
- "PPTX を TIFF として保存"
- "PPT を TIFF にエクスポート"
- "PPTX を TIFF にエクスポート"
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint（PPT、PPTX）プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を学びます。C# コード例。"
---
## **はじめに**

TIFF (**Tagged Image File Format**) は、品質が非常に高く、グラフィックの詳細な保存が可能な、広く使用されているロスレスラスター画像フォーマットです。デザイナー、写真家、デスクトップパブリッシャーは、レイヤー、色精度、元の設定を画像に保持するために TIFF を選択することが多いです。

Aspose.Slides を使用すれば、PowerPoint スライド (PPT、PPTX) および OpenDocument スライド (ODP) を直接高品質な TIFF 画像に簡単に変換でき、プレゼンテーションの視覚的忠実度を最大限に保つことができます。 

## **プレゼンテーションを TIFF に変換する**

[保存](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドと [プレゼンテーション](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスを使用して、PowerPoint プレゼンテーション全体を迅速に TIFF に変換できます。生成される TIFF 画像はデフォルトのスライドサイズに対応します。

この C# コードは、PowerPoint プレゼンテーションを TIFF に変換する方法を示しています:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイル（PPT、PPTX、ODP など）を表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // プレゼンテーションを TIFF として保存します。
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **プレゼンテーションを白黒 TIFF に変換する**

[BwConversionMode](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/bwconversionmode/) プロパティは、[TiffOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/) クラス内で、カラー スライドまたは画像を白黒 TIFF に変換する際に使用するアルゴリズムを指定できます。この設定は、[CompressionType](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/compressiontype/) プロパティが `CCITT4` または `CCITT3` に設定されている場合にのみ適用されます。

{{% alert color="info" title="Note" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/bwconversionmode/) は、完全な TIFF 画像のピクセル変換アルゴリズムを選択するエクスポートレベルの設定です。黒白表示モードが有効なときに個々のシェイプの表示方法を定義するには、[IShape.BlackWhiteMode](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/blackwhitemode/) を使用します。例については、[シェイプの白黒レンダリングの制御](/slides/ja/net/shape-formatting/#control-black-and-white-rendering-for-shapes) を参照してください。
{{% /alert %}}

たとえば、次のスライドを含む "sample.pptx" ファイルがあるとします。

![プレゼンテーション スライド](slide_black_and_white.png)

この C# コードは、カラー スライドを白黒 TIFF に変換する方法を示しています:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

特定のサイズの TIFF 画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/) に用意されているプロパティを使用して希望の値を設定できます。例えば、[ImageSize](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/imagesize/) プロパティを使用すると、生成される画像のサイズを定義できます。

この C# コードは、カスタムサイズの TIFF 画像に PowerPoint プレゼンテーションを変換する方法を示しています:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイル（PPT、PPTX、ODP など）を表す Presentation クラスのインスタンスを作成します。
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

    // 指定されたサイズでプレゼンテーションを TIFF として保存します。
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **カスタム画像ピクセルフォーマットの TIFF にプレゼンテーションを変換する**

[PixelFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/pixelformat/) プロパティを [TiffOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions) クラスから使用すると、生成される TIFF 画像の希望するピクセルフォーマットを指定できます。

この C# コードは、カスタムピクセルフォーマットの TIFF 画像に PowerPoint プレゼンテーションを変換する方法を示しています:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation クラスのインスタンスを作成します（PPT、PPTX、ODP などのプレゼンテーション ファイルを表します）。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat には以下の値が含まれます（ドキュメントに記載のとおり）：
        Format1bppIndexed - 1 ピクセルあたり 1 ビット、インデックス形式。
        Format4bppIndexed - 1 ピクセルあたり 4 ビット、インデックス形式。
        Format8bppIndexed - 1 ピクセルあたり 8 ビット、インデックス形式。
        Format24bppRgb    - 1 ピクセルあたり 24 ビット、RGB。
        Format32bppArgb   - 1 ピクセルあたり 32 ビット、ARGB。
    */

    // 指定された画像サイズでプレゼンテーションを TIFF として保存します。
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}
Aspose の [無料 PowerPoint からポスターへのコンバータ](https://products.aspose.app/slides/ja/conversion/convert-ppt-to-poster-online) をご確認ください。
{{% /alert %}}

## **よくある質問**

**個々のスライドだけを TIFF に変換できますか？**

はい。Aspose.Slides を使用すると、PowerPoint および OpenDocument プレゼンテーションの個々のスライドを個別に TIFF 画像に変換できます。

**プレゼンテーションを TIFF に変換する際、スライド数に制限はありますか？**

いいえ、Aspose.Slides にはスライド数の制限はありません。任意のサイズのプレゼンテーションを TIFF 形式に変換できます。

**PowerPoint のアニメーションやトランジション効果は、スライドを TIFF に変換するときに保持されますか？**

いいえ、TIFF は静的画像形式です。そのため、アニメーションやトランジション効果は保持されず、スライドの静止スナップショットのみがエクスポートされます。