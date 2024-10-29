---
title: 饼图
type: docs
url: /zh/net/pie-chart/
keywords: "饼图，绘图选项，切片颜色，PowerPoint演示，C#，Csharp，Aspose.Slides for .NET"
description: "饼图绘图选项和PowerPoint演示中的切片颜色，使用C#或.NET"
---

## **饼图和棱柱图的第二绘图选项**
Aspose.Slides for .NET 现在支持饼图或棱柱图的第二绘图选项。在本主题中，我们将通过示例来说明如何使用 Aspose.Slides 来指定这些选项。为了指定属性，请按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类对象。
1. 在幻灯片上添加图表。
1. 指定图表的第二绘图选项。
1. 将演示文稿写入磁盘。

在下面给出的示例中，我们设置了饼图的不同属性。

```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation();

// 在幻灯片上添加图表
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// 设置不同的属性
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// 将演示文稿写入磁盘
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```




## **设置自动饼图切片颜色**
Aspose.Slides for .NET 提供了一个简单的API来设置自动饼图切片颜色。示例代码应用了上述属性设置。

1. 创建 Presentation 类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 设置图表标题。
1. 将第一系列设置为显示值。
1. 设置图表数据表的索引。
1. 获取图表数据工作表。
1. 删除默认生成的系列和类别。
1. 添加新类别。
1. 添加新系列。

将修改后的演示文稿写入 PPTX 文件。

```c#
// 实例化表示 PPTX 文件的 Presentation 类
using (Presentation presentation = new Presentation())
{
	// 实例化表示 PPTX 文件的 Presentation 类
	Presentation presentation = new Presentation();

	// 访问第一张幻灯片
	ISlide slides = presentation.Slides[0];

	// 添加带有默认数据的图表
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// 设置图表标题
	chart.ChartTitle.AddTextFrameForOverriding("示例标题");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// 将第一系列设置为显示值
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// 设置图表数据表的索引
	int defaultWorksheetIndex = 0;

	// 获取图表数据工作表
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// 删除默认生成的系列和类别
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// 添加新类别
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "第一季度"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "第二季度"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "第三季度"));

	// 添加新系列
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "系列 1"), chart.Type);

	// 现在填充系列数据
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```