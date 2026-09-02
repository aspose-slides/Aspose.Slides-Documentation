---
title: 在 C++ 中克隆演示文稿幻灯片
linktitle: 克隆幻灯片
type: docs
weight: 40
url: /zh/cpp/clone-slides/
keywords:
- 克隆幻灯片
- 复制幻灯片
- 保存幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 快速复制 PowerPoint 幻灯片。通过我们的清晰代码示例，在几秒钟内实现 PPT 自动化创建，消除手动操作。"
---
## **介绍**

克隆是对某物进行精确复制或复本的过程。Aspose.Slides for C++ 也可以对任意幻灯片进行复制或克隆，然后将该克隆幻灯片插入当前或任何其他已打开的演示文稿。幻灯片克隆过程会创建一个新幻灯片，开发者可以对其进行修改，而不会更改原始幻灯片。克隆幻灯片有多种可能的方式：

- 在演示文稿中末尾克隆。
- 在演示文稿中其他位置克隆。
- 在另一个演示文稿的末尾克隆。
- 在另一个演示文稿的其他位置克隆。
- 在另一个演示文稿的特定位置克隆。

在 Aspose.Slides for C++ 中，(由 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 对象公开的 [ISlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/) 对象集合) 提供了 [AddClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/) 和 [InsertClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/insertclone/) 方法，以执行上述类型的幻灯片克隆

## **在演示文稿末尾克隆幻灯片**
如果希望克隆幻灯片并在同一演示文稿文件的现有幻灯片末尾使用它，请按照以下步骤使用 [AddClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/) 方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。
1. 通过引用由 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 对象公开的 Slides 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/) 类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/) 对象公开的 [AddClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/) 方法，并将要克隆的幻灯片作为参数传递给该方法。
1. 写入修改后的演示文稿文件。

在下面的示例中，我们将演示文稿中位于第一个位置（索引为 0）的幻灯片克隆到演示文稿的末尾。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **在演示文稿中其他位置克隆幻灯片**
如果希望克隆幻灯片并在同一演示文稿文件的不同位置使用它，请使用 [InsertClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/insertclone/) 方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。
1. 通过引用由 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 对象公开的 **Slides** 集合实例化相应类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/) 对象公开的 [InsertClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/insertclone/) 方法，并将要克隆的幻灯片以及新位置的索引作为参数传递给该方法。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们将演示文稿中位于索引 0（位置 1）的幻灯片克隆到索引 1（位置 2）。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **在另一个演示文稿的末尾克隆幻灯片**
如果需要从一个演示文稿克隆幻灯片并在另一个演示文稿文件的现有幻灯片末尾使用它：

1. 创建一个包含源演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类实例。
1. 创建一个包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类实例。
1. 通过引用目标演示文稿的 **Slides** 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/) 类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/) 对象公开的 [AddClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/) 方法，并将源演示文稿中的幻灯片作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将源演示文稿中索引为 0 的幻灯片克隆到目标演示文稿的末尾。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **在另一个演示文稿的其他位置克隆幻灯片**
如果需要从一个演示文稿克隆幻灯片并在另一个演示文稿文件的特定位置使用它：

1. 创建一个包含源演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类实例。
1. 创建一个包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类实例。
1. 通过引用目标演示文稿的 Slides 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/) 类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/) 对象公开的 [InsertClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/insertclone/) 方法，并将源演示文稿中的幻灯片以及期望的位置作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将源演示文稿中索引为 0 的幻灯片克隆到目标演示文稿的索引 1（位置 2）。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **在另一个演示文稿的特定位置克隆带母版的幻灯片**
如果需要将带母版的幻灯片从一个演示文稿克隆并在另一个演示文稿中使用，首先必须将所需的母版从源演示文稿克隆到目标演示文稿。随后使用该母版克隆带母版的幻灯片。**AddClone(ISlide, IMasterSlide)** 需要目标演示文稿中的母版，而不是源演示文稿中的母版。请按以下步骤克隆带母版的幻灯片：

1. 创建一个包含源演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类实例。
1. 创建一个包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类实例。
1. 访问待克隆的幻灯片及其母版。
1. 通过引用目标演示文稿的 Masters 集合，实例化 [IMasterSlideCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterslidecollection/) 类。
1. 调用由 [IMasterSlideCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterslidecollection/) 对象公开的 [AddClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/) 方法，并将源 PPTX 中的母版作为参数传递给该方法。
1. 通过引用目标演示文稿的 Slides 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/) 类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/) 对象公开的 [AddClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/) 方法，并将源演示文稿中的幻灯片及其母版作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将源演示文稿中索引为 0 的带母版幻灯片克隆到目标演示文稿的末尾，使用源幻灯片的母版。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **在指定章节的末尾克隆幻灯片**
如果希望克隆幻灯片并在同一演示文稿的不同章节使用它，请使用由 [ISlideCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/) 接口公开的 [**AddClone()**](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/) 方法。Aspose.Slides for C++ 可以克隆第一章节的幻灯片，然后将该克隆幻灯片插入同一演示文稿的第二章节。

以下代码片段演示了如何克隆幻灯片并将克隆的幻灯片插入指定章节。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **确保幻灯片尺寸匹配**

在将幻灯片克隆到另一个演示文稿时，请确保目标演示文稿的幻灯片尺寸与源演示文稿相同。如果尺寸不一致，Aspose.Slides 不会自动重新缩放克隆的形状——它们的原始坐标和尺寸会被保留，可能导致内容错位或超出幻灯片边界。

在克隆母版和幻灯片之前，可以先将目标演示文稿的幻灯片尺寸设置为与源演示文稿匹配：

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

在克隆母版和幻灯片之前执行此操作。

## **FAQ**

**演讲者备注和审阅者批注会被克隆吗？**

会。备注页和审阅批注会随克隆一起复制。如果不需要它们，请在插入后 [删除它们](/slides/zh/cpp/presentation-notes/)。

**图表及其数据源如何处理？**

图表对象、格式以及嵌入的数据都会被复制。如果图表链接到外部源（例如 OLE 嵌入的工作簿），该链接会以 OLE 对象的形式保留 [/slides/zh/cpp/manage-ole/]。在文件之间移动后，请验证数据可用性并刷新行为。

**我可以控制克隆的插入位置和章节吗？**

可以。您可以在特定幻灯片索引处插入克隆，并将其放入选定的 [section](/slides/zh/cpp/slide-section/)。如果目标章节不存在，请先创建章节，然后再将幻灯片移动进去。