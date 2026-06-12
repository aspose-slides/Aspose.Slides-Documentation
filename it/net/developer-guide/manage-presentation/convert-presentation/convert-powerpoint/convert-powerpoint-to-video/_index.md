---
title: Converti presentazioni PowerPoint in video con .NET
linktitle: PowerPoint in video
type: docs
weight: 130
url: /it/net/convert-powerpoint-to-video/
keywords:
- converti PowerPoint
- converti presentazione
- converti PPT
- converti PPTX
- PowerPoint in video
- presentazione in video
- PPT in video
- PPTX in video
- PowerPoint in MP4
- presentazione in MP4
- PPT in MP4
- PPTX in MP4
- salva PPT come MP4
- salva PPTX come MP4
- esporta PPT in MP4
- esporta PPTX in MP4
- conversione video
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Scopri come convertire le presentazioni PowerPoint in video con .NET. Trova esempi di codice C# e tecniche di automazione per ottimizzare il tuo flusso di lavoro."
---
## **Introduzione**

Convertendo la tua presentazione PowerPoint o OpenDocument in video, ottieni:

**Accessibilità aumentata:** tutti i dispositivi, indipendentemente dalla piattaforma, sono dotati di lettori video per impostazione predefinita, rendendo più semplice per gli utenti aprire o riprodurre i video rispetto alle tradizionali applicazioni di presentazione.

**Portata più ampia:** i video ti consentono di raggiungere un pubblico più vasto e di presentare le informazioni in un formato più coinvolgente. Indagini e statistiche indicano che le persone preferiscono guardare e consumare contenuti video rispetto ad altre forme, rendendo il tuo messaggio più impattante.

{{% alert color="primary" %}} 

Dai un'occhiata al nostro [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/it/video) perché offre un'implementazione live ed efficace del processo descritto qui.

{{% /alert %}} 

In Aspose.Slides per .NET, abbiamo implementato il supporto per la conversione delle presentazioni in video.

* Usa Aspose.Slides per .NET per generare fotogrammi dalle diapositive della presentazione a una frequenza di fotogrammi (FPS) specificata.  
* Quindi, usa un'utilità di terze parti come ffmpeg per compilare questi fotogrammi in un video.

## **Convertire una presentazione PowerPoint in video**

1. Usa il comando `dotnet add package` per aggiungere Aspose.Slides e la libreria FFMpegCore al tuo progetto:  
   * esegui `dotnet add package Aspose.Slides.NET --version 22.11.0`  
   * esegui `dotnet add package FFMpegCore --version 4.8.0`  
2. Scarica ffmpeg da [qui](https://ffmpeg.org/download.html).  
3. FFMpegCore richiede di specificare il percorso al ffmpeg scaricato (ad es., estratto in "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Esegui il codice di conversione da PowerPoint a video.

Questo codice C# mostra come convertire una presentazione (contenente una forma e due effetti di animazione) in un video:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // utilizzerà i binari FFmpeg che abbiamo estratto in C:\tools\ffmpeg in precedenza.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Aggiungi una forma sorridente e poi animala.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // Configura la cartella dei binari ffmpeg. Vedi questa pagina: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Converti i fotogrammi in un video webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Effetti video**

Durante la conversione di una presentazione PowerPoint in video con Aspose.Slides per .NET, è possibile applicare vari effetti video per migliorare la qualità visiva del risultato. Questi effetti consentono di controllare l'aspetto delle diapositive nel video finale aggiungendo transizioni fluide, animazioni e altri elementi visivi. Questa sezione spiega le opzioni di effetto video disponibili e mostra come applicarle.

{{% alert color="primary" %}} 

Vedi:  
- [Migliorare le presentazioni PowerPoint con animazioni in C#](https://docs.aspose.com/slides/it/net/powerpoint-animation/)  
- [Animazione della forma](https://docs.aspose.com/slides/it/net/shape-animation/)  
- [Applicare effetti forma in PowerPoint usando C#](https://docs.aspose.com/slides/it/net/shape-effect/)

{{% /alert %}} 

Le animazioni e le transizioni rendono le presentazioni più coinvolgenti e interessanti — e lo stesso vale per i video. Aggiungiamo un'altra diapositiva e una transizione al codice della presentazione precedente:

```c#
// Aggiungi una forma sorridente e animala.
// ...

// Aggiungi una nuova diapositiva e una transizione animata.
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides supporta anche le animazioni di testo. In questo esempio, animiamo i paragrafi sugli oggetti in modo che appaiano uno dopo l'altro, con un intervallo di un secondo tra di essi:

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Aggiungi testo e animazioni.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };

        animationsGenerator.Run(presentation.Slides);
    }

    // Configura la cartella dei binari ffmpeg. Vedi questa pagina: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Converti i fotogrammi in un video webm.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Classi per la conversione video**

Per abilitare le operazioni di conversione da PowerPoint a video, Aspose.Slides per .NET fornisce le classi [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/net/aspose.slides.export/presentationanimationsgenerator/) e [PresentationPlayer](https://reference.aspose.com/slides/it/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` consente di impostare la dimensione del fotogramma per il video (che sarà creato successivamente) e il valore FPS (fotogrammi al secondo) tramite il suo costruttore. Se passi un'istanza di una presentazione, verrà utilizzato il suo `Presentation.SlideSize` e genera le animazioni che [PresentationPlayer](https://reference.aspose.com/slides/it/net/aspose.slides.export/presentationplayer/) utilizza.

Quando le animazioni vengono generate, viene generato un evento `NewAnimation` per ogni animazione successiva, che include un parametro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipresentationanimationplayer/). Questa classe rappresenta un lettore per un'animazione individuale.

Per lavorare con [IPresentationAnimationPlayer](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipresentationanimationplayer/), utilizzi la proprietà [Duration](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipresentationanimationplayer/duration/) (che fornisce la durata completa dell'animazione) e il metodo [SetTimePosition](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Ogni posizione dell'animazione è impostata nell'intervallo *0 a duration*, e il metodo `GetFrame` restituisce quindi un Bitmap che rappresenta lo stato dell'animazione in quel punto temporale.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Aggiungi una forma sorridente e animala.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);          // Lo stato iniziale dell'animazione.
            Bitmap bitmap = animationPlayer.GetFrame();  // Bitmap dello stato iniziale dell'animazione.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // Lo stato finale dell'animazione.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // L'ultimo fotogramma dell'animazione.
            lastBitmap.Save("last.png");
        };
    }
}
```

Per far riprodurre tutte le animazioni di una presentazione contemporaneamente, si utilizza la classe [PresentationPlayer](https://reference.aspose.com/slides/it/net/aspose.slides.export/presentationplayer/). Questa classe prende un'istanza di [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/net/aspose.slides.export/presentationanimationsgenerator/) e un valore FPS per gli effetti nel suo costruttore, quindi chiama l'evento `FrameTick` per tutte le animazioni per riprodurle:

```c#
using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```

Successivamente i fotogrammi generati possono essere compilati per produrre un video. Vedi la sezione [Convertire una presentazione PowerPoint in video](/slides/it/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Animazioni ed effetti supportati**

Durante la conversione di una presentazione PowerPoint in video con Aspose.Slides per .NET, è importante capire quali animazioni ed effetti sono supportati nell'output. Aspose.Slides supporta una vasta gamma di effetti di ingresso, uscita ed enfasi comuni, come dissolvenza, volo, zoom e rotazione. Tuttavia, alcune animazioni avanzate o personalizzate potrebbero non essere pienamente preservate o potrebbero apparire in modo diverso nel video finale. Questa sezione elenca le animazioni ed effetti supportati.

**Ingresso**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Apparire** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolvenza** | ![supported](v.png) | ![supported](v.png) |
| **Volo in** | ![supported](v.png) | ![supported](v.png) |
| **Fluttuare dentro** | ![supported](v.png) | ![supported](v.png) |
| **Dividere** | ![supported](v.png) | ![supported](v.png) |
| **Spazzare** | ![supported](v.png) | ![supported](v.png) |
| **Forma** | ![supported](v.png) | ![supported](v.png) |
| **Ruota** | ![supported](v.png) | ![supported](v.png) |
| **Barre casuali** | ![supported](v.png) | ![supported](v.png) |
| **Crescita e rotazione** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Rotazione** | ![supported](v.png) | ![supported](v.png) |
| **Rimbalzo** | ![supported](v.png) | ![supported](v.png) |

**Enfasi**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Impulso** | ![not supported](x.png) | ![supported](v.png) |
| **Impulso colore** | ![not supported](x.png) | ![supported](v.png) |
| **Oscillazione** | ![supported](v.png) | ![supported](v.png) |
| **Rotazione** | ![supported](v.png) | ![supported](v.png) |
| **Crescita/Riduzione** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturazione** | ![not supported](x.png) | ![supported](v.png) |
| **Scurire** | ![not supported](x.png) | ![supported](v.png) |
| **Schiarire** | ![not supported](x.png) | ![supported](v.png) |
| **Trasparenza** | ![not supported](x.png) | ![supported](v.png) |
| **Colore oggetto** | ![not supported](x.png) | ![supported](v.png) |
| **Colore complementare** | ![not supported](x.png) | ![supported](v.png) |
| **Colore linea** | ![not supported](x.png) | ![supported](v.png) |
| **Colore riempimento** | ![not supported](x.png) | ![supported](v.png) |

**Uscita**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Sparire** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolvenza** | ![supported](v.png) | ![supported](v.png) |
| **Volo fuori** | ![supported](v.png) | ![supported](v.png) |
| **Fluttuare fuori** | ![supported](v.png) | ![supported](v.png) |
| **Dividere** | ![supported](v.png) | ![supported](v.png) |
| **Spazzare** | ![supported](v.png) | ![supported](v.png) |
| **Forma** | ![supported](v.png) | ![supported](v.png) |
| **Barre casuali** | ![supported](v.png) | ![supported](v.png) |
| **Riduzione e rotazione** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Rotazione** | ![supported](v.png) | ![supported](v.png) |
| **Rimbalzo** | ![supported](v.png) | ![supported](v.png) |

**Percorsi di movimento**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linee** | ![supported](v.png) | ![supported](v.png) |
| **Archi** | ![supported](v.png) | ![supported](v.png) |
| **Giri** | ![supported](v.png) | ![supported](v.png) |
| **Forme** | ![supported](v.png) | ![supported](v.png) |
| **Loop** | ![supported](v.png) | ![supported](v.png) |
| **Tracciato personalizzato** | ![supported](v.png) | ![supported](v.png) |

## **Effetti di transizione delle diapositive supportati**

Gli effetti di transizione delle diapositive svolgono un ruolo importante nella creazione di passaggi fluidi e visivamente gradevoli tra le diapositive di un video. Aspose.Slides per .NET supporta una varietà di effetti di transizione comunemente usati per preservare il flusso e lo stile della presentazione originale. Questa sezione evidenzia quali effetti di transizione sono supportati durante il processo di conversione.

**Sottile**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolvenza** | ![supported](v.png) | ![supported](v.png) |
| **Spinta** | ![supported](v.png) | ![supported](v.png) |
| **Trascinamento** | ![supported](v.png) | ![supported](v.png) |
| **Spazzare** | ![supported](v.png) | ![supported](v.png) |
| **Dividere** | ![supported](v.png) | ![supported](v.png) |
| **Rivelare** | ![not supported](x.png) | ![supported](v.png) |
| **Barre casuali** | ![supported](v.png) | ![supported](v.png) |
| **Forma** | ![not supported](x.png) | ![supported](v.png) |
| **Scoprire** | ![not supported](x.png) | ![supported](v.png) |
| **Copertura** | ![supported](v.png) | ![supported](v.png) |
| **Lampo** | ![supported](v.png) | ![supported](v.png) |
| **Strisce** | ![supported](v.png) | ![supported](v.png) |

**Entusiasmante**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Caduta** | ![not supported](x.png) | ![supported](v.png) |
| **Tenda** | ![not supported](x.png) | ![supported](v.png) |
| **Tende** | ![not supported](x.png) | ![supported](v.png) |
| **Vento** | ![not supported](x.png) | ![supported](v.png) |
| **Prestigio** | ![not supported](x.png) | ![supported](v.png) |
| **Frattura** | ![not supported](x.png) | ![supported](v.png) |
| **Schiacciare** | ![not supported](x.png) | ![supported](v.png) |
| **Sbucciare** | ![not supported](x.png) | ![supported](v.png) |
| **Piegatura pagina** | ![not supported](x.png) | ![supported](v.png) |
| **Aereo** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolvi** | ![supported](v.png) | ![supported](v.png) |
| **Scacchiera** | ![not supported](x.png) | ![supported](v.png) |
| **Persiane** | ![not supported](x.png) | ![supported](v.png) |
| **Orologio** | ![supported](v.png) | ![supported](v.png) |
| **Ondulazione** | ![not supported](x.png) | ![supported](v.png) |
| **Favo** | ![not supported](x.png) | ![supported](v.png) |
| **Scintillio** | ![not supported](x.png) | ![supported](v.png) |
| **Vortice** | ![not supported](x.png) | ![supported](v.png) |
| **Strappare** | ![not supported](x.png) | ![supported](v.png) |
| **Scambio** | ![not supported](x.png) | ![supported](v.png) |
| **Capovolgimento** | ![not supported](x.png) | ![supported](v.png) |
| **Galleria** | ![not supported](x.png) | ![supported](v.png) |
| **Cubo** | ![not supported](x.png) | ![supported](v.png) |
| **Porte** | ![not supported](x.png) | ![supported](v.png) |
| **Scatola** | ![not supported](x.png) | ![supported](v.png) |
| **Pettine** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Casuale** | ![not supported](x.png) | ![supported](v.png) |

**Contenuto dinamico**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Panoramica** | ![not supported](x.png) | ![supported](v.png) |
| **Ruota panoramica** | ![supported](v.png) | ![supported](v.png) |
| **Nastro trasportatore** | ![not supported](x.png) | ![supported](v.png) |
| **Rotazione** | ![not supported](x.png) | ![supported](v.png) |
| **Orbita** | ![not supported](x.png) | ![supported](v.png) |
| **Volo attraverso** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**È possibile convertire presentazioni protette da password?**

Sì, Aspose.Slides per .NET consente di lavorare con presentazioni protette da password. Quando si elaborano tali file, è necessario fornire la password corretta affinché la libreria possa accedere al contenuto della presentazione.

**Aspose.Slides per .NET è supportato in soluzioni cloud?**

Sì, Aspose.Slides per .NET può essere integrato in applicazioni e servizi cloud. La libreria è progettata per funzionare in ambienti server, garantendo alte prestazioni e scalabilità per l'elaborazione batch di file.

**Ci sono limitazioni di dimensione per le presentazioni durante la conversione?**

Aspose.Slides per .NET è in grado di gestire presentazioni di dimensioni praticamente illimitate. Tuttavia, quando si lavora con file molto grandi, potrebbero essere necessarie risorse di sistema aggiuntive, ed è talvolta consigliato ottimizzare la presentazione per migliorare le prestazioni.