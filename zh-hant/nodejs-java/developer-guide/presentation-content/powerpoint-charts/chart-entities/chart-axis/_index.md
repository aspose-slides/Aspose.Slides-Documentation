---
title: 使用 JavaScript 自訂簡報中的圖表坐標軸
linktitle: 圖表坐標軸
type: docs
url: /zh-hant/nodejs-java/chart-axis/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 JavaScript 搭配 Aspose.Slides for Node.js via Java 於 PowerPoint 簡報中自訂圖表坐標軸，以用於報告與視覺化。"
---
## **概觀**

本篇文章說明如何在 Aspose.Slides 中自訂圖表坐標軸。它展示了如何取得實際坐標軸值、在坐標軸之間交換資料、隱藏折線圖的垂直或水平坐標軸、變更類別坐標軸類型、設定類別坐標軸值的日期格式、旋轉坐標軸標題、設定坐標軸位置，以及在數值坐標軸上顯示單位標籤。

## **取得圖表垂直坐標軸的最大值**

Aspose.Slides for Node.js via Java 允許您取得垂直坐標軸的最小值與最大值。請依循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
1. 存取第一張投影片。
1. 新增具有預設資料的圖表。
1. 取得坐標軸的實際最大值。
1. 取得坐標軸的實際最小值。
1. 取得坐標軸的實際主單位。
1. 取得坐標軸的實際次單位。
1. 取得坐標軸的實際主單位比例。
1. 取得坐標軸的實際次單位比例。

以下範例程式碼（上述步驟的實作）示範如何在 JavaScript 中取得所需的值：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // 儲存簡報
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在坐標軸之間交換資料**

Aspose.Slides 允許您快速在坐標軸之間交換資料——垂直坐標軸（y 軸）上的資料會移至水平坐標軸（x 軸），反之亦然。

以下 JavaScript 程式碼示範如何在圖表上執行坐標軸資料交換的操作：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // 切換列與欄
    chart.getChartData().switchRowColumn();
    // 儲存簡報
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在折線圖中停用垂直坐標軸**

以下 JavaScript 程式碼示範如何隱藏折線圖的垂直坐標軸：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在折線圖中停用水平坐標軸**

以下程式碼示範如何隱藏折線圖的水平坐標軸：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **變更類別坐標軸**

使用 **CategoryAxisType** 屬性，您可以指定首選的類別坐標軸類型（**date** 或 **text**）。以下 JavaScript 程式碼示範此操作：

```javascript
var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **設定類別坐標軸值的日期格式**

Aspose.Slides for Node.js via Java 允許您設定類別坐標軸值的日期格式。以下 JavaScript 程式碼示範此操作：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
const dayjs = require('dayjs');

function convertToOADate(date) {
    const baseDate = dayjs('1899-12-30');

    const days = date.diff(baseDate, 'day');

    const fractionalDay = (date.hour() / 24) +
                          (date.minute() / (60 * 24)) +
                          (date.second() / (60 * 24 * 60));

    const oaDate = days + fractionalDay;

    return String(oaDate);
}
```

## **設定圖表坐標軸標題的旋轉角度**

Aspose.Slides for Node.js via Java 允許您設定圖表坐標軸標題的旋轉角度。以下 JavaScript 程式碼示範此操作：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定類別或數值坐標軸的位置**

Aspose.Slides for Node.js via Java 允許您設定類別或數值坐標軸的位置。以下 JavaScript 程式碼示範如何執行此任務：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在圖表數值坐標軸上顯示單位標籤**

Aspose.Slides for Node.js via Java 允許您設定圖表在其數值坐標軸上顯示單位標籤。以下 JavaScript 程式碼示範此操作：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**如何設定兩坐標軸交叉的值（坐標軸交叉）？**

坐標軸提供 [crossing 設定](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/axis/setcrosstype/)：您可以選擇在零點、最高類別/數值或特定數值處交叉。此功能可用於將 X 軸向上或向下移動，或強調基線。

**如何將刻度標籤相對於坐標軸定位（旁邊、外側、內側）？**

將 [label position](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/axis/setmajortickmark/) 設為 "cross"、"outside" 或 "inside"。此設定會影響可讀性，並有助於節省空間，特別是在小型圖表上。