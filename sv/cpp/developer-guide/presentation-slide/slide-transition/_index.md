---
title: Hantera bildövergångar i presentationer med C++
linktitle: Bildövergång
type: docs
weight: 80
url: /sv/cpp/slide-transition/
keywords:
- bildövergång
- lägg till bildövergång
- applicera bildövergång
- avancerad bildövergång
- Morph‑övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Applicera bildövergångar, konfigurera automatisk bildavancering och anpassa Morph och andra övergångseffekter med Aspose.Slides för C++."
---
## **Översikt**

Bildövergångar styr hur bilder visas under en bildspelsvisning. Med Aspose.Slides för C++ kan du välja en övergångseffekt för varje bild, konfigurera avancerning via musklick eller timer och justera alternativ som är specifika för en effekt. Den här artikeln använder C++‑exempel för att applicera övergångar, ställa in exakta övergångslängder, hantera bildens tid och skapa en Morph‑övergång mellan två bilder. Exemplen visar också hur man sparar inställningarna till en PPTX‑fil.

## **Lägg till bildövergång**

För att applicera en övergång, läs in en presentation med klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) och nå en bilds övergångsinställningar via [get_SlideShowTransition](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Anropa [set_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_type/) med ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/transitiontype/), spara sedan presentationen.

Följande exempel applicerar en Circle‑övergång på den första bilden och en Comb‑övergång på den andra. Använd en `input.pptx`‑fil med minst två bilder.

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

## **Lägg till avancerad bildövergång**

Du kan konfigurera hur länge en bild visas på skärmen och huruvida ett musklick avancerar bildspelet. Följande metoder styr detta beteende:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) tillåter användaren att avancera genom att klicka med musen.
- [set_AdvanceAfter](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_advanceafter/) aktiverar automatisk avancerning.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) specificerar fördröjningen innan automatisk avancerning, i millisekunder.

Aktivera både klick‑ och tidsbaserad avancerning så att användaren kan gå vidare med ett klick eller vänta på timern. För att endast använda timern, anropa [set_AdvanceOnClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) med `false`. Fördröjningen styr när bildspelet avancerar; den ställer inte in varaktigheten för den visuella övergångseffekten.

Det här exemplet tilldelar olika effekter till de tre första bilderna och aktiverar automatisk avancerning efter 3, 5 respektive 7 sekunder. Mus‑klick kan också avancera dessa bilder. Använd en `input.pptx`‑fil med minst tre bilder.

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

För att kontrollera om tidsbaserad avancerning är aktiverad, anropa [get_AdvanceAfter](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/get_advanceafter/). En lagrad fördröjning ensam indikerar inte att timern är aktiv.

Nästa exempel öppnar filen som sparades ovan, rapporterar varje aktiverad timer och inaktiverar automatisk avancerning för bilder med en fördröjning längre än två sekunder. Det aktiverar mus‑klick för dessa bilder och sparar de uppdaterade inställningarna.

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

## **Styr övergångstiming exakt**

Använd [set_Duration](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_duration/) för att ange den exakta längden på en övergångseffekt i millisekunder. Bildens [get_SlideShowTransition](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslide/get_slideshowtransition/)‑metod visar dessa inställningar via [ISlideShowTransition](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/):

| Metod | Syfte |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_duration/) | Ställer in varaktigheten för själva övergångseffekten, i millisekunder. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Ställer in fördröjningen innan bilden avancerar automatiskt, i millisekunder. Anropa [set_AdvanceAfter](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_advanceafter/) med `true` för att aktivera denna timer. |
| [set_Speed](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_speed/) | Väljer en fördefinierad hastighetskategori från [TransitionSpeed](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium eller Fast. Den används när ingen exakt varaktighet har angetts. |

[set_Duration] styr endast övergångseffekten; den bestämmer inte hur länge bilden förblir synlig. Konfigurera den automatiska avanceringsfördröjningen separat. När ingen explicit varaktighet har angetts bestämmer Aspose.Slides effektens varaktighet utifrån övergångstypen och värdet som returneras av [get_Speed](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/get_speed/).

### **Applicera samma varaktighet på varje bild**

För ett jämnt tempo, applicera samma effekt och exakta varaktighet på varje bild. Detta exempel läser in `input.pptx`, väljer Fade från [TransitionType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/transitiontype/), och ger varje övergång en varaktighet på 750 millisekunder. Det aktiverar separat automatisk avancerning efter 5 000 millisekunder och inaktiverar avancerning via musklick, sparar sedan resultatet som PPTX.

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

    // Konfigurera automatisk avancering oberoende av effektens varaktighet.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Ange olika varaktigheter för enskilda bilder**

Olika bilder kan använda olika effektvaraktigheter. Till exempel kan du använda en kort övergång för en titelsida och en längre övergång för en sektionintroduktion. Detta exempel sätter 500 millisekunder för den första bilden och 1 200 millisekunder för den andra. Använd en `input.pptx`‑fil med minst två bilder.

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

### **Koordinera övergångar med animerad utdata**

När du förbereder en [animert GIF](/slides/sv/cpp/convert-powerpoint-to-animated-gif/), [HTML5‑presentation](/slides/sv/cpp/export-to-html5/) eller [video](/slides/sv/cpp/convert-powerpoint-to-video/), ange exakta övergångsvaraktigheter innan export för att matcha det avsedda tempot. Till exempel, använd en 600‑millisekunders fade mellan scener och justera varje bilds avanceringsfördröjning separat för att ge tid åt dess berättelse eller innehåll.

För GIF och video, koordinera utdata‑ramfrekvensen med effektens varaktighet: 600 millisekunder motsvarar 18 bildrutor vid 30 fps. I HTML5, aktivera animerade övergångar i exportinställningarna. Kontrollera vilka effekter och tidsalternativ som stöds i det valda exportformatet och förhandsgranska resultatet för att bekräfta synkronisering.

### **Läs en befintlig övergångsvaraktighet**

Anropa [get_Duration](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/get_duration/) innan du modifierar övergången för att avgöra om ett explicit värde är lagrat. Värdet `-1` betyder att ingen explicit varaktighet är angiven; ett icke‑negativt värde specificerar den lagrade varaktigheten i millisekunder. Det oinställda värdet är inte den beräknade uppspelningsvaraktigheten: Aspose.Slides använder övergångstypen och värdet som returneras av [get_Speed](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/get_speed/) för att bestämma den varaktigheten. Att ange en övergångstyp kan initiera en varaktighet, så inspektera de ursprungliga inställningarna först.

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

## **Morph‑övergång**

Morph‑övergången animerar förändringar mellan objekt på på varandra följande bilder. För att skapa en enkel Morph‑effekt, klona en bild, flytta eller ändra storlek på ett objekt på klonen och applicera Morph‑övergången på den andra bilden. Detta ger övergången motsvarande objekt att animera mellan deras ursprungliga och modifierade tillstånd.

Följande exempel skapar en bild med en textruta, klonar bilden och ändrar rektangelns position och storlek på klonen. Det väljer sedan Morph från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/transitiontype/) för den andra bilden. Öppna den sparade filen i en presentationsvisare som stödjer Morph för att se effekten under ett bildspel.

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

## **Morph‑övergångstyper**

Uppräkningen [TransitionMorphType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/transitionmorphtype/) styr hur Morph matchar och animerar innehåll:

- [ByObject](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/transitionmorphtype/) behandlar varje form som ett helt objekt.
- [ByWord](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/transitionmorphtype/) animera text genom att matcha ord där det är möjligt.
- [ByChar](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/transitionmorphtype/) animera text genom att matcha tecken där det är möjligt.

Anropa [set_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_type/) med Morph innan du får åtkomst till [get_Value](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/get_value/). Värdet ger sedan gränssnittet [IMorphTransition](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/imorphtransition/), vars [set_MorphType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) väljer matchningsläget.

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

## **Ange övergångseffekter**

Vissa övergångar exponerar ytterligare alternativ, såsom riktning eller om effekten startar från en svart skärm. Tillgängliga alternativ beror på den valda övergångstypen. Ställ in typen först, använd sedan det lämpliga gränssnittet som returneras av [get_Value](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/get_value/).

Följande exempel applicerar en Cut‑övergång på den första bilden i `input.pptx`. Det anropar [set_FromBlack](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) med `true` via [IOptionalBlackTransition](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/ioptionalblacktransition/) så att övergången startar från en svart skärm.

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

## **FAQ**

**Kan jag kontrollera uppspelningshastigheten för en bildövergång?**

Ja. Föredragsvis använd [set_Duration](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_duration/) när du behöver en exakt effektvaraktighet i millisekunder. Använd [set_Speed](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_speed/) när en fördefinierad [TransitionSpeed](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/transitionspeed/)‑kategori — Slow, Medium eller Fast — är tillräcklig och ingen explicit varaktighet har angetts. Dessa inställningar styr övergångseffekten oberoende av den automatiska avanceringsfördröjningen.

**Kan jag bifoga ljud till en övergång och få det att loopa?**

Ja. Tilldela inbäddat ljud med [set_Sound](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_sound/), anropa [set_SoundMode](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_soundmode/) med StartSound från uppräkningen [TransitionSoundMode](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/transitionsoundmode/), och aktivera loopning med [set_SoundLoop](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_soundloop/). Ljudet loopas tills nästa ljudhändelse i bildspelet.

**Vad är det snabbaste sättet att applicera samma övergång på varje bild?**

Loopa igenom samlingen som returneras av presentationens [get_Slides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_slides/)‑metod och anropa [set_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/set_type/) med samma värde för varje bilds övergång. Ställ in eventuella timing‑ och effektalternativ i samma loop för att hålla beteendet enhetligt över bilderna.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Anropa [get_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islideshowtransition/get_type/) på övergången som returneras av bildens [get_SlideShowTransition](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslide/get_slideshowtransition/)‑metod. Den returnerar ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.slideshow/transitiontype/); None betyder att ingen övergångseffekt har applicerats.