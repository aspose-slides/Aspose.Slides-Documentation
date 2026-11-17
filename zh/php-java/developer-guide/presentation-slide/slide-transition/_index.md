---
title: 使用 PHP 管理演示文稿中的幻灯片切换
linktitle: 幻灯片切换
type: docs
weight: 80
url: /zh/php-java/slide-transition/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 应用幻灯片切换，配置自动幻灯片前进，并自定义 Morph 等切换效果。"
---
## **概述**

幻灯片切换控制幻灯片在放映过程中如何出现。使用 Aspose.Slides for PHP via Java，您可以为每张幻灯片选择切换效果，配置通过鼠标点击或计时器的前进方式，并调整特定于某个效果的选项。本文使用 PHP 示例演示如何应用切换、设置精确的切换持续时间、管理幻灯片计时，以及在两张幻灯片之间创建 Morph 切换。示例还展示了如何将设置保存为 PPTX 文件。

## **添加幻灯片切换**

要应用切换，使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类加载演示文稿，并通过 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 访问幻灯片的切换设置。使用来自 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 枚举的值调用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType)，然后保存演示文稿。

下面的示例将 Circle 切换应用于第一张幻灯片，将 Comb 切换应用于第二张幻灯片。使用包含至少两张幻灯片的 `input.pptx` 文件。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **轮形切换**

使用 [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) 方法控制有多少径向扇区显示目标幻灯片。使用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 从 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 中选择 Wheel，然后调用 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) 来访问 [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/) 设置。

示例创建了两对相同的幻灯片。每对以一张黑色幻灯片开始，并以一张被金色矩形覆盖的幻灯片结束。第 2 张幻灯片使用一个辐条，第 4 张幻灯片使用八个辐条。两个切换均使用相同的慢速，通过 [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) 设置，并通过 [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 设置明确的 8,000 毫秒持续时间。

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slides = $presentation->getSlides();
    $width = java_values($presentation->getSlideSize()->getSize()->getWidth());
    $height = java_values($presentation->getSlideSize()->getSize()->getHeight());

    $blackSlide = $slides->get_Item(0);
    $blackSlide->getShapes()->clear();
    $background = $blackSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Solid);
    $black = new Color(0, 0, 0);
    $background->getFillFormat()->getSolidFillColor()->setColor($black);

    $destinationSlide = $slides->addClone($blackSlide);
    $rectangle = $destinationSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, $width, $height);
    $rectangle->getFillFormat()->setFillType(FillType::Solid);
    $gold = new Color(255, 215, 0);
    $rectangle->getFillFormat()->getSolidFillColor()->setColor($gold);
    $rectangle->getTextFrame()->setText("Wheel transition");

    $slides->addClone($blackSlide);
    $slides->addClone($destinationSlide);

    foreach ([1 => 1, 3 => 8] as $slideIndex => $spokes) {
        $transition = $slides->get_Item($slideIndex)->getSlideShowTransition();
        $transition->setType(TransitionType::Wheel);
        $transition->getValue()->setSpokes($spokes);
        $transition->setSpeed(TransitionSpeed::Slow);
        $transition->setDuration(8000);
    }

    $presentation->save("wheel-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在 PowerPoint 中打开保存的演示文稿并启动放映。从第 1 张幻灯片前进到第 2 张幻灯片，可看到一次顺时针扫过。然后从第 3 张幻灯片前进到第 4 张幻灯片，可看到八个径向扇区同时显示相同的矩形。

## **添加高级幻灯片切换**

您可以配置幻灯片在屏幕上的停留时间以及是否通过鼠标点击推进放映。以下方法控制此行为：

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 允许观众通过点击鼠标前进。
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 启用自动前进。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 指定自动前进前的延迟（毫秒）。

同时启用点击和计时前进，使观众可以点击继续或等待计时器。若仅使用计时器，请向 [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 传递 `false`。延迟决定放映何时前进；它并不设置视觉切换效果的持续时间。

本示例为前三张幻灯片分配不同的效果，并分别在 3、5、7 秒后启用自动前进。鼠标点击也可以推进这些幻灯片。使用包含至少三张幻灯片的 `input.pptx` 文件。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

要检查是否启用了计时前进，请调用 [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter)。仅有存储的延迟并不表示计时器已激活。

下面的示例打开上述保存的文件，报告每个已启用的计时器，并对延迟超过两秒的幻灯片禁用自动前进。为这些幻灯片启用鼠标点击并保存更新后的设置。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **精确控制切换计时**

使用 [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 指定切换效果的精确时长（毫秒）。幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 方法通过 [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) 公开这些设置：

| 方法 | 用途 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | 设置切换效果本身的持续时间，单位为毫秒。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 设置幻灯片自动前进之前的延迟，单位为毫秒。传入 `true` 给 [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 以激活此计时器。 |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | 从 [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) 中选择预定义的速度类别：Slow、Medium 或 Fast。当未指定精确持续时间时使用此设置。 |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 仅控制切换效果；它不决定幻灯片的可见时长。自动前进的延迟需要单独配置。当未设置明确的持续时间时，Aspose.Slides 会根据切换类型和 [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) 值来确定该时长。

<!-- visual-explanation:slide-transition:start -->
[![分隔的条形标识 750 毫秒的切换持续时间和 5,000 毫秒的自动前进设置。](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*该示例为每张幻灯片设置了 750 毫秒的淡入切换，并单独在 5,000 毫秒时启用自动前进。切换持续时间控制效果；前进控制何时离开幻灯片。这些条形是示意设置，而非实际测量的合并时间线。*
<!-- visual-explanation:slide-transition:end -->

### **将相同持续时间应用于每张幻灯片**

为了保持一致的节奏，为每张幻灯片应用相同的效果和精确的持续时间。本示例加载 `input.pptx`，从 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 中选择 Fade，并为每个切换设置 750 毫秒的持续时间。它分别在 5,000 毫秒后启用自动前进，并禁用鼠标点击前进，然后将结果保存为 PPTX。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // 独立配置自动前进，不受效果持续时间影响。
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **为各幻灯片设置不同的持续时间**

不同的幻灯片可以使用不同的效果持续时间。例如，标题幻灯片使用简短的切换，章节介绍使用较长的切换。本示例为第一张幻灯片设置 500 毫秒，为第二张幻灯片设置 1,200 毫秒。使用包含至少两张幻灯片的 `input.pptx` 文件。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **将切换与动画输出协调**

在准备 [动画 GIF](/slides/zh/php-java/convert-powerpoint-to-animated-gif/)、[HTML5 演示文稿](/slides/zh/php-java/export-to-html5/) 或 [视频](/slides/zh/php-java/convert-powerpoint-to-video/) 时，需在导出前设置精确的切换持续时间，以匹配预期的节奏。例如，在场景之间使用 600 毫秒的淡入切换，并单独调整每张幻灯片的前进延迟，以留出旁白或内容的时间。

对于 GIF 和视频，需要将输出帧率与效果持续时间对应：600 毫秒相当于 30 帧每秒下的 18 帧。在 HTML5 中，在导出设置中启用动画切换。检查所选导出格式支持的效果和计时选项，并预览输出以确认同步。

### **读取现有切换持续时间**

在修改切换之前调用 [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) 以确定是否存储了明确的值。值为 `-1` 表示未设置明确的持续时间；非负值表示以毫秒为单位的存储持续时间。未设置的值并非计算得到的播放时长：Aspose.Slides 使用切换类型和 [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) 值来确定该时长。设置切换类型可能会初始化持续时间，因此请先检查原始设置。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Morph 切换**

Morph 切换在相邻幻灯片之间为对象的变化提供动画效果。要创建简单的 Morph 效果，克隆一张幻灯片，在克隆上移动或调整对象大小，然后对第二张幻灯片应用 Morph 切换。这样切换会对相应的对象在原始状态和修改后状态之间进行动画。

下面的示例创建一个带有文本矩形的幻灯片，克隆该幻灯片，并在克隆上修改矩形的位置和大小。随后从 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 枚举中选择 Morph 作为第二张幻灯片的切换。使用支持 Morph 的演示文稿查看器打开保存的文件，即可在放映时看到该效果。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Morph 切换类型**

[TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) 枚举控制 Morph 如何匹配和动画化内容：

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) 将每个形状视为整体对象。
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) 在可能的情况下通过匹配单词来为文本提供动画。
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) 在可能的情况下通过匹配字符来为文本提供动画。

使用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 选择 Morph，然后再访问 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue)。该值返回一个 [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) 对象，可通过其 [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) 方法选择匹配模式。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **设置切换效果**

某些切换会公开额外的选项，例如方向或是否从黑屏开始。可用的选项取决于使用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 所选的切换。先设置类型，然后从 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) 获取相应的切换对象。

下面的示例对 `input.pptx` 的第一张幻灯片应用 Cut 切换。它通过 [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) 调用 [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack)，使切换从黑屏开始。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **常见问题**

**我能控制幻灯片切换的播放速度吗？**

是的。当需要精确的效果持续时间（毫秒）时，首选使用 [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration)。当预定义的 [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) 类别（Slow、Medium 或 Fast）已足够且未设置明确的持续时间时，使用 [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed)。这些设置独立于自动前进延迟，控制切换效果。

**我可以为切换附加音频并使其循环吗？**

是的。使用 [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound) 分配嵌入音频，将 [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) 枚举中的 StartSound 传递给 [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode)，并将 [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) 设置为 `true`。音频将循环播放，直至幻灯片放映中的下一个声音事件。

**将相同切换快速应用于每张幻灯片的最快方法是什么？**

遍历演示文稿的 [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) 集合，对每张幻灯片的切换调用相同的 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType)。在同一循环中设置所有计时和效果选项，以保持各幻灯片行为的一致性。

**我如何检查幻灯片当前设置了哪个切换？**

对幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 结果调用 [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType)。它返回来自 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 枚举的值；None 表示未应用任何切换效果。