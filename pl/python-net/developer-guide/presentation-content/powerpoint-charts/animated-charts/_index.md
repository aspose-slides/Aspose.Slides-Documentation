---
title: Animuj wykresy PowerPoint w Pythonie
linktitle: Animowane wykresy
type: docs
weight: 80
url: /pl/python-net/animated-charts/
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
- Python
- Aspose.Slides
description: "Twórz oszałamiające animowane wykresy w Pythonie przy użyciu Aspose.Slides. Wzmacniaj prezentacje dynamicznymi wizualizacjami w plikach PPT, PPTX i ODP — rozpocznij już teraz."
---
## **Wprowadzenie**

Aspose.Slides for Python via .NET obsługuje animowanie elementów wykresu. **Series**, **Categories**, **Series Elements**, **Categories Elements** mogą być animowane metodą [ISequence.add_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/isequence/) oraz dwoma wyliczeniami [EffectChartMajorGroupingType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effectchartmajorgroupingtype/) i [EffectChartMinorGroupingType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effectchartminorgroupingtype/).

## **Animacja serii wykresu**
Jeśli chcesz animować serię wykresu, napisz kod zgodnie z poniższymi krokami:

1. Wczytaj prezentację.
1. Uzyskaj odniesienie do obiektu wykresu.
1. Animuj serię.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy serię wykresu.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji 
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Uzyskaj odniesienie do obiektu wykresu
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animuj serię
    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectType.FADE, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectChartMajorGroupingType.BY_SERIES, 0, 
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 1,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 2,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 3,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Zapisz zmodyfikowaną prezentację na dysku 
    presentation.save("AnimatingSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animacja kategorii wykresu**
Jeśli chcesz animować kategorię wykresu, napisz kod zgodnie z poniższymi krokami:

1. Wczytaj prezentację.
1. Uzyskaj odniesienie do obiektu wykresu.
1. Animuj kategorię.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy kategorię wykresu.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Uzyskaj odniesienie do obiektu wykresu
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animuj elementy kategorii
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Zapisz plik prezentacji na dysku
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animacja elementu serii**
Jeśli chcesz animować elementy serii, napisz kod zgodnie z poniższymi krokami:

1. Wczytaj prezentację.
1. Uzyskaj odniesienie do obiektu wykresu.
1. Animuj elementy serii.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy elementy serii.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Wczytaj prezentację
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Uzyskaj odniesienie do obiektu wykresu
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animuj elementy serii
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Zapisz plik prezentacji na dysku 
    presentation.save("AnimatingSeriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animacja elementu kategorii**
Jeśli chcesz animować elementy kategorii, napisz kod zgodnie z poniższymi krokami:

1. Wczytaj prezentację.
1. Uzyskaj odniesienie do obiektu wykresu.
1. Animuj elementy kategorii.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy elementy kategorii.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Uzyskaj odniesienie do obiektu wykresu
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animuj elementy kategorii
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Zapisz plik prezentacji na dysku
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy różne typy efektów (np. wejścia, podkreślenia, wyjścia) są obsługiwane dla wykresów tak jak dla zwykłych kształtów?**

Tak. Wykres jest traktowany jako kształt, więc obsługuje standardowe typy efektów animacji, w tym wejście, podkreślenie i wyjście, z pełną kontrolą za pośrednictwem osi czasu slajdu i sekwencji animacji.

**Czy mogę łączyć animację wykresu z przejściami slajdów?**

Tak. [Transitions](/slides/pl/python-net/slide-transition/) dotyczą slajdu, natomiast efekty animacji dotyczą obiektów na slajdzie. Możesz używać obu jednocześnie w tej samej prezentacji i kontrolować je niezależnie.

**Czy animacje wykresu są zachowywane podczas zapisu do formatu PPTX?**

Tak. Kiedy [zapisujesz do PPTX](/slides/pl/python-net/save-presentation/), wszystkie efekty animacji i ich kolejność są zachowywane, ponieważ są częścią natywnego modelu animacji prezentacji.

**Czy mogę odczytać istniejące animacje wykresu z prezentacji i je zmodyfikować?**

Tak. [API](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/) zapewnia dostęp do osi czasu slajdu, sekwencji i efektów, co pozwala przeglądać istniejące animacje wykresów i dostosowywać je bez konieczności odtwarzania wszystkiego od początku.

**Czy mogę wyprodukować wideo zawierające animacje wykresu przy użyciu Aspose.Slides for Python via .NET?**

Tak. Możesz [wyeksportować prezentację do wideo](/slides/pl/python-net/convert-powerpoint-to-video/) zachowując animacje, konfigurować czasy i inne ustawienia eksportu, aby powstały klip odzwierciedlał odtwarzanie animacji.