---
title: Konvertera PowerPoint-presentationer till video på Android
linktitle: PowerPoint till video
type: docs
weight: 130
url: /sv/androidjava/convert-powerpoint-to-video/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera PPT
- konvertera PPTX
- PowerPoint till video
- presentation till video
- PPT till video
- PPTX till video
- PowerPoint till MP4
- presentation till MP4
- PPT till MP4
- PPTX till MP4
- spara PPT som MP4
- spara PPTX som MP4
- exportera PPT till MP4
- exportera PPTX till MP4
- videokonvertering
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du konverterar PowerPoint-presentationer till video i Java. Upptäck exempel på kod och automatiseringstekniker för att effektivisera ditt arbetsflöde."
---
## **Introduktion**

Genom att konvertera din PowerPoint-presentation till video får du 

* **Ökad tillgänglighet:** Alla enheter (oavsett plattform) är som standard utrustade med videospelare jämfört med program för att öppna presentationer, så användare har det lättare att öppna eller spela upp videor.
* **Större räckvidd:** Genom videor kan du nå en stor publik och rikta information till dem som annars kan upplevas som tråkig i en presentation. De flesta undersökningar och statistik visar att människor tittar på och konsumerar videor mer än andra former av innehåll, och de föredrar generellt sådant innehåll.

## **PowerPoint till video‑konvertering i Aspose.Slides**

Aspose.Slides stöder konvertering från presentation till video.

* Använd **Aspose.Slides** för att generera en uppsättning bildrutor (från presentationsbilderna) som motsvarar en viss FPS (bilder per sekund)
* Använd ett tredjepartsverktyg som **ffmpeg** ([för java](https://github.com/bramp/ffmpeg-cli-wrapper)) för att skapa en video baserad på bildrutorna. 

### **Konvertera PowerPoint till video**

1. Add this to your POM file:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Download ffmpeg [här](https://ffmpeg.org/download.html).

3. Kör Java‑koden för PowerPoint till video.

Denna Java‑kod visar hur du konverterar en presentation (med en figur och två animeringseffekter) till en video:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Lägger till en leendeform och animerar den sedan
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

    // Konfigurera ffmpeg-binärkatalogen. Se den här sidan: https://github.com/bramp/ffmpeg-cli-wrapper
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

## **Videoeffekter**

Du kan applicera animationer på objekt på bilder och använda övergångar mellan bilder. 

{{% alert color="info" %}} 

Du kanske vill se dessa artiklar: [PowerPoint‑animation](https://docs.aspose.com/slides/sv/androidjava/powerpoint-animation/), [Form‑animation](https://docs.aspose.com/slides/sv/androidjava/shape-animation/), och [Form‑effekt](https://docs.aspose.com/slides/sv/androidjava/shape-effect/).

{{% /alert %}} 

Animationer och övergångar gör bildspel mer engagerande och intressanta—och de gör samma sak för videor. Låt oss lägga till en ytterligare bild och en övergång i koden för den föregående presentationen:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentationen med den animerade leendeformen som skapades ovan.
Presentation presentation = new Presentation();
try {
    // Lägger till en ny bild och animerad övergång

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides stöder också animation för text. Så vi animerar stycken på objekt, som visas ett efter ett (med fördröjning på en sekund):

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Lägger till text och animationer
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

    // Konfigurera ffmpeg-binärkatalogen. Se den här sidan: https://github.com/bramp/ffmpeg-cli-wrapper
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

## **Klasser för videokonvertering**

För att låta dig utföra PowerPoint‑till‑video‑konverteringsuppgifter tillhandahåller Aspose.Slides klasserna [PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentationanimationsgenerator/) och [PresentationPlayer](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator] låter dig ange bildrutinens storlek för den video (som kommer att skapas senare) via sin konstruktor. Om du passerar en instans av presentationen används `Presentation.SlideSize` och den genererar animationer som [PresentationPlayer] använder.

När animationer genereras skapas ett `NewAnimation`‑event för varje efterföljande animation, som har parametern [IPresentationAnimationPlayer]. Den senare är en klass som representerar en spelare för en separat animation.

För att arbeta med [IPresentationAnimationPlayer] används egenskaperna [Duration] (animationens totala varaktighet) och [SetTimePosition]. Varje animationsposition sätts inom intervallet *0 till varaktighet*, och sedan kommer `getFrame`‑metoden att returnera en [IImage] som motsvarar animationstillståndet vid den tidpunkten:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Lägger till en leendeform och animerar den
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

            animationPlayer.setTimePosition(0); // initialt animeringstillstånd
            // bitmap för initialt animeringstillstånd
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // slutligt animeringstillstånd
            // sista bildrutan i animationen
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // Generera animationerna. Callback-funktionen ovan körs för var och en av dem.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

För att få alla animationer i en presentation att spelas upp samtidigt används klassen [PresentationPlayer]. Denna klass tar en [PresentationAnimationsGenerator]-instans och FPS för effekter i sin konstruktor och anropar sedan `FrameTick`‑eventet för alla animationer för att spela upp dem:

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

Sedan kan de genererade bildrutorna kompileras för att skapa en video. Se avsnittet [Konvertera PowerPoint till video].

## **Stödda animationer och effekter**

**Ingång**

| Animeringstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![ej stöd](x.png) | ![stöd](v.png) |
| **Fade** | ![stöd](v.png) | ![stöd](v.png) |
| **Fly In** | ![stöd](v.png) | ![stöd](v.png) |
| **Float In** | ![stöd](v.png) | ![stöd](v.png) |
| **Split** | ![stöd](v.png) | ![stöd](v.png) |
| **Wipe** | ![stöd](v.png) | ![stöd](v.png) |
| **Shape** | ![stöd](v.png) | ![stöd](v.png) |
| **Wheel** | ![stöd](v.png) | ![stöd](v.png) |
| **Random Bars** | ![stöd](v.png) | ![stöd](v.png) |
| **Grow & Turn** | ![ej stöd](x.png) | ![stöd](v.png) |
| **Zoom** | ![stöd](v.png) | ![stöd](v.png) |
| **Swivel** | ![stöd](v.png) | ![stöd](v.png) |
| **Bounce** | ![stöd](v.png) | ![stöd](v.png) |

**Betoning**

| Animeringstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![ej stöd](x.png) | ![stöd](v.png) |
| **Color Pulse** | ![ej stöd](x.png) | ![stöd](v.png) |
| **Teeter** | ![stöd](v.png) | ![stöd](v.png) |
| **Spin** | ![stöd](v.png) | ![stöd](v.png) |
| **Grow/Shrink** | ![ej stöd](x.png) | ![stöd](v.png) |
| **Desaturate** | ![ej stöd](x.png) | ![stöd](v.png) |
| **Darken** | ![ej stöd](x.png) | ![stöd](v.png) |
| **Lighten** | ![ej stöd](x.png) | ![stöd](v.png) |
| **Transparency** | ![ej stöd](x.png) | ![stöd](v.png) |
| **Object Color** | ![ej stöd](x.png) | ![stöd](v.png) |
| **Complementary Color** | ![ej stöd](x.png) | ![stöd](v.png) |
| **Line Color** | ![ej stöd](x.png) | ![stöd](v.png) |
| **Fill Color** | ![ej stöd](x.png) | ![stöd](v.png) |

**Utgång**

| Animeringstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![ej stöd](x.png) | ![stöd](v.png) |
| **Fade** | ![stöd](v.png) | ![stöd](v.png) |
| **Fly Out** | ![stöd](v.png) | ![stöd](v.png) |
| **Float Out** | ![stöd](v.png) | ![stöd](v.png) |
| **Split** | ![stöd](v.png) | ![stöd](v.png) |
| **Wipe** | ![stöd](v.png) | ![stöd](v.png) |
| **Shape** | ![stöd](v.png) | ![stöd](v.png) |
| **Random Bars** | ![stöd](v.png) | ![stöd](v.png) |
| **Shrink & Turn** | ![ej stöd](x.png) | ![stöd](v.png) |
| **Zoom** | ![stöd](v.png) | ![stöd](v.png) |
| **Swivel** | ![stöd](v.png) | ![stöd](v.png) |
| **Bounce** | ![stöd](v.png) | ![stöd](v.png) |

**Rörelsebanor:**

| Animeringstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![stöd](v.png) | ![stöd](v.png) |
| **Arcs** | ![stöd](v.png) | ![stöd](v.png) |
| **Turns** | ![stöd](v.png) | ![stöd](v.png) |
| **Shapes** | ![stöd](v.png) | ![stöd](v.png) |
| **Loops** | ![stöd](v.png) | ![stöd](v.png) |
| **Custom Path** | ![stöd](v.png) | ![stöd](v.png) |

## **Vanliga frågor**

### Är det möjligt att konvertera presentationer som är lösenordsskyddade?

Ja, Aspose.Slides möjliggör arbete med [lösenordsskyddade presentationer](/slides/sv/androidjava/password-protected-presentation/). När du bearbetar sådana filer måste du ange rätt lösenord så att biblioteket kan komma åt presentationens innehåll.

### Stöder Aspose.Slides användning i molnlösningar?

Ja, Aspose.Slides kan integreras i molnapplikationer och tjänster. Biblioteket är designat för att fungera i servermiljöer och säkerställer hög prestanda och skalbarhet för batchbearbetning av filer.

### Finns det några storleksbegränsningar för presentationer vid konvertering?

Aspose.Slides kan hantera presentationer av i princip vilken storlek som helst. Vid arbete med mycket stora filer kan dock extra systemresurser krävas, och det rekommenderas ibland att optimera presentationen för att förbättra prestandan.