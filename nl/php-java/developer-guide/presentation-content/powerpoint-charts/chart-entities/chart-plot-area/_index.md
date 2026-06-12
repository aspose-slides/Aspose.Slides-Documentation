---
title: Aanpassen van plotgebieden van presentatiediagrammen in PHP
linktitle: Plotgebied
type: docs
url: /nl/php-java/chart-plot-area/
keywords:
- diagram
- plotgebied
- breedte van plotgebied
- hoogte van plotgebied
- grootte van plotgebied
- lay-outmodus
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek hoe u plotgebieden van diagrammen in PowerPoint-presentaties kunt aanpassen met Aspose.Slides voor PHP via Java. Verbeter moeiteloos de visuele weergave van uw dia's."
---
## **Overzicht**

Dit artikel toont hoe u met het plotgebied van een diagram in Aspose.Slides werkt. Het legt uit hoe u de werkelijke positie en grootte van het plotgebied kunt verkrijgen door de diagramlay-out te valideren en vervolgens de X-, Y-, breedte‑ en hoogte‑waarden uit te lezen.

Het laat ook zien hoe u de lay‑outmodus van het plotgebied configureert wanneer de lay-out handmatig wordt ingesteld, waarbij `LayoutTargetType` wordt gebruikt om te bepalen of het plotgebied wordt berekend op basis van de binnenste regio of de buitenste regio, samen met assen en as‑labels.

## **Breedte en hoogte van een diagram‑plotgebied ophalen**
Aspose.Slides for PHP via Java biedt een eenvoudige API voor . 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.
1. Open de eerste dia.
1. Voeg een diagram toe met standaardgegevens.
1. Roep de methode [Chart.validateChartLayout](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/validatechartlayout/) aan om de werkelijke waarden te verkrijgen.
1. Haalt de werkelijke X‑locatie (links) van het diagram‑element op, relatief ten opzichte van de linkerbovenhoek van het diagram.
1. Haalt de werkelijke bovenkant van het diagram‑element op, relatief ten opzichte van de linkerbovenhoek van het diagram.
1. Haalt de werkelijke breedte van het diagram‑element op.
1. Haalt de werkelijke hoogte van het diagram‑element op.

```php
  # Maak een instantie van de Presentation-klasse
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lay‑outmodus van een diagram‑plotgebied instellen**
Aspose.Slides for PHP via Java biedt een eenvoudige API om de lay‑outmodus van het diagram‑plotgebied in te stellen. De methoden [**setLayoutTargetType**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) en [**getLayoutTargetType**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) zijn toegevoegd aan de klasse [**ChartPlotArea**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ChartPlotArea). Als de lay‑out van het plotgebied handmatig wordt gedefinieerd, geeft deze eigenschap aan of het plotgebied moet worden gelayout op basis van de binnenkant (exclusief assen en as‑labels) of de buitenkant (inclusief assen en as‑labels). Er zijn twee mogelijke waarden die zijn gedefinieerd in de enum [**LayoutTargetType**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/LayoutTargetType#Inner) - geeft aan dat de grootte van het plotgebied de grootte van het plotgebied bepaalt, exclusief de tic‑markeringen en as‑labels.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/LayoutTargetType#Outer) - geeft aan dat de grootte van het plotgebied de grootte van het plotgebied, de tic‑markeringen en de as‑labels bepaalt.

Voorbeeldcode wordt hieronder gegeven.

```php
  # Maak een instantie van de Presentation-klasse
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**In welke eenheden worden werkelijke x, werkelijke y, werkelijke breedte en werkelijke hoogte geretourneerd?**

In punten; 1 inch = 72 punten. Dit zijn de coördinaten‑eenheden van Aspose.Slides.

**Hoe verschilt het plotgebied van het diagramgebied qua inhoud?**

Het plotgebied is het tekengebied voor de data (reeksen, rasterlijnen, trendlijnen, enz.); het diagramgebied omvat de omliggende elementen (titel, legenda, enz.). Bij 3D‑diagrammen omvat het plotgebied ook de wanden/vloer en de assen.

**Hoe worden de x, y, breedte en hoogte van het plotgebied geïnterpreteerd wanneer de lay‑out handmatig is?**

Ze zijn fracties (0–1) van de totale grootte van het diagram; in deze modus is automatische positionering uitgeschakeld en worden de door u ingestelde fracties gebruikt.

**Waarom veranderde de positie van het plotgebied na het toevoegen/verplaatsen van de legenda?**

De legenda bevindt zich in het diagramgebied buiten het plotgebied, maar beïnvloedt de lay‑out en de beschikbare ruimte, waardoor het plotgebied kan verschuiven wanneer automatische positionering actief is. (Dit is het standaardgedrag van PowerPoint‑diagrammen.)