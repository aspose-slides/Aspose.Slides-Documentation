---
title: 在投影片中使用 PHP 套用形狀動畫
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
- 擷取動畫
- 新增效果
- 取得效果
- 擷取效果
- 效果音效
- 套用動畫
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 新增、檢查與自訂形狀動畫、時序、音效、動畫後行為以及動畫文字。"
---
## **概觀**

若要處理效果內的單一行為或編輯移動路徑段落，請參閱[自訂動畫](/slides/zh-hant/php-java/custom-animation/)。

Aspose.Slides for PHP via Java 以投影片時間軸中的效果來表示投影片動畫。每個效果具備目標形狀、動畫類型與子類型、觸發方式、時序設定，以及如音效或動畫後行為等可選屬性。

時間軸包含兩種序列：

- **主要序列** 隨投影片前進而播放。
- **互動序列** 在其觸發形狀被點擊時啟動。

由於文字方塊、圖片、圖表、表格及其他投影片物件皆為形狀，您可使用相同的[Sequence::addEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/addeffect/) 方法來處理大多數投影片內容。可用的效果列於[EffectType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effecttype/) 類別中。

## **新增形狀動畫**

若要新增動畫，取得投影片的主要序列，並以目標形狀、效果類型、子類型與觸發方式呼叫[Sequence::addEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/addeffect/)。若要使效果於點擊其他形狀時開始，請建立以該形狀為觸發的互動序列。

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

觸發方式決定效果何時開始：

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effecttriggertype/) 等待主要序列的點擊，或互動序列中觸發形狀的點擊。
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effecttriggertype/) 與前一個效果同時開始。
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effecttriggertype/) 在前一個效果結束時開始。

若要為圖片、圖表或其他形狀類型加入動畫，請將該物件傳遞給[Sequence::addEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/addeffect/) 取代 `$targetShape`。有關圖表特定的分組選項，請參閱[動畫圖表](/slides/zh-hant/php-java/animated-charts/)。

## **讀取形狀動畫**

當您已知目標形狀時，使用[Sequence::getEffectsByShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/geteffectsbyshape/)。若要檢查每個效果，請列舉主要序列與所有互動序列。列舉可避免假設序列在索引 `0` 處一定有效果。

以下範例建立具有主要序列與互動效果的形狀，取得針對該形狀的效果，並列舉投影片上的所有序列。

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

若只需取得單一形狀的效果，請先以名稱、佔位符類型或其他穩定屬性識別該形狀；然後呼叫[Sequence::getEffectsByShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/geteffectsbyshape/)。請勿假設索引 `0` 的[ShapeCollection::get_Item](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/get_item/) 必定是目標物件。

## **處理繼承的佔位符效果**

普通投影片上的佔位符可以繼承其版面投影片與母版投影片中對應佔位符的動畫行為。[Shape::getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getbaseplaceholder/) 會回傳該父佔位符，若不存在父佔位符則回傳 `null`。

在下列示範簡報中，頁腳在普通投影片上使用 **Random Bars**，在版面投影片上使用 **Split**，在母版投影片上使用 **Fly In**。

![普通投影片上的頁腳動畫效果](slide-shape-animation.png)

![版面投影片上的頁腳佔位符動畫效果](layout-shape-animation.png)

![母版投影片上的頁腳佔位符動畫效果](master-shape-animation.png)

下一個範例使用新簡報中的佔位符階層。它為母版佔位符、版面佔位符及普通投影片上對應的佔位符新增效果。在使用回傳形狀之前，會先檢查每一次對[Shape::getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getbaseplaceholder/) 的呼叫。

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

## **變更動畫時序**

PowerPoint **Timing** 對話框對應到 [Timing](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/) 的屬性。

![PowerPoint 動畫效果的 Timing 對話框](shape-animation.png)

- **開始** 對應到 [Timing::getTriggerType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/gettriggertype/)。
- **持續時間** 對應到 [Timing::getDuration](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getduration/)，單位為秒。
- **延遲** 對應到 [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/gettriggerdelaytime/)，單位為秒。
- **重複** 對應到 [Timing::getRepeatCount](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getrepeatcount/)、[Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getrepeatuntilnextclick/) 或 [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getrepeatuntilendslide/)。
- **播放完畢後倒帶** 對應到 [Timing::getRewind](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/getrewind/)。

此獨立範例新增一個效果，透過[Sequence::addEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/addeffect/) 回傳的物件變更其時序，並儲存結果。保留回傳的[Effect] 參考可避免不必要的集合索引。

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

請有意只使用一種重複模式。將重複次數與「直到」旗標結合可能在不同的檢視器中產生混淆結果。變更重複模式時，請先設定 [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/setrepeatuntilnextclick/) 與 [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/setrepeatuntilendslide/)，再設定 [Timing::setRepeatCount](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/timing/setrepeatcount/)，因為設定任一旗標皆會同時變更目前的重複模式。

## **新增與擷取動畫音效**

動畫效果可以透過 [Effect::getSound](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/getsound/) 參照內嵌音訊。[Effect::setStopPreviousSound](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/setstopprevioussound/) 可指示效果停止先前效果所啟動的音訊。

### **為效果新增音效**

以下範例需要一個本機音訊檔案 `animation-sound.wav`。它建立兩個效果，將該檔案嵌入為第一個效果的音效，並設定第二個效果停止音效。它使用由[Sequence::addEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/addeffect/) 回傳的物件，因此不需要序列索引。

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

### **擷取內嵌效果音效**

以下範例需要一個本機簡報檔案 `presentation-with-animation-sounds.pptx`。它掃描主要與互動序列，並將每個內嵌的效果音訊寫入 `extracted-animation-sounds` 目錄。副檔名根據 [Audio::getContentType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audio/getcontenttype/) 所回傳的音訊 MIME 類型選取。

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

對於大型音訊物件，請使用 [Audio::getStream](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/audio/getstream/)，將串流複製至檔案，而非將整個物件載入至位元組陣列。

## **設定動畫後行為**

**動畫後** 選項控制形狀在其效果結束後的行為。

![PowerPoint 效果選項對話框顯示動畫後設定](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/afteranimationtype/) 類別支援保持形狀不變、更改其顏色、在動畫後隱藏，或在下一次點擊時隱藏。當類型為 [AfterAnimationType::Color](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/afteranimationtype/) 時，亦需設定 [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/getafteranimationcolor/)。

此獨立範例建立一個效果，透過回傳的 effect 物件設定其動畫後行為，並儲存結果。

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

將類型改為非 [AfterAnimationType::Color] 會清除動畫後的顏色設定。

## **文字動畫**

文字動畫有兩個相關控制項：

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textanimation/getbuildtype/) 控制段落是一起顯示還是逐段落顯示。
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/getanimatetexttype/) 控制文字是一次全部顯示、逐字或逐字元顯示。[Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effect/getdelaybetweentextparts/) 設定字詞或字元之間的延遲。正值為效果持續時間的百分比；負值為以秒為單位的延遲。

以下獨立範例為文字方塊中的單字加入動畫。[BuildType::AsOneObject](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/buildtype/) 會停用逐段落建構，使字詞設定套用於整個文字框。

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

若要逐段落建構文字方塊，請設定 [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/buildtype/)（或其他段落等級）。若要針對單一段落套用其專屬效果，請使用接受 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 的 [Sequence::addEffect] 重載。請參閱[動畫文字](/slides/zh-hant/php-java/animated-text/) 取得逐段落範例。

## **匯出與相容性說明**

- 儲存為 PPT 或 PPTX 會保留動畫模型，但最終播放方式由簡報檢視程式決定。
- PDF 與靜態圖像不會播放動畫。當輸出必須呈現動態時，請使用[HTML5 匯出](/slides/zh-hant/php-java/export-to-html5/)、動畫 GIF，或[影片轉換](/slides/zh-hant/php-java/convert-powerpoint-to-video/)。
- 針對 HTML5，請啟用 [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/html5options/setanimateshapes/)，必要時再啟用 [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/html5options/setanimatetransitions/)。
- 影片轉譯支援許多常見的進入、強調、退出與移動路徑效果，但並非所有 PowerPoint 效果皆受支援。請檢查目前的[支援動畫與效果](/slides/zh-hant/php-java/convert-powerpoint-to-video/#supported-animations-and-effects)，並使用目標 Aspose.Slides 版本測試關鍵簡報。
- 進階自訂效果以及從其他簡報格式匯入的效果可能會保留在檔案中，但在 PowerPoint、HTML5 或影片中呈現方式可能不同。請驗證匯出結果，而非僅依賴效果名稱。

## **常見問題**

**為什麼動畫在 PowerPoint 中顯示，但在 PDF 中不顯示？**

PDF 為靜態格式，故不會播放動畫與投影片切換。當必須保留動態時，請匯出至 HTML5、動畫 GIF，或影片。

**為什麼效果在影片中呈現方式不同？**

影片匯出會渲染動畫，而非儲存原始 PowerPoint 行為。某些進階效果不受支援或僅為近似。請參閱支援效果表，並在投入生產前測試實際簡報。

**移動形狀的前後順序會改變其動畫順序嗎？**

不會。形狀的 Z 軸順序僅控制重疊，而序列順序與觸發方式決定動畫播放。若需變更播放順序，請調整時間軸。