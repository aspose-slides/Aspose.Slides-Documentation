---
title: Python で PowerPoint プレゼンテーションを TIFF に変換
titlelink: PowerPoint を TIFF に変換
type: docs
weight: 90
url: /ja/python-net/convert-powerpoint-to-tiff/
keywords:
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーションを変換
- スライドを変換
- PowerPoint を TIFF に変換
- OpenDocument を TIFF に変換
- プレゼンテーションを TIFF に変換
- スライドを TIFF に変換
- PPT を TIFF に変換
- PPTX を TIFF に変換
- ODP を TIFF に変換
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint (PPT、PPTX) および OpenDocument (ODP) プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を学びます。コード例を含むステップバイステップガイドです。"
---

## **概要**

TIFF (**Tagged Image File Format**) は、卓越した品質とグラフィックの詳細な保存で知られる、広く使用されているロスレスラスター画像形式です。デザイナー、フォトグラファー、デスクトップパブリッシャーは、画像のレイヤー、色精度、元の設定を維持するために TIFF を選択することが多いです。

Aspose.Slides を使用すると、PowerPoint スライド（PPT、PPTX）や OpenDocument スライド（ODP）を手間なく高品質な TIFF 画像に直接変換でき、プレゼンテーションの視覚的忠実度を最大限に保つことができます。

## **プレゼンテーションを TIFF に変換する**

「[save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods)」メソッドと「[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)」クラスを使用して、PowerPoint プレゼンテーション全体を迅速に TIFF に変換できます。生成される TIFF 画像はデフォルトのスライドサイズに対応します。

この Python コードは、PowerPoint プレゼンテーションを TIFF に変換する方法を示しています:
```py
import aspose.slides as slides

# プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("presentation.pptx") as presentation:
    # プレゼンテーションを TIFF として保存します。
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```


## **プレゼンテーションを白黒 TIFF に変換する**

[TiffOptions] クラスの [bw_conversion_mode](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) プロパティを使用すると、カラーのスライドや画像を白黒 TIFF に変換する際に使用するアルゴリズムを指定できます。この設定は、[compression_type](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/compression_type/) プロパティが `CCITT4` または `CCITT3` に設定されている場合にのみ適用されます。

たとえば、次のスライドを含む "sample.pptx" ファイルがあるとします:
![プレゼンテーションスライド](slide_black_and_white.png)

この Python コードは、カラーのスライドを白黒 TIFF に変換する方法を示しています:
```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```


結果:
![白黒 TIFF](TIFF_black_and_white.png)

## **カスタムサイズの TIFF にプレゼンテーションを変換する**

特定のサイズの TIFF 画像が必要な場合は、[TiffOptions] クラスで利用可能なプロパティを使用して希望の値を設定できます。たとえば、[image_size] プロパティを使用すると、生成される画像のサイズを定義できます。

この Python コードは、PowerPoint プレゼンテーションをカスタムサイズの TIFF 画像に変換する方法を示しています:
```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# プレゼンテーション ファイル (PPT、PPTX、ODP 等) を表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # 圧縮タイプを設定します。
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    圧縮タイプ:
        Default - デフォルトの圧縮方式 (LZW) を指定します。
        None - 圧縮なしを指定します。
        CCITT3
        CCITT4
        LZW
        RLE
    """

    # 画像の DPI を設定します。
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # 画像サイズを設定します。
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # 指定したサイズでプレゼンテーションを TIFF として保存します。
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```


## **カスタム画像ピクセル形式の TIFF にプレゼンテーションを変換する**

[TiffOptions] クラスの [pixel_format] プロパティを使用すると、生成される TIFF 画像の希望するピクセル形式を指定できます。

この Python コードは、PowerPoint プレゼンテーションをカスタムピクセル形式の TIFF 画像に変換する方法を示しています:
```py
import aspose.slides as slides

# プレゼンテーション ファイル (PPT、PPTX、ODP 等) を表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat には次の値が含まれます（ドキュメントに記載のとおり）：
        FORMAT_1BPP_INDEXED - 1 ビット/ピクセル、インデックス形式。
        FORMAT_4BPP_INDEXED - 4 ビット/ピクセル、インデックス形式。
        FORMAT_8BPP_INDEXED - 8 ビット/ピクセル、インデックス形式。
        FORMAT_24BPP_RGB    - 24 ビット/ピクセル、RGB。
        FORMAT_32BPP_ARGB   - 32 ビット/ピクセル、ARGB。
    """

    # 指定された画像サイズでプレゼンテーションを TIFF として保存します。
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```


{{% alert title="Tip" color="primary" %}}
Aspose の [無料 PowerPoint → ポスター変換ツール](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) をチェックしてください。
{{% /alert %}}

## **FAQ**

**個々のスライドだけを TIFF に変換できますか？**

はい。Aspose.Slides を使用すると、PowerPoint および OpenDocument プレゼンテーションの個別のスライドを別々に TIFF 画像に変換できます。

**プレゼンテーションを TIFF に変換する際、スライド数に制限はありますか？**

いいえ、Aspose.Slides にはスライド数の制限はありません。任意のサイズのプレゼンテーションを TIFF 形式に変換できます。

**PowerPoint のアニメーションやトランジション効果は TIFF に変換したときに保持されますか？**

いいえ、TIFF は静的画像形式です。そのため、アニメーションやトランジション効果は保持されず、スライドの静止画のみがエクスポートされます。