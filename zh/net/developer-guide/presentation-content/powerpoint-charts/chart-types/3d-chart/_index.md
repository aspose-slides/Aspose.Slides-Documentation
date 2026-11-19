---
title: 在 .NET 中自定义演示文稿的 3D 图表
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
description: "使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中创建 3D 图表。通过 C# 示例调整旋转、 高度比例、 图表深度以及系列之间的间距。"
---
## **概述**

Aspose.Slides for .NET 允许您通过 [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) 属性自定义 3D 图表的视图。本文演示如何调整旋转、 高度比例、 深度、 直角坐标轴以及系列之间的间距，然后将演示文稿保存为 PPTX 格式。

## **设置 3D 图表的旋转和深度**

下面的示例创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 并使用 [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) 在其第一张幻灯片上添加一个堆叠的 3D 柱形图。它将默认的系列和类别替换为两个每个包含三个值的系列。工作表索引 `0` 标识图表的第一个数据工作表；行 `0` 保存系列名称，列 `0` 保存类别标签。

[RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) 和 [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) 属性分别将图表的旋转设置为 40 度和 270 度。 [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) 将其深度设置为宽度的 150%，而 [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) 则启用直角坐标轴而非透视。生成的演示文稿包含具有这些 3D 视图设置的填充图表。

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

## **调整 3D 图表的高度比例**

使用 [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) 将 3D 图表的高度设置为其宽度的百分比。这会改变 3D 场景的比例，而不会重新调整幻灯片上图表对象的大小。

下面的示例创建一个带有默认数据的 [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 图表：三系列四类别。它保存了三个演示文稿，分别将高度比例设为 50%、100% 和 200%。图表的位置、宽度和高度保持不变。数据、旋转、深度、系列间距和格式在所有三个文件中都是相同的；仅高度百分比发生变化。

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

以下图像使用 Microsoft PowerPoint 从生成的演示文稿中导出。较小的百分比会产生更平坦的场景，而较大的百分比会在同一图表对象中产生更高的场景。PowerPoint 还可能会调整坐标轴刻度间隔和标签位置以适应场景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![3D 柱形图，高度设置为宽度的 50%](height_percent_50.png) | ![3D 柱形图，高度设置为宽度的 100%](height_percent_100.png) | ![3D 柱形图，高度设置为宽度的 200%](height_percent_200.png) |

这些属性控制图表的不同方面：

| 属性 | 效果 |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | 3D 场景的高度，以其宽度的百分比表示。 |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | 幻灯片上图表对象的高度，单位为点。 |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | 3D 场景的深度，以其宽度的百分比表示。 |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | 沿深度轴的系列间距，以标记宽度的百分比表示。 |

高度设置影响 3D 柱形图和条形图，包括圆柱体、圆锥体和金字塔变体，以及 3D 折线图、面积图、饼图和曲面图。上面的比较使用了经过验证的 `Column3D` 类型。该设置不会更改 2D `ClusteredColumn` 图表或 `BubbleWith3D` 图表的外观；这些名称是 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 枚举的成员。有关其他图表外观设置，请参阅 [Chart Formatting](/slides/zh/net/chart-formatting/)。

## **调整系列之间的间隙**

使用 [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) 控制 3D 图表中数据系列沿深度轴的距离，表示为标记宽度的百分比。取值范围为 **0 到 500**（含）：`0` 移除间隙，较大的值会增加间距。若图表深度固定，增大间隙会使标记在深度轴上变得更细。

通过 [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) 访问该组。此设置适用于该组中的所有系列，而不仅限于用于访问的系列。 [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) 为只读属性，反映父组的设置。

此设置影响 3D 柱形图和条形图，包括它们的圆柱体、圆锥体和金字塔变体，以及 3D 折线图和面积图。外观取决于系列是按深度、聚类还是堆叠排列。若要清晰比较不同系列之间的间隙，请使用来自 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 枚举的 `ChartType.Column3D`。

这些属性控制图表的不同方面：

| 属性 | 效果 |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | 沿深度轴的系列间距，以标记宽度的百分比表示。 |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | 相邻条形或柱形簇之间的间距，以条形或柱形宽度的百分比表示。 |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | 整体图表深度，以图表宽度的百分比表示。 |

以下独立示例使用默认图表数据，其中包含三系列和四类别。它保存了两个演示文稿，数据、旋转、间隙宽度和图表深度均相同；仅间隙深度发生变化。

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

以下图像使用 Microsoft PowerPoint 从生成的演示文稿中导出。

| 间隙深度：0% | 间隙深度：500% |
| --- | --- |
| ![3D 柱形图，系列沿深度轴之间没有间隙](gap_depth_0.png) | ![3D 柱形图，系列沿深度轴之间有 500% 的间隙](gap_depth_500.png) |

## **更改 3D 系列类型和条形形状**

在聚类圆柱体图表中，第一系列起始为圆柱形条。示例在每次更改前后读取 [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) 和 [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/)。

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

将形状设为 `Box` 也会将系列类型更改为 `ClusteredColumn3D`。如果您的代码根据系列类型进行分支，请在更改形状后读取 `series.Type`。在赋值之前缓存的值仍会选择 `ClusteredCone` 分支。

![PowerPoint 对比，显示第一系列从左到右分别为圆柱体、圆锥体和矩形柱形](series-shapes.png)

## **常见问题**

**哪些图表类型在 Aspose.Slides 中支持 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 枚举公开的相关 3D 类型。要获取准确、最新的列表，请在已安装版本的 API 参考中检查 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 成员。

**我可以获取 3D 图表的栅格图像用于报告或网页吗？**

可以。您可以使用 [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) 将图表导出为图像，或将整张幻灯片[渲染为 PNG / JPEG 等格式](/slides/zh/net/convert-powerpoint-to-png/)。当您需要栅格预览或想在文档、仪表板或网页中嵌入图表且不依赖 PowerPoint 时，这很有用。

**构建和渲染大型 3D 图表的性能如何？**

性能取决于数据量和视觉复杂度。为获得最佳效果，请尽量减少 3D 效果，避免在墙面和绘图区域使用沉重的纹理，尽可能限制每个系列的数据点数量，并渲染到与目标显示或打印需求相匹配的适当尺寸输出（分辨率和尺寸）。