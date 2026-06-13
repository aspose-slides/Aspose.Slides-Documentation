---
title: 마스터 슬라이드
type: docs
weight: 30
url: /ko/php-java/examples/elements/master-slide/
keywords:
- 마스터 슬라이드
- 마스터 슬라이드 추가
- 마스터 슬라이드 접근
- 마스터 슬라이드 제거
- 사용되지 않는 마스터 슬라이드
- 코드 예시
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용한 PHP에서 마스터 슬라이드를 관리합니다: 슬라이드를 통합하기 위해 테마, 배경, 자리표시자를 생성, 편집, 복제 및 서식 지정합니다 (PowerPoint 및 OpenDocument)."
---
마스터 슬라이드는 PowerPoint에서 슬라이드 상속 계층 구조의 최상위 수준을 형성합니다. A **마스터 슬라이드**는 배경, 로고, 텍스트 서식과 같은 공통 디자인 요소를 정의합니다. **레이아웃 슬라이드**는 마스터 슬라이드로부터 상속받으며, **일반 슬라이드**는 레이아웃 슬라이드로부터 상속받습니다.

이 문서는 Aspose.Slides for PHP via Java를 사용하여 마스터 슬라이드를 생성, 수정 및 관리하는 방법을 보여줍니다.

## **마스터 슬라이드 추가**

이 예제는 기본 마스터 슬라이드를 복제하여 새 마스터 슬라이드를 만드는 방법을 보여줍니다.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // 기본 마스터 슬라이드를 복제합니다.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** 마스터 슬라이드는 모든 슬라이드에 일관된 브랜딩 또는 공유 디자인 요소를 적용하는 방법을 제공합니다. 마스터에 대한 변경 사항은 자동으로 종속 레이아웃 및 일반 슬라이드에 반영됩니다.

> 💡 **Tip 2:** 마스터 슬라이드에 추가된 모든 도형이나 서식은 레이아웃 슬라이드에 상속되고, 그 레이아웃을 사용하는 모든 일반 슬라이드에도 상속됩니다.  
> 아래 이미지는 마스터 슬라이드에 추가된 텍스트 상자가 최종 슬라이드에 자동으로 렌더링되는 방식을 보여줍니다.

![Master Inheritance Example](master-slide-banner.png)

## **마스터 슬라이드 접근**

`Presentation::getMasters` 메서드를 사용하여 마스터 슬라이드에 접근할 수 있습니다. 다음은 슬라이드를 가져오고 작업하는 방법입니다:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // 첫 번째 마스터 슬라이드에 접근합니다.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **마스터 슬라이드 제거**

마스터 슬라이드는 인덱스 또는 참조를 사용하여 제거할 수 있습니다.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // 인덱스로 제거합니다.
        $presentation->getMasters()->removeAt(0);

        // 또는 참조로 제거합니다.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **사용되지 않는 마스터 슬라이드 제거**

일부 프레젠테이션에는 사용되지 않는 마스터 슬라이드가 포함되어 있습니다. 이러한 슬라이드를 제거하면 파일 크기를 줄이는 데 도움이 됩니다.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // 사용되지 않는 모든 마스터 슬라이드를 제거합니다 (보존으로 표시된 슬라이드 포함).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Tip:** `removeUnused(true)`를 사용하여 사용되지 않는 마스터 슬라이드를 정리하고 프레젠테이션 크기를 최소화합니다.