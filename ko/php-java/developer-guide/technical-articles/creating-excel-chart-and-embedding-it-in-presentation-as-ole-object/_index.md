---
title: Excel 차트를 만들고 프레젠테이션에 OLE 개체로 삽입
type: docs
weight: 30
url: /ko/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 차트
- 차트 삽입
- OLE 개체
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Cells for PHP via Java를 사용하여 Excel 차트를 만들고, Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션에 워크북을 삽입합니다. 차트 미리보기도 포함됩니다."
---
## **개요**

이 문서에서는 Aspose.Cells for PHP via Java를 사용하여 Excel 세로 막대형 차트를 만들고, 해당 워크북을 Aspose.Slides for PHP via Java를 사용한 PowerPoint 프레젠테이션에 삽입하는 방법을 보여줍니다. 삽입된 워크북에는 원본 데이터와 차트가 모두 포함됩니다. 별도의 PNG 미리보기가 OLE 개체가 활성화되기 전에 슬라이드에 차트를 표시합니다.

결과는 본래 PowerPoint 차트가 아니라 삽입된 Excel 개체입니다. OLE를 통해 워크북을 편집하려면 OLE 활성화를 지원하는 데스크톱 애플리케이션과 호환되는 Excel이 설치돼 있어야 합니다.

## **전제 조건**

같은 PHP/Java Bridge 인스턴스를 사용하여 Aspose.Cells for PHP via Java와 Aspose.Slides for PHP via Java를 구성합니다. 두 PHP 래퍼를 로드하고 두 제품의 Java 라이브러리를 브리지에서 사용할 수 있도록 합니다. 이러한 라이브러리로 프레젠테이션을 생성하는 데 Microsoft Office는 필요하지 않습니다.

입력 파일은 필요하지 않습니다. 예제는 메모리 내에서 데이터와 차트를 생성한 뒤 `OutputChart.pptx`를 현재 작업 디렉터리에 씁니다. 평가 모드가 아닐 때는 두 제품 모두에 대한 라이선스를 적용하세요.

## **삽입 동작 방식**

1. 데이터 워크시트와 차트 시트를 포함한 워크북을 생성합니다.
1. 차트 시트를 활성화하여 워크북이 차트에서 열리도록 합니다.
1. 워크북의 OLE 표시 범위를 설정하고 차트를 PNG로 렌더링합니다.
1. 워크북을 메모리 내 XLSX 형식으로 저장하고 해당 바이트를 슬라이드에 삽입합니다.
1. PNG를 OLE 개체의 미리보기 이미지로 지정하고 프레젠테이션을 PPTX 형식으로 저장합니다.

워크북 표시 범위와 슬라이드의 프레임은 서로 다른 역할을 합니다. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) 는 0부터 시작하는 행 및 열의 시작/끝 인덱스를 사용합니다. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) 은 대신 상위 행, 좌측 열, 하위 행, 우측 열을 사용합니다. 예제에서는 행 인덱스 55와 열 인덱스 25를 오른쪽 아래 경계로 사용했으며, 이는 레이아웃 선택일 뿐 데이터 행이나 열의 수를 의미하지 않습니다.

슬라이드 프레임은 포인트 단위를 사용합니다. 예제는 프레임을 슬라이드에 맞추어 배치하고 PNG의 종횡비를 유지하면서 중앙에 위치시킵니다. 미리보기를 슬라이드 전체에 늘리지는 않습니다.

## **차트 생성 및 삽입**

다음 전체 예제는 `DataSheet`에 4개의 행과 5개의 열에 해당하는 값을 채웁니다. 각 행은 차트 시리즈가 됩니다. 워크북을 저장하기 전에 `ChartSheet`를 활성 시트로 선택합니다.

워크북은 명시적으로 XLSX 형식으로 저장되며, 이는 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/)에 전달된 `xlsx` 확장자와 일치합니다. Java 숫자 결과는 PHP가 연산을 수행하기 전에 `java_values` 로 변환되고, 바이너리 데이터는 Java 바이트 배열에 그대로 유지됩니다. PNG는 중간 비트맵 변환 없이 바이트에서 직접 로드됩니다. 이를 [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 를 통해 할당하면 기본 OLE 자리표시자가 교체됩니다.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Slides에 전달할 때 PNG와 XLSX를 Java 바이트 배열로 유지합니다.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // 미리보기를 비율을 유지하면서 맞추고 중앙에 배치합니다.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **예상 결과**

`OutputChart.pptx`에는 삽입된 Excel 워크북과 차트 미리보기가 포함된 하나의 슬라이드가 들어 있습니다. 워크북에는 원본 데이터와 네 개의 시리즈가 있는 세로 막대형 차트가 들어 있습니다. 미리보기는 슬라이드 중앙에 배치되고 비율을 유지합니다.

![삽입된 워크북 미리보기로 표시된 Excel 세로 막대형 차트](excel-chart-ole-preview.png)

Excel이 설치된 호환 가능한 데스크톱 PowerPoint 환경에서는 개체를 더블 클릭하여 삽입된 워크북을 활성화하고 편집할 수 있습니다. 활성화 및 편집은 호스트 애플리케이션의 OLE 지원 및 보안 설정에 따라 달라집니다.

## **FAQ**

**왜 미리보기 이미지가 필요합니까?**

삽입된 워크북과 슬라이드 미리보기는 별개의 콘텐츠입니다. 차트 이미지를 제공하여 슬라이드가 기본 "EMBEDDED OLE OBJECT" 자리표시자 대신 차트를 표시하도록 합니다. 자세한 내용은 [Object Preview Issue when Adding OleObjectFrame](/slides/ko/php-java/object-preview-issue-when-adding-oleobjectframe/)를 참조하세요.

**코드에서 워크북을 변경하면 미리보기가 자동으로 업데이트됩니까?**

미리보기는 스냅샷으로 간주하십시오. 프로그래밍 방식으로 워크북 데이터를 업데이트할 때 차트 이미지를 다시 생성하고 미리보기와 삽입된 워크북 데이터를 모두 교체해야 합니다.

**XLS 대신 XLSX를 사용할 수 있나요?**

예. 워크북을 XLS 형식으로 저장하고 삽입된 데이터 확장자로 `xls`를 사용합니다. 확장자는 실제 워크북 형식과 일치해야 하며, 확장자를 변경하는 것만으로는 데이터가 변환되지 않습니다.

**활성화 후 개체 크기가 변경될 수 있는 이유는 무엇입니까?**

호스트 애플리케이션이 워크북을 활성화할 때 OLE 개체의 표시를 업데이트할 수 있습니다. 워크북의 OLE 표시 범위와 슬라이드 프레임 크기 모두가 중요합니다. 자세한 내용은 [Working Solution for Chart Resizing in PPTX](/slides/ko/java/working-solution-for-chart-resizing-in-pptx/)를 확인하십시오.

## **관련 섹션**

- [PPTX에서 차트 크기 조정을 위한 작업 솔루션](/slides/ko/java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame 추가 시 객체 미리보기 문제](/slides/ko/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [OLE 개체 관리](/slides/ko/php-java/manage-ole/)