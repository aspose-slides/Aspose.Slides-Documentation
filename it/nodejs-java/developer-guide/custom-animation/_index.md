---
title: Crea e Modifica Comportamenti di Animazione Personalizzati in JavaScript
linktitle: Animazione Personalizzata
type: docs
weight: 151
url: /it/nodejs-java/custom-animation/
keywords:
- animazione personalizzata
- comportamento di animazione
- percorso di movimento
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea, ispeziona e modifica comportamenti di animazione personalizzati e percorsi di movimento modificabili in presentazioni PowerPoint con Aspose.Slides per Node.js via Java."
---
## **Panoramica**

I comportamenti di animazione personalizzati ti consentono di controllare operazioni individuali all'interno di un effetto di animazione, come cambiare un colore, ruotare una forma o seguire un percorso di movimento modificabile. Questa guida mostra come creare e combinare comportamenti, configurare la loro temporizzazione, ispezionare e modificare le animazioni esistenti e verificare che le loro proprietà sopravvivano al salvataggio e alla riapertura di una presentazione.

Per effetti predefiniti e trigger di clic, vedi [Animazione Forma](/slides/it/nodejs-java/shape-animation/).

## **Comprendere il Modello di Animazione**

Un'animazione è organizzata come **Timeline → Sequence → Effect → Behaviors**:

- Il metodo [getTimeline](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/#getTimeline) restituisce la timeline della diapositiva, che contiene la sequenza principale e le sequenze interattive.
- Una [Sequence](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/) contiene effetti, potenzialmente rivolti a forme diverse.
- Un [Effect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/) identifica una forma di destinazione, un preset, un sottotipo e la temporizzazione dell'effetto.
- La collezione restituita da [Effect.getBehaviors](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#getBehaviors) contiene le operazioni che implementano l'effetto: cambiamento di colore, spostamento, rotazione, impostazione di una proprietà, ecc.

## **Creare Comportamenti Individuali**

Chiama [Sequence.addEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#addEffect) per creare un effetto e accedere alla collezione [getBehaviors](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#getBehaviors). Un preset può popolare automaticamente questa collezione. Mantieni le sue operazioni quando estendi il preset, o usa [clear](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorcollection/#clear) quando le sostituisci deliberatamente.

[BehaviorFactory](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorfactory/) crea gli otto tipi di comportamento illustrati di seguito. Il movimento è trattato in [Crea un Percorso di Movimento](#build-a-motion-path). Ogni frammento include le importazioni dei moduli e può essere eseguito come script Node.js con i pacchetti `aspose.slides.via.java` e `java` installati. Esegui gli esempi di creazione file prima di quelli che ne leggono l'output. Gli esempi di modifica successivi indicano quale file di output utilizzano.

### **Rotazione**

Usa [createRotationEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) per creare una rotazione. [getBy](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/rotationeffect/#getBy) specifica un angolo relativo in gradi; [getFrom](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/rotationeffect/#getFrom) e [getTo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/rotationeffect/#getTo) specificano i punti finali.

L'esempio parte da un effetto Spin, sostituisce le sue operazioni preset con un singolo comportamento di rotazione e assegna a tale operazione una durata di due secondi. Un angolo relativo di 90 gradi rappresenta un quarto di giro rispetto all'orientamento iniziale della forma, quindi non è necessario specificare un angolo di partenza esplicito.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` contiene una forma e un comportamento di rotazione. La collezione, la temporizzazione e gli esempi di modifica della rotazione qui sotto usano questo file.

### **Ridimensionamento**

Usa [createScaleEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) con percentuali X/Y: [getFrom](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/scaleeffect/#getFrom) e [getTo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/scaleeffect/#getTo) descrivono la dimensione iniziale e finale, mentre [getBy](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/scaleeffect/#getBy) descrive una variazione relativa. Qui, 100 corrisponde alla dimensione originale.

L'esempio aumenta entrambe le dimensioni dal 100 % al 125 % in due secondi. Usare percentuali uguali per orizzontale e verticale mantiene le proporzioni della forma; percentuali diverse allungherebbero una dimensione più dell'altra.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Colore**

Usa [createColorEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) per cambiare il riempimento da blu a arancione. [getFrom](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/coloreffect/#getFrom) e [getTo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/coloreffect/#getTo) sono colori; [getBy](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/coloreffect/#getBy) è una variazione di colore. [Behavior.getProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behavior/#getProperties) identifica l'attributo animato.

Il riempimento a tinta unita della forma è inizializzato a blu, corrispondente al colore di partenza dell'animazione. Selezionare l'attributo di riempimento colore indica al comportamento quale parte della forma modificare; i soli punti colore non identificano quell'attributo. L'effetto salvato descrive una transizione di due secondi verso l'arancione.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filtro**

Usa [createFilterEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) per selezionare un wipe. [getType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filtereffect/#getSubtype) e [getReveal](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filtereffect/#getReveal) specificano il filtro, la direzione e se rivelare o nascondere la forma.

Questo esempio configura un wipe di due secondi che rivela la forma usando il sottotipo di direzione destra. Le impostazioni del filtro appartengono al comportamento all'interno dell'effetto, quindi vengono configurate dopo aver rimosso le operazioni originali del preset.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Proprietà**

Usa [createPropertyEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) per animare l'opacità. [getFrom](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/propertyeffect/#getTo) e [getBy](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/propertyeffect/#getBy) sono stringhe interpretate tramite [getValueType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/propertyeffect/#getValueType) e [getCalcMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/propertyeffect/#getCalcMode). Scegli endpoint o una variazione relativa piuttosto che impostare tutti e tre indiscriminatamente.

Qui, l'attributo selezionato è l'opacità, e le stringhe numeriche rappresentano un passaggio dal 25 % di opacità all'opacità totale. L'interpolazione lineare descrive una variazione graduale tra quei valori. Quando adatti questo esempio a un'altra proprietà, scegli un tipo di valore e valori finali appropriati a quella proprietà.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Imposta**

Usa [createSetEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) per assegnare la visibilità tramite [getTo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/seteffect/#getTo). Un comportamento di tipo set non interpola tra gli endpoint.

L'esempio seleziona l'attributo visibilità e assegna la stringa `visible` quando il comportamento viene eseguito. Il rettangolo è già visibile in questa presentazione minima, quindi l'assegnazione potrebbe non produrre un cambiamento visivo evidente da sola. Un'operazione del genere è utile come parte di un effetto più ampio che controlla anche quando la forma diventa nascosta o visibile.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Comando**

Usa [createCommandEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) e configura [getType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/commandeffect/#getCommandString) e [getShapeTarget](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/commandeffect/#getShapeTarget). Posiziona una registrazione WAV chiamata `sample.wav` nella directory di lavoro. Questo esempio la incorpora con [addAudioFrameEmbedded](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) e associa un comando di riproduzione al frame audio.

Il frame audio è sia il bersaglio dell'effetto sia il bersaglio del comando. Questo collega la richiesta di riproduzione alla registrazione incorporata; una stringa di comando da sola non identifica l'oggetto multimediale da controllare. L'effetto è configurato per avviarsi con un clic durante la presentazione.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

Il salvataggio memorizza il comando in `command.pptx`; non riproduce la registrazione. La riproduzione richiede un lettore di diapositive che supporti il comando e il relativo media target.

## **Gestire la Collezione di Comportamenti**

[BehaviorCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorcollection/) supporta [add](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorcollection/#remove) e [removeAt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorcollection/#removeAt). Questo esempio apre `rotation.pptx`, aggiunge una scala, la sposta prima della rotazione e rimuove la rotazione. Rimuovere e reinserire lo stesso oggetto ne cambia la posizione memorizzata senza crearne una copia.

La sequenza di modifiche trasforma la collezione da rotazione–scala a scala–rotazione, poi a sola scala. Gli indici si riferiscono alla collezione corrente, quindi la rimozione usa il nuovo indice della rotazione dopo il riordino. L'enumerazione finale conferma quale comportamento verrà salvato.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'output è `ScaleEffect`: rimane solo il ridimensionamento. L'ordine della collezione non programma, di per sé, i comportamenti uno dopo l'altro. Svuota la collezione solo quando sostituisci tutte le sue operazioni.

## **Configurare la Temporizzazione dei Comportamenti**

[Behavior.getTiming](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behavior/#getTiming) espone [Timing](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/), indipendentemente da [Effect.getTiming](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#getTiming). La temporizzazione dell'effetto programma l'effetto contenitore; la temporizzazione del comportamento descrive un'operazione al suo interno.

### **Impostare Durata, Ritardo, Ripetizione e Accelerazione**

Apri `rotation.pptx` e imposta la durata ([getDuration](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getDuration)) e il ritardo di attivazione ([getTriggerDelayTime](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) in secondi, quindi configura il conteggio delle ripetizioni tramite [setRepeatCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getAccelerate) e [getDecelerate](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getDecelerate) sono frazioni della durata; mantieni la loro somma al massimo pari a 1.

Il file di input è quello creato nell'esempio di rotazione, dove il primo comportamento è noto per essere una rotazione. Questo esempio modifica solo la temporizzazione di quel comportamento; il suo angolo di 90 gradi rimane intatto. Tenere separati angolo e temporizzazione rende più semplice regolare il ritmo senza ricostruire l'animazione.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il comportamento usa una durata di due secondi, un ritardo di mezzo secondo e un conteggio di ripetizione pari a 3. Il primo e l'ultimo 20 % della durata sono usati per accelerazione e decelerazione.

Altre politiche di ripetizione includono [getRepeatDuration](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) e [getRepeatUntilNextClick](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); scegli una politica invece di abilitarle tutte insieme. [getAutoReverse](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getAutoReverse) riproduce l'animazione al contrario dopo la fase in avanti. Accelerazione e decelerazione si applicano a cambiamenti continui, non a assegnazioni discrete o comandi.

## **Creare un Percorso di Movimento**

Usa [createMotionEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) per creare un movimento. I suoi [getFrom](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motioneffect/#getTo) e [getBy](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motioneffect/#getBy) descrivono coordinate o offset basati su percentuali. Per una rotta modificabile, crea un [MotionPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motionpath/) e assegnalo con [MotionEffect.setPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motionpath/) memorizza i comandi del percorso.

[MotionCommandPathType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motioncommandpathtype/) seleziona l'operazione:

| Comando | Punti | Significato |
| --- | --- | --- |
| MoveTo | Uno | Imposta la posizione di partenza. |
| LineTo | Uno | Si sposta lungo un segmento rettilineo verso il suo punto finale. |
| CurveTo | Tre | Segue una curva cubica definita da due punti di controllo e un punto finale. |
| CloseLoop | Nessuno | Ritorna alla posizione di partenza. |
| End | Nessuno | Termina il percorso. |

[MotionPathPointsType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motionpathpointstype/) descrive le caratteristiche di modifica dei punti, ad esempio punti d'angolo o lisci. Non sostituisce il tipo di comando. Usa un tipo di punto curva per l'esempio di curva più sotto, e un tipo di punto angolo per i segmenti rettilinei.

Le coordinate del percorso sono normalizzate alle dimensioni della diapositiva: uno spostamento X di 0,25 rappresenta un quarto della larghezza della diapositiva, non 0,25 punti. Y positivo scorre verso il basso. I comandi assoluti specificano posizioni nel sistema di coordinate del percorso; i comandi relativi specificano offset dalla posizione corrente. Questo è separato da [getOrigin](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motioneffect/#getOrigin), che seleziona il frame di riferimento del percorso, e da [getPathEditMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motioneffect/#getPathEditMode), che controlla come il percorso si sposta quando la forma viene spostata.

### **Creare un Percorso Retto**

Crea un comportamento di movimento con un punto di partenza, un segmento rettilineo e un comando di fine. [MotionPath.add](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motionpath/#add) accetta il tipo di comando, i suoi punti, il tipo di punto e un flag di coordinate relative.

Il comando di partenza stabilisce (0, 0), e la linea termina in (0,25, 0), dando al percorso uno spostamento orizzontale di un quarto della larghezza della diapositiva. Il comando di fine non ha punti di coordinate. Una volta assegnato il percorso, aggiungere il comportamento di movimento all'effetto collega quel tracciato al rettangolo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` contiene un comportamento di movimento con tre comandi di percorso. Gli esempi di modifica file seguenti usano questa struttura nota.

### **Confrontare Coordinate Assolute e Relative**

Questi due oggetti percorso descrivono lo stesso tragitto. Il comando assoluto termina in (0,3, 0,1); il comando relativo aggiunge (0,1, 0,1) alla posizione corrente, (0,2, 0).

Entrambi i percorsi iniziano nella stessa posizione. Per la linea relativa, aggiungi i suoi offset X e Y alla posizione corrente per ottenere il punto finale; per la linea assoluta, leggi direttamente il punto finale. Cambiare il flag senza convertire le coordinate descriverebbe un percorso diverso.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

Assegna uno dei due percorsi a un comportamento di movimento per usarlo in una presentazione. L'ultimo argomento booleano seleziona coordinate relative per quel comando.

### **Sostituire una Linea con una Curva**

Apri `motion.pptx` e sostituisci il suo comando di linea con una curva cubica. Fornisci prima i due punti di controllo, seguiti dal punto finale.

La posizione di partenza è fornita dal comando precedente. I primi due punti modellano la curva, mentre il terzo è la sua destinazione; non sono tre destinazioni successive. Aggiornare contemporaneamente il tipo di comando, il tipo di editing dei punti e l'array dei punti mantiene il segmento coerente con la nuova geometria.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il percorso in `curve.pptx` ha ancora tre comandi; il suo comando intermedio ora definisce una curva.

## **Ispezionare e Modificare un Percorso Salvato**

Ogni [MotionCmdPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motioncmdpath/) espone [getPoints](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motioncmdpath/#getPointsType) e [isRelative](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motioncmdpath/#isRelative). Gli esempi seguenti usano il percorso a tre comandi noto in `motion.pptx`. Per input arbitrari, individua l'effetto desiderato e verifica i tipi di comando e il numero di punti prima di modificare per indice.

### **Leggere Comandi e Coordinate**

Leggi il percorso senza modificarlo. I comandi End e CloseLoop non richiedono punti, quindi prevedi un array di punti nullo.

L'output associa ogni tipo di comando numerico al suo flag di coordinate relative prima di elencare i punti. Questo consente di distinguere un punto finale da un offset prima di modificare il percorso. Una curva elencherebbe tre punti, mentre la linea retta in questo file ne elenca solo uno.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

L'elenco contiene un punto di partenza, una linea assoluta che termina in (0,25, 0) e un comando End.

### **Modificare un Punto Finale**

Apri `motion.pptx` e sostituisci l'array di punti della linea per spostare il suo punto finale.

Nel file di input, l'indice 0 è il comando di partenza e l'indice 1 è la linea. Sostituire il singolo punto della linea ne cambia la destinazione senza alterare il tipo di comando, la temporizzazione o la posizione nella collezione. Poiché il comando usa coordinate assolute, la nuova coppia specifica una posizione anziché un offset aggiunto.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La linea in `motion-endpoint.pptx` termina in (0,4, 0,1); il file originale rimane invariato.

### **Sostituire un Segmento**

Usa [insert](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motionpath/#insert) e [removeAt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/motionpath/#removeAt) per sostituire la linea in `motion.pptx`. L'inserimento sposta la vecchia linea all'indice 2.

Questo dimostra la sostituzione di un oggetto comando piuttosto che la modifica delle sue coordinate esistenti. Dopo l'inserimento, la collezione contiene temporaneamente il comando di partenza, la nuova linea, la vecchia linea e il comando End. Rimuovendo l'indice 2 si elimina la vecchia linea e si lascia al suo posto il nuovo percorso.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il percorso salvato ha ancora tre comandi, con la nuova linea che termina in (0,2, 0,1) e il comando End alla fine.

## **Modificare e Verificare un Comportamento Esistente**

Quando l'indice del comportamento è sconosciuto, selezionalo per tipo. Questo esempio apre `rotation.pptx`, trova il suo [RotationEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/rotationeffect/), cambia l'angolo e controlla il valore salvato dopo la riapertura.

Il controllo del tipo consente al ciclo di saltare i comportamenti che non sono rotazioni. Il secondo caricamento legge il file salvato in un oggetto presentazione separato, così il confronto verifica i dati persistiti invece del valore ancora in memoria. Questo esempio presuppone ancora che l'effetto noto sia il primo nella sequenza principale; selezionare un comportamento per tipo non individua l'effetto corretto in una presentazione arbitraria.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

L'output è `Rotation preserved: true`. Applica lo stesso modello di controllo per tipo ad altri comportamenti. Per un controllo di preservazione completo, confronta la forma di destinazione, l'effetto, i tipi e l'ordine dei comportamenti, la temporizzazione e i comandi del percorso. Usa una tolleranza numerica per i valori in virgola mobile. Per una presentazione con layout di animazione sconosciuto, vedi [Leggi le Animazioni delle Forme](/slides/it/nodejs-java/shape-animation/#read-shape-animations) per l'attraversamento delle sequenze principali e interattive.

## **Ordine dei Comportamenti, Preset e Riproduzione**

L'ordine in [BehaviorCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behaviorcollection/) è l'ordine memorizzato delle operazioni di un effetto. Non è una playlist in cui ogni comportamento attende automaticamente il precedente. La temporizzazione e l'effetto contenitore determinano la programmazione. I comportamenti possono sovrapporsi, e le operazioni sulla stessa proprietà possono interagire tramite [getAdditive](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behavior/#getAdditive) e [getAccumulate](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behavior/#getAccumulate). Non usare il solo riordino della collezione per programmare “sposta, poi ruota”; usa temporizzazioni esplicite o effetti separati come descritto in [Animazione Forma](/slides/it/nodejs-java/shape-animation/).

Il [getType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#getType) e il [getSubtype](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#getSubtype) dell'effetto descrivono il suo preset. Non sono una descrizione completa di un albero di comportamenti modificato. Scegli il preset e il sottotipo prima di personalizzare i comportamenti: cambiare il preset può ricostruire la collezione e scartare le tue operazioni personalizzate. Ad esempio, cambiare un effetto Spin personalizzato in Fade può sostituire il comportamento di rotazione con comportamenti set e filter. Ispeziona nuovamente la collezione dopo aver cambiato un preset o sottotipo. Svuotare i comportamenti del preset può anche rimuovere operazioni di visibilità o inizializzazione di cui il preset ha bisogno. Gli esempi usano intenzionalmente forme visibili e sostituiscono i comportamenti; non ricostruiscono l'implementazione completa di ogni preset.

## **Compatibilità di Formato**

Un albero di comportamenti preservato non garantisce una riproduzione identica in ogni visualizzatore o motore di esportazione. Verifica separatamente i dati salvati e l'output renderizzato.

| Formato o output | Cosa verificare |
| --- | --- |
| PPTX | Usalo come formato principale per questi esempi. Riaprilo per verificare l'albero di comportamenti modificabile, poi controlla la riproduzione nella versione PowerPoint desiderata. |
| PPT | La rappresentazione binaria legacy può differire da PPTX. Testa un ciclo separato di salvataggio‑riapertura e riproduzione; non inferire il supporto per ogni combinazione personalizzata dal solo output PPTX riuscito. |
| PDF, PNG, JPEG e altre immagini statiche di diapositive | Contengono una rappresentazione statica della diapositiva, non una timeline di comportamenti riproducibili né un frame finale garantito dell'animazione. |
| [HTML5](/slides/it/nodejs-java/export-to-html5/) | Può riprodurre le animazioni supportate quando l'animazione forma è abilitata nelle opzioni di esportazione. Testa combinazioni personalizzate nel browser. |
| [GIF Animato](/slides/it/nodejs-java/convert-powerpoint-to-animated-gif/) | Memorizza i fotogrammi renderizzati, non i comportamenti modificabili o le interazioni attivate da click. Controlla il movimento effettivamente renderizzato. |
| [Video](/slides/it/nodejs-java/convert-powerpoint-to-video/) | Renderizza i fotogrammi di animazione e li codifica come video. Il supporto è limitato alle [animazioni ed effetti supportati](/slides/it/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) dal renderer; comandi ed eventi interattivi non diventano una timeline modificabile. |

## **FAQ**

**Perché il mio effetto contiene comportamenti prima di aggiungerne alcuno?**

La creazione di un effetto predefinito può generare le operazioni sottostanti. Ispezionale prima di decidere se estendere il preset o sostituirne i comportamenti.

**Spostare un comportamento all'inizio lo fa riprodurre per primo?**

Non necessariamente. L'ordine della collezione non sostituisce la temporizzazione. Controlla ritardi, durate e interazioni tra operazioni sulla stessa proprietà.

**Perché un comando End non ha punti?**

Segna la fine del percorso e non necessita di coordinate. Verifica la presenza di un array di punti nullo quando ispezioni un percorso letto da un file.

**Un ciclo completo di salvataggio‑riapertura è sufficiente a confermare la riproduzione?**

No. Riaprire conferma la conservazione delle proprietà controllate. Testa separatamente il lettore di diapositive o l'esportazione animata per confermare il comportamento visivo.