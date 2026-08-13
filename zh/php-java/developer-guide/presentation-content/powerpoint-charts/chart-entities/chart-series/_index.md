---
title: 在 PHP 中管理演示文稿的图表数据系列
linktitle: 数据系列
type: docs
url: /zh/php-java/chart-series/
keywords:
- 图表系列
- 系列重叠
- 系列颜色
- 系列名称
- 数据点
- 工作簿单元格
- 系列间隙
- 负值
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 PHP 在演示文稿中管理图表系列、数据点、工作簿单元格、格式设置、重叠、间隙宽度和负值。"
---
## **概述**

图表将其绘制的数据存储在图表数据工作簿中。一个 [ChartSeries](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/) 代表一组相关值，系列中的每个 [ChartDataPoint](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/) 引用一个或多个工作簿单元格。[ChartCategory](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartcategory/) 对象提供系列共享的标签或分组值。因此，系列名称、类别和点的值都连接到 [ChartDataCell](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/) 对象，而不仅仅以显示文本形式存储。

对于典型的类别图，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，其余单元格存放系列值。传递给 [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdataworkbook/#getCell) 的工作表、行和列索引是从零开始的。这种布局在创建带有默认数据的图表时很有用，但不要假设每个现有图表都使用它。对于已加载的演示文稿，在更改工作簿值之前，请检查系列、类别和数据点引用的单元格。

图表设置有三种不同的范围：

- 系列级别设置，例如 [ChartSeries.getFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getFormat)，为该系列中的所有点提供默认外观。
- 数据点级别设置，例如 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/#getFormat)，覆盖系列外观以作用于单个点。
- 组设置适用于属于同一 [ChartSeriesGroup](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseriesgroup/) 的兼容系列。当需要设置重叠或间隙宽度等选项时，可通过 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getParentSeriesGroup) 访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当同时存在系列和点的格式设置时，点的格式设置优先于该点。

![图表系列-PowerPoint](chart-series-powerpoint.png)

## **设置图表系列的重叠**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getOverlap) 报告 2D 图表中条形或柱形的重叠程度，范围为 -100 到 100%。它是父系列组设置的只读投影。使用 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseriesgroup/#setOverlap) 可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图中不相关的系列组没有影响。

下面的示例为包含第一系列的组设置重叠：

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // 新图表包含示例系列、类别和数值。
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

结果：

![系列重叠效果](series_overlap.png)

## **更改系列填充颜色**

使用 [ChartSeries.getFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getFormat) 设置整个系列的默认填充。如果某个点已经有显式填充，其 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/#getFormat) 设置会覆盖该点的系列填充。

下面的示例为第一系列应用纯蓝色填充：

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

结果：

![系列颜色效果](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚类柱形图创建的默认工作簿中，单元格 B1 位于第 0 行第 1 列，包含第一系列的名称。以下示例中的命名变量明确了该结构：

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

您也可以更新由 [ChartSeries.getName](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getName) 已引用的单元格。这种做法避免了对现有图表中特定行列的假设：

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

结果：

![系列名称效果](series_name.png)

## **获取自动系列填充颜色**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) 返回根据系列索引和图表样式计算的颜色。这是系列填充未显式定义时使用的颜色。调用该方法仅读取计算出的颜色，不会分配新的填充。

下面的示例打印每个默认系列的自动颜色：

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

默认图表样式的示例输出：

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

具体颜色取决于图表样式和主题。

## **为图表系列设置反转填充颜色**

对于条形、柱形和气泡系列，[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#setInvertIfNegative) 可以在负值时使用不同的填充。将常规系列填充设为实色，启用反转，并通过 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 分配负值颜色。工作簿中的负数保持不变，仅改变其显示颜色。

下面的示例用一个系列替换默认图表数据。工作表第 0 行包含系列名称，第 0 列包含类别名称，第 1 列包含数值：

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

结果：

![反转实色填充颜色效果](inverted_solid_fill_color.png)

您可以通过 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 为单个点启用反转。在下面的示例中，系列的反转被禁用，仅为选中的点启用反转，并为该点分配负值，以便显示效果：

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **清除特定数据点的值**

要使某一点为空而不移除其他点，请将其对应的工作簿单元格设为 `null`。对于柱形图，绘制的值可通过 [ChartDataPoint.getValue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/#getValue) 获得。数据点仍保留在相同的类别位置，但图表会根据空值设置将其视为空白。

下面的示例仅清除第一系列的第二个点：

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

散点图使用单独的 X 和 Y 单元格，气泡图还使用尺寸单元格。仅清除表示您想移除的数值的单元格。不要在想保留其他点时调用 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapointcollection/#clear)，因为该方法会删除集合中的所有数据点。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，以条形或柱形宽度的百分比表示。与重叠类似，它属于父系列组而不是单个系列。对该组调用一次 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseriesgroup/#setGapWidth) 即可。数值越大簇之间的空间越大，数值越小簇越密集。

下面的示例更改间隙宽度并仅保存最终演示文稿：

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

结果：

![间隙宽度效果](gap_width.png)

## **常见问题解答**

**哪些图表类型支持数据系列？**

所有由 [ChartType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/charttype/) 枚举表示的图表类型都使用图表数据，但它们的系列并不全部具有相同的值结构或设置。例如，类别图使用类别和数值，散点图使用 X 与 Y 值，气泡图则额外使用气泡大小。请使用与系列类型对应的数据点创建方法。重叠和间隙宽度等选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[ChartSeriesGroup](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseriesgroup/) 包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过某个系列访问的组的更改不一定会影响图表中的所有系列。

**新创建的图表是否包含默认数据？**

是的。默认情况下，[ShapeCollection.addChart](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/#addChart) 会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。也有重载方法可创建不带默认数据的图表。

**图表对象如何关联到工作簿单元格？**

系列名称、类别标签和数据点值引用 [ChartDataWorkbook](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdataworkbook/) 中的单元格。更改被引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行和系列值行对齐，以便每个点绘制在预期的类别下。

**如何只清除一个点而不是整个系列？**

将相关的数值单元格设为 `null`，即可保留该点的类别位置作为空点。仅在希望删除该系列所有点时才使用 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapointcollection/#clear)。如果同时删除类别，请更新每个系列，使其数值仍与类别集合保持对齐。

**空点如何显示？**

显示方式取决于图表类型以及通过 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/#setDisplayBlanksAs) 配置的值。支持的图表可以将空白显示为间隙、零值或通过连接相邻点来显示。请选择符合演示文稿中缺失数据含义的设置。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，调用 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#setInvertIfNegative) 并设置由 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 返回的颜色。您可以通过 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 为单个点覆盖此行为。这些方法影响显示格式，而非存储的数值。

**当系列和点都被格式化时，哪种格式优先？**

显式的数据点格式化在该点上具有最高优先级。其他点继续使用显式的系列格式，或在未定义系列格式时使用自动的图表样式和主题。组设置（如重叠和间隙宽度）控制布局，不属于点级格式的覆盖。

**图表能够包含的系列数量是否有限制？**

Aspose.Slides 本身没有设置固定的系列数量上限。实际限制取决于演示文稿文件的约束、可用内存、渲染时间以及图表的可读性。

**当柱形间距过近或过远时应如何调整？**

对相应的父系列组调用 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseriesgroup/#setGapWidth)。增大数值可扩大簇之间的间距，减小数值则使簇更紧密。