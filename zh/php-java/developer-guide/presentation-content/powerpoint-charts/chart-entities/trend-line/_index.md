---
title: 在 PHP 中向演示文稿图表添加趋势线
linktitle: 趋势线
type: docs
url: /zh/php-java/trend-line/
keywords:
- 图表
- 趋势线
- 指数趋势线
- 线性趋势线
- 对数趋势线
- 移动平均趋势线
- 多项式趋势线
- 幂趋势线
- 自定义趋势线
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 图表中快速添加和自定义趋势线——帮助您吸引观众的实用指南。"
---
## **概述**

本文介绍如何使用 Aspose.Slides 向演示文稿图表添加趋势线。它展示了如何创建图表、向图表系列添加趋势线，并使用多种趋势线类型，包括指数、线性、对数、移动平均、多项式和幂。

它还描述了如何通过插入线形状向图表添加自定义线，并包含一个简短的 FAQ，说明趋势线的前向和后向投影值的含义以及在导出为 PDF 或 SVG 或将图表渲染为图像时趋势线是否会被保留。

## **添加趋势线**

使用 [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) 将趋势线添加到图表系列，并使用 [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/) 选择其类型。示例创建了一个带默认数据的簇状柱形图，并为其三个系列中的每个系列添加了两条趋势线。

指数趋势线通过 [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) 和 [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/) 隐藏其公式和决定系数值，而线性趋势线显示为红色。对数趋势线使用 [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) 设置自定义标签。移动平均使用 [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) 设置为三个数据点，并使用自定义的 [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/)。

多项式趋势线的阶数为三，通过 [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/) 设置，并通过 [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/) 向前延伸一个类别。幂趋势线通过 [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/) 向后延伸一个类别。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **设置趋势线截距**

使用 [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) 将趋势线的 Y 值固定在 X = 0。此设置支持线性、指数和多项式趋势线。

例如，生产成本模型可能需要在已知的固定成本 100 开始，即使在非零生产量的测量值暗示不同的基准。对于线性趋势线，将截距固定为 `b = 100`，约束方程 `y = ax + b` 中的 b 为 100；斜率在此约束下拟合数据。它并不是简单地移动已经拟合好的直线。坐标轴交叉设置控制图表坐标轴的相交位置，而不是已拟合趋势线的系数。

下面的示例创建一个散点 (XY) 图，生产量从 1 到 4，成本分别为 170、200、230 和 260。它使用默认的自动截距保存图表，然后将截距设置为 100 并保存第二个 PPTX。这两个文件仅在截距设置上有所不同。趋势线显示其公式并向后延伸至 X = 0。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

使用自动计算时，这些数据得到 `y = 30x + 140`。将截距设置为 100 则大约得到 `y = 43.33x + 100`：零点的拟合值匹配已知基准，而直线不再经过每个数据点。

| 自动截距 | 截距固定为 100 |
| --- | --- |
| ![线性趋势线，自动计算的截距为 140](intercept-automatic.png) | ![线性趋势线，截距固定为 100](intercept-fixed.png) |

两幅图像使用相同的数据和坐标轴比例。趋势线被延伸回 X = 0 以展示其截距。

默认情况下，[getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) 返回 `NaN`，表示截距未指定而非零。随后截距会根据数据自动计算。

## **添加自定义线**

自定义线是绘制在图表上的形状，而不是从系列数据计算得到的趋势线。此示例使用 [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) 在幻灯片上图表之上添加一条水平线。该线的位置以幻灯片坐标（点）指定，因此从图表左边缘开始，位于图表中部。其宽度与图表宽度相同。[getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) 为该线设置了实线红色。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常见问题**

**趋势线的“前向”和“后向”是什么意思？**

它们是趋势线向前/向后投影的长度：对于散点 (XY) 图，以坐标轴单位表示；对于非散点图，以类别数表示。仅允许非负值。

**在将演示文稿导出为 PDF 或 SVG，或将幻灯片渲染为图像时，趋势线会被保留吗？**

会。Aspose.Slides 能将演示文稿转换为 [PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/) 或 [SVG](/slides/zh/php-java/render-a-slide-as-an-svg-image/)，并将图表渲染为图像；趋势线作为图表的一部分在这些操作中会被保留。还提供了一个方法，可 [导出图表的图像](/slides/zh/php-java/create-shape-thumbnails/)。