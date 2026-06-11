---
title: Animera PowerPoint-diagram i JavaScript
linktitle: Animera diagram
type: docs
weight: 80
url: /sv/nodejs-java/animated-charts/
keywords:
- diagram
- animert diagram
- diagramanimation
- diagramserie
- diagramkategori
- serieelement
- kategorielement
- lägg till effekt
- effekttyp
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa fantastiska animerade diagram i JavaScript med Aspose.Slides för Node.js. Förbättra presentationer med dynamiska visuella element i PPT- och PPTX-filer—kom igång nu."
---
## **Introduktion**

Aspose.Slides för Node.js via Java stöder animering av diagrammets element. **Series**, **Categories**, **Series Elements**, **Categories Elements** kan animeras med [Sequence.addEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sequence/#addEffect) metoden och två uppräkningar [EffectChartMajorGroupingType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effectchartmajorgroupingtype/) och [EffectChartMinorGroupingType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effectchartminorgroupingtype/).

## **Animering av diagramserie**
Om du vill animera en diagramserie, skriv koden enligt stegen nedan:

1. Läs in en presentation.
2. Hämta referensen till diagramobjektet.
3. Animera serien.
4. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat diagramserien.

```javascript
// Skapa en Presentation-klass som representerar en presentationsfil
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Hämta referensen till diagramobjektet
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Animera serien
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Skriv den ändrade presentationen till disk
    pres.save("AnimatingSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animering av diagramkategori**
Om du vill animera en diagramkategori, skriv koden enligt stegen nedan:

1. Läs in en presentation.
2. Hämta referensen till diagramobjektet.
3. Animera kategorin.
4. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat diagramkategorin.

```javascript
// Skapa Presentation-klass som representerar en presentationsfil
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    pres.save("Sample_Animation_C.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animation i serieelement**
Om du vill animera serieelement, skriv koden enligt stegen nedan:

1. Läs in en presentation.
2. Hämta referensen till diagramobjektet.
3. Animera serieelement.
4. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat serieelementen.

```javascript
// Instansiera Presentation-klass som representerar en presentationsfil
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Hämta referensen till diagramobjektet
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Animera serieelement
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Skriv presentationsfilen till disk
    pres.save("AnimatingSeriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animation i kategorielement**
Om du vill animera kategorielement, skriv koden enligt stegen nedan:

1. Läs in en presentation.
2. Hämta referensen till diagramobjektet.
3. Animera kategorielement.
4. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat kategorielement.

```javascript
// Instansiera Presentation-klass som representerar en presentationsfil
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Hämta referensen till diagramobjektet
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Animera element i kategorier
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Skriv presentationsfilen till disk
    pres.save("AnimatingCategoriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Stöds olika effektstyper (t.ex. inträde, betoning, avslut) för diagram på samma sätt som för vanliga former?**

Ja. Ett diagram behandlas som en form, så det stöder de vanliga animationseffekttyperna, inklusive inträde, betoning och avslut, med full kontroll via bildens tidslinje och animationssekvenser.

**Kan jag kombinera diagramanimation med bildövergångar?**

Ja. [Transitions](/slides/sv/nodejs-java/slide-transition/) gäller för bilden, medan animationseffekter gäller för objekt på bilden. Du kan använda båda tillsammans i samma presentation och kontrollera dem oberoende.

**Behålls diagramanimationer när man sparar till PPTX?**

Ja. När du [sparar till PPTX](/slides/sv/nodejs-java/save-presentation/), alla animationseffekter och deras ordning bevaras eftersom de är en del av presentationens inbyggda animationsmodell.

**Kan jag läsa befintliga diagramanimationer från en presentation och ändra dem?**

Ja. API:et ger åtkomst till bildens tidslinje, sekvenser och effekter, vilket låter dig inspektera befintliga diagramanimationer och justera dem utan att återskapa allt från början.

**Kan jag skapa en video som innehåller diagramanimationer med Aspose.Slides?**

Ja. Du kan [exportera en presentation till video](/slides/sv/nodejs-java/convert-powerpoint-to-video/) medan du bevarar animationerna, konfigurerar tidsinställningar och andra exportinställningar så att den resulterande videon återspeglar den animerade uppspelningen.