---
title: 幻灯片过渡
type: docs
weight: 80
url: /java/slide-transition/
keywords: "PowerPoint 幻灯片过渡, Java中的变形过渡"
description: "PowerPoint 幻灯片过渡, Java中的PowerPoint变形过渡"
---


## **概述**
{{% alert color="primary" %}} 

Aspose.Slides for Java 还允许开发人员管理或自定义幻灯片的过渡效果。在本主题中，我们将讨论如何通过使用 Aspose.Slides for Java 轻松控制幻灯片过渡。

{{% /alert %}} 

为了更容易理解，我们展示了如何使用 Aspose.Slides for Java 管理简单的幻灯片过渡。开发人员不仅可以对幻灯片应用不同的过渡效果，还可以自定义这些过渡效果的行为。

## **添加幻灯片过渡**
要创建简单的幻灯片过渡效果，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
1. 从 Aspose.Slides for Java 提供的过渡效果中，应用一种幻灯片过渡类型。
1. 保存修改后的演示文稿文件。

```java
// 实例化 Presentation 类以加载源演示文稿文件
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 在幻灯片 1 上应用圆形类型过渡
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 在幻灯片 2 上应用组合类型过渡
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // 将演示文稿写入磁盘
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **添加高级幻灯片过渡**
在上面的部分中，我们只是对幻灯片应用了简单的过渡效果。现在，为了让这个简单的过渡效果更好且更可控，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
1. 从 Aspose.Slides for Java 提供的过渡效果中，应用一种幻灯片过渡类型。
1. 您还可以设置过渡为单击后高级、经过特定时间后高级或两者。
1. 如果启用了单击后高级，该过渡将仅在有人单击鼠标时向前推进。此外，如果设置了“经过时间后高级”属性，则该过渡将在指定的高级时间过后自动推进。
1. 将修改后的演示文稿写入文件。

```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // 在幻灯片 1 上应用圆形类型过渡
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 设置 3 秒的过渡时间
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // 在幻灯片 2 上应用组合类型过渡
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 设置 5 秒的过渡时间
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // 在幻灯片 3 上应用缩放类型过渡
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // 设置 7 秒的过渡时间
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

Aspose.Slides for Java 现在支持 [变形过渡](https://reference.aspose.com/slides/java/com.aspose.slides/IMorphTransition)。它们是 PowerPoint 2019 新引入的变形过渡。

{{% /alert %}} 

变形过渡允许您平滑地将一个幻灯片移动到下一个幻灯片。本文描述了变形过渡的概念以及如何使用变形过渡。要有效使用变形过渡，您需要拥有两个幻灯片，并且至少有一个共同的对象。最简单的方法是复制幻灯片，然后将第二个幻灯片上的对象移动到不同的位置。

下面的代码片段向您展示了如何在演示文稿中添加一个包含一些文本的幻灯片克隆并将第二个幻灯片的过渡设置为 [变形类型](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionType)。

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
新增 [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionMorphType) 枚举。它表示不同类型的变形幻灯片过渡。

TransitionMorphType 枚举有三个成员：

- ByObject: 变形过渡将根据形状作为不可分割的对象进行。
- ByWord: 变形过渡将在可能的情况下按单词转移文本。
- ByChar: 变形过渡将在可能的情况下按字符转移文本。

以下代码片段向您展示了如何将变形过渡设置到幻灯片并更改变形类型：

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
Aspose.Slides for Java 支持设置过渡效果，例如，从黑色、从左侧、从右侧等。要设置过渡效果，请遵循以下步骤：

- 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
- 获取幻灯片的引用。
- 设置过渡效果。
- 将演示文稿作为 [PPTX ](https://docs.fileformat.com/presentation/pptx/)文件写入。

在下面给出的示例中，我们设置了过渡效果。

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