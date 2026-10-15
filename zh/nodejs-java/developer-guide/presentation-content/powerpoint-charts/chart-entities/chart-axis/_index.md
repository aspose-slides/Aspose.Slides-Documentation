---
title: 使用 JavaScript 在演示文稿中自定义图表坐标轴
linktitle: 图表坐标轴
type: docs
url: /zh/nodejs-java/chart-axis/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 JavaScript 与 Aspose.Slides for Node.js（通过 Java）在 PowerPoint 演示文稿中自定义图表坐标轴，以用于报告和可视化。"
---
## **概述**

本文解释如何使用 Aspose.Slides for Node.js（通过 Java）自定义图表坐标轴。它涵盖了计算坐标轴值、切换图表行列、坐标轴可见性、类别标签和刻度间隔、日期类别及格式化、标题旋转、坐标轴位置、显示单位以及对数刻度等内容。

## **获取图表垂直坐标轴的最大值**

创建一个[演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)并添加一个带默认数据的面积图。在读取计算坐标轴值之前调用[validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/)以确保图表布局是最新的。

读取[getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/)和[getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/)获取坐标轴的上下限，使用[getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/)和[getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/)获取刻度间隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/)和[getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/)提供时间单位刻度，这在日期坐标轴中相关。示例将这些值存储在局部变量中并保存图表。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在坐标轴之间交换数据**

使用[switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/)交换系列和类别在图表数据中的角色。每个原来的类别变为系列，每个原来的系列变为类别。这会改变数据的分组方式，但不会交换水平和垂直坐标轴。示例在切换行列之前使用[setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/)将默认数据绑定到 `Sheet1!A1:D5`（包括标题行和类别列）。它保存了一个包含四个系列和三个类别的图表。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **反转坐标轴的绘制顺序**

使用[setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/)反转类别轴或数值轴。例如，水平条形图可以按照工作表中的顺序从上到下显示项目阶段：Planning、Development、Testing。反转坐标轴会改变绘制方向，但不会对工作簿数据进行排序或重新排列。相比之下，[switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/)交换系列和类别的角色。

以下示例创建一个包含三个阶段和一个系列的水平条形图。它保存了一个包含三张幻灯片的演示文稿：正常顺序、类别反转、数值反转。每个副本使用相同的数据集，并且每个副本仅反转一个坐标轴。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // 幻灯片 2：在顶部显示第一个类别。
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // 保持水平数值坐标轴在底部。
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // 幻灯片 3：仅反转水平数值刻度。
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

反转坐标轴还可以将垂直坐标轴移动到绘图区域的另一侧。[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/)控制另一坐标轴在被配置坐标轴上的交叉位置。在第 2 张幻灯片中，对反转的类别轴调用 `aspose.slides.CrossesType.Maximum` 可保持水平数值轴位于底部。若需特定的交叉点，请使用[setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/)。在改变方向时请检查交叉设置，尤其是图表已拥有自定义交叉点的情况。调用 `setPlotOrderReversed` 并传入 `false` 可恢复正常绘制方向；交叉设置是独立的。

| 正常顺序（幻灯片 1） | 类别反转（幻灯片 2） | 数值反转（幻灯片 3） |
| --- | --- | --- |
| ![水平条形图，正常的类别和数值轴顺序](axis-order-normal.png) | ![水平条形图，类别从上到下显示](axis-order-categories-reversed.png) | ![水平条形图，数值轴反转且零位于右侧](axis-order-values-reversed.png) |
| 类别从底部到顶部；数值从左向右增大。 | Planning、Development 和 Testing 从上到下排列。数值及工作表行顺序保持不变。 | 类别保持正常顺序；数值从右向左增大。类别轴在右侧零点交叉。 |

## **禁用折线图的垂直坐标轴**

在垂直坐标轴上调用[setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/)并传入 `false` 来隐藏它。示例创建一个默认数据的折线图并保存其垂直坐标轴已隐藏的版本。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **禁用折线图的水平坐标轴**

在水平坐标轴上调用[setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/)并传入 `false` 来隐藏它。示例创建一个默认数据的折线图并保存其水平坐标轴已隐藏的版本。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **更改类别坐标轴**

使用[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/)选择日期或文本类别坐标轴。此示例需要 `ExistingChart.pptx`，其中第一张幻灯片的第一形状为图表，类别单元格包含数值型 Excel 日期。它将水平坐标轴改为日期轴。调用[setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/)并传入 `false`，随后[setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/)传入 `1`，以及[setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/)传入 `TimeUnitType.Months`，可将主刻度设置为每月一次。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制类别坐标轴标签间隔**

当图表具有大量类别时，可在不删除类别或数据点的前提下减少可见坐标轴标签的数量。调用[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/)并传入 `false`，随后将期望的类别间隔传给[setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/)。对于文本类别且顺序正常，计数从第一个类别开始：

| 间隔 | 示例中显示的标签 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

间隔为 `3` 时每三个标签显示一次，之间隐藏两个标签。它不会删除对应的列。自动间隔会根据可用空间选择间隔，未必显示所有标签。

刻度线有独立的控制。调用[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/)并传入 `false`，再使用[setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/)设置其间隔。例如，`1` 在每个类别间隔处保留刻度线，而标签仅每三个类别显示一次。使用[setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/)并设置可见样式，以便看到效果。再次将任一自动间隔设置器的参数设为 `true`，图表会重新采用自动间隔。

以下完整示例创建 24 个类别和一个系列，然后在 `CategoryAxisIntervals.pptx` 中保存三张幻灯片：自动间隔、手动标签间隔并保留独立刻度线、以及恢复自动间隔。两份副本保留原始图表数据，无需输入演示文稿。水平标签文字使得密度差异易于观察。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // 幻灯片 2：显示每三个标签，但保持每个类别都有刻度线。
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 幻灯片 3：让图表再次自动选择标签间隔和刻度间隔。
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自动间隔（幻灯片 1）：** 在此渲染中，每隔一个类别标签会显示一次，并换行成两行。自动结果会随图表大小、字体和渲染器而变化。

![自动类别标签间隔，所有 24 列均可见](category-axis-automatic.png)

**手动间隔（幻灯片 2）：** 每三个标签显示在同一行，而刻度线仍保持在每个类别间隔。所有 24 列（包括未标记的列）仍保持可见且数值相同。幻灯片 3 恢复了上图所示的自动外观。

![手动类别标签间隔为 3，所有 24 列均可见](category-axis-manual.png)

### **选择正确的坐标轴和间隔**

此类别计数间隔适用于文本类别坐标轴，例如柱形图、折线图、面积图或条形图的类别坐标轴。在柱形图中，它是水平坐标轴；在水平条形图中，类别坐标轴是垂直的，因此应对[getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/)返回的坐标轴应用这些设置。刻度线间隔同样适用于具有系列坐标轴的图表。

不要使用类别标签间隔来设置数值坐标轴的数值刻度。在数值坐标轴上，[setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/)指定数值差，例如 `10` 的主单位会在 0、10、20 等处生成刻度。类别标签间隔 `3` 仅计数类别位置，与其数据值无关。散点图和气泡图使用数值坐标轴而非文本类别坐标轴。对于日期坐标轴，请参阅[更改类别坐标轴](#change-a-category-axis)中基于时间的主单位和刻度设置。

## **设置类别坐标轴值的日期格式**

示例用四个年度值替换默认图表数据。日期以 OLE 自动化序列号存储在第一个工作表（索引 `0`）中，计算方式为自 1899 年 12 月 30 日起的天数。JavaScript 计算使用 UTC 时间戳并除以每天 86,400,000 毫秒。使用[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/)并传入 `CategoryAxisType.Date`，调用[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/)并传入 `false`，随后将 `yyyy` 传给[setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/)，即可让类别标签独立于单元格格式显示四位数年份。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **为坐标轴标题设置旋转角度**

在垂直坐标轴上调用[setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/)并传入 `true`，提供标题文本后使用[setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/)旋转标题。角度以度为单位；本示例保存了一个列形图，其数值轴标题旋转了 90 度。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在类别或数值坐标轴上设置坐标轴位置**

使用[setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/)控制数值坐标轴是跨越类别之间还是在类别刻度线上交叉。这一设置仅适用于类别坐标轴。示例在列形图的水平类别坐标轴上将其设为 `true` 并保存结果。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在数值坐标轴上设置显示单位**

使用[setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/)可在不更改底层数据的前提下缩放数值坐标轴标签。将[DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/)设为 `Millions` 时，60000000 将显示为 60。示例创建了一个列形图并对其垂直坐标轴应用了“百万”显示单位。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **配置对数数值坐标轴**

对数数值坐标轴在正值跨越多个数量级时非常有用。例如，某服务在五个周期内分别收到 10、100、1,000、10,000、100,000 次请求。在线性尺度下，较小的值会聚集在接近零的位置。对数尺度使它们的相对增长更易比较：等距代表等比而非等差。

在数值坐标轴上调用[setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/)并传入 `true`，再使用[setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/)选择底数。这会改变现有值的显示方式，但不修改数据，也不会添加对数趋势线。趋势线是对数据进行拟合的独立功能。

### **选择数值坐标轴和底数**

对于折线图或柱形图，数值坐标轴由[getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/)返回。对于水平条形图，则由[getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/)返回。散点图和气泡图拥有两个数值坐标轴，可为 X 轴选择水平坐标轴、为 Y 轴选择垂直坐标轴，或两者皆选。不要对类别坐标轴应用对数缩放。

默认对数底数为 `10`。对于 PPTX 图表，底数可取 `2` 到 `1000`（含），亦支持如 `2.5` 的小数底数。底数为 `10` 时，10、100、1,000、10,000 等连续幂次等距分布。

### **比较线性和对数缩放**

以下完整示例在第 1 张幻灯片创建一个包含五个请求计数的折线图，然后克隆该幻灯片并在第 2 张上启用底数为 10 的对数数值坐标轴。两张幻灯片使用相同的数据。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // 保持第一张幻灯片为线性，仅更改复制的数值轴比例。
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**线性尺度（幻灯片 1）：** 等距的垂直距离代表请求计数的相等差值。最大值主导图表，使得较小值难以辨别。

![PowerPoint 中显示五个请求计数的折线图，使用线性数值坐标轴](value-axis-linear.png)

**对数尺度（幻灯片 2）：** 等距的垂直距离代表等比例。每个周期的请求量是前一个的十倍，因而在底数为 10 的尺度上形成一条直线上升的线。坐标轴标签仍然显示原始的请求计数。

![PowerPoint 中相同的五个请求计数，使用底数为 10 的对数数值坐标轴](value-axis-logarithmic.png)

### **处理零和负值**

对数尺度只能显示严格正值。在启用之前请检查数据。如果零或负值有实际意义，请保持线性尺度或单独展示这些值。如果在分析中排除这些值是合理的，请说明原因。不要偷偷将其替换为小的正数，因为这会改变数据的含义。对数坐标轴的任何手动最小值或最大值也必须为正数。

## **常见问题**

**如何设置一个坐标轴与另一坐标轴交叉的位置（坐标轴交叉）？**

使用[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/)选择交叉行为。若要指定数值交叉点，请使用[setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/)。这些设置可将坐标轴交叉移动到合适的基线位置。

**如何相对于坐标轴定位刻度标签？**

调用[setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/)并使用[TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/)：`Low`、`High`、`NextTo` 或 `None`。若要控制刻度线本身，请使用[setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/)或[setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/)；这些设置与标签位置是独立的。