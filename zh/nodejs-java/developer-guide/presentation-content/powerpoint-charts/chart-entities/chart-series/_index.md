---
title: 使用 JavaScript 在演示文稿中管理图表数据系列
linktitle: 数据系列
type: docs
url: /zh/nodejs-java/chart-series/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 JavaScript 在演示文稿中管理图表系列、数据点、工作簿单元格、格式设置、重叠、间隙宽度和负值。"
---
## **概述**

图表将其绘制的数据存储在图表数据工作簿中。一个[ChartSeries](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseries/)表示一组相关值，系列中的每个[ChartDataPoint](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdatapoint/)引用一个或多个工作簿单元格。[ChartCategory](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartcategory/)对象提供系列共享的标签或分组值。因此，系列名称、类别和点值连接到[ChartDataCell](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdatacell/)对象，而不仅仅存储为显示文本。

对于典型的类别图，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，其余单元格存放系列数值。传递给[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdataworkbook/#getCell)的工作表、行和列索引采用零基计数。这种布局在创建带有默认数据的图表时很有用，但不要假设每个已有图表都采用该布局。对于已加载的演示文稿，在更改工作簿数值之前，请检查系列、类别和数据点引用的单元格。

图表设置有三种不同的作用域：

- 系列级设置，例如[ChartSeries.getFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseries/#getFormat)，为同一系列的所有点提供默认外观。
- 数据点级设置，例如[ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdatapoint/#getFormat)，覆盖该点的系列外观。
- 组设置适用于属于同一[ChartSeriesGroup](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseriesgroup/)的兼容系列。当需要设置重叠或间隙宽度等选项时，可通过[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup)访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当系列和点的格式都存在时，点的格式优先于该点的系列格式。

![图表系列-PowerPoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseries/#getOverlap)报告 2D 图表中条形或柱形的重叠程度，范围从 -100% 到 100%。它是父系列组设置的只读投影。使用[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap)可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图中不相关的系列组没有影响。

以下示例为包含第一系列的组设置重叠：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 新图表包含示例系列、类别和数值。
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![系列重叠](series_overlap.png)

## **更改系列填充颜色**

使用[ChartSeries.getFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseries/#getFormat)为整个系列设置默认填充。如果某个点已经有显式填充，其[ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdatapoint/#getFormat)设置会覆盖该点的系列填充。

以下示例为第一系列应用纯蓝色实心填充：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![系列颜色](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚类柱形图创建的默认工作簿中，单元格 B1 位于第 0 行第 1 列，包含第一系列的名称。以下示例中的命名常量明确了该结构：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

您也可以更新[ChartSeries.getName](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseries/#getName)已引用的单元格。此方式避免在已有图表中假设特定的行列：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![系列名称](series_name.png)

## **获取自动系列填充颜色**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor)返回根据系列索引和图表样式计算的颜色。该颜色在未显式定义系列填充时使用。调用该方法仅读取计算得到的颜色，不会分配新填充。

以下示例打印每个默认系列的自动颜色：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
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

具体颜色取决于图表样式和主题。

## **为图表系列设置反转填充颜色**

对于条形、柱形和气泡系列，使用[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative)可以在负值时显示不同的填充。将常规系列填充设为实心，启用反转，并通过[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor)指定负值颜色。负数在工作簿中保持不变，仅其显示颜色会改变。

以下示例用一个系列替换默认图表数据。工作表第 0 行包含系列名称，第 0 列包含类别名称，第 1 列包含数值：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![反转实心填充颜色](inverted_solid_fill_color.png)

您可以通过[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative)为单个点启用反转。下例中系列禁用反转，仅为选中点启用，并为该点分配负值以便观察效果：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **清除特定数据点的值**

要使某一点为空且不删除其他点，可将其对应的工作簿单元格设为`null`。对于柱形图，绘制的数值可通过[ChartDataPoint.getValue](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdatapoint/#getValue)获取。数据点仍保留在相同的类别位置，但图表根据空值设置将其视为空白。

以下示例仅清除第一系列的第二个点：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

散点图使用独立的 X 与 Y 单元格，气泡图还使用大小单元格。仅清除表示要移除的数值的单元格。若想保留其他点，请不要调用[ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdatapointcollection/#clear)，因为该方法会删除集合中的所有数据点。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的间距，以条形或柱形宽度的百分比表示。与重叠类似，它属于父系列组而非单个系列。对组调用一次[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth)即可。数值越大，簇之间的空间越宽；数值越小，簇越密集。

以下示例修改间隙宽度并仅保存最终演示文稿：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![间隙宽度](gap_width.png)

## **FAQ**

**哪些图表类型支持数据系列？**

所有由[ChartType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/charttype/)枚举表示的图表类型都使用图表数据，但它们的系列并非全部具有相同的值结构或设置。例如，类别图使用类别和数值，散点图使用 X 与 Y 值，气泡图则额外使用气泡大小。请使用与系列类型匹配的数据点创建方法。重叠和间隙宽度等选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[ChartSeriesGroup](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseriesgroup/)包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过某一系列访问的组的更改不一定会影响图表中的所有系列。

**新创建的图表是否包含默认数据？**

是的。默认情况下，[ShapeCollection.addChart](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapecollection/#addChart)会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。也可以使用重载方法创建不含默认数据的图表。

**图表对象是如何关联到工作簿单元格的？**

系列名称、类别标签和数据点值引用[ChartDataWorkbook](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdataworkbook/)中的单元格。更改被引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行与系列值行对齐，以确保每个点绘制在预期的类别下。

**如何只清除一个点而不是整个系列？**

将相关的数值单元格设为`null`，即可保留该点的类别位置但使其为空点。仅在需要删除该系列的所有点时才使用[ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdatapointcollection/#clear)。

**空点如何显示？**

显示方式取决于图表类型以及通过[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs)配置的值。受支持的图表可以将空白显示为间隙、零值或连接相邻点。请选择与演示文稿中缺失数据意义相符的设置。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，调用[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative)并设置[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor)返回的颜色。您可以使用[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative)为单个点单独覆盖此行为。这些方法影响的是格式，而非存储的数值。

**当系列和点同时被格式化时，哪种格式生效？**

显式的数据点格式在该点上优先于系列格式。其他点继续使用显式的系列格式；如果系列格式未定义，则使用自动的图表样式和主题。组设置（如重叠和间隙宽度）控制布局，并不是点级的格式覆盖。

**图表能够包含的系列数量是否有限制？**

Aspose.Slides 并未设定单独的固定系列计数上限。实际受演示文稿文件限制、可用内存、渲染时间以及图表可读性等因素影响。

**当柱形之间太靠近或太远时应如何调整？**

对相应的父系列组调用[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth)。增大值可扩大簇之间的间距，减小值则使簇更靠近。