---
title: Správa přechodů snímků v prezentacích pomocí C++
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/cpp/slide-transition/
keywords:
- přechod snímku
- přidání přechodu snímku
- použití přechodu snímku
- pokročilý přechod snímku
- morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Objevte, jak přizpůsobit přechody snímků v Aspose.Slides pro C++ s podrobným návodem pro prezentace PowerPoint a OpenDocument."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat přechody snímků v prezentacích pomocí Aspose.Slides. Ukazuje, jak použít typy přechodů na snímky, nakonfigurovat chování přechodu, například postup při kliknutí nebo po uplynutí stanoveného času, zkontrolovat a zakázat automatický postup, použít Morph přechod a jeho typy a nastavit možnosti efektu přechodu. Příklady ukazují, jak načíst nebo vytvořit prezentaci, upravit nastavení přechodů pro vybrané snímky a uložit výsledek jako soubor PPTX. Článek také odpovídá na časté otázky o rychlosti přechodu, zvucích přechodu, použití stejných přechodů na více snímcích a kontrole přechodu aktuálně nastaveného na snímku.

## **Přidání přechodu snímku**
Pro snadnější pochopení jsme ilustrovali použití Aspose.Slides pro C++ k řízení jednoduchých přechodů snímků. Vývojáři mohou nejen použít různé efekty přechodů na snímcích, ale také přizpůsobit chování těchto efektů. Pro vytvoření jednoduchého efektu přechodu snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) .
1. Použijte typ přechodu snímku na snímku z jedněch z přechodových efektů nabízených Aspose.Slides pro C++ pomocí výčtu TransitionType.
1. Zapište upravený soubor prezentace.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Přidání pokročilého přechodu snímku**
V předchozí sekci jsme použili jednoduchý efekt přechodu na snímku. Nyní, aby byl tento jednoduchý efekt ještě lepší a řízenější, postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) .
1. Použijte typ přechodu snímku na snímku z jedněch z přechodových efektů nabízených Aspose.Slides pro C++.
1. Můžete také nastavit přechod tak, aby se posunul po kliknutí, po určité časové periodě nebo obojí.
1. Pokud je přechod snímku nastaven na posun po kliknutí, přechod se posune pouze po kliknutí myší. Navíc, pokud je nastavena vlastnost Advance After Time, přechod se automaticky posune po uplynutí stanoveného času.
1. Zapište upravenou prezentaci jako soubor prezentace.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Morph přechod**
Aspose.Slides pro C++ nyní podporuje Morph přechod. Jedná se o nový morph přechod zavedený v PowerPoint 2019. Morph přechod vám umožňuje plynule animovat přechod z jednoho snímku na další. Tento článek popisuje koncept a jak Morph přechod použít. Pro efektivní použití Morph přechodu potřebujete dva snímky, které mají alespoň jeden společný objekt. Nejjednodušší způsob je duplikovat snímek a poté přesunout objekt na druhém snímku na jiné místo.

Následující úryvek kódu ukazuje, jak do prezentace přidat klon snímku s nějakým textem a nastavit morph typ přechodu na druhém snímku.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Typy Morph přechodu**
Byl přidán nový výčet Aspose.Slides.SlideShow.TransitionMorphType. Reprezentuje různé typy Morph přechodu snímků.

Výčet TransitionMorphType má tři členy:

- ByObject: Morph přechod bude proveden s ohledem na tvary jako nedělitelné objekty.
- ByWord: Morph přechod bude proveden přenášením textu po slovech, kde je to možné.
- ByChar: Morph přechod bude proveden přenášením textu po znacích, kde je to možné.

Následující úryvek kódu ukazuje, jak nastavit morph přechod na snímek a změnit typ morph:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **Nastavení efektů přechodu**
Aspose.Slides pro C++ podporuje nastavení efektů přechodu, například z černé, zleva, zprava atd. Pro nastavení efektu přechodu postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy Presentation.
- Získejte referenci na snímek.
- Nastavte efekt přechodu.
- Uložte prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme nastavili efekty přechodu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **Často kladené otázky**

**Mohu ovládat rychlost přehrávání přechodu snímku?**

Ano. Nastavte [speed](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) přechodu pomocí nastavení [TransitionSpeed](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/transitionspeed/) (např. pomalá/střední/rychlá).

**Mohu k přechodu připojit zvuk a nastavit jeho opakování?**

Ano. Můžete vložit zvuk pro přechod a řídit chování pomocí nastavení, jako je režim zvuku a opakování (např. [set_Sound](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), plus metadata jako [set_SoundIsBuiltIn](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) a [set_SoundName](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)).

**Jaký je nejrychlejší způsob, jak použít stejný přechod na každý snímek?**

Nastavte požadovaný typ přechodu v nastavení přechodu každého snímku; přechody jsou uloženy pro každý snímek zvlášť, takže použití stejného typu na všechny snímky poskytne konzistentní výsledek.

**Jak mohu zjistit, který přechod je aktuálně nastaven na snímku?**

Prozkoumejte [transition settings](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseslide/get_slideshowtransition/) snímku a přečtěte jeho [transition type](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/slideshowtransition/get_type/); tato hodnota vám přesně řekne, který efekt je aplikován.