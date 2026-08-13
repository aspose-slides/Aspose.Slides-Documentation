---
title: Aspose.Slides for .NET 15.8.0 的公開 API 與向後不相容變更
linktitle: Aspose.Slides for .NET 15.8.0
type: docs
weight: 190
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢視 Aspose.Slides for .NET 的公開 API 更新與重大變更，協助您順利遷移 PowerPoint PPT、PPTX 及 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 

此頁面列出了所有已新增或已移除的類別、方法、屬性等，及其他隨 Aspose.Slides for .NET 15.8.0 API 引入的變更。

{{% /alert %}} 
## **公開 API 變更**
#### **已在 IChartSeries 與 ChartSeries 中加入屬性 DoughnutHoleSize**
指定環形圖中孔的大小。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```