---
title: 在 .NET 中管理演示文稿的图表数据标记
linktitle: 数据标记
type: docs
url: /zh/net/chart-data-marker/
keywords:
- 图表
- 数据点
- 标记
- 标记选项
- 标记大小
- 填充类型
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中自定义图表数据标记，通过清晰的 C# 代码示例提升 PPT 和 PPTX 格式演示文稿的效果。"
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

// 创建默认图表
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

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

// 在此添加新点 (1:3)。
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


## **FAQ**

**哪些标记形状是开箱即用的？**

提供标准形状（圆形、方形、菱形、三角形等）；列表由 [MarkerStyleType](https://reference.aspose.com/slides/net/aspose.slides.charts/markerstyletype/) 枚举定义。如果需要非标准形状，请使用带图片填充的标记来模拟自定义视觉效果。

**将图表导出为图像或 SVG 时，标记会被保留吗？**

会的。在将图表渲染为 [raster formats](/slides/zh/net/convert-powerpoint-to-png/) 或将 [shapes as SVG](/slides/zh/net/render-a-slide-as-an-svg-image/) 保存时，标记会保留其外观和设置，包括大小、填充和轮廓。