---
title: Gestire le transizioni delle diapositive nelle presentazioni usando Java
linktitle: Transizione diapositiva
type: docs
weight: 80
url: /it/java/slide-transition/
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
- Java
- Aspose.Slides
description: "Scopri come personalizzare le transizioni delle diapositive in Aspose.Slides per Java, con guide passo passo per presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come gestire le transizioni delle diapositive nelle presentazioni utilizzando Aspose.Slides. Mostra come applicare tipi di transizione alle diapositive, configurare il comportamento della transizione come avanzare al clic o dopo un tempo specificato, verificare e disabilitare l’avanzamento automatico, utilizzare la transizione Morph e i suoi tipi, e impostare le opzioni degli effetti di transizione. Gli esempi dimostrano come caricare o creare una presentazione, modificare le impostazioni di transizione per le diapositive selezionate e salvare il risultato come file PPTX. L’articolo risponde anche a domande comuni su velocità della transizione, suoni di transizione, applicare la stessa transizione a più diapositive e verificare la transizione attualmente impostata su una diapositiva.

## **Aggiungere una transizione alla diapositiva**
Per creare un semplice effetto di transizione della diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
2. Applica un tipo di transizione alla diapositiva scegliendo uno degli effetti di transizione offerti da Aspose.Slides per Java tramite l'enumerazione TransitionType.
3. Scrivi il file della presentazione modificata.

```java
import com.aspose.slides.*;

// Istanziare la classe Presentation per caricare il file della presentazione sorgente
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Applicare la transizione di tipo cerchio alla diapositiva 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Applicare la transizione di tipo pettine alla diapositiva 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Scrivere la presentazione su disco
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aggiungere una transizione avanzata alla diapositiva**
Nella sezione precedente abbiamo applicato un semplice effetto di transizione alla diapositiva. Ora, per rendere quell’effetto ancora migliore e più controllato, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
2. Applica un tipo di transizione alla diapositiva scegliendo uno degli effetti di transizione offerti da Aspose.Slides per Java.
3. Puoi anche impostare la transizione per avanzare al clic, dopo un intervallo di tempo specifico o entrambi.
4. Se la transizione della diapositiva è abilitata per avanzare al clic, la transizione avanzerà solo quando qualcuno farà clic del mouse. Inoltre, se la proprietà Advance After Time è impostata, la transizione avanzerà automaticamente dopo il tempo specificato.
5. Scrivi la presentazione modificata come file di presentazione.

```java
import com.aspose.slides.*;

// Istanziare la classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Applicare la transizione di tipo cerchio alla diapositiva 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Impostare il tempo di transizione a 3 secondi
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Applicare la transizione di tipo pettine alla diapositiva 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Impostare il tempo di transizione a 5 secondi
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Applicare la transizione di tipo zoom alla diapositiva 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Impostare il tempo di transizione a 7 secondi
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Scrivere la presentazione su disco
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Transizione Morph**
{{% alert color="info" %}} 

Aspose.Slides per Java ora supporta la [Morph Transition](https://reference.aspose.com/slides/it/java/com.aspose.slides/IMorphTransition). Rappresenta la nuova transizione morph introdotta in PowerPoint 2019.

{{% /alert %}} 

La transizione Morph consente di animare un movimento fluido da una diapositiva alla successiva. Questo articolo descrive il concetto e come utilizzare la transizione Morph. Per usare efficacemente la transizione Morph, è necessario avere due diapositive con almeno un oggetto in comune. Il metodo più semplice è duplicare la diapositiva e poi spostare l'oggetto nella seconda diapositiva in una posizione diversa.

Il frammento di codice seguente mostra come aggiungere una copia della diapositiva con del testo alla presentazione e impostare una transizione di tipo [morph](https://reference.aspose.com/slides/it/java/com.aspose.slides/TransitionType) sulla seconda diapositiva.

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

## **Tipi di transizione Morph**
È stata aggiunta la nuova enumerazione [TransitionMorphType](https://reference.aspose.com/slides/it/java/com.aspose.slides/TransitionMorphType). Rappresenta i diversi tipi di transizione Morph della diapositiva.

L'enumerazione TransitionMorphType ha tre membri:

- ByObject: la transizione Morph verrà eseguita considerando le forme come oggetti indivisibili.
- ByWord: la transizione Morph verrà eseguita trasferendo il testo parola per parola, dove possibile.
- ByChar: la transizione Morph verrà eseguita trasferendo il testo carattere per carattere, dove possibile.

Il frammento di codice seguente mostra come impostare la transizione Morph sulla diapositiva e cambiare il tipo di morph:

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

## **Impostare gli effetti di transizione**
Aspose.Slides per Java supporta l’impostazione degli effetti di transizione, come da nero, da sinistra, da destra, ecc. Per impostare l’effetto di transizione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
- Ottieni il riferimento della diapositiva.
- Imposta l’effetto di transizione.
- Scrivi la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/).

Nell’esempio fornito di seguito, abbiamo impostato gli effetti di transizione.

```java
import com.aspose.slides.*;

// Creare un'istanza della classe Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Impostare l'effetto
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Scrivere la presentazione su disco
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Posso controllare la velocità di riproduzione di una transizione della diapositiva?

Sì. Imposta la [speed](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) della transizione utilizzando l’impostazione [TransitionSpeed](https://reference.aspose.com/slides/it/java/com.aspose.slides/transitionspeed/) (ad esempio, lento/medio/veloce).

### Posso allegare audio a una transizione e farlo ripetere in loop?

Sì. È possibile incorporare un suono per la transizione e controllarne il comportamento tramite impostazioni come modalità suono e loop (ad esempio, [setSound](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), oltre a metadati come [setSoundIsBuiltIn](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) e [setSoundName](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Qual è il modo più veloce per applicare la stessa transizione a ogni diapositiva?

Configura il tipo di transizione desiderato nelle impostazioni di transizione di ciascuna diapositiva; le transizioni sono memorizzate per diapositiva, quindi applicare lo stesso tipo a tutte le diapositive produce un risultato coerente.

### Come posso verificare quale transizione è attualmente impostata su una diapositiva?

Ispeziona le [transition settings](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseslide/#getSlideShowTransition--) della diapositiva e leggi il suo [transition type](https://reference.aspose.com/slides/it/java/com.aspose.slides/slideshowtransition/#setType-int-); quel valore indica esattamente quale effetto è applicato.