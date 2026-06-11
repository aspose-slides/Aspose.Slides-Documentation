---
title: Diagram
type: docs
weight: 60
url: /sv/net/examples/elements/chart/
keywords:
- diagram
- lägg till diagram
- kom åt diagram
- ta bort diagram
- uppdatera diagram
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Behärska diagram med Aspose.Slides för .NET: skapa, formatera, binda data och exportera diagram i PPT, PPTX och ODP med C#-exempel."
---
Exempel på att lägga till, komma åt, ta bort och uppdatera olika diagramtyper med **Aspose.Slides for .NET**. Kodsnuttarna nedan demonstrerar grundläggande diagramoperationer.

## **Lägg till ett diagram**

Den här metoden lägger till ett enkelt områdesdiagram på den första bilden.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Lägg till ett enkelt områdesdiagram på den första bilden.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Kom åt ett diagram**

Efter att ha skapat ett diagram kan du hämta det via samlingen av former.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Åtkomst till det första diagrammet på bilden.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Ta bort ett diagram**

Följande kod tar bort ett diagram från en bild.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Ta bort diagrammet.
    slide.Shapes.Remove(chart);
}
```

## **Uppdatera diagramdata**

Du kan ändra diagramegenskaper, t.ex. titeln.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Ändra diagramtiteln.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```