---
title: Python 中 PowerPoint 演示文稿的高级文本提取
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
description: "了解如何使用 Aspose.Slides for Python（基于 .NET）快速轻松地从 PowerPoint 演示文稿中提取文本。遵循我们的简明分步指南，节省时间并在应用程序中高效访问幻灯片内容。"
---

## **概述**

从演示文稿中提取文本是开发人员处理幻灯片内容时常见且必不可少的任务。无论是处理 Microsoft PowerPoint 的 PPT 或 PPTX 格式文件，还是 OpenDocument 演示文稿（ODP），获取文本数据对于分析、自动化、索引或内容迁移都可能至关重要。

本文提供了使用 Aspose.Slides for Python 高效提取各种演示文稿格式（包括 PPT、PPTX 和 ODP）文本的完整指南。您将学习如何系统地遍历演示文稿元素，以准确检索所需的文本内容。

## **从幻灯片提取文本**

Aspose.Slides for Python 提供了 [aspose.slides.util](https://reference.aspose.com/slides/python-net/aspose.slides.util/) 命名空间，其中包含 [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) 类。该类公开了多个重载的静态方法，用于从演示文稿或幻灯片中提取所有文本。要从演示文稿中的幻灯片提取文本，请使用 [get_all_text_boxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) 方法。此方法接受类型为 [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) 的对象作为参数。执行时，方法会扫描整张幻灯片的文本并返回类型为 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 的对象数组，保留文本格式。

以下代码片段提取演示文稿第一张幻灯片的所有文本：
```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 类。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # 获取 PPTX 文件中所有幻灯片的 TextFrame 对象数组。
    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)
    # 遍历文本框数组。
    for text_frame in text_frames:
        # 遍历当前文本框中的段落。
        for paragraph in text_frame.paragraphs:
            # 遍历当前段落中的文本片段。
            for portion in paragraph.portions:
                # 显示当前片段中的文本。
                print(portion.text)
                # 显示文本的字体高度。
                print(portion.portion_format.font_height)
                # 显示文本的字体名称。
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```


## **从演示文稿提取文本**

要扫描整个演示文稿的文本，请使用由 [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) 类公开的 [get_all_text_frames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_frames/) 静态方法。它接受两个参数：

1. 表示将要提取文本的 PowerPoint 或 OpenDocument 演示文稿的 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象。
1. 一个 `Boolean` 值，指示在扫描演示文稿文本时是否应包括母版幻灯片。

该方法返回类型为 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 的对象数组，其中包括文本格式信息。下面的代码从演示文稿中扫描文本和格式详情，包括母版幻灯片。
```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 类。
with slides.Presentation("pres.pptx") as presentation:
    # 获取 PPTX 文件中所有幻灯片的 TextFrame 对象数组。
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, True)
    # 遍历文本框数组。
    for text_frame in text_frames:
        # 遍历当前文本框中的段落。
        for paragraph in text_frame.paragraphs:
            # 遍历当前段落中的文本片段。
            for portion in paragraph.portions:
                # 显示当前片段中的文本。
                print(portion.text)
                # 显示文本的字体高度。
                print(portion.portion_format.font_height)
                # 显示文本的字体名称。
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```


## **分类和快速文本提取**

[PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationfactory/) 类也提供了用于从演示文稿提取所有文本的静态方法：
```py
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```


[TextExtractionArrangingMode](https://reference.aspose.com/slides/python-net/aspose.slides/textextractionarrangingmode/) 枚举参数指示组织文本提取结果的模式，可设置为以下值：
- `UNARRANGED` - 原始文本，不考虑其在幻灯片上的位置。
- `ARRANGED` - 文本按照在幻灯片上的顺序排列。

当速度至关重要时，可使用 `UNARRANGED` 模式；它比 `ARRANGED` 模式更快。

[PresentationText](https://reference.aspose.com/slides/python-net/aspose.slides/presentationtext/) 表示从演示文稿中提取的原始文本。它包含 `slides_text` 属性，返回类型为 [ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/) 的对象数组。每个对象表示对应幻灯片上的文本。类型为 [ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/) 的对象具有以下属性：

- `text` - 幻灯片形状内的文本。
- `master_text` - 与该幻灯片关联的母版幻灯片形状内的文本。
- `layout_text` - 与该幻灯片关联的版式幻灯片形状内的文本。
- `notes_text` - 幻灯片备注形状内的文本。
- `comments_text` - 与该幻灯片关联的批注中的文本。
```py
import aspose.slides as slides

arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory().get_presentation_text("sample.pptx", arranging_mode)
slide_text = presentation_text.slides_text[0]
print(slide_text.text)
print(slide_text.layout_text)
print(slide_text.master_text)
print(slide_text.notes_text)
```


## **常见问题**

**Aspose.Slides 在处理大型演示文稿进行文本提取时的速度如何？**

Aspose.Slides 已针对高性能进行优化，即使是[大型演示文稿](/slides/zh/python-net/open-presentation/)也能高效处理，适用于实时或批量处理场景。

**Aspose.Slides 能否从演示文稿中的表格和图表提取文本？**

是的，Aspose.Slides 完全支持从表格、图表及其他复杂幻灯片元素中提取文本，帮助您轻松访问和分析所有文本内容。

**提取演示文稿文本是否需要特殊的 Aspose.Slides 许可证？**

您可以使用 Aspose.Slides 的免费试用版提取文本，尽管它有[某些限制](/slides/zh/python-net/licensing/)，例如只能处理有限数量的幻灯片。若需无限制使用并处理更大的演示文稿，建议购买完整许可证。