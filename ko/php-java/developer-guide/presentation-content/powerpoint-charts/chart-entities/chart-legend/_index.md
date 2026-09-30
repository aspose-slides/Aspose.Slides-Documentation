---
title: PHP를 사용한 프레젠테이션에서 차트 범례 맞춤 설정
linktitle: 차트 범례
type: docs
url: /ko/php-java/chart-legend/
keywords:
- 차트 범례
- 범례 위치
- 글꼴 크기
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 차트 범례를 맞춤 설정하고, 맞춤형 범례 서식으로 PowerPoint 프레젠테이션을 최적화합니다."
---
## **개요**

Aspose.Slides for PHP via Java은 PowerPoint 프레젠테이션에서 차트 범례를 사용자 지정할 수 있는 옵션을 제공합니다. 이 문서에서는 범례의 위치와 크기를 지정하고, 전체 범례의 글꼴 크기를 설정하며, 개별 범례 항목을 형식화하고, 선택한 항목을 숨기거나 복원하는 방법을 보여줍니다.

FAQ에서는 범례를 위한 공간을 예약하고, 다중 행 레이블을 표시하며, 프레젠테이션 테마에서 서식을 상속받는 등 관련 동작을 다룹니다.

## **범례 위치 지정**

범례의 [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/) 및 [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) 메서드를 사용하여 차트 크기의 비율로 위치와 크기를 지정합니다.

이 예제는 프레젠테이션을 만들고 첫 번째 슬라이드에 기본 데이터가 포함된 클러스터형 열 차트를 추가합니다. 원하는 범례 오프셋과 크기를 차트의 너비와 높이로 나누어 상대 값으로 변환합니다: 범례는 차트 왼쪽 위 모서리에서 50포인트 떨어져 있으며 100 × 100포인트 크기로 지정됩니다. 예제는 java_values를 사용하여 PHP/Java Bridge가 반환한 차트 크기를 PHP 숫자로 변환한 후 나눕니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // 차트에 대한 범례의 위치와 크기를 상대적으로 지정합니다.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **범례의 글꼴 크기 설정**

범례의 [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/)을 사용하여 텍스트 서식에 접근하고, [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight)으로 글꼴 크기를 포인트 단위로 설정합니다.

이 예제는 기본 데이터가 있는 차트를 만들고 범례 텍스트를 20포인트로 설정합니다. 또한 수직 축에 대한 자동 경계를 비활성화하고 범위를 -5부터 10까지 지정합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **개별 범례 항목의 글꼴 크기 설정**

범례의 [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) 메서드가 반환하는 컬렉션을 사용하여 특정 항목의 서식에 접근합니다. 항목 인덱스는 0부터 시작하므로 인덱스 `1`은 두 번째 항목을 의미합니다.

이 예제는 기본 데이터에 두 개 이상의 시리즈가 포함된 클러스터형 열 차트를 생성합니다. 두 번째 범례 항목을 굵게, 이탤릭체, 20포인트 파란색 텍스트로 형식화합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **개별 범례 항목 숨기기**

보조 시리즈를 범례에서 제외하면서 데이터는 표시하려면 [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/)를 `true`로 설정하고 [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/)를 통해 호출합니다. 이렇게 하면 선택된 범례 항목만 숨겨지고 시리즈나 데이터 포인트는 제거되지 않습니다. 반대로 [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/)를 `false`로 호출하면 전체 범례가 숨겨집니다.

아래 예제는 기본 데이터를 사용하여 여러 시리즈가 있는 클러스터형 열 차트를 만들고, 두 번째 시리즈의 범례 항목(인덱스 `1`)을 숨긴 뒤 프레젠테이션을 저장합니다. 그런 다음 [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/)를 `false`로 호출해 항목을 복원하고 두 번째 사본을 저장합니다. 두 파일 모두에서 열은 계속 표시됩니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // 차트 데이터를 변경하지 않고 동일한 항목을 복원합니다.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

아래 비교는 모든 항목이 표시된 차트와 두 번째 항목이 숨겨진 차트를 보여줍니다. 두 번째 시리즈의 열은 변경되지 않은 채로 남아 있습니다.

![모든 범례 항목이 표시된 차트와 시리즈 2가 범례에서 숨겨진 차트의 비교; 모든 열은 계속 표시됩니다.](hide-legend-entry.png)

열, 막대 및 선 차트에서는 범례 항목이 시리즈를 식별합니다. 파이 차트에서는 개별 데이터 포인트(조각)를 식별하므로 선택된 조각에 대해 [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/)를 사용합니다. API는 `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, `BarOfPie` 차트 유형에 대해 이 데이터 포인트 메서드를 문서화합니다. 도넛 차트에는 적용되지 않으므로 가정하지 마십시오.

## **FAQ**

**Can I make the chart allocate space for the legend instead of overlaying it?**

Yes. Call [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) with `false` to reserve space for the legend instead of allowing it to overlap the plot area.

**Can I make multiline legend labels?**

Yes. Long labels can wrap when the available width is insufficient. You can also use newline characters in series names to request line breaks.

**How do I make the legend follow the presentation theme's color scheme?**

Leave the legend's colors, fills, and fonts unset so that it can inherit theme formatting. Explicit formatting overrides the corresponding theme settings.