---
title: 克隆幻灯片
type: docs
weight: 35
url: /androidjava/clone-slides/
---


## **演示文稿中的克隆幻灯片**
克隆是制作某物的精确副本或复制品的过程。Aspose.Slides for Android 通过 Java 还使得能够对任何幻灯片进行复制或克隆，然后将该克隆的幻灯片插入到当前或任何其他打开的演示文稿中。幻灯片克隆的过程创建一个新的幻灯片，开发人员可以对其进行修改而无需更改原始幻灯片。有几种可能的克隆幻灯片的方法：

- 在演示文稿的末尾克隆。
- 在演示文稿的另一个位置克隆。
- 在另一个演示文稿的末尾克隆。
- 在另一个演示文稿的另一个位置克隆。
- 在另一个演示文稿的特定位置克隆。

在 Aspose.Slides for Android 通过 Java 中，（由 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 对象公开的一组 [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) 对象）提供了 [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 和 [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法来执行上述类型的幻灯片克隆。

## **在演示文稿的末尾克隆**
如果您想克隆幻灯片，然后在现有幻灯片的末尾使用它，请根据以下步骤使用 [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 通过引用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 对象公开的幻灯片集合实例化 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将要克隆的幻灯片作为参数传递给 [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。
1. 写入修改后的演示文稿文件。

在下面给出的示例中，我们将一张幻灯片（位于演示文稿的第一个位置 - 零索引 - ）克隆到演示文稿的末尾。

```java
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

## **在演示文稿的另一个位置克隆**
如果您想克隆幻灯片，然后在同一演示文稿文件中使用它，但在不同的位置，请使用 [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 通过引用 [**幻灯片**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 集合来实例化类，该集合由 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 对象公开。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 对象公开的 [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，并将要克隆的幻灯片及新位置的索引作为参数传递给 [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面给出的示例中，我们将一张幻灯片（位于零索引 - 位置 1 - 的演示文稿中）克隆到演示文稿的索引 1 - 位置 2 - 。

```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 将所需幻灯片克隆到同一演示文稿的幻灯片集合末尾
    ISlideCollection slds = pres.getSlides();

    // 将所需幻灯片克隆到同一演示文稿中指定的索引
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 将修改后的演示文稿写入磁盘
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在另一个演示文稿的末尾克隆**
如果您需要从一个演示文稿中克隆一张幻灯片并在另一个演示文稿文件中使用它，位于现有幻灯片的末尾：

1. 创建包含要克隆幻灯片的演示文稿的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 创建包含要添加幻灯片的目标演示文稿的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 通过引用目标演示文稿的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 对象公开的 [**幻灯片**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) 类。
1. 调用 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将来自源演示文稿的幻灯片作为参数传递给 [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。
1. 写入修改后的目标演示文稿文件。

在下面给出的示例中，我们将一张幻灯片（来自源演示文稿的第一个索引）克隆到目标演示文稿的末尾。

```java
// 实例化用于加载源演示文稿文件的 Presentation 类
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 实例化目标 PPTX 的 Presentation 类（要克隆幻灯片的地方）
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

## **在另一个演示文稿的另一个位置克隆**
如果您需要从一个演示文稿中克隆一张幻灯片并在另一个演示文稿文件中使用它，位于特定位置：

1. 创建包含要克隆幻灯片的源演示文稿的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 创建包含要添加幻灯片的目标演示文稿的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 通过引用目标演示文稿的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 对象公开的幻灯片集合实例化 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 类。
1. 调用 [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，该方法由 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 对象公开，并将源演示文稿中的幻灯片和所需位置作为参数传递给 [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法。
1. 写入修改后的目标演示文稿文件。

在下面给出的示例中，我们将一张幻灯片（来自源演示文稿的零索引）克隆到目标演示文稿的索引 1（位置 2）。

```java
// 实例化用于加载源演示文稿文件的 Presentation 类
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 实例化目标 PPTX 的 Presentation 类（要克隆幻灯片的地方）
    Presentation destPres = new Presentation();
    try {
        // 将所需幻灯片从源演示文稿克隆到目标演示文稿的幻灯片集合的末尾
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // 将目标演示文稿写入磁盘
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在另一个演示文稿的特定位置克隆**
如果您需要克隆一张带有母版幻灯片的幻灯片并在另一个演示文稿中使用，您需要先将所需的母版幻灯片从源演示文稿克隆到目标演示文稿。然后，您需要使用该母版幻灯片来克隆带有母版的幻灯片。 [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 方法期望来自目标演示文稿的母版幻灯片，而不是来自源演示文稿。为了带有母版的幻灯片克隆，请按照以下步骤进行：

1. 创建包含要克隆幻灯片的源演示文稿的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 创建包含要克隆到的目标演示文稿的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 访问要克隆的幻灯片以及母版幻灯片。
1. 通过引用目标演示文稿的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 对象公开的母版集合，实例化 [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) 类。
1. 调用 [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，该方法由 [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) 对象公开，并将要克隆的源 PPTX 的母版作为参数传递给 [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。
1. 通过设置对目标演示文稿的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 对象公开的幻灯片集合的引用来实例化 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 类。
1. 调用 [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，该方法由 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 对象公开，并将来自源演示文稿的幻灯片和母版幻灯片作为参数传递给 [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。
1. 写入修改后的目标演示文稿文件。

在下面给出的示例中，我们将一张带有母版（位于源演示文稿的零索引）的幻灯片克隆到目标演示文稿的末尾，并使用源幻灯片中的母版。

```java
// 实例化用于加载源演示文稿文件的 Presentation 类
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 实例化目标演示文稿的 Presentation 类（要克隆幻灯片的地方）
    Presentation destPres = new Presentation();
    try {
        // 从源演示文稿中实例化幻灯片以及母版幻灯片
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 将所需的母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 将所需的母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // 将带有所需母版的源演示文稿中的所需幻灯片克隆到目标演示文稿的幻灯片集合的末尾
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // 保存目标演示文稿到磁盘
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在指定部分的末尾克隆**
如果您想克隆幻灯片，然后在同一演示文稿文件中使用它，但在不同的部分，请使用 [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 方法，该方法由 [**ISlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) 接口公开。Aspose.Slides for Android 通过 Java 使得可以从第一部分克隆幻灯片，然后将该克隆幻灯片插入到同一演示文稿的第二部分。

以下代码片段显示了如何克隆幻灯片并将克隆的幻灯片插入到指定部分。

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// 将目标演示文稿写入磁盘
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```