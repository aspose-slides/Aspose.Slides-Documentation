---
title: PHP에서 프레젠테이션 테이블 관리
linktitle: 테이블 관리
type: docs
weight: 10
url: /ko/php-java/manage-table/
keywords:
- 테이블 추가
- 테이블 생성
- 테이블 접근
- 가로세로 비율
- 텍스트 정렬
- 텍스트 서식 지정
- 테이블 스타일
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 슬라이드에서 테이블을 만들고 편집합니다. 테이블 작업 흐름을 간소화하는 간단한 코드 예제를 확인하세요."
---
## **소개**

PowerPoint의 테이블은 정보를 행과 열로 정리하여 값을 읽고 비교하기 쉽게 합니다.

Aspose.Slides는 [테이블](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 클래스, [셀](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) 클래스 및 기타 유형을 제공하여 프레젠테이션에서 테이블을 만들고, 업데이트하고, 관리할 수 있도록 합니다.

## **테이블을 처음부터 만들기**

위치, 열 너비 및 행 높이를 지정하여 테이블을 만듭니다. 슬라이드에 추가한 후 셀 테두리를 서식 지정하고, 셀을 병합하고, 텍스트를 삽입할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 포인트 단위의 열 너비 배열을 정의합니다.
4. 포인트 단위의 행 높이 배열을 정의합니다.
5. [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) 메서드를 사용해 슬라이드에 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 객체를 추가합니다.
6. 각 [셀](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)을 반복하여 상, 하, 좌, 우 테두리 서식을 적용합니다.
7. 테이블 첫 번째 행의 처음 두 셀을 병합합니다.
8. [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) 메서드를 통해 병합된 셀에 접근합니다.
9. 병합된 셀에 텍스트를 설정합니다.
10. 수정된 프레젠테이션을 저장합니다.

아래 예제는 (100, 50) 포인트 위치에 열 3개와 행 5개의 테이블을 생성합니다. 테두리는 너비 5포인트의 빨간색으로 적용하고, 첫 번째 행의 처음 두 셀을 병합한 뒤 결과를 `table.pptx` 파일로 저장합니다.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **표준 테이블에서 번호 매기기**

표준 테이블에서 셀 인덱스는 0부터 시작하며 (열, 행) 순서를 사용합니다. 첫 번째 셀의 인덱스는 (0, 0)입니다.

예를 들어, 열 4개와 행 4개의 테이블에서 셀은 다음과 같이 번호가 매겨집니다:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

이 예제는 위에 표시된 4×4 테이블을 생성하고, 열 너비와 행 높이를 70포인트, 테두리는 너비 5포인트의 빨간색으로 설정합니다. 좌표는 셀 인덱스를 나타냅니다; 예제는 셀을 비워 두고 테이블을 `StandardTables_out.pptx` 파일로 저장합니다.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **기존 테이블에 접근하기**

테이블은 슬라이드의 도형 컬렉션에 저장됩니다. 도형을 반복하여 테이블을 찾은 후, [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 클래스를 사용해 해당 셀을 읽거나 업데이트합니다.

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 클래스를 사용해 프레젠테이션을 로드합니다.
2. 인덱스로 테이블을 포함하는 슬라이드에 대한 참조를 가져옵니다.
3. [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 객체를 반복하고 테이블을 찾으면 중지합니다. 슬라이드에 여러 테이블이 있는 경우, 필요한 테이블을 식별하기 위해 [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/)를 사용합니다.
4. 대상 셀의 텍스트를 업데이트합니다.
5. 수정된 프레젠테이션을 저장합니다.

아래 예제는 `UpdateExistingTable.pptx` 파일을 열어 첫 번째 슬라이드에서 첫 번째 테이블을 찾습니다. 열 0, 행 1에 해당하는 셀을 `New`로 설정하고 결과를 `table1_out.pptx` 파일로 저장합니다. 입력 파일은 최소 하나의 슬라이드를 포함해야 하며, 해당 슬라이드의 첫 번째 테이블은 최소 하나의 열과 두 개의 행을 가져야 합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

기존 테이블에서 행 크기를 조정하고, 실제 높이가 요청한 최소값을 초과할 수 있는 이유를 이해하려면 [행 높이 제어](/slides/ko/php-java/manage-rows-and-columns/#control-row-height)를 참조하십시오.

## **텍스트 프레임을 소유한 셀 찾기**

일반 텍스트 처리 코드가 테이블에서 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)을 수신하면, [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) 메서드를 사용해 해당 [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)을 가져올 수 있습니다. 테이블 셀의 텍스트 프레임에서는 [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell)이 소유자를 반환하고, [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape)은 `null`을 반환합니다. 이는 테이블 자체가 도형이지만 그렇습니다.

셀 좌표는 읽기 전용 [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) 및 [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) 메서드를 통해 확인할 수 있습니다. [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell)은 또한 읽기 전용 탐색을 제공하며, 소유자를 반환하지만 소유권을 변경하지 않습니다. 사용하기 전에 항상 반환된 셀을 `java_is_null`로 확인하십시오.

테이블 셀 및 도형 소유자(스마트아트 노드와 연결된 도형 포함)를 식별하는 전체 예제는 [텍스트 검색 및 교체](/slides/ko/php-java/search-and-replace-text/)를 참조하십시오.

## **테이블에서 텍스트 정렬**

개별 테이블 셀의 수직 고정 및 텍스트 방향을 제어할 수 있습니다. 이 섹션의 예제는 첫 번째 셀의 텍스트를 가운데 정렬하고 270도 회전시킵니다.

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 객체를 추가합니다.
4. 테이블에서 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 객체에 접근합니다.
5. 첫 번째 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)에 접근하여 텍스트와 색상을 설정합니다.
6. [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) 및 [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/)을 사용해 셀의 수직 고정과 텍스트 방향을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

이 예제는 열 너비 120포인트, 행 높이 100포인트인 4×4 테이블을 생성합니다. 셀 (0, 0)의 텍스트를 서식 지정하고, 첫 번째 행의 나머지 셀에 값을 추가한 뒤 결과를 `Vertical_Align_Text_out.pptx` 파일로 저장합니다.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **테이블 수준에서 텍스트 서식 지정**

[setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/)을 사용해 테이블의 모든 셀에 텍스트 서식을 적용합니다. 이 메서드의 오버로드는 부분, 단락 및 텍스트 프레임 서식을 받아들이므로 개별 셀을 반복하지 않고도 이러한 속성을 설정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 클래스를 사용해 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에서 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 객체에 접근합니다.
4. 텍스트의 글꼴 크기를 [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight)로 설정합니다.
5. [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/)와 [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/)을 사용해 단락 정렬 및 오른쪽 여백을 설정합니다.
6. [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/)을 사용해 텍스트 방향을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

아래 예제는 최소 하나의 슬라이드와 첫 번째 도형으로 테이블을 포함하는 `table.pptx` 파일을 엽니다. 글꼴 크기를 25포인트로 설정하고, 단락을 오른쪽 정렬하며 오른쪽 여백을 20포인트로 지정하고, 텍스트를 수직으로 설정합니다. 서식이 적용된 프레젠테이션은 `result.pptx` 파일로 저장됩니다.

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **테이블 스타일 속성 가져오기**

[getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/)을 사용해 테이블의 미리 설정된 스타일을 읽고, [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/)을 사용해 적용합니다. 이 예제는 한 테이블에 [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/)을 적용하고, 프리셋 값을 출력한 뒤 두 번째 테이블에 동일한 프리셋을 할당합니다. 두 테이블은 `table-style.pptx`에 저장됩니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **테이블의 가로세로 비율 고정**

테이블의 가로세로 비율은 너비와 높이의 비율을 말합니다. [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/)을 사용해 이 비율을 고정할 수 있습니다.

아래 예제는 최소 하나의 슬라이드와 첫 번째 도형으로 테이블을 포함하는 `pres.pptx` 파일을 엽니다. 현재 잠금 상태를 출력하고, 가로세로 비율 고정을 활성화한 뒤 업데이트된 상태(`true`)를 출력하고, 결과를 `pres-out.pptx` 파일로 저장합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**전체 테이블 및 셀 내 텍스트에 대해 오른쪽‑왼쪽(RTL) 읽기 방향을 활성화할 수 있나요?**

예. 테이블에는 [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) 메서드가 제공되며, 단락에는 [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/)가 있습니다. 두 가지를 모두 사용하면 셀 내부에서 올바른 RTL 순서와 렌더링이 보장됩니다.

**사용자가 최종 파일에서 테이블을 이동하거나 크기를 조정하지 못하도록 방지하려면 어떻게 해야 하나요?**

[도형 잠금](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/)을 사용해 이동, 크기 조정, 선택 등을 비활성화할 수 있습니다. 이러한 잠금은 테이블에도 적용됩니다.

**셀 안에 이미지를 배경으로 삽입하는 것이 지원되나요?**

예. 셀에 [그림 채우기](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/)을 설정하면 이미지를 배경으로 사용할 수 있습니다; 선택한 모드(늘리기 또는 타일)에 따라 이미지가 셀 영역을 덮습니다.