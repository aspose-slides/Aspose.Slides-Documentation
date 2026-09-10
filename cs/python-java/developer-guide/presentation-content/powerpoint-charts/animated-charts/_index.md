---
title: Animujte grafy PowerPoint v Pythonu pomocí Java
linktitle: Animované grafy
type: docs
weight: 80
url: /cs/python-java/animated-charts/
keywords:
- graf
- animovaný graf
- animace grafu
- série grafu
- kategorie grafu
- prvek série
- prvek kategorie
- přidat efekt
- typ efektu
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvořte úchvatné animované grafy v Pythonu pomocí Java s Aspose.Slides. Vylepšete prezentace dynamickými vizuály v souborech PPT a PPTX — začněte hned."
---
## **Úvod**

Aspose.Slides for Python via Java podporuje animaci prvků grafu. **Série**, **Kategorie**, **Prvky sérií** a **Prvky kategorií** lze animovat pomocí metody [Sequence.addEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sequence/#addEffect) a dvou výčtů: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effectchartmajorgroupingtype/) a [EffectChartMinorGroupingType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effectchartminorgroupingtype/).

## **Animace sérií grafu**

Pokud chcete animovat sérii grafu, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.  
1. Získejte odkaz na objekt grafu.  
1. Animujte sérii.  
1. Zapíšete soubor prezentace na disk.

Následující příklad animuje série grafu. Graf v ukázkovém souboru má tři série, takže pro každý index od 0 do 2 je přidán jeden efekt. Aspose.Slides nekontroluje index vůči datům grafu a efekt přidaný pro sérii, která neexistuje, je zapsán do souboru, ale neanimuje nic — udržujte index pod počtem sérií ve vašem grafu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Načtěte prezentaci.
presentation = Presentation("ExistingChart.pptx")
try:
    # Získejte odkaz na objekt grafu.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animujte prvky grafu.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Uložte upravenou prezentaci na disk.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animace kategorií grafu**

Pokud chcete animovat kategorii grafu, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.  
1. Získejte odkaz na objekt grafu.  
1. Animujte kategorii.  
1. Zapíšete soubor prezentace na disk.

Následující příklad animuje kategorie grafu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Načtěte prezentaci.
presentation = Presentation("ExistingChart.pptx")
try:
    # Získejte odkaz na objekt grafu.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animujte prvky grafu.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Uložte upravenou prezentaci na disk.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animace v prvku série**

Pokud chcete animovat prvky sérií, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.  
1. Získejte odkaz na objekt grafu.  
1. Animujte prvky sérií.  
1. Zapíšete soubor prezentace na disk.

Následující příklad animuje prvky sérií.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Načtěte prezentaci.
presentation = Presentation("ExistingChart.pptx")
try:
    # Získejte odkaz na objekt grafu.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animujte prvky grafu.
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

    # Uložte upravenou prezentaci na disk.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animace v prvku kategorie**

Pokud chcete animovat prvky kategorií, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.  
1. Získejte odkaz na objekt grafu.  
1. Animujte prvky kategorií.  
1. Zapíšete soubor prezentace na disk.

Následující příklad animuje prvky kategorií.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Načtěte prezentaci.
presentation = Presentation("ExistingChart.pptx")
try:
    # Získejte odkaz na objekt grafu.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animujte prvky grafu.
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

    # Uložte upravenou prezentaci na disk.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Časté dotazy**

**Jsou pro grafy podporovány různé typy efektů (např. vstup, důraz, odchod) stejně jako pro běžné tvary?**

Ano. Graf je považován za tvar, takže podporuje standardní typy animačních efektů, včetně vstupu, důrazu a odchodu, s plnou kontrolou prostřednictvím časové osy snímku a animačních sekvencí.

**Mohu kombinovat animaci grafu s přechody snímků?**

Ano. [Transitions](/slides/cs/python-java/slide-transition/) se vztahují na snímek, zatímco animační efekty se vztahují na objekty na snímku. Obě můžete použít současně ve stejné prezentaci a řídit je nezávisle.

**Zachovají se animace grafu při ukládání do PPTX?**

Ano. Když [uložíte do PPTX](/slides/cs/python-java/save-presentation/), všechny animační efekty a jejich pořadí jsou zachovány, protože jsou součástí nativního animačního modelu prezentace.

**Mohu načíst existující animace grafu z prezentace a upravit je?**

Ano. API poskytuje přístup k časové ose snímku, sekvencím a efektům, což umožňuje prozkoumat existující animace grafu a upravit je, aniž byste museli vše znovu vytvářet od začátku.

**Mohu vytvořit video, které zahrnuje animace grafu pomocí Aspose.Slides?**

Ano. Můžete [exportovat prezentaci do videa](/slides/cs/python-java/convert-powerpoint-to-video/), přičemž zachováte animace, nastavíte časování a další exportní nastavení, aby výsledný klip odrážel animované přehrávání.