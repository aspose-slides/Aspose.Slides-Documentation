---
title: 使用 Java 自訂簡報中的圖表坐標軸
linktitle: 圖表坐標軸
type: docs
url: /zh-hant/java/chart-axis/
keywords:
- 圖表坐標軸
- 縱軸
- 橫軸
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
## **概述**

本文說明如何使用 Aspose.Slides for Java 自訂圖表坐標軸。內容涵蓋計算坐標軸值、切換圖表列與欄、坐標軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、坐標軸位置、顯示單位，以及對數比例。

## **取得圖表縱軸的最大值**

建立一個[簡報](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)並加入具有預設資料的區域圖。於讀取計算坐標軸值之前，呼叫[validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--)，以確保圖表版面配置為最新狀態。

讀取[getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--)與[getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--)取得坐標軸上下限，並使用[getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--)與[getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--)取得刻度間隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--)與[getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--)提供時間單位比例，對日期坐標軸相關。範例將這些值存入本機變數，然後存檔圖表。

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

使用[switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--)交換圖表資料中系列與類別的角色。原先的每個類別會變成系列，原先的每個系列會變成類別。這會改變資料的分組方式，但不會交換水平與垂直坐標軸。範例使用[setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-)將預設資料綁定至 `Sheet1!A1:D5`（包括標頭列與類別欄），再切換列與欄，最後存檔得到四個系列與三個類別的圖表。

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

使用[setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-)反轉類別或數值坐標軸。例如，水平條形圖可以依工作表的順序從上到下顯示專案階段：Planning、Development、Testing。反轉坐標軸會改變繪製方向，並不會對工作表資料進行排序或重新排列。相較之下，[switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--)則交換系列與類別的角色。

以下範例建立一個包含三個階段與一個系列的水平條形圖，並產生三張投影片：正常順序、顛倒類別、顛倒數值。每個副本使用相同的資料集，且每張投影片僅對一個坐標軸做反轉。

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

    // 幻燈片 2：在頂部顯示第一個類別。
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // 保持水平數值軸位於底部。
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // 幻燈片 3：僅反轉水平數值刻度。
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

反轉坐標軸也可以將垂直坐標軸移至繪圖區的另一側。[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-)控制另一坐標軸在被設定的坐標軸何處交叉。在第 2 張投影片中，於顛倒的類別軸上呼叫 `CrossesType.Maximum`，可讓水平數值軸保持在底部。若要設定特定交叉點，請使用[setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-)。變更方向時請檢查交叉設定，尤其當圖表已設定自訂交叉點時。呼叫 `setPlotOrderReversed` 並傳入 `false` 可還原為正常繪製方向；交叉設定是獨立的。

| 正常順序（幻燈片 1） | 顛倒類別（幻燈片 2） | 顛倒數值（幻燈片 3） |
| --- | --- | --- |
| ![水平條形圖，類別與數值軸順序正常](axis-order-normal.png) | ![水平條形圖，類別自上而下顯示](axis-order-categories-reversed.png) | ![水平條形圖，數值軸顛倒且零位於右側](axis-order-values-reversed.png) |
| 類別由下往上排列；數值由左向右遞增。 | Planning、Development 與 Testing 由上往下排列。數值與工作表列順序保持不變。 | 類別保持正常順序；數值由右向左遞增。類別軸在右側的零處交叉。 |

## **停用折線圖的縱軸**

於縱軸呼叫[setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-)並傳入 `false`，即可隱藏該軸。範例建立一個預設資料的折線圖，並以隱藏縱軸的方式存檔。

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

## **停用折線圖的橫軸**

於水平軸呼叫[setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-)並傳入 `false`，即可隱藏該軸。範例建立一個預設資料的折線圖，並以隱藏水平軸的方式存檔。

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

呼叫[getShowMajorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMajorGridLines--)與[getShowMinorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMinorGridLines--)以檢查坐標軸目前顯示哪些格線。這些方法回傳目前的可見性。若要顯示次要格線，使用[getMinorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMinorGridLinesFormat--)並將其線條填色設定為實色且可見。若要隱藏，將填色設定為[FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/#NoFill)。[getMajorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) 以相同方式變更主要格線的線條填色。變更填色不會影響坐標軸的可見性與刻度。

此群組柱狀圖的縱軸最初僅顯示主要格線。範例先將次要格線以深橙色顯示，之後再隱藏，最後存檔。程式會在每個步驟印出格線的可見性。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(new Color(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 啟用次要格線 | 隱藏次要格線 |
| --- | --- |
| ![縱軸上主要格線之間的橙色次要格線](minor-gridlines-enabled.png) | ![相同的柱狀圖，僅顯示主要格線](minor-gridlines-hidden.png) |

## **變更類別軸**

使用[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-)可以選擇日期或文字類別軸。本範例需要 `ExistingChart.pptx`，其中第一張投影片的第一個圖形為圖表，且類別儲存格包含 Excel 數值日期。範例將水平軸改為日期軸。呼叫[setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-)並傳入 `false`，再以[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-)傳入 `1`，以及[setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-)傳入 `TimeUnitType.Months`，即可在每個月的間隔上放置主要刻度。

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

### **從資料判斷類別軸類型**

在填入類別之後，呼叫[setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--)，然後讀取[getCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getCategoryAxisType--) 以檢查選擇的類型。這在圖表可能接受文字標籤或數值日期時很有用。此方法在呼叫時即決定類型，並不會在之後的資料變更時自動重新評估。更換類別後請再次呼叫。

以下範例建立一個文字類別的圖表，並在選取的類型為 `CategoryAxisType.Text` 時印出 `true`。接著將類別儲存格的值改為日期，再次呼叫該方法，當選取的類型為 `CategoryAxisType.Date` 時印出 `true`。日期以數值 OLE Automation 形式儲存，計算方式為自 1899 年 12 月 30 日起的天數，而非日期字串。[setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) 控制這些值的顯示方式；它不會將文字轉換成數值日期。更多關於類別儲存格的資訊，請參考[圖表工作簿](/slides/zh-hant/java/chart-workbook/)。

使用自動判斷的前提是輸入已知為文字類別或數值日期，如本範例所示。對於普通數值標籤、混合類別或空資料，請明確呼叫[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisType-int-) 以符合預期意義。僅有數值本身不足以表明類別代表日期。

```java
import com.aspose.slides.*;
import java.time.LocalDate;

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
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // 正確

    LocalDate baseDate = LocalDate.of(1899, 12, 30);
    LocalDate[] dates = { LocalDate.of(2026, 1, 1), LocalDate.of(2026, 1, 2), LocalDate.of(2026, 2, 1) };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        categoryCell.setValue((double)(dates[i].toEpochDay() - baseDate.toEpochDay()));
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // 正確

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制類別軸標籤間隔**

當圖表的類別數量過多時，可減少可見坐標軸標籤的數量，而不必移除類別或資料點。先以`false`呼叫[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-)，再將想要的類別間隔傳入[setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-)。對於正常排序的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

間隔為 `3` 時會每隔兩個標籤顯示一次，僅顯示每第三個標籤，未顯示的標籤仍保留其欄位。自動間隔會根據可用空間自行決定間隔，未必會顯示所有標籤。

刻度線有獨立的控制方式。以`false`呼叫[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-)，再使用[setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) 設定其間隔。例如，`1` 會在每個類別間隔保留刻度線，同時標籤僅每三個類別顯示一次。使用[setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) 並設定為可見樣式，即可觀察結果。再次以`true`呼叫任一自動間隔設定器，圖表會重新選擇間隔。

以下獨立範例建立 24 個類別與一個系列，然後在 `CategoryAxisIntervals.pptx` 中儲存三張投影片：自動間隔、手動標籤間隔（刻度線獨立）以及恢復自動間隔。兩個副本均保留原始圖表資料，無需輸入投影片。水平標籤文字使密度差異更加明顯。

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

    // 幻燈片 2：顯示每三個標籤，但為每個類別保留刻度線。
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 幻燈片 3：讓圖表再次自行選擇間隔。
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自動間隔（幻燈片 1）：** 在此渲染中，每兩個類別標籤會顯示一次，且會換行。自動結果會因圖表尺寸、字型與渲染器不同而有所變化。

![自動類別標籤間隔，所有 24 欄皆可見](category-axis-automatic.png)

**手動間隔（幻燈片 2）：** 每三個標籤顯示在同一行，且刻度線仍保留於每個類別間隔。所有 24 欄（包括未顯示標籤的欄）仍保持可見且數值相同。第 3 張投影片恢復如上所示的自動外觀。

![手動類別標籤間隔為三，所有 24 欄皆可見](category-axis-manual.png)

### **選擇正確的軸與間隔**

對文字類別軸（如柱狀圖、折線圖、區域圖或條形圖的類別軸）使用此類別計數間隔。在柱狀圖中，它是水平軸；在水平條形圖中，類別軸為垂直軸，請對由[getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 回傳的軸套用此設定。對於同時具備系列軸的圖表，刻度線間隔亦適用於系列軸。

請勿使用類別標籤間隔來設定數值軸的數值比例。於數值軸上，[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) 代表數值間的差異，例如 `10` 會在 0、10、20… 等位置產生刻度。類別標籤間隔 `3` 則僅是計算類別位置，與其實際資料值無關。散佈圖與氣泡圖使用數值軸而非文字類別軸。對於日期軸，請依照[變更類別軸](#變更類別軸) 中的說明使用基於時間的主要單位與比例。

## **設定類別軸值的日期格式**

此範例將預設圖表資料換成四筆年度值。日期以 OLE Automation 序號儲存在第一個工作表（索引 `0`），計算方式為自 1899 年 12 月 30 日起的天數。使用[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) 並傳入 `CategoryAxisType.Date`，再以[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) 傳入 `false`，最後將 `yyyy` 傳給[setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) ，即可讓類別標籤獨立於儲存格格式，顯示四位數年份。

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

於垂直坐標軸呼叫[setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) 並傳入 `true`，提供標題文字，然後使用[setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) 來旋轉標題。角度以度數為單位；本範例將欄狀圖的數值軸標題旋轉 90 度後存檔。

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

## **設定類別或數值軸上的軸位置**

使用[setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) 以控制數值軸是於類別軸的類別之間交叉，還是於類別刻度標記處交叉。此設定僅適用於類別軸。範例在柱狀圖的水平類別軸上設定為 `true`，並存檔示範結果。

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

使用[setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) 可在不更改底層資料的情況下縮放數值軸的標籤。將[DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) 設為 `Millions`，則 60,000,000 會顯示為 60。範例建立一個柱狀圖，並將其垂直軸的顯示單位設定為百萬。

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

對數數值軸在正值跨越多個数量级時特別有用。例如，服務在五個時期可能分別收到 10、100、1,000、10,000 與 100,000 個請求。線性比例下，較小的值會聚集在接近零的位置。對數比例則使它們的相對增長更易於比較：相等的距離代表相等的比例，而非相等的差異。

於數值軸呼叫[setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) 並傳入 `true`，再使用[setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) 以選擇基底。此變更僅影響現有值的顯示方式，並不會改變資料或新增對數趨勢線。趨勢線是對資料進行擬合的獨立功能。

### **選擇數值軸與基底**

對於折線圖或柱狀圖，數值軸由[getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 回傳。對於水平條形圖，則由[getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) 回傳。散佈圖與氣泡圖有兩條數值軸，請為 X 軸值選擇水平軸，為 Y 軸值選擇垂直軸，或兩者皆設定。請勿對類別軸套用對數比例。

預設的對數基底為 `10`。對於 PPTX 圖表，基底可設定為 `2`~`1000`（含），亦支援小數基底如 `2.5`。使用 `10` 為基底時，10、100、1,000、10,000 等次方會等距分佈。

### **比較線性與對數比例**

以下獨立範例在第一張投影片建立一個包含五筆請求次數的折線圖，然後複製該投影片並在第二張投影片上啟用以 10 為底的對數數值軸。兩張投影片皆保留相同資料。

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

**線性比例（幻燈片 1）：** 相等的垂直距離代表請求次數的相等差異。最大值會主導圖表，使較小的值難以辨識。

![PowerPoint 線圖，顯示在直線數值軸上的五個請求計數](value-axis-linear.png)

**對數比例（幻燈片 2）：** 相等的垂直距離代表相等的比例。每個時期的請求量是前一時期的十倍，因而在以 10 為底的比例上呈現直線上升。坐標軸標籤仍顯示原始請求次數。

![同樣的五個請求計數於 PowerPoint 上的以 10 為底的對數數值軸](value-axis-logarithmic.png)

### **處理零與負值**

對數比例只能顯示嚴格正值。啟用前請先檢查資料；若零或負值具有意義，請保留線性比例或將其另行顯示。若在分析上適合排除這些值，請說明省略的原因。切勿以小的正值靜默取代，因會改變資料意涵。任何手動設定的對數軸最小值或最大值也必須為正。

## **常見問題**

**如何設定一條坐標軸與另一條交叉的值（坐標軸交叉）？**

使用[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) 來選擇交叉行為。若要指定數值交叉點，請使用[setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-)。這些設定可將坐標軸交叉移至合適的基線。

**如何相對於坐標軸定位刻度標籤？**

呼叫[setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-)，並使用[TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/) 的 `Low`、`High`、`NextTo` 或 `None`。若要控制刻度本身，請使用[setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) 或[setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-)；這些設定與標籤位置是分開的。