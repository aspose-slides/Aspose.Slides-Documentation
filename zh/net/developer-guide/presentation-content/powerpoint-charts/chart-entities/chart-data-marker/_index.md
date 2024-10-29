---
title: 图表数据标记
type: docs
url: /zh/net/chart-data-marker/
keywords:
- 图表标记选项
- PowerPoint
- 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: "在C#或.NET的PowerPoint演示文稿中设置图表标记选项"
---

## **设置图表标记选项**
可以在特定系列中的图表数据点上设置标记。为了设置图表标记选项，请按照以下步骤操作：

- 实例化[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类。
- 创建默认图表。
- 设置图片。
- 获取第一个图表系列。
- 添加新的数据点。
- 将演示文稿写入磁盘。

在下面给出的示例中，我们已经在数据点级别设置了图表标记选项。

```c#
// 创建Presentation类的实例
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// 创建默认图表
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// 获取默认图表数据工作表索引
int defaultWorksheetIndex = 0;

// 获取图表数据工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// 删除示例系列
chart.ChartData.Series.Clear();

// 添加新系列
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "系列 1"), chart.Type);

// 设置图片
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// 设置图片
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// 获取第一个图表系列
IChartSeries series = chart.ChartData.Series[0];

// 在该位置添加新点 (1:3)
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// 更改图表系列标记
series.Marker.Size = 15;

// 将演示文稿写入磁盘
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```