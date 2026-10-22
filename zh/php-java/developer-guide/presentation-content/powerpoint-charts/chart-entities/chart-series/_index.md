---
title: 在 PHP 中管理演示文稿中的图表数据系列
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
description: "了解如何在使用 PHP 的演示文稿中管理图表系列、数据点、工作簿单元格、格式设置、重叠、间隙宽度和负值。"
---
## **概览**

图表可以将绘制的数值存储在工作簿单元格中，或直接作为数值字面量。一个[ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/)表示一组相关值，每个[ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/)表示该系列中的一个点。[ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/)对象提供系列共享的标签或分组值。在使用默认数据创建的图表中，系列名称、类别和点值使用来自图表工作簿的[ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/)对象。

对于典型的类别图表，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，其余单元格存放系列值。传递给[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/)的工作表、行和列索引是从零开始的。当你使用默认数据创建图表时，这种布局很有用，但不要假设所有已有图表都采用此布局。对于已加载的演示文稿，在更改工作簿值之前，请检查系列、类别和数据点引用的单元格。

图表设置有三种不同的作用域：

- 系列级别设置，例如[ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/)，为整个系列的所有点提供默认外观。
- 数据点级别设置，例如[ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/)，覆盖单个点的系列外观。
- 组设置适用于属于同一[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/)的兼容系列。当需要设置重叠或间隙宽度等选项时，可通过[ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/)访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当系列和点的格式同时存在时，点的格式优先于该点。

![图表系列 PowerPoint](chart-series-powerpoint.png)

## **使用数值字面量设置系列值**

当系列值来自应用数据或计算且不需要工作表单元格引用时，请使用数值字面量。在为每个点的[getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/)结果通过[setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/)赋值之前，先使用[setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/)并传入[DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/)。

集合设置控制该系列中所有点值的源类型。每个点值的[getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/)方法会报告所选类型；通过集合设置进行更改。使用 `Worksheet` 时，使用[getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/)访问引用的单元格。使用 `DoubleLiterals` 时，使用[getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/)或 `setAsLiteralDouble` 直接读取或写入数字。

下面的示例创建一个具有默认系列和类别的柱形图，然后为其第一个系列的现有点分配计算得到的 10、20 等值。它保存演示文稿，重新打开后输出存储的值。

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

点值的源类型独立于[ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/)，后者标识图表的内部或外部工作簿配置。使用数值字面量本身并不会删除嵌入的工作簿。在本例中，工作簿仍用于类别标签、系列名称以及其他系列。有关工作簿管理，请参阅[Chart Workbook](/slides/zh/php-java/chart-workbook/)。

对于散点图和气泡图，使用[setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/)和[setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/)选择[getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/)和[getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/)的来源。气泡图还使用[setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/)来设置[getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/)。在通过相应的 `setAsLiteralDouble` 方法赋值之前，将每个适用的源设置为 `DoubleLiterals`。

## **设置图表系列重叠**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/)报告 2D 图表中条形或柱形的重叠程度，范围为 -100 到 100%。它是父系列组设置的只读投影。使用[ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/)可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图中不相关的系列组没有影响。

下面的示例为包含第一个系列的组设置重叠：

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

![系列重叠](series_overlap.png)

## **更改系列填充颜色**

使用[ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/)为整个系列设置默认填充。如果某个点已具有显式填充，其[ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/)设置会覆盖该点的系列填充。

下面的示例为第一个系列应用纯蓝色填充：

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

![系列颜色](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。对于聚类柱形图的默认工作簿，单元格 B1 位于第 0 行第 1 列，包含第一个系列的名称。以下示例中的命名变量明确了该结构：

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

你也可以更新[ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/)已引用的单元格。这种方式避免了对现有图表中特定行列的假设：

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

![系列名称](series_name.png)

### **使用多个单元格创建带名称的系列**

当产品名称和报告期间分别存放在不同工作簿单元格中时，复合系列名称非常有用。例如，你可以将 B1 中的 `Product A` 与 C1 中的 `2026` 合并为单一系列名称，同时保持两部分与源单元格的链接。

使用[ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/)检索名称范围，然后将该集合传递给[ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/)。`skipHiddenCells` 参数决定是否排除隐藏单元格：`true` 排除，`false` 包含。本例使用 `false` 包含名称范围内的所有单元格。

下面的示例创建一个包含一个系列和两个数据点的演示文稿。单元格 B1:C1 提供系列名称；A2:A3 提供类别标签；B2:B3 提供数值。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // 这两个单元格提供系列名称。
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // 不同的单元格提供类别和数值数据点。
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

生成的系列名称为 `Product A 2026`，两个单元格值之间有空格。图例将其显示为一个条目。下图演示了结果：

![包含 North 和 South 值的柱形图以及图例中复合系列名称 Product A 2026](composite_series_name.png)

## **获取自动系列填充颜色**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/)返回根据系列索引和图表样式计算得到的颜色。当系列填充未被显式定义时使用此颜色。调用该方法仅读取计算出的颜色，不会分配新的填充。

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

## **为图表系列设置负值填充颜色反转**

对于条形、柱形和气泡系列，[ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) 可以在负值时使用不同的填充。将常规系列填充设为实色，启用反转，然后通过[ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/)设置负值颜色。负数在工作簿中保持不变，仅改变显示颜色。

下面的示例用一个系列替换默认图表数据。工作表第 0 行存放系列名称，第 0 列存放类别名称，第 1 列存放数值：

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

![反转实色填充颜色](inverted_solid_fill_color.png)

你可以通过[ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/)为单个点启用反转。下面的示例在系列整体禁用反转的情况下，仅为选中的点启用，并为该点赋予负值以显示效果：

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

要使某一点为空而不删除其他点，请将其对应的工作簿单元格设为 `null`。对于柱形图，绘制的值通过[ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/)获取。数据点仍保持在同一类别位置，但图表会根据空值设置将其视为缺失。

下面的示例仅清除第一个系列的第二个点：

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

散点图使用独立的 X 和 Y 单元格，气泡图还使用大小单元格。仅清除表示你想删除的值的单元格。不要在想保留其他点时调用[ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/)，因为该方法会删除集合中的所有数据点。

## **控制空单元格的显示**

隐藏的包含数值的单元格属于不同的情况。要包含或排除来自隐藏工作表行列的数据，请参阅[Include Data from Hidden Rows and Columns](/slides/zh/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空工作簿单元格表示缺失数据；包含 `0` 的单元格表示已知的数值。调用[ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/)并传入 `null` 可使单元格为空。数值零始终保持为零，不受空单元格设置影响。

使用[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/)选择图表如何显示空单元格。此设置作用于整个图表，改变空白的绘制方式，而不会用零或插值填充空工作簿单元格。

下面的独立示例创建一个包含一个系列的折线图，清除第 3 天的数值，并使用每种模式分别保存同一图表。无需输入文件。[ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)使用工作表 0，第 0 列存放类别标签，第 1 列存放数值；第 0 行保存系列名称。最终数据为 `10, 20, empty, 30, 40`。

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

    // 将第3天真正留空，同时保留其类别和数据点。
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

每个输出文件在保存前存储相应模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`和`empty_cells_Span.pptx`。若只需保存一种版本，只需在保存演示文稿前设置所需模式，而不是遍历所有模式。

下面的比较展示了三文件中相同的数据。第 3 天在工作簿中始终为空：

![折线图的相同数据：Gap 在第 3 天断开折线，Zero 将折线降至零，Span 将第 2 天连接到第 4 天。](display_blanks_as.png)

可见效果取决于图表类型。折线图能够直观比较三种模式。条形和柱形图没有连线可跨越缺失的类别，因此 `Span` 无法产生上述连段；缺失的柱形和零高度柱形也可能看起来相似。散点图仅使用标记时也没有连线。不要期望每种图表类型都产生三个不同的结果；请检查所使用图表类型的输出。

## **设置系列间距宽度**

间距宽度是相邻条形或柱形簇之间的空间，以条形或柱形宽度的百分比表示。与重叠类似，它属于父系列组而非单个系列。对组调用一次[ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/)即可。较大的值会在簇之间创建更多空间，较小的值则使它们更紧凑。

下面的示例更改间距宽度并仅保存最终演示文稿：

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

![间距宽度](gap_width.png)

## **常见问题**

**哪些图表类型支持数据系列？**

所有由[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)枚举表示的图表类型都使用图表数据，但它们的系列并非全部具有相同的值结构或设置。例如，类别图使用类别和数值，散点图使用 X 与 Y 值，气泡图还加入气泡大小。请使用与系列类型匹配的数据点创建方法。诸如重叠和间距宽度之类的选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) 包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过某个系列访问的组设置并不一定会影响图表中的所有系列。

**新创建的图表是否包含默认数据？**

是的。默认情况下，[ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) 会创建示例系列、类别和数值。你可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。也可以使用重载方法创建不带默认数据的图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点值引用[ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)中的单元格。更改引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行和系列值行对齐，以便每个点绘制在预期的类别下。

**如何只清除一个点而不是整条系列？**

将相关的值单元格设为 `null`，可保留该点的类别位置为空点。仅在想删除该系列所有点时才使用[ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/)，因为该方法会移除集合中的全部数据点。

**空点如何显示？**

显示方式取决于图表类型以及通过[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/)配置的值。受支持的图表可以将空白显示为间隙、零值或连接相邻点。选择与演示文稿中缺失数据含义相匹配的设置。完整示例和可视比较请参见[控制空单元格的显示](#control-the-display-of-empty-cells)。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，调用[ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/)并设置[ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/)返回的颜色。你可以通过[ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/)为单个点覆盖此行为。这些方法影响的是格式，而不是存储的数值。

**当系列和点都进行格式化时，哪种格式生效？**

显式的数据点格式对该点具有最高优先级。其他点继续使用显式的系列格式，若系列格式未定义，则使用自动的图表样式和主题。组设置（如重叠和间距宽度）控制布局，不属于点级别的格式覆盖。

**图表能包含多少系列？是否有限制？**

Aspose.Slides 并未设定单独的固定系列数量上限。实际限制取决于演示文稿文件的约束、可用内存、渲染时间以及图表的可读性。

**当柱形之间过于靠近或过于分散时该怎么办？**

对相应的父系列组调用[ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/)。增大数值以扩大簇间距，减小数值以使簇更紧凑。