---
title: Aspose.Slides for Java 15.8.0 的公共 API 與向後不相容變更
linktitle: Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢視 Aspose.Slides for Java 的公共 API 更新與破壞性變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}}

本頁面列出所有已[新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/)或已[移除](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/)的類別、方法、屬性等，以及隨 Aspose.Slides for Java 15.8.0 API 引入的其他變更。
{{% /alert %}}
## **公共 API 變更**
#### **已在 IChartSeries 和 ChartSeries 中加入 getDoughnutHoleSize() 與 setDoughnutHoleSize(byte) 方法**
指定環形圖中孔的大小。
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```