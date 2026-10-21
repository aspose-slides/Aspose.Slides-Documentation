---
title: 使用 Python 管理簡報中的圖表活頁簿
linktitle: 圖表活頁簿
type: docs
weight: 70
url: /zh-hant/python-net/chart-workbook/
keywords:
- 圖表活頁簿
- 圖表資料
- 活頁簿儲存格
- 資料標籤
- 工作表
- 資料來源
- 外部活頁簿
- 外部資料
- 圖表快取
- 活頁簿復原
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "探索 Aspose.Slides for Python via .NET：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表活頁簿，以精簡您的簡報資料。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿。它展示了如何透過活頁簿串流讀寫圖表資料、使用活頁簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

它還涵蓋了將外部活頁簿作為圖表資料來源的操作。範例說明了如何建立與指派外部活頁簿、取得連結至圖表的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

若活頁簿儲存格代表缺少的資料，請參閱[控制空白儲存格的顯示](/slides/zh-hant/python-net/chart-series/)，了解空儲存格與零值的差異，以及可用顯示模式的折線圖比較。

## **包含隱藏列與欄的資料**

使用[Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/)控制圖表是否僅繪製隱藏工作表列與欄的資料。將其設為 `True` 只繪製可見儲存格，設為 `False` 則同時包含可見與隱藏儲存格。此設定僅影響圖表繪製，並不會隱藏或顯示工作表列或欄。

[範例簡報](hidden-source-data.pptx)的第一張投影片上第一個圖形是一個柱狀圖。嵌入的工作表 `Sheet1` 包含以下來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍有值。

| 工作表列 | A: 月份 | B: 零售 | C: 批發 (隱藏欄) |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3 (隱藏列) | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)存取來源儲存格，並讀取[ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/)以檢查其隱藏狀態。此屬性唯讀。在此檔案中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別印出 `False`、`True`、`True`。

對於此範例，在變更繪製設定後請重新整理圖表資料：使用[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)保留嵌入活頁簿，然後以[write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/)重新載入。若要包含所有儲存格，亦需使用[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)還原完整範圍（含隱藏的二月類別）。僅變更旗標不足以刷新此範例的快取圖表資料與類別標籤。

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

            # 從嵌入的活頁簿重新整理圖表資料。
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # 還原完整的來源範圍，包括隱藏的類別。
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

此範例會儲存兩個版本的簡報：一個僅保留可見的零售值（10 與 20），另一個保留全部六個值。下方圖像是重新開啟後從已儲存的簡報渲染的；兩個檔案皆保留其指派的繪製設定。第 3 列與 C 欄在兩個嵌入活頁簿中仍保持隱藏。

| 僅可見儲存格 (`True`) | 全部儲存格 (`False`) |
| --- | --- |
| ![僅可見儲存格：一月與三月的零售值 10 與 20。](hidden_cells_True.png) | ![全部儲存格：一月、二月與三月的零售與批發值。](hidden_cells_False.png) |

含值的隱藏儲存格不同於空白儲存格。[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)控制缺少值的顯示方式，並不會包含或排除隱藏的來源資料。請參閱[控制空白儲存格的顯示](/slides/zh-hant/python-net/chart-series/#control-the-display-of-empty-cells)取得範例。

## **取得圖表的資料範圍**

在對現有簡報的活頁簿資料進行更新前，請先檢查來源範圍，以了解每個圖表使用的工作表儲存格。`[ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/)` 方法會回傳目前的資料範圍，格式為工作表限定的公式，例如 `Sheet1!$A$1:$D$5`。其中 `Sheet1` 為工作表名稱，`!` 為分隔符，`$A$1:$D$5` 表示從 A1 到 D5（含）的儲存格。美元符號表示絕對列與欄參照。

此方法僅讀取現有範圍，不會變更圖表或其活頁簿。若圖表未使用活頁簿作為資料來源，會拋出例外。更多資訊請參閱[ChartData API 參考文件](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)。

此範例開啟一個簡報，直接在每張投影片上檢查圖形是否為圖表，並印出每個圖表的名稱與來源範圍。若無法取得範圍，會印出診斷訊息並繼續處理下一個圖表。

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

## **從活頁簿讀寫圖表資料**

Aspose.Slides for Python via .NET 提供 `[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)` 與 `[write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/)` 方法，讓您可以讀寫圖表資料活頁簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同方式組織，或結構需類似來源結構。

此範例使用第一張投影片上第一個圖形的圖表，將嵌入的活頁簿讀入串流，清除既有系列與類別，然後將相同的活頁簿寫回。變更僅保留在記憶體中，範例不會儲存簡報。

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

### **驗證活頁簿變更後的圖表版面配置**

當您以修改過的活頁簿取代嵌入活頁簿時，圖表仍保留原本的系列與類別集合。這種不匹配可能導致 `[Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/)` 因索引超出範圍而失敗。請在將更新的活頁簿寫回圖表之前，先清除既有系列與類別。此範例使用第一張投影片上第一個圖形的圖表，註解標示了活頁簿編輯的位置；可執行的範例會寫回原始活頁簿，並在記憶體中驗證版面配置。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # 在此修改工作簿串流，例如，使用 Aspose.Cells。

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

清除集合可在寫回活頁簿前移除陳舊的資料參照。於使用圖表前，請為更新的活頁簿重新建立所需的系列與類別對應。

## **為活頁簿儲存格設定自訂數字格式**

使用 `[ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/)` 來控制數值在圖表嵌入活頁簿中的顯示方式。例如，報表可能需要將轉換率顯示為四位小數的百分比，將係數顯示為五位小數。請保留兩個值為數字，以便計算與圖表繪製。

數字格式僅改變顯示，不會改變儲存的值。格式 `0.0000%` 會將 `0.125` 顯示為 `12.5000%`，但不會把儲存的數字改為 `12.5`。類似地，`0.00000` 會將 `0.1234567` 顯示為 `0.12346`，而不會捨入儲存值。若自訂格式為空字串 (`""`)，則使用 `[preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/)`。

以下範例建立一個柱狀圖，並透過 `[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)` 取得其儲存格。在工作表 0 中，B2 包含轉換率，C2 包含係數。兩個儲存格皆提供圖表值。範例同時啟用與來源格式連結的數值標籤。

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

活頁簿儲存格格式與直接在圖表軸或資料標籤上設定的格式分開。在本例中，每個標籤皆因啟用了 `[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/)` 而顯示來源儲存格的值，且因 `[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/)` 為 `True`，遵循來源的數字格式。儲存並重新開啟簡報後，標籤分別顯示 `12.5000%` 與 `0.12346`，如下圖所示。縱軸使用其自身的 `[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)` 為 `0.00`，且 `[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/)` 設為 `False`。

若要獨立格式化資料標籤，請將其來源連結旗標設為 `False`，並指派其 `[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/)`。此操作不會變更活頁簿儲存格的格式。例如，獨立的標籤格式 `0.00` 會將第一個值顯示為 `0.13`，而 B2 仍顯示 `12.5000%`。請參閱[圖表資料標籤](/slides/zh-hant/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels)取得直接標籤格式化說明。

下圖為重新開啟後從已儲存的簡報渲染的圖像：

![具有來源連結標籤（顯示 12.5000% 與 0.12346）以及獨立格式化數字軸的柱狀圖。](custom-cell-formats.png)

## **將活頁簿儲存格作為圖表資料標籤**

您可以使用活頁簿儲存格中的文字作為圖表資料標籤。

此範例在現有簡報的第一張投影片加入一個預設資料的氣泡圖，使用工作表 0 的 A10:A12 取得前三個標籤（屬於第一系列），啟用來自儲存格的標籤，並儲存更新後的簡報。

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

`[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/)` 屬性提供存取圖表活頁簿中工作表的功能。此範例建立一個預設資料的圓餅圖，並將每個工作表名稱印至主控台。

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

此範例建立一個 3D 柱狀圖，使用預設資料，並以不同資料來源設定兩個系列名稱。第一個名稱使用字串常量；第二個名稱使用工作表 0 的 C1 儲存格。`[DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/)` 列舉用來選取每個名稱的來源。範例將更新後的系列名稱儲存至簡報。

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

## **偵測不支援的嵌入活頁簿格式**

Aspose.Slides 不支援可嵌入某些圖表的 Excel 二進位活頁簿（.xlsb）格式。您可以在 `[ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)` 上使用 `[embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/)` 屬性，搭配 `[WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/)` 列舉，以偵測不支援的格式並跳過這些圖表。此範例檢查現有簡報第一張投影片上的圖形，跳過非圖表圖形，並為每個具有嵌入 .xlsb 活頁簿的圖表印出診斷訊息。

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

        # 讀取或修改支援的圖表活頁簿資料於此。
```

## **外部活頁簿**

Aspose.Slides 支援將外部活頁簿作為圖表的資料來源。

### **建立外部活頁簿**

使用 `[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)` 與 `[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)` 將嵌入圖表的活頁簿匯出至檔案，並將圖表連結至該外部活頁簿。

此範例建立一個預設資料的圓餅圖，並匯出其活頁簿。關閉輸出串流後，將外部活頁簿指派為圖表資料來源，最後儲存已連結的簡報。

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

### **設定外部活頁簿**

使用 `[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)` 方法，您可以將外部活頁簿指派給圖表作為資料來源。此方法同樣可用於更新外部活頁簿的路徑（若檔案已搬移）。

雖然無法直接編輯儲存在遠端位置或資源中的活頁簿資料，但仍可將此類活頁簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此範例使用一個外部活頁簿，其工作表 `Sheet1` 在 B1 包含系列名稱，A2:A4 包含類別名稱，B2:B4 包含數值。範例建立圓餅圖，連結活頁簿，並使用 `[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)` 將 A1:B4 對應為一個系列與三個類別。最後儲存包含已連結圖表的簡報。

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

`[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)` 的 `update_chart_data` 參數控制是否載入活頁簿。

* 當 `update_chart_data` 為 `False` 時，僅更新活頁簿路徑。圖表資料不會從目標活頁簿載入或更新，即使活頁簿無法取得亦不會出錯。
* 當 `update_chart_data` 為 `True` 時，圖表資料會從目標活頁簿更新。

以下範例將佔位符 URL 指派給 `update_chart_data=False`。它保留圓餅圖的預設資料，且在未載入不可用的活頁簿情況下儲存簡報。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **取得圖表的外部資料來源活頁簿路徑**

若要辨識連結至圖表的活頁簿，請檢查圖表是否使用外部資料來源，並取得其活頁簿路徑。

此範例檢查簡報第一張投影片的第一個圖形，若為連結至外部活頁簿的圖表，則印出 `[external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)`，並儲存簡報的副本。

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

您可以像編輯內部活頁簿內容一樣編輯外部活頁簿的資料。若無法載入外部活頁簿，系統會拋出例外。

此範例使用第一張投影片上第一個圖形的圖表，且該圖表已連結至可取得的外部活頁簿。它將第一系列第一個資料點的儲存格值設為 100，並儲存更新後的簡報。編輯儲存格值會更新連結的外部 XLSX 檔案，請使用副本以保護原始活頁簿。

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

### **從圖表快取還原活頁簿**

若圖表使用的外部活頁簿遺失或無法取得，Aspose.Slides 可以從簡報中的快取資料重建圖表活頁簿。請先建立 `[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)`，設定其 `[spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/)`，並將 `[SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/)` 設為 `True` 後，再開啟簡報。

以下 Python 範例在第一張投影片的第一個圖形（參考不可用的外部活頁簿）中復原圖表資料，並透過 `[Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/)` 與 `[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)` 取得復原的資料：

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

        # 在此讀取或修改已復原的活頁簿資料。
    else:
        print("The first shape is not a chart.")
```

若外部活頁簿無法取得且未啟用復原，Aspose.Slides 會拋出例外。僅在接受使用快取圖表資料作為可接受的備援方案時才啟用復原，因為快取可能不包含外部活頁簿在最後一次更新簡報後所做的變更。

## **常見問題**

**我可以判斷特定圖表是連結至外部活頁簿還是嵌入活頁簿嗎？**

可以。圖表具有[資料來源類型](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/)與[外部活頁簿路徑](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)，若來源為外部活頁簿，您可以讀取完整路徑以確定使用的是外部檔案。

**是否支援外部活頁簿的相對路徑？它們如何儲存？**

支援。若您指定相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，搬移活頁簿時可能需要更新連結。

**我可以使用位於網路資源/共享的活頁簿嗎？**

可以，此類活頁簿可作為外部資料來源。但 Aspose.Slides 不支援直接編輯遠端活頁簿——只能將其作為來源。

**Aspose.Slides 會在儲存簡報時覆寫外部 XLSX 嗎？**

簡報會儲存指向外部檔案的[連結](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)。編輯儲存格支援的圖表資料也可能會同步更新本機的 XLSX 檔案。若原始活頁簿必須保持不變，請使用其副本。

**如果外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 在連結時不接受密碼。常見做法是事先移除保護，或使用 [Aspose.Cells](https://reference.aspose.com/cells/python-net/) 產生已解密的副本，然後連結至該副本。

**多個圖表可以參考同一個外部活頁簿嗎？**

可以。每個圖表會儲存自己的連結。如果它們指向同一檔案，更新該檔案後，下次載入資料時所有圖表皆會反映此變更。