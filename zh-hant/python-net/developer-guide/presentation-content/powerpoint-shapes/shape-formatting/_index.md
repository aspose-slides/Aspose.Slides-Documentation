---
title: 在 Python 中格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/python-net/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 草圖效果
- 草圖形狀線條
- 格式化接合樣式
- 漸層填色
- 圖案填色
- 圖片填色
- 紋理填色
- 實色填色
- 形狀透明度
- 黑白形狀渲染
- 灰階形狀渲染
- 旋轉形狀
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "學習如何在 Python 中使用 Aspose.Slides 格式化 PowerPoint 形狀——精確且完整地設定 PPT、PPTX 與 ODP 檔案的填色、線條和效果樣式。"
---
## **介紹**

透過調整外框、填色與效果，在 PowerPoint 中格式化形狀。Aspose.Slides for Python via .NET 讓您能以程式方式控制這些設定，包含透明度、旋轉與 3D 格式化。

![PowerPoint 中的形狀格式設定選項](format-shape-powerpoint.png)

Aspose.Slides for Python via .NET 提供類別與屬性，讓您使用與 PowerPoint 相同的選項來格式化形狀。

## **格式線條**

使用 [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) 來控制形狀的外框。此範例建立一個未填色、藍色虛線外框的矩形。[LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) 選擇粗細複合線，而 [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) 將寬度設為 7 點，並以 [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) 選擇虛線樣式。

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

![簡報中格式化的線條](formatted-lines.png)

### **設定自訂線條虛線圖樣**

當預先定義的線條樣式無法提供所需的虛線長度與間距（例如品牌外框或技術圖表）時，使用 [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/)。指定圖樣會自動將 [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) 設為 [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/)。

清單條目在虛線與間距長度之間交替，從虛線開始。每個值都是線寬的倍數：在寬度為 3 點時，`[4, 2]` 產生 12 點的虛線，接著 6 點的間距。使用成對的有限、非負值來定義完整的虛線‑間距段落。範例使用正值以確保每段虛線與間距皆可見。

此範例建立五條相同長度且端點為平直的藍色線條。前三條在寬度 3 點時比較圖樣。第四條以雙倍寬度重複第一個圖樣，將虛線與間距同時加倍。第五條則從自訂圖樣切換為實線。

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

    # 將最後一條線返回為實線樣式。
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

若要改回預先定義的虛線樣式，將 [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) 指派給 [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/)。所選樣式會控制線條的外觀。

PowerPoint 中的結果（由上至下）：**{4, 2}, 3 pt**；**{1, 2}, 3 pt**；**{6, 2, 1, 2}, 3 pt**；**{4, 2}, 6 pt**；以及 **Solid, 3 pt**。

![PowerPoint 中的三種自訂虛線圖樣、使用第一種圖樣的較寬線條與實線](custom-dash-patterns.png)

### **設定線條端點樣式**

使用 [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) 來設定開放線條的兩端。[LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) 列舉提供三種明確的端點樣式：

- `FLAT`：筆劃在端點處停止。
- `ROUND`：半圓形端點超出端點半個線寬。
- `SQUARE`：方形端點超出端點半個線寬。

列舉還包含 `NOT_DEFINED`，表示未明確指派端點樣式。

端點樣式不同於箭頭（在端點添加符號）與接合（控制線段之間的角落）。此範例透過 [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) 與 [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) 停用箭頭，以僅比較端點形狀。

以下範例建立三條在其他屬性上相同的水平線，寬度為 20 點。由上而下分別使用平直、圓形與方形端點。它們的端點具有相同的水平座標；圓形與方形端點會超出每個端點 10 點。

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

PowerPoint 中的結果（由上至下）：**Flat**、**Round** 與 **Square**。

![PowerPoint 中相同粗線的平直、圓形與方形端點](line-caps.png)

## **將草圖效果套用於形狀線條**

草圖效果會讓形狀線條看起來像手繪。使用 [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) 取得線條設定，使用 [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) 取得草圖設定，並透過 [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) 從 [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 列舉中選擇值。

以下 Python 程式碼示範如何套用 [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 效果，讀取明確指派的值，並以 [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 移除效果：

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

由 [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) 回傳的值代表直接指派給形狀的設定。如果線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/)，存取 [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/)，並讀取 [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/)。有效值反映在繼承解析後實際套用的格式。此範例需要一個已有的簡報，且第一張投影片上至少有一個形狀，並會印出兩個值：

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

接合樣式控制兩個外框段在角落的相交方式。使用 **Round** 取得圓角，使用 **Miter** 取得尖角，或使用 **Bevel** 取得平緩的角落。

![簡報中的接合樣式](join-style-powerpoint.png)

此範例建立三個藍色外框、寬度 15 點的黑色矩形。分別將 [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) 設為 [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) 的斜接、斜面與圓形值，以比較角落的繪製方式。

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

### **在尖角限制斜接接合**

將 [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) 與 [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) 設為 [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) 可限制尖角可伸展的距離。

此限制是內外角距離與線寬的比例。例如，值 `8` 允許斜接長度最高為線寬的八倍；它不是以點數為單位的測量。如果角落會超過此限制，PowerPoint 會在該角落使用斜面接合。較大的限制允許更銳利的點。此設定僅影響斜接接合，且在角落仍在限制範圍內時不會產生可見變化。

此範例建立兩個相同、未填色的三角形，外框寬度為 20 點。左側三角形使用限制 `2`，右側使用 `8`。每個三角形寬 80 點、高 160 點，使其頂部角的斜接長度與線寬比例約為 `4.12`。因此，PowerPoint 會對左側頂點使用斜面，並保留右側尖銳的頂點。

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

PowerPoint 中的結果：左側 **Miter limit 2**，右側 **miter limit 8**。

![PowerPoint 中斜面限制 2 的斜面頂點與斜面限制 8 的尖銳頂點](miter-limits.png)

## **漸層填色**

漸層填色會在形狀內部混合顏色。此範例使用 [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/) 將橢圓以 45 度角的線性漸層從紅色過渡到紫色填滿。透過 [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) 方法將顏色停止點分別放在 0 與 1（漸層的開始與結束）。清除現有的停止點可確保只使用這兩種顏色。

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

![具有漸層填色的橢圓](gradient-fill.png)

如果匯出的影像中的漸層與 PowerPoint 中顯示的不同，請參閱 [Choose a Gradient Rendering Style](/slides/zh-hant/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不變更簡報中儲存的漸層填色的情況下選擇渲染樣式。

### **設定線性漸層角度**

使用 [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) 來控制 [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) 填色的方向。角度以度為單位，順時針遞增：`0` 為左至右，`90` 為上至下，`180` 為右至左，`270` 為下至上。支援小數角度。超出 `[0, 360)` 的有限角度會正規化為一圈；例如 `-45` 變為 `315`，`360` 變為 `0`。

此範例建立六個矩形，於位置 `0`、`0.5`、`1` 處設定相同的紅、綠、藍停止點。停用縮放以使角度比較不受矩形比例影響。從左至右的角度分別為 `0`、`45`、`90`（第一行），以及 `135`、`180`、`270`（第二行）。

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

![上排 0、45、90 度的線性漸層，下排 135、180、270 度的線性漸層](linear-gradient-angles.png)

### **以形狀縮放線性漸層**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) 接受 [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) 值。將其明確設為 `FALSE` 可在形狀比例變化時保持幾何漸層角度不變，或設為 `TRUE` 使漸層隨形狀的寬度與高度縮放。啟用縮放時，非正方形形狀的可見角度可能與指派角度不同。

以下範例使用 `45` 度角與先前相同的顏色停止點。左欄使用 `FALSE`，右欄使用 `TRUE`。每欄包含一個寬矩形上方與一個高矩形下方。兩者皆以相同的寬度起始；變更第二個矩形的寬高，示範在不變更漸層設定的情況下，填色如何回應尺寸調整。

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

PowerPoint 中的結果：左側縮放停用，右側縮放啟用：

![左側縮放停用、右側縮放啟用的寬與高矩形，皆使用 45 度漸層](linear-gradient-scaling.png)

縮放停用時，對角色帶在兩個矩形中保持相同方向。縮放啟用時，色帶隨形狀比例伸展。此功能有助於在將形狀調整至不同尺寸時還原範本的漸層效果。於正方形上，啟用縮放不會改變此 `45` 度漸層的外觀。

角度與縮放設定皆僅適用於線性漸層。它們不會控制 [GradientShape.RADIAL 或 GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) 填色。

### **將角度與漸層方向結合**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) 從 [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/) 列舉中選取漸層樣式；它不是數值角度的替代品。對於線性漸層，角落樣式可在不變更 [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) 的情況下改變顏色分布的範圍。比較角度或縮放時，請保持方向不變。

以下範例以相反的順序套用相同設定。兩個矩形呈現相同外觀：先設定方向或先設定角度皆不會改變結果。

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

## **圖案填色**

圖案填色會套用兩色設計，如點、條紋或格子。此範例使用 [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) 選取格子圖案。[PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) 提供淡灰色背景，而 [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) 提供黃色圖案顏色。

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

![具有圖案填色的矩形](pattern-fill.png)

## **圖片填色**

圖片填色會在形狀內使用影像。此範例需要本機影像，並使用 [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) 載入至簡報的影像集合。將 [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) 設為「平鋪」模式，可在矩形內重複影像。下方顯示所使用的來源影像：

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

![具有圖片填色的形狀](picture-fill.png)

### **將圖片平鋪為紋理**

若要將平鋪圖片設為紋理並自訂平鋪行為，可使用以下 [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) 類別的屬性：

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): 設定圖片填色模式——`TILE` 或 `STRETCH`。
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): 指定平鋪在形狀內的對齊方式。
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): 控制平鋪是否在水平、垂直或同時翻轉。
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): 設定平鋪的水平偏移（以點為單位）相對於形狀原點。
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): 設定平鋪的垂直偏移（以點為單位）相對於形狀原點。
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): 以百分比定義平鋪的水平縮放。
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): 以百分比定義平鋪的垂直縮放。

此範例需要本機影像，並將 [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) 設定為以原始大小的 50% 重複。將 X 與 Y 偏移設為 ‑32 點，使平鋪在水平與垂直方向上平移；右下對齊且同時在兩個方向翻轉，決定了重複紋理的排列方式。

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

## **實色填色**

實色填色會為形狀提供單一均勻顏色。此範例將 [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 設為實色填色模式，並透過 [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) 指派黃色，最後將矩形儲存至簡報。

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

![具有實色填色的形狀](solid-color-fill.png)

### **在保留主題參照的同時複製顏色**

使用 [ColorFormat.copy_from](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/copy_from/) 複製顏色定義，包括其顏色類型、主題參照與變換。這在將填色在應持續遵循簡報主題的形狀之間轉移時很有用。此方法僅複製顏色本身：不會複製填色類型、外框或其他形狀格式。請明確設定目標的 [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/)。

此範例建立三個矩形，從左至右分別為：來源、具主題感知的複本、以及固定 RGB 複本。來源使用 [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) 參照第一個強調色，並透過 [ColorOperationCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/coloroperationcollection/add/) 加上色調。RGB 複本使用來源的有效填色，使三者起初外觀相同。指派 [ColorFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color/) 後，會設定固定的 RGB 值並清除任何既有的顏色變換。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(660, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    presentation.master_theme.color_scheme.accent1.color = draw.Color.royal_blue

    source = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 40, 180, 140)
    theme_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 240, 40, 180, 140)
    rgb_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.fill_format.fill_type = slides.FillType.SOLID
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    source_color = source.fill_format.solid_fill_color
    source_color.scheme_color = slides.SchemeColor.ACCENT1
    source_color.color_transform.add(slides.ColorTransformOperation.TINT, 0.75)

    theme_copy.fill_format.solid_fill_color.copy_from(source_color)
    rgb_copy.fill_format.solid_fill_color.color = source.fill_format.get_effective().solid_fill_color

    with slide.get_image(1.0, 1.0) as before:
        before.save("color-copy-before.png", slides.ImageFormat.PNG)

    # 主題參照會跟隨新的強調色彩；固定的 RGB 值則不會。
    presentation.master_theme.color_scheme.accent1.color = draw.Color.orange_red

    with slide.get_image(1.0, 1.0) as after:
        after.save("color-copy-after.png", slides.ImageFormat.PNG)
    presentation.save("copied_colors.pptx", slides.export.SaveFormat.PPTX)
```

主題變更前，三個填色均相同：

![來源、copy_from 目的地與固定 RGB 目的地，皆具有相同藍色填色](color-copy-before.png)

主題變更後，來源與具主題感知的複本會跟隨新的強調色並保留其色調。固定 RGB 複本仍保持藍色：

![來源與 copy_from 目的地呈現橙色填色，固定 RGB 目的地仍為藍色](color-copy-after.png)

複製的定義與來源獨立。之後更改來源的主題參照、指派其他顏色，或加入或移除其變換，都不會影響目的地。主題變更仍會影響兩個形狀，因為它們各自獨立參照相同的主題顏色。

儲存並重新開啟 PPTX 後，會保留已複製顏色的 [ColorFormat.color_type](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_type/)、主題參照與 [ColorFormat.color_transform](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_transform/) 集合；不會將定義展平成 RGB。

在不同主題環境（例如使用不同強調色調色盤的簡報）之間複製時，複製的參照會根據目的地的主題解析。因此，同一參照與變換在不同簡報中可能產生不同的可見顏色。請參閱 [Presentation Theme](/slides/zh-hant/python-net/presentation-theme/) 瞭解設定主題顏色的更多資訊。

## **將投影片背景作為形狀填色**

當形狀應與投影片背景相同（例如在投影片範本中）時，使用 [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/)。先將 [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 設為 [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 以移除任何明確的填色。如此一來，形狀會使用投影片背景而非其樣式填色。僅啟用此旗標不會移除已存在的明確填色。

此行為不同於 [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)：背景填色會以投影片背景的相應區域覆蓋形狀背後的物件，而「無填色」則會讓這些物件保持可見。漸層仍會相對於投影片對齊，而非在每個形狀內重新開始。

以下範例建立一個被投影片繼承的母版背景，並在三個矩形後方放置品紅色條帶。左側矩形使用背景填色；中間矩形無填色；右側矩形則從背景填色切換為明確的橙色填色。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # 從母片繼承漸層。
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

    # 先加入此物件，使其顯示在矩形後方。
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

    # 在套用明確填色前先停用背景填色。
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果（由左至右）：**背景填色**、**無填色** 與 **明確填色**。品紅條帶被左側與右側矩形遮蔽，但仍在中間矩形下可見。

![背景填色、無填色與明確橙色填色覆蓋在品紅條帶上](background-fill.png)

相同的行為也適用於直接定義於投影片或從版面繼承的背景。形狀使用投影片解析後的背景；此範例保持投影片與版面背景皆未定義，讓母版提供背景。

## **設定透明度**

對於實色填色，顏色的 alpha 成分控制不透明度：0 為完全透明，255 為完全不透明。此範例將 alpha 值設為 128，為黃色矩形設定約 50% 的透明度，使底下的矩形仍可見。顏色透過 [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) 指派。

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

![透明的形狀](shape-transparency.png)

## **旋轉形狀**

使用 [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) 以在投影片平面上旋轉形狀。角度以度為單位；此範例將矩形順時針旋轉 5 度，然後儲存簡報。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![形狀旋轉效果](shape-rotation.png)

## **新增 3D 斜角效果**

使用 [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) 為形狀加入深度與斜角邊緣。此範例建立一個綠色橢圓、橙色外框，將 [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) 設為 4 點，並透過 [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) 套用寬度與高度皆為 6 點的圓形上斜角。前視正投影相機與三點光源使斜角可見。

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

形狀的 3D 觀點由相機設定控制。此範例使用 [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/)，將緯度、經度與旋轉角度分別設定為 40、35、20 度。再透過 [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) 選取等角相機，並以 [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) 設定平衡光源，最後儲存已格式化的矩形。

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

## **控制形狀的黑白渲染模式**

[Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) 屬性指定當簡報以黑白模式檢視或處理時，個別形狀的渲染方式。此屬性本身不會啟用黑白顯示，也不會在一般彩色模式下改變形狀的填色、線條或其他格式。

請使用 [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) 列舉的值來選擇所需行為。例如，`AUTOMATIC` 讓渲染應用程式自行決定轉換方式，`GRAY` 與 `LIGHT_GRAY` 使用灰階著色，`BLACK_WHITE` 只使用黑白，`BLACK` 與 `WHITE` 強制單一顏色，`COLOR` 保留正常著色，`HIDDEN` 在黑白模式下隱藏形狀，`NOT_DEFINED` 表示未指派形狀層級的模式。

此範例建立一個橙色矩形，將 [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) 設為灰色。儲存後的形狀在一般彩色顯示時保留橙色填色，而在支援黑白顯示設定的應用程式中會以灰色著色：

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

在正常彩色模式下，矩形保留其橙色填色。在黑白顯示工作流程中，因模式設定為 `GRAY`，其顏色會變為灰色。這讓您在保留全彩投影片的同時，為列印、預覽或其他遵循簡報黑白顯示設定的工作流程定義不同的外觀。

## **重設格式**

使用 [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) 可從相應的版面投影片佔位符還原投影片佔位符的位置、尺寸與格式。此範例需要一個已存在且佔位符與版面連結的簡報，並在儲存前重設每張投影片。沒有對應版面佔位符的形狀不會被重設。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**形狀格式化會影響最終簡報檔案大小嗎？**

顏色、線條樣式與效果設定相較於內嵌影像與媒體，通常只會佔用極少的資料。圖片填色可能會因為儲存於簡報中的影像而增加檔案大小。

**如何偵測投影片上具有相同格式的形狀，以便將它們分組？**

比較每個形狀的關鍵格式屬性——填色、線條與效果設定。若所有對應值相同，即可視為樣式相同，並在邏輯上將這些形狀分組，這有助於之後的樣式管理。

**我可以將一組自訂形狀樣式儲存至單獨的檔案，以便在其他簡報中重複使用嗎？**

可以。將具有所需樣式的範例形狀儲存於範本投影片或 .POTX 範本檔案中。建立新簡報時，開啟該範本，複製需要的樣式形狀，並在需要的地方重新套用其格式。