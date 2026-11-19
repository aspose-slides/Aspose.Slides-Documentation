---
title: 使用 Python 在簡報中自訂 3D 圖表
linktitle: 3D 圖表
type: docs
url: /zh-hant/python-net/3d-chart/
keywords:
- 3D 圖表
- 旋轉
- 深度
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 簡報中建立 3D 圖表。使用 Python 範例調整旋轉、高度比例、圖表深度與系列之間的間距。"
---
## **概觀**

Aspose.Slides for Python via .NET 讓您可以透過 [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) 屬性自訂 3D 圖表的檢視方式。本文章示範如何調整旋轉、高度比例、深度、直角坐標軸，以及系列之間的間距，然後將簡報儲存為 PPTX 格式。

## **設定 3D 圖表的旋轉與深度**

以下範例建立一個 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)，並使用 [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) 在第一張投影片中新增一個堆疊 3D 柱狀圖。它以兩個各含三個值的系列取代預設的系列與類別。工作表索引 `0` 表示圖表的第一個資料工作表；第 `0` 列保存系列名稱，第 `0` 欄保存類別標籤。

[rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) 與 [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) 屬性分別將圖表的旋轉設定為 40 度與 270 度。[depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) 將其深度設定為寬度的 150%，而 [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) 則啟用直角坐標軸而非透視。最終的簡報包含套用了這些 3D 檢視設定的圖表。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **調整 3D 圖表的高度比例**

使用 [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) 可將 3D 圖表的高度設定為其寬度的百分比。這會在不調整投影片上圖表物件大小的情況下變更 3D 場景的比例。

下列範例建立一個 [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 圖表，使用預設資料：三個系列與四個類別。它會儲存三個簡報，分別以 50%、100% 與 200% 的高度比例。圖表的位置、寬度與高度保持不變。資料、旋轉、深度、系列間距與格式在三個檔案中皆相同；唯一變動的是高度百分比。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

以下影像是使用 Microsoft PowerPoint 從產生的簡報中匯出。較小的百分比會產生較平坦的場景，而較大的百分比會在相同圖表物件內產生較高的場景。PowerPoint 也可能會調整坐標軸刻度間隔與標籤位置以適應場景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![3D 柱狀圖，將高度設定為寬度的 50%](height_percent_50.png) | ![3D 柱狀圖，將高度設定為寬度的 100%](height_percent_100.png) | ![3D 柱狀圖，將高度設定為寬度的 200%](height_percent_200.png) |

以下屬性控制圖表的不同面向：

| 屬性 | 影響 |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | 3D 場景的高度，為其寬度的百分比。 |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | 投影片上圖表物件的高度（點數）。 |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | 3D 場景的深度，為其寬度的百分比。 |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | 沿深度軸的系列間距，以標記寬度的百分比表示。 |

高度設定會影響 3D 柱狀圖與條形圖，包括圓柱、圓錐與金字塔變體，以及 3D 折線、面積、圓餅與曲面圖。上表的比較使用驗證過的 `COLUMN_3D` 類型。此設定不會改變 2D `CLUSTERED_COLUMN` 圖表或 `BUBBLE_WITH_3D` 圖表的外觀；這些名稱皆為 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列舉成員。其他圖表外觀設定，請參閱 [Chart Formatting](/slides/zh-hant/python-net/chart-formatting/)。

## **調整系列之間的間隙**

使用 [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) 以百分比（相對於標記寬度）控制 3D 圖表中資料系列沿深度軸的距離。可使用 **0 到 500**（含）之間的值：`0` 會移除間隙，較大的值會增加間距。在固定的圖表深度下，增大間隙會使標記在深度軸上變得較細。

透過 [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) 取得群組。此設定會套用到該群組內的所有系列，而不僅僅是用來存取的那個系列。[ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) 為唯讀屬性，顯示父群組的設定。

此設定會影響 3D 柱狀圖與條形圖，包括其圓柱、圓錐與金字塔變體，以及 3D 折線與面積圖。外觀取決於系列是以深度排列、叢集還是堆疊。若要清楚比較不同系列之間的間隙，請使用來自 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列舉的 `ChartType.COLUMN_3D`。

以下屬性控制圖表的不同面向：

| 屬性 | 影響 |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | 沿深度軸的系列間距，以標記寬度的百分比表示。 |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | 相鄰柱或欄叢集之間的間距，以柱或欄寬度的百分比表示。 |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | 圖表整體深度，為圖表寬度的百分比。 |

以下自足範例使用預設圖表資料，包含三個系列與四個類別。它會儲存兩個簡報，資料、旋轉、間距寬度與圖表深度皆相同，僅間距深度不同。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

以下影像是使用 Microsoft PowerPoint 從產生的簡報中匯出。

| 間隙深度：0% | 間隙深度：500% |
| --- | --- |
| ![3D 柱狀圖，系列在深度軸上之間無間隙](gap_depth_0.png) | ![3D 柱狀圖，系列在深度軸上之間有 500% 的間隙](gap_depth_500.png) |

## **變更 3D 系列類型與條形形狀**

在叢集圓柱圖中，第一個系列以圓柱條形開始。範例在每次變更前後讀取 [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) 與 [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/)。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| 變更第一系列 | `type` | `bar_3d_shape` |
| --- | --- | --- |
| 建立圖表 | `CLUSTERED_CYLINDER` | `CYLINDER` |
| 設定 `type` 為 `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| 設定 `bar_3d_shape` 為 `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

將形狀設為 `BOX` 也會同時將系列類型變更為 `CLUSTERED_COLUMN_3D`。如果您的程式碼根據系列類型分支，在變更形狀後請重新讀取 `series.type`。在指派之前快取的值仍會走向 `CLUSTERED_CONE` 分支。

![PowerPoint 比較圖，顯示第一系列從左至右分別為圓柱、圓錐與矩形柱](series-shapes.png)

## **常見問題**

**哪種圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援柱狀圖的 3D 變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，並且透過 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列舉提供其他相關 3D 類型。欲取得完整且最新的列表，請檢視您所安裝版本的 API 參考中的 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖以用於報告或網站嗎？**

可以。您可以使用 [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) 將圖表匯出為圖像，或將整張投影片 [render the entire slide](/slides/zh-hant/python-net/convert-powerpoint-to-png/) 為 PNG、JPEG 等格式。這在需要點陣預覽或想將圖表嵌入文件、儀表板或網頁，而不需要 PowerPoint 時非常有用。

**大量 3D 圖表的建構與繪製效能如何？**

效能取決於資料量與視覺複雜度。為取得最佳效能，建議盡量減少 3D 效果、避免在牆面與繪圖區使用大量紋理、在可能的情況下限制每個系列的資料點數量，並將輸出解析度與尺寸設定為符合目標顯示或列印需求的大小。