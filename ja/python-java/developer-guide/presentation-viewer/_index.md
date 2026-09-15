---
title: Python via Java でプレゼンテーション ビューアを作成する
linktitle: プレゼンテーション ビューア
type: docs
weight: 50
url: /ja/python-java/presentation-viewer/
keywords:
- プレゼンテーションを表示
- プレゼンテーションビューア
- プレゼンテーションビューアを作成
- PPT を表示
- PPTX を表示
- ODP を表示
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Python via Java でカスタム プレゼンテーション ビューアを作成します。Microsoft PowerPoint がなくても PowerPoint および OpenDocument ファイルを簡単に表示できます。"
---
## **イントロダクション**

Aspose.Slides for Python via Java は、スライドを含むプレゼンテーション ファイルの作成に使用されます。たとえば、Microsoft PowerPoint でプレゼンテーションを開くことで、これらのスライドを表示できます。しかし、開発者がスライドを画像として好みの画像ビューアで表示したり、独自のプレゼンテーションビューアを作成したりする必要がある場合があります。そのような場合、Aspose.Slides を使用すると個々のスライドを画像としてエクスポートできます。この記事ではその方法を説明します。

## **スライドから SVG 画像を生成する**

Aspose.Slides を使用してプレゼンテーション スライドから SVG 画像を生成するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. バイト ストリームを開きます。
1. スライドを SVG 画像としてストリームに保存し、ファイルに書き出します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **カスタム シェイプ ID で SVG を生成する**

Aspose.Slides を使用して、カスタム シェイプ ID を持つスライドから [SVG](https://docs.fileformat.com/page-description-language/svg/) を生成できます。これを行うには、[SvgShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgshape/) の [SvgShape.setId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgshape/#setId) メソッドを使用します。`CustomSvgShapeFormattingController` を使用してシェイプ ID を設定できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **スライドのサムネイル画像を作成する**

Aspose.Slides はスライドのサムネイル画像の生成を支援します。Aspose.Slides を使用してスライドのサムネイルを生成するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. 定義したスケールで参照スライドのサムネイル画像を取得します。
1. 必要な画像形式でサムネイル画像を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **ユーザー定義のサイズでスライドサムネイルを作成する**

ユーザー定義のサイズでスライドのサムネイル画像を作成するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. 定義したサイズで参照スライドのサムネイル画像を取得します。
1. 必要な画像形式でサムネイル画像を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **スピーカーノート付きスライドサムネイルを作成する**

Aspose.Slides を使用してスピーカーノート付きスライドのサムネイルを生成するには、以下の手順に従ってください：

1. [RenderingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/renderingoptions/) クラスのインスタンスを作成します。
1. スピーカーノートの位置を設定するには、[RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) メソッドを使用します。
1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. レンダリングオプションを使用して参照スライドのサムネイル画像を取得します。
1. 必要な画像形式でサムネイル画像を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **ライブ例**

Aspose.Slides API で実装できることを確認するには、無料アプリの [**Aspose.Slides Viewer**](https://products.aspose.app/slides/ja/viewer/) を試すことができます：

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**ウェブ アプリケーションにプレゼンテーション ビューアを埋め込むことはできますか？**

はい。サーバー側で Aspose.Slides を使用してスライドを画像または HTML としてレンダリングし、ブラウザーに表示できます。ナビゲーションやズーム機能は JavaScript で実装でき、インタラクティブな体験を提供します。

**カスタム ビューア内でスライドを表示する最適な方法は何ですか？**

推奨される方法は、各スライドを画像（PNG や SVG など）としてレンダリングするか、Aspose.Slides を使用して HTML に変換し、デスクトップの場合はピクチャーボックス、ウェブの場合は HTML コンテナ内に表示することです。

**スライドが多数含まれる大規模なプレゼンテーションをどのように処理しますか？**

大規模なデッキの場合、スライドの遅延ロードやオンデマンドレンダリングを検討してください。ユーザーがスライドに移動したときにのみコンテンツを生成することで、メモリ使用量と読み込み時間を削減できます。