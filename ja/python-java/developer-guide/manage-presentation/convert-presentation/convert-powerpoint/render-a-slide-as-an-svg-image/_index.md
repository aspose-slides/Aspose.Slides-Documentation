---
title: Python（Java 経由）でプレゼンテーションスライドを SVG 画像としてレンダリング
linktitle: スライドを SVG に変換
type: docs
weight: 50
url: /ja/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint から SVG へ
- プレゼンテーションから SVG へ
- スライドから SVG へ
- PPT から SVG へ
- PPTX から SVG へ
- SVG エクスポート オプション
- インタラクティブ SVG
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python（Java 経由）で PowerPoint スライドを SVG 画像としてエクスポートし、フォント、テキスト、画像、ID、イベントを Aspose.Slides で制御します。"
---
## **概要**

SVG は、Web パブリッシング、スライドビューア、アクセシビリティワークフロー、そして自動ポストプロセッシングに適した、拡張性のある XML ベースの画像フォーマットです。Aspose.Slides は各スライドを個別の SVG ファイルにエクスポートし、テキスト、フォント、画像、SVG 要素の書き出し方法を制御できます。

エクスポートされた SVG をコンパクトに保ち、ブラウザ間で予測可能にし、インタラクティブに使用できるようにする場合は、[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) を使用します。

## **スライドを SVG としてエクスポート**

[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) を作成し、スライドを選択して、[Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) を使用してストリームに書き込みます。例では既存の `presentation.pptx` ファイルが必要です。各例は必要に応じて JVM を起動し、出力ストリームを閉じます。以下の例は、プレゼンテーション内のすべてのスライドを個別の SVG ファイルとしてエクスポートします。

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

ファイル名はループインデックスではなく、[Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) を使用します。スライドビューアや Web ページで特定のシェイプだけが必要な場合は、[Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) を使用して個々のシェイプをエクスポートすることもできます。

## **SVG 出力の構成**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) は SVG のレンダリングを制御します。テキストフレームの場合、[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) はレンダリング領域にテキストフレームを含め、[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) はフレームの回転を適用するかどうかを決定します。テキストをリガチャなしで描画する必要がある場合は、[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) を `True` に設定します。

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

## **矢じりでのラインエンドクロッピングの制御**

SVG 1.1 には、矢じりの下でラインが停止すべき位置を指定するマーカーインセット設定がありません。デフォルトでは、Aspose.Slides はエクスポートされたラインを短くし、ストロークがマーカーを突き抜けないようにします。[SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) を `True` で呼び出すと、ストロークが元のラインエンドポイントまで描画されます。この設定は SVG 出力にのみ影響し、スライド上のラインの位置と長さは維持されます。

この例では、2 ポイントと 10 ポイントの幅のラインに三角形とダイヤモンドの矢じりを描画します。同じスライドを 2 回エクスポートし、クロッピングオプションだけを変更します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

比較では、10 ポイントのライン上の三角形矢じりが示されています。クロッピングを有効にすると先端が鋭くなります。無効にすると、ストロークがマーカーの斜め側面を突き抜け、平らな終端になります。

![クロッピング有効時に鋭い先端、無効時に平らな端となる拡大された 10 ポイント三角形](line-end-cropping.png)

例の他のラインでは、2 ポイントの三角形では突き出たストロークが目立ちにくくなります。塗りつぶされたダイヤモンドは、両方の幅でストロークの端を覆います。

## **テキストとフォントの制御**

スライドを SVG にエクスポートする際、テキストをテキストのまま保持するかベクトルグラフィックに変換するか、外部フォントをどのように含めるかまたは参照するかを制御できます。次のオプションは、エクスポートされた SVG のビジュアル一貫性、テキスト選択、フォント依存性のバランスを取るのに役立ちます。

### **すべてのテキストをベクトル化**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) を `True` に設定すると、すべてのスライドテキストがベクトルグラフィックとして書き込まれます。これによりフォント依存性がなくなり、ブラウザ間で視覚的結果がより一貫しますが、テキストは SVG テキストとして選択または検索できなくなります。

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) は、外部から読み込まれるフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) の値を使用します。`AddLinksToFontFiles` を選択すると個別のフォントファイルへの参照となり、`Embed` はフォントデータを SVG に埋め込み、`Vectorize` は外部フォントを使用するテキストのみをグラフィックとして描画します。フォントを埋め込む前にライセンスを確認してください。

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

## **埋め込まれた画像サイズの削減**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) を使用して埋め込み画像の解像度を下げ、[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) で切り取られたソース領域を省略し、[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) で JPEG エンコード品質を制御します。これらの設定は画像の忠実度や保持データを犠牲にしてファイルサイズを削減します。

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

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) は SVG エクスポート時にメタファイルをラスタライズする際の下限解像度を設定します。EMF または WMF 画像をラスタライズする際に、詳細度とファイルサイズのバランスを取るために使用します。これは SVG の全体 DPI を定義したり、スライド上のすべてのオブジェクトをラスタ画像に強制変換したりはしません。

[metafile-rasterization.pptx](metafile-rasterization.pptx) をダウンロードしてください。これは密に配置された対角線を持つ EMF 画像を含んでいます。以下の例は、[Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) を使用して最初のスライドを 3 つのラスタライズ解像度でエクスポートします。他のエクスポート設定はすべて同一に保たれ、結果を比較できます。

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

出力では、EMF が各 SVG に埋め込まれた PNG に変換されました。以下の測定値は提供されたプレゼンテーション向けであり、DPI をピクセル寸法に変換する一般的な式ではありません。

| メタファイル ラスタライズ DPI | 埋め込み PNG の寸法 | SVG ファイルサイズ (バイト) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

以下の比較は、拡大表示サイズで同じ埋め込みラスタ領域を示しています。対角線は 72 DPI でピクセル化が目立ち、高解像度ではエッジが滑らかになりますが、SVG ファイルは大きくなります。解像度を上げてもすべてのディテールが向上したり、すべてのエクスポート画像が変化したりするわけではありません。

![72、150、300 DPI で拡大された対角線ディテール](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) は画像解像度の低減を制御し、メタファイルのラスタライズ解像度変更の影響を隠すことがあります。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) は JPEG エンコード品質を制御し、メタファイルのラスタライズ解像度は制御しません。

## **シェイプとテキストに安定した ID を割り当てる**

`jpype.JProxy` を介して登録された Python 書式コントローラを使用して、シェイプに [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) の値を、テキストの `tspan` 要素に [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) の値を割り当てます。プロキシは [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) で設定します。

以下のコントローラは、シェイプの存続期間中安定した [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId) と、テキストスパン用の再利用可能なカウンタを使用します。これにより生成された ID は、変更されていないプレゼンテーションの後処理に適しています。

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

Python 書式コントローラ内で、[SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) に [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) の値を渡してエクスポートされたシェイプに JavaScript イベントハンドラを追加します。コントローラは `jpype.JProxy` で登録し、[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) で設定します。結果をホストするページまたは SVG ドキュメントで JavaScript 関数を定義してください。

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

ホストページはハンドラが参照する JavaScript 関数を定義できます。ID とイベントハンドラを割り当てることで、スライドビューア、アクセシビリティ向上、その他のインタラクティブな SVG ワークフローが可能になります。

## **FAQ**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) を [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) の代わりに使用すべきはいつですか？**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) はすべてのテキストをフォントに依存しないようにしたいときに使用します。[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) は外部フォントを使用するテキストだけをグラフィックに変換したいときに使用します。

**SVG を小さくする最良の方法は何ですか？**

まず埋め込み画像を圧縮し、切り取られた画像領域を削除し、ターゲット環境で提供可能な場合はリンクされたフォントファイルを選択します。画像解像度の低下、JPEG 品質の低下、テキストのベクトル化はそれぞれ品質とサイズのトレードオフが異なるため、結果をテストしてください。

**エクスポート後に SVG 要素を変更できますか？**

はい。書式コントローラで ID を割り当て、後処理ツールやブラウザスクリプトで該当する SVG 要素を選択できます。