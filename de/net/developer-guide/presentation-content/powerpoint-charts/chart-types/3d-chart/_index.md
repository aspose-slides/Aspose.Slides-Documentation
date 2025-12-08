---
title: 3D Diagramm
type: docs
url: /de/net/3d-chart/
keywords: "3D-Diagramm, rotationX, rotationY, depthpercent, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "RotationX, rotationY und depthpercents für 3D-Diagramm in einer PowerPoint-Präsentation in C# oder .NET festlegen"
---

## **Setzen der Eigenschaften RotationX, RotationY und DepthPercents von 3D-Diagrammen**
Aspose.Slides for .NET bietet eine einfache API zum Festlegen dieser Eigenschaften. Der folgende Artikel zeigt, wie Sie verschiedene Eigenschaften wie X‑, Y‑Rotation, **DepthPercents** usw. einstellen können. Der Beispielcode demonstriert das Setzen der oben genannten Eigenschaften.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Setzen Sie die Rotation3D‑Eigenschaften.
5. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```c#
// Erstelle eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();
           
// Greife auf die erste Folie zu
ISlide slide = presentation.Slides[0];

// Füge ein Diagramm mit Standarddaten hinzu
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Setze den Index des Diagrammdatentabellenblatts
int defaultWorksheetIndex = 0;

// Hole das Diagrammdatentabellenblatt
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Füge Serie hinzu
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Füge Kategorien hinzu
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Setze Rotation3D-Eigenschaften
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Nimm die zweite Diagrammserie
IChartSeries series = chart.ChartData.Series[1];

// Jetzt werden die Seriendaten befüllt
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Setze Overlap-Wert
series.ParentSeriesGroup.Overlap = 100;         

// Schreibe die Präsentation auf die Festplatte
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, einschließlich Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, zusammen mit verwandten 3D‑Typen, die über die Aufzählung [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) verfügbar sind. Für eine genaue, aktuelle Liste prüfen Sie die Mitglieder von [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm über die [chart API](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) in ein Bild exportieren oder die gesamte Folie mit [render the entire slide](/slides/de/net/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG rendern. Dies ist nützlich, wenn Sie eine pixelgenaue Vorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne PowerPoint zu benötigen.

**Wie performant ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse sollten Sie 3D‑Effekte auf ein Minimum beschränken, schwere Texturen auf Wänden und Plot‑Flächen vermeiden, die Anzahl der Datenpunkte pro Serie nach Möglichkeit begrenzen und in einer passend dimensionierten Ausgabe (Auflösung und Abmessungen) rendern, die den Ziel‑Anzeige‑ oder Druckanforderungen entspricht.