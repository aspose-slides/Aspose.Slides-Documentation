---
title: Crea e modifica comportamenti di animazione personalizzati in Java
linktitle: Animazione personalizzata
type: docs
weight: 151
url: /it/java/custom-animation/
keywords:
- animazione personalizzata
- comportamento di animazione
- percorso di movimento
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Crea, ispeziona e modifica comportamenti di animazione personalizzati e percorsi di movimento modificabili nelle presentazioni PowerPoint con Aspose.Slides per Java."
---
## **Panoramica**

I comportamenti di animazione personalizzati ti consentono di controllare operazioni individuali all'interno di un effetto di animazione, ad esempio modificare un colore, ruotare una forma o seguire un percorso di movimento modificabile. Questa guida mostra come creare e combinare comportamenti, configurare il loro timing, ispezionare e modificare le animazioni esistenti e verificare che le loro proprietà sopravvivano al salvataggio e alla riapertura di una presentazione.

Per effetti predefiniti e trigger di clic, vedi [Animazione della Forma](/slides/it/java/shape-animation/).

## **Comprendere il modello di animazione**

Un'animazione è organizzata come **Timeline → Sequence → Effect → Behaviors**:

- Il metodo [getTimeline](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseslide/#getTimeline--) restituisce la timeline della diapositiva, che contiene la sua sequenza principale e le sequenze interattive.
- Un [ISequence](https://reference.aspose.com/slides/it/java/com.aspose.slides/isequence/) contiene effetti, potenzialmente riferiti a forme diverse.
- Un [IEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/) identifica la forma target, il preset, il sottotipo e il timing dell'effetto.
- La raccolta restituita da [IEffect.getBehaviors](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#getBehaviors--) contiene le operazioni che implementano l'effetto: cambio di colore, spostamento, rotazione, impostazione di una proprietà e così via.

## **Creare comportamenti individuali**

Chiama [ISequence.addEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) per creare un effetto e accedere alla raccolta [getBehaviors](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#getBehaviors--). Un preset può popolare questa raccolta automaticamente. Mantieni le sue operazioni quando estendi il preset, oppure usa [clear](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorcollection/#clear--) quando le sostituisci deliberatamente.

[IBehaviorFactory](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorfactory/) crea gli otto tipi di comportamento illustrati di seguito. Il movimento è trattato in [Crea un percorso di movimento](#build-a-motion-path). Ogni frammento include le importazioni; inserisci le istruzioni eseguibili all'interno di un metodo. Gli esempi di modifica successivi indicano quale file di output utilizzano.

### **Rotazione**

Usa [createRotationEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) per creare una rotazione. [getBy](https://reference.aspose.com/slides/it/java/com.aspose.slides/irotationeffect/#getBy--) specifica un angolo relativo in gradi; [getFrom](https://reference.aspose.com/slides/it/java/com.aspose.slides/irotationeffect/#getFrom--) e [getTo](https://reference.aspose.com/slides/it/java/com.aspose.slides/irotationeffect/#getTo--) specificano i punti finali.

L'esempio inizia con un effetto Spin, sostituisce le operazioni del preset con un comportamento di rotazione e assegna a quell'operazione una durata di due secondi. Un angolo relativo di 90 gradi rappresenta un quarto di giro rispetto all'orientamento iniziale della forma, quindi non è necessario specificare un angolo iniziale esplicito.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` contiene una forma e un comportamento di rotazione. La raccolta, il timing e gli esempi di modifica della rotazione sotto utilizzano questo file.

### **Scala**

Usa [createScaleEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) con percentuali X/Y: [getFrom](https://reference.aspose.com/slides/it/java/com.aspose.slides/iscaleeffect/#getFrom--) e [getTo](https://reference.aspose.com/slides/it/java/com.aspose.slides/iscaleeffect/#getTo--) descrivono la dimensione iniziale e finale, mentre [getBy](https://reference.aspose.com/slides/it/java/com.aspose.slides/iscaleeffect/#getBy--) descrive una variazione relativa. Qui, 100 indica la dimensione originale.

L'esempio aumenta entrambe le dimensioni dal 100 % al 125 % in due secondi. Usare percentuali uguali per orizzontale e verticale mantiene le proporzioni della forma; percentuali diverse allungherebbero una dimensione più dell'altra.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Colore**

Usa [createColorEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) per cambiare il riempimento da blu a arancione. [getFrom](https://reference.aspose.com/slides/it/java/com.aspose.slides/icoloreffect/#getFrom--) e [getTo](https://reference.aspose.com/slides/it/java/com.aspose.slides/icoloreffect/#getTo--) sono colori; [getBy](https://reference.aspose.com/slides/it/java/com.aspose.slides/icoloreffect/#getBy--) è una deviazione di colore. [IBehavior.getProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehavior/#getProperties--) identifica l'attributo animato.

Il riempimento solido della forma è inizializzato a blu, corrispondente al colore iniziale dell'animazione. Selezionare l'attributo fill-color indica al comportamento quale parte della forma modificare; i soli estremi di colore non identificano quell'attributo. L'effetto salvato descrive una transizione di due secondi verso l'arancione.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filtro**

Usa [createFilterEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) per selezionare una tendina. [getType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifiltereffect/#getSubtype--), e [getReveal](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifiltereffect/#getReveal--) specificano il filtro, la direzione e se rivelare o nascondere la forma.

Questo esempio configura una tendina di due secondi che rivela la forma usando il sottotipo di direzione destra. Le impostazioni del filtro appartengono al comportamento all'interno dell'effetto, quindi vengono configurate dopo che le operazioni originali del preset sono state rimosse.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Proprietà**

Usa [createPropertyEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) per animare l'opacità. [getFrom](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipropertyeffect/#getTo--), e [getBy](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipropertyeffect/#getBy--) sono stringhe interpretate tramite [getValueType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipropertyeffect/#getValueType--) e [getCalcMode](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipropertyeffect/#getCalcMode--). Scegli gli estremi o una deviazione relativa invece di impostare tutti e tre indiscriminatamente.

Qui, l'attributo selezionato è opacità, e le stringhe numeriche rappresentano un cambiamento dal 25 % di opacità all'opacità completa. L'interpolazione lineare descrive una variazione graduale tra quei valori. Quando adatti questo esempio a un altro attributo, scegli un tipo di valore e valori finali appropriati all'attributo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Imposta**

Usa [createSetEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) per assegnare la visibilità tramite [getTo](https://reference.aspose.com/slides/it/java/com.aspose.slides/iseteffect/#getTo--). Un comportamento di tipo set non interpola tra gli estremi.

L'esempio seleziona l'attributo visibilità e assegna la stringa `visible` quando il comportamento viene eseguito. Il rettangolo è già visibile in questa presentazione minimale, quindi l'assegnazione potrebbe non produrre un cambiamento visivo evidente da sola. Un'operazione di questo tipo è utile come parte di un effetto più ampio che controlla anche quando la forma diventa nascosta o visibile.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Comando**

Usa [createCommandEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) e configura [getType](https://reference.aspose.com/slides/it/java/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/it/java/com.aspose.slides/icommandeffect/#getCommandString--), e [getShapeTarget](https://reference.aspose.com/slides/it/java/com.aspose.slides/icommandeffect/#getShapeTarget--). Posiziona una registrazione WAV denominata `sample.wav` nella directory di lavoro. Questo esempio la incorpora con [addAudioFrameEmbedded](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) e collega un comando di riproduzione al fotogramma audio.

Il fotogramma audio è sia il target dell'effetto sia il target del comando. Questo collega la richiesta di riproduzione alla registrazione incorporata; una stringa di comando da sola non identifica quale oggetto multimediale controllare. L'effetto è configurato per iniziare con un clic durante la presentazione.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

Il salvataggio memorizza il comando in `command.pptx`; non riproduce la registrazione. La riproduzione richiede un lettore di presentazioni che supporti il comando e il suo target multimediale.

## **Gestire la raccolta di comportamenti**

[IBehaviorCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorcollection/) supporta [add](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), e [removeAt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Questo esempio apre `rotation.pptx`, aggiunge una scala, la sposta prima della rotazione e rimuove la rotazione. Rimuovere e reinserire lo stesso oggetto cambia la sua posizione memorizzata senza crearne una copia.

La sequenza di modifiche trasforma la raccolta da rotazione–scala a scala–rotazione, poi a sola scala. Gli indici si riferiscono alla raccolta corrente, quindi la rimozione utilizza il nuovo indice della rotazione dopo il riordino. L'enumerazione finale conferma quale comportamento sarà salvato.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'output è `ScaleEffect`: rimane solo la scala. L'ordine della raccolta non programma, di per sé, i comportamenti uno dopo l'altro. Svuota la raccolta solo quando sostituisci tutte le sue operazioni.

## **Configurare il timing del comportamento**

[IBehavior.getTiming](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehavior/#getTiming--) espone [ITiming](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/), indipendentemente da [IEffect.getTiming](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#getTiming--). Il timing dell'effetto programma l'effetto contenitore; il timing del comportamento descrive un'operazione al suo interno.

### **Impostare durata, ritardo, ripetizione e accelerazione**

Apri `rotation.pptx` e imposta la durata ([getDuration](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#getDuration--)) e il ritardo di trigger ([getTriggerDelayTime](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) in secondi, poi configura il conteggio delle ripetizioni tramite [setRepeatCount](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#getAccelerate--) e [getDecelerate](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#getDecelerate--) sono frazioni della durata; mantieni la loro somma al massimo 1.

Il file di input è quello creato nell'esempio di rotazione, dove il primo comportamento è noto per essere una rotazione. Questo esempio modifica solo il timing di quel comportamento; il suo angolo di 90 gradi rimane intatto. Tenere separati angolo e timing facilita la regolazione del ritmo senza ricostruire l'animazione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il comportamento utilizza una durata di due secondi, un ritardo di mezzo secondo e un conteggio di ripetizioni pari a 3. Il primo e l'ultimo 20 % della durata sono usati per accelerazione e decelerazione.

Altre politiche di ripetizione includono [getRepeatDuration](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), e [getRepeatUntilNextClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--); scegli una politica invece di abilitarle tutte insieme. [getAutoReverse](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#getAutoReverse--) riproduce l'animazione al contrario dopo il passaggio in avanti. Accelerazione e decelerazione si applicano a variazioni continue, non a assegnazioni discrete o comandi.

## **Crea un percorso di movimento**

Usa [createMotionEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) per creare il movimento. I suoi [getFrom](https://reference.aspose.com/slides/it/java/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/it/java/com.aspose.slides/imotioneffect/#getTo--), e [getBy](https://reference.aspose.com/slides/it/java/com.aspose.slides/imotioneffect/#getBy--) descrivono coordinate basate su percentuali o offset. Per una rotta modificabile, crea un [MotionPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/motionpath/) e assegnalo con [IMotionEffect.setPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/imotionpath/) memorizza i comandi del percorso.

[MotionCommandPathType](https://reference.aspose.com/slides/it/java/com.aspose.slides/motioncommandpathtype/) seleziona l'operazione:

| Comando | Punti | Significato |
| --- | --- | --- |
| MoveTo | Uno | Imposta la posizione di partenza. |
| LineTo | Uno | Si sposta lungo un segmento rettilineo verso il suo punto finale. |
| CurveTo | Tre | Segue una curva cubica definita da due punti di controllo e un punto finale. |
| CloseLoop | Nessuno | Ritorna alla posizione di partenza. |
| End | Nessuno | Conclude il percorso. |

[MotionPathPointsType](https://reference.aspose.com/slides/it/java/com.aspose.slides/motionpathpointstype/) descrive le caratteristiche di modifica dei punti, come angolo o punti lisci. Non sostituisce il tipo di comando. Usa un tipo di punto curva per l'esempio di curva sotto e un tipo di punto angolo per i segmenti rettilinei.

Le coordinate del percorso sono normalizzate alle dimensioni della diapositiva: uno spostamento X di 0,25 rappresenta un quarto della larghezza della diapositiva, non 0,25 punti. Y positivo scorre verso il basso. I comandi assoluti specificano posizioni nel sistema di coordinate del percorso; i comandi relativi specificano offset dalla posizione corrente. Questo è separato da [getOrigin](https://reference.aspose.com/slides/it/java/com.aspose.slides/imotioneffect/#getOrigin--), che seleziona il riferimento del percorso, e da [getPathEditMode](https://reference.aspose.com/slides/it/java/com.aspose.slides/imotioneffect/#getPathEditMode--), che controlla come il percorso si muove quando la forma viene spostata.

### **Crea un percorso rettilineo**

Crea un comportamento di movimento con un punto di partenza, un segmento rettilineo e un comando di fine. [IMotionPath.add](https://reference.aspose.com/slides/it/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) accetta il tipo di comando, i suoi punti, il tipo di punto e un flag di coordinate relative.

Il comando di partenza stabilisce (0, 0), e la linea termina a (0,25, 0), dando al percorso uno spostamento orizzontale di un quarto della larghezza della diapositiva. Il comando di fine non ha punti di coordinate. Una volta assegnato il percorso, aggiungere il comportamento di movimento all'effetto collega tale rotta al rettangolo.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` contiene un comportamento di movimento con tre comandi di percorso. Gli esempi di modifica dei file seguenti utilizzano questa struttura nota.

### **Confronta coordinate assolute e relative**

Questi due oggetti percorso descrivono la stessa rotta. Il comando assoluto termina a (0,3, 0,1); il comando relativo aggiunge (0,1, 0,1) alla posizione corrente, (0,2, 0).

Entrambi i percorsi partono dalla stessa posizione. Per la linea relativa, aggiungi i suoi offset X e Y alla posizione corrente per ottenere il punto finale; per la linea assoluta, leggi direttamente il punto finale. Cambiare il flag senza convertire le coordinate descriverebbe una rotta diversa.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Assegna uno dei percorsi a un comportamento di movimento per usarlo in una presentazione. L'ultimo argomento booleano seleziona coordinate relative per quel comando.

### **Sostituisci una linea con una curva**

Apri `motion.pptx` e sostituisci il suo comando linea con una curva cubica. Fornisci prima i due punti di controllo, seguiti dal punto finale.

La posizione di partenza è fornita dal comando precedente. I primi due punti modellano la curva, mentre il terzo è la destinazione; non sono tre destinazioni successive. Aggiornare contemporaneamente il tipo di comando, il tipo di modifica dei punti e l'array di punti mantiene il segmento coerente con la nuova geometria.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il percorso in `curve.pptx` ha ancora tre comandi; il suo comando intermedio ora definisce una curva.

## **Ispezionare e modificare un percorso salvato**

Ogni [IMotionCmdPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/imotioncmdpath/) espone [getPoints](https://reference.aspose.com/slides/it/java/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/it/java/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/it/java/com.aspose.slides/imotioncmdpath/#getPointsType--), e [isRelative](https://reference.aspose.com/slides/it/java/com.aspose.slides/imotioncmdpath/#isRelative--). Gli esempi seguenti usano il percorso a tre comandi noto in `motion.pptx`. Per input arbitrari, individua l'effetto desiderato e verifica i tipi di comando e il numero di punti prima di modificare per indice.

### **Leggere comandi e coordinate**

Leggi il percorso senza modificarlo. I comandi End e CloseLoop non richiedono punti, quindi ammetti un array di punti nullo.

L'output associa ogni tipo di comando numerico al suo flag di coordinate relative prima di elencare i punti. Questo ti consente di distinguere un punto finale da un offset prima di modificare il percorso. Una curva elencherebbe tre punti, mentre la linea rettilinea in questo file ne elenca solo uno.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

L'elenco contiene un punto di partenza, una linea assoluta che termina a (0,25, 0) e un comando End.

### **Modificare un punto finale**

Apri `motion.pptx` e sostituisci l'array di punti della linea per spostare il suo punto finale.

Nel file di input, l'indice 0 è il comando di partenza e l'indice 1 è la linea. Sostituire il singolo punto della linea ne cambia la destinazione senza alterare il tipo di comando, il timing o la posizione nella raccolta. Poiché il comando usa coordinate assolute, la nuova coppia specifica una posizione piuttosto che un offset aggiunto.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La linea in `motion-endpoint.pptx` termina a (0,4, 0,1); il file originale rimane invariato.

### **Sostituire un segmento**

Usa [insert](https://reference.aspose.com/slides/it/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) e [removeAt](https://reference.aspose.com/slides/it/java/com.aspose.slides/imotionpath/#removeAt-int-) per sostituire la linea in `motion.pptx`. L'inserimento sposta la vecchia linea all'indice 2.

Questo dimostra la sostituzione di un oggetto comando anziché la modifica delle sue coordinate esistenti. Dopo l'inserimento, la raccolta contiene temporaneamente il comando di partenza, la nuova linea, la vecchia linea e il comando End. Rimuovendo l'indice 2 si elimina la vecchia linea lasciando la nuova rotta al suo posto.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il percorso salvato ha ancora tre comandi, con la nuova linea che termina a (0,2, 0,1) e il comando End alla fine.

## **Modificare e verificare un comportamento esistente**

Quando l'indice del comportamento è sconosciuto, selezionalo per tipo. Questo esempio apre `rotation.pptx`, trova il suo [IRotationEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/irotationeffect/), ne cambia l'angolo e controlla il valore salvato dopo la riapertura.

Il controllo del tipo consente al ciclo di saltare i comportamenti che non sono rotazioni. Il secondo caricamento legge il file salvato in un oggetto presentazione separato, così il confronto verifica i dati persistiti anziché il valore ancora in memoria. Questo esempio presuppone comunque che l'effetto noto sia il primo nella sequenza principale; selezionare un comportamento per tipo non individua l'effetto corretto in una presentazione arbitraria.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

L'output è `Rotation preserved: true`. Applica lo stesso schema di controllo per altri comportamenti. Per un controllo completo della preservazione, confronta la forma target, l'effetto, i tipi e l'ordine dei comportamenti, il timing e i comandi del percorso. Usa una tolleranza numerica per i valori a virgola mobile. Per una presentazione con una struttura di animazione sconosciuta, vedi [Leggi le animazioni delle forme](/slides/it/java/shape-animation/#read-shape-animations) per l'attraversamento delle sequenze principali e interattive.

## **Ordine dei comportamenti, preset e riproduzione**

L'ordine in [IBehaviorCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehaviorcollection/) è l'ordine memorizzato delle operazioni di un effetto. Non è una playlist in cui ogni comportamento attende automaticamente quello precedente. Il timing e l'effetto contenitore determinano la programmazione. I comportamenti possono sovrapporsi, e le operazioni sulla stessa proprietà possono interagire tramite [getAdditive](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehavior/#getAdditive--) e [getAccumulate](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibehavior/#getAccumulate--). Non usare solo il riordinamento della raccolta per programmare “sposta, poi ruota”; usa timing esplicito o effetti separati come descritto in [Animazione della Forma](/slides/it/java/shape-animation/).

Il [getType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#getType--) e il [getSubtype](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#getSubtype--) dell'effetto descrivono il suo preset. Non costituiscono una descrizione completa di un albero di comportamenti modificato. Scegli il preset e il sottotipo prima di personalizzare i comportamenti: cambiare il preset può ricostruire la raccolta e scartare le tue operazioni personalizzate. Ad esempio, trasformare un effetto Spin personalizzato in Fade può sostituire il comportamento di rotazione con comportamenti set e filter. Ispeziona nuovamente la raccolta dopo aver cambiato preset o sottotipo. Svuotare i comportamenti del preset può anche rimuovere operazioni di visibilità o di inizializzazione di cui il preset ha bisogno. Gli esempi usano deliberatamente forme visibili e sostituiscono i comportamenti; non ricostruiscono l'implementazione di ogni preset.

## **Compatibilità dei formati**

Un albero di comportamenti preservato non garantisce una riproduzione identica in tutti i visualizzatori o motori di esportazione. Verifica separatamente i dati salvati e l'output renderizzato.

| Formato o output | Cosa verificare |
| --- | --- |
| PPTX | Usalo come formato principale per questi esempi. Riaprilo per verificare l'albero di comportamenti modificabile, poi controlla la riproduzione nella versione di PowerPoint desiderata. |
| PPT | La rappresentazione binaria legacy può differire da PPTX. Esegui un ciclo di salvataggio‑riapertura separato e verifica la riproduzione; non inferire supporto per ogni combinazione personalizzata dal solo risultato PPTX. |
| PDF, PNG, JPEG e altre immagini statiche di diapositive | Contengono una rappresentazione statica della diapositiva, non una timeline di comportamenti riproducibile né un frame finale di animazione garantito. |
| [HTML5](/slides/it/java/export-to-html5/) | Può riprodurre le animazioni supportate quando l'animazione di forma è abilitata nelle opzioni di esportazione. Testa combinazioni personalizzate nel browser. |
| [GIF animato](/slides/it/java/convert-powerpoint-to-animated-gif/) | Memorizza i frame renderizzati, non i comportamenti modificabili o le interazioni attivate da clic. Controlla il movimento effettivamente renderizzato. |
| [Video](/slides/it/java/convert-powerpoint-to-video/) | Renderizza i frame dell'animazione e li codifica come video. Il supporto è limitato alle [animazioni ed effetti supportati](/slides/it/java/convert-powerpoint-to-video/#supported-animations-and-effects); i comandi e gli eventi interattivi non diventano una timeline modificabile. |

## **FAQ**

**Perché il mio effetto contiene comportamenti prima di aggiungerne alcuno?**

La creazione di un effetto predefinito può generare le sue operazioni sottostanti. Ispezionale prima di decidere se estendere il preset o sostituire i suoi comportamenti.

**Spostare un comportamento all'inizio lo fa riprodurre per primo?**

Non necessariamente. L'ordine della raccolta non sostituisce il timing. Controlla ritardi, durate e interazioni tra operazioni sulla stessa proprietà.

**Perché un comando End non ha punti?**

Segna la fine del percorso e non richiede coordinate. Controlla la presenza di un array di punti nullo quando ispezioni un percorso letto da un file.

**Un round‑trip riuscito è sufficiente per confermare la riproduzione?**

No. Riaprire conferma la conservazione delle proprietà controllate. Testa separatamente il lettore di presentazioni o l'esportazione animata per confermare il comportamento visivo.