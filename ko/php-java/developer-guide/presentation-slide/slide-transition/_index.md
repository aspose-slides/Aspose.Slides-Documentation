---
title: PHP를 사용하여 프레젠테이션의 슬라이드 전환 관리
linktitle: 슬라이드 전환
type: docs
weight: 80
url: /ko/php-java/slide-transition/
keywords:
- 슬라이드 전환
- 슬라이드 전환 추가
- 슬라이드 전환 적용
- 고급 슬라이드 전환
- Morph 전환
- 전환 유형
- 전환 효과
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 슬라이드 전환을 적용하고, 자동 슬라이드 진행을 구성하며, Morph 및 기타 전환 효과를 사용자 지정합니다."
---
## **개요**

슬라이드 전환은 슬라이드 쇼 동안 슬라이드가 표시되는 방식을 제어합니다. Aspose.Slides for PHP via Java를 사용하면 각 슬라이드에 전환 효과를 선택하고, 마우스 클릭 또는 타이머에 의한 진행을 구성하며, 효과에 특정 옵션을 조정할 수 있습니다. 이 문서에서는 PHP 예제를 사용하여 전환을 적용하고, 정확한 전환 지속 시간을 설정하고, 슬라이드 타이밍을 관리하며, 두 슬라이드 간에 Morph 전환을 만드는 방법을 보여줍니다. 예제에서는 설정을 PPTX 파일에 저장하는 방법도 보여줍니다.

## **슬라이드 전환 추가**

전환을 적용하려면 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 클래스로 프레젠테이션을 로드하고, [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 메서드를 통해 슬라이드의 전환 설정에 접근합니다. [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 열거형 값 중 하나를 사용하여 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 메서드를 호출한 뒤 프레젠테이션을 저장합니다.

다음 예제는 첫 번째 슬라이드에 Circle 전환을, 두 번째 슬라이드에 Comb 전환을 적용합니다. 최소 두 개의 슬라이드가 있는 `input.pptx` 파일을 사용하십시오.

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

## **Wheel 전환**

[setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) 메서드는 대상 슬라이드를 표시하는 방사형 섹터의 개수를 제어합니다. [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 열거형에서 Wheel을 선택하려면 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType)을 사용하고, [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/) 설정에 접근하려면 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue)를 호출합니다.

예제에서는 두 개의 동일한 슬라이드 쌍을 만들고, 각 쌍은 검은색 슬라이드로 시작해 금색 사각형으로 덮인 슬라이드로 끝납니다. 슬라이드 2는 1개의 스포크를 사용하고, 슬라이드 4는 8개의 스포크를 사용합니다. 두 전환 모두 [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed)으로 같은 느린 속도를 지정하고, [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration)으로 8,000밀리초의 명시적인 지속 시간을 설정합니다.

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

저장된 프레젠테이션을 PowerPoint에서 열고 슬라이드 쇼를 시작하십시오. 슬라이드 1에서 슬라이드 2로 이동하면 시계 방향으로 한 번 회전하는 것을 볼 수 있습니다. 그런 다음 슬라이드 3에서 슬라이드 4로 이동하면 여덟 개의 방사형 섹터가 동시에 동일한 사각형을 드러냅니다.

## **Reveal 전환을 사용한 검은 색으로 페이드**

대상 슬라이드의 전환 유형을 Reveal로 설정한 뒤, 해당 [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/) 설정에서 [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack) 메서드를 호출합니다. 예제에서는 청록색 원본 슬라이드와 산호색 대상 슬라이드를 만든 뒤 두 슬라이드를 복제합니다. 각 쌍은 동일한 2초 길이의 Reveal 전환을 사용합니다. 두 번째 쌍만 검은 색을 통해 페이드됩니다.

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

저장된 프레젠테이션을 PowerPoint에서 열고 슬라이드 쇼를 시작하십시오. 슬라이드 1에서 슬라이드 2로 이동하면 청록색이 직접 산호색으로 페이드됩니다. 그런 다음 슬라이드 3에서 슬라이드 4로 이동하면 화면이 잠시 거의 검은 색으로 어두워졌다가 산호색 슬라이드가 나타납니다. 두 슬라이드 모두 원래 배경 색을 유지합니다.

아래 행은 0.5초 간격으로 PowerPoint에서 캡처한 프레임을 보여줍니다. 각 행의 중간 프레임을 비교하여 효과를 확인하십시오.

![분리된 막대가 750밀리초 전환 지속 시간과 5,000밀리초 자동 진행 설정을 나타냅니다.](reveal-through-black.png)

## **고급 슬라이드 전환 추가**

슬라이드가 화면에 머무는 시간과 마우스 클릭으로 슬라이드 쇼를 진행할지 여부를 구성할 수 있습니다. 다음 메서드가 이러한 동작을 제어합니다.

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 은 사용자가 마우스를 클릭하여 진행할 수 있도록 합니다.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 은 자동 진행을 활성화합니다.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 은 자동 진행 전 지연 시간을 밀리초 단위로 지정합니다.

클릭과 타이머 기반 진행을 모두 활성화하면 사용자는 클릭으로 이동하거나 타이머를 기다릴 수 있습니다. 타이머만 사용하려면 [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick)에 `false`를 전달하십시오. 지연은 슬라이드 쇼가 진행되는 시점을 제어하며, 시각적 전환 효과의 지속 시간을 설정하지는 않습니다.

이 예제는 처음 세 슬라이드에 서로 다른 효과를 할당하고 각각 3초, 5초, 7초 후에 자동 진행을 활성화합니다. 마우스 클릭으로도 슬라이드를 진행할 수 있습니다. 최소 세 개의 슬라이드가 있는 `input.pptx` 파일을 사용하십시오.

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

타이머 기반 진행이 활성화되었는지 확인하려면 [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) 메서드를 호출하십시오. 저장된 지연만으로는 타이머가 활성 상태인지를 판단할 수 없습니다.

다음 예제는 앞서 저장한 파일을 열고, 활성화된 타이머를 각각 보고, 지연 시간이 2초를 초과하는 슬라이드의 자동 진행을 비활성화합니다. 그런 슬라이드에 대해 마우스 클릭을 활성화하고 업데이트된 설정을 저장합니다.

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

## **전환 타이밍을 정확히 제어**

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 메서드를 사용하여 전환 효과의 정확한 길이를 밀리초 단위로 지정합니다. 슬라이드의 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 메서드를 통해 [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) 객체에서 이러한 설정에 접근할 수 있습니다.

| 메서드 | 목적 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | 전환 효과 자체의 지속 시간을 밀리초 단위로 설정합니다. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 슬라이드가 자동으로 진행되기 전의 지연 시간을 밀리초 단위로 설정합니다. 이 타이머를 활성화하려면 [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter)에 `true`를 전달하십시오. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) 열거형의 사전 정의된 속도 카테고리(느림, 보통, 빠름) 중 하나를 선택합니다. 정확한 지속 시간을 지정하지 않을 때 사용됩니다. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration)은 전환 효과만 제어하며, 슬라이드가 화면에 머무는 시간을 결정하지는 않습니다. 자동 진행 지연은 별도로 구성해야 합니다. 명시적인 지속 시간이 지정되지 않은 경우 Aspose.Slides는 전환 유형과 [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) 값으로 효과 지속 시간을 판단합니다.

<!-- visual-explanation:slide-transition:start -->
[![분리된 막대가 750밀리초 전환 지속 시간과 5,000밀리초 자동 진행 설정을 나타냅니다.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*공유 예제는 각 슬라이드에 750밀리초 Fade 전환을 적용하고, 별도로 5,000밀리초 자동 진행을 활성화합니다. 전환 지속 시간은 효과를 제어하고, 진행은 슬라이드를 떠나는 시점을 제어합니다. 이러한 막대는 측정된 타임라인이 아니라 설정을 나타내는 도식입니다.*
<!-- visual-explanation:slide-transition:end -->

### **모든 슬라이드에 동일한 지속 시간 적용**

일관된 속도를 위해 모든 슬라이드에 동일한 효과와 정확한 지속 시간을 적용합니다. 이 예제는 `input.pptx`를 로드하고, [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/)에서 Fade를 선택한 뒤 각 전환에 750밀리초 지속 시간을 부여합니다. 또한 5,000밀리초 후 자동 진행을 별도로 활성화하고 마우스 클릭에 의한 진행은 비활성화한 뒤 결과를 PPTX로 저장합니다.

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

        // 효과 지속 시간과 별개로 자동 진행을 구성합니다.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **개별 슬라이드에 서로 다른 지속 시간 설정**

슬라이드마다 다른 효과 지속 시간을 사용할 수 있습니다. 예를 들어 제목 슬라이드에는 짧은 전환을, 섹션 소개 슬라이드에는 긴 전환을 적용합니다. 이 예제는 첫 번째 슬라이드에 500밀리초, 두 번째 슬라이드에 1,200밀리초를 설정합니다. 최소 두 개의 슬라이드가 있는 `input.pptx` 파일을 사용하십시오.

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

### **애니메이션 출력과 전환을 연계**

[animated GIF](/slides/ko/php-java/convert-powerpoint-to-animated-gif/), [HTML5 프레젠테이션](/slides/ko/php-java/export-to-html5/), 또는 [비디오](/slides/ko/php-java/convert-powerpoint-to-video/)를 준비할 때는 내보내기 전에 정확한 전환 지속 시간을 설정하여 의도한 템포와 맞춥니다. 예를 들어 장면 사이에 600밀리초 페이드를 사용하고, 각 슬라이드의 진행 지연을 별도로 조정하여 내레이션이나 콘텐츠에 충분한 시간을 제공합니다.

GIF와 비디오의 경우 효과 지속 시간에 맞춰 프레임 레이트를 조정하십시오: 600밀리초는 초당 30프레임일 때 18프레임에 해당합니다. HTML5에서는 내보내기 설정에서 애니메이션 전환을 활성화합니다. 선택한 내보내기 형식이 지원하는 효과와 타이밍 옵션을 확인하고, 출력물을 미리 보면서 동기화를 확인하십시오.

### **기존 전환 지속 시간 읽기**

전환을 수정하기 전에 [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) 메서드를 호출하여 명시적인 값이 저장되어 있는지 확인하십시오. `-1`은 명시적인 지속 시간이 설정되지 않았음을 의미하고, 0 이상 값은 밀리초 단위로 저장된 지속 시간을 나타냅니다. 설정되지 않은 값은 계산된 재생 지속 시간이 아니며, Aspose.Slides는 전환 유형과 [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) 값을 사용해 해당 지속 시간을 결정합니다. 전환 유형을 설정하면 지속 시간이 초기화될 수 있으므로 원래 설정을 먼저 검사하십시오.

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

## **Morph 전환**

Morph 전환은 연속된 슬라이드에서 객체 간의 변경을 애니메이션 처리합니다. 간단한 Morph 효과를 만들려면 슬라이드를 복제하고 복제본에서 객체를 이동하거나 크기를 조정한 뒤 두 번째 슬라이드에 Morph 전환을 적용합니다. 이렇게 하면 원본과 수정된 상태 사이를 애니메이션으로 전환할 수 있습니다.

다음 예제는 텍스트 사각형이 있는 슬라이드를 만들고, 해당 슬라이드를 복제한 뒤 복제본에서 사각형의 위치와 크기를 변경합니다. 그런 다음 두 번째 슬라이드의 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 열거형에서 Morph를 선택합니다. Morph를 지원하는 프레젠테이션 뷰어에서 저장된 파일을 열어 슬라이드 쇼 중 효과를 확인하십시오.

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

## **Morph 전환 유형**

[TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) 열거형은 Morph가 콘텐츠를 매칭하고 애니메이션하는 방식을 제어합니다.

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) 은 각 도형을 전체 객체로 취급합니다.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) 은 가능한 경우 단어를 매칭하여 텍스트를 애니메이션합니다.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) 은 가능한 경우 문자를 매칭하여 텍스트를 애니메이션합니다.

[setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType)으로 Morph를 선택한 뒤 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue)를 호출하면 [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) 객체를 얻을 수 있으며, 해당 객체의 [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) 메서드로 매칭 모드를 선택합니다.

이 예제는 이전 섹션에서 만든 프레젠테이션을 열고 두 번째 슬라이드에 단어 기반 Morph 애니메이션을 구성합니다.

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

## **전환 효과 설정**

일부 전환은 방향이나 검은 화면에서 시작하는지 여부와 같은 추가 옵션을 제공합니다. 사용 가능한 옵션은 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType)으로 선택한 전환에 따라 달라집니다. 먼저 유형을 설정한 뒤, [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue)에서 적절한 전환 객체를 사용하십시오.

다음 예제는 `input.pptx`의 첫 번째 슬라이드에 Cut 전환을 적용합니다. [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/)을 통해 [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) 메서드를 호출하여 전환이 검은 화면에서 시작하도록 합니다.

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

## **FAQ**

**슬라이드 전환의 재생 속도를 제어할 수 있나요?**

예. 밀리초 단위의 정확한 효과 지속 시간이 필요할 때는 [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration)을 사용하십시오. 사전 정의된 [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) 카테고리(느림, 보통, 빠름)만으로 충분하고 명시적인 지속 시간을 지정하지 않을 경우에는 [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed)를 사용하십시오. 이러한 설정은 자동 진행 지연과는 별개로 전환 효과만 제어합니다.

**전환에 오디오를 연결하고 반복 재생하게 할 수 있나요?**

예. [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound)으로 임베디드 오디오를 할당하고, [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) 열거형의 `StartSound` 값을 [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode)에 전달한 뒤, `true`를 지정해 [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop)를 활성화합니다. 오디오는 슬라이드 쇼에서 다음 사운드 이벤트가 발생할 때까지 반복됩니다.

**모든 슬라이드에 동일한 전환을 가장 빠르게 적용하는 방법은?**

프레젠테이션의 [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) 컬렉션을 순회하면서 각 슬라이드의 전환에 대해 동일한 값을 사용해 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType)을 호출하십시오. 동일한 루프에서 타이밍 및 효과 옵션을 설정하면 슬라이드 전체에 일관된 동작을 유지할 수 있습니다.

**현재 슬라이드에 설정된 전환이 무엇인지 확인하려면?**

슬라이드의 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 결과에서 [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) 메서드를 호출하십시오. 반환값은 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 열거형 중 하나이며, `None`이면 전환 효과가 적용되지 않은 것입니다.