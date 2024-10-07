---
title: Datenpunkte von Baumkarten und Sonnenstrahl-Diagrammen
type: docs
url: /androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords: "Sonnenstrahl-Diagramm in Aspose.Slides für Android über Java"
description: "Sonnenstrahl-Diagramm, Sonnenstrahl-Grafik, Sonnenstrahl-Diagramm, Radialdiagramm, Radialgrafik oder Mehrstufiges Kreisdiagramm mit Aspose.Slides für Android über Java."
---

Unter den verschiedenen Arten von PowerPoint-Diagrammen gibt es zwei "hierarchische" Typen - **Baumkarte** und **Sonnenstrahl** Diagramm (auch bekannt als Sonnenstrahl-Grafik, Sonnenstrahl-Diagramm, Radialdiagramm, Radialgrafik oder Mehrstufiges Kreisdiagramm). Diese Diagramme stellen hierarchische Daten dar, die als Baum strukturiert sind - von den Blättern bis zur Spitze des Zweigs. Blätter werden durch die Serien-Datenpunkte definiert, und jede nachfolgende verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie definiert. Aspose.Slides für Android über Java ermöglicht die Formatierung von Datenpunkten im Sonnenstrahl-Diagramm und Baumkarte in Java.

Hier ist ein Sonnenstrahl-Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während andere Spalten hierarchische Datenpunkte definieren:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Lassen Sie uns beginnen, indem wir ein neues Sonnenstrahl-Diagramm zur Präsentation hinzufügen:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="Siehe auch" %}} 
- [**Erstellen eines Sonnenstrahl-Diagramms**](/slides/androidjava/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Wenn es notwendig ist, die Datenpunkte des Diagramms zu formatieren, sollten wir Folgendes verwenden:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) Klassen 
und [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) Methode 
bieten Zugriff zur Formatierung von Datenpunkten in Baumkarten und Sonnenstrahl-Diagrammen. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager)
wird verwendet, um auf mehrstufige Kategorien zuzugreifen - es stellt den Container für 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) Objekte dar.
Im Grunde ist es ein Wrapper für 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartCategoryLevelsManager) mit
den hinzugefügten Eigenschaften, die spezifisch für Datenpunkte sind. 
Die Klasse [**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) hat
zwei Methoden: [**getFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) und 
[**getDataLabel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--), die
Zugriff auf die entsprechenden Einstellungen ermöglichen.
## **Datenpunktwert anzeigen**
Wert des Datenpunkts "Blatt 4" anzeigen:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Datenpunktlabel und Farbe festlegen**
Datenlabel für "Zweig 1" festlegen, um den Seriennamen ("Series1") anstelle des Kategorienamens anzuzeigen. Dann den Textfarbe auf gelb setzen:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Farbe des Datenpunktzweigs festlegen**
Farbe des Branches "Dampfer 4" ändern:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)