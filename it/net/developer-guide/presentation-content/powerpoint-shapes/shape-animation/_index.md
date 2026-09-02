---
title: Applicare animazioni di forma nelle presentazioni in .NET
linktitle: Animazione forma
type: docs
weight: 60
url: /it/net/shape-animation/
keywords:
- forma
- animazione
- effetto
- forma animata
- testo animato
- aggiungere animazione
- ottenere animazione
- estrarre animazione
- aggiungere effetto
- ottenere effetto
- estrarre effetto
- suono effetto
- applicare animazione
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come aggiungere, ispezionare e personalizzare le animazioni di forma, la temporizzazione, i suoni, il comportamento dopo l'animazione e il testo animato con Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides per .NET rappresenta le animazioni delle diapositive come effetti in una timeline della diapositiva. Un effetto ha una forma di destinazione, un tipo e sottotipo di animazione, un attivatore, impostazioni di temporizzazione e proprietà opzionali come suono o comportamento dopo l'animazione.

La timeline contiene due tipi di sequenze:

- La **sequenza principale** viene riprodotta man mano che la diapositiva avanza.  
- Una **sequenza interattiva** inizia quando la sua forma di attivazione viene cliccata.

Poiché caselle di testo, immagini, grafici, tabelle e altri oggetti della diapositiva implementano [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/), è possibile utilizzare lo stesso metodo [ISequence.AddEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/isequence/addeffect/) per la maggior parte del contenuto della diapositiva. Gli effetti disponibili sono elencati nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effecttype/).

## **Aggiungere animazioni alle forme**

Per aggiungere un'animazione, ottieni la sequenza principale della diapositiva e chiama [ISequence.AddEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/isequence/addeffect/) con la forma di destinazione, il tipo di effetto, il sottotipo e l'attivatore. Per un effetto che inizia quando un'altra forma viene cliccata, crea una sequenza interattiva il cui attivatore è quella forma.

L'esempio seguente crea entrambi i tipi di animazione e salva il risultato in `shape-animations.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

L'attivatore controlla quando inizia un effetto:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effecttriggertype/) attende un clic nella sequenza principale, o un clic sulla forma di attivazione in una sequenza interattiva.  
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effecttriggertype/) inizia con l'effetto precedente.  
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effecttriggertype/) inizia quando l'effetto precedente termina.

Per animare un'immagine, un grafico o un altro tipo di forma, passa quell'oggetto a [ISequence.AddEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/isequence/addeffect/) invece di `targetShape`. Per le opzioni di raggruppamento specifiche dei grafici, vedere [Animated Charts](/slides/it/net/animated-charts/).

## **Leggere animazioni delle forme**

Usa [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/it/net/aspose.slides.animation/isequence/geteffectsbyshape/) quando conosci la forma di destinazione. Per ispezionare ogni effetto, enumera la sequenza principale e ogni sequenza interattiva. L'enumerazione evita di presumere che una sequenza contenga un effetto all'indice `0`.

L'esempio seguente crea una forma con effetti nella sequenza principale e interattivi, ottiene gli effetti che hanno come destinazione la forma e poi enumera ogni sequenza sulla diapositiva.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

Se hai bisogno degli effetti solo per una forma, identifica prima la forma per nome, tipo di segnaposto o un'altra proprietà stabile; poi chiama [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/it/net/aspose.slides.animation/isequence/geteffectsbyshape/). Non presumere che [IShapeCollection.Item](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/item/) all'indice `0` sia sempre l'oggetto desiderato.

## **Lavorare con gli effetti dei segnaposti ereditati**

Un segnaposto su una diapositiva normale può ereditare il comportamento di animazione dal corrispondente segnaposto nella diapositiva del layout e nella diapositiva master. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/getbaseplaceholder/) restituisce quel segnaposto genitore, o `null` se non esiste un genitore.

Nella presentazione di esempio seguente, il piè di pagina ha **Random Bars** sulla diapositiva normale, **Split** sulla diapositiva del layout e **Fly In** sulla diapositiva master.

![Effetto di animazione del piè di pagina sulla diapositiva normale](slide-shape-animation.png)

![Effetto di animazione del segnaposto piè di pagina sulla diapositiva del layout](layout-shape-animation.png)

![Effetto di animazione del segnaposto piè di pagina sulla diapositiva master](master-shape-animation.png)

L'esempio successivo costruisce la gerarchia dei segnaposti. Aggiunge effetti a un segnaposto master, a un segnaposto di layout e al corrispondente segnaposto su una diapositiva normale. Ogni chiamata a [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/getbaseplaceholder/) viene verificata prima di utilizzare la forma restituita.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **Modificare la temporizzazione delle animazioni**

La finestra di dialogo **Timing** di PowerPoint corrisponde alle proprietà di [ITiming](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/).

![Finestra di dialogo Timing di PowerPoint per un effetto di animazione](shape-animation.png)

- **Start** corrisponde a [ITiming.TriggerType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/triggertype/).  
- **Duration** corrisponde a [ITiming.Duration](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/duration/), in secondi.  
- **Delay** corrisponde a [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/triggerdelaytime/), in secondi.  
- **Repeat** corrisponde a [ITiming.RepeatCount](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/repeatuntilnextclick/) o [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/repeatuntilendslide/).  
- **Riavvolgi al termine della riproduzione** corrisponde a [ITiming.Rewind](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/rewind/).

Questo esempio indipendente aggiunge un effetto, ne modifica la temporizzazione tramite l'oggetto restituito da [ISequence.AddEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/isequence/addeffect/), e salva il risultato. Mantenere il riferimento a [IEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/) restituito evita di dover utilizzare un indice di collezione non necessario.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

Utilizza un solo modo di ripetizione intenzionalmente. Combinare un conteggio di ripetizione con un flag "until" può produrre risultati confusi in diversi visualizzatori. Quando si cambiano i modi di ripetizione, impostare [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/repeatuntilnextclick/) e [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/repeatuntilendslide/) prima di [ITiming.RepeatCount](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/repeatcount/), poiché l'impostazione di uno di questi flag cambia anche il modo di ripetizione attivo.

## **Aggiungere ed estrarre suoni delle animazioni**

Un effetto di animazione può fare riferimento a audio incorporato tramite [IEffect.Sound](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/sound/). [IEffect.StopPreviousSound](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/stopprevioussound/) indica a un effetto di interrompere l'audio avviato da un effetto precedente.

### **Aggiungere un suono a un effetto**

L'esempio seguente richiede un file audio locale chiamato `animation-sound.wav`. Crea due effetti, incorpora quel file come suono per il primo effetto e configura il secondo effetto per interrompere il suono. Utilizza gli oggetti restituiti da [ISequence.AddEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/isequence/addeffect/), quindi non è necessario fornire un indice di sequenza.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **Estrarre i suoni incorporati degli effetti**

L'esempio seguente richiede una presentazione locale chiamata `presentation-with-animation-sounds.pptx`. Analizza sia le sequenze principali che quelle interattive e scrive ogni suono effetto incorporato nella directory `extracted-animation-sounds`. L'estensione viene selezionata dal tipo MIME audio esposto da [IAudio.ContentType](https://reference.aspose.com/slides/it/net/aspose.slides/iaudio/contenttype/).

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

Per oggetti audio di grandi dimensioni, utilizza [IAudio.GetStream](https://reference.aspose.com/slides/it/net/aspose.slides/iaudio/getstream/) e copia lo stream in un file invece di caricare l'intero oggetto in un array di byte.

## **Impostare il comportamento dopo l'animazione**

L'opzione **After animation** controlla cosa succede a una forma dopo che il suo effetto è terminato.

![Finestra di dialogo Opzioni effetto di PowerPoint che mostra le impostazioni After animation](shape-after-animation.png)

L'enumerazione [AfterAnimationType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/afteranimationtype/) supporta il mantenere la forma invariata, cambiarne il colore, nasconderla dopo l'animazione o nasconderla al click successivo. Quando il tipo è [AfterAnimationType.Color](https://reference.aspose.com/slides/it/net/aspose.slides.animation/afteranimationtype/), impostare anche [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/afteranimationcolor/).

Questo esempio indipendente crea un effetto, imposta il suo comportamento dopo l'animazione tramite l'oggetto effetto restituito e salva il risultato.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

Modificare il tipo da [AfterAnimationType.Color](https://reference.aspose.com/slides/it/net/aspose.slides.animation/afteranimationtype/) cancella l'impostazione del colore dopo l'animazione.

## **Animare il testo**

L'animazione del testo ha due controlli correlati:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itextanimation/buildtype/) controlla se i paragrafi appaiono tutti insieme o per livello di paragrafo.  
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/animatetexttype/) controlla se il testo appare tutto in una volta, parola per parola o lettera per lettera. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/delaybetweentextparts/) imposta il ritardo tra parole o lettere. Un valore positivo è una percentuale della durata dell'effetto; un valore negativo è un ritardo in secondi.

L'esempio indipendente seguente anima le parole in una casella di testo. [BuildType.AsOneObject](https://reference.aspose.com/slides/it/net/aspose.slides.animation/buildtype/) disabilita la costruzione paragrafo per paragrafo in modo che l'impostazione per parola si applichi all'intero riquadro di testo.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

Per costruire una casella di testo per paragrafi, imposta [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/it/net/aspose.slides.animation/buildtype/) (o un altro livello di paragrafo). Per mirare a un singolo paragrafo con un proprio effetto, usa la sovraccarico di [ISequence.AddEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/isequence/addeffect/) che accetta un [IParagraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph/). Vedi [Animated Text](/slides/it/net/animated-text/) per esempi a livello di paragrafo.

## **Note su esportazione e compatibilità**

- Salvare in PPT o PPTX preserva il modello di animazione, ma la riproduzione finale è controllata dal visualizzatore della presentazione.  
- PDF e immagini statiche non riproducono animazioni. Usa [HTML5 export](/slides/it/net/export-to-html5/), GIF animati o [video conversion](/slides/it/net/convert-powerpoint-to-video/) quando l'output deve mostrare movimento.  
- Per HTML5, abilita [Html5Options.AnimateShapes](https://reference.aspose.com/slides/it/net/aspose.slides.export/html5options/animateshapes/) e, se necessario, [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/it/net/aspose.slides.export/html5options/animatetransitions/).  
- Il rendering video supporta molti effetti comuni di ingresso, enfasi, uscita e percorsi di movimento, ma non tutti gli effetti di PowerPoint sono supportati. Controlla le attuali [supported animations and effects](/slides/it/net/convert-powerpoint-to-video/#supported-animations-and-effects) e testa le presentazioni critiche con la versione di Aspose.Slides target.  
- Gli effetti personalizzati avanzati e gli effetti importati da altri formati di presentazione possono essere preservati nel file ma renderizzati diversamente in PowerPoint, HTML5 o video. Convalida il risultato esportato invece di fare affidamento solo sul nome dell'effetto.

## **FAQ**

**Perché un'animazione appare in PowerPoint ma non in un PDF?**

Il PDF è un formato statico, quindi le animazioni e le transizioni delle diapositive non vengono riprodotte. Esporta in HTML5, GIF animati o video quando è necessario preservare il movimento.

**Perché un effetto viene riprodotto diversamente in un video?**

L'esportazione in video rende le animazioni invece di memorizzare il comportamento originale di PowerPoint. Alcuni effetti avanzati non sono supportati o sono approssimati. Consulta la tabella degli effetti supportati e testa la presentazione reale prima dell'uso in produzione.

**Spostare una forma in avanti o indietro cambia l'ordine delle animazioni?**

No. L'ordine Z della forma controlla la sovrapposizione, mentre l'ordine della sequenza e gli attivatori controllano la riproduzione dell'animazione. Modifica la timeline se hai bisogno di un ordine di riproduzione diverso.