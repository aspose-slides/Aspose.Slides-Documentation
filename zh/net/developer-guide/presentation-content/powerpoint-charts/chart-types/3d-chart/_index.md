---
title: .NET 中演示文稿的 3D 图表自定义
linktitle: 3D 图表
type: docs
url: /zh/net/3d-chart/
keywords:
- 3D 图表
- 旋转
- 深度
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中创建 3D 图表。使用 C# 示例调整旋转、高度比例、图表深度和系列之间的间距。"
---
## **概述**

Aspose.Slides for .NET 允许您通过 [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) 属性自定义 3D 图表的视图。本文演示如何调整旋转、高度比例、深度、直角坐标轴以及系列之间的间距，然后将演示文稿保存为 PPTX 格式。

## **设置 3D 图表的旋转和深度**

下面的示例创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 并使用 [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) 在其第一张幻灯片上添加一个堆叠的 3D 柱形图。它将默认的系列和类别替换为两个各包含三个值的系列。工作表索引 `0` 标识图表的第一个数据工作表；行 `0` 包含系列名称，列 `0` 包含类别标签。

[RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) 和 [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) 属性分别将图表的旋转设置为 40 度和 270 度。[DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) 将其深度设置为宽度的 150%，而 [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) 则启用直角坐标轴而非透视。生成的演示文稿包含带有这些 3D 视图设置的已填充图表。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

var values = new double[,] { { 20, 50, 30 }, { 30, 10, 60 } };

for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, 0, $"Category {categoryIndex + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

for (var seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, seriesIndex + 1, $"Series {seriesIndex + 1}");
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

    for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }
}

chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **对 3D 图表表面应用图片填充**

3D 图表有三个表面可独立填充：[side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/)、[back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) 和 [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/)。将选定表面的 [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 设置为 `Picture` 并分配图像。将 [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) 和表面的 [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) 都设置为 `Stretch`，以使图像的单个副本覆盖整个表面。

将 [arrow.png](arrow.png) 保存到工作目录。示例旋转图表并提升垂直轴的最大值，以便在柱形之间可见地面。随后将幻灯片克隆两次，在每张幻灯片上将箭头应用到不同的表面。三个图表保持相同的数据、视角和背景。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 20, 30, 680, 480);
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 30;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 24;

var backSlide = presentation.Slides.AddClone(slide);
var floorSlide = presentation.Slides.AddClone(slide);
var backChart = (IChart)backSlide.Shapes[0];
var floorChart = (IChart)floorSlide.Shapes[0];

var imageBytes = File.ReadAllBytes("arrow.png");
var arrow = presentation.Images.AddImage(imageBytes);

foreach (var surface in new[] { chart.SideWall, backChart.BackWall, floorChart.Floor })
{
    var fill = surface.Format.Fill;
    fill.FillType = FillType.Picture;
    fill.PictureFillFormat.Picture.Image = arrow;
    fill.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    surface.PictureType = PictureType.Stretch;
}

presentation.Save("chart-surfaces.pptx", SaveFormat.Pptx);
```

Microsoft PowerPoint 如下显示这三张幻灯片。

| 侧墙 | 背墙 | 地板 |
| --- | --- | --- |
| ![沿侧墙指向图表的箭头](side-wall.png) | ![沿背墙向右指的箭头](back-wall.png) | ![在柱形之间的地板上向右指的箭头](floor.png) |

## **调整 3D 图表的高度比例**

使用 [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) 将 3D 图表的高度设置为其宽度的百分比。这会在不调整幻灯片上图表对象大小的情况下改变 3D 场景的比例。

下面的示例创建一个带有默认数据的 [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 图表：三个系列和四个类别。它保存了三个演示文稿，分别将高度比例设置为 50%、100% 和 200%。图表的位置、宽度和高度保持不变。所有三个文件的数据、旋转、深度、系列间距和格式均相同；只有高度百分比不同。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 460);
chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.DepthPercents = 100;
chart.ChartData.Series[0].ParentSeriesGroup.GapDepth = 150;

foreach (ushort heightPercent in new ushort[] { 50, 100, 200 })
{
    chart.Rotation3D.HeightPercents = heightPercent;
    presentation.Save($"chart_height_{heightPercent}.pptx", SaveFormat.Pptx);
}
```

以下图像是使用 Microsoft PowerPoint 从生成的演示文稿导出的。较小的百分比会产生更平坦的场景，而较大的百分比会在相同的图表对象内产生更高的场景。PowerPoint 可能还会调整坐标轴刻度间隔和标签位置以适应场景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![3D 柱形图，高度设置为宽度的 50%](height_percent_50.png) | ![3D 柱形图，高度设置为宽度的 100%](height_percent_100.png) | ![3D 柱形图，高度设置为宽度的 200%](height_percent_200.png) |

这些属性控制图表的不同方面：

| 属性 | 影响 |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | 3D 场景的高度，占其宽度的百分比。 |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | 幻灯片上图表对象的高度（以点为单位）。 |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | 3D 场景的深度，占其宽度的百分比。 |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | 沿深度轴的系列间距，按标记宽度的百分比计算。 |

高度设置影响 3D 柱形图和条形图，包括圆柱体、圆锥体和金字塔变体，以及 3D 折线图、面积图、饼图和曲面图。以上比较使用了已验证的 `Column3D` 类型。此设置不会改变 2D `ClusteredColumn` 图表或 `BubbleWith3D` 图表的外观；这些名称是 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 枚举的成员。有关其他图表外观设置，请参阅 [图表格式化](/slides/zh/net/chart-formatting/)。

## **调整系列之间的间隙**

使用 [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) 控制 3D 图表中数据系列沿深度轴的距离，表示为标记宽度的百分比。使用范围为 **0 到 500**（含）的值：`0` 删除间隙，而更大的值会增加间距。若图表深度固定，增大间隙会使标记在深度轴上变得更细。

通过 [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) 访问该组。该设置适用于该组中的所有系列，而不仅仅是用于访问的系列。[IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) 为只读属性，反映父组的设置。

此设置影响 3D 柱形图和条形图，包括其圆柱体、圆锥体和金字塔变体，以及 3D 折线图和面积图。外观取决于系列是按深度、聚类还是堆叠排列。要清晰比较不同系列之间的间隙，请使用来自 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 枚举的 `ChartType.Column3D`。

这些属性控制图表的不同方面：

| 属性 | 影响 |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | 沿深度轴的系列间距，按标记宽度的百分比计算。 |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | 相邻柱或柱簇之间的间距，按柱或列宽度的百分比计算。 |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | 整体图表深度，按图表宽度的百分比计算。 |

下面的独立示例使用默认图表数据，包含三个系列和四个类别。它保存了两个演示文稿，数据、旋转、间隙宽度和图表深度相同；仅间隙深度不同。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 230);

chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.DepthPercents = 100;

var series = chart.ChartData.Series[0];
var group = series.ParentSeriesGroup;
group.GapWidth = 150;

foreach (ushort gapDepth in new ushort[] { 0, 500 })
{
    group.GapDepth = gapDepth;

    var fileName = $"series_gap_depth_{gapDepth}.pptx";
    presentation.Save(fileName, SaveFormat.Pptx);

}
```

以下图像是使用 Microsoft PowerPoint 从生成的演示文稿导出的。

| 间隙深度：0% | 间隙深度：500% |
| --- | --- |
| ![3D 柱形图，系列沿深度轴之间无间隙](gap_depth_0.png) | ![3D 柱形图，系列沿深度轴之间有 500% 的间隙](gap_depth_500.png) |

## **更改 3D 系列类型和柱形状**

在聚类圆柱图中，第一系列的柱形起始为圆柱形状。示例在每次更改前后读取 [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) 和 [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/)。

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Type = ChartType.ClusteredCone;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Bar3DShape = ChartShapeType.Box;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

presentation.Save("series_shape.pptx", SaveFormat.Pptx);
```

| 对第一系列的更改 | `Type` | `Bar3DShape` |
| --- | --- | --- |
| 创建图表 | `ClusteredCylinder` | `Cylinder` |
| 将 `Type` 设置为 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 将 `Bar3DShape` 设置为 `Box` | `ClusteredColumn3D` | `Box` |

将形状设置为 `Box` 同时会将系列类型更改为 `ClusteredColumn3D`。如果代码根据系列类型进行分支，请在更改形状后读取 `series.Type`。在赋值前缓存的值仍会选择 `ClusteredCone` 分支。

![PowerPoint 对比显示第一系列从左到右分别为圆柱、圆锥和矩形柱](series-shapes.png)

## **常见问题**

**Aspose.Slides 支持哪些图表类型的 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 枚举公开的相关 3D 类型。欲获取完整、最新的列表，请在已安装版本的 API 参考中查看 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 成员。

**是否可以获取 3D 图表的光栅图像用于报告或网页？**

可以。您可以使用 [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) 将图表导出为图像，或将整个幻灯片[渲染整个幻灯片](/slides/zh/net/convert-powerpoint-to-png/) PNG、JPEG 等格式。当您需要光栅预览或希望在文档、仪表板或网页中嵌入图表而无需 PowerPoint 时，这非常有用。

**构建和渲染大型 3D 图表的性能如何？**

性能取决于数据量和视觉复杂度。为获得最佳效果，请尽量保持 3D 效果最少，避免在墙面和绘图区使用大量纹理，尽可能限制每个系列的数据点数量，并渲染到与目标显示或打印需求相匹配的适当尺寸（分辨率和尺寸）的输出。