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
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint 演示文稿中创建 3D 图表。通过 JavaScript 示例调整旋转、高度比例、图表深度和系列之间的间距。"
---
## **概述**

Aspose.Slides for Node.js via Java 允许您通过 [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) 方法自定义 3D 图表的视图。本文演示如何调整旋转、高度比例、深度、直角坐标轴以及系列之间的间距，然后将演示文稿保存为 PPTX 格式。

## **设置 3D 图表的旋转和深度**

下面的示例创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 并使用 [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) 在其第一张幻灯片上添加一个堆叠的 3D 柱状图。它用两个每个包含三个值的系列替换默认的系列和类别。工作表索引 `0` 标识图表的第一个数据工作表；行 `0` 保存系列名称，列 `0` 保存类别标签。

[setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) 和 [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) 方法分别将图表的旋转设置为 40 度和 270 度。[setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) 将其深度设置为宽度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) 则启用直角坐标轴而非透视。生成的演示文稿包含带有这些 3D 视图设置的填充图表。

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

## **对 3D 图表表面应用图片填充**

您可以分别填充 3D 图表的 [侧墙](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/)、[背墙](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/) 和 [底部](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/)。将表面的 [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) 设置为 `Picture` 并指定图像。将 [picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) 和表面的 [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) 都设置为 `Stretch`，以使图像的单个副本覆盖整个表面。

在工作目录中保存 [arrow.png](arrow.png)。示例旋转图表并提升垂直轴的最大值，使底部在柱之间可见。然后将幻灯片克隆两次，并在每张幻灯片的不同表面上应用箭头。三个图表保持相同的数据、视角和背景。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint 显示如下三个幻灯片。

| 侧墙 | 背墙 | 底部 |
| --- | --- | --- |
| ![沿侧墙指向图表的箭头](side-wall.png) | ![横跨背墙向右指的箭头](back-wall.png) | ![在柱之间的底部横向指向右侧的箭头](floor.png) |

## **调整 3D 图表的高度比例**

使用 [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) 将 3D 图表的高度设置为其宽度的百分比。这会在不改变幻灯片上图表对象尺寸的情况下调整 3D 场景的比例。

以下示例创建一个 [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 图表，使用默认数据：三个系列和四个类别。它保存三个演示文稿，分别采用 50%、100% 和 200% 的高度比例。图表的位置、宽度和高度保持固定。数据、旋转、深度、系列间距和格式在所有文件中完全相同，唯一变化的是高度百分比。

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

以下图像展示了等效的 .NET 示例中相同的高度设置，均由 Microsoft PowerPoint 导出。较小的百分比产生更平坦的场景，较大的百分比在相同图表对象内产生更高的场景。PowerPoint 可能还会调整坐标轴刻度间隔和标签位置以适应场景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![高度设为宽度 50% 的 3D 柱状图](height_percent_50.png) | ![高度设为宽度 100% 的 3D 柱状图](height_percent_100.png) | ![高度设为宽度 200% 的 3D 柱状图](height_percent_200.png) |

这些方法控制图表的不同方面：

| 方法 | 效果 |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | 3D 场景的高度，占宽度的百分比。 |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | 幻灯片上图表对象的高度，单位为点。 |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 3D 场景的深度，占宽度的百分比。 |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | 系列沿深度轴的间距，占标记宽度的百分比。 |

高度设置影响 3D 柱形和条形图，包括圆柱、圆锥和金字塔变体，以及 3D 折线、面积、饼图和曲面图。上表使用了经验证的 `Column3D` 类型。该设置不会改变 2D `ClusteredColumn` 图表或 `BubbleWith3D` 图表的外观；这些名称是 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 类的成员。有关其他图表外观设置，请参阅 [Chart Formatting](/slides/zh/nodejs-java/chart-formatting/)。

## **调整系列之间的间隙**

使用 [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) 控制 3D 图表中数据系列沿深度轴的距离，表示为标记宽度的百分比。可使用 **0 到 500** 的值（含 0 和 500）：`0` 去除间隙，较大的值则增加间距。深度固定时，增大间隙会使标记在深度轴上变得更细。

通过 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) 访问该组。此设置适用于该组中的所有系列，而不仅仅是用于访问的那个系列。[ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) 返回深度间隙并反映父组的设置。

此设置影响 3D 柱形和条形图，包括其圆柱、圆锥和金字塔变体，以及 3D 折线和面积图。外观取决于系列是按深度、聚类还是堆叠排列。若要清晰比较不同系列之间的间隙，请使用来自 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 类的 `ChartType.Column3D`。

这些方法控制图表的不同方面：

| 方法 | 效果 |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | 系列沿深度轴的间距，占标记宽度的百分比。 |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | 相邻条形或柱形簇之间的间距，占条形或柱形宽度的百分比。 |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 整体图表深度，占图表宽度的百分比。 |

以下独立示例使用默认图表数据，包含三个系列和四个类别。它保存两个演示文稿，数据、旋转、间隙宽度和图表深度完全相同，仅间隙深度不同。

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

以下图像展示了等效的 .NET 示例中相同的间隙深度设置，均由 Microsoft PowerPoint 导出。

| 间隙深度：0% | 间隙深度：500% |
| --- | --- |
| ![沿深度轴系列之间无间隙的 3D 柱状图](gap_depth_0.png) | ![沿深度轴系列之间有 500% 间隙的 3D 柱状图](gap_depth_500.png) |

## **更改 3D 系列类型和条形形状**

在聚类圆柱图中，第一个系列起始为圆柱形条形。示例在每次更改前后打印由 [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) 和 [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) 返回的整数值。下表给出相应的常量名称。

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

| 对第一个系列的更改 | 系列类型 | 条形形状 |
| --- | --- | --- |
| 创建图表 | `ClusteredCylinder` | `Cylinder` |
| 将系列类型设置为 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 将条形形状设置为 `Box` | `ClusteredColumn3D` | `Box` |

将形状设置为 `Box` 还会将系列类型更改为 `ClusteredColumn3D`。如果您的代码根据系列类型分支，请在更改形状后调用 `series.getType()`。在赋值前缓存的值仍会选择 `ClusteredCone` 分支。

![PowerPoint 比较显示第一个系列从左到右分别为圆柱体、圆锥体和矩形柱形](series-shapes.png)

## **常见问题**

**哪些图表类型在 Aspose.Slides 中支持 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 类公开的相关 3D 类型。有关准确、最新的列表，请查看您所使用版本 API 参考中的 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 成员。

**我可以获取 3D 图表的光栅图像用于报告或网页吗？**

可以。您可以使用 [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 将图表导出为图像，或将整个幻灯片 [渲染为 PNG](/slides/zh/nodejs-java/convert-powerpoint-to-png/) 等格式。这在需要光栅预览或将图表嵌入文档、仪表盘、网页而无需 PowerPoint 时非常有用。

**构建和渲染大型 3D 图表的性能如何？**

性能取决于数据量和视觉复杂度。为获得最佳效果，请尽量保持 3D 效果简洁，避免在墙面和绘图区使用大量纹理，尽可能限制每个系列的数据点数量，并将渲染输出设为适当的分辨率和尺寸，以匹配目标显示或打印需求。