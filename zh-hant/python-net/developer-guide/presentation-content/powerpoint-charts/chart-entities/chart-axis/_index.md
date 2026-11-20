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
description: "了解如何使用 Aspose.Slides for Python via .NET 於 PowerPoint 與 OpenDocument 簡報中自訂圖表坐標軸，以製作報告與視覺化。"
---
## **概覽**

本文說明如何使用 Aspose.Slides for Python via .NET 來自訂圖表坐標軸。內容涵蓋計算後的軸值、切換圖表列與欄、坐標軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、坐標軸定位、顯示單位以及對數比例。

## **取得圖表垂直軸的最大值**

建立一個[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)，並以預設資料新增區域圖表。於讀取計算後的軸值之前呼叫[validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/)以確保圖表版面已更新。

讀取[actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/)與[actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/)取得軸限制，並讀取[actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/)與[actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/)取得刻度間隔。[actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/)與[actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/)提供時間單位比例，與日期軸相關。範例將這些值存入本機變數，並儲存圖表。

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

## **交換坐標軸之間的資料**

使用[switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/)交換圖表資料中系列與類別的角色。先前的每個類別會變成系列，先前的每個系列會變成類別。此動作僅變更資料的分組方式，並不交換水平與垂直坐標軸。範例使用[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)將預設資料綁定至`Sheet1!A1:D5`（包含標頭列與類別欄），然後再切換列與欄。它會產生一個包含四個系列與三個類別的圖表。

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

## **顛倒坐標軸的繪製順序**

使用[is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/)顛倒類別軸或數值軸的繪製順序。例如，水平條形圖可以依工作表的順序（規劃、開發、測試）從上到下顯示專案階段。顛倒坐標軸會改變繪製方向，並不會對工作表資料進行排序或重新排列。相較之下，[switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/)會交換系列與類別的角色。

以下範例建立一個包含三個階段與一個系列的水平條形圖，並產生三張投影片：正常順序、顛倒類別、顛倒數值。每個副本使用相同資料集，且每張投影片僅顛倒一條坐標軸。

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

    # 第 2 張投影片：將第一個類別顯示在最上方。
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # 保持水平數值軸位於底部。
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # 第 3 張投影片：僅顛倒水平數值比例。
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

顛倒坐標軸也可以將垂直坐標軸移到繪圖區的相對側。[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/)控制另一條坐標軸在被配置的坐標軸上交叉的位置。在第 2 張投影片中，將其設定為`MAXIMUM`於顛倒的類別軸，使水平數值軸保持在底部。若需特定交叉點，請使用[cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/)。在變更方向時務必檢查交叉設定，特別是圖表已設定自訂交叉點時。將`is_plot_order_reversed`重新設為`False`即可恢復正常繪製方向；交叉設定獨立於此。

| 正常順序（第 1 張投影片） | 顛倒類別（第 2 張投影片） | 顛倒數值（第 3 張投影片） |
| --- | --- | --- |
| ![正常類別與數值軸順序的水平條形圖](axis-order-normal.png) | ![類別由上而下顯示的水平條形圖](axis-order-categories-reversed.png) | ![數值軸顛倒且零點在右側的水平條形圖](axis-order-values-reversed.png) |
| 類別由底部向上排列；數值由左至右遞增。 | 規劃、開發、測試由上而下排列。數值與工作表列順序保持不變。 | 類別保留正常順序；數值由右至左遞增。類別軸在右側的零點交叉。 |

## **為折線圖停用垂直坐標軸**

將垂直坐標軸的[is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/)設為`False`即可隱藏。範例建立一個預設資料的折線圖，並以隱藏垂直坐標軸的方式儲存。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **為折線圖停用水平坐標軸**

將水平坐標軸的[is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/)設為`False`即可隱藏。範例建立一個預設資料的折線圖，並以隱藏水平坐標軸的方式儲存。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **顯示或隱藏圖表格線**

讀取[show_major_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_major_grid_lines/)與[show_minor_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_minor_grid_lines/)以檢查坐標軸顯示哪些格線。這兩個屬性皆為唯讀。若要顯示次要格線，請將[minor_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_grid_lines_format/)的線條填充設定為實心且選擇可見顏色；若要隱藏，將填充類型設為`FillType.NO_FILL`。主要格線則使用[major_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_grid_lines_format/)`.line.fill_format`。變更填充不會影響坐標軸可見性與刻度標記。

此群組柱狀圖的垂直坐標軸預設顯示主要格線而隱藏次要格線。範例先以橙色顯示次要格線，之後再隱藏，最後儲存簡報。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 30, 660, 230)
    axis = chart.axes.vertical_axis
    print(f"Initial: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    minor_fill = axis.minor_grid_lines_format.line.fill_format
    minor_fill.fill_type = slides.FillType.SOLID
    minor_fill.solid_fill_color.color = slides.Color.dark_orange
    print(f"Enabled: minor={axis.show_minor_grid_lines}")

    minor_fill.fill_type = slides.FillType.NO_FILL
    print(f"Hidden: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    presentation.save("ChartGridlines.pptx", slides.export.SaveFormat.PPTX)
```

| 次要格線已啟用 | 次要格線已隱藏 |
| --- | --- |
| ![垂直坐標軸上主要格線之間的橙色次要格線](minor-gridlines-enabled.png) | ![僅顯示主要格線的相同柱狀圖](minor-gridlines-hidden.png) |

## **變更類別坐標軸**

將[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/)設定為日期或文字類別軸。本範例需要`ExistingChart.pptx`，圖表位於第一張投影片的第一個圖形，且類別儲存格包含 Excel 數字日期值。它會將水平坐標軸變更為日期軸。將[is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/)設為`False`、[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/)設為`1`，以及[major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/)設為月份，則主要刻度會以每月間隔顯示。

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

### **根據資料判斷類別坐標軸類型**

在填入類別後呼叫[set_category_axis_type_automatically](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/set_category_axis_type_automatically/)，再讀取[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/)以檢查選擇結果。當同一圖表可能接收文字標籤或數值日期時，這非常有用。此方法在呼叫時即決定類型，並不會開啟持續偵測之後資料變更的模式。更換類別後需再次呼叫。

以下範例先建立一個文字類別的圖表並印出`TEXT`，接著將類別儲存格值換成日期並再次呼叫，印出`DATE`。日期以數值 OLE Automation 形式儲存，表示自 1899 年 12 月 30 日以來的天數，而非字串。[custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) 控制這些值的顯示方式，並不會將文字轉換為數值日期。更多類別儲存格資訊，請參閱[Chart Workbook](/slides/zh-hant/python-net/chart-workbook/)。

在已知輸入僅為文字類別或數值日期時，請使用自動判斷。對於一般數值標籤、混合類別或空白資料，請明確設定[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) 以符合預期意義。僅有數值本身不足以表示類別為日期。

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series_name = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name, chart.type)
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.get_cell(0, i + 1, 0, label)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # 文字

    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.get_cell(0, i + 1, 0)
        category_cell.value = float((category_date - date(1899, 12, 30)).days)
        category_cell.custom_number_format = "yyyy-mm-dd"

    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # 日期

    presentation.save("AutomaticCategoryAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **控制類別坐標軸標籤間隔**

當圖表類別過多時，可減少可見標籤數量而不必刪除類別或資料點。將[is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/)設為`False`，再將[tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/)設定為想要的類別間隔。對於正常順序的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

間隔為`3`時會顯示每第三個標籤，兩個標籤會被隱藏，對應的欄位仍保留。自動間隔會根據可用空間選擇間隔，未必顯示所有標籤。

刻度線有獨立的控制。將[is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/)設為`False`，並使用[tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/)設定其間隔。例如，`1` 會在每個類別間隔保留刻度線，而標籤僅每三個類別顯示一次。將[major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/)設為可見樣式，以便觀察結果。將任一自動間隔屬性重新設為`True`，圖表會再次自行選擇間隔。

以下自包含範例建立 24 個類別與一個系列，並在 `CategoryAxisIntervals.pptx` 中產生三張投影片：自動間隔、手動標籤間隔（刻度線獨立）以及恢復自動間隔。兩個副本保留原始圖表資料，無需輸入簡報。水平標籤文字有助於觀察密度差異。

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

    # 第 2 張投影片：顯示每三個標籤，但為每個類別保留刻度線。
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # 第 3 張投影片：讓圖表再次選擇兩個間隔。
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**自動間隔（第 1 張投影片）：** 此顯示中，每兩個類別標籤會顯示一次，且會自動換行。自動結果會因圖表大小、字型與渲染方式而異。

![所有 24 個欄位皆可見的自動類別標籤間隔](category-axis-automatic.png)

**手動間隔（第 2 張投影片）：** 每三個標籤顯示在同一行，刻度線仍保留在每個類別間隔。所有 24 個欄位（包括未顯示標籤的欄位）仍保持可見且值相同。第 3 張投影片恢復前述的自動外觀。

![所有 24 個欄位皆可見的手動間隔（間隔為 3）](category-axis-manual.png)

### **選擇正確的坐標軸與間隔**

此類別計數間隔適用於文字類別坐標軸，例如柱狀圖、折線圖、區域圖或條形圖的類別坐標軸。於柱狀圖中為水平坐標軸；於水平條形圖中則為垂直坐標軸，請對[vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)套用上述設定。刻度間隔亦適用於具有系列坐標軸的圖表。

請勿使用類別標籤間隔來設定數值坐標軸的數值比例。於數值坐標軸上，[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) 代表數值差距，例如 `10` 會在 0、10、20… 等位置產生刻度。類別標籤間隔 `3` 則僅依類別位置計算，與實際資料值無關。散佈圖與氣泡圖使用數值坐標軸而非文字類別坐標軸。若為日期坐標軸，請使用[變更類別坐標軸](#變更類別坐標軸) 中描述的時間為基礎的主要單位與比例。

## **設定類別坐標軸值的日期格式**

此範例將預設圖表資料取代為四筆年值。日期以 OLE Automation 序號儲存在第一個工作表（索引 `0`）中。將[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) 設為日期軸，停用[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/)，並將[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) 設為 `yyyy`，使類別標籤以四位數年份顯示，而不受儲存格格式影響。

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

在垂直坐標軸上啟用[has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/)，提供標題文字，並將[rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) 設為旋轉角度。角度以度為單位；本範例將柱狀圖的數值軸標題旋轉 90 度後儲存。

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

## **設定類別或數值坐標軸的坐標軸位置**

使用[axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) 控制數值坐標軸是否於類別坐標軸的類別之間或於類別刻度處交叉。此屬性僅適用於類別坐標軸。範例將其於柱狀圖的水平類別坐標軸設為`True`，並儲存結果。

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

將[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) 設為顯示單位，可在不變更底層資料的情況下縮放數值坐標軸標籤。將[DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) 設為`MILLIONS`，則 60,000,000 會顯示為 60。範例建立柱狀圖，並將其垂直坐標軸的顯示單位設為百萬。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **設定對數比例的數值坐標軸**

當正值跨越多個量級時，對數數值坐標軸非常有用。例如，某服務在五個期間分別收到 10、100、1,000、10,000、100,000 筆請求。線性比例下，較小的值會聚集在接近零的位置；對數比例則讓相對增長更易比較：相等的距離代表相等的比例而非相等的差異。

將值坐標軸的[is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) 設為`True`，並使用[log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) 選擇底數。此設定會改變既有值的顯示方式，並不會修改資料或新增對數趨勢線。趨勢線是對資料擬合的獨立功能。

### **選擇數值坐標軸與底數**

對於折線圖或柱狀圖，數值坐標軸為[vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)。對於水平條形圖，則為[horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/)。散佈圖與氣泡圖有兩條數值坐標軸，請分別對 X 值使用水平軸、Y 值使用垂直軸，或同時套用。請勿對類別坐標軸使用對數比例。

預設的對數底數為 `10`。對於 PPTX 圖表，底數可介於 `2` 到 `1000`（含），亦支援小數底數如 `2.5`。使用底數 `10` 時，10、100、1,000、10,000 等次方會等距分佈。

### **比較線性與對數比例**

以下自包含範例在第 1 張投影片建立折線圖顯示五筆請求量，然後複製該投影片並在第 2 張啟用底數為 10 的對數數值坐標軸。兩張投影片均保留相同資料。

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

**線性比例（第 1 張投影片）：** 等距的垂直距離代表請求量的等差。最大值主導圖表，使較小值難以辨識。

![折線圖顯示五筆請求量的線性數值坐標軸](value-axis-linear.png)

**對數比例（第 2 張投影片）：** 等距的垂直距離代表等比例。每個期間的請求量是前一期間的十倍，於底數 10 的比例尺上形成直線上升。坐標軸標籤仍顯示原始請求量。

![相同五筆請求量於底數 10 的對數數值坐標軸上](value-axis-logarithmic.png)

### **處理零與負值**

對數比例只能顯示嚴格正值。啟用前請先檢查資料。若零或負值具有意義，請保留線性比例或另行呈現。若排除這些值符合分析需求，請說明原因。不要悄悄將它們替換為小的正值，因為會改變資料意義。任何手動設定的最小值或最大值於對數坐標軸上亦必須為正。

## **常見問題**

**如何設定坐標軸交叉的數值（坐標軸交叉點）？**

使用[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) 來選擇交叉行為。若要指定數值交叉點，請設定[cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/)。這些設定可讓您將坐標軸交叉移動至合適的基準線。

**如何相對於坐標軸定位刻度標籤？**

使用[tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) 搭配[TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/)：`LOW`、`HIGH`、`NEXT_TO` 或 `NONE`。若要控制刻度線本身，請使用[major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) 或[minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/)，這與標籤位置設定是分開的。