---
title: 使用 Python 向演示文稿添加幻灯片
linktitle: 添加幻灯片
type: docs
weight: 10
url: /zh/python-net/developer-guide/presentation-slide/add-slide-to-presentation/
keywords:
- 添加幻灯片
- 创建幻灯片
- 空幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "轻松使用 Aspose.Slides for Python via .NET 将幻灯片添加到您的 PowerPoint 和 OpenDocument 演示文稿——无缝、高效的幻灯片插入，仅需数秒。"
---

## **概述**

在向演示文稿添加幻灯片之前，了解 PowerPoint 如何组织幻灯片很有帮助。每个演示文稿包含一个母版幻灯片、可选的布局幻灯片以及一个或多个普通幻灯片。每张幻灯片都有唯一的 ID，普通幻灯片按从零开始的索引排序。本文展示如何使用 Aspose.Slides for Python 创建幻灯片并选择合适的布局。

## **向演示文稿添加幻灯片**

Aspose.Slides 允许您基于现有布局幻灯片追加新幻灯片。以下示例遍历演示文稿中的每个布局，添加使用该布局的幻灯片，然后保存文件。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 访问 [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)。
1. 对 `presentation.layout_slides` 中的每个项，调用 `add_empty_slide` 追加使用该布局的幻灯片。
1. 可选地修改新添加的幻灯片。
1. 将演示文稿另存为 PPTX 文件。

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Access the slide collection.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Add an empty slide to the slide collection.
        slides.add_empty_slide(layout_slide)

    # Do some work on the newly added slides.

    # Save the presentation to disk.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**我能在特定位置插入新幻灯片，而不是仅在末尾吗？**

是的。该库支持幻灯片集合以及 [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/) 操作，您可以在所需的索引位置添加幻灯片，而不仅限于末尾。

**基于布局添加幻灯片时，主题/样式会被保留吗？**

是的。布局从其母版继承格式，新幻灯片则从所选布局及其关联的母版继承。

**在添加幻灯片之前，新“空”演示文稿中会有哪些幻灯片？**

新创建的演示文稿已经包含一个索引为零的空白幻灯片。这在计算插入索引时需要考虑。

**如果母版有很多选项，如何为新幻灯片选择“合适”的布局？**

通常选择匹配所需结构的 [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/)（如[标题和内容、双内容等](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)）。如果缺少此类布局，您可以 [将其添加到母版](/slides/zh/python-net/slide-layout/) 然后使用它。