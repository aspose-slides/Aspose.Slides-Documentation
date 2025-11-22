---
title: Diagramm-Datenmarker
type: docs
url: /de/net/chart-data-marker/
keywords:
- Diagramm-Markeroptionen
- PowerPoint
- Präsentation
- C#
- Csharp
- Aspose.Slides for .NET
description: "Diagramm-Markeroptionen in PowerPoint-Präsentationen in C# oder .NET festlegen"
---

## **Diagramm-Markeroptionen festlegen**
Die Marker können an Datenpunkten in bestimmten Serien des Diagramms festgelegt werden. Um Diagramm-Markeroptionen zu setzen, folgen Sie bitte den nachstehenden Schritten:

- Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
- Erstellen Sie das Standarddiagramm.
- Legen Sie das Bild fest.
- Nehmen Sie die erste Diagrammserie.
- Fügen Sie einen neuen Datenpunkt hinzu.
- Schreiben Sie die Präsentation auf die Festplatte.

Im nachstehenden Beispiel haben wir die Diagrammmarkeroptionen auf Datenpunktebene festgelegt.
```c#
// Erstelle eine Instanz der Presentation-Klasse
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Erstelle das Standarddiagramm
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Abrufen des Standard-Diagrammdaten-Arbeitsblatt-Index
int defaultWorksheetIndex = 0;

// Abrufen des Diagrammdaten-Arbeitsblatts
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Demo-Serien entfernen
chart.ChartData.Series.Clear();

// Neue Serie hinzufügen
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Bild festlegen
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Bild festlegen
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Erste Diagrammserie nehmen
IChartSeries series = chart.ChartData.Series[0];

// Neuen Punkt (1:3) dort hinzufügen.
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

// Diagrammserien-Marker ändern
series.Marker.Size = 15;

// Präsentation auf Festplatte speichern
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Welche Markerformen sind standardmäßig verfügbar?**

Standardformen sind verfügbar (Kreis, Quadrat, Raute, Dreieck usw.); die Liste wird durch die Aufzählung [MarkerStyleType](https://reference.aspose.com/slides/net/aspose.slides.charts/markerstyletype/) definiert. Wenn Sie eine nicht standardmäßige Form benötigen, verwenden Sie einen Marker mit Bildfüllung, um benutzerdefinierte Visuals zu emulieren.

**Werden Marker beim Export eines Diagramms in ein Bild oder SVG beibehalten?**

Ja. Beim Rendern von Diagrammen zu [raster formats](/slides/de/net/convert-powerpoint-to-png/) oder beim Speichern von [shapes as SVG](/slides/de/net/render-a-slide-as-an-svg-image/) behalten Marker ihr Aussehen und ihre Einstellungen bei, einschließlich Größe, Füllung und Kontur.