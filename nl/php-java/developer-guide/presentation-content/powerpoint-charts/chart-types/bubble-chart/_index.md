---
title: Bubbeldiagrammen aanpassen in presentaties met PHP
linktitle: Bubbeldiagram
type: docs
url: /nl/php-java/bubble-chart/
keywords:
- bubbeldiagram
- bubbelformaat
- formaatschaling
- formaatrepresentatie
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Maak en pas krachtige bubbeldiagrammen in PowerPoint aan met Aspose.Slides for PHP via Java om uw gegevensvisualisatie eenvoudig te verbeteren."
---
## **Overzicht**

Dit artikel laat zien hoe u met bubbeldiagrammen in Aspose.Slides kunt werken. Het behandelt twee specifieke aanpassingsopties: het schalen van bubbelformaten via de `setBubbleSizeScale`‑methode en het bepalen hoe bubbelformaatwaarden worden weergegeven via de `setBubbleSizeRepresentation`‑methode.

De voorbeelden laten zien hoe u een bubbeldiagram maakt, de schaal van het formaat aanpast en de weergave van het bubbelformaat wijzigt naar breedte. Het artikel bevat tevens een korte FAQ‑sectie die verduidelijkt dat het type “Bubble with 3‑D” wordt ondersteund, opmerkt dat praktische limieten van diagrammen afhankelijk zijn van de prestaties en de doelformaat van PowerPoint, en uitlegt dat export de weergave van het diagram behoudt via de renderengine van Aspose.Slides.

## **Schaal van bubbelformaat**
Aspose.Slides voor PHP via Java biedt ondersteuning voor het schalen van bubbelformaten. In Aspose.Slides voor PHP via Java zijn de methoden [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/getbubblesizescale/), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) en [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) toegevoegd. Hieronder wordt een voorbeeld gegeven.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gegevens weergeven als bubbelformaten**
De methoden [setBubbleSizeRepresentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) en [getBubbleSizeRepresentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) zijn toegevoegd aan de klassen [ChartSeries](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/) en gerelateerde klassen. **BubbleSizeRepresentation** geeft aan hoe de bubbelformaatwaarden in het bubbeldiagram worden weergegeven. Mogelijke waarden zijn: [BubbleSizeRepresentationType::Area](https://reference.aspose.com/slides/nl/php-java/aspose.slides/BubbleSizeRepresentationType#Area) en [BubbleSizeRepresentationType::Width](https://reference.aspose.com/slides/nl/php-java/aspose.slides/BubbleSizeRepresentationType#Width). Volgens is de enumeratie [BubbleSizeRepresentationType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/BubbleSizeRepresentationType) toegevoegd om de mogelijke manieren te specificeren om gegevens weer te geven als bubbelformaatgroottes. Hieronder staat voorbeeldcode.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Is een “bubble chart with 3‑D effect” ondersteund, en hoe verschilt deze van een reguliere?**

Ja. Er bestaat een apart diagramtype, “Bubble with 3‑D”. Het past 3‑D‑styling toe op de bubbels maar voegt geen extra as toe; de gegevens blijven X‑Y‑S (grootte). Het type is beschikbaar in de klasse [chart type](https://reference.aspose.com/slides/nl/php-java/aspose.slides/charttype/).

**Is er een limiet voor het aantal series en punten in een bubbeldiagram?**

Er is geen harde limiet op API‑niveau; beperkingen worden bepaald door prestaties en de doelformaat van PowerPoint. Het wordt aanbevolen om het aantal punten redelijk te houden voor leesbaarheid en renderingssnelheid.

**Hoe beïnvloedt export de weergave van een bubbeldiagram (PDF, afbeeldingen)?**

Export naar ondersteunde formaten behoudt de weergave van het diagram; de weergave wordt uitgevoerd door de Aspose.Slides‑engine. Voor raster‑/vectorformaten gelden de algemene regels voor diagramgrafische weergave (resolutie, anti‑aliasing), dus kies een voldoende DPI voor afdrukken.