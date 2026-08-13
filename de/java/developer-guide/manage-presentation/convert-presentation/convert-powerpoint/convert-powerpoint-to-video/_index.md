---
title: PowerPoint-Präsentationen in Java zu Video konvertieren
linktitle: PowerPoint zu Video
type: docs
weight: 130
url: /de/java/convert-powerpoint-to-video/
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
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Präsentationen in Java zu Video konvertieren. Entdecken Sie Beispielcode und Automatisierungstechniken, um Ihren Arbeitsablauf zu optimieren."
---
## **Einleitung**

Durch die Konvertierung Ihrer PowerPoint‑ oder OpenDocument‑Präsentation in ein Video erhalten Sie:

**Erhöhte Barrierefreiheit:** Alle Geräte, unabhängig vom Betriebssystem, verfügen standardmäßig über Videoplayer, sodass es für Nutzer einfacher ist, Videos zu öffnen oder abzuspielen als herkömmliche Präsentations‑Apps.

**Größere Reichweite:** Videos ermöglichen es Ihnen, ein größeres Publikum zu erreichen und Informationen ansprechender zu präsentieren. Umfragen und Statistiken zeigen, dass Menschen Video‑Inhalte gegenüber anderen Formaten bevorzugen, wodurch Ihre Botschaft wirkungsvoller wird.

{{% alert color="info" %}} 
Möglicherweise möchten Sie unseren [**PowerPoint zu Video Online‑Konverter**](https://products.aspose.app/slides/de/video) prüfen, da er eine live und effektive Umsetzung des hier beschriebenen Prozesses darstellt.
{{% /alert %}} 

## **PowerPoint‑zu‑Video‑Konvertierung in Aspose.Slides**

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/de/java/aspose-slides-for-java-22-11-release-notes/) haben wir die Unterstützung für die Konvertierung von Präsentationen zu Video implementiert. 

* Verwenden Sie **Aspose.Slides**, um einen Satz von Frames (aus den Präsentationsfolien) zu erzeugen, die einer bestimmten FPS (Frames pro Sekunde) entsprechen.  
* Nutzen Sie ein Drittanbieter‑Tool wie **ffmpeg** ([für java](https://github.com/bramp/ffmpeg-cli-wrapper)), um basierend auf den Frames ein Video zu erstellen. 

### **PowerPoint zu Video konvertieren**

1. Fügen Sie Folgendes zu Ihrer POM‑Datei hinzu:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Laden Sie ffmpeg [hier](https://ffmpeg.org/download.html) herunter.

4. Führen Sie den PowerPoint‑zu‑Video‑Java‑Code aus.

Dieser Java‑Code zeigt Ihnen, wie Sie eine Präsentation (mit einer Figur und zwei Animationseffekten) in ein Video konvertieren:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Fügt eine Smiley-Form hinzu und animiert sie anschließend
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

    // Konfiguriert den ffmpeg-Binärordner. Siehe diese Seite: https://github.com/rosenbjerg/FFMpegCore#installation
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
Vielleicht möchten Sie diese Artikel sehen: [PowerPoint‑Animation](https://docs.aspose.com/slides/de/java/powerpoint-animation/), [Shape‑Animation](https://docs.aspose.com/slides/de/java/shape-animation/), und [Shape‑Effekt](https://docs.aspose.com/slides/de/java/shape-effect/).
{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter — und dasselbe gilt für Videos. Fügen wir eine weitere Folie und einen Übergang zum Code der vorherigen Präsentation hinzu:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // Fügt eine Smiley-Form hinzu und animiert sie

    // ...

    // Fügt eine neue Folie und animierten Übergang hinzu

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides unterstützt zudem Animationen für Texte. So animieren wir Absätze auf Objekten, die nacheinander erscheinen (mit einer Verzögerung von einer Sekunde):
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
    paragraphCollection.add(new Paragraph());

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

    // Konfiguriert den ffmpeg-Binärordner. Siehe diese Seite: https://github.com/rosenbjerg/FFMpegCore#installation
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

Um Ihnen das Durchführen von PowerPoint‑zu‑Video‑Konvertierungsaufgaben zu ermöglichen, stellt Aspose.Slides die Klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationanimationsgenerator/) und [PresentationPlayer](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationplayer/) zur Verfügung.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationanimationsgenerator/) ermöglicht das Festlegen der Frame‑Größe für das später zu erstellende Video über den Konstruktor. Wird eine Instanz der Präsentation übergeben, wird `Presentation.SlideSize` verwendet und es werden Animationen erzeugt, die von [PresentationPlayer](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationplayer/) genutzt werden. 

Beim Generieren von Animationen wird für jede nachfolgende Animation ein `NewAnimation`‑Ereignis mit dem Parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationanimationplayer/) ausgelöst. Letzterer ist eine Klasse, die einen Player für eine separate Animation repräsentiert.

Zur Arbeit mit [IPresentationAnimationPlayer](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationanimationplayer/) werden die Eigenschaft [Duration](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (die Gesamtdauer der Animation) und die Methode [SetTimePosition](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) verwendet. Jede Animationsposition wird innerhalb des Bereichs *0 bis Dauer* gesetzt, und die Methode `getFrame` liefert ein [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/), das dem Animationszustand zu diesem Zeitpunkt entspricht:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Fügt eine Smiley-Form hinzu und animiert sie
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

            animationPlayer.setTimePosition(0); // Anfangszustand der Animation
            // Bitmap des Anfangszustands der Animation
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // Endzustand der Animation
            // Letztes Bild der Animation
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // Animationen erzeugen - das löst die oben behandelten Ereignisse aus
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Damit alle Animationen einer Präsentation gleichzeitig abgespielt werden, wird die Klasse [PresentationPlayer](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationplayer/) verwendet. Diese Klasse nimmt im Konstruktor eine Instanz von [PresentationAnimationsGenerator](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationanimationsgenerator/) sowie FPS für Effekte entgegen und ruft dann das `FrameTick`‑Ereignis für alle Animationen auf, um sie abzuspielen:
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

Anschließend können die erzeugten Frames zu einem Video zusammengefügt werden. Siehe den Abschnitt [PowerPoint zu Video konvertieren](https://docs.aspose.com/slides/de/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Unterstützte Animationen und Effekte**

**Eintritt**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Erscheinen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Verblassen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hereinfliegen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Aufsteigen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Teilen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wischen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Form** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Rad** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Zufällige Balken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wachsen & Drehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoomen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schwenken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Abprallen** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Betonung**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Puls** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Farbpuls** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Wackeln** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Drehen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wachsen/Schrumpfen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Entsättigen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Verdunkeln** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Aufhellen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Transparenz** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Objektfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Komplementärfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Linienfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Füllfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |

**Ausgang**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Verschwinden** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Verblassen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Herausfliegen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Ausgleiten** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Teilen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wischen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Form** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Zufällige Balken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schrumpfen & Drehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoomen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schwenken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Abprallen** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Bewegungspfade**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linien** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Bögen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Drehungen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Formen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schleifen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Benutzerdefinierter Pfad** | ![unterstützt](v.png) | ![unterstützt](v.png) |

## **FAQ**

### Ist es möglich, Präsentationen zu konvertieren, die passwortgeschützt sind?

Ja, Aspose.Slides unterstützt die Arbeit mit [passwortgeschützten Präsentationen](/slides/de/java/password-protected-presentation/). Beim Verarbeiten solcher Dateien muss das korrekte Passwort angegeben werden, damit die Bibliothek auf den Inhalt der Präsentation zugreifen kann.

### Unterstützt Aspose.Slides die Verwendung in Cloud‑Lösungen?

Ja, Aspose.Slides kann in Cloud‑Anwendungen und -Diensten integriert werden. Die Bibliothek ist für den Betrieb in Serverumgebungen ausgelegt und gewährleistet hohe Leistung sowie Skalierbarkeit für die Batch‑Verarbeitung von Dateien.

### Gibt es Größenbeschränkungen für Präsentationen während der Konvertierung?

Aspose.Slides kann Präsentationen praktisch jeder Größe verarbeiten. Bei sehr großen Dateien können jedoch zusätzliche Systemressourcen erforderlich sein, und es wird häufig empfohlen, die Präsentation zu optimieren, um die Leistung zu verbessern.