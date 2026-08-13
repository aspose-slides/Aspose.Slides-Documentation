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
description: "了解如何在簡報中使用 Python 管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間距寬度與負值。"
---
## **概觀**

圖表將其繪製的資料儲存在圖表資料工作簿中。 一個[ChartSeries](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/) 代表一組相關的值，系列中的每個[ChartDataPoint](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapoint/) 參照一個或多個工作簿儲存格。[ChartCategory](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartcategory/) 物件提供系列共用的標籤或分組值。因此，系列名稱、類別和資料點值會連結到[ChartDataCell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatacell/) 物件，而不是僅以顯示文字儲存。

對於典型的類別圖表，預設工作簿使用第 0 列作為系列名稱，第 0 行作為類別名稱，剩餘儲存格則放置系列值。傳遞給[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) 的工作表、列和欄索引是從零開始的。此佈局在建立預設資料的圖表時很有用，但不要假設每個現有圖表都使用它。對於已載入的簡報，請在變更工作簿值之前先檢查系列、類別和資料點所參照的儲存格。

圖表設定有三種不同的層級：

- 系列層級設定，例如[ChartSeries.format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/format/)，提供整個系列所有資料點的預設外觀。
- 資料點層級設定，例如[ChartDataPoint.format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapoint/format/)，會覆寫單一資料點的系列外觀。
- 群組設定適用於屬於相同[ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseriesgroup/)的相容系列。當需要設定重疊或間距等選項時，透過[ChartSeries.parent_series_group](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/parent_series_group/)存取該群組。

當未設定明確的資料點或系列填色時，圖表樣式和主題會決定自動外觀。當同時存在系列和資料點格式設定時，資料點的格式會優先套用於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

[ChartSeries.overlap](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/overlap/) 回報 2D 圖表中條形或柱狀的重疊程度，範圍從 -100% 到 100%。它是父系列群組設定的唯讀投射。設定[ChartSeriesGroup.overlap](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseriesgroup/overlap/) 以更新該群組中所有相容的系列。此選項適用於顯示分組條形或柱狀的圖表類型；不會影響組合圖表中不相關的系列群組。

以下範例設定包含第一個系列的群組的重疊：

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

![The series overlap](series_overlap.png)

## **變更系列填色**

使用[ChartSeries.format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/format/) 來設定整個系列的預設填色。如果資料點已具備明確的填色，其[ChartDataPoint.format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapoint/format/) 設定會覆寫該點的系列填色。

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

![The color of the series](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常會在圖例中顯示。對於預設為叢集柱狀圖的工作簿，儲存格 B1 位於第 0 列第 1 欄，內含第一個系列的名稱。下列範例中的具名常數明確說明了此結構：

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

您也可以直接更新[ChartSeries.name](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/name/) 已參照的儲存格。此做法避免在現有圖表中假設特定的列與欄：

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

![The series name](series_name.png)

## **取得自動系列填色**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) 傳回根據系列索引和圖表樣式計算出的顏色。這是未明確定義系列填色時使用的顏色。呼叫此方法只會讀取計算出的顏色，不會指派新的填色。

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

## **設定系列的負值倒置填色**

對於條形、柱狀和氣泡系列，[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/invert_if_negative/) 可在負值時使用不同的填色。先將系列填色設定為實心，啟用倒置，並透過[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) 指定負值顏色。負數在工作簿中保持不變，僅其顯示顏色會改變。

以下範例以單一系列取代預設圖表資料。工作表第 0 列放系列名稱，第 0 欄放類別名稱，第 1 欄放數值：

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

![The inverted solid fill color](inverted_solid_fill_color.png)

您也可以透過[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) 為單一資料點啟用倒置。以下範例在系列已停用倒置的情況下，只為選取的點啟用，並將該點指派負值以便看到效果：

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

若要讓單一資料點變為空白而不移除其他點，請將其對應的工作簿儲存格設為 `None`。對於柱狀圖，繪製的值可透過[ChartDataPoint.value](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapoint/value/) 取得。資料點仍保留在相同的類別位置，但圖表會依照其空白值設定將其視為空白。

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

散佈圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。僅清除欲移除之值所對應的儲存格。若想保留其他資料點，請勿呼叫[ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapointcollection/clear/)，因為該方法會移除集合中的所有資料點。

## **設定系列間距寬度**

間距寬度是相鄰條形或柱狀叢集之間的空間，以條形或柱狀寬度的百分比表示。與重疊類似，它屬於父系列群組而非單一系列。對該群組一次設定[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)。較大的值會在叢集之間產生更多空間，較小的值則使叢集更緊密。

以下範例變更間距寬度，並只儲存最終的簡報：

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

![The gap width](gap_width.png)

## **常見問題**

**哪種圖表類型支援資料系列？**

所有由[ChartType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/charttype/) 列舉的圖表類型皆使用圖表資料，但其系列並非全部具備相同的值結構或設定。例如，類別圖使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則額外使用氣泡大小。請使用與系列類型相符的資料點建立方法。重疊與間距等選項僅適用於相容的條形或柱狀群組。

**什麼是圖表系列群組？**

[ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseriesgroup/) 包含共享群組層級繪圖設定的相容系列。組合圖表可以包含多個群組，因此透過單一系列取得的群組設定不一定會影響圖表中的所有系列。

**新建立的圖表是否包含預設資料？**

是。預設情況下，[ShapeCollection.add_chart](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_chart/) 會建立範例系列、類別與值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。也有覆載可建立不含預設資料的圖表。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤與資料點值皆參照[ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdataworkbook/) 中的儲存格。變更被參照的儲存格會更新對應的圖表元素。建構自訂資料時，請保持類別列與系列值列對齊，以確保每個資料點繪製於正確的類別下。

**如何只清除一個資料點而不是整個系列？**

將相關的值儲存格設為 `None`，即可保留該點的類別位置作為空白點。只有在確定要移除該系列所有資料點時才使用[ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapointcollection/clear/)。若同時移除類別，請更新每個系列使其值仍與類別集合保持對齊。

**空白點會如何顯示？**

結果取決於圖表類型與[Chart.display_blanks_as](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/display_blanks_as/)。支援的圖表可將空白顯示為間距、零值或連接相鄰點。請選擇符合簡報中遺失資料意義的設定。

**負值如何格式化？**

對於支援的條形、柱狀與氣泡系列，啟用[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/invert_if_negative/) 並設定[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)。您亦可使用[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) 為單一資料點覆寫此行為。這些屬性影響格式，而非儲存的數值。

**當系列與資料點同時設定格式時，哪個會優先？**

明確的資料點格式會優先套用於該點。其他點則持續使用明確的系列格式，若系列未定義則使用自動圖表樣式與主題。群組屬性如重疊與間距控制版面配置，並非資料點層級的格式覆寫。

**圖表的系列數量有上限嗎？**

Aspose.Slides 本身沒有設置固定的系列數量上限。實務上，簡報檔案的限制、可用記憶體、渲染時間以及圖表的可讀性會決定實際可容納的系列數量。

**當柱狀圖的柱子過於密集或過於稀疏時，我該如何調整？**

在適當的父系列群組上設定[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)。增加數值會擴大叢集之間的間距，減少數值則會使叢集更靠近。