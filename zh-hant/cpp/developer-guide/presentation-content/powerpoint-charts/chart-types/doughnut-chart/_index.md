---
title: 使用 С++ 自訂簡報中的甜甜圈圖表
linktitle: 甜甜圈圖表
type: docs
weight: 30
url: /zh-hant/cpp/doughnut-chart/
keywords:
- 甜甜圈圖表
- 中心間隙
- 孔大小
- PowerPoint
- 簡報
- С++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for С++ 中建立與自訂甜甜圈圖表，支援 PowerPoint 格式以製作動態簡報。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中使用甜甜圈圖表，透過將圖表新增至投影片、設定中心孔的大小，並儲存簡報。重點在於 `set_DoughnutHoleSize` 方法，並示範在程式碼中自訂此圖表類型的基本步驟。

## **在甜甜圈圖表中指定中心間隙**
為了指定甜甜圈圖表中孔的大小，請遵循以下步驟：

- 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別。
- 在投影片上新增甜甜圈圖表。
- 指定甜甜圈圖表中孔的大小。
- 將簡報寫入磁碟。

以下範例中，我們已設定甜甜圈圖表中孔的大小。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **常見問題**

**我可以建立具有多層環的甜甜圈圖表嗎？**

可以。為單一甜甜圈圖表加入多個系列──每個系列會變成獨立的環。環的順序由系列在集合中的順序決定。

**是否支援「爆炸」甜甜圈（分離切片）？**

可以。Aspose.Slides 提供 Exploded Doughnut 圖表類型，並且資料點具有爆炸屬性；您可以分離個別切片。

**如何取得甜甜圈圖表的圖片（PNG/SVG）以用於報告？**

圖表是一種形狀；您可以將其渲染為 [raster image](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getimage/) 或將圖表匯出為 [SVG image](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/writeassvg/)。