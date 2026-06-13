---
title: 헤더 푸터
type: docs
weight: 220
url: /ko/php-java/examples/elements/header-footer/
keywords:
- 헤더 푸터
- 헤더 푸터 추가
- 헤더 푸터 업데이트
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용한 PHP에서 헤더와 푸터를 제어합니다: 날짜/시간, 슬라이드 번호 및 푸터 텍스트를 추가하거나 편집하고, PPT, PPTX 및 ODP 전체에서 자리 표시자를 표시하거나 숨깁니다."
---
**Aspose.Slides for PHP via Java**를 사용하여 바닥글을 추가하고 날짜 및 시간 자리 표시자를 업데이트하는 방법을 보여줍니다.

## **바닥글 추가**

슬라이드의 바닥글 영역에 텍스트를 추가하고 표시하도록 합니다.

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **날짜 및 시간 업데이트**

슬라이드의 날짜 및 시간 자리 표시자를 수정합니다.

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```