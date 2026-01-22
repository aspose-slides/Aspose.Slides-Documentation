---
title: Datenpunkte in Treemap- und Sunburst-Diagrammen mit JavaScript anpassen
linktitle: Datenpunkte in Treemap- und Sunburst-Diagrammen
type: docs
url: /de/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap-Diagramm
- sunburst-Diagramm
- Datenpunkt
- Beschriftungsfarbe
- Astfarbe
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Datenpunkte in Treemap- und Sunburst-Diagrammen mit JavaScript und Aspose.Slides für Node.js via Java verwalten, kompatibel mit PowerPoint-Formaten."
---

Unter den anderen PowerPoint‑Diagrammtypen gibt es zwei „hierarchische“ Typen – **Treemap** und **Sunburst**‑Diagramm (auch bekannt als Sunburst‑Graph, Sunburst‑Diagramm, Radial‑Diagramm, Radial‑Graph oder Mehrstufiges Kreis‑Diagramm). Diese Diagramme stellen hierarchische Daten dar, die als Baum strukturiert sind – von den Blättern bis zur Spitze des Astes. Blätter werden durch die Datenpunkte der Serie definiert, und jede nachfolgende verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie bestimmt. Aspose.Slides für Node.js via Java ermöglicht das Formatieren von Datenpunkten des Sunburst‑Diagramms und des Treemap‑Diagramms in JavaScript.

Hier ein Sunburst‑Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während die anderen Spalten hierarchische Datenpunkte definieren:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Lassen Sie uns ein neues Sunburst‑Diagramm zur Präsentation hinzufügen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="Siehe auch" %}} 
- [**Create or Update PowerPoint Presentation Charts in JavaScript**](/slides/de/nodejs-java/create-chart/)
{{% /alert %}}

Falls Datenpunkte des Diagramms formatiert werden müssen, sollten die folgenden Klassen verwendet werden:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) Klassen 
und [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) Methode 
bieten Zugriff zum Formatieren von Datenpunkten von Treemap‑ und Sunburst‑Diagrammen. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager) 
wird zum Zugriff auf mehrstufige Kategorien verwendet – er stellt den Container für 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel)‑Objekte dar.
Im Grunde ist er ein Wrapper für 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartCategoryLevelsManager) 
mit Eigenschaften, die speziell für Datenpunkte hinzugefügt wurden. 
Die Klasse [**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) 
verfügt über zwei Methoden: [**getFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) und 
[**getDataLabel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) – sie ermöglichen den Zugriff auf die jeweiligen Einstellungen.

## **Show Data Point Value**
Wert des Datenpunkts „Leaf 4“ anzeigen:
```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Set Data Point Label and Color**
Datenbeschriftung von „Branch 1“ so einstellen, dass der Serienname („Series1“) anstelle des Kategorienamens angezeigt wird. Anschließend die Textfarbe auf Gelb setzen:
```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Set Data Point Branch Color**
Farbe des Astes „Steam 4“ ändern:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Kann ich die Reihenfolge (Sortierung) der Segmente in Sunburst/Treemap ändern?**

Nein. PowerPoint sortiert die Segmente automatisch (in der Regel absteigend, im Uhrzeigersinn). Aspose.Slides spiegelt dieses Verhalten wider: Die Reihenfolge kann nicht direkt geändert werden; sie wird durch Vorverarbeitung der Daten erreicht.

**Wie wirkt sich das Präsentationsthema auf die Farben von Segmenten und Beschriftungen aus?**

Diagramm‑Farben erben das [Thema/Palette](/slides/de/nodejs-java/presentation-theme/) der Präsentation, sofern nicht ausdrücklich Füllungen/Schriften gesetzt werden. Für konsistente Ergebnisse sollten feste Füllungen und Textformatierungen auf den erforderlichen Ebenen festgelegt werden.

**Werden beim Export nach PDF/PNG benutzerdefinierte Ast‑Farben und Beschriftungseinstellungen erhalten?**

Ja. Beim Export der Präsentation werden Diagramm‑Einstellungen (Füllungen, Beschriftungen) in den Ausgabedateien beibehalten, weil Aspose.Slides das Diagramm mit den angewendeten Formatierungen rendert.

**Kann ich die tatsächlichen Koordinaten einer Beschriftung/eines Elements berechnen, um ein benutzerdefiniertes Overlay über dem Diagramm zu platzieren?**

Ja. Nach der Validierung des Diagrammlayouts stehen die tatsächlichen X‑ und Y‑Werte für Elemente (z. B. ein [DataLabel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/)) zur Verfügung, was eine präzise Positionierung von Overlays ermöglicht.