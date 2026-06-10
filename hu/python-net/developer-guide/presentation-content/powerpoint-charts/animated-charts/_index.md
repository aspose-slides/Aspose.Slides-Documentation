---
title: "PowerPoint-diagramok animálása Pythonban"
linktitle: "Animált diagramok"
type: docs
weight: 80
url: /hu/python-net/animated-charts/
keywords:
- diagram
- animált diagram
- diagram animáció
- diagram sorozat
- diagram kategória
- sorozat elem
- kategória elem
- effektus hozzáadása
- effektus típusa
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Létrehozhat lenyűgöző animált diagramokat Pythonban az Aspose.Slides segítségével. Erősítse a prezentációkat dinamikus vizuálokkal PPT, PPTX és ODP fájlokban – kezdje el most."
---
## **Bevezetés**

Aspose.Slides for Python via .NET támogatja a diagram elemeinek animálását. **Series**, **Categories**, **Series Elements**, **Categories Elements** animálható a [ISequence.add_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/isequence/) metódussal és a két felsorolt enummal: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effectchartmajorgroupingtype/) és [EffectChartMinorGroupingType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effectchartminorgroupingtype/).
## **Diagram sorozat animáció**
Ha egy diagram sorozatot szeretne animálni, írja a kódot az alábbi lépések szerint:

1. Töltsön be egy bemutatót.  
2. Szerezze meg a diagram objektum referenciáját.  
3. Animálja a sorozatot.  
4. Írja a bemutató fájlt a lemezre.  

Az alább megadott példában animáltuk a diagram sorozatot.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely egy prezentációfájlt képvisel 
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Szerezze meg a diagram objektum referenciáját
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animálja a sorozatot
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

    # Írja a módosított prezentációt a lemezre 
    presentation.save("AnimatingSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Diagram kategória animáció**
Ha egy diagram kategóriát szeretne animálni, írja a kódot az alábbi lépések szerint:

1. Töltsön be egy bemutatót.  
2. Szerezze meg a diagram objektum referenciáját.  
3. Animálja a kategóriát.  
4. Írja a bemutató fájlt a lemezre.  

Az alább megadott példában animáltuk a diagram kategóriát.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Szerezze meg a diagram objektum referenciáját
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animálja a kategóriák elemeit
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

    # Írja a prezentációt a lemezre
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animáció a sorozat elemben**
Ha a sorozat elemeit szeretné animálni, írja a kódot az alábbi lépések szerint:

1. Töltsön be egy bemutatót.  
2. Szerezze meg a diagram objektum referenciáját.  
3. Animálja a sorozat elemeit.  
4. Írja a bemutató fájlt a lemezre.  

Az alább megadott példában animáltuk a sorozat elemeit.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

    # Töltse be a prezentációt
    with slides.Presentation(path + "ExistingChart.pptx") as presentation:
        # Szerezze meg a diagram objektum referenciáját
        slide = presentation.slides[0]
        shapes = slide.shapes
        chart = shapes[0]

        # Animálja a sorozat elemeit
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

        # Írja a prezentációs fájlt a lemezre 
        presentation.save("AnimatingSeriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animáció a kategória elemben**
Ha a kategória elemeit szeretné animálni, írja a kódot az alábbi lépések szerint:

1. Töltsön be egy bemutatót.  
2. Szerezze meg a diagram objektum referenciáját.  
3. Animálja a kategória elemeit.  
4. Írja a bemutató fájlt a lemezre.  

Az alább megadott példában animáltuk a kategória elemeit.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Szerezze meg a diagram objektum referenciáját
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animálja a kategóriák elemeit
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

    # Írja a prezentációs fájlt a lemezre
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Támogatottak a különböző effektustípusok (pl. belépés, hangsúlyozás, kilépés) a diagramok esetén, ahogy a normál alakzatoknál?**

Igen. A diagram alakzatként van kezelve, ezért támogatja a szabványos animációs effektustípusokat, beleértve a belépést, hangsúlyozást és kilépést, teljes vezérléssel a dia idővonalán és animációs sorozatokon keresztül.

**Kombinálhatom a diagram animációt a diaátmenetekkel?**

Igen. A [Transitions](/slides/hu/python-net/slide-transition/) a diára vonatkozik, míg az animációs effektek a dián lévő objektumokra. Mindkettőt használhatja egy prezentációban és külön is vezérelheti őket.

**Megmaradnak a diagram animációk PPTX mentésekor?**

Igen. Amikor [save to PPTX](/slides/hu/python-net/save-presentation/) parancsot használ, minden animációs effektus és azok sorrendje megmarad, mivel a prezentáció natív animációs modelljének része.

**Olvashatok már létező diagram animációkat egy bemutatóból és módosíthatom őket?**

Igen. Az [API](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/) hozzáférést biztosít a dia idővonalához, sorozataihoz és effektusaihoz, lehetővé téve a meglévő diagram animációk megtekintését és módosítását anélkül, hogy mindent újra kellene építeni.

**Készíthetek videót, amely diagram animációkat is tartalmaz az Aspose.Slides for Python via .NET használatával?**

Igen. A [export a presentation to video](/slides/hu/python-net/convert-powerpoint-to-video/) funkcióval exportálhat prezentációt videóba, miközben megőrzi az animációkat, beállítja az időzítéseket és egyéb export beállításokat, hogy a kész klip tükrözze az animált lejátszást.