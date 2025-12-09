---
title: Anpassen von Tortendiagrammen in Präsentationen in .NET
linktitle: Tortendiagramm
type: docs
url: /de/net/pie-chart/
keywords:
- Tortendiagramm
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
description: "Erfahren Sie, wie Sie in .NET mit Aspose.Slides Tortendiagramme erstellen und anpassen, exportierbar nach PowerPoint, und so Ihr Daten-Storytelling in Sekunden verbessern."
---

## **Optionen für das zweite Diagramm für Pie of Pie und Bar of Pie Diagramm**
Aspose.Slides for .NET unterstützt jetzt Optionen für ein zweites Diagramm bei Pie of Pie‑ oder Bar of Pie‑Diagrammen. In diesem Thema sehen wir anhand eines Beispiels, wie diese Optionen mit Aspose.Slides angegeben werden. Bitte folgen Sie den untenstehenden Schritten, um die Eigenschaften festzulegen:

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klassenobjekt.
1. Fügen Sie dem Folie ein Diagramm hinzu.
1. Geben Sie die Optionen für das zweite Diagramm des Diagramms an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im nachstehenden Beispiel haben wir verschiedene Eigenschaften des Pie of Pie‑Diagramms festgelegt.
```c#
// Instanz der Presentation-Klasse erstellen
Presentation presentation = new Presentation();

// Diagramm zur Folie hinzufügen
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Verschiedene Eigenschaften festlegen
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Präsentation auf die Festplatte schreiben
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```





## **Automatische Farben für Pie‑Diagramm‑Segmente festlegen**
Aspose.Slides for .NET bietet eine einfache API zum Festlegen automatischer Farben für Tortenabschnitte. Der Beispielcode wendet die oben genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der Presentation‑Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Legen Sie den Diagrammtitel fest.
1. Setzen Sie die erste Serie auf Werte anzeigen.
1. Legen Sie den Index des Diagrammdatenblatts fest.
1. Abrufen des Diagrammdaten‑Arbeitsblatts.
1. Löschen Sie die standardmäßig generierten Serien und Kategorien.
1. Fügen Sie neue Kategorien hinzu.
1. Fügen Sie neue Serien hinzu.

Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```c#
 // Instanzieren Sie die Presentation‑Klasse, die die PPTX‑Datei darstellt
using (Presentation presentation = new Presentation())
{
	// Instanzieren Sie die Presentation‑Klasse, die die PPTX‑Datei darstellt
	Presentation presentation = new Presentation();

	// Zugriff auf die erste Folie
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

	// Diagrammdaten‑Arbeitsblatt abrufen
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Standardmäßig generierte Serien und Kategorien löschen
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

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) ein sekundäres Diagramm für Tortendiagramme, einschließlich der Typen 'Pie of Pie' und 'Bar of Pie'.

**Kann ich das Diagramm allein als Bild exportieren (zum Beispiel PNG)?**

Ja, Sie können das Diagramm selbst [als Bild exportieren](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (z. B. PNG), ohne die gesamte Präsentation.