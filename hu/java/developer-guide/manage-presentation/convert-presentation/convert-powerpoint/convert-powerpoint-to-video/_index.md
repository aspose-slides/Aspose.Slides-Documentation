---
title: PowerPoint prezentációk videóvá konvertálása Java-ban
linktitle: PowerPoint videóvá
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
- videó konvertálás
- PowerPoint
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet PowerPoint prezentációkat videóvá konvertálni Java-ban. Fedezze fel a minta kódot és az automatizálási technikákat a munkafolyamat hatékonyabbá tételéhez."
---
## **Bevezetés**

A PowerPoint vagy OpenDocument prezentációjának videóvá konvertálásával a következő előnyöket nyújtja:

**Növelt hozzáférhetőség:** Minden eszköz, platformtól függetlenül, alapértelmezés szerint videólejátszóval van felszerelve, így a felhasználók számára könnyebb a videókat megnyitni vagy lejátszni a hagyományos prezentációs alkalmazásokhoz képest.

**Szélesebb közönség:** A videók lehetővé teszik, hogy nagyobb közönséghez érj el, és az információkat vonzóbb formátumban mutasd be. Felmérések és statisztikák azt mutatják, hogy az emberek előnyben részesítik a videótartalom nézését és fogyasztását más formákkal szemben, így az üzeneted hatásosabb lesz.

{{% alert color="info" %}} 
Érdemes megnézni az [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/hu/video) oldalt, mivel ez egy élő és hatékony megvalósítása a leírt folyamatnak.
{{% /alert %}} 

## **PowerPoint videóvá konvertálása az Aspose.Slides-ben**

Az [Aspose.Slides 22.11](https://docs.aspose.com/slides/hu/java/aspose-slides-for-java-22-11-release-notes/) verzióban bevezettük a prezentációk videóvá konvertálásának támogatását. 

* Használja a **Aspose.Slides**-t, hogy a prezentáció diái alapján képkockák sorozatát állítsa elő, amelyek egy adott FPS-nek (képkocka per másodperc) felelnek meg
* Használjon harmadik féltől származó segédprogramot, például a **ffmpeg**-et ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) a képkockák alapján videó létrehozásához. 

### **PowerPoint videóvá konvertálása**

1. Add this to your POM file:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Töltse le az ffmpeg-et [itt](https://ffmpeg.org/download.html).

4. Futtassa a PowerPoint videóvá konvertáló Java kódot.

Ez a Java kód megmutatja, hogyan lehet egy prezentációt (amely ábrát és két animációs hatást tartalmaz) videóvá konvertálni:
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

## **Videóhatások**

Animációkat alkalmazhat a diák objektumaira, és áttűnéseket használhat a diák között. 

{{% alert color="info" %}} 
Érdemes megtekinteni ezeket a cikkeket: [PowerPoint Animation](https://docs.aspose.com/slides/hu/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/hu/java/shape-animation/), és a [Shape Effect](https://docs.aspose.com/slides/hu/java/shape-effect/).
{{% /alert %}} 

Az animációk és áttűnések élénkebbé és érdekesebbé teszik a diavetítéseket – és ugyanezt teszik a videókkal is. Adjunk hozzá egy új diát és áttűnést a korábbi prezentáció kódjához:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // Hozzáad egy mosoly alakzatot és animálja azt

    // ...

    // Hozzáad egy új diát és animált áttűnést

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Az Aspose.Slides szövegeknél is támogatja az animációt. Így objektumok bekezdéseit animáljuk, melyek egymás után jelennek meg (a késleltetés egy másodpercre van állítva):
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

A PowerPoint videóvá konvertálásához szükséges feladatok elvégzéséhez az Aspose.Slides biztosítja a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationanimationsgenerator/) és a [PresentationPlayer](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationplayer/) osztályokat.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationanimationsgenerator/) lehetővé teszi a videó képkocka méretének beállítását (amely később létrejön) a konstruktorában. Ha a prezentáció egy példányát adja meg, a `Presentation.SlideSize` lesz felhasználva, és olyan animációkat generál, amelyeket a [PresentationPlayer](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationplayer/) használ.

Amikor az animációk létrejönnek, minden egyes animációhoz egy `NewAnimation` esemény jön létre, amely a [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationanimationplayer/) paramétert tartalmazza. Utóbbi egy olyan osztály, amely egy különálló animáció lejátszóját képviseli.

Az [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationanimationplayer/) használatához a [Duration](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (az animáció teljes időtartama) tulajdonságot és a [SetTimePosition](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) metódust használják. Minden animáció pozíciója a *0-tól a duration-ig* tartományban állítható be, majd a `getFrame` metódus egy [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) objektumot ad vissza, amely az adott pillanatban az animáció állapotát tükrözi:
```java
import com.aspose.slides.*;

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

            animationPlayer.setTimePosition(0); // kezdeti animációállapot
            // kezdeti animációállapot bitmap
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // animáció végső állapota
            // animáció utolsó képkockája
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // animációk generálása - ez hozza létre a fentiekben kezelt eseményeket
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Az összes animáció egyszerre történő lejátszásához a [PresentationPlayer](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationplayer/) osztályt használjuk. Ez az osztály a konstruktorában egy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationanimationsgenerator/) példányt és az FPS értéket kapja az effektusokhoz, majd meghívja a `FrameTick` eseményt az összes animációhoz, hogy lejátszhatóvá tegye őket:
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

Ezután az előállított képkockákat össze lehet állítani egy videó létrehozásához. Lásd a [Convert PowerPoint to Video](https://docs.aspose.com/slides/hu/java/convert-powerpoint-to-video/#convert-powerpoint-to-video) részt.

## **Támogatott animációk és hatások**

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

**Mozgású útvonalak**:

| Animáció típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **GYIK**

### Lehet jelszóval védett prezentációkat konvertálni?

Igen, az Aspose.Slides lehetővé teszi a [jelszóval védett prezentációk](/slides/hu/java/password-protected-presentation/) kezelését. Az ilyen fájlok feldolgozásához a helyes jelszót kell megadni, hogy a könyvtár hozzáférhessen a prezentáció tartalmához.

### Támogatja az Aspose.Slides a felhőmegoldásokban való használatot?

Igen, az Aspose.Slides integrálható felhőalkalmazásokba és szolgáltatásokba. A könyvtár szerverkörnyezetben való működésre lett tervezve, biztosítva a magas teljesítményt és a skálázhatóságot a fájlok kötegelt feldolgozásához.

### Vannak-e méretkorlátozások a konverzió során a prezentációkra?

Az Aspose.Slides gyakorlatilag bármilyen méretű prezentációt képes kezelni. Nagyon nagy fájlok esetén azonban további rendszererőforrásokra lehet szükség, és időnként ajánlott a prezentáció optimalizálása a teljesítmény javítása érdekében.