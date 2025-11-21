---
title: 3D-Diagramme in Präsentationen in .NET anpassen
linktitle: 3D Diagramm
type: docs
url: /de/net/3d-chart/
keywords:
- 3D-Diagramm
- Rotation
- Tiefe
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie 3‑D‑Diagramme in Aspose.Slides für .NET erstellen und anpassen, mit Unterstützung für PPT‑ und PPTX‑Dateien – verbessern Sie noch heute Ihre Präsentationen."
---

## **Setzen Sie die Eigenschaften RotationX, RotationY und DepthPercents eines 3D-Diagramms**
Aspose.Slides für .NET bietet eine einfache API zum Festlegen dieser Eigenschaften. Der folgende Artikel zeigt Ihnen, wie Sie verschiedene Eigenschaften wie X‑, Y‑Rotation, **DepthPercents** usw. festlegen. Der Beispielcode demonstriert das Einstellen der oben genannten Eigenschaften.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie die Eigenschaften Rotation3D.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```c#
// Erstellen Sie eine Instanz der Klasse Presentation
Presentation presentation = new Presentation();
           
// Zugriff auf die erste Folie
ISlide slide = presentation.Slides[0];

// Diagramm mit Standarddaten hinzufügen
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Festlegen des Indexes des Diagrammdatenblatts
int defaultWorksheetIndex = 0;

// Abrufen des Diagrammdaten-Arbeitsblatts
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Serien hinzufügen
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Kategorien hinzufügen
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Rotation3D-Eigenschaften festlegen
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Zweite Diagrammserie auswählen
IChartSeries series = chart.ChartData.Series[1];

// Seriendaten jetzt befüllen
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Overlap-Wert festlegen
series.ParentSeriesGroup.Overlap = 100;         

// Präsentation auf Festplatte schreiben
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, einschließlich Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, sowie verwandte 3D‑Typen, die über die Aufzählung [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) bereitgestellt werden. Für eine genaue, aktuelle Auflistung prüfen Sie die Mitglieder von [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm über die [chart API](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) oder [die gesamte Folie rendern](/slides/de/net/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG exportieren. Dies ist nützlich, wenn Sie eine pixelgenaue Vorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne PowerPoint zu benötigen.

**Wie leistungsfähig ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse halten Sie 3D‑Effekte minimal, vermeiden Sie schwere Texturen an Wänden und Plot‑Bereichen, reduzieren Sie nach Möglichkeit die Anzahl der Datenpunkte pro Serie und rendern Sie in eine passend dimensionierte Ausgabe (Auflösung und Abmessungen), die den Anforderungen der Zielanzeige oder des Drucks entspricht.