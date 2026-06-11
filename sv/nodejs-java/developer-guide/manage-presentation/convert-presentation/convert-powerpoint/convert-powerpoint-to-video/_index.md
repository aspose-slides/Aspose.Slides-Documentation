---
title: Konvertera PowerPoint-presentationer till video i JavaScript
linktitle: PowerPoint till video
type: docs
weight: 130
url: /sv/nodejs-java/convert-powerpoint-to-video/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du konverterar PowerPoint-presentationer till video i JavaScript. Upptäck exempel på kod och automatiseringstekniker för att effektivisera ditt arbetsflöde."
---
## **Introduktion**

Genom att konvertera din PowerPoint‑presentation till video får du 

* **Ökad tillgänglighet:** Alla enheter (oavsett plattform) är som standard utrustade med videospelare till skillnad från program för att öppna presentationer, så användare tycker det är enklare att öppna eller spela upp videor.
* **Större räckvidd:** Genom videor kan du nå en stor publik och rikta information till dem som annars kan upplevas som tråkig i en presentation. De flesta undersökningar och statistik visar att människor tittar på och konsumerar videor mer än andra former av innehåll, och de föredrar generellt sådant innehåll.

{{% alert color="primary" %}} 

Du kanske vill kolla in vår [**PowerPoint till Video Online‑konverterare**](https://products.aspose.app/slides/sv/conversion/ppt-to-word) eftersom den är en levande och effektiv implementering av processen som beskrivs här.

{{% /alert %}} 

## **PowerPoint till Video‑konvertering i Aspose.Slides**

Aspose.Slides stöder konvertering av presentation till video.

* Använd **Aspose.Slides** för att generera ett set av ramar (från presentationsbilder) som motsvarar en viss FPS (bilder per sekund)
* Använd ett verktyg från tredje part som **ffmpeg** ([för java](https://github.com/bramp/ffmpeg-cli-wrapper)) för att skapa en video baserad på ramarna. 

### **Konvertera PowerPoint till video**

1. Ladda ner ffmpeg [här](https://ffmpeg.org/download.html).

2. Kör PowerPoint‑till‑video‑JavaScript‑koden.

Denna JavaScript‑kod visar hur du konverterar en presentation (som innehåller en figur och två animationseffekter) till en video:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Lägger till en smiley-form och animerar den
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
    // Konfigurera ffmpeg-binärkatalogen. Se den här sidan: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Videoeffekter**

Du kan applicera animationer på objekt i bilder och använda övergångar mellan bilder. 

{{% alert color="primary" %}} 

Du kanske vill se dessa artiklar: [PowerPoint‑animation](https://docs.aspose.com/slides/sv/nodejs-java/powerpoint-animation/), [Formanimation](https://docs.aspose.com/slides/sv/nodejs-java/shape-animation/), och [Forma‑effekt](https://docs.aspose.com/slides/sv/nodejs-java/shape-effect/).

{{% /alert %}} 

Animationer och övergångar gör bildspel mer engagerande och intressanta—och de gör samma sak för videor. Låt oss lägga till en ytterligare bild och övergång i koden för den föregående presentationen:

```javascript
// Lägger till en smiley-form och animerar den
// ...
// Lägger till en ny bild och animerad övergång
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Aspose.Slides stöder även animation för text. Så vi animerar stycken på objekt, som kommer att visas ett efter ett (med fördröjning inställd på en sekund):

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Lägger till text och animationer
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
    // Konfigurera ffmpeg-binärkatalogen. Se den här sidan: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Klasser för video‑konvertering**

För att låta dig utföra PowerPoint‑till‑video‑konverteringsuppgifter tillhandahåller Aspose.Slides klasserna [PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationanimationsgenerator/) och [PresentationPlayer](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationanimationsgenerator/) låter dig ange bildstorlek för videon (som kommer att skapas senare) via dess konstruktor. Om du skickar en instans av presentationen kommer `Presentation.getSlideSize` att användas och den genererar animationer som [PresentationPlayer](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationplayer/) använder.

När animationer genereras skapas ett `NewAnimation`‑event för varje efterföljande animation, som har presentations‑animations‑spelare‑parametern. Den senare är en klass som representerar en spelare för en separat animation.

För att arbeta med presentations‑animations‑spelaren används metoderna `getDuration` (den fullständiga varaktigheten för animationen) och `setTimePosition`. Varje animationsposition sätts inom intervallet *0 till varaktighet*, och sedan kommer metoden `getFrame` att returnera en BufferedImage som motsvarar animationstillståndet vid det tillfället:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Lägger till en smiley-form och animerar den
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
            animationPlayer.setTimePosition(0);// initialt animationstillstånd
            try {
                // initialt bitmap för animationstillståndet
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// slutligt tillstånd för animationen
            try {
                // sista ramen av animationen
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

För att få alla animationer i en presentation att spelas samtidigt används klassen [PresentationPlayer](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationplayer/). Denna klass tar en [PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationanimationsgenerator/)‑instans och FPS för effekter i sin konstruktor och sedan anropar den `FrameTick`‑eventet för alla animationer för att få dem spelade:

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

Sedan kan de genererade ramarna kompileras för att producera en video. Se avsnittet [Convert PowerPoint to Video](https://docs.aspose.com/slides/sv/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Stödda animationer och effekter**

**Ingång**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Visa** | ![not supported](x.png) | ![supported](v.png) |
| **Tona** | ![supported](v.png) | ![supported](v.png) |
| **Flyg in** | ![supported](v.png) | ![supported](v.png) |
| **Flyt in** | ![supported](v.png) | ![supported](v.png) |
| **Dela** | ![supported](v.png) | ![supported](v.png) |
| **Sudd** | ![supported](v.png) | ![supported](v.png) |
| **Form** | ![supported](v.png) | ![supported](v.png) |
| **Hjul** | ![supported](v.png) | ![supported](v.png) |
| **Slumpmässiga staplar** | ![supported](v.png) | ![supported](v.png) |
| **Väx och vrid** | ![not supported](x.png) | ![supported](v.png) |
| **Zooma** | ![supported](v.png) | ![supported](v.png) |
| **Snurra** | ![supported](v.png) | ![supported](v.png) |
| **Studsa** | ![supported](v.png) | ![supported](v.png) |

**Betoning**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Puls** | ![not supported](x.png) | ![supported](v.png) |
| **Färgpuls** | ![not supported](x.png) | ![supported](v.png) |
| **Gunga** | ![supported](v.png) | ![supported](v.png) |
| **Snurra** | ![supported](v.png) | ![supported](v.png) |
| **Väx/Minsk** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturera** | ![not supported](x.png) | ![supported](v.png) |
| **Mörkna** | ![not supported](x.png) | ![supported](v.png) |
| **Ljusna** | ![not supported](x.png) | ![supported](v.png) |
| **Transparens** | ![not supported](x.png) | ![supported](v.png) |
| **Objektfärg** | ![not supported](x.png) | ![supported](v.png) |
| **Komplementär färg** | ![not supported](x.png) | ![supported](v.png) |
| **Linjefärg** | ![not supported](x.png) | ![supported](v.png) |
| **Fyllningsfärg** | ![not supported](x.png) | ![supported](v.png) |

**Utgång**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Försvinna** | ![not supported](x.png) | ![supported](v.png) |
| **Tona** | ![supported](v.png) | ![supported](v.png) |
| **Flyg ut** | ![supported](v.png) | ![supported](v.png) |
| **Flyt ut** | ![supported](v.png) | ![supported](v.png) |
| **Dela** | ![supported](v.png) | ![supported](v.png) |
| **Sudd** | ![supported](v.png) | ![supported](v.png) |
| **Form** | ![supported](v.png) | ![supported](v.png) |
| **Slumpmässiga staplar** | ![supported](v.png) | ![supported](v.png) |
| **Krymp och vrid** | ![not supported](x.png) | ![supported](v.png) |
| **Zooma** | ![supported](v.png) | ![supported](v.png) |
| **Snurra** | ![supported](v.png) | ![supported](v.png) |
| **Studsa** | ![supported](v.png) | ![supported](v.png) |

**Rörelsevägar**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linjer** | ![supported](v.png) | ![supported](v.png) |
| **Bågar** | ![supported](v.png) | ![supported](v.png) |
| **Vändningar** | ![supported](v.png) | ![supported](v.png) |
| **Former** | ![supported](v.png) | ![supported](v.png) |
| **Loopar** | ![supported](v.png) | ![supported](v.png) |
| **Anpassad bana** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Är det möjligt att konvertera presentationer som är lösenordsskyddade?**

Ja, Aspose.Slides tillåter arbete med lösenordsskyddade presentationer. När sådana filer behandlas måste du ange rätt lösenord så att biblioteket kan komma åt presentationens innehåll.

**Stöder Aspose.Slides användning i molnlösningar?**

Ja, Aspose.Slides kan integreras i molnapplikationer och tjänster. Biblioteket är utformat för att fungera i servermiljöer, vilket säkerställer hög prestanda och skalbarhet för batchbearbetning av filer.

**Finns det några storleksbegränsningar för presentationer under konvertering?**

Aspose.Slides kan hantera presentationer av praktiskt taget alla storlekar. Vid arbete med mycket stora filer kan dock extra systemresurser krävas, och det rekommenderas ibland att optimera presentationen för att förbättra prestandan.