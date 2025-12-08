---
title: PowerPoint-Präsentationen in Video konvertieren mit Python
linktitle: PowerPoint zu Video
type: docs
weight: 130
url: /de/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint zu Video
- PowerPoint in Video konvertieren
- Präsentation zu Video
- Präsentation in Video konvertieren
- PPT zu Video
- PPT in Video konvertieren
- PPTX zu Video
- PPTX in Video konvertieren
- ODP zu Video
- ODP in Video konvertieren
- PowerPoint zu MP4
- PowerPoint in MP4 konvertieren
- Präsentation zu MP4
- Präsentation in MP4 konvertieren
- PPT zu MP4
- PPT in MP4 konvertieren
- PPTX zu MP4
- PPTX in MP4 konvertieren
- PowerPoint-zu-Video-Konvertierung
- Präsentation-zu-Video-Konvertierung
- PPT-zu-Video-Konvertierung
- PPTX-zu-Video-Konvertierung
- ODP-zu-Video-Konvertierung
- Python-Video-Konvertierung
- PowerPoint
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen mit Python in Video konvertieren. Entdecken Sie Beispielcode und Automatisierungstechniken, um Ihren Arbeitsablauf zu optimieren."
---

## **Übersicht**

Durch das Konvertieren Ihrer PowerPoint‑ oder OpenDocument‑Präsentation in ein Video erhalten Sie:

**Erhöhte Barrierefreiheit:** Alle Geräte, unabhängig vom Betriebssystem, verfügen standardmäßig über Videoplayer, sodass Benutzer Videos leichter öffnen oder abspielen können als mit herkömmlichen Präsentationsanwendungen.

**Größere Reichweite:** Videos ermöglichen es Ihnen, ein größeres Publikum zu erreichen und Informationen in einem ansprechenderen Format zu präsentieren. Umfragen und Statistiken zeigen, dass Menschen lieber Video‑Inhalte ansehen und konsumieren als andere Formate, wodurch Ihre Botschaft wirkungsvoller wird.

{{% alert color="primary" %}} 

Schauen Sie sich unseren **PowerPoint‑zu‑Video‑Online‑Konverter**(https://products.aspose.app/slides/video) an, da er eine Live‑ und effektive Umsetzung des hier beschriebenen Prozesses bietet.

{{% /alert %}} 

In [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/), haben wir die Unterstützung für die Konvertierung von Präsentationen in Video implementiert.

* Verwenden Sie Aspose.Slides for Python, um Frames aus den Präsentationsfolien mit einer angegebenen Bildrate (FPS) zu erzeugen.  
* Anschließend nutzen Sie ein Drittanbieter‑Tool wie ffmpeg, um diese Frames zu einem Video zusammenzufügen.

## **PowerPoint‑Präsentation in Video konvertieren**

1. Verwenden Sie den pip‑Install‑Befehl, um Aspose.Slides for Python zu Ihrem Projekt hinzuzufügen: `pip install aspose-slides==24.4.0`
2. Laden Sie ffmpeg von [hier](https://ffmpeg.org/download.html) herunter oder installieren Sie es über den Paket‑Manager.
3. Stellen Sie sicher, dass ffmpeg im `PATH` liegt. Andernfalls starten Sie ffmpeg über den vollständigen Pfad zur ausführbaren Datei (z. B. `C:\ffmpeg\ffmpeg.exe` unter Windows oder `/opt/ffmpeg/ffmpeg` unter Linux).
4. Führen Sie den PowerPoint‑zu‑Video‑Konvertierungscode aus.

Dieses Python‑Beispiel demonstriert, wie eine Präsentation (mit einer Form und zwei Animationseffekten) in ein Video umgewandelt wird:
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


## **Videoeffekte**

Beim Konvertieren einer PowerPoint‑Präsentation in ein Video mit Aspose.Slides for Python können Sie verschiedene Videoeffekte anwenden, um die visuelle Qualität der Ausgabe zu verbessern. Diese Effekte ermöglichen die Steuerung des Aussehens der Folien im finalen Video, indem sanfte Übergänge, Animationen und weitere visuelle Elemente hinzugefügt werden. Dieser Abschnitt erklärt die verfügbaren Videoeffekt‑Optionen und zeigt, wie sie angewendet werden.

{{% alert color="primary" %}} 

Siehe [PowerPoint Animation](https://docs.aspose.com/slides/python-net/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/python-net/shape-animation/) und [Shape Effect](https://docs.aspose.com/slides/python-net/shape-effect/).

{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender – und das Gleiche gilt für Videos. Fügen wir dem Code der vorherigen Präsentation eine weitere Folie und einen Übergang hinzu:
```python
import aspose.pydrawing as drawing

# Füge eine Smiley-Form hinzu und animiere sie.
# ...

# Füge eine neue Folie und einen animierten Übergang hinzu.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```


Aspose.Slides for Python unterstützt zudem Textanimationen. In diesem Beispiel animieren wir Absätze auf Objekten, sodass sie nacheinander mit einer Sekunde Verzögerung erscheinen:
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

    # Frames zu Video konvertieren.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```


## **Klassen zur Video‑Konvertierung**

Um PowerPoint‑zu‑Video‑Aufgaben zu ermöglichen, stellt Aspose.Slides for Python die [PresentationEnumerableAnimationsGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableanimationsgenerator/) bereit.

`PresentationEnumerableAnimationsGenerator` ermöglicht das Festlegen der Frame‑Größe für das später zu erstellende Video sowie des FPS‑Werts über den Konstruktor. Wird eine Präsentationsinstanz übergeben, wird deren `Presentation.SlideSize` verwendet.

Um alle Animationen einer Präsentation gleichzeitig abzuspielen, verwenden Sie die Methode `PresentationEnumerableAnimationsGenerator.enumerate_frames`. Diese Methode nimmt eine Sammlung von Folien und gibt nacheinander [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/) zurück. Verwenden Sie anschließend `EnumerableFrameArgs.get_frame()`, um jedes Video‑Frame zu erhalten.
```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```


Anschließend können die generierten Frames zu einem Video zusammengefügt werden. Weitere Details finden Sie im Abschnitt [Convert PowerPoint to Video](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Unterstützte Animationen und Effekte**

Beim Konvertieren einer PowerPoint‑Präsentation in ein Video mit Aspose.Slides for Python ist es wichtig zu verstehen, welche Animationen und Effekte in der Ausgabe unterstützt werden. Aspose.Slides unterstützt eine breite Palette gängiger Eingangs‑, Ausgangs‑ und Betonungseffekte wie Einblenden, Hereinfliegen, Zoomen und Drehen. Einige erweiterte oder benutzerdefinierte Animationen werden jedoch möglicherweise nicht vollständig erhalten oder erscheinen im finalen Video anders. Dieser Abschnitt gibt einen Überblick über die unterstützten Animationen und Effekte.

**Eingang**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fade** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Fly In** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Float In** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Split** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wipe** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Shape** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wheel** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Random Bars** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Grow & Turn** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoom** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Swivel** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Bounce** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Betonung**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Color Pulse** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Teeter** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Spin** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Grow/Shrink** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Desaturate** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Darken** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Lighten** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Transparency** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Object Color** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Complementary Color** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Line Color** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fill Color** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |

**Ausgang**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fade** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Fly Out** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Float Out** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Split** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wipe** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Shape** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Random Bars** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Shrink & Turn** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoom** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Swivel** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Bounce** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Bewegungswege**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Arcs** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Turns** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Shapes** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Loops** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Custom Path** | ![unterstützt](v.png) | ![unterstützt](v.png) |

## **Unterstützte Folienübergangseffekte**

Folienübergangseffekte spielen eine wichtige Rolle, um sanfte und visuell ansprechende Wechsel zwischen Folien in einem Video zu erzeugen. Aspose.Slides for Python unterstützt eine Vielzahl gängiger Übergangseffekte, um den Fluss und Stil Ihrer ursprünglichen Präsentation beizubehalten. Dieser Abschnitt hebt hervor, welche Übergangseffekte während der Konvertierung unterstützt werden.

**Dezent**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fade** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Push** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Pull** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wipe** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Split** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Reveal** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Random Bars** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Shape** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Uncover** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Cover** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Flash** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Strips** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Spannend**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Drape** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Curtains** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Wind** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Prestige** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fracture** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Crush** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Peel Off** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Page Curl** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Airplane** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Origami** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Dissolve** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Checkerboard** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Blinds** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Clock** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Ripple** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Honeycomb** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Glitter** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Vortex** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Shred** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Switch** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Flip** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Gallery** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Cube** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Doors** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Box** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Comb** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoom** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Random** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |

**Dynamischer Inhalt**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Ferris Wheel** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Conveyor** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Rotate** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Orbit** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fly Through** | ![unterstützt](v.png) | ![unterstützt](v.png) |

## **FAQ**

**Ist es möglich, passwortgeschützte Präsentationen zu konvertieren?**

Ja, Aspose.Slides for Python unterstützt die Arbeit mit passwortgeschützten Präsentationen. Beim Verarbeiten solcher Dateien muss das korrekte Passwort angegeben werden, damit die Bibliothek auf den Inhalt der Präsentation zugreifen kann.

**Unterstützt Aspose.Slides for Python die Verwendung in Cloud‑Lösungen?**

Ja, Aspose.Slides for Python kann in Cloud‑Anwendungen und -Diensten integriert werden. Die Bibliothek ist für den Einsatz in Server‑Umgebungen konzipiert und gewährleistet hohe Leistung und Skalierbarkeit für die stapelweise Verarbeitung von Dateien.

**Gibt es Größenbeschränkungen für Präsentationen bei der Konvertierung?**

Aspose.Slides for Python kann praktisch Präsentationen jeder Größe verarbeiten. Bei sehr großen Dateien können jedoch zusätzliche Systemressourcen erforderlich sein, und es wird teilweise empfohlen, die Präsentation zu optimieren, um die Leistung zu verbessern.