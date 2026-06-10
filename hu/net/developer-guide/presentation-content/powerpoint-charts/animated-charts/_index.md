---
title: Animáljon PowerPoint diagramokat .NET-ben
linktitle: Animált diagramok
type: docs
weight: 80
url: /hu/net/animated-charts/
keywords:
- diagram
- animált diagram
- diagram animáció
- diagram sorozat
- diagram kategória
- sorozat elem
- kategória elem
- hatás hozzáadása
- hatástípus
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Hozzon létre lenyűgöző animált diagramokat .NET-ben az Aspose.Slides használatával. Növelje a prezentációk hatékonyságát dinamikus vizuálokkal PPT és PPTX fájlokban – kezdje el most."
---
## **Bevezetés**

Aspose.Slides for .NET támogatja a diagram elemeinek animálását. **Series**, **Categories**, **Series Elements**, **Categories Elements** animálható a [ISequence.AddEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/methods/addeffect) metódussal és két felsorolóval: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effectchartmajorgroupingtype) és [EffectChartMinorGroupingType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effectchartminorgroupingtype).

## **Diagram sorozat animációja**

Ha egy diagram sorozatot szeretne animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy prezentációt.
1. Szerezze meg a diagram objektum referenciáját.
1. Animálja a sorozatot.
1. Írja ki a prezentációs fájlt a lemezre.

Az alábbi példában animáltuk a diagram sorozatot.

```c#
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel 
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Lekéri a diagram objektum referenciáját
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animálja a sorozatot
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

    // Kiírja a módosított prezentációt lemezre 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```

## **Diagram kategória animációja**

Ha egy diagram kategóriát szeretne animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy prezentációt.
1. Szerezze meg a diagram objektum referenciáját.
1. Animálja a kategóriát.
1. Írja ki a prezentációs fájlt a lemezre.

Az alábbi példában animáltuk a diagram kategóriát.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Lekéri a diagram objektum referenciáját
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animálja a kategóriák elemeit
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

    // Kiírja a prezentációs fájlt a lemezre
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **Animáció sorozatelemben**

Ha sorozatelemeket szeretne animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy prezentációt.
1. Szerezze meg a diagram objektum referenciáját.
1. Animálja a sorozatelemeket.
1. Írja ki a prezentációs fájlt a lemezre.

Az alábbi példában animáltuk a sorozat elemeit.

```c#
// Betölti a prezentációt
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Lekéri a diagram objektum referenciáját
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animálja a sorozat elemeit
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

    // Kiírja a prezentációs fájlt a lemezre 
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **Animáció kategóriaelemben**

Ha kategóriaelemeket szeretne animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy prezentációt.
1. Szerezze meg a diagram objektum referenciáját.
1. Animálja a kategóriaelemeket.
1. Írja ki a prezentációs fájlt a lemezre.

Az alábbi példában animáltuk a kategóriaelemeket.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Lekéri a diagram objektum referenciáját
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animálja a kategóriák elemeit
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

    // Kiírja a prezentációs fájlt a lemezre
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Támogatja a diagramok a különböző hatástípusokat (például belépés, hangsúly, kilépés), akárcsak a szabályos alakzatok?**

Igen. A diagramot alakzatként kezelik, így támogatja a szabványos animációs hatástípusokat, beleértve a belépést, hangsúlyt és kilépést, teljes ellenőrzéssel a dia idővonalán és az animációs sorozatokon keresztül.

**Kombinálhatom a diagram animációját diaátmenetekkel?**

Igen. [Átmenetek](/slides/hu/net/slide-transition/) a diára vonatkozik, míg az animációs hatások a dia objektumaira. Mindkettőt használhatja ugyanabban a prezentációban, és függetlenül vezérelheti őket.

**Megmaradnak a diagram animációk PPTX mentésekor?**

Igen. Amikor [PPTX mentése](/slides/hu/net/save-presentation/) műveletet végzi, minden animációs hatás és azok sorrendje megmarad, mivel a prezentáció natív animációs modelljének részei.

**Olvashatok meglévő diagram animációkat egy prezentációból, és módosíthatom őket?**

Igen. Az [API](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/) hozzáférést biztosít a dia idővonalához, sorozataihoz és hatásaihoz, lehetővé téve a meglévő diagram animációk vizsgálatát és módosítását anélkül, hogy minden elemet újra kellene létrehozni.

**Készíthetek videót, amely tartalmazza a diagram animációkat az Aspose.Slides használatával?**

Igen. A [prezentáció exportálása videóba](/slides/hu/net/convert-powerpoint-to-video/) lehetőséggel megőrizheti az animációkat, beállíthatja az időzítéseket és egyéb exportálási beállításokat, így a kapott klip az animált lejátszást tükrözi.