---
title: Apply Shape Animations in Presentations Using C++
linktitle: Shape Animation
type: docs
weight: 60
url: /cpp/shape-animation/
keywords:
- shape
- animation
- effect
- animated shape
- animated text
- add animation
- get animation
- extract animation
- add effect
- get effect
- extract effect
- effect sound
- apply animation
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Learn how to add, inspect, and customize shape animations, timing, sounds, after-animation behavior, and animated text with Aspose.Slides for C++."
---

## **Overview**

Aspose.Slides for C++ represents slide animations as effects in a slide timeline. An effect has a target shape, an animation type and subtype, a trigger, timing settings, and optional properties such as sound or after-animation behavior.

The timeline contains two kinds of sequences:

- The **main sequence** plays as the slide advances.
- An **interactive sequence** starts when its trigger shape is clicked.

Because text boxes, pictures, charts, tables, and other slide objects implement [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), you use the same [ISequence::AddEffect](https://reference.aspose.com/slides/cpp/aspose.slides.animation/isequence/addeffect/) method for most slide content. The available effects are listed in the [EffectType](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effecttype/) enumeration.

## **Add Shape Animations**

To add an animation, get the slide's main sequence and call [ISequence::AddEffect](https://reference.aspose.com/slides/cpp/aspose.slides.animation/isequence/addeffect/) with the target shape, effect type, subtype, and trigger. For an effect that starts when another shape is clicked, create an interactive sequence whose trigger is that other shape.

The following example creates both types of animation and saves the result to `shape-animations.pptx`.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto targetShape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 120.0f, 100.0f, 320.0f, 80.0f);
targetShape->get_TextFrame()->set_Text(u"Click to animate this shape");

auto mainSequence = slide->get_Timeline()->get_MainSequence();
auto entranceEffect = mainSequence->AddEffect(targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
entranceEffect->get_Timing()->set_Duration(1.5f);

auto triggerShape = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 20.0f, 20.0f, 100.0f, 40.0f);
triggerShape->get_TextFrame()->set_Text(u"Move");

auto interactiveSequence = slide->get_Timeline()->get_InteractiveSequences()->Add(triggerShape);
interactiveSequence->AddEffect(targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

presentation->Save(u"shape-animations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The trigger controls when an effect starts:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effecttriggertype/) waits for a click in the main sequence, or for a click on the trigger shape in an interactive sequence.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effecttriggertype/) starts with the preceding effect.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effecttriggertype/) starts when the preceding effect finishes.

To animate a picture, chart, or another shape type, pass that object to [ISequence::AddEffect](https://reference.aspose.com/slides/cpp/aspose.slides.animation/isequence/addeffect/) instead of `targetShape`. For chart-specific grouping options, see [Animated Charts](/slides/cpp/animated-charts/).

## **Read Shape Animations**

Use [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) when you know the target shape. To inspect every effect, enumerate the main sequence and every interactive sequence. Enumeration avoids assuming that a sequence contains an effect at index `0`.

The following example creates a shape with main-sequence and interactive effects, gets the effects that target the shape, and then enumerates every sequence on the slide.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto printSequence = [](const String& label, const SharedPtr<ISequence>& sequence)
{
    Console::WriteLine(String::Format(u"  {0}: {1} effect(s)", label, sequence->get_Count()));

    for (const auto& effect : sequence)
    {
        auto targetName = effect->get_TargetShape() == nullptr ? u"unknown" : effect->get_TargetShape()->get_Name();
        auto effectDescription = String::Format(u"{0} {1}; target: {2}; trigger: {3}", effect->get_Type(), effect->get_Subtype(), targetName, effect->get_Timing()->get_TriggerType());
        Console::WriteLine(u"    " + effectDescription);
    }
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto targetShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
targetShape->get_TextFrame()->set_Text(u"Animated shape");

auto mainSequence = slide->get_Timeline()->get_MainSequence();
mainSequence->AddEffect(targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

auto triggerShape = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 20.0f, 20.0f, 100.0f, 40.0f);
triggerShape->get_TextFrame()->set_Text(u"Move");

auto interactiveSequence = slide->get_Timeline()->get_InteractiveSequences()->Add(triggerShape);
interactiveSequence->AddEffect(targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

auto targetEffects = mainSequence->GetEffectsByShape(targetShape);
Console::WriteLine(String::Format(u"The main sequence contains {0} effect(s) for {1}.", targetEffects->get_Length(), targetShape->get_Name()));

printSequence(u"Main sequence", mainSequence);

int32_t interactiveIndex = 1;
for (const auto& sequence : slide->get_Timeline()->get_InteractiveSequences())
{
    auto triggerName = sequence->get_TriggerShape() == nullptr ? u"unknown" : sequence->get_TriggerShape()->get_Name();
    auto sequenceLabel = String::Format(u"Interactive sequence {0}, trigger: {1}", interactiveIndex, triggerName);
    printSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

presentation->Dispose();
```

If you only need the effects for one shape, first identify the shape by name, placeholder type, or another stable property; then call [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/cpp/aspose.slides.animation/isequence/geteffectsbyshape/). Do not assume that [IShapeCollection::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/idx_get/) at index `0` is always the intended object.

## **Work with Inherited Placeholder Effects**

A placeholder on a normal slide can inherit animation behavior from the corresponding placeholder on its layout slide and master slide. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) returns that parent placeholder, or `nullptr` when no parent exists.

In the following example presentation, the footer has **Random Bars** on the normal slide, **Split** on the layout slide, and **Fly In** on the master slide.

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

The next example builds the placeholder hierarchy itself. It adds effects to a master placeholder, a layout placeholder, and the corresponding placeholder on a normal slide. Every call to [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) is checked before the returned shape is used.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto findPlaceholderWithBase = [](const SharedPtr<ISlide>& slide) -> SharedPtr<IShape>
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (shape->GetBasePlaceholder() != nullptr)
            return shape;
    }

    return nullptr;
};

auto printEffects = [](const String& source, const ArrayPtr<SharedPtr<IEffect>>& effects)
{
    Console::WriteLine(String::Format(u"{0}: {1} effect(s)", source, effects->get_Length()));

    for (const auto& effect : effects)
        Console::WriteLine(String::Format(u"  {0} {1}", effect->get_Type(), effect->get_Subtype()));
};

auto presentation = MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto layoutPlaceholder = layoutSlide->get_PlaceholderManager()->AddTextPlaceholder(100.0f, 100.0f, 400.0f, 80.0f);
layoutSlide->get_Timeline()->get_MainSequence()->AddEffect(layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
if (masterPlaceholder != nullptr)
{
    auto masterSequence = layoutSlide->get_MasterSlide()->get_Timeline()->get_MainSequence();
    masterSequence->AddEffect(masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
}

auto slide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto slidePlaceholder = findPlaceholderWithBase(slide);

if (slidePlaceholder == nullptr)
    throw InvalidOperationException(u"The slide does not contain a placeholder linked to its layout slide.");

slide->get_Timeline()->get_MainSequence()->AddEffect(slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
printEffects(u"Normal slide", slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(slidePlaceholder));

auto baseLayoutPlaceholder = slidePlaceholder->GetBasePlaceholder();
if (baseLayoutPlaceholder != nullptr)
{
    printEffects(u"Layout slide", layoutSlide->get_Timeline()->get_MainSequence()->GetEffectsByShape(baseLayoutPlaceholder));

    auto baseMasterPlaceholder = baseLayoutPlaceholder->GetBasePlaceholder();
    if (baseMasterPlaceholder != nullptr)
        printEffects(u"Master slide", layoutSlide->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(baseMasterPlaceholder));
}

presentation->Save(u"placeholder-animations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Change Animation Timing**

The PowerPoint **Timing** dialog maps to the methods of [ITiming](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itiming/).

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** maps to [ITiming::set_TriggerType](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itiming/set_triggertype/).
- **Duration** maps to [ITiming::set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itiming/set_duration/), in seconds.
- **Delay** maps to [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/), in seconds.
- **Repeat** maps to [ITiming::set_RepeatCount](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/), or [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/).
- **Rewind when done playing** maps to [ITiming::set_Rewind](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itiming/set_rewind/).

This independent example adds an effect, changes its timing through the object returned by [ISequence::AddEffect](https://reference.aspose.com/slides/cpp/aspose.slides.animation/isequence/addeffect/), and saves the result. Keeping the returned [IEffect](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/) reference avoids an unnecessary collection index.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Timed animation");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Timing()->set_TriggerType(EffectTriggerType::OnClick);
effect->get_Timing()->set_Duration(2.0f);
effect->get_Timing()->set_TriggerDelayTime(0.5f);
effect->get_Timing()->set_RepeatUntilNextClick(false);
effect->get_Timing()->set_RepeatUntilEndSlide(false);
effect->get_Timing()->set_RepeatCount(2.0f);
effect->get_Timing()->set_Rewind(true);

presentation->Save(u"shape-animation-timing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Use one repeat mode intentionally. Combining a repeat count with an "until" flag can produce confusing results in different viewers. When changing repeat modes, call [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) and [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) before [ITiming::set_RepeatCount](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itiming/set_repeatcount/), because setting either flag also changes the active repeat mode.

## **Add and Extract Animation Sounds**

An animation effect can reference embedded audio through [IEffect::set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_sound/). [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) tells an effect to stop audio started by an earlier effect.

### **Add a Sound to an Effect**

The following example expects a local audio file named `animation-sound.wav`. It creates two effects, embeds that file as the sound for the first effect, and configures the second effect to stop the sound. It uses the objects returned by [ISequence::AddEffect](https://reference.aspose.com/slides/cpp/aspose.slides.animation/isequence/addeffect/), so no sequence index is required.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80.0f, 100.0f, 240.0f, 80.0f);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 400.0f, 100.0f, 240.0f, 80.0f);
firstShape->get_TextFrame()->set_Text(u"Starts sound");
secondShape->get_TextFrame()->set_Text(u"Stops sound");

auto sequence = slide->get_Timeline()->get_MainSequence();
auto firstEffect = sequence->AddEffect(firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
auto secondEffect = sequence->AddEffect(secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

auto audioData = File::ReadAllBytes(u"animation-sound.wav");
auto effectSound = presentation->get_Audios()->AddAudio(audioData);
firstEffect->set_Sound(effectSound);
secondEffect->set_StopPreviousSound(true);

presentation->Save(u"shape-animation-sound.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Extract Embedded Effect Sounds**

The following example expects a local presentation named `presentation-with-animation-sounds.pptx`. It scans both main and interactive sequences and writes every embedded effect sound to the `extracted-animation-sounds` directory. The extension is selected from the audio MIME type exposed by [IAudio::get_ContentType](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_contenttype/).

```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::IO;

auto getAudioExtension = [](const String& contentType)
{
    auto normalizedType = String::IsNullOrEmpty(contentType) ? String::Empty : contentType.ToLowerInvariant();

    if (normalizedType == u"audio/mpeg")
        return String(u".mp3");

    if (normalizedType == u"audio/mp4")
        return String(u".m4a");

    if (normalizedType == u"audio/ogg")
        return String(u".ogg");

    if (normalizedType == u"audio/wav" || normalizedType == u"audio/x-wav")
        return String(u".wav");

    return String(u".bin");
};

auto saveSounds = [&getAudioExtension](const SharedPtr<ISequence>& sequence, const String& outputDirectory, int32_t& soundIndex)
{
    for (const auto& effect : sequence)
    {
        if (effect->get_Sound() == nullptr)
            continue;

        auto extension = getAudioExtension(effect->get_Sound()->get_ContentType());
        auto outputPath = Path::Combine(outputDirectory, String::Format(u"effect-sound-{0}{1}", soundIndex, extension));
        File::WriteAllBytes(outputPath, effect->get_Sound()->get_BinaryData());
        soundIndex++;
    }
};

auto inputPath = String(u"presentation-with-animation-sounds.pptx");
auto outputDirectory = String(u"extracted-animation-sounds");

Directory::CreateDirectory_(outputDirectory);

auto presentation = MakeObject<Presentation>(inputPath);
int32_t soundIndex = 1;

for (const auto& slide : presentation->get_Slides())
{
    saveSounds(slide->get_Timeline()->get_MainSequence(), outputDirectory, soundIndex);

    for (const auto& sequence : slide->get_Timeline()->get_InteractiveSequences())
        saveSounds(sequence, outputDirectory, soundIndex);
}

Console::WriteLine(String::Format(u"Extracted {0} sound file(s) to {1}.", soundIndex - 1, Path::GetFullPath(outputDirectory)));
presentation->Dispose();
```

For large audio objects, use [IAudio::GetStream](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/getstream/) and copy the stream to a file instead of loading the entire object into a byte array.

## **Set After-Animation Behavior**

The **After animation** option controls what happens to a shape after its effect finishes.

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

The [AfterAnimationType](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) enumeration supports leaving the shape unchanged, changing its color, hiding it after the animation, or hiding it on the next click. When the type is [AfterAnimationType::Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/), call [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) to set the color as well.

This independent example creates an effect, sets its after-animation behavior through the returned effect object, and saves the result.

```cpp
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Dim after animation");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->set_AfterAnimationType(AfterAnimationType::Color);
effect->get_AfterAnimationColor()->set_Color(Color::get_LightGray());

presentation->Save(u"shape-animation-after-effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Changing the type away from [AfterAnimationType::Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) clears the after-animation color setting.

## **Animate Text**

Text animation has two related controls:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itextanimation/set_buildtype/) controls whether paragraphs appear together or by paragraph level.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) controls whether text appears all at once, by word, or by letter. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) sets the delay between words or letters. A positive value is a percentage of the effect duration; a negative value is a delay in seconds.

The following independent example animates the words in a text box. [BuildType::AsOneObject](https://reference.aspose.com/slides/cpp/aspose.slides.animation/buildtype/) disables paragraph-by-paragraph building so that the word setting applies to the entire text frame.

```cpp
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80.0f, 80.0f, 560.0f, 100.0f);
textBox->get_TextFrame()->set_Text(u"Aspose.Slides animates this sentence word by word.");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);
effect->set_AnimateTextType(AnimateTextType::ByWord);
effect->set_DelayBetweenTextParts(20.0f);

presentation->Save(u"animated-text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

To build a text box by paragraph, use [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itextanimation/set_buildtype/) with [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/cpp/aspose.slides.animation/buildtype/) or another paragraph level. To target a single paragraph with its own effect, use the [ISequence::AddEffect](https://reference.aspose.com/slides/cpp/aspose.slides.animation/isequence/addeffect/) overload that accepts an [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/). See [Animated Text](/slides/cpp/animated-text/) for paragraph-level examples.

## **Export and Compatibility Notes**

- Saving to PPT or PPTX preserves the animation model, but the final playback is controlled by the presentation viewer.
- PDF and static images do not play animations. Use [HTML5 export](/slides/cpp/export-to-html5/), animated GIF, or [video conversion](/slides/cpp/convert-powerpoint-to-video/) when the output must show motion.
- For HTML5, enable [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) and, when needed, [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).
- Video rendering supports many common entrance, emphasis, exit, and motion-path effects, but not every PowerPoint effect is supported. Check the current [supported animations and effects](/slides/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) and test critical presentations with your target Aspose.Slides version.
- Advanced custom effects and effects imported from other presentation formats may be preserved in the file but render differently in PowerPoint, HTML5, or video. Validate the exported result rather than relying only on the effect name.

## **FAQ**

**Why does an animation appear in PowerPoint but not in a PDF?**

PDF is a static format, so animations and slide transitions do not play. Export to HTML5, animated GIF, or video when motion must be preserved.

**Why does an effect play differently in a video?**

Video export renders animations rather than storing the original PowerPoint behavior. Some advanced effects are unsupported or approximated. Review the supported-effects table and test the actual presentation before production use.

**Does moving a shape forward or backward change its animation order?**

No. Shape z-order controls overlap, while sequence order and triggers control animation playback. Change the timeline if you need a different playback order.
