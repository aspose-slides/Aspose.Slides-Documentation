---
title: Foutbalken aanpassen in presentatiediagrammen in .NET
linktitle: Foutbalk
type: docs
url: /nl/net/error-bar/
keywords:
- foutbalk
- aangepaste waarde
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u foutbalken kunt toevoegen en aanpassen in diagrammen met Aspose.Slides voor .NET—optimaliseer gegevensvisualisaties in PowerPoint-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe je foutbalken in presentatiediagrammen kunt gebruiken met Aspose.Slides. Het toont hoe je foutbalken aan een diagramreeks kunt toevoegen, X‑ en Y‑foutbalkinstellingen kunt configureren en verschillende waarde‑typen kunt toepassen, zoals vaste, percentage‑ en aangepaste waarden.

Het laat ook zien hoe je aangepaste foutbalkwaarden kunt toewijzen aan individuele datapunten in een reeks via de bijbehorende datapunten‑collectie. Daarnaast bevat het artikel korte aantekeningen over hoe foutbalken zich gedragen tijdens export, hun compatibiliteit met markers en gegevenslabels, en waar je de gerelateerde API‑referentieklassen en enums kunt vinden.

## **Foutbalken toevoegen**
Aspose.Slides for .NET biedt een eenvoudige API voor het beheren van foutbalkwaarden. De voorbeeldcode is van toepassing bij het gebruik van een aangepast waardetype. Om een waarde op te geven, gebruik je de **ErrorBarCustomValues**‑eigenschap van een specifiek datapunt in de **DataPoints**‑collectie van de reeks:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
1. Voeg een bubbelgrafiek toe op de gewenste dia.
1. Toegang tot de eerste grafiekreeks en stel het X‑foutbalkformaat in.
1. Toegang tot de eerste grafiekreeks en stel het Y‑foutbalkformaat in.
1. Instellen van balkwaarden en -formaat.
1. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

```c#
// Lege presentatie maken
using (Presentation presentation = new Presentation())
{
    // Een bubbelgrafiek maken
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Foutbalken toevoegen en het formaat instellen
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // Presentatie opslaan
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Aangepaste foutbalkwaarden toevoegen**
Aspose.Slides for .NET biedt een eenvoudige API voor het beheren van aangepaste foutbalkwaarden. De voorbeeldcode is van toepassing wanneer de **IErrorBarsFormat.ValueType**‑eigenschap gelijk is aan **Custom**. Om een waarde op te geven, gebruik je de **ErrorBarCustomValues**‑eigenschap van een specifiek datapunt in de **DataPoints**‑collectie van de reeks:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
1. Voeg een bubbelgrafiek toe op de gewenste dia.
1. Toegang tot de eerste grafiekreeks en stel het X‑foutbalkformaat in.
1. Toegang tot de eerste grafiekreeks en stel het Y‑foutbalkformaat in.
1. Toegang tot de individuele datapunten van de grafiekreeks en stel de foutbalkwaarden in voor elk datapunt van de reeks.
1. Instellen van balkwaarden en -formaat.
1. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

```c#
// Lege presentatie maken
using (Presentation presentation = new Presentation())
{
    // Een bubbelgrafiek maken
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Aangepaste foutbalken toevoegen en het formaat instellen
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Toegang tot datapunten van de grafiekreeks en foutbalkwaarden instellen voor elk punt
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Foutbalken instellen voor punten van de grafiekreeks
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // Presentatie opslaan
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Wat gebeurt er met foutbalken bij het exporteren van een presentatie naar PDF of afbeeldingen?**

Ze worden gerenderd als onderdeel van het diagram en behouden tijdens de conversie, samen met de rest van de diagramopmaak, ervan uitgaande dat er een compatibele versie of renderer wordt gebruikt.

**Kunnen foutbalken worden gecombineerd met markers en gegevenslabels?**

Ja. Foutbalken zijn een los element en zijn compatibel met markers en gegevenslabels; overlappen de elementen, dan moet je mogelijk de opmaak aanpassen.

**Waar kan ik de lijst met eigenschappen en enums vinden voor het werken met foutbalken in de API?**

In de API‑referentie: de [ErrorBarsFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/errorbarsformat/)‑klasse en de verwante enums [ErrorBarType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/errorbartype/) en [ErrorBarValueType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/errorbarvaluetype/).