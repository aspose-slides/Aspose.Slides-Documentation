---
title: Beheer grafiekgegevensmarkeringen in presentaties met PHP
linktitle: Gegevensmarkering
type: docs
url: /nl/php-java/chart-data-marker/
keywords:
- grafiek
- gegevenspunt
- markering
- markeringopties
- markeringgrootte
- vultype
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u grafiekgegevensmarkeringen in Aspose.Slides voor PHP kunt aanpassen, waardoor de impact van presentaties in PPT- en PPTX-formaten wordt vergroot met duidelijke codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u met gegevensmarkeringen in grafieken kunt werken in Aspose.Slides. Het laat zien hoe u een grafiek maakt, een serie en de gegevenspunten ervan benadert, afbeeldingvullingen toepast op markeringen op het niveau van gegevenspunten, de grootte van de markering aanpast en de bijgewerkte presentatie opslaat. Daarnaast wordt opgemerkt dat standaardmarkeringvormen beschikbaar zijn via de `MarkerStyleType`‑enumeratie en dat de weergave van markeringen behouden blijft bij het exporteren van grafieken naar rasterformaten of SVG.

## **Instellen van grafiekmarkeropties**
De markeringen kunnen worden ingesteld op grafiek‑gegevenspunten binnen een bepaalde serie. Om grafiekmarkeropties in te stellen, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse.
- Maak de standaardgrafiek aan.
- Stel de afbeelding in.
- Neem de eerste grafiekserie.
- Voeg een nieuw gegevenspunt toe.
- Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we de grafiekmarkeropties op het niveau van gegevenspunten ingesteld.

```php
  # Lege presentatie maken
  $pres = new Presentation();
  try {
    # Eerste dia benaderen
    $slide = $pres->getSlides()->get_Item(0);
    # Standaardgrafiek maken
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Standaard werkbladindex voor grafiekgegevens ophalen
    $defaultWorksheetIndex = 0;
    # Werkblad voor grafiekgegevens ophalen
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Demo‑reeks verwijderen
    $chart->getChartData()->getSeries()->clear();
    # Nieuwe reeks toevoegen
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # Afbeelding 1 laden
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Afbeelding 2 laden
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Eerste grafiekreeks nemen
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Nieuw punt (1:3) daar toevoegen.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # Markering van grafiekreeks wijzigen
    $series->getMarker()->setSize(15);
    # Presentatie met grafiek opslaan
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Welke markeringvormen zijn standaard beschikbaar?**

Standaardvormen zijn beschikbaar (cirkel, vierkant, ruit, driehoek, enz.); de lijst wordt gedefinieerd door de [MarkerStyleType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markerstyletype/)‑klasse. Als u een niet‑standaardvorm nodig hebt, gebruikt u een markering met een afbeeldingvulling om aangepaste visuele elementen te emuleren.

**Worden markeringen behouden bij het exporteren van een grafiek naar een afbeelding of SVG?**

Ja. Bij het renderen van grafieken naar [rasterformaten](/slides/nl/php-java/convert-powerpoint-to-png/) of het opslaan van [vormen als SVG](/slides/nl/php-java/render-a-slide-as-an-svg-image/) behouden markeringen hun uiterlijk en instellingen, inclusief grootte, vulling en omtrek.