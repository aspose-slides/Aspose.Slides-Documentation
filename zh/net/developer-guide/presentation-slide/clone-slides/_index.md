---
title: 克隆幻灯片
type: docs
weight: 40
url: /zh/net/clone-slides/
keywords: "克隆幻灯片, 复制幻灯片, 保存幻灯片副本, PowerPoint, 演示文稿, C#, Csharp, .NET, Aspose.Slides"
description: "在 C# 或 .NET 中克隆 PowerPoint 幻灯片"
---

## **在演示文稿中克隆幻灯片**
克隆是将某物制作成完全相同的副本或复制品的过程。Aspose.Slides for .NET 也可以复制任意幻灯片，然后将该克隆幻灯片插入到当前或任何其他已打开的演示文稿中。幻灯片克隆过程会创建一个新幻灯片，开发人员可以对其进行修改而不影响原始幻灯片。有多种克隆幻灯片的方式：

- 在演示文稿中末尾克隆。
- 在演示文稿中其他位置克隆。
- 在另一个演示文稿的末尾克隆。
- 在另一个演示文稿的其他位置克隆。
- 在另一个演示文稿的特定位置克隆。

在 Aspose.Slides for .NET 中，由 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象公开的（一个包含 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 对象的集合）提供了 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 和 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法，以实现上述幻灯片克隆类型。

## **在演示文稿中末尾克隆**
如果您想克隆幻灯片并将其放置在同一演示文稿文件的现有幻灯片末尾，请按照下列步骤使用 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过引用由 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象公开的 Slides 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象公开的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法，并将要克隆的幻灯片作为参数传递给该方法。
1. 写入修改后的演示文稿文件。

在下面的示例中，我们已将演示文稿中位于第一位置（零索引）的幻灯片克隆到演示文稿的末尾。
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


## **在演示文稿中其他位置克隆**
如果您想克隆幻灯片并将其放置在同一演示文稿文件的其他位置，请使用 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 实例化通过 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象公开的 **Slides** 集合的类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象公开的 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法，并将要克隆的幻灯片以及新位置的索引作为参数传递给该方法。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们已将演示文稿中位于零索引（位置 1）的幻灯片克隆到索引 1（位置 2）。
```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // 将所需幻灯片克隆到同一演示文稿中幻灯片集合的末尾
    ISlideCollection slds = pres.Slides;

    // 将所需幻灯片克隆到同一演示文稿中的指定索引位置
    slds.InsertClone(2, pres.Slides[1]);

    // 将修改后的演示文稿写入磁盘
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **在另一个演示文稿的末尾克隆**
如果您需要从一个演示文稿克隆幻灯片并将其放置在另一个演示文稿文件的现有幻灯片末尾：

1. 创建包含源幻灯片的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 创建包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过引用目标演示文稿的 Presentation 对象公开的 **Slides** 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象公开的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法，并将源演示文稿中的幻灯片作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们已将源演示文稿的第一索引幻灯片克隆到目标演示文稿的末尾。
```c#
// 实例化 Presentation 类以加载源演示文稿文件
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 实例化目标 PPTX 的 Presentation 类（用于克隆幻灯片）
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


## **在另一个演示文稿的其他位置克隆**
如果您需要从一个演示文稿克隆幻灯片并将其放置在另一个演示文稿文件的特定位置：

1. 创建包含源幻灯片的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 创建包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过引用目标演示文稿的 Presentation 对象公开的 Slides 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象公开的 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法，并将源演示文稿中的幻灯片以及期望的位置作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们已将源演示文稿零索引处的幻灯片克隆到目标演示文稿的索引 1（位置 2）。
```c#
// 实例化 Presentation 类以加载源演示文稿文件
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 实例化目标 PPTX 的 Presentation 类（用于克隆幻灯片）
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // 将目标演示文稿写入磁盘
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **在另一个演示文稿的特定位置克隆（包含母版）**
如果您需要克隆带有母版的幻灯片并在另一个演示文稿中使用，必须先将源演示文稿中所需的母版克隆到目标演示文稿，然后使用该母版克隆幻灯片。**AddClone(ISlide, IMasterSlide)** 期望的母版来自目标演示文稿而不是源演示文稿。请按以下步骤操作：

1. 创建包含源幻灯片的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 创建包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 获取要克隆的幻灯片以及其母版。
1. 通过引用目标演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象公开的 Masters 集合，实例化 [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) 类。
1. 调用 [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) 对象公开的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法，并将源 PPTX 中的母版作为参数传递给该方法。
1. 通过设置对目标演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象公开的 Slides 集合的引用，实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象公开的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法，并将源演示文稿中的幻灯片和目标母版作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们已将源演示文稿零索引处带母版的幻灯片克隆到目标演示文稿的末尾，使用了源幻灯片的母版。
```c#
// 实例化 Presentation 类以加载源演示文稿文件

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // 实例化目标演示文稿的 Presentation 类（用于克隆幻灯片）
    using (Presentation destPres = new Presentation())
    {

        // 从源演示文稿的幻灯片集合中实例化 ISlide，连同
        // 母版幻灯片
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 将所需母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合中
        // 目标演示文稿
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 将所需母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合中
        // 目标演示文稿
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // 将所需幻灯片（使用所需母版）从源演示文稿克隆到目标演示文稿的幻灯片集合末尾
        // 目标演示文稿的幻灯片集合
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // 将所需母版幻灯片从源演示文稿克隆到母版集合中 // 目标演示文稿
        // 将目标演示文稿保存到磁盘
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```


## **在指定分区的末尾克隆**
使用 Aspose.Slides for .NET，您可以从演示文稿的一个分区克隆幻灯片并将其插入同一演示文稿的另一个分区。在这种情况下，需要使用 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 接口的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法。

下面的 C# 代码演示了如何克隆幻灯片并将克隆的幻灯片插入到指定分区：
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

**是否会克隆演讲者备注和审阅者评论？**

会。备注页和审阅评论会包含在克隆中。如果不需要它们，请在插入后 [删除它们](/slides/zh/net/presentation-notes/)。

**图表及其数据源如何处理？**

图表对象、格式以及嵌入的数据都会被复制。如果图表链接到外部来源（例如 OLE 嵌入的工作簿），该链接会保留为 [OLE 对象](/slides/zh/net/manage-ole/)。在文件之间移动后，请验证数据可用性并刷新行为。

**我可以控制克隆的插入位置和分区吗？**

可以。您可以在特定幻灯片索引处插入克隆，并将其放入选定的 [分区](/slides/zh/net/slide-section/)。如果目标分区不存在，请先创建，然后将幻灯片移动到该分区。