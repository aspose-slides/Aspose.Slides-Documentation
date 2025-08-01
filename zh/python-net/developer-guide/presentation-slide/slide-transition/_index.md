---
title: 使用 Python 管理演示文稿中的幻灯片切换效果
linktitle: 幻灯片切换效果
type: docs
weight: 90
url: /zh/python-net/slide-transition/
keywords:
- slide transition
- add slide transition
- apply slide transition
- advanced slide transition
- morph transition
- transition type
- transition effect
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中自定义幻灯片切换效果，提供针对 PowerPoint 和 OpenDocument 演示文稿的分步指导。"
---

## **添加幻灯片过渡**
为了更容易理解，我们演示了如何使用 Aspose.Slides for Python via .NET 管理简单的幻灯片过渡。开发人员不仅可以在幻灯片上应用不同的幻灯片过渡效果，还可以自定义这些过渡效果的行为。要创建简单的幻灯片过渡效果，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过 TransitionType 枚举，应用 Aspose.Slides for Python via .NET 提供的过渡效果之一的幻灯片过渡类型。
1. 写入修改后的演示文稿文件。

```py
import aspose.slides as slides

# 实例化 Presentation 类以加载源演示文稿文件
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 在第 1 页应用圆形类型过渡
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # 在第 2 页应用组合类型过渡
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # 将演示文稿写入磁盘
    presentation.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **添加高级幻灯片过渡**
在上述部分，我们仅在幻灯片上应用了简单的过渡效果。现在，为了使这个简单的过渡效果更好且可控，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 从 Aspose.Slides for Python via .NET 提供的过渡效果之一应用幻灯片过渡类型。
1. 您还可以设置过渡为单击后推进，在特定时间段后推进或两者皆可。
1. 如果启用了单击后推进的幻灯片过渡，过渡将仅在有人单击鼠标时推进。此外，如果设置了“单击后推进”属性，过渡将在指定的推进时间过去后自动推进。
1. 将修改后的演示文稿作为演示文稿文件写入。

```py
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类
with slides.Presentation(path + "BetterSlideTransitions.pptx") as pres:
    # 在第 1 页应用圆形类型过渡
    pres.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE


    # 设置 3 秒的过渡时间
    pres.slides[0].slide_show_transition.advance_on_click = True
    pres.slides[0].slide_show_transition.advance_after_time = 3000

    # 在第 2 页应用组合类型过渡
    pres.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB


    # 设置 5 秒的过渡时间
    pres.slides[1].slide_show_transition.advance_on_click = True
    pres.slides[1].slide_show_transition.advance_after_time = 5000

    # 在第 3 页应用缩放类型过渡
    pres.slides[2].slide_show_transition.type = slides.slideshow.TransitionType.ZOOM


    # 设置 7 秒的过渡时间
    pres.slides[2].slide_show_transition.advance_on_click = True
    pres.slides[2].slide_show_transition.advance_after_time = 7000

    # 将演示文稿写入磁盘
    pres.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **变换过渡**
Aspose.Slides for Python via .NET 现在支持 [Morph Transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/)。这种过渡是 PowerPoint 2019 中引入的新变换过渡。变换过渡允许您从一张幻灯片平滑过渡到下一张幻灯片。本文描述了这个概念以及如何使用变换过渡。要有效使用变换过渡，您需要两张幻灯片并且至少有一个共同的对象。最简单的方法是复制幻灯片，然后将第二张幻灯片上的对象移动到不同的位置。

以下代码片段展示了如何向演示文稿中添加一个带有文本的幻灯片克隆，并将 [morph type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/) 的过渡设置为第二张幻灯片。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoshape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    autoshape.text_frame.text = "PowerPoint 演示文稿中的变换过渡"

    presentation.slides.add_clone(presentation.slides[0])

    presentation.slides[1].shapes[0].x += 100
    presentation.slides[1].shapes[0].y += 50
    presentation.slides[1].shapes[0].width -= 200
    presentation.slides[1].shapes[0].height -= 10

    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **变换过渡类型**
新增了 [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 枚举。它表示不同类型的变换幻灯片过渡。

TransitionMorphType 枚举有三个成员：

- ByObject: 变换过渡将考虑形状作为不可分割的对象进行执行。
- ByWord: 变换过渡将在可能的情况下按单词转移文本。
- ByChar: 变换过渡将在可能的情况下按字符转移文本。

以下代码片段展示了如何设置变换过渡到幻灯片并更改变换类型：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    presentation.slides[0].slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```



## **设置过渡效果**
Aspose.Slides for Python via .NET 支持设置如从黑色、从左侧、从右侧等过渡效果。为设置过渡效果，请按照以下步骤操作：

- 创建 [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
- 获取幻灯片的引用。
- 设置过渡效果。
- 将演示文稿写入 [PPTX ](https://docs.fileformat.com/presentation/pptx/)文件。

在下面给出的示例中，我们设置了过渡效果。

```py
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation(path + "AccessSlides.pptx") as presentation:

    # 设置效果
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CUT
    presentation.slides[0].slide_show_transition.value.from_black = True

    # 将演示文稿写入磁盘
    presentation.save("SetTransitionEffects_out.pptx", slides.export.SaveFormat.PPTX)
```