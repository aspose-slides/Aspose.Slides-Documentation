---
title: 使用 JavaScript 管理演示文稿中的图表数据系列
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
description: "了解如何在演示文稿中使用 JavaScript 管理图表系列、数据点、工作簿单元格、格式设置、重叠、间隙宽度和负值。"
---
## **概述**

图表可以将其绘制的值存储在工作簿单元格中，或直接作为数值字面量。一个[ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/)表示一组相关值，每个[ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/)表示该系列中的一个点。[ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/)对象提供系列共享的标签或分组值。在使用默认数据创建的图表中，系列名称、类别和点值使用来自图表工作簿的[ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/)对象。

对于典型的分类图，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，其余单元格存放系列数值。传递给[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/)的工作表、行和列索引均为零基。此布局在创建带有默认数据的图表时很有用，但不要假设每个现有图表都使用该布局。对于已加载的演示文稿，请在更改工作簿数值之前检查系列、类别和数据点所引用的单元格。

图表设置具有三种不同的作用范围：

- 系列级设置，例如[ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/)，为单个系列中的所有点提供默认外观。
- 数据点级设置，例如[ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/)，覆盖该点的系列外观。
- 组设置适用于属于同一[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/)的兼容系列。当需要设置重叠或间隙宽度等选项时，可通过[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/)访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当系列和点的格式均已设置时，点的格式优先于该点的系列格式。

![图表系列-PowerPoint](chart-series-powerpoint.png)

## **使用数值字面量设置系列值**

当系列值来自应用程序数据或计算且不需要工作表单元格引用时，请使用数值字面量。调用[setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/)并将参数设为[DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/)后，通过[setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/)为每个点的[getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/)结果赋值。

集合设置控制该系列所有点值的来源类型。每个点值的[getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/)方法报告所选类型；通过集合设置进行更改。使用`Worksheet`时，使用[getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/)访问引用的单元格。使用`DoubleLiterals`时，使用[getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/)或`setAsLiteralDouble`直接读取或写入数字。

以下示例创建一个默认系列和类别的柱状图，然后为其第一系列的现有点分配 10、20 等计算值。它会保存演示文稿、重新打开并打印存储的值。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

点值来源类型独立于[ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/)，后者标识图表的内部或外部工作簿配置。使用数值字面量本身并不会移除嵌入的工作簿。在本示例中，工作簿仍用于类别标签、系列名称以及其他系列。有关工作簿管理，请参阅[Chart Workbook](/slides/zh/nodejs-java/chart-workbook/)。

对于散点图和气泡图，使用[setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/)和[setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/)分别选择[ getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/)和[getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/)的来源。气泡图还使用[setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/)为[getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/)选择来源。将在该值的`setAsLiteralDouble`方法之前将每个适用的来源设为`DoubleLiterals`，然后再赋数值。

## **设置图表系列重叠**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/)报告 2D 图表中条形或柱形的重叠程度，范围为 -100 到 100%。它是对父系列组中设置的只读投影。使用[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/)可更新该组中所有兼容系列的重叠。此选项适用于显示分组条形或柱形的图表类型；在组合图中不影响无关的系列组。

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

使用[ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/)为整个系列设置默认填充。如果某个点已显式设置填充，其[ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/)将覆盖该点的系列填充。

以下示例为第一系列应用纯蓝色填充：

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

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚簇柱形图创建的默认工作簿中，单元格 B1 位于第 0 行第 1 列，包含第一系列的名称。下面示例中的命名常量显式说明了该结构：

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

您也可以直接更新由[ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/)引用的单元格。此方法避免了对现有图表中特定行列的假设：

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

### **从多个单元格创建带有名称的系列**

当产品名称和报告期间分别存放在不同工作簿单元格中时，复合系列名称非常有用。例如，可以将 B1 中的 `Product A` 与 C1 中的 `2026` 合并为单个系列名称，同时保持两部分与其源单元格的链接。

使用[ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/)获取名称范围，然后将该集合传递给[ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/)。`skipHiddenCells` 参数决定是否包含隐藏单元格：`true` 排除，`false` 包含。本示例使用 `false` 包含名称范围内的每个单元格。

以下示例创建一个包含一个系列和两个数据点的演示文稿。单元格 B1:C1 仅提供系列名称；A2:A3 提供类别标签，B2:B3 提供数值。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // 这两个单元格提供系列名称。
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // 分别的单元格提供类别和数值数据点。
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

生成的系列名称为 `Product A 2026`，两单元格值之间有一个空格。图例将其作为单一条目显示。下图展示了结果：

![带有复合系列名称 Product A 2026 的柱状图](composite_series_name.png)

## **获取自动系列填充颜色**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/)返回根据系列索引和图表样式计算的颜色。这是系列填充未显式定义时使用的颜色。调用该方法仅读取计算出的颜色，不会分配新的填充。

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

对于条形、柱形和气泡系列，调用[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/)可在负值时使用不同填充。将常规系列填充设为实色，启用反转，并通过[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/)指定负值颜色。负数在工作簿中保持不变，仅改变其显示颜色。

以下示例用一个系列替换默认图表数据。工作表第 0 行存放系列名称，第 0 列存放类别名称，第 1 列存放数值：

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

![反转实色填充颜色](inverted_solid_fill_color.png)

您也可以通过[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/)为单个点启用反转。下面示例在系列上禁用反转，仅为选定点启用，并为该点分配负值以便观察效果：

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

要使单个点为空而不删除其他点，请将其对应的工作簿单元格设为 `null`。对于柱状图，绘制值可通过[ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/)获取。数据点仍位于相同的类别位置，但图表根据空值设置将其视为空白。

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

散点图使用单独的 X 和 Y 单元格，气泡图还使用大小单元格。仅清除您希望移除的值对应的单元格。不要在想保留其他点时调用[ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/)，因为该方法会删除该系列的所有数据点。

## **控制空单元格的显示**

隐藏的包含数值的单元格是一种与空单元格不同的情况。要包含或排除隐藏行列中的数据，请参阅[Include Data from Hidden Rows and Columns](/slides/zh/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空工作簿单元格表示缺失数据；包含 `0` 的单元格表示已知的数值。调用[ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/)并传入 `null` 可使单元格为空。数值零始终保持为零，与空单元格设置无关。

使用[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/)选择图表如何显示空单元格。此设置适用于整个图表，改变空白的绘制方式，但不将空工作簿单元格填充为零或插值。

以下独立示例创建一个包含一个系列的折线图，清除第 3 天的值，并分别以每种模式保存同一图表。无需输入文件。[ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/)使用工作表 0，列 0 为类别标签，列 1 为数值；第 0 行存放系列名称。最终数据为 `10, 20, empty, 30, 40`。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // 将第3天真正设为空，同时保留其类别和数据点。
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

每个输出文件在保存前都会记录对应的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`和`empty_cells_Span.pptx`。如果只想生成一种版本，请在保存演示文稿前设定所需模式，而不是遍历所有模式。

下图比较了三个文件中的相同数据。第 3 天在工作簿中始终为空：

![折线图显示空白的比较：Gap 在第 3 天断开线段，Zero 将线段降至零，Span 将第 2 天连接到第 4 天。](display_blanks_as.png)

可见效果取决于图表类型。折线图可以直观比较所有三种模式。条形和柱形图没有连线可跨越缺失的类别，因此 `Span` 无法产生上图所示的连接段；缺失的柱形和零高度柱形也可能看起来相似。同样，仅使用标记的散点图也没有连线。请勿期望每种图表类型都出现三种明显不同的结果；请针对使用的图表类型检查输出。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，以条形或柱形宽度的百分比表示。与重叠类似，它属于父系列组而非单个系列。对该组调用一次[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/)即可。较大值在簇之间创建更多空间，较小值则使簇更密集。

以下示例修改间隙宽度并仅保存最终的演示文稿：

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

所有由[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)枚举表示的图表类型都使用图表数据，但它们的系列并非全部具有相同的值结构或设置。例如，分类图使用类别和数值，散点图使用 X 和 Y 值，气泡图另加气泡大小。请使用与系列类型匹配的数据点创建方法。重叠和间隙宽度等选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/)包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过某一系列访问的组的更改不一定会影响图表中的所有系列。

**新创建的图表会包含默认数据吗？**

会。默认情况下，[ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/)会创建示例系列、类别和值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。也可以使用重载创建不含默认数据的图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点值引用[ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/)中的单元格。更改被引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行与系列值行对齐，以便每个点绘制在预期的类别下。

**如何只清除一个点而不是整个系列？**

将相关的值单元格设为 `null`，即可保留该点的类别位置作为空点。仅在希望删除该系列的所有点时才使用[ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/)。如果同时删除了类别，请相应更新每个系列，使其值仍与类别集合保持对齐。

**空点如何显示？**

结果取决于图表类型以及通过[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/)配置的值。受支持的图表可以将空白显示为间隙、零值或连接相邻点。请选择与演示文稿中缺失数据意义相匹配的设置。有关完整示例和可视化比较，请参阅[控制空单元格的显示](#control-the-display-of-empty-cells)。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，调用[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/)并通过[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/)设置返回的颜色。您也可以使用[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/)为单个点覆盖此行为。这些方法影响格式，而不改变存储的数值。

**当系列和点都进行了格式设置时，哪种格式生效？**

显式的数据点格式在该点上具有最高优先级。其他点继续使用显式的系列格式，若系列格式未定义，则使用自动的图表样式和主题。组设置（如重叠和间隙宽度）控制布局，不属于点级别的格式覆盖。

**图表可以包含的系列数量是否有限制？**

Aspose.Slides 本身没有单独的固定系列计数限制。实际限制受演示文稿文件约束、可用内存、渲染时间以及图表可读性等因素影响。

**当列之间过于靠近或过于分散时应该怎么做？**

对相应的父系列组调用[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/)。增大该值可扩大簇之间的空间，减小则可使簇更紧凑。