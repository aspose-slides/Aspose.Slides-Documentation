---
title: 在 JavaScript 中為簡報圖表加入趨勢線
linktitle: 趨勢線
type: docs
url: /zh-hant/nodejs-java/trend-line/
keywords:
- 圖表
- 趨勢線
- 指數趨勢線
- 線性趨勢線
- 對數趨勢線
- 移動平均趨勢線
- 多項式趨勢線
- 冪次趨勢線
- 自訂趨勢線
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 以及 Aspose.Slides for Node.js（透過 Java）快速在 PowerPoint 圖表中加入並自訂趨勢線 — 為您的觀眾打造實用指南。"
---
## **概述**

本文說明如何使用 Aspose.Slides 為簡報圖表加入趨勢線。它展示如何建立圖表、為圖表系列加入趨勢線，並使用多種趨勢線類型，包括指數、線性、對數、移動平均、多項式與冪次。

它同時說明如何透過插入線條圖形為圖表加入自訂線，並包含關於趨勢線「前向」與「後向」投射值的簡短 FAQ，以及在匯出為 PDF 或 SVG、以及將簡報投影為影像時，趨勢線是否會被保留的說明。

## **加入趨勢線**

使用[TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add)將趨勢線加入圖表系列，並使用[TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/)選擇其類型。本範例建立一個具有預設資料的群組直條圖，並為其三個系列各加入兩條趨勢線。

指數趨勢線透過[setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation)與[setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue)隱藏其方程式與 R 平方值，而線性趨勢線則為紅色。對數趨勢線使用[addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding)設定自訂標籤。移動平均使用[setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod)設定為三個資料點，並使用自訂的[setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName)。

多項式趨勢線的[setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder)為三，並透過[setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward)向前延伸一個類別。冪次趨勢線則透過[setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward)向後延伸一個類別。

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

## **設定趨勢線截距**

使用[setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept)將趨勢線的 Y 值固定在 X = 0。此設定支援線性、指數與多項式趨勢線。

例如，生產成本模型可能需要在已知固定成本 100 的情況下開始，即使非零產量的測量值暗示不同的基準線。對於線性趨勢線，固定截距會將方程式 `y = ax + b` 約束為 `b = 100`；斜率在此約束下擬合資料。這並非僅僅移動已擬合的線。座標軸交叉設定控制圖表座標軸的相交位置，而非擬合趨勢線的係數。

以下範例建立一個散佈 (XY) 圖表，產量從 1 到 4，成本分別為 170、200、230 與 260。它先以預設自動截距儲存圖表，然後將截距設定為 100 並儲存第二個 PPTX。兩個檔案唯一的差異在於截距設定。趨勢線會顯示其方程式並向後延伸至 X = 0。

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

使用自動計算時，這些資料會產生 `y = 30x + 140`。將截距設定為 100 時則大約產生 `y = 43.33x + 100`：零點的擬合值符合已知基線，而線條不再通過每一個資料點。

| 自動截距 | 截距固定為 100 |
| --- | --- |
| ![自動計算截距為 140 的線性趨勢線](intercept-automatic.png) | ![截距固定為 100 的線性趨勢線](intercept-fixed.png) |

兩張影像使用相同的資料與座標軸比例。趨勢線向後延伸至 X = 0 以顯示其截距。

預設情況下，[getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept)回傳 `NaN`，表示截距未指定而非零。之後會根據資料自動計算截距。

## **加入自訂線**

自訂線是一種繪製在圖表上方的形狀，而非從系列資料計算出的趨勢線。本範例使用[ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape)在圖表上方的投影片上加入一條水平線。線條的位置以投影片坐標（點數）指定，因而從圖表左邊緣開始，位於圖表高度的正中間。其寬度與圖表寬度相同。[getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat)為線條設定實心紅色。

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

## **常見問題**

**「前向」與「後向」對於趨勢線代表什麼意思？**

它們是趨勢線向前或向後投射的長度：對於散佈 (XY) 圖表 — 以座標單位表示；對於非散佈圖表 — 以類別數量表示。僅允許非負值。

**在將簡報匯出為 PDF 或 SVG，或將投影片渲染為影像時，趨勢線會被保留嗎？**

是的。Aspose.Slides 可將簡報轉換為[PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)或[SVG](/slides/zh-hant/nodejs-java/render-a-slide-as-an-svg-image/)並將圖表渲染為影像；作為圖表一部份的趨勢線在這些操作中會被保留。也提供了[匯出圖表影像](/slides/zh-hant/nodejs-java/create-shape-thumbnails/)的方法。