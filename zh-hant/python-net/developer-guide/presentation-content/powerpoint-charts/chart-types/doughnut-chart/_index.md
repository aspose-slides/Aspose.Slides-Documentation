---
title: 使用 Python 在簡報中自訂甜甜圈圖表
linktitle: 甜甜圈圖表
type: docs
weight: 30
url: /zh-hant/python-net/doughnut-chart/
keywords:
- 甜甜圈圖表
- 中心間隙
- 洞大小
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中建立與自訂甜甜圈圖表，支援 PowerPoint 與 OpenDocument 格式的動態簡報。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用甜甜圈圖表，將圖表加入投影片、設定中心洞的大小，並儲存簡報。其重點在於 `doughnut_hole_size` 設定，並展示在程式碼中自訂此圖表類型的基本步驟。

本文亦包含簡短的 FAQ，涵蓋相關的甜甜圈圖表情境，例如使用多個系列建立多層環、使用炸裂甜甜圈圖表，以及將圖表匯出為點陣圖或 SVG。

## **指定甜甜圈圖表的中心間隙**
為了指定甜甜圈圖表中洞的大小，請依照以下步驟進行：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
- 在投影片上新增甜甜圈圖表。
- 指定甜甜圈圖表中洞的大小。
- 將簡報寫入磁碟。

以下範例中，我們已設定甜甜圈圖表的洞大小。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 建立 Presentation 類別的實例
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # 將簡報寫入磁碟
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我可以建立具有多個環的多層甜甜圈嗎？**

可以。將多個系列新增至同一個甜甜圈圖表——每個系列會形成一個獨立的環。環的順序依系列在集合中的順序決定。

**是否支援「炸裂」甜甜圈（切片分離）？**

可以。Aspose.Slides 提供 Exploded Doughnut [chart type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/charttype/) 以及資料點的爆炸屬性，您可以分離個別切片。

**如何取得甜甜圈圖表的影像（PNG/SVG）以供報告使用？**

圖表是一種形狀；您可以將其轉換為 [raster image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_image/) 或將圖表匯出為 [SVG image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/write_as_svg/)。