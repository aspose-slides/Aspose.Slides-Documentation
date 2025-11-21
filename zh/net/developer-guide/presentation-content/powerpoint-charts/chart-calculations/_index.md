---
title: 优化 .NET 中演示文稿的图表计算
linktitle: 图表计算
type: docs
weight: 50
url: /zh/net/chart-calculations/
keywords:
- 图表计算
- 图表元素
- 元素位置
- 实际位置
- 子元素
- 父元素
- 图表数值
- 实际值
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 中的图表计算、数据更新和精度控制，适用于 PPT 和 PPTX，并附有实用的 C# 代码示例。"
---

## **计算图表元素的实际值**
Aspose.Slides for .NET 提供了一个简易的 API 来获取这些属性。这将帮助您计算图表元素的实际值。实际值包括实现 IActualLayout 接口的元素位置（IActualLayout.ActualX、IActualLayout.ActualY、IActualLayout.ActualWidth、IActualLayout.ActualHeight）以及实际坐标轴值（IAxis.ActualMaxValue、IAxis.ActualMinValue、IAxis.ActualMajorUnit、IAxis.ActualMinorUnit、IAxis.ActualMajorUnitScale、IAxis.ActualMinorUnitScale）。
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// 保存演示文稿
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```


## **计算父图表元素的实际位置**
Aspose.Slides for .NET 提供了一个简易的 API 来获取这些属性。IActualLayout 的属性提供了父图表元素实际位置的信息。需要在之前调用 IChart.ValidateChartLayout() 方法以填充属性的实际值。
```c#
// 创建空白演示文稿
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```


## **隐藏图表信息**
本主题帮助您了解如何隐藏图表中的信息。使用 Aspose.Slides for .NET，您可以隐藏图表的**标题、垂直坐标轴、水平坐标轴**和**网格线**。下面的代码示例展示了如何使用这些属性。
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //隐藏图表标题
    chart.HasTitle = false;

    ///隐藏数值轴
    chart.Axes.VerticalAxis.IsVisible = false;

    //类别轴可见性
    chart.Axes.HorizontalAxis.IsVisible = false;

    //隐藏图例
    chart.HasLegend = false;

    //隐藏主网格线
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //Setting series line color
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```


## **常见问题**
**外部 Excel 工作簿可以作为数据源吗？这会如何影响重新计算？**

是的。图表可以引用外部工作簿：当您连接或刷新外部源时，公式和数值将从该工作簿中获取，图表在打开/编辑操作期间会反映这些更新。API 允许您[指定外部工作簿](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/)路径并管理链接的数据。

**我能在不自行实现回归的情况下计算并显示趋势线吗？**

是的。[趋势线](/slides/zh/net/trend-line/)（线性、指数等）由 Aspose.Slides 添加并自动更新；其参数会依据系列数据自动重新计算，因此您无需自行实现计算。

**如果一个演示文稿中有多个带有外部链接的图表，我可以控制每个图表使用哪个工作簿进行计算吗？**

是的。每个图表都可以指向其自己的[外部工作簿](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/)，或者您可以为每个图表单独创建/替换外部工作簿，而不受其他图表的影响。