---
title: 使用 Python 建立簡報的 3D 效果
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
description: "在 Python（透過 Java）使用 Aspose.Slides 套用並呈現 PowerPoint 圖形與文字的 3D 效果。設定相機、光照、材質、擠出、填充以及 3D 文字。"
---
## **概觀**

Aspose.Slides for Python via Java 能夠建立、編輯、保留並呈現 PowerPoint 風格的 3D 格式設定，適用於圖形與文字。本文說明 3D 效果，包括旋轉、擠出、斜角、光照、材質、漸層或圖片填充，以及 3D 文字。

{{% alert color="info" title="注意" %}}
本文章討論的是 PowerPoint 圖形與文字的 3D 格式效果，並非插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為影像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染至匯出的 2D 輸出。
{{% /alert %}}

將套件依照 [安裝](/slides/zh-hant/python-java/installation/) 中的說明安裝。每個範例都會匯入 `asposeslides`，在需要時啟動 JVM，然後匯入 API。圖片填充範例需要工作目錄中有 `image.jpg` 檔案。

## **3D 格式概念**

使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getThreeDFormat) 來對圖形套用 3D 格式。回傳的格式物件控制該圖形的 3D 場景。

對文字則使用 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#getThreeDFormat)。此方式會將 3D 格式套用於文字框，而非圖形本體。

最重要的 API 成員如下：

| API 成員 | 控制內容 | 何時使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getCamera) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件或匹配 PowerPoint 3D 旋轉預設。 |
| [getLightRig](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getLightRig) | 光源預設、方向與光線旋轉。 | 變更 3D 表面上高光與陰影的呈現方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getMaterial) 和 [setMaterial](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setMaterial) | 表面材質，例如平面、霧面、塑膠或金屬。 | 使相同的幾何形狀看起來更平坦、柔軟、光亮或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getExtrusionHeight) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setExtrusionHeight) | 形狀從正面向後延伸的距離。 | 將平面形狀變為可見的厚實 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getExtrusionColor) | 擠出側面的顏色。 | 使深度可見或使側面顏色與正面填充協調。 |
| [getDepth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getDepth) 和 [setDepth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 格式使用的額外深度。 | 微調形狀或文字的深度，尤其與斜角與材質設定一起使用時。 |
| [getBevelTop](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getBevelTop) 和 [getBevelBottom](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getBevelBottom) | 正面與背面的凸起或圓角邊緣。 | 在鋒利的平面上加入柔化或成型的邊緣。 |
| [getContourColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getContourColor)、[getContourWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getContourWidth) 和 [setContourWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setContourWidth) | 3D 物件的輪廓。 | 在渲染輸出中強調物件邊界。 |

## **建立 3D 圖形**

在看起來具說服力的 3D 效果之前，圖形通常需要四種設定：

- 相機設定，因為預設的正面檢視可能會隱藏擠出效果。
- 光源設定，因為光線使面與側面可辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠出或深度設定，因為平面形狀需要厚度。

以下範例建立一個矩形，於正面加入文字，套用 3D 格式，將簡報儲存為 PPTX，並將投影片渲染為 PNG 影像。

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

渲染後的投影片影像顯示矩形為厚實的 3D 方塊：

![已渲染的藍色 3D 矩形，正面帶白色 3D 文字](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉於「3-D Rotation」面板設定。X、Y、Z 旋轉值對應於您透過相機 API 設定的旋轉。

![PowerPoint 3-D Rotation 面板，已突顯 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getThreeDFormat) 回傳的 3D 格式設定相機類型與旋轉：

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

當您需要變更觀眾觀看物件的角度時使用相機。它不會改變投影片上 2D 圖形的幾何形狀，只會改變 PowerPoint 與 Aspose.Slides 在渲染時使用的 3D 觀點。

## **加入擠出與深度**

擠出會將圖形向背面延伸，使其看起來較厚。於 PowerPoint 中，深度控制設定此可見厚度，顏色控制則設定側面的顏色。

![PowerPoint 深度控制對應到擠出顏色與擠出高度屬性](img_02_02.png)

設定擠出高度以決定厚度，設定擠出顏色以決定側面顏色：

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

當您需要直接使用 PowerPoint 的深度值，或將深度與斜角、材質、文字效果結合時，使用深度設定。在許多圖形情境中，擠出高度是較直觀的設定，因為它直接表達可見的擠出量。

## **在 3D 效果中使用漸層或圖片填充**

3D 格式與圖形填充相互獨立。您可以對正面套用純色、漸層、圖樣或圖片填充，同時使用相同的相機、光源、材質與擠出設定。

以下範例對圖形套用漸層填充，並將側面顏色設為較深的擠出顏色：

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

渲染結果保留正面的漸層，同時分別渲染擠出側面：

![已渲染的 3D 矩形，藍至橙漸層填充，橙色擠出側面](img_02_03.png)

若改用圖片填充，請先將影像加入簡報，然後指派給圖形填充：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
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
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

圖片會在正面渲染，而擠出則作為 3D 側面表面渲染：

![已渲染的 3D 矩形，正面使用照片填充，橙色擠出側面](img_02_04.png)

## **將 3D 格式套用於文字**

圖形的 3D 格式影響圖形本體；文字的 3D 格式則影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要擠出、材質、光照與相機設定。

以下範例建立帶圖樣填充的文字，套用 WordArt 變形，並在 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/) 上設定 3D：

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

文字以彎曲、擠出的 3D 形式呈現：

![已渲染的 3D 文字，拱形 WordArt 變形，橙色圖樣填充，深色擠出側面](img_02_05.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PPTX 等 PowerPoint 格式時會保留 3D 格式。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製成 2D 結果。此行為適用於將投影片渲染為 PNG、匯出為 PDF、匯出為 HTML，或產生供影片轉換使用的影格。

請注意以下要點：

- 匯出的影像與 PDF 並非互動式。匯出後觀眾無法旋轉物件。
- 最終外觀取決於相機、光源、材質、擠出、填充與投影片縮放的組合。
- 若需檢視繼承或佈景主題的格式值，請使用有效格式 API。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式。在這些格式中，視覺結果會被渲染，而非保留為可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能否建立互動式 3D 簡報？**

Aspose.Slides 會建立並渲染針對圖形與文字的 PowerPoint 3D 效果。它不會使匯出的影像、PDF 或 HTML 頁面成為可供觀眾旋轉的互動式 3D 場景。於 PPTX 中，若格式支援，3D 格式仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何不同？**

3D 模型是插入至簡報的獨立 3D 物件。3D 效果則是針對一般 PowerPoint 圖形或文字套用的格式，如旋轉、擠出、斜角、光照與材質。本文僅討論 3D 效果。

**顯示可見 3D 圖形需要哪些設定？**

最低限度需設定相機旋轉，並設定擠出或深度。實務上，通常還會設定光源與材質，以確保渲染出的面具有明顯的高光與陰影。

**我可以同時對圖形與文字套用 3D 效果嗎？**

可以。對圖形本體使用 [Shape.getThreeDFormat]，對文字使用 [TextFrameFormat.getThreeDFormat]。

**匯出為影像、PDF、HTML 或影片影格時，會顯示 3D 效果嗎？**

會。Aspose.Slides 於產生投影片影像、PDF、HTML 以及用於影片轉換的影格時會渲染 3D 效果。匯出的檔案僅含渲染後的外觀，而非可編輯的 3D 物件。

**我可以在繼承與佈景主題設定後讀取最終的 3D 值嗎？**

可以。使用 [ThreeDFormat.getEffective] 讀取最終的相機、光源、斜角與相關 3D 值。