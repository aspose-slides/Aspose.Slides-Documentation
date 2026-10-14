---
title: 在 Python 中将 PowerPoint 幻灯片转换为 PNG
linktitle: PowerPoint 转 PNG
type: docs
weight: 30
url: /zh/python-net/convert-powerpoint-to-png/
keywords:
- 将 PowerPoint 转换为 PNG
- 将演示文稿转换为 PNG
- 将幻灯片转换为 PNG
- 将 PPT 转换为 PNG
- 将 PPTX 转换为 PNG
- 将 ODP 转换为 PNG
- PowerPoint 转 PNG
- 演示文稿转 PNG
- 幻灯片转 PNG
- PPT 转 PNG
- PPTX 转 PNG
- ODP 转 PNG
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 将 PowerPoint 和 OpenDocument 演示文稿快速转换为高质量 PNG 图像，确保精确、自动化的结果。"
---
## **概述**

本文说明如何使用 Aspose.Slides for Python via .NET 将演示文稿幻灯片转换为 PNG 图像。您可以加载 PPT、PPTX、ODP 等格式的演示文稿，渲染每一张幻灯片，并将其保存为单独的 PNG 图像。

下面的示例演示了默认比例渲染、放大比例渲染、以像素指定输出尺寸以及选择渐变渲染样式。

## **将 PowerPoint 转换为 PNG**

使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类加载演示文稿，并通过 [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) 集合访问其幻灯片。示例对每张幻灯片调用不带参数的 [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) 进行渲染，以创建缩略图。随后使用 [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) 并指定 [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) 将每个渲染后的幻灯片保存为 PNG 图像。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
无参数的 [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) 重载以 0.2 的比例进行渲染。例如，尺寸为 720 × 540 点的幻灯片会生成 144 × 108 像素的缩略图。要控制输出尺寸，请使用带比例因子或显式图像大小的重载，如下所示。
{{% /alert %}}

## **将 PowerPoint 转换为 PNG（自定义尺寸）**

向 [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) 传递水平和垂直比例因子，以控制渲染后的尺寸。在本例中，两个因子均为 2，因此尺寸为 720 × 540 点的幻灯片会生成 1440 × 1080 像素的图像。相同的比例因子会保持幻灯片的宽高比。每个图像使用 [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) 保存为 PNG 格式。

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **将 PowerPoint 转换为 PNG（自定义大小）**

若要以像素指定输出尺寸，请向 [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) 传递尺寸，而非比例因子。此示例将每张幻灯片渲染为 960 × 720 像素，并使用 [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) 保存结果。请选择与幻灯片宽高比匹配的尺寸，以避免图像被拉伸。

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **选择渐变渲染样式**

假设幻灯片包含渐变填充，但导出的 PNG 中的渐变过渡比 PowerPoint 中显示的更浅或有所不同。您可以使用 [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) 属性在 [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) 中选择渐变的渲染方式。

下载 [gradient-styles.pptx](gradient-styles.pptx) 并将其放置在应用程序的工作目录中。其第一张幻灯片包含两个线性渐变：顶部从青色到橙色，底部从蓝色到黄色。每个渐变都有两个停止点，分别位于 0% 和 100%。

以下示例加载该演示文稿，并使用 [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) 在两种模式下渲染同一张第一张幻灯片。

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

下面的图像展示了同一幻灯片在两种渲染模式下的输出：

| 默认 | PowerPointUI |
| --- | --- |
| ![使用 Default 渲染的青色到橙色以及蓝色到黄色渐变](gradient-Default.png) | ![使用 PowerPointUI 渲染的相同渐变](gradient-PowerPointUI.png) |

在本例中，`DEFAULT` 产生较浅的中间颜色，而 `POWER_POINT_UI` 产生较暗的中间颜色。差异取决于渐变中的颜色和停止点。

当标准的 Aspose.Slides 输出满足需求时请选择 `DEFAULT`。若您的重点是与 PowerPoint 中的外观保持一致，请尝试 `POWER_POINT_UI`。将两种输出与您期望的结果进行比较；没有哪种模式是普遍更好的。

## **FAQ**

**如何导出特定形状（例如图表或图片），而不是整个幻灯片？**

Aspose.Slides 支持 [generating thumbnails for individual shapes](/slides/zh/python-net/create-shape-thumbnails/)，您可以将单个形状渲染为 PNG 图像。

**服务器上是否支持并行转换？**

是的。为每个线程或进程使用单独的演示文稿实例；[do not share a single instance across threads](/slides/zh/python-net/multithreading/)。

**导出为 PNG 时评估模式有哪些限制？**

评估模式会在输出图像上添加水印，并在应用许可证之前施加 [other restrictions](/slides/zh/python-net/licensing/)。