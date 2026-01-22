---
title: PowerPoint-Präsentationen in JavaScript in Video konvertieren
linktitle: PowerPoint zu Video
type: docs
weight: 130
url: /de/nodejs-java/convert-powerpoint-to-video/
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
- Video-Konvertierung
- PowerPoint
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Präsentationen in JavaScript in Video konvertieren. Entdecken Sie Beispielcode und Automatisierungstechniken, um Ihren Arbeitsablauf zu optimieren."
---

Durch die Konvertierung Ihrer PowerPoint-Präsentation in ein Video erhalten Sie 

* **Erhöhte Barrierefreiheit:** Alle Geräte (unabhängig vom Betriebssystem) verfügen standardmäßig über Videoplayer im Vergleich zu Präsentations‑Öffnungs‑Anwendungen, sodass Benutzer Videos einfacher öffnen oder abspielen können.
* **Größere Reichweite:** Mit Videos können Sie ein großes Publikum erreichen und es mit Informationen ansprechen, die in einer Präsentation sonst als mühsam gelten könnten. Die meisten Umfragen und Statistiken zeigen, dass Menschen Videos mehr ansehen und konsumieren als andere Inhaltsformen und sie bevorzugen solche Inhalte im Allgemeinen.

{{% alert color="primary" %}} 

Sie sollten unseren [**PowerPoint‑zu‑Video‑Online‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-word) prüfen, da er eine aktuelle und effektive Umsetzung des hier beschriebenen Prozesses darstellt.

{{% /alert %}} 

## **PowerPoint‑zu‑Video‑Konvertierung in Aspose.Slides**

Aspose.Slides unterstützt die Konvertierung von Präsentationen zu Video.

* Verwenden Sie **Aspose.Slides**, um eine Reihe von Frames (aus den Präsentations‑Folien) zu erzeugen, die einer bestimmten FPS (Bilder pro Sekunde) entsprechen.
* Verwenden Sie ein Drittanbieter‑Tool wie **ffmpeg** ([für java](https://github.com/bramp/ffmpeg-cli-wrapper)), um basierend auf den Frames ein Video zu erstellen. 

### **PowerPoint in Video konvertieren**

1. Laden Sie ffmpeg [hier](https://ffmpeg.org/download.html) herunter.

2. Führen Sie den PowerPoint‑zu‑Video‑JavaScript‑Code aus.

Dieser JavaScript‑Code zeigt, wie Sie eine Präsentation (mit einer Figur und zwei Animationseffekten) in ein Video konvertieren:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Fügt eine Smiley-Form hinzu und animiert sie anschließend
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
    // Konfiguriere den ffmpeg-Binärordner. Siehe diese Seite: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```


## **Video‑Effekte**

Sie können Animationen auf Objekte in Folien anwenden und Übergänge zwischen Folien nutzen. 

{{% alert color="primary" %}} 

Schauen Sie sich diese Artikel an: [PowerPoint Animation](https://docs.aspose.com/slides/nodejs-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/nodejs-java/shape-animation/), und [Shape Effect](https://docs.aspose.com/slides/nodejs-java/shape-effect/).

{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter – und dasselbe gilt für Videos. Lassen Sie uns der vorherigen Präsentation eine weitere Folie und einen Übergang hinzufügen:
```javascript
// Fügt eine Smiley-Form hinzu und animiert sie
// ...
// Fügt eine neue Folie und einen animierten Übergang hinzu
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```


Aspose.Slides unterstützt auch Textanimationen. Wir animieren also Absätze auf Objekten, die nacheinander erscheinen (mit einer Sekunde Verzögerung):
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Fügt Text und Animationen hinzu
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
    // Konfiguriere den ffmpeg-Binärordner. Siehe diese Seite: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```


## **Video‑Konvertierungs‑Klassen**

Um PowerPoint‑zu‑Video‑Konvertierungsaufgaben auszuführen, stellt Aspose.Slides die Klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) und [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/) bereit.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) ermöglicht das Festlegen der Frame‑Größe für das später zu erstellende Video über seinen Konstruktor. Wenn Sie eine Instanz der Präsentation übergeben, wird `Presentation.getSlideSize` verwendet und es werden Animationen erzeugt, die [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/) nutzt.

Wenn Animationen erzeugt werden, wird für jede nachfolgende Animation ein `NewAnimation`‑Ereignis mit dem Parameter des Präsentations‑Animations‑Players generiert. Letzterer ist eine Klasse, die einen Player für eine einzelne Animation darstellt.

Um mit dem Präsentations‑Animations‑Player zu arbeiten, werden die Methoden `getDuration` (die Gesamtdauer der Animation) und `setTimePosition` verwendet. Jede Animationsposition wird im Bereich *0 bis Dauer* festgelegt, und anschließend liefert die Methode `getFrame` ein BufferedImage, das dem Animationszustand zu diesem Zeitpunkt entspricht:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Fügt eine Smiley-Form hinzu und animiert sie
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
            animationPlayer.setTimePosition(0);// initialer Animationszustand
            try {
                // Bitmap des initialen Animationszustands
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// finaler Zustand der Animation
            try {
                // letztes Bild der Animation
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


Um alle Animationen einer Präsentation gleichzeitig abspielen zu lassen, wird die Klasse [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/) verwendet. Diese Klasse nimmt im Konstruktor eine Instanz von [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) und FPS für Effekte entgegen und ruft dann das `FrameTick`‑Ereignis für alle Animationen auf, um sie abzuspielen:
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


Anschließend können die erzeugten Frames zu einem Video zusammengeführt werden. Siehe den Abschnitt [Convert PowerPoint to Video](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Unterstützte Animationen und Effekte**

**Eingang**:

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

**Betonung**:

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

**Ausgang**:

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

**Bewegungspfade:**

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Ist es möglich, passwortgeschützte Präsentationen zu konvertieren?**

Ja, Aspose.Slides ermöglicht die Arbeit mit passwortgeschützten Präsentationen. Beim Verarbeiten solcher Dateien müssen Sie das korrekte Passwort angeben, damit die Bibliothek auf den Inhalt der Präsentation zugreifen kann.

**Unterstützt Aspose.Slides den Einsatz in Cloud‑Lösungen?**

Ja, Aspose.Slides kann in Cloud‑Anwendungen und -Dienste integriert werden. Die Bibliothek ist für den Einsatz in Serverumgebungen konzipiert und gewährleistet hohe Leistung und Skalierbarkeit für die Stapelverarbeitung von Dateien.

**Gibt es Größenbeschränkungen für Präsentationen während der Konvertierung?**

Aspose.Slides kann praktisch Präsentationen jeder Größe verarbeiten. Bei sehr großen Dateien können jedoch zusätzliche Systemressourcen erforderlich sein, und es wird teilweise empfohlen, die Präsentation zu optimieren, um die Leistung zu verbessern.