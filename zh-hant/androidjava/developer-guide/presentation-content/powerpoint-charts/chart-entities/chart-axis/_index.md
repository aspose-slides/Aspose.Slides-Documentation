---
title: 在 Android 上的簡報中自訂圖表坐標軸
linktitle: 圖表坐標軸
type: docs
url: /zh-hant/androidjava/chart-axis/
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 透過 Java，於 PowerPoint 簡報中自訂圖表坐標軸，以製作報告與視覺化圖表。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Android（Java）自訂圖表坐標軸。涵蓋計算軸值、交換圖表列與欄、坐標軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、坐標軸位置、顯示單位，以及對數縮放。

## **在圖表上取得垂直軸的最大值**

建立一個[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)並加入預設資料的區域圖表。於讀取計算後的軸值之前，先呼叫[validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--)，確保圖表佈局為最新狀態。

讀取[getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--)與[getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--)取得軸的上下限，並使用[getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--)與[getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--)取得刻度間隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--)與[getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--)提供時間單位比例，這在日期軸上尤其相關。範例將這些值儲存於本地變數，然後儲存圖表。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **交換坐標軸之間的資料**

使用[switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--)交換圖表資料中系列與類別的角色。先前的每個類別會變成系列，先前的每個系列會變成類別。此操作會變更資料分組方式，但不會交換水平與垂直軸。範例使用[setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-)將預設資料繫結至`Sheet1!A1:D5`（包含標題列與類別欄），再執行列與欄的交換，最終產生含四個系列與三個類別的圖表。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **反轉坐標軸的繪製順序**

使用[setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-)可反轉類別軸或數值軸。例如，水平長條圖可以依工作表的順序自上而下顯示專案階段：規劃、開發、測試。反轉軸僅改變繪製方向，並不會對工作表資料進行排序或重新排列。相較之下，[switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--)則是交換系列與類別的角色。

以下範例建立一個含三個階段與一個系列的水平長條圖，並儲存三張投影片：正常順序、類別反轉、數值反轉。每個副本使用相同的資料集，且每張投影片僅反轉其中一個軸。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // 投影片 2：在頂部顯示第一個類別。
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // 保持水平數值軸在底部。
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // 投影片 3：僅反轉水平數值比例。
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

反轉軸同時也可以將垂直軸移至圖表的對側。[setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) 控制另一軸與目前設定軸的交叉位置。於第 2 張投影片上，將其設定為 `CrossesType.Maximum`（在反轉的類別軸上）即可使水平數值軸保持在底部。若需要指定特定的交叉點，請使用[setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-)。在變更方向時請檢查交叉設定，特別是圖表已有自訂交叉點的情況。呼叫 `setPlotOrderReversed` 並傳入 `false` 可回復為正常繪製方向；交叉設定與此獨立。

| 正常順序（投影片 1） | 反轉類別（投影片 2） | 反轉數值（投影片 3） |
| --- | --- | --- |
| ![水平長條圖，類別與數值軸順序正常](axis-order-normal.png) | ![水平長條圖，類別自上而下顯示](axis-order-categories-reversed.png) | ![水平長條圖，數值軸反向且零位於右側](axis-order-values-reversed.png) |
| 類別由底部至頂部排列；數值由左至右遞增。 | 規劃、開發、測試由上至下排列。數值及工作表列順序保持不變。 | 類別保持正常順序；數值由右至左遞增。類別軸在右側的零點交叉。 |

## **隱藏折線圖的垂直軸**

對垂直軸呼叫[setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) 並傳入 `false` 即可隱藏。範例建立一個預設資料的折線圖，並以隱藏垂直軸的方式儲存。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **隱藏折線圖的水平軸**

對水平軸呼叫[setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) 並傳入 `false` 即可隱藏。範例建立一個預設資料的折線圖，並以隱藏水平軸的方式儲存。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **變更類別軸**

使用[setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) 可選擇日期或文字類別軸。此範例需要 `ExistingChart.pptx`，圖表位於第一張投影片的第一個圖形，且類別儲存格內為 Excel 數值日期。範例將水平軸改為日期軸。將[setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) 設為 `false`、[setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) 設為 `1`，並以 `TimeUnitType.Months` 呼叫[setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-)，即可使主刻度間隔為一個月。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制類別軸標籤間隔**

當圖表的類別過多時，可降低可見軸標籤的數量，而不必移除類別或資料點。先以 `false` 呼叫[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-)，再將欲使用的類別間隔傳入[setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-)。對於文字類別且保持正常順序時，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

間隔為 `3` 時會每三個顯示一次標籤，兩個標籤會被隱藏，且不會移除對應的欄位。自動間隔會根據可用空間決定適合的間隔，未必會顯示全部標籤。

刻度線有獨立的控制。以 `false` 呼叫[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-)，再使用[setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) 設定其間隔。例如 `1` 會在每個類別間隔保留刻度線，而標籤僅每三個類別顯示一次。可使用[setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) 設定可見樣式，以便觀察結果。再次將任一自動間隔的 setter 設為 `true`，即可讓圖表自行決定間隔。

以下自行完整的範例會建立 24 個類別與一個系列，接著在 `CategoryAxisIntervals.pptx` 中儲存三張投影片：自動間隔、手動標籤間隔且刻度線獨立、以及恢復自動間隔。兩個副本保留原始圖表資料，無需輸入簡報。水平標籤文字讓密度差異一目了然。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // 投影片 2：顯示每三個標籤，但保留每個類別的刻度線。
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 投影片 3：讓圖表再次自行選擇兩者的間隔。
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自動間隔（投影片 1）:** 在此呈現中，每兩個類別標籤會顯示一次，且會換行成兩行。自動結果會因圖表大小、字型與轉譯器而異。

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**手動間隔（投影片 2）:** 每三個標籤顯示於同一行，刻度線仍維持在每個類別間隔。所有 24 個欄位（即使未顯示標籤）皆保持可見且數值相同。投影片 3 會恢復上述的自動外觀。

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **選擇正確的軸與間隔**

此類別計數間隔適用於文字類別軸，例如柱狀圖、折線圖、區域圖或長條圖的類別軸。在柱狀圖中屬於水平軸；在水平長條圖中類別軸為垂直軸，請對由[getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 取得的軸套用此設定。刻度間隔同樣適用於具有系列軸的圖表。

請勿使用類別標籤間隔來設定數值軸的數值比例。在數值軸上，[setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) 代表數值差異，例如 `10` 會在 0、10、20… 等位置產生刻度。類別標籤間隔 `3` 則是依類別位置計算，與實際資料值無關。散佈圖與氣泡圖使用數值軸而非文字類別軸。對於日期軸，請參考[變更類別軸](#變更類別軸) 中的時間基礎單位與比例設定。

## **為類別軸值設定日期格式**

此範例以四個年度值取代預設圖表資料。日期以 OLE Automation 序號儲存在第一個工作表（索引 `0`）中，計算方式為自 1899 年 12 月 30 日起的天數。兩個行事曆皆使用 UTC，且在設定日期前先清除，以避免夏令時間與當前時間影響計算。使用[setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) 並傳入 `CategoryAxisType.Date`，呼叫[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) 設為 `false`，再以 `yyyy` 呼叫[setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) 使類別標籤顯示四位數年份，且不受儲存格格式影響。

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **為圖表坐標軸標題設定旋轉角度**

在垂直軸上呼叫[setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) 並傳入 `true`，提供標題文字，接著使用[setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) 以度數旋轉標題。本範例將欄狀圖的數值軸標題旋轉 90 度後儲存。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在類別軸或數值軸上設定軸位置**

使用[setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) 以控制數值軸在類別軸之間的交叉位置（在類別之間或在類別刻度上）。此設定僅適用於類別軸。範例在柱狀圖的水平類別軸上將其設定為 `true`，並儲存結果。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在圖表數值軸上設定顯示單位**

使用[setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) 可在不改變底層資料的情況下調整數值軸標籤的比例。例如，將[DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) 設為 `Millions`，則 60,000,000 會顯示為 60。範例建立柱狀圖，並將其垂直軸的顯示單位設定為百萬。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定對數數值軸**

當正值跨越多個數量級時，對數數值軸相當實用。例如，某服務在五個時段分別收到 10、100、1,000、10,000、100,000 個請求。若使用線性比例，較小的值會集中在接近零的位置。對數比例則使相等距離代表相等比例，而非相等差距，便於比較相對增長。

在數值軸上呼叫[setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) 並傳入 `true`，再使用[setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) 指定底數。此動作會改變現有值的顯示方式，並不會改變資料或新增對數趨勢線。趨勢線是針對資料的擬合關係，屬於獨立功能。

### **選擇數值軸與底數**

對於折線圖或柱狀圖，數值軸由[getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 取得。對於水平長條圖，則由[getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) 取得。散佈圖與氣泡圖有兩個數值軸，請為 X 值選擇水平軸，為 Y 值選擇垂直軸，或同時設定。請勿對類別軸套用對數縮放。

預設的對數底數為 `10`。對於 PPTX 圖表，底數範圍為 `2` 至 `1000`（含），亦支援分數底數如 `2.5`。使用底數 `10` 時，10、100、1,000、10,000 等次方會等距分布。

### **比較線性與對數縮放**

以下自行完整的範例會在第 1 張投影片建立含五個請求量的折線圖，然後複製該投影片並在第 2 張投影片上啟用底數為 10 的對數數值軸。兩張投影片保留相同資料。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // 保持第一張投影片為線性，僅變更副本的數值軸比例。
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**線性比例（投影片 1）:** 相等的垂直距離代表相等的請求量差距。最大值佔據圖表的大部分，使較小的值難以辨識。

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**對數比例（投影片 2）:** 相等的垂直距離代表相等的比例。每個時段的請求量是前一個的十倍，因而在底數為 10 的比例上形成筆直上升的直線。軸標籤仍顯示原始請求量。

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **處理零與負值**

對數比例只能顯示嚴格正值。啟用前請先檢查資料；若零或負值具有意義，請保留線性比例或另行顯示。若將這些值排除於分析之外，請說明原因，切勿悄悄將其替換為小的正值，因為這會改變資料意義。對數軸的手動最小值或最大值亦必須為正數。

## **常見問題集**

**如何設定一個軸與另一個軸交叉的數值（軸交叉點）？**

使用[setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) 以選擇交叉行為。若要指定數值交叉點，請使用[setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-)。這些設定可將軸交叉位置移至適當的基線。

**如何相對於坐標軸定位刻度標籤？**

呼叫[setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-)，並使用[TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) 之 `Low`、`High`、`NextTo` 或 `None`。若要控制刻度線本身，請使用[setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) 或[setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-)；這與標籤位置是分開的設定。