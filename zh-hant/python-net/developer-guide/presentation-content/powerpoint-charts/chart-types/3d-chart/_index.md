---
title: 使用 Python 自訂簡報中的 3D 圖表
linktitle: 3D 圖表
type: docs
url: /zh-hant/python-net/3d-chart/
keywords:
- 3D 圖表
- 旋轉
- 深度
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中建立並自訂 3D 圖表，支援 PPT、PPTX 與 ODP 檔案——立即提升您的簡報效果。"
---
## **概觀**

本文說明如何透過設定 `rotation_3d`（例如 `rotation_x`、`rotation_y`、`depth_percents` 與 `right_angle_axes`）來自訂 Aspose.Slides 中的 3D 圖表。內容涵蓋建立簡報、加入含預設資料的 3D 圖表、套用所需的 3D 檢視設定，最後將修改後的簡報存為 PPTX 檔案的步驟。

## **設定 3D 圖表的 RotationX、RotationY 與 DepthPercents 屬性**
Aspose.Slides for Python via .NET 提供簡易的 API 來設定這些屬性。以下說明將協助您設定 X、Y 旋轉、**DepthPercents** 等不同屬性。示範程式碼展示了上述屬性的設定方式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 存取第一張投影片。
3. 加入包含預設資料的圖表。
4. 設定 Rotation3D 屬性。
5. 將已修改的簡報寫入 PPTX 檔案。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立 Presentation 類別的實例
with slides.Presentation() as presentation:
            
    # 存取第一張投影片
    slide = presentation.slides[0]

    # 加入含預設資料的圖表
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # 設定圖表資料工作表的索引
    defaultWorksheetIndex = 0

    # 取得圖表資料工作表
    fact = chart.chart_data.chart_data_workbook

    # 加入系列
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # 加入類別
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # 設定 Rotation3D 屬性
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # 取得第二個圖表系列
    series = chart.chart_data.series[1]

    # 現在填入系列資料
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # 設定 OverLap 值
    series.parent_series_group.overlap = 100         

    # 將簡報寫入磁碟
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**哪些圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援柱狀圖的 3D 變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 以及 100% Stacked Column 3D，並透過 [ChartType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/charttype/) 列舉提供相關的 3D 類型。欲取得最精確、最新的清單，請檢查您所安裝版本的 API 參考中 [ChartType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖供報告或網站使用嗎？**

可以。您可以透過 [chart API](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/get_image/) 將圖表匯出為影像，或將整張投影片[轉譯](/slides/zh-hant/python-net/convert-powerpoint-to-png/)為 PNG、JPEG 等格式。當您需要像素精確的預覽，或想在文件、儀表板或網頁中嵌入圖表而不需要 PowerPoint 時，這非常有用。

**建立與呈現大型 3D 圖表的效能如何？**

效能取決於資料量與視覺複雜度。為取得最佳效果，請儘量減少 3D 效果，避免在牆面與繪圖區使用大量紋理，盡可能限制每個系列的資料點數量，並將輸出渲染為符合目標顯示或列印需求的適當尺寸（解析度與尺寸）。