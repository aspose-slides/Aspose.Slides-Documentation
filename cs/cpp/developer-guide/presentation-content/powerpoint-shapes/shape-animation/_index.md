---
title: Použití animací tvarů v prezentacích pomocí C++
linktitle: Animace tvaru
type: docs
weight: 60
url: /cs/cpp/shape-animation/
keywords:
- tvar
- animace
- efekt
- animovaný tvar
- animovaný text
- přidat animaci
- získat animaci
- extrahovat animaci
- přidat efekt
- získat efekt
- extrahovat efekt
- zvuk efektu
- aplikovat animaci
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, jak přidávat, kontrolovat a přizpůsobovat animace tvarů, časování, zvuky, chování po animaci a animovaný text s Aspose.Slides pro C++."
---
## **Přehled**

Pro práci s jednotlivými chováními uvnitř efektu nebo úpravou segmentů dráhy pohybu viz [Custom Animation](/slides/cs/cpp/custom-animation/).

Aspose.Slides pro C++ představuje animace snímku jako efekty v časové ose snímku. Efekt má cílový tvar, typ a podtyp animace, spouštěč, nastavení časování a volitelné vlastnosti, jako je zvuk nebo chování po animaci.

Časová osa obsahuje dva typy sekvencí:

- **hlavní sekvence** přehrává se při postupu snímku.
- **interaktivní sekvence** začíná, když je kliknuto na spouštěcí tvar.

Protože textová pole, obrázky, grafy, tabulky a další objekty snímku implementují [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/), používáte stejnou metodu [ISequence::AddEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/addeffect/) pro většinu obsahu snímku. Dostupné efekty jsou uvedeny v výčtu [EffectType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effecttype/).

## **Přidání animací tvarů**

Pro přidání animace získejte hlavní sekvenci snímku a zavolejte [ISequence::AddEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/addeffect/) s cílovým tvarem, typem efektu, podtypem a spouštěčem. Pro efekt, který začíná po kliknutí na jiný tvar, vytvořte interaktivní sekvenci, jejímž spouštěčem je tento jiný tvar.

Následující příklad vytvoří oba typy animací a uloží výsledek do `shape-animations.pptx`.

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

Spouštěč určuje, kdy se efekt spustí:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effecttriggertype/) čeká na kliknutí v hlavní sekvenci nebo na kliknutí na spouštěcí tvar v interaktivní sekvenci.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effecttriggertype/) začíná současně s předchozím efektem.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effecttriggertype/) začíná po dokončení předchozího efektu.

Pro animaci obrázku, grafu nebo jiného typu tvaru předávejte tento objekt metodě [ISequence::AddEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/addeffect/) místo `targetShape`. Pro možnosti seskupování specifické pro grafy viz [Animated Charts](/slides/cs/cpp/animated-charts/).

## **Čtení animací tvarů**

Použijte [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) pokud znáte cílový tvar. Pro prohlížení každého efektu enumerujte hlavní sekvenci a každou interaktivní sekvenci. Enumerace zabraňuje předpokladu, že sekvence obsahuje efekt na indexu `0`.

Následující příklad vytvoří tvar s hlavními a interaktivními efekty, získá efekty, které cílí na tvar, a poté enumeruje každou sekvenci na snímku.

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

Pokud potřebujete efekty jen pro jeden tvar, nejprve identifikujte tvar podle názvu, typu zástupného symbolu nebo jiné stabilní vlastnosti; potom zavolejte [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/geteffectsbyshape/). Nepředpokládejte, že [IShapeCollection::idx_get](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/idx_get/) na indexu `0` je vždy zamýšlený objekt.

## **Práce s děděnými efekty zástupných symbolů**

Zástupný symbol na normálním snímku může dědit chování animace ze odpovídajícího zástupného symbolu na rozložení snímku a hlavním snímku. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/getbaseplaceholder/) vrací tento nadřazený zástupný symbol nebo `nullptr`, pokud žádný nadřazený neexistuje.

V následující ukázkové prezentaci má zápatí **Random Bars** na normálním snímku, **Split** na snímku rozložení a **Fly In** na hlavním snímku.

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

Další příklad vytváří samotnou hierarchii zástupných symbolů. Přidává efekty do hlavního zástupného symbolu, zástupného symbolu rozložení a odpovídajícího zástupného symbolu na normálním snímku. Každé volání [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/getbaseplaceholder/) je zkontrolováno, než je vrácený tvar použit.

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

## **Změna časování animace**

Dialog PowerPoint **Timing** se mapuje na metody [ITiming](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/).

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** mapuje na [ITiming::set_TriggerType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_triggertype/).
- **Duration** mapuje na [ITiming::set_Duration](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_duration/), v sekundách.
- **Delay** mapuje na [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/), v sekundách.
- **Repeat** mapuje na [ITiming::set_RepeatCount](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/), nebo [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/).
- **Rewind when done playing** mapuje na [ITiming::set_Rewind](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_rewind/).

Tento samostatný příklad přidá efekt, změní jeho časování pomocí objektu vráceného metodou [ISequence::AddEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/addeffect/), a uloží výsledek. Uchování vrácené reference [IEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/) zabraňuje zbytečnému indexování kolekce.

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

Používejte jeden režim opakování záměrně. Kombinace počtu opakování s příznakem „until“ může vést k nejasným výsledkům v různých prohlížečích. Při změně režimů opakování nejprve zavolejte [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) a [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/), pak [ITiming::set_RepeatCount](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_repeatcount/), protože nastavení kteréhokoli příznaku také mění aktivní režim opakování.

## **Přidání a extrahování zvuků animací**

Efekt animace může odkazovat na vložený zvuk pomocí [IEffect::set_Sound](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_sound/). [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) říká efektu, aby zastavil zvuk zahájený předchozím efektem.

### **Přidání zvuku k efektu**

Následující příklad očekává lokální zvukový soubor pojmenovaný `animation-sound.wav`. Vytvoří dva efekty, vloží tento soubor jako zvuk pro první efekt a nakonfiguruje druhý efekt, aby zvuk zastavil. Používá objekty vrácené metodou [ISequence::AddEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/addeffect/), takže není potřeba index sekvence.

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

### **Extrahování vložených zvuků efektů**

Následující příklad očekává lokální prezentaci pojmenovanou `presentation-with-animation-sounds.pptx`. Prohledá jak hlavní, tak interaktivní sekvence a zapíše každý vložený zvuk efektu do adresáře `extracted-animation-sounds`. Přípona je vybrána z MIME typu zvuku, který poskytuje [IAudio::get_ContentType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iaudio/get_contenttype/).

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

Pro velké zvukové objekty použijte [IAudio::GetStream](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iaudio/getstream/) a zkopírujte proud do souboru místo načítání celého objektu do pole bajtů.

## **Nastavení chování po animaci**

Možnost **After animation** určuje, co se stane s tvarem po dokončení jeho efektu.

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

Výčet [AfterAnimationType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/afteranimationtype/) podporuje ponechání tvaru beze změny, změnu jeho barvy, skrytí po animaci nebo skrytí při dalším kliknutí. Když je typ [AfterAnimationType::Color](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/afteranimationtype/), zavolejte [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) pro nastavení barvy.

Tento samostatný příklad vytvoří efekt, nastaví jeho chování po animaci pomocí vráceného objektu efektu a uloží výsledek.

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

Změna typu od [AfterAnimationType::Color](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/afteranimationtype/) vymaže nastavení barvy po animaci.

## **Animace textu**

Animace textu má dvě související nastavení:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itextanimation/set_buildtype/) určuje, zda se odstavce zobrazují společně nebo po úrovních odstavců.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) určuje, zda se text zobrazuje najednou, po slovech nebo po písmenkách. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) nastavuje prodlevu mezi slovy nebo písmenky. Kladná hodnota je procento trvání efektu; záporná hodnota je prodleva v sekundách.

Následující samostatný příklad animuje slova v textovém poli. [BuildType::AsOneObject](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/buildtype/) vypne budování po odstavcích, takže nastavení pro slova se použije na celý textový rámec.

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

Pro budování textového pole po odstavcích použijte [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itextanimation/set_buildtype/) s [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/buildtype/) nebo jinou úrovní odstavce. Pro cílení na jediný odstavec s vlastním efektem použijte přetížení [ISequence::AddEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/addeffect/) akceptující [IParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/). Viz [Animated Text](/slides/cs/cpp/animated-text/) pro příklady na úrovni odstavců.

## **Export a poznámky o kompatibilitě**

- Ukládání do PPT nebo PPTX zachovává model animací, ale finální přehrávání řídí prohlížeč prezentací.
- PDF a statické obrázky animace nepřehrávají. Použijte [HTML5 export](/slides/cs/cpp/export-to-html5/), animovaný GIF nebo [převod na video](/slides/cs/cpp/convert-powerpoint-to-video/), pokud výstup musí zobrazovat pohyb.
- Pro HTML5 povolte [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/set_animateshapes/) a podle potřeby [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/set_animatetransitions/).
- Rendering videa podporuje mnoho běžných vstupních, zdůrazňovacích, výstupních a dráhových efektů, ale ne každý efekt PowerPointu je podporován. Zkontrolujte aktuální [supported animations and effects](/slides/cs/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) a otestujte kritické prezentace s vaší cílovou verzí Aspose.Slides.
- Pokročilé vlastní efekty a efekty importované z jiných formátů prezentací mohou být v souboru zachovány, ale vykreslí se odlišně v PowerPointu, HTML5 nebo videu. Ověřte exportovaný výsledek namísto spoléhaní se pouze na název efektu.

## **Často kladené otázky**

**Proč se animace zobrazí v PowerPointu, ale ne v PDF?**

PDF je statický formát, takže animace a přechody snímků se nepřehrávají. Exportujte do HTML5, animovaného GIFu nebo videa, pokud je potřeba zachovat pohyb.

**Proč se efekt přehrává jinak ve videu?**

Export do videa renderuje animace místo ukládání původního chování PowerPointu. Některé pokročilé efekty nejsou podporovány nebo jsou aproximovány. Prohlédněte si tabulku podporovaných efektů a otestujte skutečnou prezentaci před produkčním použitím.

**Mění přesunutí tvaru dopředu nebo dozadu jeho pořadí animace?**

Ne. Z‑order tvaru řídí překrytí, zatímco pořadí sekvencí a spouštěče řídí přehrávání animace. Změňte časovou osu, pokud potřebujete jiný pořadí přehrávání.