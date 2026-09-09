---
title: 通过 Java 的 Python 获取演示文稿中文本片段的边界
linktitle: 片段边界
type: docs
weight: 47
url: /zh/python-java/portion-bounds/
keywords:
- 文本片段边界
- 文本片段
- 文本部分
- 文本坐标
- 文本位置
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中获取文本片段的边界。"
---
## **概述**

文本片段代表段落内部的特定文本片段，并允许您独立于周围内容对该片段进行操作。在 Aspose.Slides 中，当您需要获取文本片段的边界、仅对段落的一部分应用格式或在更细粒度的层面控制文本行为时，可使用片段。

本文档展示了如何使用[Portion.getRect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#getRect)获取片段的边界矩形。还展示了如何使用[Portion.getCoordinates](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#getCoordinates)获取片段起始位置的坐标。此外，还突出了常见的片段相关场景，例如为单个文本片段添加超链接、了解格式如何通过片段、段落、文本框和主题继承进行解析，以及处理指定字体不可用的情况。

## **获取文本片段的边界**

使用[Portion.getRect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#getRect)检索文本片段的边界矩形：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **获取文本片段的坐标**

使用[Portion.getCoordinates](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#getCoordinates)检索文本片段起始位置的坐标：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **常见问题**

**我可以仅对单段落中的部分文本应用超链接吗？**

可以，您可以[分配超链接](/slides/zh/python-java/manage-hyperlinks/)到单独的片段；只有该片段可点击，而不是整个段落。

**样式继承是如何工作的：片段会覆盖什么，哪些是从段落或文本框继承的？**

片段级别的属性具有最高优先级。如果在[Portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/)上未设置属性，Aspose.Slides 会从[Paragraph](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/)获取。如果那里也未设置，则使用[TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/)或[theme](https://reference.aspose.com/slides/zh/python-java/aspose.slides/theme/)的样式。

**如果片段指定的字体在目标机器或服务器上缺失会怎样？**

会应用[字体替换规则](/slides/zh/python-java/font-selection-sequence/)。文本可能会重新排版：度量、连字符和宽度都可能变化，这在精确定位时很重要。

**我可以为片段单独设置文字填充透明度或渐变，而不影响段落的其他部分吗？**

可以，位于[Portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/)级别的文字颜色、填充和透明度可以与相邻片段不同。