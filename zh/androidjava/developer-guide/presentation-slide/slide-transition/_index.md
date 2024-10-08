---
title: 幻灯片过渡
type: docs
weight: 80
url: /androidjava/slide-transition/
keywords: "PowerPoint 幻灯片过渡, Java 中的变形过渡"
description: "PowerPoint 幻灯片过渡, Java 中的 PowerPoint 变形过渡"
---


## **概述**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 还允许开发人员管理或自定义幻灯片的过渡效果。在本主题中，我们将讨论如何使用 Aspose.Slides for Android via Java 以非常简单的方式控制幻灯片过渡。

{{% /alert %}} 

为便于理解，我们演示了如何使用 Aspose.Slides for Android via Java 管理简单的幻灯片过渡。开发人员不仅可以在幻灯片上应用不同的幻灯片过渡效果，还可以自定义这些过渡效果的行为。

## **添加幻灯片过渡**
要创建简单的幻灯片过渡效果，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
1. 从 Aspose.Slides for Android via Java 提供的过渡效果中，在幻灯片上应用一个幻灯片过渡类型通过 TransitionType 枚举
1. 保存修改后的演示文稿文件。

```java
// 实例化 Presentation 类以加载源演示文稿文件
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 在幻灯片 1 上应用圆形过渡类型
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 在幻灯片 2 上应用组合过渡类型
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // 将演示文稿写入磁盘
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **添加高级幻灯片过渡**
在上面的部分中，我们仅在幻灯片上应用了一个简单的过渡效果。现在，为了让这个简单的过渡效果更好且可控，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
1. 从 Aspose.Slides for Android via Java 提供的过渡效果中，在幻灯片上应用一个幻灯片过渡类型
1. 您还可以设置过渡为在点击时、在特定时间段后或两者兼具。
1. 如果幻灯片过渡启用为在点击时提前，过渡将仅在有人点击鼠标时提前。此外，如果设置了在时间后提前属性，过渡将在指定的提前时间过去后自动提前。
1. 将修改后的演示文稿作为演示文稿文件保存。

```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // 在幻灯片 1 上应用圆形过渡类型
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 设置过渡时间为 3 秒
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // 在幻灯片 2 上应用组合过渡类型
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 设置过渡时间为 5 秒
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // 在幻灯片 3 上应用变焦过渡类型
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // 设置过渡时间为 7 秒
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // 将演示文稿写入磁盘
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **变形过渡**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 现在支持 [变形过渡](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMorphTransition)。它们代表在 PowerPoint 2019 中引入的新变形过渡。

{{% /alert %}} 

变形过渡允许您在从一张幻灯片到下一张幻灯片时进行平滑的运动动画。本文描述了这一概念以及如何使用变形过渡。要有效使用变形过渡，您需要有两张幻灯片，其中至少有一个共同的对象。最简单的方法是复制幻灯片，然后将第二张幻灯片上的对象移动到不同的位置。

以下代码片段向您展示了如何将具有一些文本的幻灯片克隆添加到演示文稿，并将变形类型的过渡设置为第二张幻灯片。

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("PowerPoint 演示文稿中的变形过渡");

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

## **变形过渡类型**
新的 [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionMorphType) 枚举已被添加。它表示不同类型的变形幻灯片过渡。

TransitionMorphType 枚举有三个成员：

- ByObject: 变形过渡将考虑形状作为不可分割的对象执行。
- ByWord: 变形过渡将通过单词转移文本进行执行（如可能）。
- ByChar: 变形过渡将通过字符转移文本进行执行（如可能）。

以下代码片段向您展示了如何将变形过渡设置为幻灯片并更改变形类型：

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

## **设置过渡效果**
Aspose.Slides for Android via Java 支持设置过渡效果，例如，从黑色、从左侧、从右侧等。要设置过渡效果，请遵循以下步骤：

- 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
- 获取幻灯片的引用。
- 设置过渡效果。
- 将演示文稿写入一个 [PPTX ](https://docs.fileformat.com/presentation/pptx/)文件。

在下面给出的示例中，我们设置了过渡效果。

```java
// 创建一个 Presentation 类的实例
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