---
title: 使用 JavaScript 自訂簡報中的圖表軸
linktitle: 圖表軸
type: docs
url: /zh-hant/nodejs-java/chart-axis/
keywords:
- 圖表軸
- 垂直軸
- 水平軸
- 自訂軸
- 操作軸
- 管理軸
- 軸屬性
- 最大值
- 最小值
- 軸線
- 日期格式
- 軸標題
- 軸位置
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 JavaScript 搭配 Aspose.Slides for Node.js（透過 Java）在 PowerPoint 簡報中自訂圖表軸，以用於報告與視覺化。"
---
## **概覽**

本文說明如何使用 Aspose.Slides for Node.js（透過 Java）自訂圖表軸。內容涵蓋計算軸值、切換圖表的列與行、軸的可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、軸位置、顯示單位以及對數比例。

## **取得圖表垂直軸的最大值**

建立一個 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 並加入預設資料的區域圖。於讀取計算後的軸值之前，先呼叫 [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/)，以確保圖表版面已更新。

讀取 [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) 與 [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) 以取得軸的上限與下限，並使用 [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) 與 [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) 取得刻度間隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) 與 [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) 提供時間單位的比例，適用於日期軸。範例將這些值存入本機變數，並儲存圖表。

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

## **交換軸之間的資料**

使用 [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) 交換圖表資料中系列 (series) 與類別 (categories) 的角色。原先的每個類別會變成系列，而原先的每個系列會變成類別。此操作會改變資料的分組方式，但不會交換水平與垂直軸。範例在切換列與行之前，使用 [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) 將預設資料繫結至 `Sheet1!A1:D5`（包含標題列與類別欄）。最後儲存一個包含四個系列與三個類別的圖表。

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

## **反轉軸的繪製順序**

使用 [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) 反轉類別軸或數值軸。例如，水平長條圖可依工作表的相同順序（規劃、開發、測試），從上至下顯示專案階段。反轉軸會改變繪製方向；不會對工作表資料進行排序或重新排列。相比之下，[switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) 交換系列與類別的角色。

以下範例建立一個包含三個階段與一個系列的水平長條圖，並儲存一個包含三張投影片的簡報：正常順序、類別反轉、數值反轉。每個副本使用相同的資料集，且每張投影片僅反轉一個軸。

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
    // 保持水平數值軸在底部。
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

反轉軸亦可將垂直軸移至圖表的相對側。[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) 控制另一條軸在被設定軸的交叉位置。在第 2 張投影片中，於反轉的類別軸上使用 `aspose.slides.CrossesType.Maximum`，可使水平數值軸保留在底部。若需指定特定交叉點，請使用 [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/)。變更方向時請檢查交叉設定，特別是圖表已有自訂交叉點的情況。以 `false` 呼叫 `setPlotOrderReversed` 可恢復正常繪製方向；交叉設定則獨立存在。

| 正常順序（投影片 1） | 類別反轉（投影片 2） | 數值反轉（投影片 3） |
| --- | --- | --- |
| ![水平長條圖，類別與數值軸順序正常](axis-order-normal.png) | ![水平長條圖，類別自上而下顯示](axis-order-categories-reversed.png) | ![水平長條圖，數值軸反轉且零位於右側](axis-order-values-reversed.png) |
| 類別由底部向上排列；數值由左至右遞增。 | 規劃、開發、測試由上而下排列。數值與工作表列順序保持不變。 | 類別保持正常順序；數值由右至左遞增。類別軸在右側的零點交叉。 |

## **為折線圖停用垂直軸**

於垂直軸上呼叫 [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) 並傳入 `false` 以隱藏該軸。範例建立一個預設資料的折線圖，並以隱藏垂直軸的方式儲存。

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

## **為折線圖停用水平軸**

於水平軸上呼叫 [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) 並傳入 `false` 以隱藏該軸。範例建立一個預設資料的折線圖，並以隱藏水平軸的方式儲存。

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

## **顯示或隱藏圖表格線**

呼叫 [getShowMajorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowmajorgridlines/) 與 [getShowMinorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowminorgridlines/) 可檢查軸顯示哪種格線。若要顯示次格線，使用 [getMinorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getminorgridlinesformat/) 並將線條填色設為實心且可見的顏色。若要隱藏，將填色設定為 [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/)。同理，可使用 [getMajorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getmajorgridlinesformat/) 變更主格線的線條填色。變更填色不會影響軸的可見性與刻度標記。

此群組直條圖的垂直軸最初僅顯示主格線。範例先將次格線以深橙色顯示，接著再次隱藏，最後儲存簡報。每個步驟皆列印格線的可見性。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 30, 660, 230);
    var axis = chart.getAxes().getVerticalAxis();
    console.log("Initial: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    var minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    var darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    minorFill.getSolidFillColor().setColor(darkOrange);
    console.log("Enabled: minor=%s", axis.getShowMinorGridLines());

    minorFill.setFillType(java.newByte(aspose.slides.FillType.NoFill));
    console.log("Hidden: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 次格線已啟用 | 次格線已隱藏 |
| --- | --- |
| ![垂直軸上主格線之間的橙色次格線](minor-gridlines-enabled.png) | ![相同的直條圖，僅顯示主格線](minor-gridlines-hidden.png) |

## **變更類別軸**

使用 [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) 以選擇日期或文字類別軸。此範例需要 `ExistingChart.pptx`，其第一張投影片的第一個圖形是一個圖表，類別儲存格內含 Excel 數值日期。它會將水平軸變更為日期軸。呼叫 [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) 並傳入 `false`、[setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) 傳入 `1`，以及 [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) 傳入 `TimeUnitType.Months`，即可將主刻度設為每月一次。

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

### **根據資料判斷類別軸類型**

在填入類別後呼叫 [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistypeautomatically/)，然後讀取 [getCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getcategoryaxistype/) 以檢查選取結果。當相同圖表可能接收文字標籤或數值日期時，這相當有用。此方法在呼叫時即決定類型，並不會在之後的資料變更時重新評估。更換類別後請再次呼叫。

以下範例建立一個文字類別的圖表，當選取類型為 `CategoryAxisType.Text` 時會印出 `true`。接著將類別儲存格的值改為日期，再次呼叫方法，若選取類型為 `CategoryAxisType.Date`，同樣印出 `true`。日期以數值 OLE Automation 序號儲存，計算方式為自 1899 年 12 月 30 日起的天數，而非日期字串。JavaScript 計算使用 UTC 時間戳並以每日 86,400,000 毫秒作除算；月份索引從零開始。使用 `java.newDouble` 可將每個日期值以 double 形式傳遞給 Java。[setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) 控制這些值的顯示方式，並不會將文字轉為數值日期。更多關於類別儲存格的資訊，請參閱 [Chart Workbook](/slides/zh-hant/nodejs-java/chart-workbook/)。

在已知輸入僅包含文字類別或數值日期時，使用自動判斷。對於普通數值標籤、混合類別或空資料，請明確呼叫 [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) 以符合預期含義。僅有數值本身並不會自動視為日期類別。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var seriesName = workbook.getCell(0, 0, 1, "Sales");
    var series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    var labels = ["First", "Second", "Third"];

    for (var i = 0; i < labels.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Text); // true

    var baseDate = Date.UTC(1899, 11, 30);
    var dates = [Date.UTC(2026, 0, 1), Date.UTC(2026, 0, 2), Date.UTC(2026, 1, 1)];

    for (var i = 0; i < dates.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0);
        var dateValue = java.newDouble((dates[i] - baseDate) / 86400000);
        categoryCell.setValue(dateValue);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Date); // true

    presentation.save("AutomaticCategoryAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制類別軸標籤間隔**

當圖表擁有大量類別時，可降低可見軸標籤的數量，而不必移除類別或資料點。呼叫 [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) 並傳入 `false`，再將欲使用的類別間隔傳給 [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/)。對於文字類別的正常順序，計算從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

間隔為 `3` 時會顯示每第三個標籤，兩個未顯示的標籤位於兩個顯示標籤之間。此操作不會移除相對應的欄位。自動間隔會根據可用空間自動選擇間隔，未必會顯示全部標籤。

刻度標記亦有獨立的控制。呼叫 [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) 並傳入 `false`，再使用 [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) 設定其間隔。例如，`1` 會在每個類別間隔保留刻度標記，而標籤只每三個類別顯示一次。使用 [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) 設定可見樣式，以便觀察結果。再次將任一自動間隔設定器傳入 `true`，圖表會重新自動選擇間隔。

以下獨立範例建立 24 個類別與一個系列，然後在 `CategoryAxisIntervals.pptx` 中儲存三張投影片：自動間隔、手動標籤間隔（刻度標記獨立）、以及恢復自動間隔。兩個副本保留原始圖表資料。此範例不需要輸入簡報。水平標籤文字使密度差異一目了然。

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

    // 投影片 2：顯示每三個標籤，但保留每個類別的刻度標記。
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 投影片 3：讓圖表再次自行選擇兩種間隔。
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自動間隔（投影片 1）：** 在此呈現中，每兩個類別標籤顯示一次，且會換行成兩行。自動結果可能因圖表大小、字型與渲染器而異。

![自動類別標籤間隔，顯示全部 24 欄](category-axis-automatic.png)

**手動間隔（投影片 2）：** 每三個標籤顯示在同一行，且刻度標記仍保留於每個類別間隔。所有 24 個欄位（包括未顯示標籤的欄位）仍保持可見且數值相同。投影片 3 會恢復如上圖所示的自動外觀。

![手動類別標籤間隔為三，顯示全部 24 欄](category-axis-manual.png)

### **選擇正確的軸與間隔**

此類別計數間隔適用於文字類別軸，例如直條圖、折線圖、區域圖或長條圖的類別軸。於直條圖中，它是水平軸；於水平長條圖中，類別軸為垂直軸，請對由 [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) 回傳的軸套用這些設定。刻度標記間隔同樣適用於具有系列軸的圖表。

請勿使用類別標籤間隔來設定數值軸的數值刻度。於數值軸上， [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) 指定的是值的差異：例如，`10` 的主單位會在 0、10、20… 等位置產生刻度，前提是軸從零開始。類別標籤間隔 `3` 則是計算類別位置，與資料值無關。散點圖與氣泡圖使用的是數值軸而非文字類別軸。若使用日期軸，請參考 [變更類別軸](#變更類別軸) 中的時間單位設定。

## **設定類別軸值的日期格式**

此範例將預設圖表資料取代為四筆年度值。日期以 OLE Automation 數值儲存在第一個工作表（索引 `0`）中，計算方式為自 1899 年 12 月 30 日起的天數。JavaScript 計算使用 UTC 時間戳並以每日 86,400,000 毫秒作除算。使用 [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) 並傳入 `CategoryAxisType.Date`，再呼叫 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) 傳入 `false`，最後將 `yyyy` 傳給 [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) ，即可使類別標籤顯示四位數年份，且不受儲存格格式影響。

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

## **設定圖表軸標題的旋轉角度**

於垂直軸呼叫 [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) 並傳入 `true`，提供標題文字，接著使用 [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) 以度數旋轉標題。本範例將直條圖的數值軸標題旋轉 90 度後儲存。

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

## **設定類別軸或數值軸的位置**

使用 [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) 以控制數值軸是在類別軸的類別之間交叉，或是在類別刻度標記處交叉。此設定僅套用於類別軸。範例於直條圖的水平類別軸上將其設為 `true`，並儲存結果。

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

## **設定圖表數值軸的顯示單位**

使用 [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) 可在不變更底層資料的情況下調整數值軸標籤的顯示比例。將 [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) 設為 `Millions`，則 60,000,000 會顯示為 60。本範例建立一個直條圖，並將其垂直軸的顯示單位設定為百萬。

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

## **設定對數數值軸**

當正值跨越多個數量級時，對數數值軸非常有用。例如，某服務在五個時段分別收到 10、100、1,000、10,000、100,000 筆請求。若使用線性比例，較小的數值會集中在接近零的區域。對數比例則讓相對增長更易比較：相等的距離代表相等的比例，而非相等的差值。

於數值軸呼叫 [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) 並傳入 `true`，再使用 [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) 以選擇底數。此設定僅改變現有值的顯示方式，並不會改變資料或加入對數趨勢線。趨勢線是資料的擬合關係，屬於另一項功能。

### **選擇數值軸與底數**

對於折線圖或直條圖，數值軸由 [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) 取得。對於水平長條圖，則由 [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) 取得。散點圖與氣泡圖有兩條數值軸，請為 X 軸使用水平軸，為 Y 軸使用垂直軸，或同時設定。請勿將對數比例套用於類別軸。

預設的對數底數為 `10`。對於 PPTX 圖表，底數可設定為 `2`~`1000`（含），亦支援小數底數，如 `2.5`。以底數 `10` 時，10、100、1,000、10,000 等次方會等距分布。

### **比較線性與對數比例**

以下獨立範例於第一張投影片建立一個顯示五筆請求量的折線圖，然後複製該投影片，於第二張投影片啟用底數為 10 的對數數值軸。兩張投影片均保留相同資料。

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

    // 保持第一張投影片為線性，且僅更改副本的數值軸比例。
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

**線性比例（投影片 1）：** 等距的垂直距離代表請求量的相等差異。最高值會主導圖表，使較小的數值難以辨識。

![PowerPoint 中的折線圖，於線性數值軸上顯示五個請求量](value-axis-linear.png)

**對數比例（投影片 2）：** 等距的垂直距離代表相等的比例。每個時段的請求量皆是前一時段的十倍，因此在底數 10 的比例下，點會形成一條直線上升。軸標籤仍顯示原始的請求量。

![PowerPoint 中相同的五個請求量，於底數為 10 的對數數值軸上](value-axis-logarithmic.png)

### **處理零與負值**

對數比例只能顯示嚴格正值，啟用前請先檢查資料。若零或負值具有實際意義，請保留線性比例或另行顯示。若將這些值排除於分析之外，請說明排除的原因。切勿以小的正數悄悄取代，因為會改變資料意義。任何手動設定的最小值或最大值於對數軸上亦必須為正值。

## **常見問題**

**如何設定一個軸與另一個軸交叉的數值（軸交叉）？**

使用 [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) 以選擇交叉行為。若要指定數值交叉點，請使用 [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/)。這些設定可將軸交叉點移至適當的基準線上。

**如何相對於軸定位刻度標籤？**

呼叫 [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) 並使用 [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) 的 `Low`、`High`、`NextTo` 或 `None`。若要控制刻度標記本身，請使用 [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) 或 [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/)，這與標籤位置設定是分開的。