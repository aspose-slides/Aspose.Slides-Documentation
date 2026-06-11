---
title: Animowanie wykresów PowerPoint w .NET
linktitle: Animowane wykresy
type: docs
weight: 80
url: /pl/net/animated-charts/
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
- .NET
- C#
- Aspose.Slides
description: "Twórz zachwycające animowane wykresy w .NET przy użyciu Aspose.Slides. Wzmacniaj prezentacje dynamicznymi grafikami w plikach PPT i PPTX — rozpocznij już teraz."
---
## **Wstęp**

Aspose.Slides for .NET obsługuje animowanie elementów wykresu. **Series**, **Categories**, **Series Elements**, **Categories Elements** można animować metodą [ISequence.AddEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/methods/addeffect) oraz dwoma wyliczeniami [EffectChartMajorGroupingType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effectchartmajorgroupingtype) i [EffectChartMinorGroupingType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effectchartminorgroupingtype).

## **Animacja serii wykresu**
Jeśli chcesz animować serię wykresu, napisz kod zgodnie z poniższymi krokami:

1. Załaduj prezentację.
1. Uzyskaj odniesienie do obiektu wykresu.
1. Animuj serię.
1. Zapisz plik prezentacji na dysku.

W podanym poniżej przykładzie animowaliśmy serię wykresu.

```c#
 // Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji 
 using (Presentation presentation = new Presentation("ExistingChart.pptx"))
 {
     // Uzyskaj odniesienie do obiektu wykresu
     var slide = presentation.Slides[0] as Slide;
     var shapes = slide.Shapes as ShapeCollection;
     var chart = shapes[0] as IChart;

     // Animuj serię
     slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
     EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 0,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 1,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 2,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 3,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     // Zapisz zmodyfikowaną prezentację na dysku 
     presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
 }
```

## **Animacja kategorii wykresu**
Jeśli chcesz animować kategorię wykresu, napisz kod zgodnie z poniższymi krokami:

1. Załaduj prezentację.
1. Uzyskaj odniesienie do obiektu wykresu.
1. Animuj kategorię.
1. Zapisz plik prezentacji na dysku.

W podanym poniżej przykładzie animowaliśmy kategorię wykresu.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Uzyskaj odniesienie do obiektu wykresu
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animuj elementy kategorii
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Zapisz plik prezentacji na dysku
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **Animacja elementu serii**
Jeśli chcesz animować elementy serii, napisz kod zgodnie z poniższymi krokami:

1. Załaduj prezentację.
1. Uzyskaj odniesienie do obiektu wykresu.
1. Animuj elementy serii.
1. Zapisz plik prezentacji na dysku.

W podanym poniżej przykładzie animowaliśmy elementy serii.

```c#
 // Załaduj prezentację
 using (Presentation presentation = new Presentation("ExistingChart.pptx"))
 {
     // Uzyskaj odniesienie do obiektu wykresu
     var slide = presentation.Slides[0] as Slide;
     var shapes = slide.Shapes as ShapeCollection;
     var chart = shapes[0] as IChart;

     // Animuj elementy serii
     slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     // Zapisz plik prezentacji na dysku 
     presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
```

## **Animacja elementu kategorii**
Jeśli chcesz animować elementy kategorii, napisz kod zgodnie z poniższymi krokami:

1. Załaduj prezentację.
1. Uzyskaj odniesienie do obiektu wykresu.
1. Animuj elementy kategorii.
1. Zapisz plik prezentacji na dysku.

W podanym poniżej przykładzie animowaliśmy elementy kategorii.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Uzyskaj odniesienie do obiektu wykresu
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animuj elementy kategorii
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Zapisz plik prezentacji na dysku
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy różne typy efektów (np. wejście, podkreślenie, wyjście) są obsługiwane dla wykresów tak jak dla zwykłych kształtów?**

Tak. Wykres jest traktowany jako kształt, więc obsługuje standardowe typy efektów animacji, w tym wejście, podkreślenie i wyjście, z pełną kontrolą poprzez oś czasu slajdu i sekwencje animacji.

**Czy mogę łączyć animację wykresu z przejściami slajdów?**

Tak. [Transitions](/slides/pl/net/slide-transition/) dotyczą slajdu, podczas gdy efekty animacji dotyczą obiektów na slajdzie. Możesz używać obu jednocześnie w tej samej prezentacji i sterować nimi niezależnie.

**Czy animacje wykresów są zachowywane przy zapisywaniu do formatu PPTX?**

Tak. Kiedy [zapiszesz do PPTX](/slides/pl/net/save-presentation/), wszystkie efekty animacji i ich kolejność są zachowywane, ponieważ są częścią natywnego modelu animacji prezentacji.

**Czy mogę odczytać istniejące animacje wykresów z prezentacji i je zmodyfikować?**

Tak. [API](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/) zapewnia dostęp do osi czasu slajdu, sekwencji i efektów, umożliwiając przeglądanie istniejących animacji wykresów i ich modyfikację bez konieczności odtwarzania wszystkiego od nowa.

**Czy mogę wygenerować wideo z animacjami wykresów przy użyciu Aspose.Slides?**

Tak. Możesz [wyeksportować prezentację do wideo](/slides/pl/net/convert-powerpoint-to-video/), zachowując animacje, konfigurować czasy i inne ustawienia eksportu, aby powstały klip odzwierciedlał odtwarzanie animacji.