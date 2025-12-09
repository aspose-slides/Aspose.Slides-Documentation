---
title: 在 .NET 中自定义演示文稿的气泡图
linktitle: 气泡图
type: docs
url: /zh/net/bubble-chart/
keywords:
- 气泡图
- 气泡大小
- 大小缩放
- 大小表示
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 中创建和自定义强大的气泡图，轻松提升数据可视化效果。"
---

## **气泡图大小缩放**
Aspose.Slides for .NET 提供对气泡图大小缩放的支持。 在 Aspose.Slides for .NET 中已添加 **IChartSeries.BubbleSizeScale** 和 **IChartSeriesGroup.BubbleSizeScale** 属性。 下面给出示例。  
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **将数据表示为气泡图大小**
已在 IChartSeries、IChartSeriesGroup 接口及相关类中添加属性 **BubbleSizeRepresentation**。 **BubbleSizeRepresentation** 指定气泡图中气泡大小值的表示方式。 可能的取值有：**BubbleSizeRepresentationType.Area** 和 **BubbleSizeRepresentationType.Width**。 因此，已添加 **BubbleSizeRepresentationType** 枚举以指定将数据表示为气泡图大小的可能方式。 下面给出示例代码。  
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```


## **常见问题**

**是否支持带 3-D 效果的气泡图，它与普通气泡图有何区别？**

是的。存在一种单独的图表类型“Bubble with 3-D”。它对气泡应用 3D 样式，但不会添加额外的坐标轴；数据仍为 X‑Y‑S（大小）。该类型在[chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 枚举中可用。

**气泡图的系列和数据点数量是否有限制？**

在 API 级别没有硬性限制；约束由性能和目标 PowerPoint 版本决定。建议保持数据点数量在合理范围，以保证可读性和渲染速度。

**导出（PDF、图像）会如何影响气泡图的外观？**

导出为受支持的格式可保留图表外观；渲染由 Aspose.Slides 引擎完成。对于栅格或矢量格式，遵循通用的图表渲染规则（分辨率、抗锯齿），因此请为打印选择足够的 DPI。