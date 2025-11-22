---
title: Kreisdiagramm
type: docs
url: /de/net/pie-chart/
keywords: "Kreisdiagramm, Plot-Optionen, Segmentfarben, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Plot-Optionen und Segmentfarben für Kreisdiagramme in PowerPoint-Präsentationen in C# oder .NET"
---

## **Zweite Plot-Optionen für Pie of Pie und Bar of Pie Diagramm**
Aspose.Slides for .NET unterstützt nun zweite Plot-Optionen für Pie of Pie‑ oder Bar of Pie‑Diagramme. In diesem Thema zeigen wir anhand eines Beispiels, wie diese Optionen mit Aspose.Slides festgelegt werden. Befolgen Sie dazu die folgenden Schritte:

1. Instanziieren Sie das Klassenobjekt [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Fügen Sie dem Folie ein Diagramm hinzu.
3. Geben Sie die zweiten Plot-Optionen des Diagramms an.
4. Schreiben Sie die Präsentation auf die Festplatte.

Im unten stehenden Beispiel haben wir verschiedene Eigenschaften des Pie of Pie‑Diagramms festgelegt.
```c#
// Instanz der Klasse Presentation erstellen
Presentation presentation = new Presentation();

// Diagramm zur Folie hinzufügen
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Verschiedene Eigenschaften festlegen
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Präsentation auf Festplatte speichern
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```


## **Automatische Farben für Pie‑Diagramm‑Scheiben festlegen**
Aspose.Slides for .NET bietet eine einfache API zum Festlegen automatischer Farben für Pie‑Diagramm‑Scheiben. Der Beispielcode wendet die oben genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der Klasse Presentation.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Legen Sie den Diagrammtitel fest.
5. Stellen Sie die erste Serie so ein, dass Werte angezeigt werden.
6. Legen Sie den Index des Diagramm‑Datenblatts fest.
7. Abrufen des Diagramm‑Datenarbeitsblatts.
8. Löschen Sie die standardmäßig generierten Serien und Kategorien.
9. Fügen Sie neue Kategorien hinzu.
10. Fügen Sie neue Serien hinzu.

Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```c#
// Instanziiere Presentation-Klasse, die die PPTX-Datei repräsentiert
using (Presentation presentation = new Presentation())
{
	// Instanziiere Presentation-Klasse, die die PPTX-Datei repräsentiert
	Presentation presentation = new Presentation();

	// Greife auf die erste Folie zu
	ISlide slides = presentation.Slides[0];

	// Diagramm mit Standarddaten hinzufügen
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Diagrammtitel festlegen
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Erste Serie auf Werte anzeigen setzen
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Index des Diagrammdatenblatts festlegen
	int defaultWorksheetIndex = 0;

	// Diagrammdaten-Arbeitsblatt abrufen
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Standardgenerierte Serien und Kategorien löschen
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Neue Kategorien hinzufügen
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Neue Serie hinzufügen
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Jetzt werden die Seriendaten befüllt
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**Werden die Varianten 'Pie of Pie' und 'Bar of Pie' unterstützt?**

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) einen sekundären Plot für Kreisdiagramme, einschließlich der Typen 'Pie of Pie' und 'Bar of Pie'.

**Kann ich nur das Diagramm als Bild (z. B. PNG) exportieren?**

Ja, Sie können das Diagramm selbst als Bild [exportieren](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (z. B. PNG), ohne die gesamte Präsentation.