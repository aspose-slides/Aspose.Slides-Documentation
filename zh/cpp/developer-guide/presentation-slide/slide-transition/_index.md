---
title: 使用 C++ 在演示文稿中管理幻灯片切换
linktitle: 幻灯片切换
type: docs
weight: 80
url: /zh/cpp/slide-transition/
keywords:
- 幻灯片切换
- 添加幻灯片切换
- 应用幻灯片切换
- 高级幻灯片切换
- Morph 切换
- 切换类型
- 切换效果
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中自定义幻灯片切换，提供针对 PowerPoint 和 OpenDocument 演示文稿的分步指导。"
---

## **添加幻灯片切换**
为了便于理解，我们演示了如何使用 Aspose.Slides for C++ 来管理简单的幻灯片切换。开发人员不仅可以在幻灯片上应用不同的切换效果，还可以自定义这些切换效果的行为。要创建一个简单的幻灯片切换效果，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 通过 TransitionType 枚举，从 Aspose.Slides for C++ 提供的切换效果中为幻灯片应用一种 Slide Transition Type。
1. 写入已修改的演示文稿文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **添加高级幻灯片切换**
在上一节中，我们仅在幻灯片上应用了一个简单的切换效果。现在，为了让该简易切换效果更加完善并可控，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 通过 Aspose.Slides for C++ 为幻灯片应用一种 Slide Transition Type。
1. 您还可以将切换设置为“单击后前进”、在特定时间后前进，或两者兼有。
1. 如果将幻灯片切换设为“单击后前进”，则只有在点击鼠标时切换才会进行。另外，如果设置了 Advance After Time 属性，切换将在指定的时间过去后自动前进。
1. 将已修改的演示文稿写入为演示文稿文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Morph 切换**
Aspose.Slides for C++ 现在支持 Morph 切换。它们对应 PowerPoint 2019 中新增的 Morph 切换。Morph 切换允许您在两张幻灯片之间实现平滑的动画移动。本文介绍了该概念以及如何使用 Morph 切换。要有效使用 Morph 切换，您需要两张至少有一个共同对象的幻灯片。最简单的做法是复制幻灯片，然后在第二张幻灯片上将对象移动到其他位置。

下面的代码片段演示了如何向演示文稿中添加带有文本的幻灯片克隆，并为第二张幻灯片设置 Morph 类型的切换。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Morph 切换类型**
新增了 Aspose.Slides.SlideShow.TransitionMorphType 枚举，表示不同类型的 Morph 幻灯片切换。

TransitionMorphType 枚举有三个成员：

- ByObject: 将形状视为不可分割的对象执行 Morph 切换。
- ByWord: 在可能的情况下，以单词为单位转移文本执行 Morph 切换。
- ByChar: 在可能的情况下，以字符为单位转移文本执行 Morph 切换。

下面的代码片段演示了如何为幻灯片设置 Morph 切换并更改 Morph 类型：

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **设置切换效果**
Aspose.Slides for C++ 支持设置诸如“从黑色”、 “从左侧”、 “从右侧”等切换效果。要设置切换效果，请按以下步骤操作：

- 创建一个 Presentation 类的实例。
- 获取幻灯片的引用。
- 设置切换效果。
- 将演示文稿写入为 PPTX 文件。

在下面的示例中，我们已经设置了切换效果。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **常见问题**

**我可以控制幻灯片切换的播放速度吗？**

可以。使用 [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) 设置（例如 slow/medium/fast）来设置切换的 [speed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/)。

**我可以为切换附加音频并使其循环播放吗？**

可以。您可以为切换嵌入声音，并通过诸如 set_Sound、 set_SoundMode、 set_SoundLoop 等设置控制行为，还可以使用 set_SoundIsBuiltIn、 set_SoundName 等元数据。

**将相同的切换应用到每张幻灯片的最快方法是什么？**

在每张幻灯片的切换设置上配置所需的切换类型；切换是按幻灯片存储的，统一设置即可实现一致效果。

**如何检查当前幻灯片上设置了哪种切换？**

检查幻灯片的 [transition settings](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_slideshowtransition/) 并读取其 [transition type](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/get_type/)；该值即表明当前应用的切换效果。