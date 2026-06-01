---
title: 在 Python 中的演示文稿高级文本提取
linktitle: 提取文本
type: docs
weight: 90
url: /zh/python-net/extract-text-from-presentation/
keywords:
- 提取文本
- 从幻灯片提取文本
- 从演示文稿提取文本
- 从 PowerPoint 提取文本
- 从 OpenDocument 提取文本
- 从 PPT 提取文本
- 从 PPTX 提取文本
- 从 ODP 提取文本
- 检索文本
- 从幻灯片检索文本
- 从演示文稿检索文本
- 从 PowerPoint 检索文本
- 从 OpenDocument 检索文本
- 从 PPT 检索文本
- 从 PPTX 检索文本
- 从 ODP 检索文本
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET，快速从 PowerPoint 和 OpenDocument 演示文稿中提取文本。遵循我们的简明分步指南，节省时间。"
---
## **概述**

从演示文稿中提取文本是开发者处理幻灯片内容时常见且必不可少的任务。无论是处理 Microsoft PowerPoint 的 PPT 或 PPTX 文件，还是 OpenDocument 演示文稿（ODP），访问和检索文本数据对于分析、自动化、索引或内容迁移都可能至关重要。

本文提供了一份全面指南，讲解如何使用 Aspose.Slides for Python via .NET 高效地从各种演示文稿格式（包括 PPT、PPTX 和 ODP）中提取文本。您将学习如何系统地遍历演示文稿元素，以准确获取所需的文本内容。

## **从幻灯片提取文本**

Aspose.Slides for Python via .NET 提供了 [aspose.slides.util](https://reference.aspose.com/slides/zh/python-net/aspose.slides.util/) 命名空间，其中包含 [SlideUtil](https://reference.aspose.com/slides/zh/python-net/aspose.slides.util/slideutil/) 类。该类公开了多个重载的静态方法，用于从演示文稿或幻灯片中提取全部文本。要从演示文稿中的幻灯片提取文本，请使用 [get_all_text_boxes](https://reference.aspose.com/slides/zh/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) 方法。此方法接受类型为 [BaseSlide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseslide/) 的对象作为参数。执行时，方法会扫描整张幻灯片的文本并返回类型为 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 的对象数组，保留任何文本格式。

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **从演示文稿提取文本**

要扫描整个演示文稿的文本，请使用 [SlideUtil](https://reference.aspose.com/slides/zh/python-net/aspose.slides.util/slideutil/) 类公开的 [get_all_text_frames](https://reference.aspose.com/slides/zh/python-net/aspose.slides.util/slideutil/get_all_text_frames/) 静态方法。它接受两个参数：

1. 首先，一个表示将要提取文本的 PowerPoint 或 OpenDocument 演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 对象。  
1. 其次，一个 `Boolean` 