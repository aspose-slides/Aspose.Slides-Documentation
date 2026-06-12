---
title: Convertire le presentazioni PowerPoint in video con Python
linktitle: PowerPoint in video
type: docs
weight: 130
url: /it/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint in video
- convertire PowerPoint in video
- presentazione in video
- convertire presentazione in video
- PPT in video
- convertire PPT in video
- PPTX in video
- convertire PPTX in video
- ODP in video
- convertire ODP in video
- PowerPoint in MP4
- convertire PowerPoint in MP4
- presentazione in MP4
- convertire presentazione in MP4
- PPT in MP4
- convertire PPT in MP4
- PPTX in MP4
- convertire PPTX in MP4
- conversione di PowerPoint in video
- conversione di presentazione in video
- conversione di PPT in video
- conversione di PPTX in video
- conversione di ODP in video
- conversione video con Python
- PowerPoint
- Python
- Aspose.Slides
description: "Scopri come convertire presentazioni PowerPoint e OpenDocument in video usando Python. Scopri esempi di codice e tecniche di automazione per ottimizzare il tuo flusso di lavoro."
---
## **Introduzione**

Convertendo la tua presentazione PowerPoint o OpenDocument in video, ottieni:

**Accessibilità aumentata:** Tutti i dispositivi, indipendentemente dalla piattaforma, sono dotati di lettori video di default, rendendo più facile per gli utenti aprire o riprodurre video rispetto alle tradizionali applicazioni di presentazione.

**Portata più ampia:** I video ti permettono di raggiungere un pubblico più ampio e presentare le informazioni in un formato più coinvolgente. Indagini e statistiche indicano che le persone preferiscono guardare e consumare contenuti video rispetto ad altri formati, rendendo il tuo messaggio più incisivo.

{{% alert color="primary" %}} 

Dai un'occhiata al nostro **Convertitore online PowerPoint in Video** perché offre un'implementazione reale ed efficace del processo descritto qui.

{{% /alert %}} 

In [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/it/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/), abbiamo implementato il supporto per la conversione delle presentazioni in video.

* Usa Aspose.Slides for Python per generare fotogrammi dalle diapositive della presentazione a una frequenza specificata (FPS).
* Quindi, utilizza un'utilità di terze parti come ffmpeg per compilare questi fotogrammi in un video.

## **Convertire una presentazione PowerPoint in video**

1. Usa il comando pip install per aggiungere Aspose.Slides for Python al tuo progetto: `pip install aspose-slides==24.4.0`
2. Scarica ffmpeg da [qui](https://ffmpeg.org/download.html) o installalo tramite il gestore di pacchetti.
3. Assicurati che ffmpeg sia nel `PATH`. In caso contrario, avvia ffmpeg usando il percorso completo del binario (ad esempio `C:\ffmpeg\ffmpeg.exe` su Windows o `/opt/ffmpeg/ffmpeg` su Linux).
4. Esegui il codice di conversione da PowerPoint a video.

Questo codice Python dimostra come convertire una presentazione (contenente una forma e due effetti di animazione) in un video:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```

## **Effetti video**

Convertendo una presentazione PowerPoint in video usando Aspose.Slides for Python, puoi applicare vari effetti video per migliorare la qualità visiva dell'output. Questi effetti ti consentono di controllare l'aspetto delle diapositive nel video finale aggiungendo transizioni fluide, animazioni e altri elementi visivi. Questa sezione spiega le opzioni di effetto video disponibili e mostra come applicarle.

{{% alert color="primary" %}} 

Vedi [Animazione PowerPoint](https://docs.aspose.com/slides/it/python-net/powerpoint-animation/), [Animazione forma](https://docs.aspose.com/slides/it/python-net/shape-animation/), e [Effetto forma](https://docs.aspose.com/slides/it/python-net/shape-effect/).

{{% /alert %}} 

Le animazioni e le transizioni rendono le presentazioni più coinvolgenti e interessanti — e lo stesso vale per i video. Aggiungiamo un'altra diapositiva e una transizione al codice della presentazione precedente:

```python
import aspose.pydrawing as drawing

# Aggiungi una forma sorridente e animala.
# ...

# Aggiungi una nuova diapositiva e una transizione animata.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides for Python supporta anche le animazioni di testo. In questo esempio, animiamo i paragrafi sugli oggetti in modo che appaiano uno dopo l'altro, con un ritardo di un secondo tra di loro:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Aggiungi testo e animazioni.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # Converti i fotogrammi in video.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **Classi di conversione video**

Per abilitare le attività di conversione da PowerPoint a video, Aspose.Slides for Python fornisce il [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/presentationenumerableframesgenerator/).

`PresentationEnumerableFramesGenerator` ti consente di impostare la dimensione del fotogramma per il video (che sarà creato successivamente) e il valore FPS (fotogrammi al secondo) tramite il suo costruttore. Se passi un'istanza di una presentazione, verrà utilizzato il suo `Presentation.SlideSize`.

Per far riprodurre tutte le animazioni di una presentazione contemporaneamente, usa il metodo `PresentationEnumerableFramesGenerator.enumerate_frames`. Questo metodo prende una collezione di diapositive e restituisce sequenzialmente [EnumerableFrameArgs](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/enumerableframeargs/). Poi, usa `EnumerableFrameArgs.get_frame()` per ottenere ogni fotogramma video.

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

Le fotogrammi generate possono quindi essere compilate in un video. Per ulteriori dettagli, consulta la sezione [Convert PowerPoint to Video](https://docs.aspose.com/slides/it/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animazioni ed effetti supportati**

Convertendo una presentazione PowerPoint in video usando Aspose.Slides for Python, è importante capire quali animazioni ed effetti sono supportati nell'output. Aspose.Slides supporta un'ampia gamma di effetti comuni di ingresso, uscita e enfasi come dissolvenza, ingresso volante, zoom e rotazione. Tuttavia, alcune animazioni avanzate o personalizzate potrebbero non essere completamente preservate o potrebbero apparire diversamente nel video finale. Questa sezione elenca le animazioni ed effetti supportati.

**Ingresso**:

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Effetti di transizione delle diapositive supportati**

Gli effetti di transizione delle diapositive svolgono un ruolo importante nel creare cambiamenti fluidi e visivamente accattivanti tra le diapositive in un video. Aspose.Slides for Python supporta una varietà di effetti di transizione comunemente usati per aiutare a preservare il flusso e lo stile della tua presentazione originale. Questa sezione evidenzia quali effetti di transizione sono supportati durante il processo di conversione.

**Sottile**:

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **Domande frequenti**

**È possibile convertire presentazioni protette da password?**

Sì, Aspose.Slides for Python permette di lavorare con presentazioni protette da password. Quando si elaborano tali file, è necessario fornire la password corretta affinché la libreria possa accedere al contenuto della presentazione.

**Aspose.Slides for Python supporta l'uso in soluzioni cloud?**

Sì, Aspose.Slides for Python può essere integrato in applicazioni e servizi cloud. La libreria è progettata per funzionare in ambienti server, garantendo alte prestazioni e scalabilità per l'elaborazione batch di file.

**Ci sono limiti di dimensione per le presentazioni durante la conversione?**

Aspose.Slides for Python è in grado di gestire presentazioni di praticamente qualsiasi dimensione. Tuttavia, quando si lavora con file molto grandi, potrebbero essere necessarie risorse di sistema aggiuntive, ed è talvolta consigliato ottimizzare la presentazione per migliorare le prestazioni.