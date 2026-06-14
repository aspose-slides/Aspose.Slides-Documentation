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
- 投影片
- .NET
- C#
- Aspose.Slides
description: "檢視 Aspose.Slides for .NET 的公開 API 更新與重大變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 投影片解決方案。"
---
{{% alert color="primary" %}}

此頁面列出所有已[新增](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/)或已[移除](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/)類別、方法、屬性等，及其他隨 Aspose.Slides for .NET 15.8.0 API 引入的變更。

{{% /alert %}}
## **公開 API 變更**
#### **已將 Property DoughnutHoleSize 新增至 IChartSeries 和 ChartSeries**
指定圓環圖中孔的大小。

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```