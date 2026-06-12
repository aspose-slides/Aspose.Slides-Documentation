---
title: Converti le presentazioni PowerPoint in video su Android
linktitle: PowerPoint in video
type: docs
weight: 130
url: /it/androidjava/convert-powerpoint-to-video/
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
- Android
- Java
- Aspose.Slides
description: "Scopri come convertire le presentazioni PowerPoint in video con Java. Scopri il codice di esempio e le tecniche di automazione per semplificare il tuo flusso di lavoro."
---
## **Introduzione**

Convertendo la tua presentazione PowerPoint in video, ottieni 

* **Aumento dell'accessibilità:** Tutti i dispositivi (indipendentemente dalla piattaforma) sono dotati di lettori video per impostazione predefinita rispetto alle applicazioni per aprire presentazioni, quindi gli utenti trovano più facile aprire o riprodurre i video.
* **Maggiore portata:** Attraverso i video, puoi raggiungere un vasto pubblico e indirizzarlo con informazioni che altrimenti potrebbero sembrare noiose in una presentazione. La maggior parte di sondaggi e statistiche suggerisce che le persone guardano e consumano video più di altri formati di contenuto e generalmente preferiscono questo tipo di contenuto.

{{% alert color="primary" %}} 
Potresti voler controllare il nostro [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/it/conversion/ppt-to-word) perché è un'implementazione live ed efficace del processo descritto qui.
{{% /alert %}} 

## **Conversione di PowerPoint in Video in Aspose.Slides**

Aspose.Slides supporta la conversione da presentazione a video.

* Usa **Aspose.Slides** per generare un set di fotogrammi (dalle diapositive della presentazione) che corrispondono a un certo FPS (fotogrammi al secondo)
* Usa un'utilità di terze parti come **ffmpeg** ([per java](https://github.com/bramp/ffmpeg-cli-wrapper)) per creare un video basato sui fotogrammi. 

### **Converti PowerPoint in Video**

1. Aggiungi questo al tuo file POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Scarica ffmpeg [qui](https://ffmpeg.org/download.html).

4. Esegui il codice Java per convertire PowerPoint in video.

Questo codice Java ti mostra come convertire una presentazione (contenente una figura e due effetti di animazione) in un video:
```java
Presentation presentation = new Presentation();
try {
    // Aggiunge una forma di sorriso e poi la anima
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Configura la cartella dei binari ffmpeg. Vedi questa pagina: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Effetti video**

Puoi applicare animazioni agli oggetti nelle diapositive e usare transizioni tra le diapositive. 

{{% alert color="primary" %}} 
Potresti voler vedere questi articoli: [PowerPoint Animation](https://docs.aspose.com/slides/it/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/it/androidjava/shape-animation/), e [Shape Effect](https://docs.aspose.com/slides/it/androidjava/shape-effect/).
{{% /alert %}} 

Le animazioni e le transizioni rendono le presentazioni più coinvolgenti e interessanti—e fanno lo stesso per i video. Aggiungiamo un'altra diapositiva e transizione al codice per la presentazione precedente:
```java
// Aggiunge una forma di sorriso e la anima

// ...

// Aggiunge una nuova diapositiva e una transizione animata

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides supporta anche l'animazione per i testi. Quindi animiamo i paragrafi sugli oggetti, che appariranno uno dopo l'altro (con il ritardo impostato a un secondo):
```java
Presentation presentation = new Presentation();
try {
    // Aggiunge testo e animazioni
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Configura la cartella dei binari ffmpeg. Vedi questa pagina: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Classi per la Conversione Video**

Per consentirti di eseguire attività di conversione da PowerPoint a video, Aspose.Slides fornisce le classi [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationanimationsgenerator/) e [PresentationPlayer](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationplayer/). 

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationanimationsgenerator/) consente di impostare la dimensione del fotogramma per il video (che verrà creato successivamente) tramite il suo costruttore. Se passi un'istanza della presentazione, `Presentation.SlideSize` verrà usata e genera animazioni che [PresentationPlayer](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationplayer/) utilizza. 

Quando le animazioni vengono generate, viene generato un evento `NewAnimation` per ogni animazione successiva, che ha il parametro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationanimationplayer/). Quest'ultimo è una classe che rappresenta un lettore per un'animazione separata. 

Per lavorare con [IPresentationAnimationPlayer](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationanimationplayer/), vengono usati la proprietà [Duration](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (la durata completa dell'animazione) e il metodo [SetTimePosition](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Ogni posizione dell'animazione è impostata nell'intervallo *0 a duration*, e quindi il metodo `GetFrame` restituirà un BufferedImage che corrisponde allo stato dell'animazione in quel momento:
```java
Presentation presentation = new Presentation();
try {
    // Aggiunge una forma di sorriso e la anima
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // stato iniziale dell'animazione
            try {
                // bitmap dello stato iniziale dell'animazione
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // stato finale dell'animazione
            try {
                // ultimo fotogramma dell'animazione
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Per far riprodurre tutte le animazioni di una presentazione contemporaneamente, viene usata la classe [PresentationPlayer](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationplayer/). Questa classe prende un'istanza di [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationanimationsgenerator/) e gli FPS per gli effetti nel suo costruttore e poi chiama l'evento `FrameTick` per tutte le animazioni per farle eseguire:
```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Successivamente i fotogrammi generati possono essere compilati per produrre un video. Vedi la sezione [Convert PowerPoint to Video](https://docs.aspose.com/slides/it/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animazioni e Effetti Supportati**

**Ingresso**:

| Tipo di Animazione | Aspose.Slides | PowerPoint |
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

| Tipo di Animazione | Aspose.Slides | PowerPoint |
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

| Tipo di Animazione | Aspose.Slides | PowerPoint |
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

| Tipo di Animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**È possibile convertire presentazioni protette da password?**

Sì, Aspose.Slides consente di lavorare con [presentazioni protette da password](/slides/it/androidjava/password-protected-presentation/). Quando si elaborano questi file, è necessario fornire la password corretta affinché la libreria possa accedere al contenuto della presentazione.

**Aspose.Slides supporta l'uso in soluzioni cloud?**

Sì, Aspose.Slides può essere integrato in applicazioni e servizi cloud. La libreria è progettata per funzionare in ambienti server, garantendo alte prestazioni e scalabilità per l'elaborazione batch di file.

**Ci sono limiti di dimensione per le presentazioni durante la conversione?**

Aspose.Slides è in grado di gestire presentazioni di dimensioni praticamente illimitate. Tuttavia, quando si lavora con file molto grandi, potrebbero essere richieste risorse di sistema aggiuntive e talvolta è consigliabile ottimizzare la presentazione per migliorare le prestazioni.