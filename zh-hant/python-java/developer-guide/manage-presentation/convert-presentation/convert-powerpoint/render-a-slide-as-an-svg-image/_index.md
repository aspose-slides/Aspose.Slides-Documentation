---
title: 在 Python 中透過 Java 將簡報投影片轉換為 SVG 圖片
linktitle: 投影片到 SVG
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
description: "在 Python 中透過 Java 匯出 PowerPoint 投影片為 SVG 圖片，並使用 Aspose.Slides 控制字型、文字、圖片、ID 與事件。"
---
## **概述**

SVG 是一种可伸缩的基于 XML 的图像格式，适用于 Web 发布、幻灯片查看器、辅助功能工作流以及自动后处理。Aspose.Slides 将每张幻灯片导出为单独的 SVG 文件，并让您能够控制文本、字体、图片和 SVG 元素的写入方式。

当导出的 SVG 必须紧凑、在各浏览器间保持一致或可用于互动时，請使用 [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/)。

## **將投影片匯出為 SVG**

建立一個 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)，選取投影片，並使用 [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) 將其寫入串流。範例需要一個現有的 `presentation.pptx` 檔案。每個範例在需要時會啟動 JVM，並關閉其輸出串流。以下範例會將簡報中的每張投影片匯出為單獨的 SVG 檔案。

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

檔名使用 [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) 而非迴圈索引。當投影片檢視器或網頁僅需要特定圖形時，亦可使用 [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 匯出單一形狀。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) 控制 SVG 的呈現。對於文字框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) 會將文字框納入繪製區域，而 [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) 決定是否套用框架旋轉。當文字必須在不使用連字的情況下呈現時，將 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) 設為 `True`。

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

在將投影片匯出為 SVG 時，您可以控制文字是保留為文字還是轉換為向量圖形，以及外部字型的包含或參考方式。以下選項可協助您在匯出 SVG 時在視覺一致性、文字選取及字型相依性之間取得平衡。

### **向量化所有文字**

將 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) 設為 `True`，即可將所有投影片文字寫入為向量圖形。這會消除字型相依性，並使視覺結果在各瀏覽器間更為一致，但文字將不再可作為 SVG 文字進行選取或搜尋。

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) 會對外部載入的字型使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) 值。選擇 `AddLinksToFontFiles` 可參考獨立的字型檔案，`Embed` 則把字型資料嵌入 SVG，或 `Vectorize` 將使用外部字型的文字以圖形方式呈現。嵌入字型前請確認字型授權。

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

## **縮小嵌入圖像大小**

使用 [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) 可降低嵌入圖片的解析度，使用 [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) 可省略剪裁後的來源區域，並使用 [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) 來控制 JPEG 編碼品質。這些設定會以圖像保真度或保留的圖像資料為代價，減少檔案大小。

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

## **控制中繼檔影像點陣化解析度**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) 設定在 SVG 匯出過程中點陣化中繼檔的最低解析度上限。當 EMF 或 WMF 圖像被點陣化時，可使用此設定在細節與檔案大小之間取得平衡。它不會為 SVG 定義全域 DPI，也不會強制投影片上的每個物件皆變成點陣圖像。

下載 [metafile-rasterization.pptx](metafile-rasterization.pptx)，其中包含具有緊密對角線的 EMF 圖像。以下範例透過 [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) 以三種點陣化解析度匯出其第一張投影片。其他匯出設定皆保持相同，以便比較結果。

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

在輸出中，EMF 會在每個 SVG 中變成一個嵌入的 PNG。以下測量值僅針對提供的簡報；並非將 DPI 轉換為像素尺寸的一般公式。

| 中繼檔點陣化 DPI | 嵌入 PNG 尺寸 | SVG 檔案大小 (位元組) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

以下比較顯示相同區域的嵌入點陣圖在相同放大顯示尺寸下的情況。對角線在 72 DPI 時出現明顯像素化，而在較高解析度時邊緣更平滑，且 SVG 檔案大小隨之增加。提升此值未必能改善所有細節或改變每張匯出的圖像。

![放大後的對角線細節（72、150、300 DPI）](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) 控制圖像解析度降低，且可能掩蓋更改中繼檔點陣化解析度的效果。 [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) 控制 JPEG 編碼品質，而非中繼檔點陣化解析度。

## **指派穩定的 ID 給形狀與文字**

使用透過 `jpype.JProxy` 註冊的 Python 格式化控制器，為形狀指派 [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) 值，為文字 `tspan` 元素指派 [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) 值。以 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) 設定此代理。

以下控制器使用 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId)，其在形狀生命週期內維持穩定，並對其文字跨度使用可重複的計數器。這使產生的 ID 適合於對未變更的簡報進行後處理。

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

## **新增 SVG 事件處理程式**

在 Python 格式化控制器中，使用 [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) 並傳入 [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) 值，即可為匯出的形狀新增 JavaScript 事件處理程式。透過 `jpype.JProxy` 註冊控制器並以 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) 指派。於宿主頁面或承載結果的 SVG 文件中定義該 JavaScript 函式。

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

宿主頁面可定義由處理程式參考的 JavaScript 函式。指派 ID 與事件處理程式可支援投影片檢視器、輔助功能增強以及其他互動式 SVG 工作流程。

## **常見問題**

**什麼時候應該使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) 而不是 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

當所有文字必須脫離字型的限制時，請使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText)。當僅需將使用外部字型的文字轉換為圖形時，請使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)。

**如何讓 SVG 更小？**

首先壓縮嵌入的圖片、刪除裁剪過的圖像區域，並在目標環境能提供字型檔案時選擇連結的字型檔。請測試結果，因為降低圖像解析度、降低 JPEG 品質以及向量化文字各有不同的品質與大小取捨。

**匯出後我可以修改 SVG 元素嗎？**

可以。透過格式化控制器指派 ID，之後在後處理工具或瀏覽器腳本中選取相符的 SVG 元素即可。