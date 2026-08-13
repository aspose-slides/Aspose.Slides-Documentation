---
title: Aspose.Slides for .NET 16.1.0 的公共 API 與向後不相容變更
linktitle: Aspose.Slides for .NET 16.1.0
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
description: "檢視 Aspose.Slides for .NET 的公共 API 更新與破壞性變更，順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 

此頁面列出所有 [added](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) 或 [removed](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) 類別、方法、屬性等，及 Aspose.Slides for .NET 16.1.0 API 所引入的其他變更。

{{% /alert %}} 
## **公共 API 變更**


#### **已在 IChartTextBlockFormat 與 ITextFrameFormat 介面中新增屬性 RotationAngle**
已在介面 Aspose.Slides.Charts.IChartTextBlockFormat 與 Aspose.Slides.ITextFrameFormat 中加入屬性 RotationAngle。  
它指定套用於包圍盒內文字的自訂旋轉。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


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
#### **OdpException 已從 Aspose.Slides.Odp 移至 Aspose.Slides 命名空間**