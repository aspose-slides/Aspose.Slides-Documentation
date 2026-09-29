---
title: 使用 Java 管理演示文稿中的图表数据标签
linktitle: 数据标签
type: docs
url: /zh/java/chart-data-label/
keywords:
- 图表
- 数据标签
- 数据精度
- 百分比
- 标签距离
- 标签位置
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 演示文稿中添加和格式化图表数据标签，以创建更具吸引力的幻灯片。"
---
## **简介**

数据标签显示图表系列和单个数据点的信息，帮助读者识别数值并了解图表。本文说明了如何格式化数值、显示百分比、读取标签文本、在超出轴最大值时控制标签、调整类目轴标签间距以及定位饼图标签。

## **在图表数据标签中设置数据精度**

使用[setNumberFormatOfValues](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-)来格式化系列数值。此示例创建一个使用默认数据的折线图，显示其数据表，并为第一个系列启用数值标签。格式 `#,##0.00` 会显示千位分隔符和两位小数，但不会更改底层数值。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **将百分比显示为标签**

对于堆叠柱形图，计算每个数值占其类别总和的百分比，并将文本分配给[getTextFrameForOverriding](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--)返回的文本框。此示例使用默认图表数据，并以 8 磅字体显示两位小数的百分比。总和为零的类别会被跳过，以避免除以零。如果图表数据更改，需要重新计算自定义标签文本。

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **使用图表数据标签设置百分号**

当数值以分数形式存储时，使用[setNumberFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-)显示百分比。将`false`传递给[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-)，使标签格式独立于源单元格。

此示例创建一个 100% 堆叠柱形图，四个类别分别包含红色和蓝色系列。每对数值之和为 1。标签格式 `0.0%` 将 0.30 显示为 30.0%，而垂直轴使用两位小数。两个系列均使用白色、10 磅的标签文字。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    Color[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **读取数据标签的实际文本**

使用[getActualLabelText](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idatalabel/#getActualLabelText--)获取由数据标签设置生成的文本。该方法在提取报告标签、搜索演示文稿内容或验证生成的图表时非常有用。以下示例中，默认的[data label format](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idatalabelformat/)将每个类别名称、系列名称和数值组合起来。一个点将其数值格式化为百分比，另一个使用[getTextFrameForOverriding](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--)提供的自定义文本。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

数据点中存储的数值仍为 `0.75`，即使其标签显示为 `75%` 并附带类别和系列名称。自定义文本会替代生成的标签文本。无论哪种情况，[getActualLabelText](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idatalabel/#getActualLabelText--)都会返回最终的标签字符串。需要单独检查[isVisible](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idatalabel/#isVisible--)，如上所示，以便仅提取可见标签。

## **在轴最大值之外控制数据标签**

当手动限制轴范围时，某些数据点可能超出其最大值。使用[setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-)来控制是否显示这些数据标签。此设置仅改变标签可见性，不会更改轴范围或底层数据值。

下面的示例创建一个二维簇状柱形图，数值为 60 和 120。它将`false`传递给[setAutomaticMaxValue](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-)，并使用[setMaxValue](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iaxis/#setMaxValue-double-)将垂直轴的最大值设为 100。第一张幻灯片允许标签超出最大值，复制的幻灯片则禁用该功能。两张幻灯片均保存为 `DataLabelsOverMaximum.pptx`。

使用[setShowValue](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-)启用数值标签。图表级别的设置本身不会启用数值显示，也不会覆盖单个标签被禁用的显示。此示例为整个系列启用数值，并使用[setPosition](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idatalabelformat/#setPosition-int-)将标签放置在每根柱子的外端。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell firstCategory = workbook.getCell(0, 1, 0, "Within range");
    IChartDataCell secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    IChartDataCell firstValue = workbook.getCell(0, 1, 1, 60);
    IChartDataCell secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    ISlide secondSlide = presentation.getSlides().addClone(slide);
    IChart secondChart = (IChart) secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

下图显示了 Microsoft PowerPoint 渲染的保存幻灯片。`true` 时，标签 **120** 在上边界可见；`false` 时，该标签被隐藏。标签 **60** 始终可见，轴最大值保持 **100**，第二个数据点在两种情况下仍为 **120**。

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint 图表在轴最大值为 100 时显示数值标签 120](data-labels-over-maximum-true.png) | ![PowerPoint 图表在轴最大值为 100 时隐藏数值标签 120](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
此示例使用带数值轴的二维柱形图。没有数值轴的图表（如饼图和环形图）没有轴最大值可供此方式限制。
{{% /alert %}}

## **设置标签与轴的距离**

使用[setLabelOffset](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iaxis/#setLabelOffset-int-)控制类目轴标签与轴之间的距离。该值是轴标签最大字体大小的百分比。此示例创建一个簇状柱形图，并将水平轴标签偏移设置为 500。此设置影响类目轴标签，而不是附加在单个数据点上的标签。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **调整标签位置**

在饼图上，调整数据标签位置以改善间距并为指示线留出空间。

此示例显示第一个数据点的数值，将其标签放置在扇形外部，并使用[setX](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilayoutable/#setX-float-)和[setY](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilayoutable/#setY-float-)调整水平和垂直偏移。这些偏移相对于图表的宽度和高度。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![饼图的调整后数据标签位置](pie-chart-adjusted-label.png)

## **常见问题**

**如何防止在密集图表上出现数据标签重叠？**

结合自动标签布局、指示线和缩小字体大小；必要时隐藏某些字段（例如类别），或仅对极值或关键点显示标签。

**如何仅为零、负数或空值禁用标签？**

在启用标签前过滤数据点，并根据定义的规则关闭对值为 0、负数或缺失的显示。

**如何确保导出为 PDF/图片时标签样式一致？**

显式设置字体族和字号，并确认渲染环境中已安装相应字体，以避免回退。