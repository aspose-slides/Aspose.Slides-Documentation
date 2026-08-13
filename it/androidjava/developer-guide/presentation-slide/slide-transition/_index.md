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
- transizione morph
- tipo di transizione
- effetto di transizione
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come personalizzare le transizioni delle diapositive in Aspose.Slides per Android via Java, con guide passo passo per presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come gestire le transizioni delle diapositive nelle presentazioni utilizzando Aspose.Slides. Mostra come applicare tipi di transizione alle diapositive, configurare il comportamento della transizione come avanzare al click o dopo un tempo specificato, utilizzare la transizione Morph e i suoi tipi, e impostare le opzioni dell’effetto di transizione. Gli esempi dimostrano come caricare o creare una presentazione, modificare le impostazioni di transizione per le diapositive selezionate e salvare il risultato come file PPTX. L’articolo risponde anche alle domande comuni sulla velocità della transizione, i suoni della transizione, l’applicazione della stessa transizione a più diapositive e la verifica della transizione attualmente impostata su una diapositiva.

## **Aggiungi Transizione Diapositiva**
Per creare un semplice effetto di transizione della diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) .
1. Applica un Tipo di Transizione Diapositiva sulla diapositiva da uno dei effetti di transizione offerti da Aspose.Slides per Android via Java tramite l'enumerazione TransitionType.
1. Scrivi il file della presentazione modificata.

```java
import com.aspose.slides.*;

// Istanzia la classe Presentation per caricare il file di presentazione di origine
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Applica la transizione di tipo cerchio alla diapositiva 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Applica la transizione di tipo comb alla diapositiva 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Scrivi la presentazione su disco
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aggiungi Transizione Diapositiva Avanzata**
Nella sezione precedente, abbiamo applicato un semplice effetto di transizione sulla diapositiva. Ora, per rendere quell’effetto di transizione semplice ancora migliore e controllato, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) .
1. Applica un Tipo di Transizione Diapositiva sulla diapositiva da uno dei effetti di transizione offerti da Aspose.Slides per Android via Java.
1. Puoi anche impostare la transizione per Avanzare al Click, dopo un periodo di tempo specifico o entrambi.
1. Se la transizione della diapositiva è abilitata per Avanzare al Click, la transizione avverrà solo quando qualcuno farà clic con il mouse. Inoltre, se la proprietà Advance After Time è impostata, la transizione avanzerà automaticamente dopo che il tempo di avanzamento specificato sarà trascorso.
1. Scrivi la presentazione modificata come file di presentazione.

```java
import com.aspose.slides.*;

// Instanzia la classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Applica la transizione di tipo cerchio alla diapositiva 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Avanza al click o automaticamente dopo 3 secondi
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Applica la transizione di tipo comb alla diapositiva 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Avanza al click o automaticamente dopo 5 secondi
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Applica la transizione di tipo zoom alla diapositiva 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Avanza al click o automaticamente dopo 7 secondi
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Scrivi la presentazione su disco
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Transizione Morph**
{{% alert color="info" %}} 

Aspose.Slides per Android via Java ora supporta la [Morph Transition](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IMorphTransition). Rappresentano la nuova transizione morph introdotta in PowerPoint 2019.

{{% /alert %}} 

La transizione Morph consente di animare un movimento fluido da una diapositiva alla successiva. Questo articolo descrive il concetto e come utilizzare la transizione Morph. Per utilizzare efficacemente la transizione Morph, è necessario avere due diapositive con almeno un oggetto in comune. Il modo più semplice è duplicare la diapositiva e quindi spostare l’oggetto sulla seconda diapositiva in una posizione diversa.

Il seguente frammento di codice mostra come aggiungere una copia della diapositiva con del testo alla presentazione e impostare una transizione di [tipo morph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TransitionType) sulla seconda diapositiva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Tipi di Transizione Morph**
È stato aggiunto il nuovo enum [TransitionMorphType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TransitionMorphType). Rappresenta i diversi tipi di transizione Morph della diapositiva.

L'enumerazione TransitionMorphType ha tre membri:

- ByObject: La transizione Morph verrà eseguita considerando le forme come oggetti indivisibili.
- ByWord: La transizione Morph verrà eseguita trasferendo il testo per parole, dove possibile.
- ByChar: La transizione Morph verrà eseguita trasferendo il testo per caratteri, dove possibile.

Il frammento di codice seguente mostra come impostare la transizione morph sulla diapositiva e cambiare il tipo morph:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta Effetti di Transizione**
Aspose.Slides per Android via Java supporta l'impostazione degli effetti di transizione, come da nero, da sinistra, da destra ecc. Per impostare l’Effetto di Transizione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) .
- Ottieni il riferimento della diapositiva.
- Imposta l'effetto di transizione.
- Scrivi la presentazione come un [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.

Nell'esempio riportato di seguito, abbiamo impostato gli effetti di transizione.

```java
import com.aspose.slides.*;

// Crea un'istanza della classe Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Imposta l'effetto
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Scrivi la presentazione su disco
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Posso controllare la velocità di riproduzione di una transizione della diapositiva?

Sì. Imposta la [velocità](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) della transizione usando l'impostazione [TransitionSpeed](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/transitionspeed/) (ad es., slow/medium/fast).

### Posso allegare un audio a una transizione e farlo ripetere in loop?

Sì. Puoi incorporare un suono per la transizione e controllarne il comportamento tramite impostazioni come modalità suono e ripetizione (ad es., [setSound](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), più metadati come [setSoundIsBuiltIn](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) e [setSoundName](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Qual è il modo più rapido per applicare la stessa transizione a ogni diapositiva?

Configura il tipo di transizione desiderato nelle impostazioni di transizione di ciascuna diapositiva; le transizioni sono memorizzate per diapositiva, quindi applicare lo stesso tipo a tutte le diapositive fornisce un risultato coerente.

### Come posso verificare quale transizione è attualmente impostata su una diapositiva?

Ispeziona le [impostazioni di transizione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) della diapositiva e leggi il suo [tipo di transizione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); quel valore ti indica esattamente quale effetto è applicato.