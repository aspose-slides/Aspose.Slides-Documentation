---
title: Diagramm
type: docs
weight: 60
url: /de/net/examples/elements/chart/
keywords:
- Diagrammbeispiel
- Diagramm hinzufügen
- Diagramm zugreifen
- Diagramm entfernen
- Diagramm aktualisieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen und Anpassen von Diagrammen in C# mit Aspose.Slides: Daten hinzufügen, Serien, Achsen und Beschriftungen formatieren, Typen ändern und exportieren – funktioniert mit PPT, PPTX und ODP."
---

Beispiele zum Hinzufügen, Zugreifen, Entfernen und Aktualisieren verschiedener Diagrammtypen mit **Aspose.Slides for .NET**. Die nachfolgenden Codeausschnitte demonstrieren grundlegende Diagrammoperationen.

## **Diagramm hinzufügen**

Diese Methode fügt der ersten Folie ein einfaches Flächendiagramm hinzu.
```csharp
static void Add_Chart()
{
    using var pres = new Presentation();

    // Füge ein einfaches Spaltendiagramm zur ersten Folie hinzu
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```


## **Zugriff auf ein Diagramm**

Nachdem Sie ein Diagramm erstellt haben, können Sie es über die Formsammlung abrufen.
```csharp
static void Access_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Zugriff auf das erste Diagramm auf der Folie
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```


## **Diagramm entfernen**

Der folgende Code entfernt ein Diagramm von einer Folie.
```csharp
static void Remove_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Entferne das Diagramm
    slide.Shapes.Remove(chart);
}
```


## **Diagrammdaten aktualisieren**

Sie können Diagrammeigenschaften wie den Titel ändern.
```csharp
static void Update_Chart_Data()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Ändere den Diagrammtitel
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```
