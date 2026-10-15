---
title: 使用 Java 自訂簡報中的圖表坐標軸
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
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 簡報中自訂圖表坐標軸，以製作報告和視覺化。"
---
## **概述**

本文章說明如何使用 Aspose.Slides for Java 自訂圖表坐標軸。它涵蓋計算坐標軸值、切換圖表的列與欄、坐標軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、坐標軸位置、顯示單位以及對數縮放。

## **取得圖表垂直坐標軸的最大值**

建立一個[簡報](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)並加入具有預設資料的區域圖表。在讀取計算坐標軸值之前，呼叫[validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--)以確保圖表佈局為最新狀態。  
讀取[getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--)和[getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--)以取得坐標軸限制，並讀取[getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--)和[getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--)以取得刻度間隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--)和[getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--)提供時間單位比例，與日期坐標軸相關。範例將這些值存入本機變數，並儲存圖表。

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

使用[switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--)交換系列與類別在圖表資料中的角色。每個原先的類別變成系列，而每個原先的系列變成類別。這會改變資料的分組方式；不會交換水平與垂直坐標軸。範例使用[setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-)將預設資料綁定至 `Sheet1!A1:D5`（包括標頭列與類別欄），再進行列與欄的交換。它會儲存一個包含四個系列和三個類別的圖表。

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

使用[setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-)反轉類別或數值坐標軸。例如，水平條形圖可以依工作表的相同順序從上至下顯示專案階段：Planning、Development、Testing。反轉坐標軸會改變繪製方向；不會對工作簿資料進行排序或重新排列。相比之下，[switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--)交換系列與類別的角色。  
以下範例建立一個具有三個階段和一個系列的水平條形圖。它會儲存一個包含三張投影片的簡報：正常順序、類別反轉和數值反轉。每個副本使用相同的資料集，且每個副本僅反轉一條坐標軸。

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

    // 投影片 2：將第一個類別顯示在頂部。
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // 保留水平數值坐標軸在底部。
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

反轉坐標軸還可以將垂直坐標軸移至圖形的相對側。[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-)控制另一條坐標軸在被設定的坐標軸上的交叉位置。在第 2 張投影片中，對反轉的類別坐標軸以 `CrossesType.Maximum` 呼叫它，將水平數值坐標軸保持在底部。若需特定的交叉點，請使用[setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-)。在改變方向時，請檢查交叉設定，特別是圖表已有自訂交叉點時。以 `false` 呼叫 `setPlotOrderReversed` 以恢復正常的繪製方向；交叉設定是獨立的。  

| 正常順序（投影片 1） | 類別反轉（投影片 2） | 數值反轉（投影片 3） |
| --- | --- | --- |
| ![水平條形圖，類別與數值坐標軸的正常順序](axis-order-normal.png) | ![水平條形圖，類別從上至下顯示](axis-order-categories-reversed.png) | ![水平條形圖，數值坐標軸反轉且零位於右側](axis-order-values-reversed.png) |
| 類別從底部到頂部排列；數值由左至右遞增。 | Planning、Development、Testing 從上至下排列。數值與工作表列順序保持不變。 | 類別保留其正常順序；數值由右至左遞增。類別坐標軸於右側零點交叉。 |

## **停用折線圖的垂直坐標軸**

在垂直坐標軸上呼叫[setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-)並傳入 `false` 以隱藏它。範例建立一個具有預設資料的折線圖，並將垂直坐標軸隱藏後儲存。

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

## **停用折線圖的水平坐標軸**

在水平坐標軸上呼叫[setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-)並傳入 `false` 以隱藏它。範例建立一個具有預設資料的折線圖，並將水平坐標軸隱藏後儲存。

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

使用[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-)以選擇日期或文字類別坐標軸。此範例需要 `ExistingChart.pptx`，其第一張投影片的第一個圖形為圖表，且類別儲存格包含數值型 Excel 日期。它會將水平坐標軸變更為日期坐標軸。呼叫[setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-)並傳入 `false`、[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-)並傳入 `1`，以及[setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-)並傳入 `TimeUnitType.Months`，可使主刻度以一個月為間隔。

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

當圖表具有許多類別時，可減少可見坐標軸標籤的數量，而不移除類別或資料點。先以 `false` 呼叫[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-)，再將欲使用的類別間隔傳入[setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-)。對於正常順序的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | 類別 1、類別 2、類別 3、⋯ 類別 24 |
| `2` | 類別 1、類別 3、類別 5、⋯ 類別 23 |
| `3` | 類別 1、類別 4、類別 7、⋯ 類別 22 |

`3` 的間隔會顯示每第三個標籤，於顯示的標籤之間隱藏兩個標籤。它不會移除相應的欄位。自動間距會根據可用空間選擇間隔；不一定會顯示所有標籤。  

刻度線有獨立的控制。以 `false` 呼叫[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-)，並使用[setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-)來設定其間隔。例如，`1` 會在每個類別間隔保留刻度線，而標籤僅每三個類別顯示一次。使用[setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-)並設定為可見樣式，以便觀察結果。再次以 `true` 呼叫任一自動間距設定器，圖表將重新選擇間隔。  

以下獨立範例建立 24 個類別及一個系列，然後在 `CategoryAxisIntervals.pptx` 中儲存三張投影片：自動間距、手動標籤間距且刻度線獨立，以及恢復自動間距。兩個副本保留原始圖表資料。無需輸入簡報。水平標籤文字使密度差異一目了然。

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

    // 投影片 2：顯示每三個標籤，但仍為每個類別保留刻度線。
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 投影片 3：讓圖表再次自行選擇兩種間隔。
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自動間距（投影片 1）:** 在此呈現中，每第二個類別標籤會顯示且換成兩行。自動結果會因圖表大小、字型與渲染器而異。  
![自動類別標籤間距，顯示所有 24 欄](category-axis-automatic.png)

**手動間距（投影片 2）:** 每第三個標籤顯示於一行，而刻度線仍保留在每個類別間隔。所有 24 欄（包括未標示的欄位）仍以相同數值顯示。投影片 3 恢復上述的自動外觀。  
![手動類別標籤間隔為三，顯示所有 24 欄](category-axis-manual.png)

### **選擇正確的坐標軸與間隔**

對於文字類別坐標軸（例如柱狀圖、折線圖、區域圖或條形圖的類別坐標軸），使用此類別計數間隔。在柱狀圖中，它是水平坐標軸。於水平條形圖中，類別坐標軸為垂直，故將此設定套用至 [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 回傳的坐標軸。刻度線間距亦適用於具有系列坐標軸的圖表。  

請勿使用類別標籤間隔來設定數值坐標軸的數值比例。於數值坐標軸上，[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) 指定值的差異：例如，主單位為 `10` 時，若坐標軸從零開始，則會在 0、10、20 等處產生刻度。`3` 的類別標籤間隔則是計算類別位置，與資料值無關。散佈圖與氣泡圖使用數值坐標軸，而非文字類別坐標軸。對於日期坐標軸，請使用基於時間的主單位與比例，如 [Change a Category Axis](#change-a-category-axis) 所述。

## **設定類別坐標軸值的日期格式**

此範例以四個年度值取代預設圖表資料。日期以 OLE Automation 序號儲存在第一個工作表（索引 `0`）中，計算方式為自 1899 年 12 月 30 日起的天數。使用[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) 並傳入 `CategoryAxisType.Date`，呼叫[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) 並傳入 `false`，再將 `yyyy` 傳給[setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-)，使類別標籤顯示四位數年份，且不受儲存格格式影響。

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
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

## **設定圖表坐標軸標題的旋轉角度**

在垂直坐標軸上呼叫[setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) 並傳入 `true`，提供標題文字，並使用[setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) 來旋轉標題。角度以度數為單位；此範例儲存一個柱狀圖，其數值坐標軸標題旋轉 90 度。

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

## **設定類別或數值坐標軸的位置**

使用[setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) 來控制數值坐標軸是於類別之間還是於類別刻度標記處與類別坐標軸相交。此設定適用於類別坐標軸。範例在柱狀圖的水平類別坐標軸上將其設為 `true`，並儲存結果。

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

## **設定圖表數值坐標軸的顯示單位**

使用[setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) 以縮放數值坐標軸的標籤而不變更底層資料。將 [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) 設為 `Millions` 時，60,000,000 會顯示為 60。範例建立一個柱狀圖，並將百萬顯示單位套用於其垂直坐標軸。

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

當正值跨越多個數量級時，對數數值坐標軸相當有用。例如，某服務於五個時段可能分別收到 10、100、1,000、10,000、100,000 個請求。使用線性比例時，較小的值會聚集在接近零的區域。對數比例則使其相對增長更易於比較：相等的距離代表相等的比例，而非相等的差異。  
在數值坐標軸上以 `true` 呼叫[setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-)，並使用[setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) 來選擇底數。此操作會變更現有值的顯示方式；不會改變資料或新增對數趨勢線。趨勢線表示資料的擬合關係，屬於另一項功能。

### **選擇數值坐標軸與底數**

對於折線圖或柱狀圖，數值坐標軸由 [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 回傳。對於水平條形圖，則由 [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) 回傳。散佈圖與氣泡圖具有兩個數值坐標軸，故可為 X 值選擇水平坐標軸，為 Y 值選擇垂直坐標軸，或同時選擇。請勿對類別坐標軸套用對數縮放。  
預設的對數底數為 `10`。對於 PPTX 圖表，可使用介於 `2` 到 `1000`（含）的底數；亦支援如 `2.5` 的分數底數。使用底數 `10` 時，連續的次方（如 10、100、1,000、10,000）間距相等。

### **比較線性與對數縮放**

以下獨立範例在第一張投影片建立一個包含五個請求次數的折線圖，然後複製該投影片並在第二張啟用底數為 10 的對數數值坐標軸。兩張投影片保留相同的資料。

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

    // 保持第一張投影片線性，且僅更改副本的數值坐標軸比例。
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

**線性比例（投影片 1）:** 相等的垂直距離代表請求次數的相等差異。最大值主導圖表，使較小的值難以辨識。  
![PowerPoint 折線圖，顯示在線性數值坐標軸上的五個請求次數](value-axis-linear.png)

**對數比例（投影片 2）:** 相等的垂直距離代表相等的比例。每個時期的請求量是前一個的十倍，因而在底數為 10 的比例下，點形成一條直上升線。坐標軸標籤仍顯示原始請求次數。  
![相同的五個請求次數於 PowerPoint 的底數 10 對數數值坐標軸上](value-axis-logarithmic.png)

### **處理零與負值**

對數比例只能顯示嚴格正值。啟用前請檢查資料。若零或負值具備意義，應保留線性比例或分別顯示。若因分析需要排除這些值，請說明排除原因。不要在未說明的情況下將其替換為小的正數，因為會改變資料的意義。對數坐標軸的手動最小值或最大值亦必須為正值。

## **常見問題**

**如何設定一條坐標軸與另一條交叉的數值（坐標軸交叉）？**  
使用[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) 來選擇交叉行為。若要指定數值型的交叉點，請使用[setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-)。這些設定讓您將坐標軸交叉位置移至合適的基線。  

**如何相對於坐標軸定位刻度標籤？**  
以[setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) 搭配 [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/)：`Low`、`High`、`NextTo` 或 `None` 來呼叫。若要控制刻度線本身，請使用[setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) 或[setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-)；這與標籤定位是分開的設定。