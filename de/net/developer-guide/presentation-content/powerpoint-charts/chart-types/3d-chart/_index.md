---
title: 3D Diagramm
type: docs
url: /de/net/3d-chart/
keywords: "3d diagramm, rotationX, rotationY, tiefenprozentsatz, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Setzen Sie rotationX, rotationY und tiefenprozentsätze für 3D-Diagramm in PowerPoint-Präsentation in C# oder .NET"
---

## **Setzen von RotationX, RotationY und Tiefenprozentsätzen für 3D-Diagramm**
Aspose.Slides für .NET bietet eine einfache API zum Setzen dieser Eigenschaften. Der folgende Artikel hilft Ihnen, verschiedene Eigenschaften wie X, Y-Rotation, **Tiefenprozentsätze** usw. festzulegen. Der Beispielcode zeigt, wie Sie die oben genannten Eigenschaften festlegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie die Rotation3D-Eigenschaften.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```c#
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();
           
// Greifen Sie auf die erste Folie zu
ISlide slide = presentation.Slides[0];

// Fügen Sie ein Diagramm mit Standarddaten hinzu
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Setzen des Index des Diagrammdatenblatts
int defaultWorksheetIndex = 0;

// Abrufen des Diagrammdatenarbeitsbuchs
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Serien hinzufügen
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.Type);

// Kategorien hinzufügen
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Kategorie 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Kategorie 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Kategorie 3"));

// Setzen der Rotation3D-Eigenschaften
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Nehmen Sie die zweite Diagrammserie
IChartSeries series = chart.ChartData.Series[1];

// Jetzt populieren der Seriendaten
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Setzen Sie den OverLap-Wert
series.ParentSeriesGroup.Overlap = 100;         

// Schreiben der Präsentation auf die Festplatte
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```