---
title: Gestire le transizioni delle diapositive nelle presentazioni usando Python via Java
linktitle: Transizione diapositiva
type: docs
weight: 80
url: /it/python-java/slide-transition/
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
- Python
- Java
- Aspose.Slides
description: "Applica transizioni alle diapositive, configura l'avanzamento automatico delle diapositive e personalizza Morph e altri effetti di transizione con Aspose.Slides per Python via Java."
---
## **Panoramica**

Le transizioni delle diapositive controllano come le diapositive appaiono durante una presentazione. Con Aspose.Slides per Python via Java, è possibile scegliere un effetto di transizione per ogni diapositiva, configurare l'avanzamento tramite clic del mouse o timer e regolare le opzioni specifiche di un effetto. Questo articolo utilizza esempi in Python per applicare le transizioni, impostare durate di transizione esatte, gestire la temporizzazione delle diapositive e creare una transizione Morph tra due diapositive. Gli esempi mostrano anche come salvare le impostazioni in un file PPTX.

## **Aggiungi transizione alla diapositiva**

Per applicare una transizione, carica una presentazione con la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) e accedi alle impostazioni di transizione della diapositiva tramite [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). Usa [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) con un valore dell'enumerazione [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), quindi salva la presentazione.

Il seguente esempio applica una transizione Circle alla prima diapositiva e una transizione Comb alla seconda. Usa un file `input.pptx` con almeno due diapositive.

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

## **Transizione a ruota**

Usa [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) per selezionare Wheel da [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Quindi chiama [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) per accedere alle impostazioni di [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/). Il suo metodo [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) controlla quante settori radiali rivelano la diapositiva di destinazione.

L'esempio crea due coppie identiche di diapositive. Ogni coppia inizia con una diapositiva nera e termina con un rettangolo dorato a tutta larghezza. Entrambe le diapositive di destinazione usano la stessa velocità lenta impostata con [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) e la stessa durata esplicita di 8.000 millisecondi impostata con [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). Solo il conteggio dei raggi cambia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Apri `wheel-transitions.pptx` in PowerPoint e avvia la presentazione. Avanza dalla diapositiva 1 alla diapositiva 2 per vedere una sweep oraria rivelare il rettangolo dorato. Poi avanza dalla diapositiva 3 alla diapositiva 4 per vedere otto settori radiali rivelare contemporaneamente lo stesso rettangolo.

## **Dissolvenza attraverso il nero con la transizione Reveal**

Imposta il tipo di transizione della diapositiva di destinazione su Reveal, quindi chiama [setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack) sulle impostazioni di [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/). L'esempio crea una diapositiva sorgente turchese e una diapositiva di destinazione corallo, poi clona entrambe. Ogni coppia usa la stessa transizione Reveal di due secondi. Solo la seconda coppia sfuma attraverso il nero.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, PresetColor, Presentation, SaveFormat, ShapeType
from asposeslides.api import TransitionLeftRightDirectionType, TransitionSpeed, TransitionType


def style_slide(slide, background_color, label):
    slide.getBackground().setType(BackgroundType.OwnBackground)
    fill = slide.getBackground().getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setPresetColor(background_color)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130)
    shape.getTextFrame().setText(label)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setFontHeight(44)


presentation = Presentation()
try:
    source = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addClone(source)
    style_slide(source, PresetColor.Teal, "Source")
    style_slide(destination, PresetColor.Coral, "Destination")

    presentation.getSlides().addClone(source)
    cloned_destination = presentation.getSlides().addClone(destination)
    for slide in (destination, cloned_destination):
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Reveal)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(2000)

        reveal = transition.getValue()
        reveal.setDirection(TransitionLeftRightDirectionType.Left)
        reveal.setThroughBlack(slide is cloned_destination)

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Apri `reveal-transitions.pptx` in PowerPoint e avvia la presentazione. Avanza dalla diapositiva 1 alla diapositiva 2 per vedere il turchese sfumare direttamente nel corallo. Poi avanza dalla diapositiva 3 alla diapositiva 4. Lo schermo si scurisce brevemente quasi fino al nero prima che appaia la diapositiva corallo. Entrambe le diapositive mantengono i loro colori di sfondo originali.

Le righe sottostanti mostrano fotogrammi di PowerPoint a intervalli di mezzo secondo. Confronta il fotogramma centrale in ogni riga per vedere l'effetto.

![Riproduzione PowerPoint con dissolvenza tramite nero disattivata (in alto) e abilitata (in basso). Solo la riga inferiore passa attraverso quasi il nero.](reveal-through-black.png)

## **Aggiungi transizione avanzata alla diapositiva**

Puoi configurare quanto tempo una diapositiva rimane sullo schermo e se un clic del mouse avanza la presentazione. I seguenti metodi controllano questo comportamento:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) consente allo spettatore di avanzare facendo clic del mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) abilita l'avanzamento automatico.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) specifica il ritardo prima dell'avanzamento automatico, in millisecondi.

Abilita sia il clic che l'avanzamento temporizzato per permettere allo spettatore di procedere con un clic o di attendere il timer. Per usare solo il timer, passa `False` a [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Il ritardo controlla quando la presentazione avanza; non imposta la durata dell'effetto di transizione visivo.

Questo esempio assegna effetti diversi alle prime tre diapositive e abilita l'avanzamento automatico dopo 3, 5 e 7 secondi, rispettivamente. Anche i clic del mouse possono avanzare queste diapositive. Usa un file `input.pptx` con almeno tre diapositive.

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

Per verificare se l'avanzamento temporizzato è abilitato, chiama [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Un ritardo memorizzato da solo non indica che il timer sia attivo.

L'esempio successivo apre il file salvato sopra, segnala ogni timer abilitato e disabilita l'avanzamento automatico per le diapositive con un ritardo superiore a due secondi. Abilita i clic del mouse per quelle diapositive e salva le impostazioni aggiornate.

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

## **Controlla con precisione il tempo della transizione**

Usa [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) per specificare la lunghezza esatta di un effetto di transizione in millisecondi. Il metodo [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) della diapositiva espone queste impostazioni tramite [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/):

| Metodo | Scopo |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Imposta la durata dell'effetto di transizione, in millisecondi. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Imposta il ritardo prima che la diapositiva avanzi automaticamente, in millisecondi. Passa `True` a [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) per attivare questo timer. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Seleziona una categoria di velocità predefinita da [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium o Fast. Viene utilizzata quando non è specificata una durata esatta. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) controlla solo l'effetto di transizione; non determina quanto tempo la diapositiva rimane visibile. Configura separatamente il ritardo di avanzamento automatico. Quando non è impostata una durata esplicita, Aspose.Slides determina la durata dell'effetto dal tipo di transizione e dal valore di [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Barre separate identificano la durata della transizione di 750 ms e l'impostazione di avanzamento automatico di 5.000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*L'esempio condiviso assegna a ogni diapositiva una transizione Dissolvenza di 750 ms e abilita separatamente l'avanzamento automatico a 5.000 ms. La durata della transizione controlla l'effetto; l'avanzamento controlla quando lasciare la diapositiva. Queste barre sono impostazioni schematiche, non una timeline combinata misurata.* 
<!-- visual-explanation:slide-transition:end -->

### **Applica la stessa durata a ogni diapositiva**

Per una cadenza costante, applica lo stesso effetto e la stessa durata esatta a tutte le diapositive. Questo esempio carica `input.pptx`, seleziona Fade da [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) e assegna a ogni transizione una durata di 750 millisecondi. Attiva separatamente l'avanzamento automatico dopo 5.000 millisecondi e disabilita l'avanzamento tramite clic del mouse, quindi salva il risultato come PPTX.

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

### **Imposta durate diverse per diapositive individuali**

Diapositive diverse possono usare durate di effetto diverse. Ad esempio, usa una transizione breve per una diapositiva titolo e una più lunga per l'introduzione di una sezione. Questo esempio imposta 500 millisecondi per la prima diapositiva e 1.200 millisecondi per la seconda. Usa un file `input.pptx` con almeno due diapositive.

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

### **Coordina le transizioni con l'output animato**

Quando si prepara un [animated GIF](/slides/it/python-java/convert-powerpoint-to-animated-gif/), una [HTML5 presentation](/slides/it/python-java/export-to-html5/) o un [video](/slides/it/python-java/convert-powerpoint-to-video/), imposta durate di transizione esatte prima dell'esportazione per corrispondere alla cadenza desiderata. Per esempio, usa una dissolvenza di 600 millisecondi tra le scene e regola separatamente il ritardo di avanzamento di ciascuna diapositiva per consentire il tempo alla narrazione o al contenuto.

Per GIF e video, coordina il frame rate di output con la durata dell'effetto: 600 millisecondi corrispondono a 18 fotogrammi a 30 fps. In HTML5, abilita le transizioni animate nelle impostazioni di esportazione. Verifica gli effetti e le opzioni di temporizzazione supportati dal formato di esportazione scelto e visualizza un'anteprima dell'output per confermare la sincronizzazione.

### **Leggi la durata di una transizione esistente**

Chiama [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) prima di modificare la transizione per determinare se è memorizzata una durata esplicita. Un valore di `-1` significa che nessuna durata esplicita è impostata; un valore non negativo specifica la durata memorizzata in millisecondi. Il valore non impostato non è la durata di riproduzione calcolata: Aspose.Slides utilizza il tipo di transizione e il valore di [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) per determinare quella durata. Impostare un tipo di transizione può inizializzare una durata, quindi ispeziona prima le impostazioni originali.

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

La transizione Morph anima le modifiche tra oggetti su diapositive consecutive. Per creare un semplice effetto Morph, clona una diapositiva, sposta o ridimensiona un oggetto nella copia e applica la transizione Morph alla seconda diapositiva. Questo fornisce agli oggetti corrispondenti la possibilità di animare dallo stato originale a quello modificato.

L'esempio seguente crea una diapositiva con un rettangolo di testo, clona la diapositiva e cambia posizione e dimensione del rettangolo nella copia. Poi seleziona Morph dall'enumerazione [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) per la seconda diapositiva. Apri il file salvato in un visualizzatore di presentazioni che supporta Morph per vedere l'effetto durante la presentazione.

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

L'enumerazione [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) controlla come Morph abbina e anima il contenuto:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) tratta ogni forma come un unico oggetto.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) anima il testo abbinando le parole quando possibile.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) anima il testo abbinando i caratteri quando possibile.

Usa [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) per selezionare Morph prima di accedere a [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue). Il valore è quindi un'istanza della classe [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/), il cui metodo [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) seleziona la modalità di corrispondenza.

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

## **Imposta gli effetti di transizione**

Alcune transizioni espongono opzioni aggiuntive, come la direzione o se l'effetto inizia da una schermata nera. Le opzioni disponibili dipendono dalla transizione selezionata con [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType). Imposta prima il tipo, poi usa la classe appropriata da [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

L'esempio seguente applica una transizione Cut alla prima diapositiva di `input.pptx`. Chiama [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) tramite [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) in modo che la transizione inizi da una schermata nera.

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

Sì. Preferisci [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) quando hai bisogno di una durata esatta dell'effetto in millisecondi. Usa [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) quando una categoria predefinita di [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) — Slow, Medium o Fast — è sufficiente e non è impostata una durata esplicita. Queste impostazioni controllano l'effetto di transizione in modo indipendente dal ritardo di avanzamento automatico.

**Posso allegare un audio a una transizione e farlo ripetere in loop?**

Sì. Assegna audio incorporato con [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound), passa StartSound dall'enumerazione [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) a [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) e abilita [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) con `True`. L'audio si ripete in loop fino al prossimo evento sonoro nella presentazione.

**Qual è il modo più rapido per applicare la stessa transizione a ogni diapositiva?**

Itera la collezione [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) della presentazione e chiama [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) con lo stesso valore per la transizione di ciascuna diapositiva. Imposta eventuali opzioni di temporizzazione e di effetto nello stesso ciclo per mantenere il comportamento coerente tra le diapositive.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Chiama [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) sul risultato di [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) della diapositiva. Restituisce un valore dell'enumerazione [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/); None_ indica che nessun effetto di transizione è applicato.