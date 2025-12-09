---
title: Aspose.Slides for .NET 16.1.0 的公共 API 及向后不兼容的更改
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
description: "审阅 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以平稳迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}}

此页面列出在 Aspose.Slides for .NET 16.1.0 API 中[added](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/)或[removed](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/)的类、方法、属性等以及其他更改。

{{% /alert %}}
## **Public API Changes**

#### **Property RotationAngle has been added to IChartTextBlockFormat and ITextFrameFormat interfaces**
已在 IChartTextBlockFormat 和 ITextFrameFormat 接口中添加属性 RotationAngle。  
已在接口 Aspose.Slides.Charts.IChartTextBlockFormat 和 Aspose.Slides.ITextFrameFormat 中添加属性 RotationAngle。  
它指定了在边界框内应用于文本的自定义旋转角度。

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
#### **OdpException moved from Aspose.Slides.Odp to Aspose.Slides namespace**
OdpException 已从 Aspose.Slides.Odp 移动到 Aspose.Slides 命名空间