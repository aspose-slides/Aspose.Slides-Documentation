---
title: Kreisdiagramme in Präsentationen in .NET anpassen
linktitle: Kreisdiagramm
type: docs
url: /de/net/pie-chart/
keywords:
- Kreisdiagramm
- Diagramm verwalten
- Diagramm anpassen
- Diagrammoptionen
- Diagrammeinstellungen
- Plot-Optionen
- Segmentfarbe
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen und Anpassen von Kreisdiagrammen in .NET mit Aspose.Slides. Konfigurieren Sie sekundäre Diagramme, zeigen Sie Datenbeschriftungen an und wenden Sie automatische Segmentfarben in PowerPoint an."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Kreisdiagrammen in Aspose.Slides arbeitet. Er zeigt, wie man sekundäre Diagrammoptionen für Kreis‑in‑Kreis‑ und Balken‑in‑Kreis‑Diagramme konfiguriert und wie man für ein Standard‑Kreisdiagramm die automatische Segmentfarbgebung aktiviert.

Die Beispiele konzentrieren sich auf Anpassungsaufgaben wie das Hinzufügen eines Diagramms zu einer Folie, das Anpassen von Reihen‑ und Beschriftungseinstellungen, das Ersetzen der Standarddiagrammdaten durch benutzerdefinierte Kategorien und Werte sowie das Speichern der aktualisierten Präsentation.

## **Optionen für das sekundäre Diagramm bei Kreis‑in‑Kreis‑ und Balken‑in‑Kreis‑Diagrammen**

Aspose.Slides for .NET unterstützt sekundäre Diagrammoptionen für Kreis‑in‑Kreis‑ und Balken‑in‑Kreis‑Diagramme. Diese Optionen bestimmen die Größe des sekundären Diagramms und wie Datenpunkte zwischen den beiden Diagrammen aufgeteilt werden.

Das folgende Beispiel erstellt ein Kreis‑in‑Kreis‑Diagramm in einer neuen Präsentation und zeigt Datenpunktwerte als Beschriftungen an. Die [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/)‑Eigenschaft setzt die Größe des sekundären Diagramms auf 149 % des Hauptdiagramms. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) wählt eine prozentbasierte Aufteilung, und [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) legt die Schwelle auf 53 % fest.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Werte anzeigen und das sekundäre Diagramm konfigurieren.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 55;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **Kategorien für das sekundäre Diagramm auswählen**

Verwenden Sie benutzerdefinierte Aufteilung, wenn Sie bestimmte Kategorien im sekundären Diagramm gruppieren möchten, unabhängig von deren prozentualen Werten. Zum Beispiel könnte ein Verkaufsbericht Online und Events zusammen anzeigen, sodass Leser diese beiden Kanäle vergleichen können, obwohl sie 35 % bzw. 10 % des Gesamtumsatzes ausmachen.

Setzen Sie [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) auf [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) und wählen Sie die Punkte über [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/). Die [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/)‑Methode der Sammlung akzeptiert entweder einen nullbasierten Index in der Reihe oder ein Datenpunkt‑Objekt. In diesem Beispiel wählt Index 1 Online aus, und der Punkt bei Index 3 wählt Events aus. Partners wird ebenfalls vorübergehend hinzugefügt und dann über [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/) ausgeschlossen.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// Ersetzen Sie die Standarddaten durch Verkäufe nach Kanal.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Wählen Sie Online anhand seines nullbasierten Index und Events anhand seines Datenpunktobjekts aus.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Schließen Sie Partners von der Auswahl aus, ohne die Quelldaten zu löschen.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) und Events (10) erscheinen als separate Segmente im sekundären Diagramm. Im primären Diagramm werden sie durch ein kombiniertes Segment mit dem Wert 45 dargestellt, zusammen mit Retail (40) und Partners (15). Das Entfernen von Partners aus der benutzerdefinierten Auswahl belässt es im primären Diagramm; die Kategorie oder ihr Wert werden nicht aus den Quelldaten des Diagramms entfernt.

Das folgende Bild zeigt die gespeicherte Präsentation in PowerPoint:

![Kreis‑in‑Kreis‑Diagramm mit Online und Events im sekundären Diagramm und ihrem kombinierten Wert von 45 im primären Diagramm](pie_of_pie_custom.png)

## **Automatische Farben für Kreisdiagramm‑Segmente festlegen**

Aspose.Slides for .NET kann automatisch unterschiedliche Farben den Segmenten eines Kreisdiagramms zuweisen. Das folgende Beispiel erstellt ein Kreisdiagramm mit einem zentrierten Titel und ersetzt die Standarddaten durch drei Quartals‑Kategorien und deren Werte. Die [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/)‑Eigenschaft zeigt die Werte 20, 50 und 30 als Beschriftungen an, während [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) für eine eindeutige Farbe jedes Segments sorgt.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Fügen Sie einen zentrierten Diagrammtitel hinzu.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Ersetzen Sie die Standarddaten mithilfe des ersten Arbeitsblatts.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Werte anzeigen und den Segmenten unterschiedliche Farben zuweisen.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Unterstützt die Bibliothek die Varianten Kreis‑in‑Kreis und Balken‑in‑Kreis?**

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) ein sekundäres Diagramm für Kreisdiagramme, einschließlich der Typen Kreis‑in‑Kreis und Balken‑in‑Kreis.

**Kann ich nur das Diagramm als Bild exportieren (zum Beispiel PNG)?**

Ja, Sie können [das Diagramm selbst als Bild exportieren](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (z. B. PNG), ohne die gesamte Präsentation zu exportieren.