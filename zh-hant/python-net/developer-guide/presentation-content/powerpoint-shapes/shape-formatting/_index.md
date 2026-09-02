---
title: 在 Python 中格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/python-net/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 素描效果
- 形狀線條素描
- 格式化連接樣式
- 漸層填色
- 圖案填色
- 圖片填色
- 紋理填色
- 純色填色
- 形狀透明度
- 旋轉形狀
- 3D 倒角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python 中格式化 PowerPoint 形狀——精確且完整地為 PPT、PPTX 與 ODP 檔案設定填色、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以向投影片添加形狀。由於形狀是由線條組成，您可以透過修改或套用效果來格式化其輪廓。除此之外，您還可以透過指定設定來控制形狀內部的填充方式，從而格式化形狀。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python 提供類別和屬性，可讓您使用與 PowerPoint 中相同的選項來格式化形狀。

## **格式化線條**

使用 Aspose.Slides，您可以為形狀指定自訂的線條樣式。以下步驟概述了此程序：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 新增至投影片。
1. 設定形狀的 [line style](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/linestyle/)。
1. 設定線條寬度。
1. 設定形狀的 [dash style](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/linedashstyle/)。
1. 設定形狀的線條顏色。
1. 將修改後的簡報另存為 PPTX 檔案。

以下 Python 程式碼示範如何格式化矩形 `AutoShape`：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個矩形類型的自動形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # 設定矩形形狀的填色。
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # 套用格式至矩形的線條。
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # 設定矩形線條的顏色。
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![The formatted lines in the presentation](formatted-lines.png)

## **將素描效果套用於形狀線條**

素描效果會讓形狀線條看起來像手繪。使用 [Shape.line_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/line_format/) 取得線條設定，使用 [LineFormat.sketch_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/lineformat/sketch_format/) 取得素描設定，並使用 [SketchFormat.sketch_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sketchformat/sketch_type/) 從 [LineSketchType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/linesketchtype/) 列舉中選取值。

以下 Python 程式碼示範如何套用 [LineSketchType.CURVED](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/linesketchtype/) 效果、讀取明確指派的值，並使用 [LineSketchType.NONE](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/linesketchtype/) 移除效果：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # 取得形狀的線條格式及其素描格式。
    sketch_format = shape.line_format.sketch_format

    # 套用素描效果。
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # 讀取直接指派給形狀的素描效果。
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # 移除素描效果。
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

`SketchFormat.sketch_type` 回傳的值代表直接指派給形狀的設定。若線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [LineFormat.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/lineformat/get_effective/)，取得回傳物件的 `sketch_format` 屬性，並讀取其 `sketch_type` 屬性。有效值反映在繼承解析後實際套用的格式：

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

## **格式化連接樣式**

以下是三種連接類型選項：

* 圓角
* 斜角
* 倒角

預設情況下，PowerPoint 在以角度（例如形狀的角落）連接兩條線時，使用 **Round** 設定。但是，若您繪製具有尖銳角度的形狀，可能會偏好 **Miter** 選項。

![The join style in the presentation](join-style-powerpoint.png)

以下 Python 程式碼示範如何使用 Miter、Bevel 和 Round 連接類型設定建立上述圖示中的三個矩形：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation() as presentation:

	# 取得第一張投影片。
	slide = presentation.slides[0]

	# 新增三個矩形類型的自動形狀。
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# 設定每個矩形形狀的填色。
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# 設定線條寬度。
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# 設定每個矩形線條的顏色。
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# 設定接合樣式。
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# 為每個矩形加入文字。
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# 將 PPTX 檔案儲存至磁碟。
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **漸層填色**

在 PowerPoint 中，漸層填色是一種格式化選項，可讓您對形狀套用連續的顏色混合。例如，您可以以一種顏色逐漸淡入另一種顏色的方式套用兩種或多種顏色。

以下說明如何使用 Aspose.Slides 對形狀套用漸層填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 新增至投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/) 設為 `GRADIENT`。
1. 使用 [GradientFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/gradientformat/) 類別所公開的 `gradient_stops` 集合的 `add` 方法，加入您偏好的兩種顏色與定義好的位置。
1. 將修改後的簡報另存為 PPTX 檔案。

```python
import aspose.slides as slides

# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個橢圓類型的自動形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # 為橢圓套用漸層格式。
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # 設定漸層方向。
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # 新增兩個漸層停止點。
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![The ellipse with gradient fill](gradient-fill.png)

## **圖案填色**

在 PowerPoint 中，圖案填色是一種格式化選項，可讓您對形狀套用雙色設計，例如點、條紋、交叉線或格子。您可以為圖案的前景色與背景色自訂顏色。

Aspose.Slides 提供超過 45 種預先定義的圖案樣式，您可以將它們套用至形狀，以提升簡報的視覺效果。即使選擇了預定義圖案，仍可指定其使用的精確顏色。

以下說明如何使用 Aspose.Slides 對形狀套用圖案填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 新增至投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/) 設為 `PATTERN`。
1. 從預先定義的選項中選取圖案樣式。
1. 設定圖案的 [back_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/patternformat/back_color/)。
1. 設定圖案的 [fore_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/patternformat/fore_color/)。
1. 將修改後的簡報另存為 PPTX 檔案。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個矩形類型的自動形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 設定填色類型為圖案。
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # 設定圖案樣式。
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # 設定圖案的背景色與前景色。
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![The rectangle with pattern fill](pattern-fill.png)

## **圖片填色**

在 PowerPoint 中，圖片填色是一種格式化選項，允許您在形狀內插入圖片，實際上將圖片作為形狀的背景。

以下說明如何使用 Aspose.Slides 為形狀套用圖片填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 新增至投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/) 設為 `PICTURE`。
1. 將圖片填色模式設為 `TILE`（或其他偏好的模式）。
1. 從您想使用的圖片建立 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 物件。
1. 將此圖片指派給形狀的 `picture_fill_format` 中的 `picture.image` 屬性。
1. 將修改後的簡報另存為 PPTX 檔案。

假設我們有一個名為「lotus.png」的檔案，其圖片如下：

![The lotus picture](lotus.png)

```python
import aspose.slides as slides

# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個矩形類型的自動形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # 設定填色類型為圖片。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 設定圖片填色模式。
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # 載入影像並將其加入簡報資源。
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # 設定圖片。
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![The shape with picture fill](picture-fill.png)

### **將圖片平鋪為紋理**

若您想將平鋪圖片作為紋理並自訂平鋪行為，可使用 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/) 類別的以下屬性：

- [picture_fill_mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/picture_fill_mode/)：設定圖片填色模式，可為 `TILE` 或 `STRETCH`。
- [tile_alignment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/tile_alignment/)：指定平鋪圖片在形狀內的對齊方式。
- [tile_flip](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/tile_flip/)：控制平鋪圖片是否水平翻轉、垂直翻轉，或同時翻轉。
- [tile_offset_x](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/tile_offset_x/)：設定平鋪圖片相對於形狀原點的水平位移（以點為單位）。
- [tile_offset_y](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/tile_offset_y/)：設定平鋪圖片相對於形狀原點的垂直位移（以點為單位）。
- [tile_scale_x](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/tile_scale_x/)：以百分比定義平鋪圖片的水平縮放比例。
- [tile_scale_y](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/tile_scale_y/)：以百分比定義平鋪圖片的垂直縮放比例。

以下程式碼範例示範如何新增一個具有平鋪圖片填色的矩形形狀，並設定平鋪選項：

```py
import aspose.slides as slides

# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    first_slide = presentation.slides[0]

    # 新增一個矩形自動形狀。
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # 設定形狀的填色類型為圖片。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 載入影像並將其加入簡報資源。
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # 指定影像給形狀。
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # 設定圖片填色模式與平鋪屬性。
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![The tile options](tile-options.png)

## **純色填色**

在 PowerPoint 中，純色填色是一種格式化選項，可使用單一均勻的顏色填滿形狀。此純色背景不包含任何漸層、紋理或圖案。

若要使用 Aspose.Slides 為形狀套用純色填色，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 新增至投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/) 設為 `SOLID`。
1. 將您偏好的填色顏色指派給形狀。
1. 將修改後的簡報另存為 PPTX 檔案。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個矩形類型的自動形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 設定填色類型為實心。
    shape.fill_format.fill_type = slides.FillType.SOLID

    # 設定填色顏色。
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![The shape with solid color fill](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您對形狀套用純色、漸層、圖片或紋理填色時，亦可設定透明度以控制填色的不透明度。較高的透明度會使形狀更透，讓背景或底層物件部分可見。

Aspose.Slides 允許您透過調整填色所使用顏色的 alpha 值來設定透明度。以下說明如何操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 新增至投影片。
1. 將填色類型設為 `SOLID`。
1. 使用 `Color.from_argb` 定義具有透明度的顏色（`alpha` 元件控制透明度）。
1. 儲存簡報。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]
    
    # 新增一個實心矩形自動形狀。
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 在實心形狀上方新增一個透明矩形自動形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![The transparent shape](shape-transparency.png)

## **旋轉形狀**

Aspose.Slides 允許您在 PowerPoint 簡報中旋轉形狀。這在需要特定對齊或設計需求的視覺元素定位時相當有用。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 新增至投影片。
1. 將形狀的 `rotation` 屬性設定為所需的角度。
1. 儲存簡報。

```python
import aspose.slides as slides

# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個矩形類型的自動形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 將形狀旋轉 5 度。
    shape.rotation = 5

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![The shape rotation](shape-rotation.png)

## **新增 3D 倒角效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat] 屬性，為其套用 3D 倒角效果。

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 新增至投影片。
1. 配置形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/) 以定義倒角設定。
1. 儲存簡報。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # 在投影片上新增形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # 設定形狀的 ThreeDFormat 屬性。
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![The 3D bevel effect](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat] 屬性，為其套用 3D 旋轉效果。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 新增至投影片。
1. 設定形狀的 [camera_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/camera/camera_type/) 和 [light_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/lightrig/light_type/) 以定義 3D 旋轉。
1. 儲存簡報。

```python
import aspose.slides as slides

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # 將簡報儲存為 PPTX 檔案。      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![The 3D rotation effect](3D-rotation-effect.png)

## **重設格式**

以下 Python 程式碼示範如何重設投影片的格式，並將 [LayoutSlide] 上所有含占位符的形狀的位移、尺寸和格式恢復為預設設定：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # 重設投影片上在版面中具有占位符的每個形狀。
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**形狀格式化會影響最終簡報檔案大小嗎？**

僅有極少的影響。嵌入的影像與媒體佔用了大部分檔案空間，而形狀的參數（如顏色、效果與漸層）以中繼資料形式儲存，幾乎不會增加額外大小。

**如何偵測投影片上具有相同格式的形狀，以便將它們分組？**

比較每個形狀的關鍵格式屬性——填色、線條與效果設定。若所有對應的值均相符，即可視為樣式相同，並在邏輯上將這些形狀分組，這有助於後續的樣式管理。

**我可以將一組自訂形狀樣式另存為檔案，以便在其他簡報中重複使用嗎？**

可以。將帶有所需樣式的範例形狀存放於範本投影片或 .POTX 範本檔案中。建立新簡報時，開啟該範本，複製所需的樣式形狀，並在需要的地方重新套用其格式。