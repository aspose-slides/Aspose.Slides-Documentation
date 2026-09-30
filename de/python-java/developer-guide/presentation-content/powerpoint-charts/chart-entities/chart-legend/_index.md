---
title: Diagrammlegenden in Präsentationen mit Python anpassen
linktitle: Diagrammlegende
type: docs
url: /de/python-java/chart-legend/
keywords:
- Diagrammlegende
- Legendenposition
- Schriftgröße
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Passen Sie Diagrammlegenden mit Aspose.Slides für Python via Java an, um PowerPoint-Präsentationen mit individueller Legendengestaltung zu optimieren."
---
## **Übersicht**

Aspose.Slides for Python via Java bietet Optionen zum Anpassen von Diagrammlegenden in PowerPoint‑Präsentationen. Dieser Artikel zeigt, wie man eine Legende positioniert und deren Größe festlegt, die Schriftgröße für die gesamte Legende einstellt, einen einzelnen Legendeneintrag formatiert und ausgewählte Einträge ausblendet oder wiederherstellt.

Das FAQ behandelt verwandte Verhaltensweisen, einschließlich des Reservierens von Platz für die Legende, der Anzeige mehrzeiliger Beschriftungen und des Erbens von Formatierungen aus dem Präsentationsthema.

## **Legendenpositionierung**

Verwenden Sie die Methoden der Legende [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth) und [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight), um ihre Position und Größe als Bruchteile der Diagrammdimensionen anzugeben.

Dieses Beispiel erstellt eine Präsentation und fügt dem ersten Folienlayout ein gruppiertes Säulendiagramm mit Standarddaten hinzu. Durch Teilen der gewünschten Legenden‑Versatzwerte und -Abmessungen durch die Breite und Höhe des Diagramms werden relative Werte erzeugt: Die Legende wird um 50 Punkte vom linken oberen Eck des Diagramms versetzt und auf 100 × 100 Punkte dimensioniert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Geben Sie die Position und Größe der Legende relativ zum Diagramm an.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Schriftgröße einer Legende festlegen**

Verwenden Sie die Legende [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat), um auf die Textformatierung zuzugreifen, und [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight), um die Schriftgröße in Punkten festzulegen.

Dieses Beispiel erstellt ein Diagramm mit Standarddaten und setzt den Legendentext auf 20 Punkte. Außerdem deaktiviert es die automatischen Grenzen für die vertikale Achse und legt deren Wertebereich auf –5 bis 10 fest.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Schriftgröße eines einzelnen Legendeneintrags festlegen**

Verwenden Sie die Sammlung, die von der Legende‑[getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries)‑Methode zurückgegeben wird, um die Formatierung eines bestimmten Eintrags zu erreichen. Eintragsindizes beginnen bei Null, sodass Index `1` den zweiten Eintrag bezeichnet.

Dieses Beispiel erstellt ein gruppiertes Säulendiagramm, dessen Standarddaten mindestens zwei Serien enthalten. Es formatiert den zweiten Legendeneintrag fett, kursiv und in blauer Schrift mit 20 Punkten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Einzelne Legendeneinträge ausblenden**

Um eine Hilfsserie aus der Legende zu entfernen, während deren Daten weiterhin sichtbar bleiben, rufen Sie [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) mit `True` über [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry) auf. Dies blendet nur den ausgewählten Legendeneintrag aus; die Serie oder ihre Datenpunkte werden nicht entfernt. Das Aufrufen von [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) mit `False` hingegen blendet die gesamte Legende aus.

Das untenstehende Beispiel erstellt ein gruppiertes Säulendiagramm mit mehreren Serien aus Standarddaten. Es blendet den Legendeneintrag der zweiten Serie (Index `1`) aus und speichert die Präsentation. Anschließend wird der Eintrag durch Aufruf von [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) mit `False` wieder eingeblendet und eine zweite Kopie gespeichert. Die Säulen bleiben in beiden Dateien sichtbar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # Den gleichen Eintrag wiederherstellen, ohne die Diagrammdaten zu ändern.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Der Vergleich unten zeigt dasselbe Diagramm mit allen Einträgen sichtbar und mit dem zweiten Eintrag ausgeblendet. Die Säulen der zweiten Serie bleiben unverändert.

![Vergleich eines Diagramms mit allen sichtbaren Legendeneinträgen und mit Serie 2 in der Legende ausgeblendet; alle Säulen bleiben sichtbar.](hide-legend-entry.png)

In Säulen‑, Balken‑ und Liniendiagrammen identifizieren Legendeneinträge die Serien. In Kreisdiagrammen identifizieren sie einzelne Datenpunkte (Scheiben); verwenden Sie dazu [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) für die ausgewählte Scheibe. Die API dokumentiert diese Datenpunkt‑Methode für die Diagrammtypen `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` und `BarOfPie`. Gehen Sie nicht davon aus, dass sie für Donut‑Diagramme gilt, die nicht in dieser Liste enthalten sind.

## **FAQ**

**Kann ich das Diagramm dazu bringen, Platz für die Legende zu reservieren, anstatt sie zu überlagern?**

Ja. Rufen Sie [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) mit `False` auf, um Platz für die Legende zu reservieren, anstatt zu erlauben, dass sie den Plot‑Bereich überlappt.

**Kann ich mehrzeilige Legendebeschriftungen erstellen?**

Ja. Lange Beschriftungen können umgebrochen werden, wenn die verfügbare Breite nicht ausreicht. Sie können zudem Zeilenumbruchzeichen in Seriennamen einfügen, um Zeilenumbrüche zu erzwingen.

**Wie bringe ich die Legende dazu, das Farbschema des Präsentationsthemas zu übernehmen?**

Lassen Sie die Farben, Füllungen und Schriftarten der Legende unverändert, damit sie das Theme‑Formatting erben kann. Explizite Formatierungen überschreiben die entsprechenden Theme‑Einstellungen.