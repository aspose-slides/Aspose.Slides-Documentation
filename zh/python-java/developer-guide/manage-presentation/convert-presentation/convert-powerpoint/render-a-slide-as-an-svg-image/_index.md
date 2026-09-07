---
title: 在 Python 中通过 Java 将演示文稿幻灯片渲染为 SVG 图像
linktitle: 幻灯片转 SVG
type: docs
weight: 50
url: /zh/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 转 SVG
- 演示文稿转 SVG
- 幻灯片转 SVG
- PPT 转 SVG
- PPTX 转 SVG
- SVG 导出选项
- 交互式 SVG
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在 Python 中通过 Java 将 PowerPoint 幻灯片导出为 SVG 图像，并使用 Aspose.Slides 控制字体、文本、图像、ID 和事件。"
---
## **概述**

SVG 是一种可伸缩的基于 XML 的图像格式，适用于网页发布、幻灯片查看器、可访问性工作流和自动后处理。Aspose.Slides 将每张幻灯片导出为单独的 SVG 文件，并让您控制文本、字体、图片和 SVG 元素的写入方式。

当导出的 SVG 必须紧凑、在不同浏览器间保持一致或准备好交互使用时，请使用 [SVGOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgoptions/)。

## **将幻灯片导出为 SVG**

创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)，选择一张幻灯片，并使用 [Slide.writeAsSvg](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/) 将其写入流。示例需要一个已有的 `presentation.pptx` 文件。每个示例在需要时启动 JVM 并关闭其输出流。下面的示例将演示文稿中的每张幻灯片导出为单独的 SVG 文件。

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

文件名使用 [Slide.getSlideNumber](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getSlideNumber) 而不是循环索引。当幻灯片查看器或网页只需要某个形状时，您也可以使用 [Shape.writeAsSvg](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 导出单个形状。

## **配置 SVG 输出**

[SVGOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgoptions/) 控制 SVG 渲染。对于文本框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgoptions/#setUseFrameSize) 将文本框包括在渲染区域中，且 [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgoptions/#setUseFrameRotation) 决定是否应用框的旋转。当文本必须在没有连字的情况下渲染时，将 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) 设置为 `True`。

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

## **控制文本和字体**

### **矢量化所有文本**

将 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgoptions/#setVectorizeText) 设置为 `True`，可将所有幻灯片文本写为矢量图形。这消除了字体依赖，使视觉效果在各浏览器间更一致，但文本将不再可作为 SVG 文本进行选择或搜索。

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

### **选择外部字体的处理方式**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) 使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgexternalfontshandling/) 的值来处理外部加载的字体。选择 `AddLinksToFontFiles` 以引用单独的字体文件，`Embed` 将字体数据嵌入 SVG，或 `Vectorize` 将使用外部字体的文本渲染为图形。在嵌入字体之前请验证字体许可。

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

## **降低嵌入图像的大小**

使用 [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgoptions/#setPicturesCompression) 可降低嵌入图片的分辨率，使用 [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) 可省略裁剪后的源区域，使用 [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgoptions/#setJpegQuality) 可控制 JPEG 编码质量。这些设置会在降低文件大小的同时牺牲图像保真度或保留的图像数据。

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

## **为形状和文本分配稳定的 ID**

使用通过 `jpype.JProxy` 注册的 Python 格式化控制器，为形状分配 [SvgShape.setId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgshape/#setId) 值，为文本 `tspan` 元素分配 [SvgTSpan.setId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgtspan/#setId) 值。使用 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgoptions/#setShapeFormattingController) 分配该代理。

以下控制器使用 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getOfficeInteropShapeId) ——在形状生命周期内保持稳定，并为其文本跨度使用可重复的计数器。这使得生成的 ID 适用于对未更改的演示文稿进行后处理。

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

## **添加 SVG 事件处理程序**

在 Python 格式化控制器中，使用 [SvgShape.setEventHandler](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgshape/#setEventHandler) 并传入 [SvgEvent](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgevent/) 值，以向导出的形状添加 JavaScript 事件处理程序。通过 `jpype.JProxy` 注册控制器，并使用 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgoptions/#setShapeFormattingController) 分配它。在承载结果的页面或 SVG 文档中定义 JavaScript 函数。

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

宿主页面可以定义处理程序引用的 JavaScript 函数。分配 ID 和事件处理程序可提升幻灯片查看器、可访问性增强以及其他交互式 SVG 工作流的功能。

## **常见问题**

**何时应使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgoptions/#setVectorizeText) 而不是 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

当所有文本必须独立于字体时，使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgoptions/#setVectorizeText)。仅在需要将使用外部字体的文本转换为图形时，使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)。

**如何最有效地减小 SVG 大小？**

首先压缩嵌入的图片，删除裁剪的图像区域，并在目标环境能够提供时选择链接的字体文件。请测试结果，因为降低图像分辨率、降低 JPEG 质量以及矢量化文本都会产生不同的质量和大小权衡。

**导出后我可以修改 SVG 元素吗？**

可以。通过格式化控制器分配 ID，然后在后处理工具或浏览器脚本中选择相应的 SVG 元素。