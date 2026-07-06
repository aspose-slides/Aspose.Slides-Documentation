---
title: 在 Python 中获取演示文稿的文本部分边界
linktitle: 文本部分边界
type: docs
weight: 47
url: /zh/python-net/portion-bounds/
keywords:
- 文本部分边界
- 文本部分
- 文本片段
- 文本坐标
- 文本位置
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中检索文本部分边界。"
---
## **概述**

文本部分表示段落内部的特定文本片段，并允许您独立于周围内容对该片段进行操作。 在 Aspose.Slides 中，当您需要检索文本片段的边界、仅对段落的部分应用格式，或在更细粒度的层面控制文本行为时，可以使用部分。

本文展示了如何使用[Portion.get_rect](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/get_rect/)获取文本部分的边界矩形。还展示了如何使用[Portion.get_coordinates](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/get_coordinates/)获取文本部分起始位置的坐标。此外，还重点说明了常见的与部分相关的场景，例如对单个文本片段应用超链接、了解格式如何通过部分、段落、文本框和主题继承进行解析，以及处理指定字体不可用的情况。

## **获取文本部分的边界**

使用[Portion.get_rect](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/get_rect/)检索文本部分的边界矩形：

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **获取文本部分的坐标**

使用[Portion.get_coordinates](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/get_coordinates/)检索文本部分起始位置的坐标：

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **常见问题**

**我可以仅对单个段落中的部分文本应用超链接吗？**

是的，您可以将[超链接分配](/slides/zh/python-net/manage-hyperlinks/)给单独的文本部分；只有该片段是可点击的，而不是整段。

**样式继承是如何工作的：文本部分会覆盖哪些属性，哪些属性会从段落或文本框继承？**

文本部分级别的属性具有最高优先级。如果在[Portion](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/)上未设置属性，Aspose.Slides 会从[Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/)获取。如果在那里也未设置，Aspose.Slides 将使用[TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)或[theme](https://reference.aspose.com/slides/zh/python-net/aspose.slides.theme/theme/)的样式。

**如果在目标机器或服务器上缺少文本部分指定的字体，会发生什么？**

[字体替换规则](/slides/zh/python-net/font-selection-sequence/) 将生效。文本可能会重新换行：度量、连字和宽度可能会改变，这对精确定位很重要。

**我可以单独为文本部分设置填充透明度或渐变，而不影响段落的其他部分吗？**

是的，文本颜色、填充和透明度在[Portion](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/)级别可以与相邻片段不同。