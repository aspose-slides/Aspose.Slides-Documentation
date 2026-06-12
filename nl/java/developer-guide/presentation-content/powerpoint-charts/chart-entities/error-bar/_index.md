---
title: Foutbalken aanpassen in presentatiediagrammen met Java
linktitle: Foutbalk
type: docs
url: /nl/java/error-bar/
keywords:
- foutbalk
- aangepaste waarde
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u foutbalken kunt toevoegen en aanpassen in diagrammen met Aspose.Slides voor Java—optimaliseer gegevensvisualisaties in PowerPoint-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u met foutbalken in presentatiediagrammen kunt werken met behulp van Aspose.Slides. Het laat zien hoe u foutbalken aan een diagramreeks kunt toevoegen, de X‑ en Y‑foutbalkinstellingen kunt configureren, en verschillende waardetypen zoals vast, percentage en aangepaste waarden kunt toepassen.

Het toont ook hoe u aangepaste foutbalkwaarden kunt toewijzen aan afzonderlijke datapunten in een reeks door de bijbehorende datapuntenverzameling te gebruiken. Bovendien bevat het artikel korte notities over hoe foutbalken zich gedragen tijdens export, hun compatibiliteit met markeringen en gegevenslabels, en waar u de gerelateerde API‑referentieklassen en enumeraties kunt vinden.

## **Foutbalken toevoegen**
Aspose.Slides for Java biedt een eenvoudige API voor het beheren van foutbalkwaarden. De voorbeeldcode is van toepassing bij het gebruik van een aangepast waardetype. Om een waarde op te geven, gebruikt u de **ErrorBarCustomValues** eigenschap van een specifiek datapunt in de collectie [**DataPoints**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartSeriesCollection) van een reeks:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation).
1. Voeg een boldiagram toe op de gewenste dia.
1. Open de eerste diagramreeks en stel het X‑formaat van de foutbalk in.
1. Open de eerste diagramreeks en stel het Y‑formaat van de foutbalk in.
1. Stel de waarden en het formaat van de balken in.
1. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Een boldiagram maken
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
Aspose.Slides for Java biedt een eenvoudige API voor het beheren van aangepaste foutbalkwaarden. De voorbeeldcode is van toepassing wanneer de eigenschap [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IErrorBarsFormat#getValue--) gelijk is aan **Custom**. Om een waarde op te geven, gebruikt u de **ErrorBarCustomValues** eigenschap van een specifiek datapunt in de collectie [**DataPoints**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartSeriesCollection) van een reeks:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation).
1. Voeg een boldiagram toe op de gewenste dia.
1. Open de eerste diagramreeks en stel het X‑formaat van de foutbalk in.
1. Open de eerste diagramreeks en stel het Y‑formaat van de foutbalk in.
1. Open de individuele datapunten van de diagramreeks en stel de foutbalkwaarden in voor elk datapunt van de reeks.
1. Stel de waarden en het formaat van de balken in.
1. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Een boldiagram maken
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Aangepaste foutbalken toevoegen en het formaat instellen
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Toegang tot het datapunt van de diagramreeks en foutbalkwaarden instellen voor
    // individueel punt
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Foutbalken instellen voor punten van de diagramreeks
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

Ze worden weergegeven als onderdeel van het diagram en behouden tijdens de conversie samen met de rest van de diagramopmaak, ervan uitgaande dat er een compatibele versie of renderer wordt gebruikt.

**Kunnen foutbalken worden gecombineerd met markeringen en gegevenslabels?**

Ja. Foutbalken zijn een afzonderlijk element en zijn compatibel met markeringen en gegevenslabels; als de elementen overlappen, moet u mogelijk de opmaak aanpassen.

**Waar kan ik de lijst met eigenschappen en klassen vinden voor het werken met foutbalken in de API?**

In de API‑referentie: de klasse [ErrorBarsFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/errorbarsformat/) en de gerelateerde klassen [ErrorBarType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/errorbartype/) en [ErrorBarValueType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/errorbarvaluetype/).