---
title: 在C#或.NET中创建或更新PowerPoint演示文稿图表
linktitle: 创建或更新图表
type: docs
weight: 10
url: /zh/net/create-chart/
keywords: "创建图表,散点图,饼图,树形图,股票图,箱形图,直方图,漏斗图,日出图,多类别图, PowerPoint演示, C#, Csharp, Aspose.Slides for .NET"
description: "在C#或.NET中创建PowerPoint演示文稿中的图表"
---

## **创建图表**
图表帮助人们快速可视化数据并获得洞察，这可能并不是从表格或电子表格中立即显而易见的。

**为什么要创建图表？**

通过使用图表，您可以

* 在演示文稿的单个幻灯片上汇总、简化或总结大量数据
* 显示数据中的模式和趋势
* 推断数据随时间或特定测量单位的方向和势头
* 识别异常值、偏差、误差、无意义数据等
* 传达或呈现复杂数据

在PowerPoint中，您可以通过插入功能创建图表，该功能提供用于设计多种类型图表的模板。通过使用Aspose.Slides，您可以创建常规图表（基于流行的图表类型）和自定义图表。

{{% alert color="primary" %}} 

为了让您能够创建图表，Aspose.Slides在[Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/)命名空间下提供了[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)枚举。该枚举下的值对应于不同的图表类型。

{{% /alert %}} 

### **创建常规图表**
1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加一个带有数据的图表并指定您首选的图表类型。
1. 为图表添加标题。
1. 访问图表数据工作表。
1. 清除所有默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加一些新的图表数据。
1. 为图表系列添加填充颜色。
1. 为图表系列添加标签。
1. 将修改后的演示文稿写入PPTX文件。

以下C#代码向您展示了如何创建常规图表：

```c#
// 实例化表示PPTX文件的Presentation类
Presentation pres = new Presentation();

// 访问第一张幻灯片
ISlide sld = pres.Slides[0];

// 添加带有默认数据的图表
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

// 设置图表标题
chart.ChartTitle.AddTextFrameForOverriding("示例标题");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// 设置第一个系列以显示值
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

// 设置图表数据工作表的索引
int defaultWorksheetIndex = 0;

// 获取图表数据工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// 删除默认生成的系列和类别
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

// 添加新的系列
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "系列 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "系列 2"), chart.Type);

// 添加新的类别
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "类别 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "类别 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "类别 3"));

// 获取第一个图表系列
IChartSeries series = chart.ChartData.Series[0];

// 填充系列数据
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

// 设置系列的填充颜色
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// 获取第二个图表系列
series = chart.ChartData.Series[1];

// 填充系列数据
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// 设置系列的填充颜色
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

// 设置第一个标签以显示类别名称
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

// 设置第三个标签显示值
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";
            
// 将PPTX文件保存到磁盘
pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```

### **创建散点图**
散点图（也称为散点图或x-y图）通常用于检查模式或演示两个变量之间的相关性。

您可能想在以下情况下使用散点图

* 您有成对的数值数据
* 您有两个变量可以很好地配对
* 您想确定两个变量是否相关
* 您有一个独立变量，该独立变量具有多个依赖变量的值

以下C#代码向您展示了如何创建带有不同系列标记的散点图：

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

// 创建默认图表
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

// 获取默认图表数据工作表索引
int defaultWorksheetIndex = 0;

// 获取图表数据工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// 删除演示系列
chart.ChartData.Series.Clear();

// 添加新的系列
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "系列 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "系列 2"), chart.Type);

// 获取第一个图表系列
IChartSeries series = chart.ChartData.Series[0];

// 向系列添加新点 (1:3)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

// 添加新点 (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

// 更改系列类型
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

// 更改图表系列标记
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

// 获取第二个图表系列
series = chart.ChartData.Series[1];

// 向图表系列添加新点 (5:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

// 添加新点 (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

// 添加新点 (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

// 添加新点 (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

// 更改图表系列标记
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

// 将PPTX文件保存到磁盘
pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```

### **创建饼图**
饼图最佳用于显示数据中的部分与整体关系，尤其是当数据包含带有数值的分类标签时。然而，如果您的数据包含多个部分或标签，您可能想考虑使用柱状图。

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加带有默认数据和所需类型的图表（在本例中，为`ChartType.Pie`）。
1. 访问图表数据IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加新的图表数据。
1. 为图表的扇区添加新的点和自定义颜色。
1. 设置系列的标签。
1. 为系列标签设置领导行。
1. 设置饼图幻灯片的旋转角度。
1. 将修改后的演示文稿写入PPTX文件。

以下C#代码向您展示了如何创建饼图：

```c#
// 实例化表示PPTX文件的Presentation类
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

// 设置第一个系列以显示值
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

// 设置图表数据工作表的索引
int defaultWorksheetIndex = 0;

// 获取图表数据工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// 删除默认生成的系列和类别
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

// 添加新的类别
chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "第一季度"));
chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "第二季度"));
chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "第三季度"));

// 添加新的系列
IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "系列 1"), chart.Type);

// 填充系列数据
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

// 无法在新版本中使用
// 添加新点并设置扇区颜色
// series.IsColorVaried = true;
chart.ChartData.SeriesGroups[0].IsColorVaried = true;

IChartDataPoint point = series.DataPoints[0];
point.Format.Fill.FillType = FillType.Solid;
point.Format.Fill.SolidFillColor.Color = Color.Cyan;
// 设置扇区边框
point.Format.Line.FillFormat.FillType = FillType.Solid;
point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
point.Format.Line.Width = 3.0;
point.Format.Line.Style = LineStyle.ThinThick;
point.Format.Line.DashStyle = LineDashStyle.DashDot;

IChartDataPoint point1 = series.DataPoints[1];
point1.Format.Fill.FillType = FillType.Solid;
point1.Format.Fill.SolidFillColor.Color = Color.Brown;

// 设置扇区边框
point1.Format.Line.FillFormat.FillType = FillType.Solid;
point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
point1.Format.Line.Width = 3.0;
point1.Format.Line.Style = LineStyle.Single;
point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

IChartDataPoint point2 = series.DataPoints[2];
point2.Format.Fill.FillType = FillType.Solid;
point2.Format.Fill.SolidFillColor.Color = Color.Coral;

// 设置扇区边框
point2.Format.Line.FillFormat.FillType = FillType.Solid;
point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
point2.Format.Line.Width = 2.0;
point2.Format.Line.Style = LineStyle.ThinThin;
point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

// 为新系列的每个类别创建自定义标签
IDataLabel lbl1 = series.DataPoints[0].Label;

// lbl.ShowCategoryName = true;
lbl1.DataLabelFormat.ShowValue = true;

IDataLabel lbl2 = series.DataPoints[1].Label;
lbl2.DataLabelFormat.ShowValue = true;
lbl2.DataLabelFormat.ShowLegendKey = true;
lbl2.DataLabelFormat.ShowPercentage = true;

IDataLabel lbl3 = series.DataPoints[2].Label;
lbl3.DataLabelFormat.ShowSeriesName = true;
lbl3.DataLabelFormat.ShowPercentage = true;

// 设置图表系列显示领导行
series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

// 设置饼图扇区的旋转角度
chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

// 将PPTX文件保存到磁盘
presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
```

### **创建线图**
线图（也称为线性图）最佳用于您想要演示随时间变化的值的情况。使用线图，您可以同时比较大量数据，跟踪随时间的变化和趋势，突出数据系列中的异常等。

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加带有默认数据和所需类型的图表（在本例中，为`ChartType.Line`）。
1. 访问图表数据IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加新的图表数据。
1. 将修改后的演示文稿写入PPTX文件。

以下C#代码向您展示了如何创建线图：

```c#
using (Presentation pres = new Presentation())
{
    IChart lineChart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 10, 50, 600, 350);
    
    pres.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

默认情况下，线图上的点通过直线连接。如果您希望点之间通过虚线连接，可以指定您首选的虚线类型，方法如下： xxx

```c#
IChart lineChart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 10, 50, 600, 350);

foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

### **创建树形图**
树形图最佳用于销售数据，当您想要显示数据类别的相对大小时，同时快速吸引对每个类别的大贡献者的注意力。

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加带有默认数据和所需类型的图表（在本例中，为`ChartType.TreeMap`）。
1. 访问图表数据IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加新的图表数据。
1. 将修改后的演示文稿写入PPTX文件。

以下C#代码向您展示了如何创建树形图：

```c#
using (Presentation presentation = new Presentation())
{
	IChart chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50, 50, 500, 400);
	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	// 分支 1
	IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "叶子1"));
	leaf.GroupingLevels.SetGroupingItem(1, "茎1");
	leaf.GroupingLevels.SetGroupingItem(2, "分支1");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "叶子2"));

	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "叶子3"));
	leaf.GroupingLevels.SetGroupingItem(1, "茎2");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "叶子4"));

	// 分支 2
	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "叶子5"));
	leaf.GroupingLevels.SetGroupingItem(1, "茎3");
	leaf.GroupingLevels.SetGroupingItem(2, "分支2");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "叶子6"));

	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "叶子7"));
	leaf.GroupingLevels.SetGroupingItem(1, "茎4");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "叶子8"));

	IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
	series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 4));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 5));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 3));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 6));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 9));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 9));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 4));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 3));

	series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

	presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

### **创建股票图**
1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加带有默认数据和所需类型的图表（ChartType.OpenHighLowClose）。
1. 访问图表数据IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加新的图表数据。
1. 指定HiLowLines格式。
1. 将修改后的演示文稿写入PPTX文件。

用于创建股票图的示例C#代码：

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);
    
	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	chart.ChartData.Categories.Add(wb.GetCell(0, 1, 0, "A"));
	chart.ChartData.Categories.Add(wb.GetCell(0, 2, 0, "B"));
	chart.ChartData.Categories.Add(wb.GetCell(0, 3, 0, "C"));

	chart.ChartData.Series.Add(wb.GetCell(0, 0, 1, "开盘"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 2, "最高"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 3, "最低"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 4, "收盘"), chart.Type);

	IChartSeries series = chart.ChartData.Series[0];

	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 1, 72));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 1, 25));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 1, 38));

	series = chart.ChartData.Series[1];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 2, 172));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 2, 57));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 2, 57));

	series = chart.ChartData.Series[2];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 3, 12));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 3, 12));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 3, 13));

	series = chart.ChartData.Series[3];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 4, 25));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 4, 38));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 4, 50));

	chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
	chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

	foreach (IChartSeries ser in chart.ChartData.Series)
	{
		ser.Format.Line.FillFormat.FillType = FillType.NoFill;
	}

	pres.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

### **创建箱形图**
1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加带有默认数据和所需类型的图表（ChartType.BoxAndWhisker）。
1. 访问图表数据IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加新的图表数据。
1. 将修改后的演示文稿写入PPTX文件。

以下C#代码向您展示了如何创建箱形图：

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "类别 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "类别 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "类别 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "类别 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "类别 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "类别 1"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

		series.QuartileMethod = QuartileMethodType.Exclusive;
		series.ShowMeanLine = true;
		series.ShowMeanMarkers = true;
		series.ShowInnerPoints = true;
		series.ShowOutlierPoints = true;

		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B1", 15));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B2", 41));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B3", 16));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B4", 10));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B5", 23));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B6", 16));

		pres.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
	}
}
```

### **创建漏斗图**
1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加带有默认数据和所需类型的图表（ChartType.Funnel）。
1. 将修改后的演示文稿写入PPTX文件。

以下C#代码向您展示了如何创建漏斗图：

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "类别 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "类别 2"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "类别 3"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "类别 4"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "类别 5"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "类别 6"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B1", 50));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B2", 100));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B3", 200));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B4", 300));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B5", 400));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B6", 500));

		pres.Save("Funnel.pptx", SaveFormat.Pptx);
	}
}
```

### **创建日出图**
1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加带有默认数据和所需类型的图表（在本例中，为`ChartType.sunburst`）。
1. 将修改后的演示文稿写入PPTX文件。

以下C#代码向您展示了如何创建日出图：

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		// 分支 1
		IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "叶子1"));
		leaf.GroupingLevels.SetGroupingItem(1, "茎1");
		leaf.GroupingLevels.SetGroupingItem(2, "分支1");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "叶子2"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "叶子3"));
		leaf.GroupingLevels.SetGroupingItem(1, "茎2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "叶子4"));

		// 分支 2
		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "叶子5"));
		leaf.GroupingLevels.SetGroupingItem(1, "茎3");
		leaf.GroupingLevels.SetGroupingItem(2, "分支2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "叶子6"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "叶子7"));
		leaf.GroupingLevels.SetGroupingItem(1, "茎4");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "叶子8"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
		series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D1", 4));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D2", 5));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D3", 3));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D4", 6));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D5", 9));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D6", 9));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D7", 4));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D8", 3));

		pres.Save("Sunburst.pptx", SaveFormat.Pptx);
	}
}
```

### **创建直方图**
1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加一些图表并指定您的首选图表类型（在本例中为`ChartType.Histogram`）。
1. 访问图表数据`IChartDataWorkbook`。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 将修改后的演示文稿写入PPTX文件。

以下C#代码向您展示了如何创建直方图：

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Histogram, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A1", 15));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A2", -41));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A3", 16));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A4", 10));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A5", -23));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A6", 16));

		chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

		pres.Save("Histogram.pptx", SaveFormat.Pptx);
	}
}
```

### **创建雷达图**
1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加带有数据并指定您的首选图表类型（在本例中为`ChartType.Radar`）的图表。
1. 将修改后的演示文稿写入PPTX文件。  

以下C#代码向您展示了如何创建雷达图：

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 400, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

### **创建多类别图**
1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加带有默认数据的图表及所需类型（ChartType.ClusteredColumn）。
1. 访问图表数据IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加新的图表数据。
1. 将修改后的演示文稿写入PPTX文件。

以下C#代码向您展示了如何创建多类别图：

```c#
Presentation pres = new Presentation();
ISlide slide = pres.Slides[0];

IChart ch = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
ch.ChartData.Series.Clear();
ch.ChartData.Categories.Clear();

IChartDataWorkbook fact = ch.ChartData.ChartDataWorkbook;
fact.Clear(0);
int defaultWorksheetIndex = 0;

IChartCategory category = ch.ChartData.Categories.Add(fact.GetCell(0, "c2", "A"));
category.GroupingLevels.SetGroupingItem(1, "组1");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c3", "B"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c4", "C"));
category.GroupingLevels.SetGroupingItem(1, "组2");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c5", "D"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c6", "E"));
category.GroupingLevels.SetGroupingItem(1, "组3");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c7", "F"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c8", "G"));
category.GroupingLevels.SetGroupingItem(1, "组4");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c9", "H"));

// 添加系列
IChartSeries series = ch.ChartData.Series.Add(fact.GetCell(0, "D1", "系列 1"),
    ChartType.ClusteredColumn);

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D2", 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D3", 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D4", 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D5", 40));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D6", 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D7", 60));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D8", 70));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D9", 80));
// 保存带图表的演示
pres.Save("AsposeChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **创建地图图**
地图图是对包含数据区域的可视化。地图图最佳用于比较地理区域之间的数据或值。

以下C#代码向您展示了如何创建地图图：

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Map, 50, 50, 500, 400);
    pres.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

### **创建组合图**
组合图（或组合图表）是将两种或多种图表组合在单个图形上的图表。这种图表允许您突出、比较或审查两个（或多个）数据集之间的差异。通过这种方式，您可以看到数据集之间的关系（如果有的话）。

![combination-chart-ppt](combination-chart-ppt.png)

以下C#代码向您展示了如何在PowerPoint中创建组合图：

```c#
private static void CreateComboChart()
{
    using (Presentation pres = new Presentation())
    {
        IChart chart = CreateChart(pres.Slides[0]);
        AddFirstSeriesToChart(chart);
        AddSecondSeriesToChart(chart);
        pres.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChart(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "系列 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "系列 2"), chart.Type);
    
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "类别 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "类别 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "类别 3"));

    IChartSeries series = chart.ChartData.Series[0];

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));
    
    series = chart.ChartData.Series[1];
    
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    return chart;
}

private static void AddFirstSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "系列 3"), ChartType.ScatterWithSmoothLines);

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 0, 1, 3),
        workbook.GetCell(worksheetIndex, 0, 2, 5));
    
    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 3, 10),
        workbook.GetCell(worksheetIndex, 1, 4, 13));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 2, 3, 20),
        workbook.GetCell(worksheetIndex, 2, 4, 15));

    series.PlotOnSecondAxis = true;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 5, "系列 4"),
        ChartType.ScatterWithStraightLinesAndMarkers);

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 3, 5),
        workbook.GetCell(worksheetIndex, 1, 4, 2));
    
    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 5, 10),
        workbook.GetCell(worksheetIndex, 1, 6, 7));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 2, 5, 15),
        workbook.GetCell(worksheetIndex, 2, 6, 12));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 3, 5, 12),
        workbook.GetCell(worksheetIndex, 3, 6, 9));
    
    series.PlotOnSecondAxis = true;
}
```

## **更新图表**

1. 实例化一个表示包含图表的演示文稿的[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类。
2. 通过索引获取幻灯片的引用。
3. 遍历所有形状以查找所需的图表。
4. 访问图表数据工作表。
5. 通过更改系列值来修改图表数据系列数据。
6. 添加新系列并填充数据。
7. 将修改后的演示文稿写入PPTX文件。

以下C#代码向您展示了如何更新图表：

```c#
// 实例化表示PPTX文件的Presentation类
Presentation pres = new Presentation("ExistingChart.pptx");

// 访问第一张幻灯片
ISlide sld = pres.Slides[0];

// 添加带有默认数据的图表
IChart chart = (IChart)sld.Shapes[0];

// 设置图表数据工作表的索引
int defaultWorksheetIndex = 0;

// 获取图表数据工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// 更改图表类别名称
fact.GetCell(defaultWorksheetIndex, 1, 0, "修改后的类别 1");
fact.GetCell(defaultWorksheetIndex, 2, 0, "修改后的类别 2");

// 获取第一个图表系列
IChartSeries series = chart.ChartData.Series[0];

// 更新系列数据
fact.GetCell(defaultWorksheetIndex, 0, 1, "新系列1");// 修改系列名称
series.DataPoints[0].Value.Data = 90;
series.DataPoints[1].Value.Data = 123;
series.DataPoints[2].Value.Data = 44;

// 获取第二个图表系列
series = chart.ChartData.Series[1];

// 现在更新系列数据
fact.GetCell(defaultWorksheetIndex, 0, 2, "新系列2");// 修改系列名称
series.DataPoints[0].Value.Data = 23;
series.DataPoints[1].Value.Data = 67;
series.DataPoints[2].Value.Data = 99;

// 现在，添加新系列
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 3, "系列 3"), chart.Type);

// 获取第三个图表系列
series = chart.ChartData.Series[2];

// 现在填充系列数据
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 3, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 30));

chart.Type = ChartType.ClusteredCylinder;

// 保存带图表的演示文稿
pres.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
```

## **为图表设置数据范围**

1. 实例化一个表示包含图表的演示文稿的[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类。
2. 通过索引获取幻灯片的引用。
3. 遍历所有形状以查找所需的图表。
4. 访问图表数据并设置范围。
5. 将修改后的演示文稿保存为PPTX文件。

以下C#代码向您展示了如何为图表设置数据范围：

```c#
// 实例化表示PPTX文件的Presentation类
Presentation presentation = new Presentation("ExistingChart.pptx");

// 访问第一张幻灯片并添加带有默认数据的图表
ISlide slide = presentation.Slides[0];
IChart chart = (IChart)slide.Shapes[0];
chart.ChartData.SetRange("Sheet1!A1:B4");
presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
```

## **在图表中使用默认标记**
当您在图表中使用默认标记时，每个图表系列都会自动获得不同的默认标记符号。

以下C#代码向您展示了如何在图表系列中自动设置标记：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;
    chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "系列 1"), chart.Type);
    IChartSeries series = chart.ChartData.Series[0];

    chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 1, 24));
    chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 1, 23));
    chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 1, -10));
    chart.ChartData.Categories.Add(fact.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 1, null));

    chart.ChartData.Series.Add(fact.GetCell(0, 0, 2, "系列 2"), chart.Type);
    // 获取第二个图表系列
    IChartSeries series2 = chart.ChartData.Series[1];

    // 填充系列数据
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    pres.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```