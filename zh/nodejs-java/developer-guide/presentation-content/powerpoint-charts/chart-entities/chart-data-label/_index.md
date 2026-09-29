---
title: 使用 JavaScript 在演示文稿中管理图表数据标签
linktitle: 数据标签
type: docs
url: /zh/nodejs-java/chart-data-label/
keywords:
- 图表
- 数据标签
- 数据精度
- 百分比
- 标签距离
- 标签位置
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 JavaScript 和 Aspose.Slides for Node.js（通过 Java）在 PowerPoint 演示文稿中添加和格式化图表数据标签，以制作更具吸引力的幻灯片。"
---
## **介绍**

数据标签显示图表系列和单个数据点的信息，帮助读者识别数值并理解图表。本文解释了如何格式化数值、显示百分比、读取标签文本、在轴最大值之外控制标签、调整类目轴标签间距以及定位饼图标签。

## **在图表数据标签中设置数据精度**

使用 [setNumberFormatOfValues](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) 来格式化系列值。此示例创建一个带默认数据的折线图，显示其数据表，并为第一个系列启用数值标签。格式 `#,##0.00` 显示千位分隔符和两位小数，但不更改底层数值。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    const series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **将百分比显示为标签**

对于堆叠柱形图，计算每个值在其类别总计中的百分比，并将文本分配给 [getTextFrameForOverriding](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) 返回的文本框。本例使用默认图表数据，并以 8 磅字体显示两位小数的百分比。总计为零的类别将被跳过，以避免除以零。若图表数据更改，请重新计算自定义标签文本。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);

    const categoryTotals = new Array(chart.getChartData().getCategories().size()).fill(0);
    for (let k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
            const series = chart.getChartData().getSeries().get_Item(i);
            const pointValue = series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += Number(pointValue);
        }
    }

    for (let x = 0; x < chart.getChartData().getSeries().size(); x++) {
        const series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            const pointValue = series.getDataPoints().get_Item(j).getValue().getData();
            const dataPointPercent = (Number(pointValue) / categoryTotals[j]) * 100;

            const portion = new aspose.slides.Portion();
            portion.setText(dataPointPercent.toFixed(2) + " %");
            portion.getPortionFormat().setFontHeight(8);

            label.getTextFrameForOverriding().setText("");
            const paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **使用图表数据标签设置百分号**

当数值以分数形式存储时，使用 [setNumberFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) 来显示百分比。将 `false` 传递给 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) 可使标签格式独立于源单元格。

此示例创建一个 100% 堆叠柱形图，包含四个类别的红色和蓝色系列。每对数值之和为 1。标签格式 `0.0%` 将 0.30 显示为 30.0%，而垂直轴使用两位小数。两个系列的标签文字均为白色、10 磅。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    for (let i = 0; i < 4; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    const seriesNames = ["Reds", "Blues"];
    const white = java.getStaticFieldValue("java.awt.Color", "WHITE");
    const seriesColors = [java.getStaticFieldValue("java.awt.Color", "RED"), java.getStaticFieldValue("java.awt.Color", "BLUE")];
    const values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]];

    for (let i = 0; i < seriesNames.length; i++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (let j = 0; j < 4; j++) {
            const valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        const labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(white);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **读取数据标签的实际文本**

使用 [getActualLabelText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) 获取数据标签设置产生的文本。这在提取标签用于报告、搜索演示文稿内容或验证生成的图表时非常有用。在下面的示例中，默认的 [data label format](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datalabelformat/) 将每个类别名称、系列名称和数值组合在一起。一个点将其数值格式化为百分比，另一个使用来自 [getTextFrameForOverriding](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) 的自定义文本。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    const secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    const northSeriesCell = workbook.getCell(0, 0, 1, "North");
    const north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    const northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    const northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    const southSeriesCell = workbook.getCell(0, 0, 2, "South");
    const south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    const southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    const southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        const format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const point = series.getDataPoints().get_Item(j);
            const label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            console.log("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

数据点中存储的数字仍为 `0.75`，即使其标签显示为 `75%` 并附带类别和系列名称。自定义文本会替换生成的标签文本。无论哪种情况，[getActualLabelText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) 都返回最终的标签字符串。如上所示，在仅想提取可见标签时，请单独检查 [isVisible](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datalabel/isvisible/)。

## **在轴最大值之外控制数据标签**

当手动限制轴范围时，某些数据点可能超过其最大值。使用 [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) 来控制是否显示这些数据点的标签。此设置仅改变标签可见性；它不更改轴范围或底层数据值。

下面的示例创建一个 2D 簇状柱形图，数值为 60 和 120。它将 `false` 传递给 [setAutomaticMaxValue](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) 并使用 [setMaxValue](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/axis/setmaxvalue/) 将垂直轴的最大值设为 100。第一张幻灯片允许标签超出最大值；该幻灯片的副本则禁用该功能。两张幻灯片均保存为 `DataLabelsOverMaximum.pptx`。

使用 [setShowValue](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) 启用数值标签。图表级别的设置本身不会启用数值显示，也不会覆盖单个标签被禁用的数值显示。此示例为整个系列启用数值，并使用 [setPosition](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datalabelformat/setposition/) 将标签放置在每根柱形的外部端点。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();

    const firstCategory = workbook.getCell(0, 1, 0, "Within range");
    const secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    const seriesName = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    const firstValue = workbook.getCell(0, 1, 1, 60);
    const secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    const secondSlide = presentation.getSlides().addClone(slide);
    const secondChart = secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

下图展示了 Microsoft PowerPoint 渲染的保存幻灯片。`true` 时，标签 **120** 在上边界可见；`false` 时，该标签被隐藏。标签 **60** 保持可见，轴最大值仍为 **100**，第二个数据点在两种情况下均为 **120**。

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint 图表显示数值标签 120，轴最大值为 100](data-labels-over-maximum-true.png) | ![PowerPoint 图表隐藏数值标签 120，轴最大值为 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}

此示例使用带数值轴的 2D 柱形图。没有数值轴的图表（如饼图和环形图）没有可限制的轴最大值。

{{% /alert %}}

## **设置标签距离轴的距离**

使用 [setLabelOffset](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/axis/setlabeloffset/) 控制类目轴标签与轴之间的距离。该值是轴标签最大字体大小的百分比。本例创建一个簇状柱形图，并将水平轴标签偏移设为 500。此设置影响类目轴标签，而不是附加到单个数据点的标签。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **调整标签位置**

在饼图上，调整数据标签位置以改善间距并为引导线留出空间。

本示例显示第一个数据点的数值，将其标签放置在切片外部，并使用 [setX](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datalabel/setx/) 和 [setY](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datalabel/sety/) 调整水平和垂直偏移。这些偏移相对于图表的宽度和高度。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    const series = chart.getChartData().getSeries();

    const label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(java.newFloat(0.71));
    label.setY(java.newFloat(0.04));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![已调整数据标签位置的饼图](pie-chart-adjusted-label.png)

## **常见问题**

**如何防止在密集图表中出现数据标签重叠？**

结合自动标签布局、引导线和减小字体大小；必要时隐藏某些字段（例如类别），或仅对极值或关键点显示标签。

**如何仅对零、负或空值禁用标签？**

在启用标签之前过滤数据点，并根据定义的规则关闭对值为 0、负值或缺失值的显示。

**如何在导出为 PDF/图片时确保标签样式一致？**

显式设置字体族和大小，并确认渲染环境中提供该字体，以避免回退。