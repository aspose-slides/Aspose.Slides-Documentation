---
title: PHP를 사용하여 프레젠테이션에 형태 애니메이션 적용
linktitle: 형태 애니메이션
type: docs
weight: 60
url: /ko/php-java/shape-animation/
keywords:
- 형태
- 애니메이션
- 효과
- 애니메이션 형태
- 애니메이션 텍스트
- 애니메이션 추가
- 애니메이션 가져오기
- 애니메이션 추출
- 효과 추가
- 효과 가져오기
- 효과 추출
- 효과 사운드
- 애니메이션 적용
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 형태 애니메이션, 타이밍, 사운드, 애프터 애니메이션 동작 및 애니메이션 텍스트를 추가, 검사 및 맞춤 설정하는 방법을 배웁니다."
---
## **개요**

효과 내부의 개별 동작을 작업하거나 움직임 경로 세그먼트를 편집하려면 [사용자 지정 애니메이션](/slides/ko/php-java/custom-animation/)을(를) 참조하십시오.

Aspose.Slides for PHP via Java는 슬라이드 타임라인의 효과로 슬라이드 애니메이션을 나타냅니다. 효과에는 대상 형태, 애니메이션 유형 및 하위 유형, 트리거, 타이밍 설정 및 사운드 또는 애프터 애니메이션 동작과 같은 선택적 속성이 있습니다.

타임라인에는 두 종류의 시퀀스가 포함됩니다:

- **주 시퀀스**는 슬라이드가 진행될 때 재생됩니다.
- **대화형 시퀀스**는 트리거 형태를 클릭할 때 시작됩니다.

텍스트 상자, 그림, 차트, 표 및 기타 슬라이드 개체는 모두 형태이므로 대부분의 슬라이드 콘텐츠에 동일한 [Sequence::addEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sequence/addeffect/) 메서드를 사용합니다. 사용 가능한 효과는 [EffectType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effecttype/) 클래스에 나열됩니다.

## **형태 애니메이션 추가**

애니메이션을 추가하려면 슬라이드의 주 시퀀스를 가져와 대상 형태, 효과 유형, 하위 유형 및 트리거와 함께 [Sequence::addEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sequence/addeffect/)를 호출합니다. 다른 형태를 클릭할 때 시작되는 효과의 경우 해당 다른 형태를 트리거로 하는 대화형 시퀀스를 생성합니다.

다음 예제는 두 종류의 애니메이션을 생성하고 결과를 `shape-animations.pptx`에 저장합니다.

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

트리거는 효과가 언제 시작되는지를 제어합니다:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effecttriggertype/)은 주 시퀀스에서 클릭을 기다리거나 대화형 시퀀스에서 트리거 형태를 클릭할 때 기다립니다.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effecttriggertype/)은 이전 효과와 동시에 시작됩니다.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effecttriggertype/)은 이전 효과가 끝날 때 시작됩니다.

그림, 차트 또는 다른 형태 유형을 애니메이션하려면 `$targetShape` 대신 해당 개체를 [Sequence::addEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sequence/addeffect/)에 전달합니다. 차트 전용 그룹화 옵션은 [Animated Charts](/slides/ko/php-java/animated-charts/)를 참조하십시오.

## **형태 애니메이션 읽기**

대상 형태를 알고 있을 때는 [Sequence::getEffectsByShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sequence/geteffectsbyshape/)를 사용하십시오. 모든 효과를 검사하려면 주 시퀀스와 모든 대화형 시퀀스를 열거합니다. 열거를 통해 시퀀스가 인덱스 `0`에 효과를 포함하고 있다고 가정하는 것을 피할 수 있습니다.

다음 예제는 주 시퀀스 및 대화형 효과가 있는 형태를 생성하고, 해당 형태를 대상으로 하는 효과를 가져온 다음 슬라이드의 모든 시퀀스를 열거합니다.

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

하나의 형태에 대한 효과만 필요하다면 먼저 이름, 자리표시자 유형 또는 다른 안정적인 속성으로 형태를 식별한 후 [Sequence::getEffectsByShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sequence/geteffectsbyshape/)를 호출하십시오. 인덱스 `0`에 있는 [ShapeCollection::get_Item](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/get_item/)이 항상 원하는 객체라고 가정하지 마십시오.

## **상속된 자리표시자 효과 작업**

일반 슬라이드의 자리표시자는 레이아웃 슬라이드 및 마스터 슬라이드에 있는 해당 자리표시자에서 애니메이션 동작을 상속받을 수 있습니다. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getbaseplaceholder/)은 부모 자리표시자를 반환하며, 부모가 없을 경우 `null`을 반환합니다.

다음 예제 프레젠테이션에서 푸터는 일반 슬라이드에서 **Random Bars**, 레이아웃 슬라이드에서 **Split**, 마스터 슬라이드에서 **Fly In** 효과를 가집니다.

![일반 슬라이드의 푸터 애니메이션 효과](slide-shape-animation.png)

![레이아웃 슬라이드의 푸터 자리표시자 애니메이션 효과](layout-shape-animation.png)

![마스터 슬라이드의 푸터 자리표시자 애니메이션 효과](master-shape-animation.png)

다음 예제는 새 프레젠테이션의 자리표시자 계층 구조를 사용합니다. 마스터 자리표시자, 레이아웃 자리표시자 및 일반 슬라이드의 해당 자리표시자에 효과를 추가합니다. 반환된 형태를 사용하기 전에 [Shape::getBasePlaceholder](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/getbaseplaceholder/)에 대한 모든 호출을 확인합니다.

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

## **애니메이션 타이밍 변경**

PowerPoint **Timing** 대화 상자는 [Timing](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/)의 속성과 매핑됩니다.

![애니메이션 효과에 대한 PowerPoint 타이밍 대화 상자](shape-animation.png)

- **Start**는 [Timing::getTriggerType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/gettriggertype/)에 매핑됩니다.
- **Duration**은 초 단위로 [Timing::getDuration](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/getduration/)에 매핑됩니다.
- **Delay**는 초 단위로 [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/gettriggerdelaytime/)에 매핑됩니다.
- **Repeat**는 [Timing::getRepeatCount](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/getrepeatuntilnextclick/) 또는 [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/getrepeatuntilendslide/)에 매핑됩니다.
- **Rewind when done playing**은 [Timing::getRewind](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/getrewind/)에 매핑됩니다.

이 독립적인 예제는 효과를 추가하고 [Sequence::addEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sequence/addeffect/)가 반환한 객체를 통해 타이밍을 변경한 뒤 결과를 저장합니다. 반환된 [Effect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/) 참조를 유지하면 불필요한 컬렉션 인덱스를 방지할 수 있습니다.

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

반복 모드를 하나만 의도적으로 사용하십시오. 반복 횟수와 "until" 플래그를 결합하면 다양한 뷰어에서 혼란스러운 결과가 발생할 수 있습니다. 반복 모드를 변경할 때는 [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/setrepeatuntilnextclick/)와 [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/setrepeatuntilendslide/)을 [Timing::setRepeatCount](https://reference.aspose.com/slides/ko/php-java/aspose.slides/timing/setrepeatcount/)보다 먼저 설정하십시오. 두 플래그 중 하나를 설정하면 활성 반복 모드도 변경되기 때문입니다.

## **애니메이션 사운드 추가 및 추출**

애니메이션 효과는 [Effect::getSound](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/getsound/)을 통해 삽입된 오디오를 참조할 수 있습니다. [Effect::setStopPreviousSound](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/setstopprevioussound/)은 이전 효과가 시작한 오디오를 중지하도록 효과에 지시합니다.

### **효과에 사운드 추가**

다음 예제는 `animation-sound.wav`라는 로컬 오디오 파일을 필요로 합니다. 두 개의 효과를 생성하고 해당 파일을 첫 번째 효과의 사운드로 삽입하며 두 번째 효과를 사운드를 중지하도록 구성합니다. [Sequence::addEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sequence/addeffect/)가 반환한 객체를 사용하므로 시퀀스 인덱스가 필요하지 않습니다.

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

### **삽입된 효과 사운드 추출**

다음 예제는 `presentation-with-animation-sounds.pptx`라는 로컬 프레젠테이션이 필요합니다. 주 시퀀스와 대화형 시퀀스를 모두 스캔하고 모든 삽입된 효과 사운드를 `extracted-animation-sounds` 디렉터리에 기록합니다. 확장자는 [Audio::getContentType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audio/getcontenttype/)이 제공하는 오디오 MIME 유형에서 선택됩니다.

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

대용량 오디오 개체의 경우 [Audio::getStream](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audio/getstream/)을 사용하고 전체 객체를 바이트 배열로 로드하는 대신 스트림을 파일에 복사하십시오.

## **애프터 애니메이션 동작 설정**

**After animation** 옵션은 효과가 끝난 후 형태에 어떤 일이 일어나는지를 제어합니다.

![After animation 설정을 보여주는 PowerPoint 효과 옵션 대화 상자](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/afteranimationtype/) 클래스는 형태를 변경하지 않음, 색상 변경, 애니메이션 후 숨기기, 다음 클릭 시 숨기기를 지원합니다. 유형이 [AfterAnimationType::Color](https://reference.aspose.com/slides/ko/php-java/aspose.slides/afteranimationtype/)인 경우 [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/getafteranimationcolor/)도 설정하십시오.

이 독립적인 예제는 효과를 생성하고 반환된 효과 객체를 통해 애프터 애니메이션 동작을 설정한 뒤 결과를 저장합니다.

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

[AfterAnimationType::Color](https://reference.aspose.com/slides/ko/php-java/aspose.slides/afteranimationtype/)이 아닌 유형으로 변경하면 애프터 애니메이션 색상 설정이 지워집니다.

## **텍스트 애니메이션**

텍스트 애니메이션에는 두 개의 관련 제어가 있습니다:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textanimation/getbuildtype/)은 단락이 함께 나타나는지 또는 단락 수준별로 나타나는지를 제어합니다.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/getanimatetexttype/)은 텍스트가 한 번에, 단어별로 또는 글자별로 나타나는지를 제어합니다. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effect/getdelaybetweentextparts/)은 단어 또는 글자 사이의 지연을 설정합니다. 양수값은 효과 지속 시간의 백분율이며, 음수값은 초 단위 지연입니다.

다음 독립적인 예제는 텍스트 상자의 단어들을 애니메이션합니다. [BuildType::AsOneObject](https://reference.aspose.com/slides/ko/php-java/aspose.slides/buildtype/)은 단락별 구축을 비활성화하여 단어 설정이 전체 텍스트 프레임에 적용되도록 합니다.

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

단락별로 텍스트 상자를 구축하려면 [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/ko/php-java/aspose.slides/buildtype/)(또는 다른 단락 수준)를 설정하십시오. 자체 효과가 있는 단일 단락을 대상으로 하려면 [Paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/)을 받아들이는 [Sequence::addEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sequence/addeffect/) 오버로드를 사용하십시오. 단락 수준 예제는 [Animated Text](/slides/ko/php-java/animated-text/)를 참조하십시오.

## **내보내기 및 호환성 참고**

- PPT 또는 PPTX로 저장하면 애니메이션 모델이 보존되지만 최종 재생은 프레젠테이션 뷰어에 의해 제어됩니다.
- PDF 및 정적 이미지는 애니메이션을 재생하지 않습니다. 출력에 움직임을 표시해야 할 경우 [HTML5 export](/slides/ko/php-java/export-to-html5/), 애니메이션 GIF 또는 [video conversion](/slides/ko/php-java/convert-powerpoint-to-video/)을 사용하십시오.
- HTML5의 경우 [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/html5options/setanimateshapes/)을 활성화하고 필요에 따라 [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/html5options/setanimatetransitions/)을 활성화하십시오.
- 비디오 렌더링은 일반적인 입장, 강조, 종료 및 움직임 경로 효과를 많이 지원하지만 모든 PowerPoint 효과를 지원하는 것은 아닙니다. 현재 [supported animations and effects](/slides/ko/php-java/convert-powerpoint-to-video/#supported-animations-and-effects)를 확인하고 대상 Aspose.Slides 버전으로 중요한 프레젠테이션을 테스트하십시오.
- 고급 사용자 지정 효과 및 다른 프레젠테이션 형식에서 가져온 효과는 파일에 보존될 수 있지만 PowerPoint, HTML5 또는 비디오에서 다르게 렌더링될 수 있습니다. 효과 이름만을 신뢰하지 말고 내보낸 결과를 검증하십시오.

## **FAQ**

**왜 애니메이션이 PowerPoint에서는 보이지만 PDF에서는 보이지 않나요?**

PDF는 정적 형식이므로 애니메이션 및 슬라이드 전환이 재생되지 않습니다. 움직임을 유지해야 할 경우 HTML5, 애니메이션 GIF 또는 비디오로 내보내십시오.

**왜 효과가 비디오에서 다르게 재생되나요?**

비디오 내보내기는 원래 PowerPoint 동작을 저장하는 대신 애니메이션을 렌더링합니다. 일부 고급 효과는 지원되지 않거나 근사치로 처리됩니다. 지원되는 효과 표를 검토하고 실제 프레젠테이션을 테스트한 후에 생산에 사용하십시오.

**형태를 앞으로 또는 뒤로 이동하면 애니메이션 순서가 변경되나요?**

아니요. 형태의 z-order는 겹침을 제어하고, 시퀀스 순서와 트리거가 애니메이션 재생을 제어합니다. 다른 재생 순서가 필요하면 타임라인을 변경하십시오.