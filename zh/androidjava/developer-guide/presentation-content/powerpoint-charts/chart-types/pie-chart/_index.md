---
title: 在 Android 上自定义演示文稿中的饼图
linktitle: 饼图
type: docs
url: /zh/androidjava/pie-chart/
keywords:
- 饼图
- 管理图表
- 自定义图表
- 图表选项
- 图表设置
- 绘图选项
- 切片颜色
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 在 Android 上创建和自定义饼图。配置次要绘图，显示数据标签，并在 PowerPoint 中应用自动切片颜色。"
---
## **概述**

本文说明了如何在 Aspose.Slides 中使用饼图。它展示了如何为 Pie of Pie 和 Bar of Pie 图表配置次要绘图选项，以及如何为标准饼图启用自动切片着色。

示例侧重于图表自定义任务，例如将图表添加到幻灯片、调整系列和标签设置、用自定义类别和值替换默认图表数据，以及保存更新后的演示文稿。

## **Pie of Pie 和 Bar of Pie 图表的次要绘图选项**

Aspose.Slides for Android via Java 支持 Pie of Pie 和 Bar of Pie 图表的次要绘图选项。这些选项控制次要绘图的大小以及数据点在两个绘图之间的分割方式。

以下示例在新演示文稿中创建一个 Pie of Pie 图表，并将数据点值显示为标签。[setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) 方法将次要绘图的大小设置为主绘图的 149%。[setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) 选择基于百分比的拆分，且 [setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) 将阈值设置为 53%。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // 显示数值并配置次要绘图。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **选择次要绘图的类别**

当您希望在次要绘图中对特定类别进行分组，而不考虑其百分比值时，可使用自定义拆分。例如，销售报告可能将 Online 和 Events 放在一起，以便读者比较这两个渠道，尽管它们分别占总销售额的 35% 和 10%。

使用 [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) 并传入 [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) 来进行自定义拆分，并通过 [getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--) 选择数据点。集合的 [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-) 方法接受系列中的零基索引；使用 [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) 添加数据点对象。在本示例中，索引 1 选择 Online，索引 3 的点选择 Events。Partners 也被临时添加，然后使用 [removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-) 将其排除。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // 用渠道销售数据替换默认数据。
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // 使用零基索引选择 Online，使用数据点对象选择 Events。
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // 在不删除其源数据的情况下，将 Partners 排除在选区之外。
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) 和 Events (10) 在次要绘图中显示为独立的切片。在主绘图中，它们以一个合并切片显示，值为 45，此外还有 Retail (40) 和 Partners (15)。从自定义选择中移除 Partners 后，它仍保留在主绘图中；此操作并未从图表源数据中删除该类别或其数值。

下图显示了在 PowerPoint 中保存的演示文稿：

![次要绘图中包含 Online 和 Events 的 Pie of Pie 图表及其在主绘图中合并后的值 45](pie_of_pie_custom.png)

## **设置自动饼图切片颜色**

Aspose.Slides for Android via Java 可以自动为饼图切片分配不同的颜色。以下示例创建了一个带居中标题的饼图，并用三个季度类别及其数值替换默认数据。[setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) 方法将数值 20、50、30 显示为标签，而 [setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) 为每个切片启用不同的颜色。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // 添加居中的图表标题。
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 使用第一个工作表替换默认数据。
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // 显示数值并为切片分配不同颜色。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**是否支持 Pie of Pie 和 Bar of Pie 变体？**

是的，库[支持](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 饼图的次要绘图，包括 Pie of Pie 和 Bar of Pie 类型。

**我可以仅将图表导出为图像吗（例如 PNG）？**

是的，您可以[将图表本身导出为图像](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--)（如 PNG），而无需导出整个演示文稿。