---
title: JavaScript로 프레젠테이션을 위한 차트 계산 최적화
linktitle: 차트 계산
type: docs
weight: 50
url: /ko/nodejs-java/chart-calculations/
keywords:
- 차트 계산
- 차트 요소
- 요소 위치
- 실제 위치
- 자식 요소
- 부모 요소
- 차트 값
- 실제 값
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 PPT 및 PPTX를 위한 차트 계산, 데이터 업데이트 및 정밀도 제어를 이해하고, 실용적인 JavaScript 코드 예제로 배우세요."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 차트 계산 및 레이아웃 데이터를 처리하기 위한 API를 제공합니다. 이 문서에서는 차트 요소의 실제 값, 즉 요소의 실제 위치와 크기 및 차트 축의 실제 값을 검색하는 방법을 보여줍니다. 또한 이러한 값은 차트 레이아웃 검증 후에 채워진다는 점을 설명합니다.

또한 이 문서에서는 부모 차트 요소의 실제 위치를 가져오는 방법과 차트의 제목, 축, 범례 및 격자선과 같은 구성 요소를 숨기는 방법을 보여줍니다. 이러한 예제를 통해 차트 레이아웃 정보를 검사하고 PowerPoint 프레젠테이션에서 차트 요소의 표시 여부를 프로그래밍으로 제어할 수 있습니다.

## **차트 요소의 실제 값 계산**

Aspose.Slides for Node.js via Java는 이러한 속성을 가져오기 위한 간단한 API를 제공합니다. [Axis](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Axis) 클래스의 속성은 축 차트 요소의 실제 위치에 대한 정보를 제공합니다([Axis.getActualMaxValue](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). 실제 값으로 속성을 채우기 위해서는 먼저 [Chart.validateChartLayout()](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Chart#validateChartLayout--) 메서드를 호출해야 합니다.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **부모 차트 요소의 실제 위치 계산**

Aspose.Slides for Node.js via Java는 이러한 속성을 가져오기 위한 간단한 API를 제공합니다. `ActualLayout` 클래스의 속성은 부모 차트 요소의 실제 위치에 대한 정보를 제공합니다(`ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`). 실제 값으로 속성을 채우기 위해서는 먼저 [Chart.validateChartLayout()](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Chart#validateChartLayout--) 메서드를 호출해야 합니다.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **차트에서 정보 숨기기**

이 항목은 차트에서 정보를 숨기는 방법을 이해하는 데 도움이 됩니다. Aspose.Slides for Node.js via Java를 사용하면 차트에서 **Title, Vertical Axis, Horizontal Axis** 및 **Grid Lines**을 숨길 수 있습니다. 아래 코드 예제는 이러한 속성을 사용하는 방법을 보여줍니다.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // 차트 제목 숨기기
    chart.setTitle(false);
    // /값 축 숨기기
    chart.getAxes().getVerticalAxis().setVisible(false);
    // 카테고리 축 가시성
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // 범례 숨기기
    chart.setLegend(false);
    // 주 격자선 숨기기
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // 시리즈 선 색상 설정
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**외부 Excel 워크북을 데이터 소스로 사용할 수 있으며, 이에 따라 재계산에 어떤 영향을 줍니까?**

예. 차트는 외부 워크북을 참조할 수 있습니다. 외부 소스를 연결하거나 새로 고치면 해당 워크북에서 수식과 값을 가져오며, 차트는 열기/편집 작업 중에 업데이트를 반영합니다. API를 사용하면 [external workbook](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) 경로를 지정하고 연결된 데이터를 관리할 수 있습니다.

**내가 직접 회귀 분석을 구현하지 않고도 추세선을 계산하고 표시할 수 있나요?**

예. [Trendlines](/slides/ko/nodejs-java/trend-line/) (선형, 지수 등)은 Aspose.Slides에 의해 추가 및 업데이트되며, 해당 매개변수는 시리즈 데이터에서 자동으로 재계산되므로 직접 계산을 구현할 필요가 없습니다.

**프레젠테이션에 외부 링크가 있는 여러 차트가 있는 경우, 각 차트가 계산된 값을 가져올 워크북을 제어할 수 있나요?**

예. 각 차트는 자체 [external workbook](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdata/setexternalworkbook/)을 가리키도록 할 수 있으며, 다른 차트와 독립적으로 차트별 외부 워크북을 생성하거나 교체할 수 있습니다.