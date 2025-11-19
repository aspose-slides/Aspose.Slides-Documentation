---
title: 在 Python 中将 PowerPoint 幻灯片转换为 PNG
linktitle: 幻灯片转 PNG
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
description: "使用 Aspose.Slides for Python via .NET 将 PowerPoint 和 OpenDocument 演示文稿快速转换为高质量 PNG 图像，确保精确且自动化的结果。"
---

## **概述**

Aspose.Slides for Python via .NET 使将 PowerPoint 演示文稿转换为 PNG 变得简单。您加载演示文稿，遍历其幻灯片，将每张幻灯片渲染为光栅图像，然后将结果保存为 PNG 文件。这非常适合生成幻灯片预览、在网页中嵌入幻灯片或为下游处理生成静态资源。

## **将幻灯片转换为 PNG**

本节展示了使用 Aspose.Slides for Python via .NET 将 PowerPoint 演示文稿转换为 PNG 图像的最简示例。

按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。
2. 从 `Presentation.slides` 集合中获取幻灯片（参见 [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) 类）。
3. 使用 `Slide.get_image` 方法生成幻灯片的缩略图。
4. 使用 `Presentation.save` 方法以 PNG 格式保存幻灯片缩略图。

以下 Python 代码演示了如何将 PowerPoint 演示文稿转换为 PNG：
```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


## **使用自定义尺寸将幻灯片转换为 PNG**

若要以自定义比例将幻灯片导出为 PNG，调用 `Slide.get_image` 并提供水平和垂直比例因子。这些乘数会相对于幻灯片的原始尺寸调整输出，例如，`2.0` 会使宽度和高度均加倍。使用相同的 `scale_x` 和 `scale_y` 值可保持宽高比。

以下 Python 代码演示了上述操作：
```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


## **使用自定义大小将幻灯片转换为 PNG**

如果您希望以特定尺寸生成 PNG 文件，请传入所需的 `width` 和 `height` 值。下面的代码展示了在指定图像大小的情况下将 PowerPoint 转换为 PNG 的方法：
```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


{{% alert title="Tip" color="primary" %}}
您可能想尝试 Aspose 免费的 **PowerPoint-to-PNG 转换器**——[PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) 和 [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。它们提供了本页所述过程的实时实现。
{{% /alert %}}

## **常见问题**

**如何只导出特定形状（例如图表或图片）而不是整个幻灯片？**

Aspose.Slides 支持 [为单个形状生成缩略图](/slides/zh/python-net/create-shape-thumbnails/)；您可以将形状渲染为 PNG 图像。

**服务器上是否支持并行转换？**

是的，但请 [不要共享](/slides/zh/python-net/multithreading/) 单个 presentation 实例跨线程使用。每个线程或进程应使用单独的实例。

**导出为 PNG 时试用版有哪些限制？**

评估模式会在输出图像上添加水印，并在未应用许可证之前实行 [其他限制](/slides/zh/python-net/licensing/)。