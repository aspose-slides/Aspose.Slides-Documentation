---
title: PowerPoint prezentációk videóvá konvertálása Java-ban
linktitle: PowerPoint videóvá konvertálása
type: docs
weight: 130
url: /hu/java/convert-powerpoint-to-video/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint videóvá
- prezentáció videóvá
- PPT videóvá
- PPTX videóvá
- PowerPoint MP4-re
- prezentáció MP4-re
- PPT MP4-re
- PPTX MP4-re
- PPT mentése MP4-ként
- PPTX mentése MP4-ként
- PPT exportálása MP4-be
- PPTX exportálása MP4-be
- videó konverzió
- PowerPoint
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan konvertálhatja a PowerPoint prezentációkat videóvá Java-ban. Fedezze fel a mintakódot és az automatizálási technikákat, hogy egyszerűsítse munkafolyamatát."
---
## **Bevezetés**

PowerPoint vagy OpenDocument prezentáció videóvá konvertálásával a következő előnyöket érheti el:

**Megnövelt hozzáférhetőség:** Minden eszköz, platformtól függetlenül, alapértelmezés szerint videólejátszóval rendelkezik, így a felhasználók számára egyszerűbb a videók megnyitása vagy lejátszása a hagyományos prezentációs alkalmazásokhoz képest.

**Szélesebb elérés:** A videók lehetővé teszik, hogy nagyobb közönséget érjen el, és információt vonzóbb formátumban mutasson be. Kérdőívek és statisztikák azt mutatják, hogy az emberek szívesebben néznek és fogyasztanak videótartalmat más formákhoz képest, ezáltal üzenete hatásosabb lesz.

{{% alert color="primary" %}} 

Érdemes megtekinteni a [**PowerPoint videó online konverter**](https://products.aspose.app/slides/hu/conversion/ppt-to-word) oldalt, mivel ez egy élő és hatékony megvalósítása a leírt folyamatnak.

{{% /alert %}} 

## **PowerPoint videó konvertálása az Aspose.Slides-ben**

Az [Aspose.Slides 22.11](https://docs.aspose.com/slides/hu/java/aspose-slides-for-java-22-11-release-notes/) verzióban bevezettük a prezentáció videóvá konvertálásának támogatását. 

* Használja a **Aspose.Slides**‑t, hogy a prezentáció diái alapján olyan képkockákat állítson elő, amelyek egy adott FPS‑nek (képkocka/másodperc) felelnek meg
* Használjon egy harmadik féltől származó eszközt, például a **ffmpeg**‑et ([java‑hoz](https://github.com/bramp/ffmpeg-cli-wrapper)), hogy a képkockákból videót készítsen. 

### **PowerPoint videóvá konvertálása**

1. Adja hozzá ezt a POM‑fájljához:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Töltse le a ffmpeg‑et [itt](https://ffmpeg.org/download.html).

4. Futtassa a PowerPoint videó Java kódot.

Ez a Java kód bemutatja, hogyan konvertálhat egy prezentációt (amely egy ábrát és két animációs hatást tartalmaz) videóvá:

```java
Presentation presentation = new Presentation();
try {
    // Hozzáad egy mosoly alakzatot, majd animálja azt
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

    // Állítsa be az ffmpeg binárisok mappáját. Lásd ezt az oldalt: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **Videóeffektek**

Animációkat alkalmazhat a diákon lévő objektumokra, valamint átmeneteket használhat a diák között. 

{{% alert color="primary" %}} 

Érdemes elolvasni ezeket a cikkeket: [PowerPoint animáció](https://docs.aspose.com/slides/hu/java/powerpoint-animation/), [Alak animáció](https://docs.aspose.com/slides/hu/java/shape-animation/), és [Alak hatás](https://docs.aspose.com/slides/hu/java/shape-effect/).

{{% /alert %}} 

Az animációk és átmenetek élőbbé és érdekesebbé teszik a diavetítéseket – ugyanígy hatnak a videókra is. Adjunk hozzá egy új diát és átmenetet a korábbi prezentáció kódjához:

```java
// Hozzáad egy mosoly alakzatot és animálja azt

// ...

// Hozzáad egy új diát és animált átmenetet

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Az Aspose.Slides szövegekre is támogat animációt. Így animálhatunk bekezdéseket objektumokon, amelyek egyesével, egy másodperces késleltetéssel jelennek meg:

```java
Presentation presentation = new Presentation();
try {
    // Szöveget és animációkat ad hozzá
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

    // Állítsa be az ffmpeg binárisok mappáját. Lásd ezt az oldalt: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **Videókonvertálási osztályok**

Az Aspose.Slides a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationanimationsgenerator/) és a [PresentationPlayer](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationplayer/) osztályokkal teszi lehetővé a PowerPoint videóvá konvertálási feladatok elvégzését.

A [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationanimationsgenerator/) segítségével a videó (később létrehozandó) képkockaméretét a konstruktorában adhatja meg. Ha a prezentáció egy példányát adja át, a `Presentation.SlideSize` lesz használva, és olyan animációkat generál, amelyeket a [PresentationPlayer](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationplayer/) felhasznál.

Az animációk generálásakor minden egyes további animációhoz egy `NewAnimation` eseményt hoz létre, amely a [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationanimationplayer/) paraméterrel rendelkezik. Az utóbbi egy olyan osztály, amely egy különálló animáció lejátszóját képviseli.

Az [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationanimationplayer/) használatához a [Duration](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (az animáció teljes időtartama) tulajdonság és a [SetTimePosition](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) metódus szolgál. Minden animáció pozíciója a *0 és az időtartam* közötti tartományban állítható, majd a `GetFrame` metódus egy BufferedImage‑et ad vissza, amely az adott pillanatban az animáció állapotát tükrözi:

```java
Presentation presentation = new Presentation();
try {
    // Hozzáad egy mosoly alakzatot és animálja azt
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
            animationPlayer.setTimePosition(0); // kezdeti animációs állapot
            try {
                // kezdeti animációs állapot bitmap
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // animáció végső állapota
            try {
                // animáció utolsó képkockája
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

Az összes animáció egyszerre történő lejátszásához a [PresentationPlayer](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationplayer/) osztályt használjuk. Ez az osztály egy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationanimationsgenerator/) példányt és az FPS‑t veszi fel a konstruktorában, majd minden animációhoz meghívja a `FrameTick` eseményt, hogy azok lejátszásra kerüljenek:

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

Ezután a generált képkockákat össze lehet vonni egy videó készítéséhez. Lásd a [PowerPoint videóvá konvertálása](https://docs.aspose.com/slides/hu/java/convert-powerpoint-to-video/#convert-powerpoint-to-video) szakaszt.

## **Támogatott animációk és hatások**

**Belépés**:

| Animáció Típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Fade** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Fly In** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Float In** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Split** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Wipe** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Shape** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Wheel** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Random Bars** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Grow & Turn** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Zoom** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Swivel** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Bounce** | ![támogatott](v.png) | ![támogatott](v.png) |

**Kiemelés**:

| Animáció Típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Color Pulse** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Teeter** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Spin** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Grow/Shrink** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Desaturate** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Darken** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Lighten** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Transparency** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Object Color** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Complementary Color** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Line Color** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Fill Color** | ![nem támogatott](x.png) | ![támogatott](v.png) |

**Kilépés**:

| Animáció Típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Fade** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Fly Out** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Float Out** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Split** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Wipe** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Shape** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Random Bars** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Shrink & Turn** | ![nem támogatott](x.png) | ![támogatott](v.png) |
| **Zoom** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Swivel** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Bounce** | ![támogatott](v.png) | ![támogatott](v.png) |

**Mozgás útvonalak**:

| Animáció Típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Arcs** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Turns** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Shapes** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Loops** | ![támogatott](v.png) | ![támogatott](v.png) |
| **Custom Path** | ![támogatott](v.png) | ![támogatott](v.png) |

## **GYIK**

**Lehetőség van jelszóval védett prezentációk konvertálására?**

Igen, az Aspose.Slides támogatja a [jelszóval védett prezentációk](/slides/hu/java/password-protected-presentation/) kezelését. Az ilyen fájlok feldolgozásához meg kell adnia a megfelelő jelszót, hogy a könyvtár hozzáférhessen a prezentáció tartalmához.

**Támogatja az Aspose.Slides a felhőalapú megoldásokat?**

Igen, az Aspose.Slides integrálható felhőalkalmazásokba és szolgáltatásokba. A könyvtár úgy lett tervezve, hogy szerverkörnyezetben működjön, magas teljesítményt és méretezhetőséget biztosítva a fájlok kötegelt feldolgozásához.

**Vannak-e méretkorlátozások a prezentációk konvertálása során?**

Az Aspose.Slides gyakorlatilag bármilyen méretű prezentációt képes kezelni. Nagyon nagy fájlok esetén azonban további rendszererőforrásokra lehet szükség, és gyakran ajánlott a prezentáció optimalizálása a teljesítmény javítása érdekében.