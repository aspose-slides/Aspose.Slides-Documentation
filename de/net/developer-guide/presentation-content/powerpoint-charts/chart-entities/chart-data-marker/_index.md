---
title: Diagrammdaten‑Marker in Präsentationen verwalten in .NET
linktitle: Datenmarker
type: docs
url: /de/net/chart-data-marker/
keywords:
- Diagramm
- Datenpunkt
- Marker
- Markeroptionen
- Markergröße
- Fülltyp
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramm‑Daten‑Marker in Aspose.Slides für .NET anpassen und die Wirkung von Präsentationen in PPT‑ und PPTX‑Formaten mit klaren C#‑Beispielcode steigern."
---

## **Diagramm-Markeroptionen festlegen**
Die Marker können an Diagrammdatenpunkten innerhalb bestimmter Reihen festgelegt werden. Um Diagramm-Markeroptionen zu setzen, befolgen Sie bitte die folgenden Schritte:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Erzeugen Sie das Standarddiagramm.
- Legen Sie das Bild fest.
- Nehmen Sie die erste Diagrammreihe.
- Fügen Sie einen neuen Datenpunkt hinzu.
- Schreiben Sie die Präsentation auf die Festplatte.

Im nachstehenden Beispiel haben wir die Diagramm-Markeroptionen auf Datenpunktebene festgelegt.
```c#
// Erstelle eine Instanz der Presentation-Klasse
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Erstelle das Standarddiagramm
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Hole den Index des Standard-Datenarbeitsblatts des Diagramms
int defaultWorksheetIndex = 0;

// Hole das Diagrammdaten-Arbeitsblatt
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Lösche Demo-Serie
chart.ChartData.Series.Clear();

// Füge neue Serie hinzu
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Setze das Bild
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Setze das Bild
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Nimm die erste Diagrammserie
IChartSeries series = chart.ChartData.Series[0];

// Füge dort einen neuen Punkt (1:3) hinzu.
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

// Ändere den Marker der Diagrammserie
series.Marker.Size = 15;

// Speichere die Präsentation auf die Festplatte
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Welche Markerformen stehen standardmäßig zur Verfügung?**

Standardformen sind verfügbar (Kreis, Quadrat, Raute, Dreieck usw.); die Liste wird durch die Aufzählung [MarkerStyleType](https://reference.aspose.com/slides/net/aspose.slides.charts/markerstyletype/) definiert. Wenn Sie eine nicht standardmäßige Form benötigen, verwenden Sie einen Marker mit Bildfüllung, um benutzerdefinierte Visualisierungen zu emulieren.

**Werden Marker beim Exportieren eines Diagramms in ein Bild oder SVG beibehalten?**

Ja. Beim Rendern von Diagrammen in [Rasterformate](/slides/de/net/convert-powerpoint-to-png/) oder beim Speichern von [Formen als SVG](/slides/de/net/render-a-slide-as-an-svg-image/) bleiben die Marker erhalten, einschließlich Größe, Füllung und Kontur.