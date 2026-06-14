---
title: Aspose.Slides for Java 15.8.0 中的公共 API 以及向後不相容的變更
linktitle: Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- 遷移
- 傳統程式碼
- 現代程式碼
- 傳統方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢視 Aspose.Slides for Java 的公共 API 更新與重大變更，順利遷移您的 PowerPoint PPT、PPTX 以及 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 
此頁面列出所有 [added](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) 或 [removed](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) 類別、方法、屬性等，及隨 Aspose.Slides for Java 15.8.0 API 引入的其他變更。
{{% /alert %}} 
## **公開 API 變更**
#### **Methods getDoughnutHoleSize(), setDoughnutHoleSize(byte) have been added to IChartSeries and ChartSeries**
指定甜甜圈圖表中孔的大小。
``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```