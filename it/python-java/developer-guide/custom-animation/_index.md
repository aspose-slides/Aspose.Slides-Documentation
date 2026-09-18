---
title: Crea e modifica comportamenti di animazione personalizzati in Python tramite Java
linktitle: Animazione personalizzata
type: docs
weight: 151
url: /it/python-java/custom-animation/
keywords:
- animazione personalizzata
- comportamento di animazione
- percorso di movimento
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea, ispeziona e modifica i comportamenti di animazione personalizzati e i percorsi di movimento modificabili nelle presentazioni PowerPoint con Aspose.Slides per Python tramite Java."
---
## **Panoramica**

I comportamenti di animazione personalizzati consentono di controllare operazioni singole all'interno di un effetto di animazione, come cambiare colore, ruotare una forma o seguire un percorso di movimento modificabile. Questa guida mostra come creare e combinare comportamenti, configurare la loro temporizzazione, ispezionare e modificare le animazioni esistenti e verificare che le loro proprietà sopravvivano al salvataggio e alla riapertura di una presentazione.

Per effetti predefiniti e trigger di clic, vedere [Animazione della Forma](/slides/it/python-java/shape-animation/).

## **Comprendere il Modello di Animazione**

Un'animazione è organizzata come **Timeline → Sequence → Effect → Behaviors**:

- Il metodo [getTimeline](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#getTimeline) restituisce la timeline della diapositiva, che contiene la sua sequenza principale e le sequenze interattive.
- Una [Sequence](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/) contiene effetti, potenzialmente destinati a forme diverse.
- Un [Effect](https://reference.aspose.com/slides/it/python-java/aspose.slides/effect/) identifica una forma di destinazione, un preset, un sottotipo e la temporizzazione dell'effetto.
- La collezione restituita da [Effect.getBehaviors](https://reference.aspose.com/slides/it/python-java/aspose.slides/effect/#getBehaviors) contiene le operazioni che implementano l'effetto: cambiamento colore, spostamento, rotazione, impostazione di una proprietà, ecc.

## **Creare Comportamenti Individuali**

Chiamare [Sequence.addEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/#addEffect) per creare un effetto e accedere alla collezione [getBehaviors](https://reference.aspose.com/slides/it/python-java/aspose.slides/effect/#getBehaviors). Un preset può popolare automaticamente questa collezione. Conserva le sue operazioni quando estendi il preset, oppure usa [clear](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorcollection/#clear) quando le sostituisci intenzionalmente.

[BehaviorFactory](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorfactory/) crea gli otto tipi di comportamento illustrati di seguito. Il movimento è trattato in [Crea un Percorso di Movimento](#build-a-motion-path). Ogni frammento include le importazioni e avvia la JVM se necessario. Gli oggetti e gli array Java vengono creati tramite JPype dove l'API li richiede. Gli esempi di modifica successiva indicano quale file di output utilizzano.

### **Rotazione**

Usare [createRotationEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorfactory/#createRotationEffect) per creare una rotazione. [getBy](https://reference.aspose.com/slides/it/python-java/aspose.slides/rotationeffect/#getBy) specifica un angolo relativo in gradi; [getFrom](https://reference.aspose.com/slides/it/python-java/aspose.slides/rotationeffect/#getFrom) e [getTo](https://reference.aspose.com/slides/it/python-java/aspose.slides/rotationeffect/#getTo) specificano i punti finali.

L'esempio inizia con un effetto Spin, sostituisce le operazioni del preset con un comportamento di rotazione e assegna a quell'operazione una durata di due secondi. Un angolo relativo di 90 gradi esprime un quarto di giro rispetto all'orientamento iniziale della forma, quindi non è necessario specificare un angolo di partenza esplicito.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` contiene una forma e un comportamento di rotazione. La collezione, la temporizzazione e gli esempi di modifica della rotazione riportati di seguito usano questo file.

### **Scala**

Usare [createScaleEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorfactory/#createScaleEffect) con percentuali X/Y: [getFrom](https://reference.aspose.com/slides/it/python-java/aspose.slides/scaleeffect/#getFrom) e [getTo](https://reference.aspose.com/slides/it/python-java/aspose.slides/scaleeffect/#getTo) descrivono la dimensione iniziale e finale, mentre [getBy](https://reference.aspose.com/slides/it/python-java/aspose.slides/scaleeffect/#getBy) descrive una variazione relativa. Qui, 100 indica la dimensione originale.

L'esempio aumenta entrambe le dimensioni dal 100 % al 125 % in due secondi. L'uso di percentuali orizzontali e verticali uguali mantiene le proporzioni della forma; percentuali diverse allungherebbero una dimensione più dell'altra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Colore**

Usare [createColorEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorfactory/#createColorEffect) per cambiare il riempimento da blu a arancione. [getFrom](https://reference.aspose.com/slides/it/python-java/aspose.slides/coloreffect/#getFrom) e [getTo](https://reference.aspose.com/slides/it/python-java/aspose.slides/coloreffect/#getTo) sono colori; [getBy](https://reference.aspose.com/slides/it/python-java/aspose.slides/coloreffect/#getBy) è una variazione di colore. [Behavior.getProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/behavior/#getProperties) identifica l'attributo animato.

Il riempimento solido della forma è inizializzato a blu, corrispondente al colore di partenza dell'animazione. Selezionare l'attributo fill-color indica al comportamento quale parte della forma modificare; i soli colori finali non identificano quell'attributo. L'effetto salvato descrive una transizione di due secondi verso l'arancione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Filtro**

Usare [createFilterEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorfactory/#createFilterEffect) per selezionare un wipe. [getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/it/python-java/aspose.slides/filtereffect/#getSubtype) e [getReveal](https://reference.aspose.com/slides/it/python-java/aspose.slides/filtereffect/#getReveal) specificano il filtro, la direzione e se rivelare o nascondere la forma.

Questo esempio configura un wipe di due secondi che rivela la forma usando il sottotipo di direzione a destra. Le impostazioni del filtro appartengono al comportamento all'interno dell'effetto, quindi vengono configurate dopo aver rimosso le operazioni originali del preset.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Proprietà**

Usare [createPropertyEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) per animare l'opacità. [getFrom](https://reference.aspose.com/slides/it/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/it/python-java/aspose.slides/propertyeffect/#getTo) e [getBy](https://reference.aspose.com/slides/it/python-java/aspose.slides/propertyeffect/#getBy) sono stringhe interpretate tramite [getValueType](https://reference.aspose.com/slides/it/python-java/aspose.slides/propertyeffect/#getValueType) e [getCalcMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/propertyeffect/#getCalcMode). Scegliere punti finali o una variazione relativa anziché impostare tutti e tre indiscriminatamente.

Qui, l'attributo selezionato è opacità, e le stringhe numeriche rappresentano una variazione dal 25 % di opacità a opacità piena. L'interpolazione lineare descrive una variazione graduale tra questi valori. Quando si adatta questo esempio a un'altra proprietà, scegliere un tipo di valore e valori finali appropriati a quella proprietà.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Imposta**

Usare [createSetEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorfactory/#createSetEffect) per assegnare la visibilità tramite [getTo](https://reference.aspose.com/slides/it/python-java/aspose.slides/seteffect/#getTo). Un comportamento di tipo set non interpola tra i punti finali.

L'esempio seleziona l'attributo di visibilità e assegna la stringa `visible` quando il comportamento viene eseguito. Il rettangolo è già visibile in questa presentazione minimale, quindi l'assegnazione potrebbe non produrre un cambiamento visivo evidente da sola. Un'operazione di questo tipo è utile come parte di un effetto più ampio che controlla anche quando la forma diventa nascosta o visibile.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Comando**

Usare [createCommandEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorfactory/#createCommandEffect) e configurare [getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/it/python-java/aspose.slides/commandeffect/#getCommandString) e [getShapeTarget](https://reference.aspose.com/slides/it/python-java/aspose.slides/commandeffect/#getShapeTarget). Posizionare una registrazione WAV denominata `sample.wav` nella cartella di lavoro. Questo esempio la incorpora con [addAudioFrameEmbedded](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) e collega un comando di riproduzione al frame audio.

Il frame audio è sia il target dell'effetto sia il target del comando. Ciò collega la richiesta di riproduzione alla registrazione incorporata; una stringa di comando da sola non identifica quale oggetto multimediale controllare. L'effetto è configurato per avviarsi con un clic durante la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il salvataggio conserva il comando in `command.pptx`; non riproduce la registrazione. La riproduzione richiede un lettore di presentazioni che supporti il comando e il suo target multimediale.

## **Gestire la Collezione di Comportamenti**

[BehaviorCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorcollection/) supporta [add](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorcollection/#remove) e [removeAt](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorcollection/#removeAt). Questo esempio apre `rotation.pptx`, aggiunge una scala, la sposta prima della rotazione e rimuove la rotazione. Rimuovere e reinserire lo stesso oggetto ne cambia la posizione memorizzata senza crearne una copia.

La sequenza di modifiche trasforma la collezione da rotazione–scala a scala–rotazione, poi solo scala. Gli indici si riferiscono alla collezione corrente, quindi la rimozione utilizza il nuovo indice della rotazione dopo il riordino. L'enumerazione finale conferma quale comportamento verrà salvato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L'output è `ScaleEffect`: rimane solo la scala. L'ordine della collezione non programma automaticamente i comportamenti uno dopo l'altro. Svuota la collezione solo quando sostituisci tutte le sue operazioni.

## **Configurare la Temporizzazione dei Comportamenti**

[Behavior.getTiming](https://reference.aspose.com/slides/it/python-java/aspose.slides/behavior/#getTiming) espone [Timing](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/), indipendentemente da [Effect.getTiming](https://reference.aspose.com/slides/it/python-java/aspose.slides/effect/#getTiming). La temporizzazione dell'effetto pianifica l'effetto contenitore; la temporizzazione del comportamento descrive un'operazione al suo interno.

### **Impostare Durata, Ritardo, Ripetizione e Accelerazione**

Aprire `rotation.pptx` e impostare la durata ([getDuration](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#getDuration)) e il ritardo di trigger ([getTriggerDelayTime](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#getTriggerDelayTime)) in secondi, quindi configurare il conteggio delle ripetizioni tramite [setRepeatCount](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#getAccelerate) e [getDecelerate](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#getDecelerate) sono frazioni della durata; mantenerne la somma al massimo 1.

Il file di input è quello creato nell'esempio di rotazione, dove il primo comportamento è noto per essere una rotazione. Questo esempio modifica solo la temporizzazione di quel comportamento; l'angolo di 90 gradi rimane intatto. Tenere separati angolo e temporizzazione facilita la regolazione del ritmo senza ricostruire l'animazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il comportamento utilizza una durata di due secondi, un ritardo di mezzo secondo e un conteggio di ripetizioni pari a 3. Il primo e l'ultimo 20 % della sua durata sono usati per accelerazione e decelerazione.

Altre politiche di ripetizione includono [getRepeatDuration](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) e [getRepeatUntilNextClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#getRepeatUntilNextClick); scegliere una politica anziché abilitarle tutte insieme. [getAutoReverse](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#getAutoReverse) riproduce l'animazione al contrario dopo il passaggio in avanti. Accelerazione e decelerazione si applicano a variazioni continue, non a assegnazioni o comandi discreti.

## **Creare un Percorso di Movimento**

Usare [createMotionEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorfactory/#createMotionEffect) per creare un movimento. I suoi [getFrom](https://reference.aspose.com/slides/it/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/it/python-java/aspose.slides/motioneffect/#getTo) e [getBy](https://reference.aspose.com/slides/it/python-java/aspose.slides/motioneffect/#getBy) descrivono coordinate o spostamenti basati su percentuali. Per un percorso modificabile, creare un [MotionPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/motionpath/) e assegnarlo con [MotionEffect.setPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/motionpath/) memorizza i comandi del percorso.

[MotionCommandPathType](https://reference.aspose.com/slides/it/python-java/aspose.slides/motioncommandpathtype/) seleziona l'operazione:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Imposta la posizione di partenza. |
| LineTo | One | Si sposta lungo un segmento rettilineo fino al suo punto finale. |
| CurveTo | Three | Segue una curva cubica definita da due punti di controllo e un punto finale. |
| CloseLoop | None | Ritorna alla posizione di partenza. |
| End | None | Conclude il percorso. |

[MotionPathPointsType](https://reference.aspose.com/slides/it/python-java/aspose.slides/motionpathpointstype/) descrive le caratteristiche di modifica dei punti, come punti angolo o lisci. Non sostituisce il tipo di comando. Usare un tipo di punto curva per l'esempio di curva qui sotto, e un tipo di punto angolo per i segmenti rettilinei.

Le coordinate del percorso sono normalizzate alle dimensioni della diapositiva: uno spostamento X di 0.25 rappresenta un quarto della larghezza della diapositiva, non 0.25 punti. Y positivo scorre verso il basso. I comandi assoluti specificano posizioni nel sistema di coordinate del percorso; i comandi relativi specificano spostamenti dalla posizione corrente. Questo è separato da [getOrigin](https://reference.aspose.com/slides/it/python-java/aspose.slides/motioneffect/#getOrigin), che seleziona il frame di riferimento del percorso, e da [getPathEditMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/motioneffect/#getPathEditMode), che controlla come il percorso si muove quando la forma viene spostata.

### **Creare un Percorso Rettilineo**

Creare un comportamento di movimento con un punto di partenza, un segmento rettilineo e un comando di fine. [MotionPath.add](https://reference.aspose.com/slides/it/python-java/aspose.slides/motionpath/#add) accetta il tipo di comando, i suoi punti, il tipo di punto e un flag di coordinate relative.

Il comando di partenza stabilisce (0, 0), e la linea termina in (0.25, 0), fornendo al percorso uno spostamento orizzontale di un quarto della larghezza della diapositiva. Il comando di fine non ha punti coordinati. Una volta assegnato il percorso, aggiungere il comportamento di movimento all'effetto collega quel percorso al rettangolo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` contiene un comportamento di movimento con tre comandi di percorso. Gli esempi di modifica del file riportati di seguito usano questa struttura nota.

### **Confrontare Coordinate Assolute e Relative**

Questi due oggetti percorso descrivono lo stesso itinerario. Il comando assoluto termina in (0.3, 0.1); il comando relativo aggiunge (0.1, 0.1) alla posizione corrente, (0.2, 0).

Entrambi i percorsi partono dalla stessa posizione. Per la linea relativa, aggiungere i suoi offset X e Y alla posizione corrente per ottenere il punto finale; per la linea assoluta, leggere direttamente il punto finale. Cambiare il flag senza convertire le coordinate descriverebbe un percorso diverso.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

Assegnare uno dei percorsi a un comportamento di movimento per usarlo in una presentazione. L'ultimo argomento booleano seleziona coordinate relative per quel comando.

### **Sostituire una Linea con una Curva**

Aprire `motion.pptx` e sostituire il suo comando linea con una curva cubica. Fornire prima i due punti di controllo, seguiti dal punto finale.

La posizione di partenza è fornita dal comando precedente. I primi due punti modellano la curva, mentre il terzo è la destinazione; non sono tre destinazioni successive. Aggiornare simultaneamente il tipo di comando, il tipo di modifica dei punti e l'array dei punti mantiene il segmento coerente con la nuova geometria.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il percorso in `curve.pptx` ha comunque tre comandi; il suo comando centrale ora definisce una curva.

## **Ispezionare e Modificare un Percorso Salvato**

Ogni [MotionCmdPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/motioncmdpath/) espone [getPoints](https://reference.aspose.com/slides/it/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/it/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/it/python-java/aspose.slides/motioncmdpath/#getPointsType) e [isRelative](https://reference.aspose.com/slides/it/python-java/aspose.slides/motioncmdpath/#isRelative). Gli esempi seguenti usano il percorso di tre comandi noto in `motion.pptx`. Per input arbitrario, individuare l'effetto desiderato e verificare i tipi di comando e il numero di punti prima di modificare per indice.

### **Leggere Comandi e Coordinate**

Leggere il percorso senza modificarlo. I comandi end e close-loop non richiedono punti, quindi gestire un array di punti nullo.

L'output associa ogni tipo di comando numerico al suo flag di coordinate relative prima di elencare i punti. Questo permette di distinguere un punto finale da uno spostamento prima di modificare il percorso. Una curva elencherebbe tre punti, mentre la linea retta in questo file ne elenca solo uno.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

L'elenco contiene un punto di partenza, una linea assoluta che termina in (0.25, 0) e un comando end.

### **Modificare un Punto Finale**

Aprire `motion.pptx` e sostituire l'array di punti della linea per spostarne il punto finale.

Nel file di input, l'indice 0 è il comando di partenza e l'indice 1 è la linea. Sostituire il singolo punto della linea cambia la destinazione senza alterare il tipo di comando, la temporizzazione o la posizione nella collezione. Poiché il comando utilizza coordinate assolute, la nuova coppia specifica una posizione piuttosto che uno spostamento aggiuntivo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La linea in `motion-endpoint.pptx` termina in (0.4, 0.1); il file originale rimane invariato.

### **Sostituire un Segmento**

Usare [insert](https://reference.aspose.com/slides/it/python-java/aspose.slides/motionpath/#insert) e [removeAt](https://reference.aspose.com/slides/it/python-java/aspose.slides/motionpath/#removeAt) per sostituire la linea in `motion.pptx`. L'inserimento sposta la vecchia linea all'indice 2.

Ciò dimostra la sostituzione di un oggetto comando anziché la modifica delle sue coordinate esistenti. Dopo l'inserimento, la collezione contiene temporaneamente il comando di partenza, la nuova linea, la vecchia linea e il comando end. Rimuovendo l'indice 2 si elimina la vecchia linea lasciando il nuovo percorso al suo posto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il percorso salvato ha ancora tre comandi, con la nuova linea che termina in (0.2, 0.1) e il comando end alla fine.

## **Modificare e Verificare un Comportamento Esistente**

Quando l'indice del comportamento è sconosciuto, selezionarlo per tipo. Questo esempio apre `rotation.pptx`, trova il suo [RotationEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/rotationeffect/), cambia l'angolo e controlla il valore salvato dopo la riapertura.

Il controllo del tipo consente al ciclo di saltare i comportamenti che non sono rotazioni. Il secondo caricamento legge il file salvato in un oggetto presentazione separato, così il confronto verifica i dati persistiti piuttosto che il valore ancora in memoria. Questo esempio presume ancora che l'effetto noto sia il primo nella sequenza principale; selezionare un comportamento per tipo non individua l'effetto corretto in una presentazione arbitraria.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

L'output è `Rotation preserved: True`. Applicare lo stesso schema di controllo per altri comportamenti. Per un controllo completo di conservazione, confrontare forma di destinazione, effetto, tipi e ordine dei comportamenti, temporizzazione e comandi del percorso. Utilizzare una tolleranza numerica per i valori a virgola mobile. Per una presentazione con layout di animazione sconosciuto, vedere [Leggere le Animazioni delle Forme](/slides/it/python-java/shape-animation/#read-shape-animations) per la traversata di sequenze principali e interattive.

## **Ordine dei Comportamenti, Preset e Riproduzione**

L'ordine in [BehaviorCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/behaviorcollection/) è l'ordine memorizzato delle operazioni di un effetto. Non è una playlist in cui ogni comportamento attende automaticamente quello precedente. Temporizzazione ed effetto contenitore determinano la programmazione. I comportamenti possono sovrapporsi, e le operazioni sulla stessa proprietà possono interagire tramite [getAdditive](https://reference.aspose.com/slides/it/python-java/aspose.slides/behavior/#getAdditive) e [getAccumulate](https://reference.aspose.com/slides/it/python-java/aspose.slides/behavior/#getAccumulate). Non usare solo il riordino della collezione per programmare “muovi, poi ruota”; usare temporizzazioni esplicite o effetti separati come descritto in [Animazione della Forma](/slides/it/python-java/shape-animation/).

Il [getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/effect/#getType) e il [getSubtype](https://reference.aspose.com/slides/it/python-java/aspose.slides/effect/#getSubtype) dell'effetto descrivono il suo preset. Non costituiscono una descrizione completa di un albero di comportamenti modificato. Scegliere il preset e il sottotipo prima di personalizzare i comportamenti: cambiare il preset può ricostruire la collezione e scartare le operazioni personalizzate. Per esempio, cambiare un effetto Spin personalizzato in Fade può sostituire il comportamento di rotazione con comportamenti di set e filter. Ispezionare nuovamente la collezione dopo aver cambiato un preset o sottotipo. Svuotare i comportamenti del preset può anche rimuovere operazioni di visibilità o di inizializzazione di cui il preset ha bisogno. Gli esempi usano volutamente forme visibili e sostituiscono i comportamenti; non ricostruiscono l'implementazione completa di ogni preset.

## **Compatibilità del Formato**

Un albero di comportamenti preservato non garantisce una riproduzione identica in ogni visualizzatore o motore di esportazione. Verificare separatamente i dati salvati e l'output renderizzato.

| Formato o output | Cosa verificare |
| --- | --- |
| PPTX | Usare come formato principale per questi esempi. Riaprire per verificare l'albero di comportamenti modificabile, poi controllare la riproduzione nella versione di PowerPoint destinata. |
| PPT | La rappresentazione binaria legacy può differire da PPTX. Eseguire un ciclo separato di salvataggio‑riapertura e riproduzione; non inferire supporto per ogni combinazione personalizzata dal solo output PPTX riuscito. |
| PDF, PNG, JPEG e altre immagini statiche delle diapositive | Contengono una rappresentazione statica della diapositiva, non una timeline di comportamenti riproducibile né un frame finale garantito dell'animazione. |
| [HTML5](/slides/it/python-java/export-to-html5/) | Può riprodurre le animazioni supportate quando l'animazione delle forme è abilitata nelle opzioni di esportazione. Testare le combinazioni personalizzate nel browser. |
| [GIF animato](/slides/it/python-java/convert-powerpoint-to-animated-gif/) | Memorizza i fotogrammi renderizzati, non i comportamenti modificabili o l'interazione con trigger di clic. Controllare il movimento realmente renderizzato. |
| [Video](/slides/it/python-java/convert-powerpoint-to-video/) | Renderizza i fotogrammi dell'animazione e li codifica in video. Il supporto è limitato alle [animazioni ed effetti supportati](/slides/it/python-java/convert-powerpoint-to-video/#supported-animations-and-effects); i comandi e gli eventi interattivi non diventano una timeline modificabile. |

## **FAQ**

**Perché il mio effetto contiene comportamenti prima che io ne aggiunga?**

La creazione di un effetto predefinito può generare le operazioni sottostanti. Ispezionarli prima di decidere se estendere il preset o sostituire i suoi comportamenti.

**Spostare un comportamento all'inizio lo fa riprodurre per primo?**

Non necessariamente. L'ordine della collezione non sostituisce la temporizzazione. Controllare ritardi, durate e interazioni tra operazioni sulla stessa proprietà.

**Perché un comando end non ha punti?**

Segna la fine del percorso e non richiede coordinate. Verificare la presenza di un array di punti nullo quando si ispeziona un percorso letto da file.

**Un round‑trip riuscito è sufficiente per confermare la riproduzione?**

No. La riapertura conferma la conservazione delle proprietà controllate. Testare separatamente il lettore di presentazioni o l'esportazione animata per confermare il comportamento visivo.