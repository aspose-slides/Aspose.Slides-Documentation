---
title: 在 .NET 中自定义演示文稿图表的绘图区域
linktitle: 绘图区域
type: docs
url: /zh/net/chart-plot-area/
keywords:
- 图表
- 绘图区域
- 绘图区域宽度
- 绘图区域高度
- 绘图区域大小
- 布局模式
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中自定义图表绘图区域。轻松提升幻灯片视觉效果。"
---

## **获取图表绘图区域的宽度和高度**
Aspose.Slides for .NET 提供了一个简单的 API 用于 。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 访问第一张幻灯片。
3. 使用默认数据添加图表。
4. 在获取实际值之前调用方法 IChart.ValidateChartLayout()。
5. 获取图表元素相对于图表左上角的实际 X 位置（左）。
6. 获取图表元素相对于图表左上角的实际 Y 位置（上）。
7. 获取图表元素的实际宽度。
8. 获取图表元素的实际高度。
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





## **设置图表绘图区域的布局模式**
Aspose.Slides for .NET 提供了一个简单的 API 来设置图表绘图区域的布局模式。属性 **LayoutTargetType** 已添加到 **ChartPlotArea** 和 **IChartPlotArea** 类中。如果绘图区域的布局手动定义，此属性指定是按内部（不包括坐标轴和坐标轴标签）还是外部（包括坐标轴和坐标轴标签）布局绘图区域。**LayoutTargetType** 枚举定义了两种可能的值。

- **LayoutTargetType.Inner** - 指定绘图区域的大小应确定绘图区域的尺寸，不包括刻度线和坐标轴标签。
- **LayoutTargetType.Outer** - 指定绘图区域的大小应确定绘图区域、刻度线和坐标轴标签的尺寸。

以下示例代码演示了如何使用。
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


## **FAQ**

**ActualX、ActualY、ActualWidth 和 ActualHeight 以什么单位返回？**

以点为单位；1 英寸 = 72 点。这些是 Aspose.Slides 的坐标单位。

**绘图区域与图表区域在内容上有什么区别？**

绘图区域是数据绘制区域（系列、网格线、趋势线等）；图表区域包括周围的元素（标题、图例等）。在 3D 图表中，绘图区域还包括墙面/底面和坐标轴。

**在手动布局时，绘图区域的 X、Y、宽度和高度如何解释？**

它们是图表整体大小的比例（0–1）；在此模式下自动定位被禁用，使用您设置的比例值。

**为什么在添加/移动图例后绘图区域的位置会改变？**

图例位于图表区域的绘图区域之外，但会影响布局和可用空间，因此在自动定位生效时，绘图区域可能会移动。（这是 PowerPoint 图表的标准行为。）