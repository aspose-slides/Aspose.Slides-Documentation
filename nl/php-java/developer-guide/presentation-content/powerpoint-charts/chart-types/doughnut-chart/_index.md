---
title: Pas donutgrafieken aan in presentaties met PHP
linktitle: Donutgrafiek
type: docs
weight: 30
url: /nl/php-java/doughnut-chart/
keywords:
- donutgrafiek
- middengat
- gatgrootte
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek hoe u donutgrafieken kunt maken en aanpassen in Aspose.Slides voor PHP via Java, met ondersteuning voor PowerPoint-formaten voor dynamische presentaties."
---
## **Overzicht**

Dit artikel laat zien hoe u met een donutgrafiek in Aspose.Slides werkt door de grafiek aan een dia toe te voegen, de grootte van het centrale gat in te stellen en de presentatie op te slaan. Het richt zich op de `setDoughnutHoleSize`‑methode en demonstreert de basisstappen die nodig zijn om dit grafiektype in code aan te passen.

Het bevat ook een korte FAQ die gerelateerde donut‑grafiekscenario's behandelt, zoals het gebruik van meerdere series om meerdere ringen te creëren, werken met uitgeprinte donutgrafieken, en het exporteren van een grafiek als raster‑afbeelding of SVG.

## **Specificeer het middengat in een donutgrafiek**

Om de grootte van het gat in een donutgrafiek te specificeren, volg de onderstaande stappen:

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) object aan.
1. Voeg een donutgrafiek toe aan de dia.
1. Specificeer de grootte van het gat in een donutgrafiek.
1. Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we de grootte van het gat in een donutgrafiek ingesteld.

```php
  # Maak een instantie van de Presentation-klasse
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Schrijf de presentatie naar schijf
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan ik een meerlagige donut met meerdere ringen maken?**

Ja. Voeg meerdere series toe aan één donutgrafiek — elke serie wordt een afzonderlijke ring. De volgorde van de ringen wordt bepaald door de volgorde van de series in de collectie.

**Wordt een "exploded" donut (gescheiden segmenten) ondersteund?**

Ja. Er is een Exploded Doughnut [chart type](https://reference.aspose.com/slides/nl/php-java/aspose.slides/charttype/) en een explosie‑eigenschap op datapunten; u kunt individuele segmenten scheiden.

**Hoe kan ik een afbeelding van een donutgrafiek (PNG/SVG) voor een rapport krijgen?**

Een grafiek is een vorm; u kunt deze renderen naar een [raster image](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getImage) of de grafiek exporteren naar een [SVG image](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#writeAsSvg).