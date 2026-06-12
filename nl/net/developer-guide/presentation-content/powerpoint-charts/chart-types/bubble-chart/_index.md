---
title: Bubbeldiagrammen aanpassen in presentaties in .NET
linktitle: Bubbeldiagram
type: docs
url: /nl/net/bubble-chart/
keywords:
- bubbeldiagram
- bubbelgrootte
- grootteschaling
- grootte weergave
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak en pas krachtige bubbeldiagrammen aan in PowerPoint met Aspose.Slides voor .NET om uw gegevensvisualisatie eenvoudig te verbeteren."
---
## **Overzicht**

Dit artikel laat zien hoe je met bubbeldiagrammen werkt in Aspose.Slides. Het behandelt twee specifieke aanpassingsopties: het schalen van bubbelgroottes via de `BubbleSizeScale`‑eigenschap en het bepalen hoe bubbelgrootte‑waarden worden weergegeven via de `BubbleSizeRepresentation`‑eigenschap.

De voorbeelden demonstreren hoe je een bubbeldiagram maakt, de schaal van de grootte aanpast, en de weergave van de bubbelgrootte wijzigt naar breedte. Het artikel bevat tevens een korte FAQ‑sectie die verduidelijkt dat “Bubbels met 3‑D” wordt ondersteund, vermeldt dat praktische diagramlimieten afhankelijk zijn van prestaties en de doel‑PowerPoint‑versie, en uitlegt dat export het uiterlijk van het diagram behoudt via de Aspose.Slides‑renderengine.

## **Schaal van Bubbeldiagramgroottes**
Aspose.Slides for .NET biedt ondersteuning voor het schalen van bubbeldiagramgroottes. In Aspose.Slides for .NET **IChartSeries.BubbleSizeScale** en **IChartSeriesGroup.BubbleSizeScale**‑eigenschappen zijn toegevoegd. Hieronder staat een voorbeeld.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Gegevens weergeven als bubbeldiagramgroottes**
Eigenschap **BubbleSizeRepresentation** is toegevoegd aan de interfaces IChartSeries, IChartSeriesGroup en gerelateerde klassen. **BubbleSizeRepresentation** specificeert hoe de bubbelgrootte‑waarden worden weergegeven in het bubbeldiagram. Mogelijke waarden zijn: **BubbleSizeRepresentationType.Area** en **BubbleSizeRepresentationType.Width**. Dienovereenkomstig is de **BubbleSizeRepresentationType**‑enum toegevoegd om de mogelijke weergavemethoden voor bubbeldiagramgroottes te definiëren. Voorbeeldcode staat hieronder.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Wordt een "bubbeldiagram met 3-D effect" ondersteund, en hoe verschilt het van een regulier diagram?**

Ja. Er bestaat een apart diagramtype, “Bubble with 3-D”. Het past 3‑D‑styling toe op de bellen maar voegt geen extra as toe; de data blijven X‑Y‑S (grootte). Het type is beschikbaar in de [chart type](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/charttype/)‑enumeratie.

**Is er een limiet op het aantal series en punten in een bubbeldiagram?**

Er is geen harde limiet op API‑niveau; beperkingen worden bepaald door prestaties en de doel‑PowerPoint‑versie. Het wordt aanbevolen om het aantal punten redelijk te houden voor leesbaarheid en render‑snelheid.

**Hoe beïnvloedt export het uiterlijk van een bubbeldiagram (PDF, afbeeldingen)?**

Exporteren naar ondersteunde formaten behoudt het uiterlijk van het diagram; de weergave wordt uitgevoerd door de Aspose.Slides‑engine. Voor raster‑/vectorformaten gelden de algemene regels voor diagramgrafische weergave (resolutie, anti‑aliasing), dus kies een voldoende DPI voor afdrukken.