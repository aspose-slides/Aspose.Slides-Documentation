---
title: 使用 Java 管理演示文稿中的幻灯片切换
linktitle: 幻灯片切换
type: docs
weight: 80
url: /zh/java/slide-transition/
keywords:
- 幻灯片切换
- 添加幻灯片切换
- 应用幻灯片切换
- 高级幻灯片切换
- Morph 过渡
- 切换类型
- 切换效果
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "发现如何在 Aspose.Slides for Java 中自定义幻灯片切换，提供针对 PowerPoint 和 OpenDocument 演示文稿的分步指南。"
---
## **概述**

本文说明了如何使用 Aspose.Slides 管理演示文稿中的幻灯片切换。它展示了如何对幻灯片应用切换类型、配置切换行为（如单击前进或在指定时间后前进）、检查并禁用自动前进、使用 Morph 过渡及其类型，以及设置切换效果选项。示例演示了如何加载或创建演示文稿、修改选定幻灯片的切换设置，并将结果保存为 PPTX 文件。文章还回答了关于切换速度、切换声音、对多个幻灯片应用相同切换以及检查幻灯片当前设置的切换等常见问题。

## **添加幻灯片切换**
要创建一个简单的幻灯片切换效果，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 类的实例。
1. 通过 TransitionType 枚举，从 Aspose.Slides for Java 提供的切换效果中为幻灯片应用 Slide Transition Type。
1. 写入修改后的演示文稿文件。

```java
import com.aspose.slides.*;

// 实例化 Presentation 类以加载源演示文稿文件
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 在第 1 张幻灯片上应用圆形切换效果
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 在第 2 张幻灯片上应用梳形切换效果
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // 将演示文稿写入磁盘
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **添加高级幻灯片切换**
在上述章节中，我们仅对幻灯片应用了一个简单的切换效果。现在，为了使该简单切换效果更佳且可控，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 类的实例。
1. 从 Aspose.Slides for Java 提供的切换效果中为幻灯片应用 Slide Transition Type。
1. 您还可以将切换设置为单击时前进、在特定时间后前进，或两者兼施。
1. 如果幻灯片切换启用了单击前进，则仅在单击鼠标时才会前进。此外，如果设置了 Advance After Time 属性，切换将在指定的时间过去后自动前进。
1. 将修改后的演示文稿写入为演示文稿文件。

```java
import com.aspose.slides.*;

// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // 在第 1 张幻灯片上应用圆形切换效果
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 设置 3 秒的切换时间
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // 在第 2 张幻灯片上应用梳形切换效果
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 设置 5 秒的切换时间
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // 在第 3 张幻灯片上应用缩放切换效果
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // 设置 7 秒的切换时间
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // 将演示文稿写入磁盘
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph 过渡**
{{% alert color="info" %}} 

Aspose.Slides for Java 现在支持 [Morph Transition](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IMorphTransition)。它们代表了 PowerPoint 2019 中引入的新 Morph 过渡。

{{% /alert %}} 

Morph 过渡允许您在两张幻灯片之间实现平滑的动画移动。本文描述了概念以及如何使用 Morph 过渡。要有效使用 Morph 过渡，您需要两张至少有一个共同对象的幻灯片。最简单的方法是复制幻灯片，然后将第二张幻灯片上的对象移动到其他位置。

以下代码片段展示了如何向演示文稿添加一个包含文本的幻灯片克隆，并为第二张幻灯片设置 [morph type](https://reference.aspose.com/slides/zh/java/com.aspose.slides/TransitionType) 切换。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Morph 过渡类型**
已添加新的 [TransitionMorphType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/TransitionMorphType) 枚举。它表示不同类型的 Morph 幻灯片过渡。

TransitionMorphType 枚举有三个成员：

- ByObject: Morph 过渡将在考虑形状为不可分割对象的情况下执行。
- ByWord: Morph 过渡将在可能的情况下按词转移文本进行执行。
- ByChar: Morph 过渡将在可能的情况下按字符转移文本进行执行。

以下代码片段展示了如何为幻灯片设置 Morph 过渡并更改 Morph 类型：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **设置切换效果**
Aspose.Slides for Java 支持设置切换效果，例如从黑色、从左侧、从右侧等。要设置切换效果，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例。
- 获取幻灯片的引用。
- 设置切换效果。
- 将演示文稿写入为 [PPTX](https://docs.fileformat.com/presentation/pptx/)文件。

在下面的示例中，我们已经设置了切换效果。

```java
import com.aspose.slides.*;

// 创建 Presentation 类的实例
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 设置效果
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // 将演示文稿写入磁盘
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### 我可以控制幻灯片切换的播放速度吗？

是的。使用 [TransitionSpeed](https://reference.aspose.com/slides/zh/java/com.aspose.slides/transitionspeed/) 设置（例如慢/中/快），通过 [speed](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) 方法设置切换的速度。

### 我可以为切换附加音频并让它循环播放吗？

是的。您可以为切换嵌入声音，并通过诸如 sound mode 和循环等设置进行控制（例如 [setSound](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-)、[setSoundMode](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-)、[setSoundLoop](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-)，以及元数据如 [setSoundIsBuiltIn](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) 和 [setSoundName](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)）。

### 将相同的切换应用于每张幻灯片的最快方法是什么？

在每张幻灯片的切换设置中配置所需的切换类型；切换是按幻灯片存储的，因此在所有幻灯片上应用相同的类型即可实现一致的效果。

### 我如何检查幻灯片当前设置的切换是什么？

检查该幻灯片的 [transition settings](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseslide/#getSlideShowTransition--) 并读取其 [transition type](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slideshowtransition/#setType-int-)；该值会明确告诉您当前应用的是哪种效果。