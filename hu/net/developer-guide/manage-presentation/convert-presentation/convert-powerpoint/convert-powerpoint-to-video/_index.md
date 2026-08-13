---
title: PowerPoint bemutatók videóvá konvertálása .NET-ben
linktitle: PowerPoint videóvá konvertálása
type: docs
weight: 130
url: /hu/net/convert-powerpoint-to-video/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint videóvá
- bemutató videóvá
- PPT videóvá
- PPTX videóvá
- PowerPoint MP4-re
- bemutató MP4-re
- PPT MP4-re
- PPTX MP4-re
- PPT mentése MP4-ként
- PPTX mentése MP4-ként
- PPT exportálása MP4-be
- PPTX exportálása MP4-be
- videó konvertálás
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan konvertálhat PowerPoint bemutatókat videóvá .NET környezetben. Fedezze fel a mintakódot C#-ban és az automatizálási technikákat, amelyek a munkafolyamatát egyszerűsítik."
---
## **Bevezetés**

A PowerPoint vagy OpenDocument bemutató videóvá alakításával a következőket érheti el:

**Növelt hozzáférhetőség:** Minden eszköz, platformtól függetlenül, alapértelmezés szerint videólejátszóval rendelkezik, ami könnyebbé teszi a felhasználók számára a videók megnyitását vagy lejátszását a hagyományos prezentációs alkalmazásokhoz képest.

**Szélesebb közönség:** A videók lehetővé teszik, hogy nagyobb közönséget érjen el és információt vonzóbb formátumban mutasson be. Felmérések és statisztikák azt mutatják, hogy az emberek a videótartalmat részesítik előnyben más formákkal szemben, ezáltal üzenete hatásosabbá válik.

{{% alert color="info" %}} 
Tekintse meg a [**PowerPoint videó online konverter**](https://products.aspose.app/slides/hu/video) oldalt, mivel ez élő és hatékony megvalósítást kínál a leírt folyamathoz.
{{% /alert %}} 

Az Aspose.Slides for .NET-ben megvalósítottuk a bemutatók videóvá konvertálásának támogatását.

* Használja az Aspose.Slides for .NET-et, hogy kereteket generáljon a bemutató diákból meghatározott képkockasebességgel (FPS).
* Ezután használjon egy harmadik fél által biztosított segédprogramot, például az ffmpeg-et, hogy ezeket a kereteket videóvá állítsa össze.

## **PowerPoint bemutató konvertálása videóvá**

1. Használja a `dotnet add package` parancsot az Aspose.Slides és az FFMpegCore könyvtárak projekthez való hozzáadásához:
   * futtassa `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * futtassa `dotnet add package FFMpegCore --version 4.8.0`
2. Töltse le az ffmpeg-et [ide](https://ffmpeg.org/download.html).
3. Az FFMpegCore megköveteli, hogy adja meg a letöltött ffmpeg elérési útját (például „C:\tools\ffmpeg” könyvtárba kicsomagolva):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Futtassa a PowerPoint‑videó konverziós kódot.

Ez a C# kód bemutatja, hogyan konvertálhatunk egy bemutatót (amely tartalmaz alakzatot és két animációs effektet) videóvá:
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // a korábban C:\tools\ffmpeg-re kibontott FFmpeg binárisokat fogja használni.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adjunk egy mosolygó alakzatot, majd animáljuk.
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

    // Állítsa be az ffmpeg binárisok mappáját. Lásd ezt az oldalt: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // A kereteket webm videóvá konvertálja.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Videóeffektek**

PowerPoint bemutató videóvá konvertálásakor az Aspose.Slides for .NET használatával különféle videóeffekteket alkalmazhat a kimenet vizuális minőségének javításához. Ezek az effektusok lehetővé teszik a diák megjelenésének szabályozását a végvideóban, sima átmenetek, animációk és egyéb vizuális elemek hozzáadásával. Ez a szakasz bemutatja a rendelkezésre álló videóeffektus beállítási lehetőségeket és azt, hogyan alkalmazhatja őket.

{{% alert color="info" %}} 
Lásd:
- [PowerPoint bemutatók fejlesztése animációkkal C#-ban](https://docs.aspose.com/slides/hu/net/powerpoint-animation/)
- [Alakzat animáció](https://docs.aspose.com/slides/hu/net/shape-animation/)
- [Alakzat effektusok alkalmazása PowerPointban C#-val](https://docs.aspose.com/slides/hu/net/shape-effect/)
{{% /alert %}} 

Az animációk és áttűnések a diavetítéseket vonzóbbá és érdekesebbé teszik – és ugyanezt teszik a videókkal is. Adjunk hozzá egy új diát és áttűnést a korábbi bemutató kódjához:
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // Adj egy mosolygó alakzatot és animáld (lásd a fenti kódot).

    // Adj egy új diát és egy animált áttűnést.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Az Aspose.Slides támogatja a szöveganimációkat is. Ebben a példában beágyazott bekezdéseket animálunk, hogy egyesével, egy másodperces késleltetéssel jelenjenek meg:
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

    // Állítsa be az ffmpeg binárisok mappáját. Lásd ezt az oldalt: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // A kereteket webm videóvá konvertálja.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Videókonverziós osztályok**

A PowerPoint‑videó konvertálási feladatok engedélyezéséhez az Aspose.Slides for .NET a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/net/aspose.slides.export/presentationanimationsgenerator/) és a [PresentationPlayer](https://reference.aspose.com/slides/hu/net/aspose.slides.export/presentationplayer/) osztályokat biztosítja.

A `PresentationAnimationsGenerator` lehetővé teszi a videó keretméretének (amelyet később létrehozunk) és az FPS (képkocka per másodperc) értékének beállítását a konstruktorában. Ha egy prezentáció példányt ad át, annak `Presentation.SlideSize` értéke lesz felhasználva, és olyan animációkat generál, amelyeket a [PresentationPlayer](https://reference.aspose.com/slides/hu/net/aspose.slides.export/presentationplayer/) használ.

Az animációk generálásakor minden egyes további animációhoz egy `NewAnimation` esemény kerül kiváltásra, amely egy [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipresentationanimationplayer/) paramétert tartalmaz. Ez az osztály egy egyedi animáció lejátszóját képviseli.

Az [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipresentationanimationplayer/) használatához a [Duration](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipresentationanimationplayer/duration/) tulajdonságot (ami az animáció teljes időtartamát adja) és a [SetTimePosition](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) metódust használja. Minden animáció pozíciója a *0‑tól a teljes időtartamig* tartományban van megadva, a `GetFrame` metódus pedig visszaad egy Bitmap‑et, amely az adott időpontban az animáció állapotát ábrázolja.
```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adj hozzá egy mosolygó alakzatot és animáld.
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

            animationPlayer.SetTimePosition(0);        // Az animáció kezdeti állapota.
            IImage image = animationPlayer.GetFrame(); // Az animáció kezdeti állapota kép.

            animationPlayer.SetTimePosition(animationPlayer.Duration); // Az animáció végső állapota.
            IImage lastImage = animationPlayer.GetFrame();             // A legutóbbi keret az animációból.
            lastImage.Save("last.png");
        };
    }
}
```

Az összes animáció egyidejű lejátszásához a [PresentationPlayer](https://reference.aspose.com/slides/hu/net/aspose.slides.export/presentationplayer/) osztályt használjuk. Ez az osztály egy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hu/net/aspose.slides.export/presentationanimationsgenerator/) példányt és egy FPS értéket vesz át a konstruktorában, majd a `FrameTick` eseményt hívja meg minden animációra, hogy lejátsza őket:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Ezután a generált kereteket össze lehet állítani videóvá. Lásd a [Convert a PowerPoint Presentation to Video](/slides/hu/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) részt.

## **Támogatott animációk és effektusok**

PowerPoint bemutató videóvá konvertálásakor fontos tudni, mely animációk és effektusok támogatottak a kimenetben. Az Aspose.Slides számos általános belépő, kilépő és hangsúlyozó effektust támogat, mint például a halványodás, a belépés, a nagyítás és a forgatás. Néhány fejlett vagy egyedi animáció azonban nem biztos, hogy teljes mértékben megmarad vagy másként jelenik meg a végvideóban. Az alábbi táblázatok a támogatott animációkat és effektusokat mutatják be.

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

**Hangsúly**:

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

**Mozgási útvonalak**:

| Animáció típusa | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Támogatott diaátmenet‑effektusok**

A diaátmenet‑effektusok fontos szerepet játszanak a videóban a diák közötti sima és vizuálisan vonzó átmenetek létrehozásában. Az Aspose.Slides for .NET számos gyakran használt átmenet‑effektust támogat, hogy megőrizze az eredeti prezentáció áramlását és stílusát. Az alábbiakban a konverzió során támogatott átmeneteket soroljuk fel.

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

**Lendületes**:

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
| **Comb** | ![not supported](x/png) | ![supported](v.png) |
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

### Lehetőség van jelszóval védett bemutatók konvertálására?

Igen, az Aspose.Slides for .NET lehetővé teszi a jelszóval védett bemutatók kezelését. Az ilyen fájlok feldolgozásakor meg kell adnia a helyes jelszót, hogy a könyvtár hozzáférhessen a bemutató tartalmához.

### Támogatja-e az Aspose.Slides for .NET a felhőalapú megoldások használatát?

Igen, az Aspose.Slides for .NET integrálható felhőalkalmazásokba és szolgáltatásokba. A könyvtár szerverkörnyezetben is működik, biztosítva a magas teljesítményt és skálázhatóságot a fájlok tömeges feldolgozásához.

### Vannak-e méretkorlátok a bemutatók konvertálása során?

Az Aspose.Slides for .NET gyakorlatilag bármilyen méretű bemutató kezelésére képes. Nagyon nagy fájlok esetén azonban több rendszererőforrásra lehet szükség, és gyakran ajánlott a bemutató optimalizálása a teljesítmény javítása érdekében.