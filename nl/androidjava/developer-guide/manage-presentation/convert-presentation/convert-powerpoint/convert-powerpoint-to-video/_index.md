---
title: PowerPoint-presentaties naar video converteren op Android
linktitle: PowerPoint naar video
type: docs
weight: 130
url: /nl/androidjava/convert-powerpoint-to-video/
keywords:
- PowerPoint converteren
- presentatie converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar video
- presentatie naar video
- PPT naar video
- PPTX naar video
- PowerPoint naar MP4
- presentatie naar MP4
- PPT naar MP4
- PPTX naar MP4
- PPT opslaan als MP4
- PPTX opslaan als MP4
- PPT exporteren naar MP4
- PPTX exporteren naar MP4
- video conversie
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint-presentaties naar video kunt converteren in Java. Ontdek voorbeeldcode en automatiseringstechnieken om uw workflow te stroomlijnen."
---
## **Introductie**

Door uw PowerPoint‑presentatie naar video te converteren, krijgt u 

* **Toename in toegankelijkheid:** Alle apparaten (onafhankelijk van het platform) zijn standaard uitgerust met videospelers in tegenstelling tot toepassingen voor het openen van presentaties, waardoor gebruikers het gemakkelijker vinden om video's te openen of af te spelen.
* **Grotere bereik:** Met video's kunt u een groot publiek bereiken en hen informeren met inhoud die anders wellicht saai zou lijken in een presentatie. De meeste enquêtes en statistieken suggereren dat mensen video's vaker bekijken en consumeren dan andere vormen van content, en ze geven doorgaans de voorkeur aan dergelijke content.

{{% alert color="primary" %}} 

U wilt misschien onze [**PowerPoint naar Video Online Converter**](https://products.aspose.app/slides/nl/conversion/ppt-to-word) bekijken, want dit is een live en effectieve implementatie van het hier beschreven proces.

{{% /alert %}} 

## **PowerPoint naar video‑conversie in Aspose.Slides**

Aspose.Slides ondersteunt conversie van presentatie naar video.

* Gebruik **Aspose.Slides** om een reeks frames (van de presentatieslides) te genereren die overeenkomen met een bepaalde FPS (frames per seconde).
* Gebruik een hulpprogramma van derden zoals **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) om een video op basis van de frames te maken. 

### **PowerPoint naar video converteren**

1. Voeg dit toe aan uw POM‑bestand:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Download ffmpeg [hier](https://ffmpeg.org/download.html).

4. Voer de PowerPoint‑naar‑video Java‑code uit.

Deze Java‑code laat zien hoe u een presentatie (met een afbeelding en twee animatie‑effecten) naar een video kunt converteren:

```java
Presentation presentation = new Presentation();
try {
    // Voegt een glimlachvorm toe en animeert deze vervolgens
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

    // Configureer ffmpeg-binaries map. Zie deze pagina: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **Video‑effecten**

U kunt animaties toepassen op objecten op dia's en overgangen tussen dia's gebruiken. 

{{% alert color="primary" %}} 

U wilt misschien deze artikelen bekijken: [PowerPoint‑animatie](https://docs.aspose.com/slides/nl/androidjava/powerpoint-animation/), [Vorm‑animatie](https://docs.aspose.com/slides/nl/androidjava/shape-animation/), en [Vorm‑effect](https://docs.aspose.com/slides/nl/androidjava/shape-effect/).

{{% /alert %}} 

Animaties en overgangen maken diavoorstellingen boeiender en interessanter — en ze hebben hetzelfde effect op video's. Laten we een extra dia en overgang toevoegen aan de code voor de vorige presentatie:

```java
// Voegt een glimlachvorm toe en animeert deze

// ...

// Voegt een nieuwe dia toe en een geanimeerde overgang

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides ondersteunt ook animatie voor tekst. Dus we animeren alinea’s op objecten, die één voor één verschijnen (met een vertraging van een seconde):

```java
Presentation presentation = new Presentation();
try {
    // Voegt tekst en animaties toe
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

    // Configureer de map met ffmpeg-binaries. Zie deze pagina: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **Klassen voor video‑conversie**

Om u in staat te stellen PowerPoint‑naar‑video‑conversietaken uit te voeren, biedt Aspose.Slides de klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationanimationsgenerator/) en [PresentationPlayer](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationplayer/) aan.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationanimationsgenerator/) stelt u in staat de frame‑grootte voor de video (die later wordt aangemaakt) in te stellen via de constructor. Als u een instantie van de presentatie doorgeeft, wordt `Presentation.SlideSize` gebruikt en genereert het animaties die [PresentationPlayer](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationplayer/) gebruikt.

Wanneer animaties worden gegenereerd, wordt voor elke opeenvolgende animatie een `NewAnimation`‑event gegenereerd, met de parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationanimationplayer/). Deze laatste is een klasse die een speler voor een afzonderlijke animatie voorstelt.

Om te werken met [IPresentationAnimationPlayer](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationanimationplayer/), worden de eigenschap [Duration](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (de volledige duur van de animatie) en de methode [SetTimePosition](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) gebruikt. Elke animatie‑positie wordt ingesteld binnen het bereik *0 tot duur*, waarna de `GetFrame`‑methode een BufferedImage retourneert die overeenkomt met de animatiestatus op dat moment:

```java
Presentation presentation = new Presentation();
try {
    // Voegt een glimlachvorm toe en animeert deze
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
            animationPlayer.setTimePosition(0); // initiële animatiestatus
            try {
                // bitmap van de initiële animatiestatus
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // laatste frame van de animatie
            try {
                // laatste frame van de animatie
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

Om alle animaties in een presentatie tegelijk af te spelen, wordt de klasse [PresentationPlayer](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationplayer/) gebruikt. Deze klasse neemt een instantie van [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationanimationsgenerator/) en FPS voor effecten in de constructor en roept vervolgens het `FrameTick`‑event aan voor alle animaties om ze af te spelen:

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

Vervolgens kunnen de gegenereerde frames worden samengevoegd om een video te maken. Zie de sectie [Convert PowerPoint to Video](https://docs.aspose.com/slides/nl/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Ondersteunde animaties en effecten**

**Ingang**:

| Animatietype | Aspose.Slides | PowerPoint |
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

**Nadruk**:

| Animatietype | Aspose.Slides | PowerPoint |
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

**Uitgang**:

| Animatietype | Aspose.Slides | PowerPoint |
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

**Bewegingspaden:** 

| Animatietype | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Is het mogelijk om presentaties die met een wachtwoord beschermd zijn te converteren?**

Ja, Aspose.Slides ondersteunt het werken met [wachtwoord‑beveiligde presentaties](/slides/nl/androidjava/password-protected-presentation/). Bij het verwerken van dergelijke bestanden moet u het juiste wachtwoord opgeven zodat de bibliotheek toegang krijgt tot de inhoud van de presentatie.

**Ondersteunt Aspose.Slides het gebruik in cloud‑oplossingen?**

Ja, Aspose.Slides kan worden geïntegreerd in cloud‑applicaties en -services. De bibliotheek is ontworpen om te werken in serveromgevingen, waardoor hoge prestaties en schaalbaarheid gegarandeerd zijn voor batchverwerking van bestanden.

**Zijn er groottebeperkingen voor presentaties tijdens de conversie?**

Aspose.Slides kan presentaties van vrijwel elke grootte aan. Echter, bij zeer grote bestanden kunnen extra systeembronnen nodig zijn, en het wordt soms aanbevolen de presentatie te optimaliseren om de prestaties te verbeteren.