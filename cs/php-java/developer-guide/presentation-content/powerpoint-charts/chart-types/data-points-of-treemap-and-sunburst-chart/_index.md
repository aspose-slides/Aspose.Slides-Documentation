---
title: Přizpůsobení datových bodů v grafech Treemap a Sunburst pomocí PHP
linktitle: Datové body v grafech Treemap a Sunburst
type: docs
url: /cs/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- graf treemap
- graf sunburst
- datový bod
- barva popisku
- barva větve
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Zjistěte, jak spravovat datové body v grafech treemap a sunburst pomocí Aspose.Slides pro PHP přes Java, kompatibilní s formáty PowerPoint."
---
## **Úvod**

Mezi ostatní typy grafů PowerPointu existují dva „hierarchické“ typy – **Treemap** a **Sunburst** graf (také známý jako Sunburst Graph, Sunburst Diagram, Radiální graf, Radiální diagram nebo Víceúrovňový koláčový graf). Tyto grafy zobrazují hierarchická data uspořádaná jako strom – od listů až po vrchol větve. Listy jsou definovány datovými body řady a každá následná vnořená úroveň skupiny je definována odpovídající kategorií. Aspose.Slides for PHP via Java umožňuje formátovat datové body Sunburst a Treemap grafů.

Zde je Sunburst graf, kde data ve sloupci Series1 definují listové uzly, zatímco ostatní sloupce definují hierarchické datové body:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Začneme přidáním nového Sunburst grafu do prezentace:

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

{{% alert color="primary" title="Viz také" %}} 
- [**Vytvořit nebo aktualizovat grafy PowerPoint prezentace v PHP**](/slides/cs/php-java/create-chart/)
{{% /alert %}}

Pokud je potřeba formátovat datové body grafu, měli bychom použít následující:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapointlevelsmanager/), 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapointlevel/) třídy 
a [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) metoda 
poskytují přístup k formátování datových bodů Treemap a Sunburst grafů. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapointlevelsmanager/)
se používá pro přístup k víceúrovňovým kategoriím – představuje kontejner pro 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapointlevel/) objekty.
V podstatě je to obal pro 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartcategorylevelsmanager/) s
vlastnostmi přidanými specificky pro datové body. 
Třída [**ChartDataPointLevel**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapointlevel/) má
dvě metody: [**getFormat**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapointlevel/#getFormat) a 
[**getDataLabel**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapointlevel/#getLabel), které
poskytují přístup k odpovídajícím nastavením.
## **Zobrazit hodnotu datového bodu**
Zobrazte hodnotu datového bodu „Leaf 4“:

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Nastavit popisek a barvu datového bodu**
Nastavte popisek „Branch 1“ tak, aby zobrazoval název řady („Series1“) místo názvu kategorie. Poté nastavte barvu textu na žlutou:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Nastavit barvu větve datového bodu**
Změňte barvu větve „Steam 4“:

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

## **Často kladené dotazy**

**Mohu změnit pořadí (seřazení) segmentů v Sunburst/Treemap?**

Ne. PowerPoint řadí segmenty automaticky (typicky sestupně, po směru hodinových ručiček). Aspose.Slides tuto funkci napodobuje: pořadí nelze změnit přímo; dosáhnete toho předzpracováním dat.

**Jak téma prezentace ovlivňuje barvy segmentů a popisků?**

Barvy grafu dědí [téma/palette](/slides/cs/php-java/presentation-theme/) prezentace, pokud výslovně nenastavíte výplně/písma. Pro konzistentní výsledky použijte pevné výplně a formátování textu na požadovaných úrovních.

**Zachová se při exportu do PDF/PNG vlastní barva větve a nastavení popisků?**

Ano. Při exportu prezentace jsou nastavení grafu (výplně, popisky) zachovány v výstupních formátech, protože Aspose.Slides renderuje s aplikovaným formátováním grafu.

**Mohu vypočítat skutečné souřadnice popisku/elementu pro vlastní překrytí nad grafem?**

Ano. Po ověření rozložení grafu jsou dostupné skutečné *x* a *y* souřadnice pro elementy (například [DataLabel](https://reference.aspose.com/slides/cs/php-java/aspose.slides/datalabel/)), což usnadňuje přesné umístění překrytí.