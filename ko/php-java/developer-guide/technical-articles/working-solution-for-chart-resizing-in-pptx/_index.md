---
title: PPTX에서 차트 크기 조정 문제 해결
type: docs
weight: 40
url: /ko/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 차트 크기 조정
- Excel 차트
- OLE 객체
- 차트 삽입
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 삽입된 Excel OLE 객체와 함께 PPTX에서 발생하는 예기치 않은 차트 크기 조정을 방지합니다. 차트와 OLE 프레임 크기를 일관되게 유지하기 위해 고정 차트 차원을 설정합니다."
---
## **개요**

Aspose 구성 요소를 사용하여 PowerPoint 프레젠테이션에 OLE 개체로 삽입된 Excel 차트는 처음 활성화된 후 크기가 변경될 수 있습니다. 이는 차트가 활성화 전후에 보이는 모습에 눈에 띄는 차이를 일으킬 수 있습니다. 이 문서에서는 크기 변경이 발생하는 이유를 설명하고 고정 차트 차원을 OLE 프레임에 맞추어 이를 방지하는 방법을 보여줍니다.

[프레젠테이션에 OLE 개체로 Excel 차트 만들고 삽입하기](/slides/ko/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)에서는 Aspose.Cells for PHP via Java를 사용하여 Excel 차트를 만들고 Aspose.Slides for PHP via Java를 사용해 PowerPoint 프레젠테이션에 삽입하는 방법을 설명했습니다. [개체 미리보기 문제](/slides/ko/php-java/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 차트 이미지를 차트의 OLE 개체 프레임에 할당했습니다. 출력 프레젠테이션에서 차트 이미지를 표시하는 OLE 개체 프레임을 더블 클릭하면 Excel 차트가 활성화됩니다. 사용자는 삽입된 Excel 워크북을 편집한 후 활성화된 워크북 외부를 클릭하여 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아올 때 OLE 개체 프레임의 크기가 변경되며, 크기 변경 비율은 OLE 개체 프레임과 삽입된 Excel 워크북의 원래 크기에 따라 달라집니다.

## **크기 변경 원인**

삽입된 Excel 워크북은 자체 창 크기를 가지고 있으며, Excel은 개체가 처음 활성화될 때 이 크기를 유지하려고 합니다. 슬라이드의 OLE 프레임은 별도로 정의된 크기를 갖습니다. Excel 워크북이 활성화되면 Excel과 PowerPoint가 삽입 과정의 일환으로 개체 크기를 비율에 맞게 조정하기 위해 협상합니다. 따라서 워크북 창과 OLE 프레임 간의 차이가 개체의 크기 변경을 일으킬 수 있습니다.

## **해결 방법**

차트 크기를 슬라이드의 OLE 프레임에 맞추고 차트 차원을 워크북 창과 독립적으로 유지하십시오. 이 솔루션은 새 프레젠테이션이나 기존 템플릿 모두에 적용됩니다.

이 예제는 Aspose.Cells for PHP via Java와 Aspose.Slides for PHP via Java가 필요합니다. 두 제품을 동일한 PHP/Java Bridge 인스턴스로 구성하고, 두 PHP 래퍼를 로드하며, 두 Java 라이브러리를 브리지에 사용할 수 있게 합니다. 입력 파일은 필요하지 않습니다. 활성 차트 시트에 간단한 세로 막대 차트를 생성하고 워크북을 XLS 형식으로 삽입합니다. 차트 미리보기 이미지는 할당되지 않으며, PowerPoint에서 OLE 개체가 활성화될 때 차트가 표시됩니다.

이 예제는 왼쪽 가장자리에서 0.5인치, 위쪽에서 1인치 떨어진 위치에 9.5 × 4인치 OLE 프레임을 배치하여 새 프레젠테이션을 생성합니다. 슬라이드 좌표와 차원은 포인트(인치당 72포인트) 단위입니다. 기존 프레젠테이션의 경우 [템플릿 사용](#use-a-template)을 참조하십시오.

## **고정 차트 크기 설정**

워크북 창과 독립적으로 차트 차원을 유지하려면 [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow)를 false로 설정합니다. [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) 차원의 크기를 [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) 및 [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height)를 통해 설정하고, 인치를 96픽셀로 환산하여 포인트를 픽셀로 변환합니다: 684 × 288 포인트 프레임은 912 × 384 픽셀 차트에 해당합니다. [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize)를 [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/)의 CUSTOM값으로 설정합니다. 예제에서는 [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame)를 사용해 워크북을 삽입하고 9.5 × 4인치 OLE 프레임으로 프레젠테이션을 저장합니다.

Java 숫자 결과는 PHP 인덱스로 사용되기 전에 `java_values`로 변환됩니다. 워크북 바이트는 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/)에 전달될 때 Java 바이트 배열에 그대로 유지됩니다.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드 좌표와 크기는 포인트 단위이며, 인치당 72포인트입니다.
        $width = 684; // 9.5인치.
        $height = 288; // 4인치.

        $chart->setSizeWithWindow(false);
        // 포인트를 차트 픽셀로 변환하려면 인치당 96픽셀을 사용합니다.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **템플릿 사용**

기존 프레젠테이션에서도 크기 조정 논리는 동일합니다. 예제를 적용하려면:

1. 빈 프레젠테이션을 생성하는 대신 템플릿 프레젠테이션을 로드합니다.
1. 첫 번째 슬라이드에 최소 세 개의 도형이 포함되어 있는지 확인하고, 인덱스 2에 있는 도형을 자리표시자로 사용합니다.
1. 고정 값 684와 288을 사용하는 대신 해당 도형에서 프레임 너비와 높이를 가져옵니다. 크기 계산은 그대로 유지합니다.
1. 고정 좌표 36과 72를 사용하지 않고 자리표시자 위치에 OLE 프레임을 추가합니다.
1. 프레젠테이션을 저장하기 전에 자리표시자를 제거합니다.

## **자주 묻는 질문**

**PowerPoint에서 활성화한 후 내 삽입된 Excel 차트가 크기가 변경되는 이유는 무엇인가요?**

이는 Excel이 처음 활성화될 때 원래 창 크기를 복원하려고 시도하고, PowerPoint의 OLE 개체 프레임은 자체적인 크기를 가지고 있기 때문입니다. PowerPoint와 Excel가 가로세로 비율을 유지하려고 크기를 협상하면서 크기 변경이 발생할 수 있습니다.

**차트와 OLE 프레임 크기를 일관되게 유지하려면 어떻게 해야 하나요?**

OLE 프레임에 맞는 고정 차트 차원을 설정하고 워크북을 삽입하기 전에 사용자 지정 차트 인쇄 크기를 사용하십시오. 위 예제에서는 필요한 설정과 단위 변환 방법을 보여줍니다.

**워크북 창 크기를 맞추는 것만으로 충분한가요?**

워크북 창만 맞추어도 활성화 후 OLE 프레임이 크기가 변경되는 것을 안정적으로 방지할 수 없습니다. 예제와 같이 고정 차트 차원을 사용하십시오.

**이 솔루션은 템플릿 기반 프레젠테이션과 새 프레젠테이션 모두에 적용되나요?**

예. 템플릿의 경우 자리표시자의 차원과 위치를 사용합니다. 새 프레젠테이션의 경우 프레임 차원과 위치를 직접 지정합니다.

**다른 스프레드시트 프로그램으로 만든 차트에도 이 예제를 사용할 수 있나요?**

이 예제는 Aspose.Cells로 만든 Excel 워크북을 사용합니다. 다른 스프레드시트 프로그램에 대한 활성화 동작은 보여주지 않습니다.

## **관련 섹션**

- [프레젠테이션에 OLE 개체로 Excel 차트 만들고 삽입하기](/slides/ko/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)