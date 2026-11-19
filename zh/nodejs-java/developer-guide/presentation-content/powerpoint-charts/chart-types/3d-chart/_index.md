---
title: 使用 JavaScript 在演示文稿中自定义 3D 图表
linktitle: 3D 图表
type: docs
url: /zh/nodejs-java/3d-chart/
keywords:
- 3D 图表
- 旋转
- 深度
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint 演示文稿中创建 3D 图表。通过 JavaScript 示例调整旋转、高度比例、图表深度以及系列间的间距。"
---
## **概述**

Aspose.Slides for Node.js via Java 允许您通过 [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) 方法自定义 3D 图表的视图。本文演示如何调整旋转、高度比例、深度、直角坐标轴以及系列之间的间距，然后将演示文稿保存为 PPTX 格式。

## **设置 3D 图表的旋转和深度**

下面的示例创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 并使用 [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) 将堆叠 3D 柱状图添加到其第一张幻灯片。它用两个每个包含三个值的系列替换默认的系列和类别。工作表索引 `0` 标识图表的第一个数据工作表；行 `0` 保存系列名称，列 `0` 保存类别标签。

[setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) 和 [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) 方法分别将图表的旋转设置为 40 度和 270 度。[setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) 将其深度设置为宽度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) 则启用直角坐标轴而非透视。生成的演示文稿包含已填充数据的图表，并采用这些 3D 视图设置。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **调整 3D 图表的高度比例**

使用 [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) 将 3D 图表的高度设置为其宽度的百分比。这会改变 3D 场景的比例，而不会更改幻灯片上图表对象的大小。

以下示例创建一个 [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 图表，使用默认数据：三系列和四类别。它保存了三个演示文稿，分别对应高度比例为 50%、100% 和 200%。图表的位置、宽度和高度保持不变。数据、旋转、深度、系列间距和格式在所有文件中完全相同；唯一变化的是高度百分比。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

以下图像展示了等效 .NET 示例中的相同高度设置，且均使用 Microsoft PowerPoint 导出。较小的百分比会产生更平坦的场景，较大的百分比则在同一图表对象内产生更高的场景。PowerPoint 还可能会调整坐标轴刻度间隔和标签位置以适应场景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![3D 柱状图，高度设置为宽度的 50%](height_percent_50.png) | ![3D 柱状图，高度设置为宽度的 100%](height_percent_100.png) | ![3D 柱状图，高度设置为宽度的 200%](height_percent_200.png) |

这些方法控制图表的不同方面：

| 方法 | 效果 |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | 3D 场景的高度，作为宽度的百分比。 |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | 幻灯片上图表对象的高度，单位为点。 |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 3D 场景的深度，作为宽度的百分比。 |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | 沿深度轴的系列间距，作为标记宽度的百分比。 |

高度设置会影响 3D 柱状图和条形图，包括圆柱形、圆锥形和金字塔形变体，以及 3D 折线图、面积图、饼图和曲面图。上面的比较使用了已验证的 `Column3D` 类型。该设置不会改变 2D `ClusteredColumn` 图表或 `BubbleWith3D` 图表的外观；这些名称是 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 类的成员。有关其他图表外观设置，请参阅 [Chart Formatting](/slides/zh/nodejs-java/chart-formatting/)。

## **调整系列之间的间隙**

使用 [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) 控制 3D 图表中数据系列沿深度轴的距离，以标记宽度的百分比表示。可使用 **0 到 500**（含）的值：`0` 移除间隙，值越大间距越大。在固定图表深度的情况下，增大间隙会使标记在深度轴上变得更细。

通过 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) 访问该组。此设置适用于该组中的每个系列，而不仅仅是用于访问它的系列。[ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) 返回深度间隙并反映父组的设置。

此设置影响 3D 柱状图和条形图，包括其圆柱形、圆锥形和金字塔形变体，以及 3D 折线图和面积图。外观取决于系列是按深度排列、聚类还是堆叠。若要清晰比较不同系列之间的间隙，请使用来自 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 类的 `ChartType.Column3D`。

| 方法 | 效果 |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | 沿深度轴的系列间距，作为标记宽度的百分比。 |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | 相邻条形或柱形簇之间的间距，作为条形或柱形宽度的百分比。 |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 整体图表深度，作为图表宽度的百分比。 |

以下独立示例使用默认图表数据，其中包含三系列和四类别。它保存了两个演示文稿，数据、旋转、间隙宽度和图表深度完全相同，仅更改了间隙深度。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

以下图像展示了等效 .NET 示例中的相同间隙深度设置，且均使用 Microsoft PowerPoint 导出。

| 间隙深度：0% | 间隙深度：500% |
| --- | --- |
| ![3D 柱状图在深度轴上系列之间没有间隙](gap_depth_0.png) | ![3D 柱状图在深度轴上系列之间的间隙为 500%](gap_depth_500.png) |

## **更改 3D 系列类型和条形形状**

在聚类圆柱形图中，第一系列的条形形状最初为圆柱形。示例在每次更改前后分别打印由 [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) 和 [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) 返回的整数值。下表给出了相应的常量名称。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 对第一系列的更改 | 系列类型 | 条形形状 |
| --- | --- | --- |
| 创建图表 | `ClusteredCylinder` | `Cylinder` |
| 将系列类型设置为 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 将条形形状设置为 `Box` | `ClusteredColumn3D` | `Box` |

将形状设置为 `Box` 还会将系列类型更改为 `ClusteredColumn3D`。如果您的代码根据系列类型进行分支，请在更改形状后调用 `series.getType()`。在赋值前缓存的值仍会选择 `ClusteredCone` 分支。

![PowerPoint 比较，显示第一系列从左到右分别为柱形、圆锥形和矩形柱形](series-shapes.png)

## **常见问题**

**哪些图表类型在 Aspose.Slides 中支持 3D 模式？**

Aspose.Slides 支持柱状图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 类公开的相关 3D 类型。要获取确切且最新的列表，请查看已安装版本 API 参考中的 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 成员。

**我能否获取 3D 图表的栅格图像用于报告或网页？**

可以。您可以使用 [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 将图表导出为图像，或使用 [render the entire slide](/slides/zh/nodejs-java/convert-powerpoint-to-png/) 将整张幻灯片导出为 PNG、JPEG 等格式。当您需要栅格预览或想在文档、仪表盘或网页中嵌入图表而不依赖 PowerPoint 时，这非常有用。

**构建和渲染大型 3D 图表的性能如何？**

性能取决于数据量和视觉复杂度。为获得最佳效果，请尽量保持 3D 效果最小化，避免在墙面和绘图区使用大量纹理，尽可能限制每个系列的数据点数量，并将输出尺寸（分辨率和尺寸）设定为匹配目标显示或打印需求的合适大小。