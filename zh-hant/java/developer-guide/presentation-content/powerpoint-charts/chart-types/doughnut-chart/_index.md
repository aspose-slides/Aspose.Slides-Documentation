---
title: 使用 Java 自訂簡報中的環形圖
linktitle: 環形圖
type: docs
weight: 30
url: /zh-hant/java/doughnut-chart/
keywords:
- 環形圖
- 中心間隙
- 洞大小
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中建立和自訂環形圖，支援 PowerPoint 格式以製作動態簡報。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用環形圖，包括將圖表加入投影片、設定中心洞的大小，並將簡報儲存。重點在 `setDoughnutHoleSize` 方法，示範在程式碼中自訂此圖表類型的基本步驟。

同時也提供一段簡短的 FAQ，涵蓋相關的環形圖情境，例如使用多個系列建立多個環、處理爆炸式環形圖，以及將圖表匯出為點陣圖或 SVG。

## **指定環形圖的中心間隙**
{{% alert color="info" %}} 

Aspose.Slides for Java 現已支援在環形圖中指定中心洞的大小。在本主題中，我們將以範例說明如何設定環形圖的中心洞大小。

{{% /alert %}} 

要在環形圖中指定中心洞的大小，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 物件。
1. 在投影片上新增環形圖表。
1. 指定環形圖的中心洞大小。
1. 將簡報寫入磁碟。

以下範例展示了如何設定環形圖的中心洞大小。

```java
import com.aspose.slides.*;

// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // 將簡報寫入磁碟
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

### 我可以建立具有多個環的多層環形圖嗎？

可以。將多個系列加入同一個環形圖——每個系列會成為獨立的環。環的順序由系列在集合中的順序決定。

### 是否支援「爆炸」式環形圖（切片分離）？

可以。圖表類型中有 Exploded Doughnut [chart type](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/charttype/)，且資料點具有爆炸屬性，您可以分離個別切片。

### 如何取得環形圖的影像（PNG/SVG）以供報表使用？

圖表本身是一個形狀；您可以將其渲染為 [點陣圖](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getImage-int-float-float-)，或將圖表匯出為 [SVG 影像](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)。