---
title: Gérer les infobulles dans les graphiques de présentation avec Java
linktitle: Infobulle
type: docs
url: /fr/java/callout/
keywords:
- infobulle de graphique
- utiliser infobulle
- étiquette de données
- format d'étiquette
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Créer et styliser des infobulles dans Aspose.Slides pour Java avec des exemples de code concis, compatibles avec PPT et PPTX pour automatiser les flux de travail de présentation."
---

## **Utilisation des infobulles**
De nouvelles méthodes [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) et [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) ont été ajoutées à la classe [DataLabelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/datalabelformat) et à l'interface [IDataLabelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat). Ces méthodes déterminent si l'étiquette de données du graphique spécifié sera affichée sous forme d'infobulle de données ou d'étiquette de données.
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400);
    
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    
    pres.save("DisplayCharts.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir une infobulle pour un graphique en anneau**
Aspose.Slides for Java offre la prise en charge de la définition de la forme d'infobulle d'étiquette de données de série pour un graphique en anneau. Un exemple de code est fourni ci-dessous.
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, false);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    int seriesIndex = 0;
    while (seriesIndex < 15)
    {
        IChartSeries series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize((byte)20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    int categoryIndex = 0;
    while (categoryIndex < 15)
    {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        int i = 0;
        while (i < chart.getChartData().getSeries().size())
        {
            IChartSeries iCS = chart.getChartData().getSeries().get_Item(i);
            IChartDataPoint dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(LineDashStyle.Solid);
            if (i == chart.getChartData().getSeries().size() - 1)
            {
                IDataLabel lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.LIGHT_GRAY);
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX((float) lbl.getX()+ (float)0.5);
                lbl.setY((float)lbl.getY()+ (float)0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Les infobulles sont‑elles conservées lors de la conversion d’une présentation en PDF, HTML5, SVG ou images ?**

Oui. Les infobulles font partie du rendu du graphique, ainsi lors de l'exportation vers [PDF](/slides/fr/java/convert-powerpoint-to-pdf/), [HTML5](/slides/fr/java/export-to-html5/), [SVG](/slides/fr/java/render-a-slide-as-an-svg-image/) ou [images raster](/slides/fr/java/convert-powerpoint-to-png/), elles sont conservées avec le formatage de la diapositive.

**Les polices personnalisées fonctionnent‑elles dans les infobulles, et leur apparence peut‑elle être conservée lors de l’exportation ?**

Oui. Aspose.Slides prend en charge [l'incorporation de polices](/slides/fr/java/embedded-font/) dans la présentation et gère l'incorporation des polices lors des exportations comme le [PDF](/slides/fr/java/convert-powerpoint-to-pdf/), garantissant que les infobulles conservent le même aspect sur différents systèmes.