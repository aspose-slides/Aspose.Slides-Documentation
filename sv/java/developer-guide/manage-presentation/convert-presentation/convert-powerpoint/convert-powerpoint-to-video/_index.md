---
title: Konvertera PowerPoint-presentationer till video i Java
linktitle: PowerPoint till video
type: docs
weight: 130
url: /sv/java/convert-powerpoint-to-video/
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
- Java
- Aspose.Slides
description: "Lär dig hur du konverterar PowerPoint-presentationer till video i Java. Upptäck exempel på kod och automatiseringstekniker för att effektivisera ditt arbetsflöde."
---
## **Introduktion**

Genom att konvertera din PowerPoint- eller OpenDocument-presentation till video får du:

**Ökad tillgänglighet:** Alla enheter, oavsett plattform, är som standard utrustade med videospelare, vilket gör det enklare för användare att öppna eller spela upp videor jämfört med traditionella presentationsprogram.

**Bredare räckvidd:** Videor gör det möjligt att nå en större publik och presentera information i ett mer engagerande format. Undersökningar och statistik visar att folk föredrar att titta på och konsumera videoinnehåll framför andra former, vilket gör ditt budskap mer slagkraftigt.

{{% alert color="info" %}} 
Du kanske vill kolla in vår [**PowerPoint till Video Online‑konverterare**](https://products.aspose.app/slides/sv/video) eftersom den är en levande och effektiv implementering av processen som beskrivs här.
{{% /alert %}} 

## **PowerPoint till Video‑konvertering i Aspose.Slides**

I [Aspose.Slides 22.11](https://docs.aspose.com/slides/sv/java/aspose-slides-for-java-22-11-release-notes/) har vi implementerat stöd för konvertering av presentation till video. 

* Använd **Aspose.Slides** för att generera ett set av bildrutor (från presentationsbilderna) som motsvarar ett visst FPS (bilder per sekund)
* Använd ett tredjepartsverktyg som **ffmpeg** ([för java](https://github.com/bramp/ffmpeg-cli-wrapper)) för att skapa en video baserad på bildrutorna. 

### **Konvertera PowerPoint till Video**

1. Add this to your POM file:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Ladda ner ffmpeg [här](https://ffmpeg.org/download.html).

4. Kör PowerPoint till video Java‑koden.

Denna Java‑kod visar hur du konverterar en presentation (innehållande en figur och två animationseffekter) till en video:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Lägger till en smile-form och animerar den sedan
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

    // Konfigurera mappen för ffmpeg-binärfiler. Se den här sidan: https://github.com/rosenbjerg/FFMpegCore#installation
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

Du kan applicera animationer på objekt i bilder och använda övergångar mellan bilder. 

{{% alert color="info" %}} 
Du kanske vill se dessa artiklar: [PowerPoint‑animation](https://docs.aspose.com/slides/sv/java/powerpoint-animation/), [Form‑animation](https://docs.aspose.com/slides/sv/java/shape-animation/), och [Form‑effekt](https://docs.aspose.com/slides/sv/java/shape-effect/).
{{% /alert %}} 

Animationer och övergångar gör bildspel mer engagerande och intressanta—och de gör samma sak för videor. Låt oss lägga till en ytterligare bild och övergång i koden för den föregående presentationen:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // Lägger till en smile-form och animerar den

    // ...

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

Aspose.Slides stödjer också animation för texter. Så vi animerar stycken på objekt, som visas ett efter ett (med fördröjning inställd på en sekund):
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

    // Konfigurera ffmpeg-binärkatalogen. Se den här sidan: https://github.com/rosenbjerg/FFMpegCore#installation
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

För att du ska kunna utföra PowerPoint‑till‑video‑konverteringsuppgifter tillhandahåller Aspose.Slides klasserna [PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationanimationsgenerator/) och [PresentationPlayer](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationanimationsgenerator/) låter dig ange bildstorlek för videon (som kommer att skapas senare) via dess konstruktor. Om du skickar en instans av presentationen används `Presentation.SlideSize` och den genererar animationer som [PresentationPlayer](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationplayer/) använder. 

När animationer genereras skapas ett `NewAnimation`‑händelse för varje efterföljande animation, som har parametern [IPresentationAnimationPlayer](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationanimationplayer/). Den senare är en klass som representerar en spelare för en separat animation.

För att arbeta med [IPresentationAnimationPlayer](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationanimationplayer/), används egenskaperna [Duration](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (animationens fulla varaktighet) och metoden [SetTimePosition](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) . Varje animationsposition sätts inom intervallet *0 till varaktighet*, och sedan returnerar `getFrame`‑metoden en [IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/) som motsvarar animationstillståndet vid den tidpunkten:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Lägger till en smile-form och animerar den
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

            animationPlayer.setTimePosition(0); // initialt animationstillstånd
            // bitmap för initialt animationstillstånd
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // slutligt animationstillstånd
            // sista bildrutan i animationen
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // generera animationerna - detta är vad som triggar händelserna ovan
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

För att få alla animationer i en presentation att spela samtidigt används klassen [PresentationPlayer](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationplayer/). Denna klass tar en [PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationanimationsgenerator/)‑instans och FPS för effekter i dess konstruktor och anropar sedan `FrameTick`‑händelsen för alla animationer för att spela dem:
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

Sedan kan de genererade bildrutorna kompileras för att producera en video. Se avsnittet [Convert PowerPoint to Video](https://docs.aspose.com/slides/sv/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Stödda animationer och effekter**

**Ingång**:

| Animations­typ | Aspose.Slides | PowerPoint |
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

**Betoning**:

| Animations­typ | Aspose.Slides | PowerPoint |
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

**Utgång**:

| Animations­typ | Aspose.Slides | PowerPoint |
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

**Rörelsebanor**:

| Animations­typ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Vanliga frågor**

### Är det möjligt att konvertera lösenordsskyddade presentationer?

Ja, Aspose.Slides möjliggör arbete med [lösenordsskyddade presentationer](/slides/sv/java/password-protected-presentation/). När sådana filer behandlas måste du ange rätt lösenord så att biblioteket kan komma åt presentationens innehåll.

### Stöder Aspose.Slides användning i molnlösningar?

Ja, Aspose.Slides kan integreras i molnapplikationer och -tjänster. Biblioteket är utformat för att fungera i servermiljöer och säkerställer hög prestanda och skalbarhet för batchbearbetning av filer.

### Finns det några storleksbegränsningar för presentationer vid konvertering?

Aspose.Slides kan hantera presentationer av praktiskt taget vilken storlek som helst. När man arbetar med väldigt stora filer kan dock extra systemresurser krävas, och det rekommenderas ibland att optimera presentationen för att förbättra prestandan.