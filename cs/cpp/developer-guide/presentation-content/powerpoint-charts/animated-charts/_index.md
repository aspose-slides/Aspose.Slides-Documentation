---
title: Animujte grafy PowerPoint v C++
linktitle: Animované grafy
type: docs
weight: 80
url: /cs/cpp/animated-charts/
keywords:
- graf
- animovaný graf
- animace grafu
- serie grafu
- kategorie grafu
- prvek řady
- prvek kategorie
- přidat efekt
- typ efektu
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Vytvořte úchvatné animované grafy v C++ s Aspose.Slides. Vylepšete prezentace dynamickými vizuály v souborech PPT a PPTX—začněte hned."
---
## **Úvod**

Aspose.Slides podporuje animaci prvků grafu. **Series**, **Categories**, **Series Elements**, **Categories Elements** lze animovat pomocí metody [ISequence::AddEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/addeffect/) a dvou výčtů [EffectChartMajorGroupingType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effectchartmajorgroupingtype/) a [EffectChartMinorGroupingType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effectchartminorgroupingtype/).

## **Animace řady grafu**
Pokud chcete animovat řadu grafu, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.
1. Získejte referenci na objekt grafu.
1. Animujte řadu.
1. Zapište soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali řadu grafu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animace v prvku řady**
Pokud chcete animovat prvky řady, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.
1. Získejte referenci na objekt grafu.
1. Animujte prvky řady.
1. Zapište soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali prvky řady.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **Animace kategorie grafu**
Pokud chcete animovat kategorii grafu, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.
1. Získejte referenci na objekt grafu.
1. Animujte kategorii.
1. Zapište soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali kategorii grafu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animace v prvku kategorie**
Pokud chcete animovat prvky kategorií, napište kód podle níže uvedených kroků:

1. Načtěte prezentaci.
1. Získejte referenci na objekt grafu.
1. Animujte prvky kategorií.
1. Zapište soubor prezentace na disk.

V níže uvedeném příkladu jsme animovali prvky kategorií.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **Často kladené dotazy**

**Jsou různé typy efektů (např. vstup, důraz, odchod) podporovány pro grafy stejně jako pro běžné tvary?**

Ano. Grafik je považován za tvar, takže podporuje standardní typy animačních efektů, včetně vstupu, důrazu a odchodu, s úplnou kontrolou prostřednictvím časové osy snímku a animačních sekvencí.

**Mohu kombinovat animaci grafu s přechody snímků?**

Ano. [Transitions](/slides/cs/cpp/slide-transition/) se aplikují na snímek, zatímco animační efekty se aplikují na objekty na snímku. Můžete oba použít společně v jedné prezentaci a ovládat je nezávisle.

**Zůstávají animace grafu zachovány při ukládání do formátu PPTX?**

Ano. Když [uložíte do PPTX](/slides/cs/cpp/save-presentation/), všechny animační efekty a jejich pořadí jsou zachovány, protože jsou součástí nativního animačního modelu prezentace.

**Mohu načíst existující animace grafu z prezentace a upravit je?**

Ano. [API](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/) poskytuje přístup k časové ose snímku, sekvencím a efektům, což vám umožní prozkoumat existující animace grafu a upravit je, aniž byste museli vše vytvářet od začátku.

**Mohu vytvořit video, které zahrnuje animace grafu pomocí Aspose.Slides?**

Ano. Můžete [exportovat prezentaci do videa](/slides/cs/cpp/convert-powerpoint-to-video/), přičemž zachováte animace, nakonfigurujete načasování a další nastavení exportu tak, aby výsledný klip odrážel animované přehrávání.