---
title: Aspose.Slides for .NET 15.8.0 的公共 API 及向后不兼容的更改
linktitle: Aspose.Slides for .NET 15.8.0
type: docs
weight: 190
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 遗留方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，帮助您顺利迁移 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 
此页面列出了所有已添加[已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/)或已删除[已删除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/)的类、方法、属性等，以及 Aspose.Slides for .NET 15.8.0 API 引入的其他更改。
{{% /alert %}} 
## **公共 API 更改**
#### **已向 IChartSeries 和 ChartSeries 添加属性 DoughnutHoleSize**
指定环形图中孔的大小。

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```