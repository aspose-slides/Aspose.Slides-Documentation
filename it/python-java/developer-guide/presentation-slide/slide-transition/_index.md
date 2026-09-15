---
title: Gestisci le transizioni delle diapositive nelle presentazioni usando Python via Java
linktitle: Transizione diapositiva
type: docs
weight: 80
url: /it/python-java/slide-transition/
keywords:
- transizione diapositiva
- aggiungi transizione diapositiva
- applica transizione diapositiva
- transizione diapositiva avanzata
- transizione morph
- tipo di transizione
- effetto di transizione
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Applica le transizioni delle diapositive, configura l’avanzamento automatico delle diapositive e personalizza Morph e altri effetti di transizione con Aspose.Slides per Python via Java."
---
## **Panoramica**

Le transizioni delle diapositive controllano il modo in cui le diapositive appaiono durante una presentazione. Con Aspose.Slides per Python via Java, è possibile scegliere un effetto di transizione per ciascuna diapositiva, configurare l'avanzamento tramite clic del mouse o timer e regolare opzioni specifiche per un effetto. Questo articolo utilizza esempi Python per applicare transizioni, impostare durate di transizione precise, gestire il tempo delle diapositive e creare una transizione Morph tra due diapositive. Gli esempi mostrano anche come salvare le impostazioni in un file PPTX.

## **Aggiungere una transizione alla diapositiva**

Per applicare una transizione, carica una presentazione con la classe [Presentazione](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e accedi alle impostazioni di transizione della diapositiva tramite [getSlideShowTransition](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#getSlideShowTransition). Usa [setType](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setType) con un valore dell’enumerazione [TransitionType](https://reference.aspose.com/slides/it/python-java/aspose.slides/transitiontype/), quindi salva la presentazione.

L’esempio seguente applica una transizione Circle alla prima diapositiva e una transizione Comb alla seconda. Usa un file `input.pptx` con almeno due diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Aggiungere una transizione avanzata alla diapositiva**

Puoi configurare per quanto tempo una diapositiva rimane sullo schermo e se un clic del mouse avanza la presentazione. I seguenti metodi controllano questo comportamento:

- [setAdvanceOnClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) consente allo spettatore di avanzare facendo clic con il mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) abilita l’avanzamento automatico.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) specifica il ritardo prima dell’avanzamento automatico, in millisecondi.

Abilita sia l’avanzamento a clic sia quello temporizzato per consentire allo spettatore di proseguire con un clic o attendere il timer. Per utilizzare solo il timer, passa `False` a [setAdvanceOnClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Il ritardo controlla quando la presentazione avanza; non imposta la durata dell’effetto di transizione visivo.

Questo esempio assegna effetti diversi alle prime tre diapositive e abilita l’avanzamento automatico dopo 3, 5 e 7 secondi, rispettivamente. I clic del mouse possono anche avanzare queste diapositive. Usa un file `input.pptx` con almeno tre diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

Per verificare se l’avanzamento temporizzato è abilitato, chiama [getAdvanceAfter](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Un ritardo memorizzato da solo non indica che il timer sia attivo.

L’esempio successivo apre il file salvato sopra, segnala ogni timer abilitato e disabilita l’avanzamento automatico per le diapositive con un ritardo superiore a due secondi. Abilita i clic del mouse per quelle diapositive e salva le impostazioni aggiornate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controllare il tempo della transizione con precisione**

Usa [setDuration](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setDuration) per specificare la durata esatta di un effetto di transizione in millisecondi. Il metodo [getSlideShowTransition](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#getSlideShowTransition) della diapositiva espone queste impostazioni tramite [SlideShowTransition](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/):

| Metodo | Scopo |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setDuration) | Imposta la durata dell’effetto di transizione stesso, in millisecondi. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Imposta il ritardo prima dell’avanzamento automatico della diapositiva, in millisecondi. Passa `True` a [setAdvanceAfter](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) per attivare questo timer. |
| [setSpeed](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setSpeed) | Seleziona una categoria di velocità predefinita dall’enumerazione [TransitionSpeed](https://reference.aspose.com/slides/it/python-java/aspose.slides/transitionspeed/): Slow, Medium o Fast. Viene usata quando non è specificata una durata esatta. |

[setDuration](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setDuration) controlla solo l’effetto di transizione; non determina per quanto tempo la diapositiva rimane visibile. Configura separatamente il ritardo di avanzamento automatico. Quando non è impostata una durata esplicita, Aspose.Slides determina la durata dell’effetto dal tipo di transizione e dal valore di [getSpeed](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#getSpeed).

### **Applicare la stessa durata a tutte le diapositive**

Per mantenere un ritmo costante, applica lo stesso effetto e la stessa durata esatta a ogni diapositiva. Questo esempio carica `input.pptx`, seleziona Fade dall’enumerazione [TransitionType](https://reference.aspose.com/slides/it/python-java/aspose.slides/transitiontype/), e assegna a ogni transizione una durata di 750 millisecondi. Abilita separatamente l’avanzamento automatico dopo 5 000 millisecondi e disabilita l’avanzamento tramite clic del mouse, quindi salva il risultato come PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Configura l'avanzamento automatico indipendentemente dalla durata dell'effetto.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Impostare durate diverse per diapositive individuali**

Diapositive diverse possono utilizzare durate di effetto differenti. Ad esempio, usa una transizione breve per una diapositiva titolo e una più lunga per l’introduzione di una sezione. Questo esempio imposta 500 millisecondi per la prima diapositiva e 1 200 millisecondi per la seconda. Usa un file `input.pptx` con almeno due diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **Coordinare le transizioni con l’output animato**

Quando prepari un [GIF animato](/slides/it/python-java/convert-powerpoint-to-animated-gif/), una [presentazione HTML5](/slides/it/python-java/export-to-html5/) o un [video](/slides/it/python-java/convert-powerpoint-to-video/), imposta le durate di transizione esatte prima dell’esportazione per corrispondere al ritmo previsto. Per esempio, usa una dissolvenza di 600 millisecondi tra le scene e regola separatamente il ritardo di avanzamento di ciascuna diapositiva per consentire il tempo necessario alla narrazione o al contenuto.

Per GIF e video, coordina la frequenza dei fotogrammi dell’output con la durata dell’effetto: 600 millisecondi corrispondono a 18 fotogrammi a 30 fps. In HTML5, abilita le transizioni animate nelle impostazioni di esportazione. Verifica gli effetti e le opzioni di timing supportati dal formato di esportazione scelto e visualizza l’anteprima dell’output per confermare la sincronizzazione.

### **Leggere la durata di una transizione esistente**

Chiama [getDuration](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#getDuration) prima di modificare la transizione per determinare se è memorizzato un valore esplicito. Un valore di `-1` indica che non è stata impostata alcuna durata esplicita; un valore non negativo specifica la durata memorizzata in millisecondi. Il valore non impostato non è la durata di riproduzione calcolata: Aspose.Slides utilizza il tipo di transizione e il valore di [getSpeed](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#getSpeed) per determinare quella durata. L’impostazione di un tipo di transizione può inizializzare una durata, quindi ispeziona prima le impostazioni originali.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Transizione Morph**

La transizione Morph anima le modifiche tra oggetti su diapositive consecutive. Per creare un semplice effetto Morph, clona una diapositiva, sposta o ridimensiona un oggetto sulla copia e applica la transizione Morph alla seconda diapositiva. Questo fornisce agli oggetti corrispondenti la possibilità di animarsi tra lo stato originale e quello modificato.

L’esempio seguente crea una diapositiva con un rettangolo di testo, clona la diapositiva e modifica la posizione e le dimensioni del rettangolo sulla copia. Quindi seleziona Morph dall’enumerazione [TransitionType](https://reference.aspose.com/slides/it/python-java/aspose.slides/transitiontype/) per la seconda diapositiva. Apri il file salvato in un visualizzatore di presentazioni che supporta Morph per vedere l’effetto durante la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tipi di transizione Morph**

L’enumerazione [TransitionMorphType](https://reference.aspose.com/slides/it/python-java/aspose.slides/transitionmorphtype/) controlla come Morph associa e anima il contenuto:

- [ByObject](https://reference.aspose.com/slides/it/python-java/aspose.slides/transitionmorphtype/#ByObject) tratta ogni forma come un singolo oggetto.
- [ByWord](https://reference.aspose.com/slides/it/python-java/aspose.slides/transitionmorphtype/#ByWord) anima il testo abbinando le parole dove possibile.
- [ByChar](https://reference.aspose.com/slides/it/python-java/aspose.slides/transitionmorphtype/#ByChar) anima il testo abbinando i caratteri dove possibile.

Usa [setType](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setType) per selezionare Morph prima di accedere a [getValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#getValue). Il valore risultante è un’istanza della classe [MorphTransition](https://reference.aspose.com/slides/it/python-java/aspose.slides/morphtransition/), il cui metodo [setMorphType](https://reference.aspose.com/slides/it/python-java/aspose.slides/morphtransition/#setMorphType) seleziona la modalità di corrispondenza.

Questo esempio apre la presentazione creata nella sezione precedente e configura la seconda diapositiva per usare l’animazione Morph basata sulle parole.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Impostare gli effetti di transizione**

Alcune transizioni espongono opzioni aggiuntive, come la direzione o se l’effetto inizia da uno schermo nero. Le opzioni disponibili dipendono dalla transizione selezionata con [setType](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setType). Imposta prima il tipo, quindi usa la classe appropriata ottenuta da [getValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#getValue).

L’esempio seguente applica una transizione Cut alla prima diapositiva di `input.pptx`. Chiama [setFromBlack](https://reference.aspose.com/slides/it/python-java/aspose.slides/optionalblacktransition/#setFromBlack) tramite [OptionalBlackTransition](https://reference.aspose.com/slides/it/python-java/aspose.slides/optionalblacktransition/) in modo che la transizione inizi da uno schermo nero.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **FAQ**

**Posso controllare la velocità di riproduzione di una transizione della diapositiva?**

Sì. Preferisci [setDuration](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setDuration) quando hai bisogno di una durata dell’effetto esatta in millisecondi. Usa [setSpeed](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setSpeed) quando è sufficiente una categoria predefinita di [TransitionSpeed](https://reference.aspose.com/slides/it/python-java/aspose.slides/transitionspeed/): Slow, Medium o Fast, e non è impostata una durata esplicita. Queste impostazioni controllano l’effetto di transizione indipendentemente dal ritardo di avanzamento automatico.

**Posso allegare audio a una transizione e farlo ripetere in loop?**

Sì. Assegna l’audio incorporato con [setSound](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setSound), passa StartSound dall’enumerazione [TransitionSoundMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/transitionsoundmode/) a [setSoundMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setSoundMode) e abilita [setSoundLoop](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setSoundLoop) con `True`. L’audio si ripete fino al prossimo evento sonoro nella presentazione.

**Qual è il modo più veloce per applicare la stessa transizione a tutte le diapositive?**

Itera sulla collezione [getSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlides) della presentazione e chiama [setType](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#setType) con lo stesso valore per la transizione di ciascuna diapositiva. Imposta eventuali opzioni di timing e di effetto nello stesso ciclo per mantenere il comportamento coerente su tutte le diapositive.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Chiama [getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideshowtransition/#getType) sul risultato di [getSlideShowTransition](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#getSlideShowTransition) della diapositiva. Restituisce un valore dell’enumerazione [TransitionType](https://reference.aspose.com/slides/it/python-java/aspose.slides/transitiontype/); None_ indica che non è stato applicato alcun effetto di transizione.