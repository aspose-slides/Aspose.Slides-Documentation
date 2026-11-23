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
description: "使用 Aspose.Slides for PHP via Java 应用幻灯片切换、配置自动幻灯片前进，并自定义 Morph 以及其他切换效果。"
---
## **概述**

幻灯片切换控制幻灯片在幻灯片放映期间的显示方式。使用 Aspose.Slides for PHP via Java，您可以为每张幻灯片选择切换效果，配置通过鼠标点击或计时器进行的切换，并调整特定于某个效果的选项。本文使用 PHP 示例来应用切换、设置精确的切换持续时间、管理幻灯片计时，并在两张幻灯片之间创建 Morph 切换。这些示例还展示了如何将设置保存为 PPTX 文件。

## **添加幻灯片切换**

要应用切换，使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类加载演示文稿，并通过 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 访问幻灯片的切换设置。使用来自 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 枚举的值调用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType)，然后保存演示文稿。

以下示例对第一页应用 Circle 切换，对第二页应用 Comb 切换。请使用至少有两张幻灯片的 `input.pptx` 文件。

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

[setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) 方法控制有多少辐射扇区显示目标幻灯片。使用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 从 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 选择 Wheel，然后调用 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) 访问 [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/) 设置。

该示例创建了两对完全相同的幻灯片。每对以黑色幻灯片开始，以金色矩形覆盖的幻灯片结束。第 2 张幻灯片使用一个扇区，第 4 张幻灯片使用八个扇区。两种切换都使用相同的慢速，通过 [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) 设置，并通过 [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 设置明确的 8,000 毫秒持续时间。

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

在 PowerPoint 中打开保存的演示文稿并开始放映。从第 1 张幻灯片前进到第 2 张可看到一次顺时针扫过。然后从第 3 张幻灯片前进到第 4 张可看到八个辐射扇区同时揭示相同的矩形。

## **使用 Reveal 切换的淡入黑色**

将目标幻灯片的切换类型设为 Reveal，然后对其 [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/) 设置调用 [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack)。示例创建了一个青绿色源幻灯片和一个珊瑚色目标幻灯片，然后克隆两者。每对使用相同的两秒 Reveal 切换。只有第二对在淡入时经过黑色。

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionLeftRightDirectionType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $source = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addClone($source);

    foreach ([
        [$source, new Color(0, 128, 128), "Source"],
        [$destination, new Color(255, 127, 80), "Destination"],
    ] as [$slide, $color, $label]) {
        $slide->getBackground()->setType(BackgroundType::OwnBackground);
        $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
        $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
        $shape->getTextFrame()->setText($label);
        $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(44);
    }

    $presentation->getSlides()->addClone($source);
    $clonedDestination = $presentation->getSlides()->addClone($destination);
    foreach ([[$destination, false], [$clonedDestination, true]] as [$slide, $throughBlack]) {
        $slide->getSlideShowTransition()->setType(TransitionType::Reveal);
        $slide->getSlideShowTransition()->setSpeed(TransitionSpeed::Slow);
        $slide->getSlideShowTransition()->setDuration(2000);
        $slide->getSlideShowTransition()->getValue()->setDirection(TransitionLeftRightDirectionType::Left);
        $slide->getSlideShowTransition()->getValue()->setThroughBlack($throughBlack);
    }

    $presentation->save("reveal-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在 PowerPoint 中打开保存的演示文稿并开始放映。从第 1 张幻灯片前进到第 2 张可看到青绿色直接淡入珊瑚色。然后前进到第 3 张和第 4 张，屏幕会短暂变暗至近黑色后出现珊瑚色幻灯片。两张幻灯片保持各自的原始背景颜色。

下面的行展示了 PowerPoint 每半秒的帧。比较每行的中间帧即可看到效果。

![PowerPoint 播放时禁用淡入黑色（上）和启用淡入黑色（下）。仅底部行经过近黑色。](reveal-through-black.png)

## **添加高级幻灯片切换**

您可以配置幻灯片在屏幕上停留的时间以及是否通过鼠标点击前进幻灯片放映。以下方法控制此行为：

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 允许观看者通过点击鼠标前进。
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 启用自动前进。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 指定自动前进前的延迟（毫秒）。

同时启用点击和计时前进，使观看者可以点击前进或等待计时器。若仅使用计时器，向 [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 传入 `false`。延迟控制幻灯片放映何时前进；它不设置视觉切换效果的持续时间。

此示例为前三张幻灯片分配不同的效果，并分别在 3、5、7 秒后启用自动前进。鼠标点击同样可以前进这些幻灯片。请使用至少有三张幻灯片的 `input.pptx` 文件。

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

要检查是否已启用计时前进，调用 [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter)。仅存储的延迟并不表示计时器已激活。

下面的示例打开上面保存的文件，报告每个已启用的计时器，并对延迟超过两秒的幻灯片禁用自动前进。对这些幻灯片启用鼠标点击并保存更新后的设置。

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

使用 [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 指定切换效果的精确长度（毫秒）。幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 方法通过 [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) 暴露这些设置：

| 方法 | 用途 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | 设置切换效果本身的持续时间（毫秒）。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 设置幻灯片自动前进前的延迟（毫秒）。将 `true` 传给 [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 以激活该计时器。 |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | 从 [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) 中选择预定义的速度类别：Slow、Medium 或 Fast。未指定精确持续时间时使用此设置。 |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 仅控制切换效果；它不决定幻灯片保持可见的时长。请单独配置自动前进的延迟。如果未设置显式持续时间，Aspose.Slides 将根据切换类型和 [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) 的值决定效果时长。

<!-- visual-explanation:slide-transition:start -->
[![分离的条形标识 750 毫秒的切换持续时间和 5,000 毫秒的自动前进设置。](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*共享示例为每张幻灯片提供 750 毫秒的淡入切换，并单独在 5,000 毫秒时启用自动前进。切换持续时间控制效果；前进控制何时离开幻灯片。这些条形是示意设置，而非测量的组合时间线。*
<!-- visual-explanation:slide-transition:end -->

### **对每张幻灯片应用相同的持续时间**

为获得一致的节奏，向每张幻灯片应用相同的效果和精确的持续时间。此示例加载 `input.pptx`，从 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 中选择 Fade，并为每个切换设置 750 毫秒的持续时间。它还单独在 5,000 毫秒后启用自动前进，并通过鼠标点击禁用前进，然后将结果保存为 PPTX。

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

        // 独立于效果持续时间配置自动前进。
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **为各个幻灯片设置不同的持续时间**

不同幻灯片可以使用不同的效果持续时间。例如，对标题幻灯片使用短暂的切换，对章节介绍使用更长的切换。此示例为第一张幻灯片设置 500 毫秒，为第二张幻灯片设置 1,200 毫秒。请使用至少有两张幻灯片的 `input.pptx` 文件。

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

### **在动画输出中协调整合切换**

在准备 [动画 GIF](/slides/zh/php-java/convert-powerpoint-to-animated-gif/)、[HTML5 演示](/slides/zh/php-java/export-to-html5/) 或 [视频](/slides/zh/php-java/convert-powerpoint-to-video/) 时，请在导出前设置精确的切换持续时间，以匹配预期的节奏。例如，在场景之间使用 600 毫秒的淡入，并分别为每张幻灯片的前进延迟设置单独的时间，以留出旁白或内容的展示时间。

对于 GIF 和视频，请将输出帧率与效果持续时间对应：600 毫秒相当于在 30 帧每秒下的 18 帧。 在 HTML5 中，需在导出设置中启用动画切换。检查所选导出格式支持的效果和计时选项，并预览输出以确认同步。

### **读取现有切换持续时间**

在修改切换之前调用 [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) 以判断是否已存储显式值。值为 `-1` 表示未设置显式持续时间；非负值表示以毫秒为单位的存储持续时间。未设置的值并非计算得到的播放时长：Aspose.Slides 使用切换类型和 [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) 值来确定该时长。设置切换类型可能会初始化持续时间，因此请首先检查原始设置。

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

Morph 切换在连续幻灯片之间对对象的变化进行动画。要创建一个简单的 Morph 效果，克隆一张幻灯片，在克隆上移动或调整对象的大小，然后对第二张幻灯片应用 Morph 切换。这会让对应对象在原始状态和修改后状态之间进行动画。

下面的示例创建了一张带有文本矩形的幻灯片，克隆该幻灯片，并在克隆上更改矩形的位置和大小。随后为第二张幻灯片从 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 枚举中选择 Morph。将在支持 Morph 的演示查看器中打开保存的文件，以在放映期间看到效果。

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
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) 在可能的情况下按词匹配文本进行动画。
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) 在可能的情况下按字符匹配文本进行动画。

使用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 选择 Morph，然后访问 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue)。该值返回一个 [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) 对象，可通过其 [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) 方法选择匹配模式。

此示例打开前一节创建的演示文稿，并将第二张幻灯片配置为使用基于词的 Morph 动画。

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

某些切换会公开额外选项，例如方向或是否从黑屏开始。可用选项取决于使用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 选择的切换。请先设置类型，然后通过 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) 获取相应的切换对象并使用。

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

**我可以控制幻灯片切换的播放速度吗？**

可以。当您需要以毫秒为单位的精确效果时，请首选 [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration)。如果预定义的 [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/)（Slow、Medium、Fast）已经足够且未设置显式持续时间，请使用 [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed)。这些设置独立于自动前进延迟，专门控制切换效果。

**我可以为切换附加音频并使其循环吗？**

可以。使用 [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound) 分配嵌入音频，将 [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) 枚举中的 StartSound 传给 [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode)，并通过将 [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) 设置为 `true` 启用循环。音频将在幻灯片放映中一直循环，直到出现下一个声音事件。

**将相同的切换应用于每张幻灯片的最快方法是什么？**

遍历演示文稿的 [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) 集合，对每张幻灯片的切换调用 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 并传入相同的值。在同一循环中设置计时和效果选项，以确保所有幻灯片的行为保持一致。

**如何检查幻灯片当前设置了哪种切换？**

对幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 结果调用 [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType)。它返回 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 枚举中的一个值；None 表示未应用任何切换效果。