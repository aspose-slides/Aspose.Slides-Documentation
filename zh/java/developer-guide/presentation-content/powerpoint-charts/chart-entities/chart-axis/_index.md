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

本文说明了如何使用 Aspose.Slides for Java 自定义图表坐标轴。内容包括计算坐标轴值、切换图表行列、坐标轴可见性、类别标签和刻度间隔、日期类别和格式、标题旋转、坐标轴定位、显示单位以及对数缩放等。

## **获取图表垂直轴的最大值**

创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)并添加默认数据的面积图。在读取计算坐标轴值之前调用[validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--)，以确保图表布局是最新的。

读取[getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--)和[getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--)获取坐标轴范围，读取[getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--)和[getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--)获取刻度间隔。 [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--)和[getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--)提供时间单位比例，适用于日期坐标轴。示例将这些值存入局部变量并保存图表。

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

使用[switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--)来交换系列和类别在图表数据中的角色。每个原来的类别会变成系列，每个原来的系列会变成类别。这会改变数据的分组方式，但不会交换水平和垂直坐标轴。示例使用[setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-)将默认数据绑定到`Sheet1!A1:D5`（包括标题行和类别列），然后切换行列。它保存了一个包含四个系列和三个类别的图表。

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

使用[setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-)可以反转类别坐标轴或数值坐标轴。例如，水平条形图可以按照工作表中的顺序自上而下显示项目阶段：Planning、Development、Testing。反转坐标轴仅改变绘制方向，不会对工作簿数据进行排序或重新排列。相比之下，[switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--)交换的是系列和类别的角色。

下面的示例创建一个包含三个阶段和一个系列的水平条形图。它保存了三张幻灯片：正常顺序、类别反向、数值反向。每个副本使用相同的数据集，仅在每个副本中反转一个坐标轴。

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

    // 幻灯片 2：在顶部显示第一个类别。
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // 保持水平数值轴在底部。
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // 幻灯片 3：仅反转水平数值尺度。
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

反转坐标轴还可以将垂直坐标轴移动到绘图区的另一侧。[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-)控制另一坐标轴在被配置坐标轴上的交叉位置。在第 2 张幻灯片中，对已反转的类别坐标轴调用`CrossesType.Maximum`，可以保持水平数值坐标轴位于底部。若需指定具体的交叉点，请使用[setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-)。在更改方向时请检查交叉设置，特别是图表已有自定义交叉点的情况。调用`setPlotOrderReversed`并传入`false`可恢复正常绘制方向；交叉设置是独立的。

| 正常顺序（幻灯片 1） | 类别反向（幻灯片 2） | 数值反向（幻灯片 3） |
| --- | --- | --- |
| ![水平条形图，类别和数值轴顺序正常](axis-order-normal.png) | ![水平条形图，类别自上而下显示](axis-order-categories-reversed.png) | ![水平条形图，数值轴反向且零位于右侧](axis-order-values-reversed.png) |
| 类别从底部到顶部；数值从左向右递增。 | Planning、Development、Testing 从顶部到底部排列。数值及工作表行顺序保持不变。 | 类别保持正常顺序；数值从右向左递增。类别坐标轴在右侧零点处交叉。 |

## **为折线图隐藏垂直坐标轴**

在垂直坐标轴上调用[setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-)并传入`false`即可隐藏它。示例创建一个默认数据的折线图并保存垂直坐标轴已隐藏的版本。

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

## **为折线图隐藏水平坐标轴**

在水平坐标轴上调用[setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-)并传入`false`即可隐藏它。示例创建一个默认数据的折线图并保存水平坐标轴已隐藏的版本。

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

## **显示或隐藏图表网格线**

调用[getShowMajorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMajorGridLines--)和[getShowMinorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMinorGridLines--)可以检查坐标轴当前显示哪些网格线。这些方法返回当前的可见性。若要显示次要网格线，请使用[getMinorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMinorGridLinesFormat--)并将其线填充设为实色、可见的颜色。要隐藏它们，将填充设为[FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/#NoFill)。使用[getMajorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMajorGridLinesFormat--)以相同方式更改主网格线的线填充。更改填充不会影响坐标轴的可见性和刻度标记。

此聚类柱形图的垂直坐标轴最初仅显示主网格线。示例将次要网格线显示为深橙色，随后再次隐藏它们并保存演示文稿。每一步都会打印网格线的可见性。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(new Color(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 启用的次要网格线 | 隐藏的次要网格线 |
| --- | --- |
| ![垂直轴上主要网格线之间的橙色次要网格线](minor-gridlines-enabled.png) | ![相同的柱形图，仅显示主要网格线](minor-gridlines-hidden.png) |

## **更改类别坐标轴**

使用[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-)可以选择日期或文本类别坐标轴。此示例需要 `ExistingChart.pptx`，其中第一张幻灯片的第一形状是一张图表，类别单元格包含 Excel 数字日期值。它将水平坐标轴改为日期轴。调用[setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-)并传入`false`，随后调用[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-)并设为`1`，再调用[setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-)并设为`TimeUnitType.Months`，即可在每月间隔放置主刻度。

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

### **根据数据自动确定类别坐标轴类型**

在填充完类别后调用[setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--)，随后读取[getCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getCategoryAxisType--)以检查选择的类型。当同一图表可能使用文本标签或数字日期值时，这非常有用。该方法在调用时确定类型；不会开启后续数据更改的持续评估模式。更换类别后请再次调用。

下面的示例创建一个使用文本类别的图表，并在选中的类型为 `CategoryAxisType.Text` 时打印 `true`。随后将类别单元格的值替换为日期，再次调用该方法并在选中的类型为 `CategoryAxisType.Date` 时打印 `true`。日期以 OLE Automation 数值存储，计算方式为自 1899 年 12 月 30 日起的天数，而非日期字符串。使用[setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-)可以控制这些数值的显示方式，但不会将文本转换为数字日期。有关类别单元格的更多信息，请参阅[Chart Workbook](/slides/zh/java/chart-workbook/)。

在已知输入仅包含文本类别或数字日期的情况下使用自动确定。如为普通数值标签、混合类别或空数据，请显式调用[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisType-int-)以匹配预期含义。仅有数值并不能自动认定类别代表日期。

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    String[] labels = { "First", "Second", "Third" };

    for (int i = 0; i < labels.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // true

    LocalDate baseDate = LocalDate.of(1899, 12, 30);
    LocalDate[] dates = { LocalDate.of(2026, 1, 1), LocalDate.of(2026, 1, 2), LocalDate.of(2026, 2, 1) };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        categoryCell.setValue((double)(dates[i].toEpochDay() - baseDate.toEpochDay()));
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // true

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制类别坐标轴标签间隔**

当图表包含大量类别时，可在不删除类别或数据点的前提下降低可见轴标签的数量。先调用[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-)并传入`false`，随后将期望的类别间隔传给[setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-)。对于正常顺序的文本类别，计数从第一个类别开始：

| 间隔 | 示例中显示的标签 |
| --- | --- |
| `1` | 类别 1, 类别 2, 类别 3, ... 类别 24 |
| `2` | 类别 1, 类别 3, 类别 5, ... 类别 23 |
| `3` | 类别 1, 类别 4, 类别 7, ... 类别 22 |

间隔为 `3` 时每隔两个标签显示一个标签，未显示的标签对应的列仍然保留。自动间隔会根据可用空间选择间隔，不一定会显示所有标签。

刻度线有独立的控制。调用[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-)并传入`false`，随后使用[setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-)设置其间隔。例如，`1` 表示在每个类别间隔都保留刻度线，而标签仅每隔三个类别显示一次。使用[setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-)并设为可见样式，以便看到效果。再次将任一自动间隔设置器设为`true`，图表会重新选择间隔。

下面的完整示例创建 24 个类别和一个系列，然后在 `CategoryAxisIntervals.pptx` 中保存三张幻灯片：自动间隔、手动标签间隔（刻度线独立）以及恢复自动间隔。两个副本保留原始图表数据，无需输入演示文稿。水平标签文本使密度差异一目了然。

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

    // 幻灯片 2：显示每第三个标签，但保持每个类别都有刻度线。
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 幻灯片 3：让图表再次自行选择两个间隔。
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自动间隔（幻灯片 1）**：在此渲染中，每隔一个类别标签显示一次，并换行至两行。自动结果会因图表尺寸、字体以及渲染器而异。

![自动类别标签间隔，所有 24 列均可见](category-axis-automatic.png)

**手动间隔（幻灯片 2）**：每隔三个标签显示一次，且刻度线仍保留在每个类别间隔。所有 24 列（包括未显示标签的列）仍保持可见且数值不变。幻灯片 3 恢复了上图所示的自动外观。

![手动类别标签间隔为三，所有 24 列均可见](category-axis-manual.png)

### **选择正确的坐标轴和间隔**

对文本类别坐标轴（例如柱形图、折线图、面积图或条形图的类别坐标轴）使用此类别计数间隔。在柱形图中，它是水平坐标轴；在水平条形图中，类别坐标轴是垂直的，因此应对[getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--)返回的坐标轴应用这些设置。刻度间隔同样适用于具有系列坐标轴的图表。

不要使用类别标签间隔来设置数值坐标轴的数值刻度。在数值坐标轴上，[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-)指定值的差异：例如，`10` 的主单位会在 0、10、20 等位置生成刻度。而类别标签间隔 `3` 仅计数类别位置，与数据值无关。散点图和气泡图使用数值坐标轴，而非文本类别坐标轴。对于日期坐标轴，请参阅[更改类别坐标轴](#change-a-category-axis)中描述的基于时间的主单位和比例。

## **为类别坐标轴值设置日期格式**

示例用四个年度值替换默认图表数据。日期以 OLE Automation 序列号存储在第一个工作表（索引 `0`）中，计算方式为自 1899 年 12 月 30 日起的天数。使用[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-)并设为 `CategoryAxisType.Date`，随后调用[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-)并传入`false`，再将 `yyyy` 传给[setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-)，即可使类别标签独立于单元格格式而显示四位年份。

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

在垂直坐标轴上调用[setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-)并传入`true`，提供标题文本，然后使用[setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-)旋转标题。角度以度数计量；本例将列形图的数值轴标题旋转了 90 度后保存。

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

使用[setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-)可以控制数值坐标轴是跨越类别之间还是在类别刻度线上与类别坐标轴相交。此设置适用于类别坐标轴。示例在柱形图的水平类别坐标轴上将其设为 `true` 并保存结果。

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

使用[setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-)可以在不更改底层数据的前提下对数值坐标轴标签进行缩放。将[DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/)设为 `Millions`，则 60,000,000 会显示为 60。示例创建一个柱形图并将其垂直坐标轴的显示单位设为百万。

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

当正值跨越多个数量级时，对数数值坐标轴非常有用。例如，某服务在五个周期内分别收到 10、100、1,000、10,000、100,000 次请求。在线性尺度下，较小的数值会聚集在接近零的位置。对数尺度使它们的相对增长更易比较：等距离代表等比例而非等差。

在数值坐标轴上调用[setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-)并传入`true`，再使用[setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-)选择基数。此操作仅改变现有数值的显示方式，不会修改数据或添加对数趋势线。趋势线是对数据进行拟合的独立功能。

### **选择数值坐标轴和基数**

对于折线图或柱形图，数值坐标轴由[getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--)返回。对于水平条形图，数值坐标轴由[getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--)返回。散点图和气泡图有两个数值坐标轴，可为 X 值选择水平坐标轴，为 Y 值选择垂直坐标轴，或同时使用。不要对类别坐标轴使用对数缩放。

默认对数基数为 `10`。对于 PPTX 图表，基数可取 `2` 到 `1000`（含），亦支持小数基数如 `2.5`。基数为 `10` 时，连续的幂次 10、100、1,000、10,000 等等间距相等。

### **比较线性和对数缩放**

下面的完整示例在第一张幻灯片上创建一个包含五个请求次数的折线图，然后克隆该幻灯片并在第二张上启用基数为 10 的对数数值坐标轴。两张幻灯片保留相同的数据。

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

    // 保持第一张幻灯片为线性，仅更改副本的数值轴比例。
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

**线性尺度（幻灯片 1）**：相同的垂直距离代表相同的请求次数差值。最大值主导图表，使得较小的值难以辨认。

![PowerPoint 中的折线图，使用线性数值轴显示五个请求次数](value-axis-linear.png)

**对数尺度（幻灯片 2）**：相同的垂直距离代表相同的比例。每个周期的请求次数是前一个的十倍，因此在基数为 10 的尺度上点形成一条直线上升线。坐标轴标签仍显示原始的请求次数。

![PowerPoint 中的相同五个请求次数，使用基数为 10 的对数数值轴](value-axis-logarithmic.png)

### **处理零值和负值**

对数尺度只能显示严格正数。启用前请检查数据。如果零或负数有意义，请保留线性尺度或单独显示它们。如果分析中可以排除这些值，请说明原因。不要悄悄将其替换为小的正数，因为这会改变数据含义。对数坐标轴的手动最小值或最大值也必须为正数。

## **常见问题**

**如何设置一个坐标轴与另一个坐标轴相交的位置（坐标轴交叉）？**

使用[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-)选择交叉行为。若需指定数值交叉点，请使用[setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-)。这些设置可将坐标轴交叉移动到合适的基线。

**如何相对于坐标轴定位刻度标签？**

调用[setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-)并使用[TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/)：`Low`、`High`、`NextTo` 或 `None`。若要控制刻度线本身，请使用[setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-)或[setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-)，这与标签位置是分开的。