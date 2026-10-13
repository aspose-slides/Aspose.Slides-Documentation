---
title: 在 Android 上自訂簡報中的圖表坐標軸
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
description: "了解如何透過 Java 使用 Aspose.Slides for Android 在 PowerPoint 簡報中自訂圖表坐標軸，以便進行報告和視覺化。"
---
## **概述**

本文說明如何透過 Java 於 Aspose.Slides for Android 針對圖表坐標軸進行自訂。內容包含計算坐標軸值、切換圖表列與欄、坐標軸可見性、類別標籤與刻度標記間隔、日期類別與格式設定、標題旋轉、坐標軸定位、顯示單位，以及對數縮放。

## **取得圖表垂直坐標軸的最大值**

建立一個 [簡報](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)，並新增帶有預設資料的面積圖。於讀取計算坐標軸值之前，先呼叫 [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--)，以確保圖表版面已更新。

讀取 [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) 與 [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) 取得坐標軸上下限，並使用 [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) 及 [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) 取得刻度間隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) 與 [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) 提供時間單位比例，與日期坐標軸相關。範例將這些值存入本機變數，然後保存圖表。

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

## **在坐標軸之間交換資料**

使用 [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) 交換圖表資料中系列與類別的角色。每個原本的類別會變成系列，原本的系列會變成類別。此操作會改變資料分組方式，但不會交換水平與垂直坐標軸。範例使用 [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) 將預設資料繫結至 `Sheet1!A1:D5`（包括標題列與類別欄），再執行列與欄的切換。最終會產生一個包含四個系列與三個類別的圖表。

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

## **關閉折線圖的垂直坐標軸**

在垂直坐標軸上呼叫 [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) 並傳入 `false` 以隱藏它。範例建立一個帶有預設資料的折線圖，並將垂直坐標軸隱藏後保存。

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

## **關閉折線圖的水平坐標軸**

在水平坐標軸上呼叫 [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) 並傳入 `false` 以隱藏它。範例建立一個帶有預設資料的折線圖，並將水平坐標軸隱藏後保存。

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

## **變更類別坐標軸**

使用 [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) 來選擇日期或文字類別坐標軸。本範例需要 `ExistingChart.pptx`，其中第一張投影片的第一個圖形是圖表，且類別儲存格內含 Excel 數字日期值。它將水平坐標軸改為日期坐標軸。呼叫 [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) 並傳入 `false`、[setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) 設為 `1`，以及 [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) 設為 `TimeUnitType.Months`，即可將主要刻度設為每月一次。

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

## **控制類別坐標軸標籤間隔**

當圖表有許多類別時，可減少可見坐標軸標籤的數量，而不必移除類別或資料點。呼叫 [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) 並傳入 `false`，然後將想要的類別間隔傳給 [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-)。對於正常排序的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | 類別 1, 類別 2, 類別 3, … 類別 24 |
| `2` | 類別 1, 類別 3, 類別 5, … 類別 23 |
| `3` | 類別 1, 類別 4, 類別 7, … 類別 22 |

間隔為 `3` 時，每三個標籤顯示一次，兩個標籤會被隱藏，且不會移除相應的欄位。自動間距會根據可用空間選擇間隔，未必會顯示全部標籤。

刻度標記有獨立的控制方式。呼叫 [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) 並傳入 `false`，再使用 [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) 設定間隔。例如，`1` 會在每個類別間隔保留刻度標記，而標籤僅每三個類別顯示一次。使用 [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) 設定可見樣式，以便看到結果。再次將任一自動間距設定器設為 `true`，即可讓圖表重新自動選擇間隔。

以下自包含範例建立 24 個類別與一個系列，然後在 `CategoryAxisIntervals.pptx` 中保存三張投影片：自動間距、手動標籤間距（刻度獨立）以及恢復自動間距。兩個副本保留原始圖表資料，無需輸入簡報。水平標籤文字讓密度差異一目了然。

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

    // 第 2 張投影片：顯示每三個標籤，但保留每個類別的刻度標記。
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 第 3 張投影片：讓圖表再次自行選擇兩個間隔。
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自動間距 (第 1 張投影片)：** 在此呈現中，每兩個類別標籤顯示一次，且會換行成兩行。自動結果會因圖表大小、字型與渲染器不同而有所變化。

![自動類別標籤間距，顯示全部 24 欄](category-axis-automatic.png)

**手動間距 (第 2 張投影片)：** 每三個標籤顯示在同一行，刻度標記仍保留在每個類別間隔。所有 24 欄（包括未標籤的欄）仍可見且數值相同。第 3 張投影片恢復如上所示的自動外觀。

![手動類別標籤間隔為三，顯示全部 24 欄](category-axis-manual.png)

### **選擇正確的坐標軸與間隔**

此類別計數間隔適用於文字類別坐標軸，例如柱狀圖、折線圖、區域圖或長條圖的類別坐標軸。於柱狀圖中，它是水平坐標軸；於水平長條圖中，類別坐標軸為垂直坐標軸，請對由 [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 取得的坐標軸套用本設定。刻度標記間距亦適用於具有系列坐標軸的圖表。

請勿使用類別標籤間距來設定數值坐標軸的數值刻度。在數值坐標軸上，[setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) 會指定數值差距，例如 `10` 的主要單位會在 0、10、20 等位置產生刻度。而類別標籤間隔 `3` 只會計算類別位置，與資料值無關。散佈圖與氣泡圖使用的是數值坐標軸，而非文字類別坐標軸。若使用日期坐標軸，請參考 [變更類別坐標軸](#變更類別坐標軸) 中的時間基礎主要單位與比例設定。

## **設定類別坐標軸值的日期格式**

此範例以四筆年度值取代預設圖表資料。日期以 OLE Automation 序號儲存在第一個工作表（索引 `0`）中，計算方式為自 1899 年 12 月 30 日起的天數。兩個曆法均使用 UTC，且在設定日期前先清除，以避免夏令時間與當前時間影響計算。使用 [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) 並傳入 `CategoryAxisType.Date`，再呼叫 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) 設為 `false`，最後將 `yyyy` 傳給 [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-)，即可讓類別標籤以四位數年份顯示，且不受儲存格格式影響。

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

在垂直坐標軸上呼叫 [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) 並傳入 `true`，提供標題文字，然後使用 [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) 旋轉標題。角度以度數計算；本範例將柱狀圖的數值坐標軸標題旋轉 90 度後保存。

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

## **在類別或數值坐標軸上設定坐標軸位置**

使用 [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) 來控制數值坐標軸是跨越類別坐標軸之間的類別還是跨越類別刻度標記。此設定僅適用於類別坐標軸。範例在柱狀圖的水平類別坐標軸上將其設為 `true`，並保存結果。

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

## **在圖表數值坐標軸上設定顯示單位**

使用 [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) 可在不改變底層資料的情況下縮放數值坐標軸的標籤。將 [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) 設為 `Millions`，則 60,000,000 會顯示為 60。本範例建立一個柱狀圖，並將其垂直坐標軸的顯示單位設為百萬。

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

## **設定對數數值坐標軸**

當正值跨越多個量級時，對數數值坐標軸相當有用。例如，某服務在五個時期分別收到 10、100、1,000、10,000 與 100,000 筆請求。若使用線性比例，較小的值會在接近零的區域集中。對數比例則讓相對成長更易比較：相等的距離代表相等的比例，而非相等的差距。

在數值坐標軸上呼叫 [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) 並傳入 `true`，再使用 [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) 來選擇底數。此設定會改變現有值的顯示方式，並不會修改資料或新增對數趨勢線。趨勢線是對資料進行擬合的獨立功能。

### **選擇數值坐標軸與底數**

對於折線圖或柱狀圖，數值坐標軸由 [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 取得；對於水平長條圖，則由 [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) 取得。散佈圖與氣泡圖有兩個數值坐標軸，請選擇水平坐標軸作為 X 值，垂直坐標軸作為 Y 值，或同時套用。請勿在類別坐標軸上使用對數縮放。

預設的對數底數為 `10`。對於 PPTX 圖表，底數可設定為 2 到 1000（含），亦支援小數底數如 `2.5`。以底數 `10` 為例，10、100、1,000、10,000 等次方會等距分布。

### **比較線性與對數縮放**

以下自包含範例於第 1 張投影片建立包含五筆請求次數的折線圖，然後複製該投影片並在第 2 張啟用底數為 10 的對數數值坐標軸。兩張投影片皆保留相同資料。

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

    // 保持第一張投影片為線性，僅變更副本的數值坐標軸比例。
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

**線性比例 (第 1 張投影片)：** 等距的垂直距離代表請求次數的等差。最大值主導圖表，較小的值難以辨識。

![PowerPoint 中的折線圖，使用線性數值坐標軸顯示五筆請求次數](value-axis-linear.png)

**對數比例 (第 2 張投影片)：** 等距的垂直距離代表等比例。每個時期的請求次數比前一個多十倍，於底數為 10 的比例上形成一條直線上升。坐標軸標籤仍顯示原始的請求次數。

![PowerPoint 中的相同五筆請求次數，使用底數為 10 的對數數值坐標軸](value-axis-logarithmic.png)

### **處理零與負值**

對數比例只能顯示嚴格正值。啟用前請先檢查資料。若零或負值具備意義，請保留線性比例或將它們另行顯示。若將這些值排除於分析之外，請說明原因。不要悄悄將它們替換為小的正數，因為這會改變資料意義。對於對數坐標軸的任何手動最小值或最大值設定，也必須為正值。

## **常見問題集**

**如何設定兩坐標軸交叉的位置 (交叉值)？**

使用 [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) 來選擇交叉行為。若要指定數值交叉點，請使用 [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-)。這些設定可讓您將坐標軸交叉移至合適的基線。

**如何相對於坐標軸定位刻度標籤？**

呼叫 [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) 並使用 [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) 之 `Low`、`High`、`NextTo` 或 `None`。若要控制刻度標記本身，請使用 [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) 或 [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-)，它們與標籤位置設定分開。