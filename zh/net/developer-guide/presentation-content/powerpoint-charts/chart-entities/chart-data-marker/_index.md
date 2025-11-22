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
description: "在 PowerPoint 演示文稿中使用 C# 或 .NET 设置图表标记选项"
---

## **设置图表标记选项**
可以在特定系列的图表数据点上设置标记。要设置图表标记选项，请按照以下步骤操作：

- 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类。
- 创建默认图表。
- 设置图片。
- 获取第一个图表系列。
- 添加新数据点。
- 将演示文稿写入磁盘。

在下面的示例中，我们在数据点级别设置了图表标记选项。
```c#
// 创建 Presentation 类的实例
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// 获取默认图表数据工作表索引
int defaultWorksheetIndex = 0;

// 获取图表数据工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// 删除示例系列
chart.ChartData.Series.Clear();

// 添加新系列
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// 设置图片
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// 设置图片
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// 获取第一个图表系列
IChartSeries series = chart.ChartData.Series[0];

// 在此处添加新点 (1:3)。
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

// 将演示文稿保存到磁盘
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**默认提供哪些标记形状？**

提供标准形状（圆形、方形、菱形、三角形等）；这些形状由 [MarkerStyleType](https://reference.aspose.com/slides/net/aspose.slides.charts/markerstyletype/) 枚举定义。如果需要非标准形状，可使用带图片填充的标记来模拟自定义视觉效果。

**导出图表为图像或 SVG 时标记会被保留吗？**

会的。在将图表渲染为 [raster formats](/slides/zh/net/convert-powerpoint-to-png/) 或保存为 [shapes as SVG](/slides/zh/net/render-a-slide-as-an-svg-image/) 时，标记会保留其外观和设置，包括大小、填充和轮廓。