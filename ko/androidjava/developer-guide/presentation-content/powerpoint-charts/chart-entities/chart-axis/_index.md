---
title: Android에서 프레젠테이션의 차트 축 사용자 지정
linktitle: 차트 축
type: docs
url: /ko/androidjava/chart-axis/
keywords:
- 차트 축
- 수직 축
- 수평 축
- 축 사용자 지정
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
- Android
- Java
- Aspose.Slides
description: 보고서와 시각화를 위한 PowerPoint 프레젠테이션에서 차트 축을 사용자 지정하기 위해 Aspose.Slides for Android via Java를 사용하는 방법을 알아보세요.
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 축을 사용자 지정하는 방법을 설명합니다. 실제 축 값을 가져오는 방법, 축 간 데이터 교환, 선 차트에서 수직 또는 수평 축 숨기기, 범주 축 유형 변경, 범주 축 값에 대한 날짜 형식 설정, 축 제목 회전, 축 위치 설정 및 값 축에 단위 레이블 표시 방법을 보여줍니다.

## **차트의 수직 축에서 최대값 가져오기**
Aspose.Slides for Android via Java를 사용하면 수직 축의 최소값과 최대값을 얻을 수 있습니다. 다음 단계를 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 액세스합니다.
1. 기본 데이터가 있는 차트를 추가합니다.
1. 축의 실제 최대값을 가져옵니다.
1. 축의 실제 최소값을 가져옵니다.
1. 축의 실제 주요 단위를 가져옵니다.
1. 축의 실제 보조 단위를 가져옵니다.
1. 축의 실제 주요 단위 눈금을 가져옵니다.
1. 축의 실제 보조 단위 눈금을 가져옵니다.

위 단계의 구현 예시인 이 샘플 코드는 Java에서 필요한 값을 가져오는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// 프레젠테이션을 저장합니다
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **축 사이의 데이터 교환**
Aspose.Slides를 사용하면 축 간 데이터를 빠르게 교환할 수 있습니다—수직 축(y축)에서 표시되는 데이터가 수평 축(x축)으로 이동하고 그 반대도 마찬가지입니다.

다음 Java 코드는 차트에서 축 간 데이터 교환 작업을 수행하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//행과 열을 전환합니다
	chart.getChartData().switchRowColumn();

	// 프레젠테이션 저장
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **선 차트에서 수직 축 비활성화**

다음 Java 코드는 선 차트에서 수직 축을 숨기는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getVerticalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **선 차트에서 수평 축 비활성화**

다음 코드는 선 차트에서 수평 축을 숨기는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getHorizontalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **범주 축 변경**

**CategoryAxisType** 속성을 사용하여 원하는 범주 축 유형(**date** 또는 **text**)을 지정할 수 있습니다. 다음 Java 코드는 해당 작업을 시연합니다:

```java
Presentation presentation = new Presentation("ExistingChart.pptx");
try {
	IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
	chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
	chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
	chart.getAxes().getHorizontalAxis().setMajorUnit(1);
	chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);
	presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

## **범주 축 값에 대한 날짜 형식 설정**
Aspose.Slides for Android via Java를 사용하면 범주 축 값에 대한 날짜 형식을 설정할 수 있습니다. 다음 Java 코드에서 이 작업을 시연합니다:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
	
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public static String convertToOADate(GregorianCalendar date) throws ParseException
{
    double oaDate;
    SimpleDateFormat myFormat = new SimpleDateFormat("dd MM yyyy");
    java.util.Date baseDate = myFormat.parse("30 12 1899");
    Long days = TimeUnit.DAYS.convert(date.getTimeInMillis() - baseDate.getTime(), TimeUnit.MILLISECONDS);
    oaDate = (double) days + ((double) date.get(Calendar.HOUR_OF_DAY) / 24) + ((double) date.get(Calendar.MINUTE) / (60 * 24)) + ((double) date.get(Calendar.SECOND) / (60 * 24 * 60));
    return String.valueOf(oaDate);
}
```

## **차트 축 제목의 회전 각도 설정**
Aspose.Slides for Android via Java를 사용하면 차트 축 제목의 회전 각도를 설정할 수 있습니다. 다음 Java 코드가 이 작업을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

## **범주 또는 값 축에서 축 위치 설정**
Aspose.Slides for Android via Java를 사용하면 범주 축 또는 값 축에서 축 위치를 설정할 수 있습니다. 다음 Java 코드는 작업 수행 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **차트 값 축에 단위 레이블 표시 활성화**
Aspose.Slides for Android via Java를 사용하면 차트 값 축에 단위 레이블을 표시하도록 차트를 구성할 수 있습니다. 다음 Java 코드가 이 작업을 시연합니다:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**축이 다른 축과 교차하는 값을 어떻게 설정합니까?**

축은 [crossing setting](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/axis/#setCrossType-int-)을 제공하며, 0에서 교차하도록 하거나, 최대 범주/값에서 교차하도록 하거나, 특정 숫자값에서 교차하도록 선택할 수 있습니다. 이는 X축을 위아래로 이동하거나 기준선을 강조할 때 유용합니다.

**축에 대한 눈금 레이블 위치를 어떻게 지정합니까(축 옆, 외부, 내부)?**

[label position](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-)을 "cross", "outside", "inside" 중 하나로 설정합니다. 이는 가독성에 영향을 주며 특히 작은 차트에서 공간 절약에 도움이 됩니다.