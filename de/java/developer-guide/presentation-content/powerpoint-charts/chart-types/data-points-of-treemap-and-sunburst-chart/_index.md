---
title: Datenpunkte des Treemap- und Sunburst-Diagramms
type: docs
url: /de/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords: "Sunburst-Diagramm in Aspose.Slides für Java"
description: "Sunburst-Diagramm, Sunburst-Grafik, Sunburst-Diagramm, Radialdiagramm, Radialgrafik oder mehrstufiges Tortendiagramm mit Aspose.Slides für Java."
---

Unter den verschiedenen Arten von PowerPoint-Diagrammen gibt es zwei "hierarchische" Typen - **Treemap** und **Sunburst** Diagramm (auch bekannt als Sunburst-Grafik, Sunburst-Diagramm, Radialdiagramm, Radialgrafik oder mehrstufiges Tortendiagramm). Diese Diagramme zeigen hierarchische Daten an, die als Baum organisiert sind - von Blättern bis zur Spitze des Asts. Blätter werden durch die Serien-Datenpunkte definiert, und jede nachfolgende geschachtelte Gruppierungsebene wird durch die entsprechende Kategorie definiert. Aspose.Slides für Java ermöglicht das Formatieren der Datenpunkte von Sunburst-Diagrammen und Treemaps in Java.

Hier ist ein Sunburst-Diagramm, bei dem die Daten in der Series1-Spalte die Blattknoten definieren, während andere Spalten die hierarchischen Datenpunkte definieren:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Lassen Sie uns mit dem Hinzufügen eines neuen Sunburst-Diagramms zur Präsentation beginnen:

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
- [**Erstellen eines Sunburst-Diagramms**](/slides/de/java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


Wenn es notwendig ist, die Datenpunkte des Diagramms zu formatieren, sollten wir Folgendes verwenden:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) Klassen 
und [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) Methode 
bieten Zugriff zum Formatieren der Datenpunkte von Treemap und Sunburst-Diagrammen. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager) 
wird verwendet, um auf mehrstufige Kategorien zuzugreifen - es repräsentiert den Container von 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) Objekten. 
Im Grunde genommen ist es ein Wrapper für 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartCategoryLevelsManager) mit 
den Eigenschaften, die spezifisch für Datenpunkte hinzugefügt wurden. 
Die Klasse [**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) hat 
zwei Methoden: [**getFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getFormat--) und 
[**getDataLabel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getLabel--) die 
Zugriff auf die entsprechenden Einstellungen bieten.
## **Datenpunktwert anzeigen**
Wert des Datenpunkts "Leaf 4" anzeigen:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Datenpunktlabel und Farbe festlegen**
Datenlabel von "Branch 1" so festlegen, dass der Serienname ("Series1") anstelle des Kategorienamens angezeigt wird. Dann die Textfarbe auf Gelb setzen:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Datenpunktastfarbe festlegen**
Ändern Sie die Farbe des Zweigs "Steam 4":

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