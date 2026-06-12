---
title: Gegevenspunten aanpassen in Treemap- en Sunburst-grafieken op Android
linktitle: Gegevenspunten in Treemap- en Sunburst-grafieken
type: docs
url: /nl/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap-grafiek
- sunburst-grafiek
- gegevenspunt
- labelkleur
- takkleur
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u gegevenspunten in treemap- en sunburst-grafieken kunt beheren met Aspose.Slides for Android via Java, compatibel met PowerPoint-formaten."
---
## **Introductie**

Naast andere soorten PowerPoint‑grafieken bestaan er twee “hiërarchische” soorten – **Treemap** en **Sunburst**‑grafiek (ook bekend als Sunburst‑grafiek, Sunburst‑diagram, Radiale grafiek, Radiale diagram of Meerlagige taartgrafiek). Deze grafieken tonen hiërarchische gegevens die zijn georganiseerd als een boom – van bladeren tot de top van de tak. Bladeren worden gedefinieerd door de gegevenspunten van de reeks, en elk volgend genest groeppenniveau wordt bepaald door de bijbehorende categorie. Aspose.Slides for Android via Java maakt het mogelijk om gegevenspunten van Sunburst‑grafieken en Treemap in Java te formatteren.

Hier is een Sunburst‑grafiek, waarbij de gegevens in de kolom Series1 de bladknopen definiëren, terwijl andere kolommen hiërarchische gegevenspunten definiëren:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Laat ons beginnen met het toevoegen van een nieuwe Sunburst‑grafiek aan de presentatie:

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
- [**Maak of werk PowerPoint‑presentatie‑grafieken bij op Android**](/slides/nl/androidjava/create-chart/)
{{% /alert %}}

Als er behoefte is om gegevenspunten van de grafiek te formatteren, moeten we het volgende gebruiken:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataPointLevel) klassen 
en [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) methode 
bieden toegang tot het formatteren van gegevenspunten van Treemap‑ en Sunburst‑grafieken.  

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataPointLevelsManager) wordt gebruikt om toegang te krijgen tot meerlagige categorieën – het vertegenwoordigt de container van 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataPointLevel) objecten. In wezen is het een wrapper voor 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartCategoryLevelsManager) met de specifiek toegevoegde eigenschappen voor gegevenspunten.  
De klasse [**IChartDataPointLevel**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataPointLevel) heeft twee methoden: 
[**getFormat**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) en 
[**getDataLabel**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) die toegang bieden tot de bijbehorende instellingen.

## **Waarde van een Gegevenspunt**

Toon de waarde van gegevenspunt "Leaf 4":

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Gegevenspuntlabel en -kleur Instellen**

Stel het gegevenslabel van "Branch 1" in om de serienaam ("Series1") weer te geven in plaats van de categorienaam. Stel vervolgens de tekstkleur in op geel:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Kleur van een Gegevenspunt‑tak Instellen**

Verander de kleur van de tak "Steam 4":

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

## **Veelgestelde vragen**

**Kan ik de volgorde (sortering) van segmenten in Sunburst/Treemap wijzigen?**

Nee. PowerPoint sorteert segmenten automatisch (meestal op aflopende waarden, met de klok mee). Aspose.Slides spiegelt dit gedrag: je kunt de volgorde niet direct wijzigen; je bereikt dit door de gegevens vooraf te verwerken.

**Hoe beïnvloedt het presentatiethema de kleuren van segmenten en labels?**

Grafiekkleuren erven het [theme/palette](/slides/nl/androidjava/presentation-theme/) van de presentatie, tenzij je expliciet vullingen of lettertypen instelt. Voor consistente resultaten kun je vaste vullingen en tekstopmaak vergrendelen op de gewenste niveaus.

**Zal exporteren naar PDF/PNG aangepaste takkleuren en labelinstellingen behouden?**

Ja. Bij het exporteren van de presentatie worden de grafiekinstellingen (vullingen, labels) behouden in de uitvoerformaten omdat Aspose.Slides rendert met de toegepaste opmaak van de grafiek.

**Kan ik de werkelijke coördinaten van een label/element berekenen voor aangepaste overlayplaatsing bovenop de grafiek?**

Ja. Nadat de grafieklay-out is gevalideerd, zijn de werkelijke *x* en *y* beschikbaar voor elementen (bijvoorbeeld een [DataLabel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/datalabel/)), wat helpt bij de precieze positionering van overlays.