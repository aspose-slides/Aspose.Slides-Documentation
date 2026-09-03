---
title: Gestisci le transizioni delle diapositive nelle presentazioni usando JavaScript
linktitle: Transizione diapositiva
type: docs
weight: 80
url: /it/nodejs-java/slide-transition/
keywords:
- transizione diapositiva
- aggiungi transizione diapositiva
- applica transizione diapositiva
- transizione diapositiva avanzata
- transizione Morph
- tipo di transizione
- effetto di transizione
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Applica le transizioni delle diapositive, configura l'avanzamento automatico delle diapositive e personalizza Morph e altri effetti di transizione con Aspose.Slides per Node.js tramite Java."
---
## **Panoramica**

Le transizioni delle diapositive controllano come le diapositive appaiono durante una presentazione. Con Aspose.Slides per Node.js tramite Java, è possibile scegliere un effetto di transizione per ogni diapositiva, configurare l'avanzamento mediante clic del mouse o timer e regolare le opzioni specifiche per un effetto. Questo articolo utilizza esempi JavaScript per applicare le transizioni, impostare durate di transizione precise, gestire il tempo delle diapositive e creare una transizione Morph tra due diapositive. Gli esempi mostrano anche come salvare le impostazioni in un file PPTX.

## **Aggiungi transizione diapositiva**

Per applicare una transizione, carica una presentazione con la classe [Presentazione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e accedi alle impostazioni di transizione della diapositiva tramite [getSlideShowTransition](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Usa [setType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setType) con un valore dell'enumerazione [TransitionType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/transitiontype/), quindi salva la presentazione.

L'esempio seguente applica una transizione Circle alla prima diapositiva e una transizione Comb alla seconda. Usa un file `input.pptx` contenente almeno due diapositive.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Aggiungi transizione diapositiva avanzata**

Puoi configurare per quanto tempo una diapositiva rimane sullo schermo e se un clic del mouse fa avanzare la presentazione. I seguenti metodi controllano questo comportamento:

- [setAdvanceOnClick](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) consente allo spettatore di avanzare facendo clic col mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) abilita l'avanzamento automatico.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) specifica il ritardo prima dell'avanzamento automatico, in millisecondi.

Abilita sia il clic che l'avanzamento temporizzato per consentire allo spettatore di proseguire con un clic o di attendere il timer. Per utilizzare solo il timer, passa `false` a [setAdvanceOnClick](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Il ritardo controlla quando la presentazione avanza; non imposta la durata dell'effetto visivo della transizione.

Questo esempio assegna effetti diversi alle prime tre diapositive e abilita l'avanzamento automatico dopo 3, 5 e 7 secondi, rispettivamente. I clic del mouse possono anche far avanzare queste diapositive. Usa un file `input.pptx` con almeno tre diapositive.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Per verificare se l'avanzamento temporizzato è abilitato, chiama [getAdvanceAfter](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Un ritardo memorizzato da solo non indica che il timer sia attivo.

L'esempio successivo apre il file salvato sopra, segnala ogni timer abilitato e disabilita l'avanzamento automatico per le diapositive con un ritardo superiore a due secondi. Abilita i clic del mouse per quelle diapositive e salva le impostazioni aggiornate.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlla con precisione la tempistica della transizione**

Usa [setDuration](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setDuration) per specificare la lunghezza esatta di un effetto di transizione in millisecondi. Il metodo [getSlideShowTransition](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) della diapositiva espone queste impostazioni tramite [SlideShowTransition](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/):

| Metodo | Scopo |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Imposta la durata dell'effetto di transizione stesso, in millisecondi. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Imposta il ritardo prima che la diapositiva avanzi automaticamente, in millisecondi. Passa `true` a [setAdvanceAfter](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) per attivare questo timer. |
| [setSpeed](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Seleziona una categoria di velocità predefinita dall'enumerazione [TransitionSpeed](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium o Fast. Viene usata quando non è specificata una durata esatta. |

[setDuration](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setDuration) controlla solo l'effetto di transizione; non determina per quanto tempo la diapositiva rimane visibile. Configura separatamente il ritardo di avanzamento automatico. Quando non è impostata alcuna durata esplicita, Aspose.Slides determina la durata dell'effetto dal tipo di transizione e dal valore di [getSpeed](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

### **Applica la stessa durata a tutte le diapositive**

Per una cadenza costante, applica lo stesso effetto e la stessa durata esatta a ogni diapositiva. Questo esempio carica `input.pptx`, seleziona Fade dall'enumerazione [TransitionType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/transitiontype/), e assegna a ciascuna transizione una durata di 750 millisecondi. Attiva separatamente l'avanzamento automatico dopo 5 000 millisecondi e disabilita l'avanzamento tramite clic del mouse, poi salva il risultato come PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Configura l'avanzamento automatico indipendentemente dalla durata dell'effetto.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Imposta durate diverse per singole diapositive**

Diapositive diverse possono usare durate di effetto differenti. Ad esempio, usa una transizione breve per una diapositiva titolo e una più lunga per l'introduzione di una sezione. Questo esempio imposta 500 millisecondi per la prima diapositiva e 1 200 millisecondi per la seconda. Usa un file `input.pptx` con almeno due diapositive.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Coordina le transizioni con l'output animato**

Quando prepari un [GIF animato](/slides/it/nodejs-java/convert-powerpoint-to-animated-gif/), una [presentazione HTML5](/slides/it/nodejs-java/export-to-html5/) o un [video](/slides/it/nodejs-java/convert-powerpoint-to-video/), imposta durate di transizione precise prima dell'esportazione per far corrispondere il ritmo desiderato. Ad esempio, usa una dissolvenza di 600 millisecondi tra le scene e regola separatamente il ritardo di avanzamento di ciascuna diapositiva per consentire il tempo della narrazione o del contenuto.

Per GIF e video, coordina il framerate dell'output con la durata dell'effetto: 600 millisecondi corrispondono a 18 fotogrammi a 30 fotogrammi al secondo. In HTML5, abilita le transizioni animate nelle impostazioni di esportazione. Controlla gli effetti e le opzioni di timing supportati dal formato di esportazione scelto e visualizza l'anteprima per confermare la sincronizzazione.

### **Leggi la durata di una transizione esistente**

Chiama [getDuration](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#getDuration) prima di modificare la transizione per determinare se è memorizzato un valore esplicito. Un valore di `-1` indica che non è impostata alcuna durata esplicita; un valore non negativo specifica la durata memorizzata in millisecondi. Il valore non impostato non è la durata di riproduzione calcolata: Aspose.Slides utilizza il tipo di transizione e il valore di [getSpeed](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) per determinare tale durata. Impostare un tipo di transizione può inizializzare una durata, quindi ispeziona prima le impostazioni originali.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Transizione Morph**

La transizione Morph anima le modifiche tra oggetti su diapositive consecutive. Per creare un semplice effetto Morph, clona una diapositiva, sposta o ridimensiona un oggetto nella copia e applica la transizione Morph alla seconda diapositiva. Questo fornisce agli oggetti corrispondenti la possibilità di animarsi tra lo stato originale e quello modificato.

L'esempio seguente crea una diapositiva con un rettangolo di testo, clona la diapositiva e modifica la posizione e le dimensioni del rettangolo nella copia. Quindi seleziona Morph dall'enumerazione [TransitionType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/transitiontype/) per la seconda diapositiva. Apri il file salvato in un visualizzatore di presentazioni che supporta Morph per vedere l'effetto durante la presentazione.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tipi di transizione Morph**

L'enumerazione [TransitionMorphType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/transitionmorphtype/) controlla come Morph corrisponde e anima il contenuto:

- [ByObject](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) tratta ogni forma come un singolo oggetto.
- [ByWord](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) anima il testo abbinando le parole quando possibile.
- [ByChar](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) anima il testo abbinando i caratteri quando possibile.

Usa [setType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setType) per selezionare Morph prima di accedere a [getValue](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#getValue). Il valore fornisce poi un oggetto [MorphTransition](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/morphtransition/), il cui metodo [setMorphType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/morphtransition/#setMorphType) seleziona la modalità di corrispondenza.

Questo esempio apre la presentazione creata nella sezione precedente e configura la seconda diapositiva per utilizzare l'animazione Morph basata sulle parole.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Imposta effetti di transizione**

Alcune transizioni espongono opzioni aggiuntive, come la direzione o se l'effetto inizia da uno schermo nero. Le opzioni disponibili dipendono dalla transizione selezionata con [setType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setType). Imposta prima il tipo, poi usa l'oggetto di transizione appropriato ottenuto da [getValue](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#getValue).

L'esempio seguente applica una transizione Cut alla prima diapositiva di `input.pptx`. Chiama [setFromBlack](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) tramite [OptionalBlackTransition](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/optionalblacktransition/) affinché la transizione inizi da uno schermo nero.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso controllare la velocità di riproduzione di una transizione di diapositiva?**

Sì. Preferisci [setDuration](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setDuration) quando ti serve una durata dell'effetto precisa in millisecondi. Usa [setSpeed](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) quando è sufficiente una categoria predefinita di [TransitionSpeed](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/transitionspeed/) — Slow, Medium o Fast — e non è impostata una durata esplicita. Queste impostazioni controllano l'effetto di transizione indipendentemente dal ritardo di avanzamento automatico.

**Posso allegare audio a una transizione e farlo ripetere in loop?**

Sì. Assegna audio incorporato con [setSound](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setSound), passa StartSound dall'enumerazione [TransitionSoundMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/transitionsoundmode/) a [setSoundMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) e abilita [setSoundLoop](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) con `true`. L'audio si ripete in loop fino al prossimo evento sonoro nella presentazione.

**Qual è il modo più rapido per applicare la stessa transizione a tutte le diapositive?**

Scorri la collezione [getSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getSlides) della presentazione e chiama [setType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#setType) con lo stesso valore per la transizione di ciascuna diapositiva. Imposta eventuali opzioni di timing ed effetti nello stesso ciclo per mantenere il comportamento coerente su tutte le diapositive.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Chiama [getType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/#getType) sul risultato di [getSlideShowTransition](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) della diapositiva. Restituisce un valore dell'enumerazione [TransitionType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/transitiontype/); None indica che non è applicato alcun effetto di transizione.