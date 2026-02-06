---
title: 幻灯片
type: docs
weight: 10
url: /zh/python-net/examples/elements/slide/
keywords:
- 幻灯片
- 添加幻灯片
- 访问幻灯片
- 幻灯片索引
- 克隆幻灯片
- 重新排序幻灯片
- 删除幻灯片
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中管理幻灯片：创建、克隆、重新排序、隐藏、设置背景和尺寸、应用过渡效果，并导出为 PowerPoint 和 OpenDocument。"
---
本文提供了一系列示例，演示如何使用 **Aspose.Slides for Python via .NET** 处理幻灯片。您将学习如何使用 `Presentation` 类添加、访问、克隆、重新排序和删除幻灯片。

下面的每个示例都包括简要说明以及相应的 Python 代码片段。

## **添加幻灯片**

要添加新幻灯片，必须先选择布局。在本例中，我们使用 `Blank` 布局并向演示文稿中添加一个空白幻灯片。

```py
def add_slide():
    with slides.Presentation() as presentation:
        # 每张幻灯片基于一种布局，而布局本身基于母版幻灯片。
        # 使用 Blank 布局创建新幻灯片。
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Add a new empty slide using the selected layout.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **提示:** 每个幻灯片布局都源自母版幻灯片，母版定义了整体设计和占位符结构。下图展示了母版幻灯片及其关联布局在 PowerPoint 中的组织方式。

![Master and Layout Relationship](master-layout-slide.png)

## **按索引访问幻灯片**

您可以使用索引访问幻灯片。这在遍历或修改特定幻灯片时非常有用。

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # 按索引访问幻灯片。
        first_slide = presentation.slides[0]
```

## **克隆幻灯片**

本示例演示如何克隆现有幻灯片。克隆的幻灯片会自动添加到幻灯片集合的末尾。

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # 克隆幻灯片；它将被添加到演示文稿的末尾。
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **重新排序幻灯片**

您可以通过将幻灯片移动到新索引来更改其顺序。在本例中，我们将幻灯片移动到第一个位置。

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # 将幻灯片移动到第一个位置（其他幻灯片向下移动）。
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **删除幻灯片**

要删除幻灯片，只需引用它并调用 `remove`。本示例删除了第一张幻灯片。

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # 删除幻灯片。
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```