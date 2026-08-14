---
title: Applica animazioni di forma nelle presentazioni usando C++
linktitle: Animazione forma
type: docs
weight: 60
url: /it/cpp/shape-animation/
keywords:
- forma
- animazione
- effetto
- forma animata
- testo animato
- aggiungi animazione
- ottieni animazione
- estrai animazione
- aggiungi effetto
- ottieni effetto
- estrai effetto
- suono effetto
- applica animazione
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come aggiungere, ispezionare e personalizzare le animazioni di forma, la temporizzazione, i suoni, il comportamento dopo l'animazione e il testo animato con Aspose.Slides per C++."
---
## **Panoramica**

Aspose.Slides per C++ rappresenta le animazioni delle diapositive come effetti in una timeline della diapositiva. Un effetto ha una forma di destinazione, un tipo e un sottotipo di animazione, un trigger, impostazioni di temporizzazione e proprietà opzionali come suono o comportamento dopo l'animazione.

La timeline contiene due tipi di sequenze:

- La **sequenza principale** viene riprodotta mentre la diapositiva avanza.  
- Una **sequenza interattiva** inizia quando la sua forma di trigger viene cliccata.

Poiché caselle di testo, immagini, grafici, tabelle e altri oggetti della diapositiva implementano [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/), si utilizza lo stesso metodo [ISequence::AddEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/isequence/addeffect/) per la maggior parte del contenuto della diapositiva. Gli effetti disponibili sono elencati nell’enumerazione [EffectType](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/effecttype/).

## **Aggiungere animazioni a forme**

Per aggiungere un'animazione, ottieni la sequenza principale della diapositiva e chiama [ISequence::AddEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/isequence/addeffect/) passando la forma di destinazione, il tipo di effetto, il sottotipo e il trigger. Per un effetto che inizia quando un'altra forma viene cliccata, crea una sequenza interattiva il cui trigger è quell'altra forma.

L’esempio seguente crea entrambi i tipi di animazione e salva il risultato in `shape-animations.pptx`.

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

Il trigger controlla quando un effetto inizia:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/effecttriggertype/) attende un clic nella sequenza principale, o un clic sulla forma di trigger in una sequenza interattiva.  
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/effecttriggertype/) inizia insieme all’effetto precedente.  
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/effecttriggertype/) inizia al termine dell’effetto precedente.

Per animare un’immagine, un grafico o un altro tipo di forma, passa quell’oggetto a [ISequence::AddEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/isequence/addeffect/) invece di `targetShape`. Per le opzioni di raggruppamento specifiche per i grafici, vedere [Grafici animati](/slides/it/cpp/animated-charts/).

## **Leggere le animazioni delle forme**

Usa [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) quando conosci la forma di destinazione. Per ispezionare ogni effetto, enumera la sequenza principale e ogni sequenza interattiva. L’enumerazione evita di presumere che una sequenza contenga un effetto all’indice `0`.

L’esempio seguente crea una forma con effetti nella sequenza principale e in quella interattiva, ottiene gli effetti che hanno come target la forma e poi enumera ogni sequenza nella diapositiva.

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

Se ti servono solo gli effetti per una singola forma, individua prima la forma per nome, tipo di segnaposto o un’altra proprietà stabile; quindi chiama [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/isequence/geteffectsbyshape/). Non presumere che [IShapeCollection::idx_get](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/idx_get/) all’indice `0` sia sempre l’oggetto desiderato.

## **Lavorare con gli effetti ereditati dei segnaposti**

Un segnaposto su una diapositiva normale può ereditare il comportamento di animazione dal corrispondente segnaposto nella diapositiva layout e nella diapositiva master. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/getbaseplaceholder/) restituisce quel segnaposto genitore, o `nullptr` quando non esiste un genitore.

Nella presentazione di esempio seguente, il piè di pagina ha **Random Bars** sulla diapositiva normale, **Split** sulla diapositiva layout e **Fly In** sulla diapositiva master.

![Effetto di animazione del piè di pagina sulla diapositiva normale](slide-shape-animation.png)

![Effetto di animazione del segnaposto piè di pagina sulla diapositiva layout](layout-shape-animation.png)

![Effetto di animazione del segnaposto piè di pagina sulla diapositiva master](master-shape-animation.png)

L’esempio successivo costruisce la gerarchia dei segnaposti stessa. Aggiunge effetti a un segnaposto master, a un segnaposto layout e al corrispondente segnaposto su una diapositiva normale. Ogni chiamata a [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/getbaseplaceholder/) viene verificata prima di utilizzare la forma restituita.

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

## **Modificare la temporizzazione dell'animazione**

La finestra di dialogo PowerPoint **Timing** corrisponde ai metodi di [ITiming](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/).

![Finestra di dialogo Timing di PowerPoint per un effetto di animazione](shape-animation.png)

- **Start** corrisponde a [ITiming::set_TriggerType](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/set_triggertype/).  
- **Duration** corrisponde a [ITiming::set_Duration](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/set_duration/), in secondi.  
- **Delay** corrisponde a [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/), in secondi.  
- **Repeat** corrisponde a [ITiming::set_RepeatCount](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) o [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/).  
- **Rewind when done playing** corrisponde a [ITiming::set_Rewind](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/set_rewind/).

Questo esempio indipendente aggiunge un effetto, ne cambia la temporizzazione tramite l’oggetto restituito da [ISequence::AddEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/isequence/addeffect/) e salva il risultato. Mantenere il riferimento al [IEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/) restituito evita di usare un indice di raccolta non necessario.

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

Usa un solo modo di ripetizione intenzionalmente. Combinare un conteggio di ripetizioni con un flag “until” può produrre risultati confusi in diversi visualizzatori. Quando cambi i modi di ripetizione, chiama prima [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) e [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) e solo dopo [ITiming::set_RepeatCount](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/set_repeatcount/), perché impostare uno dei flag cambia anche il modo di ripetizione attivo.

## **Aggiungere ed estrarre suoni di animazione**

Un effetto di animazione può fare riferimento a un audio incorporato tramite [IEffect::set_Sound](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_sound/). [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) indica a un effetto di fermare l’audio avviato da un effetto precedente.

### **Aggiungere un suono a un effetto**

L’esempio seguente prevede un file audio locale chiamato `animation-sound.wav`. Crea due effetti, incorpora quel file come suono per il primo effetto e configura il secondo effetto per fermare il suono. Utilizza gli oggetti restituiti da [ISequence::AddEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/isequence/addeffect/), quindi non è necessario alcun indice di sequenza.

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

### **Estrarre suoni di effetti incorporati**

L’esempio seguente prevede una presentazione locale chiamata `presentation-with-animation-sounds.pptx`. Scansiona sia le sequenze principali sia quelle interattive e scrive ogni suono di effetto incorporato nella directory `extracted-animation-sounds`. L’estensione è selezionata dal tipo MIME audio esposto da [IAudio::get_ContentType](https://reference.aspose.com/slides/it/cpp/aspose.slides/iaudio/get_contenttype/).

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

Per oggetti audio di grandi dimensioni, usa [IAudio::GetStream](https://reference.aspose.com/slides/it/cpp/aspose.slides/iaudio/getstream/) e copia lo stream in un file invece di caricare l’intero oggetto in un array di byte.

## **Impostare il comportamento dopo l'animazione**

L’opzione **After animation** controlla cosa accade a una forma dopo che il suo effetto è terminato.

![Finestra di dialogo Opzioni effetto di PowerPoint che mostra le impostazioni After animation](shape-after-animation.png)

L’enumerazione [AfterAnimationType](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/afteranimationtype/) supporta il mantenimento invariato della forma, il cambiamento del colore, la sua scomparsa dopo l’animazione o la scomparsa al prossimo clic. Quando il tipo è [AfterAnimationType::Color](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/afteranimationtype/), chiama [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) per impostare anche il colore.

Questo esempio indipendente crea un effetto, ne imposta il comportamento dopo l’animazione tramite l’oggetto effetto restituito e salva il risultato.

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

Cambiare il tipo da [AfterAnimationType::Color](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/afteranimationtype/) cancella l’impostazione del colore after‑animation.

## **Animare il testo**

L’animazione del testo ha due controlli correlati:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itextanimation/set_buildtype/) determina se i paragrafi appaiono tutti insieme o a livello di paragrafo.  
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) determina se il testo appare tutto in una volta, parola per parola o lettera per lettera. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) imposta il ritardo tra parole o lettere. Un valore positivo è una percentuale della durata dell’effetto; un valore negativo è un ritardo in secondi.

L’esempio indipendente seguente anima le parole in una casella di testo. [BuildType::AsOneObject](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/buildtype/) disabilita la costruzione parola per parola in modo che l’impostazione delle parole si applichi all’intero riquadro di testo.

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

Per costruire una casella di testo per paragrafo, utilizza [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itextanimation/set_buildtype/) con [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/buildtype/) o un altro livello di paragrafo. Per assegnare a un singolo paragrafo il proprio effetto, utilizza la sovraccarico di [ISequence::AddEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/isequence/addeffect/) che accetta un [IParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/). Vedi [Testo animato](/slides/it/cpp/animated-text/) per esempi a livello di paragrafo.

## **Esportazione e note di compatibilità**

- Salvare in PPT o PPTX preserva il modello di animazione, ma la riproduzione finale è controllata dal visualizzatore della presentazione.  
- PDF e immagini statiche non riproducono animazioni. Usa l’[esportazione HTML5](/slides/it/cpp/export-to-html5/), GIF animata o la [conversione video](/slides/it/cpp/convert-powerpoint-to-video/) quando l’output deve mostrare movimento.  
- Per HTML5, abilita [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/html5options/set_animateshapes/) e, se necessario, [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/html5options/set_animatetransitions/).  
- Il rendering video supporta molti effetti di ingresso, enfasi, uscita e percorso di movimento comuni, ma non tutti gli effetti di PowerPoint sono supportati. Controlla le [animazioni ed effetti supportati](/slides/it/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) attuali e verifica le presentazioni critiche con la versione di Aspose.Slides in uso.  
- Effetti personalizzati avanzati e effetti importati da altri formati di presentazione possono essere preservati nel file ma renderizzati in modo diverso in PowerPoint, HTML5 o video. Convalida il risultato esportato invece di fare affidamento solo sul nome dell’effetto.

## **FAQ**

**Perché un’animazione compare in PowerPoint ma non in un PDF?**

Il PDF è un formato statico, quindi le animazioni e le transizioni delle diapositive non vengono riprodotte. Esporta in HTML5, GIF animata o video quando è necessario preservare il movimento.

**Perché un effetto viene riprodotto in modo diverso in un video?**

L’esportazione video rende le animazioni invece di memorizzare il comportamento originale di PowerPoint. Alcuni effetti avanzati non sono supportati o sono approssimati. Consulta la tabella degli effetti supportati e testa la presentazione reale prima dell’uso in produzione.

**Spostare una forma avanti o indietro cambia l’ordine di animazione?**

No. Lo z‑order della forma controlla la sovrapposizione, mentre l’ordine delle sequenze e i trigger controllano la riproduzione delle animazioni. Modifica la timeline se desideri un ordine di riproduzione diverso.