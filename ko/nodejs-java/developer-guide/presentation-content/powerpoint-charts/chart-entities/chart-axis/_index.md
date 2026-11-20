---
title: JavaScript를 사용하여 프레젠테이션에서 차트 축을 사용자 정의
linktitle: 차트 축
type: docs
url: /ko/nodejs-java/chart-axis/
keywords:
- 차트 축
- 세로 축
- 가로 축
- 축 사용자 정의
- 축 조작
- 축 관리
- 축 속성
- 최대값
- 최소값
- 축 라인
- 날짜 형식
- 축 제목
- 축 위치
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Java를 통해 Aspose.Slides for Node.js와 JavaScript를 사용하여 보고서 및 시각화를 위한 PowerPoint 프레젠테이션의 차트 축을 맞춤 설정하는 방법을 알아보세요."
---
## **개요**

이 문서에서는 Java를 통해 Aspose.Slides for Node.js를 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행 및 열 전환, 축 표시 여부, 범주 레이블 및 눈금 간격, 날짜 범주 및 형식 지정, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트의 세로 축에서 최대값 가져오기**

기본 데이터가 포함된 영역 차트를 추가하려면 [프레젠테이션](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)을 생성합니다. 계산된 축 값을 읽기 전에 차트 레이아웃을 최신 상태로 유지하기 위해 [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/)을 호출합니다.

축 제한을 얻으려면 [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) 및 [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/)을 읽고, 눈금 간격을 얻으려면 [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) 및 [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/)을 사용합니다. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) 및 [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/)은 날짜 축과 관련된 시간 단위 스케일을 제공합니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **축 간 데이터 교환**

[switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/)을 사용하여 차트 데이터에서 시리즈와 범주의 역할을 교환합니다. 이전의 각 범주는 시리즈가 되고, 이전의 각 시리즈는 범주가 됩니다. 이는 데이터 그룹화 방식을 변경하지만 가로 축과 세로 축을 교환하지는 않습니다. 예제에서는 [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/)을 사용해 기본 데이터를 `Sheet1!A1:D5`(헤더 행 및 범주 열 포함)에 바인딩한 후 행과 열을 전환합니다. 네 개의 시리즈와 세 개의 범주가 있는 차트를 저장합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **축의 플롯 순서 반전**

[setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/)을 사용하여 범주 축 또는 값 축의 플롯 순서를 반전합니다. 예를 들어, 가로 막대 차트에서 프로젝트 단계가 워크시트와 동일한 순서인 위에서 아래로 표시될 수 있습니다: 계획, 개발, 테스트. 축을 반전하면 플롯 방향이 바뀌지만 워크북 데이터가 정렬되거나 재배열되지는 않습니다. 반면에 [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/)은 시리즈와 범주의 역할을 교환합니다.

다음 예제는 세 단계와 하나의 시리즈가 있는 가로 막대 차트를 생성합니다. 세 개의 슬라이드가 저장됩니다: 정상 순서, 역순 범주, 역순 값. 각 복사본은 동일한 데이터 세트를 사용하며, 각 복사본에서 하나의 축만 반전됩니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // 슬라이드 2: 첫 번째 범주를 위에 표시합니다.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // 가로 값 축을 아래에 유지합니다.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // 슬라이드 3: 가로 숫자 눈금만 역전합니다.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

축을 반전하면 수직 축을 플롯의 반대쪽으로 이동시킬 수도 있습니다. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/)은 다른 축이 구성 중인 축과 교차하는 위치를 제어합니다. 슬라이드 2에서는 역순 범주 축에 `aspose.slides.CrossesType.Maximum`을 사용하면 가로 값 축이 아래쪽에 유지됩니다. 특정 교차 지점을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/)을 사용하십시오. 방향을 변경할 때 교차 설정을 확인하십시오. 특히 차트에 사용자 지정 교차 지점이 있는 경우에 중요합니다. `setPlotOrderReversed`를 `false`로 호출하면 정상 플롯 방향으로 복원됩니다; 교차 설정은 별도로 유지됩니다.

| 정상 순서 (슬라이드 1) | 범주 역순 (슬라이드 2) | 값 역순 (슬라이드 3) |
| --- | --- | --- |
| ![정상 범주 및 값 축 순서가 적용된 가로 막대 차트](axis-order-normal.png) | ![위에서 아래로 범주가 표시되는 가로 막대 차트](axis-order-categories-reversed.png) | ![값 축이 역순이며 오른쪽에 0이 있는 가로 막대 차트](axis-order-values-reversed.png) |
| 범주는 아래에서 위로 진행되고, 값은 왼쪽에서 오른쪽으로 증가합니다. | 계획, 개발, 테스트가 위에서 아래로 진행됩니다. 값과 워크북 행 순서는 변경되지 않습니다. | 범주는 정상 순서를 유지하고, 값은 오른쪽에서 왼쪽으로 증가합니다. 범주 축은 오른쪽 0에서 교차합니다. |

## **선형 차트에서 세로 축 비활성화**

세로 축에 `false`를 전달하여 [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/)를 호출하면 축이 숨겨집니다. 예제에서는 기본 데이터가 포함된 선형 차트를 생성하고 세로 축을 숨긴 상태로 저장합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **선형 차트에서 가로 축 비활성화**

가로 축에 `false`를 전달하여 [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/)를 호출하면 축이 숨겨집니다. 예제에서는 기본 데이터가 포함된 선형 차트를 생성하고 가로 축을 숨긴 상태로 저장합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **차트 눈금선 표시 또는 숨기기**

축이 표시하는 눈금선을 확인하려면 [getShowMajorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowmajorgridlines/) 및 [getShowMinorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowminorgridlines/)을 호출합니다. 소규모 눈금선을 표시하려면 [getMinorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getminorgridlinesformat/)을 사용하고 선 채우기를 실선의 눈에 보이는 색으로 설정합니다. 숨기려면 채우기를 [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/)으로 설정합니다. 주요 눈금선에 대해서도 동일한 방식으로 [getMajorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getmajorgridlinesformat/)을 사용해 선 채우기를 변경할 수 있습니다. 채우기를 변경해도 축 표시와 눈금은 유지됩니다.

이 군집 세로 막대 차트의 세로 축은 처음에 주요 눈금선만 표시합니다. 예제에서는 소규모 눈금선을 어두운 주황색으로 표시한 다음 다시 숨기고 프레젠테이션을 저장합니다. 각 단계에서 눈금선 표시 상태를 출력합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 30, 660, 230);
    var axis = chart.getAxes().getVerticalAxis();
    console.log("Initial: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    var minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    var darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    minorFill.getSolidFillColor().setColor(darkOrange);
    console.log("Enabled: minor=%s", axis.getShowMinorGridLines());

    minorFill.setFillType(java.newByte(aspose.slides.FillType.NoFill));
    console.log("Hidden: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 소규모 격자선 활성화 | 소규모 격자선 숨김 |
| --- | --- |
| ![세로 축의 주요 눈금선 사이에 주황색 소규모 격자선이 표시된 모습](minor-gridlines-enabled.png) | ![주요 눈금선만 표시된 동일한 막대 차트](minor-gridlines-hidden.png) |

## **범주 축 변경**

[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/)을 사용하여 날짜 축 또는 텍스트 범주 축을 선택합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 있는 `ExistingChart.pptx`를 필요로 하며, 범주 셀에 숫자형 Excel 날짜 값이 들어 있습니다. 가로 축을 날짜 축으로 변경합니다. [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/)을 `false`로 호출하고, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/)을 `1`로, [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/)을 `TimeUnitType.Months`로 설정하면 주요 눈금이 한 달 간격으로 표시됩니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **데이터에서 범주 축 유형 자동 결정**

범주를 채운 후 [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistypeautomatically/)을 호출하고, [getCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getcategoryaxistype/)을 읽어 선택된 유형을 확인합니다. 동일한 차트에 텍스트 레이블 또는 숫자형 날짜 값이 들어올 수 있을 때 유용합니다. 이 메서드는 호출 시 유형을 결정하며, 이후 데이터 변경을 다시 평가하는 지속 모드를 제공하지 않습니다. 범주를 교체한 후 다시 호출하십시오.

다음 예제는 텍스트 범주가 있는 차트를 만들고 선택된 유형이 `CategoryAxisType.Text`일 때 `true`를 출력합니다. 그런 다음 범주 셀 값을 날짜로 교체하고 메서드를 다시 호출하여 선택된 유형이 `CategoryAxisType.Date`일 때 `true`를 출력합니다. 날짜는 숫자형 OLE Automation 값으로 저장되며, 1899년 12월 30일 이후 일수로 계산됩니다(날짜 문자열이 아님). JavaScript 계산은 UTC 타임스탬프를 사용하고 차이를 하루당 86,400,000밀리초로 나눕니다; 월 인덱스는 0부터 시작합니다. 각 날짜 값을 double로 Java에 전달하려면 `java.newDouble`을 사용하십시오. [setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/)은 이러한 값이 표시되는 방식을 제어하지만 텍스트를 숫자 날짜로 변환하지는 않습니다. 범주 셀에 대한 자세한 내용은 [Chart Workbook](/slides/ko/nodejs-java/chart-workbook/)를 참조하십시오.

입력이 텍스트 범주 또는 숫자 날짜를 포함하는 것이 알려진 경우 자동 판정을 사용하십시오. 일반 숫자 레이블, 혼합 범주 또는 빈 데이터의 경우 의도한 의미에 맞게 [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/)을 명시적으로 호출하십시오. 숫자값만으로는 범주가 날짜임을 판단할 수 없습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var seriesName = workbook.getCell(0, 0, 1, "Sales");
    var series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    var labels = ["First", "Second", "Third"];

    for (var i = 0; i < labels.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Text); // true

    var baseDate = Date.UTC(1899, 11, 30);
    var dates = [Date.UTC(2026, 0, 1), Date.UTC(2026, 0, 2), Date.UTC(2026, 1, 1)];

    for (var i = 0; i < dates.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0);
        var dateValue = java.newDouble((dates[i] - baseDate) / 86400000);
        categoryCell.setValue(dateValue);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Date); // true

    presentation.save("AutomaticCategoryAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **범주 축 레이블 간격 제어**

차트에 범주가 많이 있을 때 범주나 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄일 수 있습니다. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/)을 `false`로 설정한 뒤, 원하는 범주 간격을 [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/)에 전달합니다. 정상 순서의 텍스트 범주의 경우 첫 번째 범주부터 카운트됩니다:

| 간격 | 예제에 표시된 레이블 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

`3` 간격은 3번째 레이블마다 표시하며, 표시된 레이블 사이에 두 개의 레이블이 숨겨집니다. 해당 열은 제거되지 않습니다. 자동 간격은 사용 가능한 공간을 기준으로 선택되며, 반드시 모든 레이블을 표시하지는 않습니다.

눈금선은 별도로 제어합니다. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/)을 `false`로 설정하고 [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/)으로 간격을 지정하십시오. 예를 들어 `1`은 레이블이 3번째 범주마다 표시되더라도 모든 범주 간격에 눈금이 유지되도록 합니다. 눈에 보이는 스타일을 지정하려면 [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/)을 사용하십시오. 자동 간격 설정자를 `true`로 다시 호출하면 차트가 다시 자동 간격을 선택합니다.

다음 자체 포함 예제는 24개의 범주와 하나의 시리즈를 만든 뒤 `CategoryAxisIntervals.pptx`에 세 개의 슬라이드를 저장합니다: 자동 간격, 레이블 간격 수동 지정(눈금선 독립), 자동 간격 복원. 두 복사본은 원본 차트 데이터를 유지합니다. 입력 프레젠테이션은 필요하지 않습니다. 가로 레이블 텍스트가 밀도를 쉽게 확인할 수 있게 합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // 슬라이드 2: 모든 세 번째 레이블을 표시하지만, 각 범주마다 눈금 표시를 유지합니다.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 슬라이드 3: 차트가 두 간격을 다시 선택하도록 합니다.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째 범주 레이블마다 표시되며 두 줄로 감싸집니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![모든 24열이 보이는 자동 범주 레이블 간격](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블이 한 줄에 표시되고 눈금은 모든 범주 간격에 유지됩니다. 레이블이 없는 24개의 열도 동일한 값으로 계속 보입니다. 슬라이드 3은 위의 자동 표시를 복원합니다.

![모든 24열이 보이는 세 번째 레이블 수동 간격](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 범주 축(예: 열, 선, 영역 또는 막대 차트의 범주 축)에서는 이 범주-카운트 간격을 사용하십시오. 열 차트에서는 가로 축이며, 가로 막대 차트에서는 범주 축이 세로이므로 [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/)가 반환하는 축에 적용합니다. 눈금 간격은 시리즈 축이 있는 차트에서도 적용됩니다.

값 축에 숫자 스케일을 설정하려면 범주 레이블 간격을 사용하지 마십시오. 값 축에서 [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/)은 값 차이를 지정합니다. 예를 들어 `10`의 주요 단위는 축이 0부터 시작할 때 0, 10, 20…과 같이 눈금을 표시합니다. `3`의 범주 레이블 간격은 데이터 값과 무관하게 범주 위치를 3칸씩 건너뛰어 셉니다. 산점도 및 버블 차트는 텍스트 범주 축이 아니라 값 축을 사용합니다. 날짜 축의 경우 [범주 축 변경](#change-a-category-axis)에서 설명한 시간 기반 주요 단위와 스케일을 사용하십시오.

## **범주 축 값의 날짜 형식 설정**

예제에서는 기본 차트 데이터를 4개의 연간 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장되며, 1899년 12월 30일 이후 일수로 계산됩니다. JavaScript 계산은 UTC 타임스탬프를 사용하고 차이를 하루당 86,400,000밀리초로 나눕니다. [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/)을 `CategoryAxisType.Date`와 함께 사용하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/)을 `false`로 설정한 뒤, [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/)에 `yyyy`를 전달하면 셀 서식과 무관하게 범주 레이블에 4자리 연도가 표시됩니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **차트 축 제목 회전 각도 설정**

세로 축에 대해 [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/)을 `true`로 호출하고 제목 텍스트를 제공한 뒤, [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/)을 사용해 제목을 회전합니다. 각도는 도 단위이며, 이 예제에서는 값 축 제목을 90도 회전한 열 차트를 저장합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **범주 축 또는 값 축에 대한 축 위치 설정**

[setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/)을 사용해 값 축이 범주 축과 교차하는 위치를 범주 간 또는 범주 눈금에 지정할 수 있습니다. 이 설정은 범주 축에 적용됩니다. 예제에서는 열 차트의 가로 범주 축에 `true`를 설정하고 결과를 저장합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **차트 값 축에 표시 단위 설정**

[setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/)을 사용해 값 축 라벨을 데이터 변경 없이 스케일링합니다. [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/)을 `Millions`로 설정하면 60,000,000값이 60으로 표시됩니다. 예제에서는 열 차트를 만들고 세로 축에 백만 표시 단위를 적용합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **로그 스케일 값 축 구성**

양의 값이 여러 자릿수에 걸쳐 변동할 때 로그 값 축이 유용합니다. 예를 들어, 서비스가 5기간에 걸쳐 10, 100, 1,000, 10,000, 100,000 요청을 받을 수 있습니다. 선형 스케일에서는 작은 값이 0 근처에 몰려 보입니다. 로그 스케일은 상대 성장률을 비교하기 쉽게 만들어 주며, 같은 거리마다 같은 비율을 나타냅니다.

값 축에 `true`를 전달해 [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/)을 호출하고, [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/)으로 기준을 선택합니다. 이는 기존 값의 표시 방식을 변경하지만 데이터 자체를 바꾸거나 로그 추세선을 추가하지는 않습니다. 추세선은 데이터에 맞춰 만든 별도 기능입니다.

### **값 축 및 기준 선택**

선형 차트 또는 열 차트의 경우 값 축은 [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/)가 반환합니다. 가로 막대 차트에서는 [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/)가 반환합니다. 산점도와 버블 차트는 두 개의 값 축을 가지므로 X값은 가로 축, Y값은 세로 축, 혹은 두 축 모두에 적용합니다. 범주 축에는 로그 스케일을 적용하지 마십시오.

기본 로그 기준은 `10`입니다. PPTX 차트에서는 `2`부터 `1000`까지(포함) 범위의 기준을 사용할 수 있으며, `2.5`와 같은 소수점 기준도 지원됩니다. 기준 `10`을 사용하면 10, 100, 1,000, 10,000과 같은 연속적인 거듭 제곱값이 동일하게 간격을 둡니다.

### **선형 대비 로그 스케일 비교**

다음 자체 포함 예제는 첫 번째 슬라이드에 5개의 요청 수를 포함한 선형 차트를 만들고, 해당 슬라이드를 복제한 뒤 두 번째 슬라이드에 기준 10 로그 값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // 첫 번째 슬라이드는 선형으로 유지하고 복사본의 값 축 스케일만 변경합니다.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**선형 스케일 (슬라이드 1):** 같은 수직 거리마다 같은 요청 수 차이를 나타냅니다. 가장 큰 값이 차트를 압도해 작은 값들을 구별하기 어렵습니다.

![선형 값 축에서 다섯 개의 요청 수를 보여주는 파워포인트 선형 차트](value-axis-linear.png)

**로그 스케일 (슬라이드 2):** 같은 수직 거리마다 같은 비율을 나타냅니다. 각 기간의 요청 수가 이전보다 10배씩 증가하므로 기준 10 스케일에서 점이 직선 형태로 상승합니다. 축 레이블은 여전히 원본 요청 수를 표시합니다.

![기준 10 로그 값 축에서 동일한 다섯 개 요청 수를 보여주는 파워포인트 차트](value-axis-logarithmic.png)

### **0 및 음수값 처리**

로그 스케일은 양수 값만 표시할 수 있습니다. 활성화하기 전에 데이터를 확인하십시오. 0이나 음수값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 해당 값들을 제외하는 것이 분석에 적절하다면 그 이유를 설명해야 합니다. 작은 양수값으로 조용히 대체하면 데이터 의미가 변경됩니다. 로그 축에 대해 수동으로 설정한 최소값이나 최대값도 양수이어야 합니다.

## **FAQ**

**축이 다른 축을 교차하는 값을 어떻게 설정하나요?**

[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/)을 사용해 교차 동작을 선택하십시오. 숫자형 교차 값을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/)을 사용합니다. 이러한 설정을 통해 축 교차점을 적절한 기준선으로 이동할 수 있습니다.

**눈금 레이블을 축에 대해 어떻게 위치시키나요?**

[setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/)을 사용하고 [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) 중 하나를 지정합니다: `Low`, `High`, `NextTo` 또는 `None`. 눈금 자체를 제어하려면 [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) 또는 [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/)을 사용합니다; 이는 레이블 위치와 별개입니다.