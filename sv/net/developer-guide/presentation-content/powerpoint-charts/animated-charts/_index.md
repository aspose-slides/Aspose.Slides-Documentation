---
title: Animera PowerPoint-diagram i .NET
linktitle: Animera diagram
type: docs
weight: 80
url: /sv/net/animated-charts/
keywords:
- diagram
- animert diagram
- diagramanimation
- diagramserie
- diagramkategori
- serieelement
- kategorielelement
- lägga till effekt
- effekttyp
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa fantastiska animerade diagram i .NET med Aspose.Slides. Förbättra presentationer med dynamiska visualiseringar i PPT- och PPTX-filer - kom igång nu."
---
## **Introduktion**

Aspose.Slides för .NET stöder animering av diagrammets element. **Serier**, **Kategorier**, **Serieelement**, **Kategorielelement** kan animeras med [ISequence.AddEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/isequence/methods/addeffect) metoden och två uppräkningar [EffectChartMajorGroupingType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effectchartmajorgroupingtype) och [EffectChartMinorGroupingType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effectchartminorgroupingtype).

## **Diagramserieanimation**
Om du vill animera en diagramserie, skriv koden enligt stegen nedan:

1. Läs in en presentation.
2. Hämta referensen till diagramobjektet.
3. Animera serien.
4. Skriv presentationsfilen till disk.

I exemplet nedan animerade vi diagramserier.

```c#
 // Instansiera Presentation-klass som representerar en presentationsfil 
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Hämta referensen till diagramobjektet
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animera serien
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

    // Skriv den modifierade presentationen till disk 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```

## **Diagramkategorianimation**
Om du vill animera en diagramkategori, skriv koden enligt stegen nedan:

1. Läs in en presentation.
2. Hämta referensen till diagramobjektet.
3. Animera kategorin.
4. Skriv presentationsfilen till disk.

I exemplet nedan animerade vi diagramkategorier.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Hämta referensen till diagramobjektet
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animera kategoriernas element
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

    // Skriv presentationsfilen till disk
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **Animation i ett serieelement**
Om du vill animera serieelement, skriv koden enligt stegen nedan:

1. Läs in en presentation.
2. Hämta referensen till diagramobjektet.
3. Animera serieelement.
4. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat serieelement.

```c#
    // Läs in en presentation
    using (Presentation presentation = new Presentation("ExistingChart.pptx"))
    {
        // Hämta referensen till diagramobjektet
        var slide = presentation.Slides[0] as Slide;
        var shapes = slide.Shapes as ShapeCollection;
        var chart = shapes[0] as IChart;

        // Animera serierelement
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

        // Skriv presentationsfilen till disk 
        presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
```

## **Animation i ett kategorielelement**
Om du vill animera kategorielemen, skriv koden enligt stegen nedan:

1. Läs in en presentation.
2. Hämta referensen till diagramobjektet.
3. Animera kategorielemen.
4. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat kategorielemen.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Hämta referensen till diagramobjektet
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animera kategoriernas element
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

    // Skriv presentationsfilen till disk
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Stöds olika effektstyper (t.ex. inträde, betoning, utgång) för diagram på samma sätt som för vanliga former?**

Ja. Ett diagram behandlas som en form, så det stöder de standardanimatieffekttyperna, inklusive inträde, betoning och utgång, med full kontroll via bildens tidslinje och animationssekvenser.

**Kan jag kombinera diagramanimation med bildövergångar?**

Ja. [Transitions](/slides/sv/net/slide-transition/) gäller hela bilden, medan animationseffekter gäller objekt på bilden. Du kan använda båda tillsammans i samma presentation och styra dem oberoende.

**Behålls diagramanimationer när du sparar till PPTX?**

Ja. När du [sparar till PPTX](/slides/sv/net/save-presentation/) bevaras alla animationseffekter och deras ordning eftersom de är en del av presentationens inbyggda animationsmodell.

**Kan jag läsa befintliga diagramanimationer från en presentation och ändra dem?**

Ja. [API](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/) ger åtkomst till bildens tidslinje, sekvenser och effekter, så att du kan inspektera befintliga diagramanimationer och justera dem utan att återskapa allt från början.

**Kan jag skapa en video som inkluderar diagramanimationer med Aspose.Slides?**

Ja. Du kan [exportera en presentation till video](/slides/sv/net/convert-powerpoint-to-video/) samtidigt som du bevarar animationerna, konfigurerar tidsinställningar och andra exportalternativ så att den resulterande klippet återger den animerade uppspelningen.