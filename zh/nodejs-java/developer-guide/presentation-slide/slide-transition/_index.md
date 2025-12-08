---
title: 幻灯片切换
type: docs
weight: 80
url: /zh/nodejs-java/slide-transition/
keywords: "PowerPoint 幻灯片切换，JavaScript 中的 Morph 切换"
description: "PowerPoint 幻灯片切换，PowerPoint 在 JavaScript 中的 Morph 切换"
---

## **概述**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java 也允许开发人员管理或自定义幻灯片的切换效果。在本主题中，我们将讨论如何使用 Aspose.Slides for Node.js via Java 轻松控制幻灯片切换。

{{% /alert %}} 

为了更容易理解，我们演示了使用 Aspose.Slides for Node.js via Java 管理简单幻灯片切换的用法。开发人员不仅可以在幻灯片上应用不同的切换效果，还可以自定义这些切换效果的行为。

## **添加幻灯片切换**
要创建一个简单的幻灯片切换效果，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
1. 通过 TransitionType 枚举，从 Aspose.Slides for Node.js via Java 提供的切换效果中为幻灯片应用 Slide Transition Type。
1. 写入修改后的演示文稿文件。
```javascript
// 实例化 Presentation 类以加载源演示文稿文件
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // 在第 1 张幻灯片上应用圆形类型切换
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // 在第 2 张幻灯片上应用梳形类型切换
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // 将演示文稿写入磁盘
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **添加高级幻灯片切换**
在上节中，我们仅在幻灯片上应用了一个简单的切换效果。现在，要使该简单切换效果更好且可控，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
1. 通过 Aspose.Slides for Node.js via Java 提供的切换效果为幻灯片应用 Slide Transition Type。
1. 您还能将切换设置为单击后前进、在特定时间后前进，或两者兼而有之。
1. 如果将幻灯片切换设置为单击后前进，则仅在有人单击鼠标时才会前进。此外，如果设置了 Advance After Time 属性，则在指定的时间过去后，切换会自动前进。
1. 将修改后的演示文稿写入为演示文稿文件。
```javascript
// 实例化表示演示文稿文件的 Presentation 类
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // 在第 1 张幻灯片上应用圆形类型切换
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // 设置 3 秒的切换时间
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // 在第 2 张幻灯片上应用梳形类型切换
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // 设置 5 秒的切换时间
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // 在第 3 张幻灯片上应用缩放类型切换
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // 设置 7 秒的切换时间
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // 将演示文稿写入磁盘
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Morph 切换**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java 现在支持 [Morph Transition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MorphTransition)。它们代表在 PowerPoint 2019 中引入的新 Morph 切换。

{{% /alert %}} 

Morph 切换允许您对幻灯片之间的平滑移动进行动画化。本文描述了其概念以及如何使用 Morph 切换。要有效使用 Morph 切换，您需要拥有两张至少有一个公共对象的幻灯片。最简单的方法是复制幻灯片，然后将第二张幻灯片上的对象移动到其他位置。

下面的代码片段演示了如何向演示文稿中添加带有文本的幻灯片克隆，并为第二张幻灯片设置 [morph type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionType) 切换。
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Morph 切换类型**
新增了 [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionMorphType) 枚举。它表示不同类型的 Morph 幻灯片切换。

TransitionMorphType 枚举有三个成员：

- ByObject：Morph 切换将在将形状视为不可分割的对象时执行。
- ByWord：Morph 切换将在可能的情况下按词转移文本进行执行。
- ByChar：Morph 切换将在可能的情况下按字符转移文本进行执行。

下面的代码片段展示了如何为幻灯片设置 Morph 切换并更改 Morph 类型：
```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **设置切换效果**
Aspose.Slides for Node.js via Java 支持设置切换效果，例如，从黑色、从左、从右等。要设置切换效果，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
- 获取幻灯片的引用。
- 设置切换效果。
- 将演示文稿写入为 [PPTX ](https://docs.fileformat.com/presentation/pptx/) 文件。

以下示例中，我们已经设置了切换效果。
```javascript
// 创建 Presentation 类的实例
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // 设置效果
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // 将演示文稿写入磁盘
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**我可以控制幻灯片切换的播放速度吗？**

是的。使用 [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) 设置来设置切换的 [speed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setspeed/)（例如，slow/medium/fast）。

**我可以为切换附加音频并使其循环吗？**

是的。您可以为切换嵌入声音，并通过诸如声音模式和循环等设置来控制行为（例如，[setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsound/)、[setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/)、[setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/)），加上元数据如 [setSoundIsBuiltIn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) 和 [setSoundName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundname/)。

**将相同的切换应用于每张幻灯片的最快方法是什么？**

在每张幻灯片的切换设置上配置所需的切换类型；切换是按幻灯片存储的，因此在所有幻灯片上使用相同的类型即可实现一致的效果。

**我如何检查幻灯片当前设置了哪个切换？**

检查幻灯片的 [transition settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) 并读取其 [transition type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/gettype/)；该值会明确指示当前应用的效果。