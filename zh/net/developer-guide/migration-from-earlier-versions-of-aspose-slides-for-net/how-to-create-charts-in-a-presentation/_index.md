---
title: 如何在 .NET 中的演示文稿中创建图表
linktitle: 创建图表
type: docs
weight: 30
url: /zh/net/how-to-create-charts-in-a-presentation/
keywords:
- 迁移
- 创建图表
- 旧版代码
- 现代代码
- 旧版方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何在 .NET 中使用 Aspose.Slides，通过旧版和现代图表 API，在 PowerPoint PPT、PPTX 和 ODP 演示文稿中创建图表。"
---

{{% alert color="primary" %}} 

已发布全新的[Aspose.Slides for .NET API](/slides/zh/net/)，该产品现在支持从头创建 PowerPoint 文档以及编辑已有文档的功能。

{{% /alert %}} 
## **Support for Legacy code**
为了使用在 13.x 之前的 Aspose.Slides for .NET 版本中开发的旧版代码，您需要对代码做少量修改，代码即可像以前一样工作。之前在 Aspose.Slide 和 Aspose.Slides.Pptx 命名空间下的所有类现已合并到单一的 Aspose.Slides 命名空间中。请查看下面使用旧版 Aspose.Slides API 从头创建普通图表的简单代码片段，并按照步骤了解如何迁移到新的合并 API。
## **Legacy Aspose.Slides for .NET approach**
```c#
//实例化表示 PPTX 文件的 PresentationEx 类
using (PresentationEx pres = new PresentationEx())
{
	//访问第一张幻灯片
	SlideEx sld = pres.Slides[0];

	// 添加带默认数据的图表
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//设置图表标题
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//设置第一系列显示数值
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
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//添加新类别
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//获取第一条图表系列
	ChartSeriesEx series = chart.ChartData.Series[0];

	//现在填充系列数据
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//设置系列的填充颜色
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//获取第二条图表系列
	series = chart.ChartData.Series[1];

	//现在填充系列数据
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//设置系列的填充颜色
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//为新系列的每个类别创建自定义标签

	//第一个标签将显示类别名称
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//第二个标签显示系列名称
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//第三个标签显示数值
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//显示数值和自定义文本
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//保存包含图表的演示文稿
	pres.Write(@"D:\AsposeChart.pptx");
}
```




## **New Aspose.Slides for .NET 13.x approach**
``` csharp
//实例化表示 PPTX 文件的 Presentation 类//实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();

//访问第一张幻灯片
ISlide sld = pres.Slides[0];

// 添加带默认数据的图表
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//设置图表标题
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//设置第一系列显示数值
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
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//添加新类别
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//获取第一条图表系列
IChartSeries series = chart.ChartData.Series[0];

//现在填充系列数据

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//设置系列的填充颜色
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//获取第二条图表系列
series = chart.ChartData.Series[1];

//现在填充系列数据
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//设置系列的填充颜色
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//为新系列的每个类别创建自定义标签

//第一个标签将显示类别名称
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//第三个标签显示数值
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//保存包含图表的演示文稿
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```


请查看下面使用旧版 Aspose.Slides API 从头创建散点图的简单代码片段，以及如何使用新的合并 API 实现相同功能。

## **Legacy Aspose.Slides for .NET approach**
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

    //删除演示系列
    chart.ChartData.Series.Clear();

    //添加新系列
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //获取第一条图表系列
    ChartSeriesEx series = chart.ChartData.Series[0];

    //在此添加新点 (1:3)。
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //添加新点 (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //编辑系列的类型
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //更改图表系列的标记
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //获取第二条图表系列
    series = chart.ChartData.Series[1];

    //在此添加新点 (5:2)。
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

    //更改图表系列的标记
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```



## **New Aspose.Slides for .NET 13.x approach**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//创建默认图表
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//获取默认图表数据工作表索引
int defaultWorksheetIndex = 0;

//访问图表数据工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//删除演示系列
chart.ChartData.Series.Clear();

//添加新系列
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//获取第一条图表系列
IChartSeries series = chart.ChartData.Series[0];

//在此添加新点 (1:3)。
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//添加新点 (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//编辑系列的类型
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//更改图表系列的标记
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//获取第二条图表系列
series = chart.ChartData.Series[1];

//在此添加新点 (5:2)。
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//添加新点 (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//添加新点 (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//添加新点 (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//更改图表系列的标记
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```
