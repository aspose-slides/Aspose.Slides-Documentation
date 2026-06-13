---
title: 섹션
type: docs
weight: 90
url: /ko/php-java/examples/elements/section/
keywords:
- 섹션
- 슬라이드 섹션
- 섹션 추가
- 섹션 액세스
- 섹션 제거
- 섹션 이름 바꾸기
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP와 Aspose.Slides를 사용하여 슬라이드 섹션을 관리합니다: 섹션을 쉽게 생성·이름 변경·순서 재배치하고, 섹션 간 슬라이드를 이동하며, PPT, PPTX 및 ODP의 가시성을 제어합니다."
---
프레젠테이션 섹션을 관리하는 예시—**Aspose.Slides for PHP via Java**를 사용하여 프로그램matically 섹션을 추가, 액세스, 삭제 및 이름 바꾸는 방법.

## **섹션 추가**

특정 슬라이드에서 시작하는 섹션을 생성합니다.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 섹션의 시작을 표시하는 슬라이드를 지정합니다.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **섹션 액세스**

프레젠테이션에서 섹션 정보를 읽어옵니다.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // 인덱스로 섹션에 접근합니다.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **섹션 제거**

이전에 추가된 섹션을 삭제합니다.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // 섹션을 제거합니다.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **섹션 이름 바꾸기**

기존 섹션의 이름을 변경합니다.

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```