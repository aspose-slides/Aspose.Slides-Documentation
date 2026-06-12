---
title: Aangepaste datapunten in Treemap- en Sunburst-grafieken met JavaScript
linktitle: Datapunten in Treemap- en Sunburst-grafieken
type: docs
url: /nl/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap-grafiek
- sunburst-grafiek
- datapunt
- labelkleur
- takkleur
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u datapunten in treemap- en sunburst-grafieken kunt beheren met JavaScript en Aspose.Slides voor Node.js via Java, compatibel met PowerPoint-formaten."
---
## **Inleiding**

Naast andere soorten PowerPoint-grafieken zijn er twee “hiërarchische” typen – **Treemap** en **Sunburst**-grafiek (ook bekend als Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph of Multi Level Pie Chart). Deze grafieken tonen hiërarchische gegevens georganiseerd als een boom - van bladeren tot de top van de tak. Bladeren worden gedefinieerd door de reekspunten, en elk volgend genest groepsniveau wordt bepaald door de bijbehorende categorie. Aspose.Slides for Node.js via Java maakt het mogelijk om datapunten van Sunburst Chart en Treemap te formatteren in JavaScript.

Hier is een Sunburst-grafiek, waarbij de gegevens in de kolom Series1 de bladknooppunten definiëren, terwijl de andere kolommen hiërarchische datapunten definiëren:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Laten we beginnen met het toevoegen van een nieuwe Sunburst-grafiek aan de presentatie:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="See also" %}} 
- [**Maak of werk PowerPoint-presentatiegrafieken bij in JavaScript**](/slides/nl/nodejs-java/create-chart/)
{{% /alert %}}

Als er een behoefte is om datapunten van de grafiek te formatteren, moeten we het volgende gebruiken:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataPointLevel) classes 
en [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) methode 
bieden toegang tot het formatteren van datapunten van Treemap en Sunburst grafieken. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataPointLevelsManager)
wordt gebruikt voor het benaderen van meervoudige categorieën – het vertegenwoordigt de container van 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataPointLevel) objecten.
In feite is het een wrapper voor 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartCategoryLevelsManager) met
de eigenschappen die specifiek zijn toegevoegd voor datapunten. 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataPointLevel) klasse heeft
twee methoden: [**getFormat**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) en 
[**getDataLabel**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) die
toegang geven tot de corresponderende instellingen.

## **Waarde van datapunt weergeven**

Toon de waarde van datapunt "Leaf 4":

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Label en kleur van datapunt instellen**

Stel het datalabel van "Branch 1" in om de serienaam ("Series1") weer te geven in plaats van de categorienaam. Stel vervolgens de tekstkleur in op geel:

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Kleur van datapunt-tak instellen**

Verander de kleur van tak "Steam 4":

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Veelgestelde vragen**

**Kan ik de volgorde (sortering) van segmenten in Sunburst/Treemap wijzigen?**

Nee. PowerPoint sorteert segmenten automatisch (meestal op aflopende waarden, volgens de klok). Aspose.Slides spiegelt dit gedrag: je kunt de volgorde niet rechtstreeks wijzigen; je doet dit door de gegevens vooraf te verwerken.

**Hoe beïnvloedt het presentatiethema de kleuren van segmenten en labels?**

Grafiekkleuren erven het [theme/palette](/slides/nl/nodejs-java/presentation-theme/) van de presentatie, tenzij je expliciet opvullingen/lettertypen instelt. Voor consistente resultaten, vergrendel vaste opvullingen en tekstopmaak op de benodigde niveaus.

**Zal exporteren naar PDF/PNG aangepaste takkleuren en labelinstellingen behouden?**

Ja. Bij het exporteren van de presentatie blijven grafiekinstellingen (opvullingen, labels) behouden in de uitvoerformaten, omdat Aspose.Slides rendert met de toegepaste grafiekopmaak.

**Kan ik de werkelijke coördinaten van een label/element berekenen voor het plaatsen van een aangepaste overlay boven de grafiek?**

Ja. Nadat de lay-out van de grafiek is gevalideerd, zijn de daadwerkelijke X- en Y-waarden beschikbaar voor elementen (bijvoorbeeld een [DataLabel](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datalabel/)), wat helpt bij het nauwkeurig positioneren van overlays.