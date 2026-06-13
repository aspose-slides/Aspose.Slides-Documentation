---
title: 잉크
type: docs
weight: 180
url: /ko/php-java/examples/elements/ink/
keywords:
- 잉크
- 잉크 접근
- 잉크 제거
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP에서 Aspose.Slides를 사용하여 슬라이드의 디지털 잉크를 처리합니다: 펜 스트로크 추가, 경로 편집, 색상 및 두께 설정, 그리고 PowerPoint 및 OpenDocument용 결과를 내보냅니다."
---
기존 잉크 모양에 접근하고 이를 제거하는 예제를 **Aspose.Slides for PHP via Java**를 사용하여 제공합니다.

> ❗ **Note:** 잉크 모양은 특수 장치에서 사용자가 입력한 데이터를 나타냅니다. Aspose.Slides는 프로그래밍 방식으로 새로운 잉크 스트로크를 생성할 수 없지만, 기존 잉크를 읽고 수정할 수 있습니다.

## **잉크 액세스**
슬라이드에서 첫 번째 잉크 모양을 가져옵니다.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드에서 첫 번째 잉크 모양에 접근합니다.
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **잉크 제거**
슬라이드에서 잉크 모양을 삭제합니다.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 모양이 잉크 모양이라고 가정합니다.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```