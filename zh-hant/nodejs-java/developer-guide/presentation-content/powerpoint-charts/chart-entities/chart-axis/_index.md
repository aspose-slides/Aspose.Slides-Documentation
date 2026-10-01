---
title: 使用 JavaScript 在簡報中自訂圖表座標軸
linktitle: 圖表座標軸
type: docs
url: /zh-hant/nodejs-java/chart-axis/
keywords:
- 圖表座標軸
- 縱軸
- 橫軸
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 JavaScript 搭配 Aspose.Slides for Node.js via Java，在 PowerPoint 簡報中自訂圖表座標軸，以製作報告與視覺化。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Node.js via Java 來自訂圖表座標軸。它涵蓋計算座標軸值、切換圖表列與欄、座標軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、座標軸定位以及顯示單位。

## **取得圖表縱軸的最大值**

建立一個[簡報](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 並新增帶有預設資料的區域圖。於讀取計算後的座標軸值之前呼叫[validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) 以確保圖表版面配置為最新狀態。

讀取[getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) 和[getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) 以取得座標軸上限與下限，並讀取[getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) 和[getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) 以取得刻度間隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) 和[getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) 提供時間單位比例，與日期座標軸相關。範例將這些值儲存於本機變數，並儲存圖表。

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

## **交換座標軸之間的資料**

使用[switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) 交換圖表資料中系列與類別的角色。每個原先的類別會變為系列，而每個原先的系列會變為類別。此動作會變更資料分組方式，但不會交換水平與垂直座標軸。範例在切換列與欄之前，使用[setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) 將預設資料綁定至`Sheet1!A1:D5`，包含標頭列與類別欄。它會儲存一個擁有四個系列與三個類別的圖表。

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

## **停用折線圖的縱軸**

在縱軸上呼叫[setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) 並傳入 `false` 以隱藏它。範例建立一個具有預設資料的折線圖，並以隱藏縱軸的方式儲存。

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

## **停用折線圖的水平軸**

在水平軸上呼叫[setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) 並傳入 `false` 以隱藏它。範例建立一個具有預設資料的折線圖，並以隱藏水平軸的方式儲存。

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

## **變更類別座標軸**

使用[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) 以選擇日期或文字類別座標軸。此範例需要 `ExistingChart.pptx`，其第一張投影片的第一個圖形為圖表，且類別儲存格包含數值型 Excel 日期。它會將水平座標軸變更為日期座標軸。呼叫[setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) 並傳入 `false`，[setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) 傳入 `1`，以及[setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) 傳入 `TimeUnitType.Months`，即可將主刻度設定為每月一次的間隔。

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

## **控制類別座標軸標籤間隔**

當圖表擁有許多類別時，可在不移除類別或資料點的前提下減少可見的座標軸標籤數量。呼叫[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) 並傳入 `false`，然後將所需的類別間隔傳遞給[setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/)。對於正常順序的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

間隔為 `3` 時會顯示每第三個標籤，於顯示的標籤之間隱藏兩個標籤。它不會移除相對應的欄位。自動間隔會根據可用空間選擇間隔；未必會顯示全部標籤。

刻度線有獨立的控制方式。呼叫[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) 並傳入 `false`，再使用[setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) 設定其間隔。例如，`1` 會在每個類別間隔保留刻度線，而標籤僅每第三個類別顯示一次。使用[setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) 並設定為可見樣式，以便觀察結果。再次將任一自動間隔設定為 `true`，即可讓圖表再次自動選擇間隔。

以下獨立範例會建立 24 個類別與一個系列，然後在 `CategoryAxisIntervals.pptx` 中儲存三張投影片：自動間隔、具獨立刻度線的手動標籤間隔，以及恢復自動間隔。兩個副本保留原始圖表資料。無需輸入投影片。水平標籤文字讓密度差異一目了然。

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

    // 第 2 張投影片：顯示每三個標籤，但為每個類別保留刻度線。
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 第 3 張投影片：讓圖表再次自行選擇兩種間隔。
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自動間隔 (第 1 張投影片)：** 在此呈現中，每第二個類別標籤會顯示並換行成兩行。自動結果可能因圖表尺寸、字型與渲染器而異。

![自動類別標籤間隔，顯示全部 24 欄位](category-axis-automatic.png)

**手動間隔 (第 2 張投影片)：** 每第三個標籤會顯示在單行上，而刻度線仍保留在每個類別間隔。所有 24 欄，包括未標記的欄位，都保持可見且值相同。第 3 張投影片恢復上述的自動外觀。

![手動類別標籤間隔為三，顯示全部 24 欄位](category-axis-manual.png)

### **選擇正確的座標軸與間隔**

對文字類別座標軸使用此類別計數間隔，例如柱狀圖、折線圖、區域圖或條形圖的類別座標軸。在柱狀圖中，它是水平座標軸；在水平條形圖中，類別座標軸是垂直的，因此請將此設定套用於由[getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) 取得的座標軸。刻度線間隔亦適用於具有系列座標軸的圖表。

請勿使用類別標籤間隔來設定值座標軸的數值刻度。在值座標軸上，[setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) 指定數值差異：例如，主單位為 `10` 時，若座標軸從零開始，則會在 0、10、20 等處產生刻度。類別標籤間隔 `3` 則是計算類別位置，與資料值無關。散佈圖與氣泡圖使用值座標軸而非文字類別座標軸。若為日期座標軸，請使用基於時間的主單位與比例，如[變更類別座標軸](#change-a-category-axis)所述。

## **設定類別座標軸值的日期格式**

此範例將預設圖表資料替換為四筆年度值。日期以 OLE Automation 序列號儲存於第一個工作表（索引 `0`），其計算方式為自 1899 年 12 月 30 日起的天數。JavaScript 計算使用 UTC 時間戳記，並將差值除以每日 86,400,000 毫秒。使用[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) 並傳入 `CategoryAxisType.Date`，呼叫[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) 並傳入 `false`，再將 `yyyy` 傳給[setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/)，使類別標籤顯示四位數年份，且不受儲存格格式影響。

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

## **設定圖表座標軸標題的旋轉角度**

在縱軸上呼叫[setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) 並傳入 `true`，提供標題文字，然後使用[setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) 旋轉標題。角度以度為單位；此範例將柱狀圖的值軸標題旋轉 90 度後儲存。

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

## **設定類別或值座標軸的位置**

使用[setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) 以控制值座標軸是於類別之間還是於類別刻度標記交叉類別座標軸。此設定適用於類別座標軸。範例在柱狀圖的水平類別座標軸上將其設為 `true`，並儲存結果。

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

## **設定圖表值座標軸的顯示單位**

使用[setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) 以在不變更底層資料的情況下調整值座標軸標籤的比例。將[DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) 設為 `Millions` 後，60,000,000 會顯示為 60。此範例建立柱狀圖，並將百萬顯示單位套用於其縱軸。

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

## **FAQ**

**如何設定一個座標軸與另一個座標軸交叉的數值 (軸交叉點)？**

使用[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) 以選擇交叉行為。若要指定數值型的交叉點，請使用[setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/)。這些設定可讓您將座標軸交叉點移動至適當的基線。

**如何將刻度標籤相對於座標軸定位？**

呼叫[setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) 並使用[TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/)：`Low`、`High`、`NextTo` 或 `None`。若要控制刻度線本身，請使用[setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) 或[setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/)；這些與標籤定位是分開的。