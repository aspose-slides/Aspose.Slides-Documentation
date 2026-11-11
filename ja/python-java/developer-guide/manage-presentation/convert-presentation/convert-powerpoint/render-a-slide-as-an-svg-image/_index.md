---
title: Python から Java を介してプレゼンテーション スライドを SVG 画像としてレンダリング
linktitle: スライドを SVG に変換
type: docs
weight: 50
url: /ja/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint を SVG に変換
- プレゼンテーションを SVG に変換
- スライドを SVG に変換
- PPT を SVG に変換
- PPTX を SVG に変換
- SVG エクスポートオプション
- インタラクティブ SVG
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python から Java を介して PowerPoint のスライドを SVG 画像としてエクスポートし、Aspose.Slides を使用してフォント、テキスト、画像、ID、イベントを制御します。"
---
## **概要**

SVG はスケーラブルな XML ベースの画像形式で、Web 公開、スライドビューア、アクセシビリティ ワークフロー、そして自動ポストプロセッシングに適しています。Aspose.Slides は各スライドを個別の SVG ファイルとしてエクスポートし、テキスト、フォント、画像、および SVG 要素の書き出し方法を制御できます。

エクスポートされた SVG をコンパクトに、ブラウザ間で予測可能に、またはインタラクティブに使用できるようにする必要がある場合は、[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/)を使用します。

## **スライドを SVG としてエクスポート**

[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) を作成し、スライドを選択して、[Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) でストリームに書き込みます。例では既存の `presentation.pptx` ファイルが必要です。各例は必要に応じて JVM を起動し、出力ストリームを閉じます。以下の例はプレゼンテーション内のすべてのスライドを個別の SVG ファイルとしてエクスポートします。

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

ファイル名はループインデックスではなく、[Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) を使用します。スライドビューアや Web ページが特定のシェイプだけを必要とする場合は、[Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) を使用して個別のシェイプをエクスポートすることもできます。

## **SVG 出力の構成**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) は SVG のレンダリングを制御します。テキストフレームについては、[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) がレンダリング領域にテキストフレームを含め、[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) がフレーム回転の適用を決定します。[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) を `True` に設定すると、テキストを合字なしでレンダリングします。

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

スライドを SVG にエクスポートする際、テキストをテキストのままに保持するかベクターグラフィックに変換するか、外部フォントをどのように含めるか参照するかを制御できます。以下のオプションは、エクスポートされた SVG の視覚的一貫性、テキスト選択、フォント依存性のバランスを取るのに役立ちます。

### **すべてのテキストをベクタ化**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) を `True` に設定すると、すべてのスライドテキストがベクターグラフィックとして書き込まれます。これによりフォント依存性がなくなり、ブラウザ間で視覚結果がより一貫しますが、テキストは SVG テキストとして選択・検索できなくなります。

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

### **外部フォントの処理方法の選択**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) は、外部でロードされるフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) の値を使用します。`AddLinksToFontFiles` を選択すると個別のフォントファイルへの参照、`Embed` を選択するとフォントデータを SVG に埋め込み、`Vectorize` を選択すると外部フォントを使用するテキストのみをグラフィックとしてレンダリングします。埋め込む前にフォントのライセンスを確認してください。

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

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) を使用して埋め込み画像の解像度を下げ、[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) で切り取り領域を除外し、[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) で JPEG エンコード品質を制御できます。これらの設定は、画像の忠実度または保持データを犠牲にしてファイルサイズを削減します。

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

## **メタファイルラスタライズ解像度の制御**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) は、SVG エクスポート時にメタファイルをラスタライズする際の下限解像度を設定します。EMF や WMF 画像がラスタライズされるときの詳細とファイルサイズのバランスに使用します。SVG 全体の DPI を定義したり、スライド上のすべてのオブジェクトをラスタ画像に強制するものではありません。

[metafile-rasterization.pptx](metafile-rasterization.pptx) をダウンロードしてください。このファイルには、間隔の狭い対角線を持つ EMF 画像が含まれています。以下の例は、[Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) を使用して最初のスライドを 3 つのラスタライズ解像度でエクスポートします。他のエクスポート設定はすべて同一に保たれ、結果を比較できるようにしています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()

```

出力では、EMF が各 SVG に埋め込まれた PNG 1 枚に変換されています。以下の測定値は提供されたプレゼンテーションに対するもので、DPI をピクセル寸法に変換する一般的な式ではありません。

| メタファイル ラスタライズ DPI | 埋め込み PNG のサイズ | SVG ファイルサイズ (バイト) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

以下の比較は、同じ埋め込みラスタ領域を同一の拡大表示サイズで示しています。対角線は 72 DPI でピクセル化が目立ち、解像度が上がるとエッジが滑らかになりますが、SVG ファイルは大きくなります。値を上げても必ずしもすべてのディテールが改善されるわけでも、すべてのエクスポート画像が変わるわけでもありません。

![72、150、300 DPI で拡大された対角線の詳細](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) は画像解像度の低減を制御し、メタファイル ラスタライズ解像度の変更効果を隠すことがあります。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) は JPEG エンコード品質を制御し、メタファイル ラスタライズ解像度を制御するものではありません。

## **シェイプとテキストに安定した ID を割り当てる**

`jpype.JProxy` で登録された Python フォーマットコントローラを使用して、シェイプに [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) の値を、テキストの `tspan` 要素に [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) の値を割り当てます。プロキシは [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) で設定します。

以下のコントローラは、シェイプの存続期間中安定した [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId) を使用し、テキストスパンに対して再現可能なカウンタを使用します。これにより、変更されていないプレゼンテーションのポストプロセスに適した ID が生成されます。

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

Python フォーマットコントローラ内で、[SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) に [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) の値を渡してエクスポートされたシェイプに JavaScript イベントハンドラを追加します。コントローラは `jpype.JProxy` で登録し、[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) で割り当てます。結果をホストするページまたは SVG ドキュメント内で JavaScript 関数を定義してください。

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

ホストページはハンドラが参照する JavaScript 関数を定義できます。ID とイベントハンドラを割り当てることで、スライドビューア、アクセシビリティ向上、その他のインタラクティブ SVG ワークフローが可能になります。

## **よくある質問**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) を [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) の代わりに使用すべきタイミングは？**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) は、すべてのテキストをフォントに依存しないようにする必要がある場合に使用します。[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) は、外部フォントを使用するテキストのみをグラフィックに変換したい場合に使用します。

**SVG を小さくする最適な方法は何ですか？**

まず埋め込み画像を圧縮し、切り取られた領域を削除し、環境が提供できる場合はリンクされたフォントファイルを選択してください。画像解像度の低下、JPEG 品質の低下、ベクタ化テキストのそれぞれが品質とサイズのトレードオフを持つため、結果をテストしてください。

**エクスポート後に SVG 要素を変更できますか？**

はい。フォーマットコントローラで ID を割り当て、その ID を使用してポストプロセッシングツールやブラウザスクリプトで対象の SVG 要素を選択できます。