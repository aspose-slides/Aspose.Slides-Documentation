---
title: 使用 PHP 管理演示文稿中的幻灯片过渡
linktitle: 幻灯片过渡
type: docs
weight: 80
url: /zh/php-java/slide-transition/
keywords:
- 幻灯片过渡
- 添加幻灯片过渡
- 应用幻灯片过渡
- 高级幻灯片过渡
- Morph 过渡
- 过渡类型
- 过渡效果
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 应用幻灯片过渡，配置自动幻灯片前进，并自定义 Morph 及其他过渡效果。"
---
## **概述**

幻灯片过渡控制幻灯片在放映过程中如何出现。使用 Aspose.Slides for PHP via Java，您可以为每张幻灯片选择过渡效果，配置通过鼠标点击或计时器的前进方式，并调整特定于某种效果的选项。本文使用 PHP 示例来应用过渡、设置精确的过渡持续时间、管理幻灯片计时，并在两张幻灯片之间创建 Morph 过渡。示例还展示了如何将设置保存为 PPTX 文件。

## **添加幻灯片过渡**

要应用过渡，使用 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类加载演示文稿，并通过 [getSlideShowTransition](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseslide/#getSlideShowTransition) 访问幻灯片的过渡设置。使用来自 [TransitionType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/transitiontype/) 枚举的值调用 [setType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setType)，然后保存演示文稿。

下面的示例将 Circle 过渡应用于第一张幻灯片，Comb 过渡应用于第二张幻灯片。使用至少包含两张幻灯片的 `input.pptx` 文件。

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

## **添加高级幻灯片过渡**

您可以配置幻灯片在屏幕上停留的时间以及是否通过鼠标点击推进放映。以下方法控制此行为：

- [setAdvanceOnClick](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 允许观看者通过点击鼠标来前进。
- [setAdvanceAfter](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 启用自动前进。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 指定自动前进前的延迟时间（毫秒）。

同时启用点击和计时前进，以便观看者可以点击继续或等待计时器。若仅使用计时器，请向 [setAdvanceOnClick](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 传递 `false`。延迟决定放映何时前进；它不设定视觉过渡效果的持续时间。

此示例为前三张幻灯片分配不同的效果，并分别在 3、5、7 秒后启用自动前进。鼠标点击也可以推进这些幻灯片。使用至少包含三张幻灯片的 `input.pptx` 文件。

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

要检查是否已启用计时前进，请调用 [getAdvanceAfter](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter)。仅存储的延迟并不表明计时器已激活。

下面的示例打开上面保存的文件，报告每个已启用的计时器，并对延迟大于两秒的幻灯片禁用自动前进。为这些幻灯片启用鼠标点击并保存更新后的设置。

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

## **精确控制过渡时机**

使用 [setDuration](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setDuration) 可以以毫秒为单位指定过渡效果的精确时长。幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseslide/#getSlideShowTransition) 方法通过 [SlideShowTransition](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/) 暴露这些设置：

| 方法 | 目的 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setDuration) | 设置过渡效果本身的持续时间（毫秒）。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 设置幻灯片自动前进前的延迟（毫秒）。将 `true` 传递给 [setAdvanceAfter](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 以激活此计时器。 |
| [setSpeed](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setSpeed) | 从 [TransitionSpeed](https://reference.aspose.com/slides/zh/php-java/aspose.slides/transitionspeed/) 选择预定义的速度类别：Slow、Medium 或 Fast。当未指定精确持续时间时使用。 |

[setDuration] 仅控制过渡效果本身；它不决定幻灯片保持可见的时长。自动前进的延迟需单独配置。当未设置显式持续时间时，Aspose.Slides 会根据过渡类型和 [getSpeed](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#getSpeed) 的值来确定效果时长。

### **为每张幻灯片应用相同的持续时间**

为了保持一致的节奏，对每张幻灯片应用相同的效果和精确的持续时间。此示例加载 `input.pptx`，从 [TransitionType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/transitiontype/) 中选择 Fade，并为每个过渡设置 750 毫秒的持续时间。随后分别启用 5,000 毫秒后的自动前进，并禁用鼠标点击前进，最后将结果保存为 PPTX。

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

        // 配置自动前进，独立于效果持续时间。
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **为各幻灯片单独设置不同的持续时间**

不同的幻灯片可以使用不同的效果持续时间。例如，对标题幻灯片使用短暂的过渡，对章节介绍幻灯片使用较长的过渡。此示例为第一张幻灯片设置 500 毫秒，为第二张幻灯片设置 1,200 毫秒。使用至少包含两张幻灯片的 `input.pptx` 文件。

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

### **将过渡与动画输出同步**

在准备 [animated GIF](/slides/zh/php-java/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh/php-java/export-to-html5/) 或 [video](/slides/zh/php-java/convert-powerpoint-to-video/) 时，需要在导出前设置精确的过渡持续时间，以匹配预期的节奏。例如，在场景之间使用 600 毫秒的淡入淡出，并分别调整每张幻灯片的前进延迟，以留出旁白或内容的时间。

对于 GIF 和视频，需要将输出帧率与效果持续时间对应：600 毫秒相当于 30 帧每秒下的 18 帧。在 HTML5 中，在导出设置中启用动画过渡。检查所选导出格式支持的效果和时间选项，并预览输出以确认同步。

### **读取已有的过渡持续时间**

在修改过渡前调用 [getDuration](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#getDuration) 以确定是否存有显式值。值为 `-1` 表示未设置显式持续时间；非负值表示以毫秒为单位存储的持续时间。未设置的值并非计算得到的播放时长：Aspose.Slides 会根据过渡类型和 [getSpeed](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#getSpeed) 的值来确定时长。设置过渡类型可能会初始化持续时间，因此请先检查原始设置。

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

## **Morph 过渡**

Morph 过渡在连续幻灯片之间对对象的变化进行动画处理。要创建简易的 Morph 效果，可克隆一张幻灯片，在克隆上移动或调整对象大小，然后将 Morph 过渡应用于第二张幻灯片。这使得对应的对象在原始状态和修改后状态之间进行动画。

下面的示例创建一个包含文本矩形的幻灯片，克隆该幻灯片，并在克隆上更改矩形的位置和大小。随后在第二张幻灯片上从 [TransitionType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/transitiontype/) 枚举中选择 Morph。使用支持 Morph 的演示文稿查看器打开保存的文件，即可在放映时看到效果。

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

## **Morph 过渡类型**

[TransitionMorphType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/transitionmorphtype/) 枚举控制 Morph 匹配和动画化内容的方式：

- [ByObject](https://reference.aspose.com/slides/zh/php-java/aspose.slides/transitionmorphtype/#ByObject) 将每个形状视为整体对象。
- [ByWord](https://reference.aspose.com/slides/zh/php-java/aspose.slides/transitionmorphtype/#ByWord) 在可能的情况下按词匹配来动画化文本。
- [ByChar](https://reference.aspose.com/slides/zh/php-java/aspose.slides/transitionmorphtype/#ByChar) 在可能的情况下按字符匹配来动画化文本。

在访问 [getValue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#getValue) 之前，使用 [setType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setType) 选择 Morph。返回的值提供一个 [MorphTransition](https://reference.aspose.com/slides/zh/php-java/aspose.slides/morphtransition/) 对象，可通过其 [setMorphType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/morphtransition/#setMorphType) 方法选择匹配模式。

此示例打开上一节创建的演示文稿，并将第二张幻灯片配置为使用基于单词的 Morph 动画。

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

## **设置过渡效果**

某些过渡会暴露额外选项，例如方向或是否从黑屏开始。可用选项取决于使用 [setType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setType) 选择的过渡。首先设置类型，然后使用来自 [getValue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#getValue) 的相应过渡对象。

下面的示例对 `input.pptx` 的第一张幻灯片应用 Cut 过渡。它通过 [OptionalBlackTransition](https://reference.aspose.com/slides/zh/php-java/aspose.slides/optionalblacktransition/) 调用 [setFromBlack](https://reference.aspose.com/slides/zh/php-java/aspose.slides/optionalblacktransition/#setFromBlack)，使过渡从黑屏开始。

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

**我可以控制幻灯片过渡的播放速度吗？**

可以。需要精确的毫秒级效果时首选 [setDuration](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setDuration)。如果预定义的 [TransitionSpeed](https://reference.aspose.com/slides/zh/php-java/aspose.slides/transitionspeed/) 类别（Slow、Medium、Fast）足够且未设置显式持续时间，则使用 [setSpeed](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setSpeed)。这些设置独立于自动前进延迟，控制过渡效果本身。

**我可以为过渡附加音频并使其循环吗？**

可以。使用 [setSound](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setSound) 为过渡分配嵌入式音频，将 [TransitionSoundMode](https://reference.aspose.com/slides/zh/php-java/aspose.slides/transitionsoundmode/) 枚举中的 StartSound 传递给 [setSoundMode](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setSoundMode)，并将 [setSoundLoop](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setSoundLoop) 设置为 `true`。音频会循环播放，直至幻灯片放映中的下一个声音事件。

**将相同过渡快速应用于每张幻灯片的最快方法是什么？**

遍历演示文稿的 [getSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getSlides) 集合，对每张幻灯片的过渡调用相同的 [setType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#setType) 值。将任何计时和效果选项也在同一循环中设置，以保持各幻灯片行为一致。

**我如何检查幻灯片上当前设置的过渡是什么？**

在幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseslide/#getSlideShowTransition) 结果上调用 [getType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideshowtransition/#getType)。它返回 [TransitionType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/transitiontype/) 枚举中的值；None 表示未应用任何过渡效果。