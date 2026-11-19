---
title: Android 上演示文稿中自定义 3D 图表
linktitle: 3D 图表
type: docs
url: /zh/androidjava/3d-chart/
keywords:
- 3D 图表
- 旋转
- 深度
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 在 PowerPoint 演示文稿中创建 3D 图表。通过 Java 示例调整旋转、高度比例、图表深度和系列之间的间距。"
---
## **概述**

Aspose.Slides for Android via Java 允许您通过[IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) 方法自定义 3D 图表的视图。本文演示如何调整旋转、高度比例、深度、直角坐标轴以及系列之间的间距，然后将演示文稿保存为 PPTX 格式。

## **设置 3D 图表的旋转和深度**

下面的示例创建一个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 并使用[IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) 在其第一张幻灯片上添加一个堆叠的 3D 柱形图。它用包含各三个值的两个系列替换了默认的系列和类别。工作表索引 `0` 标识图表的第一数据工作表；行 `0` 保存系列名称，列 `0` 保存类别标签。

[setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) 和 [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) 方法分别将图表的旋转设置为 40° 和 270°。[setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) 将其深度设为宽度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) 则启用直角坐标轴而非透视。生成的演示文稿包含已填充数据且具有上述 3D 视图设置的图表。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **调整 3D 图表的高度比例**

使用[IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) 将 3D 图表的高度设置为其宽度的百分比。此操作在不改变幻灯片上图表对象大小的情况下改变 3D 场景的比例。

以下示例创建一个[Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 图表，使用默认数据：三个系列和四个类别。它分别以 50%、100% 和 200% 的高度比例保存了三个演示文稿。图表的位置、宽度和高度保持不变。数据、旋转、深度、系列间距和格式在所有文件中相同；仅高度百分比不同。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

下面的图像展示了等效 .NET 示例中相同高度设置的效果，导出时使用 Microsoft PowerPoint。较小的百分比会产生更扁平的场景，较大的百分比则在相同图表对象内产生更高的场景。PowerPoint 可能还会调整轴刻度间隔和标签位置以适应场景。

| Height: 50% | Height: 100% | Height: 200% |
| --- | --- | --- |
| ![高度设置为宽度 50% 的 3D 柱形图](height_percent_50.png) | ![高度设置为宽度 100% 的 3D 柱形图](height_percent_100.png) | ![高度设置为宽度 200% 的 3D 柱形图](height_percent_200.png) |

这些方法控制图表的不同方面：

| Method | Effect |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | 3D 场景的高度占宽度的百分比。 |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | 幻灯片上图表对象的高度（单位：点）。 |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 3D 场景的深度占宽度的百分比。 |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 沿深度轴的系列间距，按标记宽度的百分比计算。 |

高度设置影响 3D 柱形图和条形图，包括圆柱、圆锥和金字塔等变体，以及 3D 折线图、面积图、饼图和曲面图。上面的比较使用了已验证的 `Column3D` 类型。该设置不会改变 2D `ClusteredColumn` 图表或 `BubbleWith3D` 图表的外观；这些名称是 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 类的成员。有关其他图表外观设置，请参阅[Chart Formatting](/slides/zh/androidjava/chart-formatting/)。

## **调整系列之间的间距**

使用[IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) 可以控制 3D 图表中沿深度轴的系列之间的距离，以标记宽度的百分比表示。取值范围为 **0 到 500**（含），`0` 表示去除间距，数值越大间距越大。深度固定时，增大间距会使标记在深度轴上变得更细。

通过[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) 访问组。该设置会应用于该组中的所有系列，而不仅限于用于访问它的系列。 [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) 返回深度间距并反映父组的设置。

此设置影响 3D 柱形图和条形图，包括其圆柱、圆锥和金字塔变体，以及 3D 折线图和面积图。外观取决于系列是按深度排列、簇状还是堆叠。若要直观比较不同系列之间的间距，请使用来自 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 类的 `ChartType.Column3D`。

这些方法控制图表的不同方面：

| Method | Effect |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 沿深度轴的系列间距，按标记宽度的百分比计算。 |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | 相邻条形或柱形簇之间的间距，按条形或柱形宽度的百分比计算。 |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 整体图表深度，占图表宽度的百分比。 |

下面的独立示例使用默认图表数据（包含三个系列和四个类别），保存了两份演示文稿，数据、旋转、间距宽度和图表深度均相同，仅间距深度不同。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

下面的图像展示了等效 .NET 示例中相同间距深度设置的效果，导出时使用 Microsoft PowerPoint。

| Gap depth: 0% | Gap depth: 500% |
| --- | --- |
| ![沿深度轴系列之间无间距的 3D 柱形图](gap_depth_0.png) | ![沿深度轴系列之间间距为 500% 的 3D 柱形图](gap_depth_500.png) |

## **更改 3D 系列类型和条形形状**

在簇状圆柱图中，第一系列默认使用圆柱形条。示例在每次更改前后打印[IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) 和[IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) 返回的整数值。下表给出对应的常量名称。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Change to the first series | Series type | Bar shape |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

将形状设置为 `Box` 也会将系列类型更改为 `ClusteredColumn3D`。如果代码根据系列类型进行分支，请在更改形状后调用 `series.getType()`。在赋值前缓存的值仍会导致选择 `ClusteredCone` 分支。

![PowerPoint 对比图，显示第一系列从左至右分别为圆柱、圆锥和矩形柱形](series-shapes.png)

## **常见问题**

**哪些图表类型在 Aspose.Slides 中支持 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 类公开的相关 3D 类型。要获取准确、最新的列表，请检查已安装版本 API 参考中的 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 成员。

**我可以获取 3D 图表的栅格图像用于报告或网络吗？**

可以。您可以使用[Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) 将图表导出为图像，或[渲染整个幻灯片](/slides/zh/androidjava/convert-powerpoint-to-png/) 为 PNG、JPEG 等格式。当需要栅格预览或将图表嵌入文档、仪表板或网页而不依赖 PowerPoint 时，这非常有用。

**构建和渲染大型 3D 图表的性能如何？**

性能取决于数据量和视觉复杂度。为获得最佳效果，请尽量减少 3D 效果，避免在墙面和绘图区域使用大量纹理，尽可能限制每个系列的数据点数量，并将渲染输出的分辨率和尺寸设置为匹配目标显示或打印需求的大小。