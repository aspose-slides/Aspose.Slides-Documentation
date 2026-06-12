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
- transizione morph
- tipo di transizione
- effetto di transizione
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Personalizza le transizioni delle diapositive in JavaScript con Aspose.Slides per Node.js via Java, con indicazioni passo-passo per presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come gestire le transizioni delle diapositive nelle presentazioni utilizzando Aspose.Slides. Mostra come applicare i tipi di transizione alle diapositive, configurare il comportamento della transizione come avanzare al clic o dopo un tempo specificato, verificare e disabilitare l’avanzamento automatico, utilizzare la transizione Morph e i suoi tipi, e impostare le opzioni degli effetti di transizione. Gli esempi dimostrano come caricare o creare una presentazione, modificare le impostazioni di transizione per le diapositive selezionate e salvare il risultato come file PPTX. L’articolo risponde inoltre alle domande comuni sulla velocità della transizione, i suoni della transizione, l’applicazione della stessa transizione a più diapositive e la verifica della transizione attualmente impostata su una diapositiva.

## **Aggiungi transizione diapositiva**
Per creare un effetto di transizione semplice per la diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Applica un tipo di transizione diapositiva alla diapositiva scegliendo uno degli effetti di transizione offerti da Aspose.Slides per Node.js via Java tramite l'enumerazione TransitionType.
1. Scrivi il file della presentazione modificata.

```javascript
// Istanzia la classe Presentation per caricare il file della presentazione di origine
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Applica la transizione di tipo cerchio sulla diapositiva 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Applica la transizione di tipo comb sulla diapositiva 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Scrivi la presentazione su disco
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aggiungi transizione diapositiva avanzata**
Nella sezione precedente, abbiamo applicato un effetto di transizione semplice alla diapositiva. Ora, per rendere quell’effetto di transizione ancora migliore e più controllato, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Applica un tipo di transizione diapositiva alla diapositiva scegliendo uno degli effetti di transizione offerti da Aspose.Slides per Node.js via Java.
1. Puoi anche impostare la transizione per avanzare al clic, dopo un periodo di tempo specifico o entrambi.
1. Se la transizione della diapositiva è impostata per avanzare al clic, la transizione avverrà solo quando qualcuno cliccherà il mouse. Inoltre, se la proprietà Advance After Time è impostata, la transizione avanzerà automaticamente dopo il tempo di avanzamento specificato.
1. Scrivi la presentazione modificata come file di presentazione.

```javascript
// Istanzia la classe Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // Applica la transizione di tipo cerchio sulla diapositiva 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Imposta il tempo di transizione a 3 secondi
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // Applica la transizione di tipo comb sulla diapositiva 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Imposta il tempo di transizione a 5 secondi
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // Applica la transizione di tipo zoom sulla diapositiva 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // Imposta il tempo di transizione a 7 secondi
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // Scrivi la presentazione su disco
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Transizione Morph**
{{% alert color="primary" %}} 

Aspose.Slides per Node.js via Java ora supporta la [Morph Transition](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/MorphTransition). Rappresentano la nuova transizione morph introdotta in PowerPoint 2019.

{{% /alert %}} 

La transizione Morph consente di animare un movimento fluido da una diapositiva alla successiva. Questo articolo descrive il concetto e come utilizzare la transizione Morph. Per utilizzare efficacemente la transizione Morph, è necessario avere due diapositive con almeno un oggetto in comune. Il modo più semplice è duplicare la diapositiva e quindi spostare l'oggetto nella seconda diapositiva in una posizione diversa.

Il seguente frammento di codice mostra come aggiungere un clone della diapositiva con del testo alla presentazione e impostare una transizione di [tipo morph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TransitionType) alla seconda diapositiva.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tipi di transizione Morph**
È stato aggiunto il nuovo enumeratore [TransitionMorphType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TransitionMorphType). Rappresenta diversi tipi di transizione Morph per le diapositive.

L'enumeratore TransitionMorphType ha tre membri:

- ByObject: la transizione Morph verrà eseguita considerando le forme come oggetti indivisibili.
- ByWord: la transizione Morph verrà eseguita trasferendo il testo parola per parola, dove possibile.
- ByChar: la transizione Morph verrà eseguita trasferendo il testo carattere per carattere, dove possibile.

Il seguente frammento di codice mostra come impostare una transizione morph alla diapositiva e cambiare il tipo di morph:

```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta effetti di transizione**
Aspose.Slides per Node.js via Java supporta l'impostazione degli effetti di transizione, come da nero, da sinistra, da destra, ecc. Per impostare l'effetto di transizione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
- Ottieni il riferimento della diapositiva.
- Imposta l'effetto di transizione.
- Scrivi la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/).

Nell'esempio riportato di seguito, abbiamo impostato gli effetti di transizione.

```javascript
// Crea un'istanza della classe Presentation
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Imposta l'effetto
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // Scrivi la presentazione su disco
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso controllare la velocità di riproduzione di una transizione diapositiva?**

Sì. Imposta la [velocità](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/setspeed/) della transizione utilizzando l'impostazione [TransitionSpeed](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/transitionspeed/) (ad es., lento/medio/veloce).

**Posso allegare audio a una transizione e farlo ripetere in loop?**

Sì. Puoi incorporare un suono per la transizione e controllarne il comportamento tramite impostazioni come modalità suono e loop (ad es., [setSound](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/)), oltre a metadati come [setSoundIsBuiltIn](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) e [setSoundName](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/setsoundname/).

**Qual è il modo più rapido per applicare la stessa transizione a tutte le diapositive?**

Configura il tipo di transizione desiderato nelle impostazioni di transizione di ciascuna diapositiva; le transizioni sono memorizzate per diapositiva, quindi applicare lo stesso tipo a tutte le diapositive produce un risultato coerente.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Esamina le [impostazioni di transizione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) della diapositiva e leggi il suo [tipo di transizione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideshowtransition/gettype/); quel valore indica esattamente quale effetto è applicato.