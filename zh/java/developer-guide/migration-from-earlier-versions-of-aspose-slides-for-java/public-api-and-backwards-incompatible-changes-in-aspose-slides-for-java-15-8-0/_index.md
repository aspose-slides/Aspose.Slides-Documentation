---
title: Aspose.Slides for Java 15.8.0 的公共 API 及向后不兼容更改
linktitle: Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 遗留方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审查 Aspose.Slides for Java 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

此页面列出了所有 [已添加](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) 或 [已移除](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) 类、方法、属性等，以及 Aspose.Slides for Java 15.8.0 API 引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **已向 IChartSeries 和 ChartSeries 添加了方法 getDoughnutHoleSize()、setDoughnutHoleSize(byte)**

指定环形图中孔的大小。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```