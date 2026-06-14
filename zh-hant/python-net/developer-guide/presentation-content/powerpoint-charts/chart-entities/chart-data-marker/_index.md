---
title: 使用 Python 在簡報中管理圖表資料標記
linktitle: 資料標記
type: docs
url: /zh-hant/python-net/chart-data-marker/
keywords:
- 圖表
- 資料點
- 標記
- 標記選項
- 標記大小
- 填充類型
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "學習如何在 Aspose.Slides 中自訂圖表資料標記，透過清晰的程式碼範例提升 PPT、PPTX 與 ODP 格式簡報的效果。"
---
## **概觀**

本文章說明如何在 Aspose.Slides 中使用圖表資料標記。它展示了如何建立圖表、存取系列及其資料點、在資料點層級為標記套用圖片填充、調整標記大小，以及儲存更新後的簡報。文章同時指出，可透過 `MarkerStyleType` 列舉取得標準標記形狀，且在將圖表匯出為點陣格式或 SVG 時，標記外觀會被保留。

## **設定圖表標記選項**
標記可以設定在特定系列的圖表資料點上。若要設定圖表標記選項，請依照以下步驟操作：

- 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別。
- 建立預設圖表。
- 設定圖片。
- 取得第一個圖表系列。
- 新增資料點。
- 將簡報寫入磁碟。

在下方範例中，我們已在資料點層級設定圖表標記選項。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立 Presentation 類別的實例
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # 建立預設圖表
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # 取得預設圖表資料工作表索引
    defaultWorksheetIndex = 0

    # 取得圖表資料工作表
    fact = chart.chart_data.chart_data_workbook

    # 刪除示範系列
    chart.chart_data.series.clear()

    # 新增系列
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # 設定圖片
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # 設定圖片
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # 取得第一個圖表系列
    series = chart.chart_data.series[0]

    # 在此新增資料點 (1:3)。 
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # 變更圖表系列的標記
    series.marker.size = 15

    # 將簡報寫入磁碟
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**預設提供哪些標記形狀？**

提供標準形狀（圓形、方形、菱形、三角形等）；此清單由 [MarkerStyleType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/markerstyletype/) 列舉定義。若需非標準形狀，請使用帶圖片填充的標記以模擬自訂視覺效果。

**將圖表匯出為影像或 SVG 時，標記會被保留嗎？**

會。當將圖表渲染為 [raster formats](/slides/zh-hant/python-net/convert-powerpoint-to-png/) 或儲存 [shapes as SVG](/slides/zh-hant/python-net/render-a-slide-as-an-svg-image/) 時，標記會保留其外觀和設定，包括大小、填充與輪廓。