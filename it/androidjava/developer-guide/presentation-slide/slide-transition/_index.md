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
description: "Scopri come personalizzare le transizioni delle diapositive in Aspose.Slides per Android tramite Java, con guide passo passo per presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come gestire le transizioni delle diapositive nelle presentazioni utilizzando Aspose.Slides. Mostra come applicare i tipi di transizione alle diapositive, configurare il comportamento della transizione come avanzare al clic o dopo un tempo specificato, verificare e disabilitare l'avanzamento automatico, utilizzare la transizione Morph e i suoi tipi e impostare le opzioni degli effetti di transizione. Gli esempi dimostrano come caricare o creare una presentazione, modificare le impostazioni di transizione per le diapositive selezionate e salvare il risultato in un file PPTX. L'articolo risponde inoltre alle domande comuni su velocità della transizione, suoni della transizione, applicare la stessa transizione a più diapositive e verificare la transizione attualmente impostata su una diapositiva.

## **Aggiungi transizione diapositiva**
Per creare un effetto di transizione diapositiva semplice, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) .
2. Applica un tipo di transizione diapositiva alla diapositiva da uno dei effetti di transizione offerti da Aspose.Slides per Android tramite Java tramite l'enumerazione TransitionType.
3. Scrivi il file della presentazione modificata.

```java
// Istanziare la classe Presentation per caricare il file di presentazione di origine
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

## **Aggiungi transizione diapositiva avanzata**
Nella sezione precedente, abbiamo applicato solo un effetto di transizione semplice alla diapositiva. Ora, per rendere quell'effetto di transizione ancora migliore e più controllato, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) .
2. Applica un tipo di transizione diapositiva alla diapositiva da uno dei effetti di transizione offerti da Aspose.Slides per Android tramite Java.
3. Puoi anche impostare la transizione su Avanzamento al clic, dopo un periodo di tempo specifico o entrambi.
4. Se la transizione della diapositiva è abilitata all'Avanzamento al clic, la transizione avverrà solo quando qualcuno farà clic con il mouse. Inoltre, se la proprietà Advance After Time è impostata, la transizione avverrà automaticamente dopo il tempo di avanzamento specificato.
5. Scrivi la presentazione modificata come file di presentazione.

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Applica la transizione di tipo cerchio alla diapositiva 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Imposta il tempo di transizione a 3 secondi
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Applica la transizione di tipo comb alla diapositiva 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Imposta il tempo di transizione a 5 secondi
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Applica la transizione di tipo zoom alla diapositiva 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Imposta il tempo di transizione a 7 secondi
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Scrivi la presentazione su disco
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Transizione Morph**
{{% alert color="primary" %}} 

Aspose.Slides per Android tramite Java ora supporta la [Morph Transition](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IMorphTransition). Rappresenta la nuova transizione morph introdotta in PowerPoint 2019.

{{% /alert %}} 

La transizione Morph ti consente di animare un movimento fluido da una diapositiva alla successiva. Questo articolo descrive il concetto e come utilizzare la transizione Morph. Per utilizzare efficacemente la transizione Morph, è necessario avere due diapositive con almeno un oggetto in comune. Il modo più semplice è duplicare la diapositiva e poi spostare l'oggetto sulla seconda diapositiva in una posizione diversa.

Il seguente frammento di codice mostra come aggiungere una copia della diapositiva con del testo alla presentazione e impostare una transizione di [morph type](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TransitionType) alla seconda diapositiva.

```java
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

## **Tipi di transizione Morph**
È stata aggiunta la nuova enumerazione [TransitionMorphType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TransitionMorphType). Rappresenta diversi tipi di transizione diapositiva Morph.

L'enumerazione TransitionMorphType ha tre membri:

- ByObject: la transizione Morph verrà eseguita considerando le forme come oggetti indivisibili.
- ByWord: la transizione Morph verrà eseguita trasferendo il testo per parole, dove possibile.
- ByChar: la transizione Morph verrà eseguita trasferendo il testo per caratteri, dove possibile.

Il seguente frammento di codice mostra come impostare la transizione morph su una diapositiva e cambiare il tipo di morph:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta effetti di transizione**
Aspose.Slides per Android tramite Java supporta l'impostazione degli effetti di transizione, come da nero, da sinistra, da destra, ecc. Per impostare l'effetto di transizione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) .
- Ottieni il riferimento della diapositiva.
- Imposta l'effetto di transizione.
- Scrivi la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/).

Nell'esempio riportato di seguito, abbiamo impostato gli effetti di transizione.

```java
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

**Posso controllare la velocità di riproduzione di una transizione diapositiva?**

Sì. Imposta la [speed](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) della transizione utilizzando l'impostazione [TransitionSpeed](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/transitionspeed/) (ad es., slow/medium/fast).

**Posso associare audio a una transizione e farlo ripetere in loop?**

Sì. Puoi incorporare un suono per la transizione e controllare il comportamento tramite impostazioni come modalità suono e looping (ad es., [setSound](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), più metadati come [setSoundIsBuiltIn](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) e [setSoundName](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Qual è il modo più rapido per applicare la stessa transizione a ogni diapositiva?**

Configura il tipo di transizione desiderato nelle impostazioni di transizione di ogni diapositiva; le transizioni sono memorizzate per diapositiva, quindi applicare lo stesso tipo a tutte le diapositive produce un risultato coerente.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Controlla le [transition settings](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) della diapositiva e leggi il suo [transition type](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); quel valore indica esattamente quale effetto è applicato.