---
title: 使用 PHP 在演示文稿中自定义图表坐标轴
linktitle: 图表坐标轴
type: docs
url: /zh/php-java/chart-axis/
keywords:
- 图表坐标轴
- 垂直坐标轴
- 水平坐标轴
- 自定义坐标轴
- 操作坐标轴
- 管理坐标轴
- 坐标轴属性
- 最大值
- 最小值
- 坐标轴线
- 日期格式
- 坐标轴标题
- 坐标轴位置
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中自定义图表坐标轴，以用于报告和可视化。"
---
## **概述**

本文介绍如何使用 Aspose.Slides for PHP via Java 自定义图表坐标轴。它涵盖了计算坐标轴值、切换图表行列、坐标轴可见性、分类标签和刻度间隔、日期分类和格式设置、标题旋转、坐标轴定位、显示单位以及对数缩放。

## **获取图表垂直坐标轴的最大值**

创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 并添加一个带有默认数据的面积图。在读取计算坐标轴值之前调用 [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/)，以确保图表布局是最新的。

读取 [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) 和 [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) 以获取坐标轴的上下限，并读取 [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) 和 [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) 以获取刻度间隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) 和 [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) 提供时间单位比例，这与日期坐标轴相关。示例将这些值存储在局部变量中并保存图表。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在坐标轴之间交换数据**

使用 [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) 交换图表数据中系列和分类的角色。每个原来的分类会变成系列，每个原来的系列会变成分类。这会改变数据的分组方式；但不会交换水平和垂直坐标轴。示例在切换行列之前使用 [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) 将默认数据绑定到 `Sheet1!A1:D5`，包括标题行和分类列。它保存了一个包含四个系列和三个分类的图表。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **反转坐标轴的绘制顺序**

使用 [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) 可以反转分类坐标轴或数值坐标轴。例如，水平条形图可以按照工作表中的顺序从上到下显示项目阶段：Planning、Development、Testing。反转坐标轴会改变绘制方向；但不会对工作簿数据进行排序或重新排列。相比之下， [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) 交换系列和分类的角色。

下面的示例创建了一个包含三个阶段和一个系列的水平条形图。它保存了一个包含三张幻灯片的演示文稿：普通顺序、反转分类和反转数值。每个副本使用相同的数据集，并且每个副本只反转一个坐标轴。

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // 第 2 张幻灯片：在顶部显示第一个分类。
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // 保持水平数值坐标轴在底部。
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // 第 3 张幻灯片：仅反转水平数值刻度。
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

反转坐标轴还可以将垂直坐标轴移动到绘图的另一侧。[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) 控制另一坐标轴在被配置坐标轴上的交叉位置。在第 2 张幻灯片中，对反转的分类坐标轴使用 `CrossesType::Maximum` 调用，可保持水平数值坐标轴位于底部。若需指定交叉点，请使用 [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/)。更改方向时请检查交叉设置，尤其是图表已有自定义交叉点的情况。调用 `setPlotOrderReversed` 并传入 `false` 可恢复正常绘制方向；交叉设置是独立的。

| 普通顺序（第 1 张幻灯片） | 反转分类（第 2 张幻灯片） | 反转数值（第 3 张幻灯片） |
| --- | --- | --- |
| ![水平条形图，分类和数值坐标轴顺序正常](axis-order-normal.png) | ![水平条形图，分类从上到下显示](axis-order-categories-reversed.png) | ![水平条形图，数值坐标轴反转且零位于右侧](axis-order-values-reversed.png) |
| 分类从底部到顶部；数值从左到右递增。 | Planning、Development、Testing 从上到下排列。数值和工作表行顺序保持不变。 | 分类保持正常顺序；数值从右到左递增。分类坐标轴在右侧零点交叉。 |

## **在折线图中禁用垂直坐标轴**

对垂直坐标轴调用 [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) 并传入 `false` 以隐藏它。示例创建了一个带有默认数据的折线图并将其保存为隐藏垂直坐标轴的文件。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在折线图中禁用水平坐标轴**

对水平坐标轴调用 [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) 并传入 `false` 以隐藏它。示例创建了一个带有默认数据的折线图并将其保存为隐藏水平坐标轴的文件。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **显示或隐藏图表网格线**

调用 [getShowMajorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowmajorgridlines/) 和 [getShowMinorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowminorgridlines/) 检查坐标轴显示哪些网格线。若要显示次网格线，使用 [getMinorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getminorgridlinesformat/) 并将线填充设为实色且可见。若要隐藏它们， 将填充设为 [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/)。使用 [getMajorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getmajorgridlinesformat/) 以同样方式更改主网格线的线填充。更改填充不会影响坐标轴的可见性和刻度。

此簇状柱形图的垂直坐标轴最初仅显示主网格线。示例将次网格线显示为深橙色，然后在保存演示文稿前再次隐藏它们，并在每一步打印网格线的可见性。

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
    $axis = $chart->getAxes()->getVerticalAxis();
    printf("Initial: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill = $axis->getMinorGridLinesFormat()->getLine()->getFillFormat();
    $minorFill->setFillType(FillType::Solid);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $minorFill->getSolidFillColor()->setColor($darkOrange);
    printf("Enabled: minor=%s\n", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill->setFillType(FillType::NoFill);
    printf("Hidden: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $presentation->save("ChartGridlines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| 次网格线已启用 | 次网格线已隐藏 |
| --- | --- |
| ![垂直坐标轴上主网格线之间的橙色次网格线](minor-gridlines-enabled.png) | ![同一柱形图，仅显示主网格线](minor-gridlines-hidden.png) |

## **更改分类坐标轴**

使用 [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) 选择日期或文本分类坐标轴。此示例需要 `ExistingChart.pptx`，其中图表位于第一张幻灯片的第一个形状，分类单元格包含数值型 Excel 日期值。它将水平坐标轴更改为日期坐标轴。调用 [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) 并传入 `false`，[setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) 设为 `1`，以及 [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) 设为 `TimeUnitType::Months`，即可在每月间隔放置主刻度。

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **从数据确定分类坐标轴类型**

在填充分类后调用 [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistypeautomatically/)，随后读取 [getCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getcategoryaxistype/) 以检查选择类型。当同一图表可能收到文本标签或数值日期值时，这很有用。该方法在调用时确定类型；不会启用在后续数据更改时重新评估的持久模式。更换分类后请再次调用。

下面的示例创建了一个带有文本分类的图表，当选定类型为 `CategoryAxisType::Text` 时打印 `true`。随后将分类单元格值替换为日期并再次调用该方法，当选定类型为 `CategoryAxisType::Date` 时打印 `true`。日期以数值 OLE Automation 形式存储，计算方式为自 1899 年 12 月 30 日起的天数，而非日期字符串。 [setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) 控制这些值的显示方式；它不会将文本转换为数值日期。有关分类单元格的更多信息，请参阅 [Chart Workbook](/slides/zh/php-java/chart-workbook/)。

当已知输入包含文本分类或数值日期时，如本例所示，可使用自动确定。对于普通数值标签、混合分类或空数据，请显式调用 [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) 以匹配预期含义。仅有数值并不能表明分类代表日期。

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $seriesName = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());
    $labels = ["First", "Second", "Third"];

    for ($i = 0; $i < count($labels); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $labels[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, ($i + 1) * 10);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Text ? "true" : "false") . PHP_EOL;

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);
    $dates = [gmmktime(0, 0, 0, 1, 1, 2026), gmmktime(0, 0, 0, 1, 2, 2026), gmmktime(0, 0, 0, 2, 1, 2026)];

    for ($i = 0; $i < count($dates); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0);
        $categoryCell->setValue((float)(($dates[$i] - $baseDate) / 86400));
        $categoryCell->setCustomNumberFormat("yyyy-mm-dd");
    }

    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Date ? "true" : "false") . PHP_EOL;

    $presentation->save("AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **控制分类坐标轴标签间隔**

当图表拥有大量分类时，可在不删除分类或数据点的前提下降低可见轴标签的数量。调用 [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) 并设为 `false`，随后将期望的分类间隔传递给 [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/)。对于正常顺序的文本分类，计数从第一个分类开始：

| 间隔 | 示例中显示的标签 |
| --- | --- |
| `1` | 类别 1, 类别 2, 类别 3, ... 类别 24 |
| `2` | 类别 1, 类别 3, 类别 5, ... 类别 23 |
| `3` | 类别 1, 类别 4, 类别 7, ... 类别 22 |

间隔为 `3` 时每三个标签显示一次，显示的标签之间隐藏两个标签。它不会删除对应的列。自动间距根据可用空间选择间隔；并不一定显示所有标签。

刻度线有独立的控制。调用 [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) 并设为 `false`，然后使用 [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) 设置其间隔。例如，设为 `1` 可在每个分类间隔保持刻度线，而标签仅每三个分类显示一次。使用带可见样式的 [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) 以便观察效果。再次将任一自动间距设为 `true` 可让图表重新选择该间隔。

下面的独立示例创建了 24 个分类和一个系列，然后在 `CategoryAxisIntervals.pptx` 中保存三张幻灯片：自动间距、带独立刻度线的手动标签间距以及恢复的自动间距。两个副本保留原始图表数据。无需输入演示文稿。水平标签文本使密度差异一目了然。

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // 第 2 张幻灯片：显示每三个标签，但为每个分类保留刻度线。
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // 第 3 张幻灯片：让图表重新选择两个间隔。
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**自动间距（第 1 张幻灯片）：** 在此渲染中，每隔一个分类标签显示一次，并换行为两行。自动结果可能因图表尺寸、字体和渲染器而异。

![所有 24 列可见的自动分类标签间距](category-axis-automatic.png)

**手动间距（第 2 张幻灯片）：** 每三个标签显示在一行，而刻度线仍保持在每个分类间隔。所有 24 列（包括没有标签的列）仍以相同数值可见。第 3 张幻灯片恢复了上述自动外观。

![手动分类标签间隔为三，所有 24 列可见](category-axis-manual.png)

### **选择正确的坐标轴和间隔**

对文本分类坐标轴使用此分类计数间隔，例如柱形图、折线图、面积图或条形图的分类坐标轴。在柱形图中，它是水平坐标轴；在水平条形图中，分类坐标轴是垂直的，因此将这些设置应用于 [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) 返回的坐标轴。刻度间隔同样适用于具有系列坐标轴的图表。

不要使用分类标签间隔来设置数值坐标轴的数值刻度。在数值坐标轴上，[setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) 指定数值间隔，例如，主单位为 `10` 时，当坐标轴从零开始会产生 0、10、20 等刻度。`3` 的分类标签间隔则仅计分类位置，与数据值无关。散点图和气泡图使用数值坐标轴而非文本分类坐标轴。对于日期坐标轴，请使用基于时间的主单位和比例，如在 [Change a Category Axis](#change-a-category-axis) 中所述。

## **设置分类坐标轴值的日期格式**

示例将默认图表数据替换为四个年度值。日期以 OLE Automation 序列号存储在第一个工作表（索引 `0`）中，计算方式为自 1899 年 12 月 30 日起的天数。使用 [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) 并设为 `CategoryAxisType::Date`，调用 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) 并设为 `false`，以及向 [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) 传递 `yyyy`，使分类标签独立于单元格格式显示四位年份。

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **为图表坐标轴标题设置旋转角度**

在垂直坐标轴上调用 [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) 并传入 `true`，提供标题文本，并使用 [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) 旋转标题。角度以度为单位；本示例保存了一个列形图，其数值坐标轴标题旋转了 90 度。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在分类或数值坐标轴上设置坐标轴位置**

使用 [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) 控制数值坐标轴是在分类之间还是在分类刻度线处与分类坐标轴相交。此设置适用于分类坐标轴。示例在列形图的水平分类坐标轴上将其设为 `true` 并保存结果。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在图表数值坐标轴上设置显示单位**

使用 [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) 可在不更改底层数据的情况下缩放数值坐标轴的标签。将 [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) 设为 `Millions`，则 60,000,000 会显示为 60。示例创建了一个列形图并将百万显示单位应用于其垂直坐标轴。

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **配置对数数值坐标轴**

当正值跨越多个数量级时，对数数值坐标轴非常有用。例如，某服务在五个周期内可能分别收到 10、100、1,000、10,000 和 100,000 次请求。在线性尺度下，较小的数值会聚集在零附近。对数尺度使它们的相对增长更易比较：相等的距离代表相等的比率，而非相等的差值。

在数值坐标轴上调用 [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) 并传入 `true`，并使用 [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) 选择基数。这会改变现有数值的显示方式；不会更改数据或添加对数趋势线。趋势线表示对数据的拟合关系，是独立的功能。

### **选择数值坐标轴和基数**

对于折线图或柱形图，数值坐标轴由 [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) 返回。对于水平条形图，由 [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/) 返回。散点图和气泡图有两个数值坐标轴，因此可为 X 值选择水平坐标轴，为 Y 值选择垂直坐标轴，或两者皆选。不要对分类坐标轴使用对数缩放。

默认的对数基数为 `10`。对于 PPTX 图表，基数可在 `2` 到 `1000`（含）之间使用；亦支持如 `2.5` 的小数基数。基数为 `10` 时，后续的幂次 10、100、1,000、10,000 等等间距相等。

### **比较线性和对数缩放**

下面的独立示例在第一张幻灯片创建了一个包含五个请求计数的折线图，然后克隆该幻灯片并在第二张启用基数为 10 的对数数值坐标轴。两张幻灯片保持相同的数据。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // 保持第一张幻灯片为线性，仅更改副本的数值坐标轴比例。
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**线性尺度（第 1 张幻灯片）：** 相等的垂直距离代表请求计数的相等差值。最大值主导图表，使较小的值难以辨别。

![PowerPoint 中的折线图，显示线性数值坐标轴上的五个请求计数](value-axis-linear.png)

**对数尺度（第 2 张幻灯片）：** 相等的垂直距离代表相等的比例。每个周期的请求量是前一个周期的十倍，因而在基数为 10 的尺度上点形成一条直线上升线。坐标轴标签仍显示原始的请求计数。

![PowerPoint 中相同的五个请求计数，位于基数为 10 的对数数值坐标轴上](value-axis-logarithmic.png)

### **处理零值和负值**

对数尺度只能显示严格正值。启用前请检查数据。若零值或负值具有意义，请保留线性尺度或单独显示它们。若在分析中排除这些值是合适的，请说明省略原因。不要悄悄将其替换为小的正数，因为这会改变数据含义。对数坐标轴的任何手动设置的最小值或最大值也必须为正数。

## **常见问题**

**如何设置一个坐标轴交叉另一个坐标轴的值（坐标轴交叉）？**  
使用 [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) 选择交叉行为。若要指定数值交叉点，请使用 [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/)。这些设置可将坐标轴交叉点移动到合适的基准线。

**如何相对于坐标轴定位刻度标签？**  
调用 [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) 并使用 [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/)：`Low`、`High`、`NextTo` 或 `None`。若要控制刻度线本身，请使用 [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) 或 [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/)；这些与标签位置设置是独立的。