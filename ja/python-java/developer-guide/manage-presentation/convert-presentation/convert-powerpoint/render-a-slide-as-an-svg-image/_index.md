---
title: "Python を介した Java でプレゼンテーションスライドを SVG 画像としてレンダリング"
linktitle: "スライドから SVG へ"
type: docs
weight: 50
url: /ja/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint から SVG
- プレゼンテーションから SVG
- スライドから SVG
- PPT から SVG
- PPTX から SVG
- SVG エクスポートオプション
- インタラクティブ SVG
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python（Java 経由）で PowerPoint スライドを SVG 画像としてエクスポートし、フォント、テキスト、画像、ID、イベントを Aspose.Slides で制御します。"
---
## **概要**

SVGは、スケーラブルなXMLベースの画像フォーマットで、Web公開、スライドビューア、アクセシビリティのワークフロー、そして自動ポストプロセッシングに適しています。Aspose.Slides は各スライドを個別のSVGファイルとしてエクスポートし、テキスト、フォント、画像、およびSVG要素の書き出し方法を制御できます。

エクスポートされたSVGをコンパクトに保ち、ブラウザー間で予測可能にし、インタラクティブに使用できるようにしたい場合は、[SVGOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgoptions/) を使用します。

## **スライドをSVGとしてエクスポート**

[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) を作成し、スライドを選択して、[Slide.writeAsSvg](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/) を使用してストリームに書き込みます。例では既存の `presentation.pptx` ファイルが必要です。各例は必要に応じてJVMを起動し、出力ストリームを閉じます。以下の例は、プレゼンテーション内のすべてのスライドを個別のSVGファイルとしてエクスポートします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

ファイル名はループインデックスではなく、[Slide.getSlideNumber](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getSlideNumber) を使用します。また、スライドビューアやウェブページが特定のシェイプだけを必要とする場合は、[Shape.writeAsSvg](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) を使用して個別のシェイプをエクスポートすることもできます。

## **SVG出力の構成**

[SVGOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgoptions/) はSVGのレンダリングを制御します。テキストフレームの場合、[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgoptions/#setUseFrameSize) はレンダリング領域にテキストフレームを含め、[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgoptions/#setUseFrameRotation) はフレーム回転を適用するかどうかを決定します。テキストをリガチャなしで描画する必要がある場合は、[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) を `True` に設定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **テキストとフォントの制御**

### **すべてのテキストをベクトル化**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgoptions/#setVectorizeText) を `True` に設定すると、スライド上のすべてのテキストがベクトルグラフィックとして書き出されます。これによりフォントへの依存がなくなり、ブラウザー間での見た目がより一貫しますが、テキストはSVGテキストとして選択や検索ができなくなります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **外部フォントの取り扱い方法を選択**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) は、外部からロードされるフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgexternalfontshandling/) の値を使用します。`AddLinksToFontFiles` を選択すると個別のフォントファイルへの参照が生成され、`Embed` を選択するとフォントデータがSVGに埋め込まれ、`Vectorize` を選択すると外部フォントを使用するテキストのみがグラフィックとして描画されます。フォントを埋め込む前に、フォントのライセンスを確認してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **埋め込み画像サイズの縮小**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgoptions/#setPicturesCompression) を使用して埋め込み画像の解像度を下げ、[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) で切り取られた元領域を除外し、[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgoptions/#setJpegQuality) で JPEG エンコード品質を制御します。これらの設定は画像の忠実度や保持データを犠牲にしてファイルサイズを削減します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **シェイプとテキストに安定した ID を割り当てる**

`jpype.JProxy` を介して登録された Python フォーマットコントローラを使用して、シェイプに対して [SvgShape.setId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgshape/#setId) の値を、テキストの `tspan` 要素に対して [SvgTSpan.setId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgtspan/#setId) の値を割り当てます。プロキシは [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgoptions/#setShapeFormattingController) で設定します。

以下のコントローラは、シェイプの存続期間中安定した [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getOfficeInteropShapeId) と、テキストスパン用の繰り返し可能なカウンタを使用します。これにより、生成された ID は変更されていないプレゼンテーションのポストプロセッシングに適したものになります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **SVG イベントハンドラの追加**

Python フォーマットコントローラ内で、[SvgShape.setEventHandler](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgshape/#setEventHandler) に [SvgEvent](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgevent/) の値を渡してエクスポートされたシェイプに JavaScript イベントハンドラを追加します。コントローラは `jpype.JProxy` で登録し、[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgoptions/#setShapeFormattingController) で割り当てます。結果をホストするページまたは SVG ドキュメント内で JavaScript 関数を定義してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

ホストページはハンドラが参照する JavaScript 関数を定義できます。ID とイベントハンドラを割り当てることで、スライドビューアやアクセシビリティの向上、その他のインタラクティブな SVG ワークフローが可能になります。

## **FAQ**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgoptions/#setVectorizeText) を [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) の代わりに使用すべき場合はいつですか？**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgoptions/#setVectorizeText) は、すべてのテキストをフォントに依存しないようにしたい場合に使用します。[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) は、外部フォントを使用するテキストだけをグラフィックに変換したい場合に使用します。

**SVG を小さくする最適な方法は何ですか？**

まず、埋め込み画像を圧縮し、切り取られた画像領域を削除し、対象環境で提供できる場合はリンクされたフォントファイルを選択します。画像解像度の低下、JPEG 品質の低下、テキストのベクトル化はそれぞれ品質とサイズのトレードオフが異なるため、結果をテストしてください。

**エクスポート後に SVG 要素を変更できますか？**

はい。フォーマットコントローラを通じて ID を割り当てた後、ポストプロセッシングツールやブラウザスクリプトで該当する SVG 要素を選択できます。