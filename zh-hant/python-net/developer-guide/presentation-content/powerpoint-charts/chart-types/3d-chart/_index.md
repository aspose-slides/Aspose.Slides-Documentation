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
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 簡報中建立 3D 圖表。透過 Python 範例調整旋轉、 高度比例、 圖表深度 與 系列之間的間距。"
---
## **概觀**

Aspose.Slides for Python via .NET 允許您透過 [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) 屬性自訂 3D 圖表的檢視。本文示範如何調整旋轉、 高度比例、 深度、 直角軸以及系列之間的間距，然後將簡報儲存為 PPTX 格式。

## **設定 3D 圖表的旋轉與深度**

以下範例建立一個 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 並使用 [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) 在第一張投影片中加入堆疊式 3D 柱狀圖。它將預設的系列與類別取代為兩個各含三個值的系列。工作表索引 `0` 表示圖表的第一個資料工作表；列 `0` 儲存系列名稱，欄 `0` 儲存類別標籤。

[rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) 與 [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) 屬性分別將圖表的旋轉設定為 40 度與 270 度。[depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) 將深度設定為寬度的 150%，而 [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) 則啟用直角軸以取代透視。最終的簡報包含套用了這些 3D 觀視設定的圖表。

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

## **套用圖片填滿至 3D 圖表表面**

您可以分別填滿 3D 圖表的 [側牆](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/)、[背牆](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/)、[底面](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/)。將表面的 [填充類型](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 設為 `PICTURE` 並指定影像。若要使影像僅出現在表面一次，需將 [圖片填充模式](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) 與表面的 [圖片類型](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) 均設為 `STRETCH`。

將 [arrow.png](arrow.png) 儲存於工作目錄。範例會旋轉圖表並提高垂直軸的最大值，以使底面在柱狀之間可見。它會將投影片複製兩次，然後在每張投影片的不同表面套用箭頭。三個圖表共用相同的資料、檢視角度與背景。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint 會如下顯示這三張投影片。

| 側牆 | 背牆 | 底面 |
| --- | --- | --- |
| ![沿側牆指向圖表的箭頭](side-wall.png) | ![橫跨背牆向右指的箭頭](back-wall.png) | ![在柱狀之間橫跨底面向右指的箭頭](floor.png) |

## **調整 3D 圖表的高度比例**

使用 [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) 可將 3D 圖表的高度設定為其寬度的百分比。此設定會在不調整投影片上圖表物件大小的情況下，變更 3D 場景的比例。

下列範例建立一個 [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 圖表，使用預設資料：三個系列與四個類別。它會儲存三個簡報，分別以 50%、100% 與 200% 的高度比例。圖表的位置、寬度與高度保持不變。資料、旋轉、深度、系列間距與格式在所有三個檔案中皆相同；僅高度百分比不同。

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

以下影像是使用 Microsoft PowerPoint 從產生的簡報匯出。較小的百分比會產生較平的場景，而較大的百分比會在相同圖表物件內產生較高的場景。PowerPoint 也可能調整軸刻度間隔與標籤位置以適應場景。

| 高度: 50% | 高度: 100% | 高度: 200% |
| --- | --- | --- |
| ![3D 柱狀圖，高度設定為寬度的 50％](height_percent_50.png) | ![3D 柱狀圖，高度設定為寬度的 100％](height_percent_100.png) | ![3D 柱狀圖，高度設定為寬度的 200％](height_percent_200.png) |

這些屬性控制圖表的不同面向：

| 屬性 | 效果 |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | 3D 場景的高度，以寬度的百分比表示。 |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | 投影片上圖表物件的高度，單位為點 (points)。 |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | 3D 場景的深度，以寬度的百分比表示。 |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | 系列在深度軸上的間距，以標記寬度的百分比表示。 |

高度設定會影響 3D 柱狀圖與條形圖，包括圓柱、圓錐與金字塔等變體，以及 3D 折線圖、面積圖、圓餅圖與曲面圖。上述比較使用已驗證的 `COLUMN_3D` 類型。此設定不會更改 2D `CLUSTERED_COLUMN` 圖表或 `BUBBLE_WITH_3D` 圖表的外觀；這些名稱是 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列舉的成員。其他圖表外觀設定，請參閱 [Chart Formatting](/slides/zh-hant/python-net/chart-formatting/)。

## **調整系列之間的間隙**

使用 [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) 來控制 3D 圖表中資料系列在深度軸上的距離，以標記寬度的百分比表示。可使用 **0 到 500**（含）之間的值：`0` 會移除間隙，較大的值會增加間距。當圖表深度固定時，增加間隙會使標記在深度軸上變得更薄。

透過 [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) 取得該群組。此設定會套用至群組中的所有系列，而不僅是用來存取的那個系列。[ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) 為唯讀屬性，會反映父群組的設定。

此設定會影響 3D 柱狀圖與條形圖，包括其圓柱、圓錐與金字塔變體，以及 3D 折線圖與面積圖。外觀取決於系列是在深度、分群或堆疊的排列方式。若要清楚比較不同系列之間的間隙，請使用來自 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列舉的 `ChartType.COLUMN_3D`。

這些屬性控制圖表的不同面向：

| 屬性 | 效果 |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | 系列在深度軸上的間距，以標記寬度的百分比表示。 |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | 相鄰柱狀或條形叢集之間的間距，以柱狀或條形寬度的百分比表示。 |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | 圖表的整體深度，以圖表寬度的百分比表示。 |

以下獨立範例使用預設圖表資料，包含三個系列與四個類別。它會儲存兩個簡報，資料、旋轉、間距寬度與圖表深度皆相同；僅間隙深度不同。

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

以下影像是使用 Microsoft PowerPoint 從產生的簡報匯出。

| 間隙深度: 0% | 間隙深度: 500% |
| --- | --- |
| ![3D 柱狀圖，深度軸上系列之間無間隙](gap_depth_0.png) | ![3D 柱狀圖，深度軸上系列之間有 500％ 的間隙](gap_depth_500.png) |

## **變更 3D 系列類型與條形外觀**

在分群圓柱圖中，第一個系列以圓柱形條狀開始。範例於每次變更前後讀取 [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) 與 [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/)。

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

| 變更第一個系列 | `type` | `bar_3d_shape` |
| --- | --- | --- |
| 建立圖表 | `CLUSTERED_CYLINDER` | `CYLINDER` |
| 將 `type` 設為 `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| 將 `bar_3d_shape` 設為 `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

將形狀設定為 `BOX` 也會將系列類型變更為 `CLUSTERED_COLUMN_3D`。如果程式碼根據系列類型分支，請在變更形狀後讀取 `series.type`。在賦值前快取的值仍會選擇 `CLUSTERED_CONE` 分支。

![PowerPoint 比較，顯示第一個系列從左到右分別為圓柱、圓錐與矩形柱狀](series-shapes.png)

## **FAQ**

**哪些圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援欄位圖的 3D 變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，以及透過 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列舉所揭露的相關 3D 類型。欲取得精確且最新的清單，請在已安裝版本的 API 參考中檢查 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖用於報告或網路嗎？**

可以。您可以使用 [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) 將圖表匯出為影像，或將整張投影片 [將整張投影片轉為圖片](/slides/zh-hant/python-net/convert-powerpoint-to-png/) 轉換為 PNG、JPEG 等格式。當您需要點陣圖預覽或想在文件、儀表板、網頁中嵌入圖表而不需 PowerPoint 時，這非常有用。

**建立與渲染大型 3D 圖表的效能如何？**

效能取決於資料量與視覺複雜度。為獲得最佳結果，請儘量減少 3D 效果，避免在牆面與圖區使用大量紋理，盡可能限制每個系列的資料點數量，並將輸出渲染為適當大小（解析度與尺寸），以符合目標顯示或列印需求。