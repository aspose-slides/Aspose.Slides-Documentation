---
title: 在 .NET 中自定义演示文稿的图表轴
linktitle: 图表轴
type: docs
url: /zh/net/chart-axis/
keywords:
- 图表轴
- 垂直轴
- 水平轴
- 自定义轴
- 操作轴
- 管理轴
- 轴属性
- 最大值
- 最小值
- 轴线
- 日期格式
- 轴标题
- 轴位置
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中自定义图表轴，用于报告和可视化。"
---

## **获取图表垂直轴的最大值**
Aspose.Slides for .NET 允许您获取垂直轴的最小值和最大值。按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加一个带有默认数据的图表。
1. 获取轴上的实际最大值。
1. 获取轴上的实际最小值。
1. 获取轴的实际主单位。
1. 获取轴的实际次单位。
1. 获取轴的实际主单位刻度。
1. 获取轴的实际次单位刻度。

此示例代码—上述步骤的实现—展示了如何在 C# 中获取所需的值：
```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// 保存演示文稿
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```


## **在轴之间交换数据**
Aspose.Slides 允许您快速在轴之间交换数据——垂直轴 (y 轴) 上的数据将移至水平轴 (x 轴)，反之亦然。

此 C# 代码展示了如何在图表上执行轴之间的数据交换任务：
```c#
 // 创建空演示文稿
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//切换行和列
	chart.ChartData.SwitchRowColumn();
		   
	// 保存演示文稿
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```


## **禁用折线图的垂直轴**

此 C# 代码展示了如何隐藏折线图的垂直轴：
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **禁用折线图的水平轴**

此代码展示了如何隐藏折线图的水平轴：
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **更改分类轴**

使用 **CategoryAxisType** 属性，您可以指定首选的分类轴类型（**date** 或 **text**）。以下 C# 代码演示了此操作： 
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```


## **设置分类轴值的日期格式**
Aspose.Slides for .NET 允许您设置分类轴值的日期格式。此操作在以下 C# 代码中演示：
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **设置图表轴标题的旋转角度**
Aspose.Slides for .NET 允许您设置图表轴标题的旋转角度。此 C# 代码演示了此操作：
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
	         chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **设置分类轴或值轴的位置**
Aspose.Slides for .NET 允许您在分类轴或值轴上设置轴的位置。此 C# 代码展示了如何完成此任务：
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```


## **在图表值轴上启用显示单位标签**
Aspose.Slides for .NET 允许您配置图表在其值轴上显示单位标签。此 C# 代码演示了此操作：
```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```


## **常见问题**

**如何设置一个轴交叉另一个轴的数值（轴交叉）？**

轴提供了一个 [crossing setting](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/)：您可以选择在零、在最大分类/值，或在特定数值处交叉。这对于上移或下移 X 轴或强调基准线非常有用。

**如何相对于轴定位刻度标签（旁侧、外部、内部）？**

将 [label position](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) 设置为 "cross", "outside", 或 "inside"。这会影响可读性，并有助于节省空间，尤其是在小型图表上。