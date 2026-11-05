---
title: 使用 Python（透過 Java）格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/python-java/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 素描效果
- 素描形狀線條
- 格式化接合樣式
- 漸層填色
- 圖樣填色
- 圖片填色
- 紋理填色
- 純色填色
- 形狀透明度
- 黑白形狀呈現
- 灰階形狀呈現
- 旋轉形狀
- 3D 倒角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何在 Python（透過 Java）使用 Aspose.Slides 格式化 PowerPoint 形狀——精確且完整地設定 PPT 和 PPTX 檔案的填色、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中透過調整輪廓、填色和效果來格式化形狀。Aspose.Slides for Python via Java 讓您以程式方式控制這些設定，包括透明度、旋轉和 3D 格式化。

![PowerPoint 中的形狀格式化選項](format-shape-powerpoint.png)

Aspose.Slides for Python via Java 提供類別和方法，讓您使用 PowerPoint 中相同的選項來格式化形狀。

## **格式線條**

使用 [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) 來控制形狀的輪廓。此範例建立一個未填充的矩形，具有藍色虛線輪廓。[LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) 選擇粗細混合複合線，而 [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) 將寬度設定為 7 點，且 [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) 選擇虛線樣式。

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

結果如下：

![簡報中格式化的線條](formatted-lines.png)

### **設定自訂線條虛線樣式**

使用 [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) 當預定義的線條樣式無法提供所需的虛線長度和間隔時，例如品牌輪廓或技術圖表。指派樣式會自動將線條虛線樣式變更為 [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/).

陣列項目交替為虛線與間隔長度，從虛線開始。每個值都是線寬的倍數：寬度為 3 點時 `[4, 2]` 產生 12 點虛線與 6 點間隔。使用有限且非負的值對來定義完整的虛線‑間隔段落。範例使用正值以保持每段虛線與間隔皆可見。

此範例建立五條藍色線條，長度相同且端點為平直。前三條在寬度 3 點時比較不同樣式。第四條以兩倍寬度重複第一種樣式，將虛線與間隔長度皆加倍。第五條則從自訂樣式切換為實線。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpame.startJVM()

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

    # 將最後一條線恢復為實線樣式。
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

若要改回預定義的虛線樣式，傳入 [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) 給 [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle)。所選樣式控制線條的外觀。

PowerPoint 中的結果（自上而下）： **{4, 2}, 3 pt**；**{1, 2}, 3 pt**；**{6, 2, 1, 2}, 3 pt**；**{4, 2}, 6 pt**；以及 **Solid, 3 pt**。

![PowerPoint 中的三種自訂虛線樣式、使用第一種樣式的較寬線條，以及實線](custom-dash-patterns.png)

### **設定線端樣式**

使用 [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) 來設定開放線條的端點。[LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) 類別提供三種顯式端點樣式：

- `Flat`：筆畫在端點處停止。
- `Round`：半圓形端點延伸至端點以外，距離為線寬的一半。
- `Square`：方形端點延伸至端點以外，距離為線寬的一半。

此類別亦包含 `NotDefined`，表示未明確指派任何端點樣式。

端點與箭頭（在端點加入符號）以及接合（控制線段之間的拐角）不同。此範例透過 [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) 與 [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) 停用箭頭，僅比較端點形狀。

以下範例建立三條在其他方面相同的水平線，寬度皆為 20 點。自上而下分別使用平直、圓形與方形端點。它們的端點水平座標相同；圓形與方形端點各向外延伸 10 點。

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

PowerPoint 中的結果（自上而下）： **Flat**、**Round** 與 **Square**。

![PowerPoint 中相同粗線的平直、圓形與方形端點](line-caps.png)

## **套用草圖效果於形狀線條**

草圖效果使形狀線條看起來像手繪。使用 [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) 取得線條設定，使用 [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) 取得草圖設定，並使用 [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) 從 [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) 類別中選取值。

以下 Python 程式碼示範如何套用 [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) 效果、讀取明確指派的值，並以 [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) 移除效果：

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

[SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) 回傳的值代表直接指派給形狀的設定。如果線條格式可能從佈景主題、母片或版面投影片繼承，請使用 [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) 並從回傳的有效線條格式中讀取草圖類型，如下所示。有效值反映在繼承解析後實際套用的格式。此範例需要一個已有至少一個形狀位於第一張投影片的簡報，並同時列印兩個值：

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

以下為三種接合類型選項：

* Round
* Miter
* Bevel

接合樣式控制兩段輪廓在拐角處的相會方式。使用 **Round** 可取得圓角，使用 **Miter** 可取得尖角，使用 **Bevel** 可取得平緩的角。

![簡報中的接合樣式](join-style-powerpoint.png)

此範例建立三個藍色輪廓、寬度 15 點的黑色矩形。分別使用 [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) 設定 [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) 的斜接合、倒角接合與圓形接合，以比較角落的繪製方式。

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

### **限制銳角時的斜接合**

使用 [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) 搭配將 [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) 設為 [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) 以限制銳角可延伸的程度。

限制是內外角之間距離與線寬的比率。例如，值 `8` 允許斜接合長度最多為線寬的八倍；它不是以點數作為測量單位。若角落超過此限制，PowerPoint 會在該角落改用倒角接合。較大的限制容許更尖銳的點。此設定僅影響斜接合，當角落仍在限制內時不會產生可見變化。

此範例建立兩個相同、未填充的三角形，輪廓寬度為 20 點。左側三角形使用限制 `2`，右側使用 `8`。每個三角形寬 80 點、高 160 點，使其頂角的斜接合長度與線寬比約為 `4.12`。因此，PowerPoint 會將左側的頂點倒角化，右側則保留尖銳頂點。

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

PowerPoint 中的結果：左側 **斜接合限制 2**，右側 **斜接合限制 8**。

![PowerPoint 中，斜接合限制 2 的倒角頂點與斜接合限制 8 的尖銳頂點](miter-limits.png)

## **漸層填色**

漸層填色會在形狀內混合顏色。此範例使用 [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat) 以 45 度角將橢圓由紅色漸變至紫色。[GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) 方法在 0 與 1 位置（漸層的起點與終點）放置顏色停止點。清除既有的停止點可確保僅使用這兩種顏色。

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

![具有漸層填色的橢圓](gradient-fill.png)

如果匯出影像的漸層與 PowerPoint 中的呈現不同，請參閱 [選擇漸層呈現樣式](/slides/zh-hant/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不更改簡報內儲存的漸層填色的情況下切換呈現樣式。

### **設定線性漸層角度**

使用 [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) 來控制 [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/) 填色的方向。角度以度為單位，順時針遞增：`0` 為左至右，`90` 為上至下，`180` 為右至左，`270` 為下至上。支援小數角度。超出 `[0, 360)` 的有限角度會正規化為一圈，例如 `-45` 變為 `315`、`360` 變為 `0`。

此範例建立六個矩形，皆在位置 `0`、`0.5`、`1` 設定相同的紅、綠、藍色停止點。停用縮放以便角度能獨立於矩形比例比較。角度由左至右依序為第一排的 `0`、`45`、`90`，第二排的 `135`、`180`、`270`。

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

![上排 0°, 45°, 90° 與下排 135°, 180°, 270° 的線性漸層](linear-gradient-angles.png)

### **以形狀縮放線性漸層**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) 接受一個 [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) 值。將其明確設為 `False_` 可在形狀比例變化時保持幾何漸層角度不變，或設為 `True_` 使漸層隨形狀寬高縮放。啟用縮放時，在非正方形形狀上可見角度可能與指派角度不同。

以下範例使用 `45` 度角與相同的顏色停止點。左欄使用 `False_`，右欄使用 `True_`。每欄包含一個寬矩形上方與一個高矩形下方。兩者起始尺寸相同；變更第二個矩形的寬高以示範在不改變漸層設定的情況下，填色如何回應尺寸調整。

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

PowerPoint 中的結果（左側縮放停用，右側縮放啟用）：

![寬和高矩形的 45° 漸層，左側為 LinearGradientScaled False，右側為 True 的比較](linear-gradient-scaling.png)

縮放停用時，對角色帶在兩個矩形中保持相同方向。啟用縮放時，色帶會隨形狀比例伸展。這有助於在將形狀調整為不同尺寸時，復製範本的漸層。在正方形上，啟用縮放不會改變此 `45` 度漸層的外觀。

角度與縮放設定皆適用於線性漸層，並不控制 [GradientShape.Radial 或 GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/) 填色。

### **結合角度與漸層方向**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) 從 [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/) 類別中選取漸層樣式；它並非數值角度的替代方案。對於線性漸層，角落樣式可在不變更透過 [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) 指派的角度下，改變顏色分布的範圍。比較角度或縮放時，保持方向不變。

以下範例以相反順序套用相同設定。兩個矩形呈現相同外觀：先設定方向再設定角度或相反順序均不改變結果。

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

## **圖樣填色**

圖樣填色會套用兩色圖案，例如點、條紋或格子。此範例使用 [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) 選取格子圖案。[PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) 提供淡灰色背景，而 [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) 提供黃色圖案顏色。

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

![具有圖樣填色的矩形](pattern-fill.png)

## **圖片填色**

圖片填色會在形狀內使用影像。此範例需要本機影像，並使用 [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) 將其載入簡報的影像集合。將 [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) 設為平鋪模式，即可在矩形內重複影像。以下顯示所使用的原始影像：

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

![具有圖片填色的形狀](picture-fill.png)

### **將圖片平鋪為紋理**

如果想將平鋪圖片作為紋理並自訂平鋪行為，可使用以下 [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) 方法：

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode)：設定圖片填充模式—`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment)：指定平鋪在形狀內的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip)：控制平鋪是否水平、垂直或同時翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX)：設定平鋪相對於形狀原點的水平偏移（點）。
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY)：設定平鋪相對於形狀原點的垂直偏移（點）。
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX)：以百分比定義水平縮放。
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY)：以百分比定義垂直縮放。

此範例需要本機影像，並將 [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) 設定為以原始大小 50% 重複。將 X 與 Y 偏移設定為 -32 點，使平鋪水平與垂直移動；底部右側對齊並在兩個方向翻轉，以決定重複紋理的排列方式。

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

純色填色為形狀提供單一、均勻的顏色。此範例使用 [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) 設定為純色填充模式，並透過 [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) 指定黃色，最後將矩形儲存至簡報。

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

![具有純色填色的形狀](solid-color-fill.png)

### **在保留佈景主題參照的同時複製顏色**

使用 [ColorFormat.copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#copyFrom) 複製顏色定義，包括其顏色類型、佈景主題參照與變換。此功能在將填色在應該繼續遵循簡報主題的形狀之間傳遞時特別有用。此方法僅複製顏色本身，不會複製填充類型、輪廓或其他形狀格式。請使用 [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) 明確設定目標的填充類型。

此範例建立三個矩形，從左到右分別為來源、具佈景主題感知的複本與固定 RGB 複本。來源使用 [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setSchemeColor) 參照第一個強調色，並透過 [ColorOperationCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/coloroperationcollection/#add) 增加色調。RGB 複本使用來源的有效填充顏色，三者最初看起來相同。呼叫 [ColorFormat.setColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setColor) 後，設定固定的 RGB 值並清除任何既有的顏色變換。

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

    # 主題參照遵循新的強調色；固定的 RGB 值不會變更。
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

主題變更前，三個填色皆相同：

![來源、copyFrom 目的地與固定 RGB 目的地皆具有相同的藍色填色](color-copy-before.png)

主題變更後，來源與具佈景主題感知的複本遵循新的強調色並保留色調。固定 RGB 複本仍保持藍色：

![來源與 copyFrom 目的地為橙色填色，固定 RGB 目的地仍為藍色](color-copy-after.png)

複製的定義與來源獨立。之後若更改來源的佈景主題參照、指派其他顏色，或增減其變換，都不會影響目的地。佈景主題變更仍會同時影響兩個形狀，因為它們各自獨立參照相同的主題顏色。

儲存並重新開啟 PPTX 時，會保留由 [ColorFormat.getColorType](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorType) 回傳的顏色類型、佈景主題參照與由 [ColorFormat.getColorTransform](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorTransform) 回傳的變換集合；不會將定義平面化為 RGB。

在不同佈景主題環境（例如不同強調色調色板的簡報）之間複製時，複製的參照會根據目的地的佈景主題解析。因此相同的參照與變換在不同簡報中可能產生不同的可見顏色。請參閱 [簡報佈景主題](/slides/zh-hant/python-java/presentation-theme/) 以了解佈景主題顏色的設定方式。

## **將投影片背景用作形狀填色**

使用 [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) 當形狀應與投影片背景相同，例如在簡報範本中。先以 [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) 設為 [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) 以移除任何明確的填色。結合此設定後，形狀會使用投影片背景而非其樣式填色。僅啟用此旗標不會移除已有的明確填色。

這與 [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) 不同：背景填色會以投影片背景相應區域覆蓋形狀後方的物件，而無填色則會讓這些物件保持可見。漸層仍會與投影片對齊，而不會在每個形狀內重新開始。

以下範例建立一個由母片繼承的背景，並在三個矩形後放置一條洋紅色帶。左側矩形使用背景填色，中間矩形無填色，右側矩形則從背景填色切換為明確的橙色填色。

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

    # 繼承母片的漸層。
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

    # 先加入此物件，使它顯示在矩形後方。
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

結果（左至右）：**背景填色**、**無填色**與**明確填色**。洋紅色帶在左側與右側矩形後被隱藏，但在中間矩形上仍可見。

![背景填色、無填色與明確橙色填色覆蓋洋紅條紋](background-fill.png)

相同的行為也適用於直接在投影片上定義或從版面繼承的背景。形狀會使用投影片解析後的背景；此範例將投影片與版面的背景皆留未定義，讓母片提供背景。

## **設定透明度**

對於純色填色，顏色的 alpha 元件控制不透明度：0 為完全透明，255 為完全不透明。此範例為黃色矩形設定 alpha 值 128，使其大約 50% 透明，讓下層矩形仍可見。顏色透過 [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) 指派。

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

![透明的形狀](shape-transparency.png)

## **旋轉形狀**

使用 [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) 以度數在投影片平面上旋轉形狀。此範例將矩形順時針旋轉 5 度，並儲存簡報。

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

![形狀旋轉](shape-rotation.png)

## **新增 3D 倒角效果**

使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) 為形狀添加深度與倒角。此範例建立綠色橢圓、橙色輪廓，使用 [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) 設定深度為 4 點，並透過 [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) 以寬高 6 點的圓形上倒角。前視正投影相機與三點燈光使倒角可見。

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

![3D 倒角效果](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

形狀的 3D 視圖由相機設定控制。此範例使用 [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) 設定緯度、經度與旋轉角度分別為 40、35、20 度。透過 [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) 選取等角投影相機，並以 [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) 設定平衡光源，最後儲存格式化後的矩形。

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

## **控制形狀的黑白呈現**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) 方法指定單一形狀在以黑白模式檢視或處理簡報時的呈現方式。它本身不會啟用黑白顯示，也不會在一般彩色模式下變更形狀的填色、線條或其他格式。

使用 [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) 類別中的值選取所需行為。例如，`Automatic` 讓應用程式自行選擇轉換方式，`Gray` 與 `LightGray` 使用灰階著色，`BlackWhite` 僅使用黑與白，`Black` 與 `White` 強制單色，`Color` 保留一般彩色，`Hidden` 在黑白模式下省略形狀。`NotDefined` 表示未指派形狀層級的模式。

此範例建立橙色矩形，並使用 [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) 將模式設為灰階。儲存後的形狀在一般彩色顯示時保留橙色填色，於支援黑白顯示設定的應用程式中則以灰階呈現：

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

在一般彩色模式下，矩形保留橙色填色。於黑白顯示工作流程中，因模式設定為 `Gray`，因此使用灰階著色。這讓您在保留完整彩色投影片的同時，為列印、預覽或其他遵循黑白顯示設定的工作流程定義不同外觀。

## **重設格式**

使用 [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) 從對應的版面佈局佔位項還原投影片佔位項的位置、大小與格式。此範例需要一個已有版面連結佔位項的簡報，並在儲存前重設每張投影片。未對應版面佔位項的形狀不會被重設。

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

## **常見問題集**

**形狀格式化會影響最終簡報檔案大小嗎？**

顏色、線條樣式與效果設定相較於嵌入的影像與媒體，通常只會增加少量資料。圖片填色可能會因為儲存影像而增加檔案大小。

**如何偵測投影片上具有相同格式的形狀以便將它們分組？**

比較每個形狀的關鍵格式屬性——填色、線條與效果設定。如果所有對應值相符，則視為格式相同，並可在邏輯上將這些形狀分組，簡化之後的樣式管理。

**我可以將自訂形狀樣式儲存到單獨的檔案以在其他簡報中重複使用嗎？**

可以。將具備所需樣式的範例形狀儲存在範本投影片或 .POTX 範本檔案中。建立新簡報時，開啟該範本，複製需要的樣式形狀，並在需要的地方重新套用其格式。