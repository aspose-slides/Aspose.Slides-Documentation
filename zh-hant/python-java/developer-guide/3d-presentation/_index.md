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
- 3D 擠出
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Python（透過 Java）使用 Aspose.Slides 套用並渲染 PowerPoint 形狀與文字的 3D 效果。設定相機、光照、材質、擠出、填充與 3D 文字。"
---
## **概述**

Aspose.Slides for Python via Java 可以建立、編輯、保留並呈現 PowerPoint 風格的 3D 格式設定，適用於形狀與文字。本篇文章涵蓋旋轉、擠出、斜角、光照、材質、漸層或圖片填充，以及 3D 文字等 3D 效果。

{{% alert color="info" title="Note" %}}
本篇文章針對 PowerPoint 形狀與文字的 3D 格式設定效果。它不涉及插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為圖片、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果轉換為匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式設定概念**

使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getThreeDFormat) 方法可為形狀套用 3D 格式設定。此方法會傳回 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/)，用來控制該形狀的 3D 場景。

對於文字，使用 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#getThreeDFormat) 方法。此方法會將 3D 格式設定套用於文字框，而非形狀本體。

最重要的 API 成員如下：

| API 成員 | 作用說明 | 使用時機 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getCamera) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件或符合 PowerPoint 的 3D 旋轉預設。 |
| [getLightRig](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getLightRig) | 光源預設、方向與光線旋轉。 | 變更 3D 表面上亮部與陰影的呈現方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getMaterial) 和 [setMaterial](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setMaterial) | 表面材質，如平面、啞光、塑膠或金屬。 | 讓相同的幾何形狀呈現較平坦、柔和、光亮或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getExtrusionHeight) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setExtrusionHeight) | 形狀從正面向後延伸的距離。 | 將平面形狀變為可見的厚實 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getExtrusionColor) | 擠出側面的顏色。 | 顯示深度或使側色與正面填充協調。 |
| [getDepth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getDepth) 和 [setDepth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 格式所使用的額外深度。 | 微調形狀或文字的深度，特別是與斜角與材質設定結合使用。 |
| [getBevelTop](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getBevelTop) 和 [getBevelBottom](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getBevelBottom) | 正、背面之提升或圓角邊緣。 | 加入柔化或成型的邊緣，取代銳利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getContourColor) 和 [getContourWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getContourWidth) 和 [setContourWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setContourWidth) | 圍繞 3D 物件的輪廓。 | 在渲染輸出中突顯物件邊界。 |

## **建立 3D 形狀**

形狀在看起來具說服力的 3D 前，通常需要四種設定：

- 相機設定，因為預設的正面視角可能隱藏擠出效果。
- 光源設定，因為光線讓各面與側面可辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠出或深度設定，因為平面形狀需要厚度。

以下範例建立一個矩形、在其正面加入文字，並套用 3D 格式設定。相機旋轉值以度為單位，擠出高度為 100 點。範例將投影片渲染為 PNG 圖片（兩倍預設尺寸），並將簡報儲存為 PPTX。

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

渲染後的投影片圖像顯示矩形為一個厚實的 3D 方塊：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉形狀**

在 PowerPoint 中，3D 旋轉是從「3‑D 旋轉」窗格設定的。X、Y、Z 旋轉值對應於透過相機 API 設定的旋轉。

![PowerPoint 3‑D 旋轉窗格，突顯 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [ThreeDFormat.getCamera](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getCamera) 存取相機。此範例建立一個矩形、選擇正交前視圖，並分別將 X、Y、Z 旋轉設定為 20°、30°、40°。它在記憶體中配置形狀，未儲存檔案：

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

當您需要變更觀者看到物件的方式時，使用相機。它不會改變投影片上 2D 形狀的幾何形狀，只會改變 PowerPoint 與 Aspose.Slides 在渲染時使用的 3D 觀點。

## **新增擠出與深度**

擠出透過在正面之後延伸形狀，使其看起來更厚。於 PowerPoint 中，深度控制設定此可見厚度，顏色控制則設定側面的顏色。

![PowerPoint 深度控制對應到擠出顏色與擠出高度屬性](img_02_02.png)

使用 [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setExtrusionHeight) 設定厚度，並使用 [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getExtrusionColor) 取得側面顏色。此範例為矩形設定 100 點的擠出，側面為紫色，並旋轉相機以顯示其厚度。它在記憶體中配置形狀，未儲存檔案：

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

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setDepth) 方法設定 3D 形狀的深度。[setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setExtrusionHeight) 方法控制擠出效果的高度，如本範例所示。

## **在 3D 效果中使用漸層或圖片填充**

3D 格式設定與形狀填充互不相干。您可以對正面套用純色、漸層、圖樣或圖片填充，並同時使用相同的相機、光源、材質與擠出設定。

此範例將藍到橙的漸層套用於正面，並將深橙色套用於 150 點的擠出。漸層停止點 0 與 100 標示漸層的起始與結束。相機旋轉值以度為單位。投影片以兩倍預設尺寸渲染為 PNG 圖片：

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

渲染的輸出保留正面的漸層，同時分別渲染擠出側面：

![渲染的 3D 矩形，藍到橙的漸層填充與橙色擠出](img_02_03.png)

若改用圖片填充，先將影像加入簡報並指派給形狀填充。此範例需在工作目錄中已有名為 "image.jpg" 的檔案。它會將圖片伸展以填滿矩形、套用 150 點擠出，並以度為單位設定相機旋轉。它在記憶體中配置形狀，未儲存或渲染檔案：

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

圖片在正面渲染，擠出則作為 3D 側面渲染：

![渲染的 3D 矩形，正面使用照片填充並附有橙色擠出](img_02_04.png)

## **將 3D 格式套用於文字**

形狀的 3D 格式影響形狀本體。文字的 3D 格式則影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要擠出、材質、光照與相機設定。

以下範例建立具有橙白格線圖樣的文字，套用向上拱形，並透過 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#getThreeDFormat) 設定 3D 參數。擠出高度與深度以點為單位，光源旋轉以度為單位。形狀填充與輪廓被隱藏，僅顯示文字。範例以兩倍預設投影片尺寸渲染 PNG 圖片，並將簡報儲存為 PPTX：

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

文字以拱形、擠出的 3D 形式呈現：

![渲染的 3D 文字，拱形 WordArt 變形、橙色圖樣填充與深色擠出](img_02_05.png)

## **在 3D 形狀上保持文字平面**

若要在保留形狀 3D 外觀的同時讓文字保持可讀，請透過 [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#getTextFrameFormat) 呼叫 [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setKeepTextFlat)。當值為 `True` 時，文字不會進入 3D 場景；當值為 `False` 時，文字會參與場景並遵循其 3D 方向。

此設定不會移除形狀的 3D 格式：其相機、光源、材質與擠出仍透過 [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getThreeDFormat) 進行設定。它也不同於一般旋轉。[Shape.setRotation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#setRotation) 會在投影片平面上旋轉形狀，而 [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setRotationAngle) 控制文字在其邊界框內的自訂旋轉。將文字保持在 3D 場景之外不會重設上述任一角度。

以下獨立範例建立一個藍色矩形並加入文字，然後在原始矩形旁邊複製一個。兩個形狀的 3D 格式相同，僅文字設定不同：左側為 `False`，右側為 `True`。相機角度以度為單位，擠出高度為 40 點。範例將簡報儲存為 PPTX，並以兩倍預設尺寸將比較投影片渲染為 PNG。

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

左側的文字遵循 3D 方向；右側的文字保持平面且較易閱讀。兩個矩形的可見擠出與 3D 方向相同。

![左右並排的 3D 矩形：左側文字遵循 3D 方向，右側文字保持平面](keep_text_flat.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PowerPoint 格式（如 PPTX）時會保留 3D 格式設定。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製成 2D 結果。這同樣適用於將投影片渲染為 [PNG](/slides/zh-hant/python-java/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/python-java/convert-powerpoint-to-html/)，或產生供 [video conversion](/slides/zh-hant/python-java/convert-powerpoint-to-video/) 使用的影格。

請注意以下要點：

- 匯出的圖片與 PDF 不是互動式的。物件在匯出後無法由檢視者旋轉。
- 最終外觀取決於相機、光源、材質、擠出、填充與投影片縮放的組合。
- 如果需要檢查繼承或主題基礎的格式值，請閱讀 [effective shape properties](/slides/zh-hant/python-java/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式。在這些格式中，視覺結果會被渲染，而非以可編輯的 3D 設定保存。

## **FAQ**

**Aspose.Slides 能建立互動式 3D 簡報嗎？**

Aspose.Slides 會建立並渲染 PowerPoint 形狀與文字的 3D 效果，但不會讓匯出的圖片、PDF 或 HTML 頁面成為可由檢視者旋轉的互動式 3D 場景。在支援的 PPTX 中，3D 格式仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何不同？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果是套用於一般 PowerPoint 形狀或文字的格式設定，例如旋轉、擠出、斜角、光照與材質。本篇文章僅討論 3D 效果。

**要讓 3D 形狀可見，需要哪些設定？**

最低需要設定相機旋轉，並至少設定擠出或深度。實務上，同時設定光源與材質，可讓渲染的面呈現清晰的高光與陰影。

**我可以同時對形狀與文字套用 3D 效果嗎？**

可以。對形狀本體使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getThreeDFormat)，對文字使用 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#getThreeDFormat)。

**匯出為圖片、PDF、HTML 或影片影格時，會顯示 3D 效果嗎？**

會。Aspose.Slides 在產生投影片圖像、PDF 輸出、HTML 輸出以及用於影片轉換的影格時，會渲染 3D 效果。匯出的結果包含已渲染的外觀，而非可編輯的 3D 物件。

**我可以在套用繼承與主題設定後讀取最終的 3D 值嗎？**

可以。使用在 [Shape Effective Properties](/slides/zh-hant/python-java/shape-effective-properties/) 中描述的有效格式 API，即可讀取最終的相機、光源、斜角與相關 3D 值。