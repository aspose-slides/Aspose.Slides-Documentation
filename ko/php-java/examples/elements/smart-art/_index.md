---
title: 스마트아트
type: docs
weight: 140
url: /ko/php-java/examples/elements/smartart/
keywords:
- 스마트아트
- 스마트아트 추가
- 스마트아트 액세스
- 스마트아트 제거
- 스마트아트 레이아웃
- 코드 예제
- 파워포인트
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 스마트아트를 만들고 편집합니다: 노드를 추가하고, 레이아웃과 스타일을 변경하며, 정확하게 도형으로 변환하고, PPT, PPTX 및 ODP로 내보냅니다."
---
**Aspose.Slides for PHP via Java**를 사용하여 SmartArt 그래픽을 추가하고, 액세스하고, 제거하고, 레이아웃을 변경하는 방법을 보여 줍니다.

## **SmartArt 추가**

내장 레이아웃 중 하나를 사용하여 SmartArt 그래픽을 삽입합니다.

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **SmartArt 액세스**

슬라이드에서 첫 번째 SmartArt 개체를 검색합니다.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드에서 첫 번째 SmartArt에 액세스합니다.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **SmartArt 제거**

슬라이드에서 SmartArt 도형을 삭제합니다.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 도형이 SmartArt라고 가정합니다.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **SmartArt 레이아웃 변경**

기존 SmartArt 그래픽의 레이아웃 유형을 업데이트합니다.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 도형이 SmartArt라고 가정합니다.
        $smartArt = $slide->getShapes()->get_Item(0);

        // SmartArt의 레이아웃을 변경합니다.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```