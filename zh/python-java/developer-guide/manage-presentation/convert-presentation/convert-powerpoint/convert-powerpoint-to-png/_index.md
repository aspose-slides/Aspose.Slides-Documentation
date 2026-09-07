---
title: 在 Python 中将 PowerPoint 幻灯片转换为 PNG
linktitle: PowerPoint 转 PNG
type: docs
weight: 30
url: /zh/python-java/convert-powerpoint-to-png/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 PNG
- 演示文稿 转 PNG
- 幻灯片 转 PNG
- PPT 转 PNG
- PPTX 转 PNG
- 将 PPT 保存为 PNG
- 将 PPTX 保存为 PNG
- 导出 PPT 为 PNG
- 导出 PPTX 为 PNG
- Python
- Java
- Aspose.Slides
description: "在 Python（通过 Java）中将 PowerPoint 幻灯片转换为 PNG 图像。使用自定义比例或精确的图像尺寸导出 PPT、PPTX 和 ODP 演示文稿。"
---
## **概述**

本文介绍如何使用 Aspose.Slides for Python via Java 将 PowerPoint 演示文稿转换为 PNG 图像。您可以加载 PPT、PPTX 和 ODP 文件，渲染每张幻灯片，并将其保存为单独的 PNG 图像。

示例还展示了如何使用缩放因子或精确的宽度和高度来控制输出尺寸。每个示例在需要时启动 Java 虚拟机，并在使用后释放演示文稿和图像资源。

## **将 PowerPoint 转换为 PNG**

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类加载输入文件。
2. 使用 [Presentation.getSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSlides) 检索幻灯片。
3. 使用 [Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 渲染每张幻灯片。
4. 使用 [ImageFormat.Png](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imageformat/#Png) 保存每个渲染的图像，然后释放其资源。

以下 Python 示例以默认大小导出所有幻灯片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **使用自定义比例将 PowerPoint 转换为 PNG**

向 [Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 传递水平和垂直缩放因子，以增大或减小输出尺寸。例如，使用 2 的水平和垂直缩放因子渲染 720 × 540 点的幻灯片会生成 1440 × 1080 像素的图像。

使用相等的缩放因子可保持幻灯片的纵横比。不同的因子会水平或垂直拉伸幻灯片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **使用自定义尺寸将 PowerPoint 转换为 PNG**

要指定精确的像素尺寸，请向 [Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 传递包含所需宽度和高度的 Java `Dimension` 对象。请选择与源幻灯片相同纵横比的尺寸，以避免失真。

以下示例将每张幻灯片保存为 960 × 720 像素的 PNG 图像：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **常见问题**

**我可以导出单个形状（例如图表或图片），而不是整张幻灯片吗？**

可以。Aspose.Slides 支持 [generating thumbnails for individual shapes](/slides/zh/python-java/create-shape-thumbnails/)，您可以将其保存为 PNG 图像。

**我能在服务器上并行转换演示文稿吗？**

为每个线程或进程使用单独的演示文稿实例，并使用唯一的输出路径以防文件被覆盖。不要在线程之间共享演示文稿实例。参见 [Multithreading](/slides/zh/python-java/multithreading/)。

**导出为 PNG 时试用版有哪些限制？**

评估模式会在输出图像上添加水印并应用 [other restrictions](/slides/zh/python-java/licensing/)。应用许可证即可移除这些限制。