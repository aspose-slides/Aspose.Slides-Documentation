---
title: PowerPoint prezentációk konvertálása videóvá .NET-ben
linktitle: PowerPoint videóvá
type: docs
weight: 130
url: /hu/net/convert-powerpoint-to-video/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint videóvá
- prezentáció videóvá
- PPT videóvá
- PPTX videóvá
- PowerPoint MP4-be
- prezentáció MP4-be
- PPT MP4-be
- PPTX MP4-be
- PPT mentése MP4-ként
- PPTX mentése MP4-ként
- PPT exportálása MP4-be
- PPTX exportálása MP4-be
- videó konvertálás
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan konvertálhat PowerPoint prezentációkat videóvá .NET-ben. Fedezze fel a minta C# kódot és az automatizálási technikákat a munkafolyamat optimalizálásához."
---
## **Bevezetés**

PowerPoint vagy OpenDocument prezentáció videóvá konvertálásával a következő előnyöket nyújtja:

**Megnövelt hozzáférhetőség:** Minden eszköz, platformtól függetlenül, alapértelmezés szerint videolejátszóval van felszerelve, így a felhasználók könnyebben megnyithatják vagy lejátszhatják a videókat a hagyományos prezentációs alkalmazásokhoz képest.

**Szélesebb elérés:** A videók nagyobb közönséget érnek el, és vonzóbb formátumban mutatják be az információt. Felmérések és statisztikák szerint az emberek szívesebben néznek és fogyasztanak videótartalmakat, mint más formákat, így üzenete hatásosabb lesz.

{{% alert color="primary" %}} 
Nézze meg a [**PowerPoint videó online konvertert**](https://products.aspose.app/slides/hu/video), amely élő és hatékony megvalósítást nyújt az itt leírt folyamathoz.
{{% /alert %}} 

Az Aspose.Slides for .NET támogatja a prezentációk videóvá konvertálását.

* Használja az Aspose.Slides for .NET-et a prezentációs diák képkockáinak előállításához megadott képkockasebességgel (FPS).
* Ezután egy harmadik féltől származó eszközzel, például az ffmpeg‑kel állítsa össze a képkockákat videóvá.

## **PowerPoint prezentáció videóvá konvertálása**

1. Használja a `dotnet add package` parancsot az Aspose.Slides és az FFMpegCore könyvtárak hozzáadásához a projektjéhez:
   * futtassa `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * futtassa `dotnet add package FFMpegCore --version 4.8.0`
2. Töltse le az ffmpeg-et [itt](https://ffmpeg.org/download.html).
3. Az FFMpegCore megköveteli, hogy megadja a letöltött ffmpeg elérési útját (például „C:\tools\ffmpeg” könyvtárba kicsomagolva):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Futtassa a PowerPoint‑videó konvertáló kódot.

Ez a C# kód bemutatja, hogyan konvertáljon egy prezentációt (amely alakzatot és két animációs effektust tartalmaz) videóvá:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // a korábban a C:\tools\ffmpeg mappába kibontott FFmpeg bináris fájlokat fogja használni.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adjunk hozzá egy mosoly alakzatot, majd animáljuk.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // Állítsa be az ffmpeg bináris mappát. Lásd ezt az oldalt: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Konvertálja a képkockákat webm videóvá.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Videó effektusok**

PowerPoint prezentáció videóvá konvertálásakor az Aspose.Slides for .NET segítségével különféle videó effektusok alkalmazhatók a kimenet vizuális minőségének javítására. Ezek az effektusok lehetővé teszik a diák megjelenésének szabályozását a végvideóban, sima átmenetek, animációk és egyéb vizuális elemek hozzáadásával. Ez a szakasz ismerteti a rendelkezésre álló videó effektus opciókat és megmutatja, hogyan alkalmazhatók.

{{% alert color="primary" %}} 
Lásd:
- [PowerPoint prezentációk animációkkal való bővítése C#‑ban](https://docs.aspose.com/slides/hu/net/powerpoint-animation/)
- [Alakzat animáció](https://docs.aspose.com/slides/hu/net/shape-animation/)
- [Alakzat effektusok alkalmazása PowerPointban C#‑val](https://docs.aspose.com/slides/hu/net/shape-effect/)
{{% /alert %}} 

Az animációk és átmenetek színesebbé és érdekesebbé teszik a diavetítéseket – és ugyanezt teszik a videókkal is. Adjunk egy újabb diát és átmenetet a korábbi prezentáció kódjához:

```c#
// Adjunk hozzá egy mosoly alakzatot és animáljuk.
// ...

// Adjunk hozzá egy új diát és egy animált átmenetet.
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Az Aspose.Slides textus animációkat is támogat. Ebben a példában a objektumok bekezdéseit animáljuk úgy, hogy egyesével jelenjenek meg, egy másodperces késleltetéssel egymás között:

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Szöveg és animációk hozzáadása.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };

        animationsGenerator.Run(presentation.Slides);
    }

    // Állítsa be az ffmpeg bináris mappát. Lásd ezt az oldalt: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // A képkockákat webm videóvá konvertálja.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Videó konvertáló osztályok**

A PowerPoint‑videó konvertálási feladatok lehetővé tételéhez az Aspose.Slides for .NET a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/net/aspose.slides.export/presentationanimationsgenerator/) és a [PresentationPlayer](https://reference.aspose.com/slides/hu/net/aspose.slides.export/presentationplayer/) osztályokat biztosítja.

A `PresentationAnimationsGenerator` lehetővé teszi a videó képkockaméretének (amely később létrejön) és az FPS (képkocka per másodperc) értékének beállítását a konstruktorában. Ha egy prezentáció példányt ad át, annak `Presentation.SlideSize` értéke lesz használva, és olyan animációkat generál, amelyeket a [PresentationPlayer](https://reference.aspose.com/slides/hu/net/aspose.slides.export/presentationplayer/) használ.

Animációk generálásakor minden egyes következő animációhoz `NewAnimation` esemény váltódik ki, amely egy [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipresentationanimationplayer/) paramétert tartalmaz. Ez az osztály egy egyedi animáció lejátszóját képviseli.

Az [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipresentationanimationplayer/) használatához a [Duration](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipresentationanimationplayer/duration/) tulajdonságot (ami az animáció teljes időtartamát adja) és a [SetTimePosition](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) metódust használja. Minden animáció pozíciója a *0‑tól az időtartamig* tartományban van beállítva, a `GetFrame` metódus pedig egy Bitmap objektumot ad vissza, amely az adott időpontban az animáció állapotát ábrázolja.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adjunk hozzá egy mosoly alakzatot és animáljuk.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);          // A kezdeti animációállapot.
            Bitmap bitmap = animationPlayer.GetFrame();  // A kezdeti animációállapot bitmapje.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // Az animáció végső állapota.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // Az animáció utolsó képkockája.
            lastBitmap.Save("last.png");
        };
    }
}
```

Az összes animáció egyszerre történő lejátszásához a [PresentationPlayer](https://reference.aspose.com/slides/hu/net/aspose.slides.export/presentationplayer/) osztályt használják. Ez az osztály egy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/net/aspose.slides.export/presentationanimationsgenerator/) példányt és egy FPS értéket kap a konstruktorában, majd a `FrameTick` eseményt minden animációnál meghívja, hogy lejátszhassa őket:

```c#
using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```

Ezután a generált képkockák összeállíthatók videóvá. Lásd a [PowerPoint prezentáció videóvá konvertálása](/slides/hu/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) szakaszt.

## **Támogatott animációk és effektusok**

PowerPoint prezentáció videóvá konvertálásakor fontos megérteni, mely animációk és effektusok támogatottak a kimenetben. Az Aspose.Slides számos gyakori belépő, kilépő és kiemelő effektust támogat, mint például elhalványulás, betűtűzés, nagyítás és forgatás. Néhány fejlett vagy egyedi animáció azonban nem teljesen őrződik meg, vagy másként jelenhet meg a végvideóban. Az alábbiakban felsoroljuk a támogatott animációkat és effektusokat.

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

## **Támogatott diavetítés átmeneti effektusok**

A diák közti átmeneti effektusok fontos szerepet játszanak a videóban a sima és látványos változások létrehozásában. Az Aspose.Slides for .NET számos gyakran használt átmeneti effektust támogat, amelyek segítenek megőrizni az eredeti prezentáció folyamatát és stílusát. Az alábbiakban bemutatjuk, mely átmeneti effektusok támogatottak a konverzió során.

**Finom**:

| Animáció típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Izgalmas**:

| Animáció típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Dinamikus tartalom**:

| Animáció típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **GYIK**

**Lehetőség van jelszóval védett prezentációk konvertálására?**  
Igen, az Aspose.Slides for .NET lehetővé teszi a jelszóval védett prezentációk kezelését. Az ilyen fájlok feldolgozásához meg kell adnia a helyes jelszót, hogy a könyvtár hozzáférhessen a prezentáció tartalmához.

**Támogatja az Aspose.Slides for .NET a felhőalapú megoldásokat?**  
Igen, az Aspose.Slides for .NET integrálható felhőalkalmazásokba és szolgáltatásokba. A könyvtár szerver környezetben működésre készült, biztosítva a magas teljesítményt és a skálázhatóságot a fájlok kötegelt feldolgozásához.

**Vannak méretkorlátok a prezentációk konvertálása során?**  
Az Aspose.Slides for .NET képes szinte bármilyen méretű prezentáció kezelésére. Nagyon nagy fájlok esetén azonban további rendszer erőforrásokra lehet szükség, és gyakran ajánlott a prezentáció optimalizálása a teljesítmény javítása érdekében.