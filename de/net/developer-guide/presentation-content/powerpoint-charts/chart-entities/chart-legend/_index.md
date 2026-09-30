---
title: Diagrammlegenden in Präsentationen in .NET anpassen
linktitle: Diagrammlegende
type: docs
url: /de/net/chart-legend/
keywords:
- Diagrammlegende
- Legendenposition
- Schriftgröße
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Diagrammlegenden mit Aspose.Slides für .NET anpassen, um PowerPoint‑Präsentationen durch maßgeschneiderte Legendenformatierung zu optimieren."
---
## **Übersicht**

Aspose.Slides für .NET bietet Optionen zum Anpassen von Diagrammlegenden in PowerPoint‑Präsentationen. Dieser Artikel zeigt, wie man eine Legende positioniert und dimensioniert, die Schriftgröße der gesamten Legende festlegt, einen einzelnen Legendeneintrag formatiert und ausgewählte Einträge ausblendet oder wiederherstellt.

Der FAQ‑Bereich behandelt verwandte Verhaltensweisen, einschließlich der Reservierung von Platz für die Legende, der Anzeige mehrzeiliger Beschriftungen und der Vererbung von Formatierungen aus dem Präsentationsthema.

## **Positionierung der Legende**

Verwenden Sie die Eigenschaften [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/) und [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) der Legende, um deren Position und Größe als Bruchteile der Diagrammabmessungen festzulegen.

Dieses Beispiel erstellt eine Präsentation und fügt der ersten Folie ein gruppiertes Säulendiagramm mit Standarddaten hinzu. Durch Teilen der gewünschten Legendenversätze und -abmessungen durch die Breite bzw. Höhe des Diagramms werden sie in relative Werte umgewandelt: Die Legende ist um 50 Punkte vom linken oberen Eck des Diagramms versetzt und hat die Größe 100 × 100 Punkte.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Position und Größe der Legende relativ zum Diagramm festlegen.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **Schriftgröße einer Legende festlegen**

Verwenden Sie das [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) der Legende, um auf deren Textformatierung zuzugreifen und [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) in Punkten festzulegen.

Dieses Beispiel erstellt ein Diagramm mit Standarddaten und setzt den Legendentext auf 20 Punkte. Es deaktiviert zudem die automatischen Begrenzungen für die vertikale Achse und legt deren Bereich auf –5 bis 10 fest.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **Schriftgröße eines einzelnen Legendeneintrags festlegen**

Verwenden Sie die [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/)‑Sammlung der Legende, um die Formatierung eines bestimmten Eintrags zu bearbeiten. Die Eintragsindizes beginnen bei null, sodass Index `1` den zweiten Eintrag bezeichnet.

Dieses Beispiel erstellt ein gruppiertes Säulendiagramm, dessen Standarddaten mindestens zwei Reihen enthalten. Es formatiert den zweiten Legendeneintrag fett, kursiv und mit blauem 20‑Punkt‑Text.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **Einzelne Legendeneinträge ausblenden**

Um eine Hilfsreihe aus der Legende auszuschließen, während deren Daten sichtbar bleiben, setzen Sie [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) über [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/) auf `true`. Dadurch wird nur der ausgewählte Legendeneintrag ausgeblendet; die Reihe oder deren Datenpunkte werden nicht entfernt. Das Setzen von [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) auf `false` hingegen blendet die gesamte Legende aus.

Das nachstehende Beispiel erstellt ein gruppiertes Säulendiagramm mit mehreren Reihen aus Standarddaten. Es blendet den Legendeneintrag der zweiten Reihe (Index `1`) aus und speichert die Präsentation. Anschließend wird der Eintrag wiederhergestellt, indem `Hide` auf `false` gesetzt wird, und eine zweite Kopie gespeichert. Die Säulen bleiben in beiden Dateien sichtbar.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// Stelle denselben Eintrag wieder her, ohne die Diagrammdaten zu ändern.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

Der Vergleich unten zeigt dasselbe Diagramm mit allen Einträgen sichtbar und mit dem zweiten Eintrag ausgeblendet. Die Säulen der zweiten Reihe bleiben unverändert.

![Comparison of a chart with all legend entries visible and with Series 2 hidden from the legend; all columns remain visible.](hide-legend-entry.png)

In Spalten‑, Balken‑ und Liniendiagrammen identifizieren Legendeneinträge Reihen. In Kreisdiagrammen identifizieren sie einzelne Datenpunkte (Scheiben); verwenden Sie hierfür [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) am ausgewählten Segment. Die API dokumentiert diese Datenpunkt‑Eigenschaft für die Diagrammtypen `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` und `BarOfPie`. Gehen Sie nicht davon aus, dass sie für Donut‑Diagramme gilt, die in dieser Liste nicht enthalten sind.

## **FAQ**

**Kann ich das Diagramm so einstellen, dass es Platz für die Legende reserviert, anstatt sie zu überlagern?**

Ja. Setzen Sie [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) auf `false`, um Platz für die Legende zu reservieren, anstatt sie den Plot‑Bereich überlappen zu lassen.

**Kann ich mehrzeilige Legendenbeschriftungen erstellen?**

Ja. Lange Beschriftungen können umbrechen, wenn die verfügbare Breite nicht ausreicht. Sie können außerdem Zeilenumbrüche in Reihen‑Namen mittels Newline‑Zeichen einfügen, um Zeilenumbrüche zu erzwingen.

**Wie stelle ich sicher, dass die Legende dem Farbschema des Präsentationsthemas folgt?**

Lassen Sie die Farben, Füllungen und Schriftarten der Legende unverändert, damit sie die Formatierung des Themas erben kann. Explizite Formatierungen überschreiben die entsprechenden Theme‑Einstellungen.