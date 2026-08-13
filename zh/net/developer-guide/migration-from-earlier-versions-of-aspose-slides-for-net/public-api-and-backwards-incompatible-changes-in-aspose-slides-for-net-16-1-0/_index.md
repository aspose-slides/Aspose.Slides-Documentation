---
title: Aspose.Slides for .NET 16.1.0 的公共 API 和向后不兼容的更改
linktitle: Aspose.Slides for .NET 16.1.0
type: docs
weight: 220
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}}本页列出所有已[added](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/)或已[removed](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/)的类、方法、属性等，以及 Aspose.Slides for .NET 16.1.0 API 引入的其他更改。{{% /alert %}}
## **Public API Changes**

#### **已在 IChartTextBlockFormat 和 ITextFrameFormat 接口中添加属性 RotationAngle**
属性 RotationAngle 已添加到接口 Aspose.Slides.Charts.IChartTextBlockFormat 和 Aspose.Slides.ITextFrameFormat。它指定了在边界框内对文本应用的自定义旋转。

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
#### **已将 OdpException 从 Aspose.Slides.Odp 移动到 Aspose.Slides 命名空间**