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
- Plotoptionen
- Segmentfarbe
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie in .NET mit Aspose.Slides Tortendiagramme erstellen und anpassen, exportierbar nach PowerPoint, und so Ihr Daten-Storytelling in Sekunden verbessern."
---

## **Optionen für das zweite Diagramm bei Pie of Pie- und Bar of Pie-Diagrammen**
Aspose.Slides für .NET unterstützt jetzt Optionen für das zweite Diagramm bei Pie of Pie‑ oder Bar of Pie‑Diagrammen. In diesem Thema zeigen wir anhand eines Beispiels, wie diese Optionen mit Aspose.Slides festgelegt werden. Bitte folgen Sie den nachstehenden Schritten:

1. Instanziieren Sie ein Objekt der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Fügen Sie dem Folienblatt ein Diagramm hinzu.
1. Legen Sie die Optionen für das zweite Diagramm des Diagramms fest.
1. Speichern Sie die Präsentation auf dem Datenträger.

Im nachfolgenden Beispiel haben wir verschiedene Eigenschaften des Pie of Pie‑Diagramms festgelegt.
```c#
 // Erstelle eine Instanz der Presentation-Klasse
 Presentation presentation = new Presentation();

 // Diagramm zur Folie hinzufügen
 IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
      
 // Verschiedene Eigenschaften festlegen
 chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
 chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
 chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
 chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

 // Präsentation auf Datenträger speichern
 presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```


## **Automatische Farben für Torten‑Diagramm‑Segmente festlegen**
Aspose.Slides für .NET stellt eine einfache API zum Festlegen automatischer Farben für Pie‑Diagramm‑Folien bereit. Der Beispielcode wendet die oben genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der Klasse Presentation.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie den Diagrammtitel.
1. Stellen Sie die erste Reihe ein, um Werte anzuzeigen.
1. Legen Sie den Index des Diagrammdatenblatts fest.
1. Abrufen des Arbeitsblatts mit den Diagrammdaten.
1. Löschen Sie die standardmäßig generierten Reihen und Kategorien.
1. Fügen Sie neue Kategorien hinzu.
1. Fügen Sie neue Reihen hinzu.

Speichern Sie die geänderte Präsentation in einer PPTX‑Datei.
```c#
 // Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
	 // Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt
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

**Werden die 'Pie of Pie'‑ und 'Bar of Pie'‑Varianten unterstützt?**

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) ein sekundäres Diagramm für Tortendiagramme, einschließlich der Typen 'Pie of Pie' und 'Bar of Pie'.

**Kann ich das Diagramm allein als Bild (z. B. PNG) exportieren?**

Ja, Sie können das Diagramm selbst als Bild [exportieren](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (z. B. PNG), ohne die gesamte Präsentation.