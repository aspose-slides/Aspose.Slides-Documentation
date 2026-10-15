---
title: 使用 JavaScript 在簡報中自訂圖表坐標軸
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
description: "探索如何使用 Aspose.Slides for Node.js via Java 搭配 JavaScript，在 PowerPoint 簡報中自訂圖表坐標軸，以用於報告與視覺化。"
---
## **概覽**

本文說明如何使用 Aspose.Slides for Node.js via Java 來自訂圖表坐標軸。內容包括計算坐標軸值、切換圖表列與欄、坐標軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、坐標軸定位、顯示單位以及對數比例。

## **取得圖表垂直坐標軸的最大值**

建立一個[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)，並加入具有預設資料的區域圖表。在讀取計算後的坐標軸值之前，呼叫[validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/)以確保圖表版面配置為最新。

讀取[getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/)和[getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/)以取得坐標軸限制，並使用[getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/)和[getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/)取得刻度間隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/)和[getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/)提供時間單位比例，與日期坐標軸相關。範例將這些值儲存於區域變數，並儲存圖表。

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

## **交換坐標軸之間的資料**

使用[switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/)交換圖表資料中系列與類別的角色。先前的每個類別變為系列，先前的每個系列變為類別。這會改變資料的分組方式；不會交換水平與垂直坐標軸。範例在切換列與欄之前，使用[setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/)將預設資料綁定至 `Sheet1!A1:D5`（包含標頭列與類別欄）。最後儲存一個具有四個系列與三個類別的圖表。

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

## **反轉坐標軸的繪製順序**

使用[setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/)反轉類別或數值坐標軸。例如，水平長條圖可以依照工作表中的順序由上至下顯示專案階段：規劃、開發、測試。反轉坐標軸只改變繪製方向，並不會排序或重新排列工作表資料。相較之下，[switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/)是交換系列與類別的角色。

以下範例建立一個具有三個階段與一個系列的水平長條圖，並產生三張投影片：正常順序、反轉類別、反轉數值。每個副本使用相同的資料集，且每張投影片僅反轉一個坐標軸。

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

    // 投影片 2：將第一個類別顯示在頂部。
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // 保持水平數值坐標軸在底部。
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // 投影片 3：僅反轉水平數值刻度。
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

反轉坐標軸也可以將垂直坐標軸移至圖表的對側。[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/)控制另一坐標軸在被設定坐標軸上的交叉位置。在第 2 張投影片中，於反轉的類別坐標軸上以 `aspose.slides.CrossesType.Maximum` 呼叫，可將水平數值坐標軸保持在底部。若需特定交叉點，請使用[setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/)。變更方向時務必檢查交叉設定，特別是圖表已自訂交叉點的情況。使用 `false` 呼叫 `setPlotOrderReversed` 可恢復正常繪製方向；交叉設定是獨立的。

| 正常順序（投影片 1） | 反轉類別（投影片 2） | 反轉數值（投影片 3） |
| --- | --- | --- |
| ![水平長條圖，類別與數值坐標軸順序為正常](axis-order-normal.png) | ![水平長條圖，類別由上至下顯示](axis-order-categories-reversed.png) | ![水平長條圖，數值坐標軸反向且零位於右側](axis-order-values-reversed.png) |
| 類別由下至上；數值由左至右遞增。 | 規劃、開發與測試由上至下排列。數值與工作表列順序保持不變。 | 類別保持正常順序；數值由右至左遞增。類別坐標軸於右側零點相交。 |

## **停用折線圖的垂直坐標軸**

在垂直坐標軸上呼叫[setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/)並傳入 `false` 以隱藏它。範例建立一個具有預設資料的折線圖，並以隱藏垂直坐標軸的方式儲存。

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

## **停用折線圖的水平坐標軸**

在水平坐標軸上呼叫[setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/)並傳入 `false` 以隱藏它。範例建立一個具有預設資料的折線圖，並以隱藏水平坐標軸的方式儲存。

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

## **變更類別坐標軸**

使用[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/)可選擇日期或文字類別坐標軸。此範例需要 `ExistingChart.pptx`，其中圖表是第一張投影片的第一個圖形，且類別儲存格包含數字式 Excel 日期值。它將水平坐標軸改為日期坐標軸。將[setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/)設定為 `false`，[setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) 設為 `1`，且[setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) 設為 `TimeUnitType.Months`，即可在一個月間隔放置主要刻度。

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

## **控制類別坐標軸標籤間隔**

當圖表具有許多類別時，可減少可見的坐標軸標籤數量，而不必移除類別或資料點。先以 `false` 呼叫[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/)，再將想要的類別間隔傳入[setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/)。對於正常順序的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | 類別 1, 類別 2, 類別 3, ... 類別 24 |
| `2` | 類別 1, 類別 3, 類別 5, ... 類別 23 |
| `3` | 類別 1, 類別 4, 類別 7, ... 類別 22 |

間隔為 `3` 時會顯示每三個標籤，顯示的標籤之間會隱藏兩個標籤。這不會移除相對應的欄位。自動間隔會根據可用空間選擇間隔，未必會顯示每一個標籤。

刻度線有獨立的控制方式。以 `false` 呼叫[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/)，再使用[setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/)設定它們的間隔。例如，`1` 會在每個類別間隔保留一個刻度線，而標籤僅每第三個類別顯示。使用[setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/)搭配可見樣式，以便看到結果。再次以 `true` 呼叫任一自動間隔設定器，圖表會重新選擇間隔。

以下自包含範例建立 24 個類別與一個系列，然後在 `CategoryAxisIntervals.pptx` 中儲存三張投影片：自動間隔、手動標籤間隔（刻度線獨立）、以及恢復自動間隔。兩個副本保留原始圖表資料。無需輸入投影片。水平標籤文字使密度差異一目了然。

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

    // 投影片 2：顯示每第三個標籤，但為每個類別保留刻度線。
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 投影片 3：讓圖表再次自行選擇兩個間隔。
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自動間距（第 1 張投影片）：** 在此呈現中，每第二個類別標籤會顯示，且會換行成兩行。自動結果會因圖表大小、字型與渲染器而異。

![自動類別標籤間距，顯示全部 24 欄](category-axis-automatic.png)

**手動間距（第 2 張投影片）：** 每第三個標籤會顯示在同一行，且刻度線仍保留在每個類別間隔。所有 24 個欄位（包括未顯示標籤的欄位）仍保持可見且數值相同。第 3 張投影片恢復如上圖所示的自動外觀。

![手動類別標籤間隔為三，顯示全部 24 欄](category-axis-manual.png)

### **選擇正確的坐標軸與間隔**

對文字類別坐標軸（例如柱狀圖、折線圖、面積圖或長條圖的類別坐標軸）使用此類別計數間隔。在柱狀圖中，它是水平坐標軸；在水平長條圖中，類別坐標軸是垂直的，請將這些設定套用至[getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/)回傳的坐標軸。刻度線間隔亦適用於具有系列坐標軸的圖表。

不要使用類別標籤間隔來設定數值坐標軸的數值刻度。在數值坐標軸上，[setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) 指定值的差異：例如，`10` 的主要單位會在 0、10、20 等位置產生刻度，前提是坐標軸從零開始。類別標籤間隔 `3` 則是計算類別位置，與資料值無關。散佈圖與氣泡圖使用數值坐標軸而非文字類別坐標軸。對於日期坐標軸，請依照[變更類別坐標軸](#變更類別坐標軸)中所述使用基於時間的主要單位與比例。

## **設定類別坐標軸值的日期格式**

此範例以四筆年度值取代預設圖表資料。日期以 OLE Automation 序號儲存在第一個工作表（索引 `0`）中，計算方式為自 1899 年 12 月 30 日以來的天數。JavaScript 計算使用 UTC 時間戳記，並將差值除以每天 86,400,000 毫秒。使用[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/)並傳入 `CategoryAxisType.Date`，呼叫[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/)傳入 `false`，再以 `yyyy` 呼叫[setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/)；這樣類別標籤會以四位數年份顯示，且不受儲存格格式影響。

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

## **設定圖表坐標軸標題的旋轉角度**

在垂直坐標軸上呼叫[setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/)並傳入 `true`，提供標題文字，然後使用[setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/)將標題旋轉。角度以度數計算；此範例將柱狀圖的數值坐標軸標題旋轉 90 度後儲存。

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

## **設定類別或數值坐標軸的位置**

使用[setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/)控制數值坐標軸是於類別坐標軸的類別之間還是於類別刻度標記上交叉。此設定僅適用於類別坐標軸。範例在柱狀圖的水平類別坐標軸上將其設為 `true`，然後儲存結果。

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

## **設定圖表數值坐標軸的顯示單位**

使用[setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/)可在不變更底層資料的情況下調整數值坐標軸標籤的比例。將[DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) 設為 `Millions`，則 60,000,000 會顯示為 60。範例建立一個柱狀圖，並將垂直坐標軸的顯示單位設定為百萬。

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

## **設定對數數值坐標軸**

當正值跨越多個數量級時，對數數值坐標軸相當有用。例如，某服務在五個期間內分別收到 10、100、1,000、10,000 與 100,000 筆請求。若使用線性比例，較小的值會聚集在接近零的區域。對數比例使它們的相對增長更容易比較：相等的距離代表相等的比例，而非相等的差值。

在數值坐標軸上以 `true` 呼叫[setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/)，並使用[setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/)選擇基底。這會改變既有值的顯示方式，並不會改變資料或加入對數趨勢線。趨勢線是對資料中關係的擬合，屬於另一項功能。

### **選擇數值坐標軸與基底**

對於折線圖或柱狀圖，數值坐標軸可由[getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/)取得。對於水平長條圖，則由[getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/)取得。散佈圖與氣泡圖有兩個數值坐標軸，請為 X 值選擇水平坐標軸，為 Y 值選擇垂直坐標軸，或兩者皆設定。不要對類別坐標軸套用對數比例。

預設的對數基底為 `10`。對於 PPTX 圖表，基底可設定為 `2` 至 `1000`（含），亦支援 `2.5` 等分數基底。以基底 `10` 為例，10、100、1,000、10,000 等次方會等距分布。

### **比較線性與對數比例**

以下自包含範例在第 1 張投影片建立一個包含五筆請求計數的折線圖，接著複製該投影片並於第 2 張啟用以 10 為底的對數數值坐標軸。兩張投影片保留相同資料。

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

    // 保持第一張投影片為線性，且僅變更複本的數值坐標軸比例。
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

**線性比例（投影片 1）：** 相等的垂直距離代表相等的請求數差異。最大的值佔主導，較小的值較難辨識。

![PowerPoint 折線圖，線性數值坐標軸上顯示五筆請求數量](value-axis-linear.png)

**對數比例（投影片 2）：** 相等的垂直距離代表相等的比例。每個期間的請求量是前一個的十倍，因此在底數 10 的比例上點形成筆直上升的線。坐標軸標籤仍顯示原始的請求數量。

![PowerPoint 折線圖，於底數 10 的對數數值坐標軸上顯示相同的五筆請求數量](value-axis-logarithmic.png)

### **處理零與負值**

對數比例只能顯示嚴格正值。啟用前請先檢查資料。若零或負值具有意義，請保留線性比例或另行顯示。若將這些值排除符合分析需求，請說明排除的原因。切勿悄悄將它們替換為小的正值，因為這會改變資料的意義。任何手動設定的對數坐標軸最小值或最大值亦必須為正。

## **常見問題**

**如何設定坐標軸交叉的數值（坐標軸交叉點）？**

使用[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/)選擇交叉行為。若要指定數值交叉點，請使用[setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/)。這些設定讓您將坐標軸交叉點移至適當的基線位置。

**如何相對於坐標軸定位刻度標籤？**

呼叫[setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/)並使用[TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/)：`Low`、`High`、`NextTo` 或 `None`。若要控制刻度線本身，請使用[setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/)或[setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/)，這與標籤位置是分開的設定。