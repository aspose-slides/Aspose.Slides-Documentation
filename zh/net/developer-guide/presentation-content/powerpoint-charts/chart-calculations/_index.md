---
title: 图表计算
type: docs
weight: 50
url: /net/chart-calculations/
keywords: "图表计算, 图表元素, 元素位置, 图表值 C#, Csharp, Aspose.Slides for .NET"
description: "C# 或 .NET 中的 PowerPoint 图表计算和数值"
---

## **计算图表元素的实际值**
Aspose.Slides for .NET 提供了一个简单的 API 来获取这些属性。这将帮助您计算图表元素的实际值。实际值包括实现 IActualLayout 接口的元素的位置（IActualLayout.ActualX，IActualLayout.ActualY，IActualLayout.ActualWidth，IActualLayout.ActualHeight）和实际坐标轴值（IAxis.ActualMaxValue，IAxis.ActualMinValue，IAxis.ActualMajorUnit，IAxis.ActualMinorUnit，IAxis.ActualMajorUnitScale，IAxis.ActualMinorUnitScale）。

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
Aspose.Slides for .NET 提供了一个简单的 API 来获取这些属性。IActualLayout 的属性提供有关父图表元素的实际位置信息。在填充属性以获取实际值之前，必须调用方法 IChart.ValidateChartLayout()。

```c#
// 创建空演示文稿
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



## **隐藏图表中的信息**
本主题帮助您理解如何隐藏图表中的信息。使用 Aspose.Slides for .NET，您可以隐藏图表中的 **标题、纵轴、横轴** 和 **网格线**。以下代码示例展示了如何使用这些属性。

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    // 隐藏图表标题
    chart.HasTitle = false;

    // 隐藏数值轴
    chart.Axes.VerticalAxis.IsVisible = false;

    // 类别轴的可见性
    chart.Axes.HorizontalAxis.IsVisible = false;

    // 隐藏图例
    chart.HasLegend = false;

    // 隐藏主网格线
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

    // 设置系列线条颜色
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```