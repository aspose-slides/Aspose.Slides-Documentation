---
title: 使用 C++ 在簡報中自訂圓環圖
linktitle: 圓環圖
type: docs
weight: 30
url: /zh-hant/cpp/doughnut-chart/
keywords:
- 圓環圖
- 中心間隙
- 孔大小
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "探索如何在 Aspose.Slides for C++ 中建立並自訂圓環圖，支援 PowerPoint 格式以製作動態簡報。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中使用圓環圖，包括將圖表新增至投影片、設定其中心孔的大小，以及儲存簡報。重點在於 `set_DoughnutHoleSize` 方法，並示範在程式碼中自訂此圖表類型的基本步驟。

## **在圓環圖中指定中心間隙**
為了指定圓環圖中孔的大小，請依照以下步驟操作：

- 實例化 Presentation 類別。
- 在投影片上新增圓環圖。
- 指定圓環圖中孔的大小。
- 將簡報寫入磁碟。

在下方的範例中，我們已設定圓環圖中孔的大小。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **常見問題**

**我可以建立具有多個環的多層圓環圖嗎？**

是的。向單一圓環圖加入多個系列—每個系列會變成獨立的環。環的順序由系列在集合中的順序決定。

**是否支援「分裂」的圓環（切片分離）？**

是的。提供 Exploded Doughnut 圖表類型，以及資料點的爆炸屬性；您可以將個別切片分離。

**如何取得圓環圖的影像（PNG/SVG）以用於報告？**

圖表是一個形狀；您可以將其渲染為[點陣圖](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getimage/)或將圖表匯出為[SVG 影像](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/writeassvg/)。