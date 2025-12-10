---
title: 在 .NET 中从演示文稿中删除幻灯片
linktitle: 删除幻灯片
type: docs
weight: 30
url: /zh/net/remove-slide-from-presentation/
keywords:
- 删除幻灯片
- 删除幻灯片
- 删除未使用的幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET，轻松从 PowerPoint 和 OpenDocument 演示文稿中删除幻灯片。获取清晰的 C# 代码示例，提升工作流。"
---

如果幻灯片（或其内容）变得多余，您可以将其删除。Aspose.Slides 提供了封装了 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类，它是演示文稿中所有幻灯片的存储库。使用已知的 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) 对象的指针（引用或索引），您可以指定要删除的幻灯片。

## **通过引用删除幻灯片**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过其 ID 或索引获取要删除的幻灯片的引用。
1. 从演示文稿中删除引用的幻灯片。
1. 保存修改后的演示文稿。

以下 C# 代码演示了如何通过引用删除幻灯片：
```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // 通过 slides 集合中的索引访问幻灯片
    ISlide slide = pres.Slides[0];

    // 通过引用删除幻灯片
    pres.Slides.Remove(slide);

    // 保存修改后的演示文稿
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **通过索引删除幻灯片**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过索引位置从演示文稿中删除幻灯片。
1. 保存修改后的演示文稿。

以下 C# 代码演示了如何通过索引删除幻灯片：
```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // 通过幻灯片索引删除幻灯片
    pres.Slides.RemoveAt(0);

    // 保存修改后的演示文稿
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **删除未使用的布局幻灯片**

Aspose.Slides 提供了来自 [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) 类的 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 方法，使您能够删除不需要的未使用布局幻灯片。以下 C# 代码演示了如何从 PowerPoint 演示文稿中删除布局幻灯片：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **删除未使用的母版幻灯片**

Aspose.Slides 提供了来自 [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) 类的 [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) 方法，使您能够删除不需要的未使用母版幻灯片。以下 C# 代码演示了如何从 PowerPoint 演示文稿中删除母版幻灯片：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **常见问题**

**删除幻灯片后幻灯片索引会发生什么？**

删除后，[collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) 会重新索引：每个后续幻灯片左移一个位置，因此之前的索引号不再有效。如果需要稳定的引用，请使用每个幻灯片的持久 ID 而不是其索引。

**幻灯片的 ID 与索引不同吗？当相邻幻灯片被删除时它会变化吗？**

是的。索引是幻灯片的位置，会在添加或删除幻灯片时变化。幻灯片 ID 是持久标识符，在删除其他幻灯片时不会改变。

**删除幻灯片会如何影响幻灯片章节？**

如果幻灯片属于某个章节，该章节的幻灯片数量会减少一个。章节结构保持不变；如果章节变为空，您可以[删除或重新组织章节](/slides/zh/net/slide-section/)。

**删除幻灯片时，附加的备注和评论会怎样？**

[Notes](/slides/zh/net/presentation-notes/) 和 [comments](/slides/zh/net/presentation-comments/) 与特定幻灯片绑定，随其一起被删除。其他幻灯片的内容不受影响。

**删除幻灯片与清理未使用的布局/母版有什么区别？**

删除会从演示文稿中移除特定的普通幻灯片。清理未使用的布局/母版则是删除没有任何引用的布局或母版幻灯片，从而减小文件大小且不影响剩余幻灯片的内容。这两种操作是互补的：通常先删除，然后再清理。