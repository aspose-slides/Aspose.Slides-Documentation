---
title: Aspose.Slides for .NET 16.1.0 的公共 API 和向后不兼容更改
type: docs
weight: 220
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
---

{{% alert color="primary" %}} 

此页面列出了在 Aspose.Slides for .NET 16.1.0 API 中新增的或移除的所有[class](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/)类、方法、属性等，以及其他更改。

{{% /alert %}} 
## **公共 API 更改**


#### **已将 RotationAngle 属性添加到 IChartTextBlockFormat 和 ITextFrameFormat 接口**
已将 RotationAngle 属性添加到接口 Aspose.Slides.Charts.IChartTextBlockFormat 和 Aspose.Slides.ITextFrameFormat。
它指定应用于边界框内文本的自定义旋转。

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("自定义标题").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **OdpException 从 Aspose.Slides.Odp 移动到 Aspose.Slides 命名空间**