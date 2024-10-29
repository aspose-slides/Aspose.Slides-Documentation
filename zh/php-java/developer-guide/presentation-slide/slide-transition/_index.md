---
title: 幻灯片过渡
type: docs
weight: 80
url: /zh/php-java/slide-transition/
keywords: "PowerPoint 幻灯片过渡, 形态过渡"
description: "PowerPoint 幻灯片过渡, PowerPoint 形态过渡"
---


## **概述**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 还允许开发者管理或自定义幻灯片的过渡效果。在本主题中，我们将讨论如何使用 Aspose.Slides for PHP via Java 轻松控制幻灯片过渡。

{{% /alert %}} 

为了便于理解，我们演示了如何使用 Aspose.Slides for PHP via Java 管理简单的幻灯片过渡。开发者不仅可以在幻灯片上应用不同的幻灯片过渡效果，还可以自定义这些过渡效果的行为。

## **添加幻灯片过渡**
要创建一个简单的幻灯片过渡效果，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 通过 TransitionType 枚举在幻灯片上应用一个黑色的过渡类型。
1. 写入修改后的演示文件。

```php
  # 实例化 Presentation 类以加载源演示文件
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # 在幻灯片 1 上应用圆形过渡
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # 在幻灯片 2 上应用组合过渡
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # 将演示文稿写入磁盘
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **添加高级幻灯片过渡**
在以上部分，我们只是在幻灯片上应用了一个简单的过渡效果。现在，为了使该简单过渡效果更好且更可控，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 从 Aspose.Slides for PHP via Java 提供的过渡效果中应用一个幻灯片过渡类型。
1. 您还可以将过渡设置为单击后自动前进、在特定时间段后自动前进或两者皆有。
1. 如果启用了单击前进的过渡，则只有在有人单击鼠标时，过渡才会向前推进。此外，如果设置了延迟时间属性，过渡将在指定的延迟时间之后自动前进。
1. 将修改后的演示写出为演示文件。

```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # 在幻灯片 1 上应用圆形过渡
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # 设置过渡时间为 3 秒
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # 在幻灯片 2 上应用组合过渡
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # 设置过渡时间为 5 秒
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # 在幻灯片 3 上应用缩放过渡
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # 设置过渡时间为 7 秒
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # 将演示文稿写入磁盘
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **形态过渡**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 现在支持 [形态过渡](https://reference.aspose.com/slides/php-java/aspose.slides/IMorphTransition)。它们代表 PowerPoint 2019 中引入的新形态过渡。

{{% /alert %}} 

形态过渡允许您在一张幻灯片与下一张幻灯片之间实现平滑的运动动画。本文描述了形态过渡的概念以及如何使用它。要有效使用形态过渡，您需要有两张幻灯片，且至少有一个共同的对象。最简单的方法是复制幻灯片，然后将第二张幻灯片上的对象移动到不同的位置。

以下代码片段演示了如何向演示文稿中添加带有一些文本的幻灯片克隆，并将第二张幻灯片的过渡设置为 [形态类型](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType)。

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("PowerPoint 演示文稿中的形态过渡");
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

## **形态过渡类型**
新增了 [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType) 枚举。它表示不同类型的形态幻灯片过渡。

TransitionMorphType 枚举有三个成员：

- ByObject: 在进行形态过渡时将形状视为不可分割的对象。
- ByWord: 在进行形态过渡时尽可能按单词传递文本。
- ByChar: 在进行形态过渡时尽可能按字符传递文本。

以下代码片段演示了如何设置形态过渡到幻灯片并更改形态类型：

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

## **设置过渡效果**
Aspose.Slides for PHP via Java 支持设置过渡效果，例如，从黑色、从左侧、从右侧等。为设置过渡效果，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
- 获取幻灯片的引用。
- 设置过渡效果。
- 将演示文稿作为 [PPTX](https://docs.fileformat.com/presentation/pptx/)文件写入。

在下面给出的示例中，我们设置了过渡效果。

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