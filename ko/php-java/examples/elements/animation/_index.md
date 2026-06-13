---
title: 애니메이션
type: docs
weight: 100
url: /ko/php-java/examples/elements/animation/
keywords:
- 애니메이션
- 애니메이션 추가
- 애니메이션 접근
- 애니메이션 제거
- 애니메이션 시퀀스
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용한 PHP에서 슬라이드 애니메이션을 마스터하세요: 효과, 타이밍 및 트리거를 추가, 편집 및 제거하여 PPT, PPTX 및 ODP에서 동적 프레젠테이션을 만들 수 있습니다."
---
간단한 애니메이션을 만들고 **Aspose.Slides for PHP via Java**를 사용하여 시퀀스를 관리하는 방법을 보여줍니다.

## **애니메이션 추가**

사각형 모양을 만들고 클릭 시 트리거되는 페이드 인 효과를 적용합니다.

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // 페이드 인 효과.
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **애니메이션 접근**

슬라이드 타임라인에서 첫 번째 애니메이션 효과를 가져옵니다.

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 첫 번째 애니메이션 효과에 접근합니다.
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **애니메이션 제거**

시퀀스에서 애니메이션 효과를 제거합니다.

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // 효과를 제거합니다.
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **애니메이션 순서 지정**

여러 효과를 추가하고 애니메이션이 발생하는 순서를 보여줍니다.

```php
function sequenceAnimations() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 200, 50, 100, 100);

        $sequence = $slide->getTimeline()->getMainSequence();
        $sequence->addEffect($shape1, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
        $sequence->addEffect($shape2, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);

        $presentation->save("animation_sequence.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```