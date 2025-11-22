---
title: 克隆幻灯片
type: docs
weight: 35
url: /zh/nodejs-java/clone-slides/
---

## **克隆演示文稿中的幻灯片**
克隆是对某物进行完全复制或复制的过程。Aspose.Slides for Node.js via Java 还可以对任意幻灯片进行复制或克隆，然后将克隆的幻灯片插入当前或任何其他打开的演示文稿。幻灯片克隆的过程会创建一个新幻灯片，开发人员可以对其进行修改，而不会更改原始幻灯片。有多种克隆幻灯片的方式：

- 在演示文稿中末尾克隆。
- 在演示文稿中其他位置克隆。
- 在另一个演示文稿的末尾克隆。
- 在另一个演示文稿的其他位置克隆。
- 在另一个演示文稿的特定位置克隆。

在 Aspose.Slides for Node.js via Java 中，(由[演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)对象公开的[幻灯片](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide)集合)提供了[addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)和[insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)方法，以执行上述幻灯片克隆类型。

## **在演示文稿中末尾克隆**
如果想克隆幻灯片并在同一演示文稿文件的现有幻灯片末尾使用它，请按照以下步骤使用[addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)方法：

1. 创建[演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)类的实例。
1. 通过引用[演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)对象公开的 Slides 集合，实例化[SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--)类。
1. 调用[SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--)对象公开的[addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)方法，并将要克隆的幻灯片作为参数传递给该方法。
1. 写入修改后的演示文稿文件。

在下面的示例中，我们将演示文稿中第一个位置（索引为 0）的幻灯片克隆到演示文稿的末尾。
```javascript
// 实例化表示演示文稿文件的 Presentation 类
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 将所需幻灯片克隆到同一演示文稿的幻灯片集合末尾
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // 将修改后的演示文稿写入磁盘
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **在演示文稿中其他位置克隆**
如果想克隆幻灯片并在同一演示文稿文件的不同位置使用它，请使用[insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)方法：

1. 创建[演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)类的实例。
1. 通过引用[演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)对象公开的 **Slides** 集合，实例化相应的类。
1. 调用[SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--)对象公开的[insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)方法，并将要克隆的幻灯片以及新位置的索引作为参数传递给该方法。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们将演示文稿中索引为 0（位置 1）的幻灯片克隆到索引 1（位置 2）。
```javascript
// 实例化表示演示文稿文件的 Presentation 类
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // 将所需幻灯片克隆到同一演示文稿的幻灯片集合末尾
    var slds = pres.getSlides();
    // 将所需幻灯片克隆到同一演示文稿中的指定索引
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // 将修改后的演示文稿写入磁盘
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **在另一个演示文稿的末尾克隆**
如果需要从一个演示文稿克隆幻灯片并在另一个演示文稿文件的现有幻灯片末尾使用它：

1. 创建包含要克隆源幻灯片的[演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)类的实例。
1. 创建包含目标演示文稿的[演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)类的实例。
1. 通过引用目标演示文稿的 **Slides** 集合，实例化[SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection)类。
1. 调用[SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--)对象公开的[addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)方法，并将源演示文稿中的幻灯片作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将源演示文稿中第一个索引的幻灯片克隆到目标演示文稿的末尾。
```javascript
// 实例化 Presentation 类以加载源演示文稿文件
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // 实例化用于目标 PPTX 的 Presentation 类（要克隆幻灯片的地方）
    var destPres = new aspose.slides.Presentation();
    try {
        // 将所需幻灯片从源演示文稿克隆到目标演示文稿的幻灯片集合末尾
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // 将目标演示文稿写入磁盘
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **在另一个演示文稿的其他位置克隆**
如果需要从一个演示文稿克隆幻灯片并在另一个演示文稿文件的特定位置使用它：

1. 创建包含源演示文稿的[演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)类的实例。
1. 创建包含目标演示文稿的[演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)类的实例。
1. 通过引用目标演示文稿的 Slides 集合，实例化[SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--)类。
1. 调用[SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--)对象公开的[insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)方法，并将源演示文稿中的幻灯片以及所需位置作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将源演示文稿中索引为 0 的幻灯片克隆到目标演示文稿的索引 1（位置 2）。
```javascript
// 实例化 Presentation 类以加载源演示文稿文件
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // 实例化用于目标 PPTX 的 Presentation 类（要克隆幻灯片的地方）
    var destPres = new aspose.slides.Presentation();
    try {
        // 将所需幻灯片从源演示文稿克隆到目标演示文稿的幻灯片集合中指定索引处
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // 将目标演示文稿写入磁盘
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **在另一个演示文稿的特定位置克隆（包含母版）**
如果需要克隆包含母版幻灯片的幻灯片并在另一个演示文稿中使用，则需先将源演示文稿的目标母版克隆到目标演示文稿，然后使用该母版进行幻灯片克隆。[**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) 需要目标演示文稿中的母版，而不是源演示文稿中的母版。请按以下步骤克隆带母版的幻灯片：

1. 创建包含源演示文稿的[演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)类的实例。
1. 创建包含目标演示文稿的[演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)类的实例。
1. 获取待克隆的幻灯片及其母版。
1. 通过引用目标演示文稿的 Masters 集合，实例化[MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection)类。
1. 调用[MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection)对象公开的[addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)方法，并将源 PPTX 中的母版作为参数传递给该方法。
1. 通过引用目标演示文稿的 Slides 集合，实例化[SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--)类。
1. 调用[SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--)对象公开的[addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)方法，并将源演示文稿中的幻灯片和已克隆的母版作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将源演示文稿中索引为 0 的带母版幻灯片克隆到目标演示文稿的末尾，使用源幻灯片的母版。
```javascript
// 实例化 Presentation 类以加载源演示文稿文件
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 实例化用于目标演示文稿的 Presentation 类（要克隆幻灯片的地方）
    var destPres = new aspose.slides.Presentation();
    try {
        // 实例化来自源演示文稿幻灯片集合的 ISlide 以及
        // 母版幻灯片
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // 将所需母版幻灯片从源演示文稿克隆到
        // 目标演示文稿的母版集合中
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // 将所需母版幻灯片从源演示文稿克隆到
        // 目标演示文稿的母版集合中
        var iSlide = masters.addClone(SourceMaster);
        // 将所需幻灯片（带有所需母版）从源演示文稿克隆到
        // 目标演示文稿的幻灯片集合末尾
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // 将目标演示文稿保存到磁盘
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **在指定章节的末尾克隆**
如果想克隆幻灯片并在同一演示文稿文件的不同章节使用它，请使用[**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-)方法，该方法由[**SlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection)类公开。Aspose.Slides for Node.js via Java 可以克隆第一章节的幻灯片，然后将克隆的幻灯片插入同一演示文稿的第二章节。

以下代码片段演示了如何克隆幻灯片并将克隆的幻灯片插入指定章节。
```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // 将目标演示文稿保存到磁盘
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **常见问题**

**演讲者备注和审阅者评论会被克隆吗？**

会。备注页和审阅评论会包含在克隆中。如果不想保留它们，请在插入后[删除它们](/slides/zh/nodejs-java/presentation-notes/)。

**图表及其数据源如何处理？**

图表对象、格式以及嵌入的数据会被复制。如果图表链接到外部源（例如 OLE 嵌入的工作簿），该链接会作为[OLE 对象](/slides/zh/nodejs-java/manage-ole/)保留。移动文件后，请验证数据可用性并刷新行为。

**我可以控制克隆的插入位置和章节吗？**

可以。您可以在特定幻灯片索引处插入克隆，并将其放入选定的[章节](/slides/zh/nodejs-java/slide-section/)。如果目标章节不存在，请先创建，然后再将幻灯片移动到该章节。