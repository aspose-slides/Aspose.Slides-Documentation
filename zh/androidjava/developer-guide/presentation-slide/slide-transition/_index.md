---
title: 管理 Android 上演示文稿的幻灯片切换
linktitle: 幻灯片切换
type: docs
weight: 80
url: /zh/androidjava/slide-transition/
keywords:
- 幻灯片切换
- 添加幻灯片切换
- 应用幻灯片切换
- 高级幻灯片切换
- Morph 切换
- 切换类型
- 切换效果
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Android via Java 中自定义幻灯片切换，提供 PowerPoint 和 OpenDocument 演示文稿的分步指南。"
---
## **概述**

本文介绍了如何使用 Aspose.Slides 在演示文稿中管理幻灯片切换。它展示了如何对幻灯片应用切换类型、配置切换行为（例如点击后前进或在指定时间后前进）、使用 Morph 切换及其类型，以及设置切换效果选项。示例演示了如何加载或创建演示文稿、修改所选幻灯片的切换设置，并将结果保存为 PPTX 文件。本文还回答了有关切换速度、切换声音、将相同切换应用于多个幻灯片以及检查幻灯片当前设置的切换等常见问题。

## **添加幻灯片切换**
要创建简单的幻灯片切换效果，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 类的实例。
2. 通过 TransitionType 枚举，从 Aspose.Slides for Android via Java 提供的切换效果中为幻灯片应用 Slide Transition Type（幻灯片切换类型）。
3. 写入修改后的演示文稿文件。

```java
import com.aspose.slides.*;

// 实例化 Presentation 类以加载源演示文稿文件
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 在第 1 张幻灯片上应用圆形切换
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 在第 2 张幻灯片上应用梳形切换
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // 将演示文稿写入磁盘
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **添加高级幻灯片切换**
在上节中，我们仅对幻灯片应用了一个简单的切换效果。现在，为了使该简单切换效果更好且可控，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 类的实例。
2. 通过 Aspose.Slides for Android via Java 提供的切换效果，为幻灯片应用 Slide Transition Type（幻灯片切换类型）。
3. 您还可以将切换设置为点击后前进、在特定时间后前进或两者兼顾。
4. 如果幻灯片切换被设置为点击后前进，则仅在点击鼠标时才会前进。此外，如果设置了 Advance After Time（在指定时间后前进）属性，切换将在指定的时间过去后自动前进。
5. 将修改后的演示文稿写入为演示文稿文件。

```java
import com.aspose.slides.*;

// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // 在第 1 张幻灯片上应用圆形切换
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 点击后前进或在 3 秒后自动前进
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // 在第 2 张幻灯片上应用梳形切换
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 点击后前进或在 5 秒后自动前进
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // 在第 3 张幻灯片上应用缩放切换
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // 点击后前进或在 7 秒后自动前进
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // 将演示文稿写入磁盘
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph 切换**
{{% alert color="info" %}} 

Aspose.Slides for Android via Java 现已支持 [Morph Transition](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IMorphTransition)。它们表示 PowerPoint 2019 中引入的新型 Morph 切换。

{{% /alert %}} 

Morph 切换允许您在幻灯片之间实现平滑动画移动。本文描述了该概念以及如何使用 Morph 切换。要有效使用 Morph 切换，您需要两张至少包含一个公共对象的幻灯片。最简单的方式是复制幻灯片，然后在第二张幻灯片上将对象移动到不同位置。

以下代码片段展示了如何向演示文稿中添加包含文本的幻灯片克隆，并为第二张幻灯片设置 [morph type](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/TransitionType) 切换。

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

## **Morph 切换类型**
已添加新的 [TransitionMorphType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/TransitionMorphType) 枚举。它表示不同类型的 Morph 幻灯片切换。

TransitionMorphType 枚举具有三个成员：

- ByObject：Morph 切换将在将形状视为不可分割的对象进行。
- ByWord：Morph 切换将在可能的情况下按单词传输文本。
- ByChar：Morph 切换将在可能的情况下按字符传输文本。

以下代码片段展示了如何为幻灯片设置 Morph 切换并更改 Morph 类型：

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
Aspose.Slides for Android via Java 支持设置如“从黑色”“从左侧”“从右侧”等切换效果。要设置切换效果，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例。
- 获取该幻灯片的引用。
- 设置切换效果。
- 将演示文稿写入为 [PPTX ](https://docs.fileformat.com/presentation/pptx/)文件。

下面的示例中，我们已经设置了切换效果。

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

## **常见问题**

### 我可以控制幻灯片切换的播放速度吗？

是的。使用 [TransitionSpeed](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/transitionspeed/) 设置来设置切换的 [speed](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-)（例如 slow/medium/fast）。

### 我可以为切换添加音频并使其循环吗？

是的。您可以为切换嵌入声音，并通过诸如 sound mode 和循环等设置来控制行为，例如 [setSound](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-)、[setSoundMode](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-)、[setSoundLoop](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-)，以及元数据如 [setSoundIsBuiltIn](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) 和 [setSoundName](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)。

### 将相同的切换应用于每个幻灯片的最快方法是什么？

在每个幻灯片的切换设置中配置所需的切换类型；切换是按幻灯片存储的，因此在所有幻灯片上使用相同的类型即可得到一致的效果。

### 我如何检查幻灯片当前设置的切换是哪一种？

检查幻灯片的 [transition settings](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) 并读取其 [transition type](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slideshowtransition/#setType-int-)；该值会明确指示当前应用的效果类型。