---
title: 슬라이드
type: docs
weight: 10
url: /ko/php-java/examples/elements/slide/
keywords:
- 슬라이드
- 슬라이드 추가
- 슬라이드 접근
- 슬라이드 인덱스
- 슬라이드 복제
- 슬라이드 재정렬
- 슬라이드 제거
- 코드 예제
- 파워포인트
- 오픈문서
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 슬라이드를 관리합니다: 만들기, 복제, 재정렬, 숨기기, 배경 및 크기 설정, 전환 적용, 그리고 파워포인트와 오픈문서용으로 내보내기."
---
이 문서는 **Aspose.Slides for PHP via Java**를 사용하여 슬라이드를 다루는 방법을 보여주는 일련의 예제를 제공합니다. `Presentation` 클래스를 사용하여 슬라이드를 추가, 액세스, 복제, 재정렬 및 제거하는 방법을 배우게 됩니다.

아래 각 예제는 간단한 설명과 PHP 코드 스니펫을 포함합니다.

## **슬라이드 추가**

새 슬라이드를 추가하려면 먼저 레이아웃을 선택해야 합니다. 이 예제에서는 `Blank` 레이아웃을 사용하여 프레젠테이션에 빈 슬라이드를 추가합니다.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // 각 슬라이드는 레이아웃을 기반으로 하며, 레이아웃 자체는 마스터 슬라이드를 기반으로 합니다.
        // 새 슬라이드를 만들기 위해 Blank 레이아웃을 사용합니다.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // 선택한 레이아웃을 사용하여 새로운 빈 슬라이드를 추가합니다.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **팁:** 각 슬라이드 레이아웃은 마스터 슬라이드에서 파생되며, 마스터 슬라이드는 전체 디자인과 플레이스홀더 구조를 정의합니다. 아래 이미지는 PowerPoint에서 마스터 슬라이드와 관련 레이아웃이 어떻게 구성되는지를 보여줍니다.

![마스터 및 레이아웃 관계](master-layout-slide.png)

## **인덱스로 슬라이드 접근**

인덱스를 사용하여 슬라이드에 접근할 수 있습니다.

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // 인덱스로 슬라이드에 접근합니다.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **슬라이드 복제**

이 예제는 기존 슬라이드 복제 방법을 보여줍니다. 복제된 슬라이드는 슬라이드 컬렉션의 끝에 자동으로 추가됩니다.

```php
function cloneSlide() {
    // 기본적으로 프레젠테이션에는 빈 슬라이드가 하나 포함되어 있습니다.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 첫 번째 슬라이드를 복제합니다; 복제된 슬라이드는 프레젠테이션 끝에 추가됩니다.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // 복제된 슬라이드의 인덱스는 1입니다 (프레젠테이션의 두 번째 슬라이드).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **슬라이드 재정렬**

슬라이드를 새 인덱스로 이동시켜 순서를 변경할 수 있습니다. 여기서는 슬라이드를 첫 번째 위치로 이동합니다.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // 슬라이드를 첫 번째 위치로 이동합니다 (다른 슬라이드가 아래로 이동합니다).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **슬라이드 제거**

슬라이드를 제거하려면 해당 슬라이드를 참조하고 `remove`를 호출하면 됩니다. 이 예제는 인덱스와 참조를 통해 슬라이드를 제거하는 방법을 보여줍니다.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // 인덱스로 슬라이드 제거.
        $presentation->getSlides()->removeAt(0);

        // 참조로 슬라이드 제거.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```