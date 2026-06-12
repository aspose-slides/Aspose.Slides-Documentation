---
title: Bubbeldiagrammen aanpassen in presentaties met JavaScript
linktitle: Bubbeldiagram
type: docs
url: /nl/nodejs-java/bubble-chart/
keywords:
- bubbeldiagram
- bubbelgrootte
- grootte schalen
- grootte representatie
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak en pas krachtige bubbeldiagrammen aan in PowerPoint met JavaScript en Aspose.Slides voor Node.js via Java om uw gegevensvisualisatie eenvoudig te verbeteren."
---
## **Overzicht**

Dit artikel laat zien hoe u met bubbeldiagrammen in Aspose.Slides werkt. Het behandelt twee specifieke aanpassingsopties: het schalen van bubbelgroottes via de `setBubbleSizeScale`‑methode en het beheren hoe bubbelgrootte‑waarden worden weergegeven via de `setBubbleSizeRepresentation`‑methode.

De voorbeelden tonen hoe u een bubbeldiagram maakt, de schaal van de grootte aanpast en de bubbelgrootte‑representatie wijzigt naar breedte. Het artikel bevat ook een korte FAQ‑sectie die verduidelijkt dat het type “Bubble with 3‑D” wordt ondersteund, opmerkt dat praktische limieten van diagrammen afhankelijk zijn van de prestaties en de doel‑PowerPoint‑versie, en uitlegt dat export het uiterlijk van het diagram behoudt via de renderengine van Aspose.Slides.

## **Schaal van bubbeldiagramgroottes**
Aspose.Slides for Node.js via Java biedt ondersteuning voor het schalen van bubbeldiagramgroottes. In Aspose.Slides for Node.js via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) en [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) methoden zijn toegevoegd. Hieronder staat een voorbeeld.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gegevens weergeven als bubbeldiagramgroottes**
Methoden [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) en [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) zijn toegevoegd aan [ChartSeries](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartSeriesGroup)‑klassen en gerelateerde klassen. **BubbleSizeRepresentation** geeft aan hoe de bubbelgrootte‑waarden worden weergegeven in het bubbeldiagram. Mogelijke waarden zijn: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) en [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). Daarom is de enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/BubbleSizeRepresentationType) toegevoegd om de mogelijke manieren te specificeren om gegevens als bubbeldiagramgroottes weer te geven. Voorbeeldcode staat hieronder.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Wordt een “bubbeldiagram met 3‑D‑effect” ondersteund, en hoe verschilt het van een regulier diagram?**

Ja. Er is een apart diagramtype, “Bubble with 3‑D”. Het past 3‑D‑stijl toe op de bubbels, maar voegt geen extra as toe; de gegevens blijven X‑Y‑S (grootte). Het type is beschikbaar in de [grafiektype](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/)-enumeratie.

**Is er een limiet op het aantal series en punten in een bubbeldiagram?**

Er is geen harde limiet op API‑niveau; beperkingen worden bepaald door de prestaties en de doel‑PowerPoint‑versie. Het wordt aanbevolen het aantal punten redelijk te houden voor leesbaarheid en weergavesnelheid.

**Hoe beïnvloedt export het uiterlijk van een bubbeldiagram (PDF, afbeeldingen)?**

Exporteren naar ondersteunde formaten behoudt het uiterlijk van het diagram; de weergave wordt uitgevoerd door de Aspose.Slides‑engine. Voor raster‑/vectorformaten gelden algemene renderregels voor diagrammen (resolutie, anti‑aliasing), dus kies een voldoende DPI voor afdrukken.