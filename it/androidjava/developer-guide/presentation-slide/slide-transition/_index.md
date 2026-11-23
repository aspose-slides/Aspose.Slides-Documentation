---
title: Gestire le transizioni delle diapositive nelle presentazioni su Android
linktitle: Transizione diapositiva
type: docs
weight: 80
url: /it/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "Applica le transizioni delle diapositive, configura l’avanzamento automatico delle diapositive e personalizza le transizioni Morph e altre transizioni con Aspose.Slides per Android via Java."
---
## **Panoramica**

Le transizioni delle diapositive controllano il modo in cui le diapositive appaiono durante una presentazione. Con Aspose.Slides per Android tramite Java, è possibile scegliere un effetto di transizione per ogni diapositiva, configurare l’avanzamento tramite click del mouse o timer e regolare le opzioni specifiche per un effetto. Questo articolo utilizza esempi Java per applicare transizioni, impostare durate di transizione precise, gestire la temporizzazione delle diapositive e creare una transizione Morph tra due diapositive. Gli esempi mostrano anche come salvare le impostazioni in un file PPTX.

## **Aggiungere la transizione alla diapositiva**

Per applicare una transizione, carica una presentazione con la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) e accedi alle impostazioni di transizione della diapositiva tramite [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Usa [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) con un valore dell’enumerazione [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/), quindi salva la presentazione.

L’esempio seguente applica una transizione Circle alla prima diapositiva e una transizione Comb alla seconda. Usa un file `input.pptx` con almeno due diapositive.

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

## **Transizione Ruota**

Il metodo [setSpokes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/#setSpokes-long-) dell’interfaccia [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) controlla il numero di settori radiali che rivelano la diapositiva di destinazione. Imposta il tipo di transizione della diapositiva su Wheel dal [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) usando [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) prima di accedere a [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) come [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/).

Questo esempio crea due coppie identiche di diapositive: una diapositiva nera seguita da una diapositiva con un rettangolo oro. Le diapositive di destinazione usano conteggi di raggi di 1 e 8, con la stessa velocità impostata tramite [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) e una durata esplicita di 8.000 millisecondi impostata tramite [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) per rendere la differenza facile da osservare.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    int gold = Color.rgb(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Apri la presentazione di output in PowerPoint ed avvia la presentazione. Avanza dalla diapositiva 1 alla diapositiva 2, quindi dalla diapositiva 3 alla diapositiva 4. Durante la riproduzione in PowerPoint, il conteggio verificato di 1 raggi rivela la diapositiva con una singola spazzata oraria; il conteggio verificato di 8 la rivela attraverso otto settori radiali simultaneamente. Il contenuto di destinazione e la temporizzazione della transizione sono identici, quindi la differenza è il numero di settori di rivelazione.

## **Dissolvenza nera con la transizione Reveal**

Imposta il tipo di transizione della diapositiva di destinazione su Reveal, quindi chiama [setThroughBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) nelle impostazioni del suo [IRevealTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/). L’esempio crea una diapositiva di origine color acqua e una diapositiva di destinazione color corallo, quindi clona entrambe. Ogni coppia utilizza la stessa transizione Reveal di due secondi. Solo la seconda coppia sfuma attraverso il nero.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    int[] backgrounds = { Color.rgb(0, 128, 128), Color.rgb(255, 127, 80) };
    String[] labels = { "Source", "Destination" };

    for (int i = 0; i < slides.length; i++) {
        ISlide slide = slides[i];
        slide.getBackground().setType(BackgroundType.OwnBackground);
        slide.getBackground().getFillFormat().setFillType(FillType.Solid);
        slide.getBackground().getFillFormat().getSolidFillColor().setColor(backgrounds[i]);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
        shape.getTextFrame().setText(labels[i]);
        shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    ISlide clonedDestination = presentation.getSlides().addClone(destination);
    for (ISlide slide : new ISlide[] { destination, clonedDestination }) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Reveal);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(2000);

        IRevealTransition reveal = (IRevealTransition) transition.getValue();
        reveal.setDirection(TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide == clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Apri la presentazione salvata in PowerPoint e avvia la presentazione. Avanza dalla diapositiva 1 alla diapositiva 2 per vedere l’acqua sfumare direttamente in corallo. Quindi avanza dalla diapositiva 3 alla diapositiva 4. Lo schermo si oscura brevemente quasi fino al nero prima che la diapositiva corallo appaia. Entrambe le diapositive mantengono i loro colori di sfondo originali.

Le righe sottostanti mostrano fotogrammi di PowerPoint a intervalli di mezzo secondo. Confronta il fotogramma centrale di ogni riga per vedere l’effetto.

![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](reveal-through-black.png)

## **Aggiungere transizione avanzata alla diapositiva**

È possibile configurare per quanto tempo una diapositiva rimane sullo schermo e se un click del mouse avanza la presentazione. I seguenti metodi controllano questo comportamento:

- [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) consente allo spettatore di avanzare facendo click con il mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) abilita l’avanzamento automatico.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) specifica il ritardo prima dell’avanzamento automatico, in millisecondi.

Abilita sia l’avanzamento con click sia quello temporizzato per consentire allo spettatore di proseguire con un click o attendere il timer. Per usare solo il timer, passa `false` a [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Il ritardo controlla quando la presentazione avanza; non imposta la durata dell’effetto di transizione visivo.

Questo esempio assegna effetti diversi alle prime tre diapositive e abilita l’avanzamento automatico dopo 3, 5 e 7 secondi, rispettivamente. I click del mouse possono anche avanzare queste diapositive. Usa un file `input.pptx` con almeno tre diapositive.

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

Per verificare se l’avanzamento temporizzato è abilitato, chiama [getAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Un ritardo memorizzato da solo non indica che il timer sia attivo.

L’esempio successivo apre il file salvato sopra, segnala ogni timer abilitato e disabilita l’avanzamento automatico per le diapositive con un ritardo maggiore di due secondi. Abilita i click del mouse per quelle diapositive e salva le impostazioni aggiornate.

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

## **Controllare con precisione la temporizzazione delle transizioni**

Usa [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) per specificare la lunghezza esatta di un effetto di transizione in millisecondi. Il metodo [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) della diapositiva espone queste impostazioni tramite [ISlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/):

| Metodo | Scopo |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Imposta la durata dell’effetto di transizione stesso, in millisecondi. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Imposta il ritardo prima che la diapositiva avanzi automaticamente, in millisecondi. Passa `true` a [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) per attivare questo timer. |
| [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Seleziona una categoria di velocità predefinita da [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/): Slow, Medium o Fast. Viene usata quando non è specificata una durata esplicita. |

[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) controlla solo l’effetto di transizione; non determina per quanto tempo la diapositiva rimane visibile. Configura separatamente il ritardo di avanzamento automatico. Quando non è impostata alcuna durata esplicita, Aspose.Slides determina la durata dell’effetto dal tipo di transizione e dal valore di [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*L’esempio condiviso assegna a ogni diapositiva una transizione Fade di 750 ms e abilita separatamente l’avanzamento automatico a 5 000 ms. La durata della transizione controlla l’effetto; l’avanzamento controlla quando lasciare la diapositiva. Queste barre rappresentano impostazioni schematiche, non una timeline misurata combinata.*
<!-- visual-explanation:slide-transition:end -->

### **Applicare la stessa durata a ogni diapositiva**

Per mantenere un ritmo coerente, applica lo stesso effetto e la stessa durata esatta a ogni diapositiva. Questo esempio carica `input.pptx`, seleziona Fade dal [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/), e assegna a ciascuna transizione una durata di 750 millisecondi. Abilita separatamente l’avanzamento automatico dopo 5.000 millisecondi e disabilita l’avanzamento con click del mouse, quindi salva il risultato come PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Configura l'avanzamento automatico indipendentemente dalla durata dell'effetto.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Impostare durate diverse per diapositive individuali**

Diapositive diverse possono usare durate di effetto differenti. Ad esempio, usa una transizione breve per una diapositiva titolo e una più lunga per l’introduzione di una sezione. Questo esempio imposta 500 millisecondi per la prima diapositiva e 1.200 millisecondi per la seconda. Usa un file `input.pptx` con almeno due diapositive.

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

### **Coordinare le transizioni con l’output animato**

Quando si prepara un [animated GIF](/slides/it/androidjava/convert-powerpoint-to-animated-gif/), una [HTML5 presentation](/slides/it/androidjava/export-to-html5/) o un [video](/slides/it/androidjava/convert-powerpoint-to-video/), imposta durate di transizione esatte prima dell’esportazione per corrispondere al ritmo desiderato. Ad esempio, usa una dissolvenza di 600 ms tra le scene e regola separatamente il ritardo di avanzamento di ogni diapositiva per consentire il tempo necessario alla narrazione o al contenuto.

Per GIF e video, coordina la frequenza dei fotogrammi di output con la durata dell’effetto: 600 ms corrispondono a 18 fotogrammi a 30 fps. In HTML5, abilita le transizioni animate nelle impostazioni di esportazione. Controlla gli effetti e le opzioni di temporizzazione supportati dal formato di esportazione scelto e visualizza un’anteprima dell’output per confermare la sincronizzazione.

### **Leggere la durata di una transizione esistente**

Chiama [getDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) prima di modificare la transizione per determinare se è memorizzata una durata esplicita. Un valore di `-1` indica che non è impostata alcuna durata esplicita; un valore non negativo specifica la durata memorizzata in millisecondi. Il valore non impostato non è la durata di riproduzione calcolata: Aspose.Slides usa il tipo di transizione e il valore di [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) per determinare tale durata. Impostare un tipo di transizione può inizializzare una durata, quindi ispeziona prima le impostazioni originali.

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

La transizione Morph anima le modifiche tra oggetti su diapositive consecutive. Per creare un semplice effetto Morph, clona una diapositiva, sposta o ridimensiona un oggetto nella copia e applica la transizione Morph alla seconda diapositiva. Questo fornisce agli oggetti corrispondenti la possibilità di animarsi tra lo stato originale e quello modificato.

L’esempio seguente crea una diapositiva con un rettangolo di testo, clona la diapositiva e cambia la posizione e le dimensioni del rettangolo nella copia. Quindi seleziona Morph dal [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) per la seconda diapositiva. Apri il file salvato in un visualizzatore di presentazioni che supporti Morph per vedere l’effetto durante una presentazione.

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

L’enumerazione [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/) controlla come Morph associa e anima il contenuto:

- [ByObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) tratta ogni forma come un singolo oggetto.
- [ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) anima il testo abbinando parole dove possibile.
- [ByChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) anima il testo abbinando caratteri dove possibile.

Usa [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) per selezionare Morph prima di accedere a [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--). Il valore fornisce quindi l’interfaccia [IMorphTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/), il cui metodo [setMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) seleziona la modalità di corrispondenza.

Questo esempio apre la presentazione creata nella sezione precedente e configura la seconda diapositiva per usare l’animazione Morph basata sulle parole.

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

## **Impostare effetti di transizione**

Alcune transizioni espongono opzioni aggiuntive, come la direzione o se l’effetto inizia da uno schermo nero. Le opzioni disponibili dipendono dalla transizione selezionata con [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-). Imposta prima il tipo, quindi utilizza l’interfaccia appropriata da [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--).

L’esempio seguente applica una transizione Cut alla prima diapositiva di `input.pptx`. Chiama [setFromBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) tramite [IOptionalBlackTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/) affinché la transizione inizi da uno schermo nero.

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

Sì. Preferisci [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) quando hai bisogno di una durata dell’effetto esatta in millisecondi. Usa [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) quando è sufficiente una categoria predefinita di [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/): Slow, Medium o Fast e non è impostata una durata esplicita. Queste impostazioni controllano l’effetto di transizione indipendentemente dal ritardo di avanzamento automatico.

**Posso allegare audio a una transizione e farlo riprodurre in loop?**

Sì. Assegna audio incorporato con [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), passa `StartSound` dall’enumerazione [TransitionSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionsoundmode/) a [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-), e abilita [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) con `true`. L’audio riproduce in loop fino al prossimo evento sonoro nella presentazione.

**Qual è il modo più veloce per applicare la stessa transizione a tutte le diapositive?**

Scorri la collezione [getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) della presentazione e chiama [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) con lo stesso valore per la transizione di ciascuna diapositiva. Imposta eventuali opzioni di temporizzazione ed effetto nello stesso ciclo per mantenere il comportamento coerente su tutte le diapositive.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Chiama [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getType--) sul risultato di [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) della diapositiva. Restituisce un valore dell’enumerazione [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/); None indica che non è applicato alcun effetto di transizione.