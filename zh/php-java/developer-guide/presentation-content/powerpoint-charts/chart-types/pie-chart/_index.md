---
title: 使用 PHP 在演示文稿中自定义饼图
linktitle: 饼图
type: docs
url: /zh/php-java/pie-chart/
keywords:
- 饼图
- 管理图表
- 自定义图表
- 图表选项
- 图表设置
- 绘图选项
- 切片颜色
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中创建和自定义饼图。配置二级绘图区，显示数据标签，并在 PowerPoint 中应用自动切片颜色。"
---
## **概述**

本文说明了如何在 Aspose.Slides 中使用饼图。它展示了如何为 Pie of Pie 和 Bar of Pie 图表配置二级绘图区选项，以及如何为标准饼图启用自动切片着色。

示例侧重于图表自定义任务，例如向幻灯片添加图表、调整系列和标签设置、用自定义类别和值替换默认图表数据，以及保存更新后的演示文稿。

## **Pie of Pie 和 Bar of Pie 图表的二级绘图区选项**

Aspose.Slides for PHP via Java 支持 Pie of Pie 和 Bar of Pie 图表的二级绘图区选项。这些选项控制二级绘图区的大小以及数据点在两个绘图区之间的分割方式。

下面的示例在新演示文稿中创建了一个 Pie of Pie 图表，并将数据点值显示为标签。**[setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize)** 方法将二级绘图区大小设置为主绘图区的 149%。**[setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy)** 选择基于百分比的拆分，**[setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition)** 将阈值设为 53%。

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // 显示数值并配置二级绘图区。
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **为二级绘图区选择类别**

当您希望在二级绘图区中对特定类别进行分组，而不考虑它们的百分比值时，请使用自定义拆分。例如，销售报告可能会将 Online 和 Events 放在一起，以便读者比较这两个渠道，即使它们分别占总销售额的 35% 和 10%。

使用 **[setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy)** 并传入 **[PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/)**，然后通过 **[getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints)** 选择点。集合的 **[add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add)** 方法接受系列中的零基索引；使用 **[addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem)** 添加数据点对象。在本例中，索引 1 选择 Online，索引 3 选择 Events。Partners 也被临时添加，然后使用 **[removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem)** 将其排除。

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // 用渠道销售数据替换默认数据。
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // 通过零基索引选择 Online，并通过数据点对象选择 Events。
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // 从选择中排除 Partners，但不删除其源数据。
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online（35）和 Events（10）在二级绘图区中显示为单独的切片。在主绘图区中，它们合并为一个值为 45 的切片， alongside Retail（40）和 Partners（15）。从自定义选择中移除 Partners 只会使其保留在主绘图区；不会从图表的源数据中删除该类别或其值。

以下图像显示了在 PowerPoint 中保存的演示文稿：

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **设置自动饼图切片颜色**

Aspose.Slides for PHP via Java 可以自动为饼图切片分配不同颜色。下面的示例创建了一个带居中标题的饼图，并用三个季度类别及其值替换了默认数据。**[setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue)** 方法将 20、50 和 30 显示为标签，而 **[setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried)** 则为每个切片启用不同颜色。

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // 添加居中的图表标题。
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // 使用第一个工作表替换默认数据。
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // 显示数值并为切片分配不同颜色。
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常见问题**

**是否支持 Pie of Pie 和 Bar of Pie 变体？**

是的，库 **[supports](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)** 二级绘图区，适用于 Pie of Pie 和 Bar of Pie 类型的饼图。

**我可以仅将图表导出为图像（例如 PNG）吗？**

可以，您可以 **[export the chart itself as an image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage)**（如 PNG），而无需导出整个演示文稿。