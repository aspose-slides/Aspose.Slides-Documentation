---
title: Animera PowerPoint-diagram på Android
linktitle: Animerade diagram
type: docs
weight: 80
url: /sv/androidjava/animated-charts/
keywords:
- diagram
- animerat diagram
- diagramanimation
- diagramserie
- diagramkategori
- serieelement
- kategorielement
- lägg till effekt
- effekttyp
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Skapa imponerande animerade diagram i Java med Aspose.Slides för Android. Förbättra presentationer med dynamiska visuella element i PPT- och PPTX-filer — kom igång nu."
---
## **Introduktion**

Aspose.Slides för Android via Java stöder animering av diagrammets element. **Series**, **Categories**, **Series Elements**, **Categories Elements** kan animeras med metoden [ISequence.addEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) och två uppräkningar [EffectChartMajorGroupingType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/EffectChartMajorGroupingType) och [EffectChartMinorGroupingType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/EffectChartMinorGroupingType).

## **Diagramserieanimation**

Om du vill animera en diagramserie, skriv koden enligt stegen nedan:

1. Läs in en presentation.
1. Hämta referens till diagramobjektet.
1. Animera serien.
1. Skriv presentationsfilen till disk.

I exempel nedan har vi animerat diagramserier.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Hämta referens till diagramobjektet
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animera serien
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

    // Skriv den modifierade presentationen till disk
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Diagramkategorianimation**

Om du vill animera en diagramkategori, skriv koden enligt stegen nedan:

1. Läs in en presentation.
1. Hämta referens till diagramobjektet.
1. Animera kategorin.
1. Skriv presentationsfilen till disk.

I exempel nedan har vi animerat diagramkategorin.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil
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

## **Animation i ett serieelement**

Om du vill animera serieelement, skriv koden enligt stegen nedan:

1. Läs in en presentation.
1. Hämta referens till diagramobjektet.
1. Animera serieelement.
1. Skriv presentationsfilen till disk.

I exempel nedan har vi animerat seriens element.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Hämta referens till diagramobjektet
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animera serieelement
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

    // Skriv presentationsfilen till disk 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animation i ett kategorielement**

Om du vill animera kategorielement, skriv koden enligt stegen nedan:

1. Läs in en presentation.
1. Hämta referens till diagramobjektet.
1. Animera kategorielement.
1. Skriv presentationsfilen till disk.

I exempel nedan har vi animerat kategorielement.

```java
// Instansiera Presentation-klass som representerar en presentationsfil
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Hämta referens till diagramobjektet
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animera kategoriernas element
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

    // Skriv presentationsfilen till disk
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Stöds olika effekttyper (t.ex. inträde, betoning, avslut) för diagram på samma sätt som för vanliga former?**

Ja. Ett diagram behandlas som en form, så det stöder de standardanimeringseffekttyperna, inklusive inträde, betoning och avslut, med full kontroll via bildens tidslinje och animationssekvenser.

**Kan jag kombinera diagramanimation med bildövergångar?**

Ja. [Transitions](/slides/sv/androidjava/slide-transition/) gäller för hela bilden, medan animationseffekter gäller för objekt på bilden. Du kan använda båda tillsammans i samma presentation och styra dem oberoende.

**Behålls diagramanimationer när man sparar till PPTX?**

Ja. När du [spara som PPTX](/slides/sv/androidjava/save-presentation/) sparas alla animationseffekter och deras ordning, eftersom de är en del av presentationens inbyggda animationsmodell.

**Kan jag läsa befintliga diagramanimationer från en presentation och ändra dem?**

Ja. API:et ger åtkomst till bildens tidslinje, sekvenser och effekter, så att du kan inspektera befintliga diagramanimationer och justera dem utan att återskapa allt från början.

**Kan jag skapa en video som inkluderar diagramanimationer med Aspose.Slides?**

Ja. Du kan [exportera en presentation till video](/slides/sv/androidjava/convert-powerpoint-to-video/) samtidigt som du behåller animationerna, konfigurerar tidsinställningarna och andra exportinställningar så att den resulterande videon återspeglar den animerade uppspelningen.