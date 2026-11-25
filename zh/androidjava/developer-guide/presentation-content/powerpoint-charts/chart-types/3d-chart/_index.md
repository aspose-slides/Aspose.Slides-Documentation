---
title: 在 Android 上自定义演示文稿中的 3D 图表
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
description: "使用 Aspose.Slides for Android via Java 在 PowerPoint 演示文稿中创建 3D 图表。通过 Java 示例调整旋转、高度比例、图表深度以及系列间距。"
---
## **概述**

Aspose.Slides for Android via Java 允许您通过 [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) 方法自定义 3D 图表的视图。本文演示如何调整旋转、高度比例、深度、直角坐标轴以及系列之间的间距，然后以 PPTX 格式保存演示文稿。

## **设置 3D 图表的旋转和深度**

下面的示例创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 并使用 [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) 在其第一张幻灯片上添加一个堆叠的 3D 柱状图。它用两个每个包含三个值的系列替换了默认的系列和类别。工作表索引 `0` 指示图表的第一个数据工作表；行 `0` 保存系列名称，列 `0` 保存类别标签。

[setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) 和 [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) 方法分别将图表的旋转设置为 40° 和 270°。[setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) 将其深度设置为宽度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) 则启用直角坐标轴而非透视。生成的演示文稿包含具有这些 3D 视图设置的填充图表。

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

## **对 3D 图表表面应用图片填充**

3D 图表有三个可独立填充的表面：[侧墙](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getSideWall--)、[后墙](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--)，和 [底面](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--)。将表面的 [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) 设置为 `Picture` 并指定图像。将 [picture fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) 和表面的 [picture type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartwall/#setPictureType-int-) 都设置为 `Stretch`，以使单张图像拉伸填满表面。

将 [arrow.png](arrow.png) 保存在工作目录中。示例旋转图表并提升垂直轴的最大值，以便在柱形之间可见底面。随后将幻灯片克隆两次，并在每张幻灯片上将箭头应用于不同的表面。所有三个图表保持相同的数据、视角和背景。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try (FileInputStream image = new FileInputStream("arrow.png")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    IPPImage arrow = presentation.getImages().addImage(image);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint 如下显示这三张幻灯片。

| 侧墙 | 后墙 | 底面 |
| --- | --- | --- |
| ![沿侧墙指向图表的箭头](side-wall.png) | ![横跨后墙向右的箭头](back-wall.png) | ![在柱形之间横跨底面向右的箭头](floor.png) |

## **调整 3D 图表的高度比例**

使用 [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) 将 3D 图表的高度设为其宽度的百分比。此操作在不改变幻灯片上图表对象大小的情况下更改 3D 场景的比例。

下面的示例创建一个带有默认数据的 [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 图表：三个系列和四个类别。它保存了高度比例分别为 50%、100% 和 200% 的三个演示文稿。图表的位置、宽度和高度保持不变。所有三个文件的数据、旋转、深度、系列间距和格式均相同；仅高度百分比不同。

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

下图显示了等效 .NET 示例中相同高度设置的效果，图像由 Microsoft PowerPoint 导出。较小的百分比产生更平坦的场景，较大的百分比在相同图表对象内产生更高的场景。PowerPoint 可能还会调整坐标轴刻度间隔和标签位置以适应场景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![高度设为宽度 50% 的 3D 柱状图](height_percent_50.png) | ![高度设为宽度 100% 的 3D 柱状图](height_percent_100.png) | ![高度设为宽度 200% 的 3D 柱状图](height_percent_200.png) |

这些方法控制图表的不同方面：

| 方法 | 作用 |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | 3D 场景的高度占宽度的百分比。 |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | 幻灯片上图表对象的高度（单位：磅）。 |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 3D 场景的深度占宽度的百分比。 |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 沿深度轴的系列间距，以标记宽度的百分比表示。 |

高度设置影响 3D 柱形图和条形图，包括圆柱、圆锥和金字塔等变体，以及 3D 折线图、面积图、饼图和曲面图。上述比较使用了已验证的 `Column3D` 类型。此设置不会改变 2D `ClusteredColumn` 图或 `BubbleWith3D` 图的外观；这些名称是 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 类的成员。有关其他图表外观设置，请参阅 [Chart Formatting](/slides/zh/androidjava/chart-formatting/)。

## **调整系列之间的间隙**

使用 [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) 控制 3D 图表中数据系列沿深度轴的距离，以标记宽度的百分比表示。可使用 **0 到 500** 之间的值（含 0 和 500）：`0` 去除间隙，较大的值会增加间距。在固定的图表深度下，增大间隙会使标记在深度轴上变得更纤细。

通过 [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) 访问该组。此设置适用于该组中的所有系列，而不仅限于用于访问的系列。[IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) 返回深度间隙并反映父组的设置。

此设置影响 3D 柱形图和条形图，包括其圆柱、圆锥和金字塔变体，以及 3D 折线图和面积图。外观取决于系列是深度排列、聚类还是堆叠。若要清晰比较不同系列之间的间隙，请使用来自 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 类的 `ChartType.Column3D`。

这些方法控制图表的不同方面：

| 方法 | 作用 |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 沿深度轴的系列间距，以标记宽度的百分比表示。 |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | 相邻柱或条形簇之间的间距，以柱或条形宽度的百分比表示。 |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 整体图表深度，以图表宽度的百分比表示。 |

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

下面的独立示例使用默认图表数据，其中包含三个系列和四个类别。它保存了两个演示文稿，数据、旋转、间隙宽度和图表深度均相同，唯一变化的是间隙深度。

下图展示了等效 .NET 示例中相同间隙深度设置的效果，图像由 Microsoft PowerPoint 导出。

| 间隙深度：0% | 间隙深度：500% |
| --- | --- |
| ![深度轴上系列之间无间隙的 3D 柱状图](gap_depth_0.png) | ![深度轴上系列之间有 500% 间隙的 3D 柱状图](gap_depth_500.png) |

## **更改 3D 系列类型和条形形状**

在聚类圆柱图中，第一系列的条形形状起始为圆柱形。示例在每次更改前后打印 [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) 和 [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) 返回的整数值。下表给出了对应的常量名称。

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

| 对第一系列的更改 | 系列类型 | 条形形状 |
| --- | --- | --- |
| 创建图表 | `ClusteredCylinder` | `Cylinder` |
| 将系列类型设置为 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 将条形形状设置为 `Box` | `ClusteredColumn3D` | `Box` |

将形状设置为 `Box` 还会将系列类型更改为 `ClusteredColumn3D`。如果代码根据系列类型分支，请在更改形状后调用 `series.getType()`。在赋值之前缓存的值仍会选择 `ClusteredCone` 分支。

![PowerPoint 对比，左至右分别显示第一系列的圆柱、圆锥和矩形柱形](series-shapes.png)

## **常见问题**

**哪些图表类型在 Aspose.Slides 中支持 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 类公开的相关 3D 类型。有关确切且最新的列表，请查看已安装版本的 API 参考中的 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 成员。

**我可以获取 3D 图表的光栅图像用于报告或网页吗？**

可以。您可以使用 [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) 将图表导出为图像，或将整个幻灯片 [渲染为 PNG 或 JPEG](/slides/zh/androidjava/convert-powerpoint-to-png/) 等格式。这在需要光栅预览或将图表嵌入文档、仪表板或网页且不依赖 PowerPoint 时非常有用。

**构建和渲染大型 3D 图表的性能如何？**

性能取决于数据量和视觉复杂度。为获得最佳效果，建议尽量减少 3D 效果，避免在墙面和绘图区域使用大量纹理，尽可能限制每个系列的数据点数量，并将渲染输出尺寸（分辨率和尺寸）设置为匹配目标显示或打印需求的大小。