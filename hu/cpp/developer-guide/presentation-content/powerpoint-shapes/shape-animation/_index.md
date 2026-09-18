---
title: Alakzatanimációk alkalmazása prezentációkban C++ használatával
linktitle: Alakzatanimáció
type: docs
weight: 60
url: /hu/cpp/shape-animation/
keywords:
- alakzat
- animáció
- hatás
- animált alakzat
- animált szöveg
- animáció hozzáadása
- animáció lekérése
- animáció kinyerése
- hatás hozzáadása
- hatás lekérése
- hatás kinyerése
- hatás hang
- animáció alkalmazása
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, vizsgálhat meg és testreszabhat alakzatanimációkat, időzítést, hangokat, az animáció utáni viselkedést és animált szöveget az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

Az egyes viselkedések hatáson belüli kezeléséhez vagy a mozgás‑út szegmensek szerkesztéséhez lásd a [Egyéni animáció](/slides/hu/cpp/custom-animation/).

Az Aspose.Slides for C++ a diák animációit hatásokként ábrázolja egy diavetítés‑idővonalban. Egy hatásnak van cél alakja, animáció típusa és altípusa, egy aktiváló, időzítési beállítások, valamint opcionális tulajdonságok, például hang vagy az animáció utáni viselkedés.

Az idővonal kétféle szekvenciát tartalmaz:

- A **fő szekvencia** a dia előrehaladtával játszódik le.
- Egy **interaktív szekvencia** akkor indul, amikor a trigger alakját rákattintják.

Mivel a szövegdobozok, képek, diagramok, táblázatok és más diaobjektumok a [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) implementálják, ugyanazt a [ISequence::AddEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/addeffect/) metódust használhatod a legtöbb dia tartalomhoz. Az elérhető hatásokat a [EffectType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effecttype/) felsorolás tartalmazza.

## **Alakzatanimációk hozzáadása**

Animáció hozzáadásához szerezzük meg a dia fő szekvenciáját, és hívjuk meg a [ISequence::AddEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/addeffect/) metódust a cél alakjával, a hatás típusával, altípusával és a triggerrel. Ha egy hatást szeretnél, amely egy másik alakra kattintva indul, hozz létre egy interaktív szekvenciát, amelynek triggerje ez a másik alak.

A következő példa mindkét típusú animációt létrehozza, és a `shape-animations.pptx` fájlba menti.

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

A trigger határozza meg, mikor indul egy hatás:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effecttriggertype/) vár egy kattintásra a fő szekvenciában, vagy egy kattintásra a trigger alakjában egy interaktív szekvenciában.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effecttriggertype/) az előző hatással együtt indul.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effecttriggertype/) az előző hatás befejezését követően indul.

Kép, diagram vagy más alakzat animálásához add át azt az objektumot a [ISequence::AddEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/addeffect/) metódusnak a `targetShape` helyett. Diagram‑specifikus csoportosítási lehetőségekért lásd az [Animált diagramok](/slides/hu/cpp/animated-charts/).

## **Alakzat animációk beolvasása**

Használd a [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) metódust, ha ismered a cél alakot. Minden hatás megtekintéséhez sorold fel a fő szekvenciát és minden interaktív szekvenciát. A felsorolás elkerüli azt a feltételezést, hogy egy szekvencia a `0` indexen tartalmaz hatást.

A következő példa egy alakot hoz létre fő‑szekvenciás és interaktív hatásokkal, lekéri az alakot célzó hatásokat, majd felsorolja a dia minden szekvenciáját.

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

Ha csak egy alakhoz szükséges a hatások, először azonosítsd az alakot név, helyőrző típus vagy más stabil tulajdonság alapján; ezután hívd meg a [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) metódust. Ne feltételezd, hogy a [IShapeCollection::idx_get](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/idx_get/) a `0` indexen mindig a kívánt objektum.

## **Örökölt helyőrző hatások kezelése**

Egy helyőrző a normál dián örökölheti az animációs viselkedést a hozzá tartozó helyőrzőtől a diaelrendezésen és a mester dián. A [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/getbaseplaceholder/) visszaadja azt a szülőhelyőrzőt, vagy `nullptr` értéket, ha nincs szülő.

A következő példaprezentációban a láblécnek **Random Bars** hatása van a normál dián, **Split** a diaelrendezésen, és **Fly In** a mester dián.

![Lábléc animáció hatás a normál dián](slide-shape-animation.png)

![Lábléc helyőrző animáció hatás a diaelrendezésen](layout-shape-animation.png)

![Lábléc helyőrző animáció hatás a mester dián](master-shape-animation.png)

A következő példa magát a helyőrző hierarchiát építi fel. Hatásokat ad egy mester helyőrzőhöz, egy elrendezés helyőrzőhöz és a megfelelő helyőrzőhöz a normál dián. Minden hívás a [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/getbaseplaceholder/) előtt ellenőrzésre kerül, mielőtt a visszakapott alakot felhasználnák.

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

## **Animáció időzítésének módosítása**

A PowerPoint **Timing** (Időzítés) párbeszédablaka megfelel az [ITiming](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/) metódusainak.

![PowerPoint Időzítés párbeszédablak egy animációs hatáshoz](shape-animation.png)

- **Start** (Indítás) a [ITiming::set_TriggerType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_triggertype/)‑hez tartozik.
- **Duration** (Időtartam) a [ITiming::set_Duration](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_duration/)‑hez tartozik, másodpercben.
- **Delay** (Késleltetés) a [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/)‑hez tartozik, másodpercben.
- **Repeat** (Ismétlés) a [ITiming::set_RepeatCount](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) vagy [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) metódusokhoz tartozik.
- **Rewind when done playing** (Visszatekerés lejátszás befejezésekor) a [ITiming::set_Rewind](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_rewind/)‑hez tartozik.

Ez a különálló példa egy hatást ad hozzá, megváltoztatja annak időzítését a [ISequence::AddEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/addeffect/) által visszaadott objektumon keresztül, és menti az eredményt. A visszakapott [IEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/) hivatkozás megtartása elkerüli a felesleges gyűjtemény index használatát.

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

Használj egyetlen ismétlési módot szándékosan. Az ismétlésszám és egy „until” (eddig) jelző kombinálása különböző nézőkben zavaró eredményeket okozhat. Ismétlési módok módosításakor hívd meg a [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) és a [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) metódusokat a [ITiming::set_RepeatCount](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_repeatcount/) előtt, mivel bármelyik jelző beállítása megváltoztatja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs hatás hivatkozhat beágyazott hangra a [IEffect::set_Sound](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_sound/) segítségével. A [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) azt mondja a hatásnak, hogy állítsa le egy korábbi hatás által elindított hangot.

### **Hang hozzáadása egy hatáshoz**

A következő példa egy `animation-sound.wav` nevű helyi hangfájlra számít. Két hatást hoz létre, beágyazza azt a fájlt az első hatás hangjaként, és a második hatást úgy állítja be, hogy leállítsa a hangot. A [ISequence::AddEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/addeffect/) által visszaadott objektumokat használja, így nem szükséges szekvencia index.

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

### **Beágyazott hatáshangok kinyerése**

A következő példa egy `presentation-with-animation-sounds.pptx` nevű helyi prezentációra számít. Átvizsgálja a fő és interaktív szekvenciákat, és minden beágyazott hatáshangot a `extracted-animation-sounds` könyvtárba ír. A kiterjesztés az [IAudio::get_ContentType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iaudio/get_contenttype/) által visszaadott hang MIME‑típus alapján kerül kiválasztásra.

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

Nagy hangobjektumok esetén használd az [IAudio::GetStream](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iaudio/getstream/) metódust, és másold a streamet egy fájlba ahelyett, hogy az egész objektumot egy bájt tömbbe töltenéd.

## **Az animáció utáni viselkedés beállítása**

Az **After animation** (Animáció után) beállítás határozza meg, mi történik egy alakzattal, miután a hatása befejeződik.

![PowerPoint Hatásbeállítások párbeszédablaka, amely az animáció utáni beállításokat mutatja](shape-after-animation.png)

Az [AfterAnimationType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/afteranimationtype/) felsorolás támogatja az alakzat változatlan hagyását, színének módosítását, a rejtését az animáció után, vagy a következő kattintáskor való elrejtését. Ha a típus [AfterAnimationType::Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/afteranimationtype/), akkor hívd meg a [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) metódust a szín beállításához is.

Ez a különálló példa egy hatást hoz létre, a visszakapott hatásobjektumon keresztül beállítja az animáció utáni viselkedését, és elmenti az eredményt.

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

A típus [AfterAnimationType::Color]‑ról való eltávolítása törli az animáció utáni színbeállítást.

## **Szöveg animálása**

A szöveganimáció két kapcsolódó vezérlővel rendelkezik:

- Az [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itextanimation/set_buildtype/) szabályozza, hogy a bekezdések együtt vagy bekezdésenként jelenjenek meg.
- Az [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) szabályozza, hogy a szöveg egyszerre, szónként vagy betűnként jelenjen meg. Az [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) beállítja a késleltetést a szavak vagy betűk között. A pozitív érték a hatás időtartamának százaléka; a negatív érték másodpercben megadott késleltetés.

A következő különálló példa egy szövegdoboz szavait animálja. A [BuildType::AsOneObject](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/buildtype/) letiltja a bekezdésenkénti építést, így a szóbeállítás az egész szövegkeretre érvényesül.

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

Szövegdoboz bekezdésenkénti építéséhez használd az [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itextanimation/set_buildtype/) metódust a [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/buildtype/) vagy más bekezdés szinttel. Egyetlen bekezdés saját hatással való célzásához használd a [ISequence::AddEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/addeffect/) túlterhelést, amely egy [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) paramétert fogad. A bekezdés szintű példákért tekintsd meg az [Animált szöveg](/slides/hu/cpp/animated-text/) oldalt.

## **Exportálási és kompatibilitási megjegyzések**

- A PPT vagy PPTX formátumba mentés megőrzi az animációs modellt, de a végső lejátszást a prezentációs nézőprogram vezérli.
- A PDF és a statikus képek nem játszanak animációkat. Használd a [HTML5 export](/slides/hu/cpp/export-to-html5/), animált GIF‑et vagy a [videó konvertálást](/slides/hu/cpp/convert-powerpoint-to-video/) amikor a kimenetnek mozgást kell mutatnia.
- HTML5 esetén engedélyezd a [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/set_animateshapes/) opciót, és szükség esetén a [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/set_animatetransitions/) opciót.
- A videó renderelés sok közös belépő, hangsúlyozó, kilépő és mozgásút hatást támogat, de nem minden PowerPoint hatás támogatott. Nézd meg a jelenlegi [támogatott animációkat és hatásokat](/slides/hu/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) és teszteld a kritikus prezentációkat a cél Aspose.Slides verzióval.
- A fejlett egyedi hatásokat és más prezentációs formátumokból importált hatásokat a fájlban megőrizhetik, de PowerPointban, HTML5‑ben vagy videóban másként jelennek meg. Ellenőrizd az exportált eredményt, ne csak a hatás nevén alapulj.

## **GYIK**

**Miért jelenik meg egy animáció PowerPointban, de nem PDF‑ben?**

A PDF egy statikus formátum, ezért az animációk és diaátmenetek nem játszhatók le. Exportálj HTML5‑be, animált GIF‑be vagy videóba, ha a mozgást meg kell őrizni.

**Miért játszódik le egy hatás másként videóban?**

A videó exportálás animációkat renderel, nem a eredeti PowerPoint viselkedést tárolja. Néhány fejlett hatás nem támogatott vagy csak közelítőleg jelenik meg. Tekintsd át a támogatott hatások táblázatát, és teszteld a tényleges prezentációt a termelés előtt.

**Megváltoztatja egy alakzat előre vagy hátra helyezése az animációs sorrendet?**

Nem. Az alakzat Z‑sorrendje a fedés szabályozását határozza meg, míg a szekvencia sorrend és a triggerek a lejátszási sorrendet. Módosítsd az idővonalat, ha más lejátszási sorrendre van szükség.