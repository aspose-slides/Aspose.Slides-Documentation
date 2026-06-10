---
title: PowerPoint-diagramok animálása PHP-ben
linktitle: Animált diagramok
type: docs
weight: 80
url: /hu/php-java/animated-charts/
keywords:
- diagram
- animált diagram
- diagram animáció
- diagram sorozat
- diagram kategória
- sorozat elem
- kategória elem
- effektus hozzáadása
- effektustípus
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Készíts lenyűgöző animált diagramokat az Aspose.Slides for PHP via Java segítségével. Erősítsd a prezentációkat dinamikus vizuálokkal PPT és PPTX fájlokban – kezdj neki most."
---
## **Bevezetés**

Aspose.Slides for PHP via Java támogatja a diagram elemek animálását. **Series**, **Categories**, **Series Elements**, **Categories Elements** animálhatók a [Sequence::addEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/#addEffect) metódussal, valamint a két enumerációval: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/EffectChartMajorGroupingType) és [EffectChartMinorGroupingType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/EffectChartMinorGroupingType).

## **Diagram Sorozat Animációja**
Ha egy diagram sorozatot szeretnél animálni, írd meg a kódot az alábbi lépések szerint:

1. Tölts be egy prezentációt.
1. Szerezd meg a diagram objektum referenciáját.
1. Animáld a sorozatot.
1. Írd a prezentáció fájlt a lemezre.

Az alábbi példában animáltuk a diagram sorozatot.

```php
  # Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Szerezze meg a diagram objektum referenciáját
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animálja a sorozatot
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Írja a módosított prezentációt a lemezre
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Diagram Kategória Animációja**
Ha egy diagram kategóriát szeretnél animálni, írd meg a kódot az alábbi lépések szerint:

1. Tölts be egy prezentációt.
1. Szerezd meg a diagram objektum referenciáját.
1. Animáld a kategóriát.
1. Írd a prezentáció fájlt a lemezre.

Az alábbi példában animáltuk a diagram kategóriát.

```php
  # Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
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

## **Animáció Sorozat Elemben**
Ha a sorozat elemeket szeretnéd animálni, írd meg a kódot az alábbi lépések szerint:

1. Tölts be egy prezentációt.
1. Szerezd meg a diagram objektum referenciáját.
1. Animáld a sorozat elemeket.
1. Írd a prezentáció fájlt a lemezre.

Az alábbi példában animáltuk a sorozat elemeit.

```php
  # Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Szerezze meg a diagram objektum referenciáját
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animálja a sorozat elemeket
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
    # Írja a prezentációs fájlt a lemezre
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animáció Kategória Elemben**
Ha a kategória elemeket szeretnéd animálni, írd meg a kódot az alábbi lépések szerint:

1. Tölts be egy prezentációt.
1. Szerezd meg a diagram objektum referenciáját.
1. Animáld a kategória elemeket.
1. Írd a prezentáció fájlt a lemezre.

Az alábbi példában animáltuk a kategória elemeket.

```php
  # Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Szerezze meg a diagram objektum referenciáját
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animálja a kategóriák elemeit
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
    # Írja a prezentációs fájlt a lemezre
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Támogatottak-e a különböző effektustípusok (pl. belépés, hangsúlyozás, kilépés) a diagramoknál, akárcsak a szokásos alakzatoknál?**

Igen. A diagram alakzatként kezelődik, így támogatja a szabványos animációs effektustípusokat, beleértve a belépést, hangsúlyozást és kilépést, teljes vezérléssel a diák idővonalán és animációs sorozatokon keresztül.

**Kombinálhatom-e a diagram animációt diaátmenetekkel?**

Igen. [Transitions](/slides/hu/php-java/slide-transition/) a diára vonatkozik, míg az animációs effektusok a dián lévő objektumokra. Mindkettőt együtt használhatod ugyanabban a prezentációban, és függetlenül vezérelheted őket.

**Megmaradnak-e a diagram animációk PPTX mentésekor?**

Igen. Amikor [save to PPTX](/slides/hu/php-java/save-presentation/) (mented PPTX-be), minden animációs effektus és azok sorrendje megmarad, mivel a prezentáció natív animációs modelljének részei.

**Olvashatok-e meglévő diagram animációkat egy prezentációból és módosíthatom őket?**

Igen. Az API hozzáférést biztosít a dia idővonalához, sorozataihoz és effektusaihoz, így megvizsgálhatod a meglévő diagram animációkat, és módosíthatod őket anélkül, hogy mindent újra kellene építeni.

**Létrehozhatok-e videót, amely tartalmazza a diagram animációkat az Aspose.Slides használatával?**

Igen. [export a presentation to video](/slides/hu/php-java/convert-powerpoint-to-video/) segítségével exportálhatsz egy prezentációt videóba, miközben megőrzöd az animációkat, beállítva a időzítéseket és egyéb exportálási beállításokat, hogy a kész klip tükrözze az animált lejátszást.