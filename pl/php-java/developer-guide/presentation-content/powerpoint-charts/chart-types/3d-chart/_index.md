---
title: Dostosuj wykresy 3D w prezentacjach przy użyciu PHP
linktitle: Wykres 3D
type: docs
url: /pl/php-java/3d-chart/
keywords:
- wykres 3D
- obrót
- głębokość
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy 3-D w Aspose.Slides dla PHP via Java, z obsługą plików PPT i PPTX — zwiększ jakość swoich prezentacji już dziś."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować wykres 3D w Aspose.Slides poprzez konfigurowanie ustawień `Rotation3D`, takich jak `RotationX`, `RotationY`, `DepthPercents` i `RightAngleAxes`. Przeprowadza przez tworzenie prezentacji, dodawanie wykresu 3D z domyślnymi danymi, zastosowanie wymaganych ustawień widoku 3D oraz zapis zmodyfikowanej prezentacji jako plik PPTX.

## **Ustaw właściwości RotationX, RotationY i DepthPercents wykresu 3D**

Aspose.Slides for PHP via Java udostępnia prosty interfejs API do ustawiania tych właściwości. Poniższy artykuł pomoże Ci ustawić różne właściwości, takie jak **Rotacja X, Y, DepthPercents** itp. Przykładowy kod stosuje ustawienie wymienionych wyżej właściwości.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Ustaw właściwości Rotation3D.
5. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```php
  $pres = new Presentation();
  try {
    # Uzyskaj dostęp do pierwszego slajdu
    $slide = $pres->getSlides()->get_Item(0);
    # Dodaj wykres z domyślnymi danymi
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # Ustawianie indeksu arkusza danych wykresu
    $defaultWorksheetIndex = 0;
    # Pobieranie arkusza danych wykresu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Dodaj serię
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Dodaj kategorie
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Ustaw właściwości Rotation3D
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # Pobierz drugą serię wykresu
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Teraz wypełniamy dane serii
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Ustaw wartość Overlap
    $series->getParentSeriesGroup()->setOverlap(100);
    # Zapisz prezentację na dysku
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Które typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje 3‑wymiarowe warianty wykresów słupkowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D oraz 100% Stacked Column 3D, a także powiązane typy 3D udostępnione poprzez klasę [ChartType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/charttype/). Aby uzyskać dokładną, aktualną listę, sprawdź członków [ChartType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/charttype/) w dokumentacji API swojej zainstalowanej wersji.

**Czy mogę uzyskać obraz rastrowy wykresu 3D do raportu lub sieci?**

Tak. Możesz wyeksportować wykres jako obraz przy użyciu [chart API](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getImage) lub [renderować cały slajd](/slides/pl/php-java/convert-powerpoint-to-png/) do formatów takich jak PNG czy JPEG. Jest to przydatne, gdy potrzebujesz podglądu pikselowo‑idealnego lub chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych lub stronach internetowych bez konieczności używania PowerPointa.

**Jak wydajna jest budowa i renderowanie dużych wykresów 3D?**

Wydajność zależy od objętości danych i złożoności wizualnej. Aby uzyskać najlepsze rezultaty, ogranicz efekty 3D do minimum, unikaj ciężkich tekstur na ścianach i obszarach wykresu, ogranicz liczbę punktów danych w serii, o ile to możliwe, oraz renderuj do odpowiednio dobranego rozmiaru wyjścia (rozdzielczość i wymiary), aby dopasować go do docelowego wyświetlacza lub potrzeb druku.