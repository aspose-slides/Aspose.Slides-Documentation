---
title: 在 Python 中管理圖表資料系列
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
description: "學習如何在 Python 中管理 PowerPoint (PPT/PPTX) 的圖表資料系列，並透過實用的程式碼範例與最佳實踐，提升您的資料簡報效果。"
---
## **概觀**

本文說明了 [ChartSeries](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/) 在 Aspose.Slides for Python 中的角色，重點在於資料於簡報中的結構與視覺化方式。這些物件提供了定義圖表中各個資料點、類別與外觀參數的基礎元素。透過使用 [ChartSeries](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/)，開發者能夠無縫整合底層資料來源，並完整掌控資訊的呈現方式，從而產生動態、資料驅動的簡報，清楚傳達見解與分析。

Series 是在圖表中繪製的數字列或行。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定 Series 重疊**

[ChartSeries.overlap](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/overlap/) 屬性透過指定 -100 到 100 的範圍，控制 2D 圖表中長條與柱狀的重疊方式。此屬性屬於 series 群組，而非單一圖表 series，所以在 series 級別是唯讀的。若要設定重疊值，請使用 `parent_series_group.overlap` 可讀寫屬性，該屬性會將指定的重疊套用至該群組中的所有 series。

以下是示範如何建立簡報、加入群組柱狀圖、取得第一個圖表 series、設定重疊，最後儲存為 PPTX 檔的 Python 範例：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 新增一個預設資料的群組柱狀圖。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # 設定系列的重疊。
        series.parent_series_group.overlap = series_overlap

    # 將簡報檔案儲存至磁碟。
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![Series 重疊範例](series_overlap.png)

## **變更 Series 填色**

Aspose.Slides 讓自訂圖表 series 的填色變得相當簡單，您可以突顯特定資料點，並建立視覺上吸引人的圖表。這是透過 [Format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/format/) 物件實現的，該物件支援各種填充類型、顏色設定以及其他進階樣式選項。將圖表加入投影片並取得目標 series 後，只需取得 series 並套用適當的填色。除了純色填充，您也可以使用漸層或圖案填充，以獲得更高的設計彈性。完成顏色設定後，儲存簡報即可完成更新。

以下 Python 程式碼示範如何變更第一個 series 的顏色：

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 新增一個預設資料的群組柱狀圖。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # 設定第一個系列的顏色。
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # 將簡報檔案儲存至磁碟。
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![Series 顏色範例](series_color.png)

## **重新命名 Series**

Aspose.Slides 提供簡易方法來修改圖表 series 的名稱，讓資料標籤更清晰、有意義。開發者可透過存取圖表資料中的相關工作表儲存格，客製化資料的顯示方式。當需要根據資料情境更新或說明 series 名稱時，此功能特別實用。完成 series 重命名後，儲存簡報即可保留變更。

以下為展示此作業流程的 Python 程式碼片段：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 新增一個預設資料的群組柱狀圖。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # 設定第一個系列的名稱。
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # 將簡報檔案儲存至磁碟。
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

以下 Python 程式碼示範另一種變更 series 名稱的方式：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 新增一個預設資料的群組柱狀圖。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # 設定第一個系列的名稱。
    series.name.as_cells[0].value = series_name

    # 將簡報檔案儲存至磁碟。
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```

結果：

![Series 名稱範例](series_name.png)

## **取得自動 Series 填色**

Aspose.Slides for Python 允許您取得圖表區域內 series 的自動填色。建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例後，您可以依索引取得目標投影片，接著使用您偏好的圖表類型（例如 `ChartType.CLUSTERED_COLUMN`）加入圖表。透過取得圖表中的 series，即可取得其自動填色。

以下 Python 程式碼詳細說明此流程。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 新增一個預設資料的群組柱狀圖。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # 取得系列的填色。
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```

範例輸出：

```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **為 Series 設定反轉填色**

當您的資料 series 同時包含正值與負值時，若所有柱狀或長條皆使用相同顏色，圖表將難以閱讀。Aspose.Slides for Python 讓您指定「反轉填色」——對於低於零的資料點自動套用的另一種填色，使負值一目了然。本節將教您如何啟用此選項、選擇適當的顏色，並儲存更新後的簡報。

以下程式碼示範此操作：

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 新增類別。
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # 新增系列。
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # 填入系列資料。
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # 設定系列的顏色。
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![反轉實心填色範例](inverted_solid_fill_color.png)

您也可以為單一資料點而非整個 series 反轉填色。只需存取目標 `ChartDataPoint`，並將其 `invert_if_negative` 屬性設為 `True`。

以下程式碼示範如何執行：

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **清除特定資料點的資料**

有時圖表中會出現測試值、異常值或已過時的條目，您需要在不重新建立整個 series 的情況下將其移除。Aspose.Slides for Python 允許您依索引定位任意資料點，清除其內容，並立即刷新圖表，使剩餘點位移動且座標軸自動重新縮放。

以下程式碼範例說明此操作：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```

## **設定 Series 間隙寬度**

間隙寬度控制相鄰柱狀或長條之間的空白量——較寬的間隙突顯個別類別，較窄的間隙則產生更緊湊的外觀。透過 Aspose.Slides for Python，您可以為整個 series 微調此參數，精確取得簡報所需的視覺平衡，而無需改變底層資料。

以下程式碼示範如何為 series 設定間隙寬度：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# 建立空的簡報。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增預設資料的圖表。
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # 將簡報儲存至磁碟。
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # 設定 gap_width 值。
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # 將簡報儲存至磁碟。
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![間隙寬度範例](gap_width.png)

## **常見問與答**

**單一圖表能包含多少個 series 有上限嗎？**

Aspose.Slides 對您加入的 series 數量沒有固定上限。實際上限取決於圖表的可讀性以及應用程式可用的記憶體。

**如果叢集內的柱狀過於靠近或過於分散該怎麼辦？**

調整該 series（或其父 series 群組）的 [gap_width](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/gap_width/) 設定。將數值提高會擴大柱間距離，降低則使柱子更靠近。