---
title: PowerPoint prezentációk videóvá konvertálása Androidon
linktitle: PowerPoint videóvá
type: docs
weight: 130
url: /hu/androidjava/convert-powerpoint-to-video/
keywords:
- PowerPoint átalakítása
- prezentáció átalakítása
- PPT átalakítása
- PPTX átalakítása
- PowerPoint videóvá alakítása
- prezentáció videóvá alakítása
- PPT videóvá alakítása
- PPTX videóvá alakítása
- PowerPoint MP4-re konvertálása
- prezentáció MP4-re konvertálása
- PPT MP4-re konvertálása
- PPTX MP4-re konvertálása
- PPT mentése MP4-ként
- PPTX mentése MP4-ként
- PPT exportálása MP4-be
- PPTX exportálása MP4-be
- videó konvertálás
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan konvertálhat PowerPoint prezentációkat videóvá Java-ban. Fedezze fel a mintakódot és az automatizálási technikákat, hogy egyszerűsítse munkafolyamatát."
---
## **Bevezetés**

A PowerPoint prezentáció videóvá konvertálásával a következő előnyöket kapja  

* **Növekvő hozzáférhetőség:** Minden eszköz (függetlenül a platformtól) alapértelmezés szerint videolejátszóval rendelkezik, szemben a prezentációk megnyitását megkíváló alkalmazásokkal, így a felhasználók könnyebben tudnak videókat megnyitni vagy lejátszni.  
* **Szélesebb elérés:** Videókkal nagy közönséghez juthat el, és olyan információkat célozhat meg, amelyek egy prezentációban unalmasnak tűnhetnek. A legtöbb felmérés és statisztika azt mutatja, hogy az emberek a videókat gyakrabban nézik és fogyasztják más tartalomtípusokkal szemben, és általában előnyben részesítik ezt a formát.  

## **PowerPoint videóvá konvertálása az Aspose.Slides-ban**

Az Aspose.Slides támogatja a prezentációk videóvá konvertálását.

* **Aspose.Slides** használatával generálhat egy sor képkockát (a prezentáció diái alapján), amely egy adott FPS-nek (képkocka másodpercenként) felel meg  
* Harmadik fél által biztosított segédprogramot, például a **ffmpeg**-et ([java számára](https://github.com/bramp/ffmpeg-cli-wrapper)) használhat a képkockák alapján videó elkészítéséhez.  

### **PowerPoint videóvá konvertálása**

1. Add this to your POM file:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Download ffmpeg [itt](https://ffmpeg.org/download.html).

3. Run the PowerPoint to video Java code.

Ez a Java kód bemutatja, hogyan konvertálhat egy prezentációt (amely egy ábrát és két animációs hatást tartalmaz) videóvá:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    // Állítsa be az ffmpeg binárisok mappáját. Lásd ezt az oldalt: https://github.com/bramp/ffmpeg-cli-wrapper
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

## **Videóhatások**

Animációkat alkalmazhat a diákon lévő objektumokra, és átmeneteket használhat a diák között.  

{{% alert color="info" %}} 

Érdemes megnéznie ezeket a cikkeket: [PowerPoint Animation](https://docs.aspose.com/slides/hu/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/hu/androidjava/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/hu/androidjava/shape-effect/).

{{% /alert %}} 

Az animációk és átmenetek élvezetesebbé és érdekesebbé teszik a diavetítéseket – és ugyanezt teszik a videókkal is. Adjunk hozzá egy új diát és átmenetet a korábbi prezentáció kódjához:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Az előbb létrehozott animált mosoly alakzatot tartalmazó prezentáció.
Presentation presentation = new Presentation();
try {
    // Új diát és animált átmenetet ad hozzá

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Az Aspose.Slides szövegek animálását is támogatja. Így objektumok bekezdéseit animáljuk, amelyek egyesével, egymás után jelennek meg (a késleltetés egy másodpercre van beállítva):

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    // Állítsa be az ffmpeg binárisok mappáját. Lásd ezt az oldalt: https://github.com/bramp/ffmpeg-cli-wrapper
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

Az PowerPoint videóvá konvertálási feladatok elvégzéséhez az Aspose.Slides biztosítja a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationanimationsgenerator/) és a [PresentationPlayer](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationplayer/) osztályokat.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationanimationsgenerator/) lehetővé teszi, hogy a videó képkockaméretét (amely később létrejön) a konstruktorán keresztül állítsa be. Ha a prezentáció egy példányát adja át, a `Presentation.SlideSize` lesz felhasználva, és olyan animációkat generál, amelyeket a [PresentationPlayer](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationplayer/) használ.

When animations are generated, a `NewAnimation` event is generated for each subsequent animation, which has the [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationanimationplayer/) parameter. The latter is a class that represents a player for a separate animation.

To work with [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationanimationplayer/), the [Duration](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (the full duration of the animation) property and [SetTimePosition](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) method are used. Each animation position is set within the *0 to duration* range, and then the `getFrame` method will return an [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) that corresponds to the animation state at that moment:

```java
import com.aspose.slides.*;

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

            animationPlayer.setTimePosition(0); // kezdeti animációs állapot
            // kezdeti animációs állapot bitmap
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // animáció végső állapota
            // animáció utolsó képkockája
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // Generálja az animációkat. A fenti visszahívás minden egyes animációra lefut.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

To make all animations in a presentation play at once, the [PresentationPlayer](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationplayer/) class is used. This class takes a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationanimationsgenerator/) instance and FPS for effects in its constructor and then calls the `FrameTick` event for all the animations to get them played:

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

Then the generated frames can be compiled to produce a video. See the [Convert PowerPoint to Video](https://docs.aspose.com/slides/hu/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video) section.

## **Támogatott animációk és effektek**

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

**Mozgás útvonalak**:

| Animáció típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **GYIK**

### Lehetőség van jelszóval védett prezentációk konvertálására?

Igen, az Aspose.Slides lehetővé teszi a [jelszóval védett prezentációk](/slides/hu/androidjava/password-protected-presentation/) használatát. Az ilyen fájlok feldolgozásakor meg kell adnia a helyes jelszót, hogy a könyvtár hozzáférhessen a prezentáció tartalmához.

### Támogatja-e az Aspose.Slides a felhőmegoldásokat?

Igen, az Aspose.Slides integrálható felhőalkalmazásokba és -szolgáltatásokba. A könyvtár úgy lett tervezve, hogy szerverkörnyezetben működjön, biztosítva a magas teljesítményt és a skálázhatóságot a fájlok kötegelt feldolgozásához.

### Vannak-e méretkorlátok a konverzió során?

Az Aspose.Slides képes szinte bármilyen méretű prezentáció kezelésére. Nagyon nagy fájlok esetén azonban további rendszererőforrásokra lehet szükség, és gyakran javasolt a prezentáció optimalizálása a teljesítmény javítása érdekében.