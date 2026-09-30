---
title: Diagrammlegenden in Präsentationen mit Java anpassen
linktitle: Diagrammlegende
type: docs
url: /de/java/chart-legend/
keywords:
- Diagrammlegende
- Legendenposition
- Schriftgröße
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Passen Sie Diagrammlegenden mit Aspose.Slides für Java an, um PowerPoint-Präsentationen durch maßgeschneiderte Legendenformatierung zu optimieren."
---
## **Übersicht**

Aspose.Slides for Java bietet Optionen zum Anpassen von Diagrammlegenden in PowerPoint‑Präsentationen. Dieser Artikel zeigt, wie man eine Legende positioniert und ihre Größe festlegt, die Schriftgröße für die gesamte Legende einstellt, einen einzelnen Legenden‑Eintrag formatiert und ausgewählte Einträge ausblendet oder wiederherstellt.

Die FAQ behandelt verwandte Verhaltensweisen, einschließlich der Reservierung von Platz für die Legende, der Anzeige mehrzeiliger Beschriftungen und der Vererbung von Formatierungen aus dem Präsentationsthema.

## **Legendenpositionierung**

Verwenden Sie die Methoden der Legende [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-) und [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-), um deren Position und Größe als Bruchteile der Diagramm‑Abmessungen anzugeben.

Dieses Beispiel erstellt eine Präsentation und fügt der ersten Folie ein gruppiertes Säulendiagramm mit Standarddaten hinzu. Durch Teilen der gewünschten Legenden‑Versätze und -Abmessungen durch die Diagrammbreite bzw. -höhe werden relative Werte erzeugt: Die Legende wird um 50 Punkte vom oberen linken Eckpunkt des Diagramms versetzt und auf 100 × 100 Punkte skaliert.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Geben Sie die Position und Größe der Legende relativ zum Diagramm an.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Schriftgröße einer Legende festlegen**

Verwenden Sie die Legende‑Methode [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) um auf die Textformatierung zuzugreifen und [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) um die Schriftgröße in Punkten festzulegen.

Dieses Beispiel erstellt ein Diagramm mit Standarddaten und setzt den Legendentext auf 20 Punkte. Außerdem wird die automatische Begrenzung der vertikalen Achse deaktiviert und ihr Wertebereich auf -5 bis 10 gesetzt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Schriftgröße eines einzelnen Legenden‑Eintrags festlegen**

Verwenden Sie die Sammlung, die von der Legende‑Methode [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) zurückgegeben wird, um die Formatierung eines bestimmten Eintrags zu ändern. Die Eintragsindizes beginnen bei 0, sodass Index `1` den zweiten Eintrag bezeichnet.

Dieses Beispiel erstellt ein gruppiertes Säulendiagramm, dessen Standarddaten mindestens zwei Reihen enthalten. Es formatiert den zweiten Legenden‑Eintrag fett, kursiv und in blauer Schrift mit 20 Punkten.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Einzelne Legenden‑Einträge ausblenden**

Um eine Hilfs‑Reihe aus der Legende zu entfernen, während ihre Daten weiterhin sichtbar bleiben, rufen Sie [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) mit `true` über [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) auf. Dadurch wird nur der ausgewählte Legenden‑Eintrag ausgeblendet; die Reihe oder ihre Datenpunkte werden nicht entfernt. Das Aufrufen von [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) mit `false` hingegen blendet die gesamte Legende aus.

Das nachstehende Beispiel erstellt ein gruppiertes Säulendiagramm mit mehreren Reihen aus Standarddaten. Es blendet den Legenden‑Eintrag der zweiten Reihe (Index `1`) aus und speichert die Präsentation. Anschließend wird der Eintrag wieder eingeblendet, indem [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) mit `false` aufgerufen wird, und eine zweite Datei gespeichert. Die Säulen bleiben in beiden Dateien sichtbar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // Wiederherstellen des gleichen Eintrags ohne Änderung der Diagrammdaten.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der Vergleich unten zeigt dasselbe Diagramm mit allen Einträgen sichtbar und mit dem zweiten Eintrag ausgeblendet. Die Säulen der zweiten Reihe bleiben unverändert.

![Vergleich eines Diagramms mit allen sichtbaren Legenden‑Einträgen und mit ausgeblendeten Eintrag von Serie 2; alle Säulen bleiben sichtbar.](hide-legend-entry.png)

In Spalten‑, Balken‑ und Liniendiagrammen identifizieren Legenden‑Einträge die Reihen. Bei Kreisdiagrammen identifizieren sie einzelne Datenpunkte (Scheiben), sodass Sie [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) für die ausgewählte Scheibe verwenden sollten. Die API dokumentiert diese Datenpunkt‑Methode für die Diagrammtypen `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` und `BarOfPie`. Gehen Sie nicht davon aus, dass sie auch für Donut‑Diagramme gilt, die nicht in dieser Liste aufgeführt sind.

## **FAQ**

**Kann ich das Diagramm veranlassen, Platz für die Legende zu reservieren, anstatt sie zu überlagern?**

Ja. Rufen Sie [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) mit `false` auf, um Platz für die Legende zu reservieren, anstatt zu erlauben, dass sie den Zeichenbereich überlappt.

**Kann ich mehrzeilige Legenden‑Beschriftungen erzeugen?**

Ja. Lange Beschriftungen können umgebrochen werden, wenn die verfügbare Breite nicht ausreicht. Sie können außerdem Zeilenumbrüche in Reihen­namen einfügen, um Zeilenumbrüche zu erzwingen.

**Wie bringe ich die Legende dazu, das Farbschema des Präsentationsthemas zu übernehmen?**

Lassen Sie die Farben, Füllungen und Schriftarten der Legende unverändert, damit sie die Formatierung des Themas erben kann. Explizite Formatierungen überschreiben die entsprechenden Theme‑Einstellungen.