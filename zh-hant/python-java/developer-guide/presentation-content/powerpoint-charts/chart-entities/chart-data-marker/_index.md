---
title: 使用 Python 在簡報中管理圖表資料標記
linktitle: 資料標記
type: docs
url: /zh-hant/python-java/chart-data-marker/
keywords:
- 圖表
- 資料點
- 標記
- 標記選項
- 標記大小
- 填充類型
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via Java 中自訂圖表資料標記，透過清晰的 Python 程式碼範例提升 PPT 與 PPTX 格式簡報的效果。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中使用圖表資料標記。它示範如何建立圖表、存取系列及其資料點、在資料點層級為標記套用圖片填充、調整標記大小，並儲存更新後的簡報。文章也指出，標準標記形狀可透過 [MarkerStyleType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markerstyletype/) 列舉取得，且在將圖表匯出為光柵格式或 SVG 時，標記外觀會被保留。

## **設定圖表標記選項**
標記可以設定在特定系列的圖表資料點上。要設定圖表標記選項，請依照下列步驟：

- 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別。
- 建立預設圖表。
- 設定圖片。
- 存取第一個圖表系列。
- 新增資料點。
- 將簡報寫入磁碟。

以下範例在資料點層級設定圖表標記選項。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# 建立一個空白簡報。
presentation = Presentation()
try:
    # 存取第一張投影片
    slide = presentation.getSlides().get_Item(0)

    # 建立預設圖表
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # 取得預設圖表資料工作表索引。
    default_worksheet_index = 0

    # 取得圖表資料工作簿。
    workbook = chart.getChartData().getChartDataWorkbook()

    # 刪除示範系列
    chart.getChartData().getSeries().clear()

    # 新增系列
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # 載入第一張圖片。
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # 載入第二張圖片。
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # 取得第一個圖表系列。
    series = chart.getChartData().getSeries().get_Item(0)

    # 新增資料點。
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # 變更圖表系列標記大小。
    series.getMarker().setSize(15)

    # 將圖表儲存至簡報
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**預設提供哪些標記形狀？**

提供標準形狀（圓形、方形、菱形、三角形等）；此清單由 [MarkerStyleType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markerstyletype/) 類別定義。如果需要非標準形狀，請使用帶有圖片填充的標記來模擬自訂視覺效果。

**將圖表匯出為影像或 SVG 時，標記會被保留嗎？**

會。將圖表渲染為 [raster formats](/slides/zh-hant/python-java/convert-powerpoint-to-png/) 或將形狀儲存為 [shapes as SVG](/slides/zh-hant/python-java/render-a-slide-as-an-svg-image/) 時，標記會保留其外觀和設定，包括大小、填充和輪廓。