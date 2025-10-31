---
title: 创建一个Python演示文稿查看器
linktitle: 演示文稿查看器
type: docs
weight: 50
url: /zh/python-net/presentation-viewer/
keywords:
- 查看演示文稿
- 演示文稿查看器
- 创建演示文稿查看器
- 查看PPT
- 查看PPTX
- 查看ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python 中创建自定义演示文稿查看器。轻松显示 PowerPoint（PPTX、PPT）和 OpenDocument（ODP）文件，无需 Microsoft PowerPoint 或其他办公软件。"
---

## **概述**

Aspose.Slides for Python 用于创建包含幻灯片的演示文稿文件。这些幻灯片可以通过在 Microsoft PowerPoint 中打开演示文稿来查看。例如，开发人员有时需要在首选的图像查看器中将幻灯片作为图像查看，或在自定义演示文稿查看器中使用。在这种情况下，Aspose.Slides 允许您将单个幻灯片导出为图像。本文档说明了如何实现此操作。

## **从幻灯片生成 SVG 图像**

要使用 Aspose.Slides 从演示文稿幻灯片生成 SVG 图像，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取该幻灯片的引用。  
3. 打开文件流。  
4. 将幻灯片保存为 SVG 图像到文件流。

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **创建幻灯片缩略图**

Aspose.Slides 可帮助您生成幻灯片的缩略图。要使用 Aspose.Slides 为幻灯片生成缩略图，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取该幻灯片的引用。  
3. 按所需比例为引用的幻灯片创建缩略图。  
4. 以您喜欢的图像格式保存缩略图。

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **使用用户定义尺寸创建幻灯片缩略图**

要使用用户定义的尺寸创建幻灯片缩略图，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取该幻灯片的引用。  
3. 使用指定尺寸生成引用幻灯片的缩略图。  
4. 以您喜欢的图像格式保存缩略图。

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **使用讲稿创建幻灯片缩略图**

要使用 Aspose.Slides 生成带有讲稿的幻灯片缩略图，请按以下步骤操作：

1. 创建 [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) 类的实例。  
2. 使用 `RenderingOptions.slides_layout_options` 属性设置讲稿的位置。  
3. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
4. 通过索引获取该幻灯片的引用。  
5. 使用渲染选项生成引用幻灯片的缩略图。  
6. 以您喜欢的图像格式保存缩略图。

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **实时示例**

尝试免费应用 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) 了解使用 Aspose.Slides API 可以实现的功能：

[![在线 PowerPoint 查看器](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **常见问答**

**我可以在 ASP.NET Web 应用程序中嵌入演示文稿查看器吗？**

可以。您可以在服务器端使用 Aspose.Slides 将幻灯片渲染为[图像](/slides/zh/python-net/convert-powerpoint-to-png/)或[HTML](/slides/zh/python-net/convert-powerpoint-to-html/)，并在浏览器中显示。导航和缩放功能可以使用 JavaScript 实现，从而提供交互体验。

**在自定义 .NET 查看器中显示幻灯片的最佳方式是什么？**

推荐的方法是将每张幻灯片渲染为[图像](/slides/zh/python-net/convert-powerpoint-to-png/)（例如 PNG 或 SVG），或使用 Aspose.Slides 将其转换为[HTML](/slides/zh/python-net/convert-powerpoint-to-html/)，然后在桌面应用中将输出显示在 picture box 中，或在 Web 应用中放入 HTML 容器中。

**如何处理包含大量幻灯片的大型演示文稿？**

对于大型演示文稿，建议采用惰性加载或按需渲染的方式。这意味着仅在用户导航到特定幻灯片时才生成该幻灯片的内容，从而降低内存占用和加载时间。