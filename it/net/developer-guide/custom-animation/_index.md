---
title: Crea e modifica comportamenti di animazione personalizzati in .NET
linktitle: Animazione personalizzata
type: docs
weight: 151
url: /it/net/custom-animation/
keywords:
- animazione personalizzata
- comportamento di animazione
- percorso di movimento
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Crea, ispeziona e modifica comportamenti di animazione personalizzati e percorsi di movimento modificabili in presentazioni PowerPowerPoint con Aspose.Slides per .NET."
---
## **Panoramica**

I comportamenti di animazione personalizzati ti consentono di controllare operazioni individuali all'interno di un effetto di animazione, come la modifica di un colore, la rotazione di una forma o il tracciamento di un percorso di movimento modificabile. Questa guida mostra come creare e combinare comportamenti, configurare la loro temporizzazione, ispezionare e modificare le animazioni esistenti e verificare che le loro proprietà sopravvivano al salvataggio e alla riapertura di una presentazione.

Per effetti predefiniti e trigger di clic, vedi [Animazione delle forme](/slides/it/net/shape-animation/).

## **Comprendere il modello di animazione**

Un'animazione è organizzata come **Timeline → Sequence → Effect → Behaviors**:

- La [Timeline](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide/timeline/) della diapositiva contiene la sua sequenza principale e le sequenze interattive.
- Una [ISequence](https://reference.aspose.com/slides/it/net/aspose.slides.animation/isequence/) contiene effetti, potenzialmente destinati a forme diverse.
- Un [IEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/) identifica una forma target, un preset, un sottotipo e la temporizzazione dell'effetto.
- [IEffect.Behaviors](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/behaviors/) contiene le operazioni che implementano l'effetto: cambio colore, spostamento, rotazione, impostazione di una proprietà e così via.

## **Creare comportamenti individuali**

Chiama [ISequence.AddEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/isequence/addeffect/) per creare un effetto e accedere alla sua collezione [Behaviors](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/behaviors/). Un preset può popolare automaticamente questa collezione. Mantieni le sue operazioni quando estendi il preset, o usa [Clear](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorcollection/clear/) quando le sostituisci deliberatamente.

[IBehaviorFactory](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorfactory/) crea gli otto tipi di comportamento illustrati di seguito. Il movimento è trattato in [Crea un percorso di movimento](#build-a-motion-path). Ogni esempio di creazione è un programma completo; gli esempi di modifica successivi indicano quale file di output utilizzano.

### **Rotazione**

Usa [CreateRotationEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) per creare una rotazione. [By](https://reference.aspose.com/slides/it/net/aspose.slides.animation/irotationeffect/by/) specifica un angolo relativo in gradi; [From](https://reference.aspose.com/slides/it/net/aspose.slides.animation/irotationeffect/from/) e [To](https://reference.aspose.com/slides/it/net/aspose.slides.animation/irotationeffect/to/) specificano i punti finali.

L'esempio parte da un effetto Spin, sostituisce le operazioni del preset con un unico comportamento di rotazione e assegna a quell'operazione una durata di due secondi. Un angolo relativo di 90 gradi rappresenta un quarto di giro rispetto all'orientamento iniziale della forma, quindi non è necessario specificare un angolo iniziale esplicito.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` contiene una forma e un comportamento di rotazione. La collezione, la temporizzazione e gli esempi di modifica della rotazione sottostanti usano questo file.

### **Scala**

Usa [CreateScaleEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) con percentuali X/Y: [From](https://reference.aspose.com/slides/it/net/aspose.slides.animation/iscaleeffect/from/) e [To](https://reference.aspose.com/slides/it/net/aspose.slides.animation/iscaleeffect/to/) descrivono la dimensione iniziale e finale, mentre [By](https://reference.aspose.com/slides/it/net/aspose.slides.animation/iscaleeffect/by/) descrive una variazione relativa. Qui, 100 rappresenta la dimensione originale.

L'esempio aumenta entrambe le dimensioni dal 100 % al 125 % in due secondi. L'uso di percentuali orizzontali e verticali uguali mantiene le proporzioni della forma; percentuali diverse allungherebbero una dimensione più dell'altra.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **Colore**

Usa [CreateColorEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) per cambiare il riempimento da blu a arancione. [From](https://reference.aspose.com/slides/it/net/aspose.slides.animation/icoloreffect/from/) e [To](https://reference.aspose.com/slides/it/net/aspose.slides.animation/icoloreffect/to/) sono colori; [By](https://reference.aspose.com/slides/it/net/aspose.slides.animation/icoloreffect/by/) è una variazione di colore. [IBehavior.Properties](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehavior/properties/) identifica l'attributo animato.

Il riempimento solido della forma è inizializzato a blu, corrispondente al colore di partenza dell'animazione. Selezionare l'attributo fill-color indica al comportamento quale parte della forma modificare; i soli colori finali non identificano quell'attributo. L'effetto salvato descrive una transizione di due secondi verso l'arancione.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **Filtro**

Usa [CreateFilterEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) per selezionare una transizione. [Type](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ifiltereffect/subtype/) e [Reveal](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ifiltereffect/reveal/) specificano il filtro, la direzione e se rivelare o nascondere la forma.

Questo esempio configura una transizione di due secondi che rivela la forma usando il sottotipo direzione destra. Le impostazioni del filtro appartengono al comportamento all'interno dell'effetto, quindi vengono configurate dopo che le operazioni originali del preset sono state rimosse.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **Proprietà**

Usa [CreatePropertyEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) per animare l'opacità. [From](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ipropertyeffect/to/) e [By](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ipropertyeffect/by/) sono stringhe interpretate usando [ValueType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ipropertyeffect/valuetype/) e [CalcMode](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ipropertyeffect/calcmode/). Scegli punti finali o uno spostamento relativo invece di impostare tutti e tre indiscriminatamente.

Qui, l'attributo selezionato è opacity, e le stringhe numeriche rappresentano un cambiamento dal 25 % di opacità all'opacità completa. L'interpolazione lineare descrive una variazione graduale tra quei valori. Quando adatti questo esempio a un'altra proprietà, scegli un tipo di valore e valori finali appropriati a quella proprietà.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **Imposta**

Usa [CreateSetEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) per assegnare la visibilità tramite [To](https://reference.aspose.com/slides/it/net/aspose.slides.animation/iseteffect/to/). Un comportamento di impostazione non interpola tra i punti finali.

L'esempio seleziona l'attributo visibility e assegna la stringa `visible` quando il comportamento viene eseguito. Il rettangolo è già visibile in questa presentazione minima, quindi l'assegnazione potrebbe non produrre un cambiamento visivo evidente da sola. Un'operazione del genere è utile come parte di un effetto più ampio che controlla anche quando la forma diventa nascosta o visibile.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **Comando**

Usa [CreateCommandEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) e configura [Type](https://reference.aspose.com/slides/it/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/it/net/aspose.slides.animation/icommandeffect/commandstring/) e [ShapeTarget](https://reference.aspose.com/slides/it/net/aspose.slides.animation/icommandeffect/shapetarget/). Posiziona una registrazione WAV denominata `sample.wav` nella directory di lavoro. Questo esempio la incorpora con [AddAudioFrameEmbedded](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addaudioframeembedded/) e associa un comando di riproduzione al fotogramma audio.

Il fotogramma audio è sia il target dell'effetto sia il target del comando. Questo collega la richiesta di riproduzione alla registrazione incorporata; una stringa di comando da sola non identifica quale oggetto multimediale controllare. L'effetto è configurato per avviarsi con un clic durante la presentazione.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

Il salvataggio memorizza il comando in `command.pptx`; non riproduce la registrazione. La riproduzione richiede un lettore di diapositive che supporti il comando e il suo target multimediale.

## **Gestire la collezione di comportamenti**

[IBehaviorCollection](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorcollection/) supporta [Add](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorcollection/remove/) e [RemoveAt](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorcollection/removeat/). Questo esempio apre `rotation.pptx`, aggiunge una scala, la sposta prima della rotazione e rimuove la rotazione. Rimuovere e reinserire lo stesso oggetto ne cambia la posizione memorizzata senza creare una copia.

La sequenza di modifiche cambia la collezione da rotazione‑scala a scala‑rotazione, poi a sola scala. Gli indici si riferiscono alla collezione corrente, quindi la rimozione utilizza il nuovo indice della rotazione dopo il riordino. L'enumerazione finale conferma quale comportamento sarà salvato.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

L'output è `ScaleEffect`: rimane solo la scala. L'ordine della collezione non programma, di per sé, comportamenti uno dopo l'altro. Svuota la collezione solo quando sostituisci tutte le sue operazioni.

## **Configurare la temporizzazione del comportamento**

[IBehavior.Timing](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehavior/timing/) espone [ITiming](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/), indipendentemente da [IEffect.Timing](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/timing/). La temporizzazione dell'effetto programma l'effetto contenitore; la temporizzazione del comportamento descrive un'operazione al suo interno.

### **Impostare durata, ritardo, ripetizione e accelerazione**

Apri `rotation.pptx` e imposta [Duration](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/duration/) e [TriggerDelayTime](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/triggerdelaytime/) in secondi, poi configura [RepeatCount](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/repeatcount/). [Accelerate](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/accelerate/) e [Decelerate](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/decelerate/) sono frazioni della durata; mantieni la loro somma al massimo 1.

Il file di input è quello creato nell'esempio di rotazione, dove il primo comportamento è noto per essere una rotazione. Questo esempio modifica solo la temporizzazione di quel comportamento; il suo angolo di 90 gradi rimane intatto. Tenere separati angolo e temporizzazione facilita la regolazione del ritmo senza ricostruire l'animazione.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

Il comportamento usa una durata di due secondi, un ritardo di mezzo secondo e un conteggio di ripetizioni pari a 3. Il primo e l'ultimo 20 % della durata sono usati per accelerazione e decelerazione.

Altre politiche di ripetizione includono [RepeatDuration](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/repeatuntilendslide/) e [RepeatUntilNextClick](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/repeatuntilnextclick/); scegli una politica invece di abilitarle tutte insieme. [AutoReverse](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/autoreverse/) riproduce l'animazione al contrario dopo il passaggio in avanti. L'accelerazione e la decelerazione si applicano a cambiamenti continui, non a assegnazioni discrete o a comandi.

## **Creare un percorso di movimento**

Usa [CreateMotionEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) per creare un movimento. I suoi [From](https://reference.aspose.com/slides/it/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/it/net/aspose.slides.animation/imotioneffect/to/) e [By](https://reference.aspose.com/slides/it/net/aspose.slides.animation/imotioneffect/by/) descrivono coordinate o offset percentuali. Per una rotta modificabile, crea un [MotionPath](https://reference.aspose.com/slides/it/net/aspose.slides.animation/motionpath/) e assegnalo a [IMotionEffect.Path](https://reference.aspose.com/slides/it/net/aspose.slides.animation/imotioneffect/path/). [IMotionPath](https://reference.aspose.com/slides/it/net/aspose.slides.animation/imotionpath/) memorizza i comandi del percorso.

[MotionCommandPathType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/motioncommandpathtype/) seleziona l'operazione:

| Comando | Punti | Significato |
| --- | --- | --- |
| MoveTo | Uno | Imposta la posizione di partenza. |
| LineTo | Uno | Si sposta lungo un segmento rettilineo fino al punto finale. |
| CurveTo | Tre | Segue una curva cubica definita da due punti di controllo e un punto finale. |
| CloseLoop | Nessuno | Ritorna alla posizione di partenza. |
| End | Nessuno | Conclude il percorso. |

[MotionPathPointsType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/motionpathpointstype/) descrive le caratteristiche di modifica dei punti, come punti d'angolo o lisci. Non sostituisce il tipo di comando. Usa un tipo di punto curva per l'esempio di curva sotto, e un tipo di punto d'angolo per i segmenti rettilinei.

Le coordinate del percorso sono normalizzate alle dimensioni della diapositiva: uno spostamento X di 0,25 rappresenta un quarto della larghezza della diapositiva, non 0,25 punti. L'asse Y positivo scorre verso il basso. I comandi assoluti specificano posizioni nel sistema di coordinate del percorso; i comandi relativi specificano offset dalla posizione corrente. Questo è separato da [Origin](https://reference.aspose.com/slides/it/net/aspose.slides.animation/imotioneffect/origin/), che seleziona il riferimento del percorso, e [PathEditMode](https://reference.aspose.com/slides/it/net/aspose.slides.animation/imotioneffect/patheditmode/), che controlla come il percorso si muove quando la forma viene spostata.

### **Creare un percorso rettilineo**

Crea un comportamento di movimento con un punto di partenza, un segmento rettilineo e un comando di fine. [IMotionPath.Add](https://reference.aspose.com/slides/it/net/aspose.slides.animation/imotionpath/add/) accetta il tipo di comando, i suoi punti, il tipo di punto e un flag di coordinate relative.

Il comando di partenza stabilisce (0, 0), e la linea termina in (0.25, 0), dando al percorso uno spostamento orizzontale di un quarto della larghezza della diapositiva. Il comando di fine non ha punti di coordinate. Una volta assegnato il percorso, aggiungere il comportamento di movimento all'effetto collega quella rotta al rettangolo.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` contiene un comportamento di movimento con tre comandi di percorso. Gli esempi di modifica dei file seguenti usano questa struttura nota.

### **Confrontare coordinate assolute e relative**

Questi due oggetti percorso descrivono la stessa rotta. Il comando assoluto termina in (0.3, 0.1); il comando relativo aggiunge (0.1, 0.1) alla posizione corrente, (0.2, 0).

Entrambi i percorsi partono dalla stessa posizione. Per la linea relativa, aggiungi i suoi offset X e Y alla posizione corrente per ottenere il punto finale; per la linea assoluta, leggi direttamente il punto finale. Cambiare il flag senza convertire le coordinate descriverebbe una rotta diversa.

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Assegna uno dei due percorsi a un comportamento di movimento per usarlo in una presentazione. L'ultimo argomento booleano sceglie coordinate relative per quel comando.

### **Sostituire una linea con una curva**

Apri `motion.pptx` e sostituisci il suo comando di linea con una curva cubica. Fornisci prima i due punti di controllo, seguiti dal punto finale.

La posizione di partenza è fornita dal comando precedente. I primi due punti modellano la curva, mentre il terzo è la destinazione; non sono tre destinazioni successive. Aggiornare simultaneamente il tipo di comando, il tipo di modifica dei punti e l'array di punti mantiene il segmento coerente con la nuova geometria.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

Il percorso in `curve.pptx` ha ancora tre comandi; il suo comando intermedio ora definisce una curva.

## **Ispezionare e modificare un percorso salvato**

Ogni [IMotionCmdPath](https://reference.aspose.com/slides/it/net/aspose.slides.animation/imotioncmdpath/) espone [Points](https://reference.aspose.com/slides/it/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/imotioncmdpath/pointstype/) e [IsRelative](https://reference.aspose.com/slides/it/net/aspose.slides.animation/imotioncmdpath/isrelative/). Gli esempi seguenti usano il percorso di tre comandi noto in `motion.pptx`. Per input arbitrari, individua l'effetto desiderato e controlla i tipi di comando e il numero di punti prima di modificare per indice.

### **Leggere comandi e coordinate**

Leggi il percorso senza modificarlo. I comandi end e close-loop non richiedono punti, quindi prevedi un array di punti nullo.

L'output associa ogni comando al suo flag di coordinate relative prima di elencare i punti. Questo ti permette di distinguere un punto finale da un offset prima di modificare il percorso. Una curva elencherebbe tre punti, mentre la linea retta in questo file ne elenca uno solo.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

L'elenco contiene un punto di partenza, una linea assoluta che termina in (0.25, 0) e un comando end.

### **Modificare un punto finale**

Apri `motion.pptx` e sostituisci l'array di punti della linea per spostare il suo punto finale.

Nel file di input, l'indice 0 è il comando di partenza e l'indice 1 è la linea. Sostituire il singolo punto della linea ne cambia la destinazione senza alterare il tipo di comando, la temporizzazione o la posizione nella collezione. Poiché il comando usa coordinate assolute, la nuova coppia specifica una posizione anziché un offset aggiunto.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

La linea in `motion-endpoint.pptx` termina in (0.4, 0.1); il file originale rimane invariato.

### **Sostituire un segmento**

Usa [Insert](https://reference.aspose.com/slides/it/net/aspose.slides.animation/imotionpath/insert/) e [RemoveAt](https://reference.aspose.com/slides/it/net/aspose.slides.animation/imotionpath/removeat/) per sostituire la linea in `motion.pptx`. L'inserimento sposta la vecchia linea all'indice 2.

Ciò dimostra la sostituzione di un oggetto comando anziché la modifica delle sue coordinate esistenti. Dopo l'inserimento, la collezione contiene temporaneamente il comando di partenza, la nuova linea, la vecchia linea e il comando end. Rimuovendo l'indice 2 si elimina la vecchia linea, lasciando in posizione la nuova rotta.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

Il percorso salvato ha ancora tre comandi, con la nuova linea che termina in (0.2, 0.1) e il comando end per ultimo.

## **Modificare e verificare un comportamento esistente**

Quando l'indice del comportamento è sconosciuto, selezionalo per tipo. Questo esempio apre `rotation.pptx`, trova il suo [IRotationEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/irotationeffect/), cambia l'angolo e verifica il valore salvato dopo la riapertura.

Il controllo del tipo permette al ciclo di saltare i comportamenti che non sono rotazioni. Il secondo caricamento legge il file salvato in un oggetto presentazione separato, così il confronto verifica i dati persistiti invece del valore ancora in memoria. Questo esempio presuppone ancora che l'effetto noto sia il primo nella sequenza principale; selezionare un comportamento per tipo non individua l'effetto corretto in una presentazione arbitraria.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

L'output è `Rotation preserved: True`. Applica lo stesso schema di verifica per gli altri comportamenti. Per un controllo completo di preservazione, confronta forma target, effetto, tipi e ordine dei comportamenti, temporizzazione e comandi del percorso. Usa una tolleranza numerica per i valori a virgola mobile. Per una presentazione con layout di animazione sconosciuto, vedi [Leggere animazioni delle forme](/slides/it/net/shape-animation/#read-shape-animations) per l'attraversamento di sequenze principali e interattive.

## **Ordine dei comportamenti, preset e riproduzione**

L'ordine in [IBehaviorCollection](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehaviorcollection/) è l'ordine memorizzato delle operazioni di un effetto. Non è una playlist in cui ogni comportamento attende automaticamente quello precedente. La temporizzazione e l'effetto contenitore determinano la programmazione. I comportamenti possono sovrapporsi e le operazioni sulla stessa proprietà possono interagire tramite [Additive](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehavior/additive/) e [Accumulate](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ibehavior/accumulate/). Non usare il solo riordino della collezione per programmare “sposta, poi ruota”; usa temporizzazioni esplicite o effetti separati come descritto in [Animazione delle forme](/slides/it/net/shape-animation/).

Il [Type](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/type/) e il [Subtype](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/subtype/) dell'effetto descrivono il suo preset. Non rappresentano una descrizione completa di un albero di comportamenti modificato. Scegli il preset e il sottotipo prima di personalizzare i comportamenti: cambiare il preset può ricostruire la collezione e scartare le tue operazioni personalizzate. Per esempio, cambiare un effetto Spin personalizzato in Fade può sostituire il comportamento di rotazione con comportamenti di impostazione e filtro. Ispeziona nuovamente la collezione dopo aver cambiato un preset o un sottotipo. Svuotare i comportamenti del preset può anche rimuovere operazioni di visibilità o di inizializzazione di cui il preset ha bisogno. Gli esempi usano deliberatamente forme visibili e sostituiscono i comportamenti; non ricostruiscono l'implementazione di ogni preset.

## **Compatibilità dei formati**

Un albero di comportamenti preservato non garantisce una riproduzione identica in ogni visualizzatore o motore di esportazione. Controlla separatamente i dati salvati e l'output renderizzato.

| Formato o output | Cosa verificare |
| --- | --- |
| PPTX | Usalo come formato principale per questi esempi. Riaprilo per verificare l'albero di comportamenti modificabile, poi controlla la riproduzione nella versione di PowerPoint desiderata. |
| PPT | La rappresentazione binaria legacy può differire da PPTX. Esegui un ciclo di salvataggio‑riapertura separato e verifica la riproduzione; non inferire il supporto per ogni combinazione personalizzata dal solo output PPTX riuscito. |
| PDF, PNG, JPEG e altre immagini statiche delle diapositive | Contengono una rappresentazione statica della diapositiva, non una timeline di comportamento riproducibile né un fotogramma finale garantito dell'animazione. |
| [HTML5](/slides/it/net/export-to-html5/) | Può riprodurre le animazioni supportate quando l'animazione delle forme è abilitata nelle opzioni di esportazione. Prova le combinazioni personalizzate nel browser. |
| [GIF animato](/slides/it/net/convert-powerpoint-to-animated-gif/) | Memorizza i fotogrammi renderizzati, non i comportamenti modificabili o l'interazione tramite clic. Controlla il movimento effettivamente renderizzato. |
| [Video](/slides/it/net/convert-powerpoint-to-video/) | Renderizza i fotogrammi dell'animazione e li codifica come video. Il supporto è limitato alle [animazioni ed effetti supportati](/slides/it/net/convert-powerpoint-to-video/#supported-animations-and-effects); i comandi e gli eventi interattivi non diventano una timeline modificabile. |

## **FAQ**

**Perché il mio effetto contiene comportamenti prima di aggiungerne uno?**

La creazione di un effetto predefinito può generare le operazioni sottostanti. Ispezionali prima di decidere se estendere il preset o sostituire i suoi comportamenti.

**Spostare un comportamento all'inizio lo fa riprodurre per primo?**

Non necessariamente. L'ordine nella collezione non sostituisce la temporizzazione. Controlla ritardi, durate e le interazioni tra operazioni sulla stessa proprietà.

**Perché un comando end non ha punti?**

Segna la fine del percorso e non richiede coordinate. Controlla la presenza di un array di punti nullo quando ispezioni un percorso letto da un file.

**Un round‑trip riuscito è sufficiente a confermare la riproduzione?**

No. Riaprire conferma la preservazione delle proprietà verificate. Testa separatamente il lettore di diapositive o l'esportazione animata per confermare il comportamento visivo.