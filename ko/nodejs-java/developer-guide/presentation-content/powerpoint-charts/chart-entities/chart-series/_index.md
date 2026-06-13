---
title: JavaScript를 사용하여 프레젠테이션에서 차트 데이터 시리즈 관리
linktitle: 데이터 시리즈
type: docs
url: /ko/nodejs-java/chart-series/
keywords:
- 차트 시리즈
- 시리즈 겹침
- 시리즈 색상
- 카테고리 색상
- 시리즈 이름
- 데이터 포인트
- 시리즈 간격
- 파워포인트
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint(PPT/PPTX)용 JavaScript에서 차트 시리즈를 관리하는 방법을 실용적인 코드 예제와 모범 사례를 통해 배워 데이터 프레젠테이션을 향상시키세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 [ChartSeries](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/)의 역할을 설명하며, 프레젠테이션 내에서 데이터가 어떻게 구조화되고 시각화되는지에 초점을 맞춥니다. 이러한 객체는 차트에서 개별 데이터 포인트 집합, 범주 및 외관 매개변수를 정의하는 기본 요소를 제공합니다. [ChartSeries](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/)를 사용하면 개발자는 기본 데이터 소스를 원활하게 통합하고 정보 표시 방식을 완전히 제어할 수 있어, 통찰력과 분석을 명확하게 전달하는 동적이고 데이터 중심의 프레젠테이션을 만들 수 있습니다.

시리즈는 차트에 플롯된 행 또는 열의 숫자 집합입니다.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **차트 시리즈 겹침 설정**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/#getOverlap) 메서드를 사용하면 2D 차트에서 막대와 열이 겹치는 정도를 지정할 수 있습니다(범위: -100~100). 이 속성은 상위 시리즈 그룹의 모든 시리즈에 적용되며, 해당 그룹 속성의 투사입니다. 따라서 이 속성은 읽기 전용입니다.

`ParentSeriesGroup.getOverlap` 읽기/쓰기 속성을 사용하여 `Overlap`에 원하는 값을 설정합니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 슬라이드에 클러스터형 열 차트를 추가합니다.
1. 첫 번째 차트 시리즈에 액세스합니다.
1. 차트 시리즈의 `ParentSeriesGroup`에 액세스하고 시리즈에 원하는 겹침 값을 설정합니다. 
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 차트 시리즈의 겹침을 설정하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 차트를 추가합니다
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // 시리즈 겹침을 설정합니다
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // 프레젠테이션 파일을 디스크에 저장합니다
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **시리즈 색상 변경**

Aspose.Slides for Node.js via Java를 사용하면 시리즈 색상을 다음과 같이 변경할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 슬라이드에 차트를 추가합니다.
1. 색상을 변경하려는 시리즈에 액세스합니다. 
1. 원하는 채우기 유형 및 색상을 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 JavaScript 코드는 시리즈 색상을 변경하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **시리즈 범주의 색상 변경**

Aspose.Slides for Node.js via Java를 사용하면 시리즈 범주의 색상을 다음과 같이 변경할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 슬라이드에 차트를 추가합니다.
1. 색상을 변경하려는 시리즈 범주에 액세스합니다.
1. 원하는 채우기 유형 및 색상을 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 JavaScript 코드는 시리즈 범주의 색상을 변경하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **시리즈 이름 변경** 

기본적으로 차트의 범례 이름은 각 열 또는 행 위에 있는 셀의 내용입니다. 

예시(샘플 이미지)에서는 

* 열은 *Series 1, Series 2,* 및 *Series 3*입니다;
* 행은 *Category 1, Category 2, Category 3,* 및 *Category 4*입니다. 

Aspose.Slides for Node.js via Java를 사용하면 차트 데이터와 범례에서 시리즈 이름을 업데이트하거나 변경할 수 있습니다.

다음 JavaScript 코드는 차트 데이터 `ChartDataWorkbook`에서 시리즈 이름을 변경하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

다음 JavaScript 코드는 `Series`를 통해 범례에서 시리즈 이름을 변경하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **차트 시리즈 채우기 색상 설정**

Aspose.Slides for Node.js via Java를 사용하면 플롯 영역 내 차트 시리즈의 자동 채우기 색상을 다음과 같이 설정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 슬라이드의 인덱스로 슬라이드 참조를 가져옵니다.
1. 원하는 유형(예제에서는 `ChartType.ClusteredColumn`)에 기반한 기본 데이터로 차트를 추가합니다.
1. 차트 시리즈에 액세스하고 채우기 색상을 Automatic으로 설정합니다.
1. 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 차트 시리즈의 자동 채우기 색상을 설정하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 클러스터형 열 차트를 생성합니다
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // 시리즈 채우기 형식을 자동으로 설정합니다
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // 프레젠테이션 파일을 디스크에 저장합니다
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **차트 시리즈 색상 반전 설정**

Aspose.Slides를 사용하면 플롯 영역 내 차트 시리즈의 반전 채우기 색상을 다음과 같이 설정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 슬라이드의 인덱스로 슬라이드 참조를 가져옵니다.
1. 원하는 유형(예제에서는 `ChartType.ClusteredColumn`)에 기반한 기본 데이터로 차트를 추가합니다.
1. 차트 시리즈에 액세스하고 채우기 색상을 invert로 설정합니다.
1. 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 해당 작업을 시연합니다:

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // 새 시리즈와 카테고리를 추가합니다
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // 첫 번째 차트 시리즈를 가져와 시리즈 데이터를 채웁니다.
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **값이 음수일 때 시리즈 색상 반전 설정**

Aspose.Slides는 `ChartDataPoint.setInvertIfNegative` 메서드를 통해 반전을 설정하도록 허용합니다. 속성을 사용해 반전을 설정하면 데이터 포인트가 음수 값을 받을 때 색상이 반전됩니다. 

다음 JavaScript 코드는 해당 작업을 시연합니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **특정 데이터 포인트 데이터 삭제**

Aspose.Slides for Node.js via Java를 사용하면 특정 차트 시리즈에 대한 `DataPoints` 데이터를 다음과 같이 삭제할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드 참조를 가져옵니다.
3. 인덱스로 차트 참조를 가져옵니다.
4. 차트 `DataPoints` 전체를 순회하면서 `XValue`와 `YValue`를 null로 설정합니다.
5. 특정 차트 시리즈에 대한 모든 `DataPoints`를 삭제합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 해당 작업을 시연합니다:

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **시리즈 간격 너비 설정**

Aspose.Slides for Node.js via Java를 사용하면 **`GapWidth`** 속성을 통해 시리즈의 Gap Width를 다음과 같이 설정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 액세스합니다.
1. 기본 데이터로 차트를 추가합니다.
1. 임의의 차트 시리즈에 액세스합니다.
1. `GapWidth` 속성을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 시리즈의 Gap Width를 설정하는 방법을 보여줍니다:

```javascript
// 빈 프레젠테이션을 생성합니다
var pres = new aspose.slides.Presentation();
try {
    // 프레젠테이션의 첫 번째 슬라이드에 접근합니다
    var slide = pres.getSlides().get_Item(0);
    // 기본 데이터로 차트를 추가합니다
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // 차트 데이터 시트의 인덱스를 설정합니다
    var defaultWorksheetIndex = 0;
    // 차트 데이터 워크시트를 가져옵니다
    var fact = chart.getChartData().getChartDataWorkbook();
    // 시리즈를 추가합니다
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // 카테고리를 추가합니다
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // 두 번째 차트 시리즈를 가져옵니다
    var series = chart.getChartData().getSeries().get_Item(1);
    // 시리즈 데이터를 채웁니다
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // GapWidth 값을 설정합니다
    series.getParentSeriesGroup().setGapWidth(50);
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**단일 차트에 포함될 수 있는 시리즈 수에 제한이 있나요?**

Aspose.Slides는 추가할 수 있는 시리즈 수에 고정된 제한을 두지 않습니다. 실제 제한은 차트 가독성과 애플리케이션이 사용할 수 있는 메모리에 따라 결정됩니다.

**클러스터 내 열이 너무 가깝거나 너무 멀리 떨어져 있으면 어떻게 하나요?**

해당 시리즈(또는 상위 시리즈 그룹)의 Gap Width 설정을 조정하십시오. 값을 늘리면 열 사이의 간격이 넓어지고, 값을 줄이면 더 가까워집니다.