---
title: Manage Slide Transitions in Presentations Using C++
linktitle: Slide Transition
type: docs
weight: 80
url: /cpp/slide-transition/
keywords:
- slide transition
- add slide transition
- apply slide transition
- advanced slide transition
- morph transition
- transition type
- transition effect
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Apply slide transitions, configure automatic slide advancement, and customize Morph and other transition effects with Aspose.Slides for C++."
---

## **Overview**

Slide transitions control how slides appear during a slide show. With Aspose.Slides for C++, you can choose a transition effect for each slide, configure advancement by mouse click or timer, and adjust options specific to an effect. This article uses C++ examples to apply transitions, set exact transition durations, manage slide timing, and create a Morph transition between two slides. The examples also show how to save the settings to a PPTX file.

## **Add Slide Transition**

To apply a transition, load a presentation with the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class and access a slide's transition settings through [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Call [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) with a value from the [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) enumeration, then save the presentation.

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

## **Add Advanced Slide Transition**

You can configure how long a slide remains on screen and whether a mouse click advances the slide show. The following methods control this behavior:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) allows the viewer to advance by clicking the mouse.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) enables automatic advancement.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) specifies the delay before automatic advancement, in milliseconds.

Enable both click and timed advancement to let the viewer move on with a click or wait for the timer. To use only the timer, call [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) with `false`. The delay controls when the slide show advances; it does not set the duration of the visual transition effect.

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

To check whether timed advancement is enabled, call [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/). A stored delay alone does not indicate that the timer is active.

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

## **Control Transition Timing Precisely**

Use [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) to specify the exact length of a transition effect in milliseconds. The slide's [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) method exposes these settings through [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/):

| Method | Purpose |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | Sets the duration of the transition effect itself, in milliseconds. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Sets the delay before the slide advances automatically, in milliseconds. Call [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) with `true` to activate this timer. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | Selects a predefined speed category from [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium, or Fast. It is used when an exact duration is not specified. |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) controls only the transition effect; it does not determine how long the slide remains visible. Configure the automatic advancement delay separately. When no explicit duration is set, Aspose.Slides determines the effect duration from the transition type and the value returned by [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/).

### **Apply the Same Duration to Every Slide**

For consistent pacing, apply the same effect and exact duration to every slide. This example loads `input.pptx`, selects Fade from [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/), and gives each transition a duration of 750 milliseconds. It separately enables automatic advancement after 5,000 milliseconds and disables advancement by mouse click, then saves the result as PPTX.

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

    // Configure automatic advancement independently of the effect duration.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Set Different Durations for Individual Slides**

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

### **Coordinate Transitions with Animated Output**

When preparing an [animated GIF](/slides/cpp/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cpp/export-to-html5/), or [video](/slides/cpp/convert-powerpoint-to-video/), set exact transition durations before export to match the intended pacing. For example, use a 600-millisecond fade between scenes, and adjust each slide's advancement delay separately to allow time for its narration or content.

For GIF and video, coordinate the output frame rate with the effect duration: 600 milliseconds corresponds to 18 frames at 30 frames per second. In HTML5, enable animated transitions in the export settings. Check the chosen export format's supported effects and timing options, and preview the output to confirm synchronization.

### **Read an Existing Transition Duration**

Call [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) before modifying the transition to determine whether an explicit value is stored. A value of `-1` means no explicit duration is set; a nonnegative value specifies the stored duration in milliseconds. The unset value is not the calculated playback duration: Aspose.Slides uses the transition type and the value returned by [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) to determine that duration. Setting a transition type can initialize a duration, so inspect the original settings first.

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

## **Morph Transition**

The Morph transition animates changes between objects on consecutive slides. To create a simple Morph effect, clone a slide, move or resize an object on the clone, and apply the Morph transition to the second slide. This gives the transition corresponding objects to animate between their original and modified states.

The following example creates a slide with a text rectangle, clones the slide, and changes the rectangle's position and size on the clone. It then selects Morph from the [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) enumeration for the second slide. Open the saved file in a presentation viewer that supports Morph to see the effect during a slide show.

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

## **Morph Transition Types**

The [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) enumeration controls how Morph matches and animates content:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) treats each shape as a whole object.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) animates text by matching words where possible.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) animates text by matching characters where possible.

Call [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) with Morph before accessing [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/). The value then provides the [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/) interface, whose [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) method selects the matching mode.

This example opens the presentation created in the previous section and configures the second slide to use word-based Morph animation.

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

## **Set Transition Effects**

Some transitions expose additional options, such as direction or whether the effect starts from a black screen. The available options depend on the selected transition type. Set the type first, then use the appropriate interface returned by [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/).

The following example applies a Cut transition to the first slide of `input.pptx`. It calls [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) with `true` through [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) so that the transition starts from a black screen.

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

**Can I control the playback speed of a slide transition?**

Yes. Prefer [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) when you need an exact effect duration in milliseconds. Use [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) when a predefined [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) category—Slow, Medium, or Fast—is sufficient and no explicit duration is set. These settings control the transition effect independently of the automatic advancement delay.

**Can I attach audio to a transition and make it loop?**

Yes. Assign embedded audio with [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/), call [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) with StartSound from the [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/) enumeration, and enable looping with [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/). The audio loops until the next sound event in the slide show.

**What's the fastest way to apply the same transition to every slide?**

Loop through the collection returned by the presentation's [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) method and call [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) with the same value for each slide's transition. Set any timing and effect options in the same loop to keep the behavior consistent across slides.

**How can I check which transition is currently set on a slide?**

Call [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) on the transition returned by the slide's [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) method. It returns a value from the [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) enumeration; None means that no transition effect is applied.
