---
title: Gestire le transizioni delle diapositive nelle presentazioni usando C++
linktitle: Transizione diapositiva
type: docs
weight: 80
url: /it/cpp/slide-transition/
keywords:
- transizione diapositiva
- aggiungere transizione diapositiva
- applicare transizione diapositiva
- transizione diapositiva avanzata
- transizione morph
- tipo di transizione
- effetto di transizione
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Applica transizioni alle diapositive, configura l’avanzamento automatico delle diapositive e personalizza Morph e altri effetti di transizione con Aspose.Slides per C++."
---
## **Panoramica**

Le transizioni delle diapositive controllano come le diapositive appaiono durante una presentazione. Con Aspose.Slides per C++, è possibile scegliere un effetto di transizione per ogni diapositiva, configurare l’avanzamento tramite clic del mouse o timer e regolare le opzioni specifiche per un effetto. Questo articolo utilizza esempi C++ per applicare transizioni, impostare durate esatte delle transizioni, gestire il timing delle diapositive e creare una transizione Morph tra due diapositive. Gli esempi mostrano anche come salvare le impostazioni in un file PPTX.

## **Aggiungere una transizione alla diapositiva**

Per applicare una transizione, carica una presentazione con la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e accedi alle impostazioni di transizione di una diapositiva tramite [get_SlideShowTransition](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Chiama [set_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_type/) con un valore dell’enumerazione [TransitionType](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/transitiontype/), quindi salva la presentazione.

L’esempio seguente applica una transizione **Circle** alla prima diapositiva e una transizione **Comb** alla seconda. Usa un file `input.pptx` con almeno due diapositive.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Aggiungere una transizione avanzata alla diapositiva**

Puoi configurare per quanto tempo una diapositiva rimane sullo schermo e se un clic del mouse avanza la presentazione. I seguenti metodi controllano questo comportamento:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) consente allo spettatore di avanzare facendo clic con il mouse.
- [set_AdvanceAfter](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_advanceafter/) abilita l’avanzamento automatico.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) specifica il ritardo prima dell’avanzamento automatico, in millisecondi.

Abilita sia il clic che l’avanzamento temporizzato per consentire allo spettatore di proseguire con un clic o attendere il timer. Per usare solo il timer, chiama [set_AdvanceOnClick](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) con `false`. Il ritardo controlla quando la presentazione avanza; non imposta la durata dell’effetto di transizione visivo.

Questo esempio assegna effetti diversi alle prime tre diapositive e abilita l’avanzamento automatico dopo 3, 5 e 7 secondi, rispettivamente. I clic del mouse possono anche avanzare queste diapositive. Usa un file `input.pptx` con almeno tre diapositive.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

Per verificare se l’avanzamento temporizzato è abilitato, chiama [get_AdvanceAfter](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/get_advanceafter/). Un ritardo memorizzato da solo non indica che il timer sia attivo.

L’esempio successivo apre il file salvato sopra, segnala ogni timer abilitato e disabilita l’avanzamento automatico per le diapositive con un ritardo superiore a due secondi. Attiva i clic del mouse per quelle diapositive e salva le impostazioni aggiornate.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Controllare con precisione il timing della transizione**

Usa [set_Duration](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_duration/) per specificare la lunghezza esatta di un effetto di transizione in millisecondi. Il metodo [get_SlideShowTransition](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) della diapositiva espone queste impostazioni tramite [ISlideShowTransition](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/):

| Metodo | Scopo |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_duration/) | Imposta la durata dell’effetto di transizione, in millisecondi. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Imposta il ritardo prima che la diapositiva avanzi automaticamente, in millisecondi. Chiama [set_AdvanceAfter](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_advanceafter/) con `true` per attivare questo timer. |
| [set_Speed](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_speed/) | Seleziona una categoria di velocità predefinita dall’enumerazione [TransitionSpeed](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium o Fast. Viene usata quando non è specificata una durata esatta. |

[set_Duration] controlla solo l’effetto di transizione; non determina per quanto tempo la diapositiva rimane visibile. Configura separatamente il ritardo dell’avanzamento automatico. Quando non è impostata una durata esplicita, Aspose.Slides determina la durata dell’effetto dal tipo di transizione e dal valore restituito da [get_Speed](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/get_speed/).

### **Applicare la stessa durata a ogni diapositiva**

Per una cadenza costante, applica lo stesso effetto e la stessa durata a ogni diapositiva. Questo esempio carica `input.pptx`, seleziona **Fade** dal [TransitionType](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/transitiontype/), e assegna a ogni transizione una durata di 750 millisecondi. Abilita separatamente l’avanzamento automatico dopo 5 000 millisecondi e disabilita l’avanzamento con clic del mouse, quindi salva il risultato come PPTX.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // Configura l'avanzamento automatico in modo indipendente dalla durata dell'effetto.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Impostare durate diverse per diapositive individuali**

Diapositive diverse possono usare durate di effetto differenti. Per esempio, usa una transizione breve per una diapositiva titolo e una più lunga per l’introduzione di una sezione. Questo esempio imposta 500 millisecondi per la prima diapositiva e 1 200 millisecondi per la seconda. Usa un file `input.pptx` con almeno due diapositive.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **Coordinare le transizioni con l’output animato**

Quando prepari una [animated GIF](/slides/it/cpp/convert-powerpoint-to-animated-gif/), una [HTML5 presentation](/slides/it/cpp/export-to-html5/), o un [video](/slides/it/cpp/convert-powerpoint-to-video/), imposta le durate esatte delle transizioni prima dell’esportazione per corrispondere al ritmo desiderato. Per esempio, usa una dissolvenza di 600 millisecondi tra le scene e regola separatamente il ritardo di avanzamento di ciascuna diapositiva per consentire il tempo per la narrazione o il contenuto.

Per GIF e video, coordina la frequenza dei fotogrammi dell’output con la durata dell’effetto: 600 millisecondi corrispondono a 18 fotogrammi a 30 fotogrammi al secondo. In HTML5, abilita le transizioni animate nelle impostazioni di esportazione. Controlla gli effetti e le opzioni di timing supportati dal formato di esportazione scelto e visualizza in anteprima l’output per confermare la sincronizzazione.

### **Leggere la durata di una transizione esistente**

Chiama [get_Duration](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/get_duration/) prima di modificare la transizione per determinare se è memorizzato un valore esplicito. Un valore di `-1` indica che non è impostata alcuna durata esplicita; un valore non negativo specifica la durata memorizzata in millisecondi. Il valore non impostato non è la durata di riproduzione calcolata: Aspose.Slides utilizza il tipo di transizione e il valore restituito da [get_Speed](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/get_speed/) per determinare quella durata. Impostare un tipo di transizione può inizializzare una durata, quindi ispeziona prima le impostazioni originali.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Transizione Morph**

La transizione Morph anima le modifiche tra oggetti su diapositive consecutive. Per creare un semplice effetto Morph, clona una diapositiva, sposta o ridimensiona un oggetto nella copia e applica la transizione Morph alla seconda diapositiva. Questo fornisce alla transizione gli oggetti corrispondenti da animare tra lo stato originale e quello modificato.

L’esempio seguente crea una diapositiva con un rettangolo di testo, clona la diapositiva e modifica la posizione e le dimensioni del rettangolo nella copia. Quindi seleziona **Morph** dall’enumerazione [TransitionType](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/transitiontype/) per la seconda diapositiva. Apri il file salvato in un visualizzatore di presentazioni che supporta Morph per vedere l’effetto durante una presentazione.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Tipi di transizione Morph**

L’enumerazione [TransitionMorphType](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/transitionmorphtype/) controlla come Morph associa e anima i contenuti:

- [ByObject] tratta ogni forma come un intero oggetto.
- [ByWord] anima il testo associando le parole, quando possibile.
- [ByChar] anima il testo associando i caratteri, quando possibile.

Chiama [set_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_type/) con **Morph** prima di accedere a [get_Value](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/get_value/). Il valore fornisce quindi l’interfaccia [IMorphTransition](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/imorphtransition/), il cui metodo [set_MorphType](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) seleziona la modalità di corrispondenza.

Questo esempio apre la presentazione creata nella sezione precedente e configura la seconda diapositiva per usare l’animazione Morph basata su parole.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Impostare gli effetti di transizione**

Alcune transizioni espongono opzioni aggiuntive, come la direzione o se l’effetto inizia da una schermata nera. Le opzioni disponibili dipendono dal tipo di transizione selezionato. Imposta prima il tipo, poi usa l’interfaccia appropriata restituita da [get_Value](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/get_value/).

L’esempio seguente applica una transizione **Cut** alla prima diapositiva di `input.pptx`. Chiama [set_FromBlack](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) con `true` tramite [IOptionalBlackTransition](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/ioptionalblacktransition/) in modo che la transizione inizi da una schermata nera.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **FAQ**

**Posso controllare la velocità di riproduzione di una transizione della diapositiva?**

Sì. Preferisci [set_Duration](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_duration/) quando hai bisogno di una durata esatta dell’effetto in millisecondi. Usa [set_Speed](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_speed/) quando è sufficiente una categoria predefinita di [TransitionSpeed](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/transitionspeed/) — Slow, Medium o Fast — e non è impostata una durata esplicita. queste impostazioni controllano l’effetto di transizione indipendentemente dal ritardo di avanzamento automatico.

**Posso associare audio a una transizione e farlo ripetere in loop?**

Sì. Assegna audio incorporato con [set_Sound](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_sound/), chiama [set_SoundMode](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_soundmode/) con **StartSound** dall’enumerazione [TransitionSoundMode](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/transitionsoundmode/), e abilita il looping con [set_SoundLoop](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_soundloop/). L’audio si ripete finché non si verifica il prossimo evento sonoro nella presentazione.

**Qual è il modo più rapido per applicare la stessa transizione a ogni diapositiva?**

Itera attraverso la collezione restituita dal metodo [get_Slides](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_slides/) della presentazione e chiama [set_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/set_type/) con lo stesso valore per la transizione di ciascuna diapositiva. Imposta eventuali opzioni di timing ed effetto nello stesso ciclo per mantenere il comportamento coerente su tutte le diapositive.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Chiama [get_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/islideshowtransition/get_type/) sulla transizione restituita dal metodo [get_SlideShowTransition](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) della diapositiva. Restituisce un valore dell’enumerazione [TransitionType](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/transitiontype/); **None** significa che non è stato applicato alcun effetto di transizione.