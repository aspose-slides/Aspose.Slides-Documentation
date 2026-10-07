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
- 系列間距
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Python 在簡報中管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間距寬度以及負值。"
---
## **概觀**

A chart stores its plotted data in a chart data workbook. A [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) represents one set of related values, and each [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) in the series refers to one or more workbook cells. [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) objects provide the labels or grouping values shared by the series. The series name, categories, and point values are therefore connected to [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) objects rather than stored only as display text.

對於典型的類別圖表，預設工作簿使用第 0 列儲存系列名稱，第 0 欄儲存類別名稱，其餘儲存格則放置系列值。傳遞給 [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) 的工作表、列和欄索引都是從 0 開始。此布局在建立預設資料圖表時很有用，但請不要假設所有既有圖表皆使用此布局。對於已載入的簡報，請在變更工作簿值之前先檢查系列、類別與資料點所參照的儲存格。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)，為單一系列的所有資料點提供預設外觀。
- 資料點層級設定，例如 [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)，會覆寫該系列的外觀僅針對單一資料點。
- 群組設定套用於屬於相同 [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) 的相容系列。需要設定重疊或間距寬度等選項時，請透過 [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) 取得群組。

當未明確設定資料點或系列的填色時，圖表樣式與佈景主題會決定自動外觀。當同時存在系列與資料點格式時，資料點格式具有優先權。

![圖表系列 PowerPoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) 會報告 2D 圖表中長條或柱狀的重疊程度，範圍從 -100% 到 100%。它是父系列群組設定的唯讀投射。設定 [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) 以更新該群組內所有相容的系列。此選項僅適用於顯示分組長條或柱狀的圖表類型；對組合圖表中不相關的系列群組不會產生影響。

以下範例設定包含第一個系列的群組的重疊：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # 新的圖表包含範例系列、類別和數值。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![系列重疊](series_overlap.png)

## **變更系列填色**

使用 [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) 為整個系列設定預設填色。如果資料點已具備明確填色，其 [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) 設定會覆寫該系列的填色。

以下範例將第一個系列套用實心藍色填色：

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

系列名稱儲存在圖表資料工作簿中，通常顯示於圖例。預設用於叢集柱狀圖的工作簿中，儲存格 B1 位於第 0 列第 1 欄，內含第一個系列的名稱。下列範例中的具名常數明確說明了此結構：

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

您也可以直接更新由 [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) 參照的儲存格。此作法避免在既有圖表中假設特定的列與欄：

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

### **建立由多個儲存格組成的系列名稱**

當產品名稱與報告期間分別儲存在不同工作簿儲存格時，組合系列名稱會很有用。例如，您可以將 B1 中的 `Product A` 與 C1 中的 `2026` 合併為單一系列名稱，同時保持兩部分皆連結至其來源儲存格。

使用 [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) 取得名稱範圍，然後將該集合傳遞給 [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/)。`skip_hidden_cells` 參數控制是否包含隱藏儲存格：`True` 會排除，`False` 會包含。本例使用 `False` 以包含名稱範圍內的所有儲存格。

以下範例建立一個包含一個系列與兩個資料點的簡報。儲存格 B1:C1 只提供系列名稱；A2:A3 提供類別標籤，B2:B3 提供數值。

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

    # 分別的儲存格提供類別和數值資料點。
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

產生的系列名稱為 `Product A 2026`，兩個儲存格值之間有一個空格。圖例會將其顯示為兩欄的單一條目。下圖是從已儲存的簡報匯出的圖像：

![具有北部與南部值且圖例中顯示組合系列名稱 Product A 2026 的柱狀圖](composite_series_name.png)

## **取得自動系列填色**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) 會回傳依系列索引與圖表樣式計算出的顏色。這是系列填色未明確定義時所使用的顏色。呼叫此方法僅會讀取計算出的顏色，不會指派新的填色。

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

實際顏色取決於圖表樣式與佈景主題。

## **為圖表系列設定負值反轉填色**

對於長條、柱狀與氣泡系列，[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) 可在負值時使用不同的填色。將一般系列填色設定為實心，啟用反轉，並透過 [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) 指定負值顏色。負數在工作簿中保持不變，僅變更其顯示顏色。

以下範例以單一系列取代預設圖表資料。工作表第 0 列為系列名稱，第 0 欄為類別名稱，第 1 欄為數值：

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

您也可以針對單一資料點啟用反轉，方法是使用 [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)。以下範例在系列層面停用反轉，僅為選取的資料點啟用，同時將該點的值設為負數，以便看見效果：

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

若要讓單一資料點變為空白而不移除其他資料點，請將其對應的工作簿儲存格設為 `None`。對於柱狀圖，繪製的值可透過 [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) 取得。資料點仍保留在相同的類別位置，但圖表會根據空白值設定將其視為空白。

以下範例僅清除第一個系列的第二個資料點：

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

散佈圖使用獨立的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。僅清除您欲移除之值所對應的儲存格。若只想保留其他資料點，請勿呼叫 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/)，因為該方法會移除該系列中的所有資料點。

## **控制空儲存格的顯示方式**

包含值的隱藏儲存格屬於與空儲存格不同的情況。若要包含或排除來自隱藏工作表列與欄的資料，請參考 [Include Data from Hidden Rows and Columns](/slides/zh-hant/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空的工作簿儲存格代表遺失資料；含有 `0` 的儲存格則代表已知的數值。將 [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) 設為 `None` 可使儲存格為空。數值零無論空白儲存格設定為何，都仍保持為零。

使用 [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) 來選擇圖表如何顯示空儲存格。此設定套用於整個圖表，會改變空白的繪製方式，而不會將空的工作簿儲存格填入零或插值。

以下自包含範例建立一個只有一個系列的折線圖，清除第 3 天的值，並以每種模式儲存同一圖表。此範例不需要輸入檔案。[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) 使用工作表 0，第 0 欄作為類別標籤，第 1 欄作為數值；第 0 列保存系列名稱。最終資料為 `10, 20, empty, 30, 40`。

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

    # 將第 3 天真正留空，同時保留其類別和資料點。
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

每個輸出檔案在儲存前會使用相應的模式命名：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 與 `empty_cells_Span.pptx`。若只想產生單一版本，請在儲存簡報前設定所需模式，然後僅儲存一次即可，而不必遍歷所有模式。

下圖比較了三個檔案中相同的資料。第 3 天在工作簿中皆為空：

![折線圖中相同資料的顯示差異：Gap 在第 3 天斷開線段，Zero 使線段跌至零，Span 將第 2 天與第 4 天連接起來。](display_blanks_as.png)

可視化效果取決於圖表類型。折線圖易於比較三種模式；長條與柱狀圖沒有連線可跨過缺失的類別，因此 `SPAN` 無法產生上述連接段落；缺少的柱與零高度的柱也可能看起來相似。類似地，只有標記的散佈圖也沒有連線。不要期望每種圖表類型都能得到三種明顯不同的結果；請自行檢查所使用圖表的輸出。

## **設定系列間距寬度**

間距寬度是相鄰長條或柱狀叢集之間的空間，表示為長條或柱狀寬度的百分比。與重疊類似，它屬於父系列群組而非單一系列。對群組一次設定 [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) 即可。較大的值會在叢集之間產生更多空間，較小的值則使其更緊密。

以下範例變更間距寬度並僅儲存最終的簡報：

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

![間距寬度](gap_width.png)

## **常見問題**

**哪些圖表類型支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列舉的圖表類型皆使用圖表資料，但其系列並非全部具備相同的值結構或設定。例如，類別圖使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則額外使用氣泡大小。請使用與系列類型相符的資料點建立方法。重疊與間距寬度等選項僅套用於相容的長條或柱狀群組。

**什麼是圖表系列群組？**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) 包含共享群組層級繪圖設定的相容系列。組合圖表可能包含多個群組，因此透過單一系列取得的群組設定不一定會影響圖表中的所有系列。

**新建立的圖表是否包含預設資料？**

是。預設情況下，[ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) 會建立範例系列、類別與值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。也可使用其他重載建立不帶預設資料的圖表。

**圖表物件如何與工作簿儲存格相連？**

系列名稱、類別標籤與資料點值皆參照 [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) 中的儲存格。變更參照的儲存格會更新對應的圖表元素。建立自訂資料時，請保持類別列與系列值列對齊，以確保每個點均繪製於正確的類別下。

**如何只清除單一資料點而不是整個系列？**

將相關的值儲存格設為 `None`，即可保留該點的類別位置作為空白點。僅在需要移除該系列所有點時才使用 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/)。如果同時移除類別，請確保所有系列的值仍與類別集合保持對齊。

**空白點會如何顯示？**

結果取決於圖表類型與 [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)。支援的圖表可以將空白顯示為間隔、零值或連接相鄰點。選擇最符合您簡報中遺失資料意義的設定。完整範例與視覺比較請參閱 [控制空儲存格的顯示方式](#control-the-display-of-empty-cells)。

**負值的格式如何設定？**

對於支援的長條、柱狀與氣泡系列，啟用 [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) 並設定 [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)。您也可以使用 [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) 為單一資料點覆寫此行為。這些屬性僅影響格式，不會改變儲存的數值。

**當系列與資料點同時設定格式時，哪個會生效？**

明確的資料點格式優先套用於該點。其他點仍會使用明確的系列格式，或在未定義系列格式時使用自動圖表樣式與佈景主題。群組屬性（如重疊與間距寬度）控制版面配置，並非資料點層級的格式覆寫。

**圖表可容納的系列數量是否有限制？**

Aspose.Slides 本身並未設定固定的系列數量上限。實務上，簡報檔案大小、可用記憶體、渲染時間與圖表可讀性等因素會決定實際可用的上限。

**當柱狀圖的柱子過於靠近或過於分散時，我該如何調整？**

對適當的父系列群組設定 [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)。將值調高會增加叢集之間的間距，調低則會讓叢集更緊湊。