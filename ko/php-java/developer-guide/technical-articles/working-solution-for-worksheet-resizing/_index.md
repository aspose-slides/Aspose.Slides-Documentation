---
title: 워크시트 크기 조정에 대한 작업 솔루션
type: docs
weight: 20
url: /ko/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 미리보기 이미지
- 이미지 크기 조정
- Excel
- 워크시트
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "프레젠테이션에서 Excel 워크시트 OLE 크기 조정을 해결합니다: 개체 프레임을 일관되게 유지하는 두 가지 방법—프레임을 스케일하거나 시트를 스케일—PPT 및 PPTX 형식 모두에 적용됩니다."
---
{{% alert color="info" title="Note" %}}
Aspose 구성 요소를 사용하여 PowerPoint 프레젠테이션에 OLE 개체로 삽입된 Excel 워크시트는 첫 번째 활성화 후 예상치 않게 크기가 변경될 수 있습니다. 이 동작은 OLE 개체가 활성화 전후에 눈에 띄는 시각적 차이를 만들게 합니다. 이 문서에서는 문제를 설명하고 이를 해결하는 두 가지 방법을 설명합니다.
{{% /alert %}}

## **배경**

이 문서 [OLE 관리](/slides/ko/php-java/manage-ole/)에서는 Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션에 OLE 프레임을 추가하는 방법을 설명했습니다. [개체 미리 보기 문제](/slides/ko/php-java/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 선택한 워크시트 영역의 이미지를 OLE 개체 프레임에 할당했습니다. 출력 프레젠테이션에서 워크시트 이미지를 표시하는 OLE 개체 프레임을 두 번 클릭하면 Excel 통합 문서가 활성화됩니다. 최종 사용자는 실제 Excel 통합 문서를 원하는 대로 수정한 후 활성화된 Excel 통합 문서 바깥을 클릭하여 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아가면 OLE 개체 프레임의 크기가 변경됩니다. 크기 조정 비율은 OLE 개체 프레임의 크기와 삽입된 Excel 통합 문서의 크기에 따라 달라집니다.

## **크기 조정 원인**

Excel 통합 문서는 자체 창 크기를 가지고 있기 때문에 첫 번째 활성화 시 원래 크기를 유지하려고 합니다. 반면 OLE 개체 프레임은 자체 크기를 가집니다. Microsoft에 따르면 Excel 통합 문서가 활성화될 때 Excel과 PowerPoint가 크기를 협상하여 삽입 과정에서 올바른 비율을 유지합니다. 크기 조정은 Excel 창 크기와 OLE 개체 프레임의 크기 및 위치 차이에 따라 발생합니다.

## **작동 솔루션**

크기 조정 효과를 방지하기 위한 두 가지 가능한 솔루션이 있습니다.

- PowerPoint 프레젠테이션에서 OLE 프레임을 선택한 행과 열의 전체 높이와 너비에 맞게 스케일링합니다.
- OLE 프레임 크기를 일정하게 유지하고 선택한 행과 열을 해당 프레임에 맞게 스케일링합니다.

### **OLE 프레임 크기 스케일링**

이 접근 방식은 삽입된 Excel 워크시트에서 선택한 행과 열의 전체 높이와 너비에 맞게 OLE 프레임 크기를 설정합니다.

예제는 기존 Excel 통합 문서를 로드하고, 0 기반 인덱스를 사용하여 첫 번째 워크시트의 처음 10개 행과 13개 열을 선택합니다. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize)는 표시 범위를 정의합니다. 미리 보기는 96 DPI로 렌더링되며, 픽셀 치수는 인치당 72 포인트를 사용하여 포인트로 변환됩니다. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame)은 수정된 통합 문서를 해당 치수의 프레임에 삽입합니다. 미리 보기 이미지는 [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)을 통해 할당되어 저장된 프레젠테이션의 "EMBEDDED OLE OBJECT" 자리 표시자를 교체합니다.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // 수정된 워크북을 삽입하고 Java 바이트 배열에 이진 데이터를 유지합니다.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

미리 보기 도우미는 [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea)를 선택한 범위로 설정하고 여백, 머리글 및 바닥글을 제거합니다. [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea)가 활성화된 상태에서 [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage)는 해당 범위를 PNG 이미지로 렌더링합니다. 도우미는 PNG 이미지를 포함하는 새 입력 스트림을 반환하며, 프레젠테이션에서 사용하기 위해 스트림의 시작 위치에 배치됩니다.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **셀 범위 크기 스케일링**

이 접근 방식은 선택된 행의 높이와 선택된 열의 너비를 사용자 정의 OLE 프레임 크기에 맞게 스케일링합니다.

예제는 기존 Excel 통합 문서를 로드하고, 0 기반 인덱스를 사용하여 첫 번째 워크시트의 처음 10개 행과 13개 열을 선택합니다. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize)는 표시 범위를 정의하며, 아래 도우미는 해당 범위를 가로 400 포인트, 세로 100 포인트인 프레임에 맞게 스케일링합니다. 수정된 통합 문서를 스트림에 저장한 후, [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame)을 사용하여 지정된 크기로 삽입합니다. 96 DPI로 렌더링된 미리 보기 이미지는 [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)을 통해 할당되어 저장된 프레젠테이션에 기본 자리 표시자 대신 선택된 셀을 표시합니다.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // 수정된 워크북을 삽입하고 Java 바이트 배열에 이진 데이터를 유지합니다.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

스케일링 도우미는 선택된 범위에 대해 별도의 가로 및 세로 비율을 계산하여 열의 상대적인 너비와 행의 상대적인 높이를 보존합니다. 계산된 치수를 포인트에서 인치로 변환한 후 [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) 및 [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch)을 사용해 적용합니다. 선택된 범위는 너비와 높이가 0이 아니어야 합니다.

```php
use aspose\cells\CellsUnitType;

// 너비와 높이는 포인트 단위로 예상되는 셀 범위의 크기입니다.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

이 미리 보기 도우미는 [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage)을 사용하여 크기가 변경된 범위를 렌더링합니다. [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea)를 해당 범위로 제한하고, 여백, 머리글 및 바닥글을 제거한 뒤, 시작 위치에 배치된 PNG 스트림을 반환합니다.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **결론**

{{% alert color="info" title="Note" %}}
워크시트 크기 조정 문제를 해결하기 위한 두 가지 접근 방식이 있습니다. 요구 사항과 사용 사례에 가장 적합한 방식을 선택하십시오. 두 접근 방식 모두 템플릿을 사용하든 처음부터 만들든 동일하게 작동합니다. 또한 이 솔루션에서는 OLE 개체 프레임 크기에 제한이 없습니다.
{{% /alert %}}

## **FAQ**

**왜 삽입된 Excel 워크시트가 PowerPoint에서 처음 활성화될 때 크기가 변경됩니까?**

Excel이 활성화될 때 원래 창 크기를 유지하려고 하고, PowerPoint의 OLE 개체 프레임은 자체 차원을 가지고 있기 때문에 발생합니다. PowerPoint와 Excel가 크기를 협상하여 비율을 유지하려고 하며, 이 과정에서 크기 조정이 발생할 수 있습니다.

**이 크기 조정 문제를 완전히 방지할 수 있습니까?**

예. OLE 프레임을 Excel 셀 범위 크기에 맞게 스케일링하거나, 셀 범위를 원하는 OLE 프레임 크기에 맞게 스케일링함으로써 원치 않는 크기 조정을 방지할 수 있습니다.

**어떤 스케일링 방법을 사용해야 합니까, OLE 프레임 스케일링인가 셀 범위 스케일링인가?**

원래 Excel 행 및 열 크기를 유지하고 싶다면 **OLE 프레임 스케일링**을 선택하십시오. 고정된 OLE 프레임 크기를 원한다면 **셀 범위 스케일링**을 선택하십시오.

**템플릿을 기반으로 한 프레젠테이션에서도 이러한 솔루션이 작동합니까?**

예. 두 솔루션 모두 템플릿을 사용해 만든 프레젠테이션과 처음부터 만든 프레젠테이션 모두에 적용됩니다.

**이러한 방법을 사용할 때 OLE 프레임 크기에 제한이 있습니까?**

아니요. 스케일을 적절히 설정하면 OLE 개체 프레임을 원하는 크기로 만들 수 있습니다.

**PowerPoint에서 "EMBEDDED OLE OBJECT" 자리 표시자 텍스트를 피하는 방법이 있습니까?**

예. 대상 Excel 셀 범위의 스냅샷을 촬영하여 OLE 프레임의 자리 표시자 이미지로 설정하면 기본 자리 표시자 대신 사용자 지정 미리 보기 이미지를 표시할 수 있습니다.

## **관련 기사**

[Excel 차트를 생성하고 OLE 개체로 프레젠테이션에 삽입하기](/slides/ko/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint 애드인으로 OLE 개체를 자동 업데이트하기](/slides/ko/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)