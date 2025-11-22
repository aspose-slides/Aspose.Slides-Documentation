---
title: Datenpunkte von Treemap- und Sunburst-Diagrammen
type: docs
url: /de/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords: "Sunburst-Graph in Aspose.Slides für Node.js via Java"
description: "Sunburst-Graph, Sunburst-Diagramm, Sunburst-Chart, Radial-Chart, Radial-Graph oder Mehrstufiges-Pie-Diagramm mit Aspose.Slides für Node.js via Java."
---

Unter den verschiedenen Diagrammtypen in PowerPoint gibt es zwei „hierarchische“ Typen – **Treemap** und **Sunburst**‑Diagramm (auch bekannt als Sunburst‑Graph, Sunburst‑Diagramm, Radial‑Diagramm, Radial‑Grafik oder Mehrstufiges‑Kreis‑Diagramm). Diese Diagramme zeigen hierarchische Daten, die als Baum strukturiert sind – von den Blättern bis zur Spitze des Astes. Die Blätter werden durch die Datenpunkte der Serie definiert, und jede nachfolgende verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie definiert. Aspose.Slides für Node.js via Java ermöglicht das Formatieren von Datenpunkten des Sunburst‑Diagramms und des Treemap‑Diagramms in JavaScript.

Hier ist ein Sunburst‑Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während die anderen Spalten die hierarchischen Datenpunkte definieren:
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Lassen Sie uns beginnen, ein neues Sunburst‑Diagramm zur Präsentation hinzuzufügen:
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
- [**Erstellen eines Sunburst‑Diagramms**](/slides/de/nodejs-java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Wenn Sie Datenpunkte des Diagramms formatieren müssen, sollten Sie Folgendes verwenden:
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) Klassen 
und [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) Methode 
bieten Zugriff auf das Formatieren von Datenpunkten der Treemap‑ und Sunburst‑Diagramme. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager) wird verwendet, um auf mehrstufige Kategorien zuzugreifen – es stellt den Container von [**ChartDataPointLevel**]‑Objekten dar. Im Grunde ist es ein Wrapper für [**ChartCategoryLevelsManager**] mit den speziell für Datenpunkte hinzugefügten Eigenschaften. Die Klasse [**ChartDataPointLevel**] verfügt über zwei Methoden: [**getFormat**] und [**getDataLabel**], die Zugriff auf die jeweiligen Einstellungen bieten.

## **Datenpunktwert anzeigen**
Wert des Datenpunkts „Leaf 4“ anzeigen:
```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Datenpunktbeschriftung und -farbe festlegen**
Setzen Sie die Datenbeschriftung von „Branch 1“ so, dass sie den Seriennamen ("Series1") anstelle des Kategorienamens anzeigt. Danach setzen Sie die Textfarbe auf Gelb:
```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Farbe des Datenpunktzweigs festlegen**
Farbe des Zweigs „Steam 4“ ändern:
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

Nein. PowerPoint sortiert Segmente automatisch (in der Regel absteigend nach Wert, im Uhrzeigersinn). Aspose.Slides spiegelt dieses Verhalten wider: Sie können die Reihenfolge nicht direkt ändern; Sie erreichen dies durch Vorverarbeitung der Daten.

**Wie wirkt sich das Präsentationsthema auf die Farben von Segmenten und Beschriftungen aus?**

Diagrammfarben übernehmen das [Thema/Palette](/slides/de/nodejs-java/presentation-theme/) der Präsentation, sofern Sie keine Füllungen/Schriften explizit festlegen. Für konsistente Ergebnisse sollten Sie feste Füllungen und Textformatierungen auf den erforderlichen Ebenen festlegen.

**Wird der Export nach PDF/PNG benutzerdefinierte Zweigfarben und Beschriftungseinstellungen beibehalten?**

Ja. Beim Export der Präsentation bleiben die Diagrammeinstellungen (Füllungen, Beschriftungen) in den Ausgabedateien erhalten, da Aspose.Slides das Diagramm mit den angewendeten Formatierungen rendert.

**Kann ich die tatsächlichen Koordinaten einer Beschriftung/eines Elements ermitteln, um benutzerdefinierte Overlays über dem Diagramm zu platzieren?**

Ja. Nachdem das Diagrammlayout validiert wurde, stehen für Elemente die tatsächlichen X‑ und Y‑Werte zur Verfügung (zum Beispiel für ein [DataLabel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/)), was eine präzise Platzierung von Overlays ermöglicht.