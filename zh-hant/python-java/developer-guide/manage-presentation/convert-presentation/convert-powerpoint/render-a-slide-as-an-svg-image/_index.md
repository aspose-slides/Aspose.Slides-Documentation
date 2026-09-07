---
title: 在 Python 中透過 Java 將簡報投影片渲染為 SVG 圖像
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 轉 SVG
- 簡報 轉 SVG
- 投影片 轉 SVG
- PPT 轉 SVG
- PPTX 轉 SVG
- SVG 匯出選項
- 互動式 SVG
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Python 中透過 Java 匯出 PowerPoint 投影片為 SVG 圖像，並使用 Aspose.Slides 控制字型、文字、圖像、ID 與事件。"
---
## **概述**

SVG 是一種可擴展的基於 XML 的圖像格式，適用於網路發布、投影片檢視器、可及性工作流程以及自動後處理。Aspose.Slides 將每張投影片匯出為單獨的 SVG 檔案，並讓您控制文字、字型、圖片和 SVG 元素的寫入方式。

當匯出的 SVG 必須緊湊、在各瀏覽器間可預測或適合互動使用時，請使用 [SVGOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgoptions/)。

## **將投影片匯出為 SVG**

建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/)，選取投影片，並使用 [Slide.writeAsSvg](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/) 將其寫入串流。範例需要一個現有的 `presentation.pptx` 檔案。每個範例在需要時會啟動 JVM 並關閉其輸出串流。以下範例將簡報中的每張投影片匯出為單獨的 SVG 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

檔名使用 [Slide.getSlideNumber](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getSlideNumber) 而非迴圈索引。當投影片檢視器或網頁只需要特定形狀時，亦可使用 [Shape.writeAsSvg](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/) 匯出單一形狀。

## **配置 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgoptions/) 控制 SVG 的呈現方式。對於文字框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgoptions/#setUseFrameSize) 會將文字框納入呈現區域，而 [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgoptions/#setUseFrameRotation) 則決定是否套用框的旋轉。當文字必須以不含連字的方式呈現時，將 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) 設為 `True`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **控制文字與字型**

### **向量化所有文字**

將 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgoptions/#setVectorizeText) 設為 `True`，即可將所有投影片文字寫成向量圖形。這可消除字型相依性，使視覺效果在各瀏覽器間更一致，但文字將不再可作為 SVG 文字被選取或搜尋。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **選擇外部字型的處理方式**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) 會使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgexternalfontshandling/) 的值來處理外部載入的字型。選擇 `AddLinksToFontFiles` 以參考獨立的字型檔案，`Embed` 則將字型資料嵌入 SVG，或 `Vectorize` 將僅使用外部字型的文字渲染為圖形。嵌入字型前請確認字型授權。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **縮小嵌入圖像尺寸**

使用 [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgoptions/#setPicturesCompression) 降低嵌入圖片的解析度，利用 [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) 省略裁剪過的來源區域，並透過 [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgoptions/#setJpegQuality) 控制 JPEG 編碼品質。這些設定會在減少檔案大小的同時，犧牲圖像保真度或保留的圖像資料。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **為形狀與文字指派穩定的 ID**

使用透過 `jpype.JProxy` 註冊的 Python 格式化控制器，為形狀指派 [SvgShape.setId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgshape/#setId) 值，並為文字 `tspan` 元素指派 [SvgTSpan.setId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgtspan/#setId) 值。透過 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgoptions/#setShapeFormattingController) 指定此代理。

以下控制器使用 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getOfficeInteropShapeId)，該 ID 在形狀的生命週期內是穩定的，並使用可重複的計數器為其文字 span 產生 ID。這使得產生的 ID 適用於對未變更的簡報進行後處理。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **新增 SVG 事件處理程序**

在 Python 格式化控制器中，使用帶有 [SvgEvent](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgevent/) 值的 [SvgShape.setEventHandler](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgshape/#setEventHandler) 來為匯出的形狀加入 JavaScript 事件處理程序。透過 `jpype.JProxy` 註冊控制器，並以 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgoptions/#setShapeFormattingController) 指定。於承載結果的頁面或 SVG 文件中定義 JavaScript 函式。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

主機頁面可定義事件處理程序所引用的 JavaScript 函式。指派 ID 與事件處理程序可支援投影片檢視器、可及性增強以及其他互動式 SVG 工作流程。

## **常見問題**

**何時應使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgoptions/#setVectorizeText) 而非 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)？**

當所有文字必須與字型無關時，使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgoptions/#setVectorizeText)。若僅需將使用外部字型的文字轉換為圖形，則使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)。

**如何使 SVG 檔案更小？**

首先壓縮嵌入的圖片、刪除裁剪的圖像區域，並在目標環境能提供時選擇連結的字型檔案。必須測試結果，因為較低的圖像解析度、較低的 JPEG 品質以及向量化文字各有不同的品質與大小取捨。

**匯出後我可以修改 SVG 元素嗎？**

可以。透過格式化控制器指派 ID，然後在後處理工具或瀏覽器腳本中選取對應的 SVG 元素。