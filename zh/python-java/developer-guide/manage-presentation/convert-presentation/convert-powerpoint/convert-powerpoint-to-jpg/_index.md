---
title: 在 Python 中将 PPT 和 PPTX 转换为 JPG
linktitle: PowerPoint 转 JPG
type: docs
weight: 60
url: /zh/python-java/convert-powerpoint-to-jpg/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- PowerPoint 转 JPG
- PPT 转 JPG
- PPTX 转 JPG
- 保存幻灯片为 JPG
- 导出 PPT 为 JPG
- 导出 PPTX 为 JPG
- Python
- Java
- Aspose.Slides
description: "在 Python via Java 中将 PowerPoint（PPT、PPTX）幻灯片转换为 JPG 图像。使用 Aspose.Slides 设置自定义图像尺寸并渲染备注和评论。"
---
## **介绍**

Aspose.Slides for Python via Java 可将 PowerPoint 和 OpenDocument 演示文稿（PPT、PPTX 和 ODP）转换为 JPEG 图像。您可以导出每一张幻灯片或选定的幻灯片，以创建缩略图、构建演示文稿查看器，或在网站或应用程序中嵌入幻灯片预览。

## **将 PowerPoint PPT/PPTX 转换为 JPG**

1. 使用[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)加载演示文稿。  
2. 通过[getSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSlides)获取幻灯片集合。  
3. 调用[Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage)并传入水平和垂直缩放因子，以渲染每张幻灯片。  
4. 使用[ImageFormat.Jpeg](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imageformat/#Jpeg)将每个渲染后的图像保存为 JPEG，然后释放图像资源。

{{% alert color="info" title="Note" %}}
导出为 JPG 时会为每张幻灯片生成单独的图像。请保存渲染后的图像，而不是直接将演示文稿保存为图像格式。
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **将 PowerPoint PPT/PPTX 转换为具有自定义尺寸的 JPG**

根据所需的像素尺寸和原始幻灯片大小计算水平和垂直缩放因子，然后将其传递给[Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage)。以下示例为每张幻灯片目标生成 1200 × 800 像素的图像。

使用不同的缩放因子可能会拉伸幻灯片。若要保持宽高比，请对两个轴使用相同的缩放因子；这样生成的宽度和高度将遵循原始幻灯片的比例。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **在将幻灯片保存为图像时渲染备注和评论**

使用[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notescommentslayoutingoptions/)配置备注和评论，并通过[RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions)应用布局。此示例将备注放在底部，超出部分截断，并在右侧 200 像素宽的区域显示评论。每个渲染后的幻灯片均保存为 JPG 图像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**可以一次将多个幻灯片或演示文稿转换为 JPG 吗？**

可以。示例遍历所有幻灯片并为每张幻灯片保存一张 JPG。若要处理多个演示文稿，只需对每个输入文件重复转换，并使用不同的输出文件夹或唯一的文件名，以免覆盖图像。

**图表、SmartArt、表格和形状会包含在图像中吗？**

这些对象会作为幻灯片的一部分进行渲染。请确保转换环境中可用演示文稿使用的字体，以减少因字体替换而导致的差异。

**导出大型演示文稿时如何降低内存使用？**

一次处理一张图像，保存后立即释放图像资源，并避免使用不必要的大输出尺寸。内存需求取决于幻灯片内容和图像大小。

## **另请参阅**

- [Convert PowerPoint to PNG](/slides/zh/python-java/convert-powerpoint-to-png/)  
- [Render a slide as an SVG image](/slides/zh/python-java/render-a-slide-as-an-svg-image/)