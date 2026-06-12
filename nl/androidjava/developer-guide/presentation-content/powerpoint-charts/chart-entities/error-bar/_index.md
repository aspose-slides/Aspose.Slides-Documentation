---
title: Foutbalken aanpassen in presentatiediagrammen op Android
linktitle: Foutbalk
type: docs
url: /nl/androidjava/error-bar/
keywords:
- foutbalk
- aangepaste waarde
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u foutbalken kunt toevoegen en aanpassen in diagrammen met Aspose.Slides voor Android via Java—optimaliseer de datavisualisaties in PowerPoint-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe je foutbalken in presentatiediagrammen kunt gebruiken met Aspose.Slides. Het toont hoe je foutbalken aan een diagramreeks toevoegt, de X- en Y-foutbalkinstellingen configureert en verschillende waardetypen toepast, zoals vast, percentage en aangepast.

Het laat ook zien hoe je aangepaste foutbalkwaarden toekent aan individuele gegevenspunten in een reeks via de bijbehorende verzameling gegevenspunten. Bovendien bevat het artikel korte opmerkingen over hoe foutbalken zich gedragen tijdens export, hun compatibiliteit met markeringen en gegevenslabels, en waar je de gerelateerde API‑referentieklassen en enumera­ties kunt vinden.

## **Foutbalken toevoegen**
Aspose.Slides for Android via Java biedt een eenvoudige API voor het beheren van foutbalkwaarden. De voorbeeldcode is van toepassing wanneer een aangepast waardetype wordt gebruikt. Om een waarde op te geven, gebruik je de **ErrorBarCustomValues**‑eigenschap van een specifiek gegevenspunt in de [**DataPoints**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartSeriesCollection)‑verzameling van een reeks:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
1. Voeg een bubbeldiagram toe op de gewenste dia.
1. Open de eerste diagramreeks en stel het X‑formaat van de foutbalk in.
1. Open de eerste diagramreeks en stel het Y‑formaat van de foutbalk in.
1. Stel de waarden en het formaat van de balken in.
1. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand.

```java
// Maak een instantie van de Presentation‑klasse
Presentation pres = new Presentation();
try {
    // Maak een bubbeldiagram
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Foutbalken toevoegen en het formaat instellen
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // Presentatie opslaan
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aangepaste foutbalkwaarden toevoegen**
Aspose.Slides for Android via Java biedt een eenvoudige API voor het beheren van aangepaste foutbalkwaarden. De voorbeeldcode is van toepassing wanneer de eigenschap [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) gelijk is aan **Custom**. Om een waarde op te geven, gebruik je de **ErrorBarCustomValues**‑eigenschap van een specifiek gegevenspunt in de [**DataPoints**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartSeriesCollection)‑verzameling van een reeks:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
1. Voeg een bubbeldiagram toe op de gewenste dia.
1. Open de eerste diagramreeks en stel het X‑formaat van de foutbalk in.
1. Open de eerste diagramreeks en stel het Y‑formaat van de foutbalk in.
1. Open de individuele gegevenspunten van de diagramreeks en stel de foutbalkwaarden in voor elk gegevenspunt.
1. Stel de waarden en het formaat van de balken in.
1. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Maak een bubbeldiagram
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Voeg aangepaste foutbalken toe en stel het formaat in
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Toegang tot gegevenspunt van diagramreeks en foutbalkwaarden instellen voor
    // individueel punt
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Foutbalken instellen voor gegevenspunten van diagramreeks
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Presentatie opslaan
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Wat gebeurt er met foutbalken bij het exporteren van een presentatie naar PDF of afbeeldingen?**

Ze worden gerenderd als onderdeel van het diagram en behouden hun opmaak tijdens de conversie, mits een compatibele versie of renderer wordt gebruikt.

**Kunnen foutbalken worden gecombineerd met markeringen en gegevenslabels?**

Ja. Foutbalken vormen een apart element en zijn compatibel met markeringen en gegevenslabels; overlappen de elementen, dan moet je mogelijk de opmaak aanpassen.

**Waar kan ik de lijst met eigenschappen en klassen vinden voor het werken met foutbalken in de API?**

In de API‑referentie: de [ErrorBarsFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/errorbarsformat/)‑klasse en de gerelateerde klassen [ErrorBarType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/errorbartype/) en [ErrorBarValueType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/errorbarvaluetype/).