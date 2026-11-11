---
title: 在 Python 中通过 Java 将演示文稿幻灯片渲染为 SVG 图像
linktitle: 幻灯片转 SVG
type: docs
weight: 50
url: /zh/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 转 SVG
- 演示文稿 转 SVG
- 幻灯片 转 SVG
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

SVG 是一种基于 XML 的可缩放图像格式，适用于 Web 发布、幻灯片查看器、可访问性工作流和自动化后处理。Aspose.Slides 将每个幻灯片导出为单独的 SVG 文件，并允许您控制文本、字体、图片和 SVG 元素的写入方式。

当导出的 SVG 需要紧凑、跨浏览器保持一致或准备进行交互使用时，请使用 [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/)。

## **将幻灯片导出为 SVG**

创建一个 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)，选择幻灯片，并使用 [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) 将其写入流。示例需要一个现有的 `presentation.pptx` 文件。每个示例在需要时启动 JVM 并关闭其输出流。以下示例将演示文稿中的每张幻灯片导出为单独的 SVG 文件。

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

文件名使用 [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) 而不是循环索引。您也可以使用 [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 导出单个形状，当幻灯片查看器或网页只需要该形状时。

## **配置 SVG 输出**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) 控制 SVG 渲染。对于文本框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) 将文本框包含在渲染区域中，而 [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) 决定是否应用框的旋转。将 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) 设置为 `True`，当文本必须在没有连字的情况下渲染时。

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

## **控制箭头端的线段裁剪**

SVG 1.1 没有标记插入设置来指定线段在箭头下方的停止位置。默认情况下，Aspose.Slides 会缩短导出的线段，使其笔画不会穿透标记。将 [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) 设置为 `True`，即可将笔画绘制到线段原始端点。这一设置仅影响 SVG 输出。线段在幻灯片上的位置和长度保持不变。

示例在宽度为 2 和 10 点的线段上绘制三角形和菱形箭头。它两次导出同一张幻灯片，仅更改裁剪选项。

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

比较显示 10 点线段的三角形箭头。启用裁剪时，尖端锐利。禁用裁剪时，笔画会穿过标记的斜侧，形成平坦的端部。

![启用裁剪时尖端锐利、禁用裁剪时平坦端部的放大 10 点三角形](line-end-cropping.png)

在示例的其他线段中，2 点三角形的突出笔画不太明显。填充的菱形在两种宽度下都覆盖了笔画的端部。

## **控制文本和字体**

将幻灯片导出为 SVG 时，您可以控制文本是保留为文本还是转换为矢量图形，以及外部字体是如何包含或引用的。以下选项帮助您在导出 SVG 的视觉一致性、文本可选取性和字体依赖性之间取得平衡。

### **矢量化所有文本**

将 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) 设置为 `True`，可将所有幻灯片文本写入为矢量图形。这消除了字体依赖，使视觉结果在不同浏览器间更一致，但文本不再可作为 SVG 文本进行选择或搜索。

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) 使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) 的取值来处理外部加载的字体。选择 `AddLinksToFontFiles` 以引用单独的字体文件，`Embed` 将字体数据嵌入 SVG，或 `Vectorize` 将仅使用外部字体的文本渲染为图形。嵌入字体前请确认字体许可。

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

## **减小嵌入图像的大小**

使用 [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) 降低嵌入图片的分辨率，使用 [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) 删除裁剪后的源区域，并使用 [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) 控制 JPEG 编码质量。这些设置可以在牺牲图像保真度或保留的图像数据的代价下减小文件大小。

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

## **控制元文件栅格化分辨率**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) 设置在 SVG 导出期间对元文件进行栅格化的最低分辨率限制。使用它可以在细节和文件大小之间取得平衡，当 EMF 或 WMF 图像被栅格化时。它并不为 SVG 定义全局 DPI，也不会强制幻灯片上的每个对象都转为栅格图像。

下载 [metafile-rasterization.pptx](metafile-rasterization.pptx)，其中包含带有密集对角线的 EMF 图像。以下示例通过 [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) 将其第一张幻灯片以三种栅格化分辨率导出。所有其他导出设置保持一致，以便比较结果。

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

在输出中，EMF 成为每个 SVG 中的一个嵌入 PNG。以下测量基于提供的演示文稿；它们不是将 DPI 转换为像素尺寸的通用公式。

| 元文件栅格化 DPI | 嵌入 PNG 大小 | SVG 文件大小（字节） |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

下面的比较显示了在相同放大显示尺寸下嵌入光栅的相同区域。对角线在 72 DPI 时出现可见像素化，在更高分辨率下边缘更平滑，同时 SVG 文件体积增大。提高该数值并不一定能改进所有细节或改变每个导出图像。

![放大后的对角线细节，分别为 72、150 和 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) 控制图像分辨率降低，并可能掩盖更改元文件栅格化分辨率的效果。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) 控制 JPEG 编码质量，而非元文件栅格化分辨率。

## **为形状和文本分配稳定的 ID**

使用通过 `jpype.JProxy` 注册的 Python 格式化控制器，为形状分配 [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) 值，为文本 `tspan` 元素分配 [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) 值。使用 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) 进行代理分配。

以下控制器使用 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId)，该 ID 在形状生命周期内保持稳定，并使用可重复的计数器为其文本跨度生成 ID。这使得生成的 ID 适用于对未更改的演示文稿进行后处理。

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

在 Python 格式化控制器中，调用 [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) 并传入 [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) 值，可为导出形状添加 JavaScript 事件处理程序。通过 `jpype.JProxy` 注册控制器，并使用 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) 进行分配。在承载结果的页面或 SVG 文档中定义相应的 JavaScript 函数。

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

宿主页面可以定义由处理程序引用的 JavaScript 函数。分配 ID 和事件处理程序可实现幻灯片查看器、可访问性增强以及其他交互式 SVG 工作流。

## **常见问题解答**

**何时应该使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) 而不是 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)？**

当所有文本必须独立于字体时，请使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText)。当仅需要将使用外部字体的文本转换为图形时，请使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)。

**使 SVG 更小的最佳方法是什么？**

首先压缩嵌入的图片，删除裁剪的图像区域，并在目标环境能够提供字体文件时选择链接字体文件。测试结果，因为降低图像分辨率、降低 JPEG 质量以及矢量化文本各自都有不同的质量和体积取舍。

**导出后我可以修改 SVG 元素吗？**

可以。通过格式化控制器分配 ID，然后在后处理工具或浏览器脚本中选择相应的 SVG 元素。