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
- video-conversie
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint-presentaties naar video kunt converteren in Java. Ontdek voorbeeldcode en automatiseringstechnieken om uw workflow te stroomlijnen."
---
## **Introductie**

Door uw PowerPoint‑presentatie naar video te converteren, krijgt u 

* **Verbeterde toegankelijkheid:** Alle apparaten (ongeacht het platform) zijn standaard uitgerust met videospelers in plaats van presentatiesoftware, waardoor gebruikers het makkelijker vinden om video's te openen of af te spelen.
* **Grotere bereik:** Met video’s kunt u een breed publiek bereiken en hen informeren met inhoud die in een presentatie anders misschien als saai wordt ervaren. De meeste onderzoeken en statistieken geven aan dat mensen video’s meer bekijken en consumeren dan andere vormen van content, en ze geven doorgaans de voorkeur aan dit type inhoud.

## **PowerPoint‑naar‑Video‑conversie in Aspose.Slides**

Aspose.Slides ondersteunt conversie van presentaties naar video.

* Gebruik **Aspose.Slides** om een reeks frames te genereren (van de presentatieslides) die overeenkomen met een bepaalde FPS (frames per seconde).
* Gebruik een hulpprogramma van derden zoals **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) om een video te maken op basis van de frames. 

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

3. Voer de PowerPoint‑naar‑video Java‑code uit.

Deze Java‑code laat zien hoe u een presentatie (met een afbeelding en twee animatie‑effecten) naar een video converteert:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    // Configureer de ffmpeg-binaire map. Zie deze pagina: https://github.com/bramp/ffmpeg-cli-wrapper
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

{{% alert color="info" %}} 
U wilt misschien deze artikelen bekijken: [PowerPoint‑animatie](https://docs.aspose.com/slides/nl/androidjava/powerpoint-animation/), [Vormanimatie](https://docs.aspose.com/slides/nl/androidjava/shape-animation/), en [Vorm‑effect](https://docs.aspose.com/slides/nl/androidjava/shape-effect/).
{{% /alert %}} 

Animaties en overgangen maken diavoorstellingen boeiender en interessanter – en ze doen hetzelfde voor video’s. Laten we een extra dia en overgang aan de code voor de vorige presentatie toevoegen:
```java
import com.aspose.slides.*;
import java.awt.Color;

// De presentatie met de hierboven gemaakte geanimeerde glimlachvorm.
Presentation presentation = new Presentation();
try {
    // Voegt een nieuwe dia toe en een geanimeerde overgang

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides ondersteunt ook animatie voor tekst. We animeren dus alinea’s op objecten, die één voor één verschijnen (met een vertraging van een seconde):
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    // Configureer de ffmpeg-binaire map. Zie deze pagina: https://github.com/bramp/ffmpeg-cli-wrapper
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

Om u PowerPoint‑naar‑video‑conversietaken te laten uitvoeren, biedt Aspose.Slides de klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationanimationsgenerator/) en [PresentationPlayer](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationplayer/) aan.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationanimationsgenerator/) stelt u in staat de frame‑grootte voor de video (die later wordt aangemaakt) in te stellen via de constructor. Als u een instantie van de presentatie doorgeeft, wordt `Presentation.SlideSize` gebruikt en genereert deze animaties die [PresentationPlayer](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationplayer/) gebruikt.

Wanneer animaties worden gegenereerd, wordt voor elke volgende animatie een `NewAnimation`‑event gegenereerd, dat een [IPresentationAnimationPlayer](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationanimationplayer/)‑parameter heeft. Deze klasse vertegenwoordigt een speler voor een afzonderlijke animatie.

Om te werken met [IPresentationAnimationPlayer](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationanimationplayer/), worden de eigenschap [Duration](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (de volledige duur van de animatie) en de methode [SetTimePosition](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) gebruikt. Elke animatie‑positie wordt ingesteld binnen het bereik *0 tot duur*, en vervolgens geeft de `getFrame`‑methode een [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/) terug die overeenkomt met de animatiestatus op dat moment:
```java
import com.aspose.slides.*;

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
            // bitmap van de initiële animatiestatus
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // finale status van de animatie
            // laatste frame van de animatie
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // Genereer de animaties. De callback hierboven wordt voor elk van hen uitgevoerd.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Om alle animaties in een presentatie tegelijk af te spelen, wordt de klasse [PresentationPlayer](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationplayer/) gebruikt. Deze klasse neemt een instantie van [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationanimationsgenerator/) en een FPS voor de effecten in de constructor en roept vervolgens het `FrameTick`‑event aan voor alle animaties om ze af te spelen:
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

Vervolgens kunnen de gegenereerde frames worden samengevoegd tot een video. Zie de sectie [Convert PowerPoint to Video](https://docs.aspose.com/slides/nl/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Ondersteunde animaties en effecten**

**Ingang**:

| Animatietype | Aspose.Slides | PowerPoint |
|---|---|---|
| **Verschijnen** | ![not supported](x.png) | ![supported](v.png) |
| **Vervagen** | ![supported](v.png) | ![supported](v.png) |
| **Invliegen** | ![supported](v.png) | ![supported](v.png) |
| **Inzweven** | ![supported](v.png) | ![supported](v.png) |
| **Splitsen** | ![supported](v.png) | ![supported](v.png) |
| **Wegvegen** | ![supported](v.png) | ![supported](v.png) |
| **Vorm** | ![supported](v.png) | ![supported](v.png) |
| **Wiel** | ![supported](v.png) | ![supported](v.png) |
| **Willekeurige balken** | ![supported](v.png) | ![supported](v.png) |
| **Groeien en draaien** | ![not supported](x.png) | ![supported](v.png) |
| **Zoomen** | ![supported](v.png) | ![supported](v.png) |
| **Draaien** | ![supported](v.png) | ![supported](v.png) |
| **Stuiteren** | ![supported](v.png) | ![supported](v.png) |

**Nadruk**:

| Animatietype | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Kleurpuls** | ![not supported](x.png) | ![supported](v.png) |
| **Wiegen** | ![supported](v.png) | ![supported](v.png) |
| **Draaien** | ![supported](v.png) | ![supported](v.png) |
| **Groeien/Krimpelen** | ![not supported](x.png) | ![supported](v.png) |
| **Desatureren** | ![not supported](x.png) | ![supported](v.png) |
| **Donkerder maken** | ![not supported](x.png) | ![supported](v.png) |
| **Lichter maken** | ![not supported](x.png) | ![supported](v.png) |
| **Transparantie** | ![not supported](x.png) | ![supported](v.png) |
| **Objectkleur** | ![not supported](x.png) | ![supported](v.png) |
| **Complementaire kleur** | ![not supported](x.png) | ![supported](v.png) |
| **Lijnekleur** | ![not supported](x.png) | ![supported](v.png) |
| **Vulkleur** | ![not supported](x.png) | ![supported](v.png) |

**Uitgang**:

| Animatietype | Aspose.Slides | PowerPoint |
|---|---|---|
| **Verdwijnen** | ![not supported](x.png) | ![supported](v.png) |
| **Vervagen** | ![supported](v.png) | ![supported](v.png) |
| **Uithalen** | ![supported](v.png) | ![supported](v.png) |
| **Uitzweven** | ![supported](v.png) | ![supported](v.png) |
| **Splitsen** | ![supported](v.png) | ![supported](v.png) |
| **Wegvegen** | ![supported](v.png) | ![supported](v.png) |
| **Vorm** | ![supported](v.png) | ![supported](v.png) |
| **Willekeurige balken** | ![supported](v.png) | ![supported](v.png) |
| **Krompen en draaien** | ![not supported](x.png) | ![supported](v.png) |
| **Zoomen** | ![supported](v.png) | ![supported](v.png) |
| **Draaien** | ![supported](v.png) | ![supported](v.png) |
| **Stuiteren** | ![supported](v.png) | ![supported](v.png) |

**Bewegingspaden**:

| Animatietype | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lijnen** | ![supported](v.png) | ![supported](v.png) |
| **Boogjes** | ![supported](v.png) | ![supported](v.png) |
| **Draaiingen** | ![supported](v.png) | ![supported](v.png) |
| **Vormen** | ![supported](v.png) | ![supported](v.png) |
| **Lussen** | ![supported](v.png) | ![supported](v.png) |
| **Aangepast pad** | ![supported](v.png) | ![supported](v.png) |

## **Veelgestelde vragen**

### Is het mogelijk om presentaties die met een wachtwoord beveiligd zijn te converteren?

Ja, Aspose.Slides maakt het mogelijk om met [wachtwoordbeveiligde presentaties](/slides/nl/androidjava/password-protected-presentation/) te werken. Bij het verwerken van dergelijke bestanden moet u het juiste wachtwoord opgeven zodat de bibliotheek toegang krijgt tot de inhoud van de presentatie.

### Ondersteunt Aspose.Slides gebruik in cloud‑oplossingen?

Ja, Aspose.Slides kan worden geïntegreerd in cloud‑applicaties en -services. De bibliotheek is ontworpen om in serveromgevingen te werken, wat zorgt voor hoge prestaties en schaalbaarheid bij batchverwerking van bestanden.

### Zijn er grootte‑beperkingen voor presentaties tijdens conversie?

Aspose.Slides kan praktisch elke grootte van een presentatie aan. Bij het werken met zeer grote bestanden kunnen echter extra systeembronnen nodig zijn, en het wordt soms aangeraden de presentatie te optimaliseren om de prestaties te verbeteren.