---
title: Diagrammlegenden in Präsentationen auf Android anpassen
linktitle: Diagrammlegende
type: docs
url: /de/androidjava/chart-legend/
keywords:
- Diagrammlegende
- Legendenposition
- Schriftgröße
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Passen Sie Diagrammlegenden mit Aspose.Slides für Android via Java an, um PowerPoint-Präsentationen mit maßgeschneiderter Legendenformatierung zu optimieren."
---
## **Übersicht**

Aspose.Slides for Android via Java bietet Optionen zum Anpassen von Diagrammlegenden in PowerPoint‑Präsentationen. Dieser Artikel zeigt, wie man eine Legende positioniert und deren Größe festlegt, die Schriftgröße für die gesamte Legende einstellt, einen einzelnen Legendeneintrag formatiert und ausgewählte Einträge ausblendet oder wiederherstellt.

Die FAQ behandelt verwandte Verhaltensweisen, einschließlich das Reservieren von Platz für die Legende, das Anzeigen von mehrzeiligen Beschriftungen und das Erben von Formatierungen aus dem Präsentationsthema.

## **Legendenpositionierung**

Verwenden Sie die Methoden [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-), und [setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-) der Legende, um deren Position und Größe als Bruchteile der Diagrammabmessungen anzugeben.

Dieses Beispiel erstellt eine Präsentation und fügt der ersten Folie ein gruppiertes Säulendiagramm mit Standarddaten hinzu. Durch Teilen der gewünschten Legendenversätze und -abmessungen durch die Breite und Höhe des Diagramms werden diese in relative Werte umgewandelt: Die Legende ist um 50 Punkte vom linken oberen Eck des Diagramms versetzt und hat eine Größe von 100 by 100 Punkte.

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

## **Schriftgröße der Legende festlegen**

Verwenden Sie die Methode [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) , um auf die Textformatierung der Legende zuzugreifen, und die Methode [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) , um die Schriftgröße in Punkten festzulegen.

Dieses Beispiel erstellt ein Diagramm mit Standarddaten und setzt den Legendentext auf 20 Punkte. Außerdem deaktiviert es die automatischen Grenzen der vertikalen Achse und legt deren Wertebereich von -5 bis 10 fest.

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

## **Schriftgröße eines einzelnen Legendeneintrags festlegen**

Verwenden Sie die von der Methode [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) der Legende zurückgegebene Sammlung, um die Formatierung eines bestimmten Eintrags zu erhalten. Die Eintragsindizes beginnen bei null, sodass der Index `1` den zweiten Eintrag bezeichnet.

Dieses Beispiel erstellt ein gruppiertes Säulendiagramm, dessen Standarddaten mindestens zwei Serien enthalten. Es formatiert den zweiten Legendeneintrag fett, kursiv und mit blauem Text in 20 Punkten.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Einzelne Legendeneinträge ausblenden**

Um eine Hilfsserie aus der Legende auszuschließen, während ihre Daten sichtbar bleiben, rufen Sie [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) mit `true` über [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) auf. Dadurch wird nur der ausgewählte Legendeneintrag ausgeblendet; die Serie oder ihre Datenpunkte werden nicht entfernt. Im Gegensatz dazu blendet ein Aufruf von [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) mit `false` die gesamte Legende aus.

Das untenstehende Beispiel erstellt ein gruppiertes Säulendiagramm mit mehreren Serien anhand von Standarddaten. Es blendet den Legendeneintrag der zweiten Serie (Index `1`) aus und speichert die Präsentation. Anschließend wird der Eintrag durch Aufruf von [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) mit `false` wiederhergestellt und eine zweite Kopie gespeichert. Die Säulen bleiben in beiden Dateien sichtbar.

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

    // Stellen Sie denselben Eintrag wieder her, ohne die Diagrammdaten zu ändern.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der Vergleich unten zeigt dasselbe Diagramm mit allen sichtbaren Einträgen und mit dem ausgeblendeten zweiten Eintrag. Die Säulen der zweiten Serie bleiben unverändert.

![Vergleich eines Diagramms mit allen sichtbaren Legendeneinträgen und mit Serie 2 ausgeblendet aus der Legende; alle Säulen bleiben sichtbar.](hide-legend-entry.png)

In Säulen-, Balken- und Liniendiagrammen identifizieren Legendeneinträge die Serien. Bei Kreisdiagrammen identifizieren sie einzelne Datenpunkte (Scheiben), daher verwenden Sie [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) auf der ausgewählten Scheibe statt. Die API dokumentiert diese Datenpunkt‑Methode für die Diagrammtypen `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` und `BarOfPie`. Gehen Sie nicht davon aus, dass sie für Donut‑Diagramme gilt, die in dieser Liste nicht enthalten sind.

## **FAQ**

**Kann ich das Diagramm dazu bringen, Platz für die Legende zu reservieren, anstatt sie zu überlagern?**

Ja. Rufen Sie [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) mit `false` auf, um Platz für die Legende zu reservieren, anstatt sie den Plot‑Bereich überlappen zu lassen.

**Kann ich mehrzeilige Legendebeschriftungen erzeugen?**

Ja. Lange Beschriftungen können umbrochen werden, wenn die verfügbare Breite nicht ausreicht. Sie können außerdem Zeilenumbrüche in Seriennamen einfügen, um Zeilenumbrüche zu erzwingen.

**Wie bringe ich die Legende dazu, dem Farbschema des Präsentationsthemas zu folgen?**

Lassen Sie die Farben, Füllungen und Schriftarten der Legende unverändert, damit sie die Formatierung des Themas erben kann. Explizite Formatierungen überschreiben die entsprechenden Theme‑Einstellungen.