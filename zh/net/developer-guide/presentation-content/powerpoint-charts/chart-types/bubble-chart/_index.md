---
title: 气泡图
type: docs
url: /zh/net/bubble-chart/
keywords: "气泡图, 图表大小, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint 演示文稿中使用 C# 或 .NET 的气泡图大小"
---

## **气泡图大小缩放**
Aspose.Slides for .NET 提供对气泡图大小缩放的支持。在 Aspose.Slides for .NET 中已添加 **IChartSeries.BubbleSizeScale** 和 **IChartSeriesGroup.BubbleSizeScale** 属性。下面给出示例代码。  
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **将数据表示为气泡图大小**
已向 IChartSeries、IChartSeriesGroup 接口及相关类添加属性 **BubbleSizeRepresentation**。**BubbleSizeRepresentation** 指定气泡图中气泡大小值的表示方式。可能的值有：**BubbleSizeRepresentationType.Area** 和 **BubbleSizeRepresentationType.Width**。相应地，已添加 **BubbleSizeRepresentationType** 枚举，以指定将数据表示为气泡图大小的可能方式。下面给出示例代码。  
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```


## **常见问题**

**是否支持“具有 3-D 效果的气泡图”，它与普通气泡图有何区别？**

是的。有一种单独的图表类型 “Bubble with 3-D”。它对气泡应用 3-D 样式，但不添加额外的坐标轴；数据仍为 X‑Y‑S（size）。该类型在[chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 枚举中可用。

**气泡图的系列和数据点数量是否有限制？**

在 API 级别没有硬性限制；约束取决于性能和目标 PowerPoint 版本。建议保持数据点数量合理，以确保可读性和渲染速度。

**导出（PDF、图像）会影响气泡图的外观吗？**

导出到受支持的格式会保留图表的外观；渲染由 Aspose.Slides 引擎完成。对于光栅/矢量格式，遵循一般的图表渲染规则（分辨率、抗锯齿），因此请为打印选择足够的 DPI。