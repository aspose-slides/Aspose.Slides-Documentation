---
title: 테이블
type: docs
weight: 120
url: /ko/php-java/examples/elements/table/
keywords:
- 테이블
- 테이블 추가
- 테이블 액세스
- 테이블 삭제
- 셀 병합
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP와 Aspose.Slides를 사용해 테이블을 만들고 서식 지정: 데이터를 삽입하고, 셀을 병합하며, 테두리를 스타일링하고, 내용을 정렬하고, PPT, PPTX 및 ODP에 대한 가져오기/내보내기를 수행합니다."
---
**Aspose.Slides for PHP via Java**를 사용하여 테이블을 추가하고, 액세스하고, 삭제하고, 셀을 병합하는 예제입니다.

## **테이블 추가**

두 행과 두 열로 구성된 간단한 테이블을 만듭니다.

```php
function addTable() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $widths = [80, 80];
        $heights = [30, 30];
        $table = $slide->getShapes()->addTable(50, 50, $widths, $heights);

        $presentation->save("table.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **테이블 액세스**

슬라이드에서 첫 번째 테이블 모양을 가져옵니다.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드에서 첫 번째 테이블에 접근합니다.
        $firstTable = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Table"))) {
                $firstTable = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **테이블 삭제**

슬라이드에서 테이블을 삭제합니다.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 테이블이 슬라이드의 첫 번째 도형이라고 가정합니다.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **테이블 셀 병합**

테이블의 인접한 셀을 하나의 셀로 병합합니다.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 테이블이 슬라이드의 첫 번째 도형이라고 가정합니다.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```