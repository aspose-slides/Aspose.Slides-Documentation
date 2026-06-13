---
title: Android에서 프레젠테이션의 차트 데이터 시리즈 관리
linktitle: 데이터 시리즈
type: docs
url: /ko/androidjava/chart-series/
keywords:
- 차트 시리즈
- 시리즈 중첩
- 시리즈 색상
- 카테고리 색상
- 시리즈 이름
- 데이터 포인트
- 시리즈 간격
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Android에서 PowerPoint(PPT/PPTX)를 위한 차트 시리즈 관리 방법을 실용적인 Java 코드 예제와 모범 사례를 통해 배워 데이터 프레젠테이션을 향상시키세요."
---
## **개요**

이 문서는 Aspose.Slides에서 [ChartSeries](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/chartseries/)의 역할을 설명하며, 데이터가 프레젠테이션 내에서 어떻게 구조화되고 시각화되는지에 중점을 둡니다. 이러한 객체는 차트에서 개별 데이터 포인트 집합, 카테고리 및 외관 매개변수를 정의하는 기본 요소를 제공합니다. [ChartSeries](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/chartseries/)를 사용하면 개발자는 기본 데이터 소스를 원활하게 통합하고 정보 표시 방식을 완전히 제어할 수 있어, 통찰과 분석을 명확히 전달하는 동적이고 데이터 기반의 프레젠테이션을 만들 수 있습니다.

시리즈는 차트에 플롯되는 숫자의 행 또는 열입니다.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **차트 시리즈 중첩 설정**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getOverlap--) 메서드를 사용하면 2D 차트에서 막대와 열이 얼마나 중첩될지 결정할 수 있습니다(범위: -100~100). 이 속성은 상위 시리즈 그룹의 모든 시리즈에 적용됩니다: 해당 그룹 속성의 투영입니다. 따라서 이 속성은 읽기 전용입니다.  

`getParentSeriesGroup().setOverlap()` 쓰기 메서드를 사용하여 원하는 중첩 값을 설정하세요.  

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. 슬라이드에 클러스터형 열 차트를 추가합니다.  
1. 첫 번째 차트 시리즈에 접근합니다.  
1. 차트 시리즈의 `ParentSeriesGroup`에 접근하여 시리즈에 대한 원하는 중첩 값을 설정합니다.  
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 Java 코드는 차트 시리즈의 중첩을 설정하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    // 차트 추가
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // 시리즈 중첩 설정
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // 프레젠테이션 파일을 디스크에 저장
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **시리즈 색상 변경**

Aspose.Slides for Android via Java를 사용하면 시리즈 색상을 다음과 같이 변경할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. 슬라이드에 차트를 추가합니다.  
1. 색상을 변경하려는 시리즈에 접근합니다.  
1. 원하는 채우기 유형 및 색상을 설정합니다.  
1. 수정된 프레젠테이션을 저장합니다.  

다음 Java 코드는 시리즈 색상을 변경하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **시리즈 카테고리 색상 변경**

Aspose.Slides for Android via Java를 사용하면 시리즈 카테고리의 색상을 다음과 같이 변경할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. 슬라이드에 차트를 추가합니다.  
1. 색상을 변경하려는 시리즈 카테고리에 접근합니다.  
1. 원하는 채우기 유형 및 색상을 설정합니다.  
1. 수정된 프레젠테이션을 저장합니다.  

다음 Java 코드는 시리즈 카테고리의 색상을 변경하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **시리즈 이름 변경**

기본적으로 차트의 레전드 이름은 각 열 또는 행 위에 있는 셀의 내용입니다.  

예시(샘플 이미지)에서는  

* 열은 *Series 1, Series 2,* 및 *Series 3*입니다;  
* 행은 *Category 1, Category 2, Category 3,* 및 *Category 4*입니다.  

Aspose.Slides for Android via Java를 사용하면 차트 데이터 및 레전드에서 시리즈 이름을 업데이트하거나 변경할 수 있습니다.  

다음 Java 코드는 차트 데이터 `ChartDataWorkbook`에서 시리즈 이름을 변경하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

다음 Java 코드는 through`Series`를 사용하여 레전드에서 시리즈 이름을 변경하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **차트 시리즈 채우기 색상 설정**

Aspose.Slides for Android via Java를 사용하면 플롯 영역 내 차트 시리즈의 자동 채우기 색상을 다음과 같이 설정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 슬라이드의 참조를 가져옵니다.  
3. 선호하는 타입을 기반으로 기본 데이터가 있는 차트를 추가합니다(아래 예에서는 `ChartType.ClusteredColumn`을 사용했습니다).  
4. 차트 시리즈에 접근하여 채우기 색상을 Automatic(자동)으로 설정합니다.  
5. 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 Java 코드는 차트 시리즈에 대한 자동 채우기 색상을 설정하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    // 클러스터형 열 차트 생성
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // 시리즈 채우기 형식을 자동으로 설정
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // 프레젠테이션 파일을 디스크에 저장
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **차트 시리즈의 반전 채우기 색상 설정**

Aspose.Slides for Android via Java를 사용하면 플롯 영역 내 차트 시리즈의 반전 채우기 색상을 다음과 같이 설정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 슬라이드의 참조를 가져옵니다.  
3. 선호하는 타입을 기반으로 기본 데이터가 있는 차트를 추가합니다(아래 예에서는 `ChartType.ClusteredColumn`을 사용했습니다).  
4. 차트 시리즈에 접근하여 채우기 색상을 invert(반전)으로 설정합니다.  
5. 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 Java 코드는 이 작업을 보여줍니다:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // 새 시리즈와 카테고리를 추가합니다
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // 첫 번째 차트 시리즈를 가져와서 시리즈 데이터를 채웁니다.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **값이 음수일 때 시리즈를 반전하도록 설정**

Aspose.Slides를 사용하면 `IChartDataPoint.InvertIfNegative` 및 `ChartDataPoint.InvertIfNegative` 속성을 통해 반전을 설정할 수 있습니다. 해당 속성을 사용해 반전을 설정하면 데이터 포인트가 음수 값을 받을 때 색상이 반전됩니다.  

다음 Java 코드는 이 작업을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **특정 포인트 데이터 지우기**

Aspose.Slides for Android via Java를 사용하면 특정 차트 시리즈의 `DataPoints` 데이터를 다음과 같이 지울 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 슬라이드의 참조를 가져옵니다.  
3. 인덱스로 차트의 참조를 가져옵니다.  
4. 모든 차트 `DataPoints`를 순회하면서 `XValue`와 `YValue`를 null로 설정합니다.  
5. 특정 차트 시리즈에 대한 모든`DataPoints`를 지웁니다.  
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 Java 코드는 이 작업을 보여줍니다:

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **시리즈 간격 너비 설정**

Aspose.Slides for Android via Java를 사용하면 **`GapWidth`** 속성을 통해 시리즈의 간격 너비를 다음과 같이 설정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 첫 번째 슬라이드에 접근합니다.  
3. 기본 데이터가 있는 차트를 추가합니다.  
4. 임의의 차트 시리즈에 접근합니다.  
5. `GapWidth` 속성을 설정합니다.  
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 Java 코드는 시리즈의 Gap Width를 설정하는 방법을 보여줍니다:

```java
// 빈 프레젠테이션을 생성합니다 
Presentation pres = new Presentation();
try {
    // 프레젠테이션의 첫 번째 슬라이드에 접근합니다
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 기본 데이터가 포함된 차트를 추가합니다
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // 차트 데이터 시트의 인덱스를 설정합니다
    int defaultWorksheetIndex = 0;
    
    // 차트 데이터 워크시트를 가져옵니다
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // 시리즈를 추가합니다
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // 카테고리를 추가합니다
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // 두 번째 차트 시리즈를 가져옵니다
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
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
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**단일 차트가 포함할 수 있는 시리즈 수에 제한이 있나요?**

Aspose.Slides는 추가하는 시리즈 수에 고정된 제한을 두지 않습니다. 실제 제한은 차트 가독성 및 애플리케이션에 사용 가능한 메모리에 따라 결정됩니다.

**클러스터 내 열 간격이 너무 가깝거나 너무 멀면 어떻게 해야 하나요?**

`GapWidth` 설정을 해당 시리즈(또는 상위 시리즈 그룹)에 맞게 조정하세요. 값을 늘리면 열 사이의 간격이 넓어지고, 값을 줄이면 더 가깝게 배치됩니다.