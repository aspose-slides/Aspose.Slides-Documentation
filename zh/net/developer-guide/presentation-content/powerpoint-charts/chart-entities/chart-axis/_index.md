---
title: 图表坐标轴
type: docs
url: /zh/net/chart-axis/
keywords: "PowerPoint 图表坐标轴, 演示文稿图表, C#, .NET, 操作图表坐标轴, 图表数据"
description: "使用 C# 或 .NET 编辑 PowerPoint 图表坐标轴"
---


## **获取图表垂直轴的最大值**
Aspose.Slides for .NET 允许您获取垂直轴上的最小值和最大值。请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加一个带有默认数据的图表。
1. 获取轴上的实际最大值。
1. 获取轴上的实际最小值。
1. 获取轴的实际主要单位。
1. 获取轴的实际次要单位。
1. 获取轴的实际主要单位刻度。
1. 获取轴的实际次要单位刻度。

以下示例代码——上述步骤的实现——向您展示如何在 C# 中获取所需的值：

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


## **在坐标轴之间交换数据**
Aspose.Slides 允许您快速在坐标轴之间交换数据——表示在垂直轴 (y 轴) 上的数据移至水平轴 (x 轴)，反之亦然。

以下 C# 代码向您展示如何在图表的坐标轴之间执行数据交换任务：

```c#
// 创建空演示文稿
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// 交换行和列
	chart.ChartData.SwitchRowColumn();
		   
	// 保存演示文稿
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **为折线图禁用垂直轴**

以下 C# 代码向您展示如何隐藏折线图的垂直轴：

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **为折线图禁用水平轴**

以下代码向您展示如何隐藏折线图的水平轴：

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **更改分类轴**

使用 **CategoryAxisType** 属性，您可以指定首选的分类轴类型 (**date** 或 **text**)。以下 C# 代码演示了此操作： 

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

## **为分类轴值设置日期格式**
Aspose.Slides for .NET 允许您为分类轴值设置日期格式。 此操作在以下 C# 代码中演示：

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

## **为图表坐标轴标题设置旋转角度**
Aspose.Slides for .NET 允许您设置图表坐标轴标题的旋转角度。 以下 C# 代码演示了此操作：

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **在分类或数值轴中设置位置轴**
Aspose.Slides for .NET 允许您在分类或数值轴中设置位置轴。 以下 C# 代码展示了如何执行该任务：

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **在图表数值轴上启用显示单位标签**
Aspose.Slides for .NET 允许您配置图表以在其图表数值轴上显示单位标签。 以下 C# 代码演示了此操作：

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```