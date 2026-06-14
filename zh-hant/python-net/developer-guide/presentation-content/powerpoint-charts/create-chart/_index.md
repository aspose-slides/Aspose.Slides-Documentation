---
title: 在 Python 中建立或更新 PowerPoint 簡報圖表
linktitle: 建立或更新圖表
type: docs
weight: 10
url: /zh-hant/python-net/create-chart/
keywords:
- 新增圖表
- 建立圖表
- 編輯圖表
- 變更圖表
- 更新圖表
- 散佈圖
- 圓餅圖
- 折線圖
- 樹狀圖
- 股票圖表
- 箱形圖
- 漏斗圖
- 旭日圖
- 直方圖
- 雷達圖
- 多類別圖表
- PowerPoint 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中建立與自訂圖表。內容涵蓋在簡報中加入、格式化與編輯圖表，並提供實用的 Python 程式碼範例。"
---
## **概述**

本文提供了使用 Aspose.Slides for Python via .NET 建立與自訂圖表的完整指南。您將學習如何以程式方式將圖表新增至投影片、填入資料，並套用各種格式設定以符合特定的設計需求。全文提供詳細的程式碼範例，說明從初始化 Presentation 與圖表物件，到設定系列、座標軸與圖例的每一步驟。遵循本指南，您將深入瞭解如何在應用程式中整合動態圖表產生，簡化建立資料驅動簡報的流程。

## **建立圖表**

圖表可協助人們快速視覺化資料，並從中獲得在表格或試算表中不易察覺的見解。

**為何要建立圖表？**

使用圖表，您可以：

* 在單一投影片上彙總、濃縮或摘要大量資料；
* 揭示資料中的模式與趨勢；
* 推斷資料隨時間或相對於特定測量單位的方向與動能；
* 發現極端值、異常、偏差、錯誤與不合理的資料；
* 傳達或呈現複雜資料。

在 PowerPoint 中，您可以透過 *Insert* 功能建立圖表，該功能提供多種圖表範本。使用 Aspose.Slides，您可以建立一般圖表（基於常見圖表類型）以及自訂圖表。

{{% alert color="primary" %}} 
使用位於 [Aspose.Slides.Charts] 命名空間下的 [ChartType] 列舉。此列舉中的值對應不同的圖表類型。
{{% /alert %}} 

### **建立叢集柱狀圖**

本節說明如何使用 Aspose.Slides for Python via .NET 建立叢集柱狀圖。您將學習初始化簡報、加入圖表，並自訂標題、資料、系列、類別及樣式等元素。依照以下步驟即可產生標準的叢集柱狀圖：

1. 建立 [Presentation] 類別的實例。  
2. 取得指定索引的投影片參考。  
3. 加入圖表並提供一些資料，指定 `ChartType.CLUSTERED_COLUMN` 類型。  
4. 為圖表新增標題。  
5. 取用圖表的資料工作表。  
6. 清除所有預設的系列與類別。  
7. 新增系列與類別。  
8. 為圖表系列新增資料。  
9. 為圖表系列套用填色。  
10. 為圖表系列新增標籤。  
11. 將修改後的簡報儲存為 PPTX 檔。

此 Python 程式碼示範如何建立叢集柱狀圖：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立代表 PPTX 檔案的 Presentation 類別實例。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增具有預設資料的叢集柱狀圖。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # 設定圖表標題。
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # 設定第一個系列顯示數值。
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # 設定圖表資料工作表的索引。
    worksheet_index = 0

    # 取得圖表資料活頁簿。
    workbook = chart.chart_data.chart_data_workbook

    # 刪除預設產生的系列與類別。
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 新增系列。
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # 新增類別。
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # 取得第一個圖表系列。
    series = chart.chart_data.series[0]

    # 填入系列資料。
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # 設定系列的填色。
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # 取得第二個圖表系列。
    series = chart.chart_data.series[1]

    # 填入系列資料。
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # 設定系列的填色。
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # 設定第一個標籤顯示類別名稱。
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # 設定系列在第三個標籤上顯示數值。
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # 將簡報儲存為 PPTX 檔案。
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![叢集柱狀圖](clustered_column_chart.png)

### **建立散佈圖**

散佈圖（亦稱為散點圖或 x‑y 圖）常用於檢查模式或展示兩個變數之間的相關性。

在以下情況使用散佈圖：

* 您有成對的數值資料。  
* 您有兩個相互關聯的變數。  
* 您想判斷這兩個變數是否相關。  
* 您有一個獨立變數對多個依賴變數具多值。

此 Python 程式碼示範如何使用不同標記系列建立散佈圖：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立 Presentation 類別實例。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 建立預設的散佈圖。
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # 設定圖表資料工作表的索引。
    worksheet_index = 0

    # 取得圖表資料活頁簿。
    workbook = chart.chart_data.chart_data_workbook

    # 刪除預設的系列。
    chart.chart_data.series.clear()

    # 新增系列。
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # 取得第一個圖表系列。
    series = chart.chart_data.series[0]

    # 為系列新增一個點 (1:3)。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # 新增一個點 (2:10)。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # 變更系列類型。
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # 變更圖表系列標記。
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # 取得第二個圖表系列。
    series = chart.chart_data.series[1]

    # 為圖表系列新增一個點 (5:2)。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # 新增一個點 (3:1)。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # 新增一個點 (2:2)。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # 新增一個點 (5:1)。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # 變更圖表系列標記。
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![散佈圖](scatter_chart.png)

### **建立圓餅圖**

圓餅圖最適合用於顯示資料的整體與部分關係，特別是當資料包含帶有數值的類別標籤時。然而，若資料包含過多部份或標籤，建議改使用條狀圖。

1. 建立 [Presentation] 類別的實例。  
2. 取得指定索引的投影片參考。  
3. 加入圖表並使用預設資料，指定 `ChartType.PIE` 類型。  
4. 取用圖表的資料活頁簿（[ChartDataWorkbook]）。  
5. 清除預設的系列與類別。  
6. 新增系列與類別。  
7. 為圖表系列新增資料。  
8. 為圓餅圖的各扇區新增點並套用自訂顏色。  
9. 為系列設定標籤。  
10. 為系列標籤啟用引線。  
11. 設定圓餅圖的旋轉角度。  
12. 將修改後的簡報儲存為 PPTX 檔。

此 Python 程式碼示範如何建立圓餅圖：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立代表 PPTX 檔案的 Presentation 類別實例。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增具有預設資料的圖表。
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # 設定圖表標題。
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # 設定第一個系列顯示數值。
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # 設定圖表資料工作表的索引。
    worksheet_index = 0

    # 取得圖表資料活頁簿。
    workbook = chart.chart_data.chart_data_workbook

    # 刪除預設產生的系列與類別。
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 新增類別。
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # 新增系列。
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # 填入系列資料。
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # 設定扇區顏色。
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # 設定扇區邊框。
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # 設定扇區邊框。
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # 設定扇區邊框。
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # 為新系列的每個類別建立自訂標籤。
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # 設定系列在圖表中顯示引線。
    series.labels.default_data_label_format.show_leader_lines = True

    # 設定圓餅圖扇區的旋轉角度。
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![圓餅圖](pie_chart.png)

### **建立折線圖**

折線圖（亦稱為折線圖）最適合用於展示隨時間變化的數值。使用折線圖，您可以一次比較大量資料、追蹤時間變化趨勢、突顯資料系列的異常等。

1. 建立 [Presentation] 類別的實例。  
2. 取得指定索引的投影片參考。  
3. 加入圖表並使用預設資料，指定 `ChartType.LINE` 類型。  
4. 取用圖表的資料活頁簿（[ChartDataWorkbook]）。  
5. 清除預設的系列與類別。  
6. 新增系列與類別。  
7. 為圖表系列新增資料。  
8. 將修改後的簡報儲存為 PPTX 檔。

此 Python 程式碼示範如何建立折線圖：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

預設情況下，折線圖的點會以直線相連。若希望以虛線相連，可如下指定虛線類型：

```python
line_chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in line_chart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```

結果：

![折線圖](line_chart.png)

### **建立樹狀圖**

樹狀圖最適合用於銷售資料，以顯示資料類別的相對大小，並快速將注意力聚焦於每個類別中貢獻較大的項目。

1. 建立 [Presentation] 類別的實例。  
2. 取得指定索引的投影片參考。  
3. 加入圖表並使用預設資料，指定 `ChartType.TREEMAP` 類型。  
4. 取用圖表的資料活頁簿（[ChartDataWorkbook]）。  
5. 清除預設的系列與類別。  
6. 新增系列與類別。  
7. 為圖表系列新增資料。  
8. 將修改後的簡報儲存為 PPTX 檔。

此 Python 程式碼示範如何建立樹狀圖：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # 分支 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # 分支 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![樹狀圖](treemap_chart.png)

### **建立股票圖表**

股票圖表用於顯示開盤、最高、最低與收盤價格等金融資料，協助分析市場趨勢與波動。它們提供關於股票表現的關鍵洞見，幫助投資者與分析師做出明智決策。

1. 建立 [Presentation] 類別的實例。  
2. 取得指定索引的投影片參考。  
3. 加入圖表並使用預設資料，指定 `ChartType.OPEN_HIGH_LOW_CLOSE` 類型。  
4. 取用圖表的資料活頁簿（[ChartDataWorkbook]）。  
5. 清除預設的系列與類別。  
6. 新增系列與類別。  
7. 為圖表系列新增資料。  
8. 指定 HiLowLines 格式。  
9. 將修改後的簡報儲存為 PPTX 檔。

此 Python 程式碼示範如何建立股票圖表：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("StockChart.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![股票圖表](stock_chart.png)

### **建立箱形圖**

箱形圖用於透過中位數、四分位數與潛在異常值等關鍵統計量顯示資料分布。它們在探索性資料分析與統計研究中相當有用，可快速了解資料變異性並辨識異常。

1. 建立 [Presentation] 類別的實例。  
2. 取得指定索引的投影片參考。  
3. 加入圖表並使用預設資料，指定 `ChartType.BOX_AND_WHISKER` 類型。  
4. 取用圖表的資料活頁簿（[ChartDataWorkbook]）。  
5. 清除預設的系列與類別。  
6. 新增系列與類別。  
7. 為圖表系列新增資料。  
8. 將修改後的簡報儲存為 PPTX 檔。

此 Python 程式碼示範如何建立箱形圖：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```

### **建立漏斗圖**

漏斗圖用於視覺化具有逐步階段的流程，資料量會隨步驟遞減。它們特別適合分析轉換率、找出瓶頸，並追蹤銷售或行銷流程的效率。

1. 建立 [Presentation] 類別的實例。  
2. 取得指定索引的投影片參考。  
3. 加入圖表並使用預設資料，指定 `ChartType.FUNNEL` 類型。  
4. 將修改後的簡報儲存為 PPTX 檔。

此 Python 程式碼示範如何建立漏斗圖：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![漏斗圖](funnel_chart.png)

### **建立旭日圖**

旭日圖用於視覺化階層資料，將層級以同心環方式呈現。它有助於說明部份與整體的關係，並適合以緊湊的方式表達巢狀類別與子類別。

1. 建立 [Presentation] 類別的實例。  
2. 取得指定索引的投影片參考。  
3. 加入圖表並使用預設資料，指定 `ChartType.SUNBURST` 類型。  
4. 將修改後的簡報儲存為 PPTX 檔。

此 Python 程式碼示範如何建立旭日圖：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # 分支 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # 分支 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![旭日圖](sunburst_chart.png)

### **建立直方圖**

直方圖用於將數值資料依區間（或箱）分組，以呈現其分布情形。它們特別適合辨識頻率、偏態與散布等模式，並偵測資料集中的異常值。

1. 建立 [Presentation] 類別的實例。  
2. 取得指定索引的投影片參考。  
3. 加入圖表並提供一些資料，指定 `ChartType.HISTOGRAM` 類型。  
4. 取用圖表的資料活頁簿（[ChartDataWorkbook]）。  
5. 清除預設的系列與類別。  
6. 新增系列與類別。  
7. 將修改後的簡報儲存為 PPTX 檔。

此 Python 程式碼示範如何建立直方圖：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![直方圖](histogram_chart.png)

### **建立雷達圖**

雷達圖用於以二維形式呈現多變量資料，方便同時比較多個變數。它們特別適合識別多項績效指標或屬性之間的模式、優勢與弱點。

1. 建立 [Presentation] 類別的實例。  
2. 取得指定索引的投影片參考。  
3. 加入圖表並提供一些資料，指定 `ChartType.RADAR` 類型。  
4. 將修改後的簡報儲存為 PPTX 檔。

此 Python 程式碼示範如何建立雷達圖：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarСhart.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![雷達圖](radar_chart.png)

### **建立多類別圖表**

多類別圖表用於顯示涉及多個類別群組的資料，讓您能同時比較多維度的數值。當需要在複雜的多層資料集中分析趨勢與關係時，這類圖表特別有幫助。

1. 建立 [Presentation] 類別的實例。  
2. 取得指定索引的投影片參考。  
3. 加入圖表並使用預設資料，指定 `ChartType.CLUSTERED_COLUMN` 類型。  
4. 取用圖表的資料活頁簿（[ChartDataWorkbook]）。  
5. 清除預設的系列與類別。  
6. 新增系列與類別。  
7. 為圖表系列新增資料。  
8. 將修改後的簡報儲存為 PPTX 檔。

此 Python 程式碼示範如何建立多類別圖表：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # 新增系列。
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # 儲存包含圖表的簡報。
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![多類別圖表](multi_category_chart.png)

### **建立地圖圖表**

地圖圖表用於將資訊映射至特定地理位置（如國家、州或城市），以視覺化地理資料。它們特別適合分析區域趨勢、人口統計與空間分布，並以清晰且具吸引力的方式呈現。

此 Python 程式碼示範如何建立地圖圖表：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![地圖圖表](map_chart.png)

### **建立組合圖表**

組合圖表（或稱 Combo 圖表）在單一圖形中結合兩種或以上的圖表類型。此圖表可讓您突顯、比較或檢視多個資料集之間的差異，協助辨識它們之間的關係。

![組合圖表](combination_chart.png)

以下 Python 程式碼示範如何在 PowerPoint 簡報中建立上述組合圖表：

```python
def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    # 設定圖表標題。
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    title_paragraph = chart.chart_title.text_frame_for_overriding.paragraphs[0]
    title_format = title_paragraph.paragraph_format.default_portion_format

    title_format.font_bold = slides.NullableBool.FALSE
    title_format.font_height = 18

    # 設定圖表圖例。
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    # 刪除預設產生的系列與類別。
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    worksheet_index = 0
    workbook = chart.chart_data.chart_data_workbook

    # 新增類別。
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 4, 0, "Category 4"))

    # 加入第一個系列。
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 4.3))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 2.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 3.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 4.5))

    return chart


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 2.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 4.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 1.8))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 2.8))


def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 1, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 2, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 3, 3, 3.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 4, 3, 5.0))

    series.plot_on_second_axis = True


def set_primary_axes_format(chart):
    # 設定水平軸。
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12.0
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    # 設定垂直軸。
    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12.0
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    # 設定垂直主要格線的顏色。
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # 設定次要水平軸。
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # 設定次要垂直軸。
    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12.0
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")


def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12.0
```

## **更新圖表**

Aspose.Slides for Python via .NET 允許您透過修改圖表資料、格式與樣式來更新 PowerPoint 圖表。此功能簡化了使用動態內容維持簡報最新的流程，並確保圖表正確反映當前資料與視覺標準。

1. 實例化表示包含圖表之簡報的 [Presentation] 類別。  
2. 取得指定索引的投影片參考。  
3. 遍歷所有圖形以找出圖表。  
4. 取用圖表的資料工作表。  
5. 變更系列值以修改圖表資料系列。  
6. 新增系列並填入資料。  
7. 將修改後的簡報儲存為 PPTX 檔。

此 Python 程式碼示範如何更新圖表：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# 建立代表 PPTX 檔案的 Presentation 類別實例。
with slides.Presentation("ExistingChart.pptx") as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # 設定圖表資料工作表的索引。
            worksheet_index = 0

            # 取得圖表資料活頁簿。
            workbook = chart.chart_data.chart_data_workbook

            # 變更圖表類別名稱。
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # 取得第一個圖表系列。
            series = chart.chart_data.series[0]

            # 更新系列資料。
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # 修改系列名稱。
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # 取得第二個圖表系列。
            series = chart.chart_data.series[1]

            # 更新系列資料。
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # 修改系列名稱。
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # 新增系列。
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # 填入系列資料。
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # 儲存包含圖表的簡報。
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **設定圖表資料範圍**

Aspose.Slides for Python via .NET 提供彈性，讓您可以將工作表中的特定資料範圍指定為圖表資料來源。這意味著您可以直接對工作表的某一區段進行映射，控制哪些儲存格會貢獻給圖表的系列與類別。藉此，您能輕鬆在工作表資料變更時同步更新圖表，確保 PowerPoint 簡報呈現最新且正確的資訊。

1. 實例化表示包含圖表之簡報的 [Presentation] 類別。  
2. 取得指定索引的投影片參考。  
3. 遍歷所有圖形以找出圖表。  
4. 取用圖表資料並設定範圍。  
5. 將修改後的簡報儲存為 PPTX 檔。

此 Python 程式碼示範如何為圖表設定資料範圍：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# 建立代表 PPTX 檔案的 Presentation 類別實例。
with slides.Presentation("ExistingChart.pptx") as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **在圖表中使用預設標記**

使用預設標記時，每個圖表系列會自動獲得不同的預設標記符號。

此 Python 程式碼示範如何自動為圖表系列設定標記：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # 填入系列資料。
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**Aspose.Slides for Python via .NET 支援哪些圖表類型？**

Aspose.Slides for Python via .NET 支援廣泛的圖表類型，包括長條圖、折線圖、圓餅圖、區域圖、散佈圖、直方圖、雷達圖等。此彈性讓您能依資料視覺化需求選擇最適合的圖表類型。

**如何在投影片中新增圖表？**

要新增圖表，首先建立 [Presentation] 類別的實例，依索引取得目標投影片，然後呼叫加入圖表的方法，指定圖表類型與初始資料。此流程即將圖表直接嵌入簡報。

**如何更新圖表顯示的資料？**

您可以透過存取圖表的資料活頁簿（[ChartDataWorkbook]），清除預設的系列與類別，然後加入自訂資料，以程式方式刷新圖表，使其反映最新資料。

**可以自訂圖表外觀嗎？**

可以，Aspose.Slides for Python via .NET 提供豐富的客製化選項。您可以修改顏色、字型、標籤、圖例及其他格式元素，以符合特定的設計需求。