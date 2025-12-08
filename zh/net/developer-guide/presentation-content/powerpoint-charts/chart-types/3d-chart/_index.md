---
title: 3D 图表
type: docs
url: /zh/net/3d-chart/
keywords: "3d 图表, rotationX, rotationY, depthpercent, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 PowerPoint 演示文稿中使用 C# 或 .NET 设置 rotationX、rotationY 和 depthpercents"
---

## **设置 3D 图表的 RotationX、RotationY 和 DepthPercents 属性**
Aspose.Slides for .NET 提供了一个简洁的 API 用于设置这些属性。以下文章将帮助您设置不同的属性，如 X、Y 旋转、**DepthPercents** 等。示例代码演示了上述属性的设置。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 设置 Rotation3D 属性。
1. 将修改后的演示文稿写入 PPTX 文件。
```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation();
           
// 访问第一张幻灯片
ISlide slide = presentation.Slides[0];

// 添加默认数据的图表
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// 设置图表数据工作表的索引
int defaultWorksheetIndex = 0;

// 获取图表数据工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// 添加系列
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// 添加类别
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

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

// 设置 OverLap 值
series.ParentSeriesGroup.Overlap = 100;         

// 将演示文稿写入磁盘
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```


## **常见问题**

**Aspose.Slides 中哪些图表类型支持 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 枚举公开的相关 3D 类型。要获取准确、最新的列表，请在已安装版本的 API 参考中查看 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 成员。

**我可以获取 3D 图表的光栅图像用于报告或网页吗？**

是的。您可以通过 [chart API](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) 将图表导出为图像，或使用 [render the entire slide](/slides/zh/net/convert-powerpoint-to-png/) 将整个幻灯片渲染为 PNG、JPEG 等格式。当您需要像素精确的预览或想在文档、仪表板或网页中嵌入图表而无需 PowerPoint 时，这非常有用。

**构建和渲染大型 3D 图表的性能如何？**

性能取决于数据量和视觉复杂度。为获得最佳效果，请保持 3D 效果最小化，避免在墙面和绘图区域使用大量纹理，尽可能限制每个系列的数据点数量，并将渲染输出为适当尺寸（分辨率和尺寸），以匹配目标显示或打印需求。