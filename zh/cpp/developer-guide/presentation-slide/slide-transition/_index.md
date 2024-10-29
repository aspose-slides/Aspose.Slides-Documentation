---
title: 幻灯片过渡
type: docs
weight: 80
url: /zh/cpp/slide-transition/
keywords: "PowerPoint 幻灯片过渡, morph 过渡"
description: "PowerPoint 幻灯片过渡, 使用 Aspose.Slides 的 PowerPoint morph 过渡。"
---

## **添加幻灯片过渡**
为了更容易理解，我们展示了如何使用 Aspose.Slides for C++ 来管理简单的幻灯片过渡。开发人员不仅可以在幻灯片上应用不同的幻灯片过渡效果，还可以自定义这些过渡效果的行为。要创建简单的幻灯片过渡效果，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 通过 TransitionType 枚举在幻灯片上应用 Aspose.Slides for C++ 提供的过渡效果之一的幻灯片过渡类型。
1. 写入修改后的演示文稿文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **添加高级幻灯片过渡**
在上述部分中，我们仅在幻灯片上应用了简单的过渡效果。现在，为了使这个简单的过渡效果更加出色和可控，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 从 Aspose.Slides for C++ 提供的过渡效果之一在幻灯片上应用幻灯片过渡类型。
1. 您还可以设置过渡为点击时推进、经过特定时间后推进或两者兼具。
1. 如果幻灯片过渡被启用为点击时推进，过渡仅在有人点击鼠标时推进。此外，如果设置了经过时间后推进属性，过渡将在指定的推进时间经过后自动推进。
1. 将修改后的演示文稿写入演示文稿文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Morph 过渡**
Aspose.Slides for C++ 现在支持 Morph 过渡。它们表示在 PowerPoint 2019 中引入的新 morph 过渡。Morph 过渡允许您在一个幻灯片和下一个幻灯片之间顺畅地移动动画。本文描述了这一概念以及如何使用 Morph 过渡。要有效使用 Morph 过渡，您需要有两个幻灯片，并且至少有一个共同的对象。最简单的方法是复制幻灯片，然后将第二个幻灯片上的对象移动到不同的位置。

以下代码片段向您展示如何向演示文稿中添加一个带有一些文本的幻灯片克隆，并将第二个幻灯片设置为 morph 类型的过渡。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Morph 过渡类型**
新增的 Aspose.Slides.SlideShow.TransitionMorphType 枚举已添加。它表示不同类型的 Morph 幻灯片过渡。

TransitionMorphType 枚举有三个成员：

- ByObject: Morph 过渡将考虑形状作为不可分割的对象执行。
- ByWord: Morph 过渡将在可能的情况下按单词转移文本。
- ByChar: Morph 过渡将在可能的情况下按字符转移文本。

以下代码片段向您展示如何将 morph 过渡设置为幻灯片并更改 morph 类型：

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **设置过渡效果**
Aspose.Slides for C++ 支持设置过渡效果，例如从黑色、从左侧、从右侧等。为了设置过渡效果，请按照以下步骤操作：

- 创建一个 Presentation 类的实例。
- 获取幻灯片的引用。
- 设置过渡效果。
- 将演示文稿写入 PPTX 文件。

在下面给出的示例中，我们设置了过渡效果。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}