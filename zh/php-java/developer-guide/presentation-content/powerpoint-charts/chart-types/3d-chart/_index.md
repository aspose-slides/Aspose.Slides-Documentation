---
title: 使用 PHP 在演示文稿中自定义 3D 图表
linktitle: 3D 图表
type: docs
url: /zh/php-java/3d-chart/
keywords:
- 3D 图表
- 旋转
- 深度
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中创建 3D 图表。通过 PHP 示例调整旋转、 高度比例、 图表深度和系列之间的间距。"
---
## **概述**

Aspose.Slides for PHP via Java 允许您通过 [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) 方法自定义 3D 图表的视图。本文演示如何调整旋转、 高度比例、 深度、 直角坐标轴以及系列之间的间距，然后将演示文稿保存为 PPTX 格式。

## **设置 3D 图表的旋转和深度**

下面的示例创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 并使用 [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) 在其第一张幻灯片上添加一个堆叠的 3D 柱形图。它用两个系列（每个系列包含三个值）替换了默认的系列和类别。工作表索引 `0` 标识图表的第一个数据工作表；行 `0` 保存系列名称，列 `0` 保存类别标签。

[setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) 和 [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) 方法分别将图表的旋转设置为 40 度和 270 度。[setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) 将深度设置为宽度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) 则启用直角坐标轴而非透视。生成的演示文稿包含了具有这些 3D 视图设置的填充图表。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **调整 3D 图表的高度比例**

使用 [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) 将 3D 图表的高度设为宽度的百分比。这会在不改变幻灯片上图表对象大小的情况下修改 3D 场景的比例。

下面的示例创建一个默认数据的 [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 图表：三个系列和四个类别。它分别以高度比例 50%、100% 和 200% 保存三个演示文稿。图表的位置、宽度和高度保持不变。数据、旋转、深度、系列间距和格式在所有文件中完全相同，唯一变化的是高度百分比。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

以下图像展示了等效 .NET 示例中相同的高度设置，导出时使用 Microsoft PowerPoint。较小的百分比会生成更扁平的场景，而较大的百分比会在相同的图表对象内生成更高的场景。PowerPoint 可能还会调整坐标轴刻度间隔和标签位置以适应场景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![高度设置为其宽度 50% 的 3D 柱形图](height_percent_50.png) | ![高度设置为其宽度 100% 的 3D 柱形图](height_percent_100.png) | ![高度设置为其宽度 200% 的 3D 柱形图](height_percent_200.png) |

这些方法控制图表的不同方面：

| 方法 | 作用 |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | 将 3D 场景的高度设为宽度的百分比。 |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | 设置幻灯片上图表对象的高度（单位：磅）。 |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 将 3D 场景的深度设为宽度的百分比。 |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | 按标记宽度的百分比设置系列在深度轴上的间距。 |

高度设置影响 3D 柱形图和条形图，包括圆柱体、圆锥体和金字塔变体，以及 3D 折线图、面积图、饼图和曲面图。上表使用经过验证的 `Column3D` 类型。该设置不会改变 2D `ClusteredColumn` 图表或 `BubbleWith3D` 图表的外观；这些名称是 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 类的成员。有关其他图表外观设置，请参阅 [Chart Formatting](/slides/zh/php-java/chart-formatting/)。

## **调整系列之间的间隙**

使用 [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) 控制 3D 图表中数据系列在深度轴上的距离，以标记宽度的百分比表示。取值范围为 **0 到 500**（含），`0` 表示无间隙，数值越大间距越大。深度固定时，增大间隙会使标记在深度轴上看起来更薄。

通过 [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) 访问所属组。此设置会应用于该组中的所有系列，而不仅仅是用于访问它的系列。[ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) 返回深度间隙并反映父组的设置。

此设置影响 3D 柱形图和条形图，包括它们的圆柱体、圆锥体和金字塔变体，以及 3D 折线图和面积图。外观取决于系列是按深度排列、聚类还是堆叠。要对不同系列之间的间隙进行直观比较，请使用来自 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 类的 `ChartType::Column3D`。

这些方法控制图表的不同方面：

| 方法 | 作用 |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | 按标记宽度的百分比设置系列在深度轴上的间距。 |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | 按柱/条宽度的百分比设置相邻柱或条簇之间的间距。 |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 按图表宽度的百分比设置整体图表深度。 |

下面的完整示例使用默认图表数据（包含三个系列和四个类别），保存了两个演示文稿，它们在数据、旋转、间隙宽度和图表深度上完全相同，唯一变化的是间隙深度。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

以下图像展示了等效 .NET 示例中相同的间隙深度设置，导出时使用 Microsoft PowerPoint。

| 间隙深度：0% | 间隙深度：500% |
| --- | --- |
| ![在深度轴上系列之间无间隙的 3D 柱形图](gap_depth_0.png) | ![在深度轴上系列之间间隙为 500% 的 3D 柱形图](gap_depth_500.png) |

## **更改 3D 系列类型和条形形状**

在聚类圆柱体图中，第一系列默认使用圆柱形条。示例在每次更改前后打印 [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) 和 [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) 返回的整数值。下表给出了对应的常量名称。

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| 对第一系列的更改 | 系列类型 | 条形形状 |
| --- | --- | --- |
| 创建图表 | `ClusteredCylinder` | `Cylinder` |
| 将系列类型设为 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 将条形形状设为 `Box` | `ClusteredColumn3D` | `Box` |

将形状设为 `Box` 还会将系列类型更改为 `ClusteredColumn3D`。如果代码根据系列类型进行分支，请在更改形状后调用 [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/)；在赋值前缓存的值仍会导致选择 `ClusteredCone` 分支。

![PowerPoint 对比图，左至右分别显示第一系列为圆柱、圆锥和矩形柱形](series-shapes.png)

## **常见问题解答**

**哪些图表类型在 Aspose.Slides 中支持 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 类公开的相关 3D 类型。欲获取准确且最新的列表，请查看已安装版本的 API 参考中的 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 成员。

**我可以获取 3D 图表的光栅图像用于报告或网页吗？**

可以。您可以使用 [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) 将图表导出为图像，或将整张幻灯片 [render the entire slide](/slides/zh/php-java/convert-powerpoint-to-png/) 为 PNG、JPEG 等格式。当需要光栅预览或在文档、仪表板、网页中嵌入图表且不依赖 PowerPoint 时，此方式非常有用。

**构建和渲染大规模 3D 图表的性能如何？**

性能受数据量和视觉复杂度影响。为获得最佳效果，请尽量减少 3D 效果，避免在墙面和绘图区域使用大量纹理，尽可能限制每个系列的数据点数量，并将输出分辨率和尺寸设为与目标显示或打印需求相匹配的大小。