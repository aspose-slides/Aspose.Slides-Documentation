---
title: 在 Python 中格式化 PowerPoint 圖形
linktitle: 圖形格式化
type: docs
weight: 20
url: /zh-hant/python-net/shape-formatting/
keywords:
- 格式化圖形
- 格式化線條
- 草圖效果
- 圖形線條草圖
- 格式化接合樣式
- 漸層填滿
- 圖樣填滿
- 圖片填滿
- 質感填滿
- 實色填滿
- 圖形透明度
- 黑白圖形渲染
- 灰階圖形渲染
- 旋轉圖形
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 投影片
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python 中格式化 PowerPoint 圖形—精確且全面地設定 PPT、PPTX 和 ODP 檔案的填充、線條與效果樣式。"
---
## **簡介**

透過調整外框、填滿和效果來設定 PowerPoint 中的圖形。Aspose.Slides for Python via .NET 讓您能以程式方式控制這些設定，包括透明度、旋轉和 3D 格式設定。

![PowerPoint 中的圖形格式選項](format-shape-powerpoint.png)

Aspose.Slides for Python via .NET 提供類別和屬性，讓您可以使用 PowerPoint 中相同的選項來格式化圖形。

## **格式線條**

使用 [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) 來控制圖形的外框。此範例建立一個未填滿、藍色虛線外框的矩形。[LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) 選取粗細組合線，而 [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) 將寬度設為 7 點，且 [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) 選擇虛線樣式。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![投影片中格式化的線條](formatted-lines.png)

### **設定自訂線條虛線圖樣**

當預先定義的線條樣式無法提供所需的虛線長度與間隙時，請使用 [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/)。指派圖樣會自動將 [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) 設為 [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/)。

清單項目在虛線與間隙長度之間交替，從虛線開始。每個值都是線寬的倍數：在寬度為 3 點時，`[4, 2]` 會產生 12 點的虛線，接著是 6 點的間隙。請使用成對的有限、非負值來定義完整的虛線‑間隙段落。範例使用正值以確保每段虛線與間隙皆可見。

此範例建立五條藍色線條，長度相同且使用平直端點。前三條在寬度 3 點時比較不同的圖樣。第四條以兩倍寬度重複第一個圖樣，從而使虛線與間隙長度皆加倍。第五條則從自訂圖樣切換為實線。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # 將最後一條線還原為實線樣式。
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

若要改回預先定義的虛線樣式，請將 [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) 指派給 [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/)。所選樣式會控制線條的外觀。

PowerPoint 中的結果（由上而下）：**{4, 2}, 3 pt**；**{1, 2}, 3 pt**；**{6, 2, 1, 2}, 3 pt**；**{4, 2}, 6 pt**；以及 **Solid, 3 pt**。

![三種自訂虛線圖樣、使用第一種圖樣的較寬線條，以及實線的 PowerPoint 範例](custom-dash-patterns.png)

### **設定線條端點樣式**

使用 [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) 來設定開放線條的兩端。[LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) 列舉提供三種明確的端點樣式：

- `FLAT`：筆畫於端點處停止。
- `ROUND`：半圓形端點延伸至端點以外半個線寬。
- `SQUARE`：方形端點延伸至端點以外半個線寬。

列舉中亦包含 `NOT_DEFINED`，表示未明確指派端點樣式。

端點樣式不同於箭頭（在端點加入符號）以及連接樣式（控制線段之間的拐角）。此範例透過 [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) 與 [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) 停用箭頭，以便僅比較端點形狀。

以下範例建立三條在其他屬性皆相同的水平線條，寬度為 20 點。由上而下分別使用平直、圓形與方形端點。它們的端點具有相同的水平座標；圓形與方形端點會在每個端點之外延伸 10 點。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint 中的結果（由上而下）：**Flat**、**Round**、**Square**。

![在相同粗線條上使用平直、圓形與方形端點的 PowerPoint 範例](line-caps.png)

## **將草圖效果套用於圖形線條**

草圖效果可讓圖形線條呈現手繪外觀。使用 [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) 取得線條設定，使用 [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) 取得草圖設定，並使用 [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) 從 [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 列舉中選取值。

以下 Python 程式碼示範如何套用 [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 效果、讀取明確指派的值，並以 [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 移除效果：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

由 [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) 回傳的值代表直接指派給圖形的設定。若線條格式可能來自佈景主題、母片或版面投影片，請使用 [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/)，存取 [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/)，並讀取 [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/)。有效值反映在繼承解析後實際套用的格式。本範例需要一個已有投影片且首張投影片上至少有一個圖形，並同時列印兩個值：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    line_format = shape.line_format
    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **格式接合樣式**

以下是三種接合類型選項：

* Round
* Miter
* Bevel

接合樣式控制兩條外框線段在拐角處的相接方式。使用 **Round** 可得到圓角，**Miter** 可得到尖角，**Bevel** 可得到平緩的角落。

![投影片中的接合樣式](join-style-powerpoint.png)

此範例建立三個黑色矩形，藍色外框寬度為 15 點。分別將 [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) 設為 [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) 的斜接 (miter)、斜面 (bevel) 與圓角 (round) 值，以比較角落的呈現方式。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **在尖角限制斜接長度**

將 [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) 與 [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) 設為 [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) ，即可限制尖角可延伸的距離。

此限制是內外拐角距離與線寬的比例。例如，數值 `8` 允許斜接長度最多為線寬的八倍；它不是以點數作為測量單位。若角落會超過此限制，PowerPoint 會在該角落改用斜面接合。較大的限制會產生更尖銳的點。此設定僅影響斜接，且在角落仍在限制範圍內時不會產生可見變化。

此範例建立兩個相同的未填滿三角形，外框寬度為 20 點。左側三角形的限制為 `2`，右側為 `8`。每個三角形寬 80 點、高 160 點，使其頂部角的斜接長度與線寬比例約為 `4.12`。因此，PowerPoint 會將左側頂點斜面化，右側則保留尖角。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint 中的結果：左側為 **Miter limit 2**，右側為 **miter limit 8**。

![斜接限制 2 的斜面頂點與斜接限制 8 的尖銳頂點的 PowerPoint 範例](miter-limits.png)

## **漸層填滿**

漸層填滿會在圖形內混合顏色。此範例使用 [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/) 以 45 度角從紅色漸變至紫色的線性漸層填滿橢圓。透過 [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) 方法於 0 與 1 位置（漸層的開始與結尾）放置顏色停止點。清除現有的停止點可確保僅使用這兩種顏色。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![具有漸層填滿的橢圓](gradient-fill.png)

如果匯出影像後的漸層外觀與 PowerPoint 中不同，請參考 [Choose a Gradient Rendering Style](/slides/zh-hant/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不變更投影片中儲存的漸層填滿的前提下，選擇不同的渲染樣式。

### **設定線性漸層角度**

使用 [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) 來控制 [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) 填滿的方向。角度以度為單位，順時針遞增：`0` 為從左至右，`90` 為從上至下，`180` 為從右至左，`270` 為從下至上。亦支援小數角度。超出 `[0, 360)` 的有限角度會正規化為一圈，例如 `-45` 變為 `315`，`360` 變為 `0`。

此範例建立六個矩形，皆在位置 `0`、`0.5`、`1` 處使用相同的紅、綠、藍停止點。停用比例縮放，以便在不受矩形比例影響的情況下比較角度。左至右的角度分別為第一行的 `0`、`45`、`90`，以及第二行的 `135`、`180`、`270`。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint 中的結果：

![上排的 0、45、90 度線性漸層，及下排的 135、180、270 度線性漸層](linear-gradient-angles.png)

### **以圖形縮放線性漸層**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) 接受 [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) 值。明確設定為 `FALSE` 可在圖形比例變更時保持幾何漸層角度不變，設定為 `TRUE` 則會隨圖形的寬高一起縮放漸層。啟用縮放時，非方形圖形的可見角度可能與指派的角度不同。

以下範例使用 `45` 度角度與與角度比較相同的顏色停止點。左欄使用 `FALSE`；右欄使用 `TRUE`。每欄包含一個寬矩形上方與一個高矩形下方。兩者起始皆為相同的寬度，變更第二個矩形的寬高以示範填滿在調整大小時的回應，而不改變其漸層設定。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint 中的結果（左側縮放停用，右側縮放啟用）：

![寬與高矩形使用 45 度漸層，左側 linear_gradient_scaled 為 FALSE，右側為 TRUE 的比較圖](linear-gradient-scaling.png)

停用縮放時，對角線色帶在兩個矩形中保持相同方向。啟用縮放時，色帶會隨圖形比例伸展。這有助於在將圖形調整為不同大小時，復原模板的漸層。對於方形圖形，啟用縮放不會改變此 `45` 度漸層的外觀。

角度與縮放設定皆套用於線性漸層。它們不會控制 [GradientShape.RADIAL] 或 [GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) 的填滿。

### **將角度與漸層方向結合**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) 從 [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/) 列舉中選取漸層樣式；它並非數值角度的替代品。對於線性漸層，角落樣式可變更顏色分佈的區域而不改變 [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/)。在比較角度或縮放時，請保持方向不變。

以下範例以相反的順序套用相同設定。兩個矩形的外觀相同：先設定方向再設定角度，或先設定角度再設定方向，都不會改變結果。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **圖樣填滿**

圖樣填滿會套用兩色設計，例如點、條紋或格子。此範例使用 [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) 選取格子圖樣。[PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) 提供淡灰色背景，而 [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) 提供黃色圖樣顏色。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![具有圖樣填滿的矩形](pattern-fill.png)

## **圖片填滿**

圖片填滿會在圖形內使用影像。本範例需要本機影像，並使用 [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) 將其載入投影片的影像集合。將 [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) 設為平鋪模式，可在矩形內重複影像。以下顯示使用的來源圖片：

![蓮花圖片](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![具有圖片填滿的圖形](picture-fill.png)

### **將圖片平鋪為質感**

若要將平鋪圖片設為質感並自訂平鋪行為，可使用 [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) 類別的以下屬性：

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/)：設定圖片填滿模式—`TILE` 或 `STRETCH`。
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/)：指定平鋪在圖形內的對齊方式。
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/)：控制平鋪是否水平、垂直或同時翻轉。
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/)：設定平鋪在水平方向的偏移（以點為單位），相對於圖形原點。
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/)：設定平鋪在垂直方向的偏移（以點為單位），相對於圖形原點。
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/)：定義平鋪在水平方向的比例（百分比）。
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/)：定義平鋪在垂直方向的比例（百分比）。

此範例需要本機影像，並將 [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) 設定為以原始大小的 50% 重複。將 `-32` 點的偏移同時水平與垂直移動平鋪；底部右側對齊以及雙向翻轉決定了重複質感的排列方式。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![平鋪選項示意圖](tile-options.png)

## **實色填滿**

實色填滿會為圖形提供單一、均勻的顏色。此範例將 [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 設為實色填滿模式，並透過 [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) 指派黃色，最後將矩形儲存至投影片。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![具有實色填滿的圖形](solid-color-fill.png)

## **使用投影片背景作為圖形填滿**

當圖形需與投影片背景相匹配時（例如在投影片範本中），請使用 [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/)。先將 [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 設為 [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 以移除任何明確填滿。此組合下，圖形會使用投影片背景而非其樣式填滿。僅啟用此旗標不會移除既有的明確填滿。

此行為與 [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 不同：背景填滿會以投影片背景相應區域覆蓋圖形背後的物件，而無填充則會讓那些物件保持可見。漸層會與投影片對齊，而不會在每個圖形內重新啟動。

以下範例建立一個由母片繼承的背景，並在三個矩形後放置品紅色條帶。左側矩形使用背景，中間矩形無填滿，右側矩形則從背景填滿切換為顯式橙色填滿。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # 繼承母片的漸層。
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # 先加入此物件，使其出現在矩形之後。
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # 在套用顯式填滿之前，先停用背景填滿。
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果（由左至右）：**背景填滿**、**無填滿**、**顯式填滿**。品紅條帶被左側與右側矩形遮蔽，但仍在中間矩形之下可見。

![背景填滿、無填滿與顯式橙色填滿覆蓋在品紅條帶上](background-fill.png)

相同的行為亦適用於直接在投影片上定義或從版面繼承的背景。圖形使用投影片解析後的背景；本範例未為投影片與版面設定背景，讓母片提供背景。

## **設定透明度**

對於實色填滿，顏色的 alpha 元件控制不透明度：0 為完全透明，255 為完全不透明。此範例使用 128 的 alpha 值為黃色矩形設定，大約 50% 透明，使底下的矩形仍可見。顏色透過 [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) 指派。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![具有透明度的圖形](shape-transparency.png)

## **旋轉圖形**

使用 [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) 可在投影片平面上旋轉圖形。角度以度為單位；此範例將矩形順時針旋轉 5 度，並儲存投影片。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![圖形旋轉效果](shape-rotation.png)

## **新增 3D 斜角效果**

使用 [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) 可為圖形加入深度與斜角邊緣。此範例建立綠色橢圓、橙色外框，將 [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) 設為 4 點，並透過 [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) 套用寬度與高度皆為 6 點的圓形上斜角。前視正投影相機與三點式照明使斜角可見。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![3D 斜角效果示意圖](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

圖形的 3D 觀點由相機設定控制。此範例使用 [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) 設定緯度、經度與迴轉角度分別為 40、35、20 度。透過 [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) 選取等角相機，並使用 [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) 設定平衡照明，最後儲存已格式化的矩形。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![3D 旋轉效果示意圖](3D-rotation-effect.png)

## **控制圖形的黑白渲染**

[Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) 屬性指定在以黑白模式檢視或處理投影片時，單一圖形的渲染方式。它本身不會啟用黑白顯示，也不會在正常彩色模式下改變圖形的填滿、線條或其他格式設定。

請使用 [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) 列舉中的值來選取所需行為。例如，`AUTOMATIC` 讓渲染程式自行決定轉換方式，`GRAY` 與 `LIGHT_GRAY` 使用灰階顏色，`BLACK_WHITE` 僅使用黑白，`BLACK` 與 `WHITE` 強制單一顏色，`COLOR` 保留正常彩色，`HIDDEN` 在黑白模式下隱藏圖形。`NOT_DEFINED` 表示未指派圖形層級的模式。

此範例建立一個橙色矩形，並將 [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) 設為灰色。儲存的圖形在正常彩色顯示下仍保留橙色填滿，且在遵守黑白顯示設定的應用程式中會以灰色呈現：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

在正常彩色模式下，矩形保留橙色填滿。於黑白顯示工作流程中，因其模式設定為 `GRAY`，因此會使用灰色。此方式可在保留完整彩色投影片的同時，為列印、預覽或其他遵守投影片黑白顯示設定的工作流程定義不同的外觀。

## **重設格式**

使用 [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) 可從對應的版面投影片佔位項還原投影片佔位項的位置、大小與格式。本範例需要一個已有版面連結佔位項的投影片，並在儲存前重設每張投影片。未對應版面佔位項的圖形不會被重設。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題集**

**圖形格式化會影響最終投影片檔案大小嗎？**

顏色、線條樣式與效果設定相較於嵌入的影像與媒體通常佔用的資料很少。圖片填滿可能會因為其影像儲存在投影片中而增加檔案大小。

**如何偵測同一投影片上具有相同格式的圖形，以便將它們分組？**

比較每個圖形的關鍵格式屬性——填滿、線條與效果設定。若所有對應值相同，則視為樣式相同，並在邏輯上將這些圖形分組，這可簡化後續的樣式管理。

**我可以將自訂圖形樣式集合儲存為單獨檔案，以便在其他投影片中重複使用嗎？**

可以。將具有所需樣式的示範圖形儲存在範本投影片或 .POTX 範本檔案中。建立新投影片時，開啟範本，複製所需的已樣式圖形，並在需要的地方重新套用其格式設定。