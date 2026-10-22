---
title: 在 Java 演示文稿中管理图表数据系列
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

图表可以将其绘制的值存储在工作簿单元格中或直接作为数值字面量。 [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) 表示一组相关值，每个 [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) 表示该系列中的一个点。 [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) 对象提供系列共享的标签或分组值。在使用默认数据创建的图表中，系列名称、类别和值使用来自图表工作簿的 [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) 对象。

对于典型的类别图表，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，其余单元格存放系列值。传递给 [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) 的工作表、行和列索引为零基。此布局在创建带默认数据的图表时很有用，但不要假设每个现有图表都使用它。对于已加载的演示文稿，在更改工作簿值之前，检查系列、类别和数据点引用的单元格。

图表设置有三种不同的范围：

- 系列级别的设置，例如 [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--)，为单个系列中的所有点提供默认外观。
- 数据点设置，例如 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--)，覆盖单个点的系列外观。
- 组设置适用于属于同一 [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) 的兼容系列。当需要设置诸如重叠或间隙宽度等选项时，可通过 [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) 访问该组。

当未设置显式的点或系列填充时，图表样式和主题决定自动外观。当系列和点的格式都存在时，点的格式优先于该点。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **使用数值字面量设置系列值**

当系列值来自应用程序数据或计算且不需要工作表单元格引用时，使用数值字面量。 在为每个点的 [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) 结果调用 [setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-) 之前，使用 [setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) 并传入 [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals)。

集合设置控制该系列中所有点值的源类型。每个点值的 [getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--) 方法报告所选类型；可通过集合设置进行更改。使用 `Worksheet` 时，使用 [getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) 访问引用的单元格。使用 `DoubleLiterals` 时，使用 [getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) 或 `setAsLiteralDouble` 直接读取或写入数字。

以下示例创建一个带默认系列和类别的柱形图，然后将 10、20 等计算值分配给其第一个系列的现有点。它保存演示文稿，重新打开，并打印存储的值。

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

点值的源类型与 [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--) 分离，后者标识图表的内部或外部工作簿配置。使用数值字面量本身并不会移除嵌入的工作簿。在此示例中，工作簿仍用于类别标签、系列名称和其他系列。有关工作簿管理，请参阅 [图表工作簿](/slides/zh/java/chart-workbook/)。

对于散点图和气泡图，使用 [setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) 和 [setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) 来选择 [getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) 和 [getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--) 的来源。气泡图还使用 [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) 来设置 [getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--)。在通过该值的 `setAsLiteralDouble` 方法分配数字之前，将每个适用的源设置为 `DoubleLiterals`。

## **设置图表系列重叠**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) 报告 2D 图表中条形或柱形的重叠程度，范围为 -100% 到 100%。它是父系列组设置的只读投影。使用 [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) 可更新该组中所有兼容的系列。此选项适用于显示分组条形或柱形的图表类型；它不会影响组合图中不相关的系列组。

以下示例为包含第一个系列的组设置重叠：

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

使用 [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) 为整个系列设置默认填充。如果某个点已经具有显式填充，其 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) 设置会覆盖该点的系列填充。

以下示例为第一个系列应用纯蓝色填充：

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

![系列颜色](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为簇状柱形图创建的默认工作簿中，单元格 B1 位于第 0 行第 1 列，包含第一个系列的名称。下面示例中的命名常量明确了该结构：

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

您也可以更新 [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) 已引用的单元格。此方法避免在现有图表中假设特定的行和列：

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

### **使用多个单元格创建带名称的系列**

当产品名称和报告期间存储在不同工作簿单元格中时，复合系列名称很有用。例如，您可以将 B1 中的 `Product A` 与 C1 中的 `2026` 组合成单个系列名称，同时保持两部分链接到其来源单元格。

使用 [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) 检索名称范围，然后将该集合传递给 [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-)。`skipHiddenCells` 参数控制是否包括隐藏单元格：`true` 排除，`false` 包含。本示例使用 `false` 以包含名称范围内的所有单元格。

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

    // 分离的单元格提供类别和数值数据点。
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

生成的系列名称为 `Product A 2026`，两个单元格值之间有一个空格。图例将其显示为两列的单个条目。下面的图像展示了结果：

![带有复合系列名称 Product A 2026 的柱形图（北部和南部值）](composite_series_name.png)

## **获取自动系列填充颜色**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) 返回根据系列索引和图表样式计算的颜色。这是在系列填充未显式定义时使用的颜色。调用该方法读取计算出的颜色；不会分配新的填充。

以下示例打印每个默认系列的自动颜色：

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

确切的颜色取决于图表样式和主题。

## **为图表系列设置负值填充颜色反转**

对于条形、柱形和气泡系列，[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 可以使用不同的填充显示负值。将常规系列填充设为实心，启用反转，并通过 [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 分配负值颜色。负数在工作簿中保持不变，仅改变其显示颜色。

以下示例用一个系列替换默认图表数据。工作表第 0 行包含系列名称，第 0 列包含类别名称，第 1 列包含数值：

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

![反转实心填充颜色](inverted_solid_fill_color.png)

可以通过 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 为单个点启用反转。在下面的示例中，系列的反转被禁用，仅为选定的点启用反转。该点还被赋予负值，以便显示效果：

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

要使某一点为空而不删除其他点，可将其对应的工作簿单元格设为 `null`。对于柱形图，绘制的值可通过 [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) 获取。数据点仍保留在相同的类别位置，但图表会根据空值设置将其视为空白。

以下示例仅清除第一个系列中的第二个点：

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

散点图使用单独的 X 与 Y 单元格，气泡图还使用大小单元格。仅清除表示您要删除的值的单元格。若希望保留其他点，请不要调用 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--)，因为该方法会删除集合中的所有数据点。

## **控制空单元格的显示**

包含值的隐藏单元格与空单元格是不同的情况。要包含或排除隐藏工作表行列中的数据，请参阅 [包含隐藏行列中的数据](/slides/zh/java/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空工作簿单元格表示缺失数据；包含 `0` 的单元格表示已知的数值。使用 `null` 调用 [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) 可使单元格为空。无论空单元格设置如何，数值零仍保持为零。

使用 [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 选择图表如何显示空单元格。此设置适用于整个图表。它改变空白的绘制方式，但不会将空工作簿单元格填充为零或插值。

以下独立示例创建一个带有一个系列的折线图，清除第 3 天的值，并使用每种模式保存相同的图表。无需输入文件。 [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) 使用工作表 0，列 0 作为类别标签，列 1 作为数值；第 0 行存放系列名称。最终数据为 `10, 20, empty, 30, 40`。

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

    // 让第 3 天真正保持为空，同时保留其类别和数据点。
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

每个输出文件在保存前存储所分配的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 和 `empty_cells_Span.pptx`。若只想保存一个版本，可在保存演示文稿前设置所需模式，而不是遍历所有模式。

以下比较展示了三个文件中的相同数据。无论何种情况，工作簿中的第 3 天都是空的：

![折线图（相同数据）：Gap 在第 3 天断开线段，Zero 将线段降至零，Span 将第 2 天连接到第 4 天](display_blanks_as.png)

可见效果取决于图表类型。折线图使三种模式的比较变得容易。条形图和柱形图没有跨缺失类别的连线，因此 `Span` 无法产生上述的连接段；缺失的柱形与零高度的柱形也可能看起来相同。类似地，仅带标记的散点图也没有连接线。不要期望每种图表类型都有三种不同的结果；请检查您使用的图表类型的输出。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，表示为条形或柱形宽度的百分比。与重叠类似，它属于父系列组而非单个系列。对该组调用一次 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)。较大的值会在簇之间产生更多空间，较小的值则使其更密集。

以下示例更改间隙宽度，并仅保存最终的演示文稿：

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

## **常见问题**

**哪些图表类型支持数据系列？**

由 [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 枚举表示的所有图表类型都使用图表数据，但它们的系列并非都有相同的值结构或设置。例如，类别图使用类别和数值，散点图使用 X 与 Y 值，气泡图则增加气泡大小。请使用与系列类型匹配的数据点创建方法。重叠和间隙宽度等选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) 包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过某个系列访问的组的更改不一定会影响图表中的所有系列。

**新创建的图表是否包含默认数据？**

是的。默认情况下，[IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) 会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。也可以使用重载创建不带默认数据的图表。

**图表对象如何连接到工作簿单元格？**

系列名称、类别标签和数据点值引用 [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) 中的单元格。更改引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行和系列值行对齐，以便每个点在预期的类别下绘制。

**如何仅清除一个点而不是整个系列？**

将相关的值单元格设为 `null`，即可保留该点的类别位置为空点。仅在希望删除该系列所有点时才使用 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--)。如果同时删除类别，请更新所有系列，使它们的值仍然与类别集合保持对齐。

**空点如何显示？**

结果取决于图表类型以及通过 [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 配置的值。受支持的图表可以将空白显示为间隙、零值或连接相邻点。请选择与演示文稿中缺失数据含义相匹配的设置。请参阅 [控制空单元格的显示](#control-the-display-of-empty-cells) 获取完整示例和可视化比较。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，调用 [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 并设置 [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 返回的颜色。您可以使用 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 为单个点覆盖此行为。这些方法影响格式，而不影响存储的数值。

**当系列和点都进行格式化时，哪种格式优先？**

显式的数据点格式化在该点上优先。其他点继续使用显式的系列格式，或者在未定义系列格式时使用自动的图表样式和主题。组设置（如重叠和间隙宽度）控制布局，且不属于点级别的格式覆盖。

**图表可以包含的系列数量是否有限制？**

Aspose.Slides 并未设定单独的固定系列数量上限。实际中，演示文稿文件的限制、可用内存、渲染时间以及图表可读性决定了一个实际可用的上限。

**当柱形太靠近或太远时应如何调整？**

对相应的父系列组调用 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)。增大数值会扩大簇之间的间距，减小数值则会使簇更紧密。