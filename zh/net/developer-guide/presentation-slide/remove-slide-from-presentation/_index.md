---
title: 删除幻灯片
type: docs
weight: 30
url: /zh/net/remove-slide-from-presentation/
keywords: "删除幻灯片, 删除幻灯片, PowerPoint, 演示文稿, C#, Csharp, .NET, Aspose.Slides"
description: "在 C# 或 .NET 中通过引用或索引从 PowerPoint 中删除幻灯片"
---

如果幻灯片（或其内容）变得多余，您可以将其删除。Aspose.Slides 提供了封装了 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类，后者是存放演示文稿中所有幻灯片的仓库。通过已知的 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) 对象的指针（引用或索引），您可以指定要移除的幻灯片。

## **通过引用删除幻灯片**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。  
1. 通过幻灯片的 ID 或索引获取要删除的幻灯片引用。  
1. 从演示文稿中移除该引用的幻灯片。  
1. 保存修改后的演示文稿。  

下面的 C# 代码展示了如何通过引用删除幻灯片：
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

下面的 C# 代码展示了如何通过索引删除幻灯片：
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

Aspose.Slides 提供了来自 [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) 类的 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 方法，帮助您删除不需要且未使用的布局幻灯片。下面的 C# 代码展示了如何从 PowerPoint 演示文稿中删除布局幻灯片：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **删除未使用的母版幻灯片**

Aspose.Slides 提供了来自 [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) 类的 [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) 方法，帮助您删除不需要且未使用的母版幻灯片。下面的 C# 代码展示了如何从 PowerPoint 演示文稿中删除母版幻灯片：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**删除幻灯片后幻灯片索引会怎样？**

删除后，_[collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/)_ 会重新索引：后续每个幻灯片左移一个位置，之前的索引号因此失效。如果需要稳定的引用，请使用每个幻灯片的持久 ID，而不是索引。

**幻灯片的 ID 与索引不同吗？在删除相邻幻灯片时会改变吗？**

是的。索引是幻灯片在演示文稿中的位置，新增或删除幻灯片会导致它变化。幻灯片 ID 是持久标识符，删除其他幻灯片时不会改变。

**删除幻灯片会如何影响幻灯片分区？**

如果该幻灯片属于某个分区，分区中将少一张幻灯片。分区结构保持不变；如果分区变为空，您可以[删除或重新组织分区](/slides/zh/net/slide-section/)。

**删除幻灯片时，附加在该幻灯片上的备注和评论会怎样？**

[Notes](/slides/zh/net/presentation-notes/) 和 [comments](/slides/zh/net/presentation-comments/) 与该幻灯片关联，会随幻灯片一起被删除。其他幻灯片的内容不受影响。

**删除幻灯片与清理未使用的布局/母版有何不同？**

删除操作是从文稿中移除特定的普通幻灯片。清理未使用的布局/母版是删除那些没有任何引用的布局或母版幻灯片，从而减小文件大小且不改变剩余幻灯片的内容。这两者是互补的：通常先删除幻灯片，然后再清理未使用的布局/母版。