---
title: 使用 Python 管理簡報中的圖表資料標籤
linktitle: 資料標籤
type: docs
url: /zh-hant/python-net/chart-data-label/
keywords:
- 圖表
- 資料標籤
- 資料精度
- 百分比
- 標籤距離
- 標籤位置
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 簡報中新增與格式化圖表資料標籤，打造更具吸引力的投影片。"
---
## **簡介**

資料標籤顯示圖表系列和單一資料點的資訊，協助讀者辨識數值並了解圖表。本文說明如何格式化數值、顯示百分比、讀取標籤文字、調整類別軸標籤間距，以及設定圓形圖標籤的位置。

## **在圖表資料標籤中設定資料精度**

使用[number_format_of_values](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/number_format_of_values/)來格式化系列數值。此範例建立一個使用預設資料的折線圖，顯示其資料表，並為第一個系列啟用值標籤。格式`#,##0.00`會顯示千位分隔符號與兩位小數，但不會改變底層的數值。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **將百分比顯示為標籤**

對於堆疊直條圖，計算每個數值佔其類別總和的百分比，並將文字指派給[text_frame_for_overriding](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/)。此範例使用預設圖表資料，並以 8 點字型顯示兩位小數的百分比。總和為零的類別會被略過，以避免除以零的錯誤。若圖表資料變更，請重新計算自訂標籤文字。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在圖表資料標籤中設定百分比符號**

當數值以分數形式儲存時，使用[number_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datalabelformat/number_format/)來顯示百分比。將[is_number_format_linked_to_source](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/)設為`False`，即可讓標籤格式獨立於來源儲存格。

此範例建立一個 100% 堆疊直條圖，四個類別各有紅色與藍色系列。每對數值的總和為 1。標籤格式`0.0%`會把 0.30 顯示為 30.0%，而直條軸則使用兩位小數。兩個系列的標籤文字皆為白色、10 點字型。

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **讀取資料標籤的實際文字**

使用[get_actual_label_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datalabel/get_actual_label_text/)取得資料標籤設定所產生的文字。此功能在擷取標籤以製作報告、搜尋簡報內容或驗證產生的圖表時非常有用。以下範例中，預設[data label format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datalabelformat/)會結合每個類別名稱、系列名稱與數值。某個點將其數值格式化為百分比，另一個點則使用[text_frame_for_overriding](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/)中的自訂文字。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

儲存在資料點中的數字仍為`0.75`，即使其標籤顯示`75%` 並附帶類別與系列名稱。自訂文字會取代系統產生的標籤文字。無論哪種情況，[get_actual_label_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datalabel/get_actual_label_text/)都會回傳最終的標籤字串。若只想擷取可見的標籤，請如上例分別檢查[is_visible](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datalabel/is_visible/)。

## **設定標籤與軸的距離**

使用[label_offset](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/axis/label_offset/)來控制類別軸標籤與軸之間的距離。此數值為軸標籤最大字型大小的百分比。本範例建立一個群組直條圖，將水平軸標籤偏移設為 500。此設定會影響類別軸標籤，而非附加於個別資料點的標籤。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **調整標籤位置**

在圓形圖中，調整資料標籤的位置以改善間距並為指示線留出空間。

此範例顯示第一筆資料的數值，將其標籤放在切片外部，並調整其[x](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datalabel/x/)與[y](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datalabel/y/)偏移。這兩個偏移分別以圖表寬度與高度為相對基準。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![調整後的圓形圖資料標籤位置](pie-chart-adjusted-label.png)

## **常見問答**

**如何防止在密集圖表中資料標籤重疊？**

結合自動標籤放置、指示線以及縮小字型大小；必要時隱藏某些欄位（例如類別），或僅對極端值或關鍵點顯示標籤。

**如何僅對零值、負值或空值停用標籤？**

在啟用標籤前先篩選資料點，並依據自訂規則關閉 0、負值或缺失值的顯示。

**如何確保匯出為 PDF/影像時標籤樣式保持一致？**

明確設定字型系列與大小，並確認渲染環境中已安裝該字型，以避免使用備援字型。