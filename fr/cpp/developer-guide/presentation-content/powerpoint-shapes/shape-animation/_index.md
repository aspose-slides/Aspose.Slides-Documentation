---
title: Appliquer des animations de forme dans les présentations avec C++
linktitle: Animation de forme
type: docs
weight: 60
url: /fr/cpp/shape-animation/
keywords:
- forme
- animation
- effet
- forme animée
- texte animé
- ajouter animation
- obtenir animation
- extraire animation
- ajouter effet
- obtenir effet
- extraire effet
- son d'effet
- appliquer animation
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à ajouter, inspecter et personnaliser les animations de forme, le minutage, les sons, le comportement après l'animation et le texte animé avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Aspose.Slides for C++ représente les animations de diapositive comme des effets dans une chronologie de diapositive. Un effet possède une forme cible, un type et sous‑type d’animation, un déclencheur, des paramètres de minutage et des propriétés optionnelles telles que le son ou le comportement après l’animation.

La chronologie contient deux types de séquences :

- La **séquence principale** se lit lorsque la diapositive avance.
- Une **séquence interactive** démarre lorsque sa forme déclencheur est cliquée.

Comme les zones de texte, les images, les graphiques, les tableaux et les autres objets de diapositive implémentent [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/), vous utilisez la même méthode [ISequence::AddEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/isequence/addeffect/) pour la plupart du contenu de diapositive. Les effets disponibles sont répertoriés dans l’énumération [EffectType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/effecttype/).

## **Ajouter des animations de forme**

Pour ajouter une animation, obtenez la séquence principale de la diapositive et appelez [ISequence::AddEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/isequence/addeffect/) avec la forme cible, le type d’effet, le sous‑type et le déclencheur. Pour un effet qui démarre lorsqu’une autre forme est cliquée, créez une séquence interactive dont le déclencheur est cette autre forme.

L’exemple suivant crée les deux types d’animation et enregistre le résultat dans `shape-animations.pptx`.

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

Le déclencheur contrôle le moment où un effet démarre :

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/effecttriggertype/) attend un clic dans la séquence principale, ou un clic sur la forme déclencheur dans une séquence interactive.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/effecttriggertype/) démarre avec l’effet précédent.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/effecttriggertype/) démarre lorsque l’effet précédent se termine.

Pour animer une image, un graphique ou un autre type de forme, transmettez cet objet à [ISequence::AddEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/isequence/addeffect/) à la place de `targetShape`. Pour les options de groupement spécifiques aux graphiques, voir [Animated Charts](/slides/fr/cpp/animated-charts/).

## **Lire les animations de forme**

Utilisez [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) lorsque vous connaissez la forme cible. Pour inspecter chaque effet, parcourez la séquence principale et chaque séquence interactive. L’énumération évite de supposer qu’une séquence contient un effet à l’index `0`.

L’exemple suivant crée une forme avec des effets de séquence principale et interactive, récupère les effets qui ciblent la forme, puis parcourt chaque séquence de la diapositive.

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

Si vous avez besoin uniquement des effets pour une forme, identifiez d’abord la forme par son nom, son type de zone réservée ou une autre propriété stable ; puis appelez [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/isequence/geteffectsbyshape/). Ne supposez pas que [IShapeCollection::idx_get](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/idx_get/) à l’index `0` soit toujours l’objet souhaité.

## **Travailler avec les effets de zone réservée hérités**

Une zone réservée sur une diapositive normale peut hériter du comportement d’animation de la zone réservée correspondante sur la diapositive de disposition et sur la diapositive maître. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/getbaseplaceholder/) renvoie cette zone réservée parent, ou `nullptr` lorsqu’aucun parent n’existe.

Dans la présentation d’exemple suivante, le pied de page possède **Random Bars** sur la diapositive normale, **Split** sur la diapositive de disposition et **Fly In** sur la diapositive maître.

![Effet d’animation du pied de page sur la diapositive normale](slide-shape-animation.png)

![Effet d’animation du pied de page sur la diapositive de disposition](layout-shape-animation.png)

![Effet d’animation du pied de page sur la diapositive maître](master-shape-animation.png)

L’exemple suivant construit lui‑même la hiérarchie des zones réservées. Il ajoute des effets à une zone réservée maître, à une zone réservée de disposition et à la zone réservée correspondante sur une diapositive normale. Chaque appel à [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/getbaseplaceholder/) est vérifié avant d’utiliser la forme renvoyée.

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

## **Modifier le minutage de l’animation**

La boîte de dialogue **Timing** de PowerPoint correspond aux méthodes de [ITiming](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/).

![Boîte de dialogue Timing de PowerPoint pour un effet d’animation](shape-animation.png)

- **Start** correspond à [ITiming::set_TriggerType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/set_triggertype/).
- **Duration** correspond à [ITiming::set_Duration](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/set_duration/), en secondes.
- **Delay** correspond à [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/), en secondes.
- **Repeat** correspond à [ITiming::set_RepeatCount](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/), ou [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/).
- **Rewind when done playing** correspond à [ITiming::set_Rewind](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/set_rewind/).

Cet exemple autonome ajoute un effet, modifie son minutage via l’objet renvoyé par [ISequence::AddEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/isequence/addeffect/), et enregistre le résultat. Conserver la référence renvoyée à [IEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ieffect/) évite de devoir utiliser un indice de collection inutile.

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

Utilisez un seul mode de répétition à la fois. Combiner un nombre de répétitions avec un indicateur « until » peut produire des résultats confus dans différents visionneurs. Lors du changement de mode de répétition, appelez d’abord [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) et [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) avant [ITiming::set_RepeatCount](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/set_repeatcount/), car le réglage de l’un de ces indicateurs modifie également le mode de répétition actif.

## **Ajouter et extraire les sons d’animation**

Un effet d’animation peut référencer un audio embarqué via [IEffect::set_Sound](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ieffect/set_sound/). [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) indique à un effet d’arrêter le son lancé par un effet antérieur.

### **Ajouter un son à un effet**

L’exemple suivant suppose un fichier audio local nommé `animation-sound.wav`. Il crée deux effets, intègre ce fichier comme son du premier effet, et configure le second effet pour arrêter le son. Il utilise les objets renvoyés par [ISequence::AddEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/isequence/addeffect/), aucune indexation de séquence n’est donc requise.

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

### **Extraire les sons d’effet embarqués**

L’exemple suivant suppose une présentation locale nommée `presentation-with-animation-sounds.pptx`. Il parcourt les séquences principales et interactives et écrit chaque son d’effet embarqué dans le répertoire `extracted-animation-sounds`. L’extension est choisie à partir du type MIME audio fourni par [IAudio::get_ContentType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iaudio/get_contenttype/).

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

Pour les objets audio volumineux, utilisez [IAudio::GetStream](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iaudio/getstream/) et copiez le flux vers un fichier au lieu de charger l’ensemble de l’objet dans un tableau d’octets.

## **Définir le comportement après l’animation**

L’option **After animation** contrôle ce qui arrive à une forme après la fin de son effet.

![Boîte de dialogue Options d’effet de PowerPoint affichant les paramètres After animation](shape-after-animation.png)

L’énumération [AfterAnimationType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/afteranimationtype/) propose de laisser la forme inchangée, de changer sa couleur, de la masquer après l’animation, ou de la masquer au clic suivant. Lorsque le type est [AfterAnimationType::Color](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/afteranimationtype/), appelez [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) pour définir également la couleur.

Cet exemple autonome crée un effet, définit son comportement après l’animation via l’objet effet renvoyé, et enregistre le résultat.

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

Modifier le type en dehors de [AfterAnimationType::Color](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/afteranimationtype/) efface la couleur définie pour l’après‑animation.

## **Animer du texte**

L’animation de texte possède deux contrôles associés :

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itextanimation/set_buildtype/) contrôle si les paragraphes apparaissent ensemble ou par niveau de paragraphe.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) contrôle si le texte apparaît d’un seul coup, par mot ou par lettre. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) définit le délai entre les mots ou les lettres. Une valeur positive représente un pourcentage de la durée de l’effet ; une valeur négative représente un délai en secondes.

L’exemple autonome suivant anime les mots d’une zone de texte. [BuildType::AsOneObject](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/buildtype/) désactive la construction paragraphe par paragraphe afin que le réglage par mot s’applique à tout le cadre de texte.

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

Pour construire une zone de texte paragraphe par paragraphe, utilisez [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itextanimation/set_buildtype/) avec [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/buildtype/) ou un autre niveau de paragraphe. Pour cibler un seul paragraphe avec son propre effet, utilisez la surcharge de [ISequence::AddEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/isequence/addeffect/) qui accepte un [IParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iparagraph/). Consultez [Animated Text](/slides/fr/cpp/animated-text/) pour des exemples au niveau du paragraphe.

## **Exportation et notes de compatibilité**

- L’enregistrement au format PPT ou PPTX conserve le modèle d’animation, mais la lecture finale dépend du visionneur de présentation.
- Le PDF et les images statiques ne lisent pas les animations. Utilisez [HTML5 export](/slides/fr/cpp/export-to-html5/), GIF animé ou [conversion vidéo](/slides/fr/cpp/convert-powerpoint-to-video/) lorsque la sortie doit montrer du mouvement.
- Pour HTML5, activez [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/html5options/set_animateshapes/) et, si nécessaire, [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/html5options/set_animatetransitions/).
- Le rendu vidéo prend en charge de nombreux effets d’entrée, d’emphase, de sortie et de trajectoire, mais tous les effets PowerPoint ne sont pas supportés. Vérifiez la liste actuelle des [animations et effets pris en charge](/slides/fr/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) et testez les présentations critiques avec votre version cible d’Aspose.Slides.
- Les effets personnalisés avancés et les effets importés d’autres formats de présentation peuvent être conservés dans le fichier mais rendus différemment dans PowerPoint, HTML5 ou vidéo. Validez le résultat exporté plutôt que de vous fier uniquement au nom de l’effet.

## **FAQ**

**Pourquoi une animation apparaît‑elle dans PowerPoint mais pas dans un PDF ?**

Le PDF est un format statique, donc les animations et les transitions de diapositive ne sont pas lues. Exportez vers HTML5, GIF animé ou vidéo lorsque le mouvement doit être conservé.

**Pourquoi un effet se lit‑il différemment dans une vidéo ?**

L’exportation vidéo rend les animations plutôt que de stocker le comportement PowerPoint d’origine. Certains effets avancés ne sont pas pris en charge ou sont approximés. Consultez le tableau des effets pris en charge et testez la présentation réelle avant une utilisation en production.

**Le déplacement d’une forme vers l’avant ou l’arrière modifie‑t‑il l’ordre de son animation ?**

Non. L’ordre Z contrôle le chevauchement, tandis que l’ordre de la séquence et les déclencheurs contrôlent la lecture de l’animation. Modifiez la chronologie si vous avez besoin d’un ordre de lecture différent.