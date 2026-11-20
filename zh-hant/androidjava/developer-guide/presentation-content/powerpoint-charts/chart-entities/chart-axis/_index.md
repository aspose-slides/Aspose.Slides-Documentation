---
title: 在 Android 上的簡報中自訂圖表軸
linktitle: 圖表軸
type: docs
url: /zh-hant/androidjava/chart-axis/
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
- Android
- Java
- Aspose.Slides
description: "了解如何透過 Java 使用 Aspose.Slides for Android，自訂 PowerPoint 簡報中的圖表軸，以製作報告與視覺化。"
---
## **概述**

本文說明如何使用 Aspose.Slides for Android（Java）自訂圖表軸。它涵蓋計算的軸值、切換圖表列與行、軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、軸位置、顯示單位，以及對數比例。

## **取得圖表垂直軸的最大值**

建立一個[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)並加入具有預設資料的區域圖。於讀取計算的軸值之前，先呼叫[validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--)以確保圖表版面已更新。

讀取[getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) 與[getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) 以取得軸的上下限，並讀取[getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) 與[getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) 以取得刻度間隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) 與[getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) 提供時間單位比例，與日期軸相關。範例將這些值存入本機變數，並儲存圖表。

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

## **交換軸之間的資料**

使用[switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) 交換圖表資料中系列與類別的角色。每個原先的類別會變成系列，而每個原先的系列會變成類別。此動作會改變資料分組方式，但不會交換水平與垂直軸。範例在切換列與行之前，使用[setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) 將預設資料綁定至 `Sheet1!A1:D5`（包含標題列與類別欄）。它會儲存一個具有四個系列與三個類別的圖表。

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

## **反轉軸的繪圖順序**

使用[setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) 反轉類別或數值軸。例如，水平長條圖可以依工作表的順序從上至下顯示專案階段：Planning、Development、Testing。反轉軸會改變繪圖方向，並不會對活頁簿資料進行排序或重新排列。相較之下，[switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) 交換系列與類別的角色。

以下範例建立一個具有三個階段與一個系列的水平長條圖。它會將簡報儲存為三張投影片：正常順序、反轉類別、反轉數值。每個副本使用相同的資料集，且每個副本僅反轉一條軸。

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

    // 第 2 張投影片：將第一個類別顯示在頂部。
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // 保持水平數值軸位於底部。
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // 第 3 張投影片：僅反轉水平數字尺度。
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

反轉軸也可能將垂直軸移至圖形的另一側。[setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) 控制另一條軸與被設定軸的交叉位置。在第 2 張投影片中，於反轉的類別軸上使用 `CrossesType.Maximum` 可保持水平數值軸位於底部。若需特定的交叉點，請使用[setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-)。變更方向時請檢查交叉設定，尤其當圖表已有自訂交叉點時。呼叫 `setPlotOrderReversed` 並傳入 `false` 可恢復正常繪圖方向；交叉設定則是獨立的。

| 正常順序（投影片 1） | 反轉類別（投影片 2） | 反轉數值（投影片 3） |
| --- | --- | --- |
| ![水平長條圖，類別與數值軸正常順序](axis-order-normal.png) | ![水平長條圖，類別從上至下顯示](axis-order-categories-reversed.png) | ![水平長條圖，反轉數值軸且零位於右側](axis-order-values-reversed.png) |
| 類別由底部往上排列；數值由左至右遞增。 | Planning、Development、Testing 由上至下排列。數值與活頁簿列順序保持不變。 | 類別保留正常順序；數值由右至左遞增。類別軸於右側零點交叉。 |

## **為折線圖停用垂直軸**

在垂直軸上呼叫[setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) 並傳入 `false` 即可隱藏。範例建立具有預設資料的折線圖，並將垂直軸隱藏後儲存。

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

## **為折線圖停用水平軸**

在水平軸上呼叫[setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) 並傳入 `false` 即可隱藏。範例建立具有預設資料的折線圖，並將水平軸隱藏後儲存。

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

## **顯示或隱藏圖表格線**

呼叫[getShowMajorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMajorGridLines--) 與[getShowMinorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMinorGridLines--) 以檢查軸顯示哪些格線。這些方法會回報目前的可見性。若要顯示次要格線，使用[getMinorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) 並將其線條填充設定為實心、可見的顏色。若要隱藏，將填充設定為[FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/#NoFill)。也可使用[getMajorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) 以相同方式變更主要格線的線條填充。變更填充不會影響軸的可見性與刻度。

此群組柱形圖的垂直軸起始僅顯示主要格線。範例先將次要格線以深橙色顯示，然後在儲存簡報前再度隱藏。每一步皆會列印格線的可見性。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(Color.rgb(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 次要格線已啟用 | 次要格線已隱藏 |
| --- | --- |
| ![垂直軸上主要格線之間的橙色次要格線](minor-gridlines-enabled.png) | ![相同的柱形圖，僅顯示主要格線](minor-gridlines-hidden.png) |

## **變更類別軸**

使用[setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) 以選擇日期或文字類別軸。此範例需要 `ExistingChart.pptx`，其第一張投影片的第一個圖形是圖表，且類別儲存格包含數值型 Excel 日期。它會將水平軸變更為日期軸。呼叫[setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) 並傳入 `false`、[setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) 傳入 `1`、以及[setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) 傳入 `TimeUnitType.Months`，即可在每月間隔放置主要刻度。

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

### **根據資料判斷類別軸類型**

在填入類別後呼叫[setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--)，再讀取[getCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getCategoryAxisType--) 以檢查所選類型。當同一張圖表可能收到文字標籤或數值日期時，此方法很有用。此方法在呼叫時即決定類型，並不會啟用持續模式以在之後的資料變更時重新評估。替換類別後請再次呼叫它。

以下範例建立一個具有文字類別的圖表，當選取的類型為 `CategoryAxisType.Text` 時會印出 `true`。然後將類別儲存格的值換成日期，再次呼叫該方法，若選取的類型為 `CategoryAxisType.Date` 時會印出 `true`。日期以數值 OLE Automation 形式儲存，計算方式為自 1899 年 12 月 30 日起的天數，而非日期字串。兩個行事曆皆使用 UTC，且在設定日期前會先清除，以免日光節約時間與當前時間影響計算。[setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) 控制這些值的顯示方式，並不會將文字轉換為數值日期。欲了解類別儲存格的更多資訊，請參閱 [Chart Workbook](/slides/zh-hant/androidjava/chart-workbook/)。

如本範例，當輸入已知包含文字類別或數值日期時，請使用自動判斷。對於普通的數值標籤、混合類別或空資料，請明確呼叫[setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisType-int-) 以符合預期意圖。僅有數值並不足以表示類別為日期。

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    String[] labels = { "First", "Second", "Third" };

    for (int i = 0; i < labels.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // true

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);
    int[][] dates = { { 2026, Calendar.JANUARY, 1 }, { 2026, Calendar.JANUARY, 2 }, { 2026, Calendar.FEBRUARY, 1 } };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(dates[i][0], dates[i][1], dates[i][2]);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        categoryCell.setValue(serialDate);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // true

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制類別軸標籤間隔**

當圖表擁有大量類別時，可在不移除類別或資料點的情況下減少可見的軸標籤數量。先以 `false` 呼叫[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-)，再將欲設定的類別間隔傳入[setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-)。對於正常順序的文字類別，計算從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | Category 1、Category 2、Category 3、... Category 24 |
| `2` | Category 1、Category 3、Category 5、... Category 23 |
| `3` | Category 1、Category 4、Category 7、... Category 22 |

間隔為 `3` 時會每三個標籤顯示一次，於顯示的標籤之間隱藏兩個標籤。此動作不會移除對應的欄。自動間隔會根據可用空間選擇間隔；不一定會顯示所有標籤。

刻度標記有獨立的控制方式。以 `false` 呼叫[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-)，並使用[setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) 設定其間隔。例如，設定為 `1` 會在每個類別間隔保留刻度標記，而標籤僅每三個類別顯示一次。使用[setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) 並設定為可見樣式，以便看到結果。再次以 `true` 呼叫任一自動間隔設定，即可讓圖表重新選擇間隔。

以下獨立範例建立 24 個類別與一個系列，然後在 `CategoryAxisIntervals.pptx` 中儲存三張投影片：自動間隔、手動標籤間隔（刻度獨立），以及恢復自動間隔。兩個副本保留原始圖表資料。無需輸入簡報。水平標籤文字使密度差異一目了然。

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

    // 第 2 張投影片：顯示每三個標籤，但保持每個類別都有刻度標記。
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 第 3 張投影片：讓圖表再次自行選擇兩種間隔。
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自動間隔（投影片 1）：** 在此呈現中，每兩個類別標籤顯示一次，且會換成兩行。自動結果會因圖表大小、字型與渲染器而異。

![自動類別標籤間隔，顯示所有 24 欄](category-axis-automatic.png)

**手動間隔（投影片 2）：** 每三個標籤顯示在同一行，且刻度標記仍保留在每個類別間隔。所有 24 個欄位（包括未標記的）仍顯示相同值。投影片 3 恢復上述的自動外觀。

![手動類別標籤間隔為三，顯示所有 24 欄](category-axis-manual.png)

### **選擇正確的軸與間隔**

對於文字類別軸（如柱形圖、折線圖、區域圖或長條圖的類別軸），請使用此類別計數間隔。於柱形圖中，它是水平軸；於水平長條圖中，類別軸為垂直軸，因此將此設定套用到由[getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 回傳的軸。刻度間隔同樣適用於具有系列軸的圖表。

請勿使用類別標籤間隔來設定數值軸的數值尺度。在數值軸上，[setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) 指定數值差距：例如，若主要單位為 `10`，且軸從零開始，則刻度會出現在 0、10、20…。而類別標籤間隔 `3` 僅計算類別位置，與資料值無關。散佈圖與氣泡圖使用數值軸而非文字類別軸。若為日期軸，請使用基於時間的主要單位與比例，如同在[變更類別軸](#change-a-category-axis) 中所述。

## **設定類別軸值的日期格式**

範例將預設圖表資料取代為四個年度值。日期以 OLE Automation 序號儲存在第一個工作表（索引 `0`）中，計算方式為自 1899 年 12 月 30 日起的天數。兩個行事曆皆使用 UTC，且在設定日期前會先清除，以免日光節約時間與當前時間影響計算。使用[setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) 並傳入 `CategoryAxisType.Date`，呼叫[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) 並傳入 `false`，再將 `yyyy` 傳給[setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-)，使類別標籤獨立於儲存格格式，顯示四位年份。

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

## **設定圖表軸標題的旋轉角度**

在垂直軸上呼叫[setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) 並傳入 `true`，提供標題文字，然後使用[setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) 旋轉標題。角度以度為單位；此範例將柱形圖的數值軸標題旋轉 90 度後儲存。

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

## **設定類別或數值軸的位置**

使用[setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) 以控制數值軸是否在類別之間或在類別刻度標記處與類別軸交叉。此設定僅套用於類別軸。範例將其於柱形圖的水平類別軸設定為 `true`，並儲存結果。

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

## **設定圖表數值軸的顯示單位**

使用[setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) 以縮放數值軸的標籤而不變更底層資料。將[DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) 設為 `Millions` 時，60,000,000 會顯示為 60。範例建立柱形圖，並將百萬顯示單位套用到其垂直軸。

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

當正值跨越多個量級時，對數數值軸相當有用。例如，某服務在五個時期可能分別收到 10、100、1,000、10,000、100,000 個請求。線性尺度下，較小的值會聚集在接近零的區域。對數尺度則能更易於比較其相對成長：相等的距離代表相等的比例，而非相等的差異。

在數值軸上以 `true` 呼叫[setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-)，再使用[setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) 選擇底數。此動作會變更現有值的顯示方式，卻不會變更資料或新增對數趨勢線。趨勢線代表資料的擬合關係，是獨立的功能。

### **選擇數值軸與底數**

對於折線圖或柱形圖，數值軸由[getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 回傳。對於水平長條圖，則由[getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) 回傳。散佈圖與氣泡圖有兩個數值軸，故可選擇水平軸作為 X 值、垂直軸作為 Y 值，或同時設定。請勿將對數縮放套用於類別軸。

預設的對數底數為 `10`。對於 PPTX 圖表，可使用 `2` 至 `1000`（含）之間的底數；亦支援如 `2.5` 的分數底數。底數為 `10` 時，10、100、1,000、10,000 等連續次方等距排列。

### **比較線性與對數縮放**

以下獨立範例在第一張投影片建立一個折線圖，顯示五個請求計數，然後複製該投影片，於第二張投影片啟用底數為 10 的對數數值軸。兩張投影片皆保留相同資料。

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

    // 保留第一張投影片為線性，僅變更副本的數值軸比例。
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

**線性尺度（投影片 1）：** 相等的垂直距離代表請求計數的相等差異。最大值佔主導，使較小的值難以辨識。

![PowerPoint 折線圖，於線性數值軸上顯示五個請求計數](value-axis-linear.png)

**對數尺度（投影片 2）：** 相等的垂直距離代表相等的比例。每個時期的請求量是前一期的十倍，因而點在底數為 10 的尺度上形成一條直線上升。軸標籤仍顯示原始請求計數。

![同樣的五個請求計數，在 PowerPoint 上的底數為 10 的對數數值軸](value-axis-logarithmic.png)

### **處理零與負值**

對數尺度只能顯示嚴格正值。啟用之前請先檢查資料。若零或負值有其意義，請保留線性尺度或分開顯示。若在分析中適合排除這些值，請說明省略原因。切勿悄悄將其替換為小的正數，因為這會改變資料的意義。對數軸的任何手動設定之最小或最大值也必須為正數。

## **常見問題**

**How do I set the value at which one axis crosses the other (axis crossing)?**

使用[setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) 以選擇交叉行為。若要指定數值交叉點，請使用[setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-)。這些設定可將軸交叉移至適當的基線。

**How can I position tick labels relative to the axis?**

使用[setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) 並搭配[TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/)：`Low`、`High`、`NextTo` 或 `None` 來設定刻度標籤相對於軸的位置。若要控制刻度標記本身，請使用[setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) 或[setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-)；這與標籤位置設定是分開的。