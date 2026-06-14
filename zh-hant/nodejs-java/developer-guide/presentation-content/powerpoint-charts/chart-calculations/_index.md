---
title: 在 JavaScript 中優化簡報的圖表計算
linktitle: 圖表計算
type: docs
weight: 50
url: /zh-hant/nodejs-java/chart-calculations/
keywords:
- 圖表計算
- 圖表元素
- 元素位置
- 實際位置
- 子元素
- 父元素
- 圖表值
- 實際值
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解 Aspose.Slides for Node.js 在 PPT 與 PPTX 中的圖表計算、資料更新與精度控制，並提供實用的 JavaScript 程式碼範例。"
---
## **概述**

Aspose.Slides 提供用於在簡報中處理圖表計算和版面配置資料的 API。本文示範如何取得圖表元素的實際值，包括元素的真實位置與大小，以及圖表坐標軸的實際值。也說明這些值會在圖表版面配置驗證之後填入。

此外，本文還示範如何取得父圖表元素的實際位置，以及如何隱藏圖表元件，例如標題、坐標軸、圖例和格線。這些範例可協助您以程式方式檢查圖表版面配置資訊，並控制 PowerPoint 簡報中圖表元素的可見性。

## **計算圖表元素的實際值**

Aspose.Slides for Node.js via Java 提供簡單的 API 來取得這些屬性。[Axis](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Axis) 類別的屬性可提供坐標軸圖表元素的實際位置資訊（[Axis.getActualMaxValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Axis#getActualMaxValue--)、[Axis.getActualMinValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Axis#getActualMinValue--)、[Axis.getActualMajorUnit](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Axis#getActualMajorUnit--)、[Axis.getActualMinorUnit](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Axis#getActualMinorUnit--)、[Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--)、[Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)）。 必須先呼叫方法 [Chart.validateChartLayout()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Chart#validateChartLayout--) 以在屬性中填入實際值。

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **計算父圖表元素的實際位置**

Aspose.Slides for Node.js via Java 提供簡單的 API 來取得這些屬性。`ActualLayout` 類別的屬性可提供父圖表元素的實際位置資訊：`ActualLayout.getActualX`、`ActualLayout.getActualY`、`ActualLayout.getActualWidth`、`ActualLayout.getActualHeight`。 必須先呼叫方法 [Chart.validateChartLayout()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Chart#validateChartLayout--) 以在屬性中填入實際值。

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **隱藏圖表資訊**

本主題說明如何從圖表中隱藏資訊。使用 Aspose.Slides for Node.js via Java，您可以隱藏圖表的**標題、垂直坐標軸、水平坐標軸**以及**格線**。以下程式碼範例示範如何使用這些屬性。

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // 隱藏圖表標題
    chart.setTitle(false);
    // /隱藏數值軸
    chart.getAxes().getVerticalAxis().setVisible(false);
    // 類別軸可見性
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // 隱藏圖例
    chart.setLegend(false);
    // 隱藏主格線
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // 設定系列線條顏色
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**外部 Excel 活頁簿能作為資料來源嗎？這會如何影響重新計算？**

是。圖表可以參照外部活頁簿：當您連接或重新整理外部來源時，公式與數值會從該活頁簿取得，圖表會在開啟或編輯時反映這些更新。API 允許您[指定外部活頁簿](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/setexternalworkbook/)路徑並管理已連結的資料。

**我能在不自行實作迴歸的情況下計算並顯示趨勢線嗎？**

是。[趨勢線](/slides/zh-hant/nodejs-java/trend-line/)（線性、指數等）由 Aspose.Slides 自動加入並更新；其參數會自動根據系列資料重新計算，您不必自行實作計算。

**如果簡報中有多個帶外部連結的圖表，我能控制每個圖表使用哪個活頁簿來計算值嗎？**

是。每個圖表都可以指向自己的[外部活頁簿](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/setexternalworkbook/)，亦可針對各圖表獨立建立或取代外部活頁簿，而不受其他圖表影響。