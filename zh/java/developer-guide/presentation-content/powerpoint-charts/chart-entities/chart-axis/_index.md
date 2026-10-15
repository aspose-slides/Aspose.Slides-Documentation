---
title: 使用 Java 在演示文稿中自定义图表坐标轴
linktitle: 图表坐标轴
type: docs
url: /zh/java/chart-axis/
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 演示文稿中自定义图表坐标轴，以用于报告和可视化。"
---
## **概述**

本文介绍如何使用 Aspose.Slides for Java 自定义图表坐标轴。它涵盖了计算坐标轴值、切换图表行列、坐标轴可见性、类别标签和刻度间隔、日期类别及格式、标题旋转、坐标轴定位、显示单位以及对数刻度。

## **获取图表纵向坐标轴的最大值**

创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)并添加一个带有默认数据的面积图。在读取计算的坐标轴值之前，调用[validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--)以确保图表布局为最新。

读取[getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--)、[getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) 以获取坐标轴的最大最小值，读取[getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) 和 [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) 以获取刻度间隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) 和 [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) 提供时间单位比例，适用于日期坐标轴。示例将这些值存储在局部变量中并保存图表。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在坐标轴之间交换数据**

使用[switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--)来交换图表数据中系列和类别的角色。之前的每个类别变为系列，之前的每个系列变为类别。这会改变数据的分组方式；但不会交换水平和垂直坐标轴。示例在切换行列之前，使用[setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-)将默认数据绑定到`Sheet1!A1:D5`，包括标题行和类别列。它保存一个包含四个系列和三个类别的图表。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **反转坐标轴的绘制顺序**

使用[setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-)来反转类别或数值坐标轴。例如，水平条形图可以按工作表中的相同顺序（从上到下）显示项目阶段：Planning、Development、Testing。反转坐标轴会改变绘制方向；但不会对工作簿数据进行排序或重新排列。相比之下，[switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--)交换系列和类别的角色。

以下示例创建一个包含三个阶段和一个系列的水平条形图。它将演示文稿保存为三张幻灯片：正常顺序、类别反转和数值反转。每个副本使用相同的数据集，且每个副本仅反转一个坐标轴。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // 第2页：在顶部显示第一个类别。
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // 保持水平数值坐标轴在底部。
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // 第3页：仅反转水平数值刻度。
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

反转坐标轴还可以将垂直坐标轴移动到图形的另一侧。[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) 控制另一坐标轴在被配置坐标轴上的交叉位置。在第 2 张幻灯片中，对反转的类别坐标轴使用 `CrossesType.Maximum` 可保持水平数值坐标轴位于底部。若需指定交叉点，请使用[setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-)。在改变方向时请检查交叉设置，尤其是图表已有自定义交叉点的情况。使用 `setPlotOrderReversed` 并传入 `false` 可恢复正常绘制方向；交叉设置是独立的。

| 正常顺序（幻灯片 1） | 类别反转（幻灯片 2） | 数值反转（幻灯片 3） |
| --- | --- | --- |
| ![正常类别和值轴顺序的水平条形图](axis-order-normal.png) | ![从上到下显示类别的水平条形图](axis-order-categories-reversed.png) | ![数值轴反转且零在右侧的水平条形图](axis-order-values-reversed.png) |
| 类别从底部向顶部排列；数值从左向右增大。 | Planning、Development 和 Testing 从上到下排列。数值和工作表行顺序保持不变。 | 类别保持正常顺序；数值从右向左增大。类别坐标轴在右侧零点交叉。 |

## **为折线图禁用纵向坐标轴**

对纵向坐标轴调用[setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-)并传入 `false` 以隐藏它。示例创建一个带默认数据的折线图并保存为纵向坐标轴隐藏的图表。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **为折线图禁用横向坐标轴**

对横向坐标轴调用[setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-)并传入 `false` 以隐藏它。示例创建一个带默认数据的折线图并保存为横向坐标轴隐藏的图表。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **更改类别坐标轴**

使用[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-)选择日期或文本类别坐标轴。此示例需要 `ExistingChart.pptx`，其中第一张幻灯片的第一形状是图表，类别单元格包含数值型 Excel 日期值。它将水平坐标轴改为日期坐标轴。调用[setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-)并传入 `false`，[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) 传入 `1`，以及[setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) 传入 `TimeUnitType.Months`，将在每月间隔放置主刻度。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制类别坐标轴标签间隔**

当图表包含大量类别时，可在不删除类别或数据点的前提下降低可见坐标轴标签的数量。调用[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-)并传入 `false`，随后将所需的类别间隔传递给[setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-)。对于正常顺序的文本类别，计数从第一个类别开始：

| 间隔 | 示例中显示的标签 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

`3` 的间隔会显示每第三个标签，在显示的标签之间隐藏两个标签。它不会删除相应的列。自动间隔根据可用空间选择间隔；不一定显示所有标签。

刻度线有独立的控制方式。调用[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-)并传入 `false`，使用[setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-)设置其间隔。例如，`1` 在每个类别间隔保留刻度线，而标签仅每三个类别显示一次。使用[setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-)并设为可见样式，以便看到效果。再次将任一自动间隔设置器设为 `true`，图表将重新选择该间隔。

下面的独立示例创建 24 个类别和一个系列，然后在 `CategoryAxisIntervals.pptx` 中保存三张幻灯片：自动间隔、带独立刻度线的手动标签间隔以及恢复的自动间隔。两个副本保留原始图表数据。无需输入演示文稿。水平标签文本使密度差异易于观察。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // 第2页：每三个标签显示一次，但每个类别保留刻度线。
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 第3页：让图表再次自行选择标签和刻度的间隔。
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自动间隔（幻灯片 1）：**  
在此渲染中，每第二个类别标签会显示，并换行为两行。自动结果可能随图表大小、字体和渲染器而异。

![所有 24 列可见的自动类别标签间隔](category-axis-automatic.png)

**手动间隔（幻灯片 2）：**  
每第三个标签显示在一行上，而刻度线仍保持在每个类别间隔。所有 24 列，包括未标记的列，仍保持可见且数值相同。第 3 张幻灯片恢复上述自动外观。

![所有 24 列可见的手动类别标签间隔（间隔为三）](category-axis-manual.png)

### **选择正确的坐标轴和间隔**

在文本类别坐标轴（如柱形图、折线图、面积图或条形图的类别坐标轴）上使用此类别计数间隔。在柱形图中，它是水平坐标轴；在水平条形图中，类别坐标轴是垂直的，因此将这些设置应用于 [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 返回的坐标轴。刻度间隔同样适用于具有系列坐标轴的图表的系列坐标轴。

不要使用类别标签间隔来设置数值坐标轴的数值刻度。在数值坐标轴上，[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) 指定数值差异，例如，主单位为 `10` 时，轴从零开始会在 0、10、20 等处生成刻度。 `3` 的类别标签间隔则是按类别位置计数， 与其数据值无关。散点图和气泡图使用数值坐标轴而非文本类别坐标轴。对于日期坐标轴，请使用[更改类别坐标轴](#更改类别坐标轴)中描述的基于时间的主单位和比例。

## **为类别坐标轴值设置日期格式**

示例将默认图表数据替换为四个年度值。日期以 OLE Automation 序列号存储在第一张工作表（索引 `0`）中，表示自 1899 年 12 月 30 日起的天数。使用[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-)并传入 `CategoryAxisType.Date`，调用[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-)并传入 `false`，再将 `yyyy` 传递给[setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-)，使类别标签独立于单元格格式显示四位数年份。

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **为图表坐标轴标题设置旋转角度**

对纵向坐标轴调用[setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-)并传入 `true`，提供标题文本，再使用[setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-)旋转标题。角度以度为单位；此示例保存一个柱形图，其数值轴标题旋转了 90 度。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在类别或数值坐标轴上设置坐标轴位置**

使用[setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-)控制数值坐标轴是跨类别之间还是在类别刻度线处交叉类别坐标轴。此设置适用于类别坐标轴。示例在柱形图的水平类别坐标轴上将其设为 `true` 并保存结果。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在图表数值坐标轴上设置显示单位**

使用[setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-)在不更改底层数据的情况下缩放数值坐标轴上的标签。将[DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) 设置为 `Millions` 时，60000000 会显示为 60。示例创建一个柱形图，并在其纵向坐标轴上应用百万显示单位。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **配置对数数值坐标轴**

当正值跨越多个数量级时，对数数值坐标轴非常有用。例如，一个服务在五个周期内可能收到 10、100、1,000、10,000 和 100,000 次请求。在线性刻度下，较小的值会聚集在靠近零的位置。对数刻度使相对增长更易比较：相等的距离代表相等的比例，而非相等的差值。

对数值坐标轴调用[setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-)并传入 `true`，使用[setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-)选择基数。这会改变现有值的显示方式；但不更改数据，也不添加对数趋势线。趋势线表示数据的拟合关系，是另一功能。

### **选择数值坐标轴和基数**

对于折线图或柱形图，数值坐标轴由[getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--)返回。对于水平条形图，数值坐标轴由[getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--)返回。散点图和气泡图有两个数值坐标轴，可为 X 值选择水平坐标轴，为 Y 值选择垂直坐标轴，或同时选择。不要对类别坐标轴应用对数刻度。

默认的对数基数为 `10`。对于 PPTX 图表，基数可使用 `2` 到 `1000`（含）之间的值；也支持如 `2.5` 的小数基数。使用基数 `10` 时，后续的 10、100、1,000、10,000 等幂次间距相等。

### **比较线性和对数刻度**

下面的独立示例在第一张幻灯片创建一个包含五个请求计数的折线图，然后克隆该幻灯片并在第二张幻灯片上启用基数为 10 的对数数值坐标轴。两张幻灯片保留相同的数据。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // 保持第一张幻灯片为线性，并仅更改副本的数值坐标轴刻度。
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**线性刻度（幻灯片 1）：**  
相等的垂直距离代表请求计数的相等差值。最大值主导图表，使得较小的值难以辨别。

![PowerPoint 中的折线图，显示在线性数值坐标轴上的五个请求计数](value-axis-linear.png)

**对数刻度（幻灯片 2）：**  
相等的垂直距离代表相等的比例。每个周期的请求量是前一个周期的十倍，因此点在基数为 10 的刻度上形成一条直线上升线。坐标轴标签仍显示原始的请求计数。

![PowerPoint 中同样的五个请求计数，在基数为 10 的对数数值坐标轴上](value-axis-logarithmic.png)

### **处理零和负值**

对数刻度只能显示严格正值。启用前请检查数据。如果零或负值具有意义，保持线性刻度或单独显示它们。如果在分析中排除这些值是合适的，请说明省略原因。不要悄悄将其替换为小的正数，因为这会改变数据的含义。对数坐标轴的手动最小值或最大值也必须为正数。

## **常见问题**

**如何设置一个坐标轴交叉另一坐标轴的数值（坐标轴交叉）？**

使用[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-)选择交叉行为。若要指定数值交叉点，使用[setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-)。这些设置可将坐标轴交叉移动到合适的基线。

**如何相对坐标轴定位刻度标签？**

使用[setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-)并结合[TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/)：`Low`、`High`、`NextTo` 或 `None`。若要控制刻度线本身，使用[setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-)或[setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-)；这些与标签定位是独立的。