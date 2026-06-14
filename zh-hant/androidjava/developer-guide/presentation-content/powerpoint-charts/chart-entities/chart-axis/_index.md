---
title: 在 Android 上的簡報中自訂圖表座標軸
linktitle: 圖表座標軸
type: docs
url: /zh-hant/androidjava/chart-axis/
keywords:
- 圖表座標軸
- 垂直座標軸
- 水平座標軸
- 自訂座標軸
- 操作座標軸
- 管理座標軸
- 座標軸屬性
- 最大值
- 最小值
- 座標軸線
- 日期格式
- 座標軸標題
- 座標軸位置
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 在 PowerPoint 簡報中自訂圖表座標軸，以製作報告與視覺化呈現。"
---
## **概述**

本文說明如何在 Aspose.Slides 中自訂圖表座標軸。它展示如何取得實際座標軸值、在座標軸之間交換資料、隱藏折線圖的垂直或水平座標軸、更改類別座標軸類型、設定類別座標軸值的日期格式、旋轉座標軸標題、設定座標軸位置，並在值座標軸上顯示單位標籤。

## **取得圖表垂直座標軸的最大值**
Aspose.Slides for Android via Java 允許您取得垂直座標軸的最小值與最大值。請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
2. 取得第一張投影片。
3. 新增一個具有預設資料的圖表。
4. 取得座標軸的實際最大值。
5. 取得座標軸的實際最小值。
6. 取得座標軸的實際主要單位。
7. 取得座標軸的實際次要單位。
8. 取得座標軸的實際主要單位比例。
9. 取得座標軸的實際次要單位比例。

此範例程式碼（上述步驟的實作）示範如何在 Java 中取得所需的值：

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// 儲存簡報
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **交換座標軸之間的資料**
Aspose.Slides 允許您快速交換座標軸之間的資料——垂直座標軸（y 軸）的資料會移至水平座標軸（x 軸），反之亦然。

以下 Java 程式碼示範如何在圖表上執行座標軸資料交換：

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// 切換列與欄
	chart.getChartData().switchRowColumn();

	// 儲存簡報
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **在折線圖中隱藏垂直座標軸**

以下 Java 程式碼示範如何在折線圖中隱藏垂直座標軸：

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

## **在折線圖中隱藏水平座標軸**

以下程式碼示範如何在折線圖中隱藏水平座標軸：

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

## **變更類別座標軸**

使用 **CategoryAxisType** 屬性，您可以指定喜好的類別座標軸類型（**date** 或 **text**）。以下 Java 程式碼示範此操作：

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

## **設定類別座標軸值的日期格式**
Aspose.Slides for Android via Java 允許您為類別座標軸值設定日期格式。此 Java 程式碼示範此操作：

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

## **設定圖表座標軸標題的旋轉角度**
Aspose.Slides for Android via Java 允許您設定圖表座標軸標題的旋轉角度。以下 Java 程式碼示範此操作：

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

## **設定類別或值座標軸的位置**
Aspose.Slides for Android via Java 允許您在類別或值座標軸上設定位置。以下 Java 程式碼示範如何執行此任務：

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

## **在圖表值座標軸上啟用顯示單位標籤**
Aspose.Slides for Android via Java 允許您設定圖表在值座標軸上顯示單位標籤。以下 Java 程式碼示範此操作：

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

## **常見問題**

**如何設定座標軸交叉的值（座標軸交叉點）？**

座標軸提供 [crossing setting](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/axis/#setCrossType-int-)：您可以選擇在零、最大類別/值或特定數值處交叉。此功能有助於上下調整 X 軸或突顯基線。

**如何在座標軸旁設定刻度標籤的位置（旁邊、外側、內側）？**

將 [label position](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) 設為 "cross"、"outside" 或 "inside"。此設定會影響可讀性，並有助於在小型圖表中節省空間。