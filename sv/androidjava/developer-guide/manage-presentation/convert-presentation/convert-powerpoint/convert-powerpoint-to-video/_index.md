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

* **Ökad tillgänglighet:** Alla enheter (oavsett plattform) är som standard utrustade med videospelare jämfört med program för att öppna presentationer, så användare finner det lättare att öppna eller spela upp videor.
* **Större räckvidd:** Genom videor kan du nå en stor publik och rikta dem med information som annars kan verka tungrodd i en presentation. De flesta undersökningar och statistik visar att människor tittar på och konsumerar videor mer än andra former av innehåll, och de föredrar generellt sådant innehåll.

{{% alert color="primary" %}} 

Du kanske vill titta på vår [**PowerPoint till Video Onlinekonverterare**](https://products.aspose.app/slides/sv/conversion/ppt-to-word) eftersom det är en levande och effektiv implementering av processen som beskrivs här.

{{% /alert %}} 

## **PowerPoint till Video‑konvertering i Aspose.Slides**

Aspose.Slides stöder konvertering av presentation till video.

* Använd **Aspose.Slides** för att generera en uppsättning bildrutor (från presentationsbilderna) som motsvarar ett visst FPS (bilder per sekund)
* Använd ett tredjepartsverktyg som **ffmpeg** ([för java](https://github.com/bramp/ffmpeg-cli-wrapper)) för att skapa en video baserad på bildrutorna. 

### **Konvertera PowerPoint till Video**

1. Lägg till detta i din POM-fil:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Ladda ner ffmpeg [här](https://ffmpeg.org/download.html).

4. Kör PowerPoint till video Java-koden.

Denna Java-kod visar hur du konverterar en presentation (innehållande en figur och två animationseffekter) till en video:

```java
Presentation presentation = new Presentation();
try {
    // Lägger till en smileyform och animerar den sedan
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

    // Konfigurera katalogen för ffmpeg-binärer. Se den här sidan: https://github.com/rosenbjerg/FFMpegCore#installation
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

{{% alert color="primary" %}} 

Du kanske vill se dessa artiklar: [PowerPoint‑animation](https://docs.aspose.com/slides/sv/androidjava/powerpoint-animation/), [Form‑animation](https://docs.aspose.com/slides/sv/androidjava/shape-animation/), och [Form‑effekt](https://docs.aspose.com/slides/sv/androidjava/shape-effect/).

{{% /alert %}} 

Animationer och övergångar gör bildspel mer engagerande och intressanta—och de har samma effekt för videor. Låt oss lägga till ytterligare en bild och en övergång i koden för den föregående presentationen:

```java
// Lägger till en smileyform och animerar den

// ...

// Lägger till en ny bild och animerad övergång

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides stöder även animation för text. Så vi animerar stycken på objekt, som kommer att visas ett efter ett (med fördröjning satt till en sekund):

```java
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

För att låta dig utföra PowerPoint‑till‑video‑konverteringsuppgifter tillhandahåller Aspose.Slides klasserna [PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentationanimationsgenerator/) och [PresentationPlayer](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator] låter dig ange bildstorlek för videon (som kommer att skapas senare) via dess konstruktor. Om du skickar en instans av presentationen kommer `Presentation.SlideSize` att användas och den genererar animationer som [PresentationPlayer] använder.

När animationer genereras skapas ett `NewAnimation`‑händelse för varje efterföljande animation, som har [IPresentationAnimationPlayer]-parametern. Den senare är en klass som representerar en spelare för en separat animation.

För att arbeta med [IPresentationAnimationPlayer] används egenskapen [Duration] (animationens totala varaktighet) och metoden [SetTimePosition]. Varje animationsposition sätts inom intervallet *0 till varaktighet*, och sedan kommer `GetFrame`‑metoden att returnera en BufferedImage som motsvarar animationstillståndet vid det tillfället:

```java
Presentation presentation = new Presentation();
try {
    // Lägger till en smileyform och animerar den
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
            try {
                // bitmap för initialt animationstillstånd
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // slutligt animationstillstånd
            try {
                // sista bildrutan av animationen
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

För att låta alla animationer i en presentation spelas samtidigt används klassen [PresentationPlayer]. Denna klass tar en [PresentationAnimationsGenerator]-instans och FPS för effekter i sin konstruktor och anropar sedan `FrameTick`‑händelsen för alla animationer för att få dem spelade:

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

Sedan kan de genererade bildrutorna kompileras för att producera en video. Se avsnittet [Konvertera PowerPoint till Video](https://docs.aspose.com/slides/sv/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video) .

## **Stödda animationer och effekter**

**Ingång**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Visa** | ![not supported](x.png) | ![supported](v.png) |
| **Tona** | ![supported](v.png) | ![supported](v.png) |
| **Flyga in** | ![supported](v.png) | ![supported](v.png) |
| **Flyt in** | ![supported](v.png) | ![supported](v.png) |
| **Dela** | ![supported](v.png) | ![supported](v.png) |
| **Svepa** | ![supported](v.png) | ![supported](v.png) |
| **Form** | ![supported](v.png) | ![supported](v.png) |
| **Hjul** | ![supported](v.png) | ![supported](v.png) |
| **Slumpmässiga staplar** | ![supported](v.png) | ![supported](v.png) |
| **Väx och vrid** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Snurra** | ![supported](v.png) | ![supported](v.png) |
| **Studs** | ![supported](v.png) | ![supported](v.png) |

**Betoning**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulsering** | ![not supported](x.png) | ![supported](v.png) |
| **Färgpulsering** | ![not supported](x.png) | ![supported](v.png) |
| **Vobba** | ![supported](v.png) | ![supported](v.png) |
| **Snurra** | ![supported](v.png) | ![supported](v.png) |
| **Växa/krempa** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturera** | ![not supported](x.png) | ![supported](v.png) |
| **Mörkare** | ![not supported](x.png) | ![supported](v.png) |
| **Ljusare** | ![not supported](x.png) | ![supported](v.png) |
| **Transparens** | ![not supported](x.png) | ![supported](v.png) |
| **Objektsfärg** | ![not supported](x.png) | ![supported](v.png) |
| **Komplementfärg** | ![not supported](x.png) | ![supported](v.png) |
| **Linjefärg** | ![not supported](x.png) | ![supported](v.png) |
| **Fyllnadsfärg** | ![not supported](x.png) | ![supported](v.png) |

**Utgång**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Försvinna** | ![not supported](x.png) | ![supported](v.png) |
| **Tona** | ![supported](v.png) | ![supported](v.png) |
| **Flyga ut** | ![supported](v.png) | ![supported](v.png) |
| **Flyt ut** | ![supported](v.png) | ![supported](v.png) |
| **Dela** | ![supported](v.png) | ![supported](v.png) |
| **Svepa** | ![supported](v.png) | ![supported](v.png) |
| **Form** | ![supported](v.png) | ![supported](v.png) |
| **Slumpmässiga staplar** | ![supported](v.png) | ![supported](v.png) |
| **Krymp och vrid** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Snurra** | ![supported](v.png) | ![supported](v.png) |
| **Studs** | ![supported](v.png) | ![supported](v.png) |

**Rörelsesökvägar**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linjer** | ![supported](v.png) | ![supported](v.png) |
| **Bågar** | ![supported](v.png) | ![supported](v.png) |
| **Vändningar** | ![supported](v.png) | ![supported](v.png) |
| **Former** | ![supported](v.png) | ![supported](v.png) |
| **Loopar** | ![supported](v.png) | ![supported](v.png) |
| **Anpassad bana** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Är det möjligt att konvertera lösenordsskyddade presentationer?**

Ja, Aspose.Slides möjliggör arbete med [lösenordsskyddade presentationer](/slides/sv/androidjava/password-protected-presentation/). När du bearbetar sådana filer måste du ange rätt lösenord så att biblioteket kan komma åt presentationens innehåll.

**Stöder Aspose.Slides användning i molnlösningar?**

Ja, Aspose.Slides kan integreras i molnapplikationer och -tjänster. Biblioteket är designat för att fungera i servermiljöer, vilket säkerställer hög prestanda och skalbarhet för batchbearbetning av filer.

**Finns det några storleksbegränsningar för presentationer vid konvertering?**

Aspose.Slides kan hantera presentationer av i praktiken vilken storlek som helst. När du arbetar med mycket stora filer kan dock ytterligare systemresurser behövas, och det rekommenderas ibland att optimera presentationen för att förbättra prestandan.