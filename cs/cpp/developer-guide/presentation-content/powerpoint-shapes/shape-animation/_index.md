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
description: "Naučte se, jak přidávat, kontrolovat a přizpůsobovat animace tvarů, časování, zvuky, chování po animaci a animovaný text pomocí Aspose.Slides pro C++."
---
## **Přehled**

Aspose.Slides pro C++ představuje animace snímků jako efekty v časové ose snímku. Efekt má cílový tvar, typ a podtyp animace, spouštěč, nastavení časování a volitelné vlastnosti, jako je zvuk nebo chování po animaci.

Časová osa obsahuje dva typy sekvencí:

- **Hlavní sekvence** se přehrává při postupu snímku.  
- **Interaktivní sekvence** se spustí, když je kliknuto na její spouštěcí tvar.

Protože textová pole, obrázky, grafy, tabulky a další objekty snímku implementují [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/), používáte stejnou metodu [ISequence::AddEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/addeffect/) pro většinu obsahu snímku. Dostupné efekty jsou vyjmenovány ve výčtu [EffectType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effecttype/).

## **Přidání animací tvarů**

Chcete‑li přidat animaci, získejte hlavní sekvenci snímku a zavolejte [ISequence::AddEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/addeffect/) s cílovým tvarem, typem efektu, podtypem a spouštěčem. Pro efekt, který začne po kliknutí na jiný tvar, vytvořte interaktivní sekvenci, jejímž spouštěčem je tento jiný tvar.

Následující příklad vytvoří oba typy animací a výsledek uloží do souboru `shape-animations.pptx`.

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

Spouštěč určuje, kdy efekt začne:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effecttriggertype/) čeká na kliknutí v hlavní sekvenci nebo na kliknutí na spouštěcí tvar v interaktivní sekvenci.  
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effecttriggertype/) spustí se spolu s předchozím efektem.  
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/effecttriggertype/) spustí se po dokončení předchozího efektu.

Chcete‑li animovat obrázek, graf nebo jiný typ tvaru, předávejte tento objekt metodě [ISequence::AddEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/addeffect/) místo `targetShape`. Pro možnosti seskupování specifické pro grafy viz [Animated Charts](/slides/cs/cpp/animated-charts/).

## **Čtení animací tvarů**

Použijte [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/geteffectsbyshape/), pokud znáte cílový tvar. Pro kontrolu všech efektů projděte hlavní sekvenci i všechny interaktivní sekvence. Enumerace zabraňuje předpokladu, že sekvence obsahuje efekt na indexu `0`.

Následující příklad vytvoří tvar s efekty hlavní a interaktivní sekvence, získá efekty zaměřené na tento tvar a následně projde všechny sekvence na snímku.

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

Pokud potřebujete efekty pouze pro jeden tvar, nejprve identifikujte tvar podle názvu, typu zástupného objektu nebo jiné stabilní vlastnosti; pak zavolejte [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/geteffectsbyshape/). Nepředpokládejte, že [IShapeCollection::idx_get](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/idx_get/) na indexu `0` vždy odkazuje na požadovaný objekt.

## **Práce s děděnými efekty zástupných objektů**

Zástupný objekt na běžném snímku může zdědit chování animace od odpovídajícího zástupného objektu na rozložení snímku a hlavním snímku. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/getbaseplaceholder/) vrací tento nadřazený zástupný objekt nebo `nullptr`, pokud nadřazený neexistuje.

V následujícím příkladu prezentace má zápatí **Random Bars** na běžném snímku, **Split** na snímku rozložení a **Fly In** na hlavním snímku.

![Animace zápatí na běžném snímku](slide-shape-animation.png)

![Animace zápatí na snímku rozložení](layout-shape-animation.png)

![Animace zápatí na hlavním snímku](master-shape-animation.png)

Další příklad vytvoří samotnou hierarchii zástupných objektů. Přidá efekty k hlavnímu zástupnému objektu, zástupnému objektu rozložení a odpovídajícímu zástupnému objektu na běžném snímku. Každé volání [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/getbaseplaceholder/) je před použitím vráceného tvaru ověřeno.

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

Dialog PowerPoint **Timing** odpovídá metodám rozhraní [ITiming](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/).

![Dialog PowerPoint Timing pro efekt animace](shape-animation.png)

- **Start** odpovídá metodě [ITiming::set_TriggerType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_triggertype/).  
- **Duration** odpovídá metodě [ITiming::set_Duration](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_duration/), v sekundách.  
- **Delay** odpovídá metodě [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/), v sekundách.  
- **Repeat** odpovídá metodám [ITiming::set_RepeatCount](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) nebo [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/).  
- **Rewind when done playing** odpovídá metodě [ITiming::set_Rewind](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_rewind/).

Tento samostatný příklad přidá efekt, změní jeho časování pomocí objektu vráceného metodou [ISequence::AddEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/addeffect/) a výsledek uloží. Zachování reference na vrácený [IEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/) zabraňuje zbytečnému přístupu kolekci podle indexu.

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

Používejte pouze jeden režim opakování. Kombinace počtu opakování s příznakem „do“ může v různých prohlížečích vést k nejasným výsledkům. Při změně režimu opakování zavolejte nejprve [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) a [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) a až poté [ITiming::set_RepeatCount](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/set_repeatcount/), protože nastavení jednoho z příznaků také mění aktivní režim opakování.

## **Přidání a extrakce zvuků animací**

Efekt animace může odkazovat na vložený zvuk pomocí [IEffect::set_Sound](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_sound/). [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) říká efektu, aby zastavil zvuk spuštěný dřívějším efektem.

### **Přidání zvuku k efektu**

Následující příklad očekává místní audio soubor s názvem `animation-sound.wav`. Vytvoří dva efekty, vloží tento soubor jako zvuk pro první efekt a nastaví, aby druhý efekt zvuk zastavil. Používá objekty vrácené metodou [ISequence::AddEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/addeffect/), takže není potřeba index sekvence.

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

Následující příklad očekává místní prezentaci s názvem `presentation-with-animation-sounds.pptx`. Prohledá hlavní i interaktivní sekvence a zapíše každý vložený zvuk efektu do adresáře `extracted-animation-sounds`. Přípona je vybrána podle MIME typu audia, který poskytuje [IAudio::get_ContentType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iaudio/get_contenttype/).

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

U velkých audio objektů použijte [IAudio::GetStream](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iaudio/getstream/) a zkopírujte stream do souboru místo načítání celého objektu do pole bajtů.

## **Nastavení chování po animaci**

Možnost **After animation** určuje, co se stane s tvarem po dokončení jeho efektu.

![Dialog PowerPoint Effect Options zobrazující nastavení After animation](shape-after-animation.png)

Výčet [AfterAnimationType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/afteranimationtype/) podporuje ponechání tvaru beze změny, změnu jeho barvy, skrytí po animaci nebo skrytí při dalším kliknutí. Když je typ [AfterAnimationType::Color](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/afteranimationtype/), použijte [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) k nastavení barvy.

Tento samostatný příklad vytvoří efekt, nastaví jeho chování po animaci pomocí vráceného objektu efektu a výsledek uloží.

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

Animace textu má dva související ovladače:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itextanimation/set_buildtype/) určuje, zda se odstavce objevují najednou nebo po úrovních odstavců.  
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) určuje, zda se text objeví najednou, po slovech nebo po jednotlivých písmenech. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) nastavuje zpoždění mezi slovy nebo písmeny. Kladná hodnota představuje procento trvání efektu; záporná hodnota je zpoždění v sekundách.

Následující samostatný příklad animuje slova v textovém poli. [BuildType::AsOneObject](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/buildtype/) zakáže budování po odstavcích, takže nastavení pro slova se použije na celý textový rámec.

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

Pro budování textového pole po odstavcích použijte [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itextanimation/set_buildtype/) s [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/buildtype/) nebo jinou úrovní odstavců. Chcete‑li zaměřit jediný odstavec s vlastním efektem, použijte přetížení [ISequence::AddEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/addeffect/) přijímající [IParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/). Viz [Animated Text](/slides/cs/cpp/animated-text/) pro příklady na úrovni odstavců.

## **Export a poznámky o kompatibilitě**

- Uložení do formátu PPT nebo PPTX zachovává model animace, ale finální přehrávání řídí prohlížeč prezentací.  
- PDF a statické obrázky animace nepřehrávají. Použijte [HTML5 export](/slides/cs/cpp/export-to-html5/), animovaný GIF nebo [konverzi do videa](/slides/cs/cpp/convert-powerpoint-to-video/), když výstup musí zobrazovat pohyb.  
- Pro HTML5 povolte [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/set_animateshapes/) a podle potřeby [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/set_animatetransitions/).  
- Rendering videa podporuje mnoho běžných efektů vstupu, důrazu, odchodu a pohybových cest, ale ne všechny efekty PowerPointu jsou podporovány. Zkontrolujte aktuální [supported animations and effects](/slides/cs/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) a otestujte kritické prezentace s vaší cílovou verzí Aspose.Slides.  
- Pokročilé vlastní efekty a efekty importované z jiných formátů prezentací mohou být v souboru zachovány, ale v PowerPointu, HTML5 nebo videu se mohou zobrazit odlišně. Ověřte exportovaný výsledek místo spoléhání se pouze na název efektu.

## **Často kladené otázky**

**Proč se animace zobrazuje v PowerPointu, ale ne v PDF?**

PDF je statický formát, takže animace a přechody snímků se nepřehrávají. Exportujte do HTML5, animovaného GIFu nebo videa, pokud je třeba zachovat pohyb.

**Proč se efekt v videu přehrává jinak?**

Export do videa renderuje animace místo toho, aby ukládal původní chování PowerPointu. Některé pokročilé efekty nejsou podporovány nebo jsou aproximovány. Prohlédněte si tabulku podporovaných efektů a před výrobou otestujte skutečnou prezentaci.

**Mění posunutí tvaru dopředu nebo dozadu jeho pořadí animace?**

Ne. Z‑řazení tvaru (z‑order) určuje překrývání, zatímco pořadí sekvence a spouštěče řídí přehrávání animace. Změňte časovou osu, pokud potřebujete jiný pořádek přehrávání.