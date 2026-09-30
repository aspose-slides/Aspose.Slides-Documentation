---
title: 使用 PHP 在演示文稿中自定义图表图例
linktitle: 图表图例
type: docs
url: /zh/php-java/chart-legend/
keywords:
- 图表图例
- 图例位置
- 字体大小
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 定制图表图例，以针对 PowerPoint 演示文稿进行优化并实现个性化的图例格式设置。"
---
## **概述**

Aspose.Slides for PHP via Java 提供在 PowerPoint 演示文稿中自定义图表图例的选项。本文展示了如何定位和设置图例的大小、为整个图例设置字体大小、格式化单个图例项，以及隐藏或恢复选定的项。

FAQ 涵盖了相关行为，包括为图例预留空间、显示多行标签以及从演示主题继承格式设置。

## **图例定位**

使用图例的 [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/)、[setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/)、[setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/)、和 [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) 方法，以相对于图表尺寸的比例指定其位置和大小。

此示例创建一个演示文稿，并在第一张幻灯片上添加一个带有默认数据的簇状柱形图。将所需的图例偏移量和尺寸除以图表的宽度和高度即可转换为相对值：图例相对于图表左上角向右下偏移 50 点，大小为 100 × 100 点。示例使用 `java_values` 将 PHP/Java Bridge 返回的图表尺寸转换为 PHP 数字后再进行除法运算。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // 以相对于图表的方式表达图例的位置和大小。
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **设置图例的字体大小**

使用图例的 [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) 访问其文本格式，并使用 [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) 将字体大小设置为点数。

此示例创建一个带有默认数据的图表，并将图例文本设置为 20 点。它还禁用了垂直坐标轴的自动范围，并将其范围设为 -5 到 10。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **设置单个图例项的字体大小**

使用图例的 [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) 方法返回的集合，可访问特定项的格式。条目索引从零开始，因此索引 `1` 指的是第二个条目。

此示例创建一个默认数据包含至少两个系列的簇状柱形图。它将第二个图例项的文字设为加粗、斜体、20 点蓝色。

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **隐藏单个图例项**

若要在保持数据可见的情况下将辅助系列从图例中排除，请通过 [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/) 调用 [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) 并传入 `true`。这仅隐藏选中的图例项；不会移除系列或其数据点。相比之下，调用 [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) 并传入 `false` 会隐藏整个图例。

下面的示例创建一个包含多个系列的簇状柱形图（使用默认数据），隐藏第二个系列的图例项（索引 `1`），并保存演示文稿。随后通过将 [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) 设为 `false` 恢复该项，并保存第二个副本。两个文件中的柱形均保持可见。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // 恢复相同的条目而不更改图表数据。
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

下面的对比图展示了所有图例项均可见的图表以及第二个图例项被隐藏的情况。第二个系列的柱形保持不变。

![比较：所有图例项均可见的图表 与 第二个图例项隐藏的图表；所有柱形均保持可见。](hide-legend-entry.png)

在柱形图、条形图和折线图中，图例项用于标识系列。对于饼图，图例项标识单个数据点（切片），因此请对选中的切片使用 [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/)。API 为 `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie` 和 `BarOfPie` 图表类型记录了此数据点方法。不要假设它适用于环形图，因为环形图未列入该列表。

## **常见问题**

**我可以让图表为图例预留空间，而不是让它覆盖图表吗？**

可以。调用 [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) 并传入 `false`，即可为图例预留空间，而不是让其覆盖绘图区域。

**我可以创建多行图例标签吗？**

可以。当可用宽度不足时，长标签会自动换行。也可以在系列名称中使用换行符来强制换行。

**如何让图例遵循演示主题的配色方案？**

保持图例的颜色、填充和字体未设置状态，使其能够继承主题格式。显式的格式设置会覆盖相应的主题设置。