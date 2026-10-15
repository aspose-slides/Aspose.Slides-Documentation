---
title: 使用 Python 在簡報中自訂圖表坐標軸
linktitle: 圖表坐標軸
type: docs
url: /zh-hant/python-net/chart-axis/
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
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中自訂圖表坐標軸，以用於報告和可視化。"
---
## **概述**

本文說明如何使用 Aspose.Slides for Python via .NET 自訂圖表坐標軸。內容涵蓋計算坐標軸值、切換圖表行列、坐標軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、坐標軸定位、顯示單位以及對數比例。

## **在圖表的垂直軸上取得最大值**

建立一個 [簡報](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)，並以預設資料新增區域圖。於讀取計算後的坐標軸值之前，先呼叫 [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) 以確保圖表版面已更新。

讀取 [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) 與 [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) 取得坐標軸上下限，並讀取 [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) 與 [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) 取得刻度間隔。[actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) 與 [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) 提供時間單位比例，與日期坐標軸相關。範例將這些值儲存至本機變數，並儲存圖表。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在坐標軸之間交換資料**

使用 [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) 交換圖表資料中系列與類別的角色。先前的每個類別會變成系列，先前的每個系列會變成類別。此操作會改變資料的分組方式，並不會交換水平與垂直坐標軸。範例使用 [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) 將預設資料綁定至 `Sheet1!A1:D5`（包括標頭列與類別欄），然後再切換行列。最終儲存的圖表包含四個系列與三個類別。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **反轉坐標軸的繪圖順序**

使用 [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) 反轉類別或數值坐標軸。例如，水平條形圖可以依工作表的順序（規劃、開發、測試）由上至下顯示階段。反轉坐標軸會改變繪圖方向，並不會對工作表資料進行排序或重新排列。相比之下，[switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) 交換的是系列與類別的角色。

以下範例建立一個包含三個階段與一個系列的水平條形圖，並產生三張投影片：正常順序、類別反向、數值反向。每個副本使用相同資料集，且每張投影片只反轉一條坐標軸。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # 投影片 2：將第一個類別顯示在頂部。
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # 保持水平數值坐標軸在底部。
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # 投影片 3：僅反轉水平數值刻度。
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

反轉坐標軸亦可將垂直坐標軸移至圖表的對側。[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) 控制另一坐標軸在被設定的坐標軸上何處交叉。在第 2 張投影片中，將其設定為 `MAXIMUM`，即使類別坐標軸已反轉，也讓水平數值坐標軸保持在底部。若需指定特定交叉點，請使用 [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/)。變更方向時請檢查交叉設定，特別是圖表已有自訂交叉點的情況。將 `is_plot_order_reversed` 設回 `False` 後會恢復正常繪圖方向；交叉設定與之獨立。

| 正常順序（投影片 1） | 類別反向（投影片 2） | 數值反向（投影片 3） |
| --- | --- | --- |
| ![水平條形圖，類別和數值軸的正常順序](axis-order-normal.png) | ![水平條形圖，類別從上到下顯示](axis-order-categories-reversed.png) | ![水平條形圖，數值軸反向，零位於右側](axis-order-values-reversed.png) |
| 類別從底部到頂部；數值從左到右遞增。 | Planning、Development、Testing 從上到下排列。數值和工作表行順序保持不變。 | 類別保持正常順序；數值從右到左遞增。類別軸在右側的零點交叉。 |

## **停用折線圖的垂直軸**

將垂直軸的 [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) 設為 `False` 即可隱藏。範例建立一個預設資料的折線圖，並以垂直軸隱藏的方式儲存。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **停用折線圖的水平軸**

將水平軸的 [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) 設為 `False` 即可隱藏。範例建立一個預設資料的折線圖，並以水平軸隱藏的方式儲存。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **變更類別坐標軸**

將 [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) 設為日期或文字類別坐標軸。本範例需要 `ExistingChart.pptx`，其中第一張投影片的第一個圖形為圖表，且類別儲存格包含 Excel 數值日期。範例將水平坐標軸改為日期坐標軸，並將 [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) 設為 `False`、[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) 設為 `1`、[major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) 設為 months，使主要刻度間隔為一個月。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **控制類別坐標軸標籤間隔**

當圖表類別過多時，可減少可見的坐標軸標籤數量，而不必移除類別或資料點。將 [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) 設為 `False`，再將 [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) 設為想要的類別間隔。對於正常順序的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

間隔為 `3` 時會顯示每第三個標籤，兩個隱藏的標籤介於之間，並不會移除相應的欄位。自動間隔會根據可用空間選擇間隔，未必會顯示每個標籤。

刻度線有獨立的控制項。將 [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) 設為 `False`，並使用 [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) 設定其間隔。例如，`1` 會在每個類別間隔保留刻度線，而標籤僅每三個類別顯示一次。將 [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) 設為可見樣式即可看到效果。若將任一自動間隔屬性回復為 `True`，圖表會自行重新計算間隔。

以下自包含範例建立 24 個類別與一個系列，然後在 `CategoryAxisIntervals.pptx` 中儲存三張投影片：自動間隔、手動標籤間隔（刻度線獨立）以及恢復自動間隔。兩個副本保留原始圖表資料，無需輸入簡報。水平標籤文字的差異有助於觀察密度。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # 投影片 2：顯示每三個標籤，但保持每個類別都有刻度線。
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # 投影片 3：讓圖表再次自行選擇兩種間隔。
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**自動間隔（投影片 1）：** 此呈現中每兩個類別標籤顯示一次，且會換行。自動結果會因圖表大小、字型和渲染器不同而變化。

![自動類別標籤間隔，全部 24 欄皆可見](category-axis-automatic.png)

**手動間隔（投影片 2）：** 每三個標籤顯示在同一行，刻度線仍保留在每個類別間隔。所有 24 欄（即使沒有標籤）仍保持可見且值相同。投影片 3 恢復上述的自動外觀。

![手動類別標籤間隔為三，全部 24 欄皆可見](category-axis-manual.png)

### **選擇正確的坐標軸與間隔**

此類別計數間隔適用於文字類別坐標軸，例如柱狀圖、折線圖、面積圖或條形圖的類別坐標軸。於柱狀圖中，它是水平坐標軸；於水平條形圖中，類別坐標軸為垂直坐標軸，請將設定套用至 [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)。刻度線間隔亦適用於具有系列坐標軸的圖表。

請勿使用類別標籤間隔來設定數值坐標軸的數值刻度。在數值坐標軸上，[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) 代表值的差距，例如 `10` 會在 0、10、20… 產生刻度。類別標籤間隔 `3` 則是以類別位置計數，與實際數值無關。散佈圖與氣泡圖使用數值坐標軸而非文字類別坐標軸。對於日期坐標軸，請參考 [變更類別坐標軸](#變更類別坐標軸) 中的時間基礎單位與比例設定。

## **設定類別坐標軸值的日期格式**

此範例以四個年度值取代預設圖表資料。日期以 OLE Automation 序號儲存在第一個工作表（索引 `0`）中。將 [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) 設為日期坐標軸，停用 [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/)，並將 `yyyy` 指派給 [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)，使類別標籤以四位數年份顯示，且不受儲存格格式影響。

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **為圖表坐標軸標題設定旋轉角度**

在垂直坐標軸上啟用 [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/)，提供標題文字，並將 [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) 設為所需的度數。此範例將柱狀圖的數值軸標題旋轉 90 度後儲存。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **在類別或數值坐標軸上設定坐標軸位置**

使用 [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) 控制數值坐標軸是於類別之間交叉，還是於類別刻度標記處交叉。此屬性僅適用於類別坐標軸。範例將其設定為 `True`，於柱狀圖的水平類別坐標軸上使用，並儲存結果。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **在圖表數值坐標軸上設定顯示單位**

將 [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) 設定為顯示單位，可在不變更底層資料的情況下調整數值軸標籤的縮放。將 [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) 設為 `MILLIONS` 後，60000000 會顯示為 60。範例建立柱狀圖，並將其垂直坐標軸的顯示單位設定為百萬。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **設定對數數值坐標軸**

當正值跨越多個數量級時，對數數值坐標軸相當有用。例如，某服務在五個期間可能分別收到 10、100、1,000、10,000、100,000 個請求。若使用線性比例，較小的值會聚集在接近零的位置。對數比例則以相同比例的距離呈現相同的倍數變化，使相對增長更易比較。

將數值坐標軸的 [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) 設為 `True`，並使用 [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) 選擇底數。此設定會改變現有值的顯示方式，但不會改變資料或加入對數趨勢線。趨勢線是基於資料的擬合關係，屬於另一功能。

### **選擇數值坐標軸與底數**

對於折線圖或柱狀圖，數值坐標軸為 [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)。對於水平條形圖，則為 [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/)。散佈圖與氣泡圖擁有兩個數值坐標軸，請為 X 軸選擇水平坐標軸，為 Y 軸選擇垂直坐標軸，或兩者皆設定。請勿對類別坐標軸套用對數比例。

預設的對數底數為 `10`。對於 PPTX 圖表，底數可設定為 2 至 1000（含），亦支援小數底數（如 `2.5`）。使用底數 `10` 時，10、100、1,000、10,000 等次方會等距排列。

### **比較線性與對數比例**

以下自包含範例在第一張投影片建立一個包含五筆請求計數的折線圖，然後複製該投影片並在第二張投影片啟用底數為 10 的對數數值坐標軸。兩張投影片皆保留相同資料。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # 保持第一張投影片為線性，僅變更副本的數值軸比例。
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**線性比例（投影片 1）：** 相等的垂直距離代表相等的請求量差距。最大值主導圖表，較小的值難以分辨。

![Linear value axis line chart showing five request counts](value-axis-linear.png)

**對數比例（投影片 2）：** 相等的垂直距離代表相等的比例。每個期間的請求量是前一期間的十倍，因此在底數 10 的比例下，點形成直線上升。坐標軸標籤仍顯示原始的請求量。

![Logarithmic value axis line chart showing the same five request counts](value-axis-logarithmic.png)

### **處理零與負值**

對數比例只能顯示嚴格正值。啟用前請先檢查資料。若零或負值具有意義，請保留線性比例或另行顯示。若排除這些值符合分析需求，請說明排除原因。切勿悄悄將零或負值替換為小的正數，因為這會改變資料意義。任何手動設定的最小值或最大值亦必須為正數。

## **常見問題**

**如何設定兩條坐標軸交叉的數值（坐標軸交叉）？**

使用 [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) 來選擇交叉行為。若要指定具體的數值交叉位置，請設定 [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/)。這些設定可讓您將坐標軸交叉移動至適當的基準線。

**如何相對於坐標軸定位刻度標籤？**

使用 [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) 搭配 [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) 之 `LOW`、`HIGH`、`NEXT_TO` 或 `NONE` 進行設定。若要控制刻度線本身，請使用 [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) 或 [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/)，它們與標籤定位是獨立的。