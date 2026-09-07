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
description: "使用 Aspose.Slides 於 Python（透過 Java）套用並呈現 PowerPoint 圖形與文字的 3D 效果。設定相機、光照、材質、擠壓、填充與 3D 文字。"
---
## **概述**

Aspose.Slides for Python via Java 可以建立、編輯、保留並呈現 PowerPoint 風格的 3D 格式化，用於圖形和文字。本文介紹 3D 效果，例如旋轉、擠壓、斜角、光照、材質、漸層或圖片填充，以及 3D 文字。

{{% alert color="info" title="Note" %}}
本文說明的是 PowerPoint 圖形和文字的 3D 格式化效果。它不涉及插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為影像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果呈現在匯出的 2D 輸出中。
{{% /alert %}}

依照[Installation](/slides/zh-hant/python-java/installation/) 中的說明安裝套件。每個範例都會匯入 `asposeslides`，在需要時啟動 JVM，然後匯入 API。圖片填充範例需要工作目錄中有 `image.jpg` 檔案。

## **3D 格式化概念**

使用[Shape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getThreeDFormat) 來對圖形套用 3D 格式化。返回的格式物件會控制該圖形的 3D 場景。

對於文字，使用[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#getThreeDFormat)。此方法會將 3D 格式化套用到文字框，而不是圖形本體。

最重要的 API 成員如下：

| API 成員 | 它控制什麼 | 何時使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getCamera) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件或匹配 PowerPoint 的 3D 旋轉預設。 |
| [getLightRig](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getLightRig) | 光線預設、方向與光線旋轉。 | 改變 3D 表面上高光與陰影的呈現方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getMaterial) 和 [setMaterial](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setMaterial) | 表面材質，例如平面、啞光、塑膠或金屬。 | 讓相同的幾何形狀看起來更平坦、柔和、有光澤或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getExtrusionHeight) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setExtrusionHeight) | 形狀從正面向後延伸的距離。 | 將平面形狀變成可見的厚度 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getExtrusionColor) | 擠壓側面的顏色。 | 使深度可見或將側面顏色與正面填充協調。 |
| [getDepth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getDepth) 和 [setDepth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 格式化使用的額外深度。 | 微調形狀或文字的深度，特別是與斜角和材質設定一起使用時。 |
| [getBevelTop](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getBevelTop) 和 [getBevelBottom](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getBevelBottom) | 正面與背面的凸起或圓角邊緣。 | 添加柔化或模塑的邊緣，而不是銳利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getContourColor)、[getContourWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getContourWidth) 和 [setContourWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setContourWidth) | 3D 物件的輪廓線。 | 在渲染輸出中突顯物件邊界。 |

## **建立 3D 圖形**

圖形在看起來具有說服力的 3D 效果之前，通常需要四種設定：

- 相機設定，因為預設的正面視圖可能會隱藏擠壓效果。
- 光線設定，因為光照使各面與側面可辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠壓或深度設定，因為平面圖形需要厚度。

以下範例建立一個矩形，於正面加入文字，套用 3D 格式化，將簡報儲存為 PPTX，並將投影片渲染為 PNG 影像。

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

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

渲染的投影片影像顯示矩形為一個厚實的 3D 方塊：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉是從「3-D Rotation」面板設定。X、Y、Z 旋轉值對應於透過相機 API 設定的旋轉。

![PowerPoint 3-D Rotation 面板，X、Y、Z 旋轉值已標示](img_02_01.png)

在 Aspose.Slides 中，透過 [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getThreeDFormat) 返回的 3D 格式設定相機類型與旋轉：

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

當需要變更檢視者看到物件的方式時，使用相機。它不會改變投影片上 2D 圖形的幾何形狀，只會變更 PowerPoint 與 Aspose.Slides 在渲染時使用的 3D 觀點。

## **添加擠壓與深度**

擠壓透過將圖形延伸至正面之後，使其看起來變厚。於 PowerPoint 中，深度控制設定此可見厚度，顏色控制設定側面的顏色。

![PowerPoint 深度控制對應擠壓顏色與擠壓高度屬性](img_02_02.png)

設定擠壓高度以調整厚度，並設定擠壓顏色以調整側面顏色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

當需要直接使用 PowerPoint 的深度值或將深度與斜角、材質、文字效果結合時，使用深度設定。對於許多圖形情況，擠壓高度是較直觀的設定，因為它直接表示可見的擠壓。

## **在 3D 效果中使用漸層或圖片填充**

3D 格式化與圖形填充相互獨立。您可以對正面套用純色、漸層、圖案或圖片填充，同時仍使用相同的相機、光線、材質與擠壓設定。

以下範例將漸層填充套用於圖形，並將較暗的擠壓顏色套用於側面：

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

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

![渲染的 3D 矩形，藍至橙色漸層填充，橙色擠壓](img_02_03.png)

若要改用圖片填充，請將圖像加入簡報並指派給圖形填充：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

![渲染的 3D 矩形，正面為照片填充，側面為橙色擠壓](img_02_04.png)

## **將 3D 格式化套用於文字**

圖形的 3D 格式化影響圖形本體。文字的 3D 格式化則影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要擠壓、材質、光照與相機設定。

以下範例建立帶有圖案填充的文字，套用 WordArt 變形，並在[TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/)上配置 3D 設定：

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

![渲染的 3D 文字，拱形 WordArt 變形，橙色圖案填充，深色擠壓](img_02_05.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PowerPoint 格式（如 PPTX）時會保留 3D 格式化。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製成 2D 結果。這適用於將投影片渲染為 PNG、匯出為 PDF、匯出為 HTML，或產生影片轉換用的影格時。

請記住以下要點：

- 匯出的影像和 PDF 並非互動式。匯出後觀眾無法旋轉物件。
- 最終外觀取決於相機、光線、材質、擠壓、填充與投影片縮放的組合。
- 若需要檢查繼承或佈景主題基礎的格式值，請使用有效格式 API。
- 某些匯出格式無法儲存可編輯的 PowerPoint 3D 格式化。於這些格式中，視覺結果會被渲染，而非保留為可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能否建立互動式 3D 簡報？**

Aspose.Slides 會為圖形和文字建立並渲染 PowerPoint 的 3D 效果。它不會使匯出的影像、PDF 或 HTML 頁面成為可讓觀眾旋轉的互動式 3D 場景。在 PPTX 中，只要格式支援，3D 格式化仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何差異？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 圖形或文字的格式化，例如旋轉、擠壓、斜角、光照與材質。本文討論的就是 3D 效果。

**要使 3D 圖形可見，需要哪些設定？**

最低需要設定相機旋轉以及擠壓或深度之一。實務上，還會設定光線與材質，使渲染的面具有明顯的高光與陰影。

**我可以同時對圖形與文字套用 3D 效果嗎？**

可以。對圖形本體使用 [Shape.getThreeDFormat]，對文字則使用 [TextFrameFormat.getThreeDFormat]。

**匯出為影像、PDF、HTML 或影片影格時，會出現 3D 效果嗎？**

會。Aspose.Slides 在產生投影片影像、PDF、HTML 以及影片轉換用的影格時會渲染 3D 效果。匯出的結果包含渲染後的外觀，而非可編輯的 3D 物件。

**在繼承與佈景主題設定套用後，我能讀取最終的 3D 值嗎？**

可以。使用 [ThreeDFormat.getEffective] 讀取最終的相機、光線、斜角及相關 3D 值。