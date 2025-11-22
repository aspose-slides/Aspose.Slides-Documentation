---
title: 在 Python 中克隆 PowerPoint 幻灯片
linktitle: 克隆幻灯片
type: docs
weight: 40
url: /zh/python-net/clone-slides/
keywords:
- 克隆幻灯片
- 复制幻灯片
- 保存幻灯片
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 快速克隆或复制 PowerPoint 幻灯片。遵循我们的清晰代码示例和技巧，在几秒钟内实现 PPT 自动创建，提高生产力，消除手动操作。"
---

## **概述**

克隆是创建某物的精确副本或复制的过程。Aspose.Slides for Python via .NET 允许您克隆任何幻灯片并将该克隆插入当前演示文稿或其他打开的演示文稿中。克隆过程会生成一个新幻灯片，您可以对其进行修改而不影响原始幻灯片。

有多种克隆幻灯片的方式：

- 在同一演示文稿中将幻灯片克隆到末尾。
- 在同一演示文稿中将幻灯片克隆到指定位置。
- 在另一个演示文稿的末尾克隆幻灯片。
- 在另一个演示文稿的指定位置克隆幻灯片。
- 将幻灯片及其母版克隆到另一个演示文稿中。

在 Aspose.Slides for Python via .NET 中，由 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象提供的 [slide collection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) 支持 `add_clone` 和 `insert_clone` 方法，以实现这些幻灯片克隆类型。

## **在同一演示文稿中末尾克隆**

如果您想在同一演示文稿中克隆幻灯片并将其追加到现有幻灯片的末尾，请使用 `add_clone` 方法。按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 从 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象获取幻灯片集合。
3. 在 [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) 上调用 `add_clone` 方法，传入要克隆的幻灯片。
4. 保存修改后的演示文稿。

在下面的示例中，第一张幻灯片（索引 0）被克隆并追加到演示文稿的末尾。
```py
import aspose.slides as slides

# 实例化 Presentation 类以表示演示文稿文件。
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # 将所需幻灯片克隆到同一演示文稿中幻灯片集合的末尾。
    presentation.slides.add_clone(presentation.slides[0])
    # 将修改后的演示文稿保存到磁盘。
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **在同一演示文稿中克隆到指定位置**

如果您想在同一演示文稿中克隆幻灯片并将其放置在不同的位置，请使用 `insert_clone` 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 从 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象获取幻灯片集合。
3. 在 [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) 上调用 `insert_clone` 方法，传入要克隆的幻灯片以及其新位置的目标索引。
4. 保存修改后的演示文稿。

在下面的示例中，索引为 0（位置 1）的幻灯片被克隆到同一演示文稿中索引为 1（位置 2）的位置。
```py
import aspose.slides as slides

# 实例化 Presentation 类以表示演示文稿文件。
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # 将所需幻灯片克隆到同一演示文稿中指定位置（索引）。
    presentation.slides.insert_clone(2, presentation.slides[1])
    # 将修改后的演示文稿保存到磁盘。
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **在另一个演示文稿的末尾克隆**

如果需要将一份演示文稿中的幻灯片克隆并追加到另一份演示文稿的末尾：

1. 为源演示文稿（包含要克隆的幻灯片的演示文稿）创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。
2. 为目标演示文稿（将添加幻灯片的演示文稿）创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。
3. 从目标演示文稿获取幻灯片集合。
4. 在目标 [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) 上调用 `add_clone`，传入源演示文稿中的幻灯片。
5. 保存修改后的目标演示文稿。

在下面的示例中，源演示文稿中索引为 0 的幻灯片被克隆到目标演示文稿的末尾。
```py
import aspose.slides as slides

# 实例化 Presentation 类以表示源演示文稿文件。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # 实例化 Presentation 类用于目标 PPTX（幻灯片将被克隆的地方）。
    with slides.Presentation() as target_presentation:
        # 将所需幻灯片从源演示文稿克隆到目标演示文稿的幻灯片集合末尾。
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # 将目标演示文稿保存到磁盘。
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **在另一个演示文稿的指定位置克隆**

如果需要将一份演示文稿中的幻灯片克隆并插入到另一份演示文稿的指定位置：

1. 为源演示文稿（包含要克隆的幻灯片的演示文稿）创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。
2. 为目标演示文稿（将添加幻灯片的演示文稿）创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。
3. 从目标演示文稿获取幻灯片集合。
4. 在目标 [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) 上调用 `insert_clone`，传入源演示文稿中的幻灯片以及期望的目标索引。
5. 保存修改后的目标演示文稿。

在下面的示例中，源演示文稿中索引为 0 的幻灯片被克隆到目标演示文稿中索引为 1（位置 2）的地方。
```py
import aspose.slides as slides

# 实例化 Presentation 类以表示源演示文稿文件。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # 实例化 Presentation 类用于目标 PPTX（幻灯片要被克隆的地方）。
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # 在目标演示文稿的索引 2 处插入源的第一张幻灯片的克隆。
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # 将目标演示文稿保存到磁盘。
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **将幻灯片及其母版克隆到另一个演示文稿**

如果需要将幻灯片 **连同其母版** 从一份演示文稿克隆到另一份演示文稿中使用，首先将所需的母版从源演示文稿克隆到目标演示文稿。然后在克隆幻灯片时使用该目标母版。方法 `add_clone(Slide, MasterSlide)` 需要的是 **目标演示文稿中的母版**，而不是源演示文稿的母版。

克隆带母版的幻灯片，请按以下步骤操作：

1. 为源演示文稿（包含要克隆的幻灯片的演示文稿）创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。
2. 为目标演示文稿创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。
3. 访问需要克隆的源幻灯片及其母版。
4. 从目标演示文稿的母版集合中获取 [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)。
5. 在目标 [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) 上调用 `add_clone`，传入源母版以将其克隆到目标中。
6. 从目标演示文稿的幻灯片集合中获取 [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)。
7. 在目标 [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) 上调用 `add_clone`，传入源幻灯片和已克隆的目标母版。
8. 保存修改后的目标演示文稿。

在下面的示例中，源演示文稿中索引为 0 的幻灯片使用从源克隆的母版，被克隆到目标演示文稿的末尾。
```py
import aspose.slides as slides

# 实例化 Presentation 类以表示源演示文稿文件。
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # 实例化 Presentation 类以表示目标演示文稿（将在其中克隆幻灯片的地方）。
    with slides.Presentation() as target_presentation:
        # 获取源演示文稿的第一张幻灯片。
        source_slide = source_presentation.slides[0]
        # 获取第一张幻灯片使用的母版幻灯片。
        source_master = source_slide.layout_slide.master_slide
        # 将母版幻灯片克隆到目标演示文稿的母版集合中。
        cloned_master = target_presentation.masters.add_clone(source_master)
        # 使用克隆的母版将源演示文稿的幻灯片克隆到目标演示文稿的末尾。
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # 将目标演示文稿保存到磁盘。
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```


## **在指定章节的末尾克隆**

使用 Aspose.Slides for Python via .NET，您可以将幻灯片从演示文稿的一个章节克隆并插入到同一演示文稿的另一个章节。为此，请使用 [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) 接口的 `add_clone(Slide, Section)` 方法。

下面的 Python 示例展示了如何克隆幻灯片并将克隆插入到指定章节：
```py
import aspose.slides as slides

# 创建一个新的空白演示文稿。
with slides.Presentation() as presentation:
    # 基于第一张幻灯片的布局添加一个空白幻灯片。
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 向新幻灯片添加一个椭圆形状；此幻灯片稍后将被克隆。
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # 再基于第一张幻灯片的布局添加一个空白幻灯片。
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 创建一个名为 "Section2" 的章节，以 slide2 为起始。
    section = presentation.sections.add_section("Section2", slide2)
    # 将先前创建的幻灯片克隆到 "Section2" 章节中。
    presentation.slides.add_clone(slide, section)
    # 将演示文稿保存为 PPTX 文件。
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题解答**

**演讲者备注和审阅者评论会被克隆吗？**

是的。备注页和审阅评论会包含在克隆中。如果不需要它们，请在插入后[删除它们](/slides/zh/python-net/presentation-notes/)。

**图表及其数据源如何处理？**

图表对象、格式以及嵌入的数据都会被复制。如果图表链接到外部源（例如 OLE 嵌入的工作簿），该链接会保留为[OLE 对象](/slides/zh/python-net/manage-ole/)。在文件之间移动后，请检查数据可用性并刷新行为。

**我可以控制克隆的插入位置和章节吗？**

可以。您可以在特定幻灯片索引处插入克隆，并将其放入选定的[章节](/slides/zh/python-net/slide-section/)。如果目标章节不存在，请先创建，然后再将幻灯片移动到该章节。