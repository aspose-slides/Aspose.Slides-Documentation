---
title: 在 Python 中透過 Java 渲染投影片為 SVG 圖像
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 轉 SVG
- 投影片 轉 SVG
- 投影片 轉 SVG
- PPT 轉 SVG
- PPTX 轉 SVG
- SVG 匯出選項
- 互動式 SVG
- PowerPoint
- 投影片
- Python
- Java
- Aspose.Slides
description: "在 Python 中透過 Java 使用 Aspose.Slides 將 PowerPoint 投影片匯出為 SVG 圖像，並控制字型、文字、圖片、ID 及事件。"
---
## **概覽**

SVG 是可伸縮的基於 XML 的影像格式，適用於網路出版、投影片檢視器、可存取性工作流程以及自動後處理。Aspose.Slides 將每張投影片匯出為單獨的 SVG 檔案，並讓您控制文字、字型、圖片和 SVG 元素的寫入方式。

當匯出的 SVG 必須緊湊、在瀏覽器之間保持一致，或適合互動使用時，請使用 [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/)。

## **將投影片匯出為 SVG**

建立一個 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)，選取投影片，並使用 [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) 將其寫入串流。範例需要已有的 `presentation.pptx` 檔案。每個範例在需要時都會啟動 JVM，並關閉其輸出串流。以下範例將投影片中的每張投影片匯出為單獨的 SVG 檔案。

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

檔名使用 [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) 而非迴圈索引。當投影片檢視器或網頁僅需要特定形狀時，亦可使用 [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 匯出單一形狀。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) 控制 SVG 的呈現。對於文字框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) 會將文字框納入呈現區域，而 [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) 決定是否套用文字框旋轉。當文字必須以不使用連字的方式呈現時，將 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) 設為 `True`。

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

## **控制箭頭端點的線端裁切**

SVG 1.1 沒有標記插入設定，可指定線條在箭頭下方應停止的位點。預設情況下，Aspose.Slides 會縮短匯出的線條，使其筆畫不會突穿標記。將 [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) 設為 `True` 即可將筆畫繪製至線條原始端點。此設定僅影響 SVG 輸出，線條在投影片上的位置與長度保持不變。

範例在寬度為 2 點與 10 點的線條上繪製三角形與菱形箭頭。它匯出同一張投影片兩次，僅變更裁切選項。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

比較圖顯示 10 點線條上的三角形箭頭。啟用裁切時，箭頭尖端銳利；停用裁切時，筆畫會突穿標記的斜邊，形成平坦的末端。

![在啟用裁切時呈現銳利尖端、停用裁切時呈現平坦末端的放大 10 點三角形](line-end-cropping.png)

在範例的其他線條中，2 點三角形的突伸筆畫較不明顯。填滿的菱形在兩種寬度下皆覆蓋筆畫末端。

## **控制文字與字型**

將投影片匯出為 SVG 時，您可以控制文字是保留為文字還是轉換為向量圖形，以及外部字型的包含或參考方式。以下選項可協助您在匯出的 SVG 中平衡視覺一致性、文字選取以及字型相依性。

### **向量化全部文字**

將 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) 設為 `True`，即可將所有投影片文字寫入為向量圖形。這樣可消除字型相依性，使視覺結果在各瀏覽器間更一致，但文字將不再能作為 SVG 文字被選取或搜尋。

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) 針對外部載入的字型使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) 值。選擇 `AddLinksToFontFiles` 以參考獨立的字型檔案，`Embed` 以將字型資料嵌入 SVG，或 `Vectorize` 以將使用外部字型的文字渲染為圖形。嵌入字型前請確認字型授權。

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

## **減少嵌入圖像大小**

使用 [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) 可降低嵌入圖片的解析度，使用 [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) 可省略裁切過的來源區域，使用 [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) 可控制 JPEG 編碼品質。這些設定會在犧牲圖像忠實度或保留的圖像資料下減少檔案大小。

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

## **控制中繼檔點陣化解析度**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) 設定在 SVG 匯出過程中點陣化中繼檔的最低解析度上限。當將 EMF 或 WMF 圖像點陣化時，可使用此設定在細節與檔案大小之間取得平衡。它不會為 SVG 定義全域 DPI，也不會強制投影片上的每個物件皆轉為點陣圖。

下載 [metafile-rasterization.pptx](metafile-rasterization.pptx)，其中包含具有緊密對角線的 EMF 圖像。以下範例透過 [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) 以三種點陣化解析度匯出其第一張投影片。所有其他匯出設定保持相同，以便進行比較。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()

```

在輸出結果中，EMF 會在每個 SVG 中變成一個嵌入的 PNG。以下測量值僅適用於提供的投影片；它們並非將 DPI 轉換為像素尺寸的一般公式。

| 中繼檔點陣化 DPI | 嵌入的 PNG 尺寸 | SVG 檔案大小（位元組） |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

以下比較顯示在相同放大顯示尺寸下，嵌入點陣圖的相同區域。對角線在 72 DPI 時呈現明顯像素化，而在較高解析度下邊緣更平滑，且 SVG 檔案會變大。提升解析度未必能改善所有細節或改變每個匯出的圖像。

![在 72、150、300 DPI 下放大的對角線細節](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) 控制圖像解析度的降低，可能掩蓋變更中繼檔點陣化解析度的效果。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) 控制 JPEG 編碼品質，而非中繼檔點陣化解析度。

## **指派穩定的 ID 給形狀與文字**

使用透過 `jpype.JProxy` 註冊的 Python 格式化控制器，為形狀指派 [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) 值，為文字 `tspan` 元素指派 [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) 值。使用 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) 設定此代理。

以下控制器使用 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId)（在形狀生命週期內保持穩定）以及其文字跨度的可重複計數器。這使產生的 ID 可適用於未變更投影片的後處理。

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

## **加入 SVG 事件處理程序**

在 Python 格式化控制器中，使用 [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) 並傳入 [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) 值，以為匯出的形狀新增 JavaScript 事件處理程序。透過 `jpype.JProxy` 註冊控制器，並使用 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) 指定它。於承載結果的頁面或 SVG 文件中定義相應的 JavaScript 函式。

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

承載頁面可以定義處理程序所參照的 JavaScript 函式。指派 ID 與事件處理程序可支援投影片檢視器、可存取性增強以及其他互動式 SVG 工作流程。

## **常見問題**

**何時應使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) 而非 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

當所有文字必須脫離字型相依性時，請使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText)。當僅需要將使用外部字型的文字轉換為圖形時，請使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)。

**如何讓 SVG 變得更小？**

首先壓縮嵌入的圖片、刪除裁切的圖像區域，並在目標環境能提供時選擇連結的字型檔案。請測試結果，因為降低圖像解析度、降低 JPEG 品質以及向量化文字各有不同的品質與尺寸取捨。

**匯出後，我可以修改 SVG 元素嗎？**

可以。透過格式化控制器指派 ID，然後在後處理工具或瀏覽器腳本中選取對應的 SVG 元素。