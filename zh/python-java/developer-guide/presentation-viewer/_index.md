---
title: 使用 Python via Java 创建演示查看器
linktitle: 演示查看器
type: docs
weight: 50
url: /zh/python-java/presentation-viewer/
keywords:
- 查看演示文稿
- 演示查看器
- 创建演示查看器
- 查看 PPT
- 查看 PPTX
- 查看 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python via Java 中创建自定义演示查看器。轻松显示 PowerPoint 和 OpenDocument 文件，无需 Microsoft PowerPoint。"
---
## **介绍**

Aspose.Slides for Python via Java 用于创建包含幻灯片的演示文件。这些幻灯片可以通过在 Microsoft PowerPoint 等软件中打开演示文稿来查看。不过，有时开发人员可能需要在自己喜欢的图像查看器中将幻灯片以图像形式查看，或创建自己的演示查看器。在这种情况下，Aspose.Slides 允许您将单个幻灯片导出为图像。本文档介绍了具体操作方法。

## **从幻灯片生成 SVG 图像**

要使用 Aspose.Slides 从演示文稿幻灯片生成 SVG 图像，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片引用。
1. 打开一个字节流。
1. 将幻灯片保存为 SVG 图像到流中并写入文件。

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

## **使用自定义形状 ID 生成 SVG**

Aspose.Slides 可用于从幻灯片生成带有自定义形状 ID 的 [SVG](https://docs.fileformat.com/page-description-language/svg/)。为此，请使用 [SvgShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgshape/) 中的 [SvgShape.setId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgshape/#setId) 方法。`CustomSvgShapeFormattingController` 可用于设置形状 ID。

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

## **创建幻灯片缩略图图像**

Aspose.Slides 帮助您生成幻灯片的缩略图图像。要使用 Aspose.Slides 生成幻灯片缩略图，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片引用。
1. 按定义的比例获取参考幻灯片的缩略图图像。
1. 将缩略图图像以任意所需的图像格式保存。

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

## **使用用户定义尺寸创建幻灯片缩略图**

要使用用户定义的尺寸创建幻灯片缩略图，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片引用。
1. 使用定义的尺寸获取参考幻灯片的缩略图图像。
1. 将缩略图图像以任意所需的图像格式保存。

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

## **创建带有演讲者备注的幻灯片缩略图**

要使用 Aspose.Slides 生成带有演讲者备注的幻灯片缩略图，请按以下步骤操作：

1. 创建一个 [RenderingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/renderingoptions/) 类的实例。
1. 使用 [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) 方法设置演讲者备注的位置。
1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片引用。
1. 使用渲染选项获取参考幻灯片的缩略图图像。
1. 将缩略图图像以任意所需的图像格式保存。

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

## **实时示例**

您可以尝试免费应用 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/zh/viewer/) 了解使用 Aspose.Slides API 可以实现的功能：

![在线 PowerPoint 查看器](online-PowerPoint-viewer.png)

## **常见问题**

**我可以在 Web 应用程序中嵌入演示查看器吗？**

可以。您可以在服务器端使用 Aspose.Slides 将幻灯片渲染为图像或 HTML，并在浏览器中显示。导航和缩放功能可以使用 JavaScript 实现交互体验。

**在自定义查看器中显示幻灯片的最佳方式是什么？**

推荐的方法是将每张幻灯片渲染为图像（如 PNG 或 SVG）或使用 Aspose.Slides 转换为 HTML，然后在图片框（桌面）或 HTML 容器（Web）中显示输出。

**如何处理包含大量幻灯片的演示文稿？**

对于大型演示文稿，建议使用延迟加载或按需渲染幻灯片。这意味着仅在用户导航到相应幻灯片时生成其内容，从而降低内存占用和加载时间。