---
title: Anpassen von Datenpunkten in Treemap- und Sunburst-Diagrammen mit Java
linktitle: Datenpunkte in Treemap- und Sunburst-Diagrammen
type: docs
url: /de/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap-Diagramm
- Sunburst-Diagramm
- Datenpunkt
- Beschriftungsfarbe
- Zweigfarbe
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Datenpunkte in Treemap- und Sunburst-Diagrammen mit Aspose.Slides für Java verwalten, kompatibel mit PowerPoint-Formaten."
---

Unter den anderen Arten von PowerPoint‑Diagrammen gibt es zwei „hierarchische“ Typen – **Treemap** und **Sunburst**‑Diagramm (auch bekannt als Sunburst‑Graph, Sunburst‑Diagramm, Radial‑Chart, Radial‑Graph oder Multi Level Pie Chart). Diese Diagramme zeigen hierarchische Daten, die als Baum organisiert sind – von den Blättern bis zur Spitze des Astes. Blätter werden durch die Datenpunkte der Serie definiert, und jede nachfolgende verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie bestimmt. Aspose.Slides für Java ermöglicht das Formatieren von Datenpunkten des Sunburst‑Diagramms und des Treemap‑Diagramms in Java.

Hier ist ein Sunburst‑Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während die anderen Spalten hierarchische Datenpunkte definieren:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Lassen Sie uns ein neues Sunburst‑Diagramm zur Präsentation hinzufügen:
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
- [**Erstellen oder Aktualisieren von PowerPoint‑Präsentationsdiagrammen in Java**](/slides/de/java/create-chart/)
{{% /alert %}}

Falls es nötig ist, Datenpunkte des Diagramms zu formatieren, sollten wir das Folgende verwenden:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) Klassen 
und [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) Methode 
bieten Zugriff zum Formatieren von Datenpunkten der Treemap‑ und Sunburst‑Diagramme. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager) 
wird zum Zugriff auf mehrstufige Kategorien verwendet – es stellt den Container von 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) Objekten dar. 
Im Grunde ist es ein Wrapper für 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartCategoryLevelsManager) mit 
eigenschaften, die speziell für Datenpunkte hinzugefügt wurden. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) Klasse hat 
zwei Methoden: [**getFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getFormat--) und 
[**getDataLabel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getLabel--) , die 
Zugriff auf die entsprechenden Einstellungen ermöglichen.

## **Wert eines Datenpunkts anzeigen**
Wert des Datenpunkts „Leaf 4“ anzeigen:
```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Datenpunktbeschriftung und -farbe festlegen**
Setzen Sie die Datenbeschriftung von „Branch 1“ so, dass der Serienname („Series1“) anstelle des Kategorienamens angezeigt wird. Anschließend die Textfarbe auf Gelb setzen:
```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Farbe eines Datenpunktzweigs festlegen**
Farbe des Zweigs „Steam 4“ ändern:
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

## **FAQ**

**Kann ich die Reihenfolge (Sortierung) der Segmente in Sunburst/Treemap ändern?**

Nein. PowerPoint sortiert Segmente automatisch (typischerweise nach absteigenden Werten, im Uhrzeigersinn). Aspose.Slides spiegelt dieses Verhalten wider: Sie können die Reihenfolge nicht direkt ändern; Sie erreichen dies durch Vorverarbeiten der Daten.

**Wie beeinflusst das Präsentationsthema die Farben von Segmenten und Beschriftungen?**

Diagrammfarben erben das [theme/palette](/slides/de/java/presentation-theme/), sofern Sie nicht explizit Füllungen/Schriften festlegen. Für konsistente Ergebnisse sollten Sie feste Füllungen und Textformatierungen auf den erforderlichen Ebenen festlegen.

**Wird der Export nach PDF/PNG benutzerdefinierte Zweigfarben und Beschriftungseinstellungen beibehalten?**

Ja. Beim Exportieren der Präsentation bleiben Diagrammeinstellungen (Füllungen, Beschriftungen) in den Ausgabedateien erhalten, da Aspose.Slides das Diagramm mit den angewendeten Formatierungen rendert.

**Kann ich die tatsächlichen Koordinaten einer Beschriftung/eines Elements berechnen, um ein benutzerdefiniertes Overlay über dem Diagramm zu platzieren?**

Ja. Nach der Validierung des Diagrammlayouts sind die tatsächlichen *x*‑ und *y*‑Koordinaten für Elemente (z. B. ein [DataLabel](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/)) verfügbar, was bei der präzisen Positionierung von Overlays hilft.