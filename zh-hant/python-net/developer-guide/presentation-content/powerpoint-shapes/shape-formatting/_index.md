---
title: 在 Python 中格式化 PowerPoint 圖形
linktitle: 圖形格式化
type: docs
weight: 20
url: /zh-hant/python-net/shape-formatting/
keywords:
- 格式化圖形
- 格式化線條
- 手繪效果
- 手繪圖形線條
- 格式化接合樣式
- 漸層填色
- 圖案填色
- 圖片填色
- 紋理填色
- 純色填色
- 圖形透明度
- 黑白圖形算繪
- 灰階圖形算繪
- 旋轉圖形
- 3D 磨邊效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python 中格式化 PowerPoint 圖形——精確且完整控制地為 PPT、PPTX 與 ODP 檔案設定填色、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以在投影片中加入圖形。由於圖形是由線條組成，您可以透過修改或套用效果來格式化它們的輪廓。此外，您也可以透過指定控制內部填色方式的設定來格式化圖形。

![格式化圖形 PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python 提供類別和屬性，讓您能使用與 PowerPoint 相同的選項來格式化圖形。

## **格式化線條**

使用 Aspose.Slides，您可以為圖形指定自訂線條樣式。以下步驟說明了操作程序：

1. 建立 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別的實例。
1. 透過索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 設定圖形的 [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/)。
1. 設定線寬。
1. 設定圖形的 [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/)。
1. 設定圖形的線條顏色。
1. 將已修改的簡報另存為 PPTX 檔案。

以下 Python 程式碼示範如何格式化矩形 `AutoShape`：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個矩形類型的自動圖形。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # 移除矩形圖形的填色，使其僅顯示線條。
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # 為矩形的線條套用格式化。
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

![投影片中已格式化的線條](formatted-lines.png)

## **套用草圖效果於圖形線條**

草圖效果會使圖形線條看起來像手繪。使用 [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) 取得線條設定，使用 [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) 取得草圖設定，並使用 [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) 從 [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 列舉中選取值。

以下 Python 程式碼示範如何套用 [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 效果、讀取明確指派的值，以及使用 [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 移除效果：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # 存取圖形的線條格式及其草圖格式。
    sketch_format = shape.line_format.sketch_format

    # 套用草圖效果。
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # 讀取直接指派給圖形的草圖效果。
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # 移除草圖效果。
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

`SketchFormat.sketch_type` 回傳的值代表直接指派給圖形的設定。如果線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/) 取得繼承後的實際值，存取回傳物件的 `sketch_format` 屬性，並讀取其 `sketch_type` 屬性。有效值會反映在解決繼承後實際套用的格式：

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
* 斜面

預設情況下，PowerPoint 在以角度（例如圖形的角落）連接兩條線時，使用 **Round** 設定。然而，若您繪製的圖形具有銳角，可能較喜歡 **Miter** 選項。

![投影片中的連接樣式](join-style-powerpoint.png)

以下 Python 程式碼示範如何使用 Miter、Bevel 與 Round 連接類型設定建立如上圖所示的三個矩形：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

	# 取得第一張投影片。
	slide = presentation.slides[0]

	# 新增三個矩形類型的自動圖形。
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# 設定每個矩形圖形的填色。
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

在 PowerPoint 中，漸層填色是一種格式化選項，可讓您對圖形套用連續的顏色混合。例如，您可以以漸變方式將兩種或更多顏色逐漸過渡。

以下說明如何使用 Aspose.Slides 為圖形套用漸層填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別的實例。
1. 透過索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 設為 `GRADIENT`。
1. 使用 [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/) 類別所公開的 `gradient_stops` 集合的 `add` 方法，依定義的位置加入您偏好的兩種顏色。
1. 將已修改的簡報另存為 PPTX 檔案。

以下 Python 程式碼示範如何為橢圓套用漸層填色效果：

```python
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個橢圓類型的自動圖形。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # 為橢圓套用漸層格式化。
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # 設定漸層的方向。
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # 加入兩個漸層停止點。
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![漸層填色的橢圓](gradient-fill.png)

如果在匯出影像時漸層的顯示與 PowerPoint 中不同，請參閱 [Choose a Gradient Rendering Style](/slides/zh-hant/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不變更簡報內儲存的漸層填色的情況下選擇算繪樣式。

## **圖案填色**

在 PowerPoint 中，圖案填色是一種格式化選項，可讓您對圖形套用兩色設計，例如點、條紋、交叉陰影或格子。您可以為圖案的前景色與背景色自訂顏色。

Aspose.Slides 提供超過 45 種預定義圖案樣式，您可以將它們套用於圖形，以提升簡報的視覺效果。即使選取了預定義圖案，仍可指定其實際使用的顏色。

以下說明如何使用 Aspose.Slides 為圖形套用圖案填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別的實例。
1. 透過索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 設為 `PATTERN`。
1. 從預定義選項中選取圖案樣式。
1. 設定圖案的 [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/)。
1. 設定圖案的 [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/)。
1. 將已修改的簡報另存為 PPTX 檔案。

以下 Python 程式碼示範如何為矩形套用圖案填色：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個矩形類型的自動圖形。
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

![圖案填色的矩形](pattern-fill.png)

## **圖片填色**

在 PowerPoint 中，圖片填色是一種格式化選項，允許您在圖形內插入影像，實際上將影像作為圖形的背景。

以下說明如何使用 Aspose.Slides 為圖形套用圖片填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別的實例。
1. 透過索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 設為 `PICTURE`。
1. 將圖片填色模式設定為 `TILE`（或其他偏好模式）。
1. 從您想使用的影像建立 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 物件。
1. 將此影像指派給圖形的 `picture_fill_format` 中的 `picture.image` 屬性。
1. 將已修改的簡報另存為 PPTX 檔案。

假設我們有一個名為 **lotus.png** 的檔案，其內容如下：

![蓮花圖片](lotus.png)

以下 Python 程式碼示範如何使用圖片填滿圖形：

```python
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個矩形類型的自動圖形。
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

![圖片填色的圖形](picture-fill.png)

### **將圖片平鋪為紋理**

若要將平鋪圖片設為紋理並自訂平鋪行為，可使用 [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) 類別的以下屬性：

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/)：設定圖片填色模式，`TILE` 或 `STRETCH`。
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/)：指定平鋪在圖形內的對齊方式。
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/)：控制平鋪是否水平、垂直或同時翻轉。
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/)：設定平鋪在水平方向上的偏移（以點為單位），相對於圖形原點。
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/)：設定平鋪在垂直方向上的偏移（以點為單位），相對於圖形原點。
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/)：以百分比定義平鋪的水平縮放。
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/)：以百分比定義平鋪的垂直縮放。

以下程式碼範例示範如何新增一個帶有平鋪圖片填色的矩形圖形，並設定平鋪選項：

```py
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    first_slide = presentation.slides[0]

    # 新增一個矩形自動圖形。
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # 設定圖形的填色類型為圖片。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 載入影像並將其加入簡報資源。
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # 指派影像給圖形。
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

![平鋪選項](tile-options.png)

## **純色填色**

在 PowerPoint 中，純色填色是一種格式化選項，可將圖形填滿單一均勻的顏色。此背景顏色不含任何漸層、紋理或圖案。

要使用 Aspose.Slides 為圖形套用純色填色，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別的實例。
1. 透過索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 設為 `SOLID`。
1. 為圖形指定您偏好的填色。
1. 將已修改的簡報另存為 PPTX 檔案。

以下 Python 程式碼示範如何為 PowerPoint 投影片中的矩形套用純色填色：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個矩形類型的自動圖形。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 設定填色類型為純色。
    shape.fill_format.fill_type = slides.FillType.SOLID

    # 設定填充顏色。
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![純色填色的圖形](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您對圖形套用純色、漸層、圖片或紋理填色時，也可以設定透明度，以控制填色的不透明程度。較高的透明度值會使圖形更透，讓背景或底層物件部分可見。

Aspose.Slides 允許您透過調整填色顏色的 alpha 值來設定透明度。以下示範如何操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別的實例。
1. 透過索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 將填色類型設為 `SOLID`。
1. 使用 `Color.from_argb` 定義具有透明度的顏色（`alpha` 元件控制透明度）。
1. 儲存簡報。

以下 Python 程式碼示範如何為矩形套用透明填色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]
    
    # 新增一個實心矩形自動圖形。
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 在實心圖形上新增一個透明矩形自動圖形。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![透明圖形](shape-transparency.png)

## **旋轉圖形**

Aspose.Slides 允許您在 PowerPoint 簡報中旋轉圖形。這在需要特定對齊或設計需求的視覺元素佈局時非常有用。

要旋轉投影片上的圖形，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別的實例。
1. 透過索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 將圖形的 `rotation` 屬性設定為所需角度。
1. 儲存簡報。

以下 Python 程式碼示範如何將圖形旋轉 5 度：

```python
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個矩形類型的自動圖形。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 將圖形旋轉 5 度。
    shape.rotation = 5

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![圖形旋轉](shape-rotation.png)

## **新增 3D 磨邊效果**

Aspose.Slides 允許您透過設定其 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 屬性，為圖形套用 3D 磨邊效果。

要為圖形新增 3D 磨邊效果，請依照以下步驟：

1. 實例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別。
1. 透過索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 以定義磨邊設定。
1. 儲存簡報。

以下 Python 程式碼示範如何為圖形套用 3D 磨邊效果：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # 在投影片上新增圖形。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # 設定圖形的 ThreeDFormat 屬性。
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

![3D 磨邊效果](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

Aspose.Slides 允許您透過設定其 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 屬性，為圖形套用 3D 旋轉效果。

要為圖形套用 3D 旋轉：

1. 建立 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別的實例。
1. 透過索引取得投影片的參考。
1. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 設定圖形的 [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) 與 [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) 以定義 3D 旋轉。
1. 儲存簡報。

以下 Python 程式碼示範如何為圖形套用 3D 旋轉效果：

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

![3D 旋轉效果](3D-rotation-effect.png)

## **控制圖形的黑白算繪**

[Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) 屬性指定當簡報在黑白模式下檢視或處理時，單一圖形的算繪方式。它本身不會啟用黑白顯示，也不會在正常彩色模式下改變圖形的填色、線條或其他格式。

使用 [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) 列舉中的值來選擇所需的行為。例如，`AUTOMATIC` 讓算繪應用程式自行決定轉換方式，`GRAY` 與 `LIGHT_GRAY` 使用灰階，`BLACK_WHITE` 僅使用黑白，`BLACK` 與 `WHITE` 強制單一顏色，`COLOR` 保留正常顏色，`HIDDEN` 在黑白模式下隱藏圖形，`NOT_DEFINED` 表示未指派圖形層級模式。

以下 Python 程式碼建立一個彩色圖形，並在黑白顯示模式下使其呈現灰色：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # 在彩色模式下保留橙色填色，但在黑白模式下以灰階顯示圖形。
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

在正常彩色模式下，矩形保留橙色填色；在黑白顯示工作流程中，因模式設定為 `GRAY`，因此使用灰階顯示。這讓您在保留全彩投影片的同時，為列印、預覽或其他遵循簡報黑白顯示設定的工作流程定義不同的外觀。

## **重設格式**

以下 Python 程式碼示範如何重設投影片的格式，並將 [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) 上所有佔位符圖形的位置、大小與格式還原為預設設定：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # 重設投影片上具有版面佔位符的每個圖形。
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**形狀的格式化會影響最終簡報檔案大小嗎？**

影響極小。嵌入的影像與媒體佔用了大部分檔案空間，而形狀的參數（如顏色、效果與漸層）以中繼資料形式儲存，幾乎不會增加額外大小。

**如何偵測投影片上具有相同格式的圖形，以便將它們分組？**

比較每個圖形的關鍵格式屬性——填色、線條與效果設定。若所有對應值皆相同，則視為相同樣式，並在邏輯上將這些圖形分組，這樣可簡化後續的樣式管理。

**我可以將自訂的圖形樣式集合儲存為獨立檔案，以便在其他簡報中重複使用嗎？**

可以。將帶有所需樣式的範例圖形存放於模板投影片或 .POTX 模板檔案中。建立新簡報時，開啟該模板，複製所需的已樣式化圖形，並在需要的地方重新套用其格式。