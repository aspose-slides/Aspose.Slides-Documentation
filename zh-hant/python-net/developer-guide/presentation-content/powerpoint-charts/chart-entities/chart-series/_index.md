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
- 系列間距
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "學習如何在簡報中使用 Python 管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間距寬度，以及負值。"
---
## **概覽**

圖表將其繪製的資料儲存在圖表資料工作簿中。一個 [ChartSeries] 代表一組相關的值，而系列中的每個 [ChartDataPoint] 皆參照一個或多個工作簿儲存格。[ChartCategory] 物件提供系列共用的標籤或分組值。因此，系列名稱、類別與點值會連結到 [ChartDataCell] 物件，而非僅以顯示文字儲存。

對於一般的類別圖表，預設工作簿使用第 0 列作為系列名稱，第 0 行作為類別名稱，其餘儲存格則放置系列數值。傳遞給 [ChartDataWorkbook.get_cell] 的工作表、列與欄索引都是從零開始。此布局在建立具有預設資料的圖表時很有用，但不要假設所有現有圖表皆使用此布局。對於已載入的簡報，請先檢查系列、類別與資料點所參照的儲存格，再變更工作簿的值。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 [ChartSeries.format]，提供單一系列中所有點的預設外觀。
- 資料點層級設定，例如 [ChartDataPoint.format]，會覆寫單一點的系列外觀。
- 群組設定套用於屬於相同 [ChartSeriesGroup] 的相容系列。當需要設定諸如重疊或間距寬度等選項時，請透過 [ChartSeries.parent_series_group] 取得該群組。

當未設定明確的點或系列填色時，圖表樣式與佈景主題會決定自動外觀。當系列與點的格式皆存在時，點的格式會優先於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列的重疊**

[ChartSeries.overlap] 報告 2D 圖表中長條或柱狀的重疊程度，範圍從 -100% 到 100%。它是對父系列群組設定的唯讀投影。設定 [ChartSeriesGroup.overlap] 可更新該群組中所有相容系列。此選項套用於顯示分組長條或柱狀的圖表類型；對組合圖表中不相關的系列群組不會產生影響。

以下範例設定包含第一個系列的群組的重疊值：

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

![系列的重疊](series_overlap.png)

## **變更系列填色**

使用 [ChartSeries.format] 為整個系列設定預設填色。如果某個點已設定明確的填色，則其 [ChartDataPoint.format] 設定會覆寫該點的系列填色。

以下範例將實心藍色填入第一個系列：

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

系列名稱儲存在圖表資料工作簿中，通常會顯示在圖例中。在為叢集柱狀圖建立的預設工作簿中，儲存格 B1 位於第 0 列、第 1 欄，且包含第一個系列的名稱。以下範例中的命名常數明確表示該結構：

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

您也可以更新 [ChartSeries.name] 已參照的儲存格。此方法避免在現有圖表中假設特定的列與欄。

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

## **取得自動系列填色**

[ChartSeries.get_automatic_series_color] 回傳根據系列索引與圖表樣式計算出的顏色。這是系列填色未明確定義時使用的顏色。呼叫此方法會取得計算出的顏色；不會指派新的填色。

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

確切的顏色取決於圖表樣式與佈景主題。

## **設定圖表系列的反轉填色**

對於長條、柱狀與氣泡系列，[ChartSeries.invert_if_negative] 可以以不同的填色顯示負值。將一般系列填色設定為實心，啟用反轉，並透過 [ChartSeries.inverted_solid_fill_color] 指定負值的顏色。負數在工作簿中保持不變；僅其顯示顏色會改變。

以下範例以單一系列取代預設圖表資料。工作表第 0 列包含系列名稱，第 0 欄包含類別名稱，第 1 欄包含值：

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

![反轉的實心填色](inverted_solid_fill_color.png)

您可以透過 [ChartDataPoint.invert_if_negative] 為單一點啟用反轉。在以下範例中，系列的反轉被停用，且僅對所選點啟用。該點同時被賦予負值，以便看到效果：

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

若要讓某一點變為空白而不移除其他點，請將其對應的工作簿儲存格設定為 `None`。對於柱狀圖，可透過 [ChartDataPoint.value] 取得繪製的值。資料點仍保留在相同的類別位置，但圖表會依據其空白值設定將該值視為空白。

以下範例僅清除第一個系列中的第二個點：

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

散布圖使用分離的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。僅清除代表您欲移除之數值的儲存格。若想保留其他點，請勿呼叫 [ChartDataPointCollection.clear]，因為該方法會從集合中移除所有資料點。

## **控制空儲存格的顯示**

含有值的隱藏儲存格與空儲存格是不同的情況。若要包含或排除來自隱藏工作表列與欄的資料，請參閱 [Include Data from Hidden Rows and Columns](/slides/zh-hant/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空的工作簿儲存格代表缺少的資料；而包含 `0` 的儲存格則代表已知的數值。將 [ChartDataCell.value] 設為 `None` 即可使儲存格變為空白。無論空儲存格設定為何，數值零皆保持為零。

使用 [Chart.display_blanks_as] 來選擇圖表如何顯示空儲存格。此設定套用於整個圖表，會改變空白的繪製方式，而不會以零或插值填入空的工作簿儲存格。

以下獨立範例建立一個含單一系列的折線圖，清除第 3 天的值，並以每種模式保存相同的圖表。無需輸入檔案。[ChartDataWorkbook] 使用工作表 0、欄 0 作為類別標籤，欄 1 作為數值；第 0 列保存系列名稱。最終資料為 `10, 20, empty, 30, 40`。

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

每個輸出檔案會在儲存前記錄所指定的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。若只想保存單一版本，請指派所需的模式，並僅保存簡報一次，而非遍歷所有模式。

以下比較顯示三個檔案內相同的資料。第 3 天在工作簿中皆為空白：

![相同資料的折線圖：Gap 在第 3 天斷開線條，Zero 將線條降至零，Span 則將第 2 天與第 4 天相連。](display_blanks_as.png)

可見效果取決於圖表類型。折線圖能輕易比較三種模式。長條圖與柱狀圖沒有線條可跨過缺少的類別，因此 `SPAN` 無法產生上圖所示的連接段落；缺少的柱狀與零高度的柱狀也可能看起來相似。同樣地，只有標記的散布圖也沒有連接線。不要期望每種圖表類型都有三個明顯不同的結果；請檢查您使用的圖表類型的輸出。

## **設定系列間距寬度**

間距寬度是相鄰長條或柱狀叢集之間的空間，以長條或柱狀寬度的百分比表示。與重疊相同，它屬於父系列群組，而非單一系列。對該群組設定一次 [ChartSeriesGroup.gap_width] 即可。較大的數值會在叢集之間產生較多空間，較小的數值則使其更緊密。

以下範例變更間距寬度，並僅保存最終的簡報：

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

## **FAQ**

**哪種類型的圖表支援資料系列？**

所有由 [ChartType] 列舉表示的圖表類型皆使用圖表資料，但其系列並不全部具有相同的值結構或設定。例如，類別圖表使用類別與值，散布圖使用 X 與 Y 值，氣泡圖則加入氣泡大小。請使用與系列類型相符的資料點建立方法。諸如重疊與間距寬度等選項僅適用於相容的長條或柱狀群組。

**什麼是圖表系列群組？**

[ChartSeriesGroup] 包含相容的系列，這些系列共享群組層級的繪圖設定。組合圖表可以包含多個群組，因此透過某一系列取得的群組變更不一定會影響圖表中的所有系列。

**新建立的圖表是否包含預設資料？**

是。預設情況下，[ShapeCollection.add_chart] 會建立範例系列、類別與數值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前清除系列與類別集合。亦可使用另一個重載建立不含預設資料的圖表。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤與資料點值皆參照 [ChartDataWorkbook] 中的儲存格。變更參照的儲存格會更新相應的圖表元素。建立自訂資料時，請保持類別列與系列值列對齊，使每個點都繪製在預期的類別之下。

**如何只清除一個點而非整個系列？**

將相關的值儲存格設為 `None`，即可保留該點的類別位置作為空白點。僅在想要移除該系列所有點時才使用 [ChartDataPointCollection.clear]。如果同時移除類別，請更新所有系列，使其數值仍與類別集合保持對齊。

**空點如何顯示？**

結果取決於圖表類型與 [Chart.display_blanks_as]。支援的圖表可以將空白顯示為間隙、零值或連接相鄰點。請選擇與簡報中遺漏資料意涵相符的設定。參見 [控制空儲存格的顯示](#control-the-display-of-empty-cells) 以取得完整範例與視覺比較。

**負值如何格式化？**

對於支援的長條、柱狀與氣泡系列，啟用 [ChartSeries.invert_if_negative] 並設定 [ChartSeries.inverted_solid_fill_color]。您也可以使用 [ChartDataPoint.invert_if_negative] 為單一點覆寫此行為。這些屬性影響格式化，而非儲存的數值。

**當系列和點都設定格式時，哪個優先？**

對於該點，明確的資料點格式會優先。其他點則繼續使用明確的系列格式，或在未定義系列格式時使用自動圖表樣式與佈景主題。群組屬性（如重疊與間距寬度）控制版面配置，並非點層級格式的覆寫。

**圖表的系列數量有上限嗎？**

Aspose.Slides 並未設定固定的系列數量上限。實務上，簡報檔案的限制、可用記憶體、渲染時間與圖表可讀性會決定實際可接受的上限。

**當柱狀太靠近或太分散時該如何調整？**

在適當的父系列群組上設定 [ChartSeriesGroup.gap_width]。增加數值可擴大叢集之間的間距，減少則可使叢集更靠近。