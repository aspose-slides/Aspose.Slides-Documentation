---
title: 在 Python via Java 中建立簡報檢視器
linktitle: 簡報檢視器
type: docs
weight: 50
url: /zh-hant/python-java/presentation-viewer/
keywords:
- 檢視簡報
- 簡報檢視器
- 建立簡報檢視器
- 檢視 PPT
- 檢視 PPTX
- 檢視 ODP
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python via Java 中建立自訂簡報檢視器。輕鬆顯示 PowerPoint 和 OpenDocument 檔案，無需 Microsoft PowerPoint。"
---
## **簡介**

Aspose.Slides for Python via Java 用於建立包含投影片的簡報檔案。這些投影片可以透過在 Microsoft PowerPoint 等程式中開啟簡報來檢視。然而，有時開發人員可能需要在自己偏好的影像檢視器中將投影片以影像形式查看，或自行建立簡報檢視器。在此情況下，Aspose.Slides 允許您將單一投影片匯出為影像。本文說明如何執行此操作。

## **從投影片產生 SVG 影像**

若要使用 Aspose.Slides 從簡報投影片產生 SVG 影像，請依照以下步驟操作：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 開啟位元組串流。
1. 將投影片儲存為 SVG 影像至串流，並寫入檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **產生具自訂形狀 ID 的 SVG**

Aspose.Slides 可用於從投影片產生具有自訂形狀 ID 的 [SVG](https://docs.fileformat.com/page-description-language/svg/)。為此，請使用來自 [SvgShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgshape/) 的 [SvgShape.setId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgshape/#setId) 方法。`CustomSvgShapeFormattingController` 可用來設定形狀 ID。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **建立投影片縮圖影像**

Aspose.Slides 可協助您產生投影片的縮圖影像。若要使用 Aspose.Slides 產生投影片縮圖，請依照以下步驟操作：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 取得參考投影片在指定比例下的縮圖影像。
1. 以任何所需的影像格式儲存縮圖影像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **使用使用者自訂尺寸建立投影片縮圖**

若要使用使用者自訂尺寸建立投影片縮圖影像，請依照以下步驟操作：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 使用自訂的尺寸取得參考投影片的縮圖影像。
1. 以任何所需的影像格式儲存縮圖影像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **使用講者備註建立投影片縮圖**

若要使用 Aspose.Slides 產生含講者備註的投影片縮圖，請依照以下步驟操作：

1. 建立一個 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/renderingoptions/) 類別的實例。
1. 使用 [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) 方法設定講者備註的位置。
1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 使用渲染選項取得參考投影片的縮圖影像。
1. 以任何所需的影像格式儲存縮圖影像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **即時範例**

您可以嘗試 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/zh-hant/viewer/) 免費應用程式，了解可使用 Aspose.Slides API 實作的功能：

![線上 PowerPoint 檢視器](online-PowerPoint-viewer.png)

## **常見問題**

**我可以在 Web 應用程式中嵌入簡報檢視器嗎？**

是的。您可以在伺服器端使用 Aspose.Slides 將投影片渲染為影像或 HTML，並在瀏覽器中顯示。可以使用 JavaScript 實作導覽與縮放功能，以提供互動體驗。

**在自訂檢視器中顯示投影片的最佳方式是什麼？**

建議的做法是將每張投影片渲染為影像（例如 PNG 或 SVG）或使用 Aspose.Slides 轉換為 HTML，然後將輸出顯示在圖像框（桌面應用）或 HTML 容器（Web）中。

**我該如何處理包含大量投影片的簡報？**

對於大型簡報，建議採用延遲載入或按需渲染投影片的方式。即僅在使用者導航至該投影片時生成其內容，以降低記憶體使用量與載入時間。