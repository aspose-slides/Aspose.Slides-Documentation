---
title: "Tillämpa formanimationer i presentationer med C++"
linktitle: "Formanimation"
type: docs
weight: 60
url: /sv/cpp/shape-animation/
keywords:
- form
- animation
- effekt
- animerad form
- animerad text
- lägga till animation
- hämta animation
- extrahera animation
- lägga till effekt
- hämta effekt
- extrahera effekt
- effektljud
- tillämpa animation
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du lägger till, granskar och anpassar formanimationer, timing, ljud, efter‑animationsbeteende och animerad text med Aspose.Slides för C++."
---
## **Översikt**

Aspose.Slides för C++ representerar bildanimationer som effekter i en bildspels tidslinje. En effekt har ett målform, en animationstyp och undertyp, en trigger, tidsinställningar och valfria egenskaper såsom ljud eller efter‑animationsbeteende.

Tidslinjen innehåller två typer av sekvenser:

- Den **huvudsekvensen** spelas när bilden avancerar.
- En **interaktiv sekvens** startar när dess trigger‑form klickas.

Eftersom textrutor, bilder, diagram, tabeller och andra bildobjekt implementerar [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/), använder du samma metod [ISequence::AddEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/isequence/addeffect/) för det mesta bildinnehåll. De tillgängliga effekterna listas i uppräkningen [EffectType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/effecttype/).

## **Lägg till formanimationer**

För att lägga till en animation, hämta bildens huvudsekvens och anropa [ISequence::AddEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/isequence/addeffect/) med målformen, effekt‑typ, undertyp och trigger. För en effekt som startar när en annan form klickas, skapa en interaktiv sekvens vars trigger är den andra formen.

Följande exempel skapar båda typerna av animation och sparar resultatet till `shape-animations.pptx`.

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

Triggern styr när en effekt startar:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/effecttriggertype/) väntar på ett klick i huvudsekvensen, eller på ett klick på trigger‑formen i en interaktiv sekvens.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/effecttriggertype/) startar med föregående effekt.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/effecttriggertype/) startar när föregående effekt avslutas.

För att animera en bild, ett diagram eller en annan formtyp, skicka det objektet till [ISequence::AddEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/isequence/addeffect/) i stället för `targetShape`. För diagram‑specifika grupperingalternativ, se [Animerade diagram](/slides/sv/cpp/animated-charts/).

## **Läs formanimationer**

Använd [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) när du känner till målformen. För att inspektera varje effekt, iterera över huvudsekvensen och varje interaktiv sekvens. Iteration undviker antagandet att en sekvens innehåller en effekt på index `0`.

Följande exempel skapar en form med huvud‑ och interaktiva effekter, hämtar effekterna som riktar sig mot formen och itererar sedan över varje sekvens på bilden.

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

Om du bara behöver effekterna för en form, identifiera först formen efter namn, platshållartyp eller en annan stabil egenskap; anropa sedan [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/isequence/geteffectsbyshape/). Anta inte att [IShapeCollection::idx_get](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/idx_get/) på index `0` alltid är det avsedda objektet.

## **Arbeta med ärvda platshållareffekter**

En platshållare på en normal bild kan ärva animationsbeteende från motsvarande platshållare på dess layout‑bild och huvudsakliga bild. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/getbaseplaceholder/) returnerar den föräldraplatshållaren, eller `nullptr` när ingen förälder finns.

I den följande exempelpresentationen har sidfoten **Random Bars** på den normala bilden, **Split** på layout‑bilden och **Fly In** på huvud‑bilden.

![Fotanimationseffekt på den normala bilden](slide-shape-animation.png)

![Fotplatshållaranimationseffekt på layout‑bilden](layout-shape-animation.png)

![Fotplatshållaranimationseffekt på huvud‑bilden](master-shape-animation.png)

Nästa exempel bygger själva platshållar­hierarkin. Det lägger till effekter på en huvud‑platshållare, en layout‑platshållare och motsvarande platshållare på en normal bild. Varje anrop till [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/getbaseplaceholder/) kontrolleras innan den returnerade formen används.

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

## **Ändra animationstiming**

PowerPoint‑dialogrutan **Timing** motsvarar metoderna i [ITiming](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/).

![PowerPoint Timing‑dialog för en animationseffekt](shape-animation.png)

- **Start** motsvarar [ITiming::set_TriggerType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/set_triggertype/).
- **Varaktighet** motsvarar [ITiming::set_Duration](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/set_duration/), i sekunder.
- **Fördröjning** motsvarar [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/), i sekunder.
- **Upprepa** motsvarar [ITiming::set_RepeatCount](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/), eller [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/).
- **Spola tillbaka när uppspelning är klar** motsvarar [ITiming::set_Rewind](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/set_rewind/).

Detta fristående exempel lägger till en effekt, ändrar dess timing via objektet som returneras av [ISequence::AddEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/isequence/addeffect/), och sparar resultatet. Att behålla den returnerade [IEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/)-referensen undviker ett onödigt samlingsindex.

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

Använd endast ett upprepningsläge med avsikt. Att kombinera ett upprepningsantal med en ”till‑”‑flagga kan ge förvirrande resultat i olika visare. När du byter upprepningsläge, anropa först [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) och [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) innan du anropar [ITiming::set_RepeatCount](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/set_repeatcount/), eftersom att sätta någon av flaggorna också ändrar det aktiva upprepningsläget.

## **Lägg till och extrahera animationsljud**

En animationseffekt kan referera till inbäddat ljud via [IEffect::set_Sound](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_sound/). [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) får en effekt att stoppa ljud som startats av en tidigare effekt.

### **Lägg till ljud till en effekt**

Följande exempel förutsätter en lokal ljudfil med namn `animation-sound.wav`. Det skapar två effekter, bäddar in den filen som ljud för den första effekten och konfigurerar den andra effekten att stoppa ljudet. Det använder objekten som returneras av [ISequence::AddEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/isequence/addeffect/), så inget sekvensindex krävs.

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

### **Extrahera inbäddade effektljud**

Följande exempel förutsätter en lokal presentation med namn `presentation-with-animation-sounds.pptx`. Det skannar både huvud‑ och interaktiva sekvenser och skriver varje inbäddat effektljud till katalogen `extracted-animation-sounds`. Filändelsen väljs utifrån ljud‑MIME‑typen som exponeras av [IAudio::get_ContentType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iaudio/get_contenttype/).

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

För stora ljudobjekt, använd [IAudio::GetStream](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iaudio/getstream/) och kopiera strömmen till en fil i stället för att ladda hela objektet i en byte‑array.

## **Ställ in efter‑animation beteende**

Alternativet **After animation** styr vad som händer med en form efter att dess effekt avslutats.

![PowerPoint Effect Options‑dialog som visar efter‑animationsinställningar](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/afteranimationtype/)-uppräkningen stödjer att låta formen förbli oförändrad, ändra dess färg, dölja den efter animationen, eller dölja den vid nästa klick. När typen är [AfterAnimationType::Color](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/afteranimationtype/), anropa [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) för att även sätta färgen.

Detta fristående exempel skapar en effekt, sätter dess efter‑animation beteende via det returnerade effektobjektet, och sparar resultatet.

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

Att byta typ från [AfterAnimationType::Color](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/afteranimationtype/) rensar inställningen för efter‑animationsfärg.

## **Animera text**

Textanimation har två relaterade kontroller:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itextanimation/set_buildtype/) styr om stycken visas tillsammans eller per styckennivå.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) styr om text visas på en gång, per ord eller per bokstav. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) sätter fördröjningen mellan ord eller bokstäver. Ett positivt värde är en procentandel av effektens varaktighet; ett negativt värde är en fördröjning i sekunder.

Följande fristående exempel animerar orden i en textruta. [BuildType::AsOneObject](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/buildtype/) inaktiverar byggande stycke för stycke så att ordinställningen gäller hela textramen.

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

För att bygga en textruta per stycke, använd [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itextanimation/set_buildtype/) med [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/buildtype/) eller en annan styckennivå. För att rikta en enskild paragraf med sin egen effekt, använd överlagringen av [ISequence::AddEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/isequence/addeffect/) som accepterar ett [IParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/). Se [Animerad text](/slides/sv/cpp/animated-text/) för exempel på paragrafnivå.

## **Export‑ och kompatibilitetsnoteringar**

- Att spara till PPT eller PPTX bevarar animationsmodellen, men den slutliga uppspelningen styrs av presentationsvisaren.
- PDF och statiska bilder spelar inte upp animationer. Använd [HTML5‑export](/slides/sv/cpp/export-to-html5/), animerad GIF eller [videokonvertering](/slides/sv/cpp/convert-powerpoint-to-video/) när utdata måste visa rörelse.
- För HTML5, aktivera [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/html5options/set_animateshapes/) och, vid behov, [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/html5options/set_animatetransitions/).
- Videorendering stödjer många vanliga inträde‑, betoning‑, utgångs‑ och rörelsespårs‑effekter, men inte varje PowerPoint‑effekt stöds. Kontrollera den aktuella [stödda animationer och effekter](/slides/sv/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) och testa kritiska presentationer med den Aspose.Slides‑version du planerar att använda.
- Avancerade anpassade effekter och effekter importerade från andra presentationsformat kan bevaras i filen men renderas annorlunda i PowerPoint, HTML5 eller video. Validera det exporterade resultatet istället för att enbart förlita dig på effektens namn.

## **FAQ**

**Varför visas en animation i PowerPoint men inte i en PDF?**

PDF är ett statiskt format, så animationer och bildövergångar spelas inte upp. Exportera till HTML5, animerad GIF eller video när rörelse måste bevaras.

**Varför spelas en effekt annorlunda i en video?**

Videoexport renderar animationer istället för att lagra det ursprungliga PowerPoint‑beteendet. Vissa avancerade effekter stöds inte eller approximeras. Granska tabellen över stödda effekter och testa den faktiska presentationen innan produktionsanvändning.

**Ändrar flyttning av en form framåt eller bakåt dess animationsordning?**

Nej. Formens z‑ordning styr överlappning, medan sekvensordning och triggers styr animationsuppspelning. Ändra tidslinjen om du behöver en annan uppspelningsordning.