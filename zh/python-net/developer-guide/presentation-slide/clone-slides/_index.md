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
description: "使用 Aspose.Slides for Python via .NET 快速克隆或复制 PowerPoint 幻灯片。遵循我们的清晰代码示例和技巧，在几秒钟内实现 PPT 自动化，提升生产力，消除手动工作。"
---
## **简介**

克隆是对某物进行精确复制或复制的过程。Aspose.Slides 还允许您复制（克隆）任意幻灯片，然后将克隆的幻灯片插入到当前演示文稿或任何其他打开的演示文稿中。幻灯片克隆会创建一个新幻灯片，开发人员可以在不影响原始幻灯片的情况下对其进行修改。克隆幻灯片有多种方式：

- 在演示文稿的末尾克隆。
- 在演示文稿的其他位置克隆。
- 在另一个演示文稿的末尾克隆。
- 在另一个演示文稿的其他位置克隆。
- 在另一个演示文稿的特定位置克隆。

在 Aspose.Slides for Python via .NET 中，由 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 对象公开的 [slide collection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidecollection/) 提供 `add_clone` 和 `insert_clone` 方法，以执行这些类型的幻灯片克隆。

## **安装**

```bash
pip install aspose.slides
```

## **在同一演示文稿中末尾克隆**

如果您想在同一演示文稿中克隆幻灯片并将其追加到现有幻灯片的末尾，请使用 `add_clone` 方法。遵循以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 从 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 对象获取幻灯片集合。
1. 在 [SlideCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidecollection/) 上调用 `add_clone` 方法，传入要克隆的幻灯片。
1. 保存已修改的演示文稿。

在下面的示例中，首张幻灯片（索引 0）被克隆并追加到演示文稿的末尾。

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

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 从 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 对象获取幻灯片集合。
1. 在 [SlideCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidecollection/) 上调用 `insert_clone` 方法，传入要克隆的幻灯片以及其新位置的目标索引。
1. 保存已修改的演示文稿。

在下面的示例中，索引为 1（位置 2）的幻灯片被克隆到同一演示文稿中索引为 2（位置 3）的位置。

```py
import aspose.slides as slides

# 实例化 Presentation 类以表示演示文稿文件。
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # 将所需幻灯片克隆到同一演示文稿中指定的位置（索引）。
    presentation.slides.insert_clone(2, presentation.slides[1])
    # 将修改后的演示文稿保存到磁盘。
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在另一个演示文稿的末尾克隆**

如果需要将一份演示文稿中的幻灯片克隆并追加到另一份演示文稿的末尾：

1. 为源演示文稿（包含要克隆的幻灯片的演示文稿）创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 为目标演示文稿（将添加幻灯片的演示文稿）创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 从目标演示文稿获取幻灯片集合。
1. 在目标的 [SlideCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidecollection/) 上调用 `add_clone`，传入源演示文稿中的幻灯片。
1. 保存已修改的目标演示文稿。

在下面的示例中，源演示文稿中索引为 0 的幻灯片被克隆到目标演示文稿的末尾。

```py
import aspose.slides as slides

# 实例化 Presentation 类以表示源演示文稿文件。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # 实例化 Presentation 类用于目标 PPTX（将克隆幻灯片的地方）。
    with slides.Presentation() as target_presentation:
        # 将所需幻灯片从源演示文稿克隆到目标演示文稿中幻灯片集合的末尾。
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # 将目标演示文稿保存到磁盘。
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在另一个演示文稿的特定位置克隆**

如果需要将一份演示文稿中的幻灯片克隆并插入到另一份演示文稿的指定位置：

1. 为源演示文稿（包含要克隆的幻灯片的演示文稿）创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 为目标演示文稿（将添加幻灯片的演示文稿）创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 从目标演示文稿获取幻灯片集合。
1. 在目标的 [SlideCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidecollection/) 上调用 `insert_clone`，传入源演示文稿中的幻灯片以及期望的目标索引。
1. 保存已修改的目标演示文稿。

在下面的示例中，源演示文稿中索引为 0 的幻灯片被克隆到目标演示文稿中索引为 2（位置 3）的位置。

```py
import aspose.slides as slides

# 实例化 Presentation 类以表示源演示文稿文件。
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # 实例化 Presentation 类用于目标 PPTX（将在此克隆幻灯片）。
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # 在目标演示文稿中索引 2 处插入源的第一张幻灯片的克隆。
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # 将目标演示文稿保存到磁盘。
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **将幻灯片及其母版克隆到另一演示文稿中**

如果需要将幻灯片 **连同其母版** 从一份演示文稿克隆到另一份演示文稿中使用，首先将所需的母版幻灯片从源演示文稿克隆到目标演示文稿。然后在克隆幻灯片时使用该目标母版。`add_clone(Slide, MasterSlide)` 方法期望传入 **目标演示文稿的母版幻灯片**，而不是源演示文稿的母版。

克隆带母版的幻灯片，请遵循以下步骤：

1. 为源演示文稿（包含要克隆的幻灯片的演示文稿）创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 为目标演示文稿创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 获取要克隆的源幻灯片及其母版幻灯片。
1. 从目标演示文稿的母版集合中获取 [MasterSlideCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterslidecollection/)。
1. 在目标的 [MasterSlideCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masterslidecollection/) 上调用 `add_clone`，传入源母版以将其克隆到目标。
1. 从目标演示文稿的幻灯片集合中获取 [SlideCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidecollection/)。
1. 在目标的 [SlideCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidecollection/) 上调用 `add_clone`，传入源幻灯片和已克隆的目标母版。
1. 保存已修改的目标演示文稿。

在下面的示例中，源演示文稿中索引为 0 的幻灯片使用从源克隆的母版，被克隆到目标演示文稿的末尾。

```py
import aspose.slides as slides

# 实例化 Presentation 类以表示源演示文稿文件。
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # 实例化 Presentation 类用于目标演示文稿（将在其中克隆幻灯片）。
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

使用 Aspose.Slides for Python via .NET，您可以将幻灯片从演示文稿的一个章节克隆并插入到同一演示文稿的另一个章节中。为此，请使用 [SlideCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidecollection/) 类的 `add_clone(Slide, Section)` 方法。

以下 Python 示例演示了如何克隆幻灯片并将克隆插入到指定章节：

```py
import aspose.slides as slides

# 创建一个新的空白演示文稿。
with slides.Presentation() as presentation:
    # 基于第一张幻灯片的布局添加一个空白幻灯片。
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 向新幻灯片添加椭圆形状；此幻灯片稍后将被克隆。
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # 再次基于第一张幻灯片的布局添加一个空白幻灯片。
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 创建一个名为 "Section2"、以 slide2 为起始的章节。
    section = presentation.sections.add_section("Section2", slide2)
    # 将先前创建的幻灯片克隆到 "Section2" 章节中。
    presentation.slides.add_clone(slide, section)
    # 将演示文稿保存为 PPTX 文件。
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **确保幻灯片尺寸匹配**

将幻灯片克隆到另一演示文稿时，请确保目标演示文稿的幻灯片尺寸与源演示文稿相同。如果幻灯片尺寸不同，Aspose.Slides 不会自动重新缩放克隆的形状——它们的原始坐标和尺寸会被保留，这可能导致内容错位或超出幻灯片边界。

在克隆母版和幻灯片之前，您可以将目标演示文稿的幻灯片尺寸设置为与源演示文稿匹配：

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

请在克隆母版和幻灯片之前执行此操作。

## **FAQ**

### 演讲者备注和审阅者评论会被克隆吗？

会的。备注页和审阅评论会随克隆一起复制。如果不想要它们，请在插入后[删除它们](/slides/zh/python-net/presentation-notes/)。

### 图表及其数据源如何处理？

图表对象、格式和嵌入的数据会被复制。如果图表链接到外部源（例如 OLE 嵌入的工作簿），该链接会以[OLE 对象](/slides/zh/python-net/manage-ole/)的形式保留。文件移动后，请验证数据可用性并刷新行为。

### 我可以控制克隆的插入位置和章节吗？

可以。您可以在特定幻灯片索引处插入克隆，并将其放入选定的[章节](/slides/zh/python-net/slide-section/)。如果目标章节不存在，请先创建，然后将幻灯片移动到该章节。