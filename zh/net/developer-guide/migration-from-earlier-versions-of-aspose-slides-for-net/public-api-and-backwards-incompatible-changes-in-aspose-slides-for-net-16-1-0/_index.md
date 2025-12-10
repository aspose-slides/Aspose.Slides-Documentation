---
title: Aspose.Slides for .NET 16.1.0 的公共 API 与向后不兼容的更改
linktitle: Aspose.Slides for .NET 16.1.0
type: docs
weight: 220
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中审阅公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 
此页面列出所有[已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/)或[已移除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/)的类、方法、属性等，以及 Aspose.Slides for .NET 16.1.0 API 引入的其他更改。
{{% /alert %}} 
## **公共 API 更改**

#### **属性 RotationAngle 已添加到 IChartTextBlockFormat 和 ITextFrameFormat 接口**
已在接口 Aspose.Slides.Charts.IChartTextBlockFormat 和 Aspose.Slides.ITextFrameFormat 中添加属性 RotationAngle。它指定了在边框内对文本应用的自定义旋转。

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
#### **OdpException 已从 Aspose.Slides.Odp 移动到 Aspose.Slides 命名空间**