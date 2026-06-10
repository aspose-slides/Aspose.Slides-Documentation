---
title: PowerPoint diagramok animálása JavaScriptben
linktitle: Animált diagramok
type: docs
weight: 80
url: /hu/nodejs-java/animated-charts/
keywords:
- diagram
- animált diagram
- diagram animáció
- diagram sorozat
- diagram kategória
- sorozat elem
- kategória elem
- effektus hozzáadása
- effektus típus
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Készíts lenyűgöző animált diagramokat JavaScriptben az Aspose.Slides for Node.js segítségével. Emeld a prezentációkat dinamikus vizuálokkal PPT és PPTX fájlokban — kezdj bele most."
---
## **Bevezetés**

Az Aspose.Slides for Node.js via Java támogatja a diagram elemek animálását. **Series**, **Categories**, **Series Elements**, **Categories Elements** animálhatók a [Sequence.addEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#addEffect) metódussal és a két enummal [EffectChartMajorGroupingType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effectchartmajorgroupingtype/) és [EffectChartMinorGroupingType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effectchartminorgroupingtype/).

## **Diagram sorozat animációja**
Ha egy diagram sorozatot szeretne animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy prezentációt.
1. Szerezze meg a diagram objektumának hivatkozását.
1. Animálja a sorozatot.
1. Írja a prezentáció fájlt a lemezre.

Az alább megadott példában animáltuk a diagram sorozatát.

```javascript
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Szerezze meg a diagram objektumának hivatkozását
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Animálja a sorozatot
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Mentse a módosított prezentációt a lemezre
    pres.save("AnimatingSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Diagram kategória animációja**
Ha egy diagramkategóriát szeretne animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy prezentációt.
1. Szerezze meg a diagram objektumának hivatkozását.
1. Animálja a kategóriát.
1. Írja a prezentáció fájlt a lemezre.

Az alább megadott példában animáltuk a diagram kategóriáját.

```javascript
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel
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

## **Animáció a sorozat elemében**
Ha a sorozat elemeit szeretné animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy prezentációt.
1. Szerezze meg a diagram objektumának hivatkozását.
1. Animálja a sorozat elemeit.
1. Írja a prezentáció fájlt a lemezre.

Az alább megadott példában animáltuk a sorozat elemeit.

```javascript
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Szerezze meg a diagram objektumának hivatkozását
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Animálja a sorozat elemeit
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
    // Mentse a prezentációs fájlt a lemezre
    pres.save("AnimatingSeriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animáció a kategória elemében**
Ha a kategória elemeit szeretné animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy prezentációt.
1. Szerezze meg a diagram objektumának hivatkozását.
1. Animálja a kategória elemeit.
1. Írja a prezentáció fájlt a lemezre.

Az alább megadott példában animáltuk a kategória elemeit.

```javascript
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Szerezze meg a diagram objektumának hivatkozását
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Animálja a kategóriák elemeit
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
    // Mentse a prezentációs fájlt a lemezre
    pres.save("AnimatingCategoriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Támogatja-e a diagramok különböző effektustípusait (pl. belépés, hangsúlyozás, kilépés) ugyanúgy, mint a szabályos alakzatok?**

Igen. A diagramot alakzatként kezelik, így támogatja a szabványos animációs effektustípusokat, beleértve a belépést, hangsúlyozást és kilépést, teljes kontrollal a dia idővonalán és az animációs sorozatokon keresztül.

**Kombinálhatom-e a diagram animációt diák átmeneteivel?**

Igen. [Átmenetek](/slides/hu/nodejs-java/slide-transition/) a diára vonatkoznak, míg az animációs effektusok a dián lévő objektumokra. Mindkettőt használhatja ugyanabban a prezentációban, és függetlenül szabályozhatja őket.

**Megmaradnak-e a diagram animációk PPTX mentésekor?**

Igen. Amikor [PPTX-be ment](/slides/hu/nodejs-java/save-presentation/), minden animációs effektus és azok sorrendje megmarad, mivel a prezentáció natív animációs modelljének részei.

**Olvashatok-e meglévő diagram animációkat egy prezentációból és módosíthatom őket?**

Igen. Az API hozzáférést biztosít a dia idővonalához, sorozataihoz és effektusaihoz, lehetővé téve a meglévő diagram animációk megtekintését és módosítását anélkül, hogy mindent a semmiből újra kellene létrehozni.

**Készíthetek-e videót, amely tartalmazza a diagram animációkat az Aspose.Slides segítségével?**

Igen. [Exportálhat egy prezentációt videóba](/slides/hu/nodejs-java/convert-powerpoint-to-video/), miközben megőrzi az animációkat, beállítja az időzítéseket és egyéb exportálási beállításokat, így a kapott klipek az animált lejátszást tükrözik.