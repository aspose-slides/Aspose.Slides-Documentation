---
title: 使用 PHP 管理演示文稿中的图表数据标签
linktitle: 数据标签
type: docs
url: /zh/php-java/chart-data-label/
keywords:
- 图表
- 数据标签
- 数据精度
- 百分比
- 标签距离
- 标签位置
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "学习使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中添加和格式化图表数据标签，以创建更具吸引力的幻灯片。"
---
## **简介**

数据标签显示有关图表系列和单个数据点的信息，帮助读者识别数值并理解图表。本文说明如何格式化数值、显示百分比、读取标签文本、控制超出坐标轴最大值的标签、调整类目坐标轴标签间距以及定位饼图标签。

## **在图表数据标签中设置数据精度**

使用 [setNumberFormatOfValues](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#setNumberFormatOfValues) 来格式化系列值。此示例创建一个默认数据的折线图，显示其数据表，并为第一系列启用数值标签。格式 `#,##0.00` 显示千位分隔符和两位小数，而不更改底层数值。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->setNumberFormatOfValues("#,##0.00");
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("PrecisionOfDatalabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **将百分比显示为标签**

对于堆积柱形图，计算每个数值相对于其类目总和的百分比，并将文本分配给 [getTextFrameForOverriding](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datalabel/#getTextFrameForOverriding) 返回的文本框。此示例使用默认图表数据，并以 8 磅字体显示保留两位小数的百分比。总和为零的类目会被跳过，以避免除以零。如果图表数据更改，需要重新计算自定义标签文本。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\Portion;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);

    $categoryCount = java_values($chart->getChartData()->getCategories()->size());
    $categoryTotals = array_fill(0, $categoryCount, 0.0);
    for ($k = 0; $k < $categoryCount; $k++) {
        for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
            $series = $chart->getChartData()->getSeries()->get_Item($i);
            $pointValue = java_values($series->getDataPoints()->get_Item($k)->getValue()->getData());
            $categoryTotals[$k] += $pointValue;
        }
    }

    for ($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()); $x++) {
        $series = $chart->getChartData()->getSeries()->get_Item($x);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);

        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $label = $series->getDataPoints()->get_Item($j)->getLabel();
            if ($categoryTotals[$j] == 0) {
                continue;
            }

            $pointValue = java_values($series->getDataPoints()->get_Item($j)->getValue()->getData());
            $dataPointPercent = ($pointValue / $categoryTotals[$j]) * 100;

            $portion = new Portion();
            $portion->setText(sprintf("%.2F %%", $dataPointPercent));
            $portion->getPortionFormat()->setFontHeight(8);

            $label->getTextFrameForOverriding()->setText("");
            $paragraph = $label->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
            $paragraph->getPortions()->add($portion);

            $label->getDataLabelFormat()->setShowValue(true);
            $label->getDataLabelFormat()->setShowSeriesName(false);
            $label->getDataLabelFormat()->setShowPercentage(false);
            $label->getDataLabelFormat()->setShowLegendKey(false);
            $label->getDataLabelFormat()->setShowCategoryName(false);
            $label->getDataLabelFormat()->setShowBubbleSize(false);
        }
    }

    $presentation->save("DisplayPercentageAsLabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在图表数据标签中设置百分号**

当数值以分数形式存储时，使用 [setNumberFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datalabelformat/#setNumberFormat) 来显示百分比。向 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) 传入 `false`，可以使标签格式独立于源单元格。

此示例创建一个 100% 堆积柱形图，包含四个类目中的红色和蓝色系列。每对数值之和为 1。标签格式 `0.0%` 将 0.30 显示为 30.0%，而纵坐标轴使用两位小数。两个系列均使用白色、10 磅的标签文字。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    for ($i = 0; $i < 4; $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    $colors = java("java.awt.Color");
    $seriesNames = [ "Reds", "Blues" ];
    $seriesColors = [ $colors->RED, $colors->BLUE ];
    $values = [ [ 0.30, 0.50, 0.80, 0.65 ], [ 0.70, 0.50, 0.20, 0.35 ] ];

    for ($i = 0; $i < count($seriesNames); $i++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $i + 1, $seriesNames[$i]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());
        for ($j = 0; $j < 4; $j++) {
            $valueCell = $workbook->getCell($worksheetIndex, $j + 1, $i + 1, $values[$i][$j]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        $series->getFormat()->getFill()->setFillType(FillType::Solid);
        $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColors[$i]);

        $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(false);
        $labelFormat->setNumberFormat("0.0%");
        $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(10);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($colors->WHITE);
    }

    $presentation->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **读取数据标签的实际文本**

使用 [getActualLabelText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datalabel/#getActualLabelText) 获取数据标签设置产生的文本。当需要为报告提取标签、搜索演示文稿内容或验证生成的图表时，这非常有用。下例中，默认的 [data label format](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datalabelformat/) 将每个类目名称、系列名称和数值组合在一起。一个点将其数值格式化为百分比，另一个点使用来自 [getTextFrameForOverriding](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datalabel/#getTextFrameForOverriding) 的自定义文本。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $firstCategoryCell = $workbook->getCell(0, 1, 0, "Q1");
    $chart->getChartData()->getCategories()->add($firstCategoryCell);
    $secondCategoryCell = $workbook->getCell(0, 2, 0, "Q2");
    $chart->getChartData()->getCategories()->add($secondCategoryCell);

    $northSeriesCell = $workbook->getCell(0, 0, 1, "North");
    $north = $chart->getChartData()->getSeries()->add($northSeriesCell, $chart->getType());
    $northFirstValueCell = $workbook->getCell(0, 1, 1, 0.25);
    $north->getDataPoints()->addDataPointForBarSeries($northFirstValueCell);
    $northSecondValueCell = $workbook->getCell(0, 2, 1, 0.75);
    $north->getDataPoints()->addDataPointForBarSeries($northSecondValueCell);

    $southSeriesCell = $workbook->getCell(0, 0, 2, "South");
    $south = $chart->getChartData()->getSeries()->add($southSeriesCell, $chart->getType());
    $southFirstValueCell = $workbook->getCell(0, 1, 2, 0.40);
    $south->getDataPoints()->addDataPointForBarSeries($southFirstValueCell);
    $southSecondValueCell = $workbook->getCell(0, 2, 2, 0.60);
    $south->getDataPoints()->addDataPointForBarSeries($southSecondValueCell);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        $format = $series->getLabels()->getDefaultDataLabelFormat();
        $format->setShowCategoryName(true);
        $format->setShowSeriesName(true);
        $format->setShowValue(true);
    }

    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormat("0%");
    $south->getLabels()->get_Item(0)->getTextFrameForOverriding()->setText("Reviewed");

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $point = $series->getDataPoints()->get_Item($j);
            $label = $point->getLabel();
            if (!java_values($label->isVisible())) {
                continue;
            }

            echo "Value: " . java_values($point->getValue()->getData()) . "; label: " . java_values($label->getActualLabelText()) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

数据点中存储的数值仍为 `0.75`，即使其标签显示为 `75%` 并附带类目和系列名称。自定义文本会替换生成的标签文本。无论哪种情况，[getActualLabelText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datalabel/#getActualLabelText) 都返回最终的标签字符串。需要仅提取可见标签时，请单独检查 [isVisible](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datalabel/#isVisible)，如上例所示。

## **控制坐标轴最大值之外的数据标签**

手动限制坐标轴范围时，某些数据点可能超出其最大值。使用 [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) 来控制是否显示这些数据标签。此设置仅改变标签可见性，不会改变坐标轴范围或底层数据值。

下面的示例创建一个 2D 群集柱形图，数值为 60 和 120。它向 [setAutomaticMaxValue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/axis/#setAutomaticMaxValue) 传入 `false`，并在纵坐标轴上使用 [setMaxValue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/axis/#setMaxValue) 将最大值设为 100。第一张幻灯片允许标签超出最大值；其复制版禁用了此功能。两张幻灯片均保存为 `DataLabelsOverMaximum.pptx`。

使用 [setShowValue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datalabelformat/#setShowValue) 启用数值标签。图表级别的设置本身并不会启用数值显示，也不会覆盖单个标签被禁用的数值显示。此示例为整个系列启用数值，并使用 [setPosition](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datalabelformat/#setPosition) 将标签放置在每根柱子的外端。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $firstCategory = $workbook->getCell(0, 1, 0, "Within range");
    $secondCategory = $workbook->getCell(0, 2, 0, "Above maximum");

    $chart->getChartData()->getCategories()->add($firstCategory);
    $chart->getChartData()->getCategories()->add($secondCategory);

    $seriesName = $workbook->getCell(0, 0, 1, "Values");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());

    $firstValue = $workbook->getCell(0, 1, 1, 60);
    $secondValue = $workbook->getCell(0, 2, 1, 120);

    $series->getDataPoints()->addDataPointForBarSeries($firstValue);
    $series->getDataPoints()->addDataPointForBarSeries($secondValue);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);

    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(100);
    $chart->setShowDataLabelsOverMaximum(true);

    $secondSlide = $presentation->getSlides()->addClone($slide);
    $secondChart = $secondSlide->getShapes()->get_Item(0);
    $secondChart->setShowDataLabelsOverMaximum(false);

    $presentation->save("DataLabelsOverMaximum.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

下图展示了 Microsoft PowerPoint 渲染的保存后幻灯片。`true` 时，标签 **120** 在上边界可见；`false` 时，它被隐藏。标签 **60** 始终可见，坐标轴最大值保持 **100**，第二个数据点在两种情况下均为 **120**。

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
此示例使用带值轴的 2D 柱形图。没有值轴的图表，如饼图和环形图，无法通过这种方式设置坐标轴最大值限制。
{{% /alert %}}

## **设置标签距离坐标轴的距离**

使用 [setLabelOffset](https://reference.aspose.com/slides/zh/php-java/aspose.slides/axis/#setLabelOffset) 控制类目坐标轴标签与坐标轴之间的距离。该值为坐标轴标签最大字体大小的百分比。此示例创建一个群集柱形图，并将横坐标轴标签偏移设置为 500。此设置影响类目坐标轴标签，而不是附加在单个数据点上的标签。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $chart->getAxes()->getHorizontalAxis()->setLabelOffset(500);

    $presentation->save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **调整标签位置**

在饼图上，调整数据标签位置以改善间距并为指引线留出空间。

此示例显示第一个数据点的数值，将其标签放置在切片外部，并使用 [setX](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datalabel/#setX) 和 [setY](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datalabel/#setY) 调整水平和垂直偏移。这些偏移量分别相对于图表的宽度和高度。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();

    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![已调整数据标签位置的饼图](pie-chart-adjusted-label.png)

## **常见问题**

**如何防止数据标签在密集图表上重叠？**  
结合自动标签布局、指引线和减小字体大小；必要时隐藏某些字段（例如类目），或仅为极值或关键点显示标签。

**如何仅对零、负数或空值禁用标签？**  
在启用标签之前过滤数据点，并根据定义的规则关闭对值为 0、负数或缺失值的显示。

**如何在导出为 PDF/图片时确保标签样式一致？**  
显式设置字体族和大小，并确认渲染环境中存在该字体，以避免回退。