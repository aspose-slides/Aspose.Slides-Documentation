---
title: 在簡報中使用 Python 自訂圖表座標軸
linktitle: 圖表座標軸
type: docs
url: /zh-hant/python-java/chart-axis/
keywords:
- 圖表座標軸
- 垂直座標軸
- 水平座標軸
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
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 於 PowerPoint 簡報中自訂圖表座標軸，以製作報告與視覺化。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Python via Java 自訂圖表座標軸。內容涵蓋計算後的座標值、切換圖表列與欄、座標軸可見性、類別標籤與刻度標記間隔、日期類別與格式、標題旋轉、座標軸定位、顯示單位以及對數比例。

## **取得圖表垂直座標軸的最大值**

建立一個 [簡報](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 並加入預設資料的區域圖表。於讀取計算後的座標值之前，先呼叫 [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) 以確保圖表版面已更新。

讀取 [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) 與 [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) 取得座標軸上下限，並使用 [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) 與 [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) 取得刻度間隔。 [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) 與 [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) 提供時間單位比例，與日期座標軸相關。範例會將這些值存入本機變數並儲存圖表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **交換座標軸之間的資料**

使用 [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) 交換圖表資料中系列與類別的角色。先前的每個類別會變成系列，先前的每個系列會變成類別。這會改變資料的分組方式，並不會交換水平與垂直座標軸。範例使用 [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) 將預設資料繫結至 `Sheet1!A1:D5`（包含標題列與類別欄），然後切換列與欄。它會儲存一個包含四個系列與三個類別的圖表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **反轉座標軸的繪製順序**

使用 [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) 反轉類別或數值座標軸。例如，水平長條圖可以依工作表的順序從上至下顯示專案階段：規劃、開發、測試。反轉座標軸會改變繪製方向；不會排序或重新排列工作簿資料。相較之下，[switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) 交換系列與類別的角色。

以下範例建立一個具有三個階段與一個系列的水平長條圖。它會儲存三張投影片：正常順序、類別反轉、數值反轉。每個副本使用相同的資料集，且每張投影片只反轉一個座標軸。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # 投影片 2：在頂部顯示第一個類別。
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # 保持水平數值座標軸在底部。
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # 投影片 3：僅反轉水平數值刻度。
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

反轉座標軸還可以將垂直於圖表的另一座標軸移至繪圖區的相對側。[setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) 控制另一座標軸在被設定座標軸的何處交叉。在第 2 張投影片中，於反轉的類別座標軸上呼叫它並傳入 [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) 會讓水平數值座標軸保持在底部。若需特定交叉點，請使用 [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt)。變更方向時請檢查交叉設定，特別是圖表已設定自訂交叉點的情況。呼叫 [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) 並傳入 `False` 可恢復正常繪製方向；交叉設定是獨立的。

| 正常順序（投影片 1） | 反轉類別（投影片 2） | 反轉數值（投影片 3） |
| --- | --- | --- |
| ![Normal category and value axis order horizontal bar chart](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| 類別由下至上排列；數值由左至右遞增。 | 規劃、開發、測試由上至下排列。數值與工作表列順序不變。 | 類別保持正常順序；數值由右至左遞增。類別座標軸在右側零點交叉。 |

## **隱藏折線圖的垂直座標軸**

在垂直座標軸上呼叫 [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) 並傳入 `False` 以隱藏它。範例建立一個具有預設資料的折線圖，並以隱藏垂直座標軸的方式儲存。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **隱藏折線圖的水平座標軸**

在水平座標軸上呼叫 [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) 並傳入 `False` 以隱藏它。範例建立一個具有預設資料的折線圖，並以隱藏水平座標軸的方式儲存。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **變更類別座標軸**

使用 [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) 以選擇日期或文字類別座標軸。此範例需要 `ExistingChart.pptx`，其中第一張投影片的第一個圖形為圖表，且類別儲存格包含 Excel 數值日期。它會將水平座標軸變更為日期座標軸。呼叫 [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) 並傳入 `False`、[setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) 傳入 `1`，以及 [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) 傳入 [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) 以在每月間隔放置主要刻度。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **控制類別座標軸標籤間隔**

當圖表類別過多時，減少可見座標軸標籤的數量，而不必移除類別或資料點。呼叫 [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) 並傳入 `False`，然後將欲設定的類別間隔傳給 [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing)。對於正常順序的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

間隔為 `3` 時會顯示每第三個標籤，兩個未顯示的標籤介於顯示的標籤之間。這不會移除相對應的欄位。自動間隔會根據可用空間選擇間隔，未必會顯示所有標籤。

刻度標記有獨立的控制項。呼叫 [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) 並傳入 `False`，再使用 [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) 設定其間隔。例如，`1` 會在每個類別間隔保留刻度標記，而標籤僅每三個類別顯示一次。使用 [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) 以可見樣式顯示結果。再次將任一自動間隔設定器傳入 `True`，圖表會重新選擇自動間隔。

以下自包含範例建立 24 個類別與一個系列，然後在 `CategoryAxisIntervals.pptx` 中儲存三張投影片：自動間隔、手動標籤間隔（刻度標記獨立）以及恢復自動間隔。兩個副本保留原始圖表資料。無需輸入簡報。水平標籤文字使密度差異一目了然。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # 投影片 2：顯示每第三個標籤，但保留每個類別的刻度標記。
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # 投影片 3：讓圖表再次自行選擇兩個間隔。
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**自動間隔（投影片 1）:** 此呈現中每兩個類別標籤會顯示一次，且會換行成兩行。自動結果會因圖表大小、字型與轉譯器不同而有所變化。

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**手動間隔（投影片 2）:** 每三個標籤顯示於同一行，且刻度標記仍保留在每個類別間隔。所有 24 個欄位（即使沒有標籤）仍保持可見且值相同。投影片 3 會恢復上述的自動外觀。

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **選擇正確的座標軸與間隔**

對於文字類別座標軸（例如柱狀圖、折線圖、區域圖或長條圖的類別座標軸），使用此類別計數間隔。在柱狀圖中，它是水平座標軸；在水平長條圖中，類別座標軸為垂直方向，請對由 [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) 回傳的座標軸套用這些設定。刻度標記間隔亦適用於具有系列座標軸的圖表。

請勿使用類別標籤間隔來設定數值座標軸的數值比例。在數值座標軸上，[setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) 指定值的差異，例如 `10` 會在 0、10、20… 等位置產生刻度。類別標籤間隔 `3` 則是按類別位置計算，與資料值無關。散佈圖與氣泡圖使用數值座標軸而非文字類別座標軸。對於日期座標軸，請參照【[變更類別座標軸](#變更類別座標軸)】使用基於時間的主要單位與比例。

## **設定類別座標軸值的日期格式**

此範例以四個年度值取代預設圖表資料。日期以 OLE Automation 序號儲存在第一個工作表（索引 `0`），計算方式為自 1899 年 12 月 30 日起的天數。使用 [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) 並傳入 [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date)，接著呼叫 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) 並傳入 `False`，再將 `yyyy` 傳給 [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) 使類別標籤獨立於儲存格格式顯示四位數年份。

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定圖表座標軸標題的旋轉角度**

在垂直座標軸上呼叫 [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) 並傳入 `True`，提供標題文字，並在標題文字方塊格式中設定旋轉角度。角度以度為單位；此範例將柱狀圖的數值軸標題旋轉 90 度後儲存。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在類別或數值座標軸上設定座標軸位置**

使用 [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) 控制數值座標軸是否在類別之間或於類別刻度標記處交叉。此設定僅適用於類別座標軸。範例將其設為 `True`，作用於柱狀圖的水平類別座標軸，並儲存結果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在圖表數值座標軸上設定顯示單位**

使用 [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) 以在不改變底層資料的前提下縮放數值座標軸標籤。將 [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) 設為 `Millions` 時，60,000,000 會顯示為 60。範例建立柱狀圖，並將垂直座標軸的顯示單位設定為百萬。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定對數值座標軸**

當正值跨越數個數量級時，對數值座標軸非常有用。例如，某服務在五個期間內分別收到 10、100、1,000、10,000 與 100,000 筆請求。在線性比例下，較小的值會聚集在接近零的位置。對數比例會使它們的相對成長更易比較：等距代表等比例而非等差距。

在數值座標軸上呼叫 [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) 並傳入 `True`，再使用 [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) 選擇底數。這會改變現有值的顯示方式，並不會改變資料或加入對數趨勢線。趨勢線是對資料的擬合關係，屬於另一項功能。

### **選擇數值座標軸與底數**

對於折線圖或柱狀圖，數值座標軸由 [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) 回傳。對於水平長條圖，則由 [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) 回傳。散佈圖與氣泡圖有兩個數值座標軸，請為 X 值選擇水平座標軸，為 Y 值選擇垂直座標軸，或兩者皆設定。請勿將對數比例套用於類別座標軸。

預設對數底數為 `10`。對於 PPTX 圖表，可使用 `2` 至 `1000` 之間的整數或分數底數（如 `2.5`）。使用底數 `10` 時，10、100、1,000、10,000 等次方會等距排列。

### **比較線性與對數比例**

以下自包含範例在第一張投影片建立包含五筆請求量的折線圖，然後複製該投影片並在第二張投影片上啟用底數為 10 的對數值座標軸。兩張投影片保留相同資料。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # 保持第一張投影片為線性，僅變更副本的數值座標軸比例。
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**線性比例（投影片 1）:** 等距的垂直距離代表請求量的等差。最大值主導圖表，較小的值難以辨識。

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**對數比例（投影片 2）:** 等距的垂直距離代表等比例。每個期間的請求量是前一個的十倍，因此在底數為 10 的尺度上形成直線上升。座標軸標籤仍顯示原始的請求量。

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **處理零與負值**

對數比例只能顯示嚴格正值。啟用前請先檢查資料。若零或負值具意義，請保留線性比例或將其分別顯示。若排除這些值符合分析需求，請說明排除原因。切勿偷偷將它們換成小的正數，因會改變資料意義。任何手動設定的對數座標軸最小值或最大值亦必須為正。

## **常見問題**

**如何設定一個座標軸交叉另一個座標軸的值（交叉點）？**

使用 [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) 以選擇交叉行為。若要指定數值交叉點，請使用 [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt)。這些設定可將座標軸交叉移至合適的基線。

**如何相對於座標軸定位刻度標籤？**

呼叫 [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) 並使用 [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/)：`Low`、`High`、`NextTo` 或 `None`。若要控制刻度標記本身，請使用 [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) 或 [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark)；這與標籤定位是分開的。