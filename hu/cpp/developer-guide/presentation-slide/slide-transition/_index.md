---
title: Diátmenetek kezelése prezentációkban C++ használatával
linktitle: Diátmenet
type: docs
weight: 80
url: /hu/cpp/slide-transition/
keywords:
- diátmenet
- diátmenet hozzáadása
- diátmenet alkalmazása
- haladó diátmenet
- morph átmenet
- átmenettípus
- átmenet effektus
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Alkalmazzon diátmeneteket, állítson be automatikus diaváltást, és testreszabja a Morph és egyéb átmeneti effektusokat az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

A diaátmenetek szabályozzák, hogyan jelennek meg a diák egy diavetítés során. Az Aspose.Slides for C++ segítségével kiválaszthat egy átmenet‑effektet minden diára, beállíthatja a haladást egérkattintással vagy időzítővel, és testre szabhatja az effektusra jellemző beállításokat. Ez a cikk C++ példákkal mutatja be az átmenetek alkalmazását, pontos átmeneti időtartamok beállítását, diák időzítésének kezelését és a Morph átmenet létrehozását két dia között. A példák azt is bemutatják, hogyan menthetőek a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

Átmenet alkalmazásához töltse be a prezentációt a [Prezentáció](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztállyal, és érje el egy dia átmenet‑beállításait a [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) segítségével. Hívja meg a [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/)‑t a [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) felsorolt értékével, majd mentse a prezentációt.

Az alábbi példa a Circle átmenetet alkalmazza az első diára, a Comb átmenetet a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

## **Kerék átmenet**

Az [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) metódusa szabályozza a sugárirányú szektorok számát, amely a cél diát fedi fel. Hívja meg a [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/)‑t Wheel‑ként a [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/)‑ból, mielőtt elérné a [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/)‑t az [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/)‑n keresztül.

Ez a példa két azonos diapárt hoz létre: egy fekete diát, amelyet egy arany téglalappal ellátott dia követ. A cél diák 1 és 8 sugárszámot használnak, ugyanazzal a sebességgel, amelyet a [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) állít be, valamint egy explicite 8 000 ms [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) értékkel, hogy a különbség könnyen megfigyelhető legyen.

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

Nyissa meg a kimeneti prezentációt a PowerPointban, és indítsa el a diavetítést. Haladjon az 1. diákról a 2. diára, majd a 3. diákról a 4. diára. A PowerPoint lejátszásában az 1‑es sugárszám egy óramutató járásával megegyező körrel tárja fel a diát; a 8‑as szám nyolc sugárral egyidejűleg fedi fel. A cél tartalom és az átmenet időzítése azonos, így a különbség a felfedési szektorok száma.

## **Haladó diaátmenet hozzáadása**

Beállíthatja, hogy egy dia mennyi ideig marad a képernyőn, és hogy egérkattintás léptesse-e a diavetítést. A következő metódusok vezérlik ezt a viselkedést:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) lehetővé teszi a nézőnek, hogy kattintással léptessen.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) engedélyezi az automatikus haladást.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) adja meg az automatikus haladás késleltetését milliszekundumban.

Engedélyezze mind a kattintást, mind az időzített haladást, hogy a néző kattintással vagy a várakozással léphessen tovább. Ha csak az időzítőt szeretné használni, hívja meg a [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/)‑t `false` értékkel. A késleltetés azt szabályozza, mikor lép tovább a diavetítés; nem a vizuális átmenet hatásának időtartamát állítja be.

Ez a példa különböző effektusokat rendel az első három diához, és automatikus haladást állít be 3, 5 és 7 másodpercre, illetve lehetővé teszi a diák egérkattintással való előrehaladását. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

Az időzített haladás engedélyezésének ellenőrzéséhez hívja meg a [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/)‑t. Egy tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus haladást azoknál a diáknál, ahol a késleltetés nagyobb, mint két másodperc. Ezeknél a diáknál engedélyezi az egérkattintást, majd menti a módosított beállításokat.

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

## **Az átmeneti időzítés pontos szabályozása**

Használja a [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/)‑t, hogy pontosan megadja egy átmenet hatásának hosszat milliszekundumban. A dia [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) metódusa ezeket a beállításokat az [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/) interfészen keresztül teszi elérhetővé:

| Módszer | Cél |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | Beállítja magának az átmenet hatásnak a időtartamát milliszekundumban. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Beállítja a késleltetést, mielőtt a dia automatikusan továbbhaladna, milliszekundumban. Hívja a [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/)‑t `true`‑val a timer aktiválásához. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | Kiválaszt egy előre meghatározott sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/)‑ból: Slow, Medium vagy Fast. Akkor használatos, ha nincs megadva pontos időtartam. |

A [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) csak az átmeneti hatást szabályozza; nem határozza meg, mennyi ideig látható a dia. Az automatikus haladási késleltetést külön kell konfigurálni. Ha nincs explicite időtartam megadva, az Aspose.Slides a tranzíció típusából és a [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/)‑n visszaadott értékből számítja ki a hatás hosszát.

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **Ugyanazt az időtartamot alkalmazni minden diára**

A következetes tempó érdekében ugyanazt az effektust és pontos időtartamot állítsa be minden diához. Ez a példa betölti a `input.pptx`‑et, a [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/)-ból a Fade‑t választja, és minden átmenetnek 750 ms időtartamot ad. Külön engedélyezi az automatikus haladást 5 000 ms után, és letiltja a kattintással történő előrehaladást, majd PPTX‑ként menti az eredményt.

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

    // Állítsa be az automatikus előrehaladást az effektus időtartamától függetlenül.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Különböző időtartamok beállítása egyedi diákhoz**

Különböző diák eltérő effektus‑időtartamokat használhatnak. Például egy címdián rövid átmenetet, egy szekcióbevezetőnél hosszabbat alkalmazhat. Ez a példa 500 ms‑ot állít be az első diához, és 1 200 ms‑ot a másodikhoz. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

### **Átmenetek összehangolása animált kimenethez**

Amikor egy [animált GIF](/slides/hu/cpp/convert-powerpoint-to-animated-gif/)‑et, [HTML5 előadást](/slides/hu/cpp/export-to-html5/) vagy [videót](/slides/hu/cpp/convert-powerpoint-to-video/) készít, állítsa be a pontos átmeneti időtartamokat exportálás előtt, hogy a kívánt tempót tükrözzék. Például használjon 600 ms‑os elhalványulást a jelenetek között, és állítsa be minden dia haladási késleltetését külön, hogy elegendő idő legyen a narrációra vagy a tartalomra.

GIF‑hez és videóhoz a kimeneti képkockasebességet igazítsa az effektus időtartamához: 600 ms 18 képkockát jelent 30 fps‑nél. HTML5‑ben engedélyezze az animált átmeneteket az export beállításaiban. Ellenőrizze a kiválasztott exportformátum támogatott effektusait és időzítési lehetőségeit, és tekintse meg az előnézetet a szinkronizáció ellenőrzéséhez.

### **Meglévő átmeneti időtartam beolvasása**

A módosítás előtt hívja meg a [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/)‑t, hogy megállapítsa, tárolva van-e explicite érték. A `-1` érték azt jelenti, hogy nincs megadva konkrét időtartam; a nem negatív érték a tárolt időtartamot adja milliszekundumban. A nem beállított érték nem a lejátszási időt jelenti: az Aspose.Slides a tranzíció típusából és a [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) visszaadott értékből számítja ki. Egy tranzíció típusának beállítása inicializálhat időtartamot, ezért előbb ellenőrizze az eredeti beállításokat.

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

## **Morph átmenet**

A Morph átmenet animálja a tárgyak változását egymást követő diákon. Egy egyszerű Morph hatás létrehozásához klónozza a diát, módosítsa egy objektum helyzetét vagy méretét a klónon, és alkalmazza a Morph átmenetet a második diára. Így a megfelelő objektumok animálódnak az eredeti és a módosított állapot között.

Az alábbi példa egy szövegtéglalapot tartalmazó diát hoz létre, klónozza azt, majd a klónon megváltoztatja a téglalap pozícióját és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) felsorolt értékei közül a Morph‑ot választja a második diához. Nyissa meg a mentett fájlt egy olyan prezentációs nézőben, amely támogatja a Morph‑ot, hogy lássa a hatást a diavetítés során.

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

## **Morph átmenet típusok**

A [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) felsorolt értéke szabályozza, hogy a Morph milyen módon párosít és animálja a tartalmat:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) minden alakzatot egyetlen objektumként kezel.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) a szöveget szavak szerint párosítja, ahol lehetséges.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) a szöveget karakterek szerint párosítja, ahol lehetséges.

Hívja meg a [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/)‑t Morph‑ként, mielőtt hozzáférne a [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/)‑hez. Az érték ekkor egy [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/) interfészt ad, amelynek a [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) metódusa választja ki a párosítási módot.

Ez a példa megnyitja az előző szekcióban létrehozott prezentációt, és a második diát szó alapú Morph animációra állítja be.

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

## **Átmeneti effektusok beállítása**

Néhány átmenet további opciókat tesz elérhetővé, például irányt vagy azt, hogy a hatás fekete képernyőről induljon. Az elérhető opciók a kiválasztott átmenettípustól függenek. Először állítsa be a típust, majd használja a [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/)‑től kapott megfelelő interfészt.

Az alábbi példa egy Cut átmenetet alkalmaz az `input.pptx` első diájára. A [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) használatával a [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/)‑et `true`‑ra állítja, így az átmenet fekete képernyőről indul.

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

## **GYIK**

**Vezethető-e a diaátmenet lejátszási sebessége?**

Igen. Használja a [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/)‑t, ha pontos hatásidőt szeretne megadni milliszekundumban. Használja a [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/)‑t, ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) kategória – Slow, Medium vagy Fast – elegendő, és nincs explicite időtartam megadva. Ezek a beállítások az átmeneti hatást szabályozzák az automatikus haladás késleltetésétől függetlenül.

**Csatolható-e hang a átmenethez, és lehet-e ismételni?**

Igen. A beágyazott hangot a [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/) állítja be, ezután a [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/)‑t a [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/) felsorolt StartSound értékével, és a [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/) engedélyezi az ismétlést. A hang addig ismétlődik, amíg a diavetítésben nem következik egy újabb hangesemény.

**Mi a leggyorsabb módszer ugyanazon átmenet minden diára való alkalmazására?**

Iteráljon a prezentáció [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) metódusa által visszaadott gyűjteményen, és minden dia átmenetére hívja meg a [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/)‑t ugyanazzal az értékkel. A temporális és effektus beállításokat ugyanabban a ciklusban állítsa be, hogy a viselkedés minden dián konzisztens maradjon.

**Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?**

Hívja meg a [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/)‑t a dia [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) metódusa által visszaadott átmeneten. Ez egy [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) felsorolt értéket ad vissza; a None azt jelenti, hogy nincs átmenet‑effektus alkalmazva.