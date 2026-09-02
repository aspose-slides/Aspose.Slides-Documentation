---
title: 在 JavaScript 中克隆演示文稿幻灯片
linktitle: 克隆幻灯片
type: docs
weight: 35
url: /zh/nodejs-java/clone-slides/
keywords:
- 克隆幻灯片
- 复制幻灯片
- 保存幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 快速复制 PowerPoint 幻灯片。遵循我们的代码示例，在几秒钟内实现 PPT 自动生成，消除手动操作。"
---
## **简介**

克隆是对某物进行完全复制或仿制的过程。Aspose.Slides for Node.js via Java 也可以对任意幻灯片进行复制或克隆，然后将该克隆的幻灯片插入到当前演示文稿或其他已打开的演示文稿中。幻灯片克隆的过程会生成一个新幻灯片，开发者可以对其进行修改，而不会影响原始幻灯片。克隆幻灯片的方式有多种：

- 在同一演示文稿的末尾克隆。
- 在同一演示文稿的其他位置克隆。
- 在另一个演示文稿的末尾克隆。
- 在另一个演示文稿的其他位置克隆。
- 在另一个演示文稿的特定位置克隆。

在 Aspose.Slides for Node.js via Java 中，（由 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 对象公开的 [Slide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Slide) 对象集合）提供了 [addClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 和 [insertClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 方法，以执行上述类型的幻灯片克隆。

## **在同一演示文稿的末尾克隆**
如果希望克隆幻灯片并将其放在同一演示文稿文件中现有幻灯片的末尾，请按照以下步骤使用 [addClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类的实例。  
1. 通过引用由 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 对象公开的 Slides 集合，实例化 [SlideCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation#getSlides--) 类。  
1. 调用 [SlideCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法，并将要克隆的幻灯片作为参数传递给该方法。  
1. 写入修改后的演示文稿文件。

在下面的示例中，我们将演示文稿中位于首位（索引为 0）的幻灯片克隆到了演示文稿的末尾。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **在同一演示文稿的其他位置克隆**
如果希望克隆幻灯片并在同一演示文稿文件的其他位置使用它，请使用 [insertClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类的实例。  
1. 通过引用由 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 对象公开的 **Slides** 集合，实例化相应的类。  
1. 调用 [SlideCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation#getSlides--) 对象公开的 [insertClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 方法，并将要克隆的幻灯片以及新位置的索引作为参数传递给该方法。  
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们将演示文稿中索引为 1（第 2 位）的幻灯片克隆到了索引 2（第 3 位）的位置。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 实例化表示演示文稿文件的 Presentation 类
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // 将所需幻灯片克隆到同一演示文稿的幻灯片集合末尾
    var slds = pres.getSlides();
    // 将所需幻灯片克隆到同一演示文稿的指定索引位置
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // 将修改后的演示文稿写入磁盘
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **在另一个演示文稿的末尾克隆**
如果需要从一个演示文稿克隆幻灯片并将其放在另一个演示文稿文件的现有幻灯片末尾：

1. 创建包含要克隆幻灯片来源的 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类实例。  
1. 创建包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类实例。  
1. 通过引用目标演示文稿的 **Slides** 集合，实例化 [SlideCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SlideCollection) 类。  
1. 调用 [SlideCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法，并将来源演示文稿中的幻灯片作为参数传递给该方法。  
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将来源演示文稿中索引为 0 的幻灯片克隆到了目标演示文稿的末尾。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 实例化 Presentation 类以加载源演示文稿文件
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // 实例化用于目标 PPTX 的 Presentation 类（将要克隆幻灯片的目标）
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
如果需要从一个演示文稿克隆幻灯片并将其放在另一个演示文稿文件的特定位置：

1. 创建包含来源演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类实例。  
1. 创建包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类实例。  
1. 通过引用目标演示文稿的 Slides 集合，实例化 [SlideCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation#getSlides--) 类。  
1. 调用 [SlideCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation#getSlides--) 对象公开的 [insertClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 方法，并将来源演示文稿的幻灯片以及期望的位置作为参数传递给该方法。  
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将来源演示文稿中索引为 0 的幻灯片克隆到了目标演示文稿的索引 1（第 2 位）的位置。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 实例化 Presentation 类以加载源演示文稿文件
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // 实例化用于目标 PPTX 的 Presentation 类（将要克隆幻灯片的目标）
    var destPres = new aspose.slides.Presentation();
    try {
        // 将所需幻灯片从源演示文稿克隆到目标演示文稿的幻灯片集合末尾
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // 将目标演示文稿写入磁盘
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **在另一个演示文稿的特定位置克隆**
如果需要克隆带有母版幻灯片的幻灯片，并将其从一个演示文稿使用到另一个演示文稿，首先必须先将源演示文稿中的目标母版克隆到目标演示文稿。随后使用该母版克隆带母版的幻灯片。[**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) 方法期望从目标演示文稿而不是源演示文稿获取母版。要克隆带母版的幻灯片，请按照以下步骤操作：

1. 创建包含来源演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类实例。  
1. 创建包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类实例。  
1. 访问要克隆的幻灯片及其母版。  
1. 通过引用目标演示文稿的 Masters 集合，实例化 [MasterSlideCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/MasterSlideCollection) 类。  
1. 调用 [MasterSlideCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/MasterSlideCollection) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法，并将来源 PPTX 中的母版作为参数传递给该方法。  
1. 通过引用目标演示文稿的 Slides 集合，实例化 [SlideCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation#getSlides--) 类。  
1. 调用 [SlideCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法，并将来源演示文稿的幻灯片及已克隆的母版作为参数传递给该方法。  
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将来源演示文稿中索引为 0 的带母版幻灯片克隆到了目标演示文稿的末尾（使用来源幻灯片的母版）。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 实例化 Presentation 类以加载源演示文稿文件
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 实例化用于目标演示文稿的 Presentation 类（将要克隆幻灯片的目标）
    var destPres = new aspose.slides.Presentation();
    try {
        // 从源演示文稿的幻灯片集合中实例化 ISlide，连同
        // 母版幻灯片
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // 将所需母版幻灯片从源演示文稿克隆到
        // 目标演示文稿的母版集合中
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // 将所需幻灯片从源演示文稿使用所需母版克隆到
        // 目标演示文稿的幻灯片集合末尾
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
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
如果希望在同一演示文稿文件的不同章节中克隆幻灯片，请使用由 [**SlideCollection**](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SlideCollection) 类公开的 [**addClone**](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) 方法。Aspose.Slides for Node.js via Java 可以实现从第一章节克隆幻灯片，然后将该克隆幻灯片插入同一演示文稿的第二章节。

以下代码片段演示了如何克隆幻灯片并将克隆的幻灯片插入指定章节。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // 将目标演示文稿保存到磁盘
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **确保幻灯片尺寸匹配**

在将幻灯片克隆到另一个演示文稿时，请确保目标演示文稿的幻灯片尺寸与源演示文稿相同。如果尺寸不同，Aspose.Slides 不会自动重新缩放克隆的形状——它们的原始坐标和尺寸会被保留，这可能导致内容错位或超出幻灯片边界。

在克隆母版和幻灯片之前，可以先将目标演示文稿的幻灯片尺寸设置为与源演示文稿匹配：

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

在克隆母版和幻灯片之前执行此操作。

## **常见问题**

**演讲者备注和审阅者评论会被克隆吗？**

是的。备注页和审阅评论都会被包含在克隆中。如果不需要它们，请在插入后[将其删除](/slides/zh/nodejs-java/presentation-notes/)。

**图表及其数据源如何处理？**

图表对象、格式以及嵌入的数据会被复制。如果图表链接到外部源（例如 OLE 嵌入的工作簿），该链接会保留为 [OLE 对象](/slides/zh/nodejs-java/manage-ole/)。在文件之间移动后，请验证数据可用性并检查刷新行为。

**我可以控制克隆的插入位置和章节吗？**

可以。您可以在特定幻灯片索引处插入克隆，并将其放入选定的[章节](/slides/zh/nodejs-java/slide-section/)。如果目标章节不存在，请先创建该章节，然后将幻灯片移动到其中。