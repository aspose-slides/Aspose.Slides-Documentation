---
title: Toepassen van vormanimaties in presentaties met C++
linktitle: Vormanimatie
type: docs
weight: 60
url: /nl/cpp/shape-animation/
keywords:
- vorm
- animatie
- effect
- geanimeerde vorm
- geanimeerde tekst
- animatie toevoegen
- animatie ophalen
- animatie extraheren
- effect toevoegen
- effect ophalen
- effect extraheren
- effectgeluid
- animatie toepassen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u vormanimaties, timing, geluiden, gedrag na animatie en geanimeerde tekst kunt toevoegen, inspecteren en aanpassen met Aspose.Slides voor C++."
---
## **Overzicht**

Om met de afzonderlijke gedragingen binnen een effect te werken of om segmenten van bewegingspaden te bewerken, zie [Aangepaste animatie](/slides/nl/cpp/custom-animation/).

Aspose.Slides for C++ vertegenwoordigt dia‑animaties als effecte in een diatijdlijn. Een effect heeft een doelvorm, een animatietype en subtype, een trigger, timinginstellingen en optionele eigenschappen zoals geluid of gedrag na de animatie.

De tijdlijn bevat twee soorten sequenties:

- De **hoofdsequentie** wordt afgespeeld terwijl de dia vordert.
- Een **interactieve sequentie** start wanneer de trigger‑vorm wordt aangeklikt.

Omdat tekstvakken, afbeeldingen, grafieken, tabellen en andere dia‑objecten [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) implementeren, gebruik je dezelfde [ISequence::AddEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/isequence/addeffect/)‑methode voor de meeste dia‑inhoud. De beschikbare effecte staan opgesomd in de [EffectType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/effecttype/)-enumeratie.

## **Vormanimaties toevoegen**

Om een animatie toe te voegen, haal je de hoofdsequentie van de dia op en roep je [ISequence::AddEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/isequence/addeffect/) aan met de doelvorm, het effecttype, subtype en trigger. Voor een effect dat start wanneer een andere vorm wordt aangeklikt, maak je een interactieve sequentie aan waarvan de trigger die andere vorm is.

Het volgende voorbeeld maakt beide soorten animaties en slaat het resultaat op in `shape-animations.pptx`.

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

De trigger bepaalt wanneer een effect start:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/effecttriggertype/) wacht op een klik in de hoofdsequentie, of op een klik op de trigger‑vorm in een interactieve sequentie.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/effecttriggertype/) start samen met het vorige effect.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/effecttriggertype/) start wanneer het vorige effect eindigt.

Om een afbeelding, grafiek of een ander type vorm te animeren, geef je dat object door aan [ISequence::AddEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/isequence/addeffect/) in plaats van `targetShape`. Voor grafiek‑specifieke groepeeropties, zie [Geanimeerde grafieken](/slides/nl/cpp/animated-charts/).

## **Vormanimaties lezen**

Gebruik [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) wanneer je de doelvorm kent. Om elk effect te inspecteren, doorloop je de hoofdsequentie en elke interactieve sequentie. Enumeratie voorkomt de veronderstelling dat een sequentie een effect op index `0` bevat.

Het volgende voorbeeld maakt een vorm met hoofd‑ en interactieve effects, haalt de effecten op die de vorm als doel hebben, en doorloopt vervolgens elke sequentie op de dia.

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

Als je alleen de effecten voor één vorm nodig hebt, identificeer dan eerst de vorm op naam, placeholder‑type of een andere stabiele eigenschap; roep vervolgens [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) aan. Ga niet ervan uit dat [IShapeCollection::idx_get](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/idx_get/) op index `0` altijd het beoogde object is.

## **Werken met overgeërfde placeholder‑effecten**

Een placeholder op een normale dia kan het animatiegedrag overerven van de overeenkomstige placeholder op de lay-outdia en de mastersdia. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/getbaseplaceholder/) retourneert die bovenliggende placeholder, of `nullptr` wanneer er geen bovenliggende bestaat.

In de volgende voorbeeldpresentatie heeft de voettekst **Random Bars** op de normale dia, **Split** op de lay-outdia en **Fly In** op de masterdia.

![Footer animatie‑effect op de normale dia](slide-shape-animation.png)
![Footer placeholder‑animatie‑effect op de lay-outdia](layout-shape-animation.png)
![Footer placeholder‑animatie‑effect op de masterdia](master-shape-animation.png)

Het volgende voorbeeld bouwt de placeholder‑hiërarchie zelf op. Het voegt effecte toe aan een master‑placeholder, een lay-out‑placeholder en de overeenkomstige placeholder op een normale dia. Elke oproep van [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/getbaseplaceholder/) wordt gecontroleerd voordat de geretourneerde vorm wordt gebruikt.

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

## **Animatietiming wijzigen**

Het PowerPoint **Timing**‑dialoogvenster komt overeen met de methoden van [ITiming](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/).

![PowerPoint Timing‑dialoog voor een animatie‑effect](shape-animation.png)

- **Start** komt overeen met [ITiming::set_TriggerType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/set_triggertype/).
- **Duur** komt overeen met [ITiming::set_Duration](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/set_duration/), in seconden.
- **Vertraging** komt overeen met [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/), in seconden.
- **Herhalen** komt overeen met [ITiming::set_RepeatCount](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/), of [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/).
- **Terugspoelen na afspelen** komt overeen met [ITiming::set_Rewind](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/set_rewind/).

Dit zelfstandige voorbeeld voegt een effect toe, wijzigt de timing via het object dat wordt geretourneerd door [ISequence::AddEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/isequence/addeffect/), en slaat het resultaat op. Het behouden van de geretourneerde [IEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/)‑referentie voorkomt een onnodige collectie's index.

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

Gebruik bewust één repeat‑modus. Het combineren van een repeat‑aantal met een "until"‑vlag kan verwarrende resultaten opleveren in verschillende weergave‑programma's. Wanneer je repeat‑modi wijzigt, roep je [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) en [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) aan vóór [ITiming::set_RepeatCount](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/set_repeatcount/), omdat het instellen van een van beide vlaggen tevens de actieve repeat‑modus wijzigt.

## **Animatiegeluiden toevoegen en extraheren**

Een animatie‑effect kan ingebedde audio refereren via [IEffect::set_Sound](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_sound/). [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) instrueert een effect om audio die door een eerder effect is gestart te stoppen.

### **Geluid aan een effect toevoegen**

Het volgende voorbeeld verwacht een lokaal audiobestand met de naam `animation-sound.wav`. Het maakt twee effecte, embed het bestand als geluid voor het eerste effect, en configureert het tweede effect om het geluid te stoppen. Het gebruikt de objecten die worden geretourneerd door [ISequence::AddEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/isequence/addeffect/), dus er is geen sequentie‑index vereist.

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

### **Ingebedde effectgeluiden extraheren**

Het volgende voorbeeld verwacht een lokale presentatie met de naam `presentation-with-animation-sounds.pptx`. Het scant zowel de hoofd‑ als de interactieve sequenties en schrijft elk ingebed effectgeluid weg naar de map `extracted-animation-sounds`. De extensie wordt gekozen op basis van het audio‑MIME‑type dat wordt blootgesteld door [IAudio::get_ContentType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iaudio/get_contenttype/).

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

Voor grote audio‑objecten, gebruik [IAudio::GetStream](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iaudio/getstream/) en kopieer de stream naar een bestand in plaats van het volledige object in een byte‑array te laden.

## **Instellen van gedrag na animatie**

De optie **After animation** bepaalt wat er met een vorm gebeurt nadat het effect is voltooid.

![PowerPoint Effect Options‑dialoog die After‑animatie-instellingen toont](shape-after-animation.png)

De [AfterAnimationType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/afteranimationtype/)‑enumeratie ondersteunt het ongewijzigd laten van de vorm, het wijzigen van de kleur, deze verbergen na de animatie, of verbergen bij de volgende klik. Wanneer het type [AfterAnimationType::Color](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/afteranimationtype/) is, roep je [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) aan om de kleur ook in te stellen.

Dit zelfstandige voorbeeld maakt een effect, stelt het gedrag na animatie in via het geretourneerde effectobject, en slaat het resultaat op.

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

Het wijzigen van het type van [AfterAnimationType::Color](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/afteranimationtype/) wist de after‑animation‑kleurinstelling.

## **Tekst animeren**

Tekstanimatie heeft twee gerelateerde besturingselementen:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itextanimation/set_buildtype/) bepaalt of alinea's samen verschijnen of per alinea.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) bepaalt of tekst in één keer, per woord of per letter verschijnt. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) stelt de vertraging tussen woorden of letters in. Een positieve waarde is een percentage van de effectduur; een negatieve waarde is een vertraging in seconden.

Het volgende zelfstandige voorbeeld animeert de woorden in een tekstvak. [BuildType::AsOneObject](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/buildtype/) schakelt het per‑alinea opbouwen uit zodat de woordinstelling van toepassing is op het gehele tekstframe.

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

Om een tekstvak per alinea op te bouwen, gebruik je [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itextanimation/set_buildtype/) met [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/buildtype/) of een ander alinea‑niveau. Om een enkele alinea met een eigen effect te targeten, gebruik je de overload van [ISequence::AddEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/isequence/addeffect/) die een [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/) accepteert. Zie [Geanimeerde tekst](/slides/nl/cpp/animated-text/) voor voorbeelden op alinea‑niveau.

## **Export‑ en compatibiliteitsopmerkingen**

- Opslaan als PPT of PPTX behoudt het animatiemodel, maar de uiteindelijke afspeling wordt aangestuurd door de presentatieweergave.
- PDF en statische afbeeldingen spelen geen animaties af. Gebruik [HTML5 export](/slides/nl/cpp/export-to-html5/), geanimeerde GIF of [video‑conversie](/slides/nl/cpp/convert-powerpoint-to-video/) wanneer de output beweging moet tonen.
- Voor HTML5, schakel [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/html5options/set_animateshapes/) in en, indien nodig, [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/html5options/set_animatetransitions/).
- Videorendering ondersteunt veel gangbare ingang-, nadruk‑, uitgang‑ en bewegingspad‑effecten, maar niet elk PowerPoint‑effect wordt ondersteund. Controleer de huidige [supported animations and effects](/slides/nl/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) en test kritieke presentaties met de beoogde Aspose.Slides‑versie.
- Geavanceerde aangepaste effecte en effecte geïmporteerd uit andere presentatieformaten kunnen in het bestand bewaard blijven maar anders worden gerenderd in PowerPoint, HTML5 of video. Valideer het geëxporteerde resultaat in plaats van alleen op de effectnaam te vertrouwen.

## **FAQ**

**Waarom verschijnt een animatie in PowerPoint maar niet in een PDF?**

PDF is een statisch formaat, dus animaties en dia‑overgangen worden niet afgespeeld. Exporteer naar HTML5, een geanimeerde GIF of video wanneer beweging behouden moet blijven.

**Waarom wordt een effect anders afgespeeld in een video?**

Video‑export rendert animaties in plaats van het originele PowerPoint‑gedrag op te slaan. Sommige geavanceerde effecte worden niet ondersteund of benaderd. Bekijk de tabel met ondersteunde effecte en test de daadwerkelijke presentatie vóór productie‑gebruik.

**Verandert het verplaatsen van een vorm naar voren of naar achteren de animatievolgorde?**

Nee. De z‑volgorde van vormen bepaalt de overlapping, terwijl de volgorde van sequenties en triggers de animatie‑afspeelvolgorde bepalen. Pas de tijdlijn aan als je een andere afspeelvolgorde nodig hebt.