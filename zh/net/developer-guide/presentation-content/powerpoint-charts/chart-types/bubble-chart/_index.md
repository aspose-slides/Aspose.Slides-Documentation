---
title: 气泡图
type: docs
url: /net/bubble-chart/
keywords: "气泡图, 图表大小, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中的 PowerPoint 演示文稿中的气泡图大小"
---

## **气泡图大小缩放**
Aspose.Slides for .NET 提供气泡图大小缩放的支持。在 Aspose.Slides for .NET 中，添加了 **IChartSeries.BubbleSizeScale** 和 **IChartSeriesGroup.BubbleSizeScale** 属性。以下示例代码如下。

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **将数据表示为气泡图大小**
属性 **BubbleSizeRepresentation** 已添加到 IChartSeries、IChartSeriesGroup 接口及相关类中。**BubbleSizeRepresentation** 指定气泡大小值在气泡图中的表示方式。可能的值为：**BubbleSizeRepresentationType.Area** 和 **BubbleSizeRepresentationType.Width**。因此，添加了 **BubbleSizeRepresentationType** 枚举以指定将数据表示为气泡图大小的可能方式。示例代码如下。

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```