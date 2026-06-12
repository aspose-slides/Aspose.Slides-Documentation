---
title: Pas datapunten in Treemap- en Sunburst-grafieken aan met Java
linktitle: Datapunten in Treemap- en Sunburst-grafieken
type: docs
url: /nl/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap-grafiek
- sunburst-grafiek
- datapunt
- labelkleur
- tak-kleur
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u datapunten in treemap- en sunburst-grafieken kunt beheren met Aspose.Slides voor Java, compatibel met PowerPoint-formaten."
---
## **Inleiding**

Naast andere soorten PowerPoint‑grafieken zijn er twee “hiërarchische” typen – **Treemap**‑ en **Sunburst**‑grafiek (ook bekend als Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph of Multi Level Pie Chart). Deze grafieken tonen hiërarchische gegevens die als een boom zijn gestructureerd – van de bladeren tot de top van de tak. De bladeren worden gedefinieerd door de seriedatapunt‑waarden, en elk volgend genesteld groeperingsniveau wordt gedefinieerd door de bijbehorende categorie. Aspose.Slides for Java maakt het mogelijk om datapunten van Sunburst‑ en Treemap‑grafieken in Java te formatteren.

Hieronder staat een Sunburst‑grafiek, waarbij de gegevens in de kolom Series1 de blad‑knopen definiëren, terwijl de andere kolommen de hiërarchische datapunten definiëren:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Laten we beginnen met het toevoegen van een nieuwe Sunburst‑grafiek aan de presentatie:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="Zie ook" %}} 
- [**Maak of werk PowerPoint‑presentatiegrafieken bij in Java**](/slides/nl/java/create-chart/)
{{% /alert %}}

Als er behoefte is om datapunten van de grafiek te formatteren, moeten we het volgende gebruiken:

[**IChartDataPointLevelsManager**], [IChartDataPointLevel]‑klassen en [**IChartDataPoint.getDataPointLevels**]‑methode bieden toegang tot het formatteren van datapunten van Treemap‑ en Sunburst‑grafieken.  
[**IChartDataPointLevelsManager**] wordt gebruikt om multi‑level‑categorieën te benaderen – het vertegenwoordigt de container van [**IChartDataPointLevel**]‑objecten. In feite is het een wrapper voor [**IChartCategoryLevelsManager**] met de eigenschappen die specifiek zijn voor datapunten. De [**IChartDataPointLevel**]‑klasse heeft twee methoden: [**getFormat**] en [**getDataLabel**] die toegang geven tot de bijbehorende instellingen.

## **Toon een datapuntwaarde**

Toon de waarde van datapunt "Leaf 4":

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Stel een datapunt‑label en -kleur in**

Stel het datalabel van "Branch 1" in zodat de serienaam ("Series1") wordt weergegeven in plaats van de categorienaam. Stel vervolgens de tekstkleur in op geel:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Stel een tak‑kleur voor datapunt in**

Wijzig de kleur van tak "Steam 4":

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Kan ik de volgorde (sortering) van segmenten in Sunburst/Treemap wijzigen?**

Nee. PowerPoint sorteert segmenten automatisch (meestal op aflopende waarden, met de klok mee). Aspose.Slides spiegelt dit gedrag: je kunt de volgorde niet rechtstreeks wijzigen; dit moet gebeuren door de gegevens vooraf te verwerken.

**Hoe beïnvloedt het presentatiethema de kleuren van segmenten en labels?**

De kleuren van de grafiek erven het [thema/palet](/slides/nl/java/presentation-theme/) van de presentatie, tenzij je expliciet vullingen of lettertypen instelt. Voor consistente resultaten, gebruik vaste vullingen en tekstopmaak op de benodigde niveaus.

**Zal exporteren naar PDF/PNG aangepaste takkleuren en labelinstellingen behouden?**

Ja. Bij het exporteren van de presentatie worden de grafiekinstellingen (vullingen, labels) behouden in de uitvoerformaten, omdat Aspose.Slides rendert met de toegepaste opmaak van de grafiek.

**Kan ik de werkelijke coördinaten van een label/element berekenen voor aangepaste overlay‑plaatsing bovenop de grafiek?**

Ja. Nadat de grafieklay-out is gevalideerd, zijn de werkelijke *x*- en *y*-coördinaten beschikbaar voor elementen (bijvoorbeeld een [DataLabel]()), wat helpt bij het nauwkeurig positioneren van overlays.