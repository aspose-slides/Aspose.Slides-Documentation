---
title: 使用 Python 在簡報中管理圖表工作簿
linktitle: 圖表工作簿
type: docs
weight: 70
url: /zh-hant/python-net/chart-workbook/
keywords:
- 圖表工作簿
- 圖表資料
- 工作簿儲存格
- 資料標籤
- 工作表
- 資料來源
- 外部工作簿
- 外部資料
- 圖表快取
- 工作簿復原
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "探索 Aspose.Slides for Python via .NET：輕鬆管理 PowerPoint 與 OpenDocument 格式的圖表工作簿，以簡化簡報資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、將工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

它也涵蓋了將外部工作簿作為圖表資料來源的使用方式。範例說明如何建立並指派外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

若工作簿儲存格代表缺失資料，請參閱[Control the Display of Empty Cells](/slides/zh-hant/python-net/chart-series/)以了解空儲存格與零的差異，以及可用顯示模式的折線圖比較。

## **包括來自隱藏列與欄的資料**

使用[Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/)來控制圖表是否繪製來自隱藏工作表列與欄的資料。將其設為 `True` 只繪製可見儲存格，或設為 `False` 兩者皆包含。此設定僅控制圖表繪製；不會隱藏或取消隱藏工作表列或欄。

[示例簡報](hidden-source-data.pptx)的第一張投影片的第一個形狀是一個柱狀圖。內嵌工作表 `Sheet1` 包含以下來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍有值。

| 工作表列 | A：月份 | B：零售 | C：批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隱藏列） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)存取來源儲存格，並讀取[ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/)以檢查其隱藏狀態。此屬性為唯讀。在此範例中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別列印 `False`、`True`、`True`。

對於此範例，變更繪製設定後請重新整理圖表資料：保留使用[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)取得的內嵌工作簿，並使用[write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/)重新載入。若要包含所有儲存格，亦需使用[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)還原完整範圍，包含隱藏的二月類別。僅變更旗標不足以重新整理此樣本的快取圖表資料與類別標籤。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # 從嵌入的工作簿重新整理圖表資料。
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # 還原完整的來源範圍，包括隱藏的類別。
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

此範例會儲存兩個版本的簡報：一個僅包含可見的零售值 (10 與 20)，另一個則包含全部六個值。下方圖片為重新開啟後從已儲存的簡報渲染；兩個檔案皆保留其指派的繪製設定。第 3 列與 C 欄在兩個內嵌工作簿中仍為隱藏。

| 僅可見儲存格 (`True`) | 所有儲存格 (`False`) |
| --- | --- |
| ![僅可見儲存格：一月與三月的零售值 10 和 20。](hidden_cells_True.png) | ![所有儲存格：一月、二月與三月的零售與批發值。](hidden_cells_False.png) |

包含值的隱藏儲存格不同於空儲存格。[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)控制缺失值的顯示方式；它不會包含或排除隱藏的來源資料。請參閱[Control the Display of Empty Cells](/slides/zh-hant/python-net/chart-series/#control-the-display-of-empty-cells)取得示例。

## **取得圖表的資料範圍**

在更新現有簡報中的工作簿資料之前，請檢查來源範圍以辨識每個圖表使用的工作表儲存格。[ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/)方法會回傳目前的資料範圍，格式為工作表限定的公式，例如 `Sheet1!$A$1:$D$5`。其中 `Sheet1` 為工作表名稱，`!` 將其與儲存格範圍分開，`$A$1:$D$5` 表示包括 A1 至 D5 的儲存格。美元符號表示絕對列與欄參照。

此方法僅讀取目前範圍，不會變更圖表或其工作簿。若圖表未使用工作簿作為資料來源，會拋出例外。更多資訊請參閱[ChartData API 參考文件](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)。

此範例會開啟簡報，直接檢查每張投影片上的形狀是否為圖表。它會列印每個圖表的名稱與來源範圍。若無法取得範圍，會列印診斷訊息並繼續下一個圖表。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **從工作簿讀寫圖表資料**

Aspose.Slides for Python via .NET 提供[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)與[write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/)方法，允許您讀寫圖表資料工作簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同方式組織，或具備與來源相似的結構。

此範例使用第一張投影片第一個形狀為圖表的簡報。它將內嵌工作簿讀入串流，清除既有系列與類別，並將相同的工作簿寫回。變更保留於記憶體中；範例不會儲存簡報。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **在修改工作簿後驗證圖表版面配置**

當您以修改過的工作簿取代內嵌工作簿時，圖表仍保留原本的系列與類別集合。此不匹配可能導致[Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/)因索引超出範圍而失敗。寫回更新的工作簿之前，請先清除既有系列與類別。此範例使用第一張投影片第一個形狀的圖表。註解標示工作簿編輯將發生的位置；可執行的範例將原始工作簿寫回，並在記憶體中驗證版面配置。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # 在此修改工作簿串流，例如使用 Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

清除集合會在寫回工作簿前移除過時的資料參照。於使用圖表之前，請為更新後的工作簿重新建構任何必要的系列與類別對映。

## **選擇類別標籤的儲存方式**

在類別集合為空時，設定[ChartCategoryCollection.use_cells](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorycollection/use_cells/)。若標籤參照工作表儲存格或形成層級（例如以年份分組的季），將其設為 `True`。若標籤僅為單層字串，則設為 `False`。此設定僅套用於類別。範例中的兩個圖表皆使用工作表儲存格作為其數值系列。

範例建立兩個柱狀圖，列印儲存模式與標籤 `Q1 Q2 Q3 Q4`。對於以儲存格為依據的標籤，[ChartCategory.as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/as_cell/) 會回傳工作表儲存格，而[ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) 會回傳儲存於其中的標籤。對於文字標籤，直接從[ChartCategory.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/value/) 讀取字串。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    for use_cells, x in [(True, 20), (False, 360)]:
        chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, x, 20, 320, 250)
        data = chart.chart_data
        data.series.clear()
        data.categories.clear()
        data.categories.use_cells = use_cells

        workbook = data.chart_data_workbook
        series_name = workbook.get_cell(0, 0, 1, "Sales")
        series = data.series.add(series_name, chart.type)
        for row in range(1, 5):
            label = f"Q{row}"
            if use_cells:
                label_cell = workbook.get_cell(0, row, 0, label)
                data.categories.add(label_cell)
            else:
                data.categories.add(label)

            value_cell = workbook.get_cell(0, row, 1, row * 10)
            series.data_points.add_data_point_for_bar_series(value_cell)

        labels = [category.as_cell.value if use_cells else category.value for category in data.categories]
        print(f"use_cells = {data.categories.use_cells}:", *labels)

    presentation.save("category-labels.pptx", slides.export.SaveFormat.PPTX)
```

## **為工作簿儲存格設定自訂數字格式**

使用[ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/)來控制數值在圖表內嵌工作簿中的顯示方式。例如，報表可能需要將轉換率以四位小數的百分比顯示，並將係數以五位小數顯示。保持兩個值皆為數值，以便於計算與圖表繪製。

數字格式僅變更顯示方式，不會改變儲存值。格式 `0.0000%` 會將 `0.125` 顯示為 `12.5000%`，但不會將儲存的數字改為 `12.5`。同理，`0.00000` 會將 `0.1234567` 顯示為 `0.12346`，而不會捨入儲存值。若自訂格式為空字串 (`""`)，則改用[preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/)。

以下範例建立一個柱狀圖，並透過[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)存取其儲存格。於工作表 0，B2 包含轉換率，C2 包含係數。兩個儲存格皆提供圖表值。範例同時啟用與來源格式連結的數值標籤。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

工作簿儲存格格式與直接於圖表軸或資料標籤上設定的格式分開。在此範例中，由於[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) 已啟用，每個標籤皆顯示其來源儲存格的值，且因[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) 為 `True`，遵循來源的數字格式。儲存並重新開啟簡報後，標籤會顯示 `12.5000%` 與 `0.12346`，如下圖所示。垂直軸則使用自身的[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00`，且[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) 為 `False`。

若要獨立格式化資料標籤，請將其來源連結旗標設為 `False`，並指定[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/)。此做法不會變更工作簿儲存格的格式。例如，獨立的標籤格式 `0.00` 會將第一個值顯示為 `0.13`，而 B2 仍顯示 `12.5000%`。請參閱[Chart Data Labels](/slides/zh-hant/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels)以取得直接標籤格式設定的說明。

![含來源連結標籤的柱狀圖，顯示 12.5000% 與 0.12346，且數值軸獨立格式化。](custom-cell-formats.png)

## **將工作簿儲存格設為圖表資料標籤**

您可以使用工作簿儲存格的文字作為圖表資料標籤。

此範例在現有簡報的第一張投影片新增一個預設資料的氣泡圖，使用工作表 0 上的 A10:A12 作為第一系列前三個標籤，啟用儲存格來源標籤，並儲存更新後的簡報。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **管理工作表**

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) 屬性提供對圖表工作簿中工作表的存取。此範例建立一個預設資料的圓餅圖，並將每個工作表名稱列印至主控台。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **指定資料來源類型**

系列點的值也可以直接以數值常量儲存。請參閱[Set Series Values Using Numeric Literals](/slides/zh-hant/python-net/chart-series/#set-series-values-using-numeric-literals) 取得完整範例，說明如何儲存與讀取它們。點值的來源類型獨立於圖表的內部或外部工作簿設定；使用數值常量本身不會移除內嵌工作簿。

此範例建立一個預設資料的 3D 柱狀圖，並使用不同的資料來源設定兩個系列名稱。第一個名稱使用字串常量；第二個名稱使用工作表 0 上的儲存格 C1。[DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) 列舉選擇每個名稱的來源。範例儲存帶有更新系列名稱的簡報。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **偵測不支援的內嵌工作簿格式**

Aspose.Slides 不支援可嵌入於某些圖表的 Excel 二進位工作簿 (.xlsb) 格式。您可以使用 [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) 上的 [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) 屬性，結合 [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) 列舉，來偵測不支援的格式並跳過這些圖表。此範例檢查既有簡報第一張投影片上的形狀，跳過非圖表形狀，並為每個內嵌 .xlsb 工作簿的圖表列印診斷訊息。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # 在此讀取或修改受支援的圖表工作簿資料。
```

## **外部工作簿**

Aspose.Slides 支援使用外部工作簿作為圖表的資料來源。

### **建立外部工作簿**

使用[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)與[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)將內嵌圖表工作簿匯出至檔案，並將圖表連結至該外部工作簿。

此範例建立一個預設資料的圓餅圖，並匯出其工作簿。於指派外部工作簿作為圖表資料來源前，先關閉輸出串流，然後儲存已連結的簡報。

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)

    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **設定外部工作簿**

使用[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)方法，您可以將外部工作簿指派給圖表作為資料來源。此方法亦可用於更新外部工作簿的路徑（若工作簿已被移動）。

雖然無法編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此範例使用一個外部工作簿，其工作表 `Sheet1` 包含 B1 的系列名稱、A2:A4 的類別名稱，以及 B2:B4 的數值。範例建立一個圓餅圖，連結工作簿，並使用[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)將 A1:B4 映射至一個系列與三個類別。最後儲存帶有已連結圖表的簡報。

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 的 `update_chart_data` 參數控制是否載入工作簿。

* 當 `update_chart_data` 為 `False` 時，僅更新工作簿路徑。圖表資料不會從目標工作簿載入或更新，因而工作簿可以不存在。
* 當 `update_chart_data` 為 `True` 時，圖表資料會從目標工作簿更新。

以下範例將 `update_chart_data` 設為 `False`，使用佔位符 URL。它保留圓餅圖的預設資料，並在未載入不可用工作簿的情況下儲存簡報。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **取得圖表的外部資料來源工作簿路徑**

若要辨識連結至圖表的工作簿，請檢查圖表是否使用外部資料來源，並取得其工作簿路徑。

此範例檢查一個連結外部工作簿的簡報第一張投影片的第一個形狀。若它是連結外部工作簿的圖表，範例會將[external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) 列印至主控台，然後儲存簡報的副本。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **編輯圖表資料**

您可以以與編輯內部工作簿相同的方式編輯外部工作簿的資料。若無法載入外部工作簿，會拋出例外。

此範例使用第一張投影片第一個形狀的圖表，且該圖表已連結至可存取的外部工作簿。它將第一系列第一個資料點的儲存格值設為 100，並儲存更新後的簡報。編輯儲存格值可能會更新連結的外部 XLSX 檔案，若需保留原始工作簿，請使用副本。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **從圖表快取恢復工作簿**

若圖表使用的外部工作簿遺失或無法取得，Aspose.Slides 可以從簡報中快取的資料重建圖表工作簿。建立[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)，設定其[spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/)，並將[SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) 設為 `True` 後再開啟簡報。

以下 Python 範例會為第一張投影片第一個形狀的圖表恢復工作簿資料，該圖表參考一個不可用的外部工作簿。它透過[Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) 與[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) 取得恢復的資料：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # 在此讀取或修改已復原的工作簿資料。
    else:
        print("The first shape is not a chart.")
```

若外部工作簿不可用且未啟用恢復，Aspose.Slides 會拋出例外。僅在使用快取圖表資料為可接受的備援方案時才啟用恢復，因為快取可能不包含外部工作簿在簡報最後更新後所做的變更。

## **常見問題**

**我可以判斷特定圖表是連結至外部工作簿還是內嵌工作簿嗎？**

可以。圖表具備[資料來源類型](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/)與[外部工作簿路徑](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)，若來源為外部工作簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援相對路徑的外部工作簿，且它們如何儲存？**

支援。若您指定相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，若移動工作簿可能需要更新連結。

**我可以使用位於網路資源/共用區的工作簿嗎？**

可以，這類工作簿可作為外部資料來源使用。然而，Aspose.Slides 不支援直接編輯遠端工作簿——它們只能作為來源使用。

**Aspose.Slides 會在儲存簡報時覆寫外部 XLSX 嗎？**

簡報會儲存[外部檔案的連結](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)。編輯以儲存格為依據的圖表資料亦可能更新連結的本機 XLSX 檔案。若原始工作簿必須保持不變，請使用其副本。

**如果外部檔案受密碼保護，該怎麼辦？**

Aspose.Slides 在連結時不接受密碼。常見做法是事先解除保護或先建立解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/python-net/)），再連結至該副本。

**多個圖表可以引用同一個外部工作簿嗎？**

可以。每個圖表皆儲存自己的連結。若它們皆指向同一檔案，更新該檔案後，下次載入資料時所有圖表皆會反映變更。