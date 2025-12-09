---
title: PowerPoint プレゼンテーションを .NET で TIFF に変換する
titlelink: PowerPoint を TIFF に
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
- PowerPoint を TIFF に
- プレゼンテーションを TIFF に
- スライドを TIFF に
- PPT を TIFF に
- PPTX を TIFF に
- PPT を TIFF として保存
- PPTX を TIFF として保存
- PPT を TIFF にエクスポート
- PPTX を TIFF にエクスポート
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint（PPT、PPTX）プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を学びます。C# コード例。"
---

## **概要**

TIFF (**Tagged Image File Format**) は、優れた品質とグラフィックの詳細な保存で知られる、広く使用されているロスレスラスター画像フォーマットです。デザイナー、写真家、デスクトップパブリッシャーは、画像のレイヤー、色精度、元の設定を保持するために TIFF を選択することが多いです。

Aspose.Slides を使用すると、PowerPoint スライド (PPT、PPTX) および OpenDocument スライド (ODP) を直接高品質な TIFF 画像に簡単に変換でき、プレゼンテーションの視覚的忠実度を最大限に保つことができます。 

## **プレゼンテーションを TIFF に変換**

提供されている [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスの [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドを使用すると、PowerPoint プレゼンテーション全体を迅速に TIFF に変換できます。生成された TIFF 画像はデフォルトのスライドサイズに対応します。

この C# コードは、PowerPoint プレゼンテーションを TIFF に変換する方法を示しています:
```cs
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // プレゼンテーションを TIFF として保存します。
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```


## **プレゼンテーションを白黒 TIFF に変換**

[BwConversionMode](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/bwconversionmode/) プロパティは、カラーのスライドまたは画像を白黒 TIFF に変換する際に使用されるアルゴリズムを指定できます。この設定は、[CompressionType](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) プロパティが `CCITT4` または `CCITT3` に設定されている場合にのみ適用されます。

例えば、次のスライドを含む "sample.pptx" ファイルがあるとします:

![プレゼンテーション スライド](slide_black_and_white.png)

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

## **カスタムサイズで TIFF にプレゼンテーションを変換**

特定の寸法の TIFF 画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) にあるプロパティを使用して希望の値を設定できます。たとえば、[ImageSize](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) プロパティを使用すると、生成される画像のサイズを定義できます。

この C# コードは、カスタムサイズで PowerPoint プレゼンテーションを TIFF 画像に変換する方法を示しています:
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
        None - 圧縮なしを指定します。
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


## **カスタム画像ピクセル形式で TIFF にプレゼンテーションを変換**

[PixelFormat](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) プロパティを使用して、生成される TIFF 画像の希望のピクセル形式を指定できます。

この C# コードは、カスタム ピクセル形式で PowerPoint プレゼンテーションを TIFF 画像に変換する方法を示しています:
```cs
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat には以下の値が含まれます（ドキュメントに記載されている通り）：
        Format1bppIndexed - 1 ピクセルあたり 1 ビット、インデックス付き。
        Format4bppIndexed - 1 ピクセルあたり 4 ビット、インデックス付き。
        Format8bppIndexed - 1 ピクセルあたり 8 ビット、インデックス付き。
        Format24bppRgb    - 1 ピクセルあたり 24 ビット、RGB。
        Format32bppArgb   - 1 ピクセルあたり 32 ビット、ARGB。
    */

    // 指定した画像サイズでプレゼンテーションを TIFF として保存します。
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```


{{% alert title="Tip" color="primary" %}}
Aspose の [無料 PowerPoint からポスターへのコンバータ](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) をご覧ください。
{{% /alert %}}

## **よくある質問**

**PowerPoint プレゼンテーション全体ではなく個別のスライドを TIFF に変換できますか？**

はい。Aspose.Slides を使用すると、PowerPoint および OpenDocument プレゼンテーションから個々のスライドを個別に TIFF 画像に変換できます。

**プレゼンテーションを TIFF に変換する際、スライド数に制限はありますか？**

いいえ、Aspose.Slides にはスライド数に関する制限はありません。任意のサイズのプレゼンテーションを TIFF 形式に変換できます。

**スライドを TIFF に変換する際、PowerPoint のアニメーションやトランジション効果は保持されますか？**

いいえ、TIFF は静止画像フォーマットです。そのため、アニメーションやトランジション効果は保持されず、スライドの静止スナップショットのみがエクスポートされます。