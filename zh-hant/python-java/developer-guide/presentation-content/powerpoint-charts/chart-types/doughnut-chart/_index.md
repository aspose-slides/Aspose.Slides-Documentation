---
title: 使用 Python via Java 自訂簡報中的甜甜圈圖表
linktitle: 甜甜圈圖表
type: docs
weight: 30
url: /zh-hant/python-java/doughnut-chart/
keywords:
- 甜甜圈圖表
- 中心間隙
- 孔大小
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "探索如何在 Aspose.Slides for Python via Java 中建立與自訂甜甜圈圖表，支援 PowerPoint 格式，以製作動態簡報。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用甜甜圈圖，方法包括將圖表加入投影片、設定其中心孔的大小，並儲存簡報。重點在於 [setDoughnutHoleSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) 方法，並展示自訂此圖表類型所需的基本步驟。

此外，本文還包含一個簡短的 FAQ，涵蓋相關的甜甜圈圖情境，例如使用多個系列建立多層環、處理炸裂甜甜圈圖，以及將圖表匯出為點陣圖或 SVG。

## **指定甜甜圈圖的中心間隙**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java 支援指定甜甜圈圖中孔的大小。本節示範如何使用範例設定孔的大小。
{{% /alert %}}

若要指定甜甜圈圖中孔的大小，請遵循以下步驟：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件。
1. 在投影片中新增甜甜圈圖表。
1. 指定甜甜圈圖表的孔大小。
1. 將簡報寫入磁碟。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# 建立 Presentation 類別的實例。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # 將簡報寫入磁碟。
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**我可以建立具有多層環的多層甜甜圈嗎？**

可以。將多個系列加入單一甜甜圈圖表——每個系列會形成一個獨立的環。環的順序取決於系列在集合中的順序。

**是否支援「炸裂」甜甜圈（切片分離）？**

可以。Aspose.Slides 提供 Exploded Doughnut [chart type](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/charttype/) 以及資料點的爆炸屬性；您可以將個別切片分離。

**如何取得甜甜圈圖表的影像（PNG/SVG）以用於報告？**

圖表是一個 [shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/)；您可以將其算繪為 [raster image](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getImage) 或將圖表匯出為 SVG 影像。