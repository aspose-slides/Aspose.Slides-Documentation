---
title: 在 Python via Java 中的高级演示文稿文本提取
linktitle: 提取文本
type: docs
weight: 90
url: /zh/python-java/extract-text-from-presentation/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 快速提取 PowerPoint 和 OpenDocument 演示文稿中的文本。遵循我们的简洁分步指南，以节省时间。"
---
## **概述**

从演示文稿中提取文本是开发人员处理幻灯片内容时常见且必不可少的任务。无论是处理 Microsoft PowerPoint 的 PPT 或 PPTX 文件，还是 OpenDocument 演示文稿（ODP），访问和检索文本数据对于分析、自动化、索引或内容迁移都可能至关重要。

本文提供了使用 Aspose.Slides for Python via Java 高效提取各种演示文稿格式（包括 PPT、PPTX 和 ODP）文本的完整指南。您将学习如何系统地遍历演示文稿元素，以准确检索所需的文本内容。

## **从幻灯片提取文本**

Aspose.Slides for Python via Java 提供了 [SlideUtil](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideutil/) 类。该类公开了多个重载的静态方法，用于从演示文稿或幻灯片中提取所有文本。要从演示文稿中的幻灯片提取文本，请使用 [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideutil/#getAllTextBoxes) 方法。此方法接受类型为 [BaseSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/) 的对象作为参数。执行时，该方法会扫描整张幻灯片的文本并返回类型为 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 的对象数组，保留任何文本格式。

下面的代码片段提取了演示文稿第一张幻灯片的所有文本：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **从演示文稿提取文本**

要扫描整个演示文稿的文本，请使用由 [SlideUtil](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideutil/) 类公开的静态方法 [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideutil/#getAllTextFrames)。它接受两个参数：

1. 首先，一个表示将从中提取文本的 PowerPoint 或 OpenDocument 演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 对象。
1. 其次，一个 `bool` 值，指示在扫描演示文稿文本时是否应包含母版幻灯片。

该方法返回类型为 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 的对象数组，包含文本格式信息。下面的代码扫描了演示文稿的文本及其格式细节，包括母版幻灯片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **分类和快速文本提取**

[PresentationFactory](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationfactory/) 类也提供了用于从演示文稿中提取所有文本的方法：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# 从文件中提取文本。
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# 从流中提取文本。
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# 使用加载选项从流中提取文本。
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textextractionarrangingmode/) 枚举参数指示组织文本提取结果的模式，可设置为以下值：

- [Unarranged](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) - 原始文本，不考虑其在幻灯片上的位置。
- [Arranged](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textextractionarrangingmode/#Arranged) - 文本按照在幻灯片上的顺序排列。

当速度至关重要时可以使用未整理模式；它比整理模式更快。

[PresentationText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationtext/) 表示从演示文稿中提取的原始文本。其 [getSlidesText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationtext/#getSlidesText) 方法返回类型为 `SlideText` 的对象数组。每个对象表示相应幻灯片上的文本。类型为 `SlideText` 的对象具有以下方法：

- `getText` - 幻灯片形状中的文本。
- `getMasterText` - 与该幻灯片关联的母版幻灯片形状中的文本。
- `getLayoutText` - 与该幻灯片关联的布局幻灯片形状中的文本。
- `getNotesText` - 与该幻灯片关联的备注幻灯片形状中的文本。
- `getCommentsText` - 与该幻灯片关联的批注中的文本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **常见问题**

**Aspose.Slides 在文本提取期间处理大型演示文稿的速度如何？**

Aspose.Slides 已针对高性能进行优化，甚至可以处理[大型演示文稿](/slides/zh/python-java/open-presentation/)，使其适用于实时或批量处理场景。

**Aspose.Slides 能否从演示文稿中的表格和图表提取文本？**

可以。Aspose.Slides 能从许多幻灯片元素中提取文本，包括表格和图表相关对象，您可以访问并分析常见演示结构中的文本内容。

**提取演示文稿文本是否需要特殊的 Aspose.Slides 许可证？**

您可以使用 Aspose.Slides 的免费试用版提取文本，尽管它会有[某些限制](/slides/zh/python-java/licensing/)，如只能处理有限数量的幻灯片。若需无限制使用并处理更大的演示文稿，建议购买完整许可证。