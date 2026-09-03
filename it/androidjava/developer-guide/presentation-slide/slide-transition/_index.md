---
title: Gestisci le transizioni delle diapositive nelle presentazioni su Android
linktitle: Transizione Diapositiva
type: docs
weight: 80
url: /it/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "Applica transizioni alle diapositive, configura l'avanzamento automatico delle diapositive e personalizza Morph e altri effetti di transizione con Aspose.Slides per Android via Java."
---
## **Panoramica**

Le transizioni delle diapositive controllano come le diapositive appaiono durante una presentazione. Con Aspose.Slides for Android via Java, è possibile scegliere un effetto di transizione per ciascuna diapositiva, configurare l’avanzamento tramite clic del mouse o timer, e regolare le opzioni specifiche per un effetto. Questo articolo utilizza esempi Java per applicare le transizioni, impostare durate precise, gestire il timing delle diapositive e creare una transizione Morph tra due diapositive. Gli esempi mostrano anche come salvare le impostazioni in un file PPTX.

## **Aggiungi transizione diapositiva**

Per applicare una transizione, carica una presentazione con la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) e accedi alle impostazioni di transizione della diapositiva tramite [getSlideShowTransition](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Usa [setType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) con un valore dell'enumerazione [TransitionType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/transitiontype/), quindi salva la presentazione.

L'esempio seguente applica una transizione Circle alla prima diapositiva e una transizione Comb alla seconda. Usa un file `input.pptx` con almeno due diapositive.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Aggiungi transizione avanzata**

Puoi configurare per quanto tempo una diapositiva rimane sullo schermo e se un clic del mouse fa avanzare la presentazione. I seguenti metodi controllano questo comportamento:

- [setAdvanceOnClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) consente allo spettatore di avanzare facendo clic del mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) abilita l'avanzamento automatico.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) specifica il ritardo prima dell'avanzamento automatico, in millisecondi.

Abilita sia il clic che l'avanzamento temporizzato per consentire allo spettatore di passare alla diapositiva con un clic o di attendere il timer. Per usare solo il timer, passa `false` a [setAdvanceOnClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Il ritardo controlla quando la presentazione avanza; non imposta la durata dell'effetto di transizione visiva.

Questo esempio assegna effetti diversi alle prime tre diapositive e abilita l'avanzamento automatico dopo 3, 5 e 7 secondi, rispettivamente. I clic del mouse possono anche far avanzare queste diapositive. Usa un file `input.pptx` con almeno tre diapositive.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Per verificare se l'avanzamento temporizzato è abilitato, chiama [getAdvanceAfter](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Un ritardo memorizzato da solo non indica che il timer sia attivo.

L'esempio successivo apre il file salvato sopra, segnala ogni timer abilitato e disabilita l'avanzamento automatico per le diapositive con un ritardo superiore a due secondi. Abilita i clic del mouse per quelle diapositive e salva le impostazioni aggiornate.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlla con precisione il timing della transizione**

Usa [setDuration](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) per specificare la lunghezza esatta di un effetto di transizione in millisecondi. Il metodo [getSlideShowTransition](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) della diapositiva espone queste impostazioni tramite [ISlideShowTransition](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/):

| Metodo | Scopo |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Imposta la durata dell'effetto di transizione stesso, in millisecondi. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Imposta il ritardo prima che la diapositiva avanzi automaticamente, in millisecondi. Passare `true` a [setAdvanceAfter](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) per attivare questo timer. |
| [setSpeed](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Seleziona una categoria di velocità predefinita dall'enumerazione [TransitionSpeed](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/transitionspeed/): Lenta, Media o Veloce. Viene usata quando non è specificata una durata esatta. |

[setDuration] controlla solo l'effetto di transizione; non determina quanto tempo la diapositiva rimane visibile. Configura separatamente il ritardo dell'avanzamento automatico. Quando non è impostata una durata esplicita, Aspose.Slides determina la durata dell'effetto dal tipo di transizione e dal valore di [getSpeed](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--).

### **Applica la stessa durata a tutte le diapositive**

Per mantenere un ritmo costante, applica lo stesso effetto e la stessa durata esatta a ogni diapositiva. Questo esempio carica `input.pptx`, seleziona Fade dall'enumerazione [TransitionType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/transitiontype/), e assegna a ogni transizione una durata di 750 millisecondi. Attiva separatamente l'avanzamento automatico dopo 5.000 millisecondi e disabilita l'avanzamento tramite clic del mouse, quindi salva il risultato come PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Configura l'avanzamento automatico in modo indipendente dalla durata dell'effetto.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Imposta durate diverse per diapositive individuali**

Diapositive diverse possono usare durate di effetto diverse. Ad esempio, usa una transizione breve per la diapositiva titolo e una più lunga per l'introduzione di una sezione. Questo esempio imposta 500 millisecondi per la prima diapositiva e 1.200 millisecondi per la seconda. Usa un file `input.pptx` con almeno due diapositive.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Coordina le transizioni con l'output animato**

Quando si prepara un [animated GIF](/slides/it/androidjava/convert-powerpoint-to-animated-gif/), una [HTML5 presentation](/slides/it/androidjava/export-to-html5/), o un [video](/slides/it/androidjava/convert-powerpoint-to-video/), imposta durate di transizione esatte prima dell'esportazione per corrispondere al ritmo desiderato. Ad esempio, usa una dissolvenza di 600 millisecondi tra le scene e regola separatamente il ritardo di avanzamento di ciascuna diapositiva per consentire il tempo della narrazione o del contenuto.

Per GIF e video, coordina la frequenza dei fotogrammi dell'output con la durata dell'effetto: 600 millisecondi corrispondono a 18 fotogrammi a 30 fps. In HTML5, abilita le transizioni animate nelle impostazioni di esportazione. Verifica gli effetti e le opzioni di timing supportati dal formato di esportazione scelto e visualizza un'anteprima per confermare la sincronizzazione.

### **Leggi la durata di una transizione esistente**

Chiama [getDuration](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) prima di modificare la transizione per determinare se è memorizzato un valore esplicito. Un valore di `-1` indica che non è impostata alcuna durata esplicita; un valore non negativo specifica la durata memorizzata in millisecondi. Il valore non impostato non è la durata di riproduzione calcolata: Aspose.Slides utilizza il tipo di transizione e il valore di [getSpeed](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) per determinare tale durata. Impostare un tipo di transizione può inizializzare una durata, quindi ispeziona prima le impostazioni originali.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Transizione Morph**

La transizione Morph anima le modifiche tra oggetti su diapositive consecutive. Per creare un semplice effetto Morph, clona una diapositiva, sposta o ridimensiona un oggetto nella copia e applica la transizione Morph alla seconda diapositiva. Questo fornisce agli oggetti corrispondenti la possibilità di animare dallo stato originale a quello modificato.

L'esempio seguente crea una diapositiva con un rettangolo di testo, ne clona la diapositiva e ne cambia posizione e dimensione nella copia. Quindi seleziona Morph dall'enumerazione [TransitionType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/transitiontype/) per la seconda diapositiva. Apri il file salvato in un visualizzatore di presentazioni che supporta Morph per vedere l'effetto durante la presentazione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tipi di transizione Morph**

L'enumerazione [TransitionMorphType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/transitionmorphtype/) controlla come Morph corrisponde e anima il contenuto:

- [ByObject](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) tratta ogni forma come un singolo oggetto.
- [ByWord](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) anima il testo confrontando le parole dove possibile.
- [ByChar](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) anima il testo confrontando i caratteri dove possibile.

Usa [setType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) per selezionare Morph prima di accedere a [getValue](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#getValue--). Il valore fornisce quindi l'interfaccia [IMorphTransition](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imorphtransition/), il cui metodo [setMorphType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) seleziona la modalità di corrispondenza.

Questo esempio apre la presentazione creata nella sezione precedente e configura la seconda diapositiva per utilizzare l'animazione Morph basata sulle parole.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Imposta effetti di transizione**

Alcune transizioni espongono opzioni aggiuntive, come la direzione o se l'effetto inizia da una schermata nera. Le opzioni disponibili dipendono dalla transizione selezionata con [setType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setType-int-). Imposta prima il tipo, quindi usa l'interfaccia appropriata ottenuta tramite [getValue](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#getValue--).

L'esempio seguente applica una transizione Cut alla prima diapositiva di `input.pptx`. Chiama [setFromBlack](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) attraverso [IOptionalBlackTransition](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ioptionalblacktransition/) in modo che la transizione inizi da una schermata nera.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso controllare la velocità di riproduzione di una transizione della diapositiva?**

Sì. Preferisci [setDuration](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) quando hai bisogno di una durata dell'effetto esatta in millisecondi. Usa [setSpeed](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) quando è sufficiente una categoria predefinita di [TransitionSpeed](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/transitionspeed/) — Lenta, Media o Veloce — e non è impostata una durata esplicita. Queste impostazioni controllano l'effetto di transizione indipendentemente dal ritardo dell'avanzamento automatico.

**Posso allegare audio a una transizione e farlo ripetere in loop?**

Sì. Assegna audio incorporato con [setSound](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), passa StartSound dall'enumerazione [TransitionSoundMode](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/transitionsoundmode/) a [setSoundMode](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-), e abilita [setSoundLoop](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) con `true`. L'audio si ripete in loop fino al prossimo evento sonoro nella presentazione.

**Qual è il modo più veloce per applicare la stessa transizione a tutte le diapositive?**

Itera attraverso la collezione [getSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSlides--) della presentazione e chiama [setType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) con lo stesso valore per la transizione di ogni diapositiva. Imposta eventuali opzioni di timing ed effetto nello stesso ciclo per mantenere il comportamento coerente su tutte le diapositive.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Chiama [getType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islideshowtransition/#getType--) sul risultato di [getSlideShowTransition](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) della diapositiva. Restituisce un valore dell'enumerazione [TransitionType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/transitiontype/); None indica che non è applicato alcun effetto di transizione.