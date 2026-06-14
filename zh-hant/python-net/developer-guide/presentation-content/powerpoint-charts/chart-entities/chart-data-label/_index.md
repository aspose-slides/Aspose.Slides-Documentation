---
title: 使用 Python 在簡報中管理圖表資料標籤
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
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中新增與格式化圖表資料標籤，製作更具吸引力的投影片。"
---
## **概述**

圖表上的資料標籤會顯示圖表資料系列或單一資料點的詳細資訊。它們讓讀者能快速識別資料系列，並讓圖表更易於理解。在 Aspose.Slides for Python 中，您可以啟用、客製化與格式化任何圖表的資料標籤──選擇顯示什麼（數值、百分比、系列或類別名稱）、標籤放置位置，以及它們的外觀（字型、數字格式、分隔符、引線等）。本文概述了您在圖表中加入清晰、具資訊性的標籤所需的主要 API 與範例。

## **設定資料標籤精度**

圖表資料標籤常會顯示需要一致精度的數值。本節說明如何透過套用適當的數字格式，在 Aspose.Slides 中控制資料標籤的小數位數。

以下 Python 範例顯示如何設定圖表資料標籤的數值精度：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **以百分比作為標籤顯示**

使用 Aspose.Slides，您可以在圖表上將百分比顯示為資料標籤。以下範例計算每個點在其類別中的比例，並將標籤格式化為顯示百分比。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # 儲存包含圖表的簡報。
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **在圖表資料標籤中顯示百分號**

本節說明如何使用 Aspose.Slides 在圖表資料標籤中顯示百分比並加入百分號。您將學習如何為整個系列或特定資料點啟用百分比值（適用於圓餅圖、環形圖以及 100% 堆疊圖），以及如何透過標籤選項或自訂數字格式來控制其外觀。

以下 Python 範例示範如何在圖表的資料標籤中加入百分號：

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:

    # 依索引取得投影片參考。
    slide = presentation.slides[0]

    # 在投影片上建立 PercentsStackedColumn 圖表。
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # 取得圖表資料工作簿。
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # 新增一個系列。
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # 設定系列填充顏色。
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # 設定標籤格式屬性。
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # 新增一個系列。
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # 設定填充類型與顏色。
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # 儲存簡報。
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **設定標籤與坐標軸的距離**

本節說明如何在 Aspose.Slides 中控制資料標籤與圖表坐標軸之間的距離。調整此偏移量可避免重疊，提升密集圖形的可讀性。

以下 Python 程式碼示範在使用坐標軸圖表時，如何設定標籤與類別坐標軸的距離：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:
    # 取得投影片參考。
    slide = presentation.slides[0]

    # 在投影片上建立叢集柱狀圖。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # 設定標籤與類別（水平）軸的距離。
    chart.axes.horizontal_axis.label_offset = 500

    # 儲存簡報。
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **調整標籤位置**

當您建立不使用坐標軸的圖表（例如圓餅圖）時，資料標籤可能過於接近邊緣。此時，請調整標籤位置，使引線能清晰顯示。

以下 Python 程式碼示範如何在圓餅圖上調整標籤位置：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![調整後的標籤位置](changed_label_position.png)

## **常見問題**

**如何防止在密集圖表中資料標籤重疊？**

結合自動標籤放置、引線與縮小字型大小；如有需要，可隱藏某些欄位（例如類別），或僅對極端／關鍵點顯示標籤。

**如何僅對零、負值或空值停用標籤？**

在啟用標籤之前先篩選資料點，並根據定義的規則關閉對值為 0、負值或缺失值的顯示。

**如何確保匯出成 PDF/影像時標籤樣式一致？**

明確設定字型（字族、大小），並確認渲染端已安裝該字型，以避免回退。