---
title: Spravovat přechody snímků v prezentacích pomocí C++
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/cpp/slide-transition/
keywords:
- přechod snímku
- přidání přechodu snímku
- použití přechodu snímku
- pokročilý přechod snímku
- Morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Aplikujte přechody snímků, nakonfigurujte automatické posouvání snímků a přizpůsobte Morph a další efekty přechodu pomocí Aspose.Slides pro C++."
---
## **Přehled**

Přechody snímků řídí, jak se snímky objevují během prezentace. S Aspose.Slides pro C++ můžete pro každý snímek vybrat efekt přechodu, nakonfigurovat přechod na kliknutí myší nebo časovač a upravit možnosti specifické pro konkrétní efekt. Tento článek používá příklady v C++ k aplikaci přechodů, nastavení přesné délky přechodu, správě časování snímků a vytvoření přechodu Morph mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidání přechodu snímku**

Chcete‑li použít přechod, načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) a přistupte k nastavení přechodu snímku prostřednictvím [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Zavolejte [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) s hodnotou z výčtu [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/), poté prezentaci uložte.

Následující příklad použije přechod Circle na první snímek a přechod Comb na druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Kolečkový přechod**

Metoda [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) rozhraní [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) určuje počet radiálních sektorů, které odhalují cílový snímek. Zavolejte [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) s hodnotou Wheel z [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) před přístupem k [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) jako [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/).

Tento příklad vytvoří dva identické páry snímků: černý snímek následovaný snímkem se zlatým obdélníkem. Cílové snímky použijí počty paprsků 1 a 8, se stejnou rychlostí nastavenou pomocí [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) a explicitní délkou 8 000 ms nastavenou pomocí [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) pro snadné pozorování rozdílu.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/IWheelTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <cstdint>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();
auto slideWidth = presentation->get_SlideSize()->get_Size().get_Width();
auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();

auto blackSlide = presentation->get_Slide(0);
blackSlide->get_Shapes()->Clear();
blackSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
blackSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
blackSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

auto destinationSlide = presentation->get_Slides()->AddClone(blackSlide);
auto rectangle = destinationSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, slideWidth, slideHeight);
rectangle->get_FillFormat()->set_FillType(FillType::Solid);
rectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gold());
rectangle->get_TextFrame()->set_Text(u"Wheel transition");

presentation->get_Slides()->AddClone(blackSlide);
presentation->get_Slides()->AddClone(destinationSlide);

const uint32_t spokeCounts[] = { 1, 8 };
for (auto i = 0; i < 2; i++)
{
    auto transition = presentation->get_Slide(i * 2 + 1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Wheel);
    auto wheelTransition = ExplicitCast<IWheelTransition>(transition->get_Value());
    wheelTransition->set_Spokes(spokeCounts[i]);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(8000);
}

presentation->Save(u"wheel-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Otevřete výstupní prezentaci v PowerPointu a spusťte prezentaci. Přecházejte ze snímku 1 na snímek 2, pak ze snímku 3 na snímek 4. V přehrávání PowerPointu se ověřený počet paprsků 1 projeví jedním hodinovým otáčením; ověřený počet 8 odhalí snímek osmi radiálními sektory najednou. Obsah cílových snímků a časování přechodu jsou identické, rozdíl je tedy jen v počtu odhalovacích sektorů.

## **Prolínání přes černou s odhalením**

Nastavte typ přechodu cílového snímku na Reveal a poté zavolejte [set_ThroughBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/set_throughblack/) na rozhraní [IRevealTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/). Příklad vytvoří světle tyrkysový zdrojový snímek a korálový cílový snímek, následně je oba zduplikuje, aby bylo možné porovnat dvousekundový přechod s vypnutým a zapnutým prolínáním přes černou.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/SlideShowTransition/IRevealTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionLeftRightDirectionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto styleSlide = [](SharedPtr<ISlide> slide, Color background, const String& label)
{
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
    auto fill = slide->get_Background()->get_FillFormat();
    fill->set_FillType(FillType::Solid);
    fill->get_SolidFillColor()->set_Color(background);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(label);
    textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_FontHeight(44);
};

auto presentation = MakeObject<Presentation>();

auto source = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddClone(source);
styleSlide(source, Color::get_Teal(), u"Source");
styleSlide(destination, Color::get_Coral(), u"Destination");
presentation->get_Slides()->AddClone(source);
presentation->get_Slides()->AddClone(destination);

for (auto index : {1, 3})
{
    auto transition = presentation->get_Slide(index)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Reveal);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(2000);

    auto reveal = ExplicitCast<IRevealTransition>(transition->get_Value());
    reveal->set_Direction(TransitionLeftRightDirectionType::Left);
    reveal->set_ThroughBlack(index == 3);
}

presentation->Save(u"reveal-transitions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

V PowerPointové prezentaci přejděte ze snímku 1 na snímek 2. Tyrkysová se přímo prolíná do korálové. Pak přejděte ze snímku 3 na snímek 4. Obrazovka se na okamžik ztmavne téměř na černo, než se objeví korálový snímek. Oba snímky si zachovají své původní barvy pozadí.

Níže uvedené řádky ukazují snímky z PowerPointu po půlsekundových intervalech. Porovnejte prostřední snímek v každém řádku, abyste viděli vliv nastavení.

![PowerPoint playback with ThroughBlack disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **Přidání pokročilého přechodu snímku**

Můžete nakonfigurovat, jak dlouho snímek zůstane na obrazovce a zda se prezentace posune kliknutím myši. Následující metody řídí toto chování:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) umožňuje divákovi posunout prezentaci kliknutím myši.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) zapíná automatický posun.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) určuje prodlevu před automatickým posunem v milisekundách.

Povolte oba způsoby posunu, aby divák mohl přejít kliknutím nebo počkat na časovač. Pokud chcete použít jen časovač, zavolejte [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) s hodnotou `false`. Prodleva určuje, kdy se prezentace posune; nenastavuje délku vizuálního efektu přechodu.

Tento příklad přiřadí prvnímu třem snímkům různé efekty a povolí automatický posun po 3, 5 a 7 sekundách. Na tyto snímky lze také přejít kliknutím. Použijte soubor `input.pptx` s alespoň třemi snímky.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

Pro kontrolu, zda je automatický posun povolen, zavolejte [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/). Uložena prodleva sama o sobě neznamená, že je časovač aktivní.

Další příklad otevře výše uložený soubor, nahlásí každý povolený časovač a zakáže automatický posun pro snímky s prodlevou delší než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Přesné řízení časování přechodu**

Použijte [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) k určení přesné délky efektu přechodu v milisekundách. Metoda snímku [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) poskytuje tato nastavení přes rozhraní [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/):

| Method | Účel |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | Nastaví délku samotného efektu přechodu v milisekundách. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Nastaví prodlevu před automatickým posunem snímku v milisekundách. Zavolejte [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) s hodnotou `true` pro aktivaci tohoto časovače. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | Vybere předdefinovanou kategorii rychlosti z [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium nebo Fast. Používá se, když není specifikována přesná délka. |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) ovlivňuje pouze efekt přechodu; neurčuje, jak dlouho snímek zůstane viditelný. Automatickou prodlevu posunu nastavte zvlášť. Když není nastavená explicitní délka, Aspose.Slides určuje délku efektu z typu přechodu a hodnoty vrácené metodou [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/).

<!-- visual-explanation:slide-transition:start -->
[![Oddělené pruhy identifikují dobu 750 ms trvání přechodu a nastavení automatického posunu 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Ukázkový příklad nastavení dává každému snímku 750 ms Fade přechod a samostatně povoluje automatický posun po 5 000 ms. Délka přechodu řídí efekt; posun určuje, kdy snímek opustit. Tyto pruhy jsou schematické nastavení, nikoli měřená kombinovaná časová osa.*
<!-- visual-explanation:slide-transition:end -->

### **Použití stejné délky pro každý snímek**

Pro konzistentní tempo použijte stejný efekt a přesnou délku pro všechny snímky. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) a každému přechodu přiřadí délku 750 ms. Samostatně povolí automatický posun po 5 000 ms a zakáže posun kliknutím, poté výsledek uloží jako PPTX.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // Nakonfigurujte automatický posun nezávisle na délce efektu.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Nastavení různých délek pro jednotlivé snímky**

Různé snímky mohou mít různé délky efektu. Například použijte krátký přechod pro úvodní snímek a delší přechod pro úvod sekce. Tento příklad nastaví 500 ms pro první snímek a 1 200 ms pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **Koordinace přechodů s animovaným výstupem**

Při přípravě [animated GIF](/slides/cs/cpp/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/cpp/export-to-html5/) nebo [video](/slides/cs/cpp/convert-powerpoint-to-video/) nastavte přesné délky přechodů před exportem, aby odpovídaly zamýšlenému tempu. Například použijte 600 ms fade mezi scénami a samostatně upravte prodlevu posunu každého snímku, aby byl dostatek času na jeho výklad nebo obsah.

Pro GIF a video koordinujte výstupní snímkovou frekvenci s délkou efektu: 600 ms odpovídá 18 snímkům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte, jaké efekty a časování jsou podporovány zvoleným formátem, a předběžně si výstup prohlédněte, abyste potvrdili synchronizaci.

### **Čtení existující délky přechodu**

Před úpravou přechodu zavolejte [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) a zjistěte, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že žádná explicitní délka není nastavena; nenegativní hodnota udává uloženou délku v milisekundách. Nenastavená hodnota není vypočtená doba přehrávání: Aspose.Slides používá typ přechodu a hodnotu vrácenou metodou [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) k určení této doby. Nastavení typu přechodu může inicializovat délku, proto nejprve prozkoumejte původní nastavení.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Morph přechod**

Morph přechod animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého Morph efektu duplikujte snímek, na duplikátu objekt přesuňte nebo změňte jeho velikost a aplikujte Morph přechod na druhý snímek. Tím získáte odpovídající objekty, které se animují mezi původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, duplikuje jej a změní pozici a velikost obdélníku na duplikátu. Poté pro druhý snímek vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který Morph podporuje, a podívejte se na efekt během prezentace.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Typy Morph přechodu**

Výčet [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) řídí, jak Morph přiřazuje a animuje obsah:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) zachází s každým tvarem jako s celým objektem.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) animuje text tak, že kde je to možné odpovídá slova.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) animuje text tak, že kde je to možné odpovídá znaky.

Zavolejte [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) s hodnotou Morph před přístupem k [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/). Vrácená hodnota poskytne rozhraní [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/), jehož metoda [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) vybírá režim přiřazení.

Tento příklad otevře prezentaci vytvořenou v předchozí sekci a nastaví druhý snímek tak, aby používal animaci Morph založenou na slovech.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Nastavení efektů přechodu**

Některé přechody nabízejí další možnosti, jako směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na vybraném typu přechodu. Nejprve nastavte typ, pak použijte odpovídající rozhraní vrácené metodou [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/).

Následující příklad použije přechod Cut na první snímek `input.pptx`. Zavolá [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) s hodnotou `true` přes rozhraní [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/), aby přechod začínal z černé obrazovky.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **Často kladené otázky**

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Upřednostněte [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/), když potřebujete přesnou délku efektu v milisekundách. Použijte [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/), když stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) – Slow, Medium nebo Fast – a není nastavena explicitní délka. Tato nastavení řídí efekt přechodu nezávisle na prodlevě automatického posunu.

**Mohu k přechodu připojit zvuk a nechat ho opakovat?**

Ano. Přiřaďte vložený zvuk pomocí [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/), zavolejte [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) s hodnotou StartSound z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/), a povolte opakování pomocí [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/). Zvuk se bude opakovat až do další zvukové události v prezentaci.

**Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na všechny snímky?**

Projděte kolekci vrácenou metodou [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) prezentace a pro každý snímek zavolejte [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) se stejnou hodnotou. V tomtéž cyklu nastavte případné časování a možnosti efektu, aby chování zůstalo konzistentní napříč snímky.

**Jak zjistím, který přechod je aktuálně nastaven na snímku?**

Zavolejte [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) na přechodu vráceném metodou [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) snímku. Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/); None znamená, že žádný přechod není aplikován.