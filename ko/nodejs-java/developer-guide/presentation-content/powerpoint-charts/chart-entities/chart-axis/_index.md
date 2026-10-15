---
title: JavaScript를 사용하여 프레젠테이션에서 차트 축 맞춤
linktitle: 차트 축
type: docs
url: /ko/nodejs-java/chart-axis/
keywords:
- 차트 축
- 수직 축
- 수평 축
- 축 맞춤
- 축 조작
- 축 관리
- 축 속성
- 최대값
- 최소값
- 축 선
- 날짜 형식
- 축 제목
- 축 위치
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Java를 통해 Aspose.Slides for Node.js와 JavaScript를 사용하여 보고서 및 시각화를 위한 PowerPoint 프레젠테이션에서 차트 축을 맞춤 설정하는 방법을 알아보세요."
---
## **Overview**

이 문서에서는 Java를 통해 Aspose.Slides for Node.js에서 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행과 열 전환, 축 표시 여부, 카테고리 레이블 및 눈금 간격, 날짜 카테고리 및 형식 지정, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링 등을 다룹니다.

## **Get the Max Values on the Vertical Axis on Charts**

[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)을 생성하고 기본 데이터가 있는 영역 차트를 추가합니다. 계산된 축 값을 읽기 전에 차트 레이아웃을 최신 상태로 만들기 위해 [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/)을 호출합니다.

축 제한을 얻기 위해 [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/)와 [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/)를 읽고, 눈금 간격을 위해 [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/)와 [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/)를 읽습니다. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/)과 [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/)은 시간 단위 스케일을 제공하며, 날짜 축과 관련됩니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

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

## **Swap the Data between Axes**

차트 데이터에서 시리즈와 카테고리의 역할을 교환하려면 [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/)을 사용합니다. 이전의 각 카테고리는 시리즈가 되고, 이전의 각 시리즈는 카테고리가 됩니다. 이는 데이터 그룹화 방식을 변경하지만, 가로와 세로 축을 교환하지는 않습니다. 예제는 [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/)를 사용해 기본 데이터를 `Sheet1!A1:D5`(헤더 행 및 카테고리 열 포함)와 바인딩한 뒤 행과 열을 전환합니다. 네 개의 시리즈와 세 개의 카테고리가 있는 차트를 저장합니다.

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

## **Reverse the Plotting Order of an Axis**

카테고리 축이나 값 축을 역방향으로 만들려면 [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/)를 사용합니다. 예를 들어, 가로 막대 차트에서 프로젝트 단계가 워크시트와 같은 순서로 위에서 아래로 표시될 수 있습니다. 축을 역전하면 플롯 방향이 바뀌지만, 워크북 데이터가 정렬되거나 재배열되지는 않습니다. 비교를 위해서는 [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/)이 시리즈와 카테고리의 역할을 교환합니다.

다음 예제는 세 단계와 한 시리즈를 가진 가로 막대 차트를 만들고, 세 개의 슬라이드를 저장합니다: 정상 순서, 역방향 카테고리, 역방향 값. 각 복사본은 동일한 데이터셋을 사용하며, 각 복사본에서 하나의 축만 역전됩니다.

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

    // 슬라이드 2: 첫 번째 카테고리를 위에 표시합니다.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // 수평 값 축을 아래에 유지합니다.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // 슬라이드 3: 수평 숫자 스케일만 역전합니다.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

축을 역전하면 수직 축을 플롯의 반대쪽으로 이동시킬 수도 있습니다. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/)은 다른 축이 구성 중인 축과 교차하는 위치를 제어합니다. 슬라이드 2에서는 역방향 카테고리 축에 대해 `aspose.slides.CrossesType.Maximum`을 사용하면 가로 값 축이 아래에 유지됩니다. 특정 교차 지점을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/)를 사용합니다. 방향을 변경할 때는 특히 차트에 사용자 정의 교차 지점이 있는 경우 교차 설정을 확인하십시오. `setPlotOrderReversed`를 `false`로 호출하면 정상 플롯 방향으로 복원됩니다; 교차 설정은 별도로 유지됩니다.

| 정상 순서 (슬라이드 1) | 역방향 카테고리 (슬라이드 2) | 역방향 값 (슬라이드 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| 카테고리는 아래에서 위로 진행하고, 값은 왼쪽에서 오른쪽으로 증가합니다. | Planning, Development 및 Testing이 위에서 아래로 진행합니다. 값과 워크북 행 순서는 변경되지 않았습니다. | 카테고리는 정상 순서를 유지하고, 값은 오른쪽에서 왼쪽으로 증가합니다. 카테고리 축은 오른쪽의 0에서 교차합니다. |

## **Disable the Vertical Axis for Line Charts**

세로 축에 대해 `false`를 전달하여 [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/)를 호출하면 축이 숨겨집니다. 예제는 기본 데이터가 있는 선 차트를 만들고 세로 축이 숨겨진 상태로 저장합니다.

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

## **Disable the Horizontal Axis for Line Charts**

가로 축에 대해 `false`를 전달하여 [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/)를 호출하면 축이 숨겨집니다. 예제는 기본 데이터가 있는 선 차트를 만들고 가로 축이 숨겨진 상태로 저장합니다.

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

## **Change a Category Axis**

[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/)을 사용해 날짜 축 또는 텍스트 카테고리 축을 선택합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 들어있는 `ExistingChart.pptx`가 필요하며, 카테고리 셀에 숫자형 Excel 날짜 값이 들어 있습니다. 가로 축을 날짜 축으로 변경합니다. [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/)을 `false`로, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/)을 `1`로, [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/)을 `TimeUnitType.Months`로 설정하면 주요 눈금이 한 달 간격으로 배치됩니다.

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

## **Control Category Axis Label Intervals**

카테고리가 많은 차트에서 카테고리나 데이터 포인트를 제거하지 않고 보이는 축 레이블 수를 줄이고 싶을 때 사용합니다. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/)을 `false`로 호출한 뒤, 원하는 카테고리 간격을 [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/)에 전달합니다. 텍스트 카테고리를 정상 순서대로 사용할 경우, 첫 번째 카테고리부터 카운트가 시작됩니다:

| 간격 | 예시에서 표시된 레이블 |
| --- | --- |
| `1` | 카테고리 1, 카테고리 2, 카테고리 3, ... 카테고리 24 |
| `2` | 카테고리 1, 카테고리 3, 카테고리 5, ... 카테고리 23 |
| `3` | 카테고리 1, 카테고리 4, 카테고리 7, ... 카테고리 22 |

간격 `3`은 3번째 레이블마다 표시하며, 표시된 레이블 사이에 두 개의 레이블이 숨겨집니다. 해당 열 자체는 제거되지 않습니다. 자동 간격은 사용 가능한 공간을 기준으로 선택되며, 반드시 모든 레이블을 표시하지는 않습니다.

눈금선은 별도의 제어가 가능합니다. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/)을 `false`로 설정하고 [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/)으로 간격을 지정합니다. 예를 들어 `1`은 레이블이 3번째 카테고리마다만 표시되더라도 모든 카테고리 간격에 눈금선을 유지합니다. 눈에 보이도록 스타일을 지정하려면 [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/)를 사용하십시오. 자동 간격 설정자를 다시 `true`로 호출하면 차트가 자동 간격을 다시 선택합니다.

다음 자체 포함 예제는 24개의 카테고리와 하나의 시리즈를 만든 뒤 `CategoryAxisIntervals.pptx`에 세 개의 슬라이드를 저장합니다: 자동 간격, 레이블 간격은 수동이며 눈금선은 독립적, 자동 간격 복원. 두 복사본은 원본 차트 데이터를 유지합니다. 입력 프레젠테이션은 필요하지 않으며, 가로 레이블 텍스트가 밀도 차이를 쉽게 보여 줍니다.

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

    // 슬라이드 2: 모든 세 번째 레이블을 표시하되, 각 카테고리마다 눈금선을 유지합니다.
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

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째 카테고리 레이블마다 표시되며 두 줄로 줄넘김됩니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블마다 한 줄에 표시되고, 눈금선은 모든 카테고리 간격에 유지됩니다. 레이블이 없는 24개의 열도 동일한 값으로 보이게 됩니다. 슬라이드 3은 위의 자동 모습을 복원합니다.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Choose the Correct Axis and Interval**

텍스트 카테고리 축(예: 열, 선, 영역 또는 막대 차트의 카테고리 축)에서 이 카테고리 수 간격을 사용합니다. 열 차트에서는 가로 축이며, 가로 막대 차트에서는 카테고리 축이 세로이므로 [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/)가 반환하는 축에 적용합니다. 눈금 간격은 시리즈 축이 있는 차트에서도 적용됩니다.

값 축의 수치 스케일을 설정하려면 카테고리 레이블 간격을 사용하지 마십시오. 값 축에서 [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/)은 값 차이를 지정합니다(예: 주요 단위가 `10`이면 축이 0에서 시작할 때 0, 10, 20 등으로 눈금이 표시됩니다). 카테고리 레이블 간격 `3`은 데이터 값에 관계없이 카테고리 위치를 셉니다. 산점도와 거품 차트는 텍스트 카테고리 축이 아닌 값 축을 사용합니다. 날짜 축의 경우 [Change a Category Axis](#change-a-category-axis)에서 설명한 시간 기반 주요 단위와 스케일을 사용하십시오.

## **Set the Date Format for Category Axis Values**

예제는 기본 차트 데이터를 4개의 연간 값으로 교체합니다. 날짜는 OLE Automation 일련 번호로 첫 번째 워크시트(인덱스 `0`)에 저장되며, 1899년 12월 30일부터 경과한 일수로 계산됩니다. JavaScript 계산은 UTC 타임스탬프를 사용하고 차이를 하루당 86,400,000밀리초로 나눕니다. [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/)을 `CategoryAxisType.Date`와 함께 사용하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/)를 `false`로 호출한 뒤 `yyyy`를 [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/)에 전달하면 셀 서식과 무관하게 카테고리 레이블이 4자리 연도로 표시됩니다.

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

## **Set a Rotation Angle for a Chart Axis Title**

세로 축에 대해 `true`를 전달하여 [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/)를 호출하고 제목 텍스트를 지정한 뒤, [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/)를 사용해 제목을 회전합니다. 각도는 도 단위이며, 이 예제는 값 축 제목을 90도 회전한 열 차트를 저장합니다.

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

## **Set the Axis Position on a Category or Value Axis**

[setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/)을 사용해 값 축이 카테고리 축을 카테고리 간격 사이에서 교차할지, 카테고리 눈금에서 교차할지를 제어합니다. 이 설정은 카테고리 축에 적용됩니다. 예제는 열 차트의 가로 카테고리 축에 대해 이를 `true`로 설정하고 결과를 저장합니다.

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

## **Set the Display Unit on a Chart Value Axis**

[setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/)을 사용해 값 축 라벨을 데이터 자체를 변경하지 않고 스케일링합니다. [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/)을 `Millions`로 설정하면 60,000,000이 60으로 표시됩니다. 예제는 열 차트를 만들고 세로 축에 백만 단위 표시를 적용합니다.

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

## **Configure a Logarithmic Value Axis**

양의 값이 몇 십 배씩 차이를 보일 때 로그값 축이 유용합니다. 예를 들어, 서비스가 5기간 동안 10, 100, 1,000, 10,000, 100,000 요청을 받았다면, 선형 스케일에서는 작은 값들이 0 근처에 몰려 보입니다. 로그 스케일은 동일한 거리마다 동일한 비율을 나타내어 상대적인 성장률을 쉽게 비교할 수 있게 합니다.

값 축에 대해 `true`를 전달하여 [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/)를 호출하고, [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/)로 기준을 선택합니다. 이는 기존 값의 표시 방식을 바꾸지만 데이터 자체를 바꾸거나 로그 추세선을 추가하지는 않습니다. 추세선은 데이터에 맞춘 관계를 나타내는 별도 기능입니다.

### **Choose the Value Axis and Base**

선 차트나 열 차트의 경우 값 축은 [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/)가 반환합니다. 가로 막대 차트에서는 [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/)가 반환합니다. 산점도와 거품 차트는 두 개의 값 축을 가지므로 X값에는 가로 축, Y값에는 세로 축을 선택하거나 둘 다 적용합니다. 카테고리 축에는 로그 스케일을 적용하지 마십시오.

기본 로그 기준은 `10`입니다. PPTX 차트에서는 `2`부터 `1000`까지(포함) 기준을 사용할 수 있으며, `2.5`와 같은 소수 기준도 지원됩니다. 기준 `10`이면 10, 100, 1,000, 10,000 등 연속적인 거듭 제곱이 동일한 간격으로 배치됩니다.

### **Compare Linear and Logarithmic Scaling**

다음 자체 포함 예제는 첫 번째 슬라이드에 5개의 요청 수를 가진 선 차트를 만들고, 그 슬라이드를 복제한 뒤 두 번째 슬라이드에 기준 10 로그 값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

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

    // 첫 번째 슬라이드를 선형으로 유지하고 복사본의 값 축 스케일만 변경합니다.
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

**선형 스케일 (슬라이드 1):** 동일한 수직 거리는 요청 수 차이를 나타냅니다. 가장 큰 값이 차트를 지배해 작은 값들을 구분하기 어렵습니다.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**로그 스케일 (슬라이드 2):** 동일한 수직 거리는 동일한 비율을 나타냅니다. 각 기간의 요청 수는 이전 기간보다 10배 많아 기준 10 스케일에서는 직선 형태로 상승합니다. 축 레이블은 여전히 원래 요청 수를 표시합니다.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Handle Zero and Negative Values**

로그 스케일은 양수 값만 표시할 수 있습니다. 사용하기 전에 데이터를 확인하십시오. 0이나 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 해당 값들을 제외하는 것이 분석에 적절하다면 그 이유를 설명해야 합니다. 작은 양수로 대체하면 데이터 의미가 바뀌므로 조용히 대체하지 마십시오. 로그 축에 수동으로 설정한 최소값이나 최대값도 양수여야 합니다.

## **FAQ**

**한 축이 다른 축과 교차하는 위치(축 교차점)를 어떻게 설정합니까?**

[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/)을 사용해 교차 동작을 선택합니다. 수치 교차 값을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/)를 사용합니다. 이러한 설정을 통해 축 교차점을 적절한 기준선으로 이동할 수 있습니다.

**눈금 레이블을 축에 상대적으로 어떻게 배치합니까?**

[setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/)을 사용하고 [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) 중 `Low`, `High`, `NextTo`, `None` 중 하나를 지정합니다. 눈금 자체를 제어하려면 [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) 또는 [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/)를 사용합니다; 이는 레이블 위치와 별개입니다.