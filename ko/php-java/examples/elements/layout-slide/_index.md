---
title: 레이아웃 슬라이드
type: docs
weight: 20
url: /ko/php-java/examples/elements/layout-slide/
keywords:
- 레이아웃 슬라이드
- 레이아웃 슬라이드 추가
- 레이아웃 슬라이드 액세스
- 레이아웃 슬라이드 제거
- 사용되지 않는 레이아웃 슬라이드
- 레이아웃 슬라이드 복제
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides와 함께 PHP를 사용하여 레이아웃 슬라이드를 관리합니다: PPT, PPTX 및 ODP 프레젠테이션에서 레이아웃 슬라이드를 만들고, 적용하고, 복제하고, 이름을 바꾸고, 자리 표시자와 테마를 사용자 지정합니다."
---
이 문서는 Java를 통해 PHP용 Aspose.Slides에서 **Layout Slides**를 사용하는 방법을 보여줍니다. 레이아웃 슬라이드는 일반 슬라이드가 상속받는 디자인과 서식을 정의합니다. 레이아웃 슬라이드를 추가, 액세스, 복제 및 제거할 수 있으며, 사용되지 않은 슬라이드를 정리하여 프레젠테이션 크기를 줄일 수 있습니다.

## **레이아웃 슬라이드 추가**

재사용 가능한 서식을 정의하기 위해 사용자 지정 레이아웃 슬라이드를 만들 수 있습니다. 예를 들어, 이 레이아웃을 사용하는 모든 슬라이드에 표시되는 텍스트 상자를 추가할 수 있습니다.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // 빈 레이아웃 유형과 사용자 지정 이름으로 레이아웃 슬라이드를 생성합니다.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** 레이아웃 슬라이드는 개별 슬라이드의 템플릿 역할을 합니다. 공통 요소를 한 번 정의하고 여러 슬라이드에서 재사용할 수 있습니다.

> 💡 **Tip 2:** 레이아웃 슬라이드에 도형이나 텍스트를 추가하면 해당 레이아웃을 기반으로 하는 모든 슬라이드에 이 공유 콘텐츠가 자동으로 표시됩니다.  
> 아래 스크린샷은 동일한 레이아웃 슬라이드에서 텍스트 상자를 상속받은 두 슬라이드를 보여줍니다.

![Slides Inheriting Layout Content](layout-slide-result.png)


## **레이아웃 슬라이드 액세스**

레이아웃 슬라이드는 인덱스 또는 레이아웃 유형(예: `Blank`, `Title`, `SectionHeader` 등)으로 액세스할 수 있습니다.

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // 인덱스로 액세스합니다.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // 레이아웃 유형으로 액세스합니다.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **레이아웃 슬라이드 제거**

필요하지 않은 경우 특정 레이아웃 슬라이드를 제거할 수 있습니다.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // 유형으로 레이아웃 슬라이드를 가져와서 제거합니다.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **사용되지 않는 레이아웃 슬라이드 제거**

프레젠테이션 크기를 줄이기 위해 일반 슬라이드에서 사용되지 않는 레이아웃 슬라이드를 제거할 수 있습니다.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // 자동으로 어떤 슬라이드에도 참조되지 않은 모든 레이아웃 슬라이드를 제거합니다.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **레이아웃 슬라이드 복제**

`addClone` 메서드를 사용하여 레이아웃 슬라이드를 복제할 수 있습니다.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // 유형으로 기존 레이아웃 슬라이드를 가져옵니다.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // 레이아웃 슬라이드 컬렉션 끝에 레이아웃 슬라이드를 복제합니다.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Summary:** 레이아웃 슬라이드는 슬라이드 전반에 일관된 서식을 관리하는 강력한 도구입니다. Aspose.Slides는 레이아웃 슬라이드의 생성, 관리 및 최적화에 대한 전체 제어를 제공합니다.