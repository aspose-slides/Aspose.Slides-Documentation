---
title: Animera PowerPoint-diagram i PHP
linktitle: Animerade diagram
type: docs
weight: 80
url: /sv/php-java/animated-charts/
keywords:
- diagram
- animerat diagram
- diagramanimation
- diagramserie
- diagramkategori
- serieelement
- kategorielelement
- lägg till effekt
- effekttyp
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Skapa imponerande animerade diagram med Aspose.Slides för PHP via Java. Förbättra presentationer med dynamiska visuella element i PPT- och PPTX-filer — kom igång nu."
---
## **Introduktion**

Aspose.Slides för PHP via Java stöder animering av diagramelementen. **Series**, **Categories**, **Series Elements**, **Categories Elements** kan animeras med metoden [Sequence::addEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sequence/#addEffect) och två uppräkningar [EffectChartMajorGroupingType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/EffectChartMajorGroupingType) och [EffectChartMinorGroupingType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/EffectChartMinorGroupingType).

## **Diagramserieanimation**
Om du vill animera en diagramserie, skriv koden enligt stegen nedan:

1. Läs in en presentation.
1. Hämta referensen till diagramobjektet.
1. Animera serien.
1. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat diagramserien.

```php
  # Instansiera Presentation-klassen som representerar en presentationsfil
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Hämta referensen till diagramobjektet
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animera serien
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Skriv den modifierade presentationen till disk
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Diagramkategorianimering**
Om du vill animera en diagramkategori, skriv koden enligt stegen nedan:

1. Läs in en presentation.
1. Hämta referensen till diagramobjektet.
1. Animera kategorin.
1. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat diagramkategorin.

```php
  # Instansiera Presentation-klassen som representerar en presentationsfil
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

## **Animation i ett serieelement**
Om du vill animera serieelement, skriv koden enligt stegen nedan:

1. Läs in en presentation.
1. Hämta referensen till diagramobjektet.
1. Animera serieelement.
1. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat seriens element.

```php
  # Instansiera Presentation-klassen som representerar en presentationsfil
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Hämta referensen till diagramobjektet
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animera serieelement
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
    # Skriv presentationsfilen till disk
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animation i ett kategori-element**
Om du vill animera kategori-element, skriv koden enligt stegen nedan:

1. Läs in en presentation.
1. Hämta referensen till diagramobjektet.
1. Animera kategori-element.
1. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat kategori-element.

```php
  # Instansiera Presentation-klassen som representerar en presentationsfil
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Hämta referensen till diagramobjektet
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animera kategoriernas element
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
    # Skriv presentationsfilen till disk
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**Stöds olika effekttyper (t.ex. inträde, betoning, avslut) för diagram på samma sätt som för vanliga former?**

Ja. Ett diagram behandlas som en form, så det stödjer standardanimationseffekttyper, inklusive inträde, betoning och avslut, med full kontroll via bildens tidslinje och animationssekvenser.

**Kan jag kombinera diagramanimation med bildövergångar?**

Ja. [Transitions](/slides/sv/php-java/slide-transition/) gäller för bilden, medan animationseffekter gäller för objekt på bilden. Du kan använda båda tillsammans i samma presentation och styra dem oberoende.

**Behålls diagramanimationer vid sparande till PPTX?**

Ja. När du [sparar till PPTX](/slides/sv/php-java/save-presentation/), bevaras alla animationseffekter och deras ordning eftersom de är en del av presentationens inbyggda animationsmodell.

**Kan jag läsa befintliga diagramanimationer från en presentation och ändra dem?**

Ja. API:et ger tillgång till bildens tidslinje, sekvenser och effekter, vilket gör att du kan granska befintliga diagramanimationer och justera dem utan att återskapa allt från början.

**Kan jag skapa en video som inkluderar diagramanimationer med Aspose.Slides?**

Ja. Du kan [exportera en presentation till video](/slides/sv/php-java/convert-powerpoint-to-video/) samtidigt som du bevarar animationerna, konfigurerar tidsinställningar och andra exportalternativ så att den resulterande videoklippet återger den animerade uppspelningen.