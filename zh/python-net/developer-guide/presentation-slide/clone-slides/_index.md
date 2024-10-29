---
title: 克隆幻灯片
type: docs
weight: 40
url: /zh/python-net/clone-slides/
keywords: "克隆幻灯片, 复制幻灯片, 保存幻灯片副本, PowerPoint, 演示文稿, Python, Aspose.Slides"
description: "在Python中克隆PowerPoint幻灯片"
---

## **在演示文稿中克隆幻灯片**
克隆是制作某物的精确副本或复制品的过程。通过.NET的Aspose.Slides for Python还可以制作任何幻灯片的副本或克隆，然后将该克隆幻灯片插入到当前或任何其他打开的演示文稿中。幻灯片克隆的过程创建了一个新幻灯片，开发人员可以对其进行修改，而不会更改原始幻灯片。有几种可能的方式来克隆幻灯片：

- 在演示文稿末尾克隆。
- 在演示文稿中的其他位置克隆。
- 在另一演示文稿的末尾克隆。
- 在另一演示文稿的其他位置克隆。
- 在另一演示文稿的特定位置克隆。

在通过.NET的Aspose.Slides for Python中，（一个[Slide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)对象的集合）由[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)对象暴露，提供了[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)和[insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)方法来执行上述类型的幻灯片克隆。
## **在演示文稿末尾克隆**
如果您想克隆一张幻灯片，然后在现有幻灯片的末尾使用它，请按照下面列出的步骤使用[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)方法：

1. 创建一个表示演示文稿文件的[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 通过引用[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)对象暴露的Slides集合来实例化[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)类。
2. 调用[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)对象暴露的[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)方法，并将要克隆的幻灯片作为参数传递给[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)方法。
3. 将修改后的演示文稿文件写入磁盘。

在下面给出的示例中，我们将一张位于演示文稿第一个位置（零索引）的幻灯片克隆到演示文稿的末尾。

```py
import aspose.slides as slides

# 实例化表示演示文稿文件的Presentation类
with slides.Presentation(path + "CloneWithinSamePresentationToEnd.pptx") as pres:
    # 将所需幻灯片克隆到同一演示文稿的幻灯片集合末尾
    slds = pres.slides

    slds.add_clone(pres.slides[0])

    # 将修改后的演示文稿写入磁盘
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **在演示文稿中的其他位置克隆**
如果您想克隆一张幻灯片，然后在同一演示文稿文件中的不同位置使用它，请使用[insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)方法：

1. 创建一个表示演示文稿文件的[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 通过引用[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)对象暴露的**Slides**集合实例化类。
1. 调用[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)对象暴露的[insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)方法，并将要克隆的幻灯片和新位置的索引作为参数传递给[insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)方法。
1. 将修改后的演示文稿写入为PPTX文件。

在下面给出的示例中，我们将一张位于演示文稿的零索引（位置1）的幻灯片克隆到索引1（位置2）。

```py
import aspose.slides as slides

# 实例化表示演示文稿文件的Presentation类
with slides.Presentation(path + "CloneWithInSamePresentation.pptx") as pres:
    # 将所需幻灯片克隆到同一演示文稿的幻灯片集合末尾
    slds = pres.slides

    # 将所需幻灯片克隆到同一演示文稿中指定的索引
    slds.insert_clone(2, pres.slides[1])

    # 将修改后的演示文稿写入磁盘
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **在另一演示文稿的末尾克隆**
如果您需要从一个演示文稿克隆一张幻灯片并在另一个演示文稿文件的末尾使用它：

1. 创建一个表示包含要克隆的幻灯片的演示文稿的[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 创建一个表示将要添加幻灯片的目标演示文稿的[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 通过引用目标演示文稿中暴露的**Slides**集合实例化[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)类。
1. 调用[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)对象暴露的[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)方法，并将源演示文稿中的幻灯片作为参数传递给[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)方法。
1. 将修改后的目标演示文稿文件写入磁盘。

在下面给出的示例中，我们将从源演示文稿的第一索引克隆一张幻灯片到目标演示文稿的末尾。

```py
import aspose.slides as slides

# 实例化Presentation类以加载源演示文稿文件
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # 实例化Presentation类用于目标PPTX（将在此克隆幻灯片）
    with slides.Presentation() as destPres:
        # 将所需幻灯片从源演示文稿克隆到目标演示文稿的幻灯片集合末尾
        slds = destPres.slides
        slds.add_clone(srcPres.slides[0])

        # 将目标演示文稿写入磁盘
        destPres.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **在另一演示文稿的其他位置克隆**
如果您需要从一个演示文稿克隆一张幻灯片并在另一个演示文稿文件中的特定位置使用它：

1. 创建一个表示包含要克隆的幻灯片的源演示文稿的[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 创建一个表示将要添加幻灯片的演示文稿的[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 通过引用目标演示文稿中暴露的Slides集合实例化[ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)类。
1. 调用[insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)方法暴露的[ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)对象，并将源演示文稿中的幻灯片与所需位置一起作为参数传递给[insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)方法。
1. 将修改后的目标演示文稿文件写入磁盘。

在下面给出的示例中，我们将从源演示文稿的零索引克隆一张幻灯片到目标演示文稿的索引1（位置2）。

```py
import aspose.slides as slides

# 实例化Presentation类以加载源演示文稿文件
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # 实例化Presentation类用于目标PPTX（将在此克隆幻灯片）
    with slides.Presentation("Aspose2_out.pptx") as destPres:
        slds = destPres.slides
        slds.insert_clone(2, srcPres.slides[0])

        # 将目标演示文稿写入磁盘
        destPres.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **在另一演示文稿中的特定位置克隆**
如果您需要从一个演示文稿克隆一张具有母版幻灯片的幻灯片并在另一演示文稿中使用它，则需要首先将所需的母版幻灯片从源演示文稿克隆到目标演示文稿。然后您需要使用该母版幻灯片来克隆具有母版的幻灯片。**add_clone(ISlide, IMasterSlide)**期望从目标演示文稿中传递母版幻灯片，而不是从源演示文稿中传递。为了克隆带有母版的幻灯片，请按以下步骤操作：

1. 创建一个表示包含要克隆的幻灯片的源演示文稿的[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 创建一个表示克隆幻灯片的目标演示文稿的[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 访问要克隆的幻灯片及其母版幻灯片。
1. 通过引用目标演示文稿的[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)对象暴露的母版集合实例化[IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)类。
1. 调用[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)方法暴露的[IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)对象，并将要克隆的母版从源PPTX作为参数传递给[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)方法。
1. 通过将对目标演示文稿中暴露的Slides集合的引用设置为实例化的[ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)类。
2. 调用[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)方法暴露的[ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)对象，并将要克隆的源演示文稿中的幻灯片及其母版作为参数传递给[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)方法。
3. 将修改后的目标演示文稿文件写入磁盘。

在下面给出的示例中，我们将一张带有母版的幻灯片（位于源演示文稿的零索引）克隆到目标演示文稿的末尾，并使用源幻灯片的母版。

```py
import aspose.slides as slides

# 实例化Presentation类以加载源演示文稿文件
with slides.Presentation(path + "CloneToAnotherPresentationWithMaster.pptx") as srcPres:
    # 实例化Presentation类用于目标演示文稿（将在此克隆幻灯片）
    with slides.Presentation() as destPres:
        # 从源演示文稿的幻灯片集合中实例化ISlide及其母版
        sourceSlide = srcPres.slides[0]
        sourceMaster = sourceSlide.layout_slide.master_slide

        # 将所需母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合中
        masters = destPres.masters
        destMaster = sourceSlide.layout_slide.master_slide

        # 将所需母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合中
        iSlide = masters.add_clone(sourceMaster)

        # 将所需幻灯片从源演示文稿克隆到目标演示文稿的幻灯片集合末尾，使用所需母版
        slds = destPres.slides
        slds.add_clone(sourceSlide, iSlide, True)
      
        # 从源演示文稿克隆所需母版幻灯片到目标演示文稿的母版集合中
        # 将目标演示文稿保存到磁盘
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```


## 在指定部分的末尾克隆

使用通过.NET的Aspose.Slides for Python，您可以从演示文稿的一个部分克隆一张幻灯片，并将其插入到同一演示文稿的另一个部分。在这种情况下，您必须使用[ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)接口中的[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)方法。

此Python代码向您展示了如何克隆一张幻灯片并将克隆的幻灯片插入到指定部分：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100) # 用于克隆
    
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    section = pres.sections.add_section("Section2", slide2)

    pres.slides.add_clone(slide, section)
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```