---
title: Bubbelgrafieken aanpassen in presentaties met Java
linktitle: Bubbelgrafiek
type: docs
url: /nl/java/bubble-chart/
keywords:
- bubbelgrafiek
- bubbelgrootte
- grootteschaling
- grootteweergave
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Maak en pas krachtige bubbelgrafieken in PowerPoint aan met Aspose.Slides for Java om uw gegevensvisualisatie eenvoudig te verbeteren."
---
## **Overzicht**

Dit artikel toont hoe u met bubbelgrafieken in Aspose.Slides kunt werken. Het behandelt twee specifieke aanpassingsopties: het schalen van bubbelgroottes via de `setBubbleSizeScale`-methode en het regelen hoe bubbelgrootte‑waarden worden weergegeven via de `setBubbleSizeRepresentation`-methode.

De voorbeelden laten zien hoe u een bubbelgrafiek maakt, de schaal van de grootte aanpast en de weergave van de bubbelgrootte wijzigt naar breedte. Het artikel bevat ook een korte FAQ-sectie die verduidelijkt dat het type “Bubble with 3-D” wordt ondersteund, vermeldt dat praktische grafieklimieten afhankelijk zijn van de prestaties en de doel-PowerPoint-versie, en uitlegt dat export de weergave van de grafiek behoudt via de rendering-engine van Aspose.Slides.

## **Schaal van bubbelgrafiekgroottes**

Aspose.Slides for Java biedt ondersteuning voor het schalen van de grootte van bubbelgrafieken. In Aspose.Slides for Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) en [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) methoden zijn toegevoegd. Hieronder staat een voorbeeld.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gegevens weergeven als bubbelgrafiekgroottes**

Methoden [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) en [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) zijn toegevoegd aan de interfaces [IChartSeries](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartSeriesGroup) en de bijbehorende klassen. **BubbleSizeRepresentation** geeft aan hoe de bubbelgrootte-waarden worden weergegeven in de bubbelgrafiek. Mogelijke waarden zijn: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/BubbleSizeRepresentationType#Area) en [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/BubbleSizeRepresentationType#Width). Daarom is de enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/BubbleSizeRepresentationType) toegevoegd om de mogelijke manieren te specificeren om gegevens als bubbelgrafiekgroottes weer te geven. Voorbeeldcode staat hieronder.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Is een “bubble chart met 3-D effect” ondersteund, en hoe verschilt die van een gewone?**

Ja. Er is een apart grafiektype, “Bubble with 3-D”. Het past 3-D-styling toe op de bubbels, maar voegt geen extra as toe; de gegevens blijven X-Y-S (grootte). Het type is beschikbaar in de klasse [chart type](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/).

**Is er een limiet aan het aantal series en punten in een bubble chart?**

Er is geen harde limiet op API-niveau; beperkingen worden bepaald door de prestaties en de doel-PowerPoint-versie. Het wordt aanbevolen om het aantal punten redelijk te houden voor leesbaarheid en rendersnelheid.

**Hoe beïnvloedt export het uiterlijk van een bubble chart (PDF, afbeeldingen)?**

Exporteren naar ondersteunde formaten behoudt het uiterlijk van de grafiek; de weergave wordt uitgevoerd door de Aspose.Slides-engine. Voor raster-/vectorformaten gelden de algemene regels voor grafiek-rendering (resolutie, anti-aliasing), dus kies een voldoende DPI voor afdrukken.