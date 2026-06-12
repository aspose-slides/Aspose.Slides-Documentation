---
title: Converti presentazioni PowerPoint in video con Java
linktitle: PowerPoint in video
type: docs
weight: 130
url: /it/java/convert-powerpoint-to-video/
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
- Java
- Aspose.Slides
description: "Scopri come convertire le presentazioni PowerPoint in video con Java. Trova esempi di codice e tecniche di automazione per ottimizzare il tuo flusso di lavoro."
---
## **Introduzione**

Convertendo la tua presentazione PowerPoint o OpenDocument in video, ottieni:

**Accessibilità aumentata:** Tutti i dispositivi, indipendentemente dalla piattaforma, hanno lettori video preinstallati, rendendo più semplice per gli utenti aprire o riprodurre video rispetto alle tradizionali applicazioni per presentazioni.

**Portata più ampia:** I video ti consentono di raggiungere un pubblico più ampio e presentare le informazioni in un formato più coinvolgente. Sondaggi e statistiche indicano che le persone preferiscono guardare e consumare contenuti video rispetto ad altre forme, rendendo il tuo messaggio più incisivo.

{{% alert color="primary" %}} 

Potresti voler controllare il nostro [**Convertitore online PowerPoint in Video**](https://products.aspose.app/slides/it/conversion/ppt-to-word) perché è un'implementazione reale ed efficace del processo descritto qui.

{{% /alert %}} 

## **Conversione PowerPoint in Video in Aspose.Slides**

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/it/java/aspose-slides-for-java-22-11-release-notes/), abbiamo implementato il supporto per la conversione di presentazioni in video. 

* Usa **Aspose.Slides** per generare una serie di fotogrammi (dalle diapositive della presentazione) che corrispondono a un determinato FPS (fotogrammi al secondo)
* Usa un'utilità di terze parti come **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) per creare un video basato sui fotogrammi. 

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
    // Aggiunge una forma sorridente e poi la anima
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

## **Effetti Video**

Puoi applicare animazioni agli oggetti nelle diapositive e usare transizioni tra le diapositive. 

{{% alert color="primary" %}} 

Potresti voler vedere questi articoli: [Animazione PowerPoint](https://docs.aspose.com/slides/it/java/powerpoint-animation/), [Animazione Forma](https://docs.aspose.com/slides/it/java/shape-animation/), e [Effetto Forma](https://docs.aspose.com/slides/it/java/shape-effect/).

{{% /alert %}} 

Le animazioni e le transizioni rendono le presentazioni più coinvolgenti e interessanti—e lo stesso vale per i video. Aggiungiamo un'altra diapositiva e transizione al codice della presentazione precedente:

```java
// Aggiunge una forma sorridente e la anima

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

## **Classi di Conversione Video**

Per consentirti di eseguire operazioni di conversione PowerPoint in video, Aspose.Slides fornisce le classi [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationanimationsgenerator/) e [PresentationPlayer](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationanimationsgenerator/) ti permette di impostare la dimensione del fotogramma per il video (che verrà creato in seguito) tramite il suo costruttore. Se passi un'istanza della presentazione, verrà usato `Presentation.SlideSize` e genera animazioni che [PresentationPlayer](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationplayer/) utilizza. 

Quando le animazioni vengono generate, viene generato un evento `NewAnimation` per ciascuna animazione successiva, che ha il parametro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationanimationplayer/). Quest'ultima è una classe che rappresenta un lettore per un'animazione separata.

Per lavorare con [IPresentationAnimationPlayer](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationanimationplayer/), vengono usati la proprietà [Duration](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (la durata completa dell'animazione) e il metodo [SetTimePosition](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Ogni posizione dell'animazione è impostata nell'intervallo *0 a durata*, e poi il metodo `GetFrame` restituirà un BufferedImage che corrisponde allo stato dell'animazione in quel momento:

```java
Presentation presentation = new Presentation();
try {
    // Aggiunge una forma sorridente e la anima
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

Per far riprodurre tutte le animazioni di una presentazione contemporaneamente, viene usata la classe [PresentationPlayer](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationplayer/). Questa classe prende un'istanza di [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationanimationsgenerator/) e gli FPS per gli effetti nel costruttore, quindi chiama l'evento `FrameTick` per tutte le animazioni per farle riprodurre:

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

Successivamente i fotogrammi generati possono essere compilati per produrre un video. Vedi la sezione [Converti PowerPoint in Video](https://docs.aspose.com/slides/it/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animazioni e Effetti Supportati**

**Ingresso**:

| Tipo di Animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![non supportato](x.png) | ![supportato](v.png) |
| **Fade** | ![supportato](v.png) | ![supportato](v.png) |
| **Fly In** | ![supportato](v.png) | ![supportato](v.png) |
| **Float In** | ![supportato](v.png) | ![supportato](v.png) |
| **Split** | ![supportato](v.png) | ![supportato](v.png) |
| **Wipe** | ![supportato](v.png) | ![supportato](v.png) |
| **Shape** | ![supportato](v.png) | ![supportato](v.png) |
| **Wheel** | ![supportato](v.png) | ![supportato](v.png) |
| **Random Bars** | ![supportato](v.png) | ![supportato](v.png) |
| **Grow & Turn** | ![non supportato](x.png) | ![supportato](v.png) |
| **Zoom** | ![supportato](v.png) | ![supportato](v.png) |
| **Swivel** | ![supportato](v.png) | ![supportato](v.png) |
| **Bounce** | ![supportato](v.png) | ![supportato](v.png) |

**Enfasi**:

| Tipo di Animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![non supportato](x.png) | ![supportato](v.png) |
| **Color Pulse** | ![non supportato](x.png) | ![supportato](v.png) |
| **Teeter** | ![supportato](v.png) | ![supportato](v.png) |
| **Spin** | ![supportato](v.png) | ![supportato](v.png) |
| **Grow/Shrink** | ![non supportato](x.png) | ![supportato](v.png) |
| **Desaturate** | ![non supportato](x.png) | ![supportato](v.png) |
| **Darken** | ![non supportato](x.png) | ![supportato](v.png) |
| **Lighten** | ![non supportato](x.png) | ![supportato](v.png) |
| **Transparency** | ![non supportato](x.png) | ![supportato](v.png) |
| **Object Color** | ![non supportato](x.png) | ![supportato](v.png) |
| **Complementary Color** | ![non supportato](x.png) | ![supportato](v.png) |
| **Line Color** | ![non supportato](x.png) | ![supportato](v.png) |
| **Fill Color** | ![non supportato](x.png) | ![supportato](v.png) |

**Uscita**:

| Tipo di Animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![non supportato](x.png) | ![supportato](v.png) |
| **Fade** | ![supportato](v.png) | ![supportato](v.png) |
| **Fly Out** | ![supportato](v.png) | ![supportato](v.png) |
| **Float Out** | ![supportato](v.png) | ![supportato](v.png) |
| **Split** | ![supportato](v.png) | ![supportato](v.png) |
| **Wipe** | ![supportato](v.png) | ![supportato](v.png) |
| **Shape** | ![supportato](v.png) | ![supportato](v.png) |
| **Random Bars** | ![supportato](v.png) | ![supportato](v.png) |
| **Shrink & Turn** | ![non supportato](x.png) | ![supportato](v.png) |
| **Zoom** | ![supportato](v.png) | ![supportato](v.png) |
| **Swivel** | ![supportato](v.png) | ![supportato](v.png) |
| **Bounce** | ![supportato](v.png) | ![supportato](v.png) |

**Percorsi di Movimento**:

| Tipo di Animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supportato](v.png) | ![supportato](v.png) |
| **Arcs** | ![supportato](v.png) | ![supportato](v.png) |
| **Turns** | ![supportato](v.png) | ![supportato](v.png) |
| **Shapes** | ![supportato](v.png) | ![supportato](v.png) |
| **Loops** | ![supportato](v.png) | ![supportato](v.png) |
| **Custom Path** | ![supportato](v.png) | ![supportato](v.png) |

## **FAQ**

**È possibile convertire presentazioni protette da password?**

Sì, Aspose.Slides consente di lavorare con [presentazioni protette da password](/slides/it/java/password-protected-presentation/). Quando si elaborano tali file, è necessario fornire la password corretta affinché la libreria possa accedere al contenuto della presentazione.

**Aspose.Slides supporta l'uso in soluzioni cloud?**

Sì, Aspose.Slides può essere integrato in applicazioni e servizi cloud. La libreria è progettata per funzionare in ambienti server, garantendo alte prestazioni e scalabilità per l'elaborazione batch di file.

**Ci sono limitazioni di dimensione per le presentazioni durante la conversione?**

Aspose.Slides è in grado di gestire presentazioni di dimensioni praticamente illimitate. Tuttavia, quando si lavorano con file molto grandi, potrebbero essere necessarie ulteriori risorse di sistema e talvolta è consigliabile ottimizzare la presentazione per migliorare le prestazioni.