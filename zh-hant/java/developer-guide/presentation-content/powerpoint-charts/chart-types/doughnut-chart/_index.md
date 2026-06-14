---
title: 使用 Java 在簡報中自訂環形圖
linktitle: 環形圖
type: docs
weight: 30
url: /zh-hant/java/doughnut-chart/
keywords:
- 環形圖
- 中心間隙
- 孔大小
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中建立與自訂環形圖，支援 PowerPoint 格式，以製作動態簡報。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用環形圖，包括將圖表新增至投影片、設定中心孔的大小，以及儲存簡報。重點介紹 `setDoughnutHoleSize` 方法，並示範在程式碼中自訂此圖表類型的基本步驟。

同時也提供了簡短的 FAQ，涵蓋相關的環形圖情境，例如使用多個系列建立多層環、使用炸裂環形圖、以及將圖表匯出為點陣圖或 SVG。

## **在環形圖中指定中心間隙**
{{% alert color="primary" %}} 

Aspose.Slides for Java 現在支援指定環形圖中心孔的大小。以下範例說明如何設定環形圖中心孔的大小。

{{% /alert %}} 

若要指定環形圖中心孔的大小，請依照下列步驟操作：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 物件。
1. 在投影片上新增環形圖。
1. 指定環形圖中心孔的大小。
1. 將簡報寫入磁碟。

在下方範例中，我們設定了環形圖中心孔的大小。

```java
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

**我可以建立具有多層環的多重環形圖嗎？**

可以。將多個系列新增到同一個環形圖中——每個系列會成為獨立的環。環的順序由系列在集合中的順序決定。

**是否支援「炸裂」環形圖（切片分離）？**

可以。Aspose.Slides 提供 Exploded Doughnut [圖表類型](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/charttype/) 並且資料點具有爆炸屬性，您可以分離個別切片。

**如何取得環形圖的影像（PNG/SVG）以用於報告？**

圖表是一個形狀；您可以將其渲染為 [點陣圖](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getImage-int-float-float-)，或將圖表匯出為 [SVG 影像](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)。