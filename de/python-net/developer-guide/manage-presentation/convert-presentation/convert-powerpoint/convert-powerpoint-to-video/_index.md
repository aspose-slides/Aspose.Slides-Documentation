---
title: PowerPoint-Präsentationen in Video mit Python konvertieren
linktitle: PowerPoint zu Video
type: docs
weight: 130
url: /de/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint zu Video
- PowerPoint zu Video konvertieren
- Präsentation zu Video
- Präsentation zu Video konvertieren
- PPT zu Video
- PPT zu Video konvertieren
- PPTX zu Video
- PPTX zu Video konvertieren
- ODP zu Video
- ODP zu Video konvertieren
- PowerPoint zu MP4
- PowerPoint zu MP4 konvertieren
- Präsentation zu MP4
- Präsentation zu MP4 konvertieren
- PPT zu MP4
- PPT zu MP4 konvertieren
- PPTX zu MP4
- PPTX zu MP4 konvertieren
- PowerPoint-zu-Video-Konvertierung
- Präsentation-zu-Video-Konvertierung
- PPT-zu-Video-Konvertierung
- PPTX-zu-Video-Konvertierung
- ODP-zu-Video-Konvertierung
- Python-Video-Konvertierung
- PowerPoint
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen mit Python in Video konvertieren. Entdecken Sie Beispielcode und Automatisierungstechniken, um Ihren Workflow zu optimieren."
---

## **Überblick**

Durch die Konvertierung Ihrer PowerPoint‑ oder OpenDocument‑Präsentation in ein Video erhalten Sie:

**Erhöhte Barrierefreiheit:** Alle Geräte, unabhängig vom Plattformtyp, verfügen standardmäßig über Videoplayer, sodass es für Nutzer einfacher ist, Videos zu öffnen oder abzuspielen im Vergleich zu herkömmlichen Präsentationsanwendungen.

**Größere Reichweite:** Videos ermöglichen es Ihnen, ein größeres Publikum zu erreichen und Informationen in einem ansprechenderen Format zu präsentieren. Umfragen und Statistiken zeigen, dass Menschen lieber Video‑Inhalte ansehen und konsumieren als andere Formen, wodurch Ihre Botschaft wirkungsvoller wird.

{{% alert color="primary" %}} 

Schauen Sie sich unseren [**PowerPoint‑zu‑Video‑Online‑Konverter**](https://products.aspose.app/slides/video) an, weil er eine Live‑ und effektive Umsetzung des hier beschriebenen Prozesses bietet.

{{% /alert %}} 

In [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/) haben wir die Unterstützung für die Konvertierung von Präsentationen in Video implementiert.

* Verwenden Sie Aspose.Slides für Python, um Frames aus den Präsentations‑Folien mit einer festgelegten Bildrate (FPS) zu erzeugen.  
* Anschließend können Sie ein Drittanbieter‑Tool wie ffmpeg verwenden, um diese Frames zu einem Video zusammenzufügen.

## **PowerPoint‑Präsentation in Video konvertieren**

1. Verwenden Sie den pip‑Install‑Befehl, um Aspose.Slides für Python zu Ihrem Projekt hinzuzufügen: `pip install aspose-slides==24.4.0`  
2. Laden Sie ffmpeg von [hier](https://ffmpeg.org/download.html) herunter oder installieren Sie es über den Paket‑Manager.  
3. Stellen Sie sicher, dass ffmpeg im `PATH` liegt. Andernfalls starten Sie ffmpeg mit dem vollständigen Pfad zur Binärdatei (z. B. `C:\ffmpeg\ffmpeg.exe` unter Windows oder `/opt/ffmpeg/ffmpeg` unter Linux).  
4. Führen Sie den PowerPoint‑zu‑Video‑Konvertierungscode aus.

Dieser Python‑Code demonstriert, wie man eine Präsentation (die eine Form und zwei Animationseffekte enthält) in ein Video konvertiert:
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


## **Video‑Effekte**

Beim Konvertieren einer PowerPoint‑Präsentation zu Video mit Aspose.Slides für Python können Sie verschiedene Video‑Effekte anwenden, um die visuelle Qualität der Ausgabe zu verbessern. Diese Effekte ermöglichen Ihnen, das Erscheinungsbild der Folien im finalen Video zu steuern, indem Sie sanfte Übergänge, Animationen und weitere visuelle Elemente hinzufügen. Dieser Abschnitt erklärt die verfügbaren Video‑Effekt‑Optionen und zeigt, wie Sie sie anwenden.

{{% alert color="primary" %}} 

Siehe [PowerPoint‑Animation](https://docs.aspose.com/slides/python-net/powerpoint-animation/), [Shape‑Animation](https://docs.aspose.com/slides/python-net/shape-animation/) und [Shape‑Effect](https://docs.aspose.com/slides/python-net/shape-effect/).

{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter — und das Gleiche gilt für Videos. Fügen wir der vorherigen Präsentation einen weiteren Folie und Übergang zum Code hinzu:
```python
import aspose.pydrawing as drawing

# Smiley-Form hinzufügen und animieren.
# ...

# Neue Folie hinzufügen und einen animierten Übergang.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```


Aspose.Slides für Python unterstützt außerdem Textanimationen. In diesem Beispiel animieren wir Absätze auf Objekten, sodass sie nacheinander erscheinen, mit einer Verzögerung von einer Sekunde zwischen ihnen:
```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Text und Animationen hinzufügen.
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

    # Frames in Video konvertieren.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```


## **Klassen zur Video‑Konvertierung**

Um PowerPoint‑zu‑Video‑Konvertierungsaufgaben zu ermöglichen, stellt Aspose.Slides für Python den [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableframesgenerator/) bereit.

`PresentationEnumerableFramesGenerator` ermöglicht es Ihnen, die Frame‑Größe für das später zu erstellende Video sowie den FPS‑Wert (Frames pro Sekunde) über den Konstruktor festzulegen. Wenn Sie eine Präsentationsinstanz übergeben, wird deren `Presentation.SlideSize` verwendet.

Um alle Animationen in einer Präsentation gleichzeitig abspielen zu lassen, verwenden Sie die Methode `PresentationEnumerableFramesGenerator.enumerate_frames`. Diese Methode nimmt eine Sammlung von Folien und gibt nacheinander [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/) zurück. Anschließend verwenden Sie `EnumerableFrameArgs.get_frame()`, um jedes Video‑Frame zu erhalten.
```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```


Die erzeugten Frames können dann zu einem Video zusammengefügt werden. Weitere Details finden Sie im Abschnitt [Convert PowerPoint to Video](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Unterstützte Animationen und Effekte**

Beim Konvertieren einer PowerPoint‑Präsentation zu Video mit Aspose.Slides für Python ist es wichtig zu verstehen, welche Animationen und Effekte in der Ausgabe unterstützt werden. Aspose.Slides unterstützt eine breite Palette gängiger Eingangs‑, Ausgangs‑ und Hervorhebungseffekte wie Einblenden, Hereinfliegen, Zoomen und Drehen. Allerdings können einige erweiterte oder benutzerdefinierte Animationen nicht vollständig erhalten bleiben oder im fertigen Video anders erscheinen. Dieser Abschnitt gibt einen Überblick über die unterstützten Animationen und Effekte.

**Eingang**:

| Animationstyp | Aspose.Slides | PowerPoint |
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

**Betonung**:

| Animationstyp | Aspose.Slides | PowerPoint |
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

**Ausgang**:

| Animationstyp | Aspose.Slides | PowerPoint |
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

**Bewegungswege**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Unterstützte Folienübergangseffekte**

Folienübergangseffekte spielen eine wichtige Rolle, um sanfte und optisch ansprechende Wechsel zwischen Folien in einem Video zu erzeugen. Aspose.Slides für Python unterstützt eine Vielzahl gängiger Übergangseffekte, um den Fluss und Stil Ihrer Originalpräsentation zu bewahren. Dieser Abschnitt hebt hervor, welche Übergangseffekte während des Konvertierungsprozesses unterstützt werden.

**Dezent**:

| Animationstyp | Aspose.Slides | PowerPoint |
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

**Spannend**:

| Animationstyp | Aspose.Slides | PowerPoint |
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

**Dynamischer Inhalt**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Ist es möglich, passwortgeschützte Präsentationen zu konvertieren?**

Ja, Aspose.Slides für Python ermöglicht die Arbeit mit passwortgeschützten Präsentationen. Beim Verarbeiten solcher Dateien müssen Sie das korrekte Passwort angeben, damit die Bibliothek auf den Inhalt der Präsentation zugreifen kann.

**Unterstützt Aspose.Slides für Python die Verwendung in Cloud‑Lösungen?**

Ja, Aspose.Slides für Python kann in Cloud‑Anwendungen und -Diensten integriert werden. Die Bibliothek ist für den Einsatz in Serverumgebungen konzipiert und bietet hohe Leistung sowie Skalierbarkeit für die Stapelverarbeitung von Dateien.

**Gibt es Größenbeschränkungen für Präsentationen während der Konvertierung?**

Aspose.Slides für Python kann Präsentationen praktisch jeder Größe verarbeiten. Bei sehr großen Dateien können jedoch zusätzliche Systemressourcen erforderlich sein, und es wird gelegentlich empfohlen, die Präsentation zu optimieren, um die Leistung zu verbessern.