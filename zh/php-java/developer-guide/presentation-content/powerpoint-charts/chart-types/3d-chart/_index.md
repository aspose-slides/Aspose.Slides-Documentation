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
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中创建 3D 图表。通过 PHP 示例调整旋转、高度比例、图表深度以及系列之间的间距。"
---
## **概述**

Aspose.Slides for PHP via Java 允许您通过 [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) 方法自定义 3D 图表的视图。本文演示如何调整旋转、高度比例、深度、直角坐标轴以及系列之间的间距，然后将演示文稿保存为 PPTX 格式。

## **设置 3D 图表的旋转和深度**

下面的示例创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 并使用 [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) 在其第一张幻灯片上添加一个堆叠的 3D 柱形图。它用两个每个包含三个值的系列替换默认的系列和类别。工作表索引 `0` 表示图表的第一个数据工作表；行 `0` 保存系列名称，列 `0` 保存类别标签。

[setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) 和 [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) 方法分别将图表的旋转设置为 40 度和 270 度。[setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) 将其深度设置为宽度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) 启用直角坐标轴来代替透视。生成的演示文稿包含已填充数据且具有这些 3D 视图设置的图表。

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

## **对 3D 图表表面应用图片填充**

您可以分别填充 3D 图表的 [side wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/)、[back wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/) 和 [floor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/)。将表面的 [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) 设置为 `Picture` 并分配图像。将 [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) 和表面的 [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) 都设置为 `Stretch`，以使图像的一份副本覆盖整个表面。

将 [arrow.png](arrow.png) 保存在 PHP 脚本旁边。示例旋转图表并提升垂直轴的最大值，以便在柱形之间可见底面。随后将幻灯片克隆两次，并在每张幻灯片的不同表面上应用箭头。三个图表保持相同的数据、视角和背景。

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Microsoft PowerPoint 以如下方式显示这三张幻灯片。

| 侧墙 | 背墙 | 底面 |
| --- | --- | --- |
| ![箭头指向侧墙上的图表](side-wall.png) | ![箭头在背墙上向右指](back-wall.png) | ![箭头在柱形之间的底面上向右指](floor.png) |

## **调整 3D 图表的高度比例**

使用 [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) 将 3D 图表的高度设置为其宽度的百分比。这样可以在不更改幻灯片上图表对象大小的情况下改变 3D 场景的比例。

以下示例创建一个带有默认数据（3 个系列和 4 个类别）的 [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 图表。它保存三个演示文稿，分别使用 50%、100% 和 200% 的高度比例。图表的位置、宽度和高度保持不变。数据、旋转、深度、系列间距和格式在所有三个文件中均相同；仅高度百分比不同。

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

以下图像展示了等效 .NET 示例中相同高度设置的效果，已使用 Microsoft PowerPoint 导出。较小的百分比产生更平坦的场景，而较大的百分比在相同图表对象中产生更高的场景。PowerPoint 可能还会调整坐标轴刻度间隔和标签位置以适应场景。

| 高度: 50% | 高度: 100% | 高度: 200% |
| --- | --- | --- |
| ![高度设置为宽度 50% 的 3D 柱形图](height_percent_50.png) | ![高度设置为宽度 100% 的 3D 柱形图](height_percent_100.png) | ![高度设置为宽度 200% 的 3D 柱形图](height_percent_200.png) |

这些方法控制图表的不同方面：

| 方法 | 影响 |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | 3D 场景高度占宽度的百分比。 |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | 幻灯片上图表对象的高度，以点为单位。 |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 3D 场景深度占宽度的百分比。 |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | 沿深度轴的系列间距，以标记宽度的百分比表示。 |

高度设置影响 3D 柱形和条形图，包括圆柱、圆锥和金字塔变体，以及 3D 折线、面积、饼图和曲面图。上面的比较使用了验证过的 `Column3D` 类型。该设置不会改变 2D `ClusteredColumn` 图表或 `BubbleWith3D` 图表的外观；这些名称是 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 类的成员。有关其他图表外观设置，请参阅 [Chart Formatting](/slides/zh/php-java/chart-formatting/)。

## **调整系列之间的间距**

使用 [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) 控制 3D 图表中沿深度轴的数据系列之间的距离，以标记宽度的百分比表示。取值范围为 **0 到 500**（含）：`0` 移除间隙，较大的值会增加间距。在图表深度固定的情况下，增大间隙会使标记在深度轴上更细。

通过 [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) 访问该组。该设置适用于该组中的所有系列，而不仅限于用于访问的系列。[ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) 返回深度间隙并反映父组的设置。

此设置影响 3D 柱形和条形图，包括其圆柱、圆锥和金字塔变体，以及 3D 折线和面积图。外观取决于系列是按深度、簇状还是堆叠排列。若要清晰比较不同系列之间的间隙，请使用来自 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 类的 `ChartType::Column3D`。

这些方法控制图表的不同方面：

| 方法 | 影响 |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | 沿深度轴的系列间距，以标记宽度的百分比表示。 |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | 相邻条形或柱形簇之间的间距，以条形或柱形宽度的百分比表示。 |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 整体图表深度，以图表宽度的百分比表示。 |

以下独立示例使用默认图表数据，包含三个系列和四个类别。它保存两个演示文稿，数据、旋转、间隙宽度和图表深度相同，仅间隙深度不同。

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

以下图像展示了等效 .NET 示例中相同间隙深度设置的效果，已使用 Microsoft PowerPoint 导出。

| 间隙深度: 0% | 间隙深度: 500% |
| --- | --- |
| ![沿深度轴系列之间无间隙的 3D 柱形图](gap_depth_0.png) | ![沿深度轴系列之间有 500% 间隙的 3D 柱形图](gap_depth_500.png) |

## **更改 3D 系列类型和条形形状**

在簇状圆柱图中，第一系列起始为圆柱形条形。示例在每次更改前后打印 [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) 和 [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) 返回的整数值。表格给出相应的常量名称。

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
| 将系列类型设置为 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 将条形形状设置为 `Box` | `ClusteredColumn3D` | `Box` |

将形状设为 `Box` 也会将系列类型更改为 `ClusteredColumn3D`。如果您的代码根据系列类型分支，请在更改形状后调用 [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) 。在赋值前缓存的值仍会选择 `ClusteredCone` 分支。

![PowerPoint 对比显示第一系列从左到右分别为圆柱、圆锥和矩形柱形](series-shapes.png)

## **常见问题**

**哪些图表类型在 Aspose.Slides 中支持 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 类公开的相关 3D 类型。欲获取完整、最新的列表，请在已安装版本的 API 参考中查看 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 成员。

**我可以获取 3D 图表的栅格图像用于报告或网页吗？**

是的。您可以使用 [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) 将图表导出为图像，或使用 [render the entire slide](/slides/zh/php-java/convert-powerpoint-to-png/) 将整张幻灯片渲染为 PNG、JPEG 等格式。当您需要栅格预览或希望在文档、仪表板或网页中嵌入图表且不依赖 PowerPoint 时，这非常有用。

**构建和渲染大型 3D 图表的性能如何？**

性能取决于数据量和视觉复杂度。为获得最佳效果，请尽量减少 3D 效果，避免在墙面和绘图区域使用大量纹理，尽可能限制每个系列的数据点数量，并将渲染输出尺寸（分辨率和尺寸）设定为符合目标显示或打印需求的大小。