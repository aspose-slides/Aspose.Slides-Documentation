---
title: Gestire le transizioni delle diapositive nelle presentazioni usando Python
linktitle: Transizione diapositiva
type: docs
weight: 90
url: /it/python-net/slide-transition/
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
- Aspose.Slides
description: "Applica le transizioni delle diapositive, configura l’avanzamento automatico delle diapositive e personalizza Morph e altri effetti di transizione con Aspose.Slides per Python via .NET."
---
## **Panoramica**

Le transizioni delle diapositive controllano come appaiono le diapositive durante una presentazione. Con Aspose.Slides per Python via .NET, è possibile scegliere un effetto di transizione per ogni diapositiva, configurare l’avanzamento tramite clic del mouse o timer e regolare le opzioni specifiche di un effetto. Questo articolo utilizza esempi Python per applicare transizioni, impostare durate di transizione precise, gestire il timing delle diapositive e creare una transizione Morph tra due diapositive. Gli esempi mostrano inoltre come salvare le impostazioni in un file PPTX.

## **Aggiungere una transizione alla diapositiva**

Per applicare una transizione, caricare una presentazione con la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e accedere alla proprietà [slide_show_transition](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/slide_show_transition/) della diapositiva. Impostare il suo [type](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/type/) su un valore dell’enumerazione [TransitionType](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/transitiontype/), quindi salvare la presentazione.

L’esempio seguente applica una transizione Circle alla prima diapositiva e una transizione Comb alla seconda. Utilizzare un file `input.pptx` con almeno due diapositive.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **Aggiungere una transizione avanzata alla diapositiva**

È possibile configurare per quanto tempo una diapositiva rimane sullo schermo e se un clic del mouse fa avanzare la presentazione. Le seguenti proprietà controllano questo comportamento:

- [advance_on_click](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) consente allo spettatore di avanzare facendo clic con il mouse.
- [advance_after](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) abilita l’avanzamento automatico.
- [advance_after_time](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) specifica il ritardo prima dell’avanzamento automatico, in millisecondi.

Abilitare sia l’avanzamento con clic sia quello a tempo per consentire allo spettatore di procedere con un clic o di attendere il timer. Per utilizzare solo il timer, impostare [advance_on_click](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) su `False`. Il ritardo controlla quando la presentazione avanza; non imposta la durata dell’effetto di transizione visiva.

Questo esempio assegna effetti diversi alle prime tre diapositive e abilita l’avanzamento automatico dopo 3, 5 e 7 secondi, rispettivamente. Anche i clic del mouse possono far avanzare queste diapositive. Utilizzare un file `input.pptx` con almeno tre diapositive.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

Per verificare se l’avanzamento a tempo è abilitato, leggere [advance_after](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Un ritardo memorizzato da solo non indica che il timer sia attivo.

L’esempio successivo apre il file salvato sopra, segnala ogni timer abilitato e disabilita l’avanzamento automatico per le diapositive con un ritardo superiore a due secondi. Abilita i clic del mouse per tali diapositive e salva le impostazioni aggiornate.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **Controllare il timing della transizione con precisione**

Utilizzare [duration](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/duration/) per specificare la durata esatta di un effetto di transizione in millisecondi. La proprietà [slide_show_transition](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/slide_show_transition/) della diapositiva espone queste impostazioni tramite [SlideShowTransition](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/):

| Proprietà | Scopo |
| --- | --- |
| [duration](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Imposta la durata dell’effetto di transizione stesso, in millisecondi. |
| [advance_after_time](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Imposta il ritardo prima che la diapositiva avanzi automaticamente, in millisecondi. Abilitare [advance_after](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) per attivare questo timer. |
| [speed](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Seleziona una categoria di velocità predefinita da [TransitionSpeed](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM o FAST. Viene usata quando non è specificata una durata esatta. |

[duration](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/duration/) controlla solo l’effetto di transizione; non determina per quanto tempo la diapositiva rimane visibile. Configurare separatamente il ritardo di avanzamento automatico. Quando non è impostata una durata esplicita, Aspose.Slides determina la durata dell’effetto dal tipo di transizione e dal valore di [speed](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Applicare la stessa durata a ogni diapositiva**

Per mantenere un ritmo costante, applicare lo stesso effetto e la stessa durata esatta a tutte le diapositive. Questo esempio carica `input.pptx`, seleziona Fade da [TransitionType](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/transitiontype/) e assegna a ogni transizione una durata di 750 millisecondi. Abilita separatamente l’avanzamento automatico dopo 5 000 millisecondi e disabilita l’avanzamento con clic del mouse, quindi salva il risultato come PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Configura l'avanzamento automatico indipendentemente dalla durata dell'effetto.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Impostare durate diverse per singole diapositive**

Diapositive diverse possono utilizzare durate di effetto diverse. Ad esempio, usare una transizione breve per una diapositiva titolo e una più lunga per l’introduzione di una sezione. Questo esempio imposta 500 millisecondi per la prima diapositiva e 1 200 millisecondi per la seconda. Utilizzare un file `input.pptx` con almeno due diapositive.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **Coordinare le transizioni con l’output animato**

Quando si prepara un [animated GIF](/slides/it/python-net/convert-powerpoint-to-animated-gif/), una [HTML5 presentation](/slides/it/python-net/export-to-html5/) o un [video](/slides/it/python-net/convert-powerpoint-to-video/), impostare durate di transizione esatte prima dell’esportazione per corrispondere al ritmo desiderato. Ad esempio, usare una dissolvenza di 600 millisecondi tra le scene e regolare separatamente il ritardo di avanzamento di ogni diapositiva per consentire il tempo necessario alla narrazione o al contenuto.

Per GIF e video, coordinare il frame rate dell’output con la durata dell’effetto: 600 millisecondi corrispondono a 18 fotogrammi a 30 fps. In HTML5, abilitare le transizioni animate nelle impostazioni di esportazione. Verificare gli effetti e le opzioni di timing supportati dal formato di esportazione scelto e visualizzare in anteprima l’output per confermare la sincronizzazione.

### **Leggere la durata di una transizione esistente**

Leggere [duration](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/duration/) prima di modificare la transizione per determinare se è memorizzata una durata esplicita. Un valore di `-1` indica che non è impostata alcuna durata esplicita; un valore non negativo specifica la durata memorizzata in millisecondi. Il valore non impostato non è la durata di riproduzione calcolata: Aspose.Slides usa il tipo di transizione e [speed](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/speed/) per determinarla. Impostare un tipo di transizione può inizializzare una durata, quindi ispezionare prima le impostazioni originali.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Transizione Morph**

La transizione Morph anima le modifiche tra oggetti su diapositive consecutive. Per creare un semplice effetto Morph, clonare una diapositiva, spostare o ridimensionare un oggetto sulla copia e applicare la transizione Morph alla seconda diapositiva. Questo fornisce agli oggetti corrispondenti la possibilità di animarsi tra lo stato originale e quello modificato.

L’esempio seguente crea una diapositiva con un rettangolo di testo, ne clona la diapositiva e cambia la posizione e le dimensioni del rettangolo nella copia. Quindi seleziona Morph dall’enumerazione [TransitionType](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/transitiontype/) per la seconda diapositiva. Aprire il file salvato in un visualizzatore di presentazioni che supporta Morph per vedere l’effetto durante la presentazione.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Tipi di transizione Morph**

L’enumerazione [TransitionMorphType](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/transitionmorphtype/) controlla come Morph associa e anima il contenuto:

- [BY_OBJECT](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/transitionmorphtype/) tratta ogni forma come un unico oggetto.
- [BY_WORD](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/transitionmorphtype/) anima il testo associando le parole dove possibile.
- [BY_CHAR](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/transitionmorphtype/) anima il testo associando i caratteri dove possibile.

Impostare il [type](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/type/) della transizione su Morph prima di accedere al suo [value](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/value/). Il valore fornisce quindi l’oggetto [MorphTransition](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/morphtransition/), la cui proprietà [morph_type](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/morphtransition/morph_type/) seleziona la modalità di corrispondenza.

Questo esempio apre la presentazione creata nella sezione precedente e configura la seconda diapositiva per utilizzare l’animazione Morph basata sulle parole.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **Impostare gli effetti di transizione**

Alcune transizioni espongono opzioni aggiuntive, come la direzione o se l’effetto inizia da uno schermo nero. Le opzioni disponibili dipendono dal [type](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/type/) di transizione selezionato: impostare prima il tipo, quindi utilizzare l’oggetto di transizione appropriato dal suo [value](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/value/).

L’esempio seguente applica una transizione Cut alla prima diapositiva di `input.pptx`. Imposta [from_black](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) tramite [OptionalBlackTransition](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/optionalblacktransition/) in modo che la transizione inizi da uno schermo nero.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **FAQ**

**Posso controllare la velocità di riproduzione di una transizione della diapositiva?**

Sì. Preferire [duration](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/duration/) quando è necessaria una durata esatta dell’effetto in millisecondi. Usare [speed](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/speed/) quando è sufficiente una categoria predefinita di [TransitionSpeed](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM o FAST, e non è impostata una durata esplicita. Queste impostazioni controllano l’effetto di transizione indipendentemente dal ritardo di avanzamento automatico.

**Posso allegare audio a una transizione e farlo ripetere in loop?**

Sì. Assegnare audio incorporato a [sound](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/sound/), impostare [sound_mode](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) su START_SOUND dell’enumerazione [TransitionSoundMode](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/transitionsoundmode/), e abilitare [sound_loop](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). L’audio si ripete fino al prossimo evento sonoro nella presentazione.

**Qual è il modo più veloce per applicare la stessa transizione a tutte le diapositive?**

Iterare la collezione [slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/slides/it/) della presentazione e impostare per ogni diapositiva il [type](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/type/) della transizione allo stesso valore. Impostare eventuali opzioni di timing ed effetto nello stesso ciclo per mantenere il comportamento coerente tra le diapositive.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Leggere la proprietà [type](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/slideshowtransition/type/) dalla [slide_show_transition](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/slide_show_transition/) della diapositiva. Restituisce un valore dell’enumerazione [TransitionType](https://reference.aspose.com/slides/it/python-net/aspose.slides.slideshow/transitiontype/); NONE indica che non è stato applicato alcun effetto di transizione.