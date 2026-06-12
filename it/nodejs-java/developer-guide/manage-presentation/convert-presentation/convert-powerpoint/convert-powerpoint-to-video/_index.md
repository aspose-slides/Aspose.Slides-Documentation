---
title: Converti le presentazioni PowerPoint in video in JavaScript
linktitle: PowerPoint in video
type: docs
weight: 130
url: /it/nodejs-java/convert-powerpoint-to-video/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come convertire le presentazioni PowerPoint in video con JavaScript. Trova esempi di codice e tecniche di automazione per ottimizzare il tuo flusso di lavoro."
---
## **Introduzione**

Convertendo la tua presentazione PowerPoint in video, ottieni 

* **Aumento dell'accessibilità:** Tutti i dispositivi (indipendentemente dalla piattaforma) sono equipaggiati con lettori video di default rispetto alle applicazioni di apertura delle presentazioni, quindi gli utenti trovano più semplice aprire o riprodurre i video.
* **Maggiore portata:** Attraverso i video, puoi raggiungere un ampio pubblico e mirare a loro con informazioni che altrimenti potrebbero sembrare noiose in una presentazione. La maggior parte di sondaggi e statistiche suggerisce che le persone guardano e consumano video più di altre forme di contenuto, e generalmente preferiscono questo tipo di contenuto.

{{% alert color="primary" %}} 

Potresti voler provare il nostro [**Convertitore online PowerPoint in Video**](https://products.aspose.app/slides/it/conversion/ppt-to-word) poiché è un'implementazione live ed efficace del processo descritto qui.

{{% /alert %}} 

## **Conversione da PowerPoint a Video in Aspose.Slides**

Aspose.Slides supporta la conversione da presentazione a video.

* Usa **Aspose.Slides** per generare un insieme di fotogrammi (dalle diapositive della presentazione) che corrispondono a un certo FPS (frame al secondo)
* Usa un'utilità di terze parti come **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) per creare un video basato sui fotogrammi. 

### **Converti PowerPoint in Video**

1. Scarica ffmpeg [qui](https://ffmpeg.org/download.html).

2. Esegui il codice JavaScript di conversione da PowerPoint a video.

Questo codice JavaScript mostra come convertire una presentazione (contenente una figura e due effetti di animazione) in video:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Aggiunge una forma sorridente e poi la anima
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Configura la cartella dei binari ffmpeg. Vedi questa pagina: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Effetti Video**

Puoi applicare animazioni agli oggetti sulle diapositive e usare transizioni tra le diapositive. 

{{% alert color="primary" %}} 

Potresti voler consultare questi articoli: [Animazione PowerPoint](https://docs.aspose.com/slides/it/nodejs-java/powerpoint-animation/), [Animazione Forma](https://docs.aspose.com/slides/it/nodejs-java/shape-animation/), e [Effetto Forma](https://docs.aspose.com/slides/it/nodejs-java/shape-effect/).

{{% /alert %}} 

Le animazioni e le transizioni rendono le presentazioni più coinvolgenti e interessanti—e lo stesso vale per i video. Aggiungiamo un'altra diapositiva e una transizione al codice della presentazione precedente:

```javascript
// Aggiunge una forma sorridente e la anima
// ...
// Aggiunge una nuova diapositiva e una transizione animata
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Aspose.Slides supporta anche l'animazione per i testi. Quindi animiamo i paragrafi sugli oggetti, che appariranno uno dopo l'altro (con un ritardo impostato a un secondo):

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Aggiunge testo e animazioni
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Configura la cartella dei binari ffmpeg. Vedi questa pagina: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Classi di Conversione Video**

Per consentirti di eseguire operazioni di conversione da PowerPoint a video, Aspose.Slides fornisce le classi [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationanimationsgenerator/) e [PresentationPlayer](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationanimationsgenerator/) ti permette di impostare la dimensione del fotogramma per il video (che sarà creato in seguito) tramite il suo costruttore. Se passi un'istanza della presentazione, verrà usato `Presentation.getSlideSize` e genera animazioni che [PresentationPlayer](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationplayer/) utilizza.

Quando le animazioni sono generate, viene generato un evento `NewAnimation` per ogni animazione successiva, che ha il parametro del lettore di animazione della presentazione. Quest'ultimo è una classe che rappresenta un lettore per un'animazione separata.

Per lavorare con il lettore di animazione della presentazione, vengono usati i metodi `getDuration` (la durata totale dell'animazione) e `setTimePosition`. Ogni posizione dell'animazione è impostata nell'intervallo *0 to duration*, e poi il metodo `getFrame` restituirà un BufferedImage che corrisponde allo stato dell'animazione in quel momento:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Aggiunge una forma sorridente e la anima
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// stato iniziale dell'animazione
            try {
                // bitmap dello stato iniziale dell'animazione
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// stato finale dell'animazione
            try {
                // ultimo fotogramma dell'animazione
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Per far riprodurre tutte le animazioni di una presentazione contemporaneamente, viene usata la classe [PresentationPlayer](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationplayer/). Questa classe prende un'istanza di [PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationanimationsgenerator/) e un FPS per gli effetti nel suo costruttore e poi chiama l'evento `FrameTick` per tutte le animazioni per farle riprodurre:

```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Quindi i fotogrammi generati possono essere compilati per produrre un video. Vedi la sezione [Convert PowerPoint to Video](https://docs.aspose.com/slides/it/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animazioni ed Effetti Supportati**

**Ingresso**:

| Tipo di Animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Apparire** | ![non supportato](x.png) | ![supportato](v.png) |
| **Dissolvenza** | ![supportato](v.png) | ![supportato](v.png) |
| **Volare Dentro** | ![supportato](v.png) | ![supportato](v.png) |
| **Fluttuare Dentro** | ![supportato](v.png) | ![supportato](v.png) |
| **Dividere** | ![supportato](v.png) | ![supportato](v.png) |
| **Spazzare** | ![supportato](v.png) | ![supportato](v.png) |
| **Forma** | ![supportato](v.png) | ![supportato](v.png) |
| **Ruota** | ![supportato](v.png) | ![supportato](v.png) |
| **Barre Casuali** | ![supportato](v.png) | ![supportato](v.png) |
| **Crescere e Ruotare** | ![non supportato](x.png) | ![supportato](v.png) |
| **Zoom** | ![supportato](v.png) | ![supportato](v.png) |
| **Ruotare** | ![supportato](v.png) | ![supportato](v.png) |
| **Rimbalzo** | ![supportato](v.png) | ![supportato](v.png) |

**Enfasi**:

| Tipo di Animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Impulso** | ![non supportato](x.png) | ![supportato](v.png) |
| **Impulso di Colore** | ![non supportato](x.png) | ![supportato](v.png) |
| **Oscillazione** | ![supportato](v.png) | ![supportato](v.png) |
| **Rotazione** | ![supportato](v.png) | ![supportato](v.png) |
| **Crescere/Ridurre** | ![non supportato](x.png) | ![supportato](v.png) |
| **Desaturare** | ![non supportato](x.png) | ![supportato](v.png) |
| **Scurire** | ![non supportato](x.png) | ![supportato](v.png) |
| **Schiarire** | ![non supportato](x.png) | ![supportato](v.png) |
| **Trasparenza** | ![non supportato](x.png) | ![supportato](v.png) |
| **Colore Oggetto** | ![non supportato](x.png) | ![supportato](v.png) |
| **Colore Complementare** | ![non supportato](x.png) | ![supportato](v.png) |
| **Colore Linea** | ![non supportato](x.png) | ![supportato](v.png) |
| **Colore Riempimento** | ![non supportato](x.png) | ![supportato](v.png) |

**Uscita**:

| Tipo di Animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Scomparire** | ![non supportato](x.png) | ![supportato](v.png) |
| **Dissolvenza** | ![supportato](v.png) | ![supportato](v.png) |
| **Volare Via** | ![supportato](v.png) | ![supportato](v.png) |
| **Fluttuare Via** | ![supportato](v.png) | ![supportato](v.png) |
| **Dividere** | ![supportato](v.png) | ![supportato](v.png) |
| **Spazzare** | ![supportato](v.png) | ![supportato](v.png) |
| **Forma** | ![supportato](v.png) | ![supportato](v.png) |
| **Barre Casuali** | ![supportato](v.png) | ![supportato](v.png) |
| **Ridurre e Ruotare** | ![non supportato](x.png) | ![supportato](v.png) |
| **Zoom** | ![supportato](v.png) | ![supportato](v.png) |
| **Ruotare** | ![supportato](v.png) | ![supportato](v.png) |
| **Rimbalzo** | ![supportato](v.png) | ![supportato](v.png) |

**Percorsi di Movimento**:

| Tipo di Animazione | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linee** | ![supportato](v.png) | ![supportato](v.png) |
| **Archi** | ![supportato](v.png) | ![supportato](v.png) |
| **Curve** | ![supportato](v.png) | ![supportato](v.png) |
| **Forme** | ![supportato](v.png) | ![supportato](v.png) |
| **Cicli** | ![supportato](v.png) | ![supportato](v.png) |
| **Percorso Personalizzato** | ![supportato](v.png) | ![supportato](v.png) |

## **FAQ**

**È possibile convertire presentazioni protette da password?**

Sì, Aspose.Slides consente di lavorare con presentazioni protette da password. Quando si elaborano questi file, è necessario fornire la password corretta affinché la libreria possa accedere al contenuto della presentazione.

**Aspose.Slides supporta l'uso in soluzioni cloud?**

Sì, Aspose.Slides può essere integrato in applicazioni e servizi cloud. La libreria è progettata per funzionare in ambienti server, garantendo alte prestazioni e scalabilità per l'elaborazione batch di file.

**Ci sono limitazioni di dimensione per le presentazioni durante la conversione?**

Aspose.Slides è in grado di gestire presentazioni di dimensioni praticamente illimitate. Tuttavia, quando si lavora con file molto grandi, potrebbero essere necessarie risorse di sistema aggiuntive e talvolta è consigliabile ottimizzare la presentazione per migliorare le prestazioni.