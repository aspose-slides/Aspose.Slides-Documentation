---
title: Gegevenspunten aanpassen in Treemap- en Sunburst-grafieken met PHP
linktitle: Gegevenspunten in Treemap- en Sunburst-grafieken
type: docs
url: /nl/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap-grafiek
- sunburst-grafiek
- gegevenspunt
- labelkleur
- takkleur
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u gegevenspunten in treemap- en sunburst-grafieken kunt beheren met Aspose.Slides voor PHP via Java, compatibel met PowerPoint-formaten."
---
## **Introductie**

Naast andere soorten PowerPoint‑grafieken zijn er twee “hiërarchische” typen – **Treemap** en **Sunburst**‑grafiek (ook wel Sunburst‑grafiek, Sunburst‑diagram, Radiale grafiek, Radiale diagram of Meervoudige‑niveaus‑cirkeldiagram genoemd). Deze grafieken tonen hiërarchische gegevens georganiseerd als een boom – van bladeren tot de top van de tak. Bladeren worden gedefinieerd door de serie‑datapunten, en elk daaropvolgend genest groeperingsniveau wordt gedefinieerd door de overeenkomstige categorie. Aspose.Slides for PHP via Java maakt het mogelijk om datapunten van een Sunburst‑grafiek en een Treemap te formatteren.

Hier is een Sunburst‑grafiek, waarbij de gegevens in de kolom Series1 de bladknopen definiëren, terwijl de andere kolommen hiërarchische datapunten definiëren:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Laten we beginnen met het toevoegen van een nieuwe Sunburst‑grafiek aan de presentatie:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="Zie ook" %}} 
- [**Grafieken maken of bijwerken in PowerPoint‑presentaties met PHP**](/slides/nl/php-java/create-chart/)
{{% /alert %}}

Mocht er behoefte zijn om datapunten van de grafiek te formatteren, gebruik dan het volgende:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapointlevelsmanager/), 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapointlevel/) klassen 
en [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) methode 
bieden toegang tot het formatteren van datapunten van Treemap‑ en Sunburst‑grafieken. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapointlevelsmanager/)
wordt gebruikt voor toegang tot meervoudige‑niveau‑categorieën – het vertegenwoordigt de container van 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapointlevel/) objecten.
In wezen is het een wrapper voor 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartcategorylevelsmanager/) met
eigenschappen die specifiek zijn toegevoegd voor datapunten. 
De [**ChartDataPointLevel**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapointlevel/)‑klasse heeft
twee methoden: [**getFormat**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapointlevel/#getFormat) en 
[**getDataLabel**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapointlevel/#getLabel) die
toegang geven tot de bijbehorende instellingen.
## **Waarde van een datapunt tonen**
Waarde van datapunt “Leaf 4” tonen:

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Een datapunt‑label en kleur instellen**
Stel het datapunt‑label “Branch 1” in zodat de serienaam (“Series1”) wordt getoond in plaats van de categorienaam. Stel daarna de tekstkleur in op geel:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Kleur van een datapunt‑tak instellen**
Kleur van tak “Steam 4” wijzigen:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Kan ik de volgorde (sortering) van segmenten in Sunburst/Treemap wijzigen?**

Nee. PowerPoint sorteert segmenten automatisch (meestal op aflopende waarden, met de klok mee). Aspose.Slides spiegelt dit gedrag: je kunt de volgorde niet direct wijzigen; je bereikt dit door de gegevens vooraf te verwerken.

**Hoe beïnvloedt het presentatie‑thema de kleuren van segmenten en labels?**

Grafiek‑kleuren erven het [thema/palet](/slides/nl/php-java/presentation-theme/) van de presentatie tenzij je expliciet vullingen/lettertypen instelt. Voor consistente resultaten, vergrendel solide vullingen en tekstopmaak op de benodigde niveaus.

**Worden aangepaste takkleuren en labelinstellingen behouden bij export naar PDF/PNG?**

Ja. Bij het exporteren van de presentatie worden grafiek‑instellingen (vullingen, labels) behouden in de uitvoerformaten omdat Aspose.Slides rendert met de toegepaste formatering.

**Kan ik de daadwerkelijke coördinaten van een label/element berekenen voor een aangepaste overlay bovenop de grafiek?**

Ja. Nadat de grafiek‑indeling is gevalideerd, zijn de werkelijke *x*‑ en *y*‑coördinaten beschikbaar voor elementen (bijvoorbeeld een [DataLabel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabel/)), wat helpt bij precieze positionering van overlays.