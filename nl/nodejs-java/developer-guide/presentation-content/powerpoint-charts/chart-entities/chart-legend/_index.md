---
title: Grafieklegenden aanpassen in presentaties met JavaScript
linktitle: Grafieklegende
type: docs
url: /nl/nodejs-java/chart-legend/
keywords:
- grafieklegende
- legende positie
- lettergrootte
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Pas grafieklegendes aan met Aspose.Slides voor Node.js via Java om PowerPoint-presentaties te optimaliseren met op maat gemaakte legende-opmaak."
---
## **Overzicht**

Aspose.Slides for Node.js via Java biedt opties om grafieklidlegenden in PowerPoint‑presentaties aan te passen. Dit artikel laat zien hoe u een legende positioneert en van grootte wijzigt, de lettergrootte voor de hele legende instelt, een afzonderlijk legende‑item opmaakt, en geselecteerde items verbergt of herstelt.

De FAQ behandelt gerelateerde functionaliteiten, waaronder het reserveren van ruimte voor de legende, het weergeven van meerregelige labels en het overnemen van opmaak van het presentatie‑thema.

## **Legendepositionering**

Gebruik de [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/) en [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) methoden van de legende om de positie en grootte op te geven als breuken van de afmetingen van de grafiek.

Dit voorbeeld maakt een presentatie aan en voegt een gegroepeerde kolomgrafiek met standaardgegevens toe aan de eerste dia. Door de gewenste legende‑offsets en afmetingen te delen door de breedte en hoogte van de grafiek, worden ze omgezet naar relatieve waarden: de legende wordt 50 punten verschoven vanaf de linkerbovenhoek van de grafiek en krijgt een afmeting van 100 bij 100 punten.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Geef de positie en grootte van de legenda weer ten opzichte van de grafiek.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel de lettergrootte van een legende in**

Gebruik de [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) van de legende om toegang te krijgen tot de tekstopmaak en gebruik [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) om de lettergrootte in punten in te stellen.

Dit voorbeeld maakt een grafiek met standaardgegevens aan en stelt de legende‑tekst in op 20 punten. Het schakelt ook de automatische grenzen voor de verticale as uit en stelt het bereik in op -5 tot 10.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel de lettergrootte van een afzonderlijk legende‑item in**

Gebruik de collectie die wordt geretourneerd door de [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) methode van de legende om de opmaak van een specifiek item te benaderen. Item‑indices beginnen bij nul, dus index `1` verwijst naar het tweede item.

Dit voorbeeld maakt een gegroepeerde kolomgrafiek waarbij de standaardgegevens ten minste twee series bevatten. Het formatteert het tweede legende‑item met vet, cursief en blauwe tekst van 20 punten.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verberg afzonderlijke legende‑items**

Om een aanvullende serie uit de legende te verwijderen terwijl de gegevens zichtbaar blijven, roep [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) aan met `true` via [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/). Dit verbergt alleen het geselecteerde legende‑item; het verwijdert de serie of de gegevenspunten niet. Het aanroepen van [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) met `false` verbergt daarentegen de volledige legende.

Het onderstaande voorbeeld maakt een gegroepeerde kolomgrafiek met meerdere series met standaardgegevens. Het verbergt het legende‑item van de tweede serie (index `1`) en slaat de presentatie op. Vervolgens wordt het item hersteld door [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) aan te roepen met `false` en wordt een tweede kopie opgeslagen. De kolommen blijven in beide bestanden zichtbaar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // Herstel hetzelfde item zonder de grafiekgegevens te wijzigen.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De onderstaande vergelijking toont dezelfde grafiek met alle items zichtbaar en met het tweede item verborgen. De kolommen van de tweede serie blijven ongewijzigd.

![Vergelijking van een grafiek met alle legende‑items zichtbaar en met Serie 2 verborgen in de legende; alle kolommen blijven zichtbaar.](hide-legend-entry.png)

In kolom‑, staaf‑ en lijngrafieken identificeren legende‑items series. Voor cirkelgrafieken identificeren ze individuele gegevenspunten (segmenten), dus gebruik [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) op het geselecteerde segment. De API documenteert deze gegevenspunt‑methode voor de grafiektype `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` en `BarOfPie`. Ga er niet van uit dat hij van toepassing is op donutgrafieken, die niet in die lijst staan.

## **FAQ**

**Kan ik de grafiek laten ruimte reserveren voor de legende in plaats van deze te overlappen?**

Ja. Roep [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) aan met `false` om ruimte voor de legende te reserveren in plaats van deze te laten overlappen met het plotgebied.

**Kan ik meerregelige legende‑labels maken?**

Ja. Lange labels kunnen worden afgebroken wanneer de beschikbare breedte onvoldoende is. U kunt ook regeleinden gebruiken in seriesnamen om een regelbreuk te forceren.

**Hoe laat ik de legende de kleurenschema van het presentatie‑thema volgen?**

Laat de kleuren, vullingen en lettertypen van de legende oningesteld zodat deze de themavormgeving kan overnemen. Expliciete opmaak overschrijft de overeenkomstige thema‑instellingen.