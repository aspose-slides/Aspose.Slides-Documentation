---
title: Python を介した Java でプレゼンテーションのインク オブジェクトを管理
linktitle: インク の管理
type: docs
weight: 95
url: /ja/python-java/manage-ink/
keywords:
- インク
- インク オブジェクト
- インク トレース
- インク の管理
- インク の描画
- 描画
- インク のエクスポート
- インク のレンダリング
- インク の非表示
- InkOptions
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "PowerPoint のインク オブジェクトを管理し、トレースとブラシ プロパティを編集し、PDF、HTML、SVG、TIFF、画像エクスポート時に Aspose.Slides for Python via Java を使用してインク の外観を制御します。"
---
## **はじめに**

PowerPoint にはフリーハンドのストロークを描くことができるインク機能が提供されています。インクは他のオブジェクトをハイライトしたり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くために使用できます。

Aspose.Slides はインク オブジェクトを操作するために必要な型を提供します。たとえば、[Ink](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ink/) クラスはスライド上のインク オブジェクトを表します。

## **通常のオブジェクトとインク オブジェクトの違い**

PowerPoint スライド上のオブジェクトは通常、シェイプ オブジェクトで表されます。最も単純な形態では、シェイプはオブジェクト自体（フレーム）の領域と、コンテナのサイズ、形状、背景などのプロパティを定義するコンテナです。詳細は [Shape Layout Format](/slides/ja/python-java/shape-manipulations/#access-layout-formats-for-shape) を参照してください。

ただし、PowerPoint がインク オブジェクトを扱う場合、フレーム（コンテナ）のすべてのプロパティはサイズ以外無視されます。コンテナ領域のサイズは標準の [Shape.getWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getWidth) および [Shape.getHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getHeight) メソッドで決まります。

![ink_powerpoint1](ink_powerpoint1.png)

## **インク トレース**

インク トレースは、ユーザーがデジタル インクで書く際のペンの軌跡を記録する基本要素です。トレースは連続した点のシーケンスを保持します。

最も単純なエンコーディングは、各サンプル点の X と Y 座標を指定します。すべての連続点が描画されると、次のような画像が生成されます。

![ink_powerpoint2](ink_powerpoint2.png)

## **描画用ブラシ プロパティ**

ブラシはインク トレースの点を結ぶ線を描くために使用されます。ブラシには独自の色とサイズがあり、[InkBrush.getColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inkbrush/#getColor) と [InkBrush.getSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inkbrush/#getSize) メソッドで取得できます。

### **インク ブラシの色を設定する**

この Python コードはインク ブラシの色を設定する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **インク ブラシのサイズを設定する**

この Python コードはインク ブラシのサイズを設定する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

通常、ブラシの幅と高さは一致せず、PowerPoint はブラシサイズを表示しません（該当データ セクションはグレー表示）。幅と高さが一致した場合、PowerPoint は次のようにサイズを表示します。

![ink_powerpoint3](ink_powerpoint3.png)

分かりやすくするために、インク オブジェクトの高さを増やして重要な寸法を確認します。

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さは 0 とみなします（前の画像参照）。

したがって、インク オブジェクト全体の可視領域を決定するには、トレースのブラシ サイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキスト トレース）がコンテナ（フレーム）のサイズに合わせて拡大されています。コンテナのサイズが変わってもブラシ サイズは一定であり、逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint はテキスト オブジェクトでも同様の動作を使用します。

![ink_powerpoint6](ink_powerpoint6.png)

## **エクスポートおよびレンダリング時のインク 表示制御**

Aspose.Slides は、エクスポートまたはレンダリングされた出力でインク オブジェクトの表示方法を制御するための [InkOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inkoptions/) クラスを提供します。プロパティを使用してインクを完全に非表示にしたり、インク ブラシのマスク操作の解釈方法を変更したりできます。

インク オプションは、複数の出力タイプのエクスポートまたはレンダリング オプションを通じて利用できます。

| 出力 | インク オプション プロパティ |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| スライド画像 | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/renderingoptions/#getInkOptions) |

次の [InkOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inkoptions/) メソッドは同じ 2 つの設定を公開します。

- [getHideInk](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inkoptions/#getHideInk) はインク オブジェクトが出力に含まれるかどうかを決定します。既定値は `False` です。
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) は、インク ブラシをレンダリングする際にマスク操作を不透明度として解釈するかどうかを決定します。既定値は `True` です。`False` を指定して [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) を呼び出すと、ROP 操作が使用されます。

### **PDF 出力でインク オブジェクトを非表示にする**

既定では、エクスポート時にインク オブジェクトは表示されたままです。手書き注釈やその他のインク コンテンツを除いたクリーンな出力を作成するには、`True` を指定して [InkOptions.setHideInk](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inkoptions/#setHideInk) を呼び出します。

次の Python 例は、すべてのインク オブジェクトを非表示にした状態でプレゼンテーションを PDF にエクスポートします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **スライドを画像としてレンダリングする際にインク オブジェクトを非表示にする**

ビットマップ画像としてスライドをレンダリングする際にインク オブジェクトを非表示にするには、[RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/renderingoptions/#getInkOptions) を構成し、レンダリング オプションを [Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) に渡します。

次の Python 例は、インク オブジェクトなしで最初のスライドを PNG 画像としてレンダリングします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **インク マスクのレンダリング制御**

[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) 設定は、インク ブラシをレンダリングする際にマスク操作をどのように解釈するかを制御します。既定値は `True`（不透明度使用）です。ROP 操作を使用したい場合は、`False` を指定して [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) を呼び出してください。

次の Python 例は、スライドを SVG にエクスポートし、インク マスク操作に ROP ベースのレンダリングを使用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

同じ設定は、プレゼンテーションをエクスポートするかスライドを TIFF にレンダリングする際に、[TiffOptions.getInkOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/#getInkOptions) を通じて適用できます。

### **インクを非表示にするか保持するかの選択**

レビュー マークなしで配布用のクリーンな注釈付きプレゼンテーションが必要な場合は、エクスポート時に `True` を指定して [InkOptions.setHideInk](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inkoptions/#setHideInk) を呼び出します。

インク 注釈が意図したコンテンツ（レビュー コメント、手書きメモ、ハイライト、描画など）として残る必要がある場合は、[InkOptions.getHideInk](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inkoptions/#getHideInk) を既定値の `False` のままにしてください。これにより、同じプレゼンテーションからソース インク オブジェクトを変更せずに、レビュー用と最終版の出力を別々に生成できます。

## **FAQ**

**既存のインク ストロークの色やサイズを変更できますか？**

はい。まず [Ink.getTraces](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ink/#getTraces) でトレースを取得し、[InkTrace.getBrush](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inktrace/#getBrush) を取得します。その後、[InkBrush.setColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inkbrush/#setColor) または [InkBrush.setSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inkbrush/#setSize) を呼び出してブラシを変更できます。

**インクを非表示にすると元のプレゼンテーションが変更されますか？**

いいえ。[InkOptions.setHideInk](https://reference.aspose.com/slides/ja/python-java/aspose.slides/inkoptions/#setHideInk) を呼び出すと、レンダリングまたはエクスポート結果にのみ影響し、元のプレゼンテーション内のインク オブジェクトは削除も変更もされません。

**どのエクスポート形式がインク オプションに対応していますか？**

PDF、HTML、SVG、TIFF、ビットマップ スライド画像の各エクスポートまたはレンダリング オプションでインク オプションを構成できます（上表参照）。

**さらに読む**

* 形状全般については、[PowerPoint Shapes](/slides/ja/python-java/powerpoint-shapes/) セクションを参照してください。
* 有効値については、[Shape Effective Properties](/slides/ja/python-java/shape-effective-properties/#get-effective-font-height-value) をご覧ください。
* PDF エクスポートの詳細は、[Convert PPT and PPTX to PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/) を参照してください。
* HTML エクスポートの詳細は、[Convert PowerPoint Presentations to HTML](/slides/ja/python-java/convert-powerpoint-to-html/) を参照してください。
* SVG エクスポートの詳細は、[Render Presentation Slides as SVG Images](/slides/ja/python-java/render-a-slide-as-an-svg-image/) を参照してください。
* TIFF エクスポートの詳細は、[Convert PowerPoint Presentations to TIFF](/slides/ja/python-java/convert-powerpoint-to-tiff/) を参照してください。
* スライド画像へのレンダリングの詳細は、[Convert Presentation Slides to Images](/slides/ja/python-java/convert-slide/) を参照してください。