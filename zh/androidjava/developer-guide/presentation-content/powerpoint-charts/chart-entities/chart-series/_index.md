---
title: 在 Android 上管理演示文稿中的图表数据系列
linktitle: 数据系列
type: docs
url: /zh/androidjava/chart-series/
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
- Android
- Java
- Aspose.Slides
description: "了解如何在 Android 上的演示文稿中管理图表系列、数据点、工作簿单元格、格式设置、重叠、间隙宽度以及负值。"
---
## **概述**

图表将其绘制的数据存储在图表数据工作簿中。一个[IChartSeries](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseries/)代表一组相关的值，系列中的每个[IChartDataPoint](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdatapoint/)对应一个或多个工作簿单元格。 [IChartCategory](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartcategory/)对象提供系列共享的标签或分组值。因此，系列名称、类别和点值连接到[IChartDataCell](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdatacell/)对象，而不是仅作为显示文本存储。

对于典型的类别图，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，其余单元格存放系列数值。传递给[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-)的工作表、行和列索引均为零基。此布局在创建默认数据的图表时很有用，但不要假设每个已有的图表都使用该布局。对于已加载的演示文稿，请在更改工作簿值之前检查系列、类别和数据点引用的单元格。

图表设置有三种不同的作用域：

- 系列级设置，例如[IChartSeries.getFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseries/#getFormat--)，为一个系列中的所有点提供默认外观。
- 数据点级设置，例如[IChartDataPoint.getFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)，覆盖该点的系列外观。
- 组设置适用于属于同一[IChartSeriesGroup](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseriesgroup/)的兼容系列。当需要设置诸如重叠或间隙宽度等选项时，通过[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--)访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当同时存在系列和点的格式设置时，点的格式设置优先于该点的系列格式。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseries/#getOverlap--) 报告 2D 图表中条形或柱形的重叠程度，范围为 -100 到 100%。它是父系列组设置的只读投影。使用[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) 可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；不会影响组合图中不相关的系列组。

下面的示例为包含第一系列的组设置重叠：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 新图表包含示例系列、类别和数值。
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![系列重叠](series_overlap.png)

## **更改系列填充颜色**

使用[IChartSeries.getFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseries/#getFormat--) 为整个系列设置默认填充。如果某个点已经具有显式填充，其[IChartDataPoint.getFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) 设置会覆盖该点的系列填充。

下面的示例为第一系列应用纯蓝色填充：

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![系列颜色](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚类柱形图创建的默认工作簿中，单元格 B1 位于第 0 行第 1 列，包含第一系列的名称。以下示例中的命名常量明确了该结构：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

你也可以更新由[IChartSeries.getName](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseries/#getName--) 已引用的单元格。这种做法避免假设现有图表中的特定行列：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![系列名称](series_name.png)

## **获取自动系列填充颜色**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) 返回根据系列索引和图表样式计算的 Android ARGB 颜色整数。这是未显式定义系列填充时使用的颜色。调用该方法仅读取计算出的颜色，不会分配新填充。

下面的示例打印每个默认系列的自动颜色整数：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

确切的整数值取决于图表样式和主题。

## **为图表系列设置负值反转填充颜色**

对于条形、柱形和气泡系列， [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 可以在负值时使用不同的填充。将常规系列填充设为实体色，启用反转，并通过[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 指定负值颜色。负数在工作簿中保持不变，仅改变其显示颜色。

下面的示例用一个系列替换默认图表数据。工作表第 0 行包含系列名称，第 0 列包含类别名称，第 1 列包含数值：

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![反转实体填充颜色](inverted_solid_fill_color.png)

你可以通过[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 为单个点启用反转。以下示例在系列上禁用反转，仅在所选点上启用，并为该点分配负值以显示效果：

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **清除特定数据点的值**

要使某一点为空而不移除其他点，请将其对应的工作簿单元格设为 `null`。对于柱形图，绘制的数值可通过[IChartDataPoint.getValue](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) 获取。数据点仍保留在相同的类别位置，但图表会根据空值设置将其视为空白。

下面的示例仅清除第一系列的第二个点：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

散点图使用单独的 X 和 Y 单元格，气泡图还使用尺寸单元格。仅清除表示你想删除的数值的单元格。不要在想保留其他点时调用[IChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)，因为该方法会删除集合中的所有数据点。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，以条形或柱形宽度的百分比表示。类似于重叠，它属于父系列组而不是单个系列。对该组调用一次[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) 即可。更大的值会在簇之间产生更多空间，较小的值会使它们更紧密。

下面的示例更改间隙宽度并仅保存最终演示文稿：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![间隙宽度](gap_width.png)

## **常见问题解答**

**哪些图表类型支持数据系列？**

所有由[ChartType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/charttype/) 枚举表示的图表类型均使用图表数据，但其系列并非都拥有相同的值结构或设置。例如，类别图使用类别和数值，散点图使用 X 和 Y 值，气泡图还添加气泡大小。使用与系列类型相匹配的数据点创建方法。重叠和间隙宽度等选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[IChartSeriesGroup](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseriesgroup/) 包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过某个系列访问的组的更改不一定会影响图表中的所有系列。

**新建的图表是否包含默认数据？**

是的。默认情况下，[IShapeCollection.addChart](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) 会创建示例系列、类别和数值。你可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。还有一种重载方式可在不创建默认数据的情况下创建图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点数值引用[IChartDataWorkbook](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdataworkbook/) 中的单元格。更改引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行与系列值行对齐，以便每个点绘制在预期的类别下。

**如何只清除一个点而不是整个系列？**

将相应的值单元格设为 `null`，即可保留该点的类别位置作为空点。仅在想删除该系列所有点时才使用[IChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)。

**空点如何显示？**

显示方式取决于图表类型以及通过[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 配置的值。受支持的图表可以将空白显示为间隙、零值或连接相邻点。请选择符合演示文稿中缺失数据含义的设置。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，调用[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 并设置通过[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 返回的颜色。可使用[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 为单独点覆盖此行为。这些方法影响格式，而不改变存储的数值。

**当系列和点都被格式化时，哪种格式生效？**

显式的数据点格式在该点上优先。其他点继续使用显式的系列格式，或在系列格式未定义时使用自动的图表样式和主题。组设置（如重叠和间隙宽度）控制布局，不属于点级格式覆盖。

**图表能包含的系列数量是否有限制？**

Aspose.Slides 并未设定单独的固定系列数量限制。实际使用中，演示文稿文件的约束、可用内存、渲染时间以及图表可读性决定了实用的上限。

**当柱形之间过于靠近或过于分散时应如何调整？**

对相应的父系列组调用[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)。增大数值可扩大簇间间距，减小数值则使簇更紧凑。