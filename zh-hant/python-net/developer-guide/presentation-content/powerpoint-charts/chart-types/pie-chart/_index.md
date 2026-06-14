---
title: 使用 Python 自訂簡報中的圓餅圖
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
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python 中建立與自訂圓餅圖，並可匯出至 PowerPoint 與 OpenDocument，讓您在數秒內提升資料敘事效果。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圓餅圖。它展示了如何為「Pie of Pie」和「Bar of Pie」圖表配置次要繪圖選項，以及如何為標準圓餅圖啟用自動切片著色。

範例聚焦於實務的圖表自訂步驟，例如將圖表加入投影片、調整系列與標籤設定、以自訂類別與數值取代預設圖表資料，並儲存更新後的簡報。

## **第二繪圖選項：Pie of Pie 與 Bar of Pie 圖表**
Aspose.Slides for Python via .NET 現在支援 Pie of Pie 或 Bar of Pie 圖表的次要繪圖選項。本主題將透過範例說明如何使用 Aspose.Slides 指定這些選項。請依照以下步驟操作：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別物件。
2. 在投影片上新增圖表。
3. 指定圖表的第二繪圖選項。
4. 將簡報寫入磁碟。

以下範例展示了我們如何設定 Pie of Pie 圖表的不同屬性。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 建立 Presentation 類別的實例
with slides.Presentation() as presentation:
    # 在投影片上新增圖表
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # 設定不同的屬性
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # 將簡報寫入磁碟
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **設定自動圓餅圖切片顏色**
Aspose.Slides for Python via .NET 提供簡單的 API 來設定自動圓餅圖切片顏色。範例程式碼套用了上述屬性設定。

1. 建立 Presentation 類別的實例。
2. 存取第一張投影片。
3. 使用預設資料新增圖表。
4. 設定圖表標題。
5. 將第一系列設定為顯示值。
6. 設定圖表資料工作表的索引。
7. 取得圖表資料工作表。
8. 刪除預設產生的系列與類別。
9. 新增類別。
10. 新增系列。

將修改後的簡報寫入 PPTX 檔案。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 實例化代表 PPTX 檔案的 Presentation 類別
with slides.Presentation() as presentation:
	# 存取第一張投影片
	slide = presentation.slides[0]

	# 新增帶預設資料的圖表
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# 設定圖表標題
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# 將第一系列設定為顯示值
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# 設定圖表資料工作表的索引
	defaultWorksheetIndex = 0

	# 取得圖表資料工作表
	fact = chart.chart_data.chart_data_workbook

	# 刪除預設產生的系列與類別
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# 新增類別
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# 新增系列
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# 目前填入系列資料
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**是否支援「Pie of Pie」和「Bar of Pie」變體？**

是的，該函式庫[支援](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/charttype/) 圓餅圖的次要繪圖，包括「Pie of Pie」和「Bar of Pie」類型。

**我可以僅將圖表匯出為影像（例如 PNG）嗎？**

是的，您可以[將圖表本身匯出為影像](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/get_image/)（例如 PNG），而不必匯出整個簡報。