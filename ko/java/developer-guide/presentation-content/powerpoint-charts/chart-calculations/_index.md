---
title: Java 프레젠테이션을 위한 차트 계산 최적화
linktitle: 차트 계산
type: docs
weight: 50
url: /ko/java/chart-calculations/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 PPT와 PPTX를 위한 차트 계산, 데이터 업데이트 및 정밀 제어를 이해하고 실용적인 Java 코드 예제를 확인하세요."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 차트 계산 및 레이아웃 데이터를 작업하기 위한 API를 제공합니다. 이 문서에서는 `IActualLayout`을 구현하는 요소의 실제 위치 및 크기와 차트 축의 실제 값을 포함한 차트 요소의 실제 값을 검색하는 방법을 보여줍니다. 또한 이러한 값은 차트 레이아웃 검증 이후에 채워진다는 점을 설명합니다.

또한, 이 문서에서는 상위 차트 요소의 실제 위치를 얻는 방법과 제목, 축, 범례 및 그리드 라인과 같은 차트 구성 요소를 숨기는 방법을 보여줍니다. 이러한 예제들을 통해 차트 레이아웃 정보를 검사하고 PowerPoint 프레젠테이션에서 차트 요소의 표시 여부를 프로그래밍 방식으로 제어할 수 있습니다.

## **차트 요소의 실제 값 계산**

Aspose.Slides for Java는 이러한 속성을 가져오기 위한 간단한 API를 제공합니다. [IAxis](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAxis) 인터페이스의 속성은 차트 축 요소의 실제 위치에 대한 정보를 제공합니다([IAxis.getActualMaxValue](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). 실제 값으로 속성을 채우려면 먼저 [IChart.validateChartLayout()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChart#validateChartLayout--) 메서드를 호출해야 합니다.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **상위 차트 요소의 실제 위치 계산**

Aspose.Slides for Java는 이러한 속성을 가져오기 위한 간단한 API를 제공합니다. [IActualLayout](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IActualLayout) 인터페이스의 속성은 상위 차트 요소의 실제 위치에 대한 정보를 제공합니다([IActualLayout.getActualX](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IActualLayout#getActualHeight--)). 실제 값으로 속성을 채우려면 먼저 [IChart.validateChartLayout()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChart#validateChartLayout--) 메서드를 호출해야 합니다.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **차트 요소 숨기기**

이 항목에서는 차트에서 정보를 숨기는 방법을 이해하도록 도와줍니다. Aspose.Slides for Java를 사용하면 차트에서 **제목, 수직 축, 수평 축** 및 **그리드 라인**을 숨길 수 있습니다. 아래 코드 예제는 이러한 속성을 사용하는 방법을 보여줍니다.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //차트 제목 숨기기
    chart.setTitle(false);

    ///값 축 숨기기
    chart.getAxes().getVerticalAxis().setVisible(false);

    //카테고리 축 표시 여부
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //범례 숨기기
    chart.setLegend(false);

    //주 격자선 숨기기
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //시리즈 선 색상 설정
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **자주 묻는 질문**

**외부 Excel 통합 문서를 데이터 소스로 사용할 수 있나요? 그리고 이것이 재계산에 어떤 영향을 미치나요?**

예. 차트는 외부 통합 문서를 참조할 수 있습니다. 외부 소스를 연결하거나 새로 고치면 해당 통합 문서에서 수식과 값이 가져와지며, 차트는 열기/편집 작업 중에 업데이트를 반영합니다. API를 사용하면 [외부 통합 문서를 지정](https://reference.aspose.com/slides/ko/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) 경로를 설정하고 연결된 데이터를 관리할 수 있습니다.

**회귀 분석을 직접 구현하지 않고 트렌드라인을 계산하고 표시할 수 있나요?**

예. [트렌드라인](/slides/ko/java/trend-line/) (선형, 지수형 등)은 Aspose.Slides에 의해 추가 및 업데이트되며, 해당 매개변수는 시리즈 데이터에서 자동으로 재계산되므로 별도로 회귀 계산을 구현할 필요가 없습니다.

**프레젠테이션에 외부 링크가 있는 여러 차트가 있는 경우, 각 차트가 사용할 통합 문서를 계산 값에 대해 제어할 수 있나요?**

예. 각 차트는 자체 [외부 통합 문서](https://reference.aspose.com/slides/ko/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-)를 지정할 수 있으며, 차트마다 독립적으로 외부 통합 문서를 생성하거나 교체할 수 있습니다.