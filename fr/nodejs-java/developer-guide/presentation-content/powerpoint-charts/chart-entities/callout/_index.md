---
title: Annotation
type: docs
url: /fr/nodejs-java/callout/
---

## **Utilisation des callouts**

De nouvelles méthodes [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) et [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-) ont été ajoutées à la classe [DataLabelFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat) et à la classe [DataLabelFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat). Ces méthodes déterminent si le libellé de données du graphique spécifié sera affiché sous forme d'annotation de données ou de libellé de données.
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


## **Définir l'annotation pour un diagramme en anneau**

Aspose.Slides pour Node.js via Java offre la prise en charge de la définition de la forme d'annotation du libellé de données de série pour un diagramme en anneau. L'exemple suivant est fourni.  
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

**Les annotations sont‑elles conservées lors de la conversion d’une présentation en PDF, HTML5, SVG ou images ?**

Oui. Les annotations font partie du rendu du graphique, donc lors de l'exportation vers [PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/), [HTML5](/slides/fr/nodejs-java/export-to-html5/), [SVG](/slides/fr/nodejs-java/render-a-slide-as-an-svg-image/) ou [images raster](/slides/fr/nodejs-java/convert-powerpoint-to-png/), elles sont conservées avec le formatage de la diapositive.

**Les polices personnalisées fonctionnent‑elles dans les annotations, et leur apparence peut‑elle être préservée lors de l'exportation ?**

Oui. Aspose.Slides prend en charge [l’intégration des polices](/slides/fr/nodejs-java/embedded-font/) dans la présentation et contrôle l’intégration des polices lors des exportations comme le [PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/), garantissant que les annotations conservent le même aspect sur différents systèmes.