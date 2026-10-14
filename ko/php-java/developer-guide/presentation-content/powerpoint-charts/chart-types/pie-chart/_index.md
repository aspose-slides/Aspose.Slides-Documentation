---
title: PHP를 사용하여 프레젠테이션의 원형 차트 사용자 정의
linktitle: 원형 차트
type: docs
url: /ko/php-java/pie-chart/
keywords:
- 원형 차트
- 차트 관리
- 차트 사용자 정의
- 차트 옵션
- 차트 설정
- 플롯 옵션
- 슬라이스 색상
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 원형 차트를 만들고 사용자 정의합니다. 보조 플롯을 구성하고, 데이터 레이블을 표시하며, PowerPoint에서 자동 슬라이스 색상을 적용합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 원형 차트를 사용하는 방법을 설명합니다. Pie of Pie 및 Bar of Pie 차트에 대한 보조 플롯 옵션을 구성하는 방법과 표준 원형 차트에 대해 자동 슬라이스 색상을 활성화하는 방법을 보여줍니다.

예제는 슬라이드에 차트를 추가하고, 시리즈 및 레이블 설정을 조정하고, 기본 차트 데이터를 사용자 지정 카테고리와 값으로 교체한 뒤, 업데이트된 프레젠테이션을 저장하는 차트 사용자 지정 작업에 중점을 둡니다.

## **Pie of Pie 및 Bar of Pie 차트의 보조 플롯 옵션**

Aspose.Slides for PHP via Java는 Pie of Pie 및 Bar of Pie 차트에 대한 보조 플롯 옵션을 지원합니다. 이러한 옵션은 보조 플롯의 크기와 두 플롯 간에 데이터 포인트가 어떻게 분할되는지를 제어합니다.

다음 예제는 새 프레젠테이션에 Pie of Pie 차트를 만들고 데이터 포인트 값을 레이블로 표시합니다. [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) 메서드는 보조 플롯 크기를 메인 플롯의 149%로 설정합니다. [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) 은 백분율 기반 분할을 선택하고, [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) 은 임계값을 53%로 설정합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // 값을 표시하고 보조 플롯을 구성합니다.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **보조 플롯을 위한 카테고리 선택**

특정 카테고리를 백분율 값과 관계없이 보조 플롯에 그룹화하려면 사용자 지정 분할을 사용하십시오. 예를 들어, 매출 보고서에서 온라인과 이벤트를 함께 표시하면 독자는 두 채널을 비교할 수 있습니다(전체 매출의 35%와 10%를 차지함).

[setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy)에 [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/)을 전달하고, [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) 를 통해 포인트를 선택합니다. 컬렉션의 [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) 메서드는 시리즈 내의 0 기반 인덱스를 허용하며, [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) 로 데이터 포인트 객체를 추가합니다. 이 예제에서는 인덱스 1이 온라인을, 인덱스 3이 이벤트를 선택합니다. Partners도 일시적으로 추가된 후 [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem) 으로 제외됩니다.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // 기본 데이터를 채널별 매출로 교체합니다.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // Online을 0 기반 인덱스로, Events를 데이터 포인트 객체로 선택합니다.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // Partners를 선택에서 제외하지만 소스 데이터를 삭제하지는 않습니다.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

온라인(35)과 이벤트(10)는 보조 플롯에서 별개의 슬라이스로 표시됩니다. 기본 플롯에서는 이들이 합쳐져 값 45인 하나의 슬라이스로 나타나며, 소매(40) 및 파트너스(15)와 함께 표시됩니다. 커스텀 선택에서 파트너스를 제거하면 기본 플롯에 그대로 남으며, 차트 소스 데이터에서 카테고리 자체나 해당 값을 제거하지는 않습니다.

다음 이미지는 PowerPoint에서 저장된 프레젠테이션을 보여줍니다:

![보조 플롯에 온라인과 이벤트가 표시되고 기본 플롯에 이들의 합계 45가 표시된 Pie of Pie 차트](pie_of_pie_custom.png)

## **자동 파이 차트 조각 색상 설정**

Aspose.Slides for PHP via Java는 파이 차트 슬라이스마다 자동으로 다른 색상을 지정할 수 있습니다. 다음 예제는 중앙에 제목이 있는 파이 차트를 만들고 기본 데이터를 3개의 분기 카테고리와 해당 값으로 교체합니다. [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) 메서드는 레이블에 값 20, 50, 30을 표시하고, [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) 은 각 슬라이스에 고유한 색상을 적용합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // 차트 제목을 가운데에 추가합니다.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // 첫 번째 워크시트를 사용하여 기본 데이터를 교체합니다.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // 값을 표시하고 슬라이스에 서로 다른 색상을 할당합니다.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Pie of Pie 및 Bar of Pie 변형이 지원되나요?**

예, 라이브러리는 [보조 플롯을 지원](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)하며, 여기에는 Pie of Pie 및 Bar of Pie 유형이 포함됩니다.

**차트만 이미지(PNG 등)로 내보낼 수 있나요?**

예, 전체 프레젠테이션을 내보내지 않고 차트 자체를 [이미지로 내보낼 수 있습니다](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (예: PNG).