---
title: Converti le presentazioni PowerPoint in video con Python
linktitle: PowerPoint in Video
type: docs
weight: 130
url: /it/python-java/convert-powerpoint-to-video/
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
- Python
- Java
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in video MP4 con Python via Java. Genera i fotogrammi con Aspose.Slides e codificali con FFmpeg, includendo animazioni e transizioni."
---
## **Panoramica**

Convertire una presentazione PowerPoint o OpenDocument in video consente agli spettatori di visualizzare il suo contenuto in un lettore video senza aprire un'applicazione di presentazione. Aspose.Slides per Python via Java rende le animazioni e le transizioni della presentazione in fotogrammi immagine. Un codificatore separato, come FFmpeg, combina tali fotogrammi in un file video.

{{% alert color="info" title="Note" %}}
Prova il [convertitore online PowerPoint in Video](https://products.aspose.app/slides/it/video) per vedere la conversione da presentazione a video in azione.
{{% /alert %}}

## **Converti PowerPoint in Video**

La conversione ha due fasi: generare i fotogrammi PNG a una frequenza di fotogrammi scelta, quindi codificare la sequenza di immagini come MP4. Usa la stessa frequenza di fotogrammi in entrambe le fasi per preservare la sincronizzazione delle animazioni.

Prima di eseguire l'esempio:

1. Installa [Aspose.Slides per Python via Java](/slides/it/python-java/installation/).
2. Scarica [FFmpeg](https://ffmpeg.org/download.html) e rendi l'eseguibile disponibile nel `PATH`. L'esempio utilizza una build con il codificatore `libx264`.
3. Esegui il seguente codice Python in una directory scrivibile.

L'esempio crea una forma sorridente con animazioni di ingresso e uscita, rende i fotogrammi a 30 FPS e chiama FFmpeg per creare `output.mp4`. Una nuova cartella di fotogrammi impedisce che i fotogrammi di esecuzioni precedenti vengano inclusi nel video.

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

Per convertire un file esistente, inizializza [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) con il suo percorso e ometti le istruzioni di creazione della forma e dell'animazione.

Il comando FFmpeg legge una [sequenza di immagini numerata](https://ffmpeg.org/ffmpeg-formats.html#image2), arrotonda le dimensioni dispari a valori pari e scrive un video H.264 con il formato pixel `yuv420p`. L'opzione `-n` impedisce di sovrascrivere un file di output esistente. I file PNG generati rimangono nella cartella dei fotogrammi; rimuovili quando non sono più necessari.

{{% alert color="info" title="Note" %}}
Questo esempio codifica solo i fotogrammi immagine. Non aggiunge narrazione né audio incorporato della presentazione al video di output.
{{% /alert %}}

## **Effetti Video**

Le animazioni controllano come gli oggetti della diapositiva appaiono, si muovono o scompaiono. Le transizioni controllano il cambiamento tra le diapositive. Aggiungi questi effetti prima di generare i fotogrammi video.

Vedi [Animazione PowerPoint](/slides/it/python-java/powerpoint-animation/), [Animazione Forma](/slides/it/python-java/shape-animation/), [Effetti Forma](/slides/it/python-java/shape-effect/), e [Transizioni Diapositiva](/slides/it/python-java/slide-transition/).

### **Aggiungi una Transizione di Diapositiva**

Il seguente esempio autonomo crea una presentazione con due diapositive. La seconda diapositiva ha uno sfondo magenta e una transizione push. Salva la presentazione, quindi usala come input per l'esempio di generazione dei fotogrammi sopra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Anima i Paragrafi**

Il testo può apparire paragrafo per paragrafo. Questo esempio crea tre paragrafi con effetti di ingresso a dissolvenza sequenziali, ciascuno ritardato di un secondo rispetto all'effetto precedente. Usa il file `paragraphs.pptx` salvato come input per l'esempio di conversione video.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Classi di Conversione Video**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationanimationsgenerator/) genera gli eventi di animazione per le diapositive. Costruirlo a partire da una presentazione utilizza le dimensioni della diapositiva della presentazione per i fotogrammi. Usa [setDefaultDelay](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) per configurare il ritardo predefinito in millisecondi.

[PresentationPlayer](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationplayer/) campiona le animazioni generate alla frequenza di fotogrammi fornita al suo costruttore. Registra una callback Python tramite JPype con [setFrameTick](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationplayer/#setFrameTick), quindi chiama [run](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationanimationsgenerator/#run) per generare i fotogrammi. Il primo esempio utilizza il proprio contatore a base zero in modo che i nomi dei file corrispondano alla sequenza di input di FFmpeg.

Per gli stati di animazione individuali, registra una callback con [setNewAnimation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation). La callback riceve un player di animazione che può essere posizionato a un tempo selezionato. Il seguente esempio salva il primo e l'ultimo fotogramma di ogni animazione generata con nomi di file unici:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **Animazioni ed Effetti Supportati**

Le tabelle seguenti riassumono il supporto di rendering descritto nell'articolo di conversione Java. Visualizza in anteprima i fotogrammi generati quando una presentazione utilizza effetti non supportati.

**Ingresso**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly In** | Yes | Yes |
| **Float In** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Wheel** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Grow & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**Enfasi**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | No | Yes |
| **Color Pulse** | No | Yes |
| **Teeter** | Yes | Yes |
| **Spin** | Yes | Yes |
| **Grow/Shrink** | No | Yes |
| **Desaturate** | No | Yes |
| **Darken** | No | Yes |
| **Lighten** | No | Yes |
| **Transparency** | No | Yes |
| **Object Color** | No | Yes |
| **Complementary Color** | No | Yes |
| **Line Color** | No | Yes |
| **Fill Color** | No | Yes |

**Uscita**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly Out** | Yes | Yes |
| **Float Out** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Shrink & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**Percorsi di Movimento**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Yes | Yes |
| **Arcs** | Yes | Yes |
| **Turns** | Yes | Yes |
| **Shapes** | Yes | Yes |
| **Loops** | Yes | Yes |
| **Custom Path** | Yes | Yes |

## **FAQ**

**Aspose.Slides crea direttamente un file MP4?**

No. Aspose.Slides genera i fotogrammi della presentazione. Usa un codificatore video come FFmpeg per combinarli in un file MP4.

**Perché il video viene riprodotto più veloce o più lento del previsto?**

Usa lo stesso FPS per la generazione dei fotogrammi e la frequenza di fotogrammi di input del codificatore. Una discrepanza modifica la durata della riproduzione della sequenza di immagini.

**Posso convertire una presentazione protetta da password?**

Sì. Fornisci la password corretta quando [carichi la presentazione protetta](/slides/it/python-java/password-protected-presentation/), quindi genera i fotogrammi dal contenuto caricato.

**Questo flusso di lavoro preserva l'audio della presentazione?**

Gli esempi esportano solo fotogrammi immagine, quindi il video risultante è silenzioso. Per includere l'audio, fornisci una traccia audio separata durante la codifica video.

**Come posso ridurre l'uso temporaneo del disco?**

Usa una dimensione di fotogramma più piccola o un FPS più basso e rimuovi i file PNG temporanei dopo una codifica riuscita. Verifica la qualità del video risultante quando riduci una delle due impostazioni.