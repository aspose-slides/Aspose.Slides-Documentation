---
title: 在 .NET 中克隆演示文稿幻灯片
linktitle: 克隆幻灯片
type: docs
weight: 40
url: /zh/net/clone-slides/
keywords:
- 克隆幻灯片
- 复制幻灯片
- 保存幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "快速使用 Aspose.Slides for .NET 复制 PowerPoint 幻灯片。按照我们的清晰代码示例，在几秒钟内实现 PPT 自动生成，消除手动工作。"
---

## **在演示文稿中克隆幻灯片**
克隆是对某物进行精确复制或复本的过程。Aspose.Slides for .NET 也可以对任意幻灯片进行复制或克隆，然后将该克隆幻灯片插入当前或其他已打开的演示文稿中。幻灯片克隆的过程会创建一个新幻灯片，开发者可以对其进行修改，而不会改变原始幻灯片。克隆幻灯片有多种方式：

- 在同一演示文稿的末尾克隆。
- 在演示文稿的其他位置克隆。
- 在另一个演示文稿的末尾克隆。
- 在另一个演示文稿的其他位置克隆。
- 在另一个演示文稿的特定位置克隆。

在 Aspose.Slides for .NET 中，由 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象公开的 (一组 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 对象) 提供了 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 和 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法来执行上述类型的幻灯片克隆。
## **在演示文稿末尾克隆幻灯片**
如果希望克隆幻灯片并将其放在同一演示文稿文件的现有幻灯片末尾，请按照下列步骤使用 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过引用由 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象公开的 Slides 集合来实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象公开的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法，并将要克隆的幻灯片作为参数传递给该方法。
1. 写入修改后的演示文稿文件。

在下例中，我们将位于演示文稿第一位置（索引 0）的幻灯片克隆到演示文稿的末尾。
```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // 将所需幻灯片克隆到同一演示文稿中幻灯片集合的末尾
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // 将修改后的演示文稿写入磁盘
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```



## **在同一演示文稿的其他位置克隆幻灯片**
如果希望克隆幻灯片并将其放在同一演示文稿文件的其他位置，请使用 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过引用由 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象公开的 **Slides** 集合来实例化该类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象公开的 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法，并将要克隆的幻灯片以及新位置的索引作为参数传递给该方法。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下例中，我们将位于演示文稿零索引（位置 1）的幻灯片克隆到索引 1（位置 2）。
```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // 将所需幻灯片克隆到同一演示文稿中幻灯片集合的末尾
    ISlideCollection slds = pres.Slides;

    // 将所需幻灯片克隆到同一演示文稿的指定索引
    slds.InsertClone(2, pres.Slides[1]);

    // 将修改后的演示文稿写入磁盘
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```



## **在另一个演示文稿的末尾克隆幻灯片**
如果需要从一个演示文稿克隆幻灯片并将其放入另一个演示文稿文件的现有幻灯片末尾：

1. 创建一个包含要克隆来源幻灯片的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 创建一个包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过引用目标演示文稿的 **Slides** 集合来实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象公开的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法，并将来源演示文稿中的幻灯片作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下例中，我们将来源演示文稿第一索引的幻灯片克隆到目标演示文稿的末尾。
```c#
// 实例化 Presentation 类以加载源演示文稿文件
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 实例化用于目标 PPTX（要克隆幻灯片的地方）的 Presentation 类
    using (Presentation destPres = new Presentation())
    {
        // 将所需幻灯片从源演示文稿克隆到目标演示文稿的幻灯片集合末尾
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // 将目标演示文稿写入磁盘
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```



## **在另一个演示文稿的其他位置克隆幻灯片**
如果需要从一个演示文稿克隆幻灯片并将其放入另一个演示文稿文件的特定位置：

1. 创建一个包含来源演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 创建一个包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过引用目标演示文稿的 Slides 集合来实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象公开的 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法，并将来源演示文稿的幻灯片以及期望的位置作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下例中，我们将来源演示文稿零索引的幻灯片克隆到目标演示文稿的索引 1（位置 2）。
```c#
// 实例化 Presentation 类以加载源演示文稿文件
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 实例化用于目标 PPTX（要克隆幻灯片的地方）的 Presentation 类
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // 将目标演示文稿写入磁盘
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```



## **在另一个演示文稿的特定位置克隆幻灯片**
如果需要将带有母版的幻灯片从一个演示文稿克隆到另一个演示文稿，必须先将所需的母版从来源演示文稿克隆到目标演示文稿，然后使用该母版克隆幻灯片。**AddClone(ISlide, IMasterSlide)** 需要目标演示文稿中的母版，而不是来源演示文稿中的母版。为克隆带母版的幻灯片，请按以下步骤操作：

1. 创建一个包含来源演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 创建一个包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 访问要克隆的幻灯片及其母版。
1. 通过引用目标演示文稿的 Masters 集合来实例化 [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) 类。
1. 调用由 [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) 对象公开的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法，并将来源 PPTX 中的母版作为参数传递给该方法。
1. 通过引用目标演示文稿的 Slides 集合来实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象公开的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法，并将来源演示文稿的幻灯片和母版作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下例中，我们将来源演示文稿零索引的带母版幻灯片克隆到目标演示文稿的末尾，使用来源幻灯片的母版。
```c#
// 实例化 Presentation 类以加载源演示文稿文件

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // 实例化用于目标演示文稿（要克隆幻灯片的地方）的 Presentation 类
    using (Presentation destPres = new Presentation())
    {

        // 实例化来自源演示文稿的幻灯片集合以及
        // 母版幻灯片
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 将所需的母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合中
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 将所需的母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合中
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // 将所需的幻灯片与所需的母版从源演示文稿克隆到目标演示文稿的幻灯片集合末尾
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // 将所需的母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合中 // 目标演示文稿
        // 将目标演示文稿写入磁盘
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```




## **在指定章节的末尾克隆幻灯片**

使用 Aspose.Slides for .NET，您可以将幻灯片从演示文稿的一个章节克隆并插入同一演示文稿的另一个章节。此时，需要使用 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 接口的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法。

以下 C# 代码演示如何克隆幻灯片并将克隆的幻灯片插入指定章节：
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // 用于克隆
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**演讲者备注和审阅者评论会被克隆吗？**

是的。备注页和审阅评论会随克隆一起复制。如果不想保留它们，请在插入后 [remove them](/slides/zh/net/presentation-notes/)。

**图表及其数据源如何处理？**

图表对象、格式以及嵌入的数据都会被复制。如果图表链接到外部源（例如 OLE 嵌入的工作簿），该链接会以 [OLE object](/slides/zh/net/manage-ole/) 的形式保留。文件迁移后，请验证数据是否可用并检查刷新行为。

**我可以控制克隆的插入位置和章节吗？**

可以。您可以在指定的幻灯片索引处插入克隆，并将其放入选定的 [section](/slides/zh/net/slide-section/)。如果目标章节不存在，请先创建章节，然后将幻灯片移动进去。