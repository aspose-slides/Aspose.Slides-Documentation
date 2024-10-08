---
title: 图表绘图区
type: docs
url: /net/chart-plot-area/
keywords: "图表绘图区 PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "获取图表绘图区的宽度和高度。设置布局模式。C# 或 .NET 中的 PowerPoint 演示文稿"
---

## **获取图表绘图区的宽度和高度**
Aspose.Slides for .NET 提供了一个简单的 API。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 在获取实际值之前调用方法 IChart.ValidateChartLayout()。
1. 获取相对于图表左上角的图表元素的实际 X 位置（左）。
1. 获取相对于图表左上角的图表元素的实际顶部。
1. 获取图表元素的实际宽度。
1. 获取图表元素的实际高度。

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// 保存带有图表的演示文稿
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```




## **设置图表绘图区的布局模式**
Aspose.Slides for .NET 提供了一个简单的 API 来设置图表绘图区的布局模式。属性 **LayoutTargetType** 已添加到 **ChartPlotArea** 和 **IChartPlotArea** 类。如果绘图区的布局是手动定义的，则该属性指定是否通过内部（不包括坐标轴和坐标轴标签）或外部（包括坐标轴和坐标轴标签）来布局绘图区。可以在 **LayoutTargetType** 枚举中定义两种可能的值。

- **LayoutTargetType.Inner** - 指定绘图区的大小应决定绘图区的大小，不包括刻度线和坐标轴标签。
- **LayoutTargetType.Outer** - 指定绘图区的大小应决定绘图区的大小、刻度线和坐标轴标签。

下面是示例代码。

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```