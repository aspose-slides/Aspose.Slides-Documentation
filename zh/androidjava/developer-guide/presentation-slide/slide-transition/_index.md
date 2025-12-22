---
title: 在 Android 上管理演示文稿的幻灯片切换
linktitle: 幻灯片切换
type: docs
weight: 80
url: /zh/androidjava/slide-transition/
keywords:
- 幻灯片切换
- 添加幻灯片切换
- 应用幻灯片切换
- 高级幻灯片切换
- 形变切换
- 切换类型
- 切换效果
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Android via Java 中自定义幻灯片切换，提供针对 PowerPoint 和 OpenDocument 演示文稿的逐步指南。"
---

## **概述**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 还允许开发人员管理或自定义幻灯片的切换效果。在本主题中，我们将讨论如何使用 Aspose.Slides for Android via Java 轻松控制幻灯片切换。

{{% /alert %}} 

为了更易于理解，我们示例演示了使用 Aspose.Slides for Android via Java 管理简单幻灯片切换的方式。开发人员不仅可以在幻灯片上应用不同的切换效果，还可以自定义这些切换效果的行为。

## **添加幻灯片切换**
要创建一个简单的幻灯片切换效果，请按以下步骤操作：

1. 创建一个 [演示文稿](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
2. 通过 TransitionType 枚举，从 Aspose.Slides for Android via Java 提供的切换效果中为幻灯片应用幻灯片切换类型。
3. 写入修改后的演示文稿文件。
```java
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
在上面的章节中，我们仅在幻灯片上应用了一个简单的切换效果。现在，为了让该简单切换效果更好并可控，请按以下步骤操作：

1. 创建一个 [演示文稿](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
2. 通过 TransitionType 枚举，从 Aspose.Slides for Android via Java 提供的切换效果中为幻灯片应用幻灯片切换类型。
3. 您还可以将切换设置为“单击后前进”、在特定时间段后前进，或两者兼而有之。
4. 如果幻灯片切换被设为“单击后前进”，则只有在有人单击鼠标时切换才会前进。此外，如果设置了“在此时间后前进”属性，切换将在指定的时间过去后自动前进。
5. 将修改后的演示文稿写入为演示文稿文件。
```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // 在第 1 张幻灯片上应用圆形切换
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 设置 3 秒的切换时间
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // 在第 2 张幻灯片上应用梳形切换
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 设置 5 秒的切换时间
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // 在第 3 张幻灯片上应用缩放切换
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


## **Morph 切换**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 现在支持 [Morph 切换](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMorphTransition)。它们代表了 PowerPoint 2019 引入的新形变切换。

{{% /alert %}} 

Morph 切换允许您在幻灯片之间实现平滑的运动动画。本文介绍了该概念及如何使用 Morph 切换。要有效使用 Morph 切换，您需要准备两张至少有一个对象相同的幻灯片。最简便的方式是复制幻灯片，然后在第二张幻灯片上将对象移动到其他位置。

以下代码片段展示了如何将包含文本的幻灯片克隆添加到演示文稿，并为第二张幻灯片设置 [morph 类型](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionType) 的切换。
```java
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


## **形变切换类型**
已新增 [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionMorphType) 枚举。它表示了不同的 Morph 幻灯片切换类型。

TransitionMorphType 枚举有三个成员：

- ByObject：在进行形变切换时将形状视为不可分割的对象。
- ByWord：在可能的情况下按单词转移文本进行形变切换。
- ByChar：在可能的情况下按字符转移文本进行形变切换。

以下代码片段展示了如何为幻灯片设置形变切换并更改形变类型：
```java
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
Aspose.Slides for Android via Java 支持设置如“从黑色出现”“从左侧”“从右侧”等切换效果。要设置切换效果，请按以下步骤操作：

- 创建一个 [演示文稿](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
- 获取幻灯片的引用。
- 设置切换效果。
- 将演示文稿写入为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

在下面的示例中，我们设置了切换效果。
```java
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

**我可以控制幻灯片切换的播放速度吗？**

是的。使用 [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) 设置（例如慢/中/快），通过 [speed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) 方法来控制切换的速度。

**我可以为切换附加音频并使其循环吗？**

可以。您可以为切换嵌入音频，并通过诸如 [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-)、[setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-)、[setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-) 等设置来控制其行为，同时还可以使用 [setSoundIsBuiltIn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) 和 [setSoundName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-) 等元数据。

**将相同切换应用于每张幻灯片的最快方法是什么？**

在每张幻灯片的切换设置中配置所需的切换类型；切换是按幻灯片存储的，因此在所有幻灯片上使用相同类型即可实现一致效果。

**我如何检查当前幻灯片上设置了哪种切换？**

检查幻灯片的 [transition settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) 并读取其 [transition type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setType-int-)，该值即可明确指示当前应用的切换效果。