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
- 3D 擠壓
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中套用與呈現 PowerPoint 形狀與文字的 3D 效果。設定相機、光源、材質、擠壓、填充與 3D 文字。"
---
## **概觀**

Aspose.Slides for Python via .NET 可以建立、編輯、保留並呈現 PowerPoint 風格的形狀與文字的 3D 格式設定。本文說明 3D 效果，例如旋轉、擠壓、倒角、光照、材質、漸層或圖片填充，以及 3D 文字。

{{% alert color="primary" %}}
本文說明的是 PowerPoint 形狀與文字的 3D 格式化效果，並非插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為影像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果呈現在匯出的 2D 輸出中。
{{% /alert %}}

## **3D 格式概念**

使用 [Shape.three_d_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/three_d_format/) 屬性將 3D 格式套用到形狀。此屬性會公開 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/)，其控制該形狀的 3D 場景。

對於文字，使用 [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/three_d_format/) 屬性。此屬性會將 3D 格式套用到文字框，而非形狀本體。

最重要的屬性包括：

| 屬性 | 控制項目 | 何時使用 |
|---|---|---|
| [camera](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/camera/) | 視點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件，或匹配 PowerPoint 的 3D 旋轉預設值。 |
| [light_rig](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/light_rig/) | 光源預設、方向與光線旋轉。 | 變更 3D 表面上的高光與陰影呈現方式。 |
| [material](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/material/) | 表面材質，如平面、霧面、塑膠或金屬。 | 使相同幾何形狀呈現更平坦、柔和、光亮或金屬感。 |
| [extrusion_height](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/extrusion_height/) | 形狀從正面向後延伸的距離。 | 將平面形狀轉變為可見的厚實 3D 物件。 |
| [extrusion_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/extrusion_color/) | 擠壓側面的顏色。 | 使深度可見，或讓側面顏色與正面填充協調。 |
| [depth](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/depth/) | PowerPoint 3D 格式所使用的額外 3D 深度。 | 微調形狀或文字的深度，特別是與倒角與材質設定結合時。 |
| [bevel_top](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/bevel_top/) 和 [bevel_bottom](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/bevel_bottom/) | 正面與背面上的凸起或圓角邊緣。 | 在平面上添加柔化或成型的邊緣，而非尖銳的平面。 |
| [contour_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/contour_color/) 和 [contour_width](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/contour_width/) | 3D 物件的輪廓線。 | 在渲染輸出中強調物件邊界。 |

## **建立 3D 形狀**

形狀在看起來逼真的 3D 之前，通常需要四種設定：

- 相機設定，因為預設的正面視角可能隱藏擠壓效果。  
- 光源設定，因為照明使表面和側面可辨識。  
- 材質設定，因為表面會影響光線的呈現方式。  
- 擠壓或深度設定，因為平面形狀需要厚度。  

以下範例建立一個矩形，於其正面加入文字，套用 3D 格式，將簡報儲存為 PPTX，並將投影片渲染為 PNG 影像。

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

渲染的投影片影像顯示矩形為一個厚實的 3D 方塊：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉形狀**

在 PowerPoint 中，3D 旋轉是從「3-D Rotation」窗格設定的。X、Y、Z 旋轉值對應於透過相機 API 所設定的旋轉。

![PowerPoint 3-D Rotation 窗格，突顯 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [ThreeDFormat.camera](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/camera/) 設定相機類型與旋轉：

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

當您需要變更觀眾觀看物件的角度時，使用相機。它不會改變投影片上 2D 形狀的幾何形狀，只會改變 PowerPoint 與 Aspose.Slides 在渲染時使用的 3D 視點。

## **加入擠壓與深度**

擠壓透過將形狀延伸至正面之後方，使其看起來更厚實。於 PowerPoint 中，深度控制設定此可見厚度，顏色控制則設定側面的顏色。

![PowerPoint 深度控制對應到擠壓顏色與擠壓高度屬性](img_02_02.png)

設定 [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/extrusion_height/) 以決定厚度，並設定 [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/extrusion_color/) 以指定側面顏色：

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

當您需要直接使用 PowerPoint 的深度值，或將深度與倒角、材質與文字效果結合時，使用 [ThreeDFormat.depth](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/depth/)。在許多形狀情境下，使用 [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/extrusion_height/) 更直觀，因為它直接表達可見的擠壓高度。

## **在 3D 效果中使用漸層或圖片填充**

3D 格式與形狀的填充互不影響。您可以為正面套用單色、漸層、圖案或圖片填充，同時使用相同的相機、光源、材質與擠壓設定。

以下範例為形狀套用漸層填充，並為側面使用較暗的擠壓顏色：

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

渲染的輸出保留正面的漸層，同時分別渲染擠壓側面：

![渲染的 3D 矩形，藍色到橙色漸層填充，橙色擠壓側面](img_02_03.png)

若改用圖片填充，將影像加入簡報並指派給形狀填充：

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

圖片會渲染於正面，而擠壓則作為 3D 側面表面渲染：

![渲染的 3D 矩形，正面使用照片填充，橙色擠壓側面](img_02_04.png)

## **將 3D 格式套用於文字**

形狀的 3D 格式影響形狀本體；文字的 3D 格式則影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要擠壓、材質、光照與相機設定。

以下範例建立帶圖案填充的文字，套用 WordArt 變形，並在 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/) 上配置 3D 設定：

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

文字會以彎曲、擠壓的 3D 立體字型呈現：

![渲染的 3D 文字，拱形 WordArt 變形，橙色圖案填充，深色擠壓側面](img_02_05.png)

## **匯出與呈現行為**

Aspose.Slides 在儲存為 PPTX 等 PowerPoint 格式時會保留 3D 格式。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製成 2D 結果。這適用於將投影片渲染為 [PNG](/slides/zh-hant/python-net/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/)，或產生用於 [video conversion](/slides/zh-hant/python-net/convert-powerpoint-to-video/) 的影格。

請留意以下要點：

- 匯出的影像與 PDF 並非互動式，匯出後觀眾無法旋轉物件。  
- 最終外觀取決於相機、光源、材質、擠壓、填充與投影片縮放的組合。  
- 若需要檢查繼承或主題式的格式值，請閱讀 [effective shape properties](/slides/zh-hant/python-net/shape-effective-properties/)。  
- 某些輸出格式無法存儲可編輯的 PowerPoint 3D 格式。在這些格式中，視覺結果會被渲染，而非保留為可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能建立互動式 3D 簡報嗎？**

Aspose.Slides 會建立與呈現 PowerPoint 形狀與文字的 3D 效果，但不會使匯出的影像、PDF 或 HTML 頁面成為觀眾可旋轉的互動式 3D 場景。在 PPTX 中，支援的情況下 3D 格式仍可於 PowerPoint 中編輯。

**3D 模型與 3D 效果有何差異？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 形狀或文字的格式，包含旋轉、擠壓、倒角、光照與材質等。本文僅討論 3D 效果。

**要顯示可見的 3D 形狀，需要哪些設定？**

最基本需要設定相機旋轉，並且使用擠壓或深度其中之一。實務上，還會設定光源與材質，以便讓渲染的面呈現清晰的高光與陰影。

**我能同時將 3D 效果套用於形狀與文字嗎？**

可以。對形狀本體使用 [Shape.three_d_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/three_d_format/)，對文字使用 [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/three_d_format/)。

**匯出為影像、PDF、HTML 或影片框格時，會顯示 3D 效果嗎？**

會。Aspose.Slides 在產生投影片影像、PDF、HTML 以及用於影片轉換的框格時，會將 3D 效果渲染成最終外觀，而不是保留可編輯的 3D 物件。

**在套用繼承與主題設定後，我能讀取最終的 3D 值嗎？**

可以。使用在 [Shape Effective Properties](/slides/zh-hant/python-net/shape-effective-properties/) 中描述的有效格式化 API，即可讀取最終的相機、光源、倒角與其他相關 3D 值。