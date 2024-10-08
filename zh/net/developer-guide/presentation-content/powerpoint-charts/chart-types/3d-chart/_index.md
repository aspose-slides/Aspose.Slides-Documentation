---
title: 3D 图表
type: docs
url: /zh/net/3d-chart/
keywords: "3d 图表, rotationX, rotationY, depthpercent, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中为 PowerPoint 演示文稿设置 3D 图表的 rotationX, rotationY 和 depthpercents"
---

## **设置 3D 图表的 RotationX、RotationY 和 DepthPercents 属性**
Aspose.Slides for .NET 提供了一个简单的 API 来设置这些属性。以下文章将帮助您如何设置不同的属性，如 X、Y 旋转、**DepthPercents** 等。示例代码应用了上述属性的设置。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 设置 Rotation3D 属性。
1. 将修改后的演示文稿写入 PPTX 文件。

```c#
// 创建一个 Presentation 类的实例
Presentation presentation = new Presentation();
           
// 访问第一张幻灯片
ISlide slide = presentation.Slides[0];

// 添加带有默认数据的图表
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// 设置图表数据表的索引
int defaultWorksheetIndex = 0;

// 获取图表数据工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// 添加系列
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "系列 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "系列 2"), chart.Type);

// 添加类别
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "类别 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "类别 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "类别 3"));

// 设置 Rotation3D 属性
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// 获取第二个图表系列
IChartSeries series = chart.ChartData.Series[1];

// 现在填充系列数据
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// 设置重叠值
series.ParentSeriesGroup.Overlap = 100;         

// 将演示文稿写入磁盘
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```