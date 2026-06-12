---
title: Foutbalken aanpassen in presentatiediagrammen met PHP
linktitle: Foutbalk
type: docs
url: /nl/php-java/error-bar/
keywords:
- foutbalk
- aangepaste waarde
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe je foutbalken kunt toevoegen en aanpassen in diagrammen met Aspose.Slides voor PHP via Java — optimaliseer dataweergaven in PowerPoint-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe je foutbalken in presentatiediagrammen kunt gebruiken met Aspose.Slides. Het laat zien hoe je foutbalken aan een diagramreeks toevoegt, X- en Y-foutbalkinstellingen configureert, en verschillende waardetypen toepast zoals vast, percentage en aangepaste waarden.

Het toont ook hoe je aangepaste foutbalkwaarden toewijst aan individuele datapunten in een reeks via de bijbehorende datapuntencollectie. Daarnaast bevat het artikel korte notities over hoe foutbalken zich gedragen tijdens export, hun compatibiliteit met markers en datalabels, en waar je de gerelateerde API-referentieklassen en enums kunt vinden.

## **Foutbalken toevoegen**
Aspose.Slides for PHP via Java biedt een eenvoudige API voor het beheren van foutbalkwaarden. De voorbeeldcode is van toepassing bij het gebruik van een aangepast waardetype. Om een waarde op te geven, gebruik je de **ErrorBarCustomValues** eigenschap van een specifiek datapunt in de [**data points**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriescollection/) collectie van reeksen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.
1. Voeg een bubbel-diagram toe op de gewenste dia.
1. Toegang tot de eerste diagramreeks en stel het X-formaat van de foutbalk in.
1. Toegang tot de eerste diagramreeks en stel het Y-formaat van de foutbalk in.
1. Instellen van balkwaarden en -formaat.
1. Schrijf de gewijzigde presentatie naar een PPTX-bestand.

```php
  # Maak een instantie van de Presentation-klasse
  $pres = new Presentation();
  try {
    # Maak een bubbel-diagram
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Foutbalken toevoegen en format instellen
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # Presentatie opslaan
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aangepaste foutbalkwaarden toevoegen**
Aspose.Slides for PHP via Java biedt een eenvoudige API voor het beheren van aangepaste foutbalkwaarden. De voorbeeldcode is van toepassing wanneer de [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/errorbarsformat/#getValueType) methode **Custom** retourneert. Om een waarde op te geven, gebruik je de **ErrorBarCustomValues** eigenschap van een specifiek datapunt in de [**data points**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriescollection/) collectie van reeksen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.
1. Voeg een bubbel-diagram toe op de gewenste dia.
1. Toegang tot de eerste diagramreeks en stel het X-formaat van de foutbalk in.
1. Toegang tot de eerste diagramreeks en stel het Y-formaat van de foutbalk in.
1. Toegang tot de individuele datapunten van de diagramreeks en stel de foutbalkwaarden in voor elk datapunt van de reeks.
1. Instellen van balkwaarden en -formaat.
1. Schrijf de gewijzigde presentatie naar een PPTX-bestand.

```php
  # Maak een instantie van de Presentation-klasse
  $pres = new Presentation();
  try {
    # Maak een bubbel-diagram
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Aangepaste foutbalken toevoegen en het formaat instellen
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Toegang tot datapunt van de diagramreeks en foutbalkwaarden instellen voor
    # individueel punt
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Foutbalken instellen voor punten van de diagramreeks
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Presentatie opslaan
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Wat gebeurt er met foutbalken bij het exporteren van een presentatie naar PDF of afbeeldingen?**

Ze worden gerenderd als onderdeel van het diagram en behouden tijdens de conversie samen met de rest van de diagramopmaak, ervan uitgaande dat er een compatibele versie of renderer wordt gebruikt.

**Kunnen foutbalken worden gecombineerd met markers en datalabels?**

Ja. Foutbalken zijn een apart element en zijn compatibel met markers en datalabels; als elementen overlappen, moet je mogelijk de opmaak aanpassen.

**Waar kan ik de lijst met eigenschappen en klassen vinden voor het werken met foutbalken in de API?**

In de API-referentie: de [ErrorBarsFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/errorbarsformat/) klasse en de gerelateerde klassen [ErrorBarType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/errorbartype/) en [ErrorBarValueType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/errorbarvaluetype/).