---
title: 克隆幻灯片
type: docs
weight: 40
url: /zh/net/clone-slides/
keywords: "克隆幻灯片, 复制幻灯片, 保存幻灯片副本, PowerPoint, 演示文稿, C#, Csharp, .NET, Aspose.Slides"
description: "在 C# 或 .NET 中克隆 PowerPoint 幻灯片"
---

## **在演示文稿中克隆幻灯片**
克隆是制作某物的精确副本或复制品的过程。Aspose.Slides for .NET 还可以克隆任何幻灯片，然后将该克隆的幻灯片插入到当前或任何其他打开的演示文稿中。幻灯片克隆的过程会创建一个新幻灯片，开发人员可以对其进行修改，而不会更改原始幻灯片。克隆幻灯片有几种可能的方法：

- 在演示文稿末尾克隆。
- 在演示文稿中的其他位置克隆。
- 在另一个演示文稿的末尾克隆。
- 在另一个演示文稿中的其他位置克隆。
- 在另一个演示文稿中的特定位置克隆。

在 Aspose.Slides for .NET 中，由 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象公开的（一个 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 对象集合）提供了 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 和 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法以执行上述类型的幻灯片克隆。

## **在演示文稿末尾克隆**
如果您想克隆幻灯片并在现有幻灯片的末尾使用它，请按照以下步骤使用 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过引用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象公开的幻灯片集合实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象公开的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法，并将要克隆的幻灯片作为参数传递给 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法。
1. 写入修改后的演示文稿文件。

在下面的示例中，我们已经将一个幻灯片（位于演示文稿的第一个位置 - 零索引）克隆到演示文稿的末尾。

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

## **在演示文稿中的另一个位置克隆**
如果您想克隆幻灯片并在同一演示文稿文件中使用它但在不同的位置，请使用 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过引用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象公开的 **Slides** 集合实例化类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象公开的 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法，并将要克隆的幻灯片以及新位置的索引作为参数传递给 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们已经将一个幻灯片（位于零索引 - 位置 1 - 的演示文稿中）克隆到索引 1 - 位置 2 - 的演示文稿中。

```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // 将所需幻灯片克隆到同一演示文稿中幻灯片集合的末尾
    ISlideCollection slds = pres.Slides;

    // 将所需幻灯片克隆到同一演示文稿中的指定索引
    slds.InsertClone(2, pres.Slides[1]);

    // 将修改后的演示文稿写入磁盘
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **在另一个演示文稿的末尾克隆**
如果您需要从一个演示文稿中克隆幻灯片并在另一个演示文稿文件的末尾使用它：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例，其中包含要从中克隆幻灯片的演示文稿。
1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例，其中包含要添加幻灯片的目标演示文稿。
1. 通过引用目标演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象公开的 **Slides** 集合实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法并将源演示文稿中的幻灯片作为参数传递给 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们已将一个幻灯片（来自源演示文稿的第一个索引）克隆到目标演示文稿的末尾。

```c#
// 实例化用于加载源演示文稿文件的 Presentation 类
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 实例化用于目标 PPTX 的 Presentation 类（幻灯片将被克隆到此处）
    using (Presentation destPres = new Presentation())
    {
        // 将所需幻灯片从源演示文稿克隆到目标演示文稿中幻灯片集合的末尾
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // 将目标演示文稿写入磁盘
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **在另一个演示文稿中的另一个位置克隆**
如果您需要从一个演示文稿中克隆幻灯片并在另一个演示文稿文件中的特定位置使用它：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例，其中包含要从中克隆幻灯片的源演示文稿。
1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例，其中包含要添加幻灯片的演示文稿。
1. 通过引用目标演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象公开的幻灯片集合实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法并将源演示文稿中的幻灯片与所需位置作为参数传递给 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象的 [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) 方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将一个幻灯片（来自源演示文稿的零索引）克隆到目标演示文稿的索引 1（位置 2）。

```c#
// 实例化用于加载源演示文稿文件的 Presentation 类
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 实例化用于目标 PPTX 的 Presentation 类（幻灯片将被克隆到此处）
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // 将目标演示文稿写入磁盘
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **在另一个演示文稿中的特定位置克隆**
如果您需要从一个演示文稿中克隆一个带主幻灯片的幻灯片并在另一个演示文稿中使用它，您需要首先将所需的主幻灯片从源演示文稿克隆到目标演示文稿。然后，您需要使用该主幻灯片来克隆带有主幻灯片的幻灯片。**AddClone(ISlide, IMasterSlide)** 期望来自目标演示文稿的主幻灯片，而不是来自源演示文稿。为了克隆带主幻灯片的幻灯片，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例，其中包含要从中克隆幻灯片的源演示文稿。
1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例，其中包含要克隆幻灯片的目标演示文稿。
1. 访问要克隆的幻灯片及其主幻灯片。
1. 通过引用目标演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象公开的主幻灯片集合实例化 [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) 类。
1. 调用 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法并将源 PPTX 中要克隆的主幻灯片作为参数传递给 [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) 对象的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法。
1. 通过将引用设置为目标演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象公开的幻灯片集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
1. 调用 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法并将要克隆的源演示文稿中的幻灯片及主幻灯片作为参数传递给 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 对象的 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们已经克隆了一个带主幻灯片的幻灯片（位于源演示文稿的零索引）到目标演示文稿的末尾，并使用源幻灯片的主幻灯片。

```c#
// 实例化用于加载源演示文稿文件的 Presentation 类

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // 实例化用于目标演示文稿的 Presentation 类（幻灯片将被克隆到此处）
    using (Presentation destPres = new Presentation())
    {

        // 从源演示文稿的幻灯片集合中实例化 ISlide，连同
        // 主幻灯片
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 将所需的主幻灯片从源演示文稿克隆到目标演示文稿的主幻灯片集合中
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 将所需的主幻灯片从源演示文稿克隆到目标演示文稿的主幻灯片集合中
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // 将所需幻灯片从源演示文稿克隆到目标演示文稿幻灯片集合的末尾，并使用所需的主幻灯片
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // 从源演示文稿克隆所需主幻灯片到目标演示文稿的主幻灯片集合
        // 将目标演示文稿保存到磁盘
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## 在指定部分的末尾克隆

使用 Aspose.Slides for .NET，您可以从演示文稿的一个部分克隆幻灯片，并将该幻灯片插入到同一演示文稿的另一个部分。在这种情况下，您必须使用 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) 方法从 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 接口。 

以下 C# 代码展示了如何克隆幻灯片并将克隆的幻灯片插入到指定部分：

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