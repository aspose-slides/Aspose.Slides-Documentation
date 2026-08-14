---
title: Alakzatanimációk alkalmazása prezentációkban C++ segítségével
linktitle: Alakzat animáció
type: docs
weight: 60
url: /hu/cpp/shape-animation/
keywords:
- alakzat
- animáció
- effektus
- animált alakzat
- animált szöveg
- animáció hozzáadása
- animáció lekérése
- animáció kinyerése
- effektus hozzáadása
- effektus lekérése
- effektus kinyerése
- effektus hang
- animáció alkalmazása
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerkedjen meg azzal, hogyan adhat hozzá, vizsgálhat és testreszabhat alakzatanimációkat, időzítést, hangokat, az animáció utáni viselkedést és animált szöveget az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

Az Aspose.Slides for C++ a dia animációit effektusokként ábrázolja a dia idővonalában. Egy effektusnak van célalakzata, animáció típusa és altípusa, egy trigger, időzítési beállításai, valamint opcionális tulajdonságai, például hang vagy az animáció utáni viselkedés.

Az idővonal kétféle sorozatot tartalmaz:

- A **fő sorozat** a dia előrehaladtával játszódik le.
- Egy **interaktív sorozat** akkor indul, amikor a trigger alakzatára kattintanak.

Mivel a szövegmezők, képek, diagramok, táblázatok és más diaobjektumok implementálják az [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/), a legtöbb dia tartalomhoz ugyanazt az [ISequence::AddEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/addeffect/) metódust használhatja. Az elérhető effektusok a [EffectType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effecttype/) felsorolásban vannak felsorolva.

## **Alakzatanimációk hozzáadása**

Animáció hozzáadásához kérje le a dia fő sorozatát, és hívja meg az [ISequence::AddEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/addeffect/) metódust a célalakzattal, effektustípussal, altípussal és triggerrel. Ha egy effektusnak akkor kell kezdődnie, amikor egy másik alakzatra kattintanak, hozzon létre egy interaktív sorozatot, amelynek triggerje az a másik alakzat.

A következő példában mindkét típusú animációt létrehozzuk, és az eredményt a `shape-animations.pptx` fájlba mentjük.

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

A trigger szabályozza, hogy mikor indul az effektus:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effecttriggertype/) a fő sorozatban kattintásra, vagy egy interaktív sorozatban a trigger alakzatra vár.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effecttriggertype/) az előző effektussal együtt indul.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effecttriggertype/) az előző effektus befejeződése után indul.

Kép, diagram vagy más alakzattípussal történő animációhoz adja át azt az objektumot az [ISequence::AddEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/addeffect/) metódusnak a `targetShape` helyett. Diagram-specifikus csoportosítási lehetőségekért lásd a [Animated Charts](/slides/hu/cpp/animated-charts/) oldalt.

## **Alakzatanimációk olvasása**

Használja az [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) metódust, ha ismeri a cél alakzatot. Minden effektus megvizsgálásához enumerálja a fő sorozatot és minden interaktív sorozatot. Az enumerálás elkerüli annak feltételezését, hogy egy sorozat a `0` indexen tartalmaz effektust.

A következő példában létrehozunk egy alakzatot fő‑sorozat és interaktív effektusokkal, lekérdezzük a alakzatot célzó effektusokat, majd enumeráljuk a dia minden sorozatát.

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

Ha csak egy alakzatra van szüksége, először határozza meg az alakzatot név, helyőrző típus vagy más stabil tulajdonság alapján; ezután hívja meg az [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) metódust. Ne vegye fel azt a feltételezést, hogy a [IShapeCollection::idx_get](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/idx_get/) a `0` indexen mindig a kívánt objektum.

## **Örökölt helyőrző effektusok kezelése**

Egy normál dia helyőrzője örökölheti az animációs viselkedést a megfelelő helyőrzőtől az elrendezés és a mester dián. Az [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/getbaseplaceholder/) visszaadja ezt a szülőhelyőrzőt, vagy `nullptr`‑t, ha nincs szülő.

Az alábbi példában a láblécnek **Random Bars** animációja van a normál dián, **Split** az elrendezés dián, és **Fly In** a mester dián.

![Lábléc animációs effektus a normál dián](slide-shape-animation.png)

![Lábléc helyőrző animációs effektus az elrendezés dián](layout-shape-animation.png)

![Lábléc helyőrző animációs effektus a mester dián](master-shape-animation.png)

A következő példában felépíti a helyőrző hierarchiát. Effektusokat ad hozzá egy mester helyőrzőhöz, egy elrendezés helyőrzőhöz és a megfelelő helyőrzőhöz egy normál dián. Minden [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/getbaseplaceholder/) hívást ellenőriz, mielőtt a visszakapott alakzatot felhasználná.

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

A PowerPoint **Timing** (Időzítés) párbeszédablaka az [ITiming](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/) metódusainak felel meg.

![PowerPoint időzítési párbeszédablaka egy animációs effektushoz](shape-animation.png)

- **Start** az [ITiming::set_TriggerType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_triggertype/) metódusra vonatkozik.
- **Duration** (Időtartam) az [ITiming::set_Duration](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_duration/) metódusra vonatkozik, másodpercben.
- **Delay** (Késleltetés) az [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/) metódusra vonatkozik, másodpercben.
- **Repeat** (Ismétlés) az [ITiming::set_RepeatCount](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) vagy [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) metódusokra vonatkozik.
- **Rewind when done playing** (Visszatekerés lejátszás után) az [ITiming::set_Rewind](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_rewind/) metódusra vonatkozik.

Ez az önálló példa egy effektust ad hozzá, módosítja annak időzítését az [ISequence::AddEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/addeffect/) által visszaadott objektumon keresztül, és menti az eredményt. A visszakapott [IEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/) hivatkozás megtartása elkerüli a felesleges gyűjtemény index használatát.

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

Használjon egy ismétlési módot szándékosan. A ismétlési számlálót egy „until” (amíg) jelzővel kombinálva zavaró eredményeket okozhat különböző lejátszókban. Ismétlési módok módosításakor előbb hívja meg az [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) és [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) metódusokat, majd az [ITiming::set_RepeatCount](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/set_repeatcount/) metódust, mivel bármely jelző beállítása megváltoztatja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs effektus beágyazott hangot hivatkozhat a [IEffect::set_Sound](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_sound/) metóduson keresztül. Az [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) azt mondja az effektusnak, hogy állítsa le egy korábbi effektus által indított hangot.

### **Hang hozzáadása egy effektushoz**

A következő példa egy helyi `animation-sound.wav` nevű hangfájlt vár. Két effektust hoz létre, az első effektus hangjaként beágyazza ezt a fájlt, a második effektust pedig úgy konfigurálja, hogy leállítsa a hangot. A [ISequence::AddEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/addeffect/) által visszaadott objektumokat használja, így nem szükséges sorozat index.

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

### **Beágyazott effektushangok kinyerése**

A következő példa egy helyi `presentation-with-animation-sounds.pptx` nevű prezentációt vár. Átvizsgálja a fő és interaktív sorozatokat, és minden beágyazott effektushangot a `extracted-animation-sounds` könyvtárba ír. A kiterjesztés az [IAudio::get_ContentType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iaudio/get_contenttype/) által megadott audio MIME típussal van kiválasztva.

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

Nagy audio objektumok esetén használja az [IAudio::GetStream](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iaudio/getstream/) metódust, és másolja a streamet fájlba ahelyett, hogy az egész objektumot byte tömbbe töltené.

## **Az animáció utáni viselkedés beállítása**

Az **After animation** (Animáció után) opció szabályozza, hogy mi történik az alakzattal, amikor az effektus befejeződik.

![PowerPoint effektus opciók párbeszédablaka, amely az After animation beállításokat mutatja](shape-after-animation.png)

A [AfterAnimationType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/afteranimationtype/) felsorolás támogatja az alakzat változatlanul hagyását, színének módosítását, a animáció után való elrejtését, vagy a következő kattintáskor való elrejtését. Ha a típus [AfterAnimationType::Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/afteranimationtype/), akkor hívja meg a [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) metódust a szín beállításához is.

Ez az önálló példa egy effektust hoz létre, a visszakapott effektus objektumon keresztül beállítja az animáció utáni viselkedést, és menti az eredményt.

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

A [AfterAnimationType::Color](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/afteranimationtype/) típusról való eltávolítás törli az animáció utáni színbeállítást.

## **Szöveg animálása**

A szöveg animáció két kapcsolódó beállítással rendelkezik:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itextanimation/set_buildtype/) szabályozza, hogy a bekezdések egyszerre vagy bekezdés szinten jelenjenek meg.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) szabályozza, hogy a szöveg egyszerre, szó szerint vagy betűként jelenjen meg. Az [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) beállítja a késleltetést a szavak vagy betűk között. A pozitív érték az effektus időtartamának százalékában, a negatív érték másodpercben van megadva.

A következő önálló példa a szövegdoboz szavait animálja. A [BuildType::AsOneObject](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/buildtype/) letiltja a bekezdésenkénti építést, így a szóbeállítás az egész szövegkeretre vonatkozik.

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

A szövegdoboz bekezdésenkénti építéséhez használja az [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itextanimation/set_buildtype/) metódust a [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/buildtype/) vagy más bekezdés szinttel. Egyetlen bekezdéshez saját effektussal a [ISequence::AddEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/addeffect/) olyan overload-ját használja, amely egy [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) objektumot fogad. Lásd a [Animated Text](/slides/hu/cpp/animated-text/) oldalt a bekezdés‑szintű példákhoz.

## **Exportálás és kompatibilitási megjegyzések**

- A PPT vagy PPTX formátumba mentés megőrzi az animációs modellt, de a végső lejátszást a prezentációs lejátszó szabályozza.
- A PDF és a statikus képek nem játszanak animációkat. Használja a [HTML5 export](/slides/hu/cpp/export-to-html5/), animált GIF‑et vagy a [video conversion](/slides/hu/cpp/convert-powerpoint-to-video/) opciót, ha a kimenetnek mozgást kell mutatnia.
- HTML5 esetén engedélyezze a [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/set_animateshapes/) és szükség esetén a [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/set_animatetransitions/) beállításokat.
- A videórenderelés számos gyakori belépő, hangsúlyozó, kilépő és mozgásútpont effektust támogat, de nem minden PowerPoint effektus támogatott. Tekintse meg a jelenlegi [supported animations and effects](/slides/hu/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) oldalt, és tesztelje a kritikus prezentációkat a cél Aspose.Slides verzióval.
- A fejlett egyedi effektusok és más prezentációs formátumokból importált effektusok megmaradhatnak a fájlban, de PowerPointban, HTML5‑ben vagy videóban másként jelenhetnek meg. Ellenőrizze az exportált eredményt, ne csak az effektus nevére hagyatkozzon.

## **GYIK**

**Miért jelenik meg egy animáció a PowerPointban, de nem a PDF‑ben?**

A PDF statikus formátum, ezért az animációk és diák áttűnései nem játszhatók le. Exportáljon HTML5‑re, animált GIF‑re vagy videóra, ha a mozgást meg kell őrizni.

**Miért játszódik le másként egy effektus videóban?**

A videóexport animációkat renderel, nem pedig az eredeti PowerPoint viselkedést tárolja. Néhány fejlett effektus nem támogatott vagy csak közelítőleg jelenik meg. Tekintse át a támogatott effektusok táblázatát, és tesztelje a tényleges prezentációt a termelés előtt.

**Megváltoztatja-e egy alakzat előre vagy hátra mozgatása az animációs sorrendet?**

Nem. Az alakzat z‑rendje a fedését szabályozza, míg a sorozat sorrendje és a triggerek az animáció lejátszását. Módosítsa az idővonalat, ha más lejátszási sorrendre van szükség.