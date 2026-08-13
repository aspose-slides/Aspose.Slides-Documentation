---
title: PowerPoint-presentaties naar video converteren in .NET
linktitle: PowerPoint naar video
type: docs
weight: 130
url: /nl/net/convert-powerpoint-to-video/
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
- video-conversie
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u PowerPoint‑presentaties naar video kunt converteren in .NET. Ontdek voorbeeld‑C#‑code en automatiseringstechnieken om uw workflow te stroomlijnen."
---
## **Inleiding**

Door uw PowerPoint‑ of OpenDocument‑presentatie naar video om te zetten, krijgt u:

**Verbeterde toegankelijkheid:** Alle apparaten, ongeacht het platform, beschikken standaard over videospelers, waardoor het voor gebruikers gemakkelijker is om video's te openen of af te spelen dan traditionele presentatie­applicaties.

**Grotere bereik:** Video’s stellen u in staat een breder publiek te bereiken en informatie op een boeiender manier te presenteren. Enquêtes en statistieken tonen aan dat mensen liever video‑inhoud bekijken en consumeren dan andere vormen, waardoor uw boodschap meer impact heeft.

{{% alert color="info" %}} 

Bekijk onze [**PowerPoint naar Video Online Converter**](https://products.aspose.app/slides/nl/video) omdat deze een live en effectieve uitvoering van het hier beschreven proces biedt.

{{% /alert %}} 

In Aspose.Slides for .NET hebben we ondersteuning geïmplementeerd voor het converteren van presentaties naar video.

* Gebruik Aspose.Slides for .NET om frames uit de presentatieslides te genereren met een opgegeven framesnelheid (FPS).  
* Gebruik vervolgens een hulpprogramma van derden, zoals ffmpeg, om deze frames samen te voegen tot een video.

## **Een PowerPoint‑presentatie naar video converteren**

1. Gebruik het `dotnet add package`‑commando om Aspose.Slides en de FFMpegCore‑bibliotheek aan uw project toe te voegen:  
   * voer `dotnet add package Aspose.Slides.NET --version 22.11.0` uit  
   * voer `dotnet add package FFMpegCore --version 4.8.0` uit
2. Download ffmpeg van [hier](https://ffmpeg.org/download.html).  
3. FFMpegCore vereist dat u het pad naar de gedownloade ffmpeg opgeeft (bijv. uitgepakt naar "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Voer de PowerPoint‑naar‑video‑conversiecode uit.

Deze C#‑code toont hoe een presentatie (met een vorm en twee animatie‑effecten) naar een video wordt omgezet:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // zal de FFmpeg‑binaries gebruiken die we eerder hebben uitgepakt naar C:\tools\ffmpeg.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Voeg een glimlach‑vorm toe en animeer deze vervolgens.
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

    // Configureer de map met de ffmpeg‑binaries. Zie deze pagina: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Converteer de frames naar een webm‑video.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Video‑effecten**

Bij het converteren van een PowerPoint‑presentatie naar video met Aspose.Slides for .NET kunt u diverse video‑effecten toepassen om de visuele kwaliteit van de uitvoer te verbeteren. Deze effecten stellen u in staat het uiterlijk van slides in de uiteindelijke video te regelen door vloeiende overgangen, animaties en andere visuele elementen toe te voegen. Deze sectie legt de beschikbare video‑effectopties uit en laat zien hoe u ze toepast.

{{% alert color="info" %}} 

Zie:  
- [PowerPoint‑presentaties verbeteren met animaties in C#](https://docs.aspose.com/slides/nl/net/powerpoint-animation/)  
- [Vormanimatie](https://docs.aspose.com/slides/nl/net/shape-animation/)  
- [Vorm‑effecten toepassen in PowerPoint met C#](https://docs.aspose.com/slides/nl/net/shape-effect/)

{{% /alert %}} 

Animaties en overgangen maken diavoorstellingen boeiender en interessanter — en ze hebben hetzelfde effect op video’s. Laten we een extra slide en overgang toevoegen aan de code voor de vorige presentatie:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // Voeg een glimlachvorm toe en animeer deze (zie de code hierboven).

    // Voeg een nieuwe slide toe en een geanimeerde overgang.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Aspose.Slides ondersteunt ook tekstan animaties. In dit voorbeeld animeren we alinea’s op objecten zodat ze één voor één verschijnen, met een vertraging van één seconde tussen elke alinea:

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Voeg tekst en animaties toe.
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

    // Configureer de map met de ffmpeg-binaries. Zie deze pagina: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Converteer de frames naar een webm-video.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Klassen voor video‑conversie**

Om PowerPoint‑naar‑video‑taken mogelijk te maken, biedt Aspose.Slides for .NET de klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nl/net/aspose.slides.export/presentationanimationsgenerator/) en [PresentationPlayer](https://reference.aspose.com/slides/nl/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` maakt het mogelijk de frame‑grootte voor de later te maken video en de FPS‑waarde (frames per seconde) via de constructor in te stellen. Als u een presentatie‑instantie doorgeeft, wordt de `Presentation.SlideSize` ervan gebruikt en genereert het animaties die [PresentationPlayer](https://reference.aspose.com/slides/nl/net/aspose.slides.export/presentationplayer/) gebruikt.

Wanneer animaties worden gegenereerd, wordt voor elke opvolgende animatie een `NewAnimation`‑event getriggerd, met een [IPresentationAnimationPlayer](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ipresentationanimationplayer/)‑parameter. Deze klasse vertegenwoordigt een speler voor een individuele animatie.

Om met [IPresentationAnimationPlayer](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ipresentationanimationplayer/) te werken, gebruikt u de [Duration](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ipresentationanimationplayer/duration/)‑eigenschap (die de totale duur van de animatie geeft) en de [SetTimePosition](https://reference.aspose.com/slides/nl/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/)‑methode. Elke animatie‑positie wordt ingesteld binnen het bereik *0 tot duur*, en de `GetFrame`‑methode retourneert vervolgens een Bitmap die de animatiestatus op dat moment weergeeft.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Voeg een glimlachvorm toe en animeer deze.
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

            animationPlayer.SetTimePosition(0);        // De begintoestand van de animatie.
            IImage image = animationPlayer.GetFrame(); // De afbeelding van de begintoestand van de animatie.

            animationPlayer.SetTimePosition(animationPlayer.Duration); // De eindtoestand van de animatie.
            IImage lastImage = animationPlayer.GetFrame();             // Het laatste frame van de animatie.
            lastImage.Save("last.png");
        };
    }
}
```

Om alle animaties in een presentatie tegelijk te laten afspelen, wordt de klasse [PresentationPlayer](https://reference.aspose.com/slides/nl/net/aspose.slides.export/presentationplayer/) gebruikt. Deze klasse neemt een [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nl/net/aspose.slides.export/presentationanimationsgenerator/)‑instantie en een FPS‑waarde voor effecten in de constructor, en roept vervolgens het `FrameTick`‑event voor alle animaties aan om ze af te spelen:

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

Vervolgens kunnen de gegenereerde frames worden samengevoegd tot een video. Zie de sectie [Convert a PowerPoint Presentation to Video](/slides/nl/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Ondersteunde animaties en effecten**

Bij het converteren van een PowerPoint‑presentatie naar video met Aspose.Slides for .NET is het belangrijk te weten welke animaties en effecten worden ondersteund in de uitvoer. Aspose.Slides ondersteunt een breed scala aan gangbare binnenkomst‑, uitgangs‑ en nadruk‑effecten zoals vervagen, binnenvliegen, zoomen en draaien. Sommige geavanceerde of aangepaste animaties worden echter mogelijk niet volledig behouden of kunnen er anders uitzien in de uiteindelijke video. Deze sectie geeft een overzicht van de ondersteunde animaties en effecten.

**Binnenkomst**:

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

## **Ondersteunde slide‑overgangseffecten**

Slide‑overgangseffecten spelen een belangrijke rol bij het creëren van vloeiende en visueel aantrekkelijke overgangen tussen slides in een video. Aspose.Slides for .NET ondersteunt een verscheidenheid aan veelgebruikte overgangseffecten om de stroom en stijl van uw oorspronkelijke presentatie te behouden. Deze sectie belicht welke overgangseffecten tijdens het conversieproces worden ondersteund.

**Subtiel**:

| Animatietype | Aspose.Slides | PowerPoint |
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

**Ongeduldig**:

| Animatietype | Aspose.Slides | PowerPoint |
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

**Dynamische inhoud**:

| Animatietype | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### Is het mogelijk om presentaties die met een wachtwoord beschermd zijn te converteren?

Ja, Aspose.Slides for .NET maakt het werken met wachtwoord‑beveiligde presentaties mogelijk. Bij het verwerken van dergelijke bestanden moet u het juiste wachtwoord opgeven zodat de bibliotheek toegang krijgt tot de inhoud van de presentatie.

### Ondersteunt Aspose.Slides for .NET gebruik in cloud‑oplossingen?

Ja, Aspose.Slides for .NET kan worden geïntegreerd in cloud‑applicaties en -services. De bibliotheek is ontworpen om in serveromgevingen te werken, met hoge prestaties en schaalbaarheid voor batchverwerking van bestanden.

### Zijn er limieten qua bestandsgrootte bij het converteren van presentaties?

Aspose.Slides for .NET kan presentaties van praktisch elke grootte aan. Bij zeer grote bestanden kunnen echter extra systeembronnen nodig zijn, en wordt soms aangeraden de presentatie te optimaliseren om de prestaties te verbeteren.