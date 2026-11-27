---
title: PHP에서 프레젠테이션 차트 서식 지정
linktitle: 차트 서식 지정
type: docs
weight: 60
url: /ko/php-java/chart-formatting/
keywords:
- 차트 서식 지정
- 차트 포맷팅
- 차트 엔터티
- 차트 속성
- 차트 설정
- 차트 옵션
- 글꼴 속성
- 둥근 테두리
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP를 사용한 차트 서식 지정 방법을 배우고 Java를 통해 맞춤 축, 글꼴, 숫자 형식 및 둥근 차트 테두리로 PowerPoint 프레젠테이션을 향상시키세요."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션에서 차트를 서식 지정하는 방법을 설명합니다. 축, 눈금선, 제목, 범례, 플롯 영역 및 벽 채우기와 같은 주요 차트 요소를 사용자 지정하여 차트 데이터의 외관과 가독성을 향상시키는 방법을 보여줍니다.

또한 차트 텍스트에 대한 글꼴 속성을 설정하고, 차트 데이터에 사전 정의된 숫자 형식을 적용하며, 차트 영역에 둥근 모서리를 활성화하는 방법을 보여줍니다. 이러한 예제들은 프레젠테이션에서 차트의 시각적 스타일과 데이터 표시를 모두 제어하는 방법을 보여줍니다.

For separate fills and outlines on rising and falling intervals, see the [주식 차트 예제](/slides/ko/php-java/create-chart/#create-stock-charts).

## **차트 엔터티 서식 지정**

차트 제목, 축, 눈금선, 범례 및 플롯 영역을 서식 지정하려면 [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/)을 사용합니다. 이 예제는 마커와 기본 데이터를 갖는 꺾은선형 차트를 생성한 다음, 값 축과 범주 축에 별개의 텍스트 및 선 스타일을 적용합니다. 글꼴 크기와 선 굵기는 포인트 단위로 지정되며, 범주 레이블은 45도 회전됩니다.

값 축은 원본 셀과 무관하게 [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setNumberFormat)을 사용합니다. 눈금은 -2에서 15까지이며, 주요 간격은 2, 세부 간격은 0.5입니다. 이 예제는 또한 백분율 서식을 [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setDisplayUnit)을 천 단위로 설정한 것과 결합하므로, 이러한 설정을 데이터의 의미와 규모에 맞게 조정하십시오. 범례는 [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#setOverlay)가 `false`로 호출되었기 때문에 플롯 영역 밖에 위치합니다. 백월 및 바닥 채우기는 [getBackWall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getBackWall) 및 [getFloor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getFloor)를 통해 구성되지만, 이러한 표면은 3D 차트에서만 표시됩니다.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LineDashStyle;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\TickLabelPositionType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle::DashDot);

    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");

    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);

    $chart->getAxes()->getVerticalAxis()->setMaxValue(15);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);

    $valueAxisText = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $valueAxisText->setFontBold(NullableBool::True);
    $valueAxisText->setFontHeight(16);
    $valueAxisText->setFontItalic(NullableBool::True);
    $valueAxisText->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkGreen);
    $valueAxisText->setLatinFont(new FontData("Times New Roman"));

    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valueAxisTitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valueAxisTitle->setText("Primary Axis");
    $valueAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valueAxisTitle->getPortionFormat()->setFontHeight(20);
    $valueAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valueAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 128, 0));
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);

    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $categoryAxisText = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $categoryAxisText->setFontBold(NullableBool::True);
    $categoryAxisText->setFontHeight(16);
    $categoryAxisText->setFontItalic(NullableBool::True);
    $categoryAxisText->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisText->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $categoryAxisText->setLatinFont(new FontData("Arial"));

    $chart->getAxes()->getHorizontalAxis()->setTitle(true);
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");

    $categoryAxisTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $categoryAxisTitle->setText("Sample Category");
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $categoryAxisTitle->getPortionFormat()->setFontHeight(20);
    $categoryAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $categoryAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);

    $legendText = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $legendText->setFontBold(NullableBool::True);
    $legendText->setFontHeight(16);
    $legendText->setFontItalic(NullableBool::True);
    $legendText->getFillFormat()->setFillType(FillType::Solid);
    $legendText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkRed);

    $chart->getLegend()->setOverlay(false);

    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setPresetColor(PresetColor::LightCyan);

    $presentation->save("FormattedChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **차트의 글꼴 속성 설정**

차트 텍스트에 대한 기본 글꼴 크기는 [Chart::getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getTextFormat)을 통해 설정합니다. 이 예제는 20포인트 글꼴을 사용하여 클러스터ed 열 차트를 만들고, 첫 번째 시리즈에 대해 [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue)를 사용하여 값 레이블을 활성화합니다. 자체 명시적 글꼴 설정이 있는 텍스트 요소는 차트 기본값을 재정의할 수 있습니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **차트 범례에 텍스트 프레임 서식 재사용**

범례를 슬라이드 제목에 맞추려면 첫 번째 단락에서 [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat)을 사용하여 제목의 글꼴을 설정합니다. 범례의 [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#getTextFormat)에서 반환된 서식에 대해 [copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyFrom)을 호출합니다. 이렇게 하면 텍스트 프레임 설정, 첫 번째 단락의 서식 및 해당 단락의 기본 글꼴 속성이 복사됩니다. 개별 구간이나 이후 단락에 직접 적용된 서식은 원본에 국한됩니다.

이 예제는 굵게 26포인트 Calibri 글꼴에 네이비 색상을 사용한 제목을 템플릿으로 사용합니다. 범례를 스타일링한 후, [copyTo](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyTo)를 호출하여 동일한 서식을 별도 캡션에 적용합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LegendPositionType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\StyleType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $heading = $shapes->addAutoShape(ShapeType::Rectangle, 40, 20, 640, 40, false);
    $sourceTextFrame = $heading->addTextFrame("Quarterly sales");
    $font = $sourceTextFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $font->setLatinFont(new FontData("Calibri"));
    $font->setFontHeight(26);
    $font->setFontBold(NullableBool::True);
    $font->getFillFormat()->setFillType(FillType::Solid);
    $font->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 32, 64, 96));

    $chart = $shapes->addChart(ChartType::ClusteredColumn, 40, 75, 640, 360);
    $chart->setStyle(StyleType::Style3);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->getCell(0, 0, 1)->setValue("Retail");
    $workbook->getCell(0, 0, 2)->setValue("Online");
    $workbook->getCell(0, 0, 3)->setValue("Wholesale");
    for ($quarter = 1; $quarter <= 4; $quarter++) {
        $workbook->getCell(0, $quarter, 0)->setValue("Q" . $quarter);
    }

    $chart->setLegend(true);
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $legendFormat = $chart->getLegend()->getTextFormat();
    $legendFormat->copyFrom($sourceTextFrame);

    $caption = $shapes->addAutoShape(ShapeType::Rectangle, 40, 460, 640, 40, false);
    $captionTextFrame = $caption->addTextFrame("Sales in millions of dollars");
    $legendFormat->copyTo($captionTextFrame);

    $presentation->save("legend-formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

저장된 프레젠테이션에서 범례와 캡션은 크기, 굵기 및 색상에서 제목과 일치합니다. 범례는 여전히 시리즈 이름을 표시하고, 캡션은 자체 텍스트를 유지합니다. 캡션의 일부에 이미 명시적인 글꼴 크기가 지정된 경우, 해당 크기가 복사된 단락 기본값보다 우선합니다.

| 복사 전 | 복사 후 |
| --- | --- |
| ![정규 검은색 범례 레이블과 검은색 캡션이 있는 분기별 판매 차트](legend-formatting-before.png) | ![더 큰 굵은 네이비 범례 레이블과 일치하는 캡션이 있는 동일 차트](legend-formatting.png) |

## **숫자 형식 설정**

[ChartDataCell::setPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setPresetNumberFormat)을 사용하여 차트 워크북 셀에 내장된 숫자 형식을 적용합니다. 이 예제는 기본 셀 기반 데이터를 가진 클러스터ed 열 차트를 생성하고 각 시리즈 값 셀에 형식 인덱스 10(`0.00%`)을 적용합니다. 이는 기본 숫자를 변경하지 않고 워크북에서 값이 표시되는 방식을 바꾸며, 예를 들어 0.25는 25.00%로 표시됩니다. 축 및 데이터 레이블 형식은 별도로 구성할 수 있습니다.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries();

    for ($i = 0; $i < java_values($series->size()); $i++) {
        $chartSeries = $series->get_Item($i);
        $dataPoints = $chartSeries->getDataPoints();
        for ($j = 0; $j < java_values($dataPoints->size()); $j++) {
            $dataPoint = $dataPoints->get_Item($j);
            $dataPoint->getValue()->getAsCell()->setPresetNumberFormat(10); // 0.00%
        }
    }

    $presentation->save("PresetNumberFormat_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

다음 표는 영어(미국) 로케일에 대한 대표적인 Excel 형식과 함께 내장 숫자 형식 인덱스를 나열합니다. 정확한 형식 문자열 및 표시 방식은 애플리케이션 및 로케일에 따라 달라질 수 있으며, 특히 통화와 날짜에 해당합니다. 일부 Excel 형식은 [Microsoft의 숫자 형식 구현 노트](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528)에 설명된 바와 같이 OOXML 표준의 기본값과도 다를 수 있습니다.

| 인덱스 | 형식 |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **차트 영역 둥근 테두리 설정**

[Chart::setRoundedCorners](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setRoundedCorners)를 `true`로 호출하면 차트 영역의 모서리를 둥글게 만들 수 있습니다. 이 예제는 클러스터ed 열 차트를 생성하고 [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat)를 사용하여 저장하기 전에 윤곽선에 단색 회색과 단일 선 스타일을 적용합니다.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chart->getLineFormat()->setStyle(LineStyle::Single);
    $chart->setRoundedCorners(true);

    $presentation->save("out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **기존 차트 주석 편집**

차트에는 보고서 상태를 설명하는 텍스트 주석과 같은 사용자 정의 형식이 포함될 수 있습니다. 이러한 형식은 [Chart::getUserShapes](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getUserShapes)를 통해 액세스합니다. [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes)에서 반환되는 컬렉션은 차트가 소유한 형식을 포함합니다.

차트 위에 배치된 일반 텍스트 상자는 차트의 일부처럼 보이더라도 슬라이드에 속합니다. [Slide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slide/)를 반복하면 차트와 일반 슬라이드 형식을 찾지만 차트 내부의 개별 형식은 열거되지 않습니다. 차트 제목과 데이터 레이블은 별도의 차트 요소이며, 이 컬렉션의 사용자 정의 주석이 아닙니다.

[chart-annotations.pptx](chart-annotations.pptx)를 다운로드하고 애플리케이션 작업 디렉터리에 배치합니다. 첫 번째 슬라이드에는 "Preliminary results"(예비 결과)라는 주석이 있는 차트, 차트가 소유한 선, 그리고 "Slide overlay"(슬라이드 오버레이)라는 텍스트 상자가 포함됩니다. 예제는 해당 슬라이드의 첫 번째 차트를 찾아 보고서를 게시할 준비가 되면 주석을 "Final results"(최종 결과)로 변경합니다. 빈 컬렉션을 확인하고 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 중에서 [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame)으로 반환된 null이 아닌 텍스트 프레임과 예상 텍스트를 가진 형식만 편집합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-annotations.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chartType = new JavaClass("com.aspose.slides.IChart");
    $autoShapeType = new JavaClass("com.aspose.slides.IAutoShape");
    $chart = null;
    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++) {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartType)) {
            $chart = $shape;
            break;
        }
    }

    if ($chart === null || java_values($chart->getUserShapes()->getShapes()->size()) == 0) {
        echo "No chart or chart-owned shapes found." . PHP_EOL;
        return;
    }

    $updated = false;
    $userShapes = $chart->getUserShapes()->getShapes();
    for ($i = 0; $i < java_values($userShapes->size()); $i++) {
        $shape = $userShapes->get_Item($i);
        if (java_instanceof($shape, $autoShapeType)) {
            $annotation = $shape;
            if (!java_is_null($annotation->getTextFrame()) && java_values($annotation->getTextFrame()->getText()) === "Preliminary results") {
                $annotation->getTextFrame()->setText("Final results");
                $updated = true;
                break;
            }
        }
    }

    if ($updated) {
        $presentation->save("chart-annotations-updated.pptx", SaveFormat::Pptx);
    } else {
        echo "No matching text annotation found." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

선과 슬라이드 텍스트 상자는 변경되지 않은 채로 남습니다. 다음 이미지들은 입력과 저장된 후 다시 연 결과를 보여줍니다:

| 편집 전 | 편집 후 |
| --- | --- |
| ![예비 결과를 읽는 차트 주석](chart-annotations-before.png) | ![최종 결과를 읽는 차트 주석](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
예제는 최상위 차트 소유 형식만 검사합니다. 주석이 [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) 내부에 있는 경우 해당 그룹의 [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) 컬렉션도 검사합니다. 중첩된 그룹에 대해 재귀적으로 이 작업을 반복하고 자식 형식에 동일한 텍스트 검사를 적용합니다. 그룹 자체는 컨테이너이며, 텍스트 상자로 취급하지 마십시오.
{{% /alert %}}

## **FAQ**

**컬럼/영역에 반투명 채우기를 적용하면서 테두리는 불투명하게 유지할 수 있나요?**

예. 채우기 투명도와 외곽선은 별도로 구성됩니다. 이는 복잡한 시각화에서 격자와 데이터의 가독성을 향상시키는 데 유용합니다.

**데이터 레이블이 겹칠 때 어떻게 처리할 수 있나요?**

글꼴 크기를 줄이고, 필요 없는 레이블 구성 요소(예: 카테고리)를 비활성화하고, 레이블 위치를 조정하며, 필요한 경우 선택된 포인트에만 레이블을 표시하거나, 형식을 "값 + 범례"로 전환하십시오.

**시리즈에 그라디언트 또는 패턴 채우기를 적용할 수 있나요?**

예. 시리즈는 단색, 그라디언트 및 패턴 채우기를 지원합니다. 실제로는 그라디언트를 적게 사용하고 격자 및 텍스트와의 대비를 낮추는 조합은 피하십시오.