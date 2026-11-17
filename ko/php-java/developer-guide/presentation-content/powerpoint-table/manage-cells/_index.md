---
title: PHP를 사용한 프레젠테이션 테이블 셀 관리
linktitle: 셀 관리
type: docs
weight: 30
url: /ko/php-java/manage-cells/
keywords:
- 테이블 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 내 이미지
- 배경 색상
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP에서 Aspose.Slides for Java를 이용해 PowerPoint 테이블 셀을 관리합니다: 병합된 셀 식별, 테두리 제거, 셀 분할, 배경 색상 및 이미지 설정."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 테이블 셀에 접근하고 수정할 수 있습니다. 이 문서에서는 병합된 테이블 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀을 병합하거나 분할한 후 셀 번호를 처리하는 방법, 셀 배경 색상을 변경하는 방법, 그리고 테이블 셀 안에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 생성하거나 열고, 슬라이드에서 테이블을 가져와 셀 속성을 통해 셀 서식을 업데이트하고, 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 보여줍니다.

Aspose.Slides는 테이블 셀에 접근할 때 `(열, 행)` 순서의 0 기반 인덱스를 사용합니다.

## **병합된 테이블 셀 식별**

이 예제는 기존 프레젠테이션을 열고 첫 번째 슬라이드의 첫 번째 도형을 테이블로 사용합니다. 슬라이드와 도형이 존재하며 도형이 테이블이라고 가정합니다. 그런 다음 모든 행과 열을 순회하면서 [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/)을 사용해 병합된 영역에 있는 셀을 식별합니다. 일치하는 셀마다 `행;열` 순서로 셀 좌표와 [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), 그리고 영역 시작 좌표인 [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/)와 [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/)를 출력합니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **테이블 셀 테두리 제거**

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)을 생성하고 [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/)을 사용해 첫 번째 슬라이드에 테이블을 추가합니다. 열 너비, 행 높이 및 테이블 위치는 포인트 단위로 지정됩니다. 예제에서는 네 개의 셀 테두리를 모두 [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/)으로 설정해 보이지 않게 만듭니다.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **대각선 셀 테두리 추가**

[getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/)을 사용해 왼쪽 위 모서리에서 오른쪽 아래 모서리까지 선을 그리며, [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/)을 사용해 왼쪽 아래 모서리에서 오른쪽 위 모서리까지 선을 그립니다. 대각선은 코너 헤더를 표시할 수 있으며, 두 대각선을 모두 사용하면 셀을 적용 불가능으로 표시하는 X 모양을 만들 수 있습니다.

각 대각선은 고유한 [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/)을 가집니다. 해당 [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/)에서 [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/)을 사용해 [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/)을 선택하고 [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/)를 통해 색을 지정합니다. 선의 두께는 [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/)로 포인트 단위에서 설정합니다.

예제에서는 하나의 행에 세 개의 셀을 만들고 각각 빨간색 하향 대각선, 파란색 상향 대각선, 그리고 두 대각선을 모두 적용합니다. 상단, 하단, 좌측, 우측 테두리는 그대로 유지됩니다.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

대각선은 셀 서식만 변경합니다. 각 셀은 하나의 텍스트 프레임을 유지하며, 이는 [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/)을 통해 접근합니다. 대각선 양쪽 영역은 독립적으로 편집할 수 없습니다.

Microsoft PowerPoint에서 렌더링된 저장된 테이블:

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*왼쪽에서 오른쪽 순서: 하향 대각선(빨강, 3 pt), 상향 대각선(파랑, 5 pt), 그리고 두 대각선이 교차하여 X 형태.*

## **테이블 셀 병합**

[mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/)을 사용해 직사각형 영역의 테이블 셀을 하나의 셀로 결합합니다. 영역의 좌측 상단 셀과 우측 하단 셀을 지정합니다. 마지막 인자는 병합이 지정된 영역 밖의 셀을 포함할 수 있는지를 제어하며, `false`이면 해당 영역 내부에만 병합이 제한됩니다.

예제에서는 열과 행이 70 포인트인 4×4 테이블을 만든 다음, `(1, 1)`부터 `(2, 2)`까지 네 개의 가운데 셀을 병합합니다. 결과 셀은 두 열과 두 행을 차지하지만, 테이블의 기본 그리드는 여전히 네 열과 네 행을 유지합니다. 병합된 셀의 내용이나 서식에 접근하려면 이 예제와 같이 좌측 상단 위치 `$table->get_Item(1, 1)`을 사용합니다. 병합 영역 외부의 셀 위치는 변경되지 않습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **테이블 셀 분할**

앞 예제에서 셀을 병합하면 테이블 그리드가 유지됩니다. 셀을 분할하면 새로운 그리드 열이 추가되고 오른쪽에 있는 셀들의 열 인덱스가 변할 수 있습니다. Aspose.Slides는 PowerPoint의 테이블 그리드 모델을 따릅니다.

이 예제에서는 열과 행이 70 포인트인 4×4 테이블을 만든 뒤 셀 `(1, 1)`에 대해 [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/)를 호출합니다. 셀의 70 포인트 너비 중 절반을 전달해 두 개의 동일 폭 셀을 생성합니다.

분할 후 두 절반은 `$table->get_Item(1, 1)`와 `$table->get_Item(2, 1)`으로 접근합니다. 테이블 그리드는 이제 다섯 열을 갖게 되며, 원래 열 2와 3에 있던 셀은 각각 열 3과 4로 이동합니다. 행 인덱스는 변하지 않습니다. 분할 후 셀에 접근할 때는 업데이트된 열 인덱스를 사용하십시오.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![An unmerged 70-point cell splits into two 35-point cells, adding a fifth grid column and shifting the indices to its right.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*너비 분할은 셀 (1, 1)에 적용되며, 0 기반 (열, 행) 인덱스를 사용합니다. 다른 행은 두 새로운 열 위치를 모두 차지하는 셀을 유지합니다.*
<!-- visual-explanation:manage-cells:end -->

### **행 또는 열 Span을 기준으로 병합된 셀 분할**

병합된 템플릿 셀을 데이터 입력용으로 준비하려면 [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/)을 사용해 기존 행 경계 따라 분할하거나, [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/)을 사용해 열 경계 따라 분할합니다.

`index` 인자는 분할된 상단(또는 좌측) 부분의 행 또는 열 수를 나타내며, 병합된 영역을 기준으로 합니다:

- 행 분할: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- 열 분할: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

예제는 프레젠테이션에 첫 번째 슬라이드 첫 번째 도형으로 테이블이 존재하고, `(1, 2)`와 `(1, 3)`이 수직으로 병합되어 있다고 가정합니다. 아래쪽 위치에서 시작해 [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/)와 [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/)를 사용해 원점을 찾고 두 스팬을 확인합니다. `splitByRowSpan(1)`을 호출하면 제품명용으로 행 2와 3을 분리합니다. 가로 두 열 병합인 경우 대신 `splitByColSpan(1)`을 사용합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // 분할 후 테이블에서 결과 셀을 가져옵니다.
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

테이블 그리드와 주변 셀 인덱스는 변하지 않습니다. 결과 셀을 좌표로 검색하면 두 셀 모두 Span이 1이며 [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/)은 `false`를 반환합니다. 하나의 분할 후에도 큰 영역이 부분적으로 병합된 상태로 남을 수 있습니다.

원본 텍스트와 서식은 상단(또는 좌측) 셀에 남고, 새로운 셀은 비어 있지만 채우기, 테두리, 여백과 같은 셀 서식을 상속합니다. 분할 후 셀에 데이터를 채우고 필요한 텍스트 서식을 명시적으로 설정하십시오.

저장된 프레젠테이션에는 템플릿 셀 서식이 유지된 채 "Product A"와 "Product B" 셀 각각이 별도로 표시됩니다. 자세한 내용은 [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)를 참고하십시오.

### **특정 높이로 셀 분할**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/)은 위쪽 부분의 높이를 포인트 단위로 받습니다. [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/)은 위쪽 부분에 해당하는 기존 그리드 행 수를 받습니다. 오른쪽 열에 40 포인트 셀을 가운데 배치하려면 셀 실제 높이에서 40을 빼고 남은 공간을 위아래에 동일하게 나눕니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

첫 번째 분할은 그리드 행을 하나 추가하고 셀 `(1, 1)` 아래쪽에 90 포인트를 남깁니다. 두 번째 분할은 해당 셀을 40 포인트 중간 셀과 50 포인트 하단 셀로 나눕니다. 오른쪽 열은 이제 위에서 아래 순서대로 높이가 50, 40, 50 포인트인 세 개의 셀을 갖게 됩니다. 왼쪽 셀은 세 행을 모두 차지하며 원래 높이인 140 포인트를 유지합니다.

![The left cell spans the full table height beside three cells with Middle in the center.](split-by-height.png)

## **테이블 셀 배경 색상 변경**

이 예제는 열이 150 포인트, 행이 50 포인트인 테이블을 생성합니다. [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/)을 사용해 단색 채우기를 선택하고, [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/)이 반환하는 색을 빨간색으로 설정하여 셀 `(2, 3)`(3번째 열, 4번째 행)의 배경을 변경합니다.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **테이블 셀 안에 이미지 추가**

예제를 실행하기 전에 입력 이미지를 작업 디렉터리에 배치하십시오. 이미지는 [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile)으로 로드하고, [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/)를 사용해 프레젠테이션의 이미지 컬렉션에 추가합니다. 그런 다음 이미지를 셀 `(0, 0)`(테이블의 첫 번째 셀)의 그림 채우기로 지정합니다.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/)는 이미지를 셀 전체에 맞게 늘리며, 이 과정에서 가로세로 비율이 변할 수 있습니다. 열 너비와 행 높이는 포인트 단위입니다. 로드된 이미지는 프레젠테이션에 추가된 후 `finally` 블록에서 해제됩니다.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**단일 셀의 서로 다른 면에 대해 선 두께와 스타일을 다르게 지정할 수 있나요?**

네. [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/), [bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/), [left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/), [right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) 테두리는 각각 별도 속성을 가지므로 각 면의 두께와 스타일을 다르게 지정할 수 있습니다.

**셀 배경에 그림을 설정한 후 열/행 크기를 변경하면 이미지가 어떻게 되나요?**

동작은 [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/)(stretch/tile)에 따라 달라집니다. stretch 모드에서는 이미지가 새로운 셀 크기에 맞게 조정되고, tile 모드에서는 타일이 다시 계산됩니다.

**셀 전체 내용에 하이퍼링크를 지정할 수 있나요?**

[Hyperlinks](/slides/ko/php-java/manage-hyperlinks/)는 셀 텍스트 프레임 내부의 텍스트(포션) 수준이나 전체 테이블/도형 수준에서 설정됩니다. 실무에서는 셀 내의 전체 텍스트 또는 특정 포션에 링크를 할당합니다.

**단일 셀 안에서 서로 다른 글꼴을 사용할 수 있나요?**

네. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)(런) 별로 독립적인 서식을 지원하므로 글꼴 종류, 스타일, 크기 및 색상을 각각 지정할 수 있습니다.