---
title: 使用 Python 管理演示文稿中的文本片段
linktitle: 文本片段
type: docs
weight: 70
url: /zh/python-net/portion/
keywords:
- 文本片段
- 文本部分
- 文本坐标
- 文本位置
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中管理文本片段，从而提升性能和自定义能力。"
---

## **获取文本片段的坐标**

The [get_coordinates](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_coordinates/) method has been added to the [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) class which allows retrieving the coordinates of text portions:
```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```


## **FAQ**

**我可以仅对单个段落中的部分文字应用超链接吗？**

是的，您可以 [分配超链接](/slides/zh/python-net/manage-hyperlinks/) 为单独的片段分配超链接；只有该片段可点击，而不是整个段落。

**样式继承如何工作：Portion 会覆盖哪些属性，又会从 Paragraph/TextFrame 中继承哪些属性？**

Portion 级别的属性拥有最高优先级。如果属性未在 [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 上设置， 引擎会从 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 获取；如果在那里仍未设置，则从 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 或 [theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/theme/) 样式获取。

**如果在目标机器/服务器上缺少 Portion 指定的字体，会怎样？**

[字体替换规则](/slides/zh/python-net/font-selection-sequence/) 将生效。文本可能重新换行：度量、连字和宽度可能会改变，这会影响精确定位。

**我能为特定的 Portion 设置文本填充透明度或渐变，而不影响段落的其他部分吗？**

是的，文本颜色、填充和透明度在 [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 级别上可以与相邻片段不同。