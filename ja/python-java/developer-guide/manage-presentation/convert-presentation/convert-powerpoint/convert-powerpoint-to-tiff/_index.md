---
title: PythonでPowerPointプレゼンテーションをTIFFに変換
linktitle: PowerPointからTIFFへ
type: docs
weight: 90
url: /ja/python-java/convert-powerpoint-to-tiff/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint（PPT、PPTX）プレゼンテーションを高品質な TIFF 画像に簡単に変換する方法を、コード例とともに学びましょう。"
---
## **はじめに**

TIFF (**Tagged Image File Format**) は、複数ページとロスレス圧縮をサポートするラスター画像フォーマットです。単一の画像ファイルにレンダリングされたスライドを保存するのに便利です。

Aspose.Slides for Python via Java を使用すると、PowerPoint (PPT、PPTX) および OpenDocument (ODP) プレゼンテーションを TIFF に変換できます。以下の各例は、必要に応じて Java 仮想マシンを起動し、使用後にプレゼンテーションを解放します。

## **プレゼンテーションを TIFF に変換する**

[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスが提供する [save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドを使用すると、PowerPoint プレゼンテーション全体を簡単に TIFF に変換できます。生成されたマルチページ TIFF には、デフォルトサイズでレンダリングされた各スライドの画像が含まれます。

以下のコードは、PowerPoint プレゼンテーションを TIFF に変換する方法を示しています:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # すべてのスライドをマルチページTIFFファイルに保存します。
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **プレゼンテーションを白黒 TIFF に変換する**

[TiffOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/) クラスの [setBwConversionMode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/#setBwConversionMode) メソッドを使用すると、カラー スライドまたは画像を白黒 TIFF に変換する際に使用するアルゴリズムを指定できます。この設定は、[setCompressionType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/#setCompressionType) メソッドが [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) または [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffcompressiontypes/#CCITT3) に設定されている場合にのみ適用されます。

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/#setBwConversionMode) は、TIFF 画像全体に対するピクセル変換アルゴリズムを選択するエクスポートレベルの設定です。個々のシェイプを白黒表示モードでどのように描画するかを指定したい場合は、[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#setBlackWhiteMode) を使用してください。[シェイプの白黒レンダリングの制御](/slides/ja/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) に例があります。
{{% /alert %}}

たとえば、次のようなスライドを含む "sample.pptx" ファイルがあるとします。

![A presentation slide](slide_black_and_white.png)

以下のコードは、カラー スライドを白黒 TIFF に変換する方法を示しています:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

結果:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **カスタムサイズの TIFF にプレゼンテーションを変換する**

特定の寸法を持つ TIFF 画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/) に用意されているメソッドを使用して希望の値を設定できます。たとえば、[setImageSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/#setImageSize) メソッドを使用すると、生成される画像のサイズを指定できます。

以下のコードは、カスタムサイズの TIFF 画像に PowerPoint プレゼンテーションを変換する方法を示しています:

```python
import jpype
import asposeslides

if not jp<|...|>isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # 水平および垂直解像度を設定します。
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # 出力サイズをピクセル単位で設定します。
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # 各スライドの下に完全なスピーカーノートを含めます。
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **カスタム画像ピクセル形式の TIFF にプレゼンテーションを変換する**

[TiffOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/) クラスの [setPixelFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/#setPixelFormat) メソッドを使用すると、生成される TIFF 画像のピクセル形式を好きなものに指定できます。

以下のコードは、カスタムピクセル形式の TIFF 画像に PowerPoint プレゼンテーションを変換する方法を示しています:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="Tip" color="success" %}}
Aspose の [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/ja/conversion/convert-ppt-to-poster-online) をぜひお試しください。
{{% /alert %}}

## **FAQ**

**個別のスライドだけを TIFF に変換できますか？**

はい。Aspose.Slides を使用すると、PowerPoint および OpenDocument プレゼンテーションから個々のスライドを個別に TIFF 画像に変換できます。

**プレゼンテーションを TIFF に変換する際、スライド数に制限はありますか？**

TIFF エクスポートに固定されたスライド数の上限はありません。利用可能なメモリ、スライドの複雑さ、出力サイズが処理可能なプレゼンテーションの規模に影響します。

**スライドを TIFF に変換すると、PowerPoint のアニメーションやトランジション効果は保持されますか？**

保持されません。TIFF は静的画像フォーマットのため、アニメーションやトランジション効果は保存されず、スライドの静止画のみがエクスポートされます。