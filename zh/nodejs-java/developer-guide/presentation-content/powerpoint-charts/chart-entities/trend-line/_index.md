---
title: 在 JavaScript 中向演示文稿图表添加趋势线
linktitle: 趋势线
type: docs
url: /zh/nodejs-java/trend-line/
keywords:
- 图表
- 趋势线
- 指数趋势线
- 线性趋势线
- 对数趋势线
- 移动平均趋势线
- 多项式趋势线
- 幂趋势线
- 自定义趋势线
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 和 Aspose.Slides for Node.js 通过 Java，快速在 PowerPoint 图表中添加和自定义趋势线——实用指南，帮助您吸引观众。"
---
## **概述**

本文说明如何使用 Aspose.Slides 向演示文稿图表添加趋势线。它展示了如何创建图表、向图表系列添加趋势线，以及使用多种趋势线类型，包括指数、线性、对数、移动平均、多项式和幂。

它还描述了如何通过插入线形状向图表添加自定义线，并包含一个关于趋势线前向和后向投影值以及在导出为 PDF 或 SVG 或将图表渲染为图像时趋势线是否会被保留的简短 FAQ。

## **添加趋势线**

使用[TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add)向图表系列添加趋势线，并使用[TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/)选择其类型。示例创建了一个带有默认数据的聚簇柱形图，并为其三个系列中的每个系列添加了两条趋势线。

指数趋势线通过[setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation)和[setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue)隐藏其方程式和决定系数值，而线性趋势线为红色。对数趋势线使用[addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding)设置自定义标签。移动平均使用[setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod)设为三个数据点，并通过[setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName)设置自定义名称。

多项式趋势线的[setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder)为三，并通过[setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward)向前延伸一个类别。幂趋势线通过[setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward)向后延伸一个类别。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **设置趋势线截距**

使用[setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept)将趋势线在 X = 0 时的 Y 值固定。此设置支持线性、指数和多项式趋势线。

例如，生产成本模型可能需要在已知固定成本 100 的情况下开始，即使非零生产量的测量值暗示不同的基线。对于线性趋势线，将截距固定会将方程 `y = ax + b` 的 `b` 限制为 `100`；斜率在此约束下拟合数据。它并不会仅仅移动已经拟合好的线。轴交叉设置控制图表坐标轴的相交位置，而不是已拟合趋势线的系数。

以下示例创建一个散点 (XY) 图，生产量为 1 到 4，成本分别为 170、200、230 和 260。它先使用默认自动截距保存图表，然后将截距设置为 100 再保存第二个 PPTX。两个文件唯一的区别在于截距设置。趋势线显示其方程式并向后延伸到 X = 0。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在自动计算时，这些数据产生 `y = 30x + 140`。将截距设为 100 则大约得到 `y = 43.33x + 100`：零点的拟合值匹配已知基线，而线不再通过每一个数据点。

| 自动截距 | 固定截距 100 |
| --- | --- |
| ![Linear trend line with an automatically calculated intercept of 140](intercept-automatic.png) | ![Linear trend line with a fixed intercept of 100](intercept-fixed.png) |

两张图片使用相同的数据和坐标轴比例。趋势线向后延伸到 X = 0 以显示其截距。

默认情况下，[getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept)返回 `NaN`，表示截距未指定，而不是零。随后截距会根据数据自动计算。

## **添加自定义线**

自定义线是一种绘制在图表之上的形状，而不是由系列数据计算得出的趋势线。此示例使用[ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape)在图表上方的幻灯片中添加一条水平线。该线的位置以幻灯片坐标（点）指定，因而从图表左边缘开始，位于图表中部。其宽度与图表宽度相同。[getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat)为该线设置了实线红色。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**趋势线的 'forward' 和 'backward' 是什么意思？**

它们是趋势线向前/向后投影的长度：对于散点 (XY) 图，以坐标轴单位计；对于非散点图，以类别数量计。仅允许非负值。

**导出演示文稿为 PDF 或 SVG，或将幻灯片渲染为图像时，趋势线会被保留吗？**

会。Aspose.Slides 可将演示文稿转换为[PDF](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/)或[SVG](/slides/zh/nodejs-java/render-a-slide-as-an-svg-image/)并将图表渲染为图像；作为图表一部分的趋势线在这些操作中会被保留。还提供了一个方法可以[export an image of the chart](/slides/zh/nodejs-java/create-shape-thumbnails/)本身。