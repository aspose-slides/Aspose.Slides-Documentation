---
title: Dostosowywanie wykresów pierścieniowych w prezentacjach przy użyciu PHP
linktitle: Wykres pierścieniowy
type: docs
weight: 30
url: /pl/php-java/doughnut-chart/
keywords:
- wykres pierścieniowy
- przerwa środkowa
- rozmiar dziury
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy pierścieniowe w Aspose.Slides dla PHP przy użyciu Java, obsługując formaty PowerPoint dla dynamicznych prezentacji."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresem pierścieniowym w Aspose.Slides, dodając wykres do slajdu, ustawiając rozmiar centralnej dziury oraz zapisując prezentację. Skupia się na metodzie `setDoughnutHoleSize` i demonstruje podstawowe kroki niezbędne do dostosowania tego typu wykresu w kodzie.

Zawiera również krótkie FAQ dotyczące powiązanych scenariuszy wykresów pierścieniowych, takich jak użycie wielu serii do tworzenia wielu pierścieni, praca z wykresami pierścieniowymi z wybuchem oraz eksport wykresu jako obrazu rastrowego lub SVG.

## **Określenie centralnej przerwy w wykresie pierścieniowym**

Aby określić rozmiar dziury w wykresie pierścieniowym, wykonaj poniższe kroki:

1. Utwórz obiekt [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation) .
2. Dodaj wykres pierścieniowy na slajdzie.
3. Określ rozmiar dziury w wykresie pierścieniowym.
4. Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy rozmiar dziury w wykresie pierścieniowym.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Zapisz prezentację na dysku
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę utworzyć wielopoziomowy wykres pierścieniowy z wieloma pierścieniami?**

Tak. Dodaj wiele serii do jednego wykresu pierścieniowego — każda seria staje się osobnym pierścieniem. Kolejność pierścieni jest określana przez kolejność serii w kolekcji.

**Czy obsługiwany jest wykres pierścieniowy „wybuchnięty” (oddzielone segmenty)?**

Tak. Istnieje typ wykresu Exploded Doughnut [chart type](https://reference.aspose.com/slides/pl/php-java/aspose.slides/charttype/) oraz właściwość eksplozji dla punktów danych; można oddzielić poszczególne segmenty.

**Jak mogę uzyskać obraz wykresu pierścieniowego (PNG/SVG) do raportu?**

Wykres jest kształtem; można go wyrenderować do [rastrowego obrazu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getImage) lub wyeksportować wykres jako [obraz SVG](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#writeAsSvg).