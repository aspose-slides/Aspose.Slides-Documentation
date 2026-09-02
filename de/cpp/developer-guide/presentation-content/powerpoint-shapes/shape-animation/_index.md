---
title: Formanimationen in Präsentationen mit C++ anwenden
linktitle: Formanimation
type: docs
weight: 60
url: /de/cpp/shape-animation/
keywords:
- Form
- Animation
- Effekt
- animierte Form
- animierter Text
- Animation hinzufügen
- Animation abrufen
- Animation extrahieren
- Effekt hinzufügen
- Effekt abrufen
- Effekt extrahieren
- Effektton
- Animation anwenden
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formanimationen, Timing, Sounds, Nach‑Animations‑Verhalten und animierten Text mit Aspose.Slides für C++ hinzufügen, prüfen und anpassen."
---
## **Übersicht**

Aspose.Slides für C++ stellt Folienanimationen als Effekte in einer Folienzeitachse dar. Ein Effekt hat eine Zielform, einen Animationstyp und -untertyp, einen Auslöser, Timing‑Einstellungen und optionale Eigenschaften wie Sound oder ein Verhalten nach der Animation.

Die Zeitleiste enthält zwei Arten von Sequenzen:

- Die **Hauptsequenz** wird abgespielt, wenn die Folie fortschreitet.
- Eine **interaktive Sequenz** startet, wenn ihre Auslöseform angeklickt wird.

Da Textfelder, Bilder, Diagramme, Tabellen und andere Folienobjekte [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/) implementieren, verwenden Sie dieselbe Methode [ISequence::AddEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/isequence/addeffect/) für die meisten Folieninhalte. Die verfügbaren Effekte sind in der Aufzählung [EffectType](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/effecttype/) aufgelistet.

## **Formanimationen hinzufügen**

Um eine Animation hinzuzufügen, holen Sie sich die Hauptsequenz der Folie und rufen Sie [ISequence::AddEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/isequence/addeffect/) mit der Zielform, dem Effekt‑Typ, dem Untertyp und dem Auslöser auf. Für einen Effekt, der startet, wenn eine andere Form angeklickt wird, erstellen Sie eine interaktive Sequenz, deren Auslöser diese andere Form ist.

Das folgende Beispiel erstellt beide Animationsarten und speichert das Ergebnis in `shape-animations.pptx`.

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

Der Auslöser bestimmt, wann ein Effekt startet:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/effecttriggertype/) wartet in der Hauptsequenz auf einen Klick oder in einer interaktiven Sequenz auf einen Klick auf die Auslöseform.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/effecttriggertype/) startet zusammen mit dem vorhergehenden Effekt.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/effecttriggertype/) startet, wenn der vorhergehende Effekt beendet ist.

Um ein Bild, Diagramm oder einen anderen Formtyp zu animieren, übergeben Sie dieses Objekt an [ISequence::AddEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/isequence/addeffect/) anstelle von `targetShape`. Für diagrammspezifische Gruppierungsoptionen siehe [Animated Charts](/slides/de/cpp/animated-charts/).

## **Formanimationen lesen**

Verwenden Sie [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/isequence/geteffectsbyshape/), wenn Sie die Zielform kennen. Um jeden Effekt zu untersuchen, enumerieren Sie die Hauptsequenz und jede interaktive Sequenz. Die Enumeration vermeidet die Annahme, dass eine Sequenz einen Effekt am Index `0` enthält.

Das folgende Beispiel erstellt eine Form mit Haupt‑ und Interaktive‑Effekten, ermittelt die Effekte, die die Form ansprechen, und enumeriert anschließend jede Sequenz auf der Folie.

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

Wenn Sie nur die Effekte für eine Form benötigen, identifizieren Sie die Form zunächst nach Name, Platzhaltertyp oder einer anderen stabilen Eigenschaft; rufen Sie dann [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) auf. Gehen Sie nicht davon aus, dass [IShapeCollection::idx_get](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/idx_get/) am Index `0` immer das gewünschte Objekt ist.

## **Arbeiten mit geerbten Platzhaltereffekten**

Ein Platzhalter auf einer normalen Folie kann das Animationsverhalten vom entsprechenden Platzhalter auf ihrer Layout‑Folie und Master‑Folie erben. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/getbaseplaceholder/) gibt diesen übergeordneten Platzhalter zurück oder `nullptr`, wenn kein übergeordneter Platzhalter existiert.

In der folgenden Beispielpräsentation hat die Fußzeile **Random Bars** auf der normalen Folie, **Split** auf der Layout‑Folie und **Fly In** auf der Master‑Folie.

![Fußzeilen‑Animationseffekt auf der normalen Folie](slide-shape-animation.png)

![Fußzeilen‑Platzhalter‑Animationseffekt auf der Layout‑Folie](layout-shape-animation.png)

![Fußzeilen‑Platzhalter‑Animationseffekt auf der Master‑Folie](master-shape-animation.png)

Das nächste Beispiel baut die Platzhalter‑Hierarchie selbst auf. Es fügt Effekte einem Master‑Platzhalter, einem Layout‑Platzhalter und dem entsprechenden Platzhalter auf einer normalen Folie hinzu. Jeder Aufruf von [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/getbaseplaceholder/) wird überprüft, bevor die zurückgegebene Form verwendet wird.

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

## **Animations‑Timing ändern**

Der PowerPoint **Timing**‑Dialog entspricht den Methoden von [ITiming](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/).

![PowerPoint Timing‑Dialog für einen Animationseffekt](shape-animation.png)

- **Start** entspricht [ITiming::set_TriggerType](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/set_triggertype/).
- **Duration** entspricht [ITiming::set_Duration](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/set_duration/), in Sekunden.
- **Delay** entspricht [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/), in Sekunden.
- **Repeat** entspricht [ITiming::set_RepeatCount](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) oder [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/).
- **Rewind when done playing** entspricht [ITiming::set_Rewind](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/set_rewind/).

Dieses eigenständige Beispiel fügt einen Effekt hinzu, ändert dessen Timing über das von [ISequence::AddEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/isequence/addeffect/) zurückgegebene Objekt und speichert das Ergebnis. Das Behalten der zurückgegebenen [IEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/)‑Referenz vermeidet einen unnötigen Sammlungs‑Index.

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

Verwenden Sie bewusst nur einen Wiederholungsmodus. Das Kombinieren einer Wiederholungszahl mit einem „bis“-Flag kann in verschiedenen Viewern zu verwirrenden Ergebnissen führen. Beim Ändern der Wiederholungsmodi rufen Sie zuerst [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) und [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) auf, bevor Sie [ITiming::set_RepeatCount](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/set_repeatcount/) setzen, da das Setzen eines Flags auch den aktiven Wiederholungsmodus ändert.

## **Animationssounds hinzufügen und extrahieren**

Ein Animationseffekt kann über [IEffect::set_Sound](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/set_sound/) auf eingebettete Audiodaten verweisen. [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) weist einen Effekt an, den von einem früheren Effekt gestarteten Sound zu stoppen.

### **Sound zu einem Effekt hinzufügen**

Das folgende Beispiel erwartet eine lokale Audiodatei namens `animation-sound.wav`. Es erstellt zwei Effekte, bettet diese Datei als Sound für den ersten Effekt ein und konfiguriert den zweiten Effekt so, dass er den Sound stoppt. Es verwendet die von [ISequence::AddEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/isequence/addeffect/) zurückgegebenen Objekte, sodass kein Sequenz‑Index erforderlich ist.

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

### **Eingebettete Effekt‑Sounds extrahieren**

Das folgende Beispiel erwartet eine lokale Präsentation namens `presentation-with-animation-sounds.pptx`. Es durchsucht sowohl die Haupt‑ als auch die interaktive Sequenz und schreibt jeden eingebetteten Effekt‑Sound in das Verzeichnis `extracted-animation-sounds`. Die Dateierweiterung wird aus dem Audio‑MIME‑Typ ermittelt, der von [IAudio::get_ContentType](https://reference.aspose.com/slides/de/cpp/aspose.slides/iaudio/get_contenttype/) bereitgestellt wird.

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

Für große Audiodaten verwenden Sie [IAudio::GetStream](https://reference.aspose.com/slides/de/cpp/aspose.slides/iaudio/getstream/) und kopieren den Stream in eine Datei, anstatt das gesamte Objekt in ein Byte‑Array zu laden.

## **Nach‑Animationsverhalten festlegen**

Die **After animation**‑Option steuert, was mit einer Form geschieht, nachdem ihr Effekt beendet ist.

![PowerPoint Effekt‑Optionen‑Dialog mit Nach‑Animations‑Einstellungen](shape-after-animation.png)

Die Aufzählung [AfterAnimationType](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/afteranimationtype/) unterstützt das Beibehalten der Form, das Ändern ihrer Farbe, das Ausblenden nach der Animation oder das Ausblenden beim nächsten Klick. Wenn der Typ [AfterAnimationType::Color](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/afteranimationtype/) ist, rufen Sie [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) auf, um zusätzlich die Farbe festzulegen.

Dieses eigenständige Beispiel erstellt einen Effekt, legt dessen Nach‑Animationsverhalten über das zurückgegebene Effekt‑Objekt fest und speichert das Ergebnis.

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

Das Ändern des Typs von [AfterAnimationType::Color](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/afteranimationtype/) entfernt die Einstellung für die Nach‑Animations‑Farbe.

## **Text animieren**

Die Textanimation verfügt über zwei verwandte Steuerungen:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itextanimation/set_buildtype/) bestimmt, ob Absätze zusammen oder nach Absatz‑Ebene erscheinen.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) legt fest, ob der Text auf einmal, Wort‑ für Wort oder Buchstabe‑ für Buchstabe erscheint. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) setzt die Verzögerung zwischen Wörtern oder Buchstaben. Ein positiver Wert ist ein Prozentsatz der Effekt‑Dauer; ein negativer Wert ist eine Verzögerung in Sekunden.

Das folgende eigenständige Beispiel animiert die Wörter in einem Textfeld. [BuildType::AsOneObject](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/buildtype/) deaktiviert das Aufbauen Absatz‑für‑Absatz, sodass die Wort‑Einstellung für den gesamten Textrahmen gilt.

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

Um ein Textfeld Absatz für Absatz aufzubauen, verwenden Sie [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itextanimation/set_buildtype/) mit [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/buildtype/) oder einer anderen Absatz‑Ebene. Um einen einzelnen Absatz mit einem eigenen Effekt zu adressieren, nutzen Sie die Überladung von [ISequence::AddEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/isequence/addeffect/), die ein [IParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/) akzeptiert. Siehe [Animated Text](/slides/de/cpp/animated-text/) für Beispiele auf Absatz‑Ebene.

## **Export‑ und Kompatibilitätsnotizen**

- Das Speichern als PPT oder PPTX bewahrt das Animationsmodell, aber die endgültige Wiedergabe wird vom Präsentations‑Viewer gesteuert.
- PDF und statische Bilder spielen keine Animationen ab. Verwenden Sie [HTML5 export](/slides/de/cpp/export-to-html5/), animierte GIFs oder [Video conversion](/slides/de/cpp/convert-powerpoint-to-video/), wenn die Ausgabe Bewegung zeigen muss.
- Für HTML5 aktivieren Sie [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/html5options/set_animateshapes/) und bei Bedarf [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/html5options/set_animatetransitions/).
- Die Video‑Renderung unterstützt viele gängige Eintritts‑, Betonungs‑, Austritts‑ und Bewegungs‑Pfad‑Effekte, jedoch nicht jeden PowerPoint‑Effekt. Prüfen Sie die aktuelle [supported animations and effects](/slides/de/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) und testen Sie kritische Präsentationen mit Ihrer Ziel‑Aspose.Slides‑Version.
- Erweiterte benutzerdefinierte Effekte und aus anderen Präsentationsformaten importierte Effekte können in der Datei erhalten bleiben, werden jedoch in PowerPoint, HTML5 oder Video unterschiedlich gerendert. Validieren Sie das exportierte Ergebnis, anstatt sich ausschließlich auf den Effekt‑Namen zu verlassen.

## **FAQ**

**Warum erscheint eine Animation in PowerPoint, aber nicht in einem PDF?**

PDF ist ein statisches Format, daher werden Animationen und Folienübergänge nicht abgespielt. Exportieren Sie zu HTML5, animiertem GIF oder Video, wenn Bewegung erhalten bleiben muss.

**Warum wird ein Effekt in einem Video anders wiedergegeben?**

Der Video‑Export rendert Animationen, anstatt das ursprüngliche PowerPoint‑Verhalten zu speichern. Einige fortgeschrittene Effekte werden nicht unterstützt oder nur approximativ wiedergegeben. Prüfen Sie die Tabelle der unterstützten Effekte und testen Sie die eigentliche Präsentation vor dem produktiven Einsatz.

**Ändert das Vor‑ oder Zurückverschieben einer Form ihre Animationsreihenfolge?**

Nein. Die Z‑Reihenfolge einer Form bestimmt die Überlappung, während die Reihenfolge der Sequenzen und die Auslöser die Wiedergabe der Animationen steuern. Ändern Sie die Zeitleiste, wenn Sie eine andere Wiedergabereihenfolge benötigen.