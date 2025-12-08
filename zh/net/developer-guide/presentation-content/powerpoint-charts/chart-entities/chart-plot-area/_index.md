---
title: 图表绘图区
type: docs
url: /zh/net/chart-plot-area/
keywords: "图表绘图区 PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "获取图表绘图区的宽度和高度。设置布局模式。在 C# 或 .NET 中的 PowerPoint 演示文稿。"
---

## **获取图表绘图区的宽度和高度**
Aspose.Slides for .NET 提供了一个简单的 API。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加具有默认数据的图表。
1. 在获取实际值之前调用 IChart.ValidateChartLayout() 方法。
1. 获取图表元素相对于图表左上角的实际 X 位置（左）。
1. 获取图表元素相对于图表左上角的实际顶部位置。
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
Aspose.Slides for .NET 提供了一个简单的 API 来设置图表绘图区的布局模式。已向 **ChartPlotArea** 和 **IChartPlotArea** 类添加了属性 **LayoutTargetType**。如果绘图区的布局是手动定义的，则此属性指定是按内部（不包括坐标轴和坐标轴标签）还是外部（包括坐标轴和坐标轴标签）进行布局。**LayoutTargetType** 枚举中定义了两个可能的值。

- **LayoutTargetType.Inner** - 指定绘图区的大小应决定绘图区的尺寸，不包括刻度线和坐标轴标签。
- **LayoutTargetType.Outer** - 指定绘图区的大小应决定绘图区的尺寸、刻度线和坐标轴标签。

下面给出示例代码。
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


## **常见问题**
**ActualX、ActualY、ActualWidth 和 ActualHeight 以什么单位返回？**  
以点（points）为单位；1 英寸 = 72 点。这是 Aspose.Slides 的坐标单位。

**绘图区在内容上与图表区有何不同？**  
绘图区是数据绘制区域（系列、网格线、趋势线等）；图表区包括外围元素（标题、图例等）。在 3D 图表中，绘图区还包括墙面/底面和坐标轴。

**当布局为手动时，绘图区的 X、Y、宽度和高度如何解释？**  
它们是图表整体大小的比例（0–1）；在此模式下，自动定位被禁用，使用您设置的比例值。

**为什么在添加/移动图例后绘图区位置会发生变化？**  
图例位于绘图区之外的图表区，但会影响布局和可用空间，因此在自动定位生效时绘图区可能会移动。（这是 PowerPoint 图表的标准行为。）