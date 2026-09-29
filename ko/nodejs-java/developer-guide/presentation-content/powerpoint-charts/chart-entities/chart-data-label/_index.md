---
title: JavaScript를 사용하여 프레젠테이션에서 차트 데이터 라벨 관리
linktitle: 데이터 라벨
type: docs
url: /ko/nodejs-java/chart-data-label/
keywords:
- 차트
- 데이터 라벨
- 데이터 정밀도
- 백분율
- 라벨 간격
- 라벨 위치
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용하여 PowerPoint 프레젠테이션에 차트 데이터 라벨을 추가하고 서식 지정하는 방법을 학습하여 보다 매력적인 슬라이드를 만들 수 있습니다."
---
## **소개**

데이터 라벨은 차트 시리즈와 개별 데이터 포인트에 대한 정보를 표시하여 독자가 값을 식별하고 차트를 이해하도록 도와줍니다. 이 문서에서는 값 서식 지정, 백분율 표시, 라벨 텍스트 읽기, 축 최대값을 초과하는 라벨 제어, 범주 축 라벨 간격 조정 및 원형 차트 라벨 배치 방법을 설명합니다.

## **차트 데이터 라벨에서 데이터 정밀도 설정**

시리즈 값을 서식 지정하려면 [setNumberFormatOfValues](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/)를 사용합니다. 이 예제는 기본 데이터로 라인 차트를 만들고 데이터 표를 표시하며 첫 번째 시리즈에 값 라벨을 활성화합니다. `#,##0.00` 서식은 천 단위 구분 기호와 소수점 두 자리를 표시하지만 기본 값은 변경하지 않습니다.

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

## **백분율을 라벨로 표시**

스택형 컬럼 차트의 경우 각 값을 해당 범주의 합계에 대한 백분율로 계산하고 그 텍스트를 [getTextFrameForOverriding](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/)이 반환하는 텍스트 프레임에 할당합니다. 이 예제는 기본 차트 데이터를 사용하고 8포인트 글꼴로 소수점 두 자리 백분율을 표시합니다. 합계가 0인 범주는 나누기 오류를 피하기 위해 건너뜁니다. 차트 데이터가 변경되면 사용자 정의 라벨 텍스트를 다시 계산합니다.

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

## **차트 데이터 라벨에 백분율 기호 설정**

값이 분수 형태로 저장된 경우 [setNumberFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabelformat/setnumberformat/)을 사용합니다. [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/)에 `false`를 전달하면 라벨 서식을 원본 셀과 독립적으로 적용할 수 있습니다.

이 예제는 네 개 범주에 걸쳐 빨간색 및 파란색 시리즈가 있는 100% 스택형 컬럼 차트를 생성합니다. 각 값 쌍은 합이 1이 됩니다. 라벨 서식 `0.0%`는 0.30을 30.0%로 표시하고, 수직 축은 소수점 두 자리를 사용합니다. 두 시리즈 모두 흰색 10포인트 라벨 텍스트를 사용합니다.

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

## **데이터 라벨의 실제 텍스트 읽기**

[getActualLabelText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabel/getactuallabeltext/)를 사용하여 데이터 라벨 설정으로 생성된 텍스트를 가져올 수 있습니다. 이는 보고서용 라벨을 추출하거나 프레젠테이션 내용을 검색하거나 생성된 차트를 검증할 때 유용합니다. 아래 예제에서는 기본 [데이터 라벨 서식](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabelformat/)이 각 범주 이름, 시리즈 이름 및 값을 결합합니다. 한 데이터 포인트는 값을 백분율로 서식 지정하고, 다른 포인트는 [getTextFrameForOverriding](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/)에서 가져온 사용자 정의 텍스트를 사용합니다.

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

데이터 포인트에 저장된 숫자는 `0.75` 그대로이며, 라벨에 범주 및 시리즈 이름과 함께 `75%`가 표시됩니다. 사용자 정의 텍스트는 생성된 라벨 텍스트를 대체합니다. [getActualLabelText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabel/getactuallabeltext/)은 두 경우 모두 결과 라벨 문자열을 반환합니다. 표시된 라벨만 추출하려면 위에 표시된 대로 [isVisible](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabel/isvisible/)를 별도로 확인하십시오.

## **축 최대값을 초과하는 데이터 라벨 제어**

축 범위를 수동으로 제한하면 일부 데이터 포인트가 최대값을 초과할 수 있습니다. [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/)를 사용하여 해당 라벨을 표시할지 여부를 제어합니다. 이 설정은 라벨 가시성을 변경하지만 축 범위나 기본 데이터 값은 변경하지 않습니다.

아래 예제는 값이 60과 120인 2D 클러스터드 컬럼 차트를 생성합니다. [setAutomaticMaxValue](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/)에 `false`를 전달하고 수직 축의 최대값을 [setMaxValue](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/axis/setmaxvalue/)로 100으로 설정합니다. 첫 번째 슬라이드는 최대값을 초과하는 라벨을 허용하고, 복사본 슬라이드는 이를 비활성화합니다. 두 슬라이드는 `DataLabelsOverMaximum.pptx`에 저장됩니다.

[setShowValue](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabelformat/setshowvalue/)로 값 라벨을 활성화합니다. 차트 수준 설정만으로 값 표시가 자동으로 활성화되지는 않으며 개별 라벨의 비활성값 표시를 무시하지도 않습니다. 이 예제는 전체 시리즈에 값을 활성화하고 [setPosition](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabelformat/setposition/)을 사용하여 각 컬럼 외부 끝에 라벨을 배치합니다.

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

다음 이미지는 Microsoft PowerPoint에서 렌더링된 저장된 슬라이드를 보여줍니다. `true`인 경우 라벨 **120**이 상한선에 표시되고, `false`인 경우 숨겨집니다. 라벨 **60**은 계속 표시되며, 축 최대값은 **100**에 머무르고 두 번째 데이터 포인트는 두 경우 모두 **120**으로 유지됩니다.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
이 예제는 값 축이 있는 2D 컬럼 차트를 사용합니다. 파이 차트 및 도넛 차트와 같이 값 축이 없는 차트는 이렇게 축 최대값을 제한할 수 없습니다.
{{% /alert %}}

## **축으로부터 라벨 간격 설정**

[setLabelOffset](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/axis/setlabeloffset/)를 사용하여 범주 축 라벨과 축 사이의 거리를 제어합니다. 값은 축 라벨 최대 글꼴 크기의 백분율입니다. 이 예제는 클러스터드 컬럼 차트를 만들고 수평 축 라벨 오프셋을 500으로 설정합니다. 이 설정은 개별 데이터 포인트에 부착된 라벨이 아니라 범주 축 라벨에 영향을 줍니다.

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

## **라벨 위치 조정**

파이 차트에서 데이터 라벨 위치를 조정하여 간격을 개선하고 리더 라인을 위한 공간을 확보합니다.

이 예제는 첫 번째 데이터 포인트의 값을 표시하고 라벨을 슬라이스 바깥쪽에 배치한 다음 [setX](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabel/setx/)과 [setY](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabel/sety/)를 사용해 수평 및 수직 오프셋을 조정합니다. 이러한 오프셋은 각각 차트 너비와 높이에 대한 상대값입니다.

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

![조정된 데이터 라벨 위치가 있는 파이 차트](pie-chart-adjusted-label.png)

## **FAQ**

**밀집된 차트에서 데이터 라벨이 겹치는 것을 어떻게 방지할 수 있나요?**  
자동 라벨 배치, 리더 라인, 글꼴 크기 감소를 결합하십시오. 필요에 따라 일부 필드(예: 범주)를 숨기거나 극값 또는 주요 포인트에만 라벨을 표시할 수 있습니다.

**값이 0이거나 음수이거나 비어 있는 경우에만 라벨을 비활성화하려면 어떻게 해야 하나요?**  
라벨을 활성화하기 전에 데이터 포인트를 필터링하고, 정의된 규칙에 따라 0, 음수 또는 누락된 값에 대해 표시를 끕니다.

**PDF/이미지로 내보낼 때 일관된 라벨 스타일을 보장하려면 어떻게 해야 하나요?**  
폰트 종류와 크기를 명시적으로 설정하고, 렌더링 환경에 해당 폰트가 존재하는지 확인하여 대체 폰트가 사용되지 않도록 합니다.