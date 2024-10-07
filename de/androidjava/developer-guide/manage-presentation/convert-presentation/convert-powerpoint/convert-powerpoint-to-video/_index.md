---
title: PowerPoint in Video konvertieren
type: docs
weight: 130
url: /androidjava/convert-powerpoint-to-video/
keywords: "PowerPoint konvertieren, PPT, PPTX, Präsentation, Video, MP4, PPT in Video, PPT in MP4, Java, Aspose.Slides"
description: "PowerPoint in Video in Java konvertieren"
---

Durch die Konvertierung Ihrer PowerPoint-Präsentation in ein Video erhalten Sie

* **Erhöhte Zugänglichkeit:** Alle Geräte (unabhängig von der Plattform) sind standardmäßig mit Videoplayern ausgestattet, im Gegensatz zu Anwendungen zum Öffnen von Präsentationen. Daher finden es die Benutzer einfacher, Videos zu öffnen oder abzuspielen.
* **Größere Reichweite:** Durch Videos können Sie ein großes Publikum erreichen und es mit Informationen ansprechen, die in einer Präsentation möglicherweise sonst langwierig erscheinen. Die meisten Umfragen und Statistiken deuten darauf hin, dass Menschen Videos mehr ansehen und konsumieren als andere Formen von Inhalten und sie im Allgemeinen solche Inhalte bevorzugen.

{{% alert color="primary" %}} 

Sie möchten möglicherweise unseren [**PowerPoint zu Video Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) überprüfen, da es eine Live- und effektive Implementierung des hier beschriebenen Prozesses ist.

{{% /alert %}} 

## **PowerPoint zu Video Konvertierung in Aspose.Slides**

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-22-11-release-notes/) haben wir die Unterstützung für die Konvertierung von Präsentationen in Videos implementiert.

* Verwenden Sie **Aspose.Slides**, um eine Reihe von Frames (aus den Präsentationsfolien) zu generieren, die einer bestimmten FPS (Bilder pro Sekunde) entsprechen
* Verwenden Sie ein Drittanbieter-Tool wie **ffmpeg** ([für Java](https://github.com/bramp/ffmpeg-cli-wrapper)), um ein Video basierend auf den Frames zu erstellen.

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

4. Führen Sie den PowerPoint in Video Java-Code aus.

Dieser Java-Code zeigt Ihnen, wie Sie eine Präsentation (die eine Figur und zwei Animationseffekte enthält) in ein Video konvertieren:

```java
Presentation presentation = new Presentation();
try {
    // Fügt eine Smiley-Form hinzu und animiert sie
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

    // Konfigurieren Sie den Ordner für ffmpeg-Binärdateien. Siehe diese Seite: https://github.com/rosenbjerg/FFMpegCore#installation
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

{{% alert color="primary" %}} 

Sie möchten möglicherweise diese Artikel sehen: [PowerPoint Animation](https://docs.aspose.com/slides/androidjava/powerpoint-animation/), [Formanimation](https://docs.aspose.com/slides/androidjava/shape-animation/) und [Formeffekt](https://docs.aspose.com/slides/androidjava/shape-effect/).

{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter – und sie tun dasselbe für Videos. Lassen Sie uns eine weitere Folie und einen Übergang zum Code der vorherigen Präsentation hinzufügen:

```java
// Fügt eine Smiley-Form hinzu und animiert sie

// ...

// Fügt eine neue Folie und animierten Übergang hinzu

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides unterstützt auch Animationen für Texte. So animieren wir Absätze auf Objekten, die nacheinander erscheinen (mit einer Verzögerung von einer Sekunde):

```java
Presentation presentation = new Presentation();
try {
    // Fügt Text und Animationen hinzu
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides für Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("konvertiere PowerPoint-Präsentation mit Text in Video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("Absatz für Absatz"));
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

    // Konfigurieren Sie den Ordner für ffmpeg-Binärdateien. Siehe diese Seite: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **Video-Konvertierungsklassen**

Um Ihnen die Durchführung von PowerPoint-zu-Video-Konvertierungsaufgaben zu ermöglichen, bietet Aspose.Slides die [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) und [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) Klassen.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) ermöglicht es Ihnen, die Frame-Größe für das Video (das später erstellt wird) durch seinen Konstruktor festzulegen. Wenn Sie eine Instanz der Präsentation übergeben, wird `Presentation.SlideSize` verwendet und es generiert Animationen, die von [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) verwendet werden.

Wenn Animationen erzeugt werden, wird ein `NewAnimation`-Ereignis für jede nachfolgende Animation generiert, das den Parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/) aufweist. Letzteres ist eine Klasse, die einen Player für eine separate Animation darstellt.

Um mit [IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/) zu arbeiten, werden die [Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (die gesamte Dauer der Animation) Eigenschaft und die [SetTimePosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) Methode verwendet. Jede Animationsposition wird im Bereich *0 bis Dauer* festgelegt, und dann gibt die `GetFrame`-Methode ein BufferedImage zurück, das dem Animationsstatus zu diesem Zeitpunkt entspricht:

```java
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
            System.out.println(String.format("Animation Gesamtdauer: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // Anfangszustand der Animation
            try {
                // Anfangszustand der Animationsbitmap
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // Endzustand der Animation
            try {
                // Letzter Frame der Animation
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

Um alle Animationen in einer Präsentation gleichzeitig abzuspielen, wird die [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) Klasse verwendet. Diese Klasse nimmt eine Instanz von [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) und FPS für Effekte in ihrem Konstruktor und ruft dann das `FrameTick`-Ereignis für alle Animationen auf, um sie abzuspielen:

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

Dann können die generierten Frames kompiliert werden, um ein Video zu produzieren. Siehe den Abschnitt [PowerPoint in Video konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Unterstützte Animationen und Effekte**

**Eingang**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Erscheinen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Ausblenden** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Einfliegen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schweben** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Teilen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wischen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Form** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Rad** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Zufällige Balken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wachsen & Drehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoom** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schwenken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hüpfen** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Betonung**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Puls** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Farbpuls** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
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

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Verschwinden** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Ausblenden** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hinausfliegen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hinausschweben** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Teilen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wischen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Form** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Zufällige Balken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schrumpfen & Drehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoom** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schwenken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hüpfen** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Bewegungswege:**

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linien** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Bögen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Drehungen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Formen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schleifen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Benutzerdefinierter Pfad** | ![unterstützt](v.png) | ![unterstützt](v.png) |