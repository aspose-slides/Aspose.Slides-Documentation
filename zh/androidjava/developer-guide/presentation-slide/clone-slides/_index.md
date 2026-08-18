---
title: 在 Android 上克隆演示文稿幻灯片
linktitle: 克隆幻灯片
type: docs
weight: 35
url: /zh/androidjava/clone-slides/
keywords:
- 克隆幻灯片
- 复制幻灯片
- 保存幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 复制 PowerPoint 幻灯片。遵循我们清晰的 Java 代码示例，可在几秒钟内自动生成 PPT，消除手动操作。"
---
## **简介**

克隆是创建某物的精确副本或复制的过程。Aspose.Slides for Android via Java 也可以对任意幻灯片进行复制或克隆，然后将该克隆幻灯片插入到当前或其他已打开的演示文稿中。幻灯片克隆过程会生成一个新幻灯片，开发者可以对其进行修改而不影响原始幻灯片。克隆幻灯片有多种方式：

- 在演示文稿内部的末尾克隆。
- 在演示文稿内部的其他位置克隆。
- 在另一个演示文稿的末尾克隆。
- 在另一个演示文稿的其他位置克隆。
- 在另一个演示文稿的特定位置克隆。

在 Aspose.Slides for Android via Java 中，由 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 对象公开的 (一组 [ISlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlide) 对象) 提供了 [addClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 和 [insertClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，以实现上述幻灯片克隆类型。

## **在演示文稿末尾克隆幻灯片**
如果需要克隆幻灯片并将其放置在同一演示文稿文件现有幻灯片的末尾，请按照以下步骤使用 [addClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 通过引用由 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 对象公开的 Slides 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#getSlides--) 类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将要克隆的幻灯片作为参数传递给该方法。
1. 写入修改后的演示文稿文件。

在下面的示例中，我们将位于演示文稿第一位置（零索引）的幻灯片克隆到演示文稿的末尾。

```java
import com.aspose.slides.*;

// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 将所需幻灯片克隆到同一演示文稿幻灯片集合的末尾
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 将修改后的演示文稿写入磁盘
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在同一演示文稿内的其他位置克隆幻灯片**
如果需要克隆幻灯片并将其放置在同一演示文稿文件的其他位置，请使用 [insertClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 通过引用由 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 对象公开的 **Slides** 集合，实例化相应的类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#getSlides--) 对象公开的 [insertClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，并将要克隆的幻灯片以及新位置的索引作为参数传递给该方法。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们将位于索引 1（位置 2）的幻灯片克隆到索引 2（位置 3）。

```java
import com.aspose.slides.*;

// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 获取同一演示文稿中的幻灯片集合
    ISlideCollection slds = pres.getSlides();

    // 将所需幻灯片克隆到同一演示文稿中指定的索引位置
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 将修改后的演示文稿写入磁盘
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在另一演示文稿末尾克隆幻灯片**
如果需要将幻灯片从一个演示文稿克隆到另一个演示文稿的末尾：

1. 创建包含要克隆来源幻灯片的 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 实例。
1. 创建包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 实例。
1. 通过引用目标演示文稿的 **Slides** 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlideCollection) 类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将来源演示文稿中的幻灯片作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将来源演示文稿的第一个索引的幻灯片克隆到目标演示文稿的末尾。

```java
import com.aspose.slides.*;

// 实例化 Presentation 类以加载源演示文稿文件
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 实例化用于目标 PPTX 的 Presentation 类（幻灯片将在此被克隆）
    Presentation destPres = new Presentation();
    try {
        // 将所需幻灯片从源演示文稿克隆到目标演示文稿幻灯片集合的末尾
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

## **在另一演示文稿的其他位置克隆幻灯片**
如果需要将幻灯片从一个演示文稿克隆到另一个演示文稿的特定位置：

1. 创建包含来源演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 实例。
1. 创建包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 实例。
1. 通过引用目标演示文稿的 Slides 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#getSlides--) 类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#getSlides--) 对象公开的 [insertClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，并将来源演示文稿中的幻灯片以及期望的位置索引作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将来源演示文稿的零索引幻灯片克隆到目标演示文稿的索引 1（位置 2）。

```java
import com.aspose.slides.*;

// 实例化 Presentation 类以加载源演示文稿文件
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 实例化用于目标 PPTX 的 Presentation 类（幻灯片将在此被克隆）
    Presentation destPres = new Presentation();
    try {
        // 将所需幻灯片从源演示文稿克隆到目标演示文稿中指定的索引位置
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

## **在另一演示文稿的特定位置克隆带母版的幻灯片**
如果需要克隆带有母版的幻灯片，应先将源演示文稿中的目标母版克隆到目标演示文稿，然后使用该母版进行幻灯片克隆。方法 [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 需要目标演示文稿的母版，而不是来源演示文稿的母版。请按以下步骤操作：

1. 创建包含来源演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 实例。
1. 创建包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 实例。
1. 获取要克隆的幻灯片及其母版。
1. 通过引用目标演示文稿的 Masters 集合，实例化 [IMasterSlideCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IMasterSlideCollection) 类。
1. 调用由 [IMasterSlideCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IMasterSlideCollection) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将来源 PPTX 中的母版作为参数传递。
1. 通过将引用指向目标演示文稿的 Slides 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#getSlides--) 类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将来源演示文稿的幻灯片和目标母版作为参数传递。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将来源演示文稿零索引处的带母版幻灯片克隆到目标演示文稿的末尾，并使用来源幻灯片的母版。

```java
import com.aspose.slides.*;

// 实例化 Presentation 类以加载源演示文稿文件
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 实例化用于目标演示文稿的 Presentation 类（幻灯片将在此被克隆）
    Presentation destPres = new Presentation();
    try {
        // 从源演示文稿的幻灯片集合中实例化 ISlide，连同
        // 母版幻灯片
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 将所需的母版幻灯片从源演示文稿克隆到
        // 目标演示文稿的母版集合中
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // 将所需的幻灯片（使用所需的母版）从源演示文稿克隆到
        // 目标演示文稿的幻灯片集合的末尾
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // 将目标演示文稿保存到磁盘
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在指定章节的末尾克隆幻灯片**
如果需要在同一演示文稿的不同章节中克隆幻灯片，请使用由 [**ISlideCollection**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlideCollection) 接口公开的 [**addClone**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 方法。Aspose.Slides for Android via Java 支持将第一章节的幻灯片克隆后插入到同一演示文稿的第二章节。

以下代码片段演示如何克隆幻灯片并将其插入到指定章节。

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

在将幻灯片克隆到另一个演示文稿时，请确保目标演示文稿的幻灯片尺寸与源演示文稿相同。若尺寸不一致，Aspose.Slides 不会自动重新缩放克隆的形状——其原始坐标和尺寸将保持不变，可能导致内容错位或超出幻灯片边界。

可以在克隆母版和幻灯片之前，将目标演示文稿的幻灯片尺寸设置为与源演示文稿匹配：

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

在克隆母版和幻灯片之前执行上述操作。

## **常见问题**

**演讲者备注和审阅者批注会被克隆吗？**

会。备注页和审阅批注会包含在克隆中。如果不需要它们，请在插入后 [删除它们](/slides/zh/androidjava/presentation-notes/)。

**图表及其数据源如何处理？**

图表对象、格式以及嵌入的数据都会被复制。如果图表链接到外部源（例如 OLE 嵌入的工作簿），该链接会以 [OLE 对象](/slides/zh/androidjava/manage-ole/) 形式保留。文件之间迁移后，请验证数据可用性并刷新行为。

**能否控制克隆的插入位置和章节？**

可以。您可以在特定幻灯片索引处插入克隆，并将其放入选定的 [章节](/slides/zh/androidjava/slide-section/)。如果目标章节不存在，请先创建，然后将幻灯片移动到该章节。