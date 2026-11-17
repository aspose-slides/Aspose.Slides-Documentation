---
title: PHP를 사용하여 프레젠테이션에서 슬라이드 전환 관리
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
description: "Aspose.Slides for PHP via Java를 사용하여 슬라이드 전환을 적용하고 자동 슬라이드 전진을 구성하며 Morph 및 기타 전환 효과를 사용자 지정합니다."
---
## **개요**

슬라이드 전환은 슬라이드 쇼 중 슬라이드가 표시되는 방식을 제어합니다. Aspose.Slides for PHP via Java를 사용하면 각 슬라이드에 전환 효과를 선택하고 마우스 클릭 또는 타이머에 의한 전진을 구성하며 효과에 따라 특정 옵션을 조정할 수 있습니다. 이 문서에서는 PHP 예제를 사용하여 전환을 적용하고 정확한 전환 지속 시간을 설정하고 슬라이드 타이밍을 관리하며 두 슬라이드 사이에 Morph 전환을 만드는 방법을 보여줍니다. 또한 설정을 PPTX 파일에 저장하는 방법도示합니다.

## **슬라이드 전환 추가**

전환을 적용하려면 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 클래스로 프레젠테이션을 로드하고 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 를 통해 슬라이드의 전환 설정에 접근합니다. [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 열거형에서 값을 선택하여 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 과 함께 사용한 다음 프레젠테이션을 저장합니다.

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

[setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) 메서드는 대상 슬라이드를 표시할 방사형 섹터 수를 제어합니다. [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 에서 Wheel을 선택하려면 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 을 사용하고, [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/) 설정에 접근하려면 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) 를 호출합니다.

예제는 두 개의 동일한 슬라이드 쌍을 만듭니다. 각 쌍은 검은색 슬라이드로 시작하고 금색 사각형이 덮인 슬라이드로 끝납니다. 슬라이드 2는 하나의 spoke를 사용하고 슬라이드 4는 여덟 개를 사용합니다. 두 전환 모두 [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) 로 설정된 동일한 느린 속도와 [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 으로 설정된 8,000밀리초의 명시적 지속 시간을 사용합니다.

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

저장된 프레젠테이션을 PowerPoint에서 열고 슬라이드 쇼를 시작하십시오. 슬라이드 1에서 슬라이드 2로 전진하면 시계 방향으로 한 번 스윕되는 것을 볼 수 있습니다. 그런 다음 슬라이드 3에서 슬라이드 4로 전진하면 8개의 방사형 섹터가 동시에 같은 사각형을 표시합니다.

## **고급 슬라이드 전환 추가**

슬라이드가 화면에 남아 있는 시간과 마우스 클릭으로 슬라이드 쇼를 전진시킬지 여부를 구성할 수 있습니다. 다음 메서드가 이 동작을 제어합니다.

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 은 사용자가 마우스를 클릭하여 전진하도록 허용합니다.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 은 자동 전진을 활성화합니다.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 은 자동 전진 전에 지연 시간을 밀리초 단위로 지정합니다.

클릭 전진과 타이머 전진을 모두 활성화하여 사용자가 클릭하거나 타이머를 기다려 진행할 수 있도록 합니다. 타이머만 사용하려면 [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 에 `false` 를 전달하십시오. 지연 시간은 슬라이드 쇼가 언제 전진하는지를 제어하며, 시각적 전환 효과의 지속 시간을 설정하지는 않습니다.

이 예제는 처음 세 개 슬라이드에 서로 다른 효과를 할당하고 각각 3초, 5초, 7초 후 자동 전진을 활성화합니다. 마우스 클릭으로도 이 슬라이드들을 전진시킬 수 있습니다. 최소 세 개 슬라이드가 있는 `input.pptx` 파일을 사용하십시오.

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

타이머 전진이 활성화되어 있는지 확인하려면 [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) 를 호출하십시오. 저장된 지연 시간만으로는 타이머가 활성 상태인지 판단할 수 없습니다.

다음 예제는 위에서 저장한 파일을 열어 각 활성화된 타이머를 보고 2초 이상 지연된 슬라이드의 자동 전진을 비활성화합니다. 해당 슬라이드에 대해 마우스 클릭을 활성화하고 업데이트된 설정을 저장합니다.

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

## **전환 타이밍을 정확하게 제어**

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 를 사용하여 전환 효과의 정확한 길이를 밀리초 단위로 지정합니다. 슬라이드의 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 메서드는 이러한 설정을 [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) 을 통해 노출합니다.

| 메서드 | 목적 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | 전환 효과 자체의 지속 시간을 밀리초 단위로 설정합니다. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 슬라이드가 자동으로 전진하기 전의 지연 시간을 밀리초 단위로 설정합니다. 이 타이머를 활성화하려면 [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 에 `true` 를 전달하십시오. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) 열거형의 사전 정의된 속도 범주(Slow, Medium, Fast) 중 하나를 선택합니다. 명시적인 지속 시간이 지정되지 않은 경우에 사용됩니다. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 은 전환 효과만 제어하며 슬라이드가 화면에 남아 있는 시간을 결정하지는 않습니다. 자동 전진 지연은 별도로 구성하십시오. 명시적인 지속 시간이 설정되지 않은 경우 Aspose.Slides는 전환 유형과 [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) 값을 기반으로 효과 지속 시간을 결정합니다.

<!-- visual-explanation:slide-transition:start -->
[![분리된 막대가 750ms 전환 지속 시간과 5,000ms 자동 전진 설정을 나타냅니다.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*공유된 예제는 각 슬라이드에 750ms Fade 전환을 적용하고 자동 전진을 5,000ms에 별도로 활성화합니다. 전환 지속 시간은 효과를 제어하고, 전진은 슬라이드를 떠나는 시점을 제어합니다. 이 막대들은 측정된 결합 타임라인이 아닌 개념적인 설정을 나타냅니다.*
<!-- visual-explanation:slide-transition:end -->

### **모든 슬라이드에 동일한 지속 시간 적용**

일관된 속도를 위해 모든 슬라이드에 동일한 효과와 정확한 지속 시간을 적용하십시오. 이 예제는 `input.pptx` 를 로드하고 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 에서 Fade를 선택한 뒤 각 전환에 750밀리초 지속 시간을 부여합니다. 또한 5,000밀리초 후 자동 전진을 별도로 활성화하고 마우스 클릭 전진을 비활성화한 뒤 결과를 PPTX 로 저장합니다.

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

        // 효과 지속 시간과 별개로 자동 전진을 구성합니다.
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

슬라이드마다 다른 효과 지속 시간을 사용할 수 있습니다. 예를 들어 제목 슬라이드에는 짧은 전환을, 섹션 소개 슬라이드에는 긴 전환을 사용합니다. 이 예제는 첫 번째 슬라이드에 500밀리초, 두 번째 슬라이드에 1,200밀리초를 설정합니다. 최소 두 개 슬라이드가 있는 `input.pptx` 파일을 사용하십시오.

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

### **애니메이션 출력과 전환 조정**

[animated GIF](/slides/ko/php-java/convert-powerpoint-to-animated-gif/) , [HTML5 presentation](/slides/ko/php-java/export-to-html5/) 또는 [video](/slides/ko/php-java/convert-powerpoint-to-video/) 를 준비할 때 내보내기 전에 정확한 전환 지속 시간을 설정하여 의도한 템포와 일치시킵니다. 예를 들어 장면 사이에 600밀리초 페이드를 사용하고, 각 슬라이드의 전진 지연을 별도로 조정하여 내레이션이나 콘텐츠에 충분한 시간을 제공합니다.

GIF와 비디오의 경우, 프레임 레이트를 효과 지속 시간에 맞추십시오: 600밀리초는 초당 30프레임일 때 18프레임에 해당합니다. HTML5에서는 내보내기 설정에서 애니메이션 전환을 활성화하십시오. 선택한 내보내기 형식이 지원하는 효과와 타이밍 옵션을 확인하고, 출력물을 미리 보아 동기화를 확인하십시오.

### **기존 전환 지속 시간 읽기**

전환을 수정하기 전에 [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) 을 호출하여 명시적인 값이 저장되어 있는지 확인하십시오. `-1` 값은 명시적인 지속 시간이 설정되지 않았음을 의미하고, 0 이상 값은 밀리초 단위의 저장된 지속 시간을 나타냅니다. 설정되지 않은 값은 계산된 재생 지속 시간이 아니며, Aspose.Slides는 전환 유형과 [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) 값을 사용해 해당 지속 시간을 결정합니다. 전환 유형을 설정하면 지속 시간이 초기화될 수 있으므로 먼저 원래 설정을 검사하십시오.

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

Morph 전환은 연속된 슬라이드에 있는 객체 간의 변화를 애니메이션화합니다. 간단한 Morph 효과를 만들려면 슬라이드를 복제하고 복제본에서 객체를 이동하거나 크기를 조정한 뒤 두 번째 슬라이드에 Morph 전환을 적용합니다. 이렇게 하면 전환이 원본 및 수정된 상태 사이의 해당 객체를 애니메이션화합니다.

다음 예제는 텍스트 사각형이 포함된 슬라이드를 만들고, 슬라이드를 복제한 뒤 복제본에서 사각형의 위치와 크기를 변경합니다. 그런 다음 두 번째 슬라이드에 대해 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 열거형에서 Morph를 선택합니다. Morph를 지원하는 프레젠테이션 뷰어에서 저장된 파일을 열어 슬라이드 쇼 중 효과를 확인하십시오.

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

[TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) 열거형은 Morph가 콘텐츠를 일치시키고 애니메이션화하는 방식을 제어합니다.

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) 은 각 도형을 전체 객체로 취급합니다.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) 은 가능한 경우 단어를 매치하여 텍스트를 애니메이션화합니다.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) 은 가능한 경우 문자를 매치하여 텍스트를 애니메이션화합니다.

[Morph] 를 선택하려면 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 을 호출한 뒤 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) 에 접근하십시오. 반환된 값은 [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) 객체를 제공하며, 이 객체의 [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) 메서드로 매치 모드를 선택합니다.

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

일부 전환은 방향이나 효과가 검은 화면에서 시작되는지 여부와 같은 추가 옵션을 제공합니다. 사용 가능한 옵션은 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 로 선택한 전환에 따라 다릅니다. 먼저 유형을 설정한 뒤 [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) 로 적절한 전환 객체를 사용하십시오.

다음 예제는 `input.pptx` 의 첫 번째 슬라이드에 Cut 전환을 적용합니다. [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) 을 통해 [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) 을 호출하여 전환이 검은 화면에서 시작하도록 합니다.

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

네. 밀리초 단위의 정확한 효과 지속 시간이 필요한 경우 [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) 을 선호하십시오. 사전 정의된 [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) 범주(느림, 보통, 빠름)만으로 충분하고 명시적인 지속 시간이 설정되지 않은 경우에는 [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) 을 사용하십시오. 이러한 설정은 자동 전진 지연과는 별도로 전환 효과를 제어합니다.

**전환에 오디오를 첨부하고 루프 재생하도록 할 수 있나요?**

네. [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound) 로 내장 오디오를 지정하고, [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) 열거형에서 StartSound 를 [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) 에 전달한 뒤, `true` 로 [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) 을 활성화하십시오. 오디오는 슬라이드 쇼의 다음 사운드 이벤트가 발생할 때까지 루프됩니다.

**모든 슬라이드에 동일한 전환을 적용하는 가장 빠른 방법은?**

프레젠테이션의 [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) 컬렉션을 반복하고 각 슬라이드의 전환에 대해 같은 값으로 [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) 을 호출하십시오. 동일한 루프 내에서 타이밍 및 효과 옵션도 설정하여 슬라이드 전체에 일관된 동작을 유지하십시오.

**현재 슬라이드에 설정된 전환을 확인하려면 어떻게 해야 하나요?**

슬라이드의 [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) 결과에 대해 [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) 을 호출하십시오. 반환값은 [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 열거형의 값이며, None 은 전환 효과가 적용되지 않았음을 의미합니다.