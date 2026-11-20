---
title: 在 Android 上的演示文稿中自定义图表坐标轴
linktitle: 图表坐标轴
type: docs
url: /zh/androidjava/chart-axis/
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
- Android
- Java
- Aspose.Slides
description: "了解如何通过 Java 使用 Aspose.Slides for Android 在 PowerPoint 演示文稿中自定义图表坐标轴，以用于报告和可视化。"
---
## **概述**

本文说明了如何使用 Aspose.Slides for Android（Java）自定义图表坐标轴。内容涵盖计算后的坐标轴值、切换图表的行列、坐标轴可见性、类别标签和刻度间隔、日期类别及格式化、标题旋转、坐标轴定位、显示单位以及对数比例。

## **获取图表垂直坐标轴的最大值**

创建一个 [演示文稿](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 并添加一个默认数据的面积图。在读取计算后的坐标轴值之前，调用 [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) 以确保图表布局是最新的。

读取 [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) 和 [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) 以获取坐标轴上下限，读取 [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) 和 [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) 以获取刻度间隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) 和 [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) 提供时间单位比例，适用于日期坐标轴。示例将这些值存入本地变量并保存图表。

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

使用 [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) 可交换图表数据中系列和类别的角色。每个原来的类别变为系列，每个原来的系列变为类别。这会改变数据的分组方式，但不会交换水平和垂直坐标轴。示例在切换行列之前，使用 [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) 将默认数据绑定到 `Sheet1!A1:D5`，包括标题行和类别列。它保存了一个包含四个系列和三个类别的图表。

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

使用 [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) 可以反转类别坐标轴或数值坐标轴。例如，水平条形图可以按照工作表中的顺序（自上而下）显示项目阶段：Planning、Development、Testing。反转坐标轴会改变绘制方向，但不会对工作簿数据进行排序或重新排列。相比之下，[switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) 交换系列和类别的角色。

下面的示例创建一个包含三个阶段和一个系列的水平条形图。它保存一个包含三张幻灯片的演示文稿：正常顺序、类别反转、数值反转。每个副本使用相同的数据集，并且在每个副本中仅反转一个坐标轴。

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
    // 将水平数值坐标轴保持在底部。
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // 幻灯片 3：仅反转水平数值刻度。
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

反转坐标轴还可以将垂直坐标轴移动到绘图的另一侧。[setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) 控制另一坐标轴与当前配置坐标轴的交叉位置。在第 2 张幻灯片中，对反转的类别坐标轴调用 `CrossesType.Maximum` 可保持水平数值坐标轴位于底部。若需特定的交叉点，请使用 [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-)。在改变方向时检查交叉设置，尤其是当图表已经具有自定义交叉点时。调用 `setPlotOrderReversed` 并传入 `false` 可恢复正常绘制方向；交叉设置是独立的。

| 普通顺序（幻灯片 1） | 类别反转（幻灯片 2） | 数值反转（幻灯片 3） |
| --- | --- | --- |
| ![水平条形图，类别和数值坐标轴顺序正常](axis-order-normal.png) | ![水平条形图，类别从上到下显示](axis-order-categories-reversed.png) | ![水平条形图，数值坐标轴反转，零在右侧](axis-order-values-reversed.png) |
| 类别从底部到顶部；数值从左向右递增。 | Planning、Development 和 Testing 从上到下排列。数值和工作表行顺序保持不变。 | 类别保持正常顺序；数值从右向左递增。类别坐标轴在右侧零点交叉。 |

## **为折线图禁用垂直坐标轴**

在垂直坐标轴上调用 [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) 并传入 `false` 以隐藏它。示例创建一个默认数据的折线图并保存时隐藏垂直坐标轴。

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

## **为折线图禁用水平坐标轴**

在水平坐标轴上调用 [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) 并传入 `false` 以隐藏它。示例创建一个默认数据的折线图并保存时隐藏水平坐标轴。

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

调用 [getShowMajorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMajorGridLines--) 和 [getShowMinorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMinorGridLines--) 可检查坐标轴显示哪些网格线。这些方法返回当前的可见性。要显示次网格线，请使用 [getMinorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) 并将其线填充设置为实色且可见。要隐藏它们，请将填充设为 [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/#NoFill)。使用 [getMajorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) 以同样方式更改主网格线的线填充。更改填充不会影响坐标轴的可见性和刻度标记。

此簇状柱形图的垂直坐标轴最初仅显示主网格线。示例将次网格线显示为深橙色，然后在保存演示文稿前再次隐藏。它在每一步都打印网格线的可见性。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(Color.rgb(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 次网格线显示 | 次网格线隐藏 |
| --- | --- |
| ![垂直坐标轴上主网格线之间的橙色次网格线](minor-gridlines-enabled.png) | ![仅显示主网格线的相同柱形图](minor-gridlines-hidden.png) |

## **更改类别坐标轴**

使用 [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) 可选择日期或文本类别坐标轴。此示例需要 `ExistingChart.pptx`，其中图表位于第一张幻灯片的第一个形状，类别单元格包含数值型 Excel 日期。它将水平坐标轴改为日期坐标轴。调用 [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) 并传入 `false`，[setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) 设为 `1`，以及 [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) 设为 `TimeUnitType.Months`，即可将主刻度设置为每月一次。

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

### **根据数据确定类别坐标轴类型**

在填充类别后调用 [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--)，随后读取 [getCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getCategoryAxisType--) 以检查所选类型。当同一图表可能收到文本标签或数值日期时，这很有用。该方法在调用时确定类型；不会启用在后续数据更改时重新评估的持久模式。在替换类别后再次调用它。

以下示例创建一个带文本类别的图表，当选中的类型为 `CategoryAxisType.Text` 时打印 `true`。随后将类别单元格的值替换为日期并再次调用该方法，当选中的类型为 `CategoryAxisType.Date` 时同样打印 `true`。日期以数值型 OLE Automation 序列号存储，计算方式为自 1899 年 12 月 30 日起的天数，而非日期字符串。两个日历均使用 UTC，并在设置日期前清除，以免夏令时和当前时间影响计算。[setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) 控制这些值的显示方式；它不会将文本转换为数值日期。有关类别单元格的更多信息，请参阅 [Chart Workbook](/slides/zh/androidjava/chart-workbook/)。

当已知输入包含文本类别或数值日期时（如本示例），使用自动确定。对于普通数值标签、混合类别或空数据，请显式调用 [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisType-int-) 以匹配预期含义。仅有数值并不能说明类别代表日期。

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

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
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // 真

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);
    int[][] dates = { { 2026, Calendar.JANUARY, 1 }, { 2026, Calendar.JANUARY, 2 }, { 2026, Calendar.FEBRUARY, 1 } };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(dates[i][0], dates[i][1], dates[i][2]);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        categoryCell.setValue(serialDate);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // 真

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制类别坐标轴标签间隔**

当图表拥有大量类别时，可在不删除类别或数据点的前提下减少可见坐标轴标签的数量。调用 [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) 并传入 `false`，随后将所需的类别间隔传递给 [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-)。对于正常顺序的文本类别，计数从第一个类别开始：

| 间隔 | 示例中显示的标签 |
| --- | --- |
| `1` | 类别 1, 类别 2, 类别 3, ... 类别 24 |
| `2` | 类别 1, 类别 3, 类别 5, ... 类别 23 |
| `3` | 类别 1, 类别 4, 类别 7, ... 类别 22 |

`3` 的间隔会每隔三个标签显示一次，在显示的标签之间隐藏两个标签。它不会删除相应的列。自动间距会根据可用空间选择间隔；不一定显示所有标签。

刻度线有独立的控制。调用 [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) 并传入 `false`，再使用 [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) 设置其间隔。例如，`1` 在每个类别间隔保持刻度线，而标签仅每第三个类别出现一次。使用带可见样式的 [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) 以便看到效果。再次将任一自动间距设置器设为 `true`，图表会重新选择间隔。

以下独立示例创建 24 个类别和一个系列，然后在 `CategoryAxisIntervals.pptx` 中保存三张幻灯片：自动间距、带独立刻度线的手动标签间距，以及恢复的自动间距。两个副本保留原始图表数据。无需输入演示文稿。水平标签文本使密度差异易于观察。

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

    // 幻灯片 2：每三个标签显示一次，但每个类别都保留刻度线。
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

**自动间距（幻灯片 1）：** 在此渲染中，每隔第二个类别标签显示一次，并换行成两行。自动结果可能随图表大小、字体和渲染器而变化。

![所有 24 列均可见的自动类别标签间距](category-axis-automatic.png)

**手动间距（幻灯片 2）：** 每三个标签显示在一行，而刻度线仍保持在每个类别间隔。所有 24 列（包括没有标签的列）仍然可见且值相同。幻灯片 3 恢复上述的自动外观。

![所有 24 列均可见的手动类别标签间隔三](category-axis-manual.png)

### **选择正确的坐标轴和间隔**

对于文本类别坐标轴（如柱形图、折线图、面积图或条形图的类别坐标轴），使用此类别计数间隔。在柱形图中它是水平坐标轴；在水平条形图中，类别坐标轴是垂直的，因此将这些设置应用于 [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 返回的坐标轴。在具有系列坐标轴的图表中，刻度间距同样适用于系列坐标轴。

不要使用类别标签间隔来设置数值坐标轴的数值刻度。在数值坐标轴上，[setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) 指定数值差异，例如，当坐标轴从零开始时，主单位为 `10` 会在 0、10、20 等处生成刻度。而类别标签间隔 `3` 仅统计类别位置，与其数据值无关。散点图和气泡图使用数值坐标轴而不是文本类别坐标轴。对于日期坐标轴，请使用基于时间的主单位和比例，参考 [更改类别坐标轴](#change-a-category-axis)。

## **为类别坐标轴值设置日期格式**

示例将默认图表数据替换为四个年度值。日期以 OLE Automation 序列号存储在第一个工作表（索引 `0`）中，计算方式为自 1899 年 12 月 30 日起的天数。两个日历均使用 UTC，并在设置日期前进行清除，以免夏令时和当前时间影响计算。使用 [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) 并传入 `CategoryAxisType.Date`，调用 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) 并传入 `false`，再将 `yyyy` 传递给 [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-)，使类别标签显示四位年份且不受单元格格式影响。

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
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

在垂直坐标轴上调用 [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) 并传入 `true`，提供标题文本，然后使用 [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) 旋转标题。角度以度为单位；本示例保存了一个列形图，其数值坐标轴标题旋转了 90 度。

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

使用 [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) 可控制数值坐标轴是穿过类别坐标轴的类别之间还是在类别刻度线上。此设置适用于类别坐标轴。示例在柱形图的水平类别坐标轴上将其设为 `true` 并保存结果。

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

## **为图表数值坐标轴设置显示单位**

使用 [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) 可在不更改底层数据的情况下缩放数值坐标轴的标签。将 [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) 设置为 `Millions` 时，60000000 会显示为 60。示例创建一个柱形图并对其垂直坐标轴使用百万显示单位。

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

当正值跨越多个数量级时，对数数值坐标轴非常有用。例如，一个服务在五个周期内可能收到 10、100、1,000、10,000 和 100,000 次请求。在线性尺度下，较小的值会聚集在接近零的地方。对数尺度使它们的相对增长更易比较：相等的距离代表相等的比例，而非相等的差值。

在数值坐标轴上调用 [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) 并传入 `true`，并使用 [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) 选择底数。此操作仅改变已有值的显示方式，不会更改数据或添加对数趋势线。趋势线表示对数据的拟合关系，是独立的功能。

### **选择数值坐标轴和底数**

对于折线图或柱形图，数值坐标轴通过 [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 返回。对于水平条形图，数值坐标轴通过 [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) 返回。散点图和气泡图有两个数值坐标轴，因此可选择水平坐标轴作为 X 值，垂直坐标轴作为 Y 值，或两者皆用。不要对类别坐标轴应用对数比例。

默认的对数底数为 `10`。对于 PPTX 图表，底数可取 `2` 到 `1000`（含），也支持如 `2.5` 的小数底数。使用底数 `10` 时，后续的 10、100、1,000、10,000 等幂次等间距。

### **比较线性和对数比例**

以下独立示例在第一页创建一个包含五个请求计数的折线图，然后克隆该幻灯片并在第二页启用底数为 10 的对数数值坐标轴。两个幻灯片保留相同的数据。

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

    // 保持第一张幻灯片为线性，仅更改副本的数值坐标轴比例。
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

**线性比例（幻灯片 1）：** 相等的垂直距离代表请求计数的相等差值。最大值主导图表，使较小的值难以辨别。

![PowerPoint 中的折线图，显示线性数值轴上的五个请求计数](value-axis-linear.png)

**对数比例（幻灯片 2）：** 相等的垂直距离代表相等的比例。每个周期的请求量是前一个的十倍，因此在底数为 10 的尺度上点形成一条直线上升线。坐标轴标签仍显示原始的请求计数。

![PowerPoint 中相同的五个请求计数，使用底数为 10 的对数数值坐标轴](value-axis-logarithmic.png)

### **处理零值和负值**

对数尺度只能显示严格正数。启用前请检查数据。如果零或负数有实际意义，请保持线性尺度或单独显示它们。如果在分析中排除这些值是合适的，请说明省略原因。不要悄悄将它们替换为小的正数，因为这会改变数据含义。对数坐标轴的任何手动设定的最小值或最大值也必须为正数。

## **常见问题**

**如何设置一个坐标轴与另一个坐标轴交叉的数值（坐标轴交叉）？**

使用 [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) 选择交叉行为。若需指定数值交叉点，请使用 [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-)。这些设置可让您将坐标轴交叉点移动到合适的基线。

**如何相对于坐标轴定位刻度标签？**

调用 [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) 并使用 [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`、`High`、`NextTo` 或 `None`。若要控制刻度线本身，请使用 [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) 或 [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); 这些与标签定位是分开的。