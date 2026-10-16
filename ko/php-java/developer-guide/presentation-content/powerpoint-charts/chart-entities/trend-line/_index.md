---
title: PHP에서 프레젠테이션 차트에 추세선 추가
linktitle: 추세선
type: docs
url: /ko/php-java/trend-line/
keywords:
- 차트
- 추세선
- 지수 추세선
- 선형 추세선
- 로그 추세선
- 이동 평균 추세선
- 다항식 추세선
- 멱 추세선
- 사용자 정의 추세선
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides로 PowerPoint 차트에 추세선을 빠르게 추가하고 맞춤화하여 청중을 사로잡는 실용적인 가이드."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션 차트에 추세선을 추가하는 방법을 설명합니다. 차트를 만들고, 차트 시리즈에 추세선을 추가하고, 지수, 선형, 로그, 이동 평균, 다항식 및 멱 등 여러 추세선 유형을 사용하는 방법을 보여줍니다. 또한 선 모양을 삽입하여 차트에 사용자 정의 선을 추가하는 방법을 설명하고, 앞뒤 추세선 투영 값 및 PDF 또는 SVG로 내보내거나 차트를 이미지로 렌더링할 때 추세선이 유지되는지에 대한 간단한 FAQ를 포함합니다.

## **추세선 추가**

차트 시리즈에 추세선을 추가하려면 [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/)을 사용하고, [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/)으로 유형을 선택합니다. 예제에서는 기본 데이터로 클러스터형 열 차트를 만든 다음 각 세 시리즈에 두 개의 추세선을 추가합니다.

지수 추세선은 [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) 및 [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/)을 통해 방정식과 R 제곱 값을 숨기며, 선형 추세선은 빨간색입니다. 로그 추세선은 사용자 정의 레이블을 위해 [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/)을 사용합니다. 이동 평균은 세 데이터 포인트의 [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/)와 사용자 정의 [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/)를 사용합니다.

다항식 추세선은 차수가 3이며, [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/)을 통해 설정하고, [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/)으로 한 카테고리 앞으로 확장합니다. 멱 추세선은 [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/)으로 한 카테고리 뒤로 확장합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **추세선 절편 설정**

[setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/)를 사용하여 X = 0에서 추세선의 Y 값을 고정합니다. 이 설정은 선형, 지수 및 다항식 추세선에서 지원됩니다.

예를 들어, 생산 비용 모델은 비0 생산량 측정값이 다른 기준선을 제시하더라도, 알려진 고정 비용 100으로 시작해야 할 수도 있습니다. 선형 추세선의 경우, 절편을 고정하면 방정식 `y = ax + b`의 `b = 100`으로 제한되고, 기울기는 해당 제한 하에서 데이터에 맞춰 계산됩니다. 이는 이미 맞춰진 선을 단순히 이동시키는 것이 아닙니다. 축 교차 설정은 차트 축이 만나는 위치를 제어하며, 맞춰진 추세선의 계수를 제어하지 않습니다.

다음 예제는 생산량 1~4와 비용 170, 200, 230, 260을 사용하여 산점도(XY) 차트를 생성합니다. 차트를 기본 자동 절편으로 저장한 후 절편을 100으로 설정하고 두 번째 PPTX를 저장합니다. 두 파일은 절편 설정만 다릅니다. 추세선은 방정식을 표시하고 X = 0까지 뒤로 확장됩니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

자동 계산을 사용하면 이러한 데이터에서 `y = 30x + 140`이 생성됩니다. 절편을 100으로 설정하면 대략 `y = 43.33x + 100`이 됩니다: 0에서의 적합 값이 알려진 기준선과 일치하지만, 선이 이제 모든 데이터 포인트를 통과하지는 않습니다.

| 자동 절편 | 절편 100 고정 |
| --- | --- |
| ![자동으로 계산된 절편 140을 가진 선형 추세선](intercept-automatic.png) | ![절편 100으로 고정된 선형 추세선](intercept-fixed.png) |

두 이미지 모두 동일한 데이터와 축 눈금을 사용합니다. 추세선은 절편을 보여주기 위해 X = 0까지 뒤로 확장됩니다.

기본적으로, [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/)은 `NaN`을 반환하는데, 이는 0이 아니라 지정되지 않은 절편을 의미합니다. 절편은 데이터에서 자동으로 계산됩니다.

## **사용자 정의 선 추가**

사용자 정의 선은 시리즈 데이터에서 계산된 추세선이 아니라 차트 위에 그려지는 도형입니다. 이 예제에서는 [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/)을 사용하여 차트 위 슬라이드에 수평선을 추가합니다. 선의 위치는 포인트 단위의 슬라이드 좌표로 지정되므로 차트의 왼쪽 가장자리를 시작점으로 하여 차트의 절반 높이 지점에 배치됩니다. 폭은 차트의 폭과 동일합니다. [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/)은 선에 단색 빨간색을 적용합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**추세선의 'forward'와 'backward'는 무엇을 의미합니까?**

이는 추세선을 앞 혹은 뒤로 투영한 길이이며, 산점도(XY) 차트의 경우 축 단위로, 비산점도 차트의 경우 카테고리 수로 표시됩니다. 비음수 값만 허용됩니다.

**프레젠테이션을 PDF 또는 SVG로 내보내거나 슬라이드를 이미지로 렌더링할 때 추세선이 유지됩니까?**

예. Aspose.Slides는 프레젠테이션을 [PDF](/slides/ko/php-java/convert-powerpoint-to-pdf/) 또는 [SVG](/slides/ko/php-java/render-a-slide-as-an-svg-image/)로 변환하고 차트를 이미지로 렌더링합니다; 차트의 일부인 추세선은 이러한 작업 중에 유지됩니다. 또한 차트 자체의 이미지를 [차트 이미지 내보내기](/slides/ko/php-java/create-shape-thumbnails/)할 수 있는 메서드도 제공됩니다.