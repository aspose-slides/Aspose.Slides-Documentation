---
title: Crea e modifica comportamenti di animazione personalizzati in Python
linktitle: Animazione personalizzata
type: docs
weight: 151
url: /it/python-net/custom-animation/
keywords:
- animazione personalizzata
- comportamento di animazione
- percorso di movimento
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Crea, ispeziona e modifica comportamenti di animazione personalizzati e percorsi di movimento modificabili nelle presentazioni PowerPoint con Aspose.Slides per Python tramite .NET."
---
## **Panoramica**

Comportamenti di animazione personalizzati ti consentono di controllare operazioni individuali all'interno di un effetto di animazione, ad esempio cambiare un colore, ruotare una forma o seguire un percorso di movimento modificabile. Questa guida mostra come creare e combinare i comportamenti, configurarne la temporizzazione, ispezionare e modificare le animazioni esistenti e verificare che le loro proprietà sopravvivano al salvataggio e alla riapertura di una presentazione.

Per gli effetti predefiniti e i trigger di clic, vedere [Animazione forma](/slides/it/python-net/shape-animation/).

## **Comprendere il modello di animazione**

- La [timeline] della diapositiva è descritta qui: https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslide/timeline/ contiene la sua sequenza principale e le sequenze interattive.  
- Una [Sequence] contiene effetti, potenzialmente rivolti a forme diverse.  
- Un [Effect] identifica una forma di destinazione, preset, sottotipo e temporizzazione dell'effetto.  
- [Effect.behaviors] contiene le operazioni che implementano l'effetto: cambiare colore, spostare, ruotare, impostare una proprietà, ecc.

## **Creare comportamenti individuali**

Chiama [Sequence.add_effect] per creare un effetto e accedere alla sua collezione [behaviors]. Un preset può popolare automaticamente questa collezione. Mantieni le sue operazioni quando estendi il preset, oppure usa [clear] quando le sostituisci deliberatamente.

[BehaviorFactory] crea gli otto tipi di comportamento illustrati di seguito. Il movimento è trattato in [Crea un percorso di movimento](#build-a-motion-path). Ogni esempio di creazione è un programma completo; gli esempi di modifica successivi indicano quale file di output utilizzano.

### **Rotazione**

Usa [create_rotation_effect] per creare una rotazione. [by] specifica un angolo relativo in gradi; [from_address] e [to] specificano i punti finali.

L'esempio inizia con un effetto Spin, sostituisce le sue operazioni preset con un unico comportamento di rotazione e assegna a tale operazione una durata di due secondi. Un angolo relativo di 90 gradi rappresenta un quarto di giro rispetto all'orientamento iniziale della forma, quindi non è necessario specificare un angolo di partenza.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` contiene una forma e un comportamento di rotazione. La collezione, la temporizzazione e gli esempi di modifica della rotazione qui sotto usano questo file.

### **Scala**

Usa [create_scale_effect] con percentuali X/Y: [from_address] e [to] descrivono le dimensioni iniziali e finali, mentre [by] descrive una variazione relativa. Qui, 100 indica la dimensione originale.

L'esempio aumenta entrambe le dimensioni dal 100% al 125% in due secondi. L'uso di percentuali orizzontali e verticali uguali mantiene le proporzioni della forma; percentuali diverse allunerebbero una dimensione più dell'altra.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **Colore**

Usa [create_color_effect] per cambiare il riempimento da blu a arancione. [from_address] e [to] sono colori; [by] è un offset di colore. [Behavior.properties] identifica l'attributo animato.

Il riempimento solido della forma è inizializzato a blu, corrispondente al colore iniziale dell'animazione. Selezionare l'attributo fill-color indica al comportamento quale parte della forma modificare; i punti colore da soli non identificano quell'attributo. L'effetto salvato descrive una transizione di due secondi verso l'arancione.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **Filtro**

Usa [create_filter_effect] per selezionare una pulizia. [type], [subtype] e [reveal] specificano il filtro, la direzione e se rivelare o nascondere la forma.

Questo esempio configura una pulizia di due secondi che rivela la forma usando il sottotipo di direzione destra. Le impostazioni del filtro appartengono al comportamento all'interno dell'effetto, quindi sono configurate dopo che le operazioni originali del preset sono state rimosse.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **Proprietà**

Usa [create_property_effect] per animare l'opacità. [from_address], [to] e [by] sono stringhe interpretate usando [value_type] e [calc_mode]. Scegli i punti finali o un offset relativo invece di impostare tutti e tre indiscriminatamente.

Qui, l'attributo selezionato è l'opacità, e le stringhe numeriche rappresentano una variazione dal 25% di opacità all'opacità totale. L'interpolazione lineare descrive una variazione graduale tra questi valori. Quando adatti questo esempio a un altro attributo, scegli un tipo di valore e valori finali appropriati a quell'attributo.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **Imposta**

Usa [create_set_effect] per assegnare la visibilità tramite [to]. Un comportamento di tipo set non interpola tra i punti finali.

L'esempio seleziona l'attributo di visibilità e assegna la stringa `visible` quando il comportamento viene eseguito. Il rettangolo è già visibile in questa presentazione minimale, quindi l'assegnazione potrebbe non produrre un cambiamento visivo evidente da sola. Un'operazione di questo tipo è utile come parte di un effetto più ampio che controlla anche quando la forma diventa nascosta o visibile.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **Comando**

Usa [create_command_effect] e configura [type], [command_string] e [shape_target]. Posiziona una registrazione WAV chiamata `sample.wav` nella directory di lavoro. Questo esempio la incorpora con [add_audio_frame_embedded] e collega un comando di riproduzione al frame audio.

Il frame audio è sia il bersaglio dell'effetto sia il bersaglio del comando. Questo collega la richiesta di riproduzione alla registrazione incorporata; una stringa di comando da sola non identifica quale oggetto multimediale controllare. L'effetto è configurato per avviarsi al clic durante la presentazione.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

Il salvataggio memorizza il comando in `command.pptx`; non riproduce la registrazione. La riproduzione richiede un lettore di presentazioni che supporti il comando e il suo obiettivo multimediale.

## **Gestire la collezione di comportamenti**

[BehaviorCollection] supporta [add], [insert], [remove] e [remove_at]. Questo esempio apre `rotation.pptx`, aggiunge una scala, la sposta prima della rotazione e rimuove la rotazione. Rimuovere e reinserire lo stesso oggetto ne cambia la posizione memorizzata senza creare una copia.

La sequenza di modifiche trasforma la collezione da rotazione‑scala a scala‑rotazione, poi a sola scala. Gli indici si riferiscono alla collezione corrente, quindi la rimozione utilizza il nuovo indice della rotazione dopo il riordino. L'enumerazione finale conferma quale comportamento verrà salvato.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

L'output è `ScaleEffect`: rimane solo la scalatura. L'ordine della collezione non programma, di per sé, i comportamenti sequenzialmente. Svuota la collezione solo quando sostituisci tutte le sue operazioni.

## **Configurare la temporizzazione dei comportamenti**

[Behavior.timing] espone [Timing], indipendentemente da [Effect.timing]. La temporizzazione dell'effetto programma l'effetto contenitore; la temporizzazione del comportamento descrive un'operazione al suo interno.

### **Imposta durata, ritardo, ripetizione e accelerazione**

Apri `rotation.pptx` e imposta [duration] e [trigger_delay_time] in secondi, poi configura [repeat_count]. [accelerate] e [decelerate] sono frazioni della durata; mantieni la loro somma al massimo 1.

Il file di input è quello creato nell'esempio di rotazione, dove il primo comportamento è noto essere una rotazione. Questo esempio modifica solo la temporizzazione di quel comportamento; il suo angolo di 90 gradi rimane intatto. Tenere separati angolo e temporizzazione facilita la regolazione della velocità senza ricostruire l'animazione.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

Il comportamento utilizza una durata di due secondi, un ritardo di mezzo secondo e un conteggio di ripetizioni pari a 3. Il primo e l'ultimo 20% della sua durata sono usati per accelerazione e decelerazione.

Altre politiche di ripetizione includono [repeat_duration], [repeat_until_end_slide] e [repeat_until_next_click]; scegli una politica invece di abilitarle tutte insieme. [auto_reverse] riproduce l'animazione al contrario dopo il passaggio in avanti. Accelerazione e decelerazione si applicano a cambiamenti continui, non a assegnazioni discrete o comandi.

## **Creare un percorso di movimento**

Usa [create_motion_effect] per creare un movimento. I suoi [from_address], [to] e [by] descrivono coordinate o offset basati su percentuali. Per un percorso modificabile, crea un [MotionPath] e assegnalo a [MotionEffect.path]. [MotionPath] memorizza i comandi del percorso.

[MotionCommandPathType] seleziona l'operazione:

| Comando | Punti | Significato |
| --- | --- | --- |
| MOVE_TO | Uno | Imposta la posizione di partenza. |
| LINE_TO | Uno | Muove lungo un segmento rettilineo fino al suo punto finale. |
| CURVE_TO | Tre | Segue una curva cubica definita da due punti di controllo e un punto finale. |
| CLOSE_LOOP | Nessuno | Ritorna alla posizione di partenza. |
| END | Nessuno | Termina il percorso. |

[MotionPathPointsType] descrive le caratteristiche di modifica dei punti, come punti d'angolo o lisci. Non sostituisce il tipo di comando. Usa un tipo di punto curva per l'esempio di curva qui sotto e un tipo di punto angolo per i segmenti lineari.

Le coordinate del percorso sono normalizzate alle dimensioni della diapositiva: uno spostamento X di 0,25 rappresenta un quarto della larghezza della diapositiva, non 0,25 punti. Y positivo scorre verso il basso. I comandi assoluti specificano le posizioni nel sistema di coordinate del percorso; i comandi relativi specificano offset dalla posizione corrente. Questo è separato da [origin], che seleziona il riferimento del percorso, e da [path_edit_mode], che controlla come il percorso si muove quando la forma viene spostata.

### **Creare un percorso rettilineo**

Crea un comportamento di movimento con un punto di partenza, un segmento rettilineo e un comando di fine. [MotionPath.add] accetta il tipo di comando, i suoi punti, il tipo di punto e un flag per coordinate relative.

Il comando di partenza stabilisce (0, 0), e la linea termina a (0.25, 0), fornendo al percorso uno spostamento orizzontale di un quarto della larghezza della diapositiva. Il comando di fine non ha punti di coordinate. Una volta assegnato il percorso, aggiungere il comportamento di movimento all'effetto collega quel percorso al rettangolo.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` contiene un comportamento di movimento con tre comandi di percorso. I seguenti esempi di modifica del file usano questa struttura nota.

### **Confronta coordinate assolute e relative**

Questi due oggetti percorso descrivono lo stesso itinerario. Il comando assoluto termina a (0.3, 0.1); il comando relativo aggiunge (0.1, 0.1) alla posizione corrente, (0.2, 0).

Entrambi i percorsi iniziano nella stessa posizione. Per la linea relativa, aggiungi i suoi offset X e Y alla posizione corrente per ottenere il punto finale; per la linea assoluta, leggi direttamente il punto finale. Cambiare il flag senza convertire le coordinate descriverebbe un percorso diverso.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

Assegna uno dei due percorsi a un comportamento di movimento per usarlo in una presentazione. L'ultimo argomento booleano seleziona coordinate relative per quel comando.

### **Sostituire una linea con una curva**

Apri `motion.pptx` e sostituisci il suo comando di linea con una curva cubica. Fornisci prima i due punti di controllo, seguiti dal punto finale.

La posizione di partenza è fornita dal comando precedente. I primi due punti modellano la curva, mentre il terzo è la sua destinazione; non sono tre destinazioni successive. Aggiornare simultaneamente il tipo di comando, il tipo di modifica dei punti e l'array di punti mantiene il segmento coerente con la nuova geometria.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

Il percorso in `curve.pptx` ha ancora tre comandi; il comando intermedio ora definisce una curva.

## **Ispezionare e modificare un percorso salvato**

Ogni [MotionCmdPath] espone [points], [command_type], [points_type] e [is_relative]. I seguenti esempi usano il percorso a tre comandi noto in `motion.pptx`. Per un input arbitrario, individua l'effetto desiderato e controlla i tipi di comando e il conteggio dei punti prima di modificare per indice.

### **Leggere comandi e coordinate**

Leggi il percorso senza modificarlo. I comandi End e close-loop non richiedono punti, quindi prevedi un array di punti `None`.

L'output associa ogni comando al suo flag di coordinate relative prima di elencare i punti. Questo ti consente di distinguere un punto finale da un offset prima di modificare il percorso. Una curva elencherebbe tre punti, mentre la linea retta in questo file ne elenca solo uno.

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

L'elenco contiene un punto di partenza, una linea assoluta che termina a (0.25, 0) e un comando di fine.

### **Modificare un punto finale**

Apri `motion.pptx` e sostituisci l'array di punti della linea per spostare il suo punto finale.

Nel file di input, l'indice 0 è il comando di partenza e l'indice 1 è la linea. Sostituire il singolo punto della linea cambia la sua destinazione senza modificare il tipo di comando, la temporizzazione o la posizione nella collezione. Poiché il comando usa coordinate assolute, la nuova coppia specifica una posizione piuttosto che un offset aggiunto.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

La linea in `motion-endpoint.pptx` termina a (0.4, 0.1); il file originale rimane invariato.

### **Sostituire un segmento**

Usa [insert] e [remove_at] per sostituire la linea in `motion.pptx`. L'inserimento sposta la vecchia linea all'indice 2.

Ciò dimostra la sostituzione di un oggetto comando invece di modificare le sue coordinate esistenti. Dopo l'inserimento, la collezione contiene temporaneamente il comando di partenza, la nuova linea, la vecchia linea e il comando di fine. Rimuovere l'indice 2 elimina la vecchia linea e lascia il nuovo percorso al suo posto.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

Il percorso salvato ha ancora tre comandi, con la nuova linea che termina a (0.2, 0.1) e il comando di fine alla fine.

## **Modificare e verificare un comportamento esistente**

Quando l'indice del comportamento è sconosciuto, selezionalo per tipo. Questo esempio apre `rotation.pptx`, trova il suo [RotationEffect], cambia l'angolo e controlla il valore salvato dopo la riapertura.

Il controllo del tipo consente al ciclo di saltare i comportamenti che non sono rotazioni. Il secondo caricamento legge il file salvato in un oggetto presentazione separato, così il confronto verifica i dati persistenti invece del valore ancora in memoria. Questo esempio presume ancora che l'effetto noto sia il primo nella sequenza principale; selezionare un comportamento per tipo non individua l'effetto corretto in una presentazione arbitraria.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

L'output è `Rotation preserved: True`. Applica lo stesso schema di verifica del tipo ad altri comportamenti. Per un controllo completo della conservazione, confronta la forma di destinazione, l'effetto, i tipi e l'ordine dei comportamenti, la temporizzazione e i comandi del percorso. Usa una tolleranza numerica per i valori a virgola mobile. Per una presentazione con una disposizione di animazione sconosciuta, vedi [Leggere le animazioni delle forme](/slides/it/python-net/shape-animation/#read-shape-animations) per l'attraversamento delle sequenze principali e interattive.

## **Ordine dei comportamenti, preset e riproduzione**

L'ordine in [BehaviorCollection] è l'ordine memorizzato delle operazioni di un effetto. Non è una playlist in cui ogni comportamento attende automaticamente il precedente. La temporizzazione e l'effetto contenitore determinano la pianificazione. I comportamenti possono sovrapporsi, e le operazioni sulla stessa proprietà possono interagire tramite [additive] e [accumulate]. Non utilizzare solo il riordino della collezione per programmare “sposta, poi ruota”; usa temporizzazioni esplicite o effetti separati come descritto in [Animazione forma](/slides/it/python-net/shape-animation/).

Il [type] e il [subtype] dell'effetto descrivono il suo preset. Non sono una descrizione completa di un albero di comportamenti modificato. Scegli il preset e il sottotipo prima di personalizzare i comportamenti: cambiare il preset può ricostruire la collezione e scartare le tue operazioni personalizzate. Per esempio, cambiare un effetto Spin personalizzato in Fade può sostituire il suo comportamento di rotazione con comportamenti set e filter. Ispeziona nuovamente la collezione dopo aver cambiato un preset o sottotipo. Svuotare i comportamenti del preset può anche rimuovere operazioni di visibilità o di inizializzazione necessarie al preset. Gli esempi usano deliberatamente forme visibili e sostituiscono i comportamenti; non ricostruiscono l'implementazione di ogni preset.

## **Compatibilità dei formati**

Un albero di comportamenti conservato non garantisce una riproduzione identica in ogni visualizzatore o motore di esportazione. Verifica separatamente i dati salvati e l'output renderizzato.

| Formato o output | Cosa verificare |
| --- | --- |
| PPTX | Usalo come formato principale per questi esempi. Riaprilo per verificare l'albero di comportamento modificabile, quindi controlla la riproduzione nella versione di PowerPoint desiderata. |
| PPT | La rappresentazione binaria legacy può differire da PPTX. Testa un ciclo separato di salvataggio‑riapertura e riproduzione; non dedurre il supporto per ogni combinazione personalizzata dal risultato PPTX riuscito. |
| PDF, PNG, JPEG e altre immagini statiche delle diapositive | Contengono una rappresentazione statica della diapositiva, non una timeline di comportamenti riproducibili né un frame finale di animazione garantito. |
| [HTML5](/slides/it/python-net/export-to-html5/) | Può riprodurre le animazioni supportate quando l'animazione forme è abilitata nelle opzioni di esportazione. Testa combinazioni personalizzate nel browser. |
| [Animated GIF](/slides/it/python-net/convert-powerpoint-to-animated-gif/) | Memorizza i fotogrammi renderizzati, non i comportamenti modificabili o l'interazione a click. Controlla il movimento effettivamente renderizzato. |
| [Video](/slides/it/python-net/convert-powerpoint-to-video/) | Renderizza i fotogrammi dell'animazione e li codifica in video. Il supporto è limitato alle [animazioni ed effetti supportati](/slides/it/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) del motore di rendering; comandi ed eventi interattivi non diventano una timeline modificabile. |

## **FAQ**

**Perché il mio effetto contiene comportamenti prima di aggiungerne alcuno?**

La creazione di un effetto predefinito può generare le sue operazioni sottostanti. Ispezionale prima di decidere se estendere il preset o sostituire i suoi comportamenti.

**Spostare un comportamento all'inizio lo fa eseguire per primo?**

Non necessariamente. L'ordine della collezione non sostituisce la temporizzazione. Controlla ritardi, durate e le interazioni tra operazioni sulla stessa proprietà.

**Perché un comando end non ha punti?**

Segna la fine del percorso e non richiede coordinate. Verifica la presenza di un array di punti `None` quando ispezioni un percorso letto da un file.

**Un ciclo completo riuscito è sufficiente per confermare la riproduzione?**

No. Riaprire conferma la conservazione delle proprietà controllate. Testa separatamente il lettore di presentazioni o l'esportazione animata per confermare il comportamento visivo.