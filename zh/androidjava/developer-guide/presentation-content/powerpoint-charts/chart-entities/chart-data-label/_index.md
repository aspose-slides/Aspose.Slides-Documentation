---
title: 在 Android 演示文稿中管理图表数据标签
linktitle: 数据标签
type: docs
url: /zh/androidjava/chart-data-label/
keywords:
- 图表
- 数据标签
- 数据精度
- 百分比
- 标签距离
- 标签位置
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for Android via Java 在 PowerPoint 演示文稿中添加和格式化图表数据标签，以创建更具吸引力的幻灯片。"
---
## **简介**

数据标签显示有关图表系列和各个数据点的信息，帮助读者识别数值并了解图表。本文说明如何格式化数值、显示百分比、读取标签文本、调整分类坐标轴标签间距以及定位饼图标签。

## **设置图表数据标签的数据精度**

使用[setNumberFormatOfValues](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-)来格式化系列数值。此示例创建一个具有默认数据的折线图，显示其数据表，并为第一系列启用数值标签。格式`#,##0.00`显示千位分隔符和两位小数，但不更改底层数值。

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

## **显示百分比作为标签**

对于堆积柱状图，将每个数值计算为其类别总计的百分比，并将文本分配给[getTextFrameForOverriding](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--)返回的文本框。此示例使用默认图表数据，并以 8 磅字体显示保留两位小数的百分比。总计为零的类别将被跳过，以避免除以零。如果图表数据发生变化，需要重新计算自定义标签文本。

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

当数值以分数形式存储时，使用[setNumberFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-)显示百分比。将`false`传递给[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-)以使标签格式独立于源单元格。

此示例创建一个 100% 堆积柱状图，四个类别中分别有红色和蓝色系列。每对数值的总和为 1。标签格式`0.0%`将 0.30 显示为 30.0%，而纵坐标轴使用两位小数。两个系列均使用白色、10 磅的标签文本。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int[] seriesColors = { Color.RED, Color.BLUE };
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

使用[getActualLabelText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--)检索数据标签设置产生的文本。当提取标签用于报告、搜索演示文稿内容或验证生成的图表时，这非常有用。在下面的示例中，默认的[data label format](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/idatalabelformat/)将每个类别名称、系列名称和数值组合在一起。某一点将其数值格式化为百分比，另一点则使用来自[getTextFrameForOverriding](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--)的自定义文本。

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

数据点中存储的数值仍为`0.75`，即使其标签显示`75%`以及类别和系列名称。自定义文本会替换生成的标签文本。[getActualLabelText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--)在两种情况下都会返回相应的标签字符串。当您只想提取可见标签时，需要单独检查[isVisible](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/idatalabel/#isVisible--)（如上所示）。

## **设置标签与坐标轴的距离**

使用[setLabelOffset](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-)控制分类坐标轴标签与坐标轴之间的距离。该值是轴标签最大字体尺寸的百分比。此示例创建一个簇状柱形图，并将水平坐标轴标签偏移设置为 500。此设置影响分类坐标轴标签，而不是附加到单个数据点的标签。

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

在饼图上，调整数据标签位置以改善间距并为引线留出空间。

此示例显示第一个数据点的数值，将其标签放置在切片外部，并使用[setX](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutable/#setX-float-)和[setY](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutable/#setY-float-)调整其水平和垂直偏移。这些偏移量分别相对于图表的宽度和高度。

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

![调整数据标签位置的饼图](pie-chart-adjusted-label.png)

## **常见问题**

**如何防止在密集图表上数据标签重叠？**  
结合自动标签布局、引线和减小字体大小；如有必要，可隐藏某些字段（例如类别），或仅为极值或关键点显示标签。

**如何仅对零、负数或空值禁用标签？**  
在启用标签之前先筛选数据点，并根据定义的规则关闭对值为 0、负数或缺失值的显示。

**在导出为 PDF/图像时，如何确保标签样式一致？**  
明确设置字体族和字号，并确认渲染环境中存在该字体，以避免回退。