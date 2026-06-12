---
title: Převod PowerPoint prezentací na video v .NET
linktitle: PowerPoint na video
type: docs
weight: 130
url: /cs/net/convert-powerpoint-to-video/
keywords:
- převod PowerPoint
- převod prezentace
- převod PPT
- převod PPTX
- PowerPoint na video
- prezentace na video
- PPT na video
- PPTX na video
- PowerPoint na MP4
- prezentace na MP4
- PPT na MP4
- PPTX na MP4
- uložit PPT jako MP4
- uložit PPTX jako MP4
- exportovat PPT do MP4
- exportovat PPTX do MP4
- konverze videa
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak převést PowerPoint prezentace na video v .NET. Objevte ukázkový C# kód a automatizační techniky pro zefektivnění vašeho pracovního postupu."
---
## **Úvod**

Převodem vaší prezentace PowerPoint nebo OpenDocument na video získáte:

**Zvýšená přístupnost:** Všechna zařízení, bez ohledu na platformu, jsou standardně vybavena video přehrávači, což usnadňuje uživatelům otevírání nebo přehrávání videí ve srovnání s tradičními aplikacemi pro prezentace.

**Širší dosah:** Videa vám umožňují oslovit širší publikum a prezentovat informace atraktivnějším způsobem. Průzkumy a statistiky ukazují, že lidé dávají přednost sledování a konzumaci video obsahu před jinými formami, což činí vaši zprávu účinnější.

{{% alert color="primary" %}} 
Podívejte se na náš [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/cs/video), protože nabízí živou a efektivní implementaci procesu popsaného zde.
{{% /alert %}} 

V Aspose.Slides pro .NET jsme implementovali podporu převodu prezentací na video.

* Použijte Aspose.Slides pro .NET k vygenerování snímků z prezentace při zadané snímkové frekvenci (FPS).
* Pak použijte nástroj třetí strany, jako je ffmpeg, k vytvoření videa z těchto snímků.

## **Převod PowerPoint prezentace na video**

1. Použijte příkaz `dotnet add package` k přidání Aspose.Slides a knihovny FFMpegCore do vašeho projektu:
   * run `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * run `dotnet add package FFMpegCore --version 4.8.0`
2. Stáhněte ffmpeg z [zde](https://ffmpeg.org/download.html).
3. FFMpegCore vyžaduje zadání cesty k staženému ffmpeg (např. extrahováno do "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Spusťte kód pro převod PowerPoint na video.

Tento C# kód demonstruje, jak převést prezentaci (obsahující tvar a dva animační efekty) na video:
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // použije FFmpeg binární soubory, které jsme dříve extrahovali do C:\tools\ffmpeg.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Přidejte tvar úsměvu a poté jej animujte.
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

    // Nastavte složku s binárními soubory ffmpeg. Viz tato stránka: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Převěďte snímky na webm video.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Video efekty**

Když převádíte PowerPoint prezentaci na video pomocí Aspose.Slides pro .NET, můžete použít různé video efekty ke zlepšení vizuální kvality výstupu. Tyto efekty vám umožňují kontrolovat vzhled snímků ve finálním videu přidáním plynulých přechodů, animací a dalších vizuálních prvků. Tato sekce popisuje dostupné možnosti video efektů a ukazuje, jak je použít.

{{% alert color="primary" %}} 
Viz:
- [Enhancing PowerPoint Presentations with Animations in C#](https://docs.aspose.com/slides/cs/net/powerpoint-animation/)
- [Shape Animation](https://docs.aspose.com/slides/cs/net/shape-animation/)
- [Apply Shape Effects in PowerPoint Using C#](https://docs.aspose.com/slides/cs/net/shape-effect/)
{{% /alert %}} 

Animace a přechody dělají prezentace zajímavější a poutavější — a totéž platí i pro videa. Přidejme další snímek a přechod do kódu předchozí prezentace:
```c#
 // Přidejte tvar úsměvu a animujte jej.
 // ...

 // Přidejte nový snímek a animovaný přechod.
 ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
 newSlide.Background.Type = BackgroundType.OwnBackground;
 newSlide.Background.FillFormat.FillType = FillType.Solid;
 newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
 newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides také podporuje animaci textu. V tomto příkladu animujeme odstavce na objektech tak, aby se objevovaly po sobě, s jednasekundovým zpožděním mezi nimi:
```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Přidejte text a animace.
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

    // Nastavte složku s binárními soubory ffmpeg. Viz tato stránka: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Převěďte snímky na webm video.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Třídy pro konverzi videa**

Pro umožnění úkolů převodu PowerPoint na video poskytuje Aspose.Slides pro .NET třídy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/net/aspose.slides.export/presentationanimationsgenerator/) a [PresentationPlayer](https://reference.aspose.com/slides/cs/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` umožňuje nastavit velikost snímku pro video (které bude vytvořeno později) a hodnotu FPS (snímků za sekundu) přes konstruktor. Pokud předáte instanci prezentace, použije se její `Presentation.SlideSize` a generuje animace, které [PresentationPlayer](https://reference.aspose.com/slides/cs/net/aspose.slides.export/presentationplayer/) používá.

Když jsou animace generovány, spustí se událost `NewAnimation` pro každou následující animaci a předá se parametr [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ipresentationanimationplayer/). Tato třída představuje přehrávač pro jednotlivou animaci.

Pro práci s [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ipresentationanimationplayer/) používáte vlastnost [Duration](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ipresentationanimationplayer/duration/) (která udává celkovou délku animace) a metodu [SetTimePosition](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Každá pozice animace je nastavena v rozmezí *0 až duration* a metoda `GetFrame` pak vrátí Bitmap představující stav animace v daném okamžiku.
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Přidejte tvar úsměvu a animujte jej.
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

            animationPlayer.SetTimePosition(0);          // Počáteční stav animace.
            Bitmap bitmap = animationPlayer.GetFrame();  // Bitmapa počátečního stavu animace.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // Konečný stav animace.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // Poslední snímek animace.
            lastBitmap.Save("last.png");
        };
    }
}
```

Pro simultánní přehrání všech animací v prezentaci se používá třída [PresentationPlayer](https://reference.aspose.com/slides/cs/net/aspose.slides.export/presentationplayer/). Tato třída přijímá instanci [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/net/aspose.slides.export/presentationanimationsgenerator/) a hodnotu FPS pro efekty v konstruktoru a následně volá událost `FrameTick` pro všechny animace, aby je přehrála:
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

Poté mohou být vygenerované snímky zkompilovány do videa. Viz sekce [Convert a PowerPoint Presentation to Video](/slides/cs/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Podporované animace a efekty**

Při převodu PowerPoint prezentace na video pomocí Aspose.Slides pro .NET je důležité rozumět tomu, které animace a efekty jsou ve výstupu podporovány. Aspose.Slides podporuje širokou škálu běžných vstupních, výstupních a důrazových efektů, jako jsou prolínání, přilet, přiblížení a otáčení. Některé pokročilé nebo vlastní animace však nemusí být zcela zachovány nebo se mohou ve finálním videu projevit odlišně. Tato sekce popisuje podporované animace a efekty.

**Vstupní**:

| Typ animace | Aspose.Slides | PowerPoint |
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

**Důrazové**:

| Typ animace | Aspose.Slides | PowerPoint |
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

**Výstupní**:

| Typ animace | Aspose.Slides | PowerPoint |
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

**Cesty pohybu**:

| Typ animace | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Podporované efekty přechodu snímků**

Efekty přechodu snímků hrají důležitou roli při vytváření plynulých a vizuálně atraktivních změn mezi snímky ve videu. Aspose.Slides pro .NET podporuje řadu běžně používaných přechodových efektů, aby pomohl zachovat tok a styl vaší původní prezentace. Tato sekce uvádí, které přechodové efekty jsou během konverze podporovány.

**Jemné**:

| Typ animace | Aspose.Slides | PowerPoint |
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

**Vzrušující**:

| Typ animace | Aspose.Slides | PowerPoint |
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

**Dynamický obsah**:

| Typ animace | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Je možné převést prezentace chráněné heslem?**

Ano, Aspose.Slides pro .NET umožňuje práci s prezentacemi chráněnými heslem. Při zpracování takových souborů musíte zadat správné heslo, aby knihovna mohla získat přístup k obsahu prezentace.

**Podporuje Aspose.Slides pro .NET použití v cloudových řešeních?**

Ano, Aspose.Slides pro .NET lze integrovat do cloudových aplikací a služeb. Knihovna je navržena pro provoz na serverech, zajišťuje vysoký výkon a škálovatelnost pro hromadné zpracování souborů.

**Existují omezení velikosti prezentací během konverze?**

Aspose.Slides pro .NET je schopen zpracovat prezentace téměř libovolné velikosti. Při práci s velmi velkými soubory však může být potřeba více systémových zdrojů a někdy se doporučuje optimalizovat prezentaci pro zlepšení výkonu.