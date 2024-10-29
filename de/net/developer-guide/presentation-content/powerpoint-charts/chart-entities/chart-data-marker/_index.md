---
title: Diagrammdatenmarker
type: docs
url: /de/net/chart-data-marker/
keywords:
- Diagrammmarkeroptionen
- PowerPoint
- Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Setzen Sie Diagrammmarkeroptionen in PowerPoint-Präsentationen in C# oder .NET"
---

## **Diagrammmarkeroptionen festlegen**
Die Marker können an Diagrammdatenelementen innerhalb bestimmter Serien gesetzt werden. Um Diagrammmarkeroptionen festzulegen, befolgen Sie bitte die folgenden Schritte:

- Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
- Erstellen Sie das Standarddiagramm.
- Setzen Sie das Bild.
- Nehmen Sie die erste Diagrammserie.
- Fügen Sie einen neuen Datenpunkt hinzu.
- Schreiben Sie die Präsentation auf die Festplatte.

Im folgenden Beispiel haben wir die Diagrammmarkeroptionen auf Datenpunktebene festgelegt.

```c#
// Erstellen Sie eine Instanz der Presentation Klasse
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Erstellen des Standarddiagramms
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Abrufen des Index des Standarddiagrammdatenarbeitsblatts
int defaultWorksheetIndex = 0;

// Abrufen des Diagrammdatenarbeitsblatts
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Demo-Serie löschen
chart.ChartData.Series.Clear();

// Neue Serie hinzufügen
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.Type);

// Setzen Sie das Bild
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Setzen Sie das Bild
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Nehmen Sie die erste Diagrammserie
IChartSeries series = chart.ChartData.Series[0];

// Fügen Sie dort einen neuen Punkt (1:3) hinzu.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// Ändern des Diagrammserienmarkers
series.Marker.Size = 15;

// Schreiben Sie die Präsentation auf die Festplatte
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```