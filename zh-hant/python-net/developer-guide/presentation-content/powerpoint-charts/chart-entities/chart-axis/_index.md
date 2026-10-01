---
title: 使用 Python 在簡報中自訂圖表軸
linktitle: 圖表軸
type: docs
url: /zh-hant/python-net/chart-axis/
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
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "發現如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中自訂圖表軸，以用於報告與視覺化。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Python via .NET 來自訂圖表軸。內容涵蓋計算軸值、切換圖表列與欄、軸的可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、軸定位以及顯示單位。

## **在圖表上取得垂直軸的最大值**

建立一個[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)並新增一個具有預設資料的區域圖。在讀取計算後的軸值之前，先呼叫[validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/)以確保圖表版面已更新。

讀取[actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/)與[actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/)以取得軸的上下限，並讀取[actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/)與[actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/)以取得刻度間隔。[actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/)與[actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/)提供時間單位的比例，與日期軸相關。範例將這些值儲存於本機變數，並儲存圖表。

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

## **交換軸之間的資料**

使用[switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/)交換圖表資料中系列與類別的角色。每個原本的類別會變成系列，原本的系列會變成類別。此動作會變更資料的分組方式，並不會交換水平與垂直軸。範例使用[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)將預設資料繫結到`Sheet1!A1:D5`（包含標題列與類別欄），然後再切換列與欄。它會儲存一個包含四個系列與三個類別的圖表。

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

## **停用折線圖的垂直軸**

將[is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/)設定為`False`即可隱藏垂直軸。範例建立一個具有預設資料的折線圖，並將垂直軸隱藏後儲存。

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

將[is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/)設定為`False`即可隱藏水平軸。範例建立一個具有預設資料的折線圖，並將水平軸隱藏後儲存。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **變更類別軸**

設定[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/)以選擇日期或文字類別軸。此範例需要`ExistingChart.pptx`，其中第一張投影片的第一個圖形為圖表，且類別儲存格包含數值型 Excel 日期。它會將水平軸變更為日期軸。將[is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/)設定為`False`、[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/)設定為`1`，並將[major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/)設定為月份，以在每月間隔放置主要刻度。

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

## **控制類別軸標籤間隔**

當圖表有許多類別時，可減少可見軸標籤的數量，而不必移除類別或資料點。將[is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/)設定為`False`，再將[tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/)設定為所需的類別間隔。對於按正常順序排列的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | 類別 1, 類別 2, 類別 3, ... 類別 24 |
| `2` | 類別 1, 類別 3, 類別 5, ... 類別 23 |
| `3` | 類別 1, 類別 4, 類別 7, ... 類別 22 |

間隔為 `3` 時會顯示每三個標籤，兩個標籤會被隱藏。這不會移除相對應的欄位。自動間隔會根據可用空間選擇間隔；不一定會顯示所有標籤。

刻度線有獨立的控制項。將[is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/)設定為`False`，並使用[tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/)設定其間隔。例如，`1` 會在每個類別間隔保留刻度線，而標籤僅每三個類別顯示一次。將[major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/)設定為可見樣式即可看到結果。將任一自動間隔屬性重新設定為`True`，圖表會再次自行選擇間隔。

以下獨立範例會建立 24 個類別與一個系列，然後在`CategoryAxisIntervals.pptx` 中儲存三張投影片：自動間隔、手動標籤間隔（刻度線獨立），以及恢復自動間隔。兩個副本保留原始圖表資料，無需輸入投影片。水平標籤文字能讓密度差異一目了然。

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

    # 第 2 張投影片：顯示每第三個標籤，但保留每個類別的刻度線。
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # 第 3 張投影片：讓圖表再次自行選擇兩個間隔。
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatic spacing (slide 1):** In this rendering, every second category label is displayed and wraps onto two lines. The automatic result can vary with chart size, fonts, and the renderer.

![自動類別標籤間隔（顯示全部 24 欄）](category-axis-automatic.png)

**Manual spacing (slide 2):** Every third label is displayed on one line, while tick marks remain at every category interval. All 24 columns, including those without labels, remain visible with the same values. Slide 3 restores the automatic appearance shown above.

![手動類別標籤間隔（間隔為三，顯示全部 24 欄）](category-axis-manual.png)

### **選擇正確的軸與間隔**

對於文字類別軸（例如柱狀圖、折線圖、面積圖或條形圖的類別軸），使用此類別計數間隔。在柱狀圖中，它是水平軸；在水平條形圖中，類別軸是垂直的，請將設定套用至[vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)。刻度線間隔同樣適用於具有系列軸的圖表。

請勿使用類別標籤間隔來設定數值軸的數值刻度。在數值軸上，[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) 指定數值差距：例如，`10` 的主要單位會在軸從零開始時產生 0、10、20 … 等刻度。類別標籤間隔 `3` 則是計算類別位置，與其資料值無關。散佈圖和氣泡圖使用數值軸而非文字類別軸。對於日期軸，請依照[變更類別軸](#change-a-category-axis) 中的說明使用基於時間的主要單位與比例。

## **設定類別軸值的日期格式**

本範例以四個年度值取代預設圖表資料。日期以 OLE Automation 串列號儲存在第一個工作表（索引 `0`）中。將[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/)設定為日期軸，停用[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/)，並將`yyyy` 指派給[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)，使類別標籤無論儲存格格式皆顯示四位數年份。

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

## **設定圖表軸標題的旋轉角度**

在垂直軸上啟用[has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/)，提供標題文字，並將[rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/)設定為旋轉角度。角度以度數計算；本範例將柱狀圖的數值軸標題旋轉 90 度後儲存。

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

## **設定類別軸或數值軸的位置**

使用[axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/)控制數值軸是於類別之間交叉還是於類別刻度線上交叉。此屬性套用於類別軸。範例將其於柱狀圖的水平類別軸設為`True`，並儲存結果。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **設定圖表數值軸的顯示單位**

將[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/)設定為在不更改底層資料的情況下縮放數值軸標籤。將[DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/)設定為`MILLIONS`，60,000,000 會顯示為 60。範例建立柱狀圖並將其垂直軸的顯示單位設為百萬。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**如何設定軸交叉的數值 (軸交叉點)？**

使用[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/)選擇交叉行為。若要指定數值型交叉點，請設定[cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/)。這些設定可讓您將軸交叉位置移動到合適的基線。

**如何將刻度標籤相對於軸定位？**

使用[tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/)搭配[TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/)：`LOW`、`HIGH`、`NEXT_TO` 或 `NONE`。若要控制刻度線本身，請使用[major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/)或[minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/)，這些與標籤定位是分開的。