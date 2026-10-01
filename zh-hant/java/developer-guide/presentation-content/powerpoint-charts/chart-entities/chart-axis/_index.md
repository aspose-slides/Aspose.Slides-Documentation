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
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 簡報中自訂圖表坐標軸，以製作報告與視覺化。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Java 自訂圖表坐標軸。內容涵蓋計算坐標軸值、切換圖表的列與行、坐標軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、坐標軸位置以及顯示單位。

## **在圖表的垂直坐標軸上取得最大值**

建立一個[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 並加入具有預設資料的面積圖表。在讀取計算出的坐標軸值之前，呼叫[validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) 以確保圖表版面已更新。

讀取[getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) 以及[getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) 以取得坐標軸的上、下限，並使用[getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) 與[getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) 取得刻度間隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) 與[getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) 提供時間單位比例，與日期坐標軸相關。範例將這些值存入本機變數，並儲存圖表。

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

使用[switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) 交換圖表資料中系列與類別的角色。每個原本的類別會變成系列，而每個原本的系列會變成類別。此變更會影響資料的分組方式，並不會交換水平與垂直坐標軸。範例在切換列與行之前，使用[setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) 將預設資料繫結至 `Sheet1!A1:D5`（包括標題列與類別欄）。它會儲存一個包含四個系列和三個類別的圖表。

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

## **停用折線圖的垂直坐標軸**

在垂直坐標軸上呼叫[setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) 並傳入 `false` 以隱藏它。範例建立一個具有預設資料的折線圖，並在隱藏垂直坐標軸的情況下儲存。

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

在水平坐標軸上呼叫[setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) 並傳入 `false` 以隱藏它。範例建立一個具有預設資料的折線圖，並在隱藏水平坐標軸的情況下儲存。

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

使用[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) 來選擇日期或文字類別坐標軸。本範例需要 `ExistingChart.pptx`，其中圖表位於第一張投影片的第一個圖形，且類別儲存格包含數值型 Excel 日期。它將水平坐標軸變更為日期坐標軸。呼叫[setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) 並傳入 `false`，[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) 設為 `1`，以及[setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) 設為 `TimeUnitType.Months`，即可使主要刻度以一個月為間隔。

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

當圖表有大量類別時，可在不移除類別或資料點的前提下減少可見的坐標軸標籤數量。先將[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) 設為 `false`，再將想要的類別間隔傳給[setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-int-)。對於文字類別的正常順序，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | 類別 1, 類別 2, 類別 3, ... 類別 24 |
| `2` | 類別 1, 類別 3, 類別 5, ... 類別 23 |
| `3` | 類別 1, 類別 4, 類別 7, ... 類別 22 |

間隔為 `3` 時會顯示每第三個標籤，於顯示的標籤之間隱藏兩個標籤。這不會移除相對應的欄位。自動間隔會依可用空間選擇間隔；不一定會顯示所有標籤。

刻度線有獨立的控制。將[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) 設為 `false`，並使用[setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-int-) 設定其間隔。例如，`1` 代表在每個類別間隔均保留刻度線，而標籤僅每三個類別顯示一次。使用[setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) 設定可見樣式，以便觀察結果。再次將任一自動間隔設定器設為 `true`，即可讓圖表重新自動選擇間隔。

以下獨立範例會建立 24 個類別和一個系列，然後在 `CategoryAxisIntervals.pptx` 中儲存三張投影片：自動間隔、手動標籤間隔且刻度線獨立、以及恢復自動間隔。兩個副本保留原始圖表資料。無需輸入投影片。水平標籤文字可讓密度差異一目了然。

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

    // 第 2 頁投影片：顯示每三個標籤，但為每個類別保留刻度線。
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 第 3 頁投影片：讓圖表再次自行選擇兩者的間隔。
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自動間隔（第 1 張投影片）：** 在此呈現中，每兩個類別標籤顯示一次，且會換行成兩行。自動結果會因圖表大小、字型及渲染器而異。

![自動類別標籤間隔，顯示所有 24 欄可見](category-axis-automatic.png)

**手動間隔（第 2 張投影片）：** 每三個標籤顯示在同一行，同時刻度線仍保留在每個類別間隔。所有 24 欄（即使沒有標籤）仍以相同數值顯示。第 3 張投影片恢復上述的自動外觀。

![手動類別標籤間隔為三，顯示所有 24 欄可見](category-axis-manual.png)

### **選擇正確的坐標軸與間隔**

對於文字類別坐標軸（例如柱狀圖、折線圖、面積圖或長條圖的類別坐標軸），使用此類別計數間隔。在柱狀圖中，它是水平坐標軸；在水平長條圖中，類別坐標軸是垂直的，因此請將這些設定套用於由[getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 回傳的坐標軸。刻度間隔亦適用於具有系列坐標軸的圖表。

請勿使用類別標籤間隔來設定值坐標軸的數值尺度。於值坐標軸上，[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) 指定數值差異：例如，`10` 的主要單位會在 0、10、20… 等位置產生刻度，前提是坐標軸從零開始。類別標籤間隔 `3` 則僅計算類別位置，與其資料值無關。散點圖與氣泡圖使用值坐標軸，而非文字類別坐標軸。對於日期坐標軸，請使用基於時間的主要單位和比例，如[變更類別坐標軸](#change-a-category-axis)所述。

## **設定類別坐標軸值的日期格式**

此範例將預設圖表資料取代為四個年度值。日期以 OLE Automation 序號儲存在第一個工作表（索引 `0`）中，計算方式為自 1899 年 12 月 30 日起的天數。使用[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) 並傳入 `CategoryAxisType.Date`，呼叫[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) 設為 `false`，並將 `yyyy` 傳給[setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-)，即可讓類別標籤顯示四位數年份，且不受儲存格格式影響。

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

在垂直坐標軸上呼叫[setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) 並傳入 `true`，提供標題文字，然後使用[setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) 旋轉標題。角度以度為單位；此範例將欄位圖的值軸標題旋轉 90 度後儲存。

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

## **設定類別或值坐標軸的位置**

使用[setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) 來控制值坐標軸是否在類別之間或在類別刻度標記上與類別坐標軸相交。此設定僅適用於類別坐標軸。範例在柱狀圖的水平類別坐標軸上將其設為 `true`，並儲存結果。

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

## **設定圖表值坐標軸的顯示單位**

使用[setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) 來在不變更底層資料的情況下調整值坐標軸的標籤比例。將[DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) 設為 `Millions`，則 60,000,000 會顯示為 60。範例建立一個欄位圖，並將其垂直坐標軸的顯示單位設為百萬。

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

## **常見問題**

**如何設定一個坐標軸與另一個坐標軸的交叉值（坐標軸交叉）？**

使用[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) 來選擇交叉的行為。若要指定數值型交叉點，請使用[setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-)。這些設定讓您能將坐標軸交叉移動至合適的基準線。

**如何相對於坐標軸定位刻度標籤？**

呼叫[setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) 並使用[TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/) 的 `Low`、`High`、`NextTo` 或 `None`。若要控制刻度線本身，使用[setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) 或[setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-)；這些設定與標籤位置是分開的。