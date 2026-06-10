---
title: PowerPoint bemutatók konvertálása videóvá Androidon
linktitle: PowerPoint videóra
type: docs
weight: 130
url: /hu/androidjava/convert-powerpoint-to-video/
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
- PPT exportálása MP4-ba
- PPTX exportálása MP4-ba
- videó konvertálás
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan konvertálhatja a PowerPoint bemutatókat videóvá Java-ban. Fedezze fel a példakódot és az automatizálási technikákat, hogy egyszerűsítse munkafolyamatát."
---
## **Bevezetés**

PowerPoint előadás videóvá konvertálásával a következő előnyöket kapja

* **A hozzáférhetőség növekedése:** Minden eszköz (függetlenül a platformtól) alapértelmezetten videolejátszóval rendelkezik a bemutató‑megnyitó alkalmazásokhoz képest, így a felhasználók könnyebben nyitják meg vagy játszák le a videókat.
* **Nagyobb elérés:** Videók segítségével széles közönséget érhet el, és olyan információval célozhatja meg őket, ami egy bemutatóban esetleg unalmasnak tűnne. A legtöbb felmérés és statisztika azt mutatja, hogy az emberek a videókat többet nézik és fogyasztják, mint más tartalmakat, és általában ezt a formát részesítik előnyben.

{{% alert color="primary" %}} 
Érdemes megnézni a [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/hu/conversion/ppt-to-word) mert ez egy élő és hatékony megvalósítása a leírt folyamatnak.
{{% /alert %}} 

## **PowerPoint videóvá konvertálása az Aspose.Slides-ben**

Az Aspose.Slides támogatja a bemutató videóvá konvertálását.

* Használja a **Aspose.Slides**-t, hogy a bemutató diákból kereteket (frame-eket) állítson elő, amelyek egy adott FPS‑nek (képkocka per másodperc) felelnek meg
* Használjon egy harmadik fél eszközt, például a **ffmpeg**-et ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) a keretek alapján videó létrehozásához. 

### **PowerPoint videóvá konvertálása**

1. Adja hozzá ezt a POM fájlhoz:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Töltse le az ffmpeg-et [itt](https://ffmpeg.org/download.html).

4. Futtassa a PowerPoint videó Java kódot.

Ez a Java kód bemutatja, hogyan konvertáljon egy prezentációt (amely egy ábrát és két animációs effektust tartalmaz) videóvá:
```java
Presentation presentation = new Presentation();
try {
    // Hozzáad egy mosoly alakzatot, majd animálja
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

Animációkat alkalmazhat a diák objektumaira, és áttűnéseket használhat a diák között. 

{{% alert color="primary" %}} 
Érdemes megtekinteni ezeket a cikkeket: [PowerPoint Animation](https://docs.aspose.com/slides/hu/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/hu/androidjava/shape-animation/), és [Shape Effect](https://docs.aspose.com/slides/hu/androidjava/shape-effect/).
{{% /alert %}} 

Az animációk és áttűnések élvezetesebbé és érdekesebbé teszik a diavetítéseket – és ugyanígy működnek a videókkal is. Adjunk egy új diát és áttűnést a korábbi prezentáció kódjához:
```java
// Hozzáad egy mosoly alakzatot és animálja

// ...

// Hozzáad egy új diát és animált átmenetet

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Az Aspose.Slides szöveganimációt is támogat. Így animáljuk az objektumok bekezdéseit, amelyek egyesével fognak megjelenni (az késleltetés egy másodpercre van beállítva):
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

## **Videókonverziós osztályok**

A PowerPoint videóvá konvertálásához szükséges feladatok elvégzéséhez az Aspose.Slides biztosítja a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationanimationsgenerator/) és a [PresentationPlayer](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationplayer/) osztályokat.

[PresentationAnimationsGenerator] lehetővé teszi a videó képkockaméretének beállítását (amelyet később létrehoznak) a konstruktorán keresztül. Ha átad egy prezentáció példányt, a `Presentation.SlideSize` lesz használva, és olyan animációkat generál, amelyeket a [PresentationPlayer] használ.

Amikor az animációk generálódnak, egy `NewAnimation` esemény jön létre minden egyes következő animációhoz, amelynek van egy [IPresentationAnimationPlayer] paramétere. Az utóbbi egy osztály, amely egy külön animáció lejátszóját képviseli.

Az [IPresentationAnimationPlayer] használatához a [Duration] (az animáció teljes időtartama) tulajdonságot és a [SetTimePosition] metódust használjuk. Minden animáció pozíciója a *0 és a duration* tartományon belül van beállítva, majd a `GetFrame` metódus egy BufferedImage-et ad vissza, amely az adott pillanatban az animáció állapotát mutatja:
```java
Presentation presentation = new Presentation();
try {
    // Hozzáad egy mosoly alakzatot és animálja
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
            animationPlayer.setTimePosition(0); // kezdeti animáció állapota
            try {
                // kezdeti animáció állapota bitmap
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

Ahhoz, hogy a prezentáció összes animációja egyszerre játsszon le, a [PresentationPlayer] osztályt használjuk. Ez az osztály a konstruktorában kap egy [PresentationAnimationsGenerator] példányt és az FPS-t a hatásokhoz, majd a `FrameTick` eseményt hívja meg az összes animációhoz, hogy lejátszásra kerüljenek:
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

Ezután az előállított képkockákat össze lehet állítani egy videóvá. Lásd a [Convert PowerPoint to Video](https://docs.aspose.com/slides/hu/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video) részt.

## **Támogatott animációk és effektusok**

**Belépés**:

| Animáció típusa | Aspose.Slides | PowerPoint |
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

**Kiemelés**:

| Animáció típusa | Aspose.Slides | PowerPoint |
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

**Kilépés**:

| Animáció típusa | Aspose.Slides | PowerPoint |
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

**Mozgás útvonalak:**

| Animáció típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Lehetőség van jelszóval védett prezentációk konvertálására?**

Igen, az Aspose.Slides lehetővé teszi a [password-protected presentations](/slides/hu/androidjava/password-protected-presentation/) használatát. Az ilyen fájlok feldolgozásakor meg kell adni a megfelelő jelszót, hogy a könyvtár hozzáférhessen a prezentáció tartalmához.

**Az Aspose.Slides támogatja a felhasználást felhő megoldásokban?**

Igen, az Aspose.Slides integrálható felhőalkalmazásokba és szolgáltatásokba. A könyvtár úgy van tervezve, hogy szerverkörnyezetben működjön, biztosítva a magas teljesítményt és skálázhatóságot a fájlok csoportos feldolgozásához.

**Vannak méretkorlátozások a prezentációk konvertálása során?**

Az Aspose.Slides képes gyakorlatilag bármilyen méretű prezentációt kezelni. Nagyon nagy fájlok esetén azonban további rendszererőforrásokra lehet szükség, és néha ajánlott a prezentáció optimalizálása a teljesítmény javítása érdekében.