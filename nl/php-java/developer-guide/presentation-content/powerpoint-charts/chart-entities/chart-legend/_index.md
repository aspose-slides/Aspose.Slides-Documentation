---
title: Grafieklegenden aanpassen in presentaties met PHP
linktitle: Grafieklegende
type: docs
url: /nl/php-java/chart-legend/
keywords:
- grafieklegende
- legende positie
- lettergrootte
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Pas grafieklegenden aan met Aspose.Slides for PHP via Java om PowerPoint‑presentaties te optimaliseren met op maat gemaakte legende‑opmaak."
---
## **Overzicht**

Aspose.Slides for PHP via Java biedt opties om diagramlegenden in PowerPoint‑presentaties aan te passen. Dit artikel laat zien hoe je een legenda positioneert en van grootte wijzigt, de lettergrootte voor de gehele legenda instelt, een individuele legende‑item formatteert, en geselecteerde items verbergt of herstelt.

De FAQ behandelt gerelateerde gedragingen, waaronder het reserveren van ruimte voor de legenda, het weergeven van labels op meerdere regels, en het overnemen van opmaak vanuit het presentatiethema.

## **Positie van de Legenda**

Gebruik de [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/), en [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) methoden van de legenda om de positie en grootte op te geven als breuken van de afmetingen van het diagram.

Dit voorbeeld maakt een presentatie aan en voegt een gegroepeerde kolomgrafiek met standaardgegevens toe aan de eerste dia. Door de gewenste legenda‑offsets en -afmetingen te delen door de breedte en hoogte van het diagram, worden ze omgezet naar relatieve waarden: de legenda wordt 50 punten verschoven vanaf de linkerbovenhoek van het diagram en krijgt een grootte van 100 bij 100 punten. Het voorbeeld gebruikt java_values om de diagramafmetingen die door de PHP/Java Bridge worden geretourneerd, naar PHP‑getallen te converteren vóór de deling.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // Geef de positie en grootte van de legende weer relatief ten opzichte van het diagram.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lettergrootte van een Legenda Instellen**

Gebruik de [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) van de legenda om de tekstopmaak te benaderen en gebruik [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) om de lettergrootte in punten in te stellen.

Dit voorbeeld maakt een diagram met standaardgegevens en stelt de legenda‑tekst in op 20 punten. Het schakelt ook de automatische grenzen voor de verticale as uit en stelt het bereik in op -5 tot en met 10.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lettergrootte van een Individueel Legenda‑item Instellen**

Gebruik de collectie die wordt geretourneerd door de [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) methode van de legenda om de opmaak van een specifiek item te benaderen. Item‑indices beginnen bij nul, dus index `1` verwijst naar het tweede item.

Dit voorbeeld maakt een gegroepeerde kolomgrafiek waarvan de standaardgegevens minstens twee series bevatten. Het formatteert het tweede legende‑item met vet, cursief en blauwe tekst van 20 punten.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Individuele Legenda‑items Verbergen**

Om een aanvullende series uit de legenda te verwijderen terwijl de gegevens zichtbaar blijven, roep je [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) aan met `true` via [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/). Dit verbergt alleen het geselecteerde legende‑item; de serie of de datapoints worden niet verwijderd. In tegenstelling hiermee verbergt het aanroepen van [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) met `false` de volledige legenda.

Het voorbeeld hieronder maakt een gegroepeerde kolomgrafiek met meerdere series met standaardgegevens. Het verbergt het legende‑item van de tweede serie (index `1`) en slaat de presentatie op. Vervolgens herstelt het het item door [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) aan te roepen met `false` en slaat een tweede kopie op. De kolommen blijven in beide bestanden zichtbaar.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // Herstel hetzelfde item zonder de diagramgegevens te wijzigen.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De vergelijking hieronder toont hetzelfde diagram met alle items zichtbaar en met het tweede item verborgen. De kolommen van de tweede serie blijven ongewijzigd.

![Vergelijking van een diagram met alle legende‑items zichtbaar en met Serie 2 verborgen in de legenda; alle kolommen blijven zichtbaar.](hide-legend-entry.png)

In kolom‑, staaf‑ en lijndiagrammen identificeren legende‑items series. Voor cirkeldiagrammen identificeren ze individuele datapoints (partjes), dus gebruik je [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) op het geselecteerde partje. De API documenteert deze datapunt‑methode voor de diagramtypen `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` en `BarOfPie`. Ga niet ervan uit dat hij van toepassing is op donut‑diagrammen, die niet in die lijst staan.

## **FAQ**

**Kan ik het diagram ruimte laten reserveren voor de legenda in plaats van deze te overlappen?**

Ja. Roep [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) aan met `false` om ruimte voor de legenda te reserveren in plaats van toe te staan dat deze het plotgebied overlapt.

**Kan ik legenda‑labels op meerdere regels maken?**

Ja. Lange labels kunnen worden afgebroken wanneer de beschikbare breedte onvoldoende is. Je kunt ook regeleinde‑tekens gebruiken in seriesnamen om een nieuwe regel af te dwingen.

**Hoe zorg ik dat de legenda het kleurenpalet van het presentatiethema volgt?**

Laat de kleuren, vullingen en lettertypen van de legenda leeg, zodat hij de thematische opmaak kan overnemen. Expliciete opmaak overschrijft de bijbehorende themainstellingen.