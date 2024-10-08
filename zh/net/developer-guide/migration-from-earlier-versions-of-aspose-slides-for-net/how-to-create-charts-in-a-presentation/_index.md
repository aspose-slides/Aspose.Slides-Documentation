---
title: 如何在演示文稿中创建图表
type: docs
weight: 30
url: /zh/net/how-to-create-charts-in-a-presentation/
---

{{% alert color="primary" %}} 

新的 [Aspose.Slides for .NET API](/slides/zh/net/) 已经发布，现在这个单一产品支持从头生成 PowerPoint 文档和编辑现有文档的功能。

{{% /alert %}} 
## **对旧代码的支持**
为了使用使用Aspose.Slides for .NET 13.x以前版本开发的旧代码，您需要对代码进行一些小修改，代码将照常工作。旧版 Aspose.Slides for .NET 中的所有类在 Aspose.Slide 和 Aspose.Slides.Pptx 命名空间下现在都合并到单个 Aspose.Slides 命名空间中。请查看以下简单代码片段，了解如何使用旧版 Aspose.Slides API 从头在演示文稿中创建普通图表，并遵循描述如何迁移到新合并 API 的步骤。
## **旧版 Aspose.Slides for .NET 方法**
```c#
//实例化表示 PPTX 文件的 PresentationEx 类
using (PresentationEx pres = new PresentationEx())
{
	//访问第一张幻灯片
	SlideEx sld = pres.Slides[0];

	// 添加带有默认数据的图表
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//设置图表标题
	chart.ChartTitle.Text.Text = "示例标题";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//将第一系列设置为显示值
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//设置图表数据表的索引 
	int defaultWorksheetIndex = 0;

	//获取图表数据工作表
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//删除默认生成的系列和类别
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//添加新系列
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "系列 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "系列 2"), chart.Type);

	//添加新类别
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "类别 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "类别 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "类别 3"));

	//获取第一系列
	ChartSeriesEx series = chart.ChartData.Series[0];

	//现在填充系列数据
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//为系列设置填充颜色
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//获取第二系列
	series = chart.ChartData.Series[1];

	//现在填充系列数据
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//为系列设置填充颜色
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//为新系列的每个类别创建自定义标签

	//第一个标签将显示类别名称
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//为第二个标签显示系列名称
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//为第三个标签显示值
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//显示值和自定义文本
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "我的文本";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//保存带有图表的演示文稿
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **新版 Aspose.Slides for .NET 13.x 方法**
``` csharp
//实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();

//访问第一张幻灯片
ISlide sld = pres.Slides[0];

// 添加带有默认数据的图表
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//设置图表标题
//chart.ChartTitle.TextFrameForOverriding.Text = "示例标题";
chart.ChartTitle.AddTextFrameForOverriding("示例标题");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//将第一系列设置为显示值
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//设置图表数据表的索引
int defaultWorksheetIndex = 0;

//获取图表数据工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//删除默认生成的系列和类别
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//添加新系列
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "系列 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "系列 2"), chart.Type);

//添加新类别
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "类别 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "类别 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "类别 3"));

//获取第一系列
IChartSeries series = chart.ChartData.Series[0];

//现在填充系列数据

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//为系列设置填充颜色
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//获取第二系列
series = chart.ChartData.Series[1];

//现在填充系列数据
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//为系列设置填充颜色
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//为新系列的每个类别创建自定义标签

//第一个标签将显示类别名称
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//为第三个标签显示值
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//保存带有图表的演示文稿
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

请查看以下简单代码片段，了解如何使用旧版 Aspose.Slides API 从头在演示文稿中创建散点图，以及如何使用新合并 API 实现它。

## **旧版 Aspose.Slides for .NET 方法**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //创建默认图表
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //获取默认图表数据工作表索引
    int defaultWorksheetIndex = 0;

    //访问图表数据工作表
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //删除示例系列
    chart.ChartData.Series.Clear();

    //添加新系列
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "系列 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "系列 2"), chart.Type);

    //获取第一系列
    ChartSeriesEx series = chart.ChartData.Series[0];

    //添加新点 (1:3)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //添加新点 (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //编辑系列类型
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //更改图表系列标记
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //获取第二系列
    series = chart.ChartData.Series[1];

    //添加新点 (5:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //添加新点 (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //添加新点 (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //添加新点 (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //更改图表系列标记
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **新版 Aspose.Slides for .NET 13.x 方法**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//创建默认图表
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//获取默认图表数据工作表索引
int defaultWorksheetIndex = 0;

//访问图表数据工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//删除示例系列
chart.ChartData.Series.Clear();

//添加新系列
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "系列 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "系列 2"), chart.Type);

//获取第一系列
IChartSeries series = chart.ChartData.Series[0];

//添加新点 (1:3)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//添加新点 (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//编辑系列类型
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//更改图表系列标记
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//获取第二系列
series = chart.ChartData.Series[1];

//添加新点 (5:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//添加新点 (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//添加新点 (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//添加新点 (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//更改图表系列标记
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```