---
title: Animujte PowerPoint grafy v .NET
linktitle: Animované grafy
type: docs
weight: 80
url: /cs/net/animated-charts/
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
- .NET
- C#
- Aspose.Slides
description: "Vytvořte úchvatné animované grafy v .NET pomocí Aspose.Slides. Vylepšete prezentace dynamickými vizuály v souborech PPT a PPTX - začněte hned."
---
## **Úvod**

Aspose.Slides pro .NET podporuje animaci prvků grafu. **Series**, **Categories**, **Series Elements**, **Categories Elements** lze animovat pomocí metody [ISequence.AddEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/isequence/methods/addeffect) a dvou výčtových typů [EffectChartMajorGroupingType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effectchartmajorgroupingtype) a [EffectChartMinorGroupingType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effectchartminorgroupingtype).

## **Animace série grafu**
Pokud chcete animovat sérii grafu, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.
1. Získejte odkaz na objekt grafu.
1. Animujte sérii.
1. Napište soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali sérii grafu.

```c#
// Instancujte třídu Presentation, která představuje soubor prezentace 
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Získejte referenci na objekt grafu
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animujte sérii
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

    // Uložte upravenou prezentaci na disk 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```


## **Animace kategorie grafu**
Pokud chcete animovat kategorii grafu, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.
1. Získejte odkaz na objekt grafu.
1. Animujte kategorii.
1. Napište soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali kategorii grafu.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Získejte referenci na objekt grafu
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animujte prvky kategorií
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

    // Uložte soubor prezentace na disk
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **Animace v prvku série**
Pokud chcete animovat prvky sérií, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.
1. Získejte odkaz na objekt grafu.
1. Animujte prvky sérií.
1. Napište soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali prvky sérií.

```c#
// Načtěte prezentaci
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Získejte referenci na objekt grafu
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animujte prvky série
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.No
ne, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Uložte soubor prezentace na disk 
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **Animace v prvku kategorie**
Pokud chcete animovat prvky kategorií, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.
1. Získejte odkaz na objekt grafu.
1. Animujte prvky kategorií.
1. Napište soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali prvky kategorií.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Získejte referenci na objekt grafu
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animujte prvky kategorií
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

    // Uložte soubor prezentace na disk
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Jsou různé typy efektů (např. vstup, zdůraznění, ukončení) podporovány pro grafy stejně jako pro běžné tvary?**

Ano. Graf je považován za tvar, takže podporuje standardní typy animačních efektů, včetně vstupu, zdůraznění a ukončení, s plnou kontrolou přes časovou osu snímku a animační sekvence.

**Mohu kombinovat animaci grafu s přechody snímků?**

Ano. [Transitions](/slides/cs/net/slide-transition/) se vztahují na snímek, zatímco animační efekty se vztahují na objekty na snímku. Můžete je oba použít ve stejné prezentaci a ovládat je nezávisle.

**Zůstávají animace grafu zachovány při ukládání do PPTX?**

Ano. Když [uložit do PPTX](/slides/cs/net/save-presentation/), všechny animační efekty a jejich pořadí jsou zachovány, protože jsou součástí nativního animačního modelu prezentace.

**Mohu číst existující animace grafu z prezentace a upravovat je?**

Ano. [API](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/) poskytuje přístup k časové ose snímku, sekvencím a efektům, což vám umožní prozkoumat existující animace grafu a upravit je, aniž byste museli vše vytvořit znovu.

**Mohu pomocí Aspose.Slides vytvořit video, které zahrnuje animace grafu?**

Ano. Můžete [exportovat prezentaci do videa](/slides/cs/net/convert-powerpoint-to-video/), přičemž zachováte animace, nastavíte načasování a další exportní parametry, aby výsledný klip odrážel animované přehrávání.