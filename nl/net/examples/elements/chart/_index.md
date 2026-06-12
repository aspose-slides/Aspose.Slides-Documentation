---
title: Grafiek
type: docs
weight: 60
url: /nl/net/examples/elements/chart/
keywords:
- grafiek
- grafiek toevoegen
- grafiek benaderen
- grafiek verwijderen
- grafiek bijwerken
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer grafieken met Aspose.Slides voor .NET: maak, formatteer, koppel gegevens en exporteer grafieken in PPT, PPTX en ODP met C#-voorbeelden."
---
Voorbeelden voor het toevoegen, benaderen, verwijderen en bijwerken van verschillende grafiektype​n met **Aspose.Slides for .NET**. De onderstaande fragmenten tonen basisbewerkingen voor grafieken.

## **Grafiek toevoegen**

Deze methode voegt een eenvoudige gebiedsgrafiek toe aan de eerste dia.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Voeg een eenvoudige gebiedsgrafiek toe aan de eerste dia.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Grafiek benaderen**

Na het maken van een grafiek kun je deze ophalen via de vormverzameling.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Benader de eerste grafiek op de dia.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Grafiek verwijderen**

De volgende code verwijdert een grafiek van een dia.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Verwijder de grafiek.
    slide.Shapes.Remove(chart);
}
```

## **Grafiekgegevens bijwerken**

Je kunt grafiekeigenschappen zoals de titel aanpassen.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Wijzig de grafiektitel.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```