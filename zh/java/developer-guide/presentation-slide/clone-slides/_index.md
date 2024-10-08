---
title: 克隆幻灯片
type: docs
weight: 35
url: /zh/java/clone-slides/
---

## **在演示文稿中克隆幻灯片**
克隆是制作某物精确副本或复制品的过程。Aspose.Slides for Java 还可以使用户能够复制或克隆任何幻灯片，然后将克隆的幻灯片插入当前或任何其他打开的演示文稿中。幻灯片克隆的过程会创建一个新的幻灯片，开发人员可以修改它而不会更改原始幻灯片。克隆幻灯片有几种可能的方法：

- 在演示文稿中末尾克隆。
- 在演示文稿中其他位置克隆。
- 在另一演示文稿中末尾克隆。
- 在另一演示文稿中其他位置克隆。
- 在另一演示文稿中的特定位置克隆。

在 Aspose.Slides for Java 中，由 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象公开的 (一组 [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) 对象) 提供了 [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 和 [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法来执行上述类型的幻灯片克隆。

## **在演示文稿中末尾克隆**
如果您想要克隆一张幻灯片并在现有幻灯片的末尾在同一个演示文稿文件中使用它，可以根据下面列出的步骤使用 [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 通过引用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象公开的幻灯片集合实例化 [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) 类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将要克隆的幻灯片作为参数传递给 [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。
1. 写入修改后的演示文稿文件。

在下面给出的示例中，我们已经克隆了一张幻灯片（位于演示文稿的第一个位置 - 零索引）到演示文稿的末尾。

```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 将所需幻灯片克隆到同一演示文稿中幻灯片集合的末尾
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 将修改后的演示文稿写入磁盘
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在演示文稿中其他位置克隆**
如果您想要克隆一张幻灯片并在同一个演示文稿文件中使用它，但在不同的位置，请使用 [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 通过引用 [**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) 集合来实例化类，该集合由 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象公开。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) 对象公开的 [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，并将要克隆的幻灯片及其新位置的索引作为参数传递给 [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面给出的示例中，我们克隆了一张幻灯片（位于零索引 - 位置 1 - 的演示文稿中）到索引 1 – 位置 2 – 的演示文稿。

```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 将所需幻灯片克隆到同一演示文稿中幻灯片集合的末尾
    ISlideCollection slds = pres.getSlides();

    // 将所需幻灯片克隆到同一演示文稿中的指定索引
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 将修改后的演示文稿写入磁盘
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在另一演示文稿中末尾克隆**
如果您需要从一个演示文稿中克隆一张幻灯片并在另一个演示文稿文件中使用它，在现有幻灯片的末尾：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例，包含源演示文稿。
1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例，包含目标演示文稿。
1. 通过引用目标演示文稿的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象公开的 [**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) 集合来实例化 [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) 类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将源演示文稿中的幻灯片作为参数传递给 [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。
1. 写入修改后的目标演示文稿文件。

在下面给出的示例中，我们已将一张幻灯片（来自源演示文稿的第一个索引）克隆到目标演示文稿的末尾。

```java
// 实例化演示文稿类以加载源演示文稿文件
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 实例化目标 PPTX 的演示文稿类（要克隆幻灯片到此处）
    Presentation destPres = new Presentation();
    try {
        // 将所需幻灯片从源演示文稿克隆到目标演示文稿中幻灯片集合的末尾
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

## **在另一演示文稿中其他位置克隆**
如果您需要从一个演示文稿中克隆一张幻灯片并在另一个演示文稿文件中使用它，在特定位置：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例，包含源演示文稿。
1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例，包含目标演示文稿。
1. 通过引用目标演示文稿的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象公开的幻灯片集合实例化 [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) 类。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) 对象公开的 [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，并将源演示文稿中的幻灯片及其所需位置作为参数传递给 [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法。
1. 写入修改后的目标演示文稿文件。

在下面给出的示例中，我们已将一张幻灯片（来自源演示文稿的零索引）克隆到目标演示文稿的索引 1（位置 2）。

```java
// 实例化演示文稿类以加载源演示文稿文件
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 实例化目标 PPTX 的演示文稿类（要克隆幻灯片到此处）
    Presentation destPres = new Presentation();
    try {
        // 将所需幻灯片从源演示文稿克隆到目标演示文稿中幻灯片集合的末尾
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

## **在另一演示文稿中的特定位置克隆**
如果您需要克隆一张带主幻灯片的幻灯片并在另一个演示文稿中使用它，您需要先将所需的主幻灯片从源演示文稿克隆到目标演示文稿。然后，您需要使用该主幻灯片来克隆带主幻灯片的幻灯片。 [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 方法期望来自目标演示文稿的主幻灯片，而不是来自源演示文稿。为了克隆带主的幻灯片，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例，包含源演示文稿。
1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例，包含目标演示文稿。
1. 访问要克隆的幻灯片及其主幻灯片。
1. 通过引用目标演示文稿的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象公开的主幻灯片集合实例化 [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) 类。
1. 调用由 [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) 对象公开的 [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将要克隆的源 PPTX 中的主幻灯片作为参数传递给 [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。
1. 实例化 [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) 类，通过设置引用目标演示文稿的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 对象公开的幻灯片集合。
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将源演示文稿中的幻灯片和主幻灯片作为参数传递给 [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。
1. 写入修改后的目标演示文稿文件。

在下面给出的示例中，我们已将带主幻灯片的幻灯片（位于源演示文稿的零索引）克隆到目标演示文稿的末尾，使用源幻灯片的主幻灯片。

```java
// 实例化演示文稿类以加载源演示文稿文件
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 实例化演示文稿类以供目标演示文稿（要克隆幻灯片到此处）
    Presentation destPres = new Presentation();
    try {
        // 从源演示文稿的幻灯片集合中实例化 ISlide 以及主幻灯片
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 将所需主幻灯片从源演示文稿克隆到目标演示文稿中的主幻灯片集合
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 将所需主幻灯片从源演示文稿克隆到目标演示文稿中的主幻灯片集合
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // 从源演示文稿克隆所需幻灯片到目标演示文稿中带有所需主幻灯片的幻灯片集合的末尾
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

## **在指定节中末尾克隆**
如果您想要克隆一张幻灯片并在同一个演示文稿文件中使用它，但在不同的节中，请使用由 [**ISlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) 接口公开的 [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 方法。Aspose.Slides for Java 使得可以从第一个节克隆一张幻灯片，然后将该克隆幻灯片插入到同一演示文稿的第二个节中。

以下代码片段向您展示如何克隆一张幻灯片并将克隆的幻灯片插入到指定节中。

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// 将目标演示文稿保存到磁盘
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```