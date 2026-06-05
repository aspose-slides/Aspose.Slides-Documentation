---
title: 在 Python 中的高级演示文稿文本提取
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
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 快速提取 PowerPoint 和 OpenDocument 演示文稿中的文本。遵循我们的简明分步指南，节省时间。"
---
## **概述**

从演示文稿中提取文本是处理幻灯片内容的开发人员常见且必不可少的任务。无论是处理 Microsoft PowerPoint 的 PPT 或 PPTX 文件，还是 OpenDocument 演示文稿（ODP），访问并检索文本数据对于分析、自动化、索引或内容迁移都可能至关重要。

本文提供了使用 Aspose.Slides for Python via .NET 高效提取 PPT、PPTX 和 ODP 等多种演示文稿格式文本的完整指南。您将学习如何系统地遍历演示文稿元素，准确获取所需的文本内容。

## **从幻灯片提取文本**

Aspose.Slides for Python via .NET 提供了[aspose.slides.util](https://reference.aspose.com/slides/zh/python-net/aspose.slides.util/)命名空间，其中包含[SlideUtil](https://reference.aspose.com/slides/zh/python-net/aspose.slides.util/slideutil/)类。该类公开了多个重载的静态方法，用于从演示文稿或幻灯片中提取所有文本。要从演示文稿中的幻灯片提取文本，请使用[get_all_text_boxes](https://reference.aspose.com/slides/zh/python-net/aspose.slides.util/slideutil/get_all_text_boxes/)方法。此方法接受类型为[BaseSlide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseslide/)的对象作为参数。执行时，该方法会扫描整个幻灯片的文本并返回类型为[TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)的对象数组，保留所有文本格式。

以下代码片段提取演示文稿第一张幻灯片的全部文本：

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

要扫描整个演示文稿的文本，请使用[SlideUtil](https://reference.aspose.com/slides/zh/python-net/aspose.slides.util/slideutil/)类公开的[get_all_text_frames](https://reference.aspose.com/slides/zh/python-net/aspose.slides.util/slideutil/get_all_text_frames/)静态方法。它接受两个参数：

1. 第一个参数是表示 PowerPoint 或 OpenDocument 演示文稿的[Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/)对象，文本将从该对象中提取。
2. 第二个参数是`Boolean`值，指示在扫描演示文稿文本时是否包括母版幻灯片。

该方法返回类型为[TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)的对象数组，包含文本格式信息。下面的代码扫描演示文稿的文本及其格式细节，包括母版幻灯片。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

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

## **分类且快速的文本提取**

[PresentationFactory](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationfactory/)类也提供了从演示文稿提取全部文本的方法：

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textextractionarrangingmode/)枚举参数指示组织文本提取结果的模式，可设置为以下值：
- `UNARRANGED` - 原始文本，不考虑其在幻灯片上的位置。
- `ARRANGED` - 文本按照幻灯片上的顺序排列。

在对速度要求高的情况下可以使用`UNARRANGED`模式；它比`ARRANGED`模式更快。

[PresentationText](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationtext/)表示从演示文稿中提取的原始文本。其`slides_text`属性返回一个幻灯片文本对象数组。每个对象表示相应幻灯片上的文本，并具有以下属性：

- `text` - 幻灯片形状内的文本。
- `master_text` - 与该幻灯片关联的母版幻灯片形状内的文本。
- `layout_text` - 与该幻灯片关联的布局幻灯片形状内的文本。
- `notes_text` - 与该幻灯片关联的备注幻灯片形状内的文本。
- `comments_text` - 与该幻灯片关联的批注中的文本。

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **常见问题**

**Aspose.Slides 在进行大文件文本提取时的速度如何？**

Aspose.Slides 已针对高性能进行优化，即使是[大型演示文稿](/slides/zh/python-net/open-presentation/)，也能进行处理，适用于实时或批量处理场景。

**Aspose.Slides 能否从演示文稿中的表格和图表提取文本？**

可以。Aspose.Slides 能从包括表格和图表相关对象在内的许多幻灯片元素中提取文本，从而访问并分析常见演示结构中的文本内容。

**提取演示文稿文本是否需要特殊的 Aspose.Slides 许可证？**

您可以使用 Aspose.Slides 的免费试用版进行文本提取，但会有[某些限制](/slides/zh/python-net/licensing/)，例如只能处理有限数量的幻灯片。若需无限制使用并处理更大的演示文稿，建议购买完整许可证。