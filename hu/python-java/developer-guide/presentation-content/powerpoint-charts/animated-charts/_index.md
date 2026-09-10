---
title: PowerPoint diagramok animálása Pythonon keresztül Java-val
linktitle: Animált diagramok
type: docs
weight: 80
url: /hu/python-java/animated-charts/
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
- bemutató
- Python
- Java
- Aspose.Slides
description: "Készíts lenyűgöző animált diagramokat Pythonon keresztül Java-val az Aspose.Slides segítségével. Emeld fel a bemutatókat dinamikus vizuálokkal PPT és PPTX fájlokban - kezdj el most."
---
## **Bevezetés**

Az Aspose.Slides for Python via Java támogatja a diagram elemek animálását. **Series**, **Categories**, **Series Elements**, és **Category Elements** animálható a [Sequence.addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) metódussal és két felsorolással: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effectchartmajorgroupingtype/) és [EffectChartMinorGroupingType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effectchartminorgroupingtype/).

## **Diagram sorozat animáció**

Ha egy diagram sorozatot szeretne animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy bemutatót.
1. Szerezzen referenciát a diagramobjektumhoz.
1. Animálja a sorozatot.
1. Írja a bemutató fájlt a lemezre.

Az alábbi példa a diagram sorozatokat animálja. A példafájlban lévő diagram három sorozattal rendelkezik, ezért minden indexhez (0‑tól 2‑ig) egy effektust adunk hozzá. Az Aspose.Slides nem ellenőrzi az indexet a diagram adataival szemben, és egy nem létező sorozathoz hozzáadott effektus a fájlba kerül, de semmit sem animál – tartsa az indexet a saját diagramjában lévő sorozatok száma alatt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Töltsd be a bemutatót.
presentation = Presentation("ExistingChart.pptx")
try:
    # Szerezz egy hivatkozást a diagramobjektumra.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animáld a diagram elemeit.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Írd a módosított bemutatót a lemezre.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Diagram kategória animáció**

Ha egy diagram kategóriát szeretne animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy bemutatót.
1. Szerezzen referenciát a diagramobjektumhoz.
1. Animálja a kategóriát.
1. Írja a bemutató fájlt a lemezre.

Az alábbi példa a diagram kategóriákat animálja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Töltsd be a bemutatót.
presentation = Presentation("ExistingChart.pptx")
try:
    # Szerezz egy hivatkozást a diagramobjektumra.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animáld a diagram elemeit.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Írd a módosított bemutatót a lemezre.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animáció sorozat elemben**

Ha a sorozat elemeket szeretné animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy bemutatót.
1. Szerezzen referenciát a diagramobjektumhoz.
1. Animálja a sorozat elemeket.
1. Írja a bemutató fájlt a lemezre.

Az alábbi példa a sorozat elemeket animálja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Töltsd be a bemutatót.
presentation = Presentation("ExistingChart.pptx")
try:
    # Szerezz egy hivatkozást a diagramobjektumra.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animáld a diagram elemeit.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Írd a módosított bemutatót a lemezre.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animáció kategória elemben**

Ha a kategória elemeket szeretné animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy bemutatót.
1. Szerezzen referenciát a diagramobjektumhoz.
1. Animálja a kategória elemeket.
1. Írja a bemutató fájlt a lemezre.

Az alábbi példa a kategória elemeket animálja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Töltsd be a bemutatót.
presentation = Presentation("ExistingChart.pptx")
try:
    # Szerezz egy hivatkozást a diagramobjektumra.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animáld a diagram elemeit.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Írd a módosított bemutatót a lemezre.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Támogatja-e a diagramok különböző effektustípusait (pl. belépés, hangsúlyozás, kilépés) a szokásos alakzatokhoz hasonlóan?**

Igen. A diagramot alakzatként kezelik, így támogatja a szabványos animációs effektustípusokat, beleértve a belépést, hangsúlyozást és kilépést, teljes irányítással a dia idővonalán és animációs sorozataiban.

**Kombinálhatom-e a diagram animációt diaátmenetekkel?**

Igen. A [Transitions](/slides/hu/python-java/slide-transition/) a diára vonatkozik, míg az animációs effektusok a dián lévő objektumokra. Mindkettőt használhatja ugyanabban a bemutatóban, és önállóan vezérelheti őket.

**Megmaradnak-e a diagram animációk PPTX mentésekor?**

Igen. Amikor [save to PPTX](/slides/hu/python-java/save-presentation/) műveletet végez, az összes animációs effektus és azok sorrendje megmarad, mert részei a bemutató natív animációs modelljének.

**Olvashatom-e a meglévő diagram animációkat egy bemutatóból és módosíthatom őket?**

Igen. Az API hozzáférést biztosít a dia idővonalához, sorozataihoz és effektusaihoz, lehetővé téve a meglévő diagram animációk ellenőrzését és módosítását anélkül, hogy mindent újra kellene építeni.

**Készíthetek-e videót, amely tartalmazza a diagram animációkat az Aspose.Slides használatával?**

Igen. A [export a presentation to video](/slides/hu/python-java/convert-powerpoint-to-video/) funkcióval videóba konvertálhatja a bemutatót, megtartva az animációkat, beállítva az időzítéseket és egyéb export beállításokat, hogy a végeredmény tükrözze az animált lejátszást.