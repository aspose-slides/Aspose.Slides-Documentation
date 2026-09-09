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
description: "使用 Aspose.Slides 於 Python (透過 Java) 套用並渲染 PowerPoint 圖形與文字的 3D 效果。設定相機、光源、材質、擠壓、填充以及 3D 文字。"
---
## **概述**

Aspose.Slides for Python via Java 能夠建立、編輯、保留並呈現類似 PowerPoint 的 3D 格式設定，適用於圖形和文字。本文介紹 3D 效果，包括旋轉、擠壓、斜角、照明、材質、漸層或圖片填充，以及 3D 文字。

{{% alert color="info" title="Note" %}}
本文說明的是 PowerPoint 圖形和文字的 3D 格式化效果，並非插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為影像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染到匯出的 2D 輸出中。
{{% /alert %}}

按照[Installation](/slides/zh-hant/python-java/installation/) 中的說明安裝套件。每個範例都會匯入 `asposeslides`，在必要時啟動 JVM，然後匯入 API。圖片填充範例需要工作目錄中有 `image.jpg` 檔案。

## **3D 格式化概念**

使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getThreeDFormat) 為圖形套用 3D 格式。回傳的格式物件控制該圖形的 3D 場景。

對於文字，使用 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#getThreeDFormat)。這會將 3D 格式套用到文字框，而非圖形本體。

最重要的 API 成員如下：

| API 成員 | 控制項目 | 使用時機 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getCamera) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件或對應 PowerPoint 的 3D 旋轉預設。 |
| [getLightRig](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getLightRig) | 光源預設、方向與光線旋轉。 | 改變 3D 表面的高光與陰影呈現方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setMaterial) | 表面材質，例如平面、霧面、塑膠或金屬。 | 使相同的幾何形狀呈現更平坦、柔和、光亮或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setExtrusionHeight) | 形狀從前表面向後延伸的距離。 | 將平面形狀變成可見的厚實 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getExtrusionColor) | 擠壓側面的顏色。 | 使深度可見，或將側面顏色與前景填充協調。 |
| [getDepth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 格式使用的額外深度。 | 微調形狀或文字的深度，特別是結合斜角與材質設定時。 |
| [getBevelTop](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getBevelBottom) | 前後面上的凸起或圓角邊緣。 | 加入柔化或成型的邊緣，而非尖銳的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getContourWidth), and [setContourWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#setContourWidth) | 3D 物件的輪廓顏色與寬度。 | 在渲染輸出中強調物件邊界。 |

## **建立 3D 圖形**

圖形在看起來逼真的 3D 效果之前，通常需要四種設定：

- 相機設定，因為預設的正面視圖可能會隱藏擠壓效果。
- 光源設定，因為照明可使各面與側面易於辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠壓或深度設定，因為平面圖形需要厚度。

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

![渲染的藍色 3D 矩形，前面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉是從「3-D Rotation」面板進行設定。X、Y、Z 旋轉值對應於透過相機 API 設定的旋轉。

![PowerPoint 3-D Rotation 面板，突出顯示 X、Y、Z 旋轉值](img_02_01.png)

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

當需要變更觀看者看到的物件角度時使用相機。它不會更改投影片上 2D 圖形的幾何形狀，只會改變 PowerPoint 與 Aspose.Slides 渲染時使用的 3D 觀點。

## **加入擠壓與深度**

擠壓透過將形狀延伸至正面之後，使其看起來更厚。於 PowerPoint 中，深度控制設定此可見厚度，顏色控制則設定側面的顏色。

![PowerPoint 深度控制對應於擠壓顏色與擠壓高度屬性](img_02_02.png)

設定擠壓高度以決定厚度，並設定擠壓顏色以決定側面顏色：

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

當需要直接使用 PowerPoint 的深度值，或將深度與斜角、材質與文字效果結合時，使用深度設定。對於許多圖形情況，擠壓高度較為直觀，因為它直接表達可見的擠壓。

## **使用漸層或圖片填充搭配 3D 效果**

3D 格式化獨立於圖形填充。您可以對正面套用純色、漸層、圖案或圖片填充，同時使用相同的相機、光線、材質與擠壓設定。

此範例對圖形套用漸層填充，並將較深的擠壓顏色套用至側面：

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

渲染結果在正面保留漸層，同時分別渲染擠壓側面：

![渲染的 3D 矩形，藍至橙漸層填充與橙色擠壓](img_02_03.png)

若要改用圖片填充，先將影像加入簡報，並指派給圖形的填充：

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

渲染的 3D 矩形，正面使用照片填充，橙色擠壓：

![渲染的 3D 矩形，正面使用照片填充，橙色擠壓](img_02_04.png)

## **將 3D 格式套用於文字**

圖形的 3D 格式影響圖形本體。文字的 3D 格式則影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要擠壓、材質、照明與相機設定。

以下範例建立帶圖案填充的文字，套用 WordArt 變形，並在 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/) 上設定 3D 參數：

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

渲染的 3D 文字，拱形 WordArt 變形，橙色圖案填充與深色擠壓：

![渲染的 3D 文字，拱形 WordArt 變形，橙色圖案填充與深色擠壓](img_02_05.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PowerPoint 格式（如 PPTX）時會保留 3D 格式。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製為 2D 結果。這適用於將投影片渲染為 PNG、匯出為 PDF、匯出為 HTML，或產生用於影片轉換的影格時。

請注意以下要點：

- 匯出的影像與 PDF 並非互動式。匯出後觀眾無法旋轉物件。
- 最終外觀取決於相機、光源、材質、擠壓、填充與投影片縮放的組合。
- 若需檢查繼承或佈景主題的格式值，請使用有效格式 API。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式。此類格式僅會渲染視覺結果，而非保留可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能建立互動式 3D 簡報嗎？**

Aspose.Slides 會建立並渲染圖形與文字的 PowerPoint 3D 效果。它不會讓匯出的影像、PDF 或 HTML 頁面成為觀眾可旋轉的互動式 3D 場景。在 PPTX 中，若格式支援，3D 格式仍保留為可在 PowerPoint 中編輯的狀態。

**3D 模型與 3D 效果有何不同？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 圖形或文字的格式設定，如旋轉、擠壓、斜角、照明與材質。本文探討的即是 3D 效果。

**可見的 3D 圖形需要哪些設定？**

最低需要設定相機旋轉，並同時設定擠壓或深度。實務上，還應設定光源與材質，以使渲染出的面拥有明顯的高光與陰影。

**我可以同時將 3D 效果套用於圖形與文字嗎？**

可以。對圖形本體使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getThreeDFormat)，對文字使用 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#getThreeDFormat)。

**匯出為影像、PDF、HTML 或影片影格時，會顯示 3D 效果嗎？**

會。Aspose.Slides 在產生投影片影像、PDF、HTML 以及用於影片轉換的影格時會渲染 3D 效果。匯出的輸出僅包含渲染後的外觀，而非可編輯的 3D 物件。

**我可以在繼承與佈景主題套用後讀取最終的 3D 值嗎？**

可以。使用 [ThreeDFormat.getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getEffective) 可讀取最終的相機、光源、斜角及相關 3D 值。