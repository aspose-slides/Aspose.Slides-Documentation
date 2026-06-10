---
title: Animálja a PowerPoint diagramokat Java-ban
linktitle: Animált diagramok
type: docs
weight: 80
url: /hu/java/animated-charts/
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
- bemutató
- Java
- Aspose.Slides
description: "Létrehozhat lenyűgöző animált diagramokat Java-val az Aspose.Slides segítségével. Emelje a bemutatókat dinamikus vizuális elemekkel PPT és PPTX fájlokban – kezdje el most."
---
## **Bevezetés**

Az Aspose.Slides for Java támogatja a diagram elemek animálását. **Series**, **Categories**, **Series Elements**, **Categories Elements** animálhatók az [ISequence.addEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) metódussal és két felsorolással [EffectChartMajorGroupingType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/EffectChartMajorGroupingType) és [EffectChartMinorGroupingType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/EffectChartMinorGroupingType).

## **Diagram sorozat animációja**
Ha animálni szeretne egy diagram sorozatot, írja meg a kódot az alább felsorolt lépések szerint:

1. Töltse be a bemutatót.  
2. Szerezze meg a diagram objektum referenciáját.  
3. Animálja a sorozatot.  
4. Írja ki a bemutató fájlt a lemezre.  

Az alább látható példában animáltuk a diagram sorozatát.

```java
// Példányosítsa a Presentation osztályt, amely egy bemutató fájlt képvisel
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Szerezze meg a diagram objektum referenciáját
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animálja a sorozatot
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

    // Írja ki a módosított bemutatót a lemezre
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Diagram kategória animációja**
Ha animálni szeretne egy diagram kategóriát, írja meg a kódot az alább felsorolt lépések szerint:

1. Töltse be a bemutatót.  
2. Szerezze meg a diagram objektum referenciáját.  
3. Animálja a kategóriát.  
4. Írja ki a bemutató fájlt a lemezre.  

Az alább látható példában animáltuk a diagram kategóriát.

```java
// Példányosítsa a Presentation osztályt, amely egy bemutató fájlt képvisel
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
Ha animálni szeretne sorozat elemeket, írja meg a kódot az alább felsorolt lépések szerint:

1. Töltse be a bemutatót.  
2. Szerezze meg a diagram objektum referenciáját.  
3. Animálja a sorozat elemeket.  
4. Írja ki a bemutató fájlt a lemezre.  

Az alább látható példában animáltuk a sorozat elemeit.

```java
// Példányosítsa a Presentation osztályt, amely egy bemutató fájlt képvisel
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Szerezze meg a diagram objektum referenciáját
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animálja a sorozat elemeket
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.No

ne, EffectTriggerType.AfterPrevious);

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

    // Írja ki a bemutató fájlt a lemezre 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animáció egy kategória elemben**
Ha animálni szeretne kategóriaelemeket, írja meg a kódot az alább felsorolt lépések szerint:

1. Töltse be a bemutatót.  
2. Szerezze meg a diagram objektum referenciáját.  
3. Animálja a kategóriaelemeket.  
4. Írja ki a bemutató fájlt a lemezre.  

Az alább látható példában animáltuk a kategóriaelemeket.

```java
// Példányosítsa a Presentation osztályt, amely egy bemutató fájlt képvisel
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Szerezze meg a diagram objektum referenciáját
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animálja a kategóriák elemeit
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

    // Írja ki a bemutató fájlt a lemezre
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Támogatottak különböző hatástípusok (pl. belépés, hangsúlyozás, kilépés) a diagramok esetében, ahogyan a szokásos alakzatoknál?**  
Igen. A diagramot alakzatként kezelik, ezért támogatja a szabványos animációs hatástípusokat, beleértve a belépést, hangsúlyozást és kilépést, teljes vezérléssel a dia idővonalán és animációs sorozataiban.

**Kombinálhatom a diagram animációt diaátmenetekkel?**  
Igen. A [Transitions](/slides/hu/java/slide-transition/) a diára vonatkozik, míg az animációs hatások a dián lévő objektumokra. Mindkettőt használhatja ugyanabban a bemutatóban, és függetlenül vezérelheti őket.

**Megmaradnak a diagram animációk PPTX mentéskor?**  
Igen. Amikor [save to PPTX](/slides/hu/java/save-presentation/) paranccsal ment, minden animációs hatás és azok sorrendje megmarad, mivel a bemutató natív animációs modelljének részei.

**Olvashatok és módosíthatok meglévő diagram animációkat egy bemutatóból?**  
Igen. Az API hozzáférést biztosít a dia idővonalához, sorozataihoz és hatásaihoz, lehetővé téve a meglévő diagram animációk megtekintését és módosítását anélkül, hogy mindent újra kellene építeni.

**Készíthetek videót, amely tartalmazza a diagram animációkat az Aspose.Slides segítségével?**  
Igen. A [export a presentation to video](/slides/hu/java/convert-powerpoint-to-video/) segítségével exportálhatja a bemutatót videóba, miközben megőrzi az animációkat, beállítja az időzítéseket és egyéb exportbeállításokat, így a kapott klip tükrözi az animált lejátszást.