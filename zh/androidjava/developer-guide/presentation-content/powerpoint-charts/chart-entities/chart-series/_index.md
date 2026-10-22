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
- 系列间距
- 负值
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何在 Android 演示文稿中管理图表系列、数据点、工作簿单元格、格式设置、重叠、间距宽度和负值。"
---
## **概述**

图表可以将绘制的数值存储在工作簿单元格中，或直接使用数值文字。一个[IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) 表示一组相关值，而每个[IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) 表示该系列中的一个点。[IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) 对象提供系列共享的标签或分组值。 在使用默认数据创建的图表中，系列名称、类别和点值使用来自图表工作簿的[IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) 对象。

对于典型的类别图表，默认工作簿使用第0行存放系列名称，第0列存放类别名称，其余单元格用于系列数值。传递给[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) 的工作表、行和列索引是从零开始计数的。此布局在创建带有默认数据的图表时很有用，但不要假设每个已有图表都使用该布局。对于已加载的演示文稿，在更改工作簿数值之前，请检查系列、类别和数据点所引用的单元格。

图表设置有三种不同的作用域：

- 系列级别设置，例如[IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--)，提供单个系列中所有点的默认外观。
- 数据点级别设置，例如[IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)，覆盖单个点的系列外观。
- 组设置适用于属于同一[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) 的兼容系列。当需要设置如重叠或间距宽度等选项时，可通过[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) 访问该组。

当未设置显式的点或系列填充时，图表样式和主题决定自动外观。若同时存在系列和点的格式设置，则点的格式设置优先于该点的系列设置。

![图表系列 PowerPoint](chart-series-powerpoint.png)

## **使用数值文字设置系列值**

当系列值来自应用程序数据或计算且不需要工作表单元格引用时，请使用数值文字。 在为每个点的[getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) 结果通过[setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-) 赋值之前，先使用[DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) 调用[setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-)。

集合设置控制该系列中所有点值的来源类型。每个点值的[getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) 方法报告所选类型；可通过集合设置进行更改。对于`Worksheet`，使用[getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) 访问引用的单元格。对于`DoubleLiterals`，使用[getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) 或 `setAsLiteralDouble` 直接读取或写入数值。

以下示例创建一个带有默认系列和类别的柱状图，然后为其第一系列的现有点分配 10、20 等计算值。它会保存演示文稿，重新打开，并打印存储的值。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

点值来源类型独立于[IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--)，后者标识图表的内部或外部工作簿配置。使用数值文字本身并不会删除嵌入的工作簿。在本例中，工作簿仍然可用于类别标签、系列名称以及其他系列。请参阅[图表工作簿](/slides/zh/androidjava/chart-workbook/) 了解工作簿管理。

对于散点图和气泡图，使用[setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) 和[setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) 来选择 [getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) 和[getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--) 的来源。气泡图还使用[setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) 为[getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--) 设置来源。在通过该值的`setAsLiteralDouble` 方法赋值之前，将每个适用的来源设置为`DoubleLiterals`。

## **设置图表系列重叠**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) 报告2D图表中条形或柱形的重叠程度，范围从 -100% 到 100%。它是父系列组设置的只读投影。使用[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) 可更新该组中所有兼容的系列。此选项适用于显示分组条形或柱形的图表类型；不会影响组合图中不相关的系列组。

以下示例为包含第一系列的组设置重叠：

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

![系列重叠](series_overlap.png)

## **更改系列填充颜色**

使用[IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) 为整个系列设置默认填充。如果某个点已经具有显式填充，则其[IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) 设置会覆盖该点的系列填充。

以下示例对第一系列应用实心蓝色填充：

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

![系列颜色](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚类柱形图创建的默认工作簿中，单元格 B1 位于第0行第1列，包含第一系列的名称。以下示例中的命名常量明确了该结构：

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

您还可以更新[IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) 已引用的单元格。这种方法避免了对现有图表中特定行列的假设：

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

![系列名称](series_name.png)

### **使用多个单元格创建系列名称**

当产品名称和报告期间分别存储在不同工作簿单元格中时，复合系列名称很有用。例如，您可以将 B1 中的 `Product A` 与 C1 中的 `2026` 合并为单个系列名称，同时保持两部分与其源单元格的链接。

使用[IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) 检索名称范围，然后将该集合传递给[IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-)。`skipHiddenCells` 参数控制是否包括隐藏单元格：`true` 排除，`false` 包含。本示例使用 `false` 来包含名称范围内的所有单元格。

以下示例创建一个包含一个系列和两个数据点的演示文稿。单元格 B1:C1 仅提供系列名称；A2:A3 提供类别标签，B2:B3 提供数值。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // 这两个单元格提供系列名称。
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // 单独的单元格提供类别和数值数据点。
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

生成的系列名称为 `Product A 2026`，两单元格值之间有一个空格。图例将其显示为两列的单一条目。以下图像展示了结果：

![柱形图（北部和南部数值），图例中显示复合系列名称 Product A 2026](composite_series_name.png)

## **获取自动系列填充颜色**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) 返回基于系列索引和图表样式计算的 Android ARGB 颜色整数。当系列填充未显式定义时使用此颜色。调用该方法读取计算出的颜色；并不会分配新的填充。

以下示例打印每个默认系列的自动颜色整数：

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

对于条形、柱形和气泡系列，[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 可使用不同的填充来显示负值。将常规系列填充设为实心，启用反转，并通过[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 分配负值颜色。负数在工作簿中保持不变，仅更改其显示颜色。

以下示例用一个系列替换默认的图表数据。工作表第0行包含系列名称，第0列包含类别名称，第1列包含数值：

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

![反转实心填充颜色](inverted_solid_fill_color.png)

可以通过[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 为单个点启用反转。在下面的示例中，系列的反转被禁用，仅对选定点启用。该点还被赋予负值以便可见效果：

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

要使某一点为空而不删除其他点，可将其对应的工作簿单元格设为 `null`。对于柱形图，绘制的数值可通过[IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) 获取。数据点仍保持在相同的类别位置，但图表会根据空值设置将其视为空白。

以下示例仅清除第一系列的第二个点：

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

散点图使用单独的 X 和 Y 单元格，气泡图也使用尺寸单元格。仅清除表示您想要删除的值的单元格。若想保留其他点，请勿调用[IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)，因为该方法会移除集合中的所有数据点。

## **控制空单元格的显示**

包含数值的隐藏单元格与空单元格是不同的情况。要包含或排除隐藏工作表行列中的数据，请参阅[包含隐藏行列的数据](/slides/zh/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空的工作簿单元格表示缺失数据；包含 `0` 的单元格表示已知数值。调用[IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) 并传入 `null` 可将单元格设为空。无论空单元格设置如何，数值零始终保持为零。

使用[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 选择图表如何显示空单元格。此设置适用于整个图表。它更改空白的绘制方式，而不将空工作簿单元格填充为零或插值。

以下独立示例创建一个带有一个系列的折线图，清除第 3 天的值，并以每种模式保存相同的图表。无需输入文件。[IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) 使用工作表 0，第 0 列作为类别标签，第 1 列作为数值；第 0 行存放系列名称。最终数据为 `10, 20, empty, 30, 40`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // 将第3天真正留空，同时保留其类别和数据点。
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

每个输出文件在保存前存储所分配的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 和 `empty_cells_Span.pptx`。若只需保存一个版本，可在保存演示文稿前设置所需模式，而无需遍历所有模式。

以下比较展示了三个文件中相同的数据。无论如何，第 3 天在工作簿中均为空：

![折线图（相同数据）：Gap 在第3天断开线段，Zero 将线段降至零，Span 将第2天连接到第4天](display_blanks_as.png)

可见效果取决于图表类型。折线图使三种模式都易于比较。条形图和柱形图没有跨越缺失类别的连线，因此 `Span` 无法产生上述连接段；缺失的柱形与零高度柱形也可能看起来相同。类似地，仅使用标记的散点图没有连线。不要期望每种图表类型都有三种不同的结果；请检查所使用类型的输出。

## **设置系列间距宽度**

间距宽度是相邻条形或柱形簇之间的空间，以条形或柱形宽度的百分比表示。与重叠类似，它属于父系列组而不是单个系列。对该组调用一次[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)。较大的值会在簇之间产生更大的间距，较小的值则使它们更紧密。

以下示例更改间距宽度并仅保存最终的演示文稿：

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

![间距宽度](gap_width.png)

## **常见问题**

**哪些图表类型支持数据系列？**

由[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 枚举表示的所有图表类型均使用图表数据，但它们的系列并不具有相同的数值结构或设置。例如，类别图使用类别和数值，散点图使用 X 与 Y 数值，气泡图则添加气泡大小。请使用与系列类型匹配的数据点创建方法。诸如重叠和间距宽度的选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) 包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过某个系列访问的组的更改不一定会影响图表中的所有系列。

**新创建的图表是否包含默认数据？**

是的。默认情况下，[IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) 会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。也可以使用重载创建不带默认数据的图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点数值引用[IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) 中的单元格。修改引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行和系列值行对齐，以便每个点绘制在预期的类别下。

**如何仅清除一个点而不是整系列？**

将相应的数值单元格设为 `null`，即可保留该点的类别位置为空点。仅在想要删除该系列的所有点时才使用[IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)。如果同时删除类别，请更新所有系列，使其数值仍与类别集合保持对齐。

**空点如何显示？**

结果取决于图表类型以及通过[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 配置的值。支持的图表可以将空白显示为间隙、零值，或通过连接相邻点来显示。请选择与演示文稿中缺失数据含义相匹配的设置。参阅[控制空单元格的显示](#control-the-display-of-empty-cells) 获取完整示例和可视化比较。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，调用[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 并设置[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 返回的颜色。您可以使用[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 为单个点覆盖此行为。这些方法影响格式化，而不更改存储的数值。

**当系列和点都被格式化时，哪种格式优先？**

显式的数据点格式在该点上优先。其他点继续使用显式的系列格式，或在未定义系列格式时使用自动的图表样式和主题。组设置（如重叠和间距宽度）控制布局，且不属于点级格式覆盖。

**图表可以包含的系列数量是否有限制？**

Aspose.Slides 并未设定独立的系列数量上限。实际上，演示文稿文件的限制、可用内存、渲染时间以及图表可读性决定了实际可用的上限。

**当柱形过于靠近或过于分散时应如何调整？**

对相应的父系列组调用[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)。增大该值可扩大簇之间的间距，减小则使簇更紧密。