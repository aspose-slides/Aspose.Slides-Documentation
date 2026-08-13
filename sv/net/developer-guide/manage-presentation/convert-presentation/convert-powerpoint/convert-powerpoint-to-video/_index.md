---
title: Konvertera PowerPoint-presentationer till video i .NET
linktitle: PowerPoint till video
type: docs
weight: 130
url: /sv/net/convert-powerpoint-to-video/
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
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du konverterar PowerPoint-presentationer till video i .NET. Upptäck exempel på C#‑kod och automatiseringstekniker för att förenkla ditt arbetsflöde."
---
## **Introduktion**

Genom att konvertera din PowerPoint- eller OpenDocument-presentation till video får du:

**Ökad tillgänglighet:** Alla enheter, oavsett plattform, har videospelare som standard, vilket gör det enklare för användare att öppna eller spela upp videor jämfört med traditionella presentationsprogram.

**Bredare räckvidd:** Videor gör det möjligt att nå en större publik och presentera information i ett mer engagerande format. Undersökningar och statistik visar att folk föredrar att titta på och konsumera videoinnehåll framför andra former, vilket gör ditt budskap mer genomslagfullt.

{{% alert color="info" %}} 

Kolla in vår [**PowerPoint till Video Online‑konverterare**](https://products.aspose.app/slides/sv/video) eftersom den erbjuder en live‑ och effektiv implementation av processen som beskrivs här.

{{% /alert %}} 

I Aspose.Slides för .NET har vi implementerat stöd för att konvertera presentationer till video.

* Använd Aspose.Slides för .NET för att generera bildrutor från presentationsbilderna med en specificerad bildfrekvens (FPS).
* Använd sedan ett tredjepartsverktyg som ffmpeg för att sammanställa dessa bildrutor till en video.

## **Konvertera en PowerPoint‑presentation till video**

1. Använd `dotnet add package`‑kommandot för att lägga till Aspose.Slides och FFMpegCore‑biblioteket i ditt projekt:
   * kör `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * kör `dotnet add package FFMpegCore --version 4.8.0`
2. Ladda ner ffmpeg från [här](https://ffmpeg.org/download.html).
3. FFMpegCore kräver att du anger sökvägen till den nedladdade ffmpeg (t.ex. extraherad till "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Kör koden för PowerPoint‑till‑video‑konvertering.

Den här C#‑koden visar hur du konverterar en presentation (som innehåller en form och två animationseffekter) till en video:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // kommer att använda FFmpeg-binärerna vi extraherade till C:\tools\ffmpeg tidigare.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Lägg till en smiley-form och animera den sedan.
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

    // Konfigurera mappen för ffmpeg-binärer. Se denna sida: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Konvertera bildrutorna till en webm-video.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Videoeffekter**

När du konverterar en PowerPoint‑presentation till video med Aspose.Slides för .NET kan du applicera olika videoeffekter för att förbättra den visuella kvaliteten på resultatet. Dessa effekter låter dig styra hur bilderna ser ut i den färdiga videon genom att lägga till mjuka övergångar, animationer och andra visuella element. Denna sektion förklarar de tillgängliga videoeffektalternativen och visar hur de appliceras.

{{% alert color="info" %}} 

- [Förbättra PowerPoint‑presentationer med animationer i C#](https://docs.aspose.com/slides/sv/net/powerpoint-animation/)
- [Formanimation](https://docs.aspose.com/slides/sv/net/shape-animation/)
- [Applicera formeffekter i PowerPoint med C#](https://docs.aspose.com/slides/sv/net/shape-effect/)

{{% /alert %}} 

Animationer och övergångar gör bildspel mer engagerande och intressanta — och de gör samma sak för videor. Låt oss lägga till en ytterligare bild och övergång i koden för den föregående presentationen:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // Lägg till en smiley-form och animera den (se koden ovan).

    // Lägg till en ny bild och en animerad övergång.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Aspose.Slides stödjer också textanimationer. I detta exempel animerar vi stycken på objekt så att de visas ett efter ett, med en sekunders fördröjning mellan dem:

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Lägg till text och animationer.
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

    // Konfigurera ffmpeg-binärmappen. Se den här sidan: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Konvertera bildrutorna till en webm-video.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Klasser för videokonvertering**

För att möjliggöra PowerPoint‑till‑video‑konverteringsuppgifter tillhandahåller Aspose.Slides för .NET klasserna [PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/net/aspose.slides.export/presentationanimationsgenerator/) och [PresentationPlayer](https://reference.aspose.com/slides/sv/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` låter dig ange bildstorleken för videon (som kommer att skapas senare) och FPS‑värdet (bilder per sekund) via sin konstruktor. Om du skickar en instans av en presentation används dess `Presentation.SlideSize` och den genererar animationer som [PresentationPlayer](https://reference.aspose.com/slides/sv/net/aspose.slides.export/presentationplayer/) använder.

När animationer genereras triggas en `NewAnimation`‑händelse för varje efterföljande animation, som inkluderar en [IPresentationAnimationPlayer](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipresentationanimationplayer/)‑parameter. Denna klass representerar en spelare för en enskild animation.

För att arbeta med [IPresentationAnimationPlayer](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipresentationanimationplayer/) använder du egenskapen [Duration](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipresentationanimationplayer/duration/) (som anger hela animationens varaktighet) och metoden [SetTimePosition](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Varje animationsposition sätts inom intervallet *0 till duration*, och `GetFrame`‑metoden returnerar sedan en Bitmap som representerar animationstillståndet vid den tidpunkten.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Lägg till en smiley-form och animera den.
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

            animationPlayer.SetTimePosition(0);        // Det initiala animationstillståndet.
            IImage image = animationPlayer.GetFrame(); // Bild av det initiala animationstillståndet.

            animationPlayer.SetTimePosition(animationPlayer.Duration); // Det slutgiltiga tillståndet för animationen.
            IImage lastImage = animationPlayer.GetFrame();             // Den sista bildrutan av animationen.
            lastImage.Save("last.png");
        };
    }
}
```

För att få alla animationer i en presentation att spelas samtidigt används klassen [PresentationPlayer](https://reference.aspose.com/slides/sv/net/aspose.slides.export/presentationplayer/). Denna klass tar en [PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/net/aspose.slides.export/presentationanimationsgenerator/)-instans och ett FPS‑värde för effekter i sin konstruktor, och anropar sedan `FrameTick`‑händelsen för alla animationer för att spela dem:

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

Sedan kan de genererade bildrutorna sammanställas för att skapa en video. Se avsnittet [Convert a PowerPoint Presentation to Video](/slides/sv/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Stödda animationer och effekter**

När du konverterar en PowerPoint‑presentation till video med Aspose.Slides för .NET är det viktigt att förstå vilka animationer och effekter som stöds i resultatet. Aspose.Slides stödjer ett brett spektrum av vanliga ingångs‑, utgångs‑ och betoningseffekter som toning, flyg‑in, zoom och rotation. Vissa avancerade eller anpassade animationer kan dock inte bevaras fullt ut eller kan se annorlunda ut i den färdiga videon. Denna sektion beskriver de stödda animationerna och effekterna.

**Ingång**:

| Animationstyp | Aspose.Slides | PowerPoint |
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

**Betoning**:

| Animationstyp | Aspose.Slides | PowerPoint |
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

**Utgång**:

| Animationstyp | Aspose.Slides | PowerPoint |
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

**Rörelsebanor:**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Stödda bildövergångseffekter**

Bildövergångseffekter spelar en viktig roll för att skapa smidiga och visuellt tilltalande förändringar mellan bilder i en video. Aspose.Slides för .NET stödjer en rad vanliga övergångseffekter för att bevara flödet och stilen i din ursprungliga presentation. Denna sektion lyfter fram vilka övergångseffekter som stöds under konverteringsprocessen.

**Subtil**:

| Animationstyp | Aspose.Slides | PowerPoint |
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

**Spännande**:

| Animationstyp | Aspose.Slides | PowerPoint |
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

**Dynamiskt innehåll**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **Vanliga frågor**

### Är det möjligt att konvertera presentationer som är lösenordsskyddade?

Ja, Aspose.Slides för .NET möjliggör arbete med lösenordsskyddade presentationer. När sådana filer behandlas måste du ange rätt lösenord så att biblioteket kan komma åt presentationens innehåll.

### Stöder Aspose.Slides för .NET användning i molnlösningar?

Ja, Aspose.Slides för .NET kan integreras i molnapplikationer och -tjänster. Biblioteket är utformat för att fungera i servermiljöer och säkerställer hög prestanda och skalbarhet för batch‑behandling av filer.

### Finns det några storleksbegränsningar för presentationer vid konvertering?

Aspose.Slides för .NET kan hantera presentationer av praktiskt taget vilken storlek som helst. När du arbetar med mycket stora filer kan dock extra systemresurser krävas, och det rekommenderas ibland att optimera presentationen för att förbättra prestandan.