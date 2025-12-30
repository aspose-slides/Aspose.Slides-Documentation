---
title: 在演示文稿中使用 PHP 应用形状动画
linktitle: 形状动画
type: docs
weight: 60
url: /zh/php-java/shape-animation/
keywords:
- 形状
- 动画
- 效果
- 动画形状
- 动画文本
- 添加动画
- 获取动画
- 提取动画
- 添加效果
- 获取效果
- 提取效果
- 效果声音
- 应用动画
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中创建和自定义形状动画。脱颖而出！"
---

动画是可以应用于文本、图像、形状或[charts](https://docs.aspose.com/slides/php-java/animated-charts/)的视觉效果。它们为演示文稿或其组成部分赋予生命。

## **为何在演示文稿中使用动画？**

使用动画，您可以  

* 控制信息的流动  
* 强调重要要点  
* 提升观众的兴趣或参与度  
* 使内容更易阅读、吸收或处理  
* 将读者或观众的注意力引导至演示文稿中的重要部分  

PowerPoint 在 **入口**、**退出**、**强调** 和 **运动路径** 类别中提供了众多动画选项和工具。 

## **Aspose.Slides 中的动画**

* Aspose.Slides 在 `Aspose.Slides.Animation` 命名空间下提供了处理动画所需的类和类型，  
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype) 枚举下提供了超过 **150** 种动画效果。这些效果本质上与 PowerPoint 中使用的效果相同（或等价）。

## **将动画应用于文本框**

Aspose.Slides for PHP via Java 允许您对形状中的文本应用动画。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape)。  
4. 向 [IAutoShape.TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-) 添加文本。  
5. 获取主效果序列。  
6. 向 [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) 添加动画效果。  
7. 将 `TextAnimation.BuildType` 属性设置为 `BuildType` 枚举中的值。  
8. 将演示文稿写入磁盘，保存为 PPTX 文件。  

下面的 PHP 代码演示如何将 `Fade` 效果应用于 AutoShape 并将文本动画设置为 *By 1st Level Paragraphs* 值：
```php
  # 实例化表示演示文稿文件的 Presentation 类。
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # 添加带文本的新 AutoShape
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # 获取幻灯片的主序列。
    $sequence = $sld->getTimeline()->getMainSequence();
    # 为形状添加 Fade 动画效果
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # 按第一层段落为形状文本设置动画
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # 将 PPTX 文件保存至磁盘
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{%  alert color="primary"  %}} 

除了对文本应用动画外，您还可以对单个[Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph)应用动画。请参阅[**Animated Text**](/slides/zh/php-java/animated-text/)。

{{% /alert %}} 

## **将动画应用于图片框**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 在幻灯片上添加或获取一个 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe)。  
4. 获取主效果序列。  
5. 向 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) 添加动画效果。  
6. 将演示文稿写入磁盘，保存为 PPTX 文件。  

下面的 PHP 代码演示如何将 `Fly` 效果应用于图片框：
```php
  # 实例化一个表示演示文稿文件的 Presentation 类。
  $pres = new Presentation();
  try {
    # 加载要添加到演示文稿图像集合的图像
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 向幻灯片添加图片框
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # 获取幻灯片的主序列。
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # 向图片框添加从左侧 Fly 动画效果
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

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape)。  
4. 添加一个 `Bevel` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape)（当点击此对象时，动画将播放）。  
5. 在斜面形状上创建效果序列。  
6. 创建自定义 `UserPath`。  
7. 添加移动到 `UserPath` 的命令。  
8. 将演示文稿写入磁盘，保存为 PPTX 文件。  

下面的 PHP 代码演示如何将 `PathFootball`（路径足球）效果应用于形状：
```php
  # 实例化一个表示 PPTX 文件的 Presentation 类。
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # 为已有形状从头创建 PathFootball 效果。
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # 添加 PathFootBall 动画效果
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # 创建某种 "按钮"。
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # 为该按钮创建一系列效果。
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # 创建自定义用户路径。只有在点击按钮后才会移动对象。
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # 为空路径添加移动命令。
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

以下示例演示如何使用来自 [Sequence](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/) 类的 `getEffectsByShape` 方法来获取应用于形状的所有动画效果。

**示例 1：获取普通幻灯片上形状的动画效果**

之前，您已经学习了如何在 PowerPoint 演示文稿中向形状添加动画效果。以下示例代码演示如何获取演示文稿 `AnimExample_out.pptx` 中第一张普通幻灯片上第一个形状所应用的效果。
```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # 获取幻灯片的主动画序列。
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # 获取第一张幻灯片上的第一个形状。
    $shape = $firstSlide->getShapes()->get_Item(0);

    # 获取应用于该形状的动画效果。
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


**示例 2：获取所有动画效果，包括从占位符继承的效果**

如果普通幻灯片上的形状拥有位于布局幻灯片和/或母版幻灯片上的占位符，并且这些占位符已添加动画效果，则在放映过程中该形状将播放所有效果，包括从占位符继承的效果。

假设我们有一个 PowerPoint 演示文稿文件 `sample.pptx`，其中仅有一张幻灯片，包含一个仅包含文本 “Made with Aspose.Slides” 的页脚形状，并对该形状应用了 **Random Bars** 效果。

![幻灯片形状动画效果](slide-shape-animation.png)

再假设在 **布局** 幻灯片的页脚占位符上应用了 **Split** 效果。

![布局形状动画效果](layout-shape-animation.png)

最后，在 **母版** 幻灯片的页脚占位符上应用了 **Fly In** 效果。

![母版形状动画效果](master-shape-animation.png)

以下示例代码演示如何使用来自 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 类的 `getBasePlaceholder` 方法来访问形状占位符，并获取应用于页脚形状的动画效果，包括从布局和母版幻灯片上的占位符继承的效果。
```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// 获取普通幻灯片上形状的动画效果。
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// 获取布局幻灯片上占位符的动画效果。
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// 获取母版幻灯片上占位符的动画效果。
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```

```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```


```text
Main sequence of shape effects:
Type: 47, subtype: 2              // 飞入, 底部
Type: 134, subtype: 45            // 拆分, 垂直进入
Type: 126, subtype: 22            // 随机条形, 水平
```


## **更改动画效果的时间属性**

Aspose.Slides for PHP via Java 允许您更改动画效果的 Timing（时间）属性。

![PowerPoint 中的动画时间窗格](shape-animation.png)

- PowerPoint Timing **Start** 下拉列表对应 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerType--) 属性。  
- PowerPoint Timing **Duration** 对应 [Effect.Timing.Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getDuration--) 属性。动画的持续时间（以秒为单位）是动画完成一次循环所需的总时间。  
- PowerPoint Timing **Delay** 对应 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerDelayTime--) 属性。  

以下是更改 Effect Timing（效果时间）属性的方法：

1. [应用](#apply-animation-to-shape) 或获取动画效果。  
2. 为所需的 [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) 属性设置新值。  
3. 保存修改后的 PPTX 文件。  

下面的 PHP 代码演示此操作：
```php
  # 实例化一个表示演示文稿文件的 Presentation 类。
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # 获取幻灯片的主序列。
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # 获取主序列的第一个效果。
    $effect = $sequence->get_Item(0);
    # 将效果的 TriggerType 更改为点击时启动
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # 更改效果的持续时间
    $effect->getTiming()->setDuration(3.0);
    # 更改效果的 TriggerDelayTime
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

Aspose.Slides 提供以下属性，以便您在动画效果中使用声音：

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **添加动画效果声音**

下面的 PHP 代码展示如何添加动画效果声音，并在下一个效果开始时停止它：
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
    # 设置效果的“停止先前声音”标志
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

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 获取主效果序列。  
4. 提取嵌入到每个动画效果中的 [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)。  

下面的 PHP 代码展示如何提取嵌入在动画效果中的声音：
```php
  # 实例化表示演示文稿文件的 Presentation 类。
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 获取幻灯片的主序列。
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # 提取效果声音为字节数组
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **动画结束后**

Aspose.Slides for PHP via Java 允许您更改动画效果的 After animation（结束后）属性。

![PowerPoint 中的动画结束后窗格](shape-after-animation.png)

PowerPoint Effect **After animation** 下拉列表对应以下属性：

- `[setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationType-int-)` 属性描述了 After animation 类型：
  * PowerPoint **More Colors** 对应 [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) 类型；
  * PowerPoint **Don't Dim** 列表项对应 [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) 类型（默认的结束后动画类型）；
  * PowerPoint **Hide After Animation** 项对应 [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation) 类型；
  * PowerPoint **Hide on Next Mouse Click** 项对应 [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) 类型；
- `[setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-)` 属性定义了结束后动画的颜色格式。此属性与 [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) 类型一起使用。如果将类型更改为其他，结束后动画颜色将被清除。  

下面的 PHP 代码演示如何更改结束后动画效果：
```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # 获取主序列的第一个效果
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # 将之后动画类型更改为 Color
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # 设置之后动画的暗淡颜色
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

Aspose.Slides 提供以下属性，以便您使用动画效果的 *Animate text*（动画文本）块：

- `[setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-)` 用于描述效果的动画文本类型。形状文本可以被动画化：
  - 一次性全部（[AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce) 类型）
  - 按词（[AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord) 类型）
  - 按字母（[AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter) 类型）
- `[setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-)` 设置动画文本部件（词或字母）之间的延迟。正值表示效果持续时间的百分比，负值表示秒数。  

以下是更改 Effect Animate text（效果动画文本）属性的方法：

1. [应用](#apply-animation-to-shape) 或获取动画效果。  
2. 将 `[setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/itextanimation/#setBuildType-int-)` 属性设置为 `[BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject)` 值，以关闭 *By Paragraphs*（按段落）动画模式。  
3. 为 `[setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-)` 和 `[setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-)` 属性设置新值。  
4. 保存修改后的 PPTX 文件。  

下面的 PHP 代码演示此操作：
```php
  # 实例化表示演示文稿文件的 Presentation 类。
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # 获取主序列的第一个效果
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # 将效果文本动画类型更改为 "As One Object"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # 将动画文本类型更改为 "By word"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # 将词之间的延迟设置为效果持续时间的 20%
    $firstEffect->setDelayBetweenTextParts(20.0);
    # 将 PPTX 文件写入磁盘
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**如何确保在将演示文稿发布到 Web 时保留动画？**  
[Export to HTML5](/slides/zh/php-java/export-to-html5/) 并启用负责 [shape](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) 和 [transition](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/) 动画的 [options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/)。普通 HTML 不会播放幻灯片动画，而 HTML5 会。

**更改形状的 z 顺序（层级顺序）会如何影响动画？**  
动画和绘制顺序相互独立：效果控制出现/消失的时间和类型，而 [z-order](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) 确定哪个覆盖哪个。可见结果由两者组合决定。（这是 PowerPoint 的通用行为；Aspose.Slides 的效果与形状模型遵循相同逻辑。）

**将动画转换为视频时对某些效果是否有限制？**  
一般而言，[animations are supported](/slides/zh/php-java/convert-powerpoint-to-video/)，但在少数情况下或特定效果可能会有不同的渲染方式。建议使用您所使用的效果以及相应的库版本进行测试。