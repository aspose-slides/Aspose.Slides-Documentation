---
title: 在 Java 中克隆演示文稿幻灯片
linktitle: 克隆幻灯片
type: docs
weight: 35
url: /zh/java/clone-slides/
keywords:
- 克隆幻灯片
- 复制幻灯片
- 保存幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 快速复制 PowerPoint 幻灯片。遵循我们清晰的代码示例，在几秒钟内实现 PPT 自动生成，消除手动工作。"
---
## **介绍**

克隆是创建某物的精确复制或副本的过程。Aspose.Slides for Java 还可以对任意幻灯片进行复制或克隆，然后将该克隆幻灯片插入当前或任何其他已打开的演示文稿中。幻灯片克隆过程会生成一个新幻灯片，开发人员可以对其进行修改，而不会更改原始幻灯片。克隆幻灯片有以下几种可能方式：

- 在演示文稿中末尾克隆。
- 在演示文稿中其他位置克隆。
- 在另一个演示文稿的末尾克隆。
- 在另一个演示文稿的其他位置克隆。
- 将幻灯片及其母版一起克隆到另一个演示文稿。

在 Aspose.Slides for Java 中，(由 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 对象公开的 [ISlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlide) 对象集合) 提供了 [addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 和 [insertClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，以执行上述类型的幻灯片克隆。

## **在演示文稿末尾克隆幻灯片**
如果要克隆幻灯片并在同一演示文稿文件的现有幻灯片末尾使用它，请按照以下步骤使用 [addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例。
1. 通过引用 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 对象公开的 Slides 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation#getSlides--) 类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将要克隆的幻灯片作为参数传递给该方法。
1. 写入修改后的演示文稿文件。

下面的示例中，我们将演示文稿中第一个位置（零索引）的幻灯片克隆到演示文稿的末尾。

```java
import com.aspose.slides.*;

// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 将所需幻灯片克隆到同一演示文稿的幻灯片集合末尾
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 将修改后的演示文稿写入磁盘
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在演示文稿中其他位置克隆幻灯片**
如果要克隆幻灯片并在同一演示文稿文件的不同位置使用它，请使用 [insertClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例。
1. 通过引用 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 对象公开的 **Slides** 集合实例化类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation#getSlides--) 对象公开的 [insertClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，并将要克隆的幻灯片以及新位置的索引作为参数传递给该方法。
1. 将修改后的演示文稿写入为 PPTX 文件。

下面的示例中，我们将演示文稿中索引 1（位置 2）的幻灯片克隆到索引 2（位置 3）。

```java
import com.aspose.slides.*;

// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 获取演示文稿中的幻灯片集合
    ISlideCollection slds = pres.getSlides();

    // 将所需幻灯片克隆到同一演示文稿的指定索引位置
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 将修改后的演示文稿写入磁盘
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在另一个演示文稿的末尾克隆幻灯片**
如果需要从一个演示文稿克隆幻灯片并在另一个演示文稿文件的现有幻灯片末尾使用它：

1. 创建一个包含源演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例。
1. 创建一个包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例。
1. 通过引用目标演示文稿的 Presentation 对象公开的 **Slides** 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlideCollection) 类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将源演示文稿中的幻灯片作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

下面的示例中，我们将源演示文稿第一个索引的幻灯片克隆到目标演示文稿的末尾。

```java
import com.aspose.slides.*;

// 实例化 Presentation 类以加载源演示文稿文件
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 实例化用于目标 PPTX 的 Presentation 类（要克隆幻灯片的地方）
    Presentation destPres = new Presentation();
    try {
        // 将所需幻灯片从源演示文稿克隆到目标演示文稿的幻灯片集合末尾
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // 将目标演示文稿写入磁盘
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在另一个演示文稿的其他位置克隆幻灯片**
如果需要从一个演示文稿克隆幻灯片并在另一个演示文稿文件的特定位置使用它：

1. 创建一个包含源演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例。
1. 创建一个包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例。
1. 通过引用目标演示文稿的 Presentation 对象公开的 Slides 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation#getSlides--) 类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation#getSlides--) 对象公开的 [insertClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，并将源演示文稿中的幻灯片以及期望的位置作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

下面的示例中，我们将源演示文稿零索引的幻灯片克隆到目标演示文稿索引 1（位置 2）。

```java
import com.aspose.slides.*;

// 实例化 Presentation 类以加载源演示文稿文件
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 实例化用于目标 PPTX 的 Presentation 类（要克隆幻灯片的地方）
    Presentation destPres = new Presentation();
    try {
        // 将所需幻灯片从源演示文稿克隆到目标演示文稿的指定索引位置
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // 将目标演示文稿写入磁盘
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **将幻灯片及其母版克隆到另一个演示文稿**
如果需要从一个演示文稿克隆幻灯片以及其母版并在另一个演示文稿中使用，首先需要将所需的母版从源演示文稿克隆到目标演示文稿。然后使用该母版进行带母版的幻灯片克隆。[**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 方法要求提供目标演示文稿中的母版，而不是源演示文稿中的母版。为克隆带母版的幻灯片，请按以下步骤操作：

1. 创建一个包含源演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例。
1. 创建一个包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例。
1. 访问待克隆的幻灯片及其母版。
1. 通过引用目标演示文稿的 Presentation 对象公开的 Masters 集合，实例化 [IMasterSlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IMasterSlideCollection) 类。
1. 调用 [IMasterSlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IMasterSlideCollection) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) 方法，并将源 PPTX 中要克隆的母版作为参数传递给该方法。
1. 通过引用目标演示文稿的 Presentation 对象公开的 Slides 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation#getSlides--) 类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) 方法，并将源演示文稿中的幻灯片和刚克隆的母版作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

下面的示例中，我们将源演示文稿零索引的幻灯片连同母版克隆到目标演示文稿的末尾（使用源幻灯片的母版）。

```java
import com.aspose.slides.*;

// 实例化 Presentation 类以加载源演示文稿文件
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 实例化用于目标演示文稿的 Presentation 类（要克隆幻灯片的地方）
    Presentation destPres = new Presentation();
    try {
        // 从源演示文稿的幻灯片集合中实例化 ISlide，连同
        // 母版幻灯片
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 将所需母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合中
        // Destination presentation
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // 将源演示文稿中带所需母版的幻灯片克隆到目标演示文稿的幻灯片集合末尾
        // Collection of slides in the destination presentation
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // 将目标演示文稿写入磁盘
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在指定章节的末尾克隆幻灯片**
如果要克隆幻灯片并在同一演示文稿文件的不同章节使用它，请使用由 [**ISlideCollection**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlideCollection) 接口公开的 [**addClone**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 方法。Aspose.Slides for Java 支持从第一章节克隆幻灯片，然后将该克隆幻灯片插入同一演示文稿的第二章节。

以下代码片段演示了如何克隆幻灯片并将克隆的幻灯片插入指定章节。

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // 将目标演示文稿保存到磁盘
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **确保幻灯片尺寸匹配**

在将幻灯片克隆到另一个演示文稿时，请确保目标演示文稿的幻灯片尺寸与源演示文稿相同。如果尺寸不同，Aspose.Slides 不会自动重新缩放克隆的形状——它们的原始坐标和尺寸会被保留，这可能导致内容错位或超出幻灯片边界。

在克隆母版和幻灯片之前，您可以将目标演示文稿的幻灯片尺寸设置为与源演示文稿匹配：

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

请在克隆母版和幻灯片之前执行上述操作。

## **常见问题解答**

**演讲者备注和审阅者评论会被克隆吗？**

会。备注页和审阅评论会包含在克隆中。如果不需要它们，请在插入后 [删除它们](/slides/zh/java/presentation-notes/)。

**图表及其数据源如何处理？**

图表对象、格式以及嵌入的数据都会被复制。如果图表链接到外部源（例如 OLE 嵌入的工作簿），该链接会保留为 [OLE 对象](/slides/zh/java/manage-ole/)。在文件之间移动后，请验证数据可用性并检查刷新行为。

**我可以控制克隆的插入位置和章节吗？**

可以。您可以在特定幻灯片索引处插入克隆，并将其放入选定的 [章节](/slides/zh/java/slide-section/)。如果目标章节不存在，请先创建，然后再将幻灯片移动到该章节。