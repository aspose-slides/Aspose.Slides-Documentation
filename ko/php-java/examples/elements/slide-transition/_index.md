---
title: 슬라이드 전환
type: docs
weight: 110
url: /ko/php-java/examples/elements/slide-transition/
keywords:
- 슬라이드 전환
- 슬라이드 전환 추가
- 슬라이드 전환 접근
- 슬라이드 전환 제거
- 전환 지속 시간
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP에서 Aspose.Slides를 사용하여 슬라이드 전환을 제어합니다: 유형, 속도, 사운드 및 타이밍을 선택하여 PPT, PPTX 및 ODP 프레젠테이션을 다듬습니다."
---
**Aspose.Slides for PHP via Java**을 사용하여 슬라이드 전환 효과와 타이밍을 적용하는 방법을 보여줍니다.

## **슬라이드 전환 추가**

첫 번째 슬라이드에 페이드 전환 효과를 적용합니다.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 페이드 전환을 적용합니다.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **슬라이드 전환 접근**

슬라이드에 할당된 전환 유형을 읽습니다.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 전환 유형에 접근합니다.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **슬라이드 전환 제거**

전환 유형을 `None`으로 설정하여 모든 전환 효과를 제거합니다.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 전환을 None으로 설정하여 제거합니다.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **전환 지속 시간 설정**

자동으로 다음 슬라이드로 넘어가기 전에 슬라이드가 표시되는 시간을 지정합니다.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // 밀리초 단위.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```