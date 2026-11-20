---
title: 使用 JavaScript 在演示文稿中自定义图表轴
linktitle: 图表轴
type: docs
url: /zh/nodejs-java/chart-axis/
keywords:
- 图表轴
- 垂直轴
- 水平轴
- 自定义轴
- 操作轴
- 管理轴
- 轴属性
- 最大值
- 最小值
- 轴线
- 日期格式
- 轴标题
- 轴位置
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 JavaScript 通过 Java 与 Aspose.Slides for Node.js 在 PowerPoint 演示文稿中自定义图表轴，以用于报告和可视化。"
---
## **概述**

本文介绍如何使用 Aspose.Slides for Node.js 通过 Java 自定义图表轴。它涵盖了计算轴值、切换图表行列、轴可见性、类别标签和刻度间隔、日期类别及格式化、标题旋转、轴定位、显示单位以及对数刻度。

## **获取图表纵轴的最大值**

创建一个 [演示文稿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 并添加一个默认数据的面积图。在读取计算轴值之前，调用 [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) 以确保图表布局是最新的。

读取 [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) 和 [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) 以获取轴的上下限，读取 [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) 和 [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) 以获取刻度间隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) 和 [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) 提供时间单位刻度，这与日期轴相关。示例将这些值存入本地变量并保存图表。

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

## **交换轴之间的数据**

使用 [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) 交换图表数据中系列和类别的角色。每个原来的类别变为系列，每个原来的系列变为类别。这会改变数据的分组方式；但不会交换水平和垂直轴。示例使用 [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) 将默认数据绑定到 `Sheet1!A1:D5`，包括标题行和类别列，然后再交换行和列。它保存了一个包含四个系列和三个类别的图表。

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

## **反转轴的绘制顺序**

使用 [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) 反转类别轴或数值轴。例如，水平条形图可以按工作表中的顺序从上到下显示项目阶段：规划、开发、测试。反转轴会改变绘图方向；不会对工作簿数据进行排序或重新排列。相比之下，[switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) 交换系列和类别的角色。

下面的示例创建了一个包含三个阶段和一个系列的水平条形图。它保存了三张幻灯片：正常顺序、类别反转、数值反转。每个副本使用相同的数据集，每张副本仅反转一个轴。

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
    // 保持水平数值轴在底部。
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

反转轴还可以将垂直轴移动到绘图区域的另一侧。[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) 控制另一条轴在被配置轴上的交叉位置。在第 2 张幻灯片中，对反转的类别轴调用 `aspose.slides.CrossesType.Maximum` 可保持水平数值轴位于底部。若需特定的交叉点，请使用 [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/)。在更改方向时检查交叉设置，尤其是图表已经具有自定义交叉点时。调用 `setPlotOrderReversed` 并传入 `false` 可恢复正常的绘制方向；交叉设置是独立的。

| 正常顺序（幻灯片 1） | 类别反转（幻灯片 2） | 数值反转（幻灯片 3） |
| --- | --- | --- |
| ![水平条形图，正常的类别和数值轴顺序](axis-order-normal.png) | ![水平条形图，类别从上到下显示](axis-order-categories-reversed.png) | ![水平条形图，反转的数值轴，零点在右侧](axis-order-values-reversed.png) |
| 类别从下到上排列；数值从左到右递增。 | 规划、开发和测试从上到下排列。数值和工作表行顺序保持不变。 | 类别保持正常顺序；数值从右到左递增。类别轴在右侧零点交叉。 |

## **禁用折线图的纵轴**

在纵轴上调用 [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) 并传入 `false` 以隐藏它。示例创建了一个默认数据的折线图，并在保存时隐藏了纵轴。

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

## **禁用折线图的横轴**

在横轴上调用 [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) 并传入 `false` 以隐藏它。示例创建了一个默认数据的折线图，并在保存时隐藏了横轴。

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

## **显示或隐藏图表网格线**

调用 [getShowMajorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowmajorgridlines/) 和 [getShowMinorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowminorgridlines/) 检查轴显示哪些网格线。要显示次要网格线，使用 [getMinorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getminorgridlinesformat/) 并将线填充设为实色且可见。要隐藏它们，将填充设为 [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/)。使用 [getMajorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getmajorgridlinesformat/) 以同样方式更改主网格线的线填充。更改填充不会影响轴的可见性和刻度标记。

此聚类柱形图的纵轴最初仅显示主网格线。示例将次要网格线显示为深橙色，然后在保存演示文稿前再次隐藏它们，并在每一步打印网格线的可见性。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 30, 660, 230);
    var axis = chart.getAxes().getVerticalAxis();
    console.log("Initial: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    var minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    var darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    minorFill.getSolidFillColor().setColor(darkOrange);
    console.log("Enabled: minor=%s", axis.getShowMinorGridLines());

    minorFill.setFillType(java.newByte(aspose.slides.FillType.NoFill));
    console.log("Hidden: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 启用次要网格线 | 隐藏次要网格线 |
| --- | --- |
| ![垂直轴上主要网格线之间的橙色次要网格线](minor-gridlines-enabled.png) | ![仅显示主要网格线的相同柱形图](minor-gridlines-hidden.png) |

## **更改类别轴**

使用 [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) 可选择日期或文本类别轴。此示例需要 `ExistingChart.pptx`，该文件的第一张幻灯片的第一个形状是图表，类别单元格包含 Excel 数字日期值。它将水平轴改为日期轴。调用 [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) 并传入 `false`，随后调用 [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) 传入 `1`，以及 [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) 传入 `TimeUnitType.Months`，可将主刻度设置为一个月的间隔。

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

### **根据数据确定类别轴类型**

在填充类别后调用 [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistypeautomatically/)，随后读取 [getCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getcategoryaxistype/) 以检查选定的类型。当同一图表可能接收文本标签或数字日期值时，此方法非常有用。该方法在调用时确定类型；不会启用对后续数据更改的持续重新评估。更换类别后再次调用即可。

下面的示例创建了一个文本类别的图表，并在选定的类型为 `CategoryAxisType.Text` 时打印 `true`。随后将类别单元格的值替换为日期，并再次调用该方法，打印 `true` 表示选定的类型为 `CategoryAxisType.Date`。日期以数字 OLE Automation 值存储，计算方式为自 1899 年 12 月 30 日起的天数，而非日期字符串。JavaScript 计算使用 UTC 时间戳并除以 86,400,000 毫秒（每天的毫秒数）；月份索引从零开始。使用 `java.newDouble` 将每个日期值作为 double 传递给 Java。[setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) 控制这些数值的显示方式；它不将文本转换为数字日期。有关类别单元格的更多信息，请参阅 [Chart Workbook](/slides/zh/nodejs-java/chart-workbook/)。

在输入已知包含文本类别或数字日期的情况下使用自动确定；对于普通数字标签、混合类别或空数据，请显式调用 [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) 以匹配预期含义。仅有数字值并不足以确定类别代表日期。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var seriesName = workbook.getCell(0, 0, 1, "Sales");
    var series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    var labels = ["First", "Second", "Third"];

    for (var i = 0; i < labels.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Text); // true

    var baseDate = Date.UTC(1899, 11, 30);
    var dates = [Date.UTC(2026, 0, 1), Date.UTC(2026, 0, 2), Date.UTC(2026, 1, 1)];

    for (var i = 0; i < dates.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0);
        var dateValue = java.newDouble((dates[i] - baseDate) / 86400000);
        categoryCell.setValue(dateValue);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Date); // true

    presentation.save("AutomaticCategoryAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制类别轴标签间隔**

当图表拥有大量类别时，可通过减少可见轴标签的数量来避免拥挤，而不必删除类别或数据点。先调用 [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) 并传入 `false`，随后将所需的类别间隔传给 [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/)。对于保持正常顺序的文本类别，计数从第一个类别开始：

| 间隔 | 示例中显示的标签 |
| --- | --- |
| `1` | 类别 1, 类别 2, 类别 3, … 类别 24 |
| `2` | 类别 1, 类别 3, 类别 5, … 类别 23 |
| `3` | 类别 1, 类别 4, 类别 7, … 类别 22 |

间隔为 `3` 时每三个标签显示一次，两个标签被隐藏。它不会删除对应的列。自动间隔会根据可用空间选择间隔；并非一定显示每个标签。

刻度标记有独立的控制。调用 [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) 并传入 `false`，再使用 [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) 设置其间隔。例如，`1` 在每个类别间隔保留刻度标记，而标签仅每第三个类别出现。使用 [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) 并设为可见样式，以便看到效果。再次将任一自动间隔设为 `true`，图表会重新选择间隔。

下面的示例创建 24 个类别和一个系列，随后在 `CategoryAxisIntervals.pptx` 中保存三张幻灯片：自动间隔、手动标签间隔并独立刻度标记、以及恢复自动间隔。两个副本保留了原始图表数据。无需输入演示文稿。水平标签文本使密度差异一目了然。

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

    // 幻灯片 2：显示每三个标签，但保持每个类别都有刻度标记。
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 幻灯片 3：让图表再次自行选择两个间隔。
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自动间隔（幻灯片 1）：** 在此渲染中，每隔一个类别标签显示一次，并换行为两行。自动结果会随图表大小、字体和渲染器而异。

![自动类别标签间隔，显示全部 24 列](category-axis-automatic.png)

**手动间隔（幻灯片 2）：** 每三个标签在一行显示，而刻度标记仍保持在每个类别间隔。所有 24 列（包括未显示标签的列）仍保持可见且数值相同。幻灯片 3 恢复了上图所示的自动外观。

![手动设置间隔为三的类别标签，显示全部 24 列](category-axis-manual.png)

### **选择正确的轴和间隔**

对文本类别轴（如柱形、折线、面积或条形图的类别轴）使用此类别计数间隔。在柱形图中，它是水平轴；在水平条形图中，类别轴是垂直的，因此将这些设置应用于由 [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) 返回的轴。刻度间隔同样适用于具有系列轴的图表。

不要使用类别标签间隔来设置数值轴的数值刻度。在数值轴上，[setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) 指定数值差，如 `10` 会在 0、10、20 等处生成刻度。类别标签间隔 `3` 仅计数类别位置，且不考虑其数值。散点图和气泡图使用数值轴，而非文本类别轴。对于日期轴，请使用 [Change a Category Axis](#更改类别轴) 中描述的基于时间的主单位和刻度。

## **设置类别轴值的日期格式**

示例用四个年度值替换了默认的图表数据。日期以 OLE Automation 序列号存储在第一个工作表（索引 `0`）中，计算方式为自 1899 年 12 月 30 日起的天数。JavaScript 计算使用 UTC 时间戳并除以 86,400,000 毫秒（每天的毫秒数）。使用 [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) 并传入 `CategoryAxisType.Date`，随后调用 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) 并传入 `false`，再将 `yyyy` 传给 [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/)，即可让类别标签独立于单元格格式显示四位数年份。

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

## **设置图表轴标题的旋转角度**

在纵轴上调用 [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) 并传入 `true`，提供标题文本后使用 [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) 进行旋转。角度以度数计量；本示例保存了一个柱形图，其数值轴标题旋转了 90 度。

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

## **设置类别或数值轴上的轴位置**

使用 [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) 控制数值轴是跨越类别之间还是在类别刻度线上交叉。此设置适用于类别轴。示例在柱形图的水平类别轴上将其设为 `true` 并保存结果。

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

## **设置图表数值轴的显示单位**

使用 [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) 可在不更改底层数据的前提下缩放数值轴标签。将 [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) 设为 `Millions` 时，60000000 会显示为 60。示例创建了一个柱形图并将其纵轴的显示单位设置为百万。

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

## **配置对数数值轴**

当正值跨越多个数量级时，对数数值轴非常有用。例如，一个服务在五个周期内可能收到 10、100、1,000、10,000、100,000 次请求。在线性尺度上，较小的值会聚集在零附近。对数尺度使它们的相对增长更易比较：等距代表等比例而非等差。

在数值轴上调用 [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) 并传入 `true`，再使用 [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) 选择底数。这会改变现有值的显示方式；并不修改数据或添加对数趋势线。趋势线是对数据进行拟合的独立功能。

### **选择数值轴及基数**

对于折线图或柱形图，数值轴由 [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) 返回。对于水平条形图，数值轴由 [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) 返回。散点图和气泡图有两个数值轴，请为 X 值选择水平轴，为 Y 值选择纵轴，或两者皆选。不要对类别轴应用对数尺度。

默认的对数底数是 `10`。对于 PPTX 图表，底数可在 `2` 到 `1000`（含）之间选择；也支持 `2.5` 等分数底数。底数为 `10` 时，后续的 10、100、1,000、10,000 等幂等间距。

### **比较线性和对数刻度**

下面的示例创建了一个折线图，在第一张幻灯片上显示五个请求计数，然后克隆该幻灯片并在第二张上启用基数为 10 的对数数值轴。两张幻灯片保留相同数据。

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

    // 保持第一张幻灯片为线性，只更改副本的数值轴刻度。
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

**线性刻度（幻灯片 1）：** 等距的垂直距离表示相等的请求数差异。最大值主导图表，导致较小的值难以辨别。

![PowerPoint 中的折线图，显示线性数值轴上的五个请求计数](value-axis-linear.png)

**对数刻度（幻灯片 2）：** 等距的垂直距离表示相等的比例。每个周期的请求数是前一个的十倍，因此在以 10 为底的尺度上形成一条直线上升的线。轴标签仍然显示原始的请求计数。

![PowerPoint 中相同的五个请求计数，使用以 10 为底的对数数值轴](value-axis-logarithmic.png)

### **处理零值和负值**

对数尺度只能显示严格正值。启用前请检查数据。如果零值或负值具有意义，请保留线性尺度或单独显示它们。如果在分析中排除这些值是合理的，请说明原因。不要悄悄将它们替换为小的正数，因为这会改变数据含义。对数轴的任何手动设置的最小值或最大值也必须为正。

## **常见问题**

**如何设置一个轴交叉另一个轴的数值（轴交叉）？**

使用 [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) 选择交叉行为。若要指定数值交叉点，请使用 [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/)。这些设置可让您将轴交叉移动到合适的基准线。

**如何相对于轴定位刻度标签？**

调用 [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) 并使用 [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/)：`Low`、`High`、`NextTo` 或 `None`。若要控制刻度本身，请使用 [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) 或 [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/)；这些与标签位置是分开的。