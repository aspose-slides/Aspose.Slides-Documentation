---
title: Správa přechodů snímků v prezentacích pomocí C++
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/cpp/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- použít přechod snímku
- pokročilý přechod snímku
- Morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Použijte přechody snímků, nastavte automatické postupování snímků a přizpůsobte Morph a jiné efekty přechodu pomocí Aspose.Slides pro C++."
---
## **Přehled**

Slide transitions control how slides appear during a slide show. With Aspose.Slides for C++, you can choose a transition effect for each slide, configure advancement by mouse click or timer, and adjust options specific to an effect. This article uses C++ examples to apply transitions, set exact transition durations, manage slide timing, and create a Morph transition between two slides. The examples also show how to save the settings to a PPTX file.

## **Přidat přechod snímku**

To apply a transition, load a presentation with the [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) class and access a slide's transition settings through [get_SlideShowTransition](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Call [set_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_type/) with a value from the [TransitionType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/transitiontype/) enumeration, then save the presentation.

The following example applies a Circle transition to the first slide and a Comb transition to the second. Use an `input.pptx` file with at least two slides.

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

## **Přidat pokročilý přechod snímku**

You can configure how long a slide remains on screen and whether a mouse click advances the slide show. The following methods control this behavior:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) umožňuje divákovi postupovat kliknutím myši.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_advanceafter/) povoluje automatické postupování.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) určuje prodlevu před automatickým postupem v milisekundách.

Enable both click and timed advancement to let the viewer move on with a click or wait for the timer. To use only the timer, call [set_AdvanceOnClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) with `false`. The delay controls when the slide show advances; it does not set the duration of the visual transition effect.

This example assigns different effects to the first three slides and enables automatic advancement after 3, 5, and 7 seconds, respectively. Mouse clicks can also advance these slides. Use an `input.pptx` file with at least three slides.

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
    secondTransition->set_AdvanceAfterTime(5

    );

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

To check whether timed advancement is enabled, call [get_AdvanceAfter](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/get_advanceafter/). A stored delay alone does not indicate that the timer is active.

The next example opens the file saved above, reports each enabled timer, and disables automatic advancement for slides with a delay greater than two seconds. It enables mouse clicks for those slides and saves the updated settings.

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

## **Přesně řídit načasování přechodu**

Use [set_Duration](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_duration/) to specify the exact length of a transition effect in milliseconds. The slide's [get_SlideShowTransition](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) method exposes these settings through [ISlideShowTransition](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/):

| Metoda | Účel |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_duration/) | Nastaví dobu trvání samotného efektu přechodu v milisekundách. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Nastaví prodlevu před automatickým posunem snímku v milisekundách. Zavolejte [set_AdvanceAfter](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_advanceafter/) s `true` pro aktivaci tohoto časovače. |
| [set_Speed](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_speed/) | Vybere předdefinovanou kategorii rychlosti z [TransitionSpeed](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium nebo Fast. Používá se, když není zadána přesná doba trvání. |

[set_Duration](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_duration/) řídí pouze efekt přechodu; neurčuje, jak dlouho snímek zůstane viditelný. Automatickou prodlevu pro postupování nastavte zvlášť. Když není nastavena explicitní doba trvání, Aspose.Slides určuje dobu trvání efektu podle typu přechodu a hodnoty vrácené metodou [get_Speed](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/get_speed/).

### **Použít stejnou dobu trvání na každý snímek**

For consistent pacing, apply the same effect and exact duration to every slide. This example loads `input.pptx`, selects Fade from [TransitionType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/transitiontype/), and gives each transition a duration of 750 milliseconds. It separately enables automatic advancement after 5,000 milliseconds and disables advancement by mouse click, then saves the result as PPTX.

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

    // Nastavte automatické postupování nezávisle na délce trvání efektu.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Nastavit různé doby trvání pro jednotlivé snímky**

Different slides can use different effect durations. For example, use a brief transition for a title slide and a longer transition for a section introduction. This example sets 500 milliseconds for the first slide and 1,200 milliseconds for the second. Use an `input.pptx` file with at least two slides.

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

### **Koordinovat přechody s animovaným výstupem**

When preparing an [animated GIF](/slides/cs/cpp/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/cpp/export-to-html5/), or [video](/slides/cs/cpp/convert-powerpoint-to-video/), set exact transition durations before export to match the intended pacing. For example, use a 600 millisecond fade between scenes, and adjust each slide's advancement delay separately to allow time for its narration or content.

U GIFu a videa koordinujte výstupní snímkovou frekvenci s dobou trvání efektu: 600 milliseconds corresponds to 18 frames at 30 frames per second. In HTML5, enable animated transitions in the export settings. Check the chosen export format's supported effects and timing options, and preview the output to confirm synchronization.

### **Načíst existující dobu trvání přechodu**

Call [get_Duration](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/get_duration/) before modifying the transition to determine whether an explicit value is stored. A value of `-1` means no explicit duration is set; a nonnegative value specifies the stored duration in milliseconds. The unset value is not the calculated playback duration: Aspose.Slides uses the transition type and the value returned by [get_Speed](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/get_speed/) to determine that duration. Setting a transition type can initialize a duration, so inspect the original settings first.

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

The Morph transition animates changes between objects on consecutive slides. To create a simple Morph effect, clone a slide, move or resize an object on the clone, and apply the Morph transition to the second slide. This gives the transition corresponding objects to animate between their original and modified states.

The following example creates a slide with a text rectangle, clones the slide, and changes the rectangle's position and size on the clone. It then selects Morph from the [TransitionType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/transitiontype/) enumeration for the second slide. Open the saved file in a presentation viewer that supports Morph to see the effect during a slide show.

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

The [TransitionMorphType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/transitionmorphtype/) enumeration controls how Morph matches and animates content:

- [ByObject](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/transitionmorphtype/) považuje každý tvar za celý objekt.
- [ByWord](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/transitionmorphtype/) animuje text přiřazováním slov, kde je to možné.
- [ByChar](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/transitionmorphtype/) animuje text přiřazováním znaků, kde je to možné.

Call [set_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_type/) with Morph before accessing [get_Value](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/get_value/). The value then provides the [IMorphTransition](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/imorphtransition/) interface, whose [set_MorphType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) method selects the matching mode.

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

## **Nastavit efekty přechodu**

Some transitions expose additional options, such as direction or whether the effect starts from a black screen. The available options depend on the selected transition type. Set the type first, then use the appropriate interface returned by [get_Value](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/get_value/).

The following example applies a Cut transition to the first slide of `input.pptx`. It calls [set_FromBlack](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) with `true` through [IOptionalBlackTransition](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/ioptionalblacktransition/) so that the transition starts from a black screen.

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

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Upřednostněte [set_Duration](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_duration/) když potřebujete přesnou dobu trvání efektu v milisekundách. Použijte [set_Speed](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_speed/) pokud stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium nebo Fast, a není nastavena explicitní doba trvání. Tato nastavení řídí efekt přechodu nezávisle na prodlevě automatického postupu.

**Mohu k přechodu přiřadit zvuk a nechat jej smyčkovat?**

Ano. Přiřaďte vložený zvuk pomocí [set_Sound](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_sound/), zavolejte [set_SoundMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_soundmode/) s hodnotou StartSound z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/transitionsoundmode/), a povolte smyčkování pomocí [set_SoundLoop](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_soundloop/). Zvuk bude opakován, dokud nenastane další zvuková událost v prezentaci.

**Jaký je nejrychlejší způsob, jak použít stejný přechod na každý snímek?**

Projděte smyčkou kolekci vrácenou metodou [get_Slides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_slides/) prezentace a pro každý snímek zavolejte [set_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/set_type/) se stejnou hodnotou. V téže smyčce nastavte veškeré časové a efektové možnosti, aby se chování napříč snímky udrželo konzistentní.

**Jak mohu zjistit, který přechod je aktuálně nastaven na snímku?**

Zavolejte [get_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideshowtransition/get_type/) na přechodu vráceném metodou [get_SlideShowTransition](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) snímku. Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.slideshow/transitiontype/); None znamená, že není aplikován žádný efekt přechodu.