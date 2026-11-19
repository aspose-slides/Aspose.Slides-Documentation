---
title: 使用 Python 在簡報中建立 3D 效果
linktitle: 3D 簡報
type: docs
weight: 232
url: /zh-hant/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 簡報
- 3D 旋轉
- 3D 深度
- 3D 擠出
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 套用並呈現 PowerPoint 圖形與文字的 3D 效果。設定相機、光照、材質、擠出、填色以及 3D 文字。"
---
## **概觀**

Aspose.Slides for Python via .NET 可以建立、編輯、保留並呈現 PowerPoint 風格的 3D 格式設定，適用於圖形與文字。本篇文章探討 3D 效果，例如旋轉、擠出、斜角、光照、材質、漸層或圖片填色，以及 3D 文字。

{{% alert color="info" title="Note" %}}
本文說明 PowerPoint 圖形與文字的 3D 格式效果。它不涉及插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為影像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染成匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式概念**

使用 [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) 屬性將 3D 格式套用至圖形。此屬性會公開 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/)，用來控制該圖形的 3D 場景。

對於文字，使用 [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) 屬性。此屬性會將 3D 格式套用至文字框，而非圖形本體。

最重要的屬性如下：

| 屬性 | 控制項目 | 何時使用 |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件，或對應 PowerPoint 的 3D 旋轉預設值。 |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | 光源預設、方向與光線旋轉。 | 變更 3D 表面的高光與陰影呈現方式。 |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | 表面材質，如平面、霧面、塑膠或金屬。 | 讓相同幾何形狀呈現較平坦、較柔和、光亮或金屬感。 |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | 圖形從前表面向後延伸的距離。 | 將平面圖形變成可見的厚實 3D 物件。 |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | 擠出側面的顏色。 | 讓深度可見，或將側面顏色與前景填色協調。 |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | PowerPoint 3D 格式使用的額外 3D 深度。 | 微調圖形或文字的深度，特別是與斜角與材質設定結合時。 |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) and [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | 前後表面的凸起或圓角邊緣。 | 加入柔化或成型的邊緣，取代尖銳平坦的表面。 |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) and [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | 3D 物件的外框輪廓。 | 在渲染輸出中強調物件邊界。 |

## **建立 3D 圖形**

圖形在看起來逼真 3D 之前，通常需要四種設定：

- 相機設定，因為預設的正面視圖可能會隱藏擠出效果。
- 光源設定，因為光照讓各個面與側面更易辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠出或深度設定，因為平面圖形需要厚度。

以下範例建立一個矩形，於其前表面加入文字，並套用 3D 格式。相機旋轉值以度為單位，擠出高度為 100 點。此範例將投影片以兩倍預設尺寸渲染為 PNG 圖像，並將簡報儲存為 PPTX。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

渲染的投影片圖像顯示矩形為厚實的 3D 塊狀：

![已渲染的藍色 3D 矩形，前表面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉是從「3‑D 旋轉」面板設定。X、Y、Z 旋轉值對應於透過相機 API 設定的旋轉。

![PowerPoint 3‑D 旋轉面板，突顯 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) 取得相機。此範例建立一個矩形，選擇正交正面視圖，並分別將其 X、Y、Z 旋轉設定為 20、30、40 度。它在記憶體中配置圖形，未儲存檔案：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

在需要變更觀者觀看物件方式時使用相機。它不會變更投影片上 2D 圖形的幾何形狀，而是變更 PowerPoint 與 Aspose.Slides 在渲染時使用的 3D 觀點。

### **從範本圖形複製相機方向**

若要匹配範本圖形的方向，複製其 [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) 預設值，並使用 [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/) 讀取其旋轉。此範例開啟 `template.pptx`，將第一張投影片上第一個圖形的相機方向複製到第二個圖形。兩個圖形皆已具備 3D 光源，而第二個圖形沒有明確的相機旋轉設定。

角度以度為單位。索引 `0`、`1`、`2` 分別代表緯度、經度與旋轉。依此順序傳遞給 [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/)。若來源沒有明確的旋轉，`get_rotation` 會回傳 `None`，因此目標角度保持未設定。若來源明確將三個角度皆設為 0，則複製這些 0。

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

當您在 PowerPoint 中重新開啟 `camera-copy.pptx`，兩個圖形皆具有相同的相機預設與旋轉。右側的箭頭使用左側矩形複製的方向。兩個圖形使用相同的光源與擠出深度。

![一個藍色 3D 矩形與一個相同相機方向的右箭頭，從上方及右側觀察](camera-orientation.png)

## **加入擠出與深度**

擠出透過將圖形延伸至前表面後方，使其看起來較厚。於 PowerPoint 中，深度控制設定此可見厚度，而顏色控制則設定側面的顏色。

![PowerPoint 深度控制對應至擠出顏色與擠出高度屬性](img_02_02.png)

設定 [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) 以調整厚度，設定 [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) 以設定側面顏色。此範例為矩形設定 100 點的擠出，側面為紫色，並旋轉相機以顯示其厚度。它在記憶體中配置圖形，未儲存檔案：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

[ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) 屬性設定 3D 圖形的深度。[extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) 屬性控制擠出效果的高度，如此範例所示。

## **在 3D 效果中使用漸層或圖片填色**

3D 格式獨立於圖形的填色。您可以對前表面套用單色、漸層、圖案或圖片填色，同時仍使用相同的相機、光源、材質與擠出設定。

此範例對前表面套用藍至橙的漸層，對 150 點的擠出使用深橙色。漸層在 0 與 100 處作為起始與結束點。相機旋轉值以度為單位。投影片以兩倍預設尺寸渲染為 PNG 圖像：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

![已渲染的 3D 矩形，藍至橙漸層填色與橙色擠出](img_02_03.png)

若改用圖片填色，先將圖片加入簡報並指定給圖形填色。此範例需要工作目錄中已存在名為 "image.jpg" 的檔案。它將圖片拉伸填滿矩形，套用 150 點的擠出，並以度為單位設定相機旋轉。它在記憶體中配置圖形，未儲存或渲染檔案：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

![已渲染的 3D 矩形，前表面為照片填色，側面為橙色擠出](img_02_04.png)

## **將 3D 格式套用至文字**

圖形的 3D 格式影響圖形本體。文字的 3D 格式則影響文字框。這在類似 WordArt 的效果中很有用，因為字母本身需要擠出、材質、光照與相機設定。

以下範例建立帶有橙白格線圖案的文字，套用向上拱形，並透過 [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) 設定 3D 參數。擠出高度與深度以點為單位，光線旋轉以度為單位。圖形填色與輪廓被隱藏，僅顯示文字。此範例以兩倍預設投影片尺寸渲染 PNG 圖像，並將簡報儲存為 PPTX：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

![已渲染的 3D 文字，拱形 WordArt 變形，橙色圖案填色，深色擠出](img_02_05.png)

## **在 3D 圖形上保持文字平面**

為了在保持圖形 3D 外觀的同時使文字易於閱讀，請透過 [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/) 設定 [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/)。當值為 `True` 時，文字不會進入 3D 場景；當值為 `False` 時，文字會參與場景並遵循其 3D 方向。

此設定不會移除圖形的 3D 格式：其相機、光源、材質與擠出仍透過 [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) 設定。它亦不同於一般旋轉。[Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) 會在投影片平面中旋轉圖形，而 [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) 控制文字在其邊框內的自訂旋轉。將文字排除於 3D 場景外不會重設這兩個角度。

以下獨立範例建立一個藍色矩形文字，並在原圖旁邊複製一份。兩個圖形具有相同的 3D 格式；唯一不同的是文字設定：左側為 `False`，右側為 `True`。相機角度以度為單位，擠出高度為 40 點。此範例將簡報儲存為 PPTX，並以兩倍預設尺寸渲染比較投影片為 PNG。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

![並排的 3D 矩形：左側 keep_text_flat 為 False，右側為 True](keep_text_flat.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PPTX 等 PowerPoint 格式時會保留 3D 格式。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製成 2D 結果。這在您將投影片渲染為 [PNG](/slides/zh-hant/python-net/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/)，或產生用於 [影片轉換](/slides/zh-hant/python-net/convert-powerpoint-to-video/) 的影格時皆適用。

- 匯出的影像和 PDF 不是互動式的。匯出後，觀者無法旋轉物件。
- 最終外觀取決於相機、光源、材質、擠出、填色與投影片縮放的組合。
- 若需檢查繼承或主題基礎的格式值，請閱讀 [有效的圖形屬性](/slides/zh-hant/python-net/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式。在這些格式中，視覺結果會被渲染，而非保留為可編輯的 3D 設定。

## **FAQ**

**Aspose.Slides 能否建立互動式 3D 簡報？**

Aspose.Slides 會建立並渲染圖形與文字的 PowerPoint 3D 效果。它不會使匯出的影像、PDF 或 HTML 頁面成為觀者可旋轉的互動式 3D 場景。於 PPTX 中，只要格式支援，3D 格式仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何差異？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 圖形或文字的格式設定，如旋轉、擠出、斜角、光照與材質。本篇文章僅討論 3D 效果。

**顯示 3D 圖形需要哪些設定？**

最低需設定相機旋轉以及擠出或深度。實務上，還需設定光源與材質，以便渲染出的面具備明顯的高光與陰影。

**我能將 3D 效果套用到圖形與文字嗎？**

可以。對圖形本體使用 [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/)，對文字使用 [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/)。

**匯出為影像、PDF、HTML 或影片影格時，會顯示 3D 效果嗎？**

會。Aspose.Slides 會在產生投影片影像、PDF 輸出、HTML 輸出以及用於影片轉換的影格時渲染 3D 效果。匯出的結果僅包含已渲染的外觀，而非可編輯的 3D 物件。

**在套用繼承與主題設定後，我能讀取最終的 3D 參數嗎？**

可以。使用在 [有效的圖形屬性](/slides/zh-hant/python-net/shape-effective-properties/) 中描述的有效格式化 API，即可讀取最終的相機、光源、斜角與相關 3D 參數。