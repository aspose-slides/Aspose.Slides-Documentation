---
title: 使用 Python 在簡報中自訂圖表座標軸
linktitle: 圖表座標軸
type: docs
url: /zh-hant/python-net/chart-axis/
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
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 簡報中自訂圖表座標軸，以用於報告與視覺化。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Python via .NET 自訂圖表座標軸。內容涵蓋計算座標軸值、交換圖表列與欄、座標軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、座標軸定位、顯示單位以及對數縮放。

## **取得圖表垂直座標軸的最大值**

建立一個 [簡報](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)，並加入預設資料的區域圖。於讀取計算後的座標軸值之前，先呼叫 [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) 以確保圖表版面已更新。

讀取 [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) 與 [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) 取得座標軸上下限，並使用 [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) 與 [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) 取得刻度間隔。 [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) 與 [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) 提供時間單位比例，與日期座標軸相關。範例將這些值存入本機變數，並儲存圖表。

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

## **交換座標軸之間的資料**

使用 [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) 交換圖表資料中系列與類別的角色。每個原本的類別會變成系列，每個原本的系列會變成類別。此操作會改變資料的分組方式，並不會交換水平與垂直座標軸。範例使用 [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) 將預設資料繫結至 `Sheet1!A1:D5`（包括標題列與類別欄），然後執行交換列與欄。最終產生包含四個系列與三個類別的圖表。

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

## **隱藏折線圖的垂直座標軸**

將垂直座標軸的 [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) 設為 `False` 即可隱藏。範例建立一個預設資料的折線圖，並以隱藏垂直座標軸的方式儲存。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **隱藏折線圖的水平座標軸**

將水平座標軸的 [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) 設為 `False` 即可隱藏。範例建立一個預設資料的折線圖，並以隱藏水平座標軸的方式儲存。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **變更類別座標軸**

將 [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) 設定為日期或文字類別座標軸。本範例需要 `ExistingChart.pptx`，其中第一張投影片的第一個圖形為圖表，且類別儲存格包含數值型 Excel 日期。範例將水平座標軸變更為日期座標軸。將 [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) 設為 `False`、[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) 設為 `1`、[major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) 設為 months，則主要刻度會以每月為間隔。

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

## **控制類別座標軸標籤間隔**

當圖表有許多類別時，可減少可見的座標軸標籤數量，且不必移除類別或資料點。將 [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) 設為 `False`，再將 [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) 設為想要的類別間隔。對於保持正常順序的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

間隔為 `3` 時會顯示每第三個標籤，顯示的標籤之間會隱藏兩個標籤。此設定不會移除相應的欄位。自動間隔會根據可用空間選擇間隔，未必會顯示每個標籤。

刻度線有獨立的控制方式。將 [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) 設為 `False`，並使用 [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) 設定其間隔。例如，`1` 會在每個類別間隔皆保留刻度線，而標籤只每三個類別顯示一次。將 [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) 設為可見樣式，以便觀察結果。將任一自動間隔屬性重新設為 `True`，圖表便會再次自行決定間隔。

以下自行完整的範例會建立 24 個類別與一條系列，然後在 `CategoryAxisIntervals.pptx` 中儲存三張投影片：自動間隔、手動標籤間隔搭配獨立刻度線、以及恢復自動間隔。兩個副本保留原始圖表資料，無需輸入簡報。水平標籤文字可清楚顯示密度差異。

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

    # 投影片 2：顯示每三個標籤，但為每個類別保留刻度線。
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # 投影片 3：讓圖表再次自行選擇兩個間隔。
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**自動間隔（投影片 1）:** 此呈現方式會顯示每第二個類別標籤，且會自動換行為兩行。自動結果會因圖表大小、字型與繪圖引擎不同而有所變化。

![自動類別標籤間隔，顯示全部 24 欄](category-axis-automatic.png)

**手動間隔（投影片 2）:** 每第三個標籤顯示在單行，同時刻度線仍保留在每個類別間隔。所有 24 欄（包括未顯示標籤的欄）仍保持可見且數值相同。投影片 3 會還原如上方所示的自動外觀。

![手動類別標籤間隔為三，顯示全部 24 欄](category-axis-manual.png)

### **選擇正確的座標軸與間隔**

對文字類別座標軸（例如柱狀圖、折線圖、區域圖或長條圖的類別座標軸）使用此類別間隔。在柱狀圖中，它是水平座標軸；在水平長條圖中，類別座標軸是垂直的，請將此設定套用到 [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)。刻度間隔同樣適用於具有系列座標軸的圖表。

不要使用類別標籤間隔來設定值座標軸的數值刻度。在值座標軸上，[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) 代表值的差距，例如 `10` 會在 0、10、20… 等位置產生刻度；而類別標籤間隔 `3` 則是以類別位置計算，與其資料值無關。散佈圖與氣泡圖使用值座標軸，而非文字類別座標軸。對於日期座標軸，請使用在 [變更類別座標軸](#change-a-category-axis) 中描述的時間基礎主要單位與比例。

## **為類別座標軸值設定日期格式**

本範例以四筆年度資料取代預設圖表資料。日期以 OLE Automation 序號儲存在第一個工作表（索引 `0`）中。將 [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) 設為日期座標軸，停用 [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/)，並將 `yyyy` 指派給 [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)，使類別標籤顯示四位數年份，且不受儲存格格式影響。

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

## **為圖表座標軸標題設定旋轉角度**

在垂直座標軸上啟用 [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/)，提供標題文字，並將 [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) 設為旋轉角度。角度以度為單位；本範例將柱狀圖的值座標軸標題旋轉 90 度後儲存。

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

## **設定類別或值座標軸的位置**

使用 [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) 控制值座標軸是穿過類別座標軸的類別之間，還是穿過類別刻度線。此屬性適用於類別座標軸。範例在柱狀圖的水平類別座標軸上將其設為 `True`，並儲存結果。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **在值座標軸上設定顯示單位**

將 [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) 設定為比例顯示值座標軸的標籤，而不改變底層資料。配合 [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) 設為 `MILLIONS`，60,000,000 會顯示為 60。範例建立柱狀圖，並將垂直座標軸的顯示單位設為百萬。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **設定對數值座標軸**

當正值跨越數個數量級時，對數值座標軸非常有用。例如，服務在五個期間內可能分別收到 10、100、1,000、10,000 與 100,000 筆請求。線性比例會使較小的值聚集在零附近；對數比例則使其相對成長更易比較：相等的距離代表相等的比例而非相等的差值。

將值座標軸的 [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) 設為 `True`，並使用 [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) 選擇底數。此設定僅改變現有值的顯示方式，不會改變資料或新增對數趨勢線。趨勢線是依資料擬合的獨立功能。

### **選擇值座標軸與底數**

對於折線圖或柱狀圖，值座標軸為 [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)。對於水平長條圖，則為 [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/)。散佈圖與氣泡圖有兩條值座標軸，請自行選擇水平軸作為 X 值、垂直軸作為 Y 值，或同時套用。切勿對類別座標軸套用對數縮放。

預設的對數底數為 `10`。對於 PPTX 圖表，底數可設為 2 至 1000（含）之間的任意整數；亦支援小數底數如 `2.5`。使用底數 `10` 時，10、100、1,000、10,000 等連續次方會等距排列。

### **比較線性與對數縮放**

以下自行完整的範例會在第一張投影片建立一個折線圖，顯示五筆請求數量，然後複製該投影片並在第二張投影片上啟用底數為 10 的對數值座標軸。兩張投影片皆保留相同資料。

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

    # 保持第一張投影片為線性，僅對副本的值座標軸比例進行變更。
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**線性比例（投影片 1）:** 相等的垂直距離代表請求數量的相等差值。最大值會主導圖表，使較小的值難以辨識。

![PowerPoint 折線圖，五筆請求數量使用線性值座標軸顯示](value-axis-linear.png)

**對數比例（投影片 2）:** 相等的垂直距離代表相等的比例。每個期間的請求數量是前一期間的十倍，因此在以 10 為底的對數尺度上點形成直線上升。座標軸標籤仍顯示原始請求數量。

![PowerPoint 同樣的五筆請求數量在底數為 10 的對數值座標軸上顯示](value-axis-logarithmic.png)

### **處理零值與負值**

對數比例只能顯示嚴格正值，啟用前請先檢查資料。若零或負值具備意義，請保留線性比例或將其另行顯示。若刪除這些值符合分析需求，須在說明中註明原因。切勿悄悄將其替換為小的正值，因會改變資料意義。對數座標軸的任何手動最小值或最大值亦必須為正值。

## **常見問題集**

**如何設定兩條座標軸交叉的位置（座標軸交叉）？**

使用 [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) 選擇交叉行為。若要指定數值交叉位置，請設定 [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/)。這些設定讓您將座標軸交叉點移至適當的基線。

**如何相對於座標軸定位刻度標籤？**

使用 [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) 搭配 [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/)：`LOW`、`HIGH`、`NEXT_TO` 或 `NONE`。若要控制刻度線本身，請使用 [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) 或 [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/)，這些屬性與標籤位置分開設定。