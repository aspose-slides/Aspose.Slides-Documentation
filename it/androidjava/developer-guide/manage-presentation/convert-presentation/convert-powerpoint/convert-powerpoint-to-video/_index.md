---
title: Converti presentazioni PowerPoint in video su Android
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
description: "Scopri come convertire le presentazioni PowerPoint in video con Java. Trova codice di esempio e tecniche di automazione per semplificare il tuo flusso di lavoro."
---
## **Introduzione**

Convertendo la tua presentazione PowerPoint in video, ottieni 

* **Aumento dell'accessibilità:** Tutti i dispositivi (indipendentemente dalla piattaforma) sono dotati di lettori video per impostazione predefinita rispetto alle applicazioni di apertura delle presentazioni, quindi gli utenti trovano più semplice aprire o riprodurre i video.
* **Maggiore portata:** Attraverso i video, puoi raggiungere un vasto pubblico e indirizzarlo con informazioni che altrimenti potrebbero sembrare noiose in una presentazione. La maggior parte di sondaggi e statistiche suggerisce che le persone guardano e consumano video più di altri formati di contenuto, e generalmente preferiscono questo tipo di contenuto.

## **Conversione da PowerPoint a Video in Aspose.Slides**

* Usa **Aspose.Slides** per generare un insieme di fotogrammi (dalle diapositive della presentazione) che corrispondono a un certo FPS (fotogrammi al secondo)
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

3. Esegui il codice Java per convertire PowerPoint in video.

Questo codice Java ti mostra come convertire una presentazione (contenente una figura e due effetti di animazione) in un video:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    // Configura la cartella dei binari ffmpeg. Vedi questa pagina: https://github.com/bramp/ffmpeg-cli-wrapper
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

Puoi applicare animazioni agli oggetti nelle diapositive e utilizzare transizioni tra le diapositive. 

{{% alert color="info" %}} 

Potresti voler vedere questi articoli: [Animazione PowerPoint](https://docs.aspose.com/slides/it/androidjava/powerpoint-animation/), [Animazione Forma](https://docs.aspose.com/slides/it/androidjava/shape-animation/), e [Effetto Forma](https://docs.aspose.com/slides/it/androidjava/shape-effect/).

{{% /alert %}} 

Le animazioni e le transizioni rendono le presentazioni più coinvolgenti e interessanti—e fanno lo stesso per i video. Aggiungiamo un'altra diapositiva e una transizione al codice della presentazione precedente:

```java
import com.aspose.slides.*;
import java.awt.Color;

// La presentazione con la forma sorridente animata creata sopra.
Presentation presentation = new Presentation();
try {
    // Aggiunge una nuova diapositiva e una transizione animata

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides supporta anche l'animazione per i testi. Quindi animiamo i paragrafi sugli oggetti, che appariranno uno dopo l'altro (con il ritardo impostato a un secondo):

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

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

    // Configura la cartella dei binari ffmpeg. Vedi questa pagina: https://github.com/bramp/ffmpeg-cli-wrapper
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

Per consentirti di eseguire operazioni di conversione da PowerPoint a video, Aspose.Slides fornisce le classi [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationanimationsgenerator/) e [PresentationPlayer](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationanimationsgenerator/) ti consente di impostare la dimensione del fotogramma per il video (che sarà creato successivamente) tramite il suo costruttore. Se passi un'istanza della presentazione, verrà usato `Presentation.SlideSize` e genera animazioni che [PresentationPlayer](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationplayer/) utilizza.

Quando le animazioni vengono generate, viene generato un evento `NewAnimation` per ogni animazione successiva, che ha il parametro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationanimationplayer/). Quest'ultimo è una classe che rappresenta un lettore per un'animazione separata.

Per lavorare con [IPresentationAnimationPlayer](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationanimationplayer/), vengono utilizzate la proprietà [Duration](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (la durata completa dell'animazione) e il metodo [SetTimePosition](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) . Ogni posizione dell'animazione è impostata nell'intervallo *0 a durata*, e quindi il metodo `getFrame` restituirà un [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) che corrisponde allo stato dell'animazione in quel momento:

```java
import com.aspose.slides.*;

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
            // bitmap dello stato iniziale dell'animazione
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // stato finale dell'animazione
            // ultimo fotogramma dell'animazione
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // Genera le animazioni. Il callback sopra viene eseguito per ciascuna di esse.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Per far riprodurre tutte le animazioni di una presentazione contemporaneamente, viene utilizzata la classe [PresentationPlayer](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationplayer/). Questa classe prende un'istanza di [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationanimationsgenerator/) e gli FPS per gli effetti nel suo costruttore, quindi richiama l'evento `FrameTick` per tutte le animazioni per avviarne la riproduzione:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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

Successivamente i fotogrammi generati possono essere compilati per produrre un video. Vedi la sezione [Converti PowerPoint in Video](https://docs.aspose.com/slides/it/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animazioni e Effetti Supportati**

**Entrata**:

| Tipo di Animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Apparire** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolvenza** | ![supported](v.png) | ![supported](v.png) |
| **Vola Dentro** | ![supported](v.png) | ![supported](v.png) |
| **Fluttua Dentro** | ![supported](v.png) | ![supported](v.png) |
| **Dividi** | ![supported](v.png) | ![supported](v.png) |
| **Spazzola** | ![supported](v.png) | ![supported](v.png) |
| **Forma** | ![supported](v.png) | ![supported](v.png) |
| **Ruota** | ![supported](v.png) | ![supported](v.png) |
| **Barre Casuali** | ![supported](v.png) | ![supported](v.png) |
| **Crescere e Girare** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Ruotare** | ![supported](v.png) | ![supported](v.png) |
| **Rimbalzo** | ![supported](v.png) | ![supported](v.png) |

**Enfasi**:

| Tipo di Animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Impulso** | ![not supported](x.png) | ![supported](v.png) |
| **Impulso di Colore** | ![not supported](x.png) | ![supported](v.png) |
| **Oscillare** | ![supported](v.png) | ![supported](v.png) |
| **Rotazione** | ![supported](v.png) | ![supported](v.png) |
| **Crescere/Ridurre** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturare** | ![not supported](x.png) | ![supported](v.png) |
| **Scurire** | ![not supported](x.png) | ![supported](v.png) |
| **Illuminare** | ![not supported](x.png) | ![supported](v.png) |
| **Trasparenza** | ![not supported](x.png) | ![supported](v.png) |
| **Colore Oggetto** | ![not supported](x.png) | ![supported](v.png) |
| **Colore Complementare** | ![not supported](x.png) | ![supported](v.png) |
| **Colore Linea** | ![not supported](x.png) | ![supported](v.png) |
| **Colore Riempimento** | ![not supported](x.png) | ![supported](v.png) |

**Uscita**:

| Tipo di Animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Scomparire** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolvenza** | ![supported](v.png) | ![supported](v.png) |
| **Vola Fuori** | ![supported](v.png) | ![supported](v.png) |
| **Fluttua Fuori** | ![supported](v.png) | ![supported](v.png) |
| **Dividi** | ![supported](v.png) | ![supported](v.png) |
| **Spazzola** | ![supported](v.png) | ![supported](v.png) |
| **Forma** | ![supported](v.png) | ![supported](v.png) |
| **Barre Casuali** | ![supported](v.png) | ![supported](v.png) |
| **Rimpicciolire e Girare** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Ruotare** | ![supported](v.png) | ![supported](v.png) |
| **Rimbalzo** | ![supported](v.png) | ![supported](v.png) |

**Percorsi di Movimento**:

| Tipo di Animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linee** | ![supported](v.png) | ![supported](v.png) |
| **Archi** | ![supported](v.png) | ![supported](v.png) |
| **Curvi** | ![supported](v.png) | ![supported](v.png) |
| **Forme** | ![supported](v.png) | ![supported](v.png) |
| **Loop** | ![supported](v.png) | ![supported](v.png) |
| **Percorso Personalizzato** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### È possibile convertire presentazioni protette da password?

Sì, Aspose.Slides consente di lavorare con [presentazioni protette da password](/slides/it/androidjava/password-protected-presentation/). Quando si elaborano questi file, è necessario fornire la password corretta affinché la libreria possa accedere al contenuto della presentazione.

### Aspose.Slides supporta l'uso in soluzioni cloud?

Sì, Aspose.Slides può essere integrato in applicazioni e servizi cloud. La libreria è progettata per funzionare in ambienti server, garantendo alte prestazioni e scalabilità per l'elaborazione batch di file.

### Ci sono limitazioni di dimensione per le presentazioni durante la conversione?

Aspose.Slides è in grado di gestire presentazioni di praticamente qualsiasi dimensione. Tuttavia, quando si lavora con file molto grandi, potrebbero essere richieste risorse di sistema aggiuntive, e a volte è consigliabile ottimizzare la presentazione per migliorare le prestazioni.