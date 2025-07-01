---
title: Python でプレゼンテーションを TIFF に変換する
titlelink: PowerPoint から TIFF
type: docs
weight: 90
url: /ja/python-net/convert-powerpoint-to-tiff/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して、PowerPoint (PPT、PPTX) および OpenDocument (ODP) プレゼンテーションを高品質の TIFF 画像に簡単に変換する方法を学びましょう。ステップバイステップのガイドとコード例付き。"
---

**TIFF**（Tagged Image File Format）は、ロスレスラスタおよび高品質な画像フォーマットです。プロフェッショナルは、デザイン、写真、デスクトップパブリッシングの目的でTIFFを使用します。たとえば、デザインや画像のレイヤーや設定を保持したい場合は、作業をTIFF画像ファイルとして保存したいかもしれません。

Aspose.Slidesを使用すると、PowerPointのスライドを直接TIFFに変換できます。

{{% alert title="ヒント" color="primary" %}}

Asposeの[無料PowerPointからポスターへの変換ツール](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)をぜひご覧ください。

{{% /alert %}}

## **PowerPointをTIFFに変換**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスが公開する[Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods)メソッドを使用すると、全体のPowerPointプレゼンテーションを迅速にTIFFに変換できます。生成されるTIFF画像はスライドのデフォルトサイズに対応します。

このPythonコードは、PowerPointをTIFFに変換する方法を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
presentation = slides.Presentation("pres.pptx")
# プレゼンテーションをTIFFとして保存
presentation.save("Tiffoutput_out.tiff", slides.export.SaveFormat.TIFF)
```

## **PowerPointを白黒TIFFに変換**

Aspose.Slides 23.10では、[TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/)クラスに新しいプロパティ`bw_conversion_mode`が追加され、カラースライドまたは画像が白黒TIFFに変換される際に従うアルゴリズムを指定できます。この設定は、`compression_type`プロパティが`CCITT4`または`CCITT3`に設定されている場合にのみ適用されます。

このPythonコードは、カラーのスライドまたは画像を白黒TIFFに変換する方法を示しています：

```python
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

presentation = slides.Presentation("sample.pptx")
presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **カスタムサイズでPowerPointをTIFFに変換**

指定された寸法のTIFF画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/)の下に提供されるプロパティを通じて希望する数値を定義できます。たとえば、`image_size`プロパティを使用することで、結果の画像のサイズを設定できます。

このPythonコードは、カスタムサイズのTIFF画像にPowerPointを変換する方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
pres = slides.Presentation("pres.pptx")

# TiffOptionsクラスをインスタンス化
opts = slides.export.TiffOptions()

# 圧縮タイプを設定
opts.compression_type = slides.export.TiffCompressionTypes.DEFAULT
opts.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# 画像のDPIを設定
opts.dpi_x = 200
opts.dpi_y = 100

# 画像サイズを設定
opts.image_size = drawing.Size(1728, 1078)

# 指定したサイズでプレゼンテーションをTIFFとして保存
pres.save("TiffWithCustomSize_out.tiff", slides.export.SaveFormat.TIFF, opts)
```

## **カスタム画像ピクセルフォーマットでPowerPointをTIFFに変換**

[TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/)クラスの下にある`pixel_format`プロパティを使用することで、生成されるTIFF画像の希望するピクセルフォーマットを指定できます。

このPythonコードは、カスタムピクセルフォーマットでPowerPointをTIFF画像に変換する方法を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
pres = slides.Presentation("pres.pptx")

# TiffOptionsクラスをインスタンス化
options = slides.export.TiffOptions()

options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED

# 指定したサイズでプレゼンテーションをTIFFとして保存
pres.save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", slides.export.SaveFormat.TIFF, options)
```