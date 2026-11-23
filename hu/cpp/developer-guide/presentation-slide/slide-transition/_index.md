---
title: Diaátmenetek kezelése prezentációkban C++ használatával
linktitle: Diaátmenet
type: docs
weight: 80
url: /hu/cpp/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- haladó diaátmenet
- morph átmenet
- átmenet típusa
- átmeneti hatás
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Diaátmenetek alkalmazása, automatikus diák előrehaladásának beállítása, valamint a Morph és egyéb átmeneti hatások testreszabása az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

A diaátmenetek szabályozzák, hogyan jelennek meg a diák egy diavetítés során. Az Aspose.Slides for C++-val minden diára kiválaszthat egy átmeneti hatást, konfigurálhatja a haladást egérkattintással vagy időzítővel, és beállíthatja a hatáshoz specifikus opciókat. Ez a cikk C++ példákat használ az átmenetek alkalmazásához, a pontos átmeneti időtartamok beállításához, a diaidőzítés kezeléséhez, és egy Morph átmenet létrehozásához két dia között. A példák azt is bemutatják, hogyan lehet a beállításokat PPTX fájlba menteni.

## **Diaátmenet hozzáadása**

Az átmenet alkalmazásához töltse be a bemutatót a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztállyal, és a dia átmeneti beállításaihoz férjen hozzá a [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) metóduson keresztül. Hívja meg a [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) metódust a [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) felsorolásból származó értékkel, majd mentse a bemutatót.

A következő példa körkörös (Circle) átmenetet alkalmaz az első diára, és Comb átmenetet a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

A [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) metódus a [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) felületén szabályozza a sugárirányú szektorok számát, amelyek felfedik a cél diát. Hívja meg a [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) metódust a Wheel értékkel a [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) felsorolásból, mielőtt a [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) metódust [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) típusként hívná meg.

Ez a példa két azonos diapárt hoz létre: egy fekete diát, amelyet egy arany téglalapot tartalmazó dia követ. A cél diák 1 és 8 kerékpárna számot használnak, ugyanazzal a sebességgel, amelyet a [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) metódussal állítanak be, és egy 8 000 ezredmásodperces explicit időtartammal a [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) segítségével, hogy a különbség könnyen megfigyelhető legyen.

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

Nyissa meg a kimeneti prezentációt a PowerPointban, és indítsa el a diavetítést. Lépjen az 1. diáról a 2. diára, majd a 3. diáról a 4. diára. A PowerPoint lejátszásában az 1-es kerékpárna szám egy óramutató járásával megegyező körrel fed fel a diát; a 8-as szám nyolc sugárirányú szektorral egyszerre. A cél tartalom és az átmenet időzítése azonos, ezért a különbség a felfedő szektorok száma.

## **Feketénen keresztüli átmenet a Reveal átmenettel**

Állítsa be a cél dia átmenet típusát Reveal-re, majd hívja meg a [set_ThroughBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/set_throughblack/) metódust a [IRevealTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/) felületen. A példa egy türkiz forrásdiát és egy korall cél diát hoz létre, majd mindkettőt klónozza, így összehasonlíthatja ugyanazt a kétmásodperces átmenetet a feketénen keresztüli elhalványítás ki- és bekapcsolásával.

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

PowerPoint diavetítése során lépjen az 1. diáról a 2. diára. A türkiz közvetlenül a korallba halványul. Ezután lépjen a 3. diáról a 4. diára. A képernyő röviden majdnem feketévé válik, mielőtt a korall dia megjelenik. Mindkét dia megtartja eredeti háttérszínét.

Az alábbi sorok a PowerPoint képkockáit mutatják félmásodperces intervallumokban. Hasonlítsa össze minden sor középső képkockáját, hogy lássa a beállítás hatását.

![PowerPoint lejátszás ThroughBlack letiltva (felső) és engedélyezve (alsó). Csak az alsó sor halad közel feketén keresztül.](reveal-through-black.png)

## **Haladó diaátmenet hozzáadása**

Konfigurálhatja, mennyi ideig marad a dia a képernyőn, és hogy egy egérkattintás előreviszi-e a diavetítést. A következő módszerek szabályozzák ezt a viselkedést:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) lehetővé teszi, hogy a néző a kattintással lépjen tovább.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) engedi az automatikus előrehaladást.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) megadja a késleltetést az automatikus előrehaladás előtt, ezredmásodpercben.

Engedélyezze egyszerre a kattintást és az időzített előrehaladást, hogy a néző kattintással vagy a timerrel léphessen tovább. Ha csak a timert szeretné használni, hívja meg a [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) metódust `false` értékkel. A késleltetés szabályozza, mikor lép tovább a diavetítés; nem állítja be a vizuális átmenet effektus időtartamát.

Ez a példa különböző hatásokat rendel az első három diára, és automatikus előrehaladást engedélyez 3, 5 és 7 másodperc után, illetve a kattintás is előreléphet ezekkel a diákkal. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

A timed előrehaladás engedélyezését a [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/) metódussal ellenőrizheti. A tárolt késleltetés önmagában nem jelzi, hogy a timer aktív-e.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett timerről, és letiltja az automatikus előrehaladást azoknál a diáknál, amelyek késleltetése nagyobb mint két másodperc. Ezeknél a diáknál engedélyezi a kattintást, és elmenti a módosított beállításokat.

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

Használja a [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) metódust, hogy pontosan megadja egy átmeneti effektus hosszát ezredmásodpercben. A dia [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) metódusa ezeket a beállításokat a [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/) felületen keresztül teszi elérhetővé:

| Módszer | Cél |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | Beállítja az átmenet effektus időtartamát, ezredmásodpercben. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Beállítja a késleltetést, mielőtt a dia automatikusan előrehalad, ezredmásodpercben. Hívja meg a [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) metódust `true` értékkel a timer aktiválásához. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | Kiválaszt egy előre definiált sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) felsorolásból: Slow, Medium vagy Fast. Akkor használja, ha nincs megadva pontos időtartam. |

A [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) csak az átmeneti effektust szabályozza; nem határozza meg, mennyi ideig látható a dia. Az automatikus előrehaladási késleltetést külön kell konfigurálni. Ha nincs explicit időtartam beállítva, az Aspose.Slides a átmenet típusából és a [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) által visszaadott értékből határozza meg az effektus időtartamát.

<!-- visual-explanation:slide-transition:start -->
[![Különálló sávok mutatják a 750 ms átmeneti időtartamot és az 5 000 ms automatikus előrehaladási beállítást.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*A megosztott példa minden diához 750 ms Fade átmenetet ad, és külön engedélyezi az automatikus előrehaladást 5 000 ms-re. Az átmeneti időtartam az effektust szabályozza; az előrehaladás azt, mikor hagyja el a diát. Ezek a sávok vázlatos beállítások, nem egy mért kombinált idővonal.*
<!-- visual-explanation:slide-transition:end -->

### **Azonos időtartam alkalmazása minden diára**

A konzisztens tempó érdekében alkalmazza ugyanazt a hatást és pontos időtartamot minden diára. Ez a példa betölti a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) felsorolásából a Fade-et választja, és minden átmenetnek 750 ms időtartamot ad. Külön engedélyezi az automatikus előrehaladást 5 000 ms után, letiltja a kattintással történő előrehaladást, majd menti az eredményt PPTX formátumban.

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

### **Különböző időtartamok beállítása egyes diákhoz**

Az egyes diák különböző átmeneti időtartamokat használhatnak. Például egy cím diához rövid átmenetet, egy szekció bevezetőhöz hosszabb átmenetet lehet alkalmazni. Ez a példa 500 ms időtartamot állít be az első diára, és 1 200 ms-et a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

### **Átmenetek koordinálása animált kimenetben**

Animált [animált GIF](/slides/hu/cpp/convert-powerpoint-to-animated-gif/), [HTML5 prezentáció](/slides/hu/cpp/export-to-html5/) vagy [videó](/slides/hu/cpp/convert-powerpoint-to-video/) készítésekor állítsa be a pontos átmeneti időtartamokat exportálás előtt, hogy megfeleljenek a kívánt tempónak. Például használjon 600 ms-os fade-ot a jelenetek között, és minden dia előrehaladási késleltetését külön szabályozza, hogy elegendő idő legyen a narrációnak vagy a tartalomnak.

GIF és videó esetén hangolja össze a kimeneti képkockasebességet az effektus időtartamával: 600 ms 18 képkockának felel meg 30 fps-nél. HTML5-ben engedélyezze az animált átmeneteket az exportbeállításokban. Ellenőrizze a kiválasztott exportformátum támogatott hatásait és időzítési beállításait, és tekintse meg a kimenetet, hogy megbizonyosodjon a szinkronról.

### **Meglévő átmeneti időtartam beolvasása**

Hívja meg a [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) metódust az átmenet módosítása előtt, hogy meghatározza, tárolt-e explicit érték. A `-1` érték azt jelenti, hogy nincs explicit időtartam beállítva; egy nem negatív érték a tárolt ezredmásodpercben megadott időtartamot jelenti. A be nem állított érték nem az számított lejátszási idő: az Aspose.Slides a átmenet típusából és a [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) által visszaadott értékből határozza meg ezt az időtartamot. Egy átmenet típus beállítása inicializálhat egy időtartamot, ezért először vizsgálja meg az eredeti beállításokat.

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

A Morph átmenet animálja az objektumok változását egymást követő diákon. Egy egyszerű Morph effektus létrehozásához klónozzon egy diát, módosítsa vagy átméretezze egy objektumot a klónon, és alkalmazza a Morph átmenetet a második diára. Ez biztosítja, hogy az átmenet a megfelelő objektumok között animálja az eredeti és a módosított állapotot.

A következő példa egy szöveges téglalappal rendelkező diát hoz létre, klónozza a diát, és a klónon megváltoztatja a téglalap helyzetét és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) felsorolásból a Morph-ot választja a második diára. Nyissa meg a mentett fájlt egy olyan prezentációs nézőben, amely támogatja a Morph-ot, hogy lássa a hatást a diavetítés során.

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

A [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) felsorolás szabályozza, hogyan párosítja és animálja a Morph a tartalmat:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) az egyes alakzatokat egészként kezeli.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) a szöveget szavak alapján animálja, ahol lehetséges.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) a szöveget karakterek alapján animálja, ahol lehetséges.

Hívja meg a [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) metódust Morph értékkel, mielőtt a [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) metódust hívná. A visszakapott érték a [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/) felületet adja, amelynek a [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) metódusa választja ki a párosítási módot.

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

## **Átmeneti hatások beállítása**

Egyes átmenetek további opciókat tesznek elérhetővé, például irányt vagy azt, hogy az effektus fekete képernyőn indul-e. A rendelkezésre álló opciók a kiválasztott átmenet típustól függenek. Először állítsa be a típust, majd használja a [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) által visszaadott megfelelő felületet.

A következő példa egy Cut átmenetet alkalmaz a `input.pptx` első diájára. A [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) felületén keresztül meghívja a [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) metódust `true` értékkel, hogy az átmenet fekete képernyőn induljon.

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

**Kezelhetem a diaátmenet lejátszási sebességét?**

Igen. Használja a [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) metódust, ha pontos effektus időtartamot szeretne ezredmásodpercben megadni. Ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) kategória – Slow, Medium vagy Fast – elegendő, és nem állított be explicit időtartamot, használja a [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) metódust. Ezek a beállítások az átmeneti effektust szabályozzák az automatikus előrehaladási késleltetéstől függetlenül.

**Csatolhatok hangot az átmenethez, és ismételhetem?**

Igen. A [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/) metódussal állíthat be beágyazott hangot, a [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) metódussal a [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/) felsorolásból a StartSound értéket használja, és a [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/) metódussal engedélyezheti az ismétlést. A hang a következő hangeseményig ismétlődik a diavetítésben.

**Mi a leggyorsabb módja ugyanazon átmenet alkalmazásának minden diára?**

Iteráljon végig a prezentáció [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) metódusával visszaadott gyűjteményen, és minden dia átmenetére hívja meg a [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) metódust ugyanazzal az értékkel. A időzítési és effektus beállításokat ugyanabban a ciklusban állítsa be, hogy a viselkedés minden dián konzisztens legyen.

**Hogyan ellenőrizhetem, hogy melyik átmenet van beállítva egy dián?**

Hívja meg a [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) metódust a dia [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) által visszaadott átmeneten. Ez egy értéket ad vissza a [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) felsorolásból; a None érték azt jelenti, hogy nincs alkalmazva átmeneti hatás.