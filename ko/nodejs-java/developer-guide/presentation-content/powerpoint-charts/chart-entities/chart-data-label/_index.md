---
title: JavaScript를 사용하여 프레젠테이션의 차트 데이터 레이블 관리
linktitle: 데이터 레이블
type: docs
url: /ko/nodejs-java/chart-data-label/
keywords:
- 차트
- 데이터 레이블
- 데이터 정밀도
- 백분율
- 레이블 거리
- 레이블 위치
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용하여 PowerPoint 프레젠테이션에 차트 데이터 레이블을 추가하고 서식 지정하는 방법을 배우고, 보다 매력적인 슬라이드를 만들 수 있습니다."
---
## **소개**

데이터 레이블은 차트 시리즈와 개별 데이터 포인트에 대한 정보를 표시하여 독자가 값을 식별하고 차트를 이해하도록 돕습니다. 이 문서에서는 값 서식 지정, 백분율 표시, 레이블 텍스트 읽기, 축 최대값 초과 레이블 제어, 범주 축 레이블 간격 조정 및 파이 차트 레이블 위치 지정 방법을 설명합니다.

## **차트 데이터 레이블에서 데이터 정밀도 설정**

시리즈 값을 서식 지정하려면 [setNumberFormatOfValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/)를 사용합니다. 이 예제는 기본 데이터로 라인 차트를 만들고, 데이터 테이블을 표시하며 첫 번째 시리즈에 값 레이블을 활성화합니다. `#,##0.00` 형식은 천 단위 구분 기호와 소수점 둘째 자리까지 표시하지만 기본 값을 변경하지는 않습니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    const series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **레이블로 백분율 표시**

스택형 컬럼 차트에서 각 값을 해당 범주 총계의 백분율로 계산하고, 텍스트를 [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/)이(가) 반환하는 텍스트 프레임에 할당합니다. 이 예제는 기본 차트 데이터를 사용하고 8포인트 글꼴로 소수점 둘째 자리까지 백분율을 표시합니다. 총합이 0인 범주는 나눗셈 오류를 방지하기 위해 건너뜁니다. 차트 데이터가 변경되면 사용자 정의 레이블 텍스트를 다시 계산해야 합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);

    const categoryTotals = new Array(chart.getChartData().getCategories().size()).fill(0);
    for (let k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
            const series = chart.getChartData().getSeries().get_Item(i);
            const pointValue = series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += Number(pointValue);
        }
    }

    for (let x = 0; x < chart.getChartData().getSeries().size(); x++) {
        const series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            const pointValue = series.getDataPoints().get_Item(j).getValue().getData();
            const dataPointPercent = (Number(pointValue) / categoryTotals[j]) * 100;

            const portion = new aspose.slides.Portion();
            portion.setText(dataPointPercent.toFixed(2) + " %");
            portion.getPortionFormat().setFontHeight(8);

            label.getTextFrameForOverriding().setText("");
            const paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **차트 데이터 레이블에 백분율 기호 설정**

값이 분수 형태로 저장된 경우, 백분율을 표시하려면 [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/)을 사용합니다. 레이블 형식을 원본 셀과 독립적으로 적용하려면 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/)에 `false`를 전달합니다.

이 예제는 네 가지 범주에 걸쳐 빨강 및 파랑 시리즈가 포함된 100% 스택형 컬럼 차트를 생성합니다. 각 값 쌍은 합계가 1이 됩니다. 레이블 형식 `0.0%`는 0.30을 30.0%로 표시하고, 세로 축은 소수점 둘째 자리까지 표시합니다. 두 시리즈 모두 흰색 10포인트 레이블 텍스트를 사용합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    for (let i = 0; i < 4; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    const seriesNames = ["Reds", "Blues"];
    const white = java.getStaticFieldValue("java.awt.Color", "WHITE");
    const seriesColors = [java.getStaticFieldValue("java.awt.Color", "RED"), java.getStaticFieldValue("java.awt.Color", "BLUE")];
    const values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]];

    for (let i = 0; i < seriesNames.length; i++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (let j = 0; j < 4; j++) {
            const valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        const labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(white);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **데이터 레이블의 실제 텍스트 읽기**

[getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/)를 사용하면 데이터 레이블 설정에 의해 생성된 텍스트를 가져올 수 있습니다. 이는 보고서를 위한 레이블 추출, 프레젠테이션 내용 검색, 또는 생성된 차트 검증에 유용합니다. 아래 예제에서 기본 [데이터 레이블 형식](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/)은 각 범주 이름, 시리즈 이름 및 값을 결합합니다. 한 데이터 포인트는 값을 백분율로 서식 지정하고, 다른 포인트는 [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/)에서 가져온 사용자 정의 텍스트를 사용합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    const secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    const northSeriesCell = workbook.getCell(0, 0, 1, "North");
    const north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    const northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    const northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    const southSeriesCell = workbook.getCell(0, 0, 2, "South");
    const south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    const southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    const southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        const format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const point = series.getDataPoints().get_Item(j);
            const label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            console.log("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

데이터 포인트에 저장된 숫자는 `0.75`이며, 레이블에 범주 및 시리즈 이름과 함께 `75%`가 표시되더라도 값은 변하지 않습니다. 사용자 정의 텍스트는 생성된 레이블 텍스트를 대체합니다. [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/)은 두 경우 모두 결과 레이블 문자열을 반환합니다. 표시된 레이블만 추출하려는 경우 위와 같이 별도로 [isVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/isvisible/)를 확인하십시오.

## **축 최대값을 초과하는 데이터 레이블 제어**

축 범위를 수동으로 제한하면 일부 데이터 포인트가 최대값을 초과할 수 있습니다. [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/)을 사용하여 해당 데이터 레이블을 표시할지 여부를 제어합니다. 이 설정은 레이블 표시 여부만 변경하며, 축 범위나 기본 데이터 값은 변경하지 않습니다.

아래 예제는 값이 60과 120인 2D 클러스터형 컬럼 차트를 생성합니다. 수직 축에 대해 [setAutomaticMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/)에 `false`를 전달하고 [setMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmaxvalue/)으로 최대값을 100으로 설정합니다. 첫 번째 슬라이드는 최대값을 초과하는 레이블을 허용하고, 해당 슬라이드의 복사본은 이를 비활성화합니다. 두 슬라이드는 `DataLabelsOverMaximum.pptx`에 저장됩니다.

[setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/)로 값 레이블을 활성화합니다. 차트 수준 설정은 자체적으로 값 표시를 활성화하거나 개별 레이블의 비활성값 표시를 무시하지 않습니다. 이 예제는 전체 시리즈에 값을 활성화하고 [setPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setposition/)을 사용하여 각 컬럼 외부 끝에 레이블을 배치합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();

    const firstCategory = workbook.getCell(0, 1, 0, "Within range");
    const secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    const seriesName = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    const firstValue = workbook.getCell(0, 1, 1, 60);
    const secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    const secondSlide = presentation.getSlides().addClone(slide);
    const secondChart = secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

다음 이미지들은 Microsoft PowerPoint에서 렌더링된 저장된 슬라이드를 보여줍니다. `true`인 경우 레이블 **120**이 상한선에 표시되고, `false`인 경우 숨겨집니다. 레이블 **60**은 계속 표시되며, 축 최대값은 **100**으로 유지되고 두 번째 데이터 포인트는 두 경우 모두 **120**으로 유지됩니다.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
이 예제는 값 축이 있는 2D 컬럼 차트를 사용합니다. 파이 차트 및 도넛 차트와 같이 값 축이 없는 차트는 이러한 방식으로 제한할 축 최대값이 없습니다.
{{% /alert %}}

## **축에서 레이블 거리 설정**

[setLabelOffset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlabeloffset/)을 사용하여 범주 축 레이블과 축 사이의 거리를 제어합니다. 값은 축 레이블 최대 글꼴 크기의 백분율입니다. 이 예제는 클러스터형 컬럼 차트를 만들고 수평 축 레이블 오프셋을 500으로 설정합니다. 이 설정은 개별 데이터 포인트에 연결된 레이블이 아니라 범주 축 레이블에 영향을 줍니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **레이블 위치 조정**

파이 차트에서 데이터 레이블 위치를 조정하여 간격을 개선하고 리더 라인을 위한 공간을 확보합니다.

이 예제는 첫 번째 데이터 포인트의 값을 표시하고 레이블을 조각 외부에 배치하며, [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/)와 [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/)를 사용하여 수평 및 수직 오프셋을 조정합니다. 이러한 오프셋은 각각 차트 너비와 높이에 상대적입니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    const series = chart.getChartData().getSeries();

    const label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(java.newFloat(0.71));
    label.setY(java.newFloat(0.04));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![조정된 데이터 레이블 위치가 있는 파이 차트](pie-chart-adjusted-label.png)

## **컬럼 차트 위에 여러 행의 데이터 레이블 추가**

이 예제는 플롯 영역 위에 두 줄의 데이터 레이블을 가진 컬럼 차트를 생성합니다. Series A는 보이는 컬럼을 표시하고, Series B와 Series C는 추가 레이블을 제공합니다. 해당 컬럼들은 채우기와 외곽선을 제거하여 숨겨집니다. [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) 메서드는 세 시리즈를 동일한 범주 중심에 정렬합니다.

[ChartPlotArea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartplotarea/) 설정은 레이블 행을 위한 공간을 확보합니다. [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/)이 기본 위치를 계산한 후, [DataLabel.setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/)와 [DataLabel.setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/)는 수평 정렬을 유지하고 수직 오프셋을 적용하여 레이블을 두 줄로 배치합니다. 숫자는 시리즈 값에 연결된 데이터 레이블로 유지되며, 행 제목만 별도의 텍스트 도형으로 표시됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categories = ["North", "South", "East", "West"];
    const seriesNames = ["Series A", "Series B", "Series C"];
    const seriesValues = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]];

    for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        const categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        const seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        const series = chart.getChartData().getSeries().add(seriesCell, aspose.slides.ChartType.ClusteredColumn);

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // B와 C의 열을 숨기되, 데이터 레이블은 유지합니다.
            series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            const labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
            labelFill.getSolidFillColor().setColor(black);
            series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.InsideBase);
        }
    }

    // 세 시리즈를 모두 동일한 범주 중심에 정렬합니다.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(java.newByte(100));

    // 이 간결한 예제에서는 눈금선을 적게 사용합니다.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // 플롯 위에 두 행의 데이터 레이블을 위한 공간을 예약합니다.
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    chart.getPlotArea().setX(java.newFloat(0.15));
    chart.getPlotArea().setY(java.newFloat(0.32));
    chart.getPlotArea().setWidth(java.newFloat(0.80));
    chart.getPlotArea().setHeight(java.newFloat(0.48));
    chart.validateChartLayout();

    for (let seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const rowTop = seriesIndex == 1 ? 0.15 : 0.03;

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // 기본 수평 위치를 유지합니다. Y는 다음으로부터의 오프셋입니다.
            // 기본 레이블 위치이며, 차트 높이 비율로 표현됩니다.
            dataLabel.setX(0);
            dataLabel.setY(java.newFloat(rowTop - dataLabel.getActualY() / chart.getHeight()));
        }

        // 행 제목만 별도의 텍스트 도형입니다.
        const rowHeading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        const headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        headingFormat.getFillFormat().getSolidFillColor().setColor(black);
    }

    presentation.save("multiple-rows-of-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![플롯 영역 위에 두 줄의 데이터 레이블이 있는 컬럼 차트](multiple-rows-of-labels.png)

## **FAQ**

**밀집된 차트에서 데이터 레이블이 겹치는 것을 어떻게 방지할 수 있나요?**  
자동 레이블 배치, 리더 라인 및 글꼴 크기 축소를 결합하십시오. 필요하면 일부 필드(예: 범주)를 숨기거나 극값 또는 핵심 포인트에만 레이블을 표시하십시오.

**0, 음수 또는 빈 값에 대해서만 레이블을 비활성화하려면 어떻게 해야 하나요?**  
레이블을 활성화하기 전에 데이터 포인트를 필터링하고, 정의된 규칙에 따라 0, 음수 또는 누락된 값에 대한 표시를 끄십시오.

**PDF/이미지로 내보낼 때 레이블 스타일을 일관되게 유지하려면 어떻게 해야 하나요?**  
글꼴 패밀리와 크기를 명시적으로 설정하고, 렌더링 환경에 해당 글꼴이 존재하는지 확인하여 대체 글꼴 사용을 방지하십시오.