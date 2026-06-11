---
title: Animuj wykresy PowerPoint na Androidzie
linktitle: Animowane wykresy
type: docs
weight: 80
url: /pl/androidjava/animated-charts/
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
- Android
- Java
- Aspose.Slides
description: "Twórz zachwycające animowane wykresy w Javie z Aspose.Slides dla Androida. Zwiększ atrakcyjność prezentacji dzięki dynamicznym wizualizacjom w plikach PPT i PPTX - rozpocznij już teraz."
---
## **Wprowadzenie**

Aspose.Slides for Android via Java obsługuje animowanie elementów wykresu. **Series**, **Categories**, **Series Elements**, **Categories Elements** można animować za pomocą metody [ISequence.addEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) oraz dwóch wyliczeń [EffectChartMajorGroupingType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/EffectChartMajorGroupingType) i [EffectChartMinorGroupingType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/EffectChartMinorGroupingType).

## **Animacja serii wykresu**
Jeśli chcesz animować serię wykresu, napisz kod zgodnie z poniższymi krokami:

1. Załaduj prezentację.
1. Uzyskaj referencję do obiektu wykresu.
1. Animuj serię.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy serię wykresu.

```java
// Utwórz instancję klasy Presentation reprezentującej plik prezentacji
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Pobierz referencję do obiektu wykresu
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animuj serię
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Zapisz zmodyfikowaną prezentację na dysk
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animacja kategorii wykresu**
Jeśli chcesz animować kategorię wykresu, napisz kod zgodnie z poniższymi krokami:

1. Załaduj prezentację.
1. Uzyskaj referencję do obiektu wykresu.
1. Animuj kategorię.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy kategorię wykresu.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animacja elementu serii**
Jeśli chcesz animować elementy serii, napisz kod zgodnie z poniższymi krokami:

1. Załaduj prezentację.
1. Uzyskaj referencję do obiektu wykresu.
1. Animuj elementy serii.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy elementy serii.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Pobierz referencję do obiektu wykresu
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animuj elementy serii
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Zapisz plik prezentacji na dysk 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animacja elementu kategorii**
Jeśli chcesz animować elementy kategorii, napisz kod zgodnie z poniższymi krokami:

1. Załaduj prezentację.
1. Uzyskaj referencję do obiektu wykresu.
1. Animuj elementy kategorii.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy elementy kategorii.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Pobierz referencję do obiektu wykresu
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animuj elementy kategorii
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Zapisz plik prezentacji na dysk
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy różne typy efektów (np. wejścia, podkreślenia, wyjścia) są obsługiwane dla wykresów tak jak dla zwykłych kształtów?**

Tak. Wykres traktowany jest jako kształt, więc obsługuje standardowe typy efektów animacji, w tym wejścia, podkreślenia i wyjścia, z pełną kontrolą za pomocą osi czasu slajdu i sekwencji animacji.

**Czy mogę łączyć animację wykresu z przejściami slajdów?**

Tak. [Transitions](/slides/pl/androidjava/slide-transition/) dotyczą slajdu, natomiast efekty animacji odnoszą się do obiektów na slajdzie. Można używać obu jednocześnie w tej samej prezentacji i kontrolować je niezależnie.

**Czy animacje wykresów są zachowywane przy zapisywaniu do formatu PPTX?**

Tak. Gdy [zapisz jako PPTX](/slides/pl/androidjava/save-presentation/), wszystkie efekty animacji oraz ich kolejność są zachowywane, ponieważ są częścią natywnego modelu animacji prezentacji.

**Czy mogę odczytać istniejące animacje wykresów z prezentacji i modyfikować je?**

Tak. API zapewnia dostęp do osi czasu slajdu, sekwencji i efektów, umożliwiając przeglądanie istniejących animacji wykresów i ich dostosowywanie bez konieczności odtwarzania wszystkiego od początku.

**Czy mogę stworzyć wideo zawierające animacje wykresów przy użyciu Aspose.Slides?**

Tak. Możesz [wyeksportować prezentację do wideo](/slides/pl/androidjava/convert-powerpoint-to-video/), zachowując animacje, konfigurując czasy i inne ustawienia eksportu, tak aby powstały klip odzwierciedlał animowane odtwarzanie.