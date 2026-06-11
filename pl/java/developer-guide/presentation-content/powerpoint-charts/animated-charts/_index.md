---
title: Animuj wykresy PowerPoint w Javie
linktitle: Animowane wykresy
type: docs
weight: 80
url: /pl/java/animated-charts/
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
- Java
- Aspose.Slides
description: "Twórz zachwycające animowane wykresy w Javie z Aspose.Slides. Wzbogacaj prezentacje o dynamiczne wizualizacje w plikach PPT i PPTX — rozpocznij już teraz."
---
## **Wprowadzenie**

Aspose.Slides for Java obsługuje animowanie elementów wykresu. **Series**, **Categories**, **Series Elements**, **Categories Elements** mogą być animowane przy użyciu metody [ISequence.addEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) oraz dwóch wyliczeń [EffectChartMajorGroupingType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/EffectChartMajorGroupingType) i [EffectChartMinorGroupingType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/EffectChartMinorGroupingType).

## **Animacja serii wykresu**
Jeśli chcesz animować serię wykresu, napisz kod zgodnie z poniższymi krokami:

1. Załaduj prezentację.
1. Uzyskaj odwołanie do obiektu wykresu.
1. Animuj serię.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy serię wykresu.

```java
// Instancjuj klasę Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Pobierz odwołanie do obiektu wykresu
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
Jeśli chcesz animować serię wykresu, napisz kod zgodnie z poniższymi krokami:

1. Załaduj prezentację.
1. Uzyskaj odwołanie do obiektu wykresu.
1. Animuj kategorię.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy kategorię wykresu.

```java
// Instancjuj klasę Presentation, która reprezentuje plik prezentacji
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
1. Uzyskaj odwołanie do obiektu wykresu.
1. Animuj elementy serii.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy elementy serii.

```java
// Instancjuj klasę Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Pobierz odwołanie do obiektu wykresu
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
1. Uzyskaj odwołanie do obiektu wykresu.
1. Animuj elementy kategorii.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy elementy kategorii.

```java
// Utwórz klasę Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Pobierz odwołanie do obiektu wykresu
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

**Czy różne typy efektów (np. wejście, podkreślenie, zakończenie) są obsługiwane dla wykresów tak jak dla zwykłych kształtów?**

Tak. Wykres jest traktowany jako kształt, więc obsługuje standardowe typy efektów animacji, w tym wejście, podkreślenie i zakończenie, z pełną kontrolą poprzez oś czasu slajdu i sekwencje animacji.

**Czy mogę połączyć animację wykresu z przejściami slajdów?**

Tak. [Transitions](/slides/pl/java/slide-transition/) odnoszą się do slajdu, natomiast efekty animacji dotyczą obiektów na slajdzie. Możesz używać obu jednocześnie w tej samej prezentacji i kontrolować je niezależnie.

**Czy animacje wykresów są zachowywane przy zapisie do PPTX?**

Tak. Gdy [save to PPTX](/slides/pl/java/save-presentation/), wszystkie efekty animacji i ich kolejność są zachowywane, ponieważ stanowią część natywnego modelu animacji prezentacji.

**Czy mogę odczytać istniejące animacje wykresu z prezentacji i zmodyfikować je?**

Tak. API zapewnia dostęp do osi czasu slajdu, sekwencji i efektów, umożliwiając przeglądanie istniejących animacji wykresu i ich dostosowanie bez konieczności tworzenia wszystkiego od nowa.

**Czy mogę stworzyć wideo zawierające animacje wykresu przy użyciu Aspose.Slides?**

Tak. Możesz [export a presentation to video](/slides/pl/java/convert-powerpoint-to-video/) zachowując animacje, konfigurując czasy i inne ustawienia eksportu, aby otrzymany klip odzwierciedlał animowane odtwarzanie.