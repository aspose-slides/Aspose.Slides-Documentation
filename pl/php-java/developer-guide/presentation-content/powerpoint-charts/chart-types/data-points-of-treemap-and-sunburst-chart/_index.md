---
title: Dostosowywanie punktów danych w wykresach Treemap i Sunburst przy użyciu PHP
linktitle: Punkty danych w wykresach Treemap i Sunburst
type: docs
url: /pl/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- wykres treemap
- wykres sunburst
- punkt danych
- kolor etykiety
- kolor gałęzi
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak zarządzać punktami danych w wykresach treemap i sunburst za pomocą Aspose.Slides dla PHP poprzez Java, zgodnie z formatami PowerPoint."
---
## **Wprowadzenie**

Oprócz innych typów wykresów PowerPoint istnieją dwa „hierarchiczne” typy – wykres **Treemap** i wykres **Sunburst** (znany również jako Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph lub Multi Level Pie Chart). Te wykresy wyświetlają dane hierarchiczne zorganizowane jako drzewo – od liści do góry gałęzi. Liście są definiowane przez punkty danych serii, a każdy kolejny poziom zagnieżdżonej grupy definiowany jest przez odpowiednią kategorię. Aspose.Slides for PHP via Java umożliwia formatowanie punktów danych wykresu Sunburst i Treemap.

Poniżej znajduje się wykres Sunburst, gdzie dane w kolumnie Series1 definiują węzły liścia, a pozostałe kolumny definiują hierarchiczne punkty danych:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Rozpocznijmy od dodania nowego wykresu Sunburst do prezentacji:

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

{{% alert color="primary" title="Zobacz także" %}} 
- [**Tworzenie lub aktualizacja wykresów prezentacji PowerPoint w PHP**](/slides/pl/php-java/create-chart/)
{{% /alert %}}

Jeśli istnieje potrzeba formatowania punktów danych wykresu, powinniśmy użyć następujących:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapointlevelsmanager/), 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapointlevel/) klasy 
oraz [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) metoda 
zapewniają dostęp do formatowania punktów danych wykresów Treemap i Sunburst. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapointlevelsmanager/)
służy do uzyskiwania dostępu do wielopoziomowych kategorii – reprezentuje kontener obiektów 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapointlevel/). 
W zasadzie jest to wrapper dla 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartcategorylevelsmanager/) z
dodanymi właściwościami specyficznymi dla punktów danych. 
Klasa [**ChartDataPointLevel**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapointlevel/) posiada
dwie metody: [**getFormat**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapointlevel/#getFormat) i 
[**getDataLabel**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapointlevel/#getLabel), które
zapewniają dostęp do odpowiednich ustawień.

## **Pokaż wartość punktu danych**
Pokaż wartość punktu danych "Leaf 4":

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Ustaw etykietę i kolor punktu danych**
Ustaw etykietę danych "Branch 1", aby wyświetlała nazwę serii ("Series1") zamiast nazwy kategorii. Następnie ustaw kolor tekstu na żółty:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Ustaw kolor gałęzi punktu danych**
Zmień kolor gałęzi "Steam 4":

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

**Czy mogę zmienić kolejność (sortowanie) segmentów w wykresie Sunburst/Treemap?**

Nie. PowerPoint sortuje segmenty automatycznie (zazwyczaj malejąco, zgodnie z ruchem wskazówek zegara). Aspose.Slides odzwierciedla to zachowanie: nie można bezpośrednio zmienić kolejności; osiąga się to poprzez wstępne przetwarzanie danych.

**Jak motyw prezentacji wpływa na kolory segmentów i etykiet?**

Kolory wykresu dziedziczą [motyw/palettę](/slides/pl/php-java/presentation-theme/) prezentacji, chyba że jawnie ustawisz wypełnienia/czcionki. Aby uzyskać spójne wyniki, zamknij wypełnienia stałe i formatowanie tekstu na wymaganych poziomach.

**Czy eksport do PDF/PNG zachowa niestandardowe kolory gałęzi i ustawienia etykiet?**

Tak. Podczas eksportu prezentacji ustawienia wykresu (wypełnienia, etykiety) są zachowywane w formatach wyjściowych, ponieważ Aspose.Slides renderuje je z zastosowanym formatowaniem.

**Czy mogę obliczyć rzeczywiste współrzędne etykiety/elementu w celu umieszczenia własnej nakładki nad wykresem?**

Tak. Po zwalidowaniu układu wykresu rzeczywiste *x* i *y* są dostępne dla elementów (na przykład dla [DataLabel](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datalabel/)), co pomaga w precyzyjnym pozycjonowaniu nakładek.