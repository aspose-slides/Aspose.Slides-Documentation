---
title: Diagramm
type: docs
weight: 60
url: /de/net/examples/elements/chart/
keywords:
- Diagramm
- Diagramm hinzufügen
- Diagramm abrufen
- Diagramm entfernen
- Diagramm aktualisieren
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Meistern Sie Diagramme mit Aspose.Slides für .NET: Erstellen, formatieren, Daten binden und Diagramme in PPT, PPTX und ODP exportieren – mit C#-Beispielen."
---
Beispiele zum Hinzufügen, Zugreifen, Entfernen und Aktualisieren verschiedener Diagrammtypen mit **Aspose.Slides for .NET**. Die nachstehenden Snippets demonstrieren grundlegende Diagrammoperationen.

## **Diagramm hinzufügen**

Diese Methode fügt dem ersten Folie ein einfaches Flächendiagramm hinzu.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Fügt der ersten Folie ein einfaches Flächendiagramm hinzu.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Diagramm abrufen**

Nachdem ein Diagramm erstellt wurde, können Sie es über die Formsammlung abrufen.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Greift auf das erste Diagramm auf der Folie zu.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Diagramm entfernen**

Der folgende Code entfernt ein Diagramm von einer Folie.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Entfernt das Diagramm.
    slide.Shapes.Remove(chart);
}
```

## **Diagrammdaten aktualisieren**

Sie können Diagrammeigenschaften wie den Titel ändern.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Ändert den Diagrammtitel.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```