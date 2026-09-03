---
title: Beheer dia‑overgangen in presentaties met C++
linktitle: Dia‑overgang
type: docs
weight: 80
url: /nl/cpp/slide-transition/
keywords:
- dia‑overgang
- dia‑overgang toevoegen
- dia‑overgang toepassen
- geavanceerde dia‑overgang
- morph‑overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Dia‑overgangen toepassen, automatische voortzetting van dia's configureren en Morph‑ en andere overgangseffecten aanpassen met Aspose.Slides voor C++."
---
## **Overzicht**

Diavoorstellingsovergangen bepalen hoe dia's verschijnen tijdens een diavoorstelling. Met Aspose.Slides voor C++ kun je voor elke dia een overgangseffect kiezen, de voortgang via muisklik of timer configureren en opties die specifiek zijn voor een effect aanpassen. Dit artikel gebruikt C++‑voorbeelden om overgangen toe te passen, exacte overgangsduur in te stellen, de timing van dia's te beheren en een Morph‑overgang tussen twee dia's te maken. De voorbeelden laten ook zien hoe je de instellingen opslaat in een PPTX‑bestand.

## **Dia‑overgang toevoegen**

Om een overgang toe te passen, laad je een presentatie met de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse en krijg je via [get_SlideShowTransition](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) toegang tot de overgangsinstellingen van een dia. Roep [set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_type/) aan met een waarde uit de [TransitionType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/transitiontype/)-enumeratie, en sla vervolgens de presentatie op.

Het volgende voorbeeld past een Circle‑overgang toe op de eerste dia en een Comb‑overgang op de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia's.

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

## **Geavanceerde dia‑overgang toevoegen**

Je kunt configureren hoe lang een dia zichtbaar blijft en of een muisklik de diavoorstelling voortzet. De volgende methoden regelen dit gedrag:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) laat de kijker de presentatie voortzetten door te klikken.
- [set_AdvanceAfter](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_advanceafter/) schakelt automatische voortzetting in.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) specificeert de vertraging vóór automatische voortzetting, in milliseconden.

Schakel zowel klik‑ als timer‑voortzetting in zodat de kijker kan doorgaan met een klik of wachten op de timer. Om alleen de timer te gebruiken, roep je [set_AdvanceOnClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) aan met `false`. De vertraging bepaalt wanneer de diavoorstelling vooruitgaat; hij stelt de duur van het visuele overgangseffect niet in.

Dit voorbeeld kent verschillende effecten toe aan de eerste drie dia's en schakelt automatische voortzetting in na respectievelijk 3, 5 en 7 seconden. Muisklikken kunnen deze dia's ook voortzetten. Gebruik een `input.pptx`‑bestand met minstens drie dia's.

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

Om te controleren of timer‑voortzetting is ingeschakeld, roep je [get_AdvanceAfter](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/get_advanceafter/) aan. Een opgeslagen vertraging alleen geeft niet aan dat de timer actief is.

Het volgende voorbeeld opent het eerder opgeslagen bestand, meldt elke geactiveerde timer en schakelt automatische voortzetting uit voor dia's met een vertraging groter dan twee seconden. Het schakelt muisklikken voor die dia's in en slaat de bijgewerkte instellingen op.

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

## **Overgangstiming nauwkeurig regelen**

Gebruik [set_Duration](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_duration/) om de exacte lengte van een overgangseffect in milliseconden op te geven. De [get_SlideShowTransition](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslide/get_slideshowtransition/)-methode van de dia maakt deze instellingen beschikbaar via [ISlideShowTransition](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/):

| Methode | Doel |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_duration/) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Stelt de vertraging in voordat de dia automatisch wordt voortgezet, in milliseconden. Roep [set_AdvanceAfter](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_advanceafter/) aan met `true` om deze timer te activeren. |
| [set_Speed](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_speed/) | Selecteert een vooraf gedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium of Fast. Deze wordt gebruikt wanneer geen exacte duur is opgegeven. |

[set_Duration](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_duration/) regelt alleen het overgangseffect; hij bepaalt niet hoe lang de dia zichtbaar blijft. Stel de vertraging voor automatische voortzetting apart in. Wanneer geen expliciete duur is ingesteld, bepaalt Aspose.Slides de effectduur op basis van het overgangstype en de waarde die door [get_Speed](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/get_speed/) wordt geretourneerd.

### **Dezelfde duur toepassen op elke dia**

Voor een gelijkmatig tempo, pas je hetzelfde effect en dezelfde exacte duur toe op elke dia. Dit voorbeeld laadt `input.pptx`, selecteert Fade uit [TransitionType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/transitiontype/) en geeft elke overgang een duur van 750 milliseconden. Het schakelt bovendien automatische voortzetting in na 5.000 milliseconden en schakelt voortzetting via muisklik uit, waarna het resultaat als PPTX wordt opgeslagen.

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

    // Configureer automatische voortzetting onafhankelijk van de duur van het effect.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Verschillende duur voor individuele dia's instellen**

Verschillende dia's kunnen verschillende effectduren gebruiken. Bijvoorbeeld, een korte overgang voor een titeldia en een langere overgang voor een sectie‑introductie. Dit voorbeeld stelt 500 milliseconden in voor de eerste dia en 1.200 milliseconden voor de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia's.

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

### **Overgangen synchroniseren met geanimeerde uitvoer**

Bij het voorbereiden van een [animated GIF](/slides/nl/cpp/convert-powerpoint-to-animated-gif/), een [HTML5 presentation](/slides/nl/cpp/export-to-html5/) of een [video](/slides/nl/cpp/convert-powerpoint-to-video/), stel je exacte overgangsduren in vóór export om het beoogde tempo te behalen. Gebruik bijvoorbeeld een fade van 600 milliseconden tussen scènes en pas elke dia‑vervolgvertraging apart aan om tijd te geven voor de bijbehorende vertelling of inhoud.

Voor GIF en video, stem je de frame‑rate van de uitvoer af op de effectduur: 600 milliseconden komt overeen met 18 frames bij 30 fps. In HTML5 schakel je geanimeerde overgangen in de exportinstellingen in. Controleer de ondersteunde effecten en timingopties van het gekozen exportformaat en preview de uitvoer om synchronisatie te bevestigen.

### **Bestaande overgangsduur lezen**

Roep [get_Duration](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/get_duration/) aan vóór je de overgang wijzigt om te bepalen of er een expliciete waarde is opgeslagen. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden aan. De niet‑ingestelde waarde is niet de berekende afspeelduur: Aspose.Slides gebruikt het overgangstype en de waarde van [get_Speed](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/get_speed/) om die duur te bepalen. Het instellen van een overgangstype kan een duur initialiseren, dus inspecteer eerst de oorspronkelijke instellingen.

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

## **Morph‑overgang**

De Morph‑overgang animeert wijzigingen tussen objecten op opeenvolgende dia's. Om een eenvoudige Morph‑effect te creëren, kloon je een dia, verplaats of wijzig je de grootte van een object op de kloon, en pas je de Morph‑overgang toe op de tweede dia. Hierdoor krijgen de overeenkomstige objecten een animatie tussen hun oorspronkelijke en gewijzigde staat.

Het volgende voorbeeld maakt een dia met een tekstvak, kloont de dia en wijzigt de positie en afmeting van het tekstvak op de kloon. Vervolgens selecteert het Morph uit de [TransitionType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/transitiontype/)‑enumeratie voor de tweede dia. Open het opgeslagen bestand in een presentatie‑viewer die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

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

## **Morph‑overgangstypen**

De [TransitionMorphType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/transitionmorphtype/)‑enumeratie bepaalt hoe Morph inhoud overeenkomt en animeert:

- [ByObject](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/transitionmorphtype/) behandelt elke vorm als één geheel.
- [ByWord](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door woorden waar mogelijk te koppelen.
- [ByChar](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door karakters waar mogelijk te koppelen.

Roep [set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_type/) aan met Morph voordat je [get_Value](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/get_value/) benadert. De waarde levert vervolgens de [IMorphTransition](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/imorphtransition/)‑interface, waarvan de [set_MorphType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/)‑methode de overeenkomstige modus selecteert.

Dit voorbeeld opent de presentatie die in de vorige sectie is gemaakt en configureert de tweede dia om woordgebaseerde Morph‑animatie te gebruiken.

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

## **Overgangseffecten instellen**

Sommige overgangen bieden extra opties, zoals richting of of het effect start vanaf een zwart scherm. De beschikbare opties hangen af van het gekozen overgangstype. Stel eerst het type in en gebruik daarna de juiste interface die door [get_Value](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/get_value/) wordt geretourneerd.

Het volgende voorbeeld past een Cut‑overgang toe op de eerste dia van `input.pptx`. Het roept [set_FromBlack](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) aan met `true` via [IOptionalBlackTransition](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/ioptionalblacktransition/) zodat de overgang start vanaf een zwart scherm.

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

**Kan ik de afspeelsnelheid van een dia‑overgang regelen?**

Ja. Geef de voorkeur aan [set_Duration](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_duration/) wanneer je een exacte effectduur in milliseconden nodig hebt. Gebruik [set_Speed](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_speed/) wanneer een vooraf gedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/transitionspeed/)-categorie – Slow, Medium of Fast – voldoende is en er geen expliciete duur is ingesteld. Deze instellingen regelen het overgangseffect onafhankelijk van de vertraging voor automatische voortzetting.

**Kan ik audio aan een overgang koppelen en laten herhalen?**

Ja. Wijs ingesloten audio toe met [set_Sound](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_sound/), roep [set_SoundMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_soundmode/) aan met **StartSound** uit de [TransitionSoundMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/transitionsoundmode/)-enumeratie, en schakel herhaling in met [set_SoundLoop](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_soundloop/). Het geluid blijft herhalen tot het volgende geluids‑event in de diavoorstelling.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Loop door de collectie die wordt geretourneerd door de [get_Slides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_slides/)-methode van de presentatie en roep [set_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/set_type/) aan met dezelfde waarde voor de overgang van elke dia. Stel eventuele timing‑ en effectopties in dezelfde lus in om het gedrag consistent te houden over alle dia's.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Roep [get_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islideshowtransition/get_type/) aan op de overgang die wordt geretourneerd door de [get_SlideShowTransition](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslide/get_slideshowtransition/)-methode van de dia. Het retourneert een waarde uit de [TransitionType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.slideshow/transitiontype/)-enumeratie; **None** betekent dat er geen overgangseffect is toegepast.