---
title: 克隆幻灯片
type: docs
weight: 40
url: /cpp/clone-slides/
---


## **在演示文稿中克隆幻灯片**
克隆是制作某物精确副本或复制的过程。Aspose.Slides for C++ 也使得可以复制或克隆任何幻灯片，然后将该克隆幻灯片插入到当前或任何其他打开的演示文稿中。幻灯片克隆的过程会创建一个新幻灯片，开发人员可以修改而不改变原始幻灯片。有几个可能的方式来克隆幻灯片：

- 在演示文稿末尾克隆。
- 在演示文稿中的其他位置克隆。
- 在另一个演示文稿的末尾克隆。
- 在另一个演示文稿中的其他位置克隆。
- 在另一个演示文稿中的特定位置克隆。

在 Aspose.Slides for C++ 中，由 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象暴露的一组 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 对象提供了 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) 和 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) 方法来执行上述类型的幻灯片克隆。

## **在演示文稿末尾克隆**
如果您想克隆一张幻灯片并将其用在同一演示文稿文件中现有幻灯片的末尾，请按照以下步骤使用 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过引用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象暴露的幻灯片集合实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象暴露的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) 方法，并将要克隆的幻灯片作为参数传递给 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) 方法。
1. 写入修改后的演示文稿文件。

在下面的示例中，我们将一张位于演示文稿第一个位置（零索引）的幻灯片克隆到演示文稿的末尾。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}


## **在演示文稿中的其他位置克隆**
如果您想克隆一张幻灯片并将其用在同一演示文稿文件但在不同位置，请使用 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过引用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象暴露的 **Slides** 集合实例化该类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象暴露的 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) 方法，并将要克隆的幻灯片以及新位置的索引作为参数传递给 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) 方法。
1. 将修改后的演示文稿作为 PPTX 文件写入。

在下面的示例中，我们将一张位于零索引（位置 1）的幻灯片克隆到演示文稿的索引 1（位置 2）。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **将幻灯片克隆到另一个演示文稿的末尾**
如果您需要从一个演示文稿克隆一张幻灯片并在另一个演示文稿文件中的现有幻灯片末尾使用它：

1. 创建包含将要克隆幻灯片的源演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 创建包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例，该演示文稿将添加幻灯片。
1. 通过引用目标演示文稿的 **Slides** 集合实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象暴露的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) 方法，并将源演示文稿中的幻灯片作为参数传递给 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) 方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将一张来自源演示文稿第一个索引的幻灯片克隆到目标演示文稿的末尾。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **将幻灯片克隆到另一个演示文稿的其他位置**
如果您需要从一个演示文稿克隆一张幻灯片并在另一个演示文稿文件中特定位置使用它：

1. 创建包含要克隆幻灯片的源演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 创建包含将要添加幻灯片的目标演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过引用目标演示文稿的 Slides 集合实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象暴露的 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) 方法，并将源演示文稿中的幻灯片及所需位置作为参数传递给 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) 方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将一张源演示文稿中的幻灯片（零索引）克隆到目标演示文稿的索引 1（位置 2）。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}
## **在另一个演示文稿的特定位置克隆幻灯片**
如果您需要从一个演示文稿克隆带母版幻灯片的幻灯片并在另一个演示文稿中使用它，您需要先将所需的母版幻灯片从源演示文稿克隆到目标演示文稿。然后，您需要使用该母版幻灯片来克隆带母版的幻灯片。**AddClone(ISlide, IMasterSlide)** 期望的是来自目标演示文稿的母版幻灯片，而不是来自源演示文稿的。为了克隆带母版的幻灯片，请按照以下步骤操作：

1. 创建包含将要克隆幻灯片的源演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 创建包含将要克隆幻灯片的目标演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 访问要克隆的幻灯片及其母版幻灯片。
1. 通过引用目标演示文稿的母版集合实例化 [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection) 类。
1. 调用 [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection) 对象暴露的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) 方法，并将源 PPTX 中要克隆的母版作为参数传递给 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) 方法。
1. 通过设置对目标演示文稿的 Slides 集合的引用实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象暴露的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) 方法，并将源演示文稿中的幻灯片和母版作为参数传递给 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) 方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将带母版的幻灯片（位于源演示文稿的零索引）克隆到目标演示文稿的末尾，使用源幻灯片的母版。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}
## **将幻灯片克隆到指定部分**
如果您想克隆一张幻灯片并在同一演示文稿文件中的不同部分使用它，请使用 [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a46981dac8b18355531a04a70c70c444b) 方法， 该方法由 [**ISlideCollection** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection) 接口暴露。Aspose.Slides for C++ 使得可以从第一部分克隆幻灯片，然后将该克隆幻灯片插入到同一演示文稿的第二部分。

以下代码片段展示了如何克隆一张幻灯片并将克隆的幻灯片插入到指定部分。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}