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
- 动画文字
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
description: "了解如何使用 Aspose.Slides for PHP via Java 添加、检查和自定义形状动画、时间设置、声音、动画后行为以及动画文字。"
---
## **概述**

Aspose.Slides for PHP via Java 将幻灯片动画表示为幻灯片时间轴中的效果。每个效果具有目标形状、动画类型和子类型、触发器、时间设置以及可选属性（如声音或动画后行为）。

时间轴包含两种序列：

- **主序列** 在幻灯片前进时播放。
- **交互序列** 在其触发形状被单击时开始。

因为文本框、图片、图表、表格和其他幻灯片对象都是形状，您可以使用相同的[Sequence::addEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sequence/addeffect/)方法为大多数幻灯片内容添加效果。可用的效果列在[EffectType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effecttype/)类中。

## **添加形状动画**

要添加动画，获取幻灯片的主序列并调用[Sequence::addEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sequence/addeffect/)——传入目标形状、效果类型、子类型和触发器。若要创建在另一个形状被单击时启动的效果，请创建一个触发器为该形状的交互序列。

下面的示例创建两种类型的动画并将结果保存为`shape-animations.pptx`。

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Click to animate this shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $entranceEffect = $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $entranceEffect->getTiming()->setDuration(1.5);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $presentation->save("shape-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

触发器决定效果何时开始：

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effecttriggertype/) 在主序列中等待单击，或在交互序列中等待对触发形状的单击。
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effecttriggertype/) 与前一个效果同时开始。
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effecttriggertype/) 在前一个效果结束后开始。

要为图片、图表或其他形状类型添加动画，请将该对象传递给[Sequence::addEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sequence/addeffect/)而不是`$targetShape`。有关图表专用分组选项，请参阅[Animated Charts](/slides/zh/php-java/animated-charts/)。

## **读取形状动画**

当已知目标形状时，使用[Sequence::getEffectsByShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sequence/geteffectsbyshape/)。若要检查每个效果，请枚举主序列和所有交互序列。枚举可避免假设序列在索引`0`处一定有效果。

下面的示例创建一个具有主序列和交互效果的形状，获取针对该形状的效果，然后枚举幻灯片上的每个序列。

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function printSequence($label, $sequence)
{
    $effectCount = java_values($sequence->getCount());

    echo "  " . $label . ": " . $effectCount . " effect(s)" . PHP_EOL;

    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $targetShape = $effect->getTargetShape();
        $targetName = java_is_null($targetShape) ? "unknown" : java_values($targetShape->getName());
        $effectType = java_values($effect->getType());
        $effectSubtype = java_values($effect->getSubtype());
        $triggerType = java_values($effect->getTiming()->getTriggerType());
        echo "    type: " . $effectType . "; subtype: " . $effectSubtype . "; target: " . $targetName . "; trigger: " . $triggerType . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Animated shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $targetEffects = $mainSequence->getEffectsByShape($targetShape);
    $Array = new JavaClass("java.lang.reflect.Array");
    echo "The main sequence contains " . java_values($Array->getLength($targetEffects)) . " effect(s) for " . java_values($targetShape->getName()) . "." . PHP_EOL;

    printSequence("Main sequence", $mainSequence);

    $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
    $interactiveCount = java_values($interactiveSequences->getCount());
    for ($interactiveIndex = 0; $interactiveIndex < $interactiveCount; $interactiveIndex++) {
        $sequence = $interactiveSequences->get_Item($interactiveIndex);
        $sequenceTrigger = $sequence->getTriggerShape();
        $triggerName = java_is_null($sequenceTrigger) ? "unknown" : java_values($sequenceTrigger->getName());
        printSequence("Interactive sequence " . ($interactiveIndex + 1) . ", trigger: " . $triggerName, $sequence);
    }
} finally {
    $presentation->dispose();
}
```

如果只需要单个形状的效果，请先通过名称、占位符类型或其他稳定属性识别该形状；然后调用[Sequence::getEffectsByShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sequence/geteffectsbyshape/)。不要假设[ShapeCollection::get_Item](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/get_item/)在索引`0`处一定是目标对象。

## **使用继承占位符效果**

普通幻灯片上的占位符可以继承其版式幻灯片和母版幻灯片上对应占位符的动画行为。[Shape::getBasePlaceholder](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getbaseplaceholder/)返回该父占位符，若不存在父占位符则返回`null`。

在下面的示例演示文稿中，页脚在普通幻灯片上为**Random Bars**，在版式幻灯片上为**Split**，在母版幻灯片上为**Fly In**。

![普通幻灯片上的页脚动画效果](slide-shape-animation.png)

![版式幻灯片上页脚占位符的动画效果](layout-shape-animation.png)

![母版幻灯片上页脚占位符的动画效果](master-shape-animation.png)

下一个示例使用新演示文稿中的占位符层次结构。它向母版占位符、版式占位符以及普通幻灯片上的相应占位符添加效果。每次调用[Shape::getBasePlaceholder](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getbaseplaceholder/)前都会进行检查，以确保返回的形状可用。

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

function findLayoutPlaceholderWithBase($layoutSlide)
{
    $shapes = $layoutSlide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_is_null($shape->getBasePlaceholder())) {
            return $shape;
        }
    }

    return null;
}

function findSlidePlaceholderWithBase($slide, $expectedBase)
{
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $basePlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($basePlaceholder) && java_values($basePlaceholder->equals($expectedBase))) {
            return $shape;
        }
    }

    return null;
}

function printEffects($source, $effects)
{
    $Array = new JavaClass("java.lang.reflect.Array");
    echo $source . ": " . java_values($Array->getLength($effects)) . " effect(s)" . PHP_EOL;

    foreach ($effects as $effect) {
        echo "  type: " . java_values($effect->getType()) . "; subtype: " . java_values($effect->getSubtype()) . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);
    $layoutPlaceholder = findLayoutPlaceholderWithBase($layoutSlide);

    if ($layoutPlaceholder === null) {
        throw new RuntimeException("The layout slide does not contain a placeholder linked to its master slide.");
    }

    $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
    $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->addEffect($masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    $layoutSlide->getTimeline()->getMainSequence()->addEffect($layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

    $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $slidePlaceholder = findSlidePlaceholderWithBase($slide, $layoutPlaceholder);

    if ($slidePlaceholder === null) {
        throw new RuntimeException("The slide does not contain a placeholder linked to its layout slide.");
    }

    $slide->getTimeline()->getMainSequence()->addEffect($slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
    printEffects("Normal slide", $slide->getTimeline()->getMainSequence()->getEffectsByShape($slidePlaceholder));

    $baseLayoutPlaceholder = $slidePlaceholder->getBasePlaceholder();
    if (!java_is_null($baseLayoutPlaceholder)) {
        printEffects("Layout slide", $layoutSlide->getTimeline()->getMainSequence()->getEffectsByShape($baseLayoutPlaceholder));

        $baseMasterPlaceholder = $baseLayoutPlaceholder->getBasePlaceholder();
        if (!java_is_null($baseMasterPlaceholder)) {
            printEffects("Master slide", $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($baseMasterPlaceholder));
        }
    }

    $presentation->save("placeholder-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **更改动画时间设置**

PowerPoint 的**Timing** 对话框映射到[Timing](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/)的属性。

![PowerPoint 动画效果的 Timing 对话框](shape-animation.png)

- **Start** 映射到[Timing::getTriggerType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/gettriggertype/)。
- **Duration** 映射到[Timing::getDuration](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/getduration/)，单位为秒。
- **Delay** 映射到[Timing::getTriggerDelayTime](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/gettriggerdelaytime/)，单位为秒。
- **Repeat** 映射到[Timing::getRepeatCount](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/getrepeatcount/)、[Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/getrepeatuntilnextclick/)或[Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/getrepeatuntilendslide/)。
- **Rewind when done playing** 映射到[Timing::getRewind](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/getrewind/)。

此独立示例添加一个效果，通过[Sequence::addEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sequence/addeffect/)返回的对象更改其时间设置，并保存结果。保留返回的[Effect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effect/)引用可避免不必要的集合索引。

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Timed animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    $effect->getTiming()->setDuration(2.0);
    $effect->getTiming()->setTriggerDelayTime(0.5);
    $effect->getTiming()->setRepeatUntilNextClick(false);
    $effect->getTiming()->setRepeatUntilEndSlide(false);
    $effect->getTiming()->setRepeatCount(2.0);
    $effect->getTiming()->setRewind(true);

    $presentation->save("shape-animation-timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

请仅使用一种重复模式。将重复计数与“until”标志组合会在不同查看器中产生混淆结果。更改重复模式时，请先调用[Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/setrepeatuntilnextclick/)和[Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/setrepeatuntilendslide/)，再调用[Timing::setRepeatCount](https://reference.aspose.com/slides/zh/php-java/aspose.slides/timing/setrepeatcount/)，因为设置任意标志都会改变当前的重复模式。

## **添加和提取动画声音**

动画效果可以通过[Effect::getSound](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effect/getsound/)引用嵌入的音频。[Effect::setStopPreviousSound](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effect/setstopprevioussound/) 指示效果停止先前效果启动的音频。

### **为效果添加声音**

下面的示例期望本地存在名为`animation-sound.wav`的音频文件。它创建两个效果，将该文件嵌入为第一个效果的声音，并将第二个效果配置为停止该声音。示例使用[Sequence::addEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sequence/addeffect/)返回的对象，因此不需要序列索引。

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$Files = new JavaClass("java.nio.file.Files");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 100, 240, 80);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 400, 100, 240, 80);
    $firstShape->addTextFrame("Starts sound");
    $secondShape->addTextFrame("Stops sound");

    $sequence = $slide->getTimeline()->getMainSequence();
    $firstEffect = $sequence->addEffect($firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $secondEffect = $sequence->addEffect($secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $baseDirectory = getcwd();
    $audioPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "animation-sound.wav"))->toPath();
    $audioData = $Files->readAllBytes($audioPath);
    $effectSound = $presentation->getAudios()->addAudio($audioData);
    $firstEffect->setSound($effectSound);
    $secondEffect->setStopPreviousSound(true);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "shape-animation-sound.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **提取嵌入的效果声音**

下面的示例期望本地存在名为`presentation-with-animation-sounds.pptx`的演示文稿。它扫描主序列和交互序列，并将每个嵌入的效果声音写入`extracted-animation-sounds`目录。文件扩展名依据[Audio::getContentType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/audio/getcontenttype/)返回的音频 MIME 类型选择。

```php
use aspose\slides\Presentation;

function getAudioExtension($contentType)
{
    $normalizedType = strtolower($contentType === null ? "" : java_values($contentType));

    if ($normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if ($normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if ($normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if ($normalizedType === "audio/wav" || $normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds($sequence, $outputDirectory, $soundIndex)
{
    $effectCount = java_values($sequence->getCount());
    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $sound = $effect->getSound();
        if (java_is_null($sound)) {
            continue;
        }

        $extension = getAudioExtension($sound->getContentType());
        $outputPath = $outputDirectory->resolve("effect-sound-" . $soundIndex . $extension);
        $outputStream = new Java("java.io.FileOutputStream", $outputPath->toFile());
        try {
            $outputStream->write($sound->getBinaryData());
        } finally {
            $outputStream->close();
        }
        $soundIndex++;
    }

    return $soundIndex;
}

$baseDirectory = getcwd();
$inputPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "presentation-with-animation-sounds.pptx"))->toPath();
$outputDirectoryName = $baseDirectory . DIRECTORY_SEPARATOR . "extracted-animation-sounds";
if (!is_dir($outputDirectoryName)) {
    mkdir($outputDirectoryName, 0777, true);
}
$outputDirectory = (new Java("java.io.File", $outputDirectoryName))->toPath();

$presentation = new Presentation($inputPath->toString());
try {
    $soundIndex = 1;

    $slides = $presentation->getSlides();
    $slideCount = java_values($slides->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $slides->get_Item($slideIndex);
        $soundIndex = saveSounds($slide->getTimeline()->getMainSequence(), $outputDirectory, $soundIndex);

        $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
        $interactiveCount = java_values($interactiveSequences->getCount());
        for ($sequenceIndex = 0; $sequenceIndex < $interactiveCount; $sequenceIndex++) {
            $sequence = $interactiveSequences->get_Item($sequenceIndex);
            $soundIndex = saveSounds($sequence, $outputDirectory, $soundIndex);
        }
    }

    echo "Extracted " . ($soundIndex - 1) . " sound file(s) to " . java_values($outputDirectory->toAbsolutePath()->toString()) . "." . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

对于大型音频对象，请使用[Audio::getStream](https://reference.aspose.com/slides/zh/php-java/aspose.slides/audio/getstream/)并将流复制到文件，而不是将整个对象加载到字节数组中。

## **设置动画后行为**

**After animation** 选项控制形状在效果结束后如何处理。

![PowerPoint 效果选项对话框显示 After animation 设置](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/afteranimationtype/) 类支持保持形状不变、更改其颜色、在动画后隐藏，或在下次单击时隐藏。当类型为[AfterAnimationType::Color](https://reference.aspose.com/slides/zh/php-java/aspose.slides/afteranimationtype/) 时，还需设置[Effect::getAfterAnimationColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effect/getafteranimationcolor/)。

此独立示例创建一个效果，通过返回的效果对象设置其动画后行为，并保存结果。

```php
use aspose\slides\AfterAnimationType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Dim after animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->setAfterAnimationType(AfterAnimationType::Color);
    $effect->getAfterAnimationColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("shape-animation-after-effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

将类型从[AfterAnimationType::Color](https://reference.aspose.com/slides/zh/php-java/aspose.slides/afteranimationtype/) 改为其他会清除动画后颜色设置。

## **文字动画**

文字动画有两个相关控制：

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textanimation/getbuildtype/) 控制段落是整体出现还是逐段出现。
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effect/getanimatetexttype/) 控制文字是一次全部出现、按单词还是按字母出现。[Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/zh/php-java/aspose.slides/effect/getdelaybetweentextparts/) 设置单词或字母之间的延迟。正值表示效果持续时间的百分比，负值表示以秒为单位的延迟。

下面的独立示例为文本框中的单词添加动画。[BuildType::AsOneObject](https://reference.aspose.com/slides/zh/php-java/aspose.slides/buildtype/) 禁用段落逐段构建，使单词设置适用于整个文本框。

```php
use aspose\slides\AnimateTextType;
use aspose\slides\BuildType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 560, 100);
    $textBox->addTextFrame("Aspose.Slides animates this sentence word by word.");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    $effect->setAnimateTextType(AnimateTextType::ByWord);
    $effect->setDelayBetweenTextParts(20.0);

    $presentation->save("animated-text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

若要按段落构建文本框，请设置[BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/zh/php-java/aspose.slides/buildtype/)（或其他段落级别）。若要为单个段落单独设置效果，请使用接受[Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 的[Sequence::addEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sequence/addeffect/) 重载。请参阅[Animated Text](/slides/zh/php-java/animated-text/)获取段落级别示例。

## **导出与兼容性说明**

- 保存为 PPT 或 PPTX 会保留动画模型，但最终播放由演示文稿查看器控制。
- PDF 和静态图像不播放动画。需要显示运动时请使用[HTML5 导出](/slides/zh/php-java/export-to-html5/)、动画 GIF 或[视频转换](/slides/zh/php-java/convert-powerpoint-to-video/)。
- 对于 HTML5，请启用[Html5Options::setAnimateShapes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/html5options/setanimateshapes/)，必要时还可启用[Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/html5options/setanimatetransitions/)。
- 视频渲染支持多种常见的进入、强调、退出和运动路径效果，但并非所有 PowerPoint 效果都受支持。请查看当前的[受支持动画和效果](/slides/zh/php-java/convert-powerpoint-to-video/#supported-animations-and-effects)并使用目标 Aspose.Slides 版本对关键演示文稿进行测试。
- 高级自定义效果以及从其他演示文稿格式导入的效果可能在文件中得以保留，但在 PowerPoint、HTML5 或视频中呈现方式不同。请验证导出结果，而不要仅凭效果名称判断。

## **常见问题**

**为什么动画在 PowerPoint 中出现，但在 PDF 中没有？**

PDF 是静态格式，动画和幻灯片切换不会播放。需要保留运动时请导出为 HTML5、动画 GIF 或视频。

**为什么同一效果在视频中表现不同？**

视频导出会渲染动画，而不是存储原始 PowerPoint 行为。某些高级效果不受支持或被近似。请查看受支持的效果表，并在生产使用前对实际演示文稿进行测试。

**移动形状的前后顺序会改变其动画顺序吗？**

不会。形状的 Z 顺序控制重叠，序列顺序和触发器控制动画播放。如果需要不同的播放顺序，请更改时间轴。