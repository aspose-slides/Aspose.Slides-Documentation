---
title: PowerPoint diagramok animálása Androidon
linktitle: Animált diagramok
type: docs
weight: 80
url: /hu/androidjava/animated-charts/
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
- Android
- Java
- Aspose.Slides
description: "Készítsen lenyűgöző animált diagramokat Java-val az Aspose.Slides for Android segítségével. Emelje a prezentációkat dinamikus vizuális elemekkel PPT és PPTX fájlokban – kezdje el most."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java támogatja a diagram elemek animálását. **Series**, **Categories**, **Series Elements**, **Categories Elements** animálhatók az [ISequence.addEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) metódussal és két felsorolással [EffectChartMajorGroupingType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/EffectChartMajorGroupingType) és [EffectChartMinorGroupingType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/EffectChartMinorGroupingType).

## **Diagram sorozat animáció**

Ha egy diagram sorozatot szeretne animálni, írja meg a kódot az alább felsorolt lépések szerint:

1. Töltsön be egy bemutatót.
1. Szerezze meg a diagram objektum hivatkozását.
1. Animálja a sorozatot.
1. Írja a bemutató fájlt a lemezre.

Az alábbi példa mutatja, hogy animáltuk a diagram sorozatot.

```java
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // A diagram objektum hivatkozásának lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Sorozat animálása
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

    // A módosított prezentáció mentése a lemezre
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Diagram kategória animáció**

Ha a diagram kategóriát szeretné animálni, írja meg a kódot az alább felsorolt lépések szerint:

1. Töltsön be egy bemutatót.
1. Szerezze meg a diagram objektum hivatkozását.
1. Animálja a kategóriát.
1. Írja a bemutató fájlt a lemezre.

Az alábbi példában animáltuk a diagram kategóriát.

```java
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel
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

## **Animáció egy sorozat elemben**

Ha a sorozat elemeket szeretné animálni, írja meg a kódot az alább felsorolt lépések szerint:

1. Töltsön be egy bemutatót.
1. Szerezze meg a diagram objektum hivatkozását.
1. Animálja a sorozat elemeket.
1. Írja a bemutató fájlt a lemezre.

Az alábbi példában animáltuk a sorozat elemeit.

```java
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // A diagram objektum hivatkozásának lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Sorozat elemek animálása
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

    // A prezentáció fájl mentése a lemezre 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animáció egy kategória elemben**

Ha a kategória elemeket szeretné animálni, írja meg a kódot az alább felsorolt lépések szerint:

1. Töltsön be egy bemutatót.
1. Szerezze meg a diagram objektum hivatkozását.
1. Animálja a kategória elemeket.
1. Írja a bemutató fájlt a lemezre.

Az alábbi példában animáltuk a kategória elemeket.

```java
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // A diagram objektum hivatkozásának lekérése
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Kategóriák elemeinek animálása
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

    // A prezentáció fájl mentése a lemezre
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Támogatottak a különböző hatástípusok (pl. belépés, hangsúly, kilépés) a diagramoknál úgy, mint a szabályos alakzatoknál?**

Igen. A diagramot alakzatként kezelik, így támogatja a szabványos animációs hatástípusokat, beleértve a belépést, hangsúlyt és kilépést, a dia idővonalán és animációs sorozataiban teljes vezérléssel.

**Kombinálhatom a diagram animációt diaátmenetekkel?**

Igen. A [Transitions](/slides/hu/androidjava/slide-transition/) a diára vonatkozik, míg az animációs hatások a dián lévő objektumokra. Mindkettőt együtt használhatja ugyanabban a prezentációban, és függetlenül vezérelheti őket.

**Megmaradnak a diagram animációk PPTX mentésekor?**

Igen. Amikor [save to PPTX](/slides/hu/androidjava/save-presentation/) műveletet hajtja végre, minden animációs hatás és azok sorrendje megmarad, mivel a prezentáció natív animációs modelljének részei.

**Olvashatok és módosíthatok meglévő diagram animációkat egy prezentációból?**

Igen. Az API hozzáférést biztosít a dia idővonalához, sorozataihoz és hatásaihoz, lehetővé téve a meglévő diagram animációk megtekintését és módosítását anélkül, hogy mindent újra kellene építeni.

**Készíthetek videót, amely tartalmazza a diagram animációkat az Aspose.Slides használatával?**

Igen. A [export a presentation to video](/slides/hu/androidjava/convert-powerpoint-to-video/) funkcióval exportálhat egy prezentációt videóba, miközben megőrzi az animációkat, beállítja az időzítéseket és egyéb export beállításokat, így a kapott klip az animált lejátszást tükrözi.