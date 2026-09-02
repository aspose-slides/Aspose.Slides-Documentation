---
title: 在簡報中使用 PHP 套用形狀動畫
linktitle: 形狀動畫
type: docs
weight: 60
url: /zh-hant/php-java/shape-animation/
keywords:
- 形狀
- 動畫
- 效果
- 動畫形狀
- 動畫文字
- 新增動畫
- 取得動畫
- 提取動畫
- 新增效果
- 取得效果
- 提取效果
- 效果聲音
- 套用動畫
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 新增、檢查與自訂形狀動畫、時間設定、聲音、動畫結束後的行為，以及動畫文字。"
---
## **概觀**

Aspose.Slides for PHP via Java 以幻燈片時間軸中的效果來表示幻燈片動畫。每個效果具有目標形狀、動畫類型與子類型、觸發器、時間設定，以及可選屬性，例如聲音或動畫結束後的行為。

時間軸包含兩種序列：

- **主要序列** 隨著幻燈片前進而播放。
- **互動序列** 在其觸發形狀被點擊時開始。

由於文字方塊、圖片、圖表、表格和其他幻燈片物件皆為形狀，您可以對大多數幻燈片內容使用相同的[Sequence::addEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/addeffect/) 方法。可用的效果列於[EffectType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effecttype/) 類別中。

## **新增形狀動畫**

若要新增動畫，取得投影片的主要序列，並以目標形狀、效果類型、子類型與觸發器呼叫[Sequence::addEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/addeffect/)。若要建立在點擊另一個形狀時開始的效果，請建立觸發該其他形狀的互動序列。

以下範例同時建立兩種動畫，並將結果儲存為 `shape-animations.pptx`。

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

觸發器決定何時開始效果：

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effecttriggertype/) 在主要序列中等待點擊，或在互動序列中等待點擊觸發形狀。
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effecttriggertype/) 與前一個效果同時開始。
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effecttriggertype/) 在前一個效果結束後開始。

若要為圖片、圖表或其他形狀類型加入動畫，請將該物件傳遞給[Sequence::addEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/addeffect/) 取代 `$targetShape`。有關圖表專屬的群組選項，請參閱[Animated Charts](/slides/zh-hant/php-java/animated-charts/)。

## **讀取形狀動畫**

當您已知目標形狀時，使用[Sequence::getEffectsByShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/geteffectsbyshape/)。若要檢查每一個效果，請列舉主要序列與所有互動序列。列舉可避免假設序列在索引 `0` 處一定有效果。

以下範例建立具有主要序列與互動效果的形狀，取得針對該形狀的效果，然後列舉投影片上的每一個序列。

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

如果只需要單一形狀的效果，請先以名稱、佔位符類型或其他穩定屬性識別該形狀；然後呼叫[Sequence::getEffectsByShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/geteffectsbyshape/)。不要假設[ShapeCollection::get_Item](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/get_item/) 在索引 `0` 處永遠是目標物件。

## **使用繼承的佔位符效果**

普通投影片上的佔位符可以繼承佈局投影片與母版投影片上相應佔位符的動畫行為。[Shape::getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getbaseplaceholder/) 會回傳該父佔位符，若無父佔位符則回傳 `null`。

在下方示範簡報中，頁腳在普通投影片上使用 **Random Bars**，在佈局投影片上使用 **Split**，而在母版投影片上使用 **Fly In**。

![普通投影片上的頁腳動畫效果](slide-shape-animation.png)

![佈局投影片上頁腳佔位符動畫效果](layout-shape-animation.png)

![母版投影片上頁腳佔位符動畫效果](master-shape-animation.png)

下一個範例使用新簡報的佔位符階層。它向母版佔位符、佈局佔位符以及普通投影片上的相應佔位符新增效果。每一次呼叫[Shape::getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getbaseplaceholder/) 前，都會檢查回傳的形狀是否為 `null`。

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

## **變更動畫時間設定**

PowerPoint **Timing** 對話方塊對應到[Timing](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/) 的屬性。

![PowerPoint 動畫效果的時間設定對話方塊](shape-animation.png)

- **Start** 對應到[Timing::getTriggerType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/gettriggertype/)。
- **Duration** 對應到[Timing::getDuration](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getduration/)，單位為秒。
- **Delay** 對應到[Timing::getTriggerDelayTime](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/gettriggerdelaytime/)，單位為秒。
- **Repeat** 對應到[Timing::getRepeatCount](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getrepeatcount/)、[Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getrepeatuntilnextclick/) 或[Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getrepeatuntilendslide/)。
- **Rewind when done playing** 對應到[Timing::getRewind](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getrewind/)。

此獨立範例新增一個效果，透過[Sequence::addEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/addeffect/) 回傳的物件變更其時間設定，並儲存結果。保留回傳的[Effect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/) 參考，可避免不必要的集合索引。

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

請有意選擇單一的重複模式。將重複次數與「until」旗標同時使用可能在不同的觀賞端造成混亂結果。變更重複模式時，請先呼叫[Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/setrepeatuntilnextclick/) 與[Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/setrepeatuntilendslide/)，再設定[Timing::setRepeatCount](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/setrepeatcount/)，因為設定任一旗標都會同時改變目前的重複模式。

## **新增與提取動畫聲音**

動畫效果可以透過[Effect::getSound](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/getsound/) 參照嵌入的音訊。[Effect::setStopPreviousSound](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/setstopprevioussound/) 可指示效果停止先前效果所啟動的音訊。

### **為效果加入聲音**

以下範例假設本機已有名為 `animation-sound.wav` 的音訊檔。它會建立兩個效果，將該檔案嵌入為第一個效果的聲音，並設定第二個效果停止聲音。範例使用[Sequence::addEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/addeffect/) 回傳的物件，因此不需要序列索引。

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

### **提取嵌入的效果聲音**

以下範例假設本機已有名為 `presentation-with-animation-sounds.pptx` 的簡報。它會掃描主要與互動序列，將每個嵌入的效果聲音寫入 `extracted-animation-sounds` 目錄。副檔名會根據[Audio::getContentType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audio/getcontenttype/) 回傳的音訊 MIME 類型自動選擇。

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

若音訊物件過大，請使用[Audio::getStream](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audio/getstream/) 並將串流複製至檔案，而非一次載入至位元組陣列。

## **設定動畫結束後的行為**

**After animation** 選項控制形狀在效果結束後的狀態。

![PowerPoint 效果選項對話框顯示「動畫結束後」設定](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/afteranimationtype/) 類別支援保持形狀不變、變更顏色、動畫結束後隱藏，或在下一次點擊時隱藏。當類型為[AfterAnimationType::Color](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/afteranimationtype/) 時，亦需設定[Effect::getAfterAnimationColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/getafteranimationcolor/)。

此獨立範例建立一個效果，透過回傳的效果物件設定其動畫結束後行為，並儲存結果。

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

將類型從[AfterAnimationType::Color](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/afteranimationtype/) 變更為其他類型時，會清除動畫結束後的顏色設定。

## **文字動畫**

文字動畫有兩個相關控制：

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textanimation/getbuildtype/) 控制段落是一起顯示還是逐段落顯示。
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/getanimatetexttype/) 控制文字是一次全部出現、逐字或逐詞出現。[Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/getdelaybetweentextparts/) 設定詞或字之間的延遲。正值為效果持續時間的百分比，負值則為秒數延遲。

以下獨立範例為文字方塊中的單字加入動畫。[BuildType::AsOneObject](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/buildtype/) 會停用段落逐段構建，使字元設定套用於整個文字框。

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

若要以段落為單位構建文字方塊，請設定[BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/buildtype/)（或其他段落層級）。若要為單一段落套用獨立效果，請使用接受[Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 參數的[Sequence::addEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/addeffect/) 版型。參考[Animated Text](/slides/zh-hant/php-java/animated-text/) 取得段落層級範例。

## **匯出與相容性說明**

- 儲存為 PPT 或 PPTX 會保留動畫模型，但最終播放方式取決於簡報檢視器。
- PDF 與靜態影像不會播放動畫。若必須呈現運動，請使用[HTML5 匯出](/slides/zh-hant/php-java/export-to-html5/)、動畫 GIF，或[影片轉換](/slides/zh-hant/php-java/convert-powerpoint-to-video/)。
- 針對 HTML5，請啟用[Html5Options::setAnimateShapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/html5options/setanimateshapes/)，必要時再啟用[Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/html5options/setanimatetransitions/)。
- 影片轉換支援多數常見的進入、強調、退出與移動路徑效果，但並非所有 PowerPoint 效果皆受支援。請參閱目前的[受支援動畫與效果](/slides/zh-hant/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) 並以目標 Aspose.Slides 版本測試關鍵簡報。
- 進階自訂效果與從其他簡報格式匯入的效果可能會在檔案中保留，但在 PowerPoint、HTML5 或影片中呈現方式不同。請驗證匯出結果，而非僅依賴效果名稱。

## **常見問與答**

**為何動畫在 PowerPoint 中可見，但在 PDF 中不存在？**

PDF 為靜態格式，無法播放動畫與幻燈片切換。若需保留動態效果，請匯出為 HTML5、動畫 GIF 或影片。

**為何同一效果在影片中播放的方式不同？**

影片匯出會渲染動畫，而非直接保存 PowerPoint 原始行為。某些進階效果未受支援或會被近似處理。請參考受支援效果表，並在正式使用前測試實際簡報。

**移動形狀的前後順序會改變其動畫播放順序嗎？**

不會。形狀的 Z 軸順序僅影響重疊顯示，動畫的播放順序由序列順序與觸發器決定。如需改變播放順序，請調整時間軸。