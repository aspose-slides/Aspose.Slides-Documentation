---
title: 使用 Python 在簡報中自訂圓餅圖
linktitle: 圓餅圖
type: docs
url: /zh-hant/python-net/pie-chart/
keywords:
- 圓餅圖
- 管理圖表
- 自訂圖表
- 圖表選項
- 圖表設定
- 繪圖選項
- 切片顏色
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中建立並自訂圓餅圖。配置次要圖表、顯示資料標籤，並在 PowerPoint 中套用自動切片顏色。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圓餅圖。它展示了如何為 Pie of Pie 與 Bar of Pie 圖表設定次要圖表選項，以及如何為標準圓餅圖啟用自動切片著色。

範例著重於圖表自訂工作，例如將圖表加入投影片、調整系列與標籤設定、以自訂類別與數值取代預設圖表資料，並儲存更新後的簡報。

## **Pie of Pie 與 Bar of Pie 圖表的次要圖表選項**

Aspose.Slides for Python via .NET 支援 Pie of Pie 與 Bar of Pie 圖表的次要圖表選項。這些選項控制次要圖表的大小以及資料點在兩個圖表之間的分割方式。

以下範例在新簡報中建立 Pie of Pie 圖表，並將資料點值顯示為標籤。 [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) 屬性將次要圖表大小設定為主圖表的 149%。 [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) 選擇以百分比方式分割，且 [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) 將門檻設定為 53%。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # 顯示值並配置次要圖表。
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **選取次要圖表的類別**

當您想在次要圖表中以自訂方式分組特定類別，而不考慮其百分比值時，請使用自訂分割。例如，銷售報告可能會將「線上」與「活動」放在一起，讓讀者能比較這兩個管道，即使它們分別只佔總銷售的 35% 與 10%。

將 [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) 設為 [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/)，並透過 [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/) 來選取點。此集合的 [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) 方法接受系列中的零基索引或資料點物件。在本例中，索引 1 選取「線上」，索引 3 的點選取「活動」。亦暫時加入「合作夥伴」，然後使用 [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/) 將其排除。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # 用渠道的銷售資料取代預設資料。
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # 以零基索引選取「線上」，並以資料點物件選取「活動」。
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # 在不刪除來源資料的情況下，將「合作夥伴」從選取中排除。
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

「線上」(35) 與「活動」(10) 會在次要圖表中顯示為獨立切片。在主圖表中，它們以 45 的合併切片表示，此外還有「零售」(40) 與「合作夥伴」(15)。將「合作夥伴」從自訂選取中移除，只會讓它不出現在次要圖表中；不會從圖表的來源資料中移除該類別或其數值。

以下圖片顯示在 PowerPoint 中儲存的簡報：

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **設定自動圓餅圖切片顏色**

Aspose.Slides for Python via .NET 可以自動為圓餅圖切片分配不同顏色。以下範例建立一個置中標題的圓餅圖，並以三個季節類別及其數值取代預設資料。[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) 屬性會將 20、50、30 的數值顯示為標籤，而 [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) 則啟用每個切片使用不同顏色。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # 新增置中圖表標題。
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # 使用第一個工作表取代預設資料。
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # 顯示數值並為切片指定不同顏色。
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**是否支援 Pie of Pie 與 Bar of Pie 變體？**

是的，函式庫 [支援](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 圓餅圖的次要圖表，包括 Pie of Pie 與 Bar of Pie 類型。

**我可以只將圖表匯出為圖像（例如 PNG）嗎？**

可以，您可以 [匯出圖表本身為圖像](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/)（例如 PNG），而不必匯出整個簡報。