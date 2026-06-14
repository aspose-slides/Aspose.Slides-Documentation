---
title: Aspose.Slides for .NET 16.1.0 的公開 API 以及向後不相容的變更
linktitle: Aspose.Slides（適用於 .NET） 16.1.0
type: docs
weight: 220
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
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
description: "檢視 Aspose.Slides for .NET 的公開 API 更新與重大變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有[已新增](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/)或[已移除](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/)的類別、方法、屬性等，及 Aspose.Slides for .NET 16.1.0 API 所引入的其他變更。

{{% /alert %}} 
## **公開 API 變更**


#### **已在 IChartTextBlockFormat 和 ITextFrameFormat 介面中新增屬性 RotationAngle**
已在介面 Aspose.Slides.Charts.IChartTextBlockFormat 和 Aspose.Slides.ITextFrameFormat 中新增屬性 RotationAngle。它指定套用於邊框內文字的自訂旋轉角度。

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Custom title").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **已將 OdpException 從 Aspose.Slides.Odp 移至 Aspose.Slides 命名空間**