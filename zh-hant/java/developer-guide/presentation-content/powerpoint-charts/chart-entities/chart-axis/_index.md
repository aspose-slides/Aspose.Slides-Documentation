---
title: 使用 Java 在簡報中自訂圖表坐標軸
linktitle: 圖表坐標軸
type: docs
url: /zh-hant/java/chart-axis/
keywords:
- 圖表坐標軸
- 垂直坐標軸
- 水平坐標軸
- 自訂坐標軸
- 操作坐標軸
- 管理坐標軸
- 坐標軸屬性
- 最大值
- 最小值
- 坐標軸線
- 日期格式
- 坐標軸標題
- 坐標軸位置
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 簡報中自訂圖表坐標軸，以便於報告和視覺化。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中自訂圖表坐標軸。它展示了如何取得實際坐標軸值、在坐標軸之間交換資料、隱藏折線圖的垂直或水平坐標軸、變更類別坐標軸類型、設定類別坐標軸值的日期格式、旋轉坐標軸標題、設定坐標軸位置，以及在值坐標軸上顯示單位標籤。

## **取得圖表垂直坐標軸的最大值**
Aspose.Slides for Java 允許您取得垂直坐標軸的最小值和最大值。請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
1. 取得第一張投影片。
1. 新增一個預設資料的圖表。
1. 取得坐標軸的實際最大值。
1. 取得坐標軸的實際最小值。
1. 取得坐標軸的實際主單位。
1. 取得坐標軸的實際次單位。
1. 取得坐標軸的實際主單位比例。
1. 取得坐標軸的實際次單位比例。

以下範例程式碼（上述步驟的實作）示範如何在 Java 中取得所需的值：

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

## **交換坐標軸間的資料**
Aspose.Slides 讓您能快速交換坐標軸之間的資料——垂直坐標軸（y 軸）的資料會移至水平坐標軸（x 軸），反之亦然。

此 Java 程式碼示範如何在圖表的坐標軸之間執行資料交換：

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

## **停用折線圖的垂直坐標軸**

此 Java 程式碼示範如何隱藏折線圖的垂直坐標軸：

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

## **停用折線圖的水平坐標軸**

此程式碼示範如何隱藏折線圖的水平坐標軸：

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

## **變更類別坐標軸**

使用 **CategoryAxisType** 屬性，您可以指定偏好的類別坐標軸類型（**date** 或 **text**）。以下 Java 程式碼示範此操作：

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

## **設定類別坐標軸值的日期格式**
Aspose.Slides for Java 允許您為類別坐標軸值設定日期格式。此 Java 程式碼示範此操作：

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

## **設定圖表坐標軸標題的旋轉角度**
Aspose.Slides for Java 允許您設定圖表坐標軸標題的旋轉角度。此 Java 程式碼示範此操作：

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

## **設定類別或值坐標軸的位置**
Aspose.Slides for Java 允許您在類別或值坐標軸上設定位置。此 Java 程式碼示範如何執行此任務：

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

## **啟用在圖表值坐標軸上顯示單位標籤**
Aspose.Slides for Java 允許您設定圖表在其值坐標軸上顯示單位標籤。此 Java 程式碼示範此操作：

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

**如何設定一個坐標軸與另一個坐標軸交叉的值（坐標軸交叉）？**

坐標軸提供了 [crossing setting](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/axis/#setCrossType-int-)：您可以選擇在零點、最大類別/值或特定數值處交叉。此功能有助於將 X 軸向上或向下移動，或突顯基線。

**如何相對於坐標軸定位刻度標籤（旁側、外側、內側）？**

設定 [label position](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/axis/#setMajorTickMark-int-) 為 "cross"、"outside" 或 "inside"。這會影響可讀性，並有助於在小型圖表上節省空間。