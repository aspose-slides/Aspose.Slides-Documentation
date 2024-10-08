---
title: 形状动画
type: docs
weight: 60
url: /zh/php-java/shape-animation/
keywords: "PowerPoint 动画, 动画效果, 应用动画, PowerPoint 演示文稿, Java, Aspose.Slides for PHP via Java"
description: "应用 PowerPoint 动画 "
---

动画是可以应用于文本、图像、形状或 [图表](https://docs.aspose.com/slides/php-java/animated-charts/) 的视觉效果。它们为演示文稿及其组成部分注入活力。

### **为什么在演示文稿中使用动画？**

使用动画，您可以

* 控制信息流
* 强调重要点
* 增加观众的兴趣或参与感
* 使内容更易于阅读、吸收或处理
* 吸引读者或观众注意演示文稿中的重要部分

PowerPoint 在 **入场**、**退场**、**强调** 和 **运动路径** 类型中提供了许多动画和动画效果的选项和工具。

### **Aspose.Slides中的动画**

* Aspose.Slides 提供了您在 `Aspose.Slides.Animation` 命名空间下需要处理动画的类和类型，
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype) 枚举下提供了超过 **150 种动画效果**。这些效果与 PowerPoint 中使用的效果基本相同（或等效）。

## **将动画应用于文本框**

Aspose.Slides for PHP via Java 允许您将动画应用于形状中的文本。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape)。
4. 将文本添加到 [IAutoShape.TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-)。
5. 获取主效果序列。
6. 将动画效果添加到 [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape)。
7. 将 `TextAnimation.BuildType` 属性设置为 `BuildType` 枚举中的值。
8. 将演示文稿保存为 PPTX 文件。

以下 PHP 代码展示了如何将 `Fade` 效果应用于 AutoShape，并将文本动画设置为 *按 1 级段落* 值：

```php
  # 实例化代表演示文稿文件的演示文稿类。
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # 添加带有文本的新 AutoShape
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("第一段 \n第二段 \n第三段");
    # 获取幻灯片的主序列。
    $sequence = $sld->getTimeline()->getMainSequence();
    # 向形状添加淡入动画效果
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # 根据 1 级段落为形状文本设置动画
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # 将 PPTX 文件保存到磁盘
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

除了将动画应用于文本，您还可以将动画应用于单个 [段落](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph)。请参见 [**动画文本**](/slides/zh/php-java/animated-text/)。

{{% /alert %}} 

## **将动画应用于图片框**

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 在幻灯片上添加或获取 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe)。
4. 获取主效果序列。
5. 将动画效果添加到 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe)。
6. 将演示文稿保存为 PPTX 文件。

以下 PHP 代码展示了如何将 `Fly` 效果应用于图片框：

```php
  # 实例化代表演示文稿文件的演示文稿类。
  $pres = new Presentation();
  try {
    # 加载要添加到演示文稿图像集合中的图像
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 将图片框添加到幻灯片
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # 获取幻灯片的主序列。
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # 向图片框添加从左侧飞入的动画效果
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # 将 PPTX 文件保存到磁盘
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **将动画应用于形状**

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape)。
4. 添加一个 `Bevel` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape)（当单击此对象时，播放动画）。
5. 在斜面形状上创建一系列效果。
6. 创建一个自定义 `UserPath`。
7. 为移动到 `UserPath` 添加命令。
8. 将演示文稿保存为 PPTX 文件。

以下 PHP 代码展示了如何将 `PathFootball`（路径足球）效果应用于形状：

```php
  # 实例化代表 PPTX 文件的演示文稿类。
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # 从头开始为现有形状创建 PathFootball 效果。
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("动画文本框");
    # 添加 PathFootBall 动画效果
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # 创建某种“按钮”。
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # 为此按钮创建一系列效果。
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # 创建一个自定义用户路径。我们的对象只会在点击按钮后移动。
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # 添加移动的命令，因为创建的路径是空的。
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # 将 PPTX 文件写入磁盘
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **获取应用于形状的动画效果**

您可能希望找出应用于单个形状的所有动画效果。

以下 PHP 代码展示了如何获取应用于特定形状的所有效果：

```php
  # 实例化代表演示文稿文件的演示文稿类。
  $pres = new Presentation("AnimExample_out.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # 获取幻灯片的主序列。
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # 获取幻灯片上的第一个形状。
    $shape = $firstSlide->getShapes()->get_Item(0);
    # 获取应用于该形状的所有动画效果。
    $shapeEffects = $sequence->getEffectsByShape($shape);
    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("形状 " . $shape->getName() . " 有 " . $Array->getLength($shapeEffects) . " 个动画效果。");
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **更改动画效果的计时属性**

Aspose.Slides for PHP via Java 允许您更改动画效果的计时属性。

这是 Microsoft PowerPoint 中的动画计时窗格：

![example1_image](shape-animation.png)

这些是 PowerPoint 计时和 [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) 属性之间的对应关系：

- PowerPoint 计时 **开始** 下拉列表与 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerType--) 属性相匹配。
- PowerPoint 计时 **持续时间** 与 [Effect.Timing.Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getDuration--) 属性相匹配。动画的持续时间（以秒为单位）是动画完成一个周期所需的总时间。
- PowerPoint 计时 **延迟** 与 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerDelayTime--) 属性相匹配。

这是您如何更改效果计时属性：

1. [应用](#apply-animation-to-shape) 或获取动画效果。
2. 为所需的 [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) 属性设置新值。
3. 保存修改后的 PPTX 文件。

以下PHP代码演示了该操作：

```php
  # 实例化代表演示文稿文件的演示文稿类。
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # 获取幻灯片的主序列。
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # 获取主序列的第一个效果。
    $effect = $sequence->get_Item(0);
    # 将效果 TriggerType 更改为单击时开始
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # 更改效果持续时间
    $effect->getTiming()->setDuration(3.0);
    # 更改效果 TriggerDelayTime
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # 将 PPTX 文件保存到磁盘
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **动画效果声音**

Aspose.Slides 提供这些属性以允许您在动画效果中使用声音：

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **添加动画效果声音**

以下 PHP 代码展示了如何添加动画效果声音，并在下一个效果开始时停止它：

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # 向演示文稿音频集合添加音频
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # 获取幻灯片的主序列。
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # 获取主序列的第一个效果
    $firstEffect = $sequence->get_Item(0);
    # 检查效果是否为“无声音”
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # 为第一个效果添加声音
      $firstEffect->setSound($effectSound);
    }
    # 获取幻灯片的第一个交互序列。
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # 设置效果“停止之前的声音”标志
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # 将 PPTX 文件写入磁盘
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **提取动画效果声音**

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 获取效果的主序列。 
4. 提取嵌入在每个动画效果中的 [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)。

以下 PHP 代码展示了如何提取嵌入在动画效果中的声音：

```php
  # 实例化代表演示文稿文件的演示文稿类。
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 获取幻灯片的主序列。
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # 以字节数组提取效果声音
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **动画之后**

Aspose.Slides for PHP via Java 允许您更改动画效果的之后动画属性。

这是 Microsoft PowerPoint 中的动画效果窗格和扩展菜单：

![example1_image](shape-after-animation.png)

PowerPoint 效果 **之后动画** 下拉列表与以下属性相匹配：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationType-int-) 属性描述了之后动画类型：
  * PowerPoint **更多颜色** 匹配 [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) 类型；
  * PowerPoint **不暗淡** 列表项匹配 [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) 类型（默认之后动画类型）；
  * PowerPoint **动画后隐藏** 项匹配 [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation) 类型；
  * PowerPoint **在下次鼠标单击时隐藏** 项匹配 [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) 类型；
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) 属性定义了之后动画颜色格式。此属性与 [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) 类型协同工作。如果您将类型更改为其他类型，则会清除之后动画颜色。

以下 PHP 代码展示了如何更改之后动画效果：

```php
  # 实例化代表演示文稿文件的演示文稿类
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # 获取主序列的第一个效果
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # 将之后动画类型更改为颜色
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # 设置之后动画暗淡颜色
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # 将 PPTX 文件写入磁盘
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **动画文本**

Aspose.Slides 提供这些属性以允许您在动画效果的 *动画文本* 块中工作：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) 描述了效果的动画文本类型。形状文本可以动画化：
  - 一次性（[AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce) 类型）
  - 按字（[AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord) 类型）
  - 按字母（[AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter) 类型）
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 设置动画文本部分（单词或字母）之间的延迟。正值指定效果持续时间的百分比。负值指定秒数的延迟。

这是您如何更改效果动画文本属性：

1. [应用](#apply-animation-to-shape) 或获取动画效果。
2. 将 [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/itextanimation/#setBuildType-int-) 属性设置为 [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject) 值以关闭 *按段落* 动画模式。
3. 为 [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) 和 [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 属性设置新值。
4. 保存修改后的 PPTX 文件。

以下 PHP 代码演示了该操作：

```php
  # 实例化代表演示文稿文件的演示文稿类。
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # 获取主序列的第一个效果
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # 将效果文本动画类型更改为“作为一个对象”
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # 将效果动画文本类型更改为“按字”
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # 将单词之间的延迟设置为效果持续时间的 20%
    $firstEffect->setDelayBetweenTextParts(20.0);
    # 将 PPTX 文件写入磁盘
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```