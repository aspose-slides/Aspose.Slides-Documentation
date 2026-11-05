---
title: Python via Java で PowerPoint シェイプを整形する
linktitle: シェイプの書式設定
type: docs
weight: 20
url: /ja/python-java/shape-formatting/
keywords:
- シェイプの書式設定
- 線の書式設定
- スケッチ効果
- シェイプ線のスケッチ
- ジョインスタイルの書式設定
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- シェイプの透明度
- 白黒シェイプ描画
- グレースケールシェイプ描画
- シェイプの回転
- 3D ベベル効果
- 3D 回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Python via Java で PowerPoint シェイプをフォーマットする方法を学びます。PPT および PPTX ファイルの塗りつぶし、線、効果スタイルを正確かつフルコントロールで設定できます。"
---
## **概要**

PowerPoint でシェイプの輪郭、塗りつぶし、効果を調整して書式設定します。Aspose.Slides for Python via Java を使用すると、透明度、回転、3D 書式設定などをプログラムから制御できます。

![PowerPoint のシェイプ書式設定オプション](format-shape-powerpoint.png)

Aspose.Slides for Python via Java は、PowerPoint で使用できる同じオプションを使用してシェイプをフォーマットできるクラスとメソッドを提供します。

## **線の書式設定**

[Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) を使用してシェイプの輪郭を制御します。この例では、塗りつぶしのない矩形に青色の破線輪郭を作成します。[LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) で太さが異なる複合線を選択し、[LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) で幅を 7 ポイントに設定し、[LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) で破線パターンを選択します。

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

![プレゼンテーション内の書式設定された線](formatted-lines.png)

### **カスタム線破線パターンの設定**

事前定義された線スタイルで必要な破線の長さや隙間が得られない場合は、[LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) を使用します。パターンを設定すると、線の破線スタイルが自動的に [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) に変更されます。

配列の要素は破線と隙間の長さを交互に並べ、最初は破線から始まります。各値は線幅の倍数です。例として幅 3 ポイントで `[4, 2]` を指定すると、12 ポイントの破線の後に 6 ポイントの隙間ができます。有限かつ非負の値のペアを使用して、完全な破線‑隙間セグメントを定義します。この例ではすべての破線と隙間が見えるように正の値を使用しています。

この例は、同じ長さでフラットなキャップを持つ青色の線を 5 本作成します。最初の 3 本は幅 3 ポイントでパターンを比較し、4 本目は幅を 2 倍にして最初のパターンを繰り返し、破線と隙間の長さがそれぞれ 2 倍になります。5 本目はカスタムパターンから実線に切り替えます。

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

事前定義された破線スタイルに戻す場合は、[LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) を [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) に渡します。選択したスタイルが線の外観を制御します。

PowerPoint での結果（上から順に）: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; および **Solid, 3 pt**。

![PowerPoint での 3 つのカスタム破線パターン、最初のパターンを使用した太い線、実線](custom-dash-patterns.png)

### **線キャップの設定**

[LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) を使用して開放線の端を設定します。[LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) クラスは次の 3 つの明示的なキャップスタイルを提供します:

- `Flat`: ストロークは端点で止まります。
- `Round`: 半円形のキャップが端点を線幅の半分だけ超えて伸びます。
- `Square`: 正方形のキャップが端点を線幅の半分だけ超えて伸びます。

クラスには `NotDefined` も含まれ、これはキャップスタイルが明示的に割り当てられていないことを意味します。

キャップは、線端に記号を付加する矢じりや、線セグメント間の角を制御するジョインとは異なります。この例では、[LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) と [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) で矢じりを無効にし、キャップ形状だけを比較しています。

以下の例は、幅 20 ポイントの横方向の線を 3 本作成します。上から順にフラット、ラウンド、スクエアのキャップを使用します。端点の水平座標は同じですが、ラウンドとスクエアのキャップは各端点を 10 ポイント超えて伸びます。

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

PowerPoint での結果（上から順に）: **Flat**, **Round**, **Square**。

![PowerPoint で同一太線に適用されたフラット、ラウンド、スクエアキャップ](line-caps.png)

## **シェイプ線へのスケッチ効果の適用**

スケッチ効果はシェイプの線を手描き風に見せます。[Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) で線設定にアクセスし、[LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) でスケッチ設定にアクセスし、[SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) で [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) クラスの値を選択します。

以下の Python コードは、[LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) 効果の適用、明示的に割り当てられた値の取得、そして [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) で効果を削除する方法を示しています。

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

[SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) が返す値は、シェイプに直接割り当てられた設定を表します。線の書式設定がテーマ、マスタースライド、またはレイアウトスライドから継承される可能性がある場合は、[LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) を使用し、返された有効な線書式からスケッチタイプを読み取ります（下記参照）。有効な値は、継承が解決された後に実際に適用される書式を反映します。この例は、最初のスライドに少なくとも 1 つのシェイプがある既存のプレゼンテーションが必要で、両方の値を出力します。

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

## **ジョインスタイルの書式設定**

利用できるジョインタイプは次の 3 つです:

* Round
* Miter
* Bevel

ジョインスタイルは、2 本の輪郭セグメントが角でどのように接続されるかを制御します。丸みを帯びた角には **Round**、鋭い角には **Miter**、平らな角には **Bevel** を使用します。

![プレゼンテーション内のジョインスタイル](join-style-powerpoint.png)

この例は、青い輪郭を持つ黒い矩形を 3 つ作成し、幅 15 ポイントです。[LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) を使用して、[LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) のミーター、ベベル、ラウンドの値をそれぞれ設定し、角の描画方法を比較します。

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

### **鋭角でのミータージョインの制限**

[LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) と、[LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) を [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) に設定して、鋭角がどれだけ伸びるかを制限します。

制限は、ジョインの内側と外側の角間距離を線幅で割った比率です。たとえば `8` の値は、線幅の最大 8 倍までミーター長を許可します（ポイント単位の測定ではありません）。角が制限を超える場合、PowerPoint はその角でベベルジョインを使用します。制限が大きいほど鋭い点になります。この設定はミータージョインにのみ影響し、角が両方の制限内に収まる場合は見た目に変化はありません。

この例は、幅 20 ポイントの輪郭を持つ同一の塗りつぶしなし三角形を 2 つ作成します。左側の三角形は制限 `2`、右側は `8` を使用します。各三角形は幅 80 ポイント、高さ 160 ポイントで、上部の角のミーター長さ‑線幅比は約 `4.12` です。その結果、PowerPoint は左側の頂点をベベル化し、右側の頂点は鋭く保ちます。

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

PowerPoint の結果: 左側は **Miter limit 2**、右側は **miter limit 8**。

![PowerPoint でのミーター制限 2 のベベル頂点とミーター制限 8 の鋭い頂点](miter-limits.png)

## **グラデーション塗りつぶし**

グラデーション塗りつぶしはシェイプ全体に色をブレンドします。この例は、[FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat) を使用して、赤から紫への 45 度角の線形グラデーションで楕円を塗りつぶします。[GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) メソッドでグラデーションの開始と終了（0 と 1）に色ストップを配置します。既存のストップをクリアすることで、これら 2 色だけが使用されます。

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

エクスポートされた画像でグラデーションの見え方が PowerPoint と異なる場合は、[Choose a Gradient Rendering Style](/slides/ja/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) を参照してください。プレゼンテーションに保存されたグラデーション塗りつぶしを変更せずに、レンダリングスタイルを選択できます。

### **線形グラデーションの角度設定**

[GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) を使用して、[GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/) 塗りつぶしの向きを制御します。角度は度単位で時計回りに増加し、`0` は左から右、`90` は上から下、`180` は右から左、`270` は下から上を表します。小数角度もサポートされています。`[0, 360)` の範囲外の有限角度は 1 回転で正規化されます。たとえば `-45` は `315`、`360` は `0` になります。

この例は、位置 `0`、`0.5`、`1` に同一の赤・緑・青ストップを持つ 6 つの矩形を作成します。スケーリングは無効にして、角度を矩形の形状に依存せずに比較できるようにしています。左から右への角度は、最上段が `0`、`45`、`90`、次の行が `135`、`180`、`270` です。

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

### **シェイプで線形グラデーションをスケーリング**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) は [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) を受け取ります。`False_` に設定すると、シェイプのサイズが変わっても幾何学的なグラデーション角度が保持され、`True_` に設定するとシェイプの幅と高さに合わせてグラデーションがスケーリングされます。スケーリングが有効な非正方形シェイプでは、見た目の角度が割り当てた角度と異なることがあります。

以下の例は、`45` 度の角度と同じ色ストップを使用し、左列は `False_`、右列は `True_` で比較します。各列は上部に横長矩形、下部に縦長矩形を配置しています。最初は同じ幅で開始し、2 番目の矩形の幅と高さを変更して、塗りつぶしがリサイズにどのように応答するかを示します。

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

PowerPoint の結果（左はスケーリングなし、右はスケーリングあり）:

![左側は LinearGradientScaled が False、右側は True の 45 度グラデーションを持つ横長・縦長矩形](linear-gradient-scaling.png)

スケーリングが無効な場合、対角の色帯は両方の矩形で同じ向きを保ちます。スケーリングが有効になると、帯はシェイプの比例に合わせて伸びます。これにより、テンプレートのグラデーションを別サイズのシェイプに適用する際に同一の外観を再現できます。正方形の場合、スケーリングを有効にしてもこの `45` 度グラデーションの外観は変わりません。

角度とスケーリングの設定は線形グラデーションにのみ適用され、[GradientShape.Radial] や [GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/) の塗りつぶしには影響しません。

### **角度とグラデーション方向の組み合わせ**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) は [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/) クラスからスタイルを選択しますが、数値角度の代わりにはなりません。線形グラデーションの場合、角度は [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) で設定され、方向は角度とは独立して角のスタイルを変更できます。角度やスケーリングを比較するときは方向を変更しないでください。

以下の例は、同じ設定を順序を逆にして適用します。2 つの矩形は同一の外観になり、方向を角度の前後で設定しても結果は変わりません。

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

パターン塗りつぶしは、点、ストライプ、チェック柄など 2 色のデザインを適用します。この例は、[PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) でトレリスパターンを選択し、[PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) で薄いグレーの背景色、[PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) で黄色のパターン色を設定します。

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

![パターン塗りつぶしの矩形](pattern-fill.png)

## **画像塗りつぶし**

画像塗りつぶしはシェイプ内に画像を使用します。この例はローカル画像が必要で、[Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) を使用してプレゼンテーションの画像コレクションに読み込みます。[PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) をタイルモードに設定すると、画像が矩形内で繰り返されます。使用した元画像は以下です。

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

![画像塗りつぶしのシェイプ](picture-fill.png)

### **テクスチャとして画像をタイル配置**

タイル画像をテクスチャとして設定し、タイルの動作をカスタマイズしたい場合は、[PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます:

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): `Tile` または `Stretch` のいずれかを設定します。
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): シェイプ内でタイルの配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): タイルを水平、垂直、または両方に反転させるかを制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): シェイプの原点からタイルの水平オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): シェイプの原点からタイルの垂直オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): タイルの水平スケールをパーセンテージで定義します。
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): タイルの垂直スケールをパーセンテージで定義します。

この例はローカル画像を使用し、元サイズの 50% に縮小して繰り返すように [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) を設定します。`-32` ポイントのオフセットでタイルを水平・垂直にシフトし、右下揃えと両方向の反転で繰り返しテクスチャの配置を決定します。

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

単色塗りつぶしはシェイプに単一の均一な色を付けます。この例は、[FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) で単色塗りつぶしモードを設定し、[FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) で黄色を割り当て、矩形をプレゼンテーションに保存します。

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

![単色塗りつぶしのシェイプ](solid-color-fill.png)

### **テーマ参照を保持したまま色をコピー**

[ColorFormat.copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#copyFrom) を使用すると、色タイプ、テーマ参照、変換を含む色定義をコピーできます。これは、塗りつぶし色を別のシェイプに転送し、プレゼンテーションのテーマに従い続けさせたい場合に便利です。このメソッドは色だけをコピーし、塗りつぶしタイプ、輪郭、その他のシェイプ書式設定はコピーしません。コピー先の塗りつぶしタイプは [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) で明示的に設定してください。

この例は、左から右へ 3 つの矩形を作成します: ソース、テーマに応じたコピー、固定 RGB コピーです。ソースは [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setSchemeColor) で最初のアクセント色を参照し、[ColorOperationCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/coloroperationcollection/#add) でティントを追加します。RGB コピーはソースの有効な塗りつぶし色を使用するため、最初は 3 つとも同じ青色に見えます。[ColorFormat.setColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setColor) を呼び出すと固定 RGB 値が設定され、既存の色変換はクリアされます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, ImageFormat, Presentation, SaveFormat, SchemeColor, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    accent_color = Color(65, 105, 225)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140)
    theme_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140)
    rgb_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.getFillFormat().setFillType(FillType.Solid)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    source_color = source.getFillFormat().getSolidFillColor()
    source_color.setSchemeColor(SchemeColor.Accent1)
    source_color.getColorTransform().add(ColorTransformOperation.Tint, 0.75)

    theme_copy.getFillFormat().getSolidFillColor().copyFrom(source_color)
    rgb_copy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor())

    before = slide.getImage(1.0, 1.0)
    try:
        before.save("color-copy-before.png", ImageFormat.Png)
    finally:
        before.dispose()

    # テーマ参照は新しいアクセント色に従いますが、固定 RGB 値は従いません。
    accent_color = Color(255, 69, 0)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    after = slide.getImage(1.0, 1.0)
    try:
        after.save("color-copy-after.png", ImageFormat.Png)
    finally:
        after.dispose()
    presentation.save("copied_colors.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

テーマ変更前、3 つの塗りつぶしはすべて一致しています:

![ソース、copyFrom 宛先、固定 RGB 宛先の同一の青塗りつぶし](color-copy-before.png)

テーマ変更後、ソースとテーマ対応コピーは新しいアクセント色とティントを保持し、固定 RGB コピーは青のままです:

![オレンジ塗りつぶしのソースと copyFrom 宛先、固定 RGB 宛先は青のまま](color-copy-after.png)

コピーされた定義はソースとは独立しています。以後ソースのテーマ参照を変更したり、別の色を割り当てたり、変換を追加・削除しても、宛先は変わりません。テーマ変更は両方のシェイプに影響しますが、これはそれぞれが同じテーマカラーを個別に参照しているためです。

PPTX を保存して再度開くと、[ColorFormat.getColorType](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorType) が返す色タイプ、テーマ参照、[ColorFormat.getColorTransform](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorTransform) が返す変換コレクションは保持されます。定義は RGB にフラット化されません。

異なるテーマコンテキスト（例: アクセント パレットが異なるプレゼンテーション）間でコピーすると、コピー先のテーマに対して参照が解決されます。同じ参照と変換でも、見た目の色が異なる場合があります。テーマカラーの構成方法については、[Presentation Theme](/slides/ja/python-java/presentation-theme/) を参照してください。

## **スライド背景をシェイプの塗りつぶしとして使用**

スライド背景と一致させたいシェイプがある場合は、[AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) を使用します。最初に [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) で [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) を設定して明示的な塗りつぶしを削除します。この組み合わせにより、シェイプはスタイル塗りつぶしではなくスライド背景を使用します。フラグだけを有効にしても、既存の明示的な塗りつぶしは削除されません。

これは [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) とは異なります。NoFill はシェイプの背後にあるオブジェクトを表示したままにし、背景塗りつぶしはスライド背景の対応領域で背後のオブジェクトを覆います。グラデーションはスライドに合わせて配置され、各シェイプ内で再開されません。

以下の例は、マスタの背景をスライドが継承し、3 つの矩形の背後にマゼンタの帯を配置します。左の矩形は背景を使用し、中央は無塗りつぶし、右は背景塗りつぶしから明示的なオレンジ塗りつぶしに切り替えます。

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

    # マスターからグラデーションを継承します。
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

結果（左から右）: **背景塗りつぶし**, **無塗りつぶし**, **明示的な塗りつぶし**。マゼンタの帯は左と右の矩形で隠れますが、中央の矩形を通しては見えます。

![背景塗りつぶし、無塗りつぶし、明示的なオレンジ塗りつぶしとマゼンタ帯の比較](background-fill.png)

同じ動作はスライドに直接定義された背景やレイアウトから継承された背景にも適用されます。シェイプはスライドの解決された背景を使用します。この例ではスライドとレイアウトの背景を未定義にして、マスタが提供する背景を使用しています。

## **透明度の設定**

単色塗りつぶしの場合、カラーのアルファ成分が不透明度を制御します。0 が完全に透明、255 が完全に不透明です。この例はアルファ値 128 の黄色矩形を使用し、約 50% の透明度にして下の矩形が見えるようにします。カラーは [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) で割り当てられます。

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

![透明なシェイプ](shape-transparency.png)

## **シェイプの回転**

[Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) を使用してスライド平面上でシェイプを回転させます。角度は度単位で、この例は矩形を時計回りに 5 度回転させ、プレゼンテーションを保存します。

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

![シェイプの回転](shape-rotation.png)

## **3D ベベル効果の追加**

[Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) を使用してシェイプに奥行きとベベルエッジを付与します。この例は緑の楕円にオレンジの輪郭を付け、[ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) で深さを 4 ポイントに設定し、[ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) を通じて幅と高さが 6 ポイントの円形上ベベルを適用します。前面の正投影カメラと三点照明によりベベルが見やすくなります。

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

シェイプの 3D 表示はカメラ設定で制御されます。この例は [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) で緯度、経度、回転角度をそれぞれ 40、35、20 度に設定し、[Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) で等角カメラを選択し、[LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) でバランス照明を選択して、書式設定した矩形を保存します。

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

## **シェイプの白黒描画制御**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) メソッドは、プレゼンテーションが白黒モードで表示または処理されるときに個々のシェイプがどのように描画されるかを指定します。このメソッド自体では白黒表示を有効にせず、通常のカラー表示時のシェイプの塗りつぶし、線、その他の書式設定は変更しません。

[BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) クラスから値を選択して目的の動作を指定します。例: `Automatic` は変換をアプリケーションに任せ、`Gray` と `LightGray` はグレイカラー、`BlackWhite` は黒と白のみ、`Black` と `White` は単一色、`Color` は通常のカラーを保持、`Hidden` は白黒モードでシェイプを省略します。`NotDefined` はシェイプレベルのモードが割り当てられていないことを意味します。

この例はオレンジの矩形を作成し、[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) でモードを `Gray` に設定します。保存されたシェイプは通常カラー表示ではオレンジの塗りつぶしを保持し、白黒表示を尊重するアプリケーションではグレーで描画されます。

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

通常カラー表示では矩形はオレンジの塗りつぶしを保持します。白黒表示のワークフローでは、モードが `Gray` に設定されているためグレーで描画されます。これにより、フルカラーのスライドを保持しつつ、印刷やプレビュー、その他白黒表示を尊重するワークフロー向けに別の外観を定義できます。

## **書式設定のリセット**

[Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) を使用すると、レイアウトプレースホルダーに対応するスライドプレースホルダーの位置、サイズ、書式設定を元に戻せます。この例はレイアウトにリンクされたプレースホルダーがある既存のプレゼンテーションが必要で、保存前にすべてのスライドをリセットします。対応するレイアウトプレースホルダーがないシェイプはリセットされません。

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

**シェイプの書式設定は最終的なプレゼンテーション ファイルサイズに影響しますか？**

色、線スタイル、効果設定は、埋め込み画像やメディアに比べてほとんどデータを増やしません。画像塗りつぶしは画像がプレゼンテーションに保存されるため、ファイルサイズを増加させる可能性があります。

**同一の書式設定を持つシェイプをスライド上で検出し、グループ化するにはどうすればよいですか？**

各シェイプの主要な書式プロパティ（塗りつぶし、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなし、論理的にグループ化します。これにより、後続のスタイル管理が簡素化されます。

**カスタム シェイプ スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

はい。目的のスタイルを持つサンプルシェイプをテンプレート スライド デッキまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成する際にテンプレートを開き、必要なスタイル付きシェイプをクローンして、必要な場所で書式設定を再適用します。