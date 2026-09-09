---
title: 管理演示文稿中使用 Python via Java 的上标和下标
linktitle: 上标和下标
type: docs
weight: 80
url: /zh/python-java/superscript-and-subscript/
keywords:
- 上标
- 下标
- 添加上标
- 添加下标
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中精通上标和下标，提升演示文稿的专业文本格式，实现最大效果。"
---
## **概述**

Aspose.Slides 提供将上标和下标文本集成到 PowerPoint (PPT, PPTX) 和 OpenDocument (ODP) 演示文稿中的功能。无论是需要突出显示化学式、数学公式，还是用脚注对内容进行标注，这些专用的格式设置选项都有助于保持清晰和精确。在本文中，您将学习如何无缝地应用上标和下标样式，并确保每张幻灯片的专业效果。

## **管理上标和下标文本**

您可以向段落的任何部分添加上标和下标文本。要在 Aspose.Slides 文本框中应用此格式，请使用 [PortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/) 类的 [setEscapement](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/#setEscapement) 方法。

Escapement 值的范围为 -100%（下标）到 100%（上标）。例如：

- 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
- 通过索引获取幻灯片。
- 向幻灯片添加类型为 [ShapeType.Rectangle](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapetype/#Rectangle) 的 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。
- 访问与 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 关联的 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/)。
- 清除现有段落。
- 创建一个用于存放上标文本的段落，并将其添加到文本框的 [paragraph collection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#getParagraphs) 中。
- 创建一个 Portion。
- 使用 [setEscapement](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/#setEscapement) 将上标的值设置为 0 到 100（0 表示无上标）。
- 设置 [Portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/) 的文本，并将其添加到段落的 portion collection 中。
- 创建一个用于存放下标文本的段落，并将其添加到文本框的 [paragraph collection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#getParagraphs) 中。
- 创建一个 Portion。
- 使用 [setEscapement](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/#setEscapement) 将下标的值设置为 -100 到 0（0 表示无下标）。
- 设置 [Portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/) 的文本，并将其添加到段落的 portion collection 中。
- 将演示文稿保存为 PPTX 文件。

以下示例实现了这些步骤：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpata.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# 创建演示文稿。
presentation = Presentation()
try:
    # 获取幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 创建文本框。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # 创建用于上标文本的段落。
    superscript_paragraph = Paragraph()

    # 创建包含普通文本的 Portion。
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # 创建包含上标文本的 Portion。
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # 创建用于下标文本的段落。
    subscript_paragraph = Paragraph()

    # 创建包含普通文本的 Portion。
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # 创建包含下标文本的 Portion。
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # 将段落添加到文本框。
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**导出为 PDF 或其他格式时，上标和下标会被保留吗？**

是的，Aspose.Slides 在将演示文稿导出为 PDF、PPT/PPTX、图像以及其他受支持的格式时，会正确保留上标和下标格式。所有输出文件中的专用格式均保持完整。

**上标和下标可以与其他格式样式（例如粗体或斜体）一起使用吗？**

是的，Aspose.Slides 允许在同一 Portion 文本中混合多种文字样式。您可以启用粗体、斜体、下划线，并通过在 [PortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/) 中设置相应属性，同时应用上标或下标。

**上标和下标格式适用于表格、图表或 SmartArt 内的文本吗？**

是的，Aspose.Slides 支持在大多数对象中进行格式设置，包括表格和图表元素。在使用 SmartArt 时，您需要访问相应的元素（例如 [SmartArtNode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartartnode/)）及其文本容器，然后以类似方式配置 [PortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/) 属性。