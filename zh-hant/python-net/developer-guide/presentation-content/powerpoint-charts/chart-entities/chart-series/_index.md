---
title: 在 Python 簡報中管理圖表資料系列
linktitle: 資料系列
type: docs
url: /zh-hant/python-net/chart-series/
keywords:
- 圖表系列
- 系列重疊
- 系列顏色
- 類別顏色
- 系列名稱
- 資料點
- 系列間隙
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何在簡報中使用 Python 管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間隙寬度，以及負值。"
---
## **概觀**

圖表可以將其繪製的值儲存在工作簿儲存格中，或直接以數值文字方式儲存。 [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) 代表一組相關的值，而每個 [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) 代表該系列中的一個點。[ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) 物件提供系列共享的標籤或分組值。對於使用預設資料建立的圖表，系列名稱、類別和點值會使用來自圖表工作簿的 [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) 物件。

對於一般的類別圖表，預設工作簿使用第 0 列儲存系列名稱，第 0 欄儲存類別名稱，其餘儲存格則存放系列值。傳遞給 [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) 的工作表、列與欄索引採用零基制。此佈局在建立帶有預設資料的圖表時很有用，但不要假設所有現有圖表皆使用此佈局。對於已載入的簡報，請在變更工作簿值之前，先檢查系列、類別和資料點所參照的儲存格。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)，提供整個系列中所有點的預設外觀。
- 資料點層級設定，例如 [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)，會覆寫該系列的外觀，僅作用於單一點。
- 群組設定套用於同屬於 [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) 的相容系列。當需要設定重疊或間隙寬度等選項時，請透過 [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) 取得群組。

如果未明確設定點或系列的填滿，圖表樣式與主題會決定自動外觀。當系列與點的格式同時存在時，點的格式會優先套用於該點。

![圖表系列-PowerPoint](chart-series-powerpoint.png)

## **使用數值文字設定系列值**

當系列值來自應用程式資料或計算且不需要工作表儲存格參照時，請使用數值文字。將 [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) 設為 [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) 後，再透過 [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/) 為每個點的 [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) 指定值。

此集合設定會控制該系列中所有點值的來源類型。每個點的 [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) 會回傳所選類型；請透過集合設定變更。若使用 `WORKSHEET`，則使用 [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) 取得參照的儲存格。若使用 `DOUBLE_LITERALS`，則使用 `as_literal_double` 直接讀寫數字。

以下範例建立一個具有預設系列與類別的柱狀圖，然後為其第一系列的現有點指派計算後的 10、20…… 值。範例會儲存簡報、重新開啟，並列印儲存的值。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

點值的來源類型與 [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) 分開，後者識別圖表的內部或外部工作簿設定。使用數值文字本身不會移除內嵌的工作簿。在此範例中，工作簿仍保留供類別標籤、系列名稱以及其他系列使用。請參閱 [Chart Workbook](/slides/zh-hant/python-net/chart-workbook/) 了解工作簿管理。

對於散佈圖與氣泡圖，請分別設定 [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) 與 [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) 以選擇 [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) 及 [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/) 的來源。氣泡圖亦使用 [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) 來決定 [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/) 的來源。於指派數字之前，請先將每個適用的來源設為 `DOUBLE_LITERALS`，再透過該值的 `as_literal_double` 屬性讀寫。

## **設定圖表系列重疊**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) 會回報在 2D 圖表中條形或柱形的重疊程度，範圍為 -100 到 100%。此屬性為唯讀，僅投射父系列群組的設定。請設定 [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) 以更新該群組中所有相容系列。此選項僅適用於顯示分組條形或柱形的圖表類型；對於組合圖中不相關的系列群組則不會產生影響。

以下範例為包含第一系列的群組設定重疊：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # 新圖表包含範例系列、類別與數值。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![系列重疊](series_overlap.png)

## **變更系列填充顏色**

使用 [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) 設定整個系列的預設填充。如果某個點已明確設定填充，則其 [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) 會覆寫該系列的填充。

以下範例為第一系列套用實心藍色填充：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![系列顏色](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常顯示於圖例。對於在預設工作簿中建立的群組柱狀圖，儲存格 B1（第 0 列第 1 欄）即為第一系列的名稱。以下範例中的具名常數說明了此結構：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

您也可以直接更新由 [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) 參照的儲存格。此做法避免假設現有圖表的特定列與欄：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![系列名稱](series_name.png)

### **從多個儲存格建立具有名稱的系列**

當產品名稱與報告期間分別存放於不同工作簿儲存格時，合成的系列名稱會很有用。例如，您可以將 B1 中的 `Product A` 與 C1 中的 `2026` 合併為單一系列名稱，同時保持兩個部分與來源儲存格的連結。

使用 [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) 取得名稱範圍，然後將該集合傳遞給 [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/)。`skip_hidden_cells` 參數控制是否排除隱藏儲存格：`True` 會排除，`False` 會包含。本範例使用 `False` 以包含名稱範圍內的所有儲存格。

以下範例建立一個簡報，內含一個系列與兩個資料點。B1:C1 只提供系列名稱；A2:A3 提供類別標籤；B2:B3 提供數值。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # 這兩個儲存格提供系列名稱。
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # 不同的儲存格提供類別和數值資料點。
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

產生的系列名稱為 `Product A 2026`（兩個儲存格值之間有空格）。圖例會將其顯示為單一條目。下圖為已儲存簡報的渲染結果：

![帶有北部與南部值以及合成系列名稱 Product A 2026 的柱狀圖](composite_series_name.png)

## **取得自動系列填充顏色**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) 會回傳依系列索引與圖表樣式計算出的顏色。此顏色用於系列填充未明確定義時。呼叫此方法只會讀取計算出的顏色，並不會指派新的填充。

以下範例列印每個預設系列的自動顏色：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

預設圖表樣式的範例輸出：

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

實際顏色會依圖表樣式與主題而異。

## **為圖表系列設定負向填充顏色**

對於條形、柱形與氣泡系列，您可以使用 [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) 於負值時顯示不同的填充。先將系列填充設為實心，啟用反轉，並透過 [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) 指定負值的顏色。負數在工作簿中仍保持不變，僅在顯示時變更顏色。

以下範例以單一系列取代預設圖表資料。工作表第 0 列存放系列名稱，第 0 欄存放類別名稱，第 1 欄存放數值：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![反轉實心填充顏色](inverted_solid_fill_color.png)

您也可以針對單一資料點啟用反轉，使用 [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)。以下範例在系列層級停用反轉，僅於選取的點啟用，同時為該點指定負值以示效果：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **清除特定資料點的值**

若要使某一點變為空白但保留其他點，請將其對應的工作簿儲存格設為 `None`。對於柱狀圖，繪製的值可透過 [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) 取得。資料點仍保留在相同的類別位置，但圖表會依照空白值設定將其視為空白。

以下範例僅清除第一系列的第二個點：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

散佈圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。請僅清除您欲移除之值所對應的儲存格。若只想保留其他點，請勿呼叫 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/)，因為該方法會移除整個集合中的所有資料點。

## **控制空儲存格的顯示方式**

隱藏的儲存格即使有值，也屬於與空儲存格不同的情況。若需包含或排除隱藏列與欄的資料，請參閱 [Include Data from Hidden Rows and Columns](/slides/zh-hant/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空白的工作簿儲存格代表缺少資料；內容為 `0` 的儲存格則代表已知的數值。將 [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) 設為 `None` 即可使儲存格變為空白。數值零不會因空白儲存格設定而改變。

使用 [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) 來選擇圖表如何顯示空儲存格。此設定套用於整個圖表，會改變空白的繪製方式，而不會將空白工作簿儲存格填入零或插值。

以下為自行完整的範例：建立一條線圖，僅為第 3 天的值設定為空，並分別以每種模式儲存同一圖表。此範例不需要輸入檔案。[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) 使用工作表 0，第 0 欄作為類別標籤，第 1 欄作為數值；第 0 列為系列名稱。最終資料為 `10, 20, empty, 30, 40`。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # 將第 3 天真正留空，同時保留其類別與資料點。
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

每個輸出檔案會在儲存前記錄所指定的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。若只想產生單一版本，請設定欲使用的模式後僅儲存一次簡報，而非遍歷所有模式。

下圖比較了三個檔案的相同資料。第 3 天在工作簿中皆為空白：

![線圖的空白顯示比較：Gap 在第 3 天斷開線條，Zero 使線條下降至零，Span 連接第 2 天與第 4 天。](display_blanks_as.png)

可見效果取決於圖表類型。線圖能清楚比較三種模式；條形與柱形圖則因缺少連接線，`SPAN` 無法產生上述的連接段落，缺少的柱形與零高度的柱形看起來也相似。同樣地，僅有標記的散佈圖也不會有連接線。不要期望每種圖表類型都會呈現三種不同結果，請依實際圖表檢查輸出。

## **設定系列間隙寬度**

間隙寬度是相鄰條形或柱形叢集之間的間距，以條形或柱形寬度的百分比表示。與重疊一樣，它屬於父系列群組，而非單一系列。請於群組層級一次設定 [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)。較大的值會在叢集間產生更多空間，較小的值則會使叢集更緊密。

以下範例調整間隙寬度，並僅儲存最終簡報：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![間隙寬度](gap_width.png)

## **常見問題集**

**哪些圖表類型支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列舉的圖表類型皆使用圖表資料，但其系列並非全部擁有相同的值結構或設定。例如，類別圖使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則另外加入氣泡大小。請使用與系列類型相符的資料點建立方法。重疊與間隙寬度等選項僅適用於相容的條形或柱形群組。

**什麼是圖表系列群組？**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) 包含共享群組層級繪圖設定的相容系列。組合圖可以包含多個群組，因此透過單一系列取得的群組設定未必會影響圖表中的所有系列。

**新建立的圖表會包含預設資料嗎？**

會。預設情況下，[ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) 會建立範例系列、類別與值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。也有其他重載可建立不含預設資料的圖表。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤與資料點值皆參照 [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) 中的儲存格。變更被參照的儲存格會更新相對應的圖表元素。建立自訂資料時，請保持類別列與系列值列對齊，使每個點都繪製於預期的類別之下。

**如何只清除單一點而非整個系列？**

將相關的值儲存格設為 `None`，即可保留該點的類別位置作為空白點。僅在想移除該系列所有點時才使用 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/)。若同時移除類別，請更新所有系列，使其值仍與類別集合對齊。

**空白點會如何顯示？**

顯示結果取決於圖表類型與 [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)。支援的圖表可將空白顯示為斷開、零值或連接相鄰點。請選擇符合簡報中資料缺失意義的設定。請參閱 [控制空儲存格的顯示方式](#control-the-display-of-empty-cells) 以取得完整範例與視覺比較。

**負值的格式如何設定？**

對於支援的條形、柱形與氣泡系列，啟用 [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) 並設定 [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)。您也可以使用 [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) 為單一點覆寫此行為。這些屬性影響格式，而不會改變儲存的數值。

**當系列與點同時設定格式時，哪個會生效？**

明確的資料點格式會優先於系列格式，僅對該點生效。其他點仍會使用明確的系列格式，或在系列格式未定義時使用自動圖表樣式與主題。群組屬性如重疊與間隙寬度屬於版面配置，並非點級別的格式覆寫。

**圖表可容納的系列數量有限制嗎？**

Aspose.Slides 本身未設置固定的系列數量上限。實務上，簡報檔案的限制、可用記憶體、渲染時間與圖表可讀性會決定實際可使用的上限。

**當柱形過於靠近或過於分散時該怎麼調整？**

於相應的父系列群組上設定 [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)。增大該值會擴大叢集之間的間距，減小則會使叢集更靠近。