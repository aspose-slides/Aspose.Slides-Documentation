---
title: "使用 PHP 管理演示文稿中的幻灯片切换"
linktitle: "幻灯片切换"
type: docs
weight: 80
url: /zh/php-java/slide-transition/
keywords:
- "幻灯片切换"
- "添加幻灯片切换"
- "应用幻灯片切换"
- "高级幻灯片切换"
- "形态切换"
- "切换类型"
- "切换效果"
- "PowerPoint"
- "OpenDocument"
- "演示文稿"
- "PHP"
- "Aspose.Slides"
description: "了解如何在 Aspose.Slides for PHP via Java 中自定义幻灯片切换，提供针对 PowerPoint 和 OpenDocument 演示文稿的分步指南。"
---

## **概述**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 也允许开发人员管理或自定义幻灯片的切换效果。 在本主题中，我们将讨论如何使用 Aspose.Slides for PHP via Java 轻松控制幻灯片切换。

{{% /alert %}} 

为了更容易理解，我们演示了使用 Aspose.Slides for PHP via Java 管理简单幻灯片切换的用法。 开发人员不仅可以在幻灯片上应用不同的切换效果，还可以自定义这些切换效果的行为。

## **添加幻灯片切换**
要创建一个简单的幻灯片切换效果，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
2. 通过 TransitionType 枚举，从 Aspose.Slides for PHP via Java 提供的过渡效果中，对幻灯片应用 Slide Transition Type。
3. 写入修改后的演示文稿文件。
```php
  # 实例化 Presentation 类以加载源演示文稿文件
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # 在第 1 张幻灯片上应用圆形过渡
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # 在第 2 张幻灯片上应用梳形过渡
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # 将演示文稿写入磁盘
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **添加高级幻灯片切换**
在上述部分，我们仅对幻灯片应用了一个简单的切换效果。现在，为了使该简单切换效果更好、更可控，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
2. 通过 Aspose.Slides for PHP via Java 提供的过渡效果之一，对幻灯片应用 Slide Transition Type。
3. 您还可以将切换设置为单击后前进、在特定时间段后前进，或两者兼而有之。
4. 如果幻灯片切换被设置为单击后前进，则只有在点击鼠标时才会前进。此外，如果设置了 Advance After Time 属性，则在指定的前进时间过去后，切换会自动前进。
5. 将修改后的演示文稿写入为演示文稿文件。
```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # 在第 1 张幻灯片上应用圆形过渡
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # 设置 3 秒的切换时间
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # 在第 2 张幻灯片上应用梳形过渡
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # 设置 5 秒的切换时间
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # 在第 3 张幻灯片上应用缩放过渡
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # 设置 7 秒的切换时间
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # 将演示文稿写入磁盘
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **形态切换**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 现在支持 [Morph Transition](https://reference.aspose.com/slides/php-java/aspose.slides/IMorphTransition)。它们代表了 PowerPoint 2019 中引入的新形态切换。

{{% /alert %}} 

形态切换允许您在幻灯片之间实现平滑的动画移动。本文介绍了其概念以及如何使用形态切换。要有效使用形态切换，您需要有两张至少包含一个共同对象的幻灯片。最简便的方法是复制幻灯片，然后将第二张幻灯片上的对象移动到其他位置。

以下代码片段展示了如何向演示文稿中添加带有文本的幻灯片克隆，并为第二张幻灯片设置 [morph type](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) 过渡。
```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **形态切换类型**
新增了 [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType) 枚举。它表示不同类型的形态幻灯片切换。

TransitionMorphType 枚举有三个成员：

- ByObject: 形态切换将在将形状视为不可分割对象的前提下执行。
- ByWord: 形态切换将在可能的情况下按单词转移文本执行。
- ByChar: 形态切换将在可能的情况下按字符转移文本执行。

以下代码片段展示了如何为幻灯片设置形态切换并更改形态类型：
```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **设置切换效果**
Aspose.Slides for PHP via Java 支持设置诸如“从黑色”“从左”“从右”等切换效果。要设置切换效果，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
- 获取幻灯片的引用。
- 设置切换效果。
- 将演示文稿写入为 [PPTX ](https://docs.fileformat.com/presentation/pptx/) 文件。

在下面给出的示例中，我们已经设置了切换效果。
```php
  # 创建 Presentation 类的实例
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # 设置效果
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # 将演示文稿写入磁盘
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **FAQ**

**我可以控制幻灯片切换的播放速度吗？**

是的。使用 [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) 设置来设置切换的 [speed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setspeed/)，例如 slow/medium/fast。

**我可以为切换附加音频并使其循环吗？**

是的。您可以为切换嵌入声音，并通过诸如 sound mode 和 looping 等设置来控制其行为（例如，[setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsound/)，[setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundmode/)，[setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundloop/)，以及元数据如 [setSoundIsBuiltIn](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) 和 [setSoundName](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundname/)）。

**将相同的切换应用于每张幻灯片的最快方法是什么？**

在每张幻灯片的切换设置中配置所需的切换类型；切换是按幻灯片存储的，因此在所有幻灯片上使用相同的类型即可实现一致的结果。

**我如何检查幻灯片当前设置了哪种切换？**

检查幻灯片的 [transition settings](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 并读取其 [transition type](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/settype/)，该值即可明确显示当前应用的效果。