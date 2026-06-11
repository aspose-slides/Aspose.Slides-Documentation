---
title: Dostosuj legendy wykresów w prezentacjach przy użyciu PHP
linktitle: Legenda wykresu
type: docs
url: /pl/php-java/chart-legend/
keywords:
- legenda wykresu
- pozycja legendy
- rozmiar czcionki
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dostosuj legendy wykresów za pomocą Aspose.Slides for PHP via Java, aby zoptymalizować prezentacje PowerPoint z dopasowanym formatowaniem legendy."
---
## **Przegląd**

Aspose.Slides udostępnia opcje dostosowywania legend wykresów w prezentacjach PowerPoint. Ten artykuł pokazuje, jak ustawić położenie i rozmiar legendy, ustawić rozmiar czcionki dla całej legendy oraz zastosować formatowanie do pojedynczego wpisu legendy.

Opisuje także kilka powiązanych zachowań w sekcji FAQ, w tym użycie trybu bez nakładania, aby obszar wykresu zrobił miejsce dla legendy, umożliwienie długich etykiet legendy do zawijania lub używania podziałów wierszy oraz pozwolenie, aby formatowanie legendy dziedziczyło z motywu prezentacji, gdy nie zostaną zastosowane wyraźne ustawienia tekstu i wypełnienia.

## **Pozycjonowanie legendy**
Aby ustawić właściwości legendy, proszę wykonać następujące kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
- Pobierz odwołanie do slajdu.
- Dodaj wykres na slajdzie.
- Ustaw właściwości legendy.
- Zapisz prezentację jako plik PPTX.

W poniższym przykładzie ustawiliśmy położenie i rozmiar legendy wykresu.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation();
  try {
    # Pobierz odwołanie do slajdu
    $slide = $pres->getSlides()->get_Item(0);
    # Dodaj wykres skumulowanych kolumn na slajdzie
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Ustaw właściwości legendy
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Zapisz prezentację na dysk
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustaw rozmiar czcionki legendy**
Aspose.Slides for PHP via Java umożliwia programistom ustawienie rozmiaru czcionki legendy. Proszę wykonać następujące kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
- Utwórz domyślny wykres.
- Ustaw rozmiar czcionki.
- Ustaw minimalną wartość osi.
- Ustaw maksymalną wartość osi.
- Zapisz prezentację na dysku.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustaw rozmiar czcionki indywidualnego wpisu legendy**
Aspose.Slides for PHP via Java umożliwia programistom ustawienie rozmiaru czcionki indywidualnych wpisów legendy. Proszę wykonać następujące kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
- Utwórz domyślny wykres.
- Uzyskaj dostęp do wpisu legendy.
- Ustaw rozmiar czcionki.
- Ustaw minimalną wartość osi.
- Ustaw maksymalną wartość osi.
- Zapisz prezentację na dysku.

```php
  # Utwórz instancję klasy Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę włączyć legendę tak, aby wykres automatycznie przydzielał dla niej miejsce zamiast nakładać ją?**  
Tak. Użyj trybu bez nakładania ([setOverlay(false)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/legend/setoverlay/)); w tym przypadku obszar wykresu zostanie zmniejszony, aby pomieścić legendę.

**Czy mogę tworzyć etykiety legendy wielowierszowe?**  
Tak. Długie etykiety są automatycznie zawijane, gdy brakuje miejsca; wymuszone podziały wierszy są obsługiwane za pomocą znaków nowej linii w nazwie serii.

**Jak sprawić, aby legenda podążała za schematem kolorów motywu prezentacji?**  
Nie ustawiaj wyraźnych kolorów/wypełnień/czcionek dla legendy ani jej tekstu. Wtedy zostaną one odziedziczone z motywu i będą się prawidłowo aktualizować po zmianie projektu.