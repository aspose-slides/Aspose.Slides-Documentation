---
title: Animuj wykresy PowerPoint w PHP
linktitle: Animowane wykresy
type: docs
weight: 80
url: /pl/php-java/animated-charts/
keywords:
- wykres
- animowany wykres
- animacja wykresu
- seria wykresu
- kategoria wykresu
- element serii
- element kategorii
- dodaj efekt
- typ efektu
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Twórz oszałamiające animowane wykresy za pomocą Aspose.Slides for PHP via Java. Wzmacniaj prezentacje dynamicznymi wizualizacjami w plikach PPT i PPTX — rozpocznij już teraz."
---
## **Wprowadzenie**

Aspose.Slides for PHP via Java obsługuje animowanie elementów wykresu. **Series**, **Categories**, **Series Elements**, **Categories Elements** mogą być animowane metodą [Sequence::addEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sequence/#addEffect) oraz dwoma wyliczeniami [EffectChartMajorGroupingType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/EffectChartMajorGroupingType) i [EffectChartMinorGroupingType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/EffectChartMinorGroupingType).

## **Animacja serii wykresu**
If you want to animate a chart series, write the code according to the steps listed below:

1. Załaduj prezentację.
1. Uzyskaj referencję do obiektu wykresu.
1. Animuj serię.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy serię wykresu.

```php
  # Utwórz instancję klasy Presentation reprezentującej plik prezentacji
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Pobierz referencję do obiektu wykresu
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animuj serię
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Zapisz zmodyfikowaną prezentację na dysku
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animacja kategorii wykresu**
If you want to animate a chart series, write the code according to the steps listed below:

1. Załaduj prezentację.
1. Uzyskaj referencję do obiektu wykresu.
1. Animuj kategorię.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy kategorię wykresu.

```php
  # Utwórz instancję klasy Presentation reprezentującej plik prezentacji
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animacja elementu serii**
If you want to animate series elements, write the code according to the steps listed below:

1. Załaduj prezentację.
1. Uzyskaj referencję do obiektu wykresu.
1. Animuj elementy serii.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy elementy serii.

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Uzyskaj referencję do obiektu wykresu
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animuj elementy serii
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Zapisz plik prezentacji na dysku
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animacja elementu kategorii**
If you want to animate categories elements, write the code according to the steps listed below:

1. Załaduj prezentację.
1. Uzyskaj referencję do obiektu wykresu.
1. Animuj elementy kategorii.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy elementy kategorii.

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Uzyskaj referencję do obiektu wykresu
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animuj elementy kategorii
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Zapisz plik prezentacji na dysku
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy różne typy efektów (np. wejścia, podkreślenia, wyjścia) są obsługiwane dla wykresów tak jak dla zwykłych kształtów?**

Tak. Wykres jest traktowany jako kształt, więc obsługuje standardowe typy efektów animacji, w tym wejście, podkreślenie i wyjście, z pełną kontrolą poprzez oś czasu slajdu i sekwencje animacji.

**Czy mogę łączyć animację wykresu z przejściami slajdów?**

Tak. [Transitions](/slides/pl/php-java/slide-transition/) odnoszą się do slajdu, natomiast efekty animacji dotyczą obiektów na slajdzie. Można używać obu jednocześnie w tej samej prezentacji i kontrolować je niezależnie.

**Czy animacje wykresów są zachowywane przy zapisywaniu do formatu PPTX?**

Tak. Gdy [zapisujesz do PPTX](/slides/pl/php-java/save-presentation/), wszystkie efekty animacji i ich kolejność są zachowywane, ponieważ są częścią natywnego modelu animacji prezentacji.

**Czy mogę odczytać istniejące animacje wykresu z prezentacji i je zmodyfikować?**

Tak. API zapewnia dostęp do osi czasu slajdu, sekwencji i efektów, co umożliwia przeglądanie istniejących animacji wykresu i ich dostosowywanie bez konieczności tworzenia wszystkiego od nowa.

**Czy mogę wyprodukować wideo zawierające animacje wykresów przy użyciu Aspose.Slides?**

Tak. Możesz [eksportować prezentację do wideo](/slides/pl/php-java/convert-powerpoint-to-video/) zachowując animacje, konfigurować czasy i inne ustawienia eksportu, aby uzyskany klip odzwierciedlał animowane odtwarzanie.