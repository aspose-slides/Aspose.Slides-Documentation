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
- 变形切换
- 切换类型
- 切换效果
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中自定义幻灯片切换，并提供针对 PowerPoint 和 OpenDocument 演示文稿的分步指导。"
---

## **概述**
{{% alert color="primary" %}} 
Aspose.Slides for Java 还允许开发者管理或自定义幻灯片的切换效果。本文将介绍如何使用 Aspose.Slides for Java 轻松控制幻灯片切换。
{{% /alert %}} 

为了便于理解，我们演示了使用 Aspose.Slides for Java 管理简单幻灯片切换的示例。开发者不仅可以在幻灯片上应用不同的切换效果，还可以自定义这些效果的行为。

## **添加幻灯片切换**
要创建一个简单的幻灯片切换效果，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
2. 通过 TransitionType 枚举从 Aspose.Slides for Java 提供的切换效果中为幻灯片应用切换类型。
3. 将修改后的演示文稿写入文件。
```java
// 实例化 Presentation 类以加载源演示文稿文件
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 在第 1 张幻灯片上应用圆形过渡
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 在第 2 张幻灯片上应用梳形过渡
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // 将演示文稿写入磁盘
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **添加高级幻灯片切换**
在上一节中，我们只为幻灯片应用了简单的切换效果。现在，为了使该切换更灵活可控，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
2. 通过 Aspose.Slides for Java 提供的切换效果为幻灯片应用切换类型。
3. 还可以将切换设置为单击后前进、在特定时间后前进或两者兼有。
4. 如果切换被设置为单击后前进，则仅在点击鼠标时才会前进；如果设置了“在指定时间后前进”属性，则在达到指定时间后会自动前进。
5. 将修改后的演示文稿写入文件。
```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // 在第 1 张幻灯片上应用圆形过渡
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 设置 3 秒的切换时间
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // 在第 2 张幻灯片上应用梳形过渡
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 设置 5 秒的切换时间
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // 在第 3 张幻灯片上应用缩放过渡
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


## **变形切换**
{{% alert color="primary" %}} 
Aspose.Slides for Java 现已支持 [Morph Transition](https://reference.aspose.com/slides/java/com.aspose.slides/IMorphTransition)。它代表了 PowerPoint 2019 引入的全新变形切换。
{{% /alert %}} 

变形切换可实现从一张幻灯片平滑动画过渡到下一张幻灯片。本文介绍了变形切换的概念及使用方法。要有效使用变形切换，需要两张幻灯片至少共享一个对象。最简单的做法是复制幻灯片，然后在第二张幻灯片上移动该对象到其他位置。

下面的代码片段演示了如何向演示文稿中添加包含文本的幻灯片克隆，并为第二张幻灯片设置 [morph type](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionType) 切换。
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


## **变形切换类型**
新增了 [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionMorphType) 枚举，表示不同的变形幻灯片切换类型。

TransitionMorphType 枚举包含三个成员：

- ByObject: 将形状视为不可分割的对象执行变形切换。
- ByWord: 在可能的情况下按单词转移文本执行变形切换。
- ByChar: 在可能的情况下按字符转移文本执行变形切换。

下面的代码片段展示了如何为幻灯片设置变形切换并更改变形类型：
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
Aspose.Slides for Java 支持设置多种切换效果，例如从黑色、从左侧、从右侧等。要设置切换效果，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
- 获取幻灯片的引用。
- 设置切换效果。
- 将演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

下面的示例展示了我们是如何设置切换效果的。
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

可以。使用 [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) 设置（例如 slow/medium/fast）来设置切换的 [speed](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSpeed-int-)。

**我可以为切换附加音频并让其循环吗？**

可以。您可以为切换嵌入声音，并通过如 [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-)、[setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-)、[setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-) 等设置控制行为，还可以使用 [setSoundIsBuiltIn](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) 和 [setSoundName](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-) 等元数据。

**将相同的切换应用于所有幻灯片的最快方法是什么？**

在每张幻灯片的切换设置中配置所需的切换类型；切换是按幻灯片存储的，因此在所有幻灯片上使用相同类型即可实现一致的效果。

**如何检查当前幻灯片上设置了哪种切换？**

检查幻灯片的 [transition settings](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getSlideShowTransition--) 并读取其 [transition type](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setType-int-)；该值即可告诉您当前应用的具体切换效果。