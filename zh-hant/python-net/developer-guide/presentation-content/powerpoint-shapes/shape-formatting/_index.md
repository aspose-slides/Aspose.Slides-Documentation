---
title: 在 Python 中格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/python-net/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 格式化接合樣式
- 漸層填色
- 圖案填色
- 圖片填色
- 紋理填色
- 實色填色
- 形狀透明度
- 旋轉形狀
- 3D 倒角效果
- 3D 旋轉效果
- 重置格式
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "學習如何在 Python 中使用 Aspose.Slides 格式化 PowerPoint 形狀——精確且完全控制地為 PPT、PPTX 和 ODP 檔案設定填色、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以在投影片上加入形狀。由於形狀是由線條構成，您可以透過修改或套用外框效果來格式化它們。另外，您也可以透過設定控制內部填充方式來格式化形狀。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python 提供了類別和屬性，讓您能使用 PowerPoint 中相同的選項來格式化形狀。

## **格式化線條**

使用 Aspose.Slides，您可以為形狀指定自訂的線條樣式。以下步驟說明了操作程序：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 向該投影片加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 設定形狀的 [line style](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/linestyle/)。
1. 設定線條寬度。
1. 設定形狀的 [dash style](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/linedashstyle/)。
1. 設定形狀的線條顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 Python 程式碼示範如何格式化矩形 `AutoShape`：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個類型為矩形的自動形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # 設定矩形形狀的填色。
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # 套用矩形線條的格式化。
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

## **格式化接合樣式**

以下是三種接合類型選項：

* 圓角
* 斜接
* 斜面

預設情況下，PowerPoint 在以角度連接兩條線（例如形狀的角落）時，使用 **圓角** 設定。然而，如果您要繪製具有尖銳角度的形狀，可能會較偏好 **斜接** 選項。

![The join style in the presentation](join-style-powerpoint.png)

以下 Python 程式碼示範如何使用斜接、斜面與圓角接合類型建立三個矩形（如上圖所示）：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

	# 取得第一張投影片。
	slide = presentation.slides[0]

	# 新增三個類型為矩形的自動形狀。
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# 為每個矩形形狀設定填色。
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

	# 為每個矩形的線條設定顏色。
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

在 PowerPoint 中，漸層填色是一種格式化選項，可讓您將連續的顏色混合套用至形狀。例如，您可以以兩種或多種顏色逐漸過渡的方式填滿形狀。

以下說明如何使用 Aspose.Slides 為形狀套用漸層填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 向該投影片加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/) 設為 `GRADIENT`。
1. 使用由 [GradientFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/gradientformat/) 類別公開的 `gradient_stops` 集合的 `add` 方法，依指定位置新增兩種偏好的顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 Python 程式碼示範如何為橢圓套用漸層填色效果：

```python
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個類型為橢圓的自動形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # 為橢圓套用漸層格式化。
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # 設定漸層的方向。
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

在 PowerPoint 中，圖案填色是一種格式化選項，可讓您以兩種顏色的圖樣（例如點、條紋、交叉或格子）套用至形狀。您可以為圖案的前景色與背景色自訂顏色。

Aspose.Slides 提供超過 45 種預定義圖案樣式，您可以將其套用至形狀以提升簡報的視覺效果。即使選取了預定義圖案，仍可自行指定其確切使用的顏色。

以下說明如何使用 Aspose.Slides 為形狀套用圖案填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 向該投影片加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/) 設為 `PATTERN`。
1. 從預定義選項中選取圖案樣式。
1. 設定圖案的 [back_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/patternformat/back_color/)。
1. 設定圖案的 [fore_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/patternformat/fore_color/)。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 Python 程式碼示範如何為矩形套用圖案填色：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個類型為矩形的自動形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 設定填充類型為圖案。
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

在 PowerPoint 中，圖片填色是一種格式化選項，可讓您將影像插入形狀內部——實質上將影像作為形狀的背景。

以下說明如何使用 Aspose.Slides 為形狀套用圖片填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 向該投影片加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/) 設為 `PICTURE`。
1. 將圖片填色模式設定為 `TILE`（或其他偏好的模式）。
1. 從欲使用的影像建立 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 物件。
1. 將此影像指派給形狀的 `picture_fill_format` 中的 `picture.image` 屬性。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下為「lotus.png」檔案的示意圖：

![The lotus picture](lotus.png)

以下 Python 程式碼示範如何以圖片填滿形狀：

```python
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個類型為矩形的自動形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # 設定填充類型為圖片。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 設定圖片填充模式。
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

如果您想將平鋪的圖片作為紋理並自訂平鋪行為，可使用 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/) 類別的以下屬性：

- [picture_fill_mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/picture_fill_mode/)：設定圖片填色模式—`TILE` 或 `STRETCH`。
- [tile_alignment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/tile_alignment/)：指定平鋪在形狀內的對齊方式。
- [tile_flip](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/tile_flip/)：控制平鋪是否水平、垂直或同時翻轉。
- [tile_offset_x](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/tile_offset_x/)：設定平鋪相對於形狀原點的水平偏移（點）。
- [tile_offset_y](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/tile_offset_y/)：設定平鋪相對於形狀原點的垂直偏移（點）。
- [tile_scale_x](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/tile_scale_x/)：以百分比定義平鋪的水平比例。
- [tile_scale_y](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/tile_scale_y/)：以百分比定義平鋪的垂直比例。

以下程式碼範例展示如何加入一個具有平鋪圖片填色的矩形，並設定平鋪選項：

```py
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    first_slide = presentation.slides[0]

    # 新增一個矩形自動形狀。
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # 將形狀的填充類型設為圖片。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 載入影像並將其加入簡報資源。
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # 將影像指派給形狀。
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # 設定圖片填充模式與平鋪屬性。
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

## **實色填色**

在 PowerPoint 中，實色填色是一種格式化選項，可將形狀填滿單一、均勻的顏色。此純色背景不包含任何漸層、紋理或圖案。

若要使用 Aspose.Slides 為形狀套用實色填色，請依照下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 向該投影片加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/) 設為 `SOLID`。
1. 指定您偏好的填色顏色給形狀。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 Python 程式碼示範如何在 PowerPoint 投影片的矩形上套用實色填色：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個類型為矩形的自動形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 設定填充類型為實色。
    shape.fill_format.fill_type = slides.FillType.SOLID

    # 設定填充顏色。
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![The shape with solid color fill](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您對形狀套用實色、漸層、圖片或紋理填色時，也可以設定透明度，以控制填色的不透明程度。較高的透明度值會使形狀更透，讓背景或底層物件部分可見。

Aspose.Slides 允許您透過調整填色顏色的 alpha 值來設定透明度。操作步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 向該投影片加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 將填色類型設為 `SOLID`。
1. 使用 `Color.from_argb` 定義帶有透明度的顏色（`alpha` 元素控制透明度）。
1. 儲存簡報。

以下 Python 程式碼示範如何為矩形套用透明填色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]
    
    # 新增一個實色矩形自動形狀。
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 在實色形狀上方加入一個透明矩形自動形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![The transparent shape](shape-transparency.png)

## **旋轉形狀**

Aspose.Slides 讓您可以在 PowerPoint 簡報中旋轉形狀。這在需要特定對齊或設計需求時相當實用。

若要在投影片上旋轉形狀，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 向該投影片加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 將形狀的 `rotation` 屬性設定為目標角度。
1. 儲存簡報。

以下 Python 程式碼示範如何將形狀旋轉 5 度：

```python
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個類型為矩形的自動形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 將形狀旋轉 5 度。
    shape.rotation = 5

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![The shape rotation](shape-rotation.png)

## **新增 3D 倒角效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/) 屬性，為形狀套用 3D 倒角效果。

若要為形狀新增 3D 倒角效果，請依照以下步驟：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別。
1. 依索引取得投影片參考。
1. 向該投影片加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/) 以定義倒角設定。
1. 儲存簡報。

以下 Python 程式碼展示如何為形狀套用 3D 倒角效果：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # 在投影片上加入形狀。
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

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/) 屬性，為形狀套用 3D 旋轉效果。

若要為形狀套用 3D 旋轉：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片參考。
1. 向該投影片加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。
1. 設定形狀的 [camera_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/camera/camera_type/) 與 [light_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/lightrig/light_type/) 以定義 3D 旋轉。
1. 儲存簡報。

以下 Python 程式碼示範如何為形狀套用 3D 旋轉效果：

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

## **重置格式**

以下 Python 程式碼示範如何重置投影片的格式，並將所有在 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/) 上具有版位與格式的占位形狀，恢復為預設設定：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # 重置投影片上在版面配置中有占位符的每個形狀。
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**形狀格式化會影響最終簡報檔案大小嗎？**

影響極小。嵌入的影像與多媒體檔案佔用大部分空間，而形狀的參數（如顏色、效果與漸層）僅以中繼資料儲存，幾乎不會增加額外容量。

**如何偵測投影片上具相同格式的形狀以便將它們分組？**

比較每個形狀的關鍵格式屬性——填色、線條與效果設定。若所有對應值皆相同，即可視為樣式相同，並在邏輯上將這些形狀分組，這樣可簡化之後的樣式管理。

**我可以將自訂的形狀樣式集合儲存為獨立檔案，以便在其他簡報中重複使用嗎？**

可以。將帶有所需樣式的範本形狀存於範本投影片或 .POTX 範本檔案中。建立新簡報時，開啟該範本，複製所需的樣式形狀，並在需要的地方重新套用其格式。