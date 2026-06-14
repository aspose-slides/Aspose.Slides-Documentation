---
title: 使用 JavaScript 管理簡報圖表中的標註
linktitle: 標註
type: docs
url: /zh-hant/nodejs-java/callout/
keywords:
- 圖表標註
- 使用標註
- 資料標籤
- 標籤格式
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用簡潔的程式碼範例在 Aspose.Slides for Node.js via Java 中建立與設定標註，兼容 PPT 與 PPTX，協助自動化簡報工作流程。"
---
## **Overview**

本文說明如何在 Aspose.Slides 中使用圖表資料標籤的標註。它示範如何使用 `setShowLabelAsDataCallout` 方法將標籤顯示為標註、如何為環狀圖配置與標註相關的標籤設定，以及指出在將簡報匯出為 PDF、HTML5、SVG 與點陣圖格式時，標註及其外觀會被保留。

## **Using Callouts**

已在[DataLabelFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/DataLabelFormat)類別中加入新方法[**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--)與[**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-)。這些方法決定指定圖表的資料標籤是否顯示為資料標註或資料標籤。

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 500, 400);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    pres.save("DisplayCharts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Callout for Doughnut Chart**

Aspose.Slides for Node.js via Java 提供設定環狀圖系列資料標籤標註形狀的支援。以下提供範例程式碼。

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Doughnut, 10, 10, 500, 500, false);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    var seriesIndex = 0;
    while (seriesIndex < 15) {
        var series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize(20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    var categoryIndex = 0;
    while (categoryIndex < 15) {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        var i = 0;
        while (i < chart.getChartData().getSeries().size()) {
            var iCS = chart.getChartData().getSeries().get_Item(i);
            var dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
            if (i == (chart.getChartData().getSeries().size() - 1)) {
                var lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new aspose.slides.FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX(lbl.getX() + 0.5);
                lbl.setY(lbl.getY() + 0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**在將簡報轉換為 PDF、HTML5、SVG 或影像時，標註會被保留嗎？**

是。標註是圖表呈現的一部份，因此在匯出為[PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)、[HTML5](/slides/zh-hant/nodejs-java/export-to-html5/)、[SVG](/slides/zh-hant/nodejs-java/render-a-slide-as-an-svg-image/)或[raster images](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/)時，會與投影片的格式一起被保留。

**自訂字體能在標註中使用，且其外觀在匯出時能被保留嗎？**

是。Aspose.Slides 支援將[embedding fonts](/slides/zh-hant/nodejs-java/embedded-font/)嵌入簡報，並在匯出如[PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)等格式時控制字體嵌入，確保標註在不同系統上看起來相同。