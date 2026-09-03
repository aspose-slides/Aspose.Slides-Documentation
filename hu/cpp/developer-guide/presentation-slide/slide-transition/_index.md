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
- speciális diaátmenet
- Morph áttűnés
- átmenet típusa
- átmenet hatása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Alkalmazzon diaátmeneteket, állítsa be az automatikus diaelőrehaladást, és testreszabja a Morph és egyéb átmeneti hatásokat az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

A diák átmenetei szabályozzák, hogyan jelennek meg a diák a diavetítés során. Az Aspose.Slides for C++ segítségével minden diához kiválaszthat egy áttűnési hatást, beállíthatja az előrehaladást egérkattintással vagy időzítővel, és módosíthatja a hatáshoz specifikus beállításokat. Ez a cikk C++ példákat használ az áttűnések alkalmazására, a pontos áttűnési időtartamok beállítására, a diák időzítésének kezelésére, valamint két dia közötti Morph áttűnés létrehozására. A példák bemutatják, hogyan menthetők a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

Az áttűnés alkalmazásához töltsön be egy prezentációt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztállyal, és érje el egy dia áttűnési beállításait a [get_SlideShowTransition](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) segítségével. Hívja meg a [set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_type/) metódust a [TransitionType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/transitiontype/) felsorolás egyik értékével, majd mentse a prezentációt.

A következő példa kör (Circle) áttűnést alkalmaz az első diára, és Comb áttűnést a másodikra. Használjon egy legalább két diával rendelkező `input.pptx` fájlt.

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

## **Speciális diaátmenet hozzáadása**

Beállíthatja, hogy egy dia mennyi ideig marad a képernyőn, és hogy egy egérkattintás előreviszi‑e a diavetítést. Az alábbi metódusok vezérlik ezt a viselkedést:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) a nézőnek lehetővé teszi, hogy az egér kattintásával lépjen tovább.
- [set_AdvanceAfter](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_advanceafter/) automatikus előrehaladást tesz lehetővé.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) megadja a késleltetést az automatikus előrehaladás előtt, ezredmásodpercben.

Engedélyezze mind a kattintást, mind az időzített előrehaladást, hogy a néző kattintással léphessen tovább, vagy várjon a számlálóra. Ha csak az időzítőt akarja használni, hívja a [set_AdvanceOnClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) metódust `false` értékkel. A késleltetés azt szabályozza, mikor lép előre a diavetítés; nem állítja be a vizuális áttűnési effektus időtartamát.

A következő példa különböző effektusokat rendeli az első három diához, és automatikus előrehaladást engedélyez 3, 5 és 7 másodperc után, illetve egérkattintással is előreviheti ezeket a diákot. Használjon egy legalább három diával rendelkező `input.pptx` fájlt.

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

A tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív. Ennek ellenőrzéséhez hívja a [get_AdvanceAfter](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/get_advanceafter/) metódust.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus előrehaladást azoknál a diák között, amelyeknek késleltetése nagyobb mint két másodperc. Ezekhez a diákhoz engedélyezi a kattintást, majd elmenti a módosított beállításokat.

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

## **Az áttűnés időzítésének pontos szabályozása**

Használja a [set_Duration](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_duration/) metódust, hogy pontosan megadja egy áttűnési effektus hosszát ezredmásodpercben. A dia [get_SlideShowTransition](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) metódusa ezeket a beállításokat a [ISlideShowTransition](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/) interfészen keresztül teszi elérhetővé:

| Módszer | Cél |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_duration/) | Beállítja az áttűnési effektus tényleges időtartamát ezredmásodpercben. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Beállítja a késleltetést, mielőtt a dia automatikusan továbblép, ezredmásodpercben. A [set_AdvanceAfter](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_advanceafter/) meghívásával `true` értékkel aktiválja a időzítőt. |
| [set_Speed](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_speed/) | Kiválaszt egy előre definiált sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium vagy Fast. Akkor használják, ha nincs pontos időtartam megadva. |

A [set_Duration](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_duration/) csak az áttűnési effektust szabályozza; nem határozza meg, mennyi ideig marad a dia látható. Az automatikus előrehaladási késleltetést külön kell beállítani. Ha nincs explicit időtartam megadva, az Aspose.Slides a hatás időtartamát a transition type‑ból és a [get_Speed](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/get_speed/) által visszaadott értékből számolja ki.

### **Ugyanannak az időtartamnak az alkalmazása minden diára**

Az egységes tempóért alkalmazzon ugyanazt a hatást és pontos időtartamot minden diára. Ez a példa betölti az `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/transitiontype/)‑ból a Fade‑et választja, és minden áttűnést 750 ms időtartammal állít be. Emellett automatikus előrehaladást 5 000 ms után engedélyez, letiltja a kattintási előrehaladást, és PPTX‑ként menti az eredményt.

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

    // Állítsa be az automatikus előrehaladást a hatás időtartamától függetlenül.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Különböző időtartamok beállítása egyedi diákhoz**

Különböző diák különböző effektus időtartamokat használhatnak. Például egy cím dia rövid áttűnés, egy szakasz bevezető dia hosszabb áttűnés. Ez a példa 500 ms‑t állít be az első diára, és 1 200 ms‑t a másodikra. Használjon egy legalább két diával rendelkező `input.pptx` fájlt.

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

### **Az áttűnések összehangolása animált kimenettel**

Amikor [animált GIF](/slides/hu/cpp/convert-powerpoint-to-animated-gif/), [HTML5 prezentáció](/slides/hu/cpp/export-to-html5/) vagy [videó](/slides/hu/cpp/convert-powerpoint-to-video/) készül, exportálás előtt állítsa be a pontos áttűnési időtartamokat a kívánt tempóhoz igazodva. Például használjon 600 ms‑es fade‑et a jelenetek között, és állítsa be minden dia előrehaladási késleltetését külön, hogy elegendő idő legyen a narrációnak vagy a tartalomnak.

GIF‑ és videó esetén a kimeneti képkockasebességet egyeztesse a hatás időtartamával: 600 ms 18 képkockát jelent 30 fps‑nél. HTML5‑ben engedélyezze az animált áttűnéseket az export beállításokban. Ellenőrizze a választott export formátum által támogatott effektusokat és időzítési lehetőségeket, majd tekintse meg az előnézetet a szinkronizáció megerősítéséhez.

## **Meglévő áttűnési időtartam beolvasása**

Módosítás előtt hívja a [get_Duration](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/get_duration/) metódust, hogy megállapítsa, tárolt‑e explicit érték. A `-1` érték azt jelenti, hogy nincs explicit időtartam beállítva; egy nem negatív érték a tárolt időtartamot jelzi ezredmásodpercben. A nem beállított érték nem a lejátszási idő, mivel az Aspose.Slides a transition type‑ból és a [get_Speed](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/get_speed/) visszatérési értékéből számolja ki. Egy transition type beállítása inicializálhat egy időtartamot, ezért előbb ellenőrizze az eredeti beállításokat.

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

## **Morph áttűnés**

A Morph áttűnés animálja az objektumok változását egymást követő diákon. Egy egyszerű Morph effektus létrehozásához másolja le a diát, mozdítsa vagy méretezze át az objektumot a másodikon, majd alkalmazza a Morph áttűnést a második diára. Így a kapcsolódó objektumok animálódnak az eredeti és a módosított állapot között.

A következő példa egy szöveges téglalappal ellátott diát hoz létre, lemásolja, majd a másodikon megváltoztatja a téglalap pozícióját és méretét. A [TransitionType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/transitiontype/) felsorolásból a Morph‑ot választja a második diához. Nyissa meg a mentett fájlt egy Morph‑ot támogató prezentációs nézőben, hogy lássa a hatást a diavetítés során.

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

## **Morph áttűnés típusok**

A [TransitionMorphType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/transitionmorphtype/) felsorolás határozza meg, hogy a Morph hogyan párosítja és animálja a tartalmat:

- [ByObject](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/transitionmorphtype/) minden alakzatot egész objektumként kezel.
- [ByWord](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/transitionmorphtype/) a szöveget szavak szerint animálja, ahol lehetséges.
- [ByChar](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/transitionmorphtype/) a szöveget karakterek szerint animálja, ahol lehetséges.

Hívja meg a [set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_type/) metódust Morph‑al, mielőtt hozzáférne a [get_Value](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/get_value/) metódushoz. Az érték ezután a [IMorphTransition](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/imorphtransition/) interfészt adja, amelynek a [set_MorphType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) metódusa választja ki a párosítási módot.

Ez a példa megnyitja az előző szakaszban létrehozott prezentációt, és a második diához szó‑alapú Morph animációt konfigurál.

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

## **Áttűnési hatások beállítása**

Néhány áttűnés további opciókat fed fel, például irányt vagy azt, hogy az effektus fekete képernyőn indul‑e. Az elérhető opciók a kiválasztott áttűnés típusától függenek. Először állítsa be a típust, majd használja a [get_Value](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/get_value/) által visszaadott megfelelő interfészt.

A következő példa a Cut áttűnést alkalmazza az `input.pptx` első diájára. A [IOptionalBlackTransition](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/ioptionalblacktransition/) interfészen keresztül a [set_FromBlack](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) metódust `true`‑ra állítja, hogy az áttűnés fekete képernyőről induljon.

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

**Vezérelhetem a diaátmenet lejátszási sebességét?**

Igen. Használja a [set_Duration](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_duration/) metódust, ha pontos effektus időtartamra van szüksége ezredmásodpercben. Használja a [set_Speed](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_speed/) metódust, ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/transitionspeed/) kategória (Slow, Medium vagy Fast) elegendő, és nincs explicit időtartam beállítva. Ezek a beállítások a áttűnési effektust szabályozzák, függetlenül az automatikus előrehaladási késleltetéstől.

**Csatolhatok hangot az áttűnéshez, és folyamatosan lejátszhatom?**

Igen. A beágyazott hangot a [set_Sound](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_sound/) metódussal adja meg, a [set_SoundMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_soundmode/)‑mal a [TransitionSoundMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/transitionsoundmode/) felsorolásból a StartSound értéket állítsa be, és a [set_SoundLoop](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_soundloop/)‑mal engedélyezze a hurok lejátszást. A hang a következő hangeseményig ismétlődik a diavetítésben.

**Mi a leggyorsabb módja annak, hogy ugyanazt az áttűnést alkalmazzam minden diára?**

Iteráljon végig a prezentáció [get_Slides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_slides/) metódusa által visszaadott gyűjteményen, és minden dia áttűnésére hívja meg a [set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/set_type/) metódust ugyanazzal az értékkel. Bármilyen időzítési és effektus opciót ugyanabban a ciklusban állítson be, hogy a viselkedés konzisztens maradjon a diák között.

**Hogyan ellenőrizhetem, hogy melyik áttűnés van jelenleg beállítva egy dián?**

Hívja a [get_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideshowtransition/get_type/) metódust a dia [get_SlideShowTransition](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) által visszaadott áttűnésen. Ez a [TransitionType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.slideshow/transitiontype/) felsorolás egy értékét adja vissza; a None azt jelenti, hogy nincs áttűnési effektus beállítva.