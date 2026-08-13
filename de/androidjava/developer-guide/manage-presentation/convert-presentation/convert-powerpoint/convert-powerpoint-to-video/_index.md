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
- Video-Konvertierung
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Präsentationen in Java in ein Video konvertieren. Entdecken Sie Beispielcode und Automatisierungstechniken, um Ihren Arbeitsablauf zu optimieren."
---
## **Einleitung**

Durch die Konvertierung Ihrer PowerPoint‑Präsentation in ein Video erhalten Sie 

* **Steigerung der Barrierefreiheit:** Alle Geräte (unabhängig vom Betriebssystem) verfügen standardmäßig über Videoplayer im Vergleich zu Präsentations‑Öffnungs‑Anwendungen, sodass Benutzer Videos leichter öffnen oder abspielen können.
* **Mehr Reichweite:** Durch Videos können Sie ein großes Publikum erreichen und mit Informationen ansprechen, die in einer Präsentation sonst als mühsam gelten könnten. Die meisten Umfragen und Statistiken zeigen, dass Menschen Videos mehr ansehen und konsumieren als andere Inhaltsformen und sie im Allgemeinen bevorzugen.

## **PowerPoint‑zu‑Video‑Konvertierung in Aspose.Slides**

* Verwenden Sie **Aspose.Slides**, um einen Satz von Frames (aus den Folien der Präsentation) zu erzeugen, die einer bestimmten Bildrate (Frames pro Sekunde) entsprechen
* Verwenden Sie ein Drittanbieter‑Werkzeug wie **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)), um basierend auf den Frames ein Video zu erstellen. 

### **PowerPoint in Video konvertieren**

1. Fügen Sie dies zu Ihrer POM-Datei hinzu:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Laden Sie ffmpeg [hier](https://ffmpeg.org/download.html) herunter.

3. Führen Sie den PowerPoint‑zu‑Video‑Java‑Code aus.

Dieser Java‑Code zeigt, wie Sie eine Präsentation (mit einer Abbildung und zwei Animationseffekten) in ein Video konvertieren:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Fügt ein Smiley-Shape hinzu und animiert es anschließend
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

    // Konfiguriere den Ordner mit den ffmpeg-Binärdateien. Siehe diese Seite: https://github.com/bramp/ffmpeg-cli-wrapper
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

Sie können Animationen auf Objekte in Folien anwenden und Übergänge zwischen Folien verwenden.

{{% alert color="info" %}} 

Vielleicht möchten Sie diese Artikel sehen: [PowerPoint‑Animation](https://docs.aspose.com/slides/de/androidjava/powerpoint-animation/), [Form‑Animation](https://docs.aspose.com/slides/de/androidjava/shape-animation/), und [Form‑Effekt](https://docs.aspose.com/slides/de/androidjava/shape-effect/).

{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter – und sie bewirken dasselbe bei Videos. Fügen wir dem Code für die vorherige Präsentation eine weitere Folie und einen Übergang hinzu:
```java
import com.aspose.slides.*;
import java.awt.Color;

// Die Präsentation mit dem oben erstellten animierten Smiley-Shape.
Presentation presentation = new Presentation();
try {
    // Fügt eine neue Folie und einen animierten Übergang hinzu

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides unterstützt außerdem Animationen für Texte. Wir animieren also Absätze auf Objekten, die nacheinander erscheinen (mit einer Verzögerung von einer Sekunde):
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    // Konfiguriere den ffmpeg-Binärdateien-Ordner. Siehe diese Seite: https://github.com/bramp/ffmpeg-cli-wrapper
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

## **Video‑Konvertierungsklassen**

Um Ihnen die Durchführung von PowerPoint‑zu‑Video‑Konvertierungsaufgaben zu ermöglichen, stellt Aspose.Slides die Klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentationanimationsgenerator/) und [PresentationPlayer](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentationplayer/) bereit.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentationanimationsgenerator/) ermöglicht es Ihnen, über seinen Konstruktor die Frame‑Größe für das später zu erstellende Video festzulegen. Wenn Sie eine Instanz der Präsentation übergeben, wird `Presentation.SlideSize` verwendet und er erzeugt Animationen, die [PresentationPlayer](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentationplayer/) nutzt.

Wenn Animationen erzeugt werden, wird für jede nachfolgende Animation ein `NewAnimation`‑Ereignis mit dem Parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationanimationplayer/) generiert. Letzteres ist eine Klasse, die einen Player für eine einzelne Animation darstellt.

Um mit [IPresentationAnimationPlayer](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationanimationplayer/) zu arbeiten, werden die Eigenschaft [Duration](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (die Gesamtdauer der Animation) und die Methode [SetTimePosition](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) verwendet. Jede Animationsposition wird innerhalb des *0‑bis‑Dauer*-Bereichs festgelegt, und anschließend liefert die Methode `getFrame` ein [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/), das dem Animationszustand zu diesem Zeitpunkt entspricht:
```java
import com.aspose.slides.*;

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
            // Bitmap des initialen Animationszustands
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // finaler Zustand der Animation
            // letztes Bild der Animation
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // Erzeugt die Animationen. Der obige Callback wird für jede von ihnen ausgeführt.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Um alle Animationen einer Präsentation gleichzeitig abzuspielen, wird die Klasse [PresentationPlayer](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentationplayer/) verwendet. Diese Klasse nimmt im Konstruktor eine Instanz von [PresentationAnimationsGenerator](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentationanimationsgenerator/) und FPS für Effekte entgegen und ruft dann das `FrameTick`‑Ereignis für alle Animationen auf, um sie abzuspielen:
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

Anschließend können die erzeugten Frames zu einem Video zusammengefügt werden. Siehe den Abschnitt [PowerPoint in Video konvertieren](https://docs.aspose.com/slides/de/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Unterstützte Animationen und Effekte**

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

**Bewegungspfade**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Arcs** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Turns** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Shapes** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Loops** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Custom Path** | ![unterstützt](v.png) | ![unterstützt](v.png) |

## **FAQ**

### Ist es möglich, passwortgeschützte Präsentationen zu konvertieren?

Ja, Aspose.Slides ermöglicht die Arbeit mit [passwortgeschützten Präsentationen](/slides/de/androidjava/password-protected-presentation/). Beim Verarbeiten solcher Dateien müssen Sie das korrekte Passwort angeben, damit die Bibliothek auf den Inhalt der Präsentation zugreifen kann.

### Unterstützt Aspose.Slides die Nutzung in Cloud‑Lösungen?

Ja, Aspose.Slides kann in Cloud‑Anwendungen und -Dienste integriert werden. Die Bibliothek ist für den Einsatz in Serverumgebungen konzipiert und gewährleistet hohe Leistung und Skalierbarkeit für die Batch‑Verarbeitung von Dateien.

### Gibt es Größenbeschränkungen für Präsentationen während der Konvertierung?

Aspose.Slides kann praktisch Präsentationen jeder Größe verarbeiten. Beim Arbeiten mit sehr großen Dateien können jedoch zusätzliche Systemressourcen erforderlich sein, und es wird manchmal empfohlen, die Präsentation zu optimieren, um die Leistung zu verbessern.