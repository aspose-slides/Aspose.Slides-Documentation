---
title: 在 Android 上自訂簡報中的環形圖
linktitle: 環形圖
type: docs
weight: 30
url: /zh-hant/androidjava/doughnut-chart/
keywords:
- 環形圖
- 中心間隙
- 孔大小
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Android via Java 中建立與自訂環形圖，支援 PowerPoint 格式以製作動態簡報。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用環形圖，方法包括將圖表加入投影片、設定中心孔的大小，並儲存簡報。重點在於 `setDoughnutHoleSize` 方法，並示範在程式碼中自訂此圖表類型的基本步驟。

同時也包含一段簡短的 FAQ，說明相關的環形圖情境，例如使用多個系列建立多層環、處理炸裂環形圖，以及將圖表匯出為點陣圖或 SVG。

## **指定環形圖的中心間隙**
{{% alert color="info" %}} 

Aspose.Slides for Android via Java 現已支援指定環形圖孔的大小。在本節中，我們將透過範例說明如何設定環形圖孔的大小。

{{% /alert %}} 

為了指定環形圖孔的大小，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 物件。
1. 在投影片上新增環形圖。
1. 指定環形圖孔的大小。
1. 將簡報寫入磁碟。

以下範例示範了如何設定環形圖孔的大小。

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

可以。將多個系列加入同一個環形圖——每個系列會形成一個獨立的環。環的順序依系列在集合中的排列順序決定。

### 支援「炸裂」環形圖（切片分離）嗎？

可以。Aspose.Slides 提供 Exploded Doughnut [圖表類型](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/charttype/) 以及資料點的炸裂屬性，您可以將個別切片分離。

### 如何取得環形圖的圖像（PNG/SVG）以用於報告？

圖表本身是一個形狀；您可以將其轉換為 [點陣圖](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)，或將圖表匯出為 [SVG 圖像](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)。