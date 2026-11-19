---
title: 使用 Python 在簡報中建立 3D 效果
linktitle: 3D 簡報
type: docs
weight: 232
url: /zh-hant/python-java/3d-presentation/
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
- Java
- Aspose.Slides
description: "在 Python（透過 Java）使用 Aspose.Slides 為 PowerPoint 圖形和文字套用並渲染 3D 效果。設定相機、光照、材質、擠壓、填色與 3D 文字。"
---
## **概觀**

Aspose.Slides for Python via Java 可以建立、編輯、保留和呈現 PowerPoint 風格的 3D 格式設定，適用於圖形和文字。本篇文章涵蓋 3D 效果，如旋轉、擠壓、斜角、光照、材質、漸層或圖案填色，以及 3D 文字。

{{% alert color="info" title="Note" %}}
本篇文章說明在 PowerPoint 圖形和文字上使用 3D 格式設定的效果。它不涉及插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為圖像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染成匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式設定概念**

使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) 方法將 3D 格式設定套用至圖形。此方法會傳回 [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/)，用來控制該圖形的 3D 場景。

對於文字，請使用 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) 方法。此方法會將 3D 格式設定套用到文字框，而非圖形本體。

最重要的 API 成員如下：

| API 成員 | 它控制什麼 | 何時使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | 視點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件或匹配 PowerPoint 的 3D 旋轉預設。 |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | 光線預設、方向與光線旋轉。 | 更改 3D 表面的高光與陰影呈現方式。 |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) 和 [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | 表面材質，例如平面、啞光、塑膠或金屬。 | 讓相同的幾何形狀看起來更平坦、柔和、光亮或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) 和 [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | 圖形從正面向後延伸的距離。 | 將平面圖形變成可見的厚實 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | 擠壓側面的顏色。 | 讓深度可見，或使側面顏色與正面填充協調。 |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) 和 [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 格式設定使用的額外深度。 | 為圖形或文字微調深度，特別是與斜角與材質設定一起使用時。 |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) 和 [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | 正面與背面的凸起或圓角邊緣。 | 在平直的面上加入柔化或模塑的邊緣，而非銳利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) 和 [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) 和 [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | 3D 物件的輪廓線。 | 在渲染輸出中強調物件的邊界。 |

## **建立 3D 圖形**

通常圖形在呈現逼真的 3D 效果之前，需要四種設定：

- 相機設定，因為預設的正視圖可能會隱藏擠壓效果。
- 光線設定，因為光照讓各面與側面可辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠壓或深度設定，因為平面圖形需要厚度。

以下範例建立一個矩形，於其正面加入文字，並套用 3D 格式設定。相機旋轉值以度為單位，擠壓高度為 100 點。範例將投影片渲染為 PNG 圖像，尺寸為預設的兩倍，並將簡報儲存為 PPTX。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

渲染出的投影片圖像顯示矩形為一個厚實的 3D 方塊：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉是透過「3-D 旋轉」面板設定。X、Y、Z 旋轉值對應於您透過相機 API 所設定的旋轉。

![PowerPoint 3-D 旋轉面板，標示 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) 取得相機。此範例建立一個矩形，選擇正交前視圖，並分別將 X、Y、Z 旋轉設定為 20、30、40 度。它在記憶體中配置圖形，未儲存檔案：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

當需要變更觀察者觀看物件的方式時，請使用相機。它不會改變投影片上 2D 圖形的幾何形狀，而是改變 PowerPoint 與 Aspose.Slides 在渲染時使用的 3D 視點。

### **從範本圖形複製相機方向**

為匹配範本圖形的方向，請使用 [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) 讀取其相機預設，並使用 [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation) 取得旋轉角度。此範例開啟 `template.pptx`，將第一張投影片第一個圖形的相機方向複製到第二個圖形。兩個圖形皆已有 3D 燈光，且第二個圖形沒有明確的相機旋轉設定。

角度以度為單位。索引 `0` 為緯度，`1` 為經度，`2` 為旋轉。依此順序傳遞給 [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation)。如果來源回傳 `None`，表示沒有明確的旋轉，則保持第二個圖形的角度未設定。明確的旋轉 `(0, 0, 0)` 會回傳三個零，應予以複製。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

當您在 PowerPoint 中重新開啟 `camera-copy.pptx` 時，右側的箭頭與左側的矩形擁有相同的相機預設與旋轉。兩個圖形使用相同的光線與擠壓深度。

![一個藍色 3D 矩形與一個向右的箭頭，相機方向匹配，從上方右側觀看](camera-orientation.png)

## **加入擠壓與深度**

擠壓透過將圖形延伸至正面之後，使其看起來更厚。在 PowerPoint 中，深度控制設定此可見的厚度，而顏色控制設定側面的顏色。

![PowerPoint 深度控制對應至擠壓顏色與擠壓高度屬性](img_02_02.png)

使用 [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) 方法設定厚度，並使用 [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) 取得側面顏色。此範例給矩形 100 點的擠壓，側面為紫色，並旋轉相機以顯示其厚度。它在記憶體中配置圖形，未儲存檔案：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) 方法設定 3D 圖形的深度。[setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) 方法控制擠壓效果的高度，如本範例所示。

## **在 3D 效果中使用漸層或圖片填色**

3D 格式設定與圖形填色互不影響。您可以對正面套用純色、漸層、圖案或圖片填色，同時仍使用相同的相機、光線、材質與擠壓設定。

此範例對正面套用藍到橙的漸層，並將 150 點的擠壓側面設定為深橙色。漸層停點在 0 與 100 處分別標示起始與結束。相機旋轉值以度為單位。投影片被渲染為 PNG 圖像，尺寸為預設的兩倍：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

渲染的 3D 矩形，藍至橙的漸層填色與橙色擠壓：

![渲染的 3D 矩形，藍至橙的漸層填色與橙色擠壓](img_02_03.png)

若要改用圖片填色，請先將圖片加入簡報並指派給圖形填色。此範例需要工作目錄中已有名為 "image.jpg" 的檔案。它將圖片拉伸以填滿矩形，套用 150 點的擠壓，並以度為單位設定相機旋轉。它在記憶體中配置圖形，未儲存或渲染檔案：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

渲染的 3D 矩形，正面使用照片填色，橙色擠壓：

![渲染的 3D 矩形，正面使用照片填色，橙色擠壓](img_02_04.png)

## **將 3D 格式套用至文字**

圖形的 3D 格式影響圖形本體。文字的 3D 格式影響文字框。這在類似 WordArt 的效果中很有用，因為字母本身需要擠壓、材質、光照與相機設定。

以下範例建立文字，套用橙白格線圖案，加入向上拱形，並透過 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) 設定 3D。擠壓高度與深度以點為單位，光線旋轉以度為單位。圖形填色與輪廓被隱藏，僅顯示文字。範例將 PNG 圖像渲染為預設投影片尺寸的兩倍，並將簡報儲存為 PPTX：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

渲染的 3D 文字，帶有拱形 WordArt 變形、橙色圖案填色與深色擠壓：

![渲染的 3D 文字，帶有拱形 WordArt 變形、橙色圖案填色與深色擠壓](img_02_05.png)

## **在 3D 圖形上保持文字平面**

為了在保留圖形 3D 外觀的同時保持文字可讀，請透過 [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat) 呼叫 [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat)。當值為 `True` 時，文字保持在 3D 場景之外；當值為 `False` 時，文字會參與 3D 場景並遵循其 3D 方向。

此設定不會移除圖形的 3D 格式：其相機、光線、材質與擠壓仍透過 [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) 設定。它也不同於普通旋轉。[Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) 旋轉圖形於投影片平面，而 [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) 控制文字在其邊框內的自訂旋轉。將文字保持在 3D 場景之外不會重設上述任一角度。

以下自行封閉的範例建立一個藍色矩形，內含文字，並在原始圖形旁邊複製一次。兩個圖形都有相同的 3D 格式；唯一不同的是文字設定：左側為 `False`，右側為 `True`。相機角度以度為單位，擠壓高度為 40 點。範例將簡報儲存為 PPTX，並將比較投影片渲染為 PNG，尺寸為預設的兩倍。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

左側文字遵循 3D 方向，右側文字保持平面且較易閱讀。兩個矩形保留相同的可見擠壓與 3D 方向。

![並排的 3D 矩形：左側文字遵循 3D 方向，右側文字保持平面](keep_text_flat.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PPTX 等 PowerPoint 格式時會保留 3D 格式設定。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製成 2D 結果。這適用於將投影片渲染為 [PNG](/slides/zh-hant/python-java/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/python-java/convert-powerpoint-to-html/)，或產生 [video conversion](/slides/zh-hant/python-java/convert-powerpoint-to-video/) 的影格。

請留意以下要點：

- 匯出的圖像與 PDF 並非互動式。匯出後物件無法由檢視者旋轉。
- 最終外觀取決於相機、光線裝置、材質、擠壓、填色與投影片縮放的組合。
- 若需檢查繼承或佈景主題的格式值，請讀取[有效形狀屬性](/slides/zh-hant/python-java/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式設定。在這些格式中，視覺結果會被渲染，而非保留為可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能建立互動式 3D 簡報嗎？**

Aspose.Slides 會建立並渲染 PowerPoint 3D 效果，適用於圖形與文字。它不會使匯出的圖像、PDF 或 HTML 頁面變成可由檢視者旋轉的互動式 3D 場景。在 PPTX 中，3D 格式仍可在支援的 PowerPoint 版本中編輯。

**3D 模型與 3D 效果有何差異？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果是套用於一般 PowerPoint 圖形或文字的格式設定，如旋轉、擠壓、斜角、光照與材質。本篇文章僅討論 3D 效果。

**要產生可見的 3D 圖形，需要哪些設定？**

最低限度必須設定相機旋轉，並設定擠壓或深度。實務上通常也會設定光線裝置與材質，以確保渲染出的面具有清晰的高光與陰影。

**我可以同時將 3D 效果套用於圖形與文字嗎？**

可以。對圖形本體使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat)，對文字使用 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat)。

**匯出為圖像、PDF、HTML 或影片框格時，3D 效果會顯示嗎？**

會。Aspose.Slides 會在產生投影片圖像、PDF 輸出、HTML 輸出以及影片轉換的框格時渲染 3D 效果。匯出的結果包含已渲染的外觀，而非可編輯的 3D 物件。

**在套用繼承與佈景主題設定後，我能讀取最終的 3D 值嗎？**

能。請使用 [有效形狀屬性](/slides/zh-hant/python-java/shape-effective-properties/) 中描述的有效格式 API，讀取最終的相機、光線裝置、斜角與相關 3D 值。