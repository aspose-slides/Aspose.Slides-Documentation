---
title: PHP를 사용하여 프레젠테이션의 테이블 셀 관리
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
description: "PHP에서 PowerPoint 테이블 셀을 관리합니다: 병합된 셀 식별, 테두리 제거, 셀 분할, 배경 색상 및 이미지를 Aspose.Slides for PHP via Java를 사용하여 설정합니다."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 테이블 셀에 접근하고 수정할 수 있습니다. 이 문서에서는 병합된 테이블 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀을 병합하거나 분할한 후 셀 번호를 다루는 방법, 셀의 배경 색상을 변경하는 방법, 그리고 테이블 셀 내부에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 생성하거나 열고, 슬라이드에서 테이블을 가져오며, 셀 속성을 통해 셀 서식을 업데이트하고, 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 보여줍니다.

Aspose.Slides는 `(column, row)` 순서로 테이블 셀에 접근하기 위해 0부터 시작하는 인덱스를 사용합니다.

## **병합된 테이블 셀 식별**

예제는 기존 프레젠테이션을 열고 첫 번째 슬라이드의 첫 번째 도형을 테이블로 접근합니다. 슬라이드와 도형이 존재하고 도형이 테이블이라고 가정합니다. 그런 다음 모든 행과 열을 반복하면서 [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/)을 사용해 병합 영역에 있는 셀을 식별합니다. 일치하는 각 셀에 대해 `row;column` 순서로 셀 좌표와 [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), 그리고 영역 시작 좌표인 [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/)와 [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/)를 출력합니다.

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

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)을 생성하고 첫 번째 슬라이드에 [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/)을 사용해 테이블을 추가합니다. 열 너비, 행 높이 및 테이블 위치는 포인트 단위로 지정됩니다. 예제는 네 개의 셀 테두스를 모두 [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/)으로 설정하여 보이지 않게 합니다.

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

## **테이블 셀 병합**

[mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/)을 사용해 직사각형 범위의 테이블 셀을 하나의 셀로 결합합니다. 범위의 좌상단 셀과 우하단 셀을 지정합니다. 마지막 인자는 지정된 범위 밖의 셀을 포함할 수 있는지를 제어하며, `false`는 병합을 해당 범위 안에만 유지합니다.

예제는 70 포인트 너비와 높이를 가진 4×4 테이블을 만든 뒤, `(1, 1)`부터 `(2, 2)`까지 네 개의 중앙 셀을 병합합니다. 결과 셀은 두 열과 두 행을 차지하지만, 테이블의 기본 그리드는 여전히 네 열과 네 행을 유지합니다. 병합된 셀의 내용이나 서식에 접근하려면 이 예제에서는 `$table->get_Item(1, 1)`을 사용합니다. 병합 범위에 포함되지 않은 다른 위치는 테이블 그리드의 일부로 남아 있기 때문에 범위 외 셀의 인덱스는 변경되지 않습니다.

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

이전 예제에서 셀을 병합하면 테이블 그리드가 보존됩니다. 셀을 분할하면 새로운 그리드 열이 추가되고 오른쪽 셀들의 열 인덱스가 변경될 수 있습니다. Aspose.Slides는 PowerPoint의 테이블 그리드 모델을 따릅니다.

이 예제는 70 포인트 너비와 높이를 가진 4×4 테이블을 만든 뒤 셀 `(1, 1)`에 대해 [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/)을 호출합니다. 셀의 70 포인트 너비 절반을 전달하여 두 개의 같은 너비 셀을 생성합니다.

분할 후 두 절반은 `$table->get_Item(1, 1)`와 `$table->get_Item(2, 1)`으로 접근합니다. 테이블 그리드는 이제 다섯 열을 갖게 되며, 원래 2·3 열에 있던 셀은 각각 3·4 열로 이동합니다. 행 인덱스는 변하지 않습니다. 분할 후 셀에 접근할 때는 업데이트된 열 인덱스를 사용하십시오.

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

### **행 또는 열 범위로 병합된 셀 분할**

병합된 템플릿 셀을 데이터 입력용으로 준비하려면 기존 행 경계에 따라 [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/)으로, 열 경계에 따라 [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/)으로 분할합니다.

`index` 인자는 분할된 상단 부분의 행 또는 왼쪽 부분의 열을 계산하며, 병합 영역을 기준으로 합니다:

- 행 분할: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- 열 분할: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

예제는 첫 번째 슬라이드 첫 번째 도형이 테이블이며 `(1, 2)`와 `(1, 3)`이 수직으로 병합되어 있다고 가정합니다. 아래쪽 위치에서 시작해 [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/)와 [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/)을 사용해 시작점을 찾고 두 스팬을 확인합니다. `splitByRowSpan(1)`은 제품 이름을 위해 행 2와 3을 분리합니다. 가로 두 열 병합의 경우 대신 `splitByColSpan(1)`을 사용합니다.

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

테이블 그리드와 주변 셀 인덱스는 변경되지 않습니다. 결과 셀을 좌표로 조회하면 두 셀 모두 스팬이 1이며 [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/)은 `false`를 반환합니다. 하나의 분할 후에도 더 큰 영역이 부분적으로 병합된 상태로 남을 수 있습니다.

원본 텍스트와 서식은 상위(또는 왼쪽) 셀에 남고, 새 셀은 비어 있지만 채우기, 테두리, 여백 등 셀 서식을 그대로 상속합니다. 분할 후 셀에 텍스트를 채우고 필요한 텍스트 서식을 명시적으로 설정하십시오.

저장된 프레젠테이션에는 템플릿의 셀 서식이 유지된 채 "Product A"와 "Product B" 셀 각각이 별도로 존재합니다. 자세한 내용은 [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)를 참조하십시오.

## **테이블 셀 배경 색상 변경**

이 예제는 150 포인트 열과 50 포인트 행을 가진 테이블을 생성합니다. [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/)을 사용해 단색 채우기를 선택하고, [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/)이 반환하는 색을 빨간색으로 설정하여 셀 `(2, 3)` (세 번째 열, 네 번째 행)의 배경 색을 변경합니다.

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

예제를 실행하기 전에 입력 이미지를 작업 디렉터리에 배치하십시오. 이미지를 [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile)으로 로드하고 [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/)를 사용해 프레젠테이션 이미지 컬렉션에 추가합니다. 그런 다음 이미지를 셀 `(0, 0)`(테이블 첫 번째 셀)의 그림 채우기 속성에 할당합니다.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/)은 이미지를 셀에 맞게 늘려 채우므로 비율이 변경될 수 있습니다. 열 너비와 행 높이는 포인트 단위입니다. 로드된 이미지는 프레젠테이션에 추가된 후 `finally` 블록에서 해제됩니다.

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

예. [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) 테두리는 각각 별도 속성을 가지므로 각 면의 두께와 스타일을 다르게 설정할 수 있습니다.

**셀 배경에 그림을 설정한 후 열/행 크기를 변경하면 이미지가 어떻게 되나요?**

동작은 [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/)에 따라 다릅니다. 스트레칭이면 이미지가 새 셀 크기에 맞게 조정되고, 타일링이면 타일이 다시 계산됩니다.

**셀 전체 내용에 하이퍼링크를 지정할 수 있나요?**

[Hyperlinks](/slides/ko/php-java/manage-hyperlinks/)은 셀 텍스트 프레임 내부의 텍스트(부분) 수준이나 전체 테이블/도형 수준에서 설정됩니다. 실제로는 셀의 일부 텍스트나 전체 텍스트에 링크를 지정합니다.

**단일 셀 내에서 서로 다른 글꼴을 사용할 수 있나요?**

예. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)(런)별로 글꼴 패밀리, 스타일, 크기 및 색상을 독립적으로 지정할 수 있습니다.