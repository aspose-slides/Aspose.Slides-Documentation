---
title: Crea e modifica comportamenti di animazione personalizzati in C++
linktitle: Animazione personalizzata
type: docs
weight: 151
url: /it/cpp/custom-animation/
keywords:
- animazione personalizzata
- comportamento di animazione
- percorso di movimento
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Crea, ispeziona e modifica comportamenti di animazione personalizzati e percorsi di movimento modificabili nelle presentazioni PowerPoint con Aspose.Slides per C++."
---
## **Panoramica**

I comportamenti di animazione personalizzati ti consentono di controllare operazioni individuali all'interno di un effetto di animazione, come cambiare un colore, ruotare una forma o seguire un percorso di movimento modificabile. Questa guida mostra come creare e combinare comportamenti, configurarne la tempistica, ispezionare e modificare le animazioni esistenti e verificare che le loro proprietà sopravvivano al salvataggio e alla riapertura di una presentazione.

Per effetti predefiniti e trigger di clic, vedi [Shape Animation](/slides/it/cpp/shape-animation/).

## **Comprendere il modello di animazione**

Un'animazione è organizzata come **Timeline → Sequence → Effect → Behaviors**:

- Il [get_Timeline](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslide/get_timeline/) della diapositiva contiene la sua sequenza principale e le sequenze interattive.  
- Un [ISequence](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/isequence/) contiene gli effetti, potenzialmente rivolti a forme diverse.  
- Un [IEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/) identifica una forma di destinazione, un preset, un sottotipo e la tempistica dell'effetto.  
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/get_behaviors/) contiene le operazioni che implementano l'effetto: cambiare colore, spostare, ruotare, impostare una proprietà e così via.

## **Creare comportamenti individuali**

Chiama [ISequence::AddEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/isequence/addeffect/) per creare un effetto e accedere alla sua collezione [get_Behaviors](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/get_behaviors/). Un preset può popolare automaticamente questa collezione. Conserva le sue operazioni quando estendi il preset, o usa [Clear](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorcollection/clear/) quando le sostituisci deliberatamente.

[IBehaviorFactory](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorfactory/) crea gli otto tipi di comportamento illustrati di seguito. Il movimento è trattato in [Build a Motion Path](#build-a-motion-path). Ogni esempio di creazione è codice autonomo da eseguire all'interno di una funzione; gli esempi di modifica successivi indicano quale file di output utilizzano.

### **Rotazione**

Usa [CreateRotationEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) per creare una rotazione. [get_By](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/irotationeffect/get_by/) specifica un angolo relativo in gradi; [get_From](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/irotationeffect/get_from/) e [get_To](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/irotationeffect/get_to/) specificano i punti finali.

L'esempio inizia con un effetto Spin, sostituisce le sue operazioni preset con un comportamento di rotazione e assegna a tale operazione una durata di due secondi. Un angolo relativo di 90 gradi rappresenta un quarto di giro rispetto all'orientamento iniziale della forma, quindi non è necessario un angolo iniziale esplicito.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto rotation = factory->CreateRotationEffect();
rotation->set_By(90.0f);
rotation->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(rotation);

presentation->Save(u"rotation.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`rotation.pptx` contiene una forma e un comportamento di rotazione. La collezione, la temporizzazione e gli esempi di modifica della rotazione seguenti utilizzano questo file.

### **Scala**

Usa [CreateScaleEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) con percentuali X/Y: [get_From](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/iscaleeffect/get_from/) e [get_To](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/iscaleeffect/get_to/) descrivono le dimensioni iniziali e finali, mentre [get_By](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/iscaleeffect/get_by/) descrive una variazione relativa. Qui, 100 indica la dimensione originale.

L'esempio aumenta entrambe le dimensioni dal 100% al 125% in due secondi. L'uso di percentuali orizzontali e verticali uguali mantiene le proporzioni della forma; percentuali diverse allungherebbero una dimensione più dell'altra.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_From(PointF(100, 100));
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(scale);

presentation->Save(u"scale.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Colore**

Usa [CreateColorEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) per cambiare il riempimento da blu a arancione. [get_From](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/icoloreffect/get_from/) e [get_To](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/icoloreffect/get_to/) sono colori; [get_By](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/icoloreffect/get_by/) è una variazione di colore. [IBehavior::get_Properties](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehavior/get_properties/) identifica l'attributo animato.

Il riempimento solido della forma è inizializzato a blu, corrispondente al colore iniziale dell'animazione. Selezionare l'attributo fill-color indica al comportamento quale parte della forma cambiare; i soli punti finali di colore non identificano quell'attributo. L'effetto salvato descrive una transizione di due secondi verso l'arancione.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IColorEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/FillType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto color = factory->CreateColorEffect();
color->get_Properties()->Add(BehaviorProperty::get_FillColor()->get_Value());
color->get_From()->set_Color(Color::get_Blue());
color->get_To()->set_Color(Color::get_Orange());
color->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(color);

presentation->Save(u"color.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Filtro**

Usa [CreateFilterEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) per selezionare un effetto di cancellazione. [get_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ifiltereffect/get_subtype/), e [get_Reveal](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) specificano il filtro, la direzione e se rivelare o nascondere la forma.

Questo esempio configura una cancellazione di due secondi che rivela la forma usando il sottotipo di direzione destra. Le impostazioni del filtro appartengono al comportamento all'interno dell'effetto, quindi vengono configurate dopo che le operazioni originali del preset sono state rimosse.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/FilterEffectRevealType.h>
#include <DOM/Animation/FilterEffectSubtype.h>
#include <DOM/Animation/FilterEffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IFilterEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto filter = factory->CreateFilterEffect();
filter->set_Type(FilterEffectType::Wipe);
filter->set_Subtype(FilterEffectSubtype::Right);
filter->set_Reveal(FilterEffectRevealType::In);
filter->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(filter);

presentation->Save(u"filter.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Proprietà**

Usa [CreatePropertyEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) per animare l'opacità. [get_From](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ipropertyeffect/get_to/), e [get_By](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ipropertyeffect/get_by/) sono stringhe interpretate usando [get_ValueType](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) e [get_CalcMode](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/). Scegli i punti finali o una variazione relativa anziché impostare tutti e tre indiscriminatamente.

Qui, l'attributo selezionato è l'opacità, e le stringhe numeriche rappresentano una variazione dal 25% di opacità all'opacità completa. L'interpolazione lineare descrive una variazione graduale tra questi valori. Quando adatti questo esempio a un altro attributo, scegli un tipo di valore e valori finali appropriati a quell'attributo.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IPropertyEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/PropertyCalcModeType.h>
#include <DOM/Animation/PropertyValueType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto property = factory->CreatePropertyEffect();
property->get_Properties()->Add(BehaviorProperty::get_StyleOpacity()->get_Value());
property->set_ValueType(PropertyValueType::Number);
property->set_CalcMode(PropertyCalcModeType::Linear);
property->set_From(u"0.25");
property->set_To(u"1");
property->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(property);

presentation->Save(u"property.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Imposta**

Usa [CreateSetEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) per assegnare la visibilità tramite [get_To](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/iseteffect/get_to/). Un comportamento set non interpola tra i punti finali.

L'esempio seleziona l'attributo visibilità e assegna la stringa `visible` quando il comportamento viene eseguito. In C++, incapsula la stringa come oggetto prima di assegnarla al comportamento set. Il rettangolo è già visibile in questa presentazione minimale, quindi l'assegnazione potrebbe non produrre un cambiamento visivo evidente da sola. Un'operazione del genere è utile come parte di un effetto più ampio che controlla anche quando la forma diventa nascosta o visibile.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISetEffect.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto set = factory->CreateSetEffect();
set->get_Properties()->Add(BehaviorProperty::get_StyleVisibility()->get_Value());
auto visibility = ObjectExt::Box<String>(u"visible");
set->set_To(visibility);

effect->get_Behaviors()->Add(set);

presentation->Save(u"set.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Comando**

Usa [CreateCommandEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) e configura [get_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/icommandeffect/get_commandstring/), e [get_ShapeTarget](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/). Posiziona una registrazione WAV denominata `sample.wav` nella directory di lavoro. Questo esempio la incorpora con [AddAudioFrameEmbedded](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) e allega un comando di riproduzione al fotogramma audio.

Il fotogramma audio è sia il bersaglio dell'effetto sia il bersaglio del comando. Questo collega la richiesta di riproduzione alla registrazione incorporata; una stringa di comando da sola non identifica quale oggetto multimediale controllare. L'effetto è configurato per avviarsi con un clic durante la presentazione.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/CommandEffectType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/ICommandEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = IO::File::OpenRead(u"sample.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto command = factory->CreateCommandEffect();
command->set_Type(CommandEffectType::Call);
command->set_CommandString(u"play");
command->set_ShapeTarget(audioFrame);

effect->get_Behaviors()->Add(command);

presentation->Save(u"command.pptx", SaveFormat::Pptx);

audioStream->Close();

presentation->Dispose();
```

Il salvataggio memorizza il comando in `command.pptx`; non riproduce la registrazione. La riproduzione richiede un lettore di presentazioni che supporti il comando e il suo obiettivo multimediale.

## **Gestire la collezione di comportamenti**

[IBehaviorCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorcollection/) supporta [Add](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorcollection/remove/), e [RemoveAt](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorcollection/removeat/). Questo esempio apre `rotation.pptx`, aggiunge una scala, la sposta prima della rotazione e rimuove la rotazione. Rimuovere e reinserire lo stesso oggetto ne cambia la posizione memorizzata senza crearne una copia.

La sequenza di modifiche trasforma la collezione da rotazione–scala a scala–rotazione, poi a sola scala. Gli indici si riferiscono alla collezione corrente, quindi la rimozione utilizza il nuovo indice della rotazione dopo il riordino. L'enumerazione finale conferma quale comportamento verrà salvato.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto behaviors = effect->get_Behaviors();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

behaviors->Add(scale);

behaviors->Remove(scale);
behaviors->Insert(0, scale);
behaviors->RemoveAt(1);

for (auto behavior : behaviors)
    Console::WriteLine(behavior->GetType().get_Name());

presentation->Save(u"collection-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

L'output è `ScaleEffect`: rimane solo la scala. L'ordine della collezione, di per sé, non programma i comportamenti uno dopo l'altro. Pulisci la collezione solo quando sostituisci tutte le sue operazioni.

## **Configurare la temporizzazione dei comportamenti**

[IBehavior::get_Timing](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehavior/get_timing/) espone [ITiming](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/), indipendentemente da [IEffect::get_Timing](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/get_timing/). La temporizzazione dell'effetto pianifica l'effetto contenitore; la temporizzazione del comportamento descrive un'operazione al suo interno.

### **Impostare durata, ritardo, ripetizione e accelerazione**

Apri `rotation.pptx` e imposta [get_Duration](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/get_duration/) e [get_TriggerDelayTime](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) in secondi, poi configura [get_RepeatCount](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/get_repeatcount/). [get_Accelerate](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/get_accelerate/) e [get_Decelerate](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/get_decelerate/) sono frazioni della durata; mantieni la loro somma al massimo 1.

Il file di input è quello creato nell'esempio di rotazione, dove il primo comportamento è noto essere una rotazione. Questo esempio modifica solo la temporizzazione di quel comportamento; il suo angolo di 90 gradi rimane invariato. Tenere separati angolo e temporizzazione facilita la regolazione della velocità senza ricostruire l'animazione.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto rotation = ExplicitCast<IRotationEffect>(effect->get_Behaviors()->idx_get(0));
rotation->get_Timing()->set_Duration(2.0f);
rotation->get_Timing()->set_TriggerDelayTime(0.5f);
rotation->get_Timing()->set_RepeatCount(3.0f);
rotation->get_Timing()->set_Accelerate(0.2f);
rotation->get_Timing()->set_Decelerate(0.2f);

presentation->Save(u"timing.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Il comportamento utilizza una durata di due secondi, un ritardo di mezzo secondo e un conteggio di ripetizione pari a 3. Il primo e l'ultimo 20% della sua durata sono usati per accelerazione e decelerazione.

Altre politiche di ripetizione includono [get_RepeatDuration](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), e [get_RepeatUntilNextClick](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/); scegli una politica anziché abilitarle tutte insieme. [get_AutoReverse](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itiming/get_autoreverse/) riproduce l'animazione al contrario dopo la fase in avanti. Accelerazione e decelerazione si applicano a cambiamenti continui, non a assegnazioni o comandi discreti.

## **Creare un percorso di movimento**

Usa [CreateMotionEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) per creare un movimento. I suoi [get_From](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/imotioneffect/get_to/), e [get_By](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/imotioneffect/get_by/) descrivono coordinate o offset basati su percentuali. Per un percorso modificabile, crea un [MotionPath](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/motionpath/) e assegnalo a [IMotionEffect::get_Path](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/imotioneffect/get_path/). [IMotionPath](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/imotionpath/) memorizza i comandi del percorso.

| Comando | Punti | Significato |
| --- | --- | --- |
| MoveTo | Uno | Imposta la posizione di partenza. |
| LineTo | Uno | Muovi lungo un segmento rettilineo fino al suo punto finale. |
| CurveTo | Tre | Segui una curva cubica definita da due punti di controllo e un punto finale. |
| CloseLoop | Nessuno | Ritorna alla posizione di partenza. |
| End | Nessuno | Termina il percorso. |

[MotionPathPointsType](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/motionpathpointstype/) descrive le caratteristiche di modifica dei punti, come punti angolo o lisci. Non sostituisce il tipo di comando. Usa un tipo di punto curva per l'esempio di curva qui sotto, e un tipo di punto angolo per i segmenti rettilinei.

Le coordinate del percorso sono normalizzate alle dimensioni della diapositiva: uno spostamento X di 0.25 rappresenta un quarto della larghezza della diapositiva, non 0.25 punti. Y positivo scorre verso il basso. I comandi assoluti specificano posizioni nel sistema di coordinate del percorso; i comandi relativi specificano offset dalla posizione corrente. Questo è separato da [get_Origin](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/imotioneffect/get_origin/), che seleziona il riferimento del percorso, e [get_PathEditMode](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/), che controlla come il percorso si muove quando la forma viene spostata.

### **Creare un percorso rettilineo**

Crea un comportamento di movimento con un punto di partenza, un segmento rettilineo e un comando di fine. [IMotionPath::Add](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/imotionpath/add/) accetta il tipo di comando, i suoi punti, il tipo di punto e un flag di coordinate relative.

Il comando di partenza stabilisce (0, 0), e la linea termina in (0.25, 0), fornendo al percorso uno spostamento orizzontale di un quarto della larghezza della diapositiva. Il comando finale non ha punti di coordinate. Una volta assegnato il percorso, aggiungere il comportamento di movimento all'effetto collega quel percorso al rettangolo.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionOriginType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto motion = factory->CreateMotionEffect();
motion->set_Origin(MotionOriginType::Layout);
motion->get_Timing()->set_Duration(2.0f);

auto path = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0, 0) });
path->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto linePoints = MakeArray<PointF>({ PointF(0.25f, 0) });
path->Add(MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
auto endPoints = MakeArray<PointF>(0);
path->Add(MotionCommandPathType::End, endPoints, MotionPathPointsType::None, false);

motion->set_Path(path);
effect->get_Behaviors()->Add(motion);

presentation->Save(u"motion.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion.pptx` contiene un comportamento di movimento con tre comandi di percorso. I seguenti esempi di modifica del file usano questa struttura nota.

### **Confrontare coordinate assolute e relative**

Questi due oggetti percorso descrivono lo stesso itinerario. Il comando assoluto termina in (0.3, 0.1); il comando relativo aggiunge (0.1, 0.1) alla posizione corrente, (0.2, 0).

Entrambi i percorsi iniziano nella stessa posizione. Per la linea relativa, aggiungi i suoi offset X e Y alla posizione corrente per ottenere il punto finale; per la linea assoluta, leggi direttamente il punto finale. Cambiare il flag senza convertire le coordinate descriverebbe un percorso diverso.

```cpp
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::Drawing;

auto absolutePath = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
absolutePath->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto absoluteEndPoints = MakeArray<PointF>({ PointF(0.3f, 0.1f) });
absolutePath->Add(MotionCommandPathType::LineTo, absoluteEndPoints, MotionPathPointsType::Corner, false);

auto relativePath = MakeObject<MotionPath>();
auto relativeStartPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
relativePath->Add(MotionCommandPathType::MoveTo, relativeStartPoints, MotionPathPointsType::Auto, false);
auto relativeOffsets = MakeArray<PointF>({ PointF(0.1f, 0.1f) });
relativePath->Add(MotionCommandPathType::LineTo, relativeOffsets, MotionPathPointsType::Corner, true);
```

Assegna uno dei due percorsi a un comportamento di movimento per usarlo in una presentazione. L'argomento booleano finale seleziona coordinate relative per quel comando.

### **Sostituire una linea con una curva**

Apri `motion.pptx` e sostituisci il suo comando di linea con una curva cubica. Fornisci prima i due punti di controllo, seguiti dal punto finale.

La posizione di partenza è fornita dal comando precedente. I primi due punti modellano la curva, mentre il terzo è la sua destinazione; non sono tre destinazioni successive. Aggiornare simultaneamente il tipo di comando, il tipo di modifica dei punti e l'array di punti mantiene il segmento coerente con la sua nuova geometria.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
path->idx_get(1)->set_CommandType(MotionCommandPathType::CurveTo);
path->idx_get(1)->set_PointsType(MotionPathPointsType::CurveSmooth);
auto curvePoints = MakeArray<PointF>({ PointF(0.1f, 0), PointF(0.2f, 0.1f), PointF(0.3f, 0.1f) });
path->idx_get(1)->set_Points(curvePoints);

presentation->Save(u"curve.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Il percorso in `curve.pptx` ha ancora tre comandi; il suo comando intermedio ora definisce una curva.

## **Ispezionare e modificare un percorso salvato**

Ogni [IMotionCmdPath](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/imotioncmdpath/) espone [get_Points](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), e [get_IsRelative](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/). I seguenti esempi usano il percorso noto di tre comandi in `motion.pptx`. Per input arbitrari, individua l'effetto desiderato e verifica i tipi di comando e il numero di punti prima di modificare per indice.

### **Leggere comandi e coordinate**

Leggi il percorso senza modificarlo. I comandi End e CloseLoop non richiedono punti, quindi è necessario prevedere un array di punti nullo.

L'output associa ogni comando al suo flag di coordinate relative prima di elencare i punti. Questo ti consente di distinguere un punto finale da un offset prima di modificare il percorso. Una curva elencherebbe tre punti, mentre la linea rettilinea in questo file ne elenca solo uno.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
for (auto segment : path)
{
    Console::WriteLine(u"{0}, relative: {1}", segment->get_CommandType(), segment->get_IsRelative());
    if (segment->get_Points() != nullptr)
        for (auto point : segment->get_Points())
            Console::WriteLine(u"X={0}, Y={1}", point.get_X(), point.get_Y());
}

presentation->Dispose();
```

L'elenco contiene un punto di partenza, una linea assoluta che termina in (0.25, 0) e un comando end.

### **Modificare un punto finale**

Apri `motion.pptx` e sostituisci l'array di punti della linea per spostare il suo punto finale.

Nel file di input, l'indice 0 è il comando di partenza e l'indice 1 è la linea. Sostituire il singolo punto della linea ne cambia la destinazione senza modificare il tipo di comando, la temporizzazione o la posizione nella collezione. Poiché il comando utilizza coordinate assolute, la nuova coppia specifica una posizione piuttosto che un offset aggiunto.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));
auto endpointPoints = MakeArray<PointF>({ PointF(0.4f, 0.1f) });
motion->get_Path()->idx_get(1)->set_Points(endpointPoints);

presentation->Save(u"motion-endpoint.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

La linea in `motion-endpoint.pptx` termina in (0.4, 0.1); il file originale rimane invariato.

### **Sostituire un segmento**

Usa [Insert](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/imotionpath/insert/) e [RemoveAt](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/imotionpath/removeat/) per sostituire la linea in `motion.pptx`. L'inserimento sposta la vecchia linea all'indice 2.

Questo dimostra la sostituzione di un oggetto comando anziché modificare le sue coordinate esistenti. Dopo l'inserimento, la collezione contiene temporaneamente il comando di partenza, la nuova linea, la vecchia linea e il comando end. Rimuovendo l'indice 2 si scarta la vecchia linea e si lascia il nuovo percorso al suo posto.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
auto linePoints = MakeArray<PointF>({ PointF(0.2f, 0.1f) });
path->Insert(1, MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
path->RemoveAt(2);

presentation->Save(u"motion-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Il percorso salvato ha ancora tre comandi, con la nuova linea che termina in (0.2, 0.1) e il comando end in ultima posizione.

## **Modificare e verificare un comportamento esistente**

Quando l'indice del comportamento è sconosciuto, selezionalo per tipo. Questo esempio apre `rotation.pptx`, trova il suo [IRotationEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/irotationeffect/), cambia l'angolo e controlla il valore salvato dopo la riapertura.

Il controllo del tipo consente al ciclo di saltare i comportamenti che non sono rotazioni. Il secondo caricamento legge il file salvato in un oggetto presentazione separato, quindi il confronto verifica i dati persistenti anziché il valore ancora in memoria. Questo esempio assume ancora che l'effetto noto sia il primo nella sequenza principale; selezionare un comportamento per tipo non individua l'effetto corretto in una presentazione arbitraria.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <cmath>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : effect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        rotation->set_By(180.0f);
}

presentation->Save(u"rotation-edited.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"rotation-edited.pptx");
auto savedEffect = reopened->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : savedEffect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        Console::WriteLine(u"Rotation preserved: {0}", std::abs(rotation->get_By() - 180.0f) < 0.001f);
}

presentation->Dispose();
reopened->Dispose();
```

L'output è `Rotation preserved: True`. Applica lo stesso schema di verifica del tipo ad altri comportamenti. Per un controllo completo della conservazione, confronta la forma di destinazione, l'effetto, i tipi e l'ordine dei comportamenti, la temporizzazione e i comandi del percorso. Usa una tolleranza numerica per i valori a virgola mobile. Per una presentazione con una struttura di animazione sconosciuta, vedi [Read Shape Animations](/slides/it/cpp/shape-animation/#read-shape-animations) per l'attraversamento delle sequenze principali e interattive.

## **Ordine dei comportamenti, preset e riproduzione**

L'ordine in [IBehaviorCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehaviorcollection/) è l'ordine memorizzato delle operazioni di un effetto. Non è una playlist in cui ogni comportamento attende automaticamente il precedente. La temporizzazione e l'effetto contenitore determinano la programmazione. I comportamenti possono sovrapporsi, e le operazioni sulla stessa proprietà possono interagire tramite [get_Additive](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehavior/get_additive/) e [get_Accumulate](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ibehavior/get_accumulate/). Non utilizzare solo il riordino della collezione per programmare “muovi, poi ruota”; usa temporizzazioni esplicite o effetti separati come descritto in [Shape Animation](/slides/it/cpp/shape-animation/).

Il [get_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/get_type/) e il [get_Subtype](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/get_subtype/) dell'effetto descrivono il suo preset. Non sono una descrizione completa di un albero di comportamenti modificato. Scegli il preset e il sottotipo prima di personalizzare i comportamenti: cambiare il preset può ricostruire la collezione e scartare le tue operazioni personalizzate. Per esempio, cambiare un effetto Spin personalizzato in Fade può sostituire il suo comportamento di rotazione con comportamenti set e filter. Controlla nuovamente la collezione dopo aver cambiato un preset o un sottotipo. Cancellare i comportamenti del preset può anche rimuovere operazioni di visibilità o di inizializzazione di cui il preset ha bisogno. Gli esempi usano deliberatamente forme visibili e sostituiscono i comportamenti; non ricostruiscono l'implementazione di ogni preset.

## **Compatibilità dei formati**

Un albero di comportamenti preservato non garantisce una riproduzione identica in ogni visualizzatore o motore di esportazione. Controlla separatamente i dati salvati e l'output renderizzato.

| Formato o output | Cosa verificare |
| --- | --- |
| PPTX | Usalo come formato principale per questi esempi. Riaprilo per verificare l’albero di comportamenti modificabile, poi controlla la riproduzione nella versione di PowerPoint desiderata. |
| PPT | La rappresentazione binaria legacy può differire da PPTX. Testa un ciclo di salvataggio‑riapertura separato e la riproduzione; non inferire il supporto per ogni combinazione personalizzata dal risultato PPTX riuscito. |
| PDF, PNG, JPEG, and other static slide images | Contengono una rappresentazione statica della diapositiva, non una timeline di comportamenti riproducibile o un fotogramma finale di animazione garantito. |
| [HTML5](/slides/it/cpp/export-to-html5/) | Può riprodurre le animazioni supportate quando l'animazione delle forme è abilitata nelle opzioni di esportazione. Testa combinazioni personalizzate nel browser. |
| [Animated GIF](/slides/it/cpp/convert-powerpoint-to-animated-gif/) | Memorizza i fotogrammi renderizzati, non comportamenti modificabili o interazioni attivate da clic. Controlla il movimento effettivamente renderizzato. |
| [Video](/slides/it/cpp/convert-powerpoint-to-video/) | Renderizza i fotogrammi di animazione e li codifica come video. Il supporto è limitato alle [animazioni ed effetti supportati](/slides/it/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) del renderer; i comandi e gli eventi interattivi non diventano una timeline modificabile. |

## **FAQ**

**Perché il mio effetto contiene comportamenti prima che ne aggiunga qualcuno?**  
La creazione di un effetto predefinito può generare le operazioni sottostanti. Ispezionale prima di decidere se estendere il preset o sostituirne i comportamenti.

**Spostare un comportamento all'inizio lo fa riprodurre per primo?**  
Non necessariamente. L'ordine della collezione non sostituisce la temporizzazione. Controlla ritardi, durate e interazioni tra operazioni sulla stessa proprietà.

**Perché un comando end non ha punti?**  
Indica la fine del percorso e non richiede coordinate. Quando ispezioni un percorso da file, verifica la presenza di un array di punti nullo.

**Un round‑trip riuscito è sufficiente per confermare la riproduzione?**  
No. Riaprire conferma la conservazione delle proprietà verificate. Testa separatamente il lettore di presentazioni o l'esportazione animata per confermarne il comportamento visivo.