---
title: Callout
type: docs
url: /nodejs-java/callout/
---

## **Using Callouts**
New methods [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) and [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) have been added to [DataLabelFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat) class and [DataLabelFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat) interface. These methods determine either specified chart's data label will be displayed as data callout or as data label.

```javascript
    var pres = new  aspose.slides.Presentation();
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
Aspose.Slides for Node.js via Java provides support for setting series data label callout shape for a Doughnut chart. Below sample example is given. 

```javascript
    var pres = new  aspose.slides.Presentation();
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
                dataPoint.getFormat().getFill().setFillType(aspose.slides.FillType.Solid);
                dataPoint.getFormat().getLine().getFillFormat().setFillType(aspose.slides.FillType.Solid);
                dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
                dataPoint.getFormat().getLine().setWidth(1);
                dataPoint.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
                dataPoint.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
                if (i == (chart.getChartData().getSeries().size() - 1)) {
                    var lbl = dataPoint.getLabel();
                    lbl.getTextFormat().getTextBlockFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
                    lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                    lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new  aspose.slides.FontData("DINPro-Bold"));
                    lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                    lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
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
