---
title: Pas bubbeldiagrammen aan in presentaties op Android
linktitle: Bubbeldiagram
type: docs
url: /nl/androidjava/bubble-chart/
keywords:
- bubbeldiagram
- bubblegrootte
- schaalvergroting
- grootteweergave
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak en pas krachtige bubbeldiagrammen in PowerPoint aan met Aspose.Slides for Android via Java om uw gegevensvisualisatie gemakkelijk te verbeteren."
---
## **Overzicht**

Dit artikel laat zien hoe u met bubble‑grafieken in Aspose.Slides kunt werken. Het behandelt twee specifieke aanpassingsopties: het schalen van bubble‑groottes via de `setBubbleSizeScale`‑methode en het regelen hoe bubble‑groottewaarden worden weergegeven via de `setBubbleSizeRepresentation`‑methode.

De voorbeelden tonen hoe u een bubble‑grafiek maakt, de schaal van de grootte aanpast en de weergave van de bubble‑grootte overschakelt naar breedte. Het artikel bevat tevens een korte sectie met veelgestelde vragen die verduidelijkt dat het “Bubble met 3‑D” diagramtype wordt ondersteund, aangeeft dat praktische limieten van diagrammen afhangen van de prestaties en de doel‑PowerPoint‑versie, en uitlegt dat export de weergave van het diagram behoudt via de render‑engine van Aspose.Slides.

## **Grootte schalen van bubble‑grafiek**

Aspose.Slides for Android via Java biedt ondersteuning voor het schalen van bubble‑grafiekgroottes. In Aspose.Slides for Android via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) en [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) methoden zijn toegevoegd. Hieronder staat een voorbeeld.

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

## **Gegevens weergeven als bubble‑grafiekgroottes**
Methoden [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) en [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) zijn toegevoegd aan de interfaces [IChartSeries](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartSeries) en [IChartSeriesGroup](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartSeriesGroup) en aan verwante klassen. **BubbleSizeRepresentation** specificeert hoe de bubble‑groottewaarden worden weergegeven in de bubble‑grafiek. Mogelijke waarden zijn: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) en [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). Daarom is de enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/BubbleSizeRepresentationType) toegevoegd om de mogelijke manieren te specificeren waarop gegevens als bubble‑grafiekgroottes worden weergegeven. Voorbeeldcode staat hieronder.

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

## **Veelgestelde vragen**

**Wordt een “bubble‑grafiek met 3‑D‑effect” ondersteund, en hoe verschilt deze van een gewone?**

Ja. Er bestaat een apart diagramtype, “Bubble met 3‑D”. Het past 3‑D‑styling toe op de bubbles, maar voegt geen extra as toe; de gegevens blijven X‑Y‑S (grootte). Het type is beschikbaar in de [chart type](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/)‑klasse.

**Is er een limiet aan het aantal series en punten in een bubble‑grafiek?**

Er is geen harde limiet op API‑niveau; de beperkingen worden bepaald door de prestaties en de doel‑PowerPoint‑versie. Het wordt aanbevolen om het aantal punten redelijk te houden voor leesbaarheid en weergavesnelheid.

**Hoe beïnvloedt export de weergave van een bubble‑grafiek (PDF, afbeeldingen)?**

Exporteren naar ondersteunde formaten behoudt de weergave van het diagram; de weergave wordt uitgevoerd door de Aspose.Slides‑engine. Voor raster‑ en vectorformaten gelden algemene regels voor diagram‑grafische weergave (resolutie, anti‑aliasing), dus kies een voldoende DPI voor afdrukken.