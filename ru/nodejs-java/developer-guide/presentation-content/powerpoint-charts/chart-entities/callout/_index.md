---
title: Подсказка
type: docs
url: /ru/nodejs-java/callout/
---

## **Использование callout'ов**

Новые методы [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) и [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-) добавлены в класс [DataLabelFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat) и в класс [DataLabelFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat). Эти методы определяют, будет ли метка данных указанной диаграммы отображаться как data callout или как метка данных.
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


## **Установка callout'а для кольцевой диаграммы**

Aspose.Slides for Node.js via Java предоставляет возможность задавать форму callout'а метки данных серии для кольцевой диаграммы. Ниже приведён пример.
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

**Сохраняются ли callout'ы при конвертации презентации в PDF, HTML5, SVG или изображения?**

Да. Callout'ы являются частью отрисовки диаграммы, поэтому при экспорте в [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/), [HTML5](/slides/ru/nodejs-java/export-to-html5/), [SVG](/slides/ru/nodejs-java/render-a-slide-as-an-svg-image/) или [растровые изображения](/slides/ru/nodejs-java/convert-powerpoint-to-png/) они сохраняются вместе с форматированием слайда.

**Работают ли пользовательские шрифты в callout'ах, и можно ли сохранить их внешний вид при экспорте?**

Да. Aspose.Slides поддерживает [встраивание шрифтов](/slides/ru/nodejs-java/embedded-font/) в презентацию и управляет встраиванием шрифтов при экспорте, например в [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/), гарантируя, что callout'ы выглядят одинаково на разных системах.