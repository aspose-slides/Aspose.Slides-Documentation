---
title: "Pas 3D-diagrammen aan in presentaties met PHP"
linktitle: "3D-diagram"
type: docs
url: /nl/php-java/3d-chart/
keywords:
- "3D-diagram"
- "rotatie"
- "diepte"
- "PowerPoint"
- "presentatie"
- "PHP"
- "Aspose.Slides"
description: "Leer hoe u 3D-diagrammen kunt maken en aanpassen in Aspose.Slides voor PHP via Java, met ondersteuning voor PPT- en PPTX-bestanden — verbeter vandaag nog uw presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u een 3D-diagram in Aspose.Slides kunt aanpassen door de `Rotation3D`-instellingen zoals `RotationX`, `RotationY`, `DepthPercents` en `RightAngleAxes` te configureren. Het doorloopt het maken van een presentatie, het toevoegen van een 3D-diagram met standaardgegevens, het toepassen van de vereiste 3D-weergave-instellingen en het opslaan van de gewijzigde presentatie als een PPTX-bestand.

## **Instellen van de eigenschappen RotationX, RotationY en DepthPercents van een 3D-diagram**
Aspose.Slides for PHP via Java biedt een eenvoudige API om deze eigenschappen in te stellen. Het volgende artikel helpt u bij het instellen van verschillende eigenschappen, zoals **X,Y-rotatie, DepthPercents** enzovoort. De voorbeeldencode past de hierboven genoemde eigenschappen toe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)-klasse.
1. Open de eerste dia.
1. Voeg een diagram toe met standaardgegevens.
1. Stel de Rotation3D-eigenschappen in.
1. Schrijf de gewijzigde presentatie naar een PPTX-bestand.

```php
  $pres = new Presentation();
  try {
    # Toegang tot eerste dia
    $slide = $pres->getSlides()->get_Item(0);
    # Voeg diagram toe met standaardgegevens
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # Instellen van de index van het diagramgegevensblad
    $defaultWorksheetIndex = 0;
    # Ophalen van het diagramgegevenswerkblad
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Voeg series toe
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Voeg categorieën toe
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Stel Rotation3D-eigenschappen in
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # Neem tweede diagramserie
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Nu gegevens voor de serie invullen
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Stel OverLap-waarde in
    $series->getParentSeriesGroup()->setOverlap(100);
    # Schrijf presentatie naar schijf
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Welke diagramtypen ondersteunen de 3D-modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D-varianten van kolomdiagrammen, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100% Stacked Column 3D, samen met gerelateerde 3D-typen die beschikbaar zijn via de [ChartType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/charttype/)-klasse. Voor een exacte, up-to-date lijst, bekijk de leden van [ChartType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/charttype/) in de API-referentie van uw geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D-diagram krijgen voor een rapport of het web?**

Ja. U kunt een diagram exporteren naar een afbeelding via de [chart API](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getImage) of [render de volledige dia](/slides/nl/php-java/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer u een pixel-perfect voorbeeld nodig heeft of het diagram wilt insluiten in documenten, dashboards of webpagina's zonder dat PowerPoint vereist is.

**Hoe presteert het bouwen en renderen van grote 3D-diagrammen?**

De prestaties hangen af van de hoeveelheid data en de visuele complexiteit. Voor optimale resultaten houdt u 3D-effecten tot een minimum, vermijdt u zware texturen op wanden en tekengebieden, beperkt u het aantal gegevenspunten per serie waar mogelijk, en rendert u naar een output met een geschikte grootte (resolutie en afmetingen) die overeenkomt met het beoogde scherm of de afdrukbehoeften.