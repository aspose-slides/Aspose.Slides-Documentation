---
title: 用 Python 创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/python-net/create-presentation/
keywords:
- 创建演示文稿
- 新建演示文稿
- 创建PPT
- 新建PPT
- 创建PPTX
- 新建PPTX
- 创建ODP
- 新建ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中创建 PowerPoint 演示文稿——生成 PPT、PPTX 和 ODP 文件，受益于对 OpenDocument 的支持，并以编程方式保存它们以获得可靠的结果。"
---

## **创建 PowerPoint 演示文稿**
要向演示文稿的选定幻灯片添加一条简单的直线，请按照以下步骤操作：

1. 创建一个 Presentation 类的实例。
1. 使用索引获取幻灯片的引用。
1. 使用 `shapes` 对象中公开的 `add_auto_shape` 方法添加一个类型为 `LINE` 的 AutoShape。
1. 将修改后的演示文稿写入 PPTX 文件。

在下面给出的示例中，我们向演示文稿的第一张幻灯片添加了一条线。

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX)
```