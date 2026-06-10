---
title: PowerPoint prezentációk videóvá konvertálása JavaScriptben
linktitle: PowerPoint videóvá
type: docs
weight: 130
url: /hu/nodejs-java/convert-powerpoint-to-video/
keywords:
- PowerPoint átalakítása
- bemutató átalakítása
- PPT átalakítása
- PPTX átalakítása
- PowerPoint videóvá alakítása
- bemutató videóvá alakítása
- PPT videóvá alakítása
- PPTX videóvá alakítása
- PowerPoint MP4-vé konvertálása
- bemutató MP4-vé konvertálása
- PPT MP4-vé konvertálása
- PPTX MP4-vé konvertálása
- PPT mentése MP4-ként
- PPTX mentése MP4-ként
- PPT exportálása MP4-be
- PPTX exportálása MP4-be
- videó konvertálás
- PowerPoint
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan konvertálhatja a PowerPoint prezentációkat videóvá JavaScriptben. Fedezze fel a mintakódot és az automatizálási technikákat, amelyekkel egyszerűsítheti munkafolyamatát."
---
## **Introduction**

A PowerPoint bemutató videóvá konvertálásával a következő előnyöket érheti el:

* **Az elérhetőség növelése:** Minden eszköz (platformtól függetlenül) alapértelmezés szerint videólejátszóval van felszerelve a prezentációk megnyitásához szükséges alkalmazásokkal szemben, így a felhasználók könnyebben nyitják meg vagy játszák le a videókat.
* **Nagyobb elérés:** A videók segítségével széles közönséghez juthat el, és információkat célozhat meg, amelyek egyébként unalmasnak tűnhetnek egy prezentációban. A legtöbb felmérés és statisztika azt mutatja, hogy az emberek a videókat gyakrabban nézik és fogyasztják, mint egyéb tartalmakat, és általában előnyben részesítik ezeket.

{{% alert color="primary" %}} 
Érdemes megnézni a [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/hu/conversion/ppt-to-word)-t, mivel ez egy élő és hatékony megvalósítása a leírt folyamatnak.
{{% /alert %}} 

## **PowerPoint videó konvertálás az Aspose.Slides-ban**

Az Aspose.Slides támogatja a prezentáció videóvá alakítását.

* Használja az **Aspose.Slides**-t, hogy a prezentáció diákjaiból egy adott FPS-nek (képkocka per másodperc) megfelelő képkockasort generáljon.
* Használjon harmadik féltől származó segédprogramot, például a **ffmpeg**-et ([java számára](https://github.com/bramp/ffmpeg-cli-wrapper)), a képkockák alapján videó létrehozásához. 

### **PowerPoint videóvá konvertálása**

1. Töltse le az ffmpeg-et [itt](https://ffmpeg.org/download.html).
2. Futtassa a PowerPoint videó konvertáló JavaScript kódot.

Ez a JavaScript kód megmutatja, hogyan konvertáljon egy bemutatót (amely egy ábrát és két animációs hatást tartalmaz) videóvá:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Hozzáad egy mosolys alakzatot, majd animálja
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
    // Állítsa be az ffmpeg binárisok mappáját. Lásd ezt az oldalt: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Videóhatások**

Animációkat alkalmazhat a diák objektumaira, és átmeneteket használhat a diák között. 

{{% alert color="primary" %}} 
Érdemes megnézni ezeket a cikkeket: [PowerPoint Animation](https://docs.aspose.com/slides/hu/nodejs-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/hu/nodejs-java/shape-animation/), és [Shape Effect](https://docs.aspose.com/slides/hu/nodejs-java/shape-effect/).
{{% /alert %}} 

Az animációk és átmenetek vonzóbbá és érdekesebbé teszik a diavetítéseket – és ugyanezt teszik a videók esetén is. Adjunk egy újabb diát és átmenetet a korábbi bemutató kódjához:

```javascript
// Hozzáad egy mosolys alakzatot és animálja
// ...
// Hozzáad egy új diát és animált átmenetet
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Az Aspose.Slides szövegek animációját is támogatja. Így a objektumok bekezdéseit animáljuk, amelyek egyesével (egy másodperces késleltetéssel) jelennek meg:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Hozzáad szöveget és animációkat
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
    // Állítsa be az ffmpeg binárisok mappáját. Lásd ezt az oldalt: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Videókonvertálási osztályok**

A PowerPoint videó konvertálási feladatok elvégzéséhez az Aspose.Slides a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationanimationsgenerator/) és a [PresentationPlayer](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationplayer/) osztályokat biztosítja.

A [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationanimationsgenerator/) lehetővé teszi a videó (később létrehozandó) keretméretének beállítását a konstruktorában. Ha a prezentáció egy példányát adja át, a `Presentation.getSlideSize` kerül felhasználásra, és olyan animációkat generál, amelyeket a [PresentationPlayer](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationplayer/) használ.

Animációk generálásakor minden egyes következő animációhoz egy `NewAnimation` esemény jön létre, amely a prezentáció animációs lejátszó paraméterét tartalmazza. Az utóbbi egy osztály, amely egy külön animáció lejátszóját képviseli.

A prezentáció animációs lejátszójával a `getDuration` (az animáció teljes időtartama) és a `setTimePosition` metódusokat használjuk. Minden animáció pozíciója a *0-tól a duration-ig* terjedő tartományban állítható be, majd a `getFrame` metódus egy BufferedImage‑et ad vissza, amely az adott pillanatban az animáció állapotát tükrözi:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Hozzáad egy mosolys alakzatot és animálja
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
            animationPlayer.setTimePosition(0);// kezdeti animáció állapota
            try {
                // kezdeti animáció állapot bitmap
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// animáció végső állapota
            try {
                // animáció utolsó képkockája
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

Az összes animáció egyszerre történő lejátszásához a [PresentationPlayer](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationplayer/) osztályt használjuk. Ez az osztály egy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationanimationsgenerator/) példányt és az effektusok FPS-ét veszi át a konstruktorában, majd minden animációhoz meghívja a `FrameTick` eseményt, hogy azok lejátszásra kerüljenek:

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

Ezután az előállított képkockákat össze lehet állítani, hogy videót kapjunk. Lásd a [Convert PowerPoint to Video](https://docs.aspose.com/slides/hu/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video) szakaszt.

## **Támogatott animációk és hatások**

**Entrance**:

| Animáció típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Megjelenés** | ![not supported](x.png) | ![supported](v.png) |
| **Halványulás** | ![supported](v.png) | ![supported](v.png) |
| **Beköltözés** | ![supported](v.png) | ![supported](v.png) |
| **Lebegő belépés** | ![supported](v.png) | ![supported](v.png) |
| **Felosztás** | ![supported](v.png) | ![supported](v.png) |
| **Törlés** | ![supported](v.png) | ![supported](v.png) |
| **Alakzat** | ![supported](v.png) | ![supported](v.png) |
| **Kerék** | ![supported](v.png) | ![supported](v.png) |
| **Véletlen sávok** | ![supported](v.png) | ![supported](v.png) |
| **Növekedés és fordulás** | ![not supported](x.png) | ![supported](v.png) |
| **Nagyítás** | ![supported](v.png) | ![supported](v.png) |
| **Forgatás** | ![supported](v.png) | ![supported](v.png) |
| **Ugrás** | ![supported](v.png) | ![supported](v.png) |

**Emphasis**:

| Animáció típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulzálás** | ![not supported](x.png) | ![supported](v.png) |
| **Színpulzálás** | ![not supported](x.png) | ![supported](v.png) |
| **Röpködés** | ![supported](v.png) | ![supported](v.png) |
| **Forgás** | ![supported](v.png) | ![supported](v.png) |
| **Növekedés/Kicsinyítés** | ![not supported](x.png) | ![supported](v.png) |
| **Színtelítettség csökkentése** | ![not supported](x.png) | ![supported](v.png) |
| **Sötétítés** | ![not supported](x.png) | ![supported](v.png) |
| **Világosítás** | ![not supported](x.png) | ![supported](v.png) |
| **Átlátszóság** | ![not supported](x.png) | ![supported](v.png) |
| **Objektum színe** | ![not supported](x.png) | ![supported](v.png) |
| **Komplementer szín** | ![not supported](x.png) | ![supported](v.png) |
| **Vonal színe** | ![not supported](x.png) | ![supported](v.png) |
| **Kitöltés színe** | ![not supported](x.png) | ![supported](v.png) |

**Exit**:

| Animáció típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Eltűnés** | ![not supported](x.png) | ![supported](v.png) |
| **Halványulás** | ![supported](v.png) | ![supported](v.png) |
| **Kifelégzés** | ![supported](v.png) | ![supported](v.png) |
| **Lebegő kilépés** | ![supported](v.png) | ![supported](v.png) |
| **Felosztás** | ![supported](v.png) | ![supported](v.png) |
| **Törlés** | ![supported](v.png) | ![supported](v.png) |
| **Alakzat** | ![supported](v.png) | ![supported](v.png) |
| **Véletlen sávok** | ![supported](v.png) | ![supported](v.png) |
| **Kicsinyítés és fordulás** | ![not supported](x.png) | ![supported](v.png) |
| **Nagyítás** | ![supported](v.png) | ![supported](v.png) |
| **Forgatás** | ![supported](v.png) | ![supported](v.png) |
| **Ugrás** | ![supported](v.png) | ![supported](v.png) |

**Motion Paths**:

| Animáció típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Vonalak** | ![supported](v.png) | ![supported](v.png) |
| **Ívek** | ![supported](v.png) | ![supported](v.png) |
| **Fordulatok** | ![supported](v.png) | ![supported](v.png) |
| **Alakzatok** | ![supported](v.png) | ![supported](v.png) |
| **Hurok** | ![supported](v.png) | ![supported](v.png) |
| **Egyéni útvonal** | ![supported](v.png) | ![supported](v.png) |

## **GYIK**

**Lehetőség van jelszóval védett bemutatók konvertálására?**  

Igen, az Aspose.Slides lehetővé teszi a jelszóval védett bemutatók kezelését. Az ilyen fájlok feldolgozásakor a megfelelő jelszót kell megadni, hogy a könyvtár hozzáférhessen a bemutató tartalmához.

**Támogatja az Aspose.Slides a felhőalapú megoldásokat?**  

Igen, az Aspose.Slides integrálható felhőalkalmazásokba és szolgáltatásokba. A könyvtár szerver környezetekben való működésre van tervezve, biztosítva a magas teljesítményt és a skálázhatóságot a fájlok kötegelt feldolgozásához.

**Vannak méretkorlátok a bemutatók konvertálása során?**  

Az Aspose.Slides gyakorlatilag bármilyen méretű bemutató kezelésére képes. Nagy fájlok esetén azonban további rendszererőforrásokra lehet szükség, és néha ajánlott a bemutatót optimalizálni a teljesítmény javítása érdekében.