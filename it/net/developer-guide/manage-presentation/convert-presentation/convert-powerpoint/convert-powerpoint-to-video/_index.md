---
title: Converti le presentazioni PowerPoint in video con .NET
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
description: "Scopri come convertire le presentazioni PowerPoint in video con .NET. Trova esempi di codice C# e tecniche di automazione per semplificare il tuo flusso di lavoro."
---
## **Introduzione**

Convertendo la tua presentazione PowerPoint o OpenDocument in video, ottieni:

**Accessibilità aumentata:** Tutti i dispositivi, indipendentemente dalla piattaforma, sono dotati di lettori video di default, rendendo più semplice per gli utenti aprire o riprodurre video rispetto alle tradizionali applicazioni di presentazione.

**Maggiore portata:** I video ti consentono di raggiungere un pubblico più ampio e presentare le informazioni in un formato più coinvolgente. Sondaggi e statistiche indicano che le persone preferiscono guardare e consumare contenuti video rispetto ad altre forme, rendendo il tuo messaggio più incisivo.

{{% alert color="info" %}} 
Vedi il nostro [**Convertitore PowerPoint in Video Online**](https://products.aspose.app/slides/it/video) perché offre un'implementazione live ed efficace del processo descritto qui.
{{% /alert %}} 

In Aspose.Slides per .NET, abbiamo implementato il supporto alla conversione delle presentazioni in video.

* Usa Aspose.Slides per .NET per generare i fotogrammi dalle diapositive della presentazione a una frequenza di fotogrammi specificata (FPS).
* Quindi, utilizza un'utilità di terze parti come ffmpeg per compilare questi fotogrammi in un video.

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

Questo codice C# dimostra come convertire una presentazione (contenente una forma e due effetti di animazione) in un video:

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

Convertendo una presentazione PowerPoint in video usando Aspose.Slides per .NET, è possibile applicare vari effetti video per migliorare la qualità visiva del risultato. Questi effetti consentono di controllare l'aspetto delle diapositive nel video finale aggiungendo transizioni fluide, animazioni e altri elementi visivi. Questa sezione spiega le opzioni di effetti video disponibili e mostra come applicarli.

{{% alert color="info" %}} 
Vedi:
- [Migliorare le presentazioni PowerPoint con animazioni in C#](https://docs.aspose.com/slides/it/net/powerpoint-animation/)
- [Animazione della forma](https://docs.aspose.com/slides/it/net/shape-animation/)
- [Applicare effetti forma in PowerPoint usando C#](https://docs.aspose.com/slides/it/net/shape-effect/)
{{% /alert %}} 

Le animazioni e le transizioni rendono le presentazioni più coinvolgenti e interessanti — e lo stesso vale per i video. Aggiungiamo un'altra diapositiva e transizione al codice della presentazione precedente:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // Aggiungi una forma sorridente e animala (vedi il codice sopra).

    // Aggiungi una nuova diapositiva e una transizione animata.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Aspose.Slides supporta anche le animazioni di testo. In questo esempio, animiamo i paragrafi sugli oggetti in modo che appaiano uno dopo l'altro, con un ritardo di un secondo tra di essi:

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

## **Classi di conversione video**

Per abilitare le attività di conversione da PowerPoint a video, Aspose.Slides per .NET fornisce le classi [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/net/aspose.slides.export/presentationanimationsgenerator/) e [PresentationPlayer](https://reference.aspose.com/slides/it/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` consente di impostare la dimensione del fotogramma per il video (che sarà creato in seguito) e il valore FPS (fotogrammi al secondo) tramite il suo costruttore. Se passi un'istanza di una presentazione, il suo `Presentation.SlideSize` verrà usato e genera animazioni che [PresentationPlayer](https://reference.aspose.com/slides/it/net/aspose.slides.export/presentationplayer/) utilizza.

Quando le animazioni vengono generate, viene attivato un evento `NewAnimation` per ciascuna animazione successiva, che include un parametro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipresentationanimationplayer/). Questa classe rappresenta un lettore per un'animazione individuale.

Per lavorare con [IPresentationAnimationPlayer](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipresentationanimationplayer/), utilizzi la proprietà [Duration](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipresentationanimationplayer/duration/) (che fornisce la durata completa dell'animazione) e il metodo [SetTimePosition](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Ogni posizione dell'animazione è impostata all'interno dell'intervallo *0 a durata*, e il metodo `GetFrame` restituisce un Bitmap che rappresenta lo stato dell'animazione in quel momento.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

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

            animationPlayer.SetTimePosition(0);        // Lo stato iniziale dell'animazione.
            IImage image = animationPlayer.GetFrame(); // L'immagine dello stato iniziale dell'animazione.

            animationPlayer.SetTimePosition(animationPlayer.Duration); // Lo stato finale dell'animazione.
            IImage lastImage = animationPlayer.GetFrame();             // L'ultimo fotogramma dell'animazione.
            lastImage.Save("last.png");
        };
    }
}
```

Per far riprodurre tutte le animazioni di una presentazione simultaneamente, si utilizza la classe [PresentationPlayer](https://reference.aspose.com/slides/it/net/aspose.slides.export/presentationplayer/). Questa classe accetta un'istanza di [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/net/aspose.slides.export/presentationanimationsgenerator/) e un valore FPS per gli effetti nel suo costruttore, quindi chiama l'evento `FrameTick` per tutte le animazioni per riprodurle:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Quindi i fotogrammi generati possono essere compilati per produrre un video. Vedi la sezione [Convertire una presentazione PowerPoint in video](/slides/it/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Animazioni e effetti supportati**

Quando si converte una presentazione PowerPoint in video usando Aspose.Slides per .NET, è importante capire quali animazioni ed effetti sono supportati nell'output. Aspose.Slides supporta un'ampia gamma di effetti comuni di ingresso, uscita e enfasi, come dissolvenza, ingresso volo, zoom e rotazione. Tuttavia, alcune animazioni avanzate o personalizzate potrebbero non essere completamente preservate o potrebbero apparire diversamente nel video finale. Questa sezione descrive le animazioni ed effetti supportati.

**Ingresso**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Enfasi**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Uscita**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Percorsi di movimento**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Effetti di transizione diapositiva supportati**

Gli effetti di transizione delle diapositive svolgono un ruolo importante nel creare cambiamenti fluidi e visivamente accattivanti tra le diapositive in un video. Aspose.Slides per .NET supporta una varietà di effetti di transizione comunemente usati per aiutare a preservare il flusso e lo stile della presentazione originale. Questa sezione evidenzia quali effetti di transizione sono supportati durante il processo di conversione.

**Sottile**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Eccitante**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Contenuto dinamico**:

| Tipo di animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### È possibile convertire presentazioni protette da password?

Sì, Aspose.Slides per .NET consente di lavorare con presentazioni protette da password. Quando si elaborano questi file, è necessario fornire la password corretta affinché la libreria possa accedere al contenuto della presentazione.

### Aspose.Slides per .NET supporta l'uso in soluzioni cloud?

Sì, Aspose.Slides per .NET può essere integrato in applicazioni e servizi cloud. La libreria è progettata per funzionare in ambienti server, garantendo alte prestazioni e scalabilità per l'elaborazione batch di file.

### Esistono limiti di dimensione per le presentazioni durante la conversione?

Aspose.Slides per .NET è in grado di gestire presentazioni di dimensioni praticamente illimitate. Tuttavia, quando si lavora con file molto grandi, potrebbero essere necessarie risorse di sistema aggiuntive, e talvolta è consigliabile ottimizzare la presentazione per migliorare le prestazioni.