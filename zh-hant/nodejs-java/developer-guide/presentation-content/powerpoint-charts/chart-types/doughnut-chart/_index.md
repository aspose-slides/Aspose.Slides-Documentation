---
title: 使用 JavaScript 自訂簡報中的甜甜圈圖表
linktitle: 甜甜圈圖表
type: docs
weight: 30
url: /zh-hant/nodejs-java/doughnut-chart/
keywords:
- 甜甜圈圖表
- 中心間隙
- 孔大小
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 JavaScript 以及 Aspose.Slides for Node.js 建立與自訂甜甜圈圖表，支援 PowerPoint 格式以製作動態簡報。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用甜甜圈圖表，透過將圖表加入投影片、設定中心孔大小，並儲存簡報。重點在於 `setDoughnutHoleSize` 方法，展示在程式碼中自訂此圖表類型的基本步驟。

同時也提供一段簡短的 FAQ，涵蓋相關的甜甜圈圖表情境，例如使用多個系列建立多環、處理分裂甜甜圈圖表，以及將圖表匯出為點陣圖或 SVG。

## **變更甜甜圈圖表的中心間隙**

為了指定甜甜圈圖表中心孔的大小，請依照以下步驟進行：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 物件。
1. 在投影片上新增甜甜圈圖表。
1. 指定甜甜圈圖表中心孔的大小。
1. 將投影片寫入磁碟。

在下方範例中，我們已設定甜甜圈圖表中心孔的大小。

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // 將簡報寫入磁碟
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以建立帶有多個環的多層甜甜圈嗎？**

是的。將多個系列加入單一甜甜圈圖表——每個系列會變成獨立的環。環的順序由系列在集合中的順序決定。

**是否支援「分裂」甜甜圈（切片分離）？**

是的。有 Exploded Doughnut [chart type](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/charttype/) 並且資料點具備爆炸屬性；您可以分離個別切片。

**如何取得甜甜圈圖表的圖像（PNG/SVG）以供報告使用？**

圖表是形狀；您可以將其轉換為 [raster image](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getImage) 或將圖表匯出為 [SVG image](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/writeassvg/)。