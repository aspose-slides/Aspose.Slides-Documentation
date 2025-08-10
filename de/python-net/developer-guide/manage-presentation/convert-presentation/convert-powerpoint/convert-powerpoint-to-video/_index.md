---
title: PowerPoint-Präsentationen in Videos umwandeln mit Python
linktitle: PowerPoint zu Video
type: docs
weight: 130
url: /de/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint zu Video
- PowerPoint in Video umwandeln
- Präsentation zu Video
- Präsentation in Video umwandeln
- PPT zu Video
- PPT in Video umwandeln
- PPTX zu Video
- PPTX in Video umwandeln
- ODP zu Video
- ODP in Video umwandeln
- PowerPoint zu MP4
- PowerPoint in MP4 umwandeln
- Präsentation zu MP4
- Präsentation in MP4 umwandeln
- PPT zu MP4
- PPT in MP4 umwandeln
- PPTX zu MP4
- PPTX in MP4 umwandeln
- PowerPoint-Video-Konvertierung
- Präsentation-Video-Konvertierung
- PPT-Video-Konvertierung
- PPTX-Video-Konvertierung
- ODP-Video-Konvertierung
- Python-Video-Konvertierung
- PowerPoint
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen mit Python in Videos umwandeln können. Entdecken Sie Beispielcode und Automatisierungstechniken, um Ihren Workflow zu optimieren."
---

Durch die Umwandlung Ihrer PowerPoint-Präsentation in ein Video erhalten Sie 

* **Erhöhte Zugänglichkeit:** Alle Geräte (unabhängig von der Plattform) sind standardmäßig mit Videoplayern ausgestattet im Vergleich zu Programmen zum Öffnen von Präsentationen, sodass es den Benutzern leichter fällt, Videos zu öffnen oder abzuspielen.
* **Größere Reichweite:** Durch Videos können Sie ein großes Publikum erreichen und mit Informationen versorgen, die in einer Präsentation sonst vielleicht langwierig erscheinen würden. Die meisten Umfragen und Statistiken deuten darauf hin, dass Menschen Videos häufiger ansehen und konsumieren als andere Formen von Inhalten, und sie ziehen im Allgemeinen solche Inhalte vor.

{{% alert color="primary" %}} 

Sie sollten unseren [**PowerPoint zu Video Online-Konverter**](https://products.aspose.app/slides/conversion/ppt-to-word) überprüfen, da dies eine Live- und effektive Umsetzung des hier beschriebenen Prozesses ist.

{{% /alert %}} 

## **PowerPoint in Video Umwandlung in Aspose.Slides**

In [Aspose.Slides 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/) haben wir die Unterstützung für die Umwandlung von Präsentationen in Videos implementiert.

* Verwenden Sie Aspose.Slides, um eine Reihe von Frames (aus den Präsentationsfolien) zu generieren, die einem bestimmten FPS (Frames pro Sekunde) entsprechen.
* Verwenden Sie ein Dienstprogramm von Drittanbietern wie ffmpeg, um ein Video basierend auf den Frames zu erstellen.

### **PowerPoint in Video umwandeln**

1. Verwenden Sie den pip install-Befehl, um Aspose.Slides zu Ihrem Projekt hinzuzufügen:
   * Führen Sie `pip install Aspose.Slides==24.4.0` aus.
2. Laden Sie ffmpeg [hier](https://ffmpeg.org/download.html) herunter oder installieren Sie es über einen Paketmanager.
3. Stellen Sie sicher, dass ffmpeg im `PATH` ist, andernfalls starten Sie ffmpeg mit dem vollständigen Pfad zur Binärdatei (z. B. `C:\ffmpeg\ffmpeg.exe` unter Windows oder `/opt/ffmpeg/ffmpeg` unter Linux).
4. Führen Sie den PowerPoint in Video-Code aus.

Dieser Python-Code zeigt Ihnen, wie Sie eine Präsentation (die eine Figur und zwei Animationseffekte enthält) in ein Video umwandeln:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    smile = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)
    effect_in = presentation.slides[0].timeline.main_sequence.add_effect(smile, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.TOP_LEFT, slides.animation.EffectTriggerType.AFTER_PREVIOUS)
    effect_out = presentation.slides[0].timeline.main_sequence.add_effect(smile, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM_RIGHT, slides.animation.EffectTriggerType.AFTER_PREVIOUS)
    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "smile.webm"]
    subprocess.call(cmd_line)
```

## **Videoeffekte**

Sie können Animationen auf Objekte in Folien anwenden und Übergänge zwischen Folien verwenden.

{{% alert color="primary" %}} 

Sie sollten sich diese Artikel ansehen: [PowerPoint-Animation](https://docs.aspose.com/slides/python-net/powerpoint-animation/), [Formanimation](https://docs.aspose.com/slides/python-net/shape-animation/) und [Formeffekt](https://docs.aspose.com/slides/python-net/shape-effect/).

{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter — und sie tun dasselbe für Videos. Lassen Sie uns eine weitere Folie und einen Übergang zum Code der vorherigen Präsentation hinzufügen:

```python
import aspose.pydrawing as drawing
# Fügt eine Smile-Form hinzu und animiert sie
# ...
# Fügt eine neue Folie und einen animierten Übergang hinzu

new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides unterstützt auch Animationen für Texte. Daher animieren wir Absätze auf Objekten, die nacheinander erscheinen (mit einer Verzögerung von einer Sekunde):

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    # Fügt Text und Animationen hinzu
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose Slides für .NET"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("PowerPoint-Präsentation mit Text in Video umwandeln"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("Absatz für Absatz"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = presentation.slides[0].timeline.main_sequence.add_effect(para1, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = presentation.slides[0].timeline.main_sequence.add_effect(para2, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = presentation.slides[0].timeline.main_sequence.add_effect(para3, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = presentation.slides[0].timeline.main_sequence.add_effect(para3, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # Konvertiert Frames in Video
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **Video-Konverterklassen**

Um Ihnen die Durchführung von PowerPoint-zu-Video-Umwandlungsaufgaben zu ermöglichen, bietet Aspose.Slides den [PresentationEnumerableAnimationsGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableanimationsgenerator/).

Der PresentationEnumerableAnimationsGenerator ermöglicht es Ihnen, die Bildgröße für das Video (das später erstellt wird) und den FPS-Wert (Frames pro Sekunde) über seinen Konstruktor festzulegen. Wenn Sie eine Instanz der Präsentation übergeben, wird `Presentation.SlideSize` verwendet.

Um alle Animationen in einer Präsentation gleichzeitig abzuspielen, verwenden Sie die Methode PresentationEnumerableAnimationsGenerator.enumerate_frames. Diese Methode nimmt eine Sammlung von Folien und ermöglicht es, nacheinander [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/) zu erhalten. Dann ermöglicht EnumerableFrameArgs.get_frame() den Zugriff auf das Videobild:

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

Anschließend können die generierten Frames kompiliert werden, um ein Video zu erstellen. Siehe den Abschnitt [PowerPoint in Video umwandeln](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Unterstützte Animationen und Effekte**


**Eingang**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Erscheinen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Verblassen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hineinfliegen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schweben** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Teilen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wischen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Form** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Rad** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Zufällige Balken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wachsen & Drehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoomen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wenden** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hüpfen** | ![unterstützt](v.png) | ![unterstützt](v.png) |


**Betonung**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Farbe Pulse** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Wippen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Drehen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wachsen/Schrumpfen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Entsättigen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Dunkeln** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Aufhellen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Transparenz** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Objektfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Komplementärfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Linienfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Füllfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |

**Austritt**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Verschwinden** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Verblassen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hinausfliegen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hinausschweben** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Teilen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wischen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Form** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Zufällige Balken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schrumpfen & Drehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoomen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wenden** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hüpfen** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Bewegungspfad:**

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linien** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Bögen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Drehungen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Formen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schleifen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Benutzerdefinierter Pfad** | ![unterstützt](v.png) | ![unterstützt](v.png) |

## **Unterstützte Folienübergangseffekte**

**Subtil**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Verblassen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schieben** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Ziehen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wischen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Teilen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Enthüllen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zufällige Balken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Form** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Enthüllen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Bedecken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Blitzen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Streifen** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Aufregend**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Umfallen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Drapieren** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Vorhänge** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Wind** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Prestige** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Bruch** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zerschlagen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Abziehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Seitenaufcurlen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Flugzeug** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Origami** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Auflösen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schachbrett** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Jalousien** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Uhr** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Welle** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Wabenmuster** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Glitzern** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Wirbel** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Schreddern** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Schalter** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Drehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Galerie** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Würfel** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Türen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Kiste** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Kamm** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoomen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Zufällig** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |

**Dynamische Inhalte**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Schwenken** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Riesenrad** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Förderband** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Drehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Umlaufbahn** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Durchfliegen** | ![unterstützt](v.png) | ![unterstützt](v.png) |