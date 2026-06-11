---
title: Zarządzanie seriami danych wykresu w prezentacjach przy użyciu PHP
linktitle: Serie danych
type: docs
url: /pl/php-java/chart-series/
keywords:
- seria wykresu
- nakładanie serii
- kolor serii
- kolor kategorii
- nazwa serii
- punkt danych
- przerwa serii
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami danych wykresu w PHP dla PowerPoint (PPT/PPTX) z praktycznymi przykładami kodu i najlepszymi praktykami, aby ulepszyć swoje prezentacje danych."
---
## **Przegląd**

Ten artykuł opisuje rolę [ChartSeries](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/) w Aspose.Slides, koncentrując się na tym, jak dane są strukturyzowane i wizualizowane w prezentacjach. Obiekty te zapewniają podstawowe elementy definiujące indywidualne zestawy punktów danych, kategorie i parametry wyglądu wykresu. Pracując z [ChartSeries](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/), programiści mogą płynnie integrować źródła danych i zachować pełną kontrolę nad sposobem wyświetlania informacji, co skutkuje dynamicznymi, opartymi na danych prezentacjami, które jasno przekazują wnioski i analizy.

Seria to wiersz lub kolumna liczb wykreślona na wykresie.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ustaw nakładanie serii wykresu**

Za pomocą metody [getParentSeriesGroup](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/#getParentSeriesGroup) możesz określić, jak bardzo słupki i kolumny powinny się nachodzić na wykresie 2D (zakres: -100 do 100). Ta właściwość ma zastosowanie do wszystkich serii w grupie serii nadrzędnej: jest to projekcja odpowiedniej właściwości grupy. Dlatego ta właściwość jest tylko do odczytu. 

Użyj metody `ChartSeriesGroup::setOverlap`, aby ustawić preferowaną wartość dla `Overlap`. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Dodaj wykres słupkowy grupowany na slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu.
1. Uzyskaj dostęp do `ParentSeriesGroup` serii wykresu i ustaw preferowaną wartość nakładania dla serii. 
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Ten kod PHP pokazuje, jak ustawić nakładanie dla serii wykresu:

```php
  $pres = new Presentation();
  try {
    # Dodaje wykres
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Ustawia nakładanie serii
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # Zapisuje plik prezentacji na dysku
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zmień kolor serii**
Aspose.Slides for PHP via Java umożliwia zmianę koloru serii w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Dodaj wykres na slajdzie.
1. Uzyskaj dostęp do serii, której kolor chcesz zmienić. 
1. Ustaw preferowany typ wypełnienia i kolor wypełnienia.
1. Zapisz zmodyfikowaną prezentację.

Ten kod PHP pokazuje, jak zmienić kolor serii:

```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zmień kolor kategorii serii**
Aspose.Slides for PHP via Java umożliwia zmianę koloru kategorii serii w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Dodaj wykres na slajdzie.
1. Uzyskaj dostęp do kategorii serii, której kolor chcesz zmienić.
1. Ustaw preferowany typ wypełnienia i kolor wypełnienia.
1. Zapisz zmodyfikowaną prezentację.

Ten kod pokazuje, jak zmienić kolor kategorii serii:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zmień nazwę serii** 

Domyślnie nazwy w legendzie wykresu pochodzą z zawartości komórek powyżej każdej kolumny lub wiersza danych. 

W naszym przykładzie (obrazek przykładowy), 

* kolumny to *Series 1, Series 2,* i *Series 3*;
* wiersze to *Category 1, Category 2, Category 3,* i *Category 4.* 

Aspose.Slides for PHP via Java umożliwia aktualizację lub zmianę nazwy serii w danych wykresu oraz legendzie.

Ten kod PHP pokazuje, jak zmienić nazwę serii w danych wykresu `ChartDataWorkbook`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ten kod PHP pokazuje, jak zmienić nazwę serii w legendzie przy użyciu `Series`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustaw kolor wypełnienia serii wykresu**

Aspose.Slides for PHP via Java umożliwia ustawienie automatycznego koloru wypełnienia dla serii wykresu wewnątrz obszaru wykresu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Uzyskaj referencję do slajdu według jego indeksu.
1. Dodaj wykres z domyślnymi danymi na podstawie wybranego typu (w poniższym przykładzie użyliśmy `ChartType::ClusteredColumn`).
1. Uzyskaj dostęp do serii wykresu i ustaw kolor wypełnienia na Automatic.
1. Zapisz prezentację do pliku PPTX.

Ten kod PHP pokazuje, jak ustawić automatyczny kolor wypełnienia dla serii wykresu:

```php
  $pres = new Presentation();
  try {
    # Tworzy wykres słupkowy grupowany
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Ustawia format wypełnienia serii na automatyczny
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # Zapisuje plik prezentacji na dysku
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustaw odwrócony kolor wypełnienia dla serii wykresu**
Aspose.Slides umożliwia ustawienie odwróconego koloru wypełnienia dla serii wykresu wewnątrz obszaru wykresu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Uzyskaj referencję do slajdu według jego indeksu.
1. Dodaj wykres z domyślnymi danymi na podstawie wybranego typu (w poniższym przykładzie użyliśmy `ChartType::ClusteredColumn`).
1. Uzyskaj dostęp do serii wykresu i ustaw kolor wypełnienia na invert.
1. Zapisz prezentację do pliku PPTX.

Ten kod PHP demonstruje działanie:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Dodaje nowe serie i kategorie
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # Pobiera pierwszą serię wykresu i wypełnia jej dane.
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustaw serię na odwracanie, gdy wartość jest ujemna**
Aspose.Slides umożliwia ustawienie odwróceń poprzez właściwości `IChartDataPoint.InvertIfNegative` i `ChartDataPoint.InvertIfNegative`. Gdy odwrócenie jest ustawione za pomocą tych właściwości, punkt danych odwraca swoje kolory, gdy otrzyma wartość ujemną. 

Ten kod PHP demonstruje działanie:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Wyczyść dane konkretnego punktu**
Aspose.Slides for PHP via Java umożliwia wyczyszczenie danych `DataPoints` dla konkretnej serii wykresu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
2. Uzyskaj referencję do slajdu poprzez jego indeks.
3. Uzyskaj referencję do wykresu poprzez jego indeks.
4. Iteruj przez wszystkie `DataPoints` wykresu i ustaw `XValue` oraz `YValue` na null.
5. Wyczyść wszystkie`DataPoints` dla konkretnej serii wykresu.
6. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Ten kod PHP demonstruje działanie:

```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustaw szerokość przerwy serii**
Aspose.Slides for PHP via Java umożliwia ustawienie szerokości przerwy serii poprzez właściwość **`GapWidth`** w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z domyślnymi danymi.
1. Uzyskaj dostęp do dowolnej serii wykresu.
1. Ustaw właściwość `GapWidth`.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Ten kod pokazuje, jak ustawić szerokość przerwy serii:

```php
  # Tworzy pustą prezentację
  $pres = new Presentation();
  try {
    # Uzyskuje dostęp do pierwszego slajdu prezentacji
    $slide = $pres->getSlides()->get_Item(0);
    # Dodaje wykres z domyślnymi danymi
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Ustawia indeks arkusza danych wykresu
    $defaultWorksheetIndex = 0;
    # Pobiera arkusz danych wykresu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Dodaje serie
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Dodaje kategorie
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Pobiera drugą serię wykresu
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Wypełnia dane serii
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Ustawia wartość GapWidth
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Zapisuje prezentację na dysku
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy istnieje limit liczby serii, które może zawierać pojedynczy wykres?**

Aspose.Slides nie nakłada sztywnego limitu na liczbę dodawanych serii. Praktyczny limit zależy od czytelności wykresu oraz dostępnej pamięci w aplikacji.

**Co zrobić, jeśli kolumny w grupie są zbyt blisko siebie lub zbyt daleko od siebie?**

Dostosuj ustawienie `GapWidth` dla tej serii (lub jej grupy serii nadrzędnej). Zwiększenie wartości poszerza odstęp między kolumnami, natomiast zmniejszenie go zbliża kolumny do siebie.