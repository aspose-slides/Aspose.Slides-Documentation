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
description: "使用 Aspose.Slides for .NET 快速复制 PowerPoint 幻灯片。遵循我们的清晰代码示例，在几秒钟内实现 PPT 自动生成，消除手动操作。"
---
## **介绍**

克隆是对某物进行完全复制的过程。Aspose.Slides 还允许您复制（克隆）任何幻灯片，然后将克隆的幻灯片插入到当前演示文稿或其他打开的演示文稿中。幻灯片克隆会创建一个新幻灯片，开发人员可以在不影响原始幻灯片的情况下进行修改。克隆幻灯片有多种方式：

- 在演示文稿末尾克隆。
- 在演示文稿的其他位置克隆。
- 在另一个演示文稿末尾克隆。
- 在另一个演示文稿的其他位置克隆。
- 将幻灯片及其母版一起克隆到另一个演示文稿中。

在 Aspose.Slides for .NET 中，`Presentation` 对象公开的幻灯片集合（`ISlide` 对象的集合）提供了 `AddClone` 和 `InsertClone` 方法，以执行上述幻灯片克隆操作。

## **在演示文稿末尾克隆幻灯片**

如果要克隆幻灯片并在同一演示文稿文件的现有幻灯片末尾使用它，请按照以下步骤使用 `AddClone` 方法：

1. 创建 `Presentation` 类的实例。
1. 通过引用 `Presentation` 对象公开的 Slides 集合来实例化 `ISlideCollection`。
1. 调用 `ISlideCollection` 对象公开的 `AddClone` 方法，并将要克隆的幻灯片作为参数传递给 `AddClone` 方法。
1. 写入修改后的演示文稿文件。

下面的示例中，我们将演示文稿中第一个位置（索引为 0）的幻灯片克隆到演示文稿的末尾。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // 将所需幻灯片克隆到同一演示文稿的幻灯片集合末尾
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // 将修改后的演示文稿保存到磁盘
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **在演示文稿的另一个位置克隆幻灯片**
如果要克隆幻灯片并在同一演示文稿文件的不同位置使用它，请使用 `InsertClone` 方法：

1. 创建 `Presentation` 类的实例。
1. 通过引用 `Presentation` 对象公开的 **Slides** 集合来实例化类。
1. 调用 `ISlideCollection` 对象公开的 `InsertClone` 方法，并将要克隆的幻灯片以及新位置的索引作为参数传递给 `InsertClone` 方法。
1. 将修改后的演示文稿写为 PPTX 文件。

下面的示例中，我们将演示文稿中索引为 1（位置 2）的幻灯片克隆到索引 2（位置 3）。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // 将所需幻灯片克隆到同一演示文稿的幻灯片集合末尾
    ISlideCollection slds = pres.Slides;

    // 将所需幻灯片克隆到同一演示文稿的指定索引位置
    slds.InsertClone(2, pres.Slides[1]);

    // 将修改后的演示文稿保存到磁盘
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **在另一个演示文稿末尾克隆幻灯片**
如果需要从一个演示文稿克隆幻灯片并在另一个演示文稿文件的现有幻灯片末尾使用它：

1. 创建包含要克隆幻灯片的源演示文稿的 `Presentation` 实例。
1. 创建包含目标演示文稿的 `Presentation` 实例，克隆的幻灯片将被添加到该演示文稿。
1. 通过引用目标演示文稿的 `Presentation` 对象公开的 **Slides** 集合来实例化 `ISlideCollection`。
1. 调用 `ISlideCollection` 对象公开的 `AddClone` 方法，并将源演示文稿中的幻灯片作为参数传递给 `AddClone` 方法。
1. 写入修改后的目标演示文稿文件。

下面的示例中，我们将源演示文稿中第一个索引的幻灯片克隆到目标演示文稿的末尾。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化 Presentation 类以加载源演示文稿文件
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 实例化用于目标 PPTX 的 Presentation 类（要克隆幻灯片的地方）
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
如果需要从一个演示文稿克隆幻灯片并在另一个演示文稿文件的特定位置使用它：

1. 创建包含源演示文稿的 `Presentation` 实例，幻灯片将从该演示文稿克隆。
1. 创建包含目标演示文稿的 `Presentation` 实例，幻灯片将被添加到该演示文稿。
1. 通过引用目标演示文稿的 `Presentation` 对象公开的 Slides 集合来实例化 `ISlideCollection`。
1. 调用 `ISlideCollection` 对象公开的 `InsertClone` 方法，并将源演示文稿中的幻灯片以及期望的位置作为参数传递给 `InsertClone` 方法。
1. 写入修改后的目标演示文稿文件。

下面的示例中，我们将源演示文稿中索引为 0 的幻灯片克隆到目标演示文稿的索引 1（位置 2）。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化 Presentation 类以加载源演示文稿文件
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 实例化用于目标 PPTX 的 Presentation 类（要克隆幻灯片的地方）
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // 将目标演示文稿写入磁盘
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **将幻灯片及其母版克隆到另一个演示文稿**
如果需要从一个演示文稿克隆带有母版的幻灯片并在另一个演示文稿中使用，首先需要先将源演示文稿中的目标母版克隆到目标演示文稿。随后使用该母版来克隆带母版的幻灯片。`AddClone(ISlide, IMasterSlide)` 需要的是目标演示文稿中的母版，而不是源演示文稿中的母版。按照以下步骤克隆带母版的幻灯片：

1. 创建包含源演示文稿的 `Presentation` 实例，幻灯片将从该演示文稿克隆。
1. 创建包含目标演示文稿的 `Presentation` 实例，幻灯片将被克隆到该演示文稿。
1. 获取要克隆的幻灯片及其母版。
1. 通过引用目标演示文稿的 `Presentation` 对象公开的 Masters 集合来实例化 `IMasterSlideCollection`。
1. 调用 `IMasterSlideCollection` 对象公开的 `AddClone` 方法，并将源 PPTX 中的母版作为参数传递给 `AddClone` 方法。
1. 通过引用目标演示文稿的 `Presentation` 对象公开的 Slides 集合来实例化 `ISlideCollection`。
1. 调用 `ISlideCollection` 对象公开的 `AddClone` 方法，并将源演示文稿中的幻灯片和克隆后的母版作为参数传递给 `AddClone` 方法。
1. 写入修改后的目标演示文稿文件。

下面的示例中，我们将源演示文稿中索引为 0 的幻灯片（带母版）克隆到目标演示文稿的末尾，使用的是源幻灯片的母版。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化 Presentation 类以加载源演示文稿文件

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // 实例化用于目标演示文稿的 Presentation 类（要克隆幻灯片的地方）
    using (Presentation destPres = new Presentation())
    {

        // 从源演示文稿的幻灯片集合中实例化 ISlide 并且
        // 母版幻灯片
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 将所需母版幻灯片从源演示文稿克隆到该演示文稿的母版集合中
        // 目标演示文稿
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 将所需母版幻灯片从源演示文稿克隆到该演示文稿的母版集合中
        // 目标演示文稿
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // 将所需幻灯片从源演示文稿使用所需母版克隆到目标演示文稿的幻灯片集合末尾
        // 目标演示文稿的幻灯片集合中
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // 将所需母版幻灯片从源演示文稿克隆到该演示文稿的母版集合中 // 目标演示文稿
        // 将目标演示文稿保存到磁盘
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **在指定章节的末尾克隆幻灯片**

使用 Aspose.Slides for .NET，您可以从演示文稿的一个章节克隆幻灯片并将其插入同一演示文稿的另一个章节。此时需要使用 `ISlideCollection` 接口的 `AddClone` 方法。

下面的 C# 代码演示了如何克隆幻灯片并将克隆后的幻灯片插入指定章节：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **确保幻灯片尺寸匹配**

在将幻灯片克隆到另一个演示文稿时，请确保目标演示文稿的幻灯片尺寸与源演示文稿相同。如果尺寸不同，Aspose.Slides 不会自动重新缩放克隆的形状——它们的原始坐标和尺寸将被保留，这可能导致内容错位或超出幻灯片边界。

在克隆母版和幻灯片之前，您可以先设置目标演示文稿的幻灯片尺寸以匹配源演示文稿：

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

在克隆母版和幻灯片之前执行此操作。

## **常见问题**

**演讲者备注和审阅者评论会被克隆吗？**

会。备注页和审阅评论都会包含在克隆中。如果不需要它们，请在插入后 [删除它们](/slides/zh/net/presentation-notes/)。

**图表及其数据源如何处理？**

图表对象、格式以及嵌入的数据都会被复制。如果图表链接到外部源（例如 OLE 嵌入的工作簿），该链接会保留为一个 [OLE 对象](/slides/zh/net/manage-ole/)。在文件之间移动后，请验证数据的可用性并刷新行为。

**我可以控制克隆的插入位置和章节吗？**

可以。您可以在特定幻灯片索引处插入克隆，并将其放入选定的 [章节](/slides/zh/net/slide-section/)。如果目标章节不存在，请先创建章节，然后将幻灯片移动进去。