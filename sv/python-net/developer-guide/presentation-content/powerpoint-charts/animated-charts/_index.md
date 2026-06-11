---
title: Animera PowerPoint-diagram i Python
linktitle: Animera diagram
type: docs
weight: 80
url: /sv/python-net/animated-charts/
keywords:
- diagram
- animerat diagram
- diagramanimation
- diagramserie
- diagramkategori
- serieselement
- kategorielement
- lägg till effekt
- effekttyp
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Skapa fantastiska animerade diagram i Python med Aspose.Slides. Förbättra presentationer med dynamiska visuella element i PPT-, PPTX- och ODP-filer—kom igång nu."
---
## **Introduktion**

Aspose.Slides för Python via .NET stöder animering av diagrammets element. **Series**, **Categories**, **Series Elements**, **Categories Elements** kan animeras med metoden [ISequence.add_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/isequence/) och två uppräkningar [EffectChartMajorGroupingType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effectchartmajorgroupingtype/) och [EffectChartMinorGroupingType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effectchartminorgroupingtype/).
## **Diagramserieanimation**
Om du vill animera en diagramserie, skriv koden enligt stegen nedan:

1. Läs in en presentation.
1. Hämta referensen till diagramobjektet.
1. Animera serien.
1. Skriv presentationsfilen till disk.

I exemplet nedan animade vi diagramserien.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar en presentationsfil 
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Hämta referensen till diagramobjektet
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animera serien
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

    # Skriv den modifierade presentationen till disk 
    presentation.save("AnimatingSeries_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Diagramkategorianimation**
Om du vill animera en diagramkategori, skriv koden enligt stegen nedan:

1. Läs in en presentation.
1. Hämta referensen till diagramobjektet.
1. Animera kategorin.
1. Skriv presentationsfilen till disk.

I exemplet nedan animade vi diagramkategorin.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Hämta referensen till diagramobjektet
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animera kategorins element
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

    # Skriv presentationsfilen till disk
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Animation i serieelement**
Om du vill animera serieelement, skriv koden enligt stegen nedan:

1. Läs in en presentation.
1. Hämta referensen till diagramobjektet.
1. Animera serieelement.
1. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat serieelementen.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Läs in en presentation
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Hämta referensen till diagramobjektet
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animera serieelement
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

    # Skriv presentationsfilen till disk 
    presentation.save("AnimatingSeriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Animation i kategorielement**
Om du vill animera kategorielement, skriv koden enligt stegen nedan:

1. Läs in en presentation.
1. Hämta referensen till diagramobjektet.
1. Animera kategorielement.
1. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat kategorielement.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Hämta referensen till diagramobjektet
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animera kategorins element
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

    # Skriv presentationsfilen till disk
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Stöds olika effekttyper (t.ex. inträde, betoning, utgång) för diagram på samma sätt som för vanliga former?**

Ja. Ett diagram behandlas som en form, så det stödjer standardanimationseffekt‑typer, inklusive inträde, betoning och utgång, med full kontroll via bildens tidslinje och animationssekvenser.

**Kan jag kombinera diagramanimation med bildövergångar?**

Ja. [Transitions](/slides/sv/python-net/slide-transition/) gäller för bilden, medan animationseffekter gäller för objekt på bilden. Du kan använda båda tillsammans i samma presentation och kontrollera dem oberoende.

**Behålls diagramanimationer när man sparar till PPTX?**

Ja. När du [save to PPTX](/slides/sv/python-net/save-presentation/) sparas alla animationseffekter och deras ordning, eftersom de är en del av presentationens inbyggda animationsmodell.

**Kan jag läsa befintliga diagramanimationer från en presentation och ändra dem?**

Ja. [API](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/) ger åtkomst till bildens tidslinje, sekvenser och effekter, vilket gör att du kan undersöka befintliga diagramanimationer och justera dem utan att återskapa allt från början.

**Kan jag skapa en video som inkluderar diagramanimationer med Aspose.Slides för Python via .NET?**

Ja. Du kan [export a presentation to video](/slides/sv/python-net/convert-powerpoint-to-video/) samtidigt som du bevarar animationerna, konfigurerar tidsinställningar och andra exportalternativ så att den färdiga videoklippet återger den animerade uppspelningen.