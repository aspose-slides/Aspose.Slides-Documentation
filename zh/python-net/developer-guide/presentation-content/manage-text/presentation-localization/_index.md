---
title: 演示文稿本地化
type: docs
weight: 100
url: /python-net/presentation-localization/
keywords: "换语言, 拼写检查, 拼写检查, 拼写检查工具, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "更改或检查 PowerPoint 演示文稿中的语言。在 Python 中检查文本的拼写"
---
## **更改演示文稿和形状文本的语言**
- 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 向幻灯片添加一个矩形类型的自动形状。
- 向文本框中添加一些文本。
- 设置文本的语言 ID。
- 以 PPTX 文件格式保存演示文稿。

上述步骤的实现示例如下所示。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("要应用拼写检查语言的文本")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```