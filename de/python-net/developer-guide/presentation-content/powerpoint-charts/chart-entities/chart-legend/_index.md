---
title: Diagrammlegenden in Präsentationen mit Python anpassen
linktitle: Diagrammlegende
type: docs
url: /de/python-net/chart-legend/
keywords:
- Diagrammlegende
- Legendenposition
- Schriftgröße
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Passen Sie Diagrammlegenden mit Aspose.Slides für Python via .NET an, um PowerPoint-Präsentationen mit individuell formatierter Legende zu optimieren."
---
## **Übersicht**

Aspose.Slides für Python via .NET bietet Optionen zum Anpassen von Diagrammlegenden in PowerPoint‑Präsentationen. Dieser Artikel zeigt, wie man eine Legende positioniert und ihre Größe festlegt, die Schriftgröße für die gesamte Legende einstellt, einen einzelnen Legendeeintrag formatiert und ausgewählte Einträge ausblendet oder wiederherstellt.

Das FAQ behandelt verwandte Verhaltensweisen, einschließlich der Reservierung von Platz für die Legende, der Anzeige mehrzeiliger Beschriftungen und der Vererbung von Formatierungen aus dem Präsentationsthema.

## **Legendenpositionierung**

Verwenden Sie die Eigenschaften [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/) und [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) der Legende, um deren Position und Größe als Bruchteile der Diagrammdimensionen festzulegen.

Dieses Beispiel erstellt eine Präsentation und fügt der ersten Folie ein gruppiertes Säulendiagramm mit Standarddaten hinzu. Durch Teilen der gewünschten Legenden‑Offsets und -Abmessungen durch die Breite und Höhe des Diagramms werden relative Werte erhalten: Die Legende wird um 50 Punkt vom linken oberen Diagrammrand versetzt und hat die Größe 100 × 100 Punkt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Position und Größe der Legende relativ zum Diagramm angeben.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **Schriftgröße einer Legende festlegen**

Verwenden Sie die [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) der Legende, um deren Textformatierung zuzugreifen und [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) in Punkten festzulegen.

Dieses Beispiel erstellt ein Diagramm mit Standarddaten und setzt den Legendentext auf 20 Punkt. Außerdem werden die automatischen Grenzen der vertikalen Achse deaktiviert und ihr Wertebereich auf –5 bis 10 festgelegt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Schriftgröße eines einzelnen Legendeeintrags festlegen**

Verwenden Sie die [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/)‑Sammlung der Legende, um die Formatierung eines bestimmten Eintrags zu erhalten. Eintragsindizes beginnen bei null, sodass Index `1` den zweiten Eintrag bezeichnet.

Dieses Beispiel erstellt ein gruppiertes Säulendiagramm, dessen Standarddaten mindestens zwei Reihen enthalten. Es formatiert den zweiten Legendeeintrag fett, kursiv und mit blauem Text in 20 Punkt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Einzelne Legendeeinträge ausblenden**

Um eine Hilfsreihe aus der Legende zu entfernen, während ihre Daten sichtbar bleiben, setzen Sie [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) über [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/) auf `True`. Dadurch wird nur der ausgewählte Legendeeintrag ausgeblendet; die Reihe oder ihre Datenpunkte werden nicht entfernt. Das Setzen von [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) auf `False` blendet dagegen die gesamte Legende aus.

Das nachstehende Beispiel erstellt ein gruppiertes Säulendiagramm mit mehreren Reihen anhand der Standarddaten. Es blendet den Legendeeintrag der zweiten Reihe (Index `1`) aus und speichert die Präsentation. Anschließend wird der Eintrag wiederhergestellt, indem [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) auf `False` gesetzt wird, und eine zweite Kopie gespeichert. Die Säulen bleiben in beiden Dateien sichtbar.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Stellen Sie denselben Eintrag wieder her, ohne die Diagrammdaten zu ändern.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

Der Vergleich unten zeigt dasselbe Diagramm mit allen sichtbaren Einträgen und mit dem zweiten Eintrag ausgeblendet. Die Säulen der zweiten Reihe bleiben unverändert.

![Vergleich eines Diagramms mit allen sichtbaren Legendeeinträgen und mit Serie 2 in der Legende ausgeblendet; alle Spalten bleiben sichtbar.](hide-legend-entry.png)

In Säulen‑, Balken‑ und Liniendiagrammen identifizieren Legendeeinträge Reihen. Bei Kreisdiagrammen identifizieren sie einzelne Datenpunkte (Scheiben), sodass stattdessen [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) für die ausgewählte Scheibe verwendet wird. Die API dokumentiert diese Datenpunkt‑Eigenschaft für die Diagrammtypen `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE` und `BAR_OF_PIE`. Gehen Sie nicht davon aus, dass sie für Donut‑Diagramme gilt, da diese nicht in der Liste enthalten sind.

## **FAQ**

**Kann ich das Diagramm veranlassen, Platz für die Legende zu reservieren, anstatt sie zu überlagern?**

Ja. Setzen Sie [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) auf `False`, um Platz für die Legende zu reservieren, anstatt zuzulassen, dass sie den Diagrammbereich überlappt.

**Kann ich mehrzeilige Legendenbeschriftungen erstellen?**

Ja. Lange Beschriftungen können umbrechen, wenn die verfügbare Breite nicht ausreicht. Sie können auch Zeilenumbrüche in Reihen­namen einfügen, um Zeilenumbrüche zu erzwingen.

**Wie bringe ich die Legende dazu, dem Farbschema des Präsentationsthemas zu folgen?**

Lassen Sie die Farben, Füllungen und Schriftarten der Legende ungesetzt, damit sie die Themenformatierung erben kann. Explizite Formatierungen überschreiben die entsprechenden Themeeinstellungen.