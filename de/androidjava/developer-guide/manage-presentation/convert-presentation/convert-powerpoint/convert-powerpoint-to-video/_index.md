---
title: PowerPoint-Präsentationen auf Android in Video konvertieren
linktitle: PowerPoint zu Video
type: docs
weight: 130
url: /de/androidjava/convert-powerpoint-to-video/
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
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Präsentationen in Java zu Video konvertieren. Entdecken Sie Beispielcode und Automatisierungstechniken, um Ihren Arbeitsablauf zu optimieren."
---

Durch die Konvertierung Ihrer PowerPoint‑Präsentation in ein Video erhalten Sie 

* **Erhöhte Barrierefreiheit:** Alle Geräte (unabhängig von der Plattform) verfügen standardmäßig über Videoplayer im Vergleich zu Anwendungen zum Öffnen von Präsentationen, sodass Benutzer es einfacher finden, Videos zu öffnen oder abzuspielen.
* **Größere Reichweite:** Durch Videos können Sie ein großes Publikum erreichen und mit Informationen ansprechen, die in einer Präsentation sonst als lästig empfunden werden könnten. Die meisten Umfragen und Statistiken zeigen, dass Menschen Videos mehr ansehen und konsumieren als andere Inhaltsformen und sie im Allgemeinen solche Inhalte bevorzugen.

{{% alert color="primary" %}} 
Vielleicht möchten Sie unseren [**PowerPoint‑zu‑Video‑Online‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-word) überprüfen, da er eine aktuelle und effektive Umsetzung des hier beschriebenen Prozesses darstellt.
{{% /alert %}} 

## **PowerPoint‑zu‑Video‑Konvertierung in Aspose.Slides**

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-22-11-release-notes/) haben wir die Unterstützung für die Konvertierung von Präsentationen in Videos implementiert.

* Verwenden Sie **Aspose.Slides**, um eine Reihe von Frames (aus den Präsentationsfolien) zu erzeugen, die einer bestimmten FPS (Frames pro Sekunde) entsprechen
* Verwenden Sie ein Drittanbieter‑Dienstprogramm wie **ffmpeg** ([für java](https://github.com/bramp/ffmpeg-cli-wrapper)), um basierend auf den Frames ein Video zu erstellen. 

### **PowerPoint in Video konvertieren**

1. Fügen Sie dies zu Ihrer POM‑Datei hinzu:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```


2. Laden Sie ffmpeg [hier](https://ffmpeg.org/download.html) herunter.

4. Führen Sie den PowerPoint‑zu‑Video‑Java‑Code aus.

Dieser Java‑Code zeigt Ihnen, wie Sie eine Präsentation (mit einer Abbildung und zwei Animationseffekten) in ein Video konvertieren:
```java
Presentation presentation = new Presentation();
try {
    // Fügt ein Smiley-Shape hinzu und animiert es dann
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

    // Konfiguriere den Ordner mit den ffmpeg-Binärdateien. Siehe diese Seite: https://github.com/rosenbjerg/FFMpegCore#installation
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


## **Videoeffekte**

Sie können Objekten auf Folien Animationen zuweisen und Übergänge zwischen Folien verwenden. 

{{% alert color="primary" %}} 
Vielleicht möchten Sie diese Artikel ansehen: [PowerPoint‑Animation](https://docs.aspose.com/slides/androidjava/powerpoint-animation/), [Form‑Animation](https://docs.aspose.com/slides/androidjava/shape-animation/), und [Form‑Effekt](https://docs.aspose.com/slides/androidjava/shape-effect/).
{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter – und dasselbe gilt für Videos. Lassen Sie uns dem Code für die vorherige Präsentation eine weitere Folie und einen Übergang hinzufügen:
```java
// Fügt ein Smiley-Shape hinzu und animiert es

// ...

// Fügt eine neue Folie und einen animierten Übergang hinzu

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```


Aspose.Slides unterstützt auch Animationen für Texte. Daher animieren wir Absätze auf Objekten, die nacheinander angezeigt werden (mit einer Verzögerung von einer Sekunde):
```java
Presentation presentation = new Presentation();
try {
    // Fügt Text und Animationen hinzu
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

    // Konfiguriere den ffmpeg-Binärordner. Siehe diese Seite: https://github.com/rosenbjerg/FFMpegCore#installation
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


## **Klassen für die Videokonvertierung**

Um Ihnen die Durchführung von PowerPoint‑zu‑Video‑Konvertierungsaufgaben zu ermöglichen, stellt Aspose.Slides die Klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) und [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) bereit.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) ermöglicht Ihnen, die Frame‑Größe für das später erstellte Video über dessen Konstruktor festzulegen. Wenn Sie eine Instanz der Präsentation übergeben, wird `Presentation.SlideSize` verwendet und es generiert Animationen, die [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) nutzt.

Wenn Animationen generiert werden, wird für jede nachfolgende Animation ein `NewAnimation`‑Ereignis erzeugt, das den Parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/) enthält. Letzterer ist eine Klasse, die einen Player für eine separate Animation darstellt.

Um mit [IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/) zu arbeiten, werden die Eigenschaft [Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (die Gesamtdauer der Animation) und die Methode [SetTimePosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) verwendet. Jede Animationsposition wird im Bereich *0 bis Dauer* festgelegt, und anschließend liefert die Methode `GetFrame` ein BufferedImage, das dem Animationszustand zu diesem Zeitpunkt entspricht:
```java
Presentation presentation = new Presentation();
try {
    // Fügt ein Smiley-Shape hinzu und animiert es
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
            animationPlayer.setTimePosition(0); // initialer Animationszustand
            try {
                // Bitmap des Anfangszustands
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // Endzustand der Animation
            try {
                // Letztes Bild der Animation
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


Um alle Animationen einer Präsentation gleichzeitig abspielen zu lassen, wird die Klasse [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) verwendet. Diese Klasse nimmt im Konstruktor eine Instanz von [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) sowie FPS für die Effekte entgegen und ruft dann das `FrameTick`‑Ereignis für alle Animationen auf, um sie abzuspielen:
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


Anschließend können die erzeugten Frames zu einem Video zusammengefügt werden. Siehe den Abschnitt [Convert PowerPoint to Video](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Unterstützte Animationen und Effekte**

**Eintritt**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Erscheinen** | ![not supported](x.png) | ![supported](v.png) |
| **Ausblenden** | ![supported](v.png) | ![supported](v.png) |
| **Einfliegen** | ![supported](v.png) | ![supported](v.png) |
| **Schweben** | ![supported](v.png) | ![supported](v.png) |
| **Aufteilen** | ![supported](v.png) | ![supported](v.png) |
| **Wischen** | ![supported](v.png) | ![supported](v.png) |
| **Form** | ![supported](v.png) | ![supported](v.png) |
| **Rad** | ![supported](v.png) | ![supported](v.png) |
| **Zufällige Balken** | ![supported](v.png) | ![supported](v.png) |
| **Wachsen & Drehen** | ![not supported](x.png) | ![supported](v.png) |
| **Zoomen** | ![supported](v.png) | ![supported](v.png) |
| **Schwenken** | ![supported](v.png) | ![supported](v.png) |
| **Springen** | ![supported](v.png) | ![supported](v.png) |

**Betonung**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Puls** | ![not supported](x.png) | ![supported](v.png) |
| **Farbpuls** | ![not supported](x.png) | ![supported](v.png) |
| **Wackeln** | ![supported](v.png) | ![supported](v.png) |
| **Drehen** | ![supported](v.png) | ![supported](v.png) |
| **Wachsen/Schrumpfen** | ![not supported](x.png) | ![supported](v.png) |
| **Entsättigen** | ![not supported](x.png) | ![supported](v.png) |
| **Verdunkeln** | ![not supported](x.png) | ![supported](v.png) |
| **Aufhellen** | ![not supported](x.png) | ![supported](v.png) |
| **Transparenz** | ![not supported](x.png) | ![supported](v.png) |
| **Objektfarbe** | ![not supported](x.png) | ![supported](v.png) |
| **Komplementärfarbe** | ![not supported](x.png) | ![supported](v.png) |
| **Linienfarbe** | ![not supported](x.png) | ![supported](v.png) |
| **Füllfarbe** | ![not supported](x.png) | ![supported](v.png) |

**Ausgang**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Verschwinden** | ![not supported](x.png) | ![supported](v.png) |
| **Ausblenden** | ![supported](v.png) | ![supported](v.png) |
| **Ausfliegen** | ![supported](v.png) | ![supported](v.png) |
| **Schweben Aus** | ![supported](v.png) | ![supported](v.png) |
| **Aufteilen** | ![supported](v.png) | ![supported](v.png) |
| **Wischen** | ![supported](v.png) | ![supported](v.png) |
| **Form** | ![supported](v.png) | ![supported](v.png) |
| **Zufällige Balken** | ![supported](v.png) | ![supported](v.png) |
| **Schrumpfen & Drehen** | ![not supported](x.png) | ![supported](v.png) |
| **Zoomen** | ![supported](v.png) | ![supported](v.png) |
| **Schwenken** | ![supported](v.png) | ![supported](v.png) |
| **Springen** | ![supported](v.png) | ![supported](v.png) |

**Bewegungspfade**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linien** | ![supported](v.png) | ![supported](v.png) |
| **Bögen** | ![supported](v.png) | ![supported](v.png) |
| **Drehungen** | ![supported](v.png) | ![supported](v.png) |
| **Formen** | ![supported](v.png) | ![supported](v.png) |
| **Schleifen** | ![supported](v.png) | ![supported](v.png) |
| **Benutzerdefinierter Pfad** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Ist es möglich, passwortgeschützte Präsentationen zu konvertieren?**

Ja, Aspose.Slides unterstützt die Arbeit mit [passwortgeschützten Präsentationen](/slides/de/androidjava/password-protected-presentation/). Beim Verarbeiten solcher Dateien müssen Sie das korrekte Passwort angeben, damit die Bibliothek auf den Inhalt der Präsentation zugreifen kann.

**Unterstützt Aspose.Slides die Verwendung in Cloud‑Lösungen?**

Ja, Aspose.Slides kann in Cloud‑Anwendungen und -Dienste integriert werden. Die Bibliothek ist für den Einsatz in Serverumgebungen konzipiert und gewährleistet hohe Leistung und Skalierbarkeit für die Stapelverarbeitung von Dateien.

**Gibt es Größenbeschränkungen für Präsentationen während der Konvertierung?**

Aspose.Slides kann praktisch Präsentationen jeder Größe verarbeiten. Bei sehr großen Dateien können jedoch zusätzliche Systemressourcen erforderlich sein, und es wird manchmal empfohlen, die Präsentation zu optimieren, um die Leistung zu verbessern.