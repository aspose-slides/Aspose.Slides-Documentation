---
title: Diagram
type: docs
weight: 60
url: /hu/net/examples/elements/chart/
keywords:
- diagram
- diagram hozzáadása
- diagram elérése
- diagram eltávolítása
- diagram frissítése
- kód példa
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Mesteri diagramok az Aspose.Slides for .NET segítségével: diagramok létrehozása, formázása, adatkötés és exportálás PPT, PPTX és ODP formátumban C# példákkal."
---
Példák különböző diagramtípusok hozzáadására, elérésére, eltávolítására és frissítésére a **Aspose.Slides for .NET** segítségével. Az alábbi kódrészletek alapvető diagramműveleteket mutatnak be.

## **Diagram hozzáadása**

Ez a metódus egy egyszerű területdiagramot ad hozzá az első diára.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Egyszerű területdiagram hozzáadása az első diára.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Diagram elérése**

Diagram létrehozása után a alakzatgyűjteményen keresztül hívhatja elő.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // A dián lévő első diagram elérése.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Diagram eltávolítása**

Az alábbi kód eltávolít egy diagramot a diáról.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // A diagram eltávolítása.
    slide.Shapes.Remove(chart);
}
```

## **Diagramadatok frissítése**

Módosíthatja a diagram tulajdonságait, például a címet.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // A diagram címének módosítása.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```