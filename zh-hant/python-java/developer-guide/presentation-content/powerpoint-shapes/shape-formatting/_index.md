---
title: 在 Python via Java 中格式化 PowerPoint 圖形
linktitle: 圖形格式化
type: docs
weight: 20
url: /zh-hant/python-java/shape-formatting/
keywords:
- 格式化圖形
- 格式化線條
- 草圖效果
- 圖形線條草圖
- 格式化接合樣式
- 漸層填色
- 圖案填色
- 圖片填色
- 紋理填色
- 純色填色
- 圖形透明度
- 黑白圖形呈現
- 灰階圖形呈現
- 旋轉圖形
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何在 Python via Java 中使用 Aspose.Slides 格式化 PowerPoint 圖形——精確且完整控制 PPT 與 PPTX 檔案的填色、線條與效果樣式。"
---
## **簡介**

透過調整輪廓、填色與效果，為 PowerPoint 中的圖案套用格式。Aspose.Slides for Python via Java 讓您能以程式方式控制這些設定，包括透明度、旋轉與 3D 格式化。

![PowerPoint 中的圖案格式選項](format-shape-powerpoint.png)

Aspose.Slides for Python via Java 提供類別與方法，讓您使用 PowerPoint 中相同的選項來格式化圖案。

## **格式線條**

使用[Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat)來控制圖案的輪廓。本範例建立一個未填充且具有藍色虛線輪廓的矩形。[LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle)選取粗細組合線，而[LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth)將寬度設定為 7 點，且[LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle)選擇虛線樣式。

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

結果：

![簡報中格式化的線條](formatted-lines.png)

### **設定自訂線條虛線圖案**

當預先定義的線條樣式無法提供所需的虛線長度與間隙時（例如品牌輪廓或技術圖表），請使用[LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern)。指派圖案會自動將線條虛線樣式變更為[LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/)。

陣列項目交替表示虛線與間隙長度，從虛線開始。每個值皆為線寬的倍數：在寬度為 3 點時，`[4, 2]` 產生 12 點的虛線，接著 6 點的間隙。使用成對的有限且非負值來定義完整的虛線-間隙段落。範例使用正值以確保每條虛線與間隙皆可見。

此範例建立五條相同長度且使用平直端點的藍色線條。前三條在 3 點寬度下比較圖案。第四條以兩倍寬度重複第一個圖案，將虛線與間隙長度皆加倍。第五條則從自訂圖案切換為實線。

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

    # 將最後一條線設定為實線樣式。
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

若要改回預先定義的虛線樣式，請將[LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/)傳遞給[LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle)。所選樣式會控制線條的外觀。

PowerPoint 中的結果，從上到下：**{4, 2}, 3 pt**；**{1, 2}, 3 pt**；**{6, 2, 1, 2}, 3 pt**；**{4, 2}, 6 pt**；以及**Solid, 3 pt**。

![PowerPoint 中的三種自訂虛線圖案、使用第一個圖案的較寬線條，以及實線](custom-dash-patterns.png)

### **設定線端樣式**

使用[LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle)設定開放線條的兩端。[LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/)類別提供三種明確的端點樣式：

- `Flat`：筆劃在端點處停止。
- `Round`：半圓形端點延伸至端點之外，距離為線寬的一半。
- `Square`：方形端點延伸至端點之外，距離為線寬的一半。

此類別亦包含`NotDefined`，表示未明確指定端點樣式。

端點樣式不同於箭頭，箭頭會在線條末端加入符號；亦不同於接合樣式，接合樣式控制線段之間的拐角。此範例透過[LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle)與[LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle)停用箭頭，以便僅比較端點形狀。

以下範例建立三條除端點樣式外完全相同的水平線，寬度為 20 點。從上到下分別使用平直、圓形與方形端點。它們的端點具有相同的水平座標；圓形與方形端點會在每個端點延伸 10 點。

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

PowerPoint 中的結果，從上到下：**Flat**、**Round** 與 **Square**。

![PowerPoint 中相同粗線條的平直、圓形與方形端點](line-caps.png)

## **套用草圖效果於圖案線條**

草圖效果會使圖案線條呈現手繪外觀。使用[Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat)取得線條設定，使用[LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat)取得草圖設定，並使用[SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType)從[LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/)類別中選取值。

下面的 Python 程式碼示範如何套用[LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/)效果、讀取明確指派的值，並以[LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/)移除該效果：

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

由[SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType)回傳的值代表直接指派給圖案的設定。若線條格式可能從佈景主題、母片或版面投影片繼承，請使用[LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective)並從回傳的有效線條格式中讀取草圖類型，如下所示。有效值反映繼承解析後實際套用的格式。此範例需要一個已有簡報，且第一張投影片上至少有一個圖案，並印出兩個值：

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

## **格式接合樣式**

以下是三種接合類型選項：

* Round
* Miter
* Bevel

接合樣式控制兩條輪廓段在拐角處的相接方式。使用**Round**取得圓角，使用**Miter**取得尖角，或使用**Bevel**取得平坦的拐角。

![簡報中的接合樣式](join-style-powerpoint.png)

此範例建立三個黑色矩形，藍色輪廓寬度為 15 點。它使用[LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle)分別設定[LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/)為斜切、斜角與圓形值，以比較拐角的繪製方式。

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

### **限制尖角斜切接合**

使用[LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit)搭配將[LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle)設定為[LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/)來限制尖角可延伸的距離。

此限制為接合內外角之距離與線寬的比率。例如，值為`8`允許斜切長度最高為線寬的八倍；此值並非以點數衡量。若拐角超過此限制，PowerPoint 會在該拐角使用斜角接合。較大的限制允許更尖銳的點。此設定僅影響斜切接合，當拐角仍在限制內時，變更不會產生可見效果。

此範例建立兩個相同的未填充三角形，輪廓寬度為 20 點。左側三角形使用限制`2`，右側使用`8`。每個三角形寬 80 點、高 160 點，使其頂角的斜切長度與線寬比約為`4.12`。因此，PowerPoint 會斜角化左側頂點，保留右側頂點。

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

PowerPoint 中的結果：左側為**Miter limit 2**，右側為**miter limit 8**。

![PowerPoint 中斜切限制 2 的倒角頂點與斜切限制 8 的尖銳頂點](miter-limits.png)

## **漸層填色**

漸層填色會在圖形中混合顏色。本範例使用[FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat)以 45 度角在橢圓形上套用線性漸層，顏色由紅色過渡至紫色。[GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor)方法將顏色停止點放在 0 與 1，即漸層的開始與結束。清除現有的停止點可確保僅使用這兩種顏色。

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

結果：

![具有漸層填色的橢圓形](gradient-fill.png)

如果匯出圖片中的漸層與 PowerPoint 中呈現的不同，請參閱[Choose a Gradient Rendering Style](/slides/zh-hant/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不變更簡報內儲存的漸層填色的情況下選擇渲染樣式。

### **設定線性漸層角度**

使用[GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle)控制[GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/)填色的方向。角度以度數為單位，順時針遞增：`0` 代表從左至右，`90` 代表從上至下，`180` 代表從右至左，`270` 代表從下至上。支援小數角度。超出 `[0, 360)` 的有限角度會正規化為一圈，例如 `-45` 變為 `315`，`360` 變為 `0`。

此範例建立六個矩形，其紅、綠、藍三色停止點位置相同，分別為 `0`、`0.5` 與 `1`。停用縮放，以便角度能獨立於矩形比例比較。角度從左至右依序為第一列的 `0`、`45`、`90`，以及第二列的 `135`、`180`、`270`。

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

PowerPoint 中的結果：

![上排 0、45、90 度與下排 135、180、270 度的線性漸層](linear-gradient-angles.png)

### **隨圖形縮放線性漸層**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled)接受一個[NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/)值。明確設定為`False_`可在圖形比例變更時保持幾何漸層角度不變，設定為`True_`則使漸層隨圖形的寬度與高度縮放。啟用縮放後，非正方形圖形的可見角度可能與指派的角度不同。

以下範例使用 `45` 度角度與相同的顏色停止點作為角度比較。左欄使用 `False_`；右欄使用 `True_`。每欄包含一個寬矩形在上方與一個高矩形在下方。兩者皆從相同的寬尺寸開始；變更第二個矩形的寬度與高度即可展示填色在調整大小時的回應，而不改變其漸層設定。

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

PowerPoint 中的結果，左側停用縮放，右側啟用縮放：

![寬與高矩形的 45 度漸層比較：左側 LinearGradientScaled 為 False，右側為 True](linear-gradient-scaling.png)

停用縮放時，對角色帶在兩個矩形中保持相同方向。啟用縮放時，色帶會隨圖形比例伸展。這有助於在將圖形調整為不同尺寸時復原模板的漸層。對於正方形而言，啟用縮放不會改變此 `45` 度漸層的外觀。

角度與縮放設定皆適用於線性漸層。它們不會控制[GradientShape.Radial 或 GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/)填色。

### **將角度與漸層方向結合**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection)從[GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/)類別中選取漸層樣式；它並非數值角度的替代方案。對於線性漸層，角落樣式可變更顏色分佈的區域，而不改變透過[setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle)指派的角度。比較角度或縮放時，保持方向不變。

以下範例以相反的順序套用相同設定。兩個矩形的外觀相同：先指派方向或先指派角度皆不會改變結果。

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

## **圖案填色**

圖案填色會套用兩色設計，例如點、條紋或格子。此範例使用[PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle)選取格柵圖案。[PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor)提供淡灰色背景，[PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor)則提供黃色圖案顏色。

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

結果：

![使用圖案填色的矩形](pattern-fill.png)

## **圖片填色**

圖片填色會在圖形內使用圖像。本範例需要本機圖像，並使用[Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile)將其載入簡報的影像集合。將[PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode)設定為平鋪模式，會在矩形內重複圖像。以下顯示此處使用的來源圖像：

![蓮花圖片](lotus.png)

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

結果：

![使用圖片填色的圖形](picture-fill.png)

### **將圖片平鋪為紋理**

若要將平鋪圖片設定為紋理且自訂平鋪行為，可使用[PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/)類別的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode)：設定圖片填色模式——`Tile`（平鋪）或 `Stretch`（伸展）。
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment)：指定平鋪圖案在圖形內的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip)：控制平鋪圖案是否水平翻轉、垂直翻轉或同時翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX)：設定平鋪圖案相對於圖形原點的水平偏移（單位為點）。
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY)：設定平鋪圖案相對於圖形原點的垂直偏移（單位為點）。
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX)：以百分比定義平鋪圖案的水平縮放。
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY)：以百分比定義平鋪圖案的垂直縮放。

此範例需要本機圖像，並設定[PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/)以原始尺寸的 50% 進行平鋪。−32 點的水平與垂直偏移會移動平鋪圖案；右下對齊且同時翻轉兩個方向，決定重複紋理的排列方式。

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

結果：

![平鋪選項](tile-options.png)

## **純色填色**

純色填色為圖形賦予單一均勻的顏色。此範例使用[FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType)設定為純色填色，並透過[FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor)指定黃色，最後將矩形儲存於簡報中。

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

結果：

![使用純色填色的圖形](solid-color-fill.png)

## **將投影片背景用作圖形填色**

當圖形需要與投影片背景相匹配時（例如在簡報範本中），請使用[AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill)。先將[FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType)設定為[FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/)，以移除任何明確的填色。使用此組合時，圖形會使用投影片背景而非其樣式填色。僅啟用此旗標不會移除已有的明確填色。

這與[FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/)不同：背景填色會使用投影片背景的相應區域覆蓋圖形背後的物件，而無填色則會保留這些物件可見。漸層則保持與投影片對齊，而不是在每個圖形內重新開始。

以下範例建立一個被投影片繼承的母片背景，並在三個矩形後放置品紅色條帶。左側矩形使用背景，中央矩形無填色，右側矩形則從背景填色切換為明確的橙色填色。

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

    # 從母片繼承漸層。
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

    # 先加入此物件，使其顯示在矩形之後。
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

    # 在套用明確填色之前，先停用背景填色。
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果，從左至右：**background fill**、**no fill** 與 **explicit fill**。品紅色條帶被左側與右側矩形遮蔽，但在中間矩形可見。

![背景填色、無填色與明確橙色填色覆蓋品紅條帶](background-fill.png)

相同的行為也適用於直接在投影片上定義或從版面繼承的背景。圖形使用投影片解析後的背景；本範例保持投影片與版面的背景皆未定義，讓母片提供背景。

## **設定透明度**

對於純色填色，顏色的 alpha 成分控制不透明度：0 表示完全透明，255 表示完全不透明。此範例對黃色矩形使用 alpha 值 128，使其大約 50% 透明，以下方矩形仍可見。顏色透過[FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor)指派。

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

結果：

![透明的圖形](shape-transparency.png)

## **旋轉圖形**

使用[Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation)在投影片平面上旋轉圖形。角度以度數為單位；本範例將矩形順時針旋轉 5 度，並儲存簡報。

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

結果：

![圖形旋轉](shape-rotation.png)

## **新增 3D 斜角效果**

使用[Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat)為圖形添加深度與斜角邊緣。此範例建立一個綠色橢圓形，橙色輪廓，使用[ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth)將深度設定為 4 點，並透過[ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop)套用寬度與高度皆為 6 點的圓形上斜角。前視正投影相機與三點式照明使斜角可見。

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

結果：

![3D 斜角效果](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

圖形的 3D 觀點由相機設定控制。本範例使用[Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation)分別以 40、35、20 度的緯度、經度與旋轉角度。透過[Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType)選取等角相機，並使用[LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType)設定平衡光源，最後儲存已格式化的矩形。

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

結果：

![3D 旋轉效果](3D-rotation-effect.png)

## **控制圖形的黑白呈現**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode)方法指定在以黑白模式檢視或處理簡報時，各個圖形的呈現方式。此方法本身不會啟用黑白顯示，也不會在正常彩色模式下變更圖形的填色、線條或其他格式設定。

使用[BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/)類別中的值來選擇所需的行為。例如，`Automatic`讓呈現應用程式自行決定轉換方式，`Gray`與`LightGray`使用灰色，`BlackWhite`僅使用黑與白，`Black`與`White`強制單一顏色，`Color`保留正常顏色，`Hidden`在黑白模式下省略圖形。`NotDefined`表示未指派圖形層級的模式。

此範例建立一個橙色矩形，並使用[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode)將模式設定為灰色。儲存的圖形在正常彩色顯示時保留橙色填色，且會向支援黑白顯示設定的應用程式請求灰色著色：

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

在正常彩色模式下，矩形保留橙色填色。於黑白顯示工作流程中，因模式設定為`Gray`，它會使用灰色著色。這讓您在保留全彩投影片的同時，為列印、預覽或其他遵循簡報黑白顯示設定的工作流程定義不同的外觀。

## **重設格式**

使用[Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset)從相對應的版面配置占位元復原投影片占位元的位置、大小與格式。此範例需要一個已有版面連結占位元的簡報，並在儲存前重設每張投影片。沒有相對應版面占位元的圖形不會被重設。

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

## **常見問題**

**圖形格式化會影響最終簡報檔案大小嗎？**

與嵌入的圖像和媒體相比，顏色、線條樣式與效果設定通常僅增加少量資料。圖片填色可能會因圖像儲存在簡報中而提升檔案大小。

**如何偵測投影片上具有相同格式的圖形以便將其分組？**

比較每個圖形的關鍵格式屬性——填色、線條與效果設定。若所有相對應的值皆相符，則視為相同樣式，並在邏輯上將這些圖形分組，以簡化後續的樣式管理。

**我可以將一組自訂圖形樣式儲存至單獨檔案，以便在其他簡報中重複使用嗎？**

可以。將具備所需樣式的範例圖形儲存於範本投影片或 .POTX 範本檔案中。建立新簡報時，開啟該範本，複製所需的樣式圖形，並在需要的地方重新套用其格式。