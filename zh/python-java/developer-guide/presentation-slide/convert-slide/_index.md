---
title: 在 Python 中将演示文稿幻灯片转换为图像
linktitle: 幻灯片转图像
type: docs
weight: 35
url: /zh/python-java/convert-slide/
keywords:
- 转换幻灯片
- 导出幻灯片
- 幻灯片转图像
- 将幻灯片保存为图像
- 幻灯片转 EMF
- 幻灯片转 PNG
- 幻灯片转 JPEG
- 幻灯片转位图
- 幻灯片转 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中将 PPT、PPTX 和 ODP 演示文稿的幻灯片转换为 PNG、JPEG、GIF、TIFF、EMF 以及其他图像格式。"
---
## **简介**

Aspose.Slides for Python via Java 可以将 PowerPoint 和 OpenDocument 演示文稿中的单个幻灯片渲染为 PNG、JPEG、GIF、TIFF 等图像格式。

要将幻灯片转换为图像，请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类加载演示文稿。
2. 选择要渲染的幻灯片。
3. 如有必要，使用 [RenderingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/renderingoptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/) 类配置渲染。
4. 调用 [Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 方法。它返回一个图像对象。
5. 保存图像，并使用 [ImageFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imageformat/) 值指定输出格式。

## **将幻灯片转换为 PNG 图像**

最简单的转换使用默认渲染设置。生成的图像对象可以在内存中处理或保存为文件。

以下 Python 示例渲染第一张幻灯片并将其保存为 PNG 图像：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **使用自定义尺寸将幻灯片转换为图像**

使用接受 [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) 参数的 [Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 重载，以精确像素尺寸渲染幻灯片。

以下示例创建一个 1820 × 1040 的 JPEG 图像：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **将带有备注和批注的幻灯片转换为图像**

默认情况下，幻灯片图像不包含备注或批注。将 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notescommentslayoutingoptions/) 对象传递给 [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) 方法，可控制备注和批注的显示位置。

以下示例将截断的备注放在幻灯片下方，批注放在右侧：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
对于幻灯片转图像的转换，不要将 [BottomFull](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notespositions/#BottomFull) 传递给 [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 方法。备注的文字可能超过固定图像尺寸的容纳范围。请改用 [BottomTruncated](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notespositions/#BottomTruncated)。
{{% /alert %}}

## **使用 TIFF 选项将幻灯片转换为图像**

[TiffOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/) 类允许您控制渲染的 TIFF 图像的尺寸、分辨率及其他属性。

以下示例以 300 DPI 渲染第一张幻灯片为 2160 × 2880 的 TIFF 图像：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
在 JDK 9 之前的 Java 版本中不保证支持 TIFF。
{{% /alert %}}

## **将所有幻灯片转换为图像**

遍历幻灯片集合，将整个演示文稿转换为一系列图像。除非显式跳过，否则会包括隐藏的幻灯片。

以下示例将每张幻灯片渲染为水平和垂直比例因子为 2 的 JPEG 图像：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **创建增强型图元文件 (EMF) 输出**

增强型图元文件 (EMF) 在需要将基于矢量的图形与 Microsoft Office 或其他支持 Windows 图元文件的 Windows 应用程序交换时非常有用。与基于像素的图像不同，EMF 能保留矢量绘图操作，可在缩放时保持清晰度。然而，EMF 主要是面向支持 Windows 图元文件的应用程序的兼容性格式，而非通用的交换格式。此外，复杂的幻灯片内容（如位图图像和某些效果）可能会作为光栅化元素存储在矢量图元文件容器中。

### **将幻灯片导出为 EMF**

[Slide.writeAsEmf](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/) 方法将 [Slide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/) 写入目标流，以 EMF 格式。以下示例加载演示文稿，选择第一张幻灯片，并将其写入 EMF 文件流：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

调用方拥有传递给 [Slide.writeAsEmf](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/) 的流，并负责在上述示例中关闭该流。

### **将 SVG 图像转换为 EMF 并添加到演示文稿**

使用 [SvgImage.writeAsEmf](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgimage/) 将 SVG 内容转换为 EMF。生成的字节可通过 [ImageCollection.addImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imagecollection/#addImage) 添加到演示文稿，并使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addPictureFrame) 放置在幻灯片上。

以下示例从 SVG 标记创建 [SvgImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgimage/)，将其转换为内存中的 EMF，插入到第一张幻灯片，并保存演示文稿：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgimage/) 不会获取目标流的所有权。[ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) 将所有生成的数据存储在内存中，因此在调用 [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--) 之前无需重置位置。流关闭后返回的字节数组仍然有效。

EMF 生成在所选的 Aspose.Slides for Python via Java 以及对应的 JDK 配置支持的操作系统上可用，但当字体或图形依赖缺失时，不同平台的渲染可能会有所差异。请安装源内容使用的字体或配置适当的替代方案，遵循 Aspose.Slides for Python via Java 的[平台要求](/slides/zh/python-java/system-requirements/)，并在目标 EMF 使用应用程序中验证结果。Linux 和 macOS 应用程序通常对显示和编辑 Windows 图元文件的支持有限或不一致。

## **彩色表情符号渲染**

{{% alert title="Note" color="info" %}}
在将演示文稿幻灯片转换为图像时，要正确渲染彩色表情符号，必须在执行转换的系统上安装并提供演示文稿使用的表情符号字体。例如，如果演示文稿使用 **Segoe UI Emoji** 而该字体缺失，输出图像中的表情符号可能会以单色显示。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 是否支持渲染带有动画的幻灯片？**

不支持。[Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 方法渲染幻灯片的静态图像，不会导出动画。

**可以将隐藏幻灯片导出为图像吗？**

可以。隐藏幻灯片可以像普通幻灯片一样渲染。请在处理循环中加入它们，如上述示例所示。

**幻灯片图像中会保留阴影和其他效果吗？**

会。Aspose.Slides 在幻灯片图像中渲染阴影、透明度以及其他受支持的图形效果。