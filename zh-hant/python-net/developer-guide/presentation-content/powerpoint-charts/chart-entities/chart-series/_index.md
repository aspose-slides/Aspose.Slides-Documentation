---
title: 在 Python 中管理簡報的圖表資料系列
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
description: "學習如何在 Python 簡報中管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間隙寬度以及負值。"
---
## **概述**

圖表可以將其繪製的值儲存在工作簿儲存格中，或直接作為數值文字。**[ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/)** 代表一組相關的值，而每個 **[ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/)** 代表該系列中的一個點。**[ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/)** 物件提供系列共用的標籤或分組值。在使用預設資料建立的圖表中，系列名稱、類別和點值使用 **[ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/)** 物件來自圖表工作簿。

對於典型的類別圖表，預設工作簿使用第 0 列作為系列名稱，第 0 欄作為類別名稱，其餘儲存格則存放系列值。傳遞給 **[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/)** 的工作表、列與欄索引是零基的。此配置在建立預設資料的圖表時很有用，但不要假設每個現有圖表都使用它。對於已載入的簡報，請在變更工作簿值之前檢查系列、類別和資料點所參照的儲存格。

圖表設定具有三種不同的範圍：

- 系列層級設定，例如 **[ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)**，為單一系列的所有點提供預設外觀。
- 資料點層級設定，例如 **[ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)**，會覆寫該點的系列外觀。
- 群組設定套用於屬於相同 **[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/)** 的相容系列。需要設定重疊或間隙寬度等選項時，請透過 **[ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/)** 取得群組。

當未明確設定點或系列填色時，圖表樣式與主題會決定自動外觀。當同時存在系列與點的格式設定時，點的格式會優先套用於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

對於叢集圓柱圖，請參考 **[changing the 3D series type or bar shape](/slides/zh-hant/python-net/3d-chart/#change-the-3d-series-type-and-bar-shape)** 如何影響第一系列。

## **使用數值文字設置系列值**

當系列值來源於應用程式資料或計算，且不需要工作表儲存格參照時，請使用數值文字。將 **[data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/)** 設為 **[DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/)**，再透過 **[as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/)** 為每個點的 **[value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/)** 指派。

此集合設定控制該系列所有點值的來源類型。每個點的 **[value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/)** 會回報已選取的類型；可透過集合設定變更。使用 `WORKSHEET` 時，請使用 **[as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/)** 存取參照的儲存格。使用 `DOUBLE_LITERALS` 時，直接以 `as_literal_double` 讀寫數字。

以下範例建立一個預設系列與類別的柱狀圖，然後將計算得到的 10、20 等值指派給其第一系列的現有點，最後儲存簡報、重新開啟並列印儲存的值。

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

點值的來源類型獨立於 **[ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/)**，後者標示圖表的內部或外部工作簿組態。僅使用數值文字並不會自行移除內嵌工作簿。在此範例中，工作簿仍保留用於類別標籤、系列名稱與其他系列。請參考 **[Chart Workbook](/slides/zh-hant/python-net/chart-workbook/)** 了解工作簿管理。

對於散佈圖與氣泡圖，請設定 **[data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/)** 與 **[data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/)** 以選擇 **[x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/)** 與 **[y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/)** 的來源。氣泡圖亦使用 **[data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/)** 來決定 **[bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/)** 的來源。於指派數字之前，先將每個相關來源設為 `DOUBLE_LITERALS`，再透過該值的 `as_literal_double` 屬性讀寫。

## **設定圖表系列重疊**

**[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/)** 回報 2D 圖表中長條或柱狀的重疊程度，範圍為 -100% 至 100%。它是父系列群組設定的唯讀投影。若要更新該群組中所有相容系列，請設定 **[ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/)**。此選項適用於顯示分組長條或柱狀的圖表類型；不會影響組合圖中不相關的系列群組。

以下範例設定包含第一系列的群組的重疊：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # 新增的圖表包含範例系列、類別和數值。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![系列重疊](series_overlap.png)

## **變更系列填色**

使用 **[ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)** 設定整個系列的預設填色。如果某個點已明確設定填色，則其 **[ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)** 會覆寫該系列的填色。

以下範例為第一系列套用實心藍色填色：

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

![系列的顏色](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常顯示於圖例。對於預設建立的叢集柱狀圖，儲存格 B1（第 0 列第 1 欄）即為第一系列的名稱。下列範例的具名常數將此結構明確化：

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

您也可以直接更新 **[ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/)** 已參照的儲存格。此作法避免假設既有圖表中的特定列與欄：

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

當產品名稱與報告期間分別儲存在不同工作簿儲存格時，組合系列名稱相當有用。例如，可將 B1 中的 `Product A` 與 C1 中的 `2026` 合併為單一系列名稱，同時保留兩個部份與來源儲存格的連結。

使用 **[ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/)** 取得名稱範圍，然後將該集合傳遞給 **[ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/)**。`skip_hidden_cells` 參數控制是否包含隱藏儲存格：`True` 會排除，`False` 會包含。本範例使用 `False` 以包含名稱範圍內的每個儲存格。

以下範例建立一個簡報，其中包含一個系列與兩筆資料點。儲存格 B1:C1 僅提供系列名稱；A2:A3 提供類別標籤；B2:B3 提供數值。

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

    # 不同的儲存格提供類別與數值資料點。
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

最終的系列名稱為 `Product A 2026`，兩個儲存格值之間保留空格。圖例會將其顯示為單一條目。下圖為儲存簡報後的渲染結果：

![包含北部與南部值的柱狀圖，圖例中的合成系列名稱 Product A 2026](composite_series_name.png)

## **取得自動系列填色**

**[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/)** 會回傳根據系列索引與圖表樣式計算出的顏色。此顏色用於系列填色未明確定義的情況。呼叫此方法只是讀取計算出的顏色，並不會指派新的填色。

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

實際顏色取決於圖表樣式與主題。

## **為圖表系列設定反轉填色**

對於長條、柱狀與氣泡系列，**[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/)** 可在負值時顯示不同的填色。將常規系列填色設為實心，啟用反轉，並透過 **[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)** 指派負值顏色。負數在工作簿中仍保持不變，僅其顯示顏色會改變。

以下範例以單一系列取代預設圖表資料。工作表第 0 列存放系列名稱，第 0 欄存放類別名稱，第 1 欄存放值：

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

![反轉實心填色](inverted_solid_fill_color.png)

您也可以透過 **[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)** 為單一資料點啟用反轉。以下範例在系列層面停用反轉，僅為所選資料點啟用，且為該點指派負值以顯示效果：

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

若要讓某一點變為空白而不移除其他點，請將其對應的工作簿儲存格設定為 `None`。對於柱狀圖，繪製值可透過 **[ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/)** 取得。資料點仍保留在相同類別位置，但圖表會依照空白值設定將其視為空白。

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

散佈圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。僅清除您欲移除之值所對應的儲存格。若要保留其他點，切勿呼叫 **[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/)**，因為該方法會移除該系列的所有資料點。

## **控制空儲存格的顯示**

隱藏且包含值的儲存格屬於與空白儲存格不同的情況。若要包含或排除來自隱藏列與欄的資料，請參考 **[Include Data from Hidden Rows and Columns](/slides/zh-hant/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns)**。

空的工作簿儲存格代表缺少資料；儲存格內含 `0` 則代表已知的數值。將 **[ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/)** 設為 `None` 即可使儲存格變為空。數值零即使在空白儲存格設定下仍保持為零。

使用 **[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)** 來選擇圖表如何顯示空儲存格。此設定套用於整個圖表，會改變空白的繪製方式，但不會將空白工作簿儲存格填入零或插值。

以下獨立範例建立一個單系列折線圖，清除第 3 天的值，並以每種模式保存同一圖表。此範例不需要輸入檔案。**[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)** 使用工作表 0，第 0 欄作為類別標籤，第 1 欄作為值；第 0 列保存系列名稱。最終資料為 `10, 20, empty, 30, 40`。

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

    # 讓第 3 天真正留空，同時保留其類別和資料點。
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

每個輸出檔案儲存於保存前指定的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。若只需一個版本，請在儲存簡報前設定所需模式，然後一次儲存即可，而不是對每個模式迭代。

下圖比較了三個檔案中相同資料的呈現。第 3 天在工作簿中皆為空白：

![相同資料的折線圖：Gap 在第 3 天斷開線條，Zero 將線條降至零，Span 連接第 2 天與第 4 天](display_blanks_as.png)

可見效果取決於圖表類型。折線圖最能清楚比較三種模式。長條與柱狀圖沒有線條可在缺失類別間連接，故 `SPAN` 無法產生上圖所示的連接段落；缺少的柱與零高度的柱看起來也可能相似。類似地，僅有標記的散佈圖也沒有連接線。請不要指望每種圖表類型都有三種明顯的結果；使用前請檢查實際輸出。

## **設定系列間隙寬度**

間隙寬度是相鄰長條或柱狀叢集之間的空間，以長條或柱狀寬度的百分比表示。與重疊類似，它屬於父系列群組，而非單一系列。請一次對群組設定 **[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)**。較大的值會在叢集之間產生更多空間，較小的值則使它們更密集。

以下範例變更間隙寬度，僅儲存最終簡報：

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

## **顯示或隱藏系列線條**

系列線條在圖表中視覺上連接相關部份。使用 **[ChartSeriesGroup.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/has_series_lines/)** 可在受支援的堆疊長條與派中派圖表中顯示或隱藏它們。在二維堆疊長條與柱狀圖中，這些線條會跨類別連接對應的堆疊邊界；在派中派與長條中派圖表中，它們會將主圖與次圖連接。此設定並非用於其他圖表類型的通用連接器。

請透過 **[ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/)** 取得群組。設定會套用到該群組內的每一個系列。**[ChartSeries.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/has_series_lines/)** 為唯讀屬性，反映父群組的設定；變更群組屬性即可更新它。

以下範例建立一個使用預設資料的 **[ChartType.PIE_OF_PIE](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)** 圖表，分別以啟用與停用系列線條儲存兩個簡報，以供比較。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 400)
    series = chart.chart_data.series[0]
    series_group = series.parent_series_group

    series_group.has_series_lines = True
    presentation.save("series_lines_enabled.pptx", slides.export.SaveFormat.PPTX)

    series_group.has_series_lines = False
    presentation.save("series_lines_disabled.pptx", slides.export.SaveFormat.PPTX)
```

| 系列線條已啟用 | 系列線條已停用 |
| --- | --- |
| ![啟用系列線條的派中派圖](series_lines_enabled.png) | ![停用系列線條的派中派圖](series_lines_disabled.png) |
| 這兩條線將主餅圖連接到次餅圖。 | 兩個餅圖仍然可見，但連接線已隱藏。 |

系列線條不同於資料標籤指引線（連接標籤與資料點）、格線（標示坐標軸間隔）以及折線圖中的線條（代表資料值）。此設定不會控制上述元素。

## **常見問題集**

**哪些圖表類型支援資料系列？**

所有由 **[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)** 列舉的圖表類型皆使用圖表資料，但它們的系列並非都有相同的值結構或設定。例如，類別圖使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則再加入氣泡大小。請使用與系列類型相符的資料點建立方法。重疊與間隙寬度等選項僅適用於相容的長條或柱狀群組。

**什麼是圖表系列群組？**

**[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/)** 包含共享群組層級繪圖設定的相容系列。組合圖表可能包含多個群組，因此透過單一系列取得的群組設定不一定會改變圖表中所有系列。

**新建立的圖表是否包含預設資料？**

是。預設情況下，**[ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/)** 會建立範例系列、類別與值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。亦可使用其他重載建立不含預設資料的圖表。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤與資料點值皆參照 **[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)** 中的儲存格。變更參照的儲存格會更新相應的圖表元素。自訂資料時，請確保類別列與系列值列對齊，以便每個點正確繪製在預期的類別下。

**如何只清除單一資料點而非整個系列？**

將相關的值儲存格設為 `None`，即可保留該點的類別位置作為空白點。僅在確實想移除該系列所有點時才使用 **[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/)**，因為該方法會移除系列內的全部資料點。如果同時移除類別，請務必更新所有系列，使其值仍與類別集合保持對齊。

**空白資料點將如何顯示？**

結果取決於圖表類型與 **[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)** 的設定。支援的圖表可將空白顯示為間隙、零值或連接相鄰點。請選擇與簡報中遺失資料意義相符的設定。詳情請參考 **[控制空儲存格的顯示](#control-the-display-of-empty-cells)** 中的完整範例與視覺比較。

**負值如何格式化？**

對於支援的長條、柱狀與氣泡系列，請啟用 **[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/)** 並設定 **[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)**。您也可以使用 **[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)** 為單一資料點覆寫此行為。這些屬性影響的是格式化，而非儲存的數值。

**當系列與資料點同時格式化時，哪個格式優先？**

明確的資料點格式會優先套用於該點。其他點則繼續使用明確的系列格式，或在系列格式未定義時使用自動圖表樣式與主題。群組屬性（如重疊與間隙寬度）僅控制版面配置，並非點層級的格式覆寫。

**圖表可容納的系列數量是否有限制？**

Aspose.Slides 本身未設定固定的系列數上限。實務上，簡報檔案的限制、可用記憶體、渲染時間以及圖表的可讀性會共同決定實際可用的上限。

**當柱狀圖列太靠近或太遠時，要如何調整？**

請於對應的父系列群組上設定 **[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)**。將值調高即可擴大叢集間的空間，降低則使叢集更緊密。