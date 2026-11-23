---
title: Beheer diaovergangen in presentaties met C++
linktitle: Diaovergang
type: docs
weight: 80
url: /nl/cpp/slide-transition/
keywords:
- diaovergang
- diaovergang toevoegen
- diaovergang toepassen
- geavanceerde diaovergang
- morph‑overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Diaovergangen toepassen, automatische voortzetting van dia's configureren, en Morph en andere overgangseffecten aanpassen met Aspose.Slides voor C++."
---
## **Overzicht**

Diaovergangen bepalen hoe dia's verschijnen tijdens een diavoorstelling. Met Aspose.Slides for C++ kun je voor elke dia een overgangseffect kiezen, de voortgang per muisklik of timer configureren, en opties die specifiek zijn voor een effect aanpassen. Dit artikel gebruikt C++‑voorbeelden om overgangen toe te passen, exacte overgangsduren in te stellen, de timing van dia's te beheren en een Morph‑overgang tussen twee dia's te maken. De voorbeelden laten ook zien hoe je de instellingen opslaat in een PPTX‑bestand.

## **Diaovergang toevoegen**

Om een overgang toe te passen, laad je een presentatie met de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑klasse en krijg je toegang tot de overgangsinstellingen van een dia via [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Roep [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) aan met een waarde uit de [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/)‑enumeratie, en sla vervolgens de presentatie op.

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

## **Wielovergang**

De [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/)‑methode van [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) regelt het aantal radiale sectoren dat de doel-dia onthult. Roep [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) aan met Wheel uit [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) voordat je [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) benadert als [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/).

Dit voorbeeld maakt twee identieke paar dia's: een zwarte dia gevolgd door een dia met een gouden rechthoek. De doel-dia's gebruiken radiale aantallen van 1 en 8, met dezelfde snelheid ingesteld via [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) en een expliciete duur van 8.000 milliseconden ingesteld via [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) om het verschil duidelijk waarneembaar te maken.

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

Open de gegenereerde presentatie in PowerPoint en start de diavoorstelling. Ga van dia 1 naar dia 2, daarna van dia 3 naar dia 4. In PowerPoint‑afspelen onthult de gecontroleerde radiale teller van 1 de dia met één wijzerzin beweging; de gecontroleerde teller van 8 onthult de dia via acht radiale sectoren tegelijk. De doelinhoud en overgangstiming zijn identiek, dus het verschil zit in het aantal onthullingssectoren.

## **Fade door zwart met de Reveal‑overgang**

Stel het overgangstype van de doel-dia in op Reveal, roep vervolgens [set_ThroughBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/set_throughblack/) aan op de [IRevealTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/)‑interface. Het voorbeeld maakt een teal‑brondia en een koral‑doeldia, en kloont vervolgens beide zodat je dezelfde twee‑seconden‑overgang kunt vergelijken met de fade‑door‑zwart‑optie uitgeschakeld en ingeschakeld.

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

In een PowerPoint‑diavoorstelling ga je van dia 1 naar dia 2. Teal vervaagt direct in koral. Vervolgens ga je van dia 3 naar dia 4. Het scherm wordt kort donker tot bijna zwart voordat de koral‑dia verschijnt. Beide dia's behouden hun oorspronkelijke achtergrondkleuren.

De onderstaande rijen tonen frames uit PowerPoint met intervallen van een halve seconde. Vergelijk het middelframe in elke rij om het effect van de instelling te zien.

![PowerPoint‑weergave met ThroughBlack uitgeschakeld (boven) en ingeschakeld (onder). Alleen de onderste rij gaat door bijna zwart heen.](reveal-through-black.png)

## **Geavanceerde diaovergang toevoegen**

Je kunt configureren hoe lang een dia op het scherm blijft en of een muisklik de diavoorstelling voortzet. De volgende methoden regelen dit gedrag:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) stelt de kijker in staat om door te klikken met de muis.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) schakelt automatische voortzetting in.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) specificeert de vertraging vóór automatische voortzetting, in milliseconden.

Schakel zowel klik‑ als tijdsgebaseerde voortzetting in zodat de kijker kan doorgaan met een klik of wachten op de timer. Om alleen de timer te gebruiken, roep je [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) aan met `false`. De vertraging bepaalt wanneer de diavoorstelling wordt voortgezet; hij stelt niet de duur van het visuele overgangseffect in.

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

Om te controleren of tijdsgebaseerde voortzetting is ingeschakeld, roep je [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/) aan. Een opgeslagen vertraging alleen geeft niet aan dat de timer actief is.

Het volgende voorbeeld opent het hierboven opgeslagen bestand, meldt elke ingeschakelde timer, en schakelt automatische voortzetting uit voor dia's met een vertraging groter dan twee seconden. Het schakelt muisklikken in voor die dia's en slaat de bijgewerkte instellingen op.

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

Gebruik [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) om de exacte lengte van een overgangseffect in milliseconden op te geven. De [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/)‑methode van de dia maakt deze instellingen beschikbaar via [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/):

| Methode | Doel |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Stelt de vertraging in voordat de dia automatisch wordt voortgezet, in milliseconden. Roep [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) aan met `true` om deze timer te activeren. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | Selecteert een vooraf gedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium of Fast. Deze wordt gebruikt wanneer geen exacte duur is opgegeven. |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) regelt alleen het overgangseffect; het bepaalt niet hoe lang de dia zichtbaar blijft. Configureer de automatische voortzettingsvertraging afzonderlijk. Wanneer geen expliciete duur is ingesteld, bepaalt Aspose.Slides de effectduur aan de hand van het overgangstype en de waarde die [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) retourneert.

<!-- visual-explanation:slide-transition:start -->
[![Aparte balken geven de overgangsduur van 750 ms en de automatische voortzettingsinstelling van 5.000 ms weer.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Het gedeelde voorbeeld geeft elke dia een Fade‑overgang van 750 ms en schakelt afzonderlijk automatische voortzetting in na 5 000 ms. De overgangsduur regelt het effect; de voortzetting regelt wanneer de dia wordt verlaten. Deze balken zijn schematische instellingen, geen gemeten gecombineerde tijdlijn.*
<!-- visual-explanation:slide-transition:end -->

### **Dezelfde duur toepassen op elke dia**

Voor een consistente timing, pas je hetzelfde effect en dezelfde exacte duur toe op elke dia. Dit voorbeeld laadt `input.pptx`, selecteert Fade uit [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/), en geeft elke overgang een duur van 750 milliseconden. Het schakelt afzonderlijk automatische voortzetting in na 5.000 milliseconden en schakelt voortzetting per muisklik uit, en slaat vervolgens het resultaat op als PPTX.

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

### **Verschillende duur instellen voor individuele dia's**

Verschillende dia's kunnen verschillende duur van het effect hebben. Gebruik bijvoorbeeld een korte overgang voor een titel-dia en een langere overgang voor een sectie‑introductie. Dit voorbeeld stelt 500 milliseconden in voor de eerste dia en 1.200 milliseconden voor de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia's.

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

### **Overgangen coördineren met geanimeerde output**

Bij het voorbereiden van een [animated GIF](/slides/nl/cpp/convert-powerpoint-to-animated-gif/), [HTML5‑presentatie](/slides/nl/cpp/export-to-html5/), of [video](/slides/nl/cpp/convert-powerpoint-to-video/), stel je exacte overgangsduren in vóór export om de beoogde timing te matchen. Gebruik bijvoorbeeld een fade van 600 milliseconden tussen scènes, en pas de voortzettingsvertraging van elke dia apart aan om tijd te geven voor de bijbehorende voice‑over of inhoud.

Voor GIF en video, stem de output‑frame‑rate af op de effectduur: 600 milliseconden komt overeen met 18 frames bij 30 fps. In HTML5 schakel je geanimeerde overgangen in de exportinstellingen in. Controleer de ondersteunde effecten en timing‑opties van het gekozen exportformaat, en bekijk een voorbeeld van de output om de synchronisatie te bevestigen.

### **Bestaande overgangsduur lezen**

Roep [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) aan voordat je de overgang wijzigt om te bepalen of er een expliciete waarde is opgeslagen. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden aan. De niet‑ingestelde waarde is niet de berekende afspeelduur: Aspose.Slides gebruikt het overgangstype en de waarde die [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) retourneert om die duur te bepalen. Het instellen van een overgangstype kan een duur initialiseren, dus bekijk eerst de oorspronkelijke instellingen.

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

De Morph‑overgang animeert wijzigingen tussen objecten op opeenvolgende dia's. Om een eenvoudige Morph‑werking te maken, kloon je een dia, verplaats of wijzig je de grootte van een object op de kloon, en pas je de Morph‑overgang toe op de tweede dia. Hierdoor heeft de overgang de corresponderende objecten om te animeren tussen hun oorspronkelijke en gewijzigde staat.

Het volgende voorbeeld maakt een dia met een tekst‑rechthoek, kloont de dia, en verandert de positie en grootte van de rechthoek op de kloon. Vervolgens selecteert het Morph uit de [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/)‑enumeratie voor de tweede dia. Open het opgeslagen bestand in een presentatiewaarnemer die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

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

De [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/)‑enumeratie bepaalt hoe Morph content koppelt en animeert:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) behandelt elke vorm als één geheel.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door woorden te koppelen waar mogelijk.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door tekens te koppelen waar mogelijk.

Roep [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) aan met Morph voordat je [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) benadert. De verkregen waarde levert de [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/)‑interface, waarvan de [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/)‑methode de koppelingsmodus selecteert.

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

Sommige overgangen bieden extra opties, zoals richting of of het effect start vanaf een zwart scherm. De beschikbare opties hangen af van het gekozen overgangstype. Stel eerst het type in, en gebruik vervolgens de passende interface die door [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) wordt geretourneerd.

Het volgende voorbeeld past een Cut‑overgang toe op de eerste dia van `input.pptx`. Het roept [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) aan met `true` via [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) zodat de overgang start vanaf een zwart scherm.

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

**Kan ik de afspeelsnelheid van een diaovergang regelen?**

Ja. Gebruik [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) wanneer je een exacte effectduur in milliseconden nodig hebt. Gebruik [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) wanneer een vooraf gedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/)‑categorie — Slow, Medium of Fast — voldoende is en er geen expliciete duur is ingesteld. Deze instellingen regelen het overgangseffect onafhankelijk van de automatische voortzettingsvertraging.

**Kan ik audio aan een overgang koppelen en laten herhalen?**

Ja. Koppel ingesloten audio met [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/), roep [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) aan met StartSound uit de [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/)‑enumeratie, en schakel herhalen in met [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/). De audio blijft herhalen tot het volgende geluidsevent in de diavoorstelling.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Loop door de collectie die wordt geretourneerd door de [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/)‑methode van de presentatie en roep [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) aan met dezelfde waarde voor de overgang van elke dia. Stel eventuele timing‑ en effectopties in dezelfde lus in om het gedrag consistent te houden over alle dia's.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Roep [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) aan op de overgang die wordt geretourneerd door de [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/)‑methode van de dia. Het retourneert een waarde uit de [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/)‑enumeratie; None betekent dat er geen overgangseffect is toegepast.