---
title: JavaScript를 사용하여 프레젠테이션에서 차트 축 맞춤 설정
linktitle: 차트 축
type: docs
url: /ko/nodejs-java/chart-axis/
keywords:
- 차트 축
- 수직 축
- 가로 축
- 축 맞춤
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
description: "Java를 통해 Node.js용 Aspose.Slides와 JavaScript를 사용하여 보고서 및 시각화를 위한 PowerPoint 프레젠테이션에서 차트 축을 맞춤 설정하는 방법을 알아보세요."
---
## **개요**

이 문서에서는 Aspose.Slides for Node.js via Java를 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행과 열 전환, 축 표시 여부, 카테고리 레이블 및 눈금 간격, 날짜 카테고리와 서식, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트의 세로축에서 최대값 가져오기**

기본 데이터가 있는 영역 차트를 추가하려면 [프레젠테이션](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)을 생성합니다. 계산된 축 값을 읽기 전에 차트 레이아웃을 최신 상태로 유지하기 위해 [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/)을 호출합니다.

축 한계를 얻으려면 [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) 및 [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/)를 호출하고, 눈금 간격을 얻으려면 [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) 및 [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/)을 호출합니다. 날짜 축과 관련된 시간 단위 스케일은 [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) 및 [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/)이 제공합니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

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

## **축 사이의 데이터 교환**

[switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/)을 사용하여 차트 데이터에서 시리즈와 카테고리의 역할을 교환합니다. 기존 카테고리는 시리즈가 되고, 기존 시리즈는 카테고리가 됩니다. 이는 데이터가 그룹화되는 방식을 변경하지만 가로축과 세로축을 교환하는 것은 아닙니다. 예제에서는 [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/)을 사용하여 기본 데이터를 `Sheet1!A1:D5`(헤더 행과 카테고리 열 포함)와 바인딩한 뒤 행과 열을 전환합니다. 결과적으로 네 개의 시리즈와 세 개의 카테고리를 가진 차트를 저장합니다.

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

## **라인 차트의 세로축 비활성화**

세로축에 `false`를 전달하여 [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/)를 호출하면 축을 숨길 수 있습니다. 예제에서는 기본 데이터가 있는 라인 차트를 생성하고 세로축을 숨긴 상태로 저장합니다.

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

## **라인 차트의 가로축 비활성화**

가로축에 `false`를 전달하여 [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/)를 호출하면 축을 숨길 수 있습니다. 예제에서는 기본 데이터가 있는 라인 차트를 생성하고 가로축을 숨긴 상태로 저장합니다.

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

## **카테고리 축 변경**

[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/)을 사용하여 날짜 축 또는 텍스트 축을 선택합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 포함된 `ExistingChart.pptx` 파일을 필요로 하며, 카테고리 셀에 Excel 날짜 값(숫자 형식)이 들어 있습니다. 가로축을 날짜 축으로 바꿉니다. [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/)을 `false`로, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/)을 `1`로, [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/)을 `TimeUnitType.Months`로 설정하면 주요 눈금이 한 달 간격으로 배치됩니다.

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

## **카테고리 축 레이블 간격 제어**

차트에 카테고리가 많을 경우 카테고리나 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄일 수 있습니다. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/)에 `false`를 전달한 뒤, 원하는 카테고리 간격을 [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/)에 전달합니다. 텍스트 카테고리가 일반 순서대로 있을 때는 첫 번째 카테고리부터 계산이 시작됩니다.

| 간격 | 예시에서 표시된 레이블 |
| --- | --- |
| `1` | 범주 1, 범주 2, 범주 3, ... 범주 24 |
| `2` | 범주 1, 범주 3, 범주 5, ... 범주 23 |
| `3` | 범주 1, 범주 4, 범주 7, ... 범주 22 |

`3` 간격은 3번째 레이블마다 하나씩 표시하고, 표시된 레이블 사이에 두 개의 레이블을 숨깁니다. 이는 해당 열을 제거하지 않습니다. 자동 간격은 사용 가능한 공간을 기준으로 간격을 선택하며, 반드시 모든 레이블을 표시하지는 않습니다.

눈금표에도 별도 제어가 있습니다. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/)에 `false`를 전달하고 [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/)를 사용하여 눈금표 간격을 설정합니다. 예를 들어 `1`은 각 카테고리 간격마다 눈금표를 유지하면서 레이블은 3번째 카테고리마다만 표시합니다. 눈금표가 보이도록 하려면 [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/)를 사용합니다. 자동 간격 설정자를 `true`로 다시 호출하면 차트가 자동 간격을 다시 선택합니다.

다음 자체 포함 예제는 24개의 카테고리와 하나의 시리즈를 만든 뒤 `CategoryAxisIntervals.pptx`에 세 개의 슬라이드를 저장합니다: 자동 간격, 독립 눈금표가 있는 수동 레이블 간격, 자동 간격 복원. 두 복사본은 원본 차트 데이터를 그대로 유지합니다. 입력 프레젠테이션이 필요하지 않으며, 가로 레이블 텍스트가 밀도 차이를 쉽게 보여줍니다.

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

    // 슬라이드 2: 매 세 번째 레이블을 표시하지만, 각 카테고리마다 눈금표를 유지합니다.
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

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째 카테고리 레이블마다 표시되며 두 줄로 감깁니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![모든 24열이 보이는 자동 카테고리 레이블 간격](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블마다 한 줄에 표시되고, 눈금표는 각 카테고리 간격마다 유지됩니다. 레이블이 없는 열을 포함한 모든 24열이 동일한 값으로 보입니다. 슬라이드 3은 위에 보여진 자동 모양을 복원합니다.

![모든 24열이 보이는 수동 카테고리 레이블 간격(간격 3)](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 카테고리 축(예: 열, 라인, 영역, 막대 차트의 카테고리 축)에서는 이 카테고리-간격을 사용합니다. 열 차트에서는 가로축이며, 가로 막대 차트에서는 카테고리 축이 세로이므로 [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/)가 반환하는 축에 적용합니다. 눈금표 간격은 값 축이 있는 차트의 시리즈 축에도 적용됩니다.

값 축의 숫자 스케일을 설정하려면 카테고리 레이블 간격을 사용하지 마세요. 값 축에서는 [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/)이 값 차이를 지정합니다(예: `10`은 0, 10, 20 등으로 눈금을 만듭니다). 카테고리 레이블 간격 `3`은 데이터 값과 상관없이 카테고리 위치를 3씩 건너뜁니다. 산점도와 버블 차트는 텍스트 카테고리 축이 아닌 값 축을 사용합니다. 날짜 축의 경우 [카테고리 축 변경](#change-a-category-axis)에서 설명한 시간 기반 주요 단위와 스케일을 사용하세요.

## **카테고리 축 값에 대한 날짜 형식 설정**

예제에서는 기본 차트 데이터를 4개의 연도 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장되며, 1899년 12월 30일부터 경과된 일수로 계산됩니다. JavaScript 계산은 UTC 타임스탬프를 사용하고 차이를 하루당 86,400,000밀리초로 나눕니다. [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/)에 `CategoryAxisType.Date`를 지정하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/)에 `false`를 전달한 뒤 `yyyy`를 [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/)에 전달하면 셀 서식에 관계없이 카테고리 레이블이 4자리 연도로 표시됩니다.

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

## **차트 축 제목에 회전 각도 설정**

세로축에 `true`를 전달하여 [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/)를 호출하고 제목 텍스트를 제공한 뒤, [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/)을 사용해 제목을 회전시킵니다. 각도는 도(unit)이며, 이 예제에서는 값 축 제목을 90도 회전한 열 차트를 저장합니다.

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

## **카테고리 또는 값 축에 대한 축 위치 설정**

[setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/)을 사용하여 값 축이 카테고리 축을 카테고리 사이에 교차하도록 할지 카테고리 눈금표에 교차하도록 할지를 제어합니다. 이 설정은 카테고리 축에만 적용됩니다. 예제에서는 열 차트의 가로 카테고리 축에 `true`를 설정하고 결과를 저장합니다.

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

[setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/)을 사용하면 기본 데이터를 변경하지 않고 값 축 레이블을 스케일링할 수 있습니다. [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/)을 `Millions`로 설정하면 60,000,000이라는 값이 60으로 표시됩니다. 예제에서는 열 차트를 만들고 세로축에 백만 단위를 적용합니다.

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

## **로그값 축 구성**

양의 값이 여러 차수에 걸쳐 크게 변할 때 로그값 축이 유용합니다. 예를 들어, 한 서비스가 5기간에 걸쳐 10, 100, 1,000, 10,000, 100,000개의 요청을 받는다고 가정합니다. 선형 스케일에서는 작은 값들이 0에 가까워서 서로 겹쳐 보입니다. 로그 스케일은 같은 거리마다 같은 비율을 나타내므로 상대적인 성장률을 비교하기 쉬워집니다.

값 축에 `true`를 전달하여 [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/)를 호출하고, [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/)로 기준을 선택합니다. 이는 기존 값이 표시되는 방식을 변경하지만 데이터 자체를 바꾸거나 로그 추세선을 추가하지는 않습니다. 추세선은 데이터에 맞춘 별도 기능입니다.

### **값 축 및 기준 선택**

라인 차트나 열 차트에서는 값 축이 [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/)가 반환합니다. 가로 막대 차트에서는 [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/)가 반환합니다. 산점도와 버블 차트는 두 개의 값 축을 가지므로 X값에는 가로 축, Y값에는 세로 축, 또는 모두 적용합니다. 카테고리 축에는 로그 스케일을 적용하지 마세요.

기본 로그 기준은 `10`입니다. PPTX 차트에서는 `2`부터 `1000`까지의 정수를 기준으로 사용할 수 있으며, `2.5`와 같은 소수점 기준도 지원됩니다. 기준 `10`을 사용하면 10, 100, 1,000, 10,000 등 연속적인 거듭 제곱이 동일한 간격으로 배치됩니다.

### **선형 및 로그 스케일 비교**

다음 자체 포함 예제는 첫 번째 슬라이드에 요청 수 다섯 개를 가진 라인 차트를 만들고, 두 번째 슬라이드에서는 해당 슬라이드를 복제한 뒤 기준 10 로그값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

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

**선형 스케일 (슬라이드 1):** 같은 세로 거리마다 요청 수 차이가 동일하게 표시됩니다. 가장 큰 값이 차트를 지배해 작은 값들을 구분하기 어렵습니다.

![선형 값 축에 다섯 개의 요청 수가 표시된 PowerPoint 라인 차트](value-axis-linear.png)

**로그 스케일 (슬라이드 2):** 같은 세로 거리마다 비율이 동일하게 표시됩니다. 각 기간의 요청 수가 이전 기간의 10배이므로, 기준 10 로그 스케일에서는 점들이 곧은 상승선으로 나타납니다. 축 레이블은 여전히 원본 요청 수를 보여줍니다.

![기준 10 로그값 축에 같은 다섯 개 요청 수가 표시된 PowerPoint 차트](value-axis-logarithmic.png)

### **0 및 음수 값 처리**

로그 스케일은 양수 값만 표시할 수 있습니다. 적용하기 전에 데이터를 확인하세요. 0이나 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 해당 값을 제외하는 것이 분석에 적합하다면 그 이유를 설명해야 합니다. 작은 양수로 대체하여 조용히 바꾸지는 마세요. 로그 축에 수동으로 설정한 최소값이나 최대값도 양수여야 합니다.

## **자주 묻는 질문**

**축 교차 지점을 어떻게 설정합니까?**

[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/)을 사용하여 교차 동작을 선택합니다. 숫자 교차 값을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/)을 사용합니다. 이러한 설정을 통해 축 교차점을 적절한 기준선으로 이동할 수 있습니다.

**눈금 레이블을 축에 대해 어떻게 배치합니까?**

[setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/)을 호출하고 [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) 중 `Low`, `High`, `NextTo`, `None` 중 하나를 선택합니다. 눈금 자체를 제어하려면 [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) 또는 [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/)를 사용합니다; 이는 레이블 위치와는 별개입니다.