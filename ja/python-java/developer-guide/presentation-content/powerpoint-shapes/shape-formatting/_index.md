---
title: Java 経由の Python で PowerPoint の図形を書式設定する
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/python-java/shape-formatting/
keywords:
- 図形の書式設定
- 線の書式設定
- スケッチ効果
- 図形線のスケッチ
- 結合スタイルの書式設定
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- 図形の透明度
- 白黒図形レンダリング
- グレースケール図形レンダリング
- 図形の回転
- 3D ベベル効果
- 3D 回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java 経由の Python で PowerPoint の図形を書式設定する方法を学びます—PPT および PPTX ファイルの塗りつぶし、線、効果スタイルを正確かつ完全に制御できます。"
---
## **概要**

PowerPoint で図形の輪郭、塗りつぶし、効果を調整して図形の書式設定を行います。Aspose.Slides for Python via Java を使用すると、透過性、回転、3D 書式設定などの設定をプログラムで制御できます。

![PowerPoint の図形書式設定オプション](format-shape-powerpoint.png)

Aspose.Slides for Python via Java は、PowerPoint で利用できる同じオプションを使用して図形を書式設定できるクラスとメソッドを提供します。

## **線の書式設定**

[Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) を使用して図形の輪郭を制御します。この例は、塗りつぶしのない長方形を作成し、青色の破線輪郭を設定します。[LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) は太さが異なる複合線を選択し、[LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) は幅を 7 ポイントに設定し、[LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) は破線パターンを選択します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![プレゼンテーションの書式設定された線](formatted-lines.png)

### **カスタム線破線パターンの設定**

事前定義された線スタイルで必要な破線長さや隙間が得られない場合は、[LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) を使用します。パターンを設定すると、線の破線スタイルは自動的に [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) に変更されます。

配列の要素は破線と隙間の長さを交互に並べ、破線から開始します。各値は線幅の倍数です。例として幅 3 ポイントの場合、`[4, 2]` は 12 ポイントの破線と 6 ポイントの隙間を生成します。有限かつ非負の値のペアで完全な破線‑隙間セグメントを定義します。この例ではすべての破線と隙間が可視になるよう正の値を使用しています。

この例は、同じ長さでフラットキャップの青線を 5 本作成します。最初の 3 本は幅 3 ポイントでパターンを比較し、4 本目は幅を 2 倍にして最初のパターンを繰り返し、破線と隙間の長さも倍にします。5 本目はカスタムパターンから実線に切り替えます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0)
        line.getLineFormat().setWidth(6 if i == 3 else 3)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setCapStyle(LineCapStyle.Flat)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setCustomDashPattern(jpype.JArray(jpype.JFloat)(pattern))

    # 最後の線を実線スタイルに戻す。
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

事前定義された破線スタイルに戻す場合は、[LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) に [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) を渡します。選択したスタイルが線の外観を制御します。

PowerPoint での結果（上から下へ）：**{4, 2}, 3 pt**；**{1, 2}, 3 pt**；**{6, 2, 1, 2}, 3 pt**；**{4, 2}, 6 pt**；および **Solid, 3 pt**。

![PowerPoint のカスタム破線パターン、最初のパターンを幅広く使用した線、実線](custom-dash-patterns.png)

### **線キャップの設定**

[LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) を使用して開線の端を設定します。[LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) クラスは次の 3 つの明示的なキャップスタイルを提供します。

- `Flat`：ストロークは端点で止まります。
- `Round`：半円形のキャップが端点を線幅の半分だけ超えて伸びます。
- `Square`：正方形のキャップが端点を線幅の半分だけ超えて伸びます。

クラスには `NotDefined` も含まれ、これは明示的なキャップスタイルが割り当てられていないことを意味します。

キャップは矢印ヘッドや結合とは異なり、矢印ヘッドは線端にシンボルを追加し、結合は線セグメント間の角を制御します。この例では [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) と [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) で矢印ヘッドを無効にし、キャップ形状だけを比較します。

次の例は、幅 20 ポイントの同一の水平線を 3 本作成します。上から下へ、フラット、ラウンド、スクエアのキャップを使用します。端点は同じ水平座標で、ラウンドとスクエアのキャップは各端点から 10 ポイント伸びます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    cap_styles = [LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square]

    for i, cap_style in enumerate(cap_styles):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0)
        line.getLineFormat().setWidth(20)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setDashStyle(LineDashStyle.Solid)
        line.getLineFormat().setCapStyle(cap_style)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)

    presentation.save("line_caps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

PowerPoint での結果（上から下へ）：**Flat**、**Round**、**Square**。

![PowerPoint の同一太線上のフラット、ラウンド、スクエア キャップ](line-caps.png)

## **図形線へのスケッチ効果の適用**

スケッチ効果により図形線が手描き風になります。[Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) で線設定にアクセスし、[LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) でスケッチ設定にアクセスし、[SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) で [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) クラスから値を選択します。

以下の Python コードは、[LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) 効果を適用し、明示的に割り当てられた値を読み取り、[LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) で効果を削除する方法を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    sketch_format = shape.getLineFormat().getSketchFormat()
    sketch_format.setSketchType(LineSketchType.Curved)
    explicit_sketch_type = sketch_format.getSketchType()
    print("Explicit sketch type:", explicit_sketch_type)
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) が返す値は、図形に直接割り当てられた設定を表します。線の書式設定がテーマ、マスタースライド、レイアウトスライドから継承される場合は、[LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) を使用し、返された有効な線書式設定からスケッチタイプを読み取ります。下の例は、少なくとも 1 つの図形が最初のスライドに存在するプレゼンテーションを前提とし、2 つの値を出力します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    line_format = shape.getLineFormat()
    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print("Explicit sketch type:", explicit_sketch_type)
    print("Effective sketch type:", effective_sketch_type)
finally:
    presentation.dispose()
```

## **結合スタイルの書式設定**

次の 3 つの結合タイプがあります。

* Round
* Miter
* Bevel

結合スタイルは、2 つの輪郭セグメントが角でどのように接続されるかを制御します。丸みのある角には **Round**、鋭角には **Miter**、平坦な角には **Bevel** を使用します。

![プレゼンテーションの結合スタイル](join-style-powerpoint.png)

この例は、幅 15 ポイントの青い輪郭を持つ黒い長方形を 3 つ作成します。[LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) を使用して、[LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) の miter、bevel、round の値をそれぞれ設定し、角の描画方法を比較します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **鋭角でのミータ結合の制限**

[LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) と、[LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) を [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) に設定して、鋭角がどれだけ伸びるかを制限します。

制限は、結合部の内側と外側の角間距離と線幅の比率です。例えば、値 `8` は線幅の最大 8 倍までミータ長を許可します（ポイント単位の測定ではありません）。角が制限を超える場合、PowerPoint はその角でベベル結合を使用します。制限を大きくすると、より鋭い点が得られます。この設定はミータ結合にのみ影響し、角が両方の制限内に収まっている場合は可視的な変化はありません。

この例は、幅 20 ポイントの輪郭を持つ同一の塗りつぶしなし三角形を 2 つ作成します。左側の三角形は `2` の制限、右側は `8` の制限を使用します。各三角形は幅 80 ポイント、高さ 160 ポイントで、上部の角のミータ長さ‑線幅比は約 `4.12` です。そのため、PowerPoint は左側の頂点をベベルし、右側の頂点は保持します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160)
        triangle.getFillFormat().setFillType(FillType.NoFill)
        triangle.getLineFormat().setWidth(20)
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
        triangle.getLineFormat().setMiterLimit(miter_limit)

    presentation.save("miter_limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

PowerPoint の結果：左側は **Miter limit 2**、右側は **miter limit 8**。

![PowerPoint のベベル頂点（ミータ制限 2）と鋭角頂点（ミータ制限 8）](miter-limits.png)

## **グラデーション塗りつぶし**

グラデーション塗りつぶしは、図形全体に色をブレンドします。この例は、[FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat) を使用して、赤から紫への 45 度角の線形グラデーションで楕円を塗りつぶします。[GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) メソッドでグラデーションの開始点（0）と終了点（1）にカラー ストップを配置します。既存のストップをクリアすることで、この 2 色だけが使用されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45)
    shape.getFillFormat().getGradientFormat().getGradientStops().clear()
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![グラデーション塗りつぶしの楕円](gradient-fill.png)

エクスポートした画像でグラデーションが PowerPoint と異なる場合は、[Choose a Gradient Rendering Style](/slides/ja/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) を参照してください。プレゼンテーションに保存されているグラデーション塗りつぶしを変更せずに、レンダリング スタイルを選択できます。

### **線形グラデーション角度の設定**

[GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) を使用して、[GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/) 塗りつぶしの向きを制御します。角度は度で測定され、時計回りに増加します：`0` は左から右、`90` は上から下、`180` は右から左、`270` は下から上です。小数角度もサポートされています。`[0, 360)` 範囲外の有限角度は 1 周に正規化されます。例として、`-45` は `315`、`360` は `0` になります。

この例は、位置 `0`、`0.5`、`1` に同一の赤・緑・青ストップを持つ 6 つの長方形を作成します。スケーリングを無効にして、角度を長方形の比率に依存せずに比較できるようにしています。左から右への角度は、1 行目が `0`、`45`、`90`、2 行目が `135`、`180`、`270` です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.False_)
        gradient.setLinearGradientAngle(angle)

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

PowerPoint の結果:

![上段が 0、45、90 度、下段が 135、180、270 度の線形グラデーション](linear-gradient-angles.png)

### **図形に対する線形グラデーションのスケーリング**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) は [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) 値を受け取ります。`False_` に設定すると図形のサイズ変更時にジオメトリ角度が保持され、`True_` に設定すると幅と高さに合わせてグラデーションがスケーリングされます。スケーリングが有効な非正方形図形では、見えている角度が割り当てた角度と異なる場合があります。

以下の例は、`45` 度の角度と前述と同じカラー ストップを使用します。左列は `False_`、右列は `True_` です。各列には幅の広い長方形の上に高さの高い長方形があります。両方とも同じ幅で開始し、2 番目の長方形の幅と高さを変更して、塗りつぶし設定を変更せずにリサイズ時の挙動を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    scaling_options = [NullableBool.False_, NullableBool.True_]

    for column, scaled in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90)
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
            shape.getFillFormat().setFillType(FillType.Gradient)

            gradient = shape.getFillFormat().getGradientFormat()
            gradient.setGradientShape(GradientShape.Linear)
            gradient.getGradientStops().clear()
            gradient.getGradientStops().add(0, Color.RED)
            gradient.getGradientStops().add(0.5, Color.GREEN)
            gradient.getGradientStops().add(1, Color.BLUE)
            gradient.setLinearGradientAngle(45)
            gradient.setLinearGradientScaled(scaled)

            if row == 1:
                shape.setWidth(90)
                shape.setHeight(280)

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

PowerPoint の結果（左はスケーリング無効、右は有効）:

![左側は LinearGradientScaled が False、右側は True の 45 度グラデーションを持つ幅広と高さの長方形](linear-gradient-scaling.png)

スケーリングを無効にすると、対角線のカラーバンドは両方の長方形で同じ向きを保ちます。スケーリングを有効にすると、バンドは図形の比率に合わせて伸びます。これにより、テンプレートのグラデーションを別サイズの図形に適用するときに再現しやすくなります。正方形の場合、スケーリングを有効にしてもこの `45` 度グラデーションの外観は変わりません。

角度とスケーリングの設定は線形グラデーションにのみ適用され、[GradientShape.Radial] や [GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/) の塗りつぶしには影響しません。

### **角度とグラデーション方向の組み合わせ**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) は [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/) クラスからグラデーションスタイルを選択しますが、数値角度の代替ではありません。線形グラデーションの場合、角度は [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) で設定されますが、コーナー スタイルにより色が分布する領域が変わります。角度やスケーリングを比較する際は、方向は変更しないでください。

以下の例は、同じ設定を逆順で適用します。2 つの長方形は同一の外観で、方向を角度の前後で設定しても結果は変わりません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    for i in range(2):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.True_)

        if i == 0:
            gradient.setGradientDirection(GradientDirection.FromCorner1)
            gradient.setLinearGradientAngle(30)
        else:
            gradient.setLinearGradientAngle(30)
            gradient.setGradientDirection(GradientDirection.FromCorner1)

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **パターン塗りつぶし**

パターン塗りつぶしは、ドット、ストライプ、チェックなどの 2 色デザインを適用します。この例は、[PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) を使用して格子パターンを選択します。[PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) が淡いグレーの背景色を提供し、[PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) が黄色のパターン色を提供します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Pattern)
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![パターン塗りつぶしの長方形](pattern-fill.png)

## **画像塗りつぶし**

画像塗りつぶしは、図形の内部に画像を使用します。この例はローカル画像を必要とし、[Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) でプレゼンテーションの画像コレクションにロードします。[PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) をタイル モードに設定すると、画像が長方形内で繰り返されます。使用した元画像は以下です。

![ロータスの画像](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    image = Images.fromFile("lotus.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![画像塗りつぶしの図形](picture-fill.png)

### **テクスチャとして画像をタイル表示**

タイル画像をテクスチャとして設定し、タイル動作をカスタマイズしたい場合は、[PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます。

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode)：`Tile` または `Stretch` の画像塗りつぶしモードを設定します。
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment)：図形内でのタイルの配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip)：タイルを水平方向、垂直方向、または両方に反転するかを制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX)：図形の原点からタイルの水平オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY)：図形の原点からタイルの垂直オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX)：タイルの水平スケールをパーセンテージで定義します。
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY)：タイルの垂直スケールをパーセンテージで定義します。

この例はローカル画像を使用し、元サイズの 50% で繰り返すように [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) を構成します。`-32` ポイントのオフセットでタイルを水平・垂直にシフトし、右下揃えと両方向の反転で繰り返しテクスチャの配置を決定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)
    shape.getFillFormat().setFillType(FillType.Picture)

    source_image = Images.fromFile("lotus.png")
    try:
        presentation_image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![タイルオプション](tile-options.png)

## **単色塗りつぶし**

単色塗りつぶしは、図形に単一の均一な色を付けます。この例は、[FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) で単色塗りつぶしモードを設定し、[FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) で黄色を割り当て、長方形をプレゼンテーションに保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![単色塗りつぶしの図形](solid-color-fill.png)

## **スライドの背景を図形の塗りつぶしとして使用**

スライドの背景に合わせた図形が必要な場合（例：プレゼンテーションテンプレート）には、[AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) を使用します。最初に [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) を [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) に設定して明示的な塗りつぶしを削除します。この組み合わせにより、図形はスタイル塗りつぶしではなくスライドの背景を使用します。フラグだけを有効にしても既存の明示的な塗りつぶしは削除されません。

これは [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) とは異なります。NoFill は図形の背後にあるオブジェクトを表示したままにし、背景塗りつぶしはスライド背景の該当エリアでオブジェクトを覆います。グラデーションはスライド全体に合わせて配置され、各図形内で再開されません。

以下の例は、スライドが継承するマスタ背景を作成し、3 つの長方形の背後にマゼンタ帯を配置します。左の長方形は背景塗りつぶしを使用し、中央は塗りつぶしなし、右は背景塗りつぶしから明示的なオレンジ塗りつぶしに切り替えます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, GradientShape, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    # マスターからグラデーションを継承する。
    slide.getBackground().setType(BackgroundType.NotDefined)
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined)
    background = slide.getLayoutSlide().getMasterSlide().getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Gradient)
    gradient = background.getFillFormat().getGradientFormat()
    gradient.setGradientShape(GradientShape.Linear)
    gradient.setLinearGradientAngle(0)
    gradient.getGradientStops().clear()
    color = Color(0, 0, 139)
    gradient.getGradientStops().add(0, color)
    color = Color(135, 206, 250)
    gradient.getGradientStops().add(1, color)

    # このオブジェクトを最初に追加すると、矩形の背面に表示されます。
    band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    background_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200)
    background_shape.getFillFormat().setFillType(FillType.NotDefined)
    background_shape.setUseBackgroundFill(True)

    no_fill_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200)
    no_fill_shape.getFillFormat().setFillType(FillType.NoFill)

    explicit_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200)
    explicit_shape.getFillFormat().setFillType(FillType.NotDefined)
    explicit_shape.setUseBackgroundFill(True)

    # 明示的な塗りつぶしを適用する前に背景塗りつぶしを無効にします。
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果（左から右へ）：**背景塗りつぶし**、**塗りつぶしなし**、**明示的な塗りつぶし**。マゼンタ帯は左と右の長方形で隠れますが、中央の長方形を通しては表示されます。

![マゼンタ帯の上に背景塗りつぶし、塗りつぶしなし、明示的なオレンジ塗りつぶし](background-fill.png)

同じ動作はスライド自体に直接定義された背景やレイアウトから継承された背景にも適用されます。図形は解決されたスライド背景を使用します。例ではスライドとレイアウトの背景を未定義にして、マスタが提供するようにしています。

## **透明度の設定**

単色塗りつぶしの場合、色のアルファ成分が不透明度を制御します：0 が完全に透明、255 が完全に不透明です。この例はアルファ値 128 の黄色の長方形を使用し、約 50% 透明にして下の長方形が見えるようにします。色は [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) を介して割り当てられます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 255, 0, 128)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![透明な図形](shape-transparency.png)

## **図形の回転**

[Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) を使用して、スライド平面上で図形を回転させます。角度は度で測定され、この例は長方形を時計回りに 5 度回転させてプレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.setRotation(5)

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![図形の回転](shape-rotation.png)

## **3D ベベル効果の追加**

[Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) を使用して、図形に奥行きとベベル エッジを付加します。この例は緑の楕円にオレンジの輪郭を付け、[ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) で深さを 4 ポイントに設定し、[ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) を介して幅と高さが 6 ポイントの円形上ベベルを適用します。正面向きの正射投影カメラと三点照明によりベベルが可視化されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().setWidth(2.0)
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![3D ベベル効果](3D-bevel-effect.png)

## **3D 回転効果の追加**

図形の 3D 表示はカメラ設定で制御されます。この例は [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) に緯度 40 度、経度 35 度、回転 20 度を指定して使用します。[Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) で等角カメラを選択し、[LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) でバランス照明を選択して、書式設定した長方形を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![3D 回転効果](3D-rotation-effect.png)

## **図形の白黒レンダリング制御**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) メソッドは、プレゼンテーションが白黒モードで表示または処理されるときに個々の図形がどのようにレンダリングされるかを指定します。これは白黒表示自体を有効にするものではなく、通常のカラー表示時の図形の塗りつぶしや線、その他の書式設定も変更しません。

[BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) クラスの値で目的の動作を選択します。例として、`Automatic` は変換方法をアプリケーションに委ね、`Gray` と `LightGray` はグレー表示、`BlackWhite` は黒白のみ、`Black` と `White` は単一色、`Color` は通常カラーを保持、`Hidden` は白黒モードで図形を非表示にします。`NotDefined` は図形レベルのモードが割り当てられていないことを意味します。

この例はオレンジの長方形を作成し、[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) でモードを灰色に設定します。保存された図形は通常カラー表示ではオレンジの塗りつぶしを保持し、白黒表示設定を尊重するアプリケーションでは灰色で表示されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

通常カラー表示では長方形はオレンジの塗りつぶしを保持します。白黒表示のワークフローではモードが `Gray` に設定されているため灰色で表示されます。これにより、フルカラーのスライドを保持しつつ、印刷やプレビューなど白黒表示を尊重するワークフローで別の外観を定義できます。

## **書式設定のリセット**

[Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) を使用して、スライド プレースホルダーの位置、サイズ、書式設定を対応するレイアウト プレースホルダーから復元します。この例はレイアウトにリンクされたプレースホルダーがある既存のプレゼンテーションを前提とし、保存前にすべてのスライドをリセットします。対応するレイアウト プレースホルダーがない図形はリセットされません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**図形の書式設定は最終的なプレゼンテーション ファイル サイズに影響しますか？**

色、線スタイル、効果設定は、埋め込み画像やメディアに比べてデータ量がほとんど増加しません。画像塗りつぶしは、画像がプレゼンテーションに保存されるためファイルサイズを増加させる可能性があります。

**同一の書式設定を共有するスライド上の図形を検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗りつぶし、線、効果設定）を比較します。すべての対応する値が一致した場合、そのスタイルを同一と見なし、論理的に図形をグループ化します。これにより、後のスタイル管理が簡素化されます。

**カスタム図形スタイルのセットを別ファイルに保存して、他のプレゼンテーションで再利用できますか？**

はい。目的のスタイルを持つサンプル図形をテンプレート スライド デッキまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成する際にテンプレートを開き、必要なスタイル済み図形をクローンして、必要な場所で書式設定を再適用します。