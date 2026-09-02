---
title: 在 Java 中管理演示文稿的图表数据系列
linktitle: 数据系列
type: docs
url: /zh/java/chart-series/
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
- Java
- Aspose.Slides
description: "了解如何在使用 Java 的演示文稿中管理图表系列、数据点、工作簿单元格、格式设置、重叠、间隙宽度和负值。"
---
## **概述**

图表将其绘制的数据存储在图表数据工作簿中。一个[IChartSeries](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseries/)表示一组相关值，系列中的每个[IChartDataPoint](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatapoint/)对应一个或多个工作簿单元格。[IChartCategory](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartcategory/)对象提供系列共享的标签或分组值。因此，系列名称、类别和点值连接到[IChartDataCell](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatacell/)对象，而不是仅作为显示文本存储。

对于典型的类别图，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，其余单元格存放系列值。传递给[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-)的工作表、行和列索引是从零开始的。这种布局在创建带默认数据的图表时很有用，但不要假设每个已有图表都使用它。对于已加载的演示文稿，请在更改工作簿值之前检查系列、类别和数据点所引用的单元格。

图表设置有三种不同的作用域：

- 系列级设置，例如[IChartSeries.getFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseries/#getFormat--)，为同一系列中的所有点提供默认外观。
- 数据点级设置，例如[IChartDataPoint.getFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatapoint/#getFormat--)，覆盖该点的系列外观。
- 组设置适用于属于同一[IChartSeriesGroup](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseriesgroup/)的兼容系列。当需要设置重叠或间隙宽度等选项时，通过[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--)访问该组。

当未明确设置点或系列填充时，图表样式和主题决定自动外观。当系列和点的格式均存在时，点的格式优先适用于该点。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseries/#getOverlap--)报告2D 图表中条形或柱形的重叠程度，范围为 -100 到 100 百分比。它是对父系列组设置的只读投影。使用[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-)可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图中不相关的系列组没有影响。

下面的示例为包含第一系列的组设置重叠：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 新的图表包含示例系列、类别和数值。
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The series overlap](series_overlap.png)

## **更改系列填充颜色**

使用[IChartSeries.getFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseries/#getFormat--)为整个系列设置默认填充。如果某个点已经有显式填充，其[IChartDataPoint.getFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatapoint/#getFormat--)设置会覆盖该点的系列填充。

下面的示例为第一系列应用纯蓝色填充：

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![The color of the series](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚簇柱形图创建的默认工作簿中，单元格 B1 位于第 0 行第 1 列，包含第一系列的名称。下面示例中的命名常量明确了该结构：

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

您也可以直接更新[IChartSeries.getName](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseries/#getName--)已引用的单元格。此方法避免对现有图表的特定行列作出假设：

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

![The series name](series_name.png)

## **获取自动系列填充颜色**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--)返回根据系列索引和图表样式计算的颜色。这是未显式定义系列填充时使用的颜色。调用该方法只读取计算出的颜色，不会分配新的填充。

下面的示例打印每个默认系列的自动颜色：

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

默认图表样式的示例输出：

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

确切颜色取决于图表样式和主题。

## **为图表系列设置反转填充颜色**

对于条形、柱形和气泡系列，[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)可以在负值时使用不同的填充。将常规系列填充设为实色，启用反转，并通过[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)分配负值颜色。工作簿中的负数保持不变，仅改变其显示颜色。

下面的示例用一个系列替换默认图表数据。工作表第 0 行包含系列名称，第 0 列包含类别名称，第 1 列包含数值：

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
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

![The inverted solid fill color](inverted_solid_fill_color.png)

您可以通过[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)为单个点启用反转。在下面的示例中，系列的反转被禁用，仅为选定的点启用，并为该点分配负值以便效果可见：

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
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

要使某一点为空而不删除其他点，请将其对应的工作簿单元格设为 `null`。对于柱形图，绘制的值可通过[IChartDataPoint.getValue](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatapoint/#getValue--)获取。数据点仍保持在相同的类别位置，但图表会根据空值设置将其视为空白。

下面的示例仅清除第一系列中的第二个点：

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

散点图使用单独的 X 和 Y 单元格，气泡图还使用大小单元格。仅清除表示您想移除的数值的单元格。不要在想保留其他点时调用[IChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatapointcollection/#clear--)，因为该方法会删除集合中的所有数据点。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，以条形或柱形宽度的百分比表示。与重叠类似，它属于父系列组而非单个系列。对该组调用一次[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)即可。数值越大，簇之间的空间越大；数值越小，簇越密集。

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

![The gap width](gap_width.png)

## **常见问题**

**哪些图表类型支持数据系列？**

由[ChartType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/charttype/)枚举表示的所有图表类型都使用图表数据，但它们的系列并非全部具有相同的值结构或设置。例如，类别图使用类别和数值，散点图使用 X 与 Y 值，气泡图还增加气泡大小。请使用与系列类型相匹配的数据点创建方法。重叠和间隙宽度等选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[IChartSeriesGroup](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseriesgroup/)包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过某一系列访问的组的更改不一定会影响图表中的所有系列。

**新创建的图表是否包含默认数据？**

是的。默认情况下，[IShapeCollection.addChart](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-)会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。还有重载方法可创建不带默认数据的图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点值引用[IChartDataWorkbook](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdataworkbook/)中的单元格。更改所引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行与系列值行对齐，以便每个点绘制在预期的类别下。

**如何只清除一个点而不是整个系列？**

将相关的值单元格设为 `null`，即可保留该点的类别位置但将其设为空点。仅在希望移除该系列的所有点时才使用[IChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatapointcollection/#clear--)。

**空点如何显示？**

显示结果取决于图表类型以及通过[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)配置的值。受支持的图表可以将空白显示为间隙、零值或通过连接相邻点来显示。请选择符合您演示文稿中缺失数据意义的设置。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，调用[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)并设置[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)返回的颜色。您也可以通过[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)为单个点覆盖此行为。这些方法影响格式，而非存储的数值。

**当系列和点都进行格式化时，哪个生效？**

显式的数据点格式在该点上具有最高优先级。其他点继续使用显式的系列格式，或者在未定义系列格式时使用自动的图表样式和主题。组设置（如重叠和间隙宽度）控制布局，不属于点级格式覆盖。

**图表可以包含多少系列，有没有限制？**

Aspose.Slides 并未施加单独的固定系列计数限制。实际限制取决于演示文稿文件的约束、可用内存、渲染时间以及图表的可读性。

**当列太靠近或太分散时该怎么办？**

对相应的父系列组调用[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)。增大该值可扩大簇之间的空间，减小则使簇更紧凑。