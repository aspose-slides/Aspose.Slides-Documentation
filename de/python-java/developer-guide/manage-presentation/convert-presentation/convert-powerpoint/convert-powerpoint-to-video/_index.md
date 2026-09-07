---
title: PowerPoint-Präsentationen in Python zu Video konvertieren
linktitle: PowerPoint zu Video
type: docs
weight: 130
url: /de/python-java/convert-powerpoint-to-video/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu Video
- Präsentation zu Video
- PPT zu Video
- PPTX zu Video
- PowerPoint zu MP4
- Präsentation zu MP4
- PPT zu MP4
- PPTX zu MP4
- PPT als MP4 speichern
- PPTX als MP4 speichern
- PPT nach MP4 exportieren
- PPTX nach MP4 exportieren
- Videokonvertierung
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "PowerPoint-Präsentationen in MP4-Video in Python über Java konvertieren. Frames mit Aspose.Slides erzeugen und mit FFmpeg kodieren, einschließlich Animationen und Übergängen."
---
## **Übersicht**

Das Konvertieren einer PowerPoint‑ oder OpenDocument‑Präsentation in ein Video ermöglicht es Betrachtern, deren Inhalt in einem Videoplayer anzusehen, ohne eine Präsentationsanwendung zu öffnen. Aspose.Slides for Python via Java rendert Präsentationsanimationen und -übergänge in Bild‑Frames. Ein separater Encoder, wie FFmpeg, kombiniert diese Frames zu einer Videodatei.

{{% alert color="info" title="Note" %}}
Probieren Sie den Online‑[PowerPoint‑zu‑Video‑Konverter](https://products.aspose.app/slides/de/video) aus, um die Konvertierung von Präsentationen zu Video in Aktion zu sehen.
{{% /alert %}}

## **PowerPoint in Video konvertieren**

Die Konvertierung besteht aus zwei Schritten: PNG‑Frames mit einer gewählten Bildrate erzeugen und dann die Bildsequenz als MP4 zu kodieren. Verwenden Sie in beiden Schritten die gleiche Bildrate, um das Timing der Animationen beizubehalten.

Bevor Sie das Beispiel ausführen:

1. Richten Sie [Aspose.Slides for Python via Java](/slides/de/python-java/installation/) ein.
2. Laden Sie [FFmpeg](https://ffmpeg.org/download.html) herunter und stellen Sie die ausführbare Datei im `PATH` bereit. Das Beispiel verwendet eine Build mit dem `libx264`‑Encoder.
3. Führen Sie den folgenden Python‑Code in einem beschreibbaren Verzeichnis aus.

Das Beispiel erstellt eine lächelnde Form mit Eingangs‑ und Ausgangsanimationen, rendert Frames mit 30 FPS und ruft FFmpeg auf, um `output.mp4` zu erzeugen. Ein neuer Frame‑Ordner verhindert, dass Frames aus früheren Durchläufen in das Video aufgenommen werden.

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

Um eine vorhandene Datei zu konvertieren, initialisieren Sie [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) mit ihrem Pfad und lassen Sie die Anweisungen zur Form‑ und Animations‑Erstellung weg.

Der FFmpeg‑Befehl liest eine nummerierte [image sequence](https://ffmpeg.org/ffmpeg-formats.html#image2), füllt ungerade Dimensionen zu geraden Werten auf und schreibt H.264‑Video mit dem Pixel‑Format `yuv420p`. Die Option `-n` verhindert das Überschreiben einer vorhandenen Ausgabedatei. Die erzeugten PNG‑Dateien verbleiben im Frame‑Verzeichnis; entfernen Sie sie, wenn sie nicht mehr benötigt werden.

{{% alert color="info" title="Note" %}}
Dieses Beispiel kodiert nur Bild‑Frames. Es fügt dem Ausgabebild keinen Kommentar oder eingebetteten Präsentations‑Audio hinzu.
{{% /alert %}}

## **Video‑Effekte**

Animationen steuern, wie Folienobjekte erscheinen, sich bewegen oder verschwinden. Übergänge steuern den Wechsel zwischen Folien. Fügen Sie diese Effekte hinzu, bevor Sie Videoframes generieren.

Siehe [PowerPoint Animation](/slides/de/python-java/powerpoint-animation/), [Shape Animation](/slides/de/python-java/shape-animation/), [Shape Effects](/slides/de/python-java/shape-effect/) und [Slide Transitions](/slides/de/python-java/slide-transition/).

### **Folienübergang hinzufügen**

Das folgende eigenständige Beispiel erstellt eine Präsentation mit zwei Folien. Die zweite Folie hat einen magentafarbenen Hintergrund und einen Push‑Übergang. Speichern Sie die Präsentation und verwenden Sie sie anschließend als Eingabe für das obenstehende Frame‑Generierungs‑Beispiel.

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

### **Absätze animieren**

Text kann Absatz für Absatz erscheinen. Dieses Beispiel erstellt drei Absätze mit sequenziellen Fade‑Eingangs­effekten, wobei jeder um eine Sekunde nach dem vorherigen Effekt verzögert wird. Verwenden Sie die gespeicherte Datei `paragraphs.pptx` als Eingabe für das Video‑Konvertierungs‑Beispiel.

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

## **Klassen für Video‑Konvertierung**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationanimationsgenerator/) erzeugt Animationsereignisse für die Folien. Wird er aus einer Präsentation erstellt, verwendet er die Foliengröße der Präsentation für die Frames. Verwenden Sie [setDefaultDelay](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay), um die Standardverzögerung in Millisekunden zu konfigurieren.

[PresentationPlayer](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationplayer/) nimmt die erzeugten Animationen mit der Bildrate, die dem Konstruktor übergeben wird, ab. Registrieren Sie einen Python‑Callback über JPype mit [setFrameTick](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationplayer/#setFrameTick) und rufen Sie dann [run](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationanimationsgenerator/#run) auf, um die Frames zu erzeugen. Das erste Beispiel verwendet einen eigenen nullbasierten Zähler, damit die Dateinamen der Eingabesequenz von FFmpeg entsprechen.

Für einzelne Animationszustände registrieren Sie einen Callback mit [setNewAnimation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation). Der Callback erhält einen Animations‑Player, der zu einem ausgewählten Zeitpunkt positioniert werden kann. Das folgende Beispiel speichert den ersten und letzten Frame jeder erzeugten Animation mit eindeutigen Dateinamen:

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

## **Unterstützte Animationen und Effekte**

Die folgenden Tabellen fassen die Rendering‑Unterstützung zusammen, die im Java‑Konvertierungs‑Artikel beschrieben wird. Vorschau der erzeugten Frames, wenn eine Präsentation Effekte verwendet, die nicht unterstützt werden.

**Eintritt**:

| Animations­typ | Aspose.Slides | PowerPoint |
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

**Betonung**:

| Animations­typ | Aspose.Slides | PowerPoint |
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

**Ausgang**:

| Animations­typ | Aspose.Slides | PowerPoint |
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

**Bewegungspfade**:

| Animations­typ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Yes | Yes |
| **Arcs** | Yes | Yes |
| **Turns** | Yes | Yes |
| **Shapes** | Yes | Yes |
| **Loops** | Yes | Yes |
| **Custom Path** | Yes | Yes |

## **FAQ**

**Erstellt Aspose.Slides eine MP4‑Datei direkt?**

Nein. Aspose.Slides erzeugt Präsentations‑Frames. Verwenden Sie einen Video‑Encoder wie FFmpeg, um sie zu einer MP4‑Datei zu kombinieren.

**Warum spielt das Video schneller oder langsamer als erwartet?**

Verwenden Sie dieselbe FPS‑Rate für die Frame‑Erzeugung und die Eingabebildrate des Encoders. Eine Abweichung ändert die Wiedergabedauer der Bildsequenz.

**Kann ich eine passwortgeschützte Präsentation konvertieren?**

Ja. Geben Sie das richtige Passwort beim [Laden der geschützten Präsentation](/slides/de/python-java/password-protected-presentation/) an und erzeugen Sie dann Frames aus dem geladenen Inhalt.

**Behält dieser Workflow die Präsentations‑Audio bei?**

Die Beispiele exportieren Bild‑Frames, sodass das resultierende Video stumm ist. Um Audio einzubinden, stellen Sie während der Video‑Kodierung einen separaten Audiospur bereit.

**Wie kann ich den temporären Festplattenverbrauch reduzieren?**

Verwenden Sie eine kleinere Frame‑Größe oder eine niedrigere FPS und entfernen Sie die temporären PNG‑Dateien nach erfolgreicher Kodierung. Prüfen Sie die resultierende Videoqualität, wenn Sie eine der Einstellungen reduzieren.