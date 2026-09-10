---
title: Animuj wykresy PowerPoint w Pythonie przy użyciu Java
linktitle: Animowane wykresy
type: docs
weight: 80
url: /pl/python-java/animated-charts/
keywords:
- wykres
- animowany wykres
- animacja wykresu
- serie wykresu
- kategoria wykresu
- element serii
- element kategorii
- dodaj efekt
- typ efektu
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Twórz oszałamiające animowane wykresy w Pythonie przy użyciu Java z Aspose.Slides. Zwiększ atrakcyjność prezentacji dzięki dynamicznym wizualizacjom w plikach PPT i PPTX — zacznij już teraz."
---
## **Wprowadzenie**

Aspose.Slides dla Pythona via Java obsługuje animowanie elementów wykresu. **Series**, **Categories**, **Series Elements** i **Category Elements** można animować przy użyciu metody [Sequence.addEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sequence/#addEffect) oraz dwóch wyliczeń: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effectchartmajorgroupingtype/) i [EffectChartMinorGroupingType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effectchartminorgroupingtype/).

## **Animacja serii wykresu**

Jeśli chcesz animować serię wykresu, napisz kod zgodnie z poniższymi krokami:

1. Wczytaj prezentację.
1. Pobierz odwołanie do obiektu wykresu.
1. Animuj serię.
1. Zapisz plik prezentacji na dysku.

Poniższy przykład animuje serie wykresu. Wykres w pliku przykładowym ma trzy serie, więc dla każdego indeksu od 0 do 2 dodawany jest jeden efekt. Aspose.Slides nie sprawdza indeksu względem danych wykresu, a efekt dodany dla nieistniejącej serii jest zapisywany w pliku, ale nie animuje niczego — zachowaj indeks mniejszy niż liczba serii w twoim własnym wykresie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Wczytaj prezentację.
presentation = Presentation("ExistingChart.pptx")
try:
    # Pobierz odwołanie do obiektu wykresu.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animuj elementy wykresu.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Zapisz zmodyfikowaną prezentację na dysku.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animacja kategorii wykresu**

Jeśli chcesz animować kategorię wykresu, napisz kod zgodnie z poniższymi krokami:

1. Wczytaj prezentację.
1. Pobierz odwołanie do obiektu wykresu.
1. Animuj kategorię.
1. Zapisz plik prezentacji na dysku.

Poniższy przykład animuje kategorie wykresu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Wczytaj prezentację.
presentation = Presentation("ExistingChart.pptx")
try:
    # Pobierz odwołanie do obiektu wykresu.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animuj elementy wykresu.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Zapisz zmodyfikowaną prezentację na dysku.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animacja w elemencie serii**

Jeśli chcesz animować elementy serii, napisz kod zgodnie z poniższymi krokami:

1. Wczytaj prezentację.
1. Pobierz odwołanie do obiektu wykresu.
1. Animuj elementy serii.
1. Zapisz plik prezentacji na dysku.

Poniższy przykład animuje elementy serii.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpapi.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Wczytaj prezentację.
presentation = Presentation("ExistingChart.pptx")
try:
    # Pobierz odwołanie do obiektu wykresu.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animuj elementy wykresu.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Zapisz zmodyfikowaną prezentację na dysku.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animacja w elemencie kategorii**

Jeśli chcesz animować elementy kategorii, napisz kod zgodnie z poniższymi krokami:

1. Wczytaj prezentację.
1. Pobierz odwołanie do obiektu wykresu.
1. Animuj elementy kategorii.
1. Zapisz plik prezentacji na dysku.

Poniższy przykład animuje elementy kategorii.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Wczytaj prezentację.
presentation = Presentation("ExistingChart.pptx")
try:
    # Pobierz odwołanie do obiektu wykresu.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animuj elementy wykresu.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Zapisz zmodyfikowaną prezentację na dysku.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy różne typy efektów (np. wejścia, uwydatnienia, wyjścia) są obsługiwane dla wykresów tak jak dla zwykłych kształtów?**

Tak. Wykres jest traktowany jako kształt, więc obsługuje standardowe typy efektów animacji, w tym wejścia, uwydatnienia i wyjścia, z pełną kontrolą poprzez oś czasu slajdu i sekwencje animacji.

**Czy mogę łączyć animację wykresu z przejściami slajdów?**

Tak. [Transitions](/slides/pl/python-java/slide-transition/) stosuje się do slajdu, natomiast efekty animacji dotyczą obiektów na slajdzie. Można używać obu jednocześnie w tej samej prezentacji i sterować nimi niezależnie.

**Czy animacje wykresów są zachowywane przy zapisywaniu do PPTX?**

Tak. Gdy [zapisujesz do PPTX](/slides/pl/python-java/save-presentation/), wszystkie efekty animacji i ich kolejność są zachowywane, ponieważ są częścią natywnego modelu animacji prezentacji.

**Czy mogę odczytać istniejące animacje wykresów z prezentacji i zmodyfikować je?**

Tak. API udostępnia dostęp do osi czasu slajdu, sekwencji i efektów, co pozwala przeglądać istniejące animacje wykresów i modyfikować je bez konieczności od nowa tworzyć wszystkie efekty.

**Czy mogę wygenerować wideo zawierające animacje wykresów przy użyciu Aspose.Slides?**

Tak. Możesz [wyeksportować prezentację do wideo](/slides/pl/python-java/convert-powerpoint-to-video/), zachowując animacje, konfigurując czasy i inne ustawienia eksportu, aby uzyskany klip odzwierciedlał animowane odtwarzanie.