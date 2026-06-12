---
title: PowerPoint-presentaties naar video converteren in JavaScript
linktitle: PowerPoint naar video
type: docs
weight: 130
url: /nl/nodejs-java/convert-powerpoint-to-video/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u PowerPoint-presentaties naar video kunt converteren met JavaScript. Ontdek voorbeeldcode en automatiseringstechnieken om uw workflow te stroomlijnen."
---
## **Introductie**

Door uw PowerPoint‑presentatie naar video te converteren, krijgt u 

* **Toename van toegankelijkheid:** Alle apparaten (ongeacht platform) hebben standaard videospelers, in tegenstelling tot applicaties die presentaties openen, waardoor gebruikers video's makkelijker kunnen openen of afspelen.
* **Groter bereik:** Met video's kunt u een groot publiek bereiken en hen informatie aanbieden die in een presentatie anders misschien als saai wordt ervaren. De meeste onderzoeken en statistieken geven aan dat mensen meer video’s bekijken en consumeren dan andere vormen van content, en ze geven over het algemeen de voorkeur aan dit type content.

{{% alert color="primary" %}} 

U wilt wellicht onze [**PowerPoint‑naar‑Video Online Converter**](https://products.aspose.app/slides/nl/conversion/ppt-to-word) bekijken, omdat dit een live en effectieve implementatie is van het hier beschreven proces.

{{% /alert %}} 

## **PowerPoint‑naar‑Video‑conversie in Aspose.Slides**

Aspose.Slides ondersteunt conversie van presentaties naar video.

* Gebruik **Aspose.Slides** om een reeks frames (van de presentatieslides) te genereren die overeenkomen met een bepaald FPS (frames per seconde)
* Gebruik een hulpprogramma van derden zoals **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) om op basis van die frames een video te maken. 

### **PowerPoint naar video converteren**

1. Download ffmpeg [here](https://ffmpeg.org/download.html).

2. Voer de PowerPoint‑naar‑video JavaScript‑code uit.

Deze JavaScript‑code laat zien hoe u een presentatie (met een figuur en twee animatie‑effecten) naar video converteert:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Voegt een smiley-vorm toe en animeert deze daarna
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
    // Configureer de map met ffmpeg-binaries. Zie deze pagina: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Video‑effecten**

U kunt animaties toepassen op objecten op dia’s en overgangen tussen dia’s gebruiken. 

{{% alert color="primary" %}} 

U wilt deze artikelen bekijken: [PowerPoint Animation](https://docs.aspose.com/slides/nl/nodejs-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/nl/nodejs-java/shape-animation/), en [Shape Effect](https://docs.aspose.com/slides/nl/nodejs-java/shape-effect/).

{{% /alert %}} 

Animaties en overgangen maken diavoorstellingen boeiender en interessanter — en ze doen hetzelfde voor video’s. Laten we een extra dia en overgang toevoegen aan de code van de vorige presentatie:

```javascript
// Voegt een smile-vorm toe en animeert deze
// ...
// Voegt een nieuwe dia toe en een geanimeerde overgang
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Aspose.Slides ondersteunt ook animatie voor tekst. We animeren alinea’s op objecten, die één voor één verschijnen (met een vertraging van een seconde):

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Voegt tekst en animaties toe
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
    // Configureer de map met ffmpeg-binaries. Zie deze pagina: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Klassen voor video‑conversie**

Om u in staat te stellen PowerPoint‑naar‑video‑conversietaken uit te voeren, biedt Aspose.Slides de klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationanimationsgenerator/) en [PresentationPlayer](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationanimationsgenerator/) stelt u in staat de framgrootte voor de later te maken video in te stellen via de constructor. Als u een instantie van de presentatie doorgeeft, wordt `Presentation.getSlideSize` gebruikt en genereert het animaties die [PresentationPlayer](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationplayer/) gebruikt.

Wanneer animaties worden gegenereerd, wordt een `NewAnimation`‑event gegenereerd voor elke volgende animatie, met de presentatie‑animatie‑player‑parameter. Deze laatste is een klasse die een speler voor een afzonderlijke animatie vertegenwoordigt.

Om met de presentatie‑animatie‑player te werken, worden de methoden `getDuration` (de totale duur van de animatie) en `setTimePosition` gebruikt. Elke animatie‑positie wordt ingesteld binnen het bereik *0 tot duur*, waarna de `getFrame`‑methode een BufferedImage retourneert die overeenkomt met de animatiestatus op dat moment:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Voegt een smile-vorm toe en animeert deze
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
            animationPlayer.setTimePosition(0);// initiële animatiestatus
            try {
                // bitmap van initiële animatiestatus
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// finale animatiestatus
            try {
                // laatste frame van de animatie
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

Om alle animaties in een presentatie tegelijk af te spelen, wordt de klasse [PresentationPlayer](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationplayer/) gebruikt. Deze klasse neemt een instance van [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationanimationsgenerator/) en een FPS‑waarde voor effecten in de constructor en roept daarna het `FrameTick`‑event voor alle animaties aan om ze af te spelen:

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

Vervolgens kunnen de gegenereerde frames worden samengevoegd tot een video. Zie de sectie [Convert PowerPoint to Video](https://docs.aspose.com/slides/nl/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

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

**Bewegingspaden**:

| Animatietype | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Is het mogelijk presentaties te converteren die met een wachtwoord beschermd zijn?**

Ja, Aspose.Slides maakt het werken met wachtwoord‑beveiligde presentaties mogelijk. Bij het verwerken van zulke bestanden moet u het juiste wachtwoord opgeven zodat de bibliotheek toegang krijgt tot de inhoud van de presentatie.

**Ondersteunt Aspose.Slides gebruik in cloud‑oplossingen?**

Ja, Aspose.Slides kan worden geïntegreerd in cloud‑applicaties en -diensten. De bibliotheek is ontworpen om in serveromgevingen te draaien, met hoge prestaties en schaalbaarheid voor batchverwerking van bestanden.

**Zijn er limieten qua grootte voor presentaties tijdens conversie?**

Aspose.Slides kan praktisch elke grootte aan. Bij zeer grote bestanden kunnen extra systeemresources nodig zijn, en het wordt soms aangeraden de presentatie te optimaliseren om de prestaties te verbeteren.