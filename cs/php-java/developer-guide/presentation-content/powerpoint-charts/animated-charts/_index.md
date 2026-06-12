---
title: Animovat grafy PowerPoint v PHP
linktitle: Animované grafy
type: docs
weight: 80
url: /cs/php-java/animated-charts/
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
- PHP
- Aspose.Slides
description: "Vytvořte úchvatné animované grafy pomocí Aspose.Slides pro PHP přes Java. Posilte své prezentace dynamickými vizuály v souborech PPT a PPTX – začněte ještě dnes."
---
## **Úvod**

Aspose.Slides for PHP via Java podporuje animaci prvků grafu. **Series**, **Categories**, **Series Elements**, **Categories Elements** lze animovat pomocí metody [Sequence::addEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sequence/#addEffect) a dvou výčtů [EffectChartMajorGroupingType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/EffectChartMajorGroupingType) a [EffectChartMinorGroupingType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/EffectChartMinorGroupingType).

## **Animace řady grafu**
Pokud chcete animovat řadu grafu, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.
1. Získejte odkaz na objekt grafu.
1. Animujte řadu.
1. Uložte soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali řadu grafu.

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor prezentace
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Získejte odkaz na objekt grafu
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animujte řadu
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Uložte upravenou prezentaci na disk
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animace kategorie grafu**
Pokud chcete animovat kategorii grafu, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.
1. Získejte odkaz na objekt grafu.
1. Animujte kategorii.
1. Uložte soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali kategorii grafu.

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor prezentace
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

## **Animace v prvku řady**
Pokud chcete animovat prvky řady, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.
1. Získejte odkaz na objekt grafu.
1. Animujte prvky řady.
1. Uložte soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali prvky řady.

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor prezentace
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Získejte odkaz na objekt grafu
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animujte prvky řady
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
    # Uložte soubor prezentace na disk
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animace v prvku kategorie**
Pokud chcete animovat prvky kategorií, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.
1. Získejte odkaz na objekt grafu.
1. Animujte prvky kategorií.
1. Uložte soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali prvky kategorií.

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor prezentace
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Získejte odkaz na objekt grafu
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animujte prvky kategorií
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
    # Uložte soubor prezentace na disk
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Jsou pro grafy podporovány různé typy efektů (např. vstup, důraz, odchod) stejně jako pro běžné tvary?**

Ano. Graf je považován za tvar, takže podporuje standardní typy animačních efektů, včetně vstupu, důrazu a odchodu, s plnou kontrolou přes časovou osu snímku a animační sekvence.

**Mohu kombinovat animaci grafu s přechody snímků?**

Ano. [Transitions](/slides/cs/php-java/slide-transition/) se vztahují na snímek, zatímco animační efekty se vztahují na objekty na snímku. Obě lze použít současně v jedné prezentaci a ovládat je nezávisle.

**Zůstávají animace grafu zachovány při ukládání do PPTX?**

Ano. Když [uložíte do PPTX](/slides/cs/php-java/save-presentation/), všechny animační efekty a jejich pořadí jsou zachovány, protože jsou součástí nativního animačního modelu prezentace.

**Mohu načíst existující animace grafu z prezentace a upravit je?**

Ano. API poskytuje přístup k časové ose snímku, sekvencím a efektům, což vám umožní prozkoumat existující animace grafu a upravit je, aniž byste museli vše vytvářet od začátku.

**Mohu vytvořit video, které zahrnuje animace grafu pomocí Aspose.Slides?**

Ano. Můžete [exportovat prezentaci do videa](/slides/cs/php-java/convert-powerpoint-to-video/), přičemž zachováte animace, nastavíte načasování a další exportní parametry, aby výsledný klip odrážel animované přehrávání.