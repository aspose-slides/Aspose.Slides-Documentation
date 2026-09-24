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
description: "了解如何使用 PHP 在演示文稿中管理图表系列、数据点、工作簿单元格、格式设置、重叠、间隙宽度以及负值。"
---
## **概述**

图表将其绘制的数据存储在图表数据工作簿中。一个 [ChartSeries](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/) 表示一组相关值，系列中的每个 [ChartDataPoint](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/) 都引用一个或多个工作簿单元格。[ChartCategory](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartcategory/) 对象提供系列共享的标签或分组值。因此，系列名称、分类和点值连接到 [ChartDataCell](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/) 对象，而不仅仅存储为显示文本。

对于典型的分类图，默认工作簿使用第 0 行存放系列名称，第 0 列存放分类名称，其余单元格存放系列数值。传递给 [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdataworkbook/#getCell) 的工作表、行和列索引是从零开始的。此布局在使用默认数据创建图表时很有用，但不要假设每个已有图表都采用此布局。对于已加载的演示文稿，请在更改工作簿值之前检查系列、分类和数据点所引用的单元格。

图表设置有三种不同的作用域：

- 系列级别设置，例如 [ChartSeries.getFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getFormat)，为该系列的所有点提供默认外观。
- 数据点级别设置，例如 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/#getFormat)，会覆盖该点的系列外观。
- 组设置适用于属于同一 [ChartSeriesGroup](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseriesgroup/) 的兼容系列。当需要设置重叠或间隙宽度等选项时，可通过 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getParentSeriesGroup) 访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当系列和点的格式都存在时，点的格式优先于该点的系列格式。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置图表系列的重叠**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getOverlap) 报告 2D 图表中条形或柱形的重叠程度，范围为 -100 到 100%。它是对父系列组设置的只读投影。使用 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseriesgroup/#setOverlap) 可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图中不相关的系列组没有影响。

以下示例为包含第一系列的组设置重叠：

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // 新图表包含示例系列、分类和数值。
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

![The series overlap](series_overlap.png)

## **更改系列填充颜色**

使用 [ChartSeries.getFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getFormat) 为整个系列设置默认填充。如果某个点已有显式填充，其 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/#getFormat) 设置会覆盖该点的系列填充。

以下示例为第一系列应用纯蓝色填充：

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

![The color of the series](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚类柱形图创建的默认工作簿中，单元格 B1（第 0 行，第 1 列）包含第一系列的名称。下面示例中的命名变量明确了该结构：

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

您也可以更新 [ChartSeries.getName](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getName) 已引用的单元格。这种做法避免了对已有图表中特定行列的假设：

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

![The series name](series_name.png)

## **获取自动系列填充颜色**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) 返回根据系列索引和图表样式计算的颜色。该颜色在系列填充未显式定义时使用。调用此方法仅读取计算得到的颜色，不会分配新的填充。

以下示例打印每个默认系列的自动颜色：

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

对于条形、柱形和气泡系列，[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#setInvertIfNegative) 可在负值时使用不同的填充。将常规系列填充设为实色，启用反转，并通过 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 指定负值颜色。工作簿中的负数保持不变，仅改变其显示颜色。

以下示例用一个系列替换默认图表数据。工作表第 0 行存放系列名称，第 0 列存放分类名称，第 1 列存放数值：

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

![The inverted solid fill color](inverted_solid_fill_color.png)

您也可以通过 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 为单个点启用反转。在下面的示例中，系列的反转被禁用，仅为选中的点启用，并为该点分配负值以便看到效果：

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

要使某一点为空而不删除其他点，请将其对应的工作簿单元格设为 `null`。对于柱形图，绘制的数值可通过 [ChartDataPoint.getValue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/#getValue) 获取。数据点仍保留在相同的分类位置，但图表会根据空值设置将其视为空白。

以下示例仅清除第一系列的第二个点：

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

散点图使用独立的 X 和 Y 单元格，气泡图还使用大小单元格。仅清除表示要移除的值的单元格。不要在想保留其他点时调用 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapointcollection/#clear)；该方法会删除集合中的所有数据点。

## **控制空单元格的显示方式**

空工作簿单元格表示缺失数据；包含 `0` 的单元格表示已知的数值。调用 [ChartDataCell::setValue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/#setValue) 并传入 `null` 可将单元格设为空。数值零始终保持为零，无论空单元格设置为何。

使用 [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/#setDisplayBlanksAs) 选择图表如何显示空单元格。此设置作用于整个图表，会改变空白的绘制方式，但不会用零或插值填充空工作簿单元格。

下面的完整示例创建了一个带有一个系列的折线图，清除第 3 天的数值，并分别以每种模式保存相同的图表。无需输入文件。[ChartDataWorkbook](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdataworkbook/) 使用工作表 0，第 0 列存放分类标签，第 1 列存放数值；第 0 行存放系列名称。最终数据为 `10, 20, empty, 30, 40`。

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // 将第 3 天真正设为空，同时保留其分类和数据点。
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

每个输出文件在保存前存储相应的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 和 `empty_cells_Span.pptx`。如果只需一种版本，请在保存演示文稿前分配所需的模式，而不是遍历所有模式。

下面的比较展示了三种文件中相同的数据。第 3 天在工作簿中始终为空：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可见效果取决于图表类型。折线图可以轻松比较所有三种模式。条形和柱形图没有连线跨越缺失的分类，因此 `Span` 无法产生上图所示的连接段；缺失的柱形和零高度的柱形看起来也很相似。同样，仅有标记的散点图没有连接线。不要期望每种图表类型都得到三种截然不同的结果；请检查您使用的图表类型的实际输出。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，表示为条形或柱形宽度的百分比。与重叠类似，它属于父系列组而不是单个系列。对组调用一次 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseriesgroup/#setGapWidth) 即可。更大的值会在簇之间创建更多空间，较小的值则使它们更密集。

以下示例更改间隙宽度并仅保存最终的演示文稿：

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

![The gap width](gap_width.png)

## **常见问题**

**哪些图表类型支持数据系列？**

所有由 [ChartType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/charttype/) 枚举表示的图表类型都使用图表数据，但它们的系列并非全部具有相同的值结构或设置。例如，分类图使用分类和数值，散点图使用 X 与 Y 值，气泡图则额外使用气泡大小。请使用与系列类型匹配的数据点创建方法。诸如重叠和间隙宽度之类的选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[ChartSeriesGroup](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseriesgroup/) 包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过某个系列访问的组的更改不一定会影响图表中的所有系列。

**新创建的图表是否包含默认数据？**

是的。默认情况下，[ShapeCollection.addChart](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/#addChart) 会创建示例系列、分类和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和分类集合。还有重载方法可创建不带默认数据的图表。

**图表对象如何与工作簿单元格关联？**

系列名称、分类标签和数据点数值引用 [ChartDataWorkbook](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdataworkbook/) 中的单元格。更改被引用的单元格会更新相应的图表元素。构建自定义数据时，请保持分类行和系列值行对齐，以便每个点绘制在预期的分类下。

**如何只清除一个点而不是整个系列？**

将相关的值单元格设为 `null`，以保留该点的分类位置为空点。仅在需要删除该系列所有点时才使用 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapointcollection/#clear)。如果同时删除分类，请更新所有系列，使它们的数值仍与分类集合保持对齐。

**空点如何显示？**

显示效果取决于图表类型以及通过 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/#setDisplayBlanksAs) 配置的值。支持的图表可以将空白显示为间隙、零值或连接相邻点。请选择与演示文稿中缺失数据含义相匹配的设置。完整示例和可视化比较请参见 **控制空单元格的显示方式**。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，调用 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#setInvertIfNegative) 并设置通过 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 返回的颜色。您可以通过 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 为单个点覆盖此行为。这些方法影响的是格式，而不是存储的数值。

**当系列和点都被格式化时，哪种格式优先？**

显式的数据点格式在该点上具有最高优先级。其他点继续使用显式的系列格式，或在系列格式未定义时使用自动图表样式和主题。组设置（如重叠和间隙宽度）控制布局，不属于点级别的格式覆盖。

**图表可以包含的系列数量有限制吗？**

Aspose.Slides 并未设定单独的系列数量上限。实际上，演示文稿文件的限制、可用内存、渲染时间以及图表的可读性决定了实际可用的上限。

**当列之间过于靠近或过于疏远时，我该如何调整？**

对相应的父系列组调用 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseriesgroup/#setGapWidth)。增大该值可扩大簇之间的间距，减小则使簇更靠近。