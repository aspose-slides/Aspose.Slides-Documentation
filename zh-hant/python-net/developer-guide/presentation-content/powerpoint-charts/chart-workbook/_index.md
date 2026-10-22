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
description: "探索 Aspose.Slides for Python via .NET：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表工作簿，以簡化您的簡報資料。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿資料流讀寫圖表資料、將工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表數值指定資料來源類型。

它也涵蓋了使用外部工作簿作為圖表資料來源的操作。範例示範了如何建立並指派外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

如要處理代表缺少資料的工作簿儲存格，請參閱[控制空儲存格的顯示](/slides/zh-hant/python-net/chart-series/)以了解空儲存格與零之間的差異，以及線圖中可用顯示模式的比較。

## **包含隱藏列與欄的資料**

使用[Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/)來控制圖表是否繪製隱藏工作表列與欄的資料。將其設為`True`僅繪製可見儲存格，或設為`False`同時包含可見與隱藏儲存格。此設定僅控制圖表繪製，並不隱藏或取消隱藏工作表列或欄。

[sample presentation](hidden-source-data.pptx)的第一張投影片的第一個圖形是一個柱狀圖。內嵌工作表`Sheet1`的來源範圍為`A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍包含數值。

| 工作表列 | A: 月份 | B: 零售 | C: 批發 (隱藏欄) |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3 (隱藏列) | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)存取來源儲存格，並讀取[ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/)以檢查其隱藏狀態。此屬性為唯讀。於本檔案中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別輸出`False`、`True`、`True`。

對於此範例，在變更繪製設定後需重新整理圖表資料：使用[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)保留內嵌工作簿，並以[write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/)重新載入。若要包含所有儲存格，亦需使用[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)還原完整範圍，包含隱藏的二月類別。僅變更旗標不足以重新整理此範例的快取圖表資料與類別標籤。

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
                # 還原完整的來源範圍，包含隱藏的類別。
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

範例儲存了兩個版本的簡報：一個僅含可見的零售值 (10 與 20)，另一個則包含全部六個值。下方圖片是重新開啟儲存後的簡報所呈現的結果；兩個檔案皆保留其指派的繪製設定。第 3 列與 C 欄在兩個內嵌工作簿中仍保持隱藏。

| 僅可見儲存格 (`True`) | 全部儲存格 (`False`) |
| --- | --- |
| ![僅可見儲存格：一月與三月的零售值 10 與 20。](hidden_cells_True.png) | ![全部儲存格：一月、二月與三月的零售與批發值。](hidden_cells_False.png) |

包含數值的隱藏儲存格與空儲存格不同。[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)控制缺少值的顯示方式；它不會包含或排除隱藏的來源資料。請參閱[控制空儲存格的顯示](/slides/zh-hant/python-net/chart-series/#control-the-display-of-empty-cells)以了解範例。

## **擷取圖表的資料範圍**

在更新現有簡報中的工作簿資料之前，請檢查來源範圍以辨識每個圖表使用的工作表儲存格。[ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/)方法會回傳目前的資料範圍，以工作表限定的公式表示，例如`Sheet1!$A$1:$D$5`。此處`Sheet1`為工作表名稱，`!`將名稱與儲存格範圍分開，`$A$1:$D$5`表示包含 A1 至 D5 的儲存格。美元符號表示絕對列與欄參照。

此方法在不變更圖表或其工作簿的情況下讀取目前範圍。若圖表未使用工作簿作為資料來源，會拋出例外。更多資訊請參閱[ChartData API 參考](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)。

此範例開啟簡報並直接檢查每張投影片上的圖形，以尋找圖表。它會列印每個圖表的名稱與來源範圍。若無法取得範圍，則列印診斷訊息並繼續處理下一個圖表。

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

Aspose.Slides for Python via .NET 提供[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)與[write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/)方法，讓您能讀寫圖表工作簿（包含使用 Aspose.Cells 編輯的圖表資料）。**Note** 圖表資料必須以相同方式組織，或必須具備類似來源的結構。

此範例使用簡報，其第一張投影片的第一個圖形是一個圖表。它將內嵌工作簿讀入資料流，清除現有的系列與類別，然後再次寫回同一工作簿。變更保留於記憶體中；範例不會儲存簡報。

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

### **在工作簿修改後驗證圖表佈局**

當您以修改過的工作簿取代內嵌工作簿時，圖表仍保留其原始的系列與類別集合。此不匹配可能導致[Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/)因索引超出範圍而失敗。寫回更新的工作簿之前，請先清除現有的系列與類別。此範例使用第一張投影片的第一個圖形作為圖表。註解標示了工作簿編輯的位置；可執行的範例寫回原始工作簿並在記憶體中驗證佈局。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # 在此修改工作簿資料流，例如使用 Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

清除集合可在寫回工作簿前移除陳舊的資料參照。請在使用圖表之前，為更新的工作簿重建任何必要的系列與類別對應。

## **為工作簿儲存格設定自訂數字格式**

使用[ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/)來控制數值在圖表內嵌工作簿中的顯示方式。例如，報表可能需要將轉換率以四位小數的百分比顯示，將係數以五位小數顯示。請保留兩個值為數值型別，以便於計算與圖表繪製。

數字格式僅變更顯示，而不變更儲存值。格式`0.0000%`會將`0.125`顯示為`12.5000%`，但不會將儲存的數字改為`12.5`。同理，`0.00000`會將`0.1234567`顯示為`0.12346`，且不會捨入儲存的值。若自訂格式為空字串 (`""`)，則會使用[preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/)。

以下範例建立一個柱狀圖，並透過[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)存取其儲存格。在工作表 0 中，B2 包含轉換率，C2 包含係數。兩個儲存格皆提供圖表數值。範例同時啟用與來源格式連結的數值標籤。

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

工作簿儲存格格式與直接設定於圖表坐標軸或資料標籤的格式是分開的。在此範例中，因為[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/)已啟用，且[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/)為`True`，所以每個標籤顯示其來源儲存格的值，並遵循來源的數字格式。儲存並重新開啟簡報後，標籤分別顯示`12.5000%`和`0.12346`，如下圖所示。垂直坐標軸使用其自訂的[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00`，且[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/)設為`False`。

若要獨立格式化資料標籤，請將其來源連結旗標設為`False`，並指派[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/)。這不會變更工作簿儲存格的格式。例如，獨立的標籤格式`0.00`會將第一個值顯示為`0.13`，而 B2 仍顯示`12.5000%`。請參閱[Chart Data Labels](/slides/zh-hant/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels)以取得直接標籤格式化的說明。

![來源連結標籤顯示 12.5000% 與 0.12346，且坐標軸獨立格式化為數字的柱狀圖。](custom-cell-formats.png)

## **將工作簿儲存格設為圖表資料標籤**

您可以使用工作簿儲存格中的文字作為圖表資料標籤。

此範例在現有簡報的第一張投影片加入一個預設資料的氣泡圖，使用工作表 0 的 A10:A12 作為第一系列的前三個標籤，啟用來自儲存格的標籤，並儲存更新後的簡報。

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

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/)屬性提供對圖表工作簿中工作表的存取。此範例建立一個預設資料的圓餅圖，並將每個工作表名稱列印至主控台。

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

系列點的數值也可以直接以數值文字儲存。請參閱[使用數值文字設定系列值](/slides/zh-hant/python-net/chart-series/#set-series-values-using-numeric-literals)以取得完整的儲存與讀取範例。點值的來源類型與圖表的內部或外部工作簿設定分開；使用數值文字本身不會移除內嵌工作簿。

此範例建立一個預設資料的 3D 柱狀圖，並使用不同的資料來源設定兩個系列名稱。第一個名稱使用字串文字；第二個名稱使用工作表 0 中的 C1 儲存格。[DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/)列舉會為每個名稱選取來源。範例儲存了更新後的系列名稱。

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

Aspose.Slides 不支援可在某些圖表中內嵌的 Excel 二進位工作簿 (.xlsb) 格式。您可以於[ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)上使用[embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/)屬性，搭配[WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/)列舉，偵測不支援的格式並跳過那些圖表。此範例檢查現有簡報第一張投影片上的圖形，跳過非圖表的圖形，並為每個內嵌 .xlsb 工作簿的圖表列印診斷訊息。

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

使用[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)與[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)將內嵌圖表工作簿匯出為檔案，並將圖表連結至該外部工作簿。

此範例建立一個預設資料的圓餅圖，並匯出其工作簿。它會在指派外部工作簿作為圖表資料來源之前關閉輸出資料流，然後儲存已連結的簡報。

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

使用[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)方法，您可以將外部工作簿指派給圖表作為資料來源。此方法亦可用於更新外部工作簿的路徑（若該檔案已搬移）。

雖然無法編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿用作外部資料來源。若提供相對路徑，系統會自動將其轉換為完整路徑。

此範例使用一個外部工作簿，其工作表 `Sheet1` 內 B1 為系列名稱，A2:A4 為類別名稱，B2:B4 為數值。範例建立圓餅圖，連結工作簿，並使用[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)將 A1:B4 對映至一個系列與三個類別。最後儲存連結了圖表的簡報。

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

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)的`update_chart_data`參數決定是否載入工作簿。

* 當`update_chart_data`為`False`時，僅更新工作簿路徑。圖表資料不會從目標工作簿載入或更新，因而工作簿可為不可用狀態。
* 當`update_chart_data`為`True`時，圖表資料會從目標工作簿更新。

以下範例將`update_chart_data`設為`False`，並指派一個佔位 URL。它保留圓餅圖的預設資料，且在未載入不可用工作簿的情況下儲存簡報。

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

此範例檢查一個連結了外部工作簿的簡報之第一張投影片的第一個圖形。若該圖形是連結至外部工作簿的圖表，範例會將[external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)列印至主控台，然後儲存簡報的副本。

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

您可以以與編輯內部工作簿相同的方式編輯外部工作簿的資料。當外部工作簿無法載入時，會拋出例外。

此範例使用第一張投影片的第一個圖形，且該圖表已連結至可存取的外部工作簿。它將第一系列第一資料點的儲存格備援值設為 100，並儲存更新後的簡報。編輯儲存格值會更新連結的外部 XLSX 檔案，若需保留原始工作簿，請使用副本。

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

### **從圖表快取還原工作簿**

如果圖表使用的外部工作簿遺失或不可用，Aspose.Slides 可以從簡報中快取的資料重建圖表工作簿。建立[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)，設定其[spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/)，並將[SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/)設為`True`，然後開啟簡報。

以下 Python 範例復原了第一張投影片第一個圖形的圖表資料，該圖表參考了不可用的外部工作簿。它透過[Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/)與[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)存取復原的資料：

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

        # 在此讀取或修改復原的工作簿資料。
    else:
        print("The first shape is not a chart.")
```

若外部工作簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅在接受使用快取圖表資料作為可接受的備援時才啟用復原，因為快取資料可能不包含自最後一次更新簡報後對外部工作簿所做的變更。

## **常見問題**

**我可以判斷特定圖表是連結至外部工作簿還是內嵌工作簿嗎？**

可以。圖表具有[data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/)與[external workbook path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)，若來源是外部工作簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援相對路徑的外部工作簿，且它們如何儲存？**

支援。若您指定相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，所以搬移工作簿可能需要更新連結。

**我可以使用位於網路資源/共享的工作簿嗎？**

可以，此類工作簿可作為外部資料來源使用。但不支援直接從 Aspose.Slides 編輯遠端工作簿——只能作為來源使用。

**Aspose.Slides 會在儲存簡報時覆寫外部 XLSX 嗎？**

簡報會儲存[指向外部檔案的連結](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)。編輯以儲存格為基礎的圖表資料也可能更新連結的本機 XLSX 檔案。若原始檔案必須保持不變，請使用該工作簿的副本。

**如果外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 在連結時不接受密碼。常見做法是事先移除保護或準備一個已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/python-net/)），然後連結至該副本。

**多個圖表可以參考相同的外部工作簿嗎？**

可以。每個圖表都會儲存自己的連結。如果它們都指向同一檔案，更新該檔案將在下次載入資料時反映於所有圖表。