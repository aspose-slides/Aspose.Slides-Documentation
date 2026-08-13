---
title: .NET で PowerPoint プレゼンテーションを TIFF に変換する
titlelink: PowerPoint を TIFF に変換
type: docs
weight: 90
url: /ja/net/convert-powerpoint-to-tiff/
keywords:
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を TIFF に変換
- プレゼンテーションを TIFF に変換
- スライドを TIFF に変換
- PPT を TIFF に変換
- PPTX を TIFF に変換
- PPT を TIFF として保存
- PPTX を TIFF として保存
- PPT を TIFF にエクスポート
- PPTX を TIFF にエクスポート
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint（PPT、PPTX）プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を学びます。C# のコード例付き。"
---
## **イントロダクション**

TIFF (**Tagged Image File Format**) は、卓越した品質と詳細なグラフィック保存で知られる、広く使用されているロスレスラスター画像形式です。デザイナー、フォトグラファー、デスクトップパブリッシャーは、画像のレイヤー、色精度、元の設定を保持するために TIFF を選択することが多いです。

Aspose.Slides を使用すると、PowerPoint スライド (PPT、PPTX) や OpenDocument スライド (ODP) を直接高品質な TIFF 画像に簡単に変換でき、プレゼンテーションの視覚的忠実度を最大限に保つことができます。 

## **プレゼンテーションを TIFF に変換する**

[Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドを [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスが提供することで、PowerPoint プレゼンテーション全体を迅速に TIFF に変換できます。生成される TIFF 画像はデフォルトのスライドサイズに対応します。

この C# コードは、PowerPoint プレゼンテーションを TIFF に変換する方法を示しています：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーションファイル（PPT、PPTX、ODP、等）を表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // プレゼンテーションを TIFF として保存します。
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **プレゼンテーションを白黒 TIFF に変換する**

[TiffOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/) クラスの [BwConversionMode](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/bwconversionmode/) プロパティを使用すると、カラーのスライドや画像を白黒 TIFF に変換する際のアルゴリズムを指定できます。この設定は、[CompressionType](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/compressiontype/) プロパティが `CCITT4` または `CCITT3` に設定されている場合にのみ適用されます。

たとえば、以下のスライドを含む「sample.pptx」ファイルがあるとします：

![プレゼンテーションスライド](slide_black_and_white.png)

この C# コードは、カラー スライドを白黒 TIFF に変換する方法を示しています：

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

結果：

![白黒 TIFF](TIFF_black_and_white.png)

## **カスタムサイズでプレゼンテーションを TIFF に変換する**

特定の寸法の TIFF 画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/) に用意されたプロパティを使用して希望の値を設定できます。たとえば、[ImageSize](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/imagesize/) プロパティを使用すると、生成される画像のサイズを定義できます。

この C# コードは、PowerPoint プレゼンテーションをカスタムサイズの TIFF 画像に変換する方法を示しています：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーションファイル（PPT、PPTX、ODP、等）を表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // 圧縮タイプを設定します。
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
        圧縮タイプ:
            Default - デフォルトの圧縮方式 (LZW) を指定します。
            None - 圧縮なしを指定します。
            CCITT3
            CCITT4
            LZW
            RLE
    */

    // 深さは圧縮タイプに依存し、手動で設定できません。

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

## **カスタム画像ピクセル形式でプレゼンテーションを TIFF に変換する**

[TiffOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions) クラスの [PixelFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/pixelformat/) プロパティを使用すると、生成される TIFF 画像のピクセル形式を好きなものに指定できます。

この C# コードは、PowerPoint プレゼンテーションをカスタムピクセル形式の TIFF 画像に変換する方法を示しています：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーションファイル（PPT、PPTX、ODP 等）を表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat には以下の値が含まれます（ドキュメントに記載されているとおり）:
        Format1bppIndexed - 1 ビット/ピクセル、インデックス方式。
        Format4bppIndexed - 4 ビット/ピクセル、インデックス方式。
        Format8bppIndexed - 8 ビット/ピクセル、インデックス方式。
        Format24bppRgb    - 24 ビット/ピクセル、RGB。
        Format32bppArgb   - 32 ビット/ピクセル、ARGB。
    */

    // 指定した画像サイズでプレゼンテーションを TIFF として保存します。
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}
Aspose の[無料 PowerPoint からポスターへのコンバーター](https://products.aspose.app/slides/ja/conversion/convert-ppt-to-poster-online)をご確認ください。
{{% /alert %}}

## **FAQ**

### 個々のスライドだけを TIFF に変換できますか？

はい。Aspose.Slides を使用すると、PowerPoint や OpenDocument プレゼンテーションから個別のスライドを TIFF 画像として別々に変換できます。

### プレゼンテーションを TIFF に変換する際、スライド数に制限はありますか？

いいえ、Aspose.Slides にはスライド数に関する制限はありません。任意のサイズのプレゼンテーションを TIFF 形式に変換できます。

### スライドを TIFF に変換する際、PowerPoint のアニメーションやトランジション効果は保持されますか？

保持されません。TIFF は静的画像形式であるため、アニメーションやトランジション効果は保存されず、スライドの静止画のみがエクスポートされます。