---
title: 在 .NET 中创建演示文稿图表
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
description: "了解如何使用 Aspose.Slides 在 .NET 中通过旧版和现代图表 API 创建 PowerPoint PPT、PPTX 和 ODP 演示文稿中的图表。"
---

{{% alert color="primary" %}} 

已发布全新的 [Aspose.Slides for .NET API](/slides/zh/net/) ，现在该产品支持从头生成 PowerPoint 文档以及编辑现有文档的功能。

{{% /alert %}} 
## **对旧版代码的支持**
为了使用在 13.x 之前的 Aspose.Slides for .NET 版本中开发的旧版代码，您需要对代码进行少量修改，代码即可如前般工作。以前在 Aspose.Slide 和 Aspose.Slides.Pptx 命名空间下的所有类现在已合并到单一的 Aspose.Slides 命名空间。请查看以下使用旧版 Aspose.Slides API 从头在演示文稿中创建普通图表的简易代码片段，并遵循步骤了解如何迁移到新的合并 API。
## **旧版 Aspose.Slides for .NET 方法**
```c#
 //实例化表示 PPTX 文件的 PresentationEx 类
 using (PresentationEx pres = new PresentationEx())
 {
 	//访问第一张幻灯片
 	SlideEx sld = pres.Slides[0];
 
 	// 添加默认数据的图表
 	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);
 
 	//设置图表标题
 	chart.ChartTitle.Text.Text = "Sample Title";
 	chart.ChartTitle.Text.CenterText = true;
 	chart.ChartTitle.Height = 20;
 	chart.HasTitle = true;
 
 	//设置第一数据系列显示数值
 	chart.ChartData.Series[0].Labels.ShowValue = true;
 
 	//设置图表数据工作表的索引
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
 
 	//获取第一图表系列
 	ChartSeriesEx series = chart.ChartData.Series[0];
 
 	//现在填充系列数据
 	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
 	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
 	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
 
 	//设置系列的填充颜色
 	series.Format.Fill.FillType = FillTypeEx.Solid;
 	series.Format.Fill.SolidFillColor.Color = Color.Red;
 
 
 	//获取第二图表系列
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


## **新版 Aspose.Slides for .NET 13.x 方法**
``` csharp
//实例化表示 PPTX 文件的 Presentation 类//实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();

//Access first slide
ISlide sld = pres.Slides[0];

// Add chart with default data
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Setting chart Title
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Set first series to Show Values
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Setting the index of chart data sheet
int defaultWorksheetIndex = 0;

//Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Delete default generated series and categories
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Adding new series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Adding new categories
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Take first chart series
IChartSeries series = chart.ChartData.Series[0];

//Now populating series data

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Setting fill color for series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Take second chart series
series = chart.ChartData.Series[1];

//Now populating series data
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Setting fill color for series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

//create custom labels for each of categories for new series

//first label will be show Category name
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Show value for third label
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Save presentation with chart
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```


请查看以下使用旧版 Aspose.Slides API 从头在演示文稿中创建散点图的简易代码片段，以及如何使用新的合并 API 实现相同功能。

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

    //Add new series
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //获取第一图表系列
    ChartSeriesEx series = chart.ChartData.Series[0];

    //在此处添加新点 (1:3)。
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

    //获取第二图表系列
    series = chart.ChartData.Series[1];

    //在此处添加新点 (5:2)。
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
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//获取第一图表系列
IChartSeries series = chart.ChartData.Series[0];

//在此处添加新点 (1:3)。
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//添加新点 (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//编辑系列类型
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//更改图表系列标记
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//获取第二图表系列
series = chart.ChartData.Series[1];

//在此处添加新点 (5:2)。
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
