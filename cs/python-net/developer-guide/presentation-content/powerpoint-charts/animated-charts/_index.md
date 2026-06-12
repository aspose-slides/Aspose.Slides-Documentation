---
title: Animujte grafy PowerPointu v Pythonu
linktitle: Animované grafy
type: docs
weight: 80
url: /cs/python-net/animated-charts/
keywords:
- graf
- animovaný graf
- animace grafu
- řada grafu
- kategorie grafu
- prvek řady
- prvek kategorie
- přidat efekt
- typ efektu
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vytvořte úchvatné animované grafy v Pythonu s Aspose.Slides. Zvyšte kvalitu prezentací pomocí dynamických vizuálů v souborech PPT, PPTX a ODP - zacnete hned."
---
## **Úvod**

Aspose.Slides for Python via .NET podporuje animaci prvků grafu. **Series**, **Categories**, **Series Elements**, **Categories Elements** lze animovat pomocí metody [ISequence.add_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/isequence/) a dvou výčtů [EffectChartMajorGroupingType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effectchartmajorgroupingtype/) a [EffectChartMinorGroupingType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effectchartminorgroupingtype/).

## **Animace řady grafu**
Pokud chcete animovat řadu grafu, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.  
1. Získejte odkaz na objekt grafu.  
1. Animujte řadu.  
1. Uložte soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali řadu grafu.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace 
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Získat odkaz na objekt grafu
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animovat řadu
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

    # Uložit upravenou prezentaci na disk 
    presentation.save("AnimatingSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animace kategorie grafu**
Pokud chcete animovat kategorii grafu, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.  
1. Získejte odkaz na objekt grafu.  
1. Animujte kategorii.  
1. Uložte soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali kategorii grafu.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Získat odkaz na objekt grafu
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animovat prvky kategorií
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

    # Uložit soubor prezentace na disk
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animace v elementu řady**
Pokud chcete animovat prvky řady, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.  
1. Získejte odkaz na objekt grafu.  
1. Animujte prvky řady.  
1. Uložte soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali prvky řady.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Načíst prezentaci
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Získat odkaz na objekt grafu
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animovat prvky řady
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

    # Uložit soubor prezentace na disk 
    presentation.save("AnimatingSeriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animace v elementu kategorie**
Pokud chcete animovat prvky kategorií, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.  
1. Získejte odkaz na objekt grafu.  
1. Animujte prvky kategorií.  
1. Uložte soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali prvky kategorií.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Získat odkaz na objekt grafu
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animovat prvky kategorií
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

    # Uložit soubor prezentace na disk
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jsou pro grafy podporovány různé typy efektů (např. vstupní, zvýrazňovací, výstupní) stejně jako pro běžné tvary?**

Ano. Graf je považován za tvar, takže podporuje standardní typy animačních efektů, včetně vstupních, zvýrazňovacích a výstupních, s plnou kontrolou pomocí časové osy snímku a animačních sekvencí.

**Mohu kombinovat animaci grafu s přechody snímků?**

Ano. [Transitions](/slides/cs/python-net/slide-transition/) se vztahují na snímek, zatímco animační efekty se vztahují na objekty na snímku. Oba můžete použít společně ve stejné prezentaci a ovládat je nezávisle.

**Zůstávají animace grafu zachovány při ukládání do PPTX?**

Ano. Když [save to PPTX](/slides/cs/python-net/save-presentation/), všechny animační efekty a jejich pořadí jsou zachovány, protože jsou součástí nativního animačního modelu prezentace.

**Mohu načíst existující animace grafu z prezentace a upravit je?**

Ano. [API](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/) poskytuje přístup k časové ose snímku, sekvencím a efektům, což vám umožní prozkoumat existující animace grafu a upravit je, aniž byste museli vše od začátku znovu vytvářet.

**Mohu vytvořit video, které zahrnuje animace grafu pomocí Aspose.Slides for Python via .NET?**

Ano. Můžete [export a presentation to video](/slides/cs/python-net/convert-powerpoint-to-video/) a zachovat animace, nakonfigurovat načasování a další nastavení exportu, aby výsledný klip odrážel animované přehrávání.