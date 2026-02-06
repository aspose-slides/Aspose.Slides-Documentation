---
title: GroupShape
type: docs
weight: 170
url: /zh/python-net/examples/elements/group-shape/
keywords:
- 组
- 添加组形状
- 访问组形状
- 删除组形状
- 取消组合形状
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 处理组形状：创建和取消组合，重新排列子形状，跨 PowerPoint 和 OpenDocument 设置变换和边界。"
---
使用 **Aspose.Slides for Python via .NET** 示例，演示如何创建形状组、访问它们、取消组合以及删除。

## **添加组形状**

创建一个包含两个基本形状的组。

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 添加组形状。
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **访问组形状**

从幻灯片中获取第一个组形状。

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # 访问幻灯片上的第一个组形状。
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **删除组形状**

从幻灯片中删除组形状。

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是组形状。
        group = slide.shapes[0]

        # 删除组形状。
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **取消组合形状**

将形状从组容器中移出。

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是组形状。
        group = slide.shapes[0]

        # 将形状移出组。
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```