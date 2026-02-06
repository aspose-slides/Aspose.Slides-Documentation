---
title: 文本框
type: docs
weight: 40
url: /zh/python-net/examples/elements/text-box/
keywords:
- 文本框
- 添加文本框
- 访问文本框
- 删除文本框
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中创建和格式化文本框：设置字体、对齐方式、换行、自动适应，以及链接以完善 PowerPoint 和 OpenDocument 的幻灯片。"
---
在 Aspose.Slides 中，**文本框**由 `AutoShape` 表示。几乎所有形状都可以包含文本，但典型的文本框没有填充或边框，只显示文本。

本指南解释了如何以编程方式添加、访问和删除文本框。

## **添加文本框**

文本框只是一个没有填充或边框并带有某些格式化文本的 `AutoShape`。以下是创建方法：

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 创建一个矩形形状（默认填充并带边框且无文本）。
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # 移除填充和边框，使其看起来像典型的文本框。
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # 设置文本格式。
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # 分配实际的文本内容。
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **注意:** 包含非空 `TextFrame` 的任何 `AutoShape` 都可以充当文本框。

## **按内容访问文本框**

要查找包含特定关键字（例如 “Slide”）的所有文本框，请遍历形状并检查它们的文本：

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # 只有 AutoShape 可以包含可编辑的文本。
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # 对匹配的文本框执行操作。
                    pass
```

## **按内容删除文本框**

此示例查找并删除第一张幻灯片上包含特定关键字的所有文本框：

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # 查找要删除的形状，这些 AutoShape 包含单词 "Slide"。
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # 从幻灯片中删除每个匹配的形状。
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **提示:** 在迭代期间修改形状集合之前，始终先创建该集合的副本，以避免集合修改错误。