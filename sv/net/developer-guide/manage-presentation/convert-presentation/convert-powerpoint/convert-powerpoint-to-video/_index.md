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
description: "Lär dig hur du konverterar PowerPoint-presentationer till video i .NET. Upptäck exempel på C#-kod och automatiseringstekniker för att effektivisera ditt arbetsflöde."
---
## **Introduktion**

Genom att konvertera din PowerPoint‑ eller OpenDocument‑presentation till video får du:

**Ökad tillgänglighet:** Alla enheter, oavsett plattform, har videospelare inbyggda som standard, vilket gör det enklare för användare att öppna eller spela upp videor jämfört med traditionella presentationsprogram.

**Större räckvidd:** Videor låter dig nå en bredare publik och presentera information i ett mer engagerande format. Undersökningar och statistik visar att folk föredrar att titta på och konsumera videoinnehåll framför andra former, vilket gör ditt budskap mer genomslagskraftigt.

{{% alert color="primary" %}} 
Kolla in vår [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/sv/video) eftersom den erbjuder en levande och effektiv implementering av processen som beskrivs här.
{{% /alert %}} 

I Aspose.Slides för .NET har vi implementerat stöd för att konvertera presentationer till video.

* Använd Aspose.Slides för .NET för att generera bildrutor från presentationsbilderna med en angiven bildhastighet (FPS).
* Använd sedan ett tredjepartsverktyg som ffmpeg för att sammanfoga dessa bildrutor till en video.

## **Konvertera en PowerPoint‑presentation till video**

1. Använd kommandot `dotnet add package` för att lägga till Aspose.Slides och FFMpegCore‑biblioteket i ditt projekt:
   * kör `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * kör `dotnet add package FFMpegCore --version 4.8.0`
2. Ladda ner ffmpeg från [here](https://ffmpeg.org/download.html).
3. FFMpegCore kräver att du anger sökvägen till den nedladdade ffmpeg (t.ex. extraherad till "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Kör kodexemplet för PowerPoint‑till‑video‑konverteringen.

Denna C#‑kod visar hur du konverterar en presentation (med en form och två animeringseffekter) till en video:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // kommer att använda de FFmpeg-binärer vi extraherade till C:\tools\ffmpeg tidigare.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Lägg till en smileyform och animera den sedan.
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

    // Konfigurera ffmpeg-binärmappen. Se den här sidan: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Konvertera bildrutorna till en webm-video.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Videoeffekter**

När du konverterar en PowerPoint‑presentation till video med Aspose.Slides för .NET kan du använda olika videoeffekter för att förbättra den visuella kvaliteten på resultatet. Dessa effekter låter dig styra hur bilderna ser ut i den slutliga videon genom att lägga till mjuka övergångar, animationer och andra visuella element. Denna sektion förklarar de tillgängliga videoeffektalternativen och visar hur du använder dem.

{{% alert color="primary" %}} 
Se:
- [Enhancing PowerPoint Presentations with Animations in C#](https://docs.aspose.com/slides/sv/net/powerpoint-animation/)
- [Shape Animation](https://docs.aspose.com/slides/sv/net/shape-animation/)
- [Apply Shape Effects in PowerPoint Using C#](https://docs.aspose.com/slides/sv/net/shape-effect/)
{{% /alert %}} 

Animationer och övergångar gör bildspel mer engagerande och intressanta – och de gör samma sak för videor. Låt oss lägga till en extra bild och övergång i koden för den föregående presentationen:

```c#
    // Lägg till en smileyform och animera den.
    // ...

    // Lägg till en ny bild och en animerad övergång.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides stödjer även textanimationer. I detta exempel animerar vi stycken på objekt så att de visas ett efter ett, med en sekunds fördröjning mellan dem:

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

För att möjliggöra PowerPoint‑till‑video‑konverteringar tillhandahåller Aspose.Slides för .NET klasserna [PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/net/aspose.slides.export/presentationanimationsgenerator/) och [PresentationPlayer](https://reference.aspose.com/slides/sv/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` låter dig ange bildstorlek för videon (som kommer att skapas senare) och FPS‑värdet via sin konstruktor. Om du passerar en presentationsinstans används dess `Presentation.SlideSize` och den genererar animationer som [PresentationPlayer](https://reference.aspose.com/slides/sv/net/aspose.slides.export/presentationplayer/) använder.

När animationer genereras utlöses ett `NewAnimation`‑event för varje efterföljande animation, vilket inkluderar en [IPresentationAnimationPlayer](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipresentationanimationplayer/)‑parameter. Denna klass representerar en spelare för en enskild animation.

För att arbeta med [IPresentationAnimationPlayer](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipresentationanimationplayer/) använder du egenskapen [Duration](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipresentationanimationplayer/duration/) (som ger hela animationens varaktighet) och metoden [SetTimePosition](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Varje animationsposition sätts inom intervallet *0 till duration*, och `GetFrame`‑metoden returnerar sedan en Bitmap som representerar animationens tillstånd vid den tidpunkten.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Lägg till en smileyform och animera den.
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

            animationPlayer.SetTimePosition(0);          // Det initiala animationsläget.
            Bitmap bitmap = animationPlayer.GetFrame();  // Bitmap för det initiala animationsläget.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // Det slutliga tillståndet för animationen.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // Den sista bildrutan av animationen.
            lastBitmap.Save("last.png");
        };
    }
}
```

För att alla animationer i en presentation ska spelas samtidigt används klassen [PresentationPlayer](https://reference.aspose.com/slides/sv/net/aspose.slides.export/presentationplayer/). Den tar en [PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/net/aspose.slides.export/presentationanimationsgenerator/)‑instans och ett FPS‑värde för effekter i sin konstruktor, och anropar sedan `FrameTick`‑eventet för alla animationer så att de spelas:

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

De genererade bildrutorna kan sedan sammanfogas för att producera en video. Se sektionen [Convert a PowerPoint Presentation to Video](/slides/sv/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Stödda animationer och effekter**

När du konverterar en PowerPoint‑presentation till video med Aspose.Slides för .NET är det viktigt att förstå vilka animationer och effekter som stöds i utdata. Aspose.Slides stödjer ett brett spektrum av vanliga ingångs‑, utgångs‑ och betoningseffekter såsom toning, flygning, zoom och rotation. Vissa avancerade eller anpassade animationer kan dock inte bevaras fullt ut eller kan visas annorlunda i den slutliga videon. Denna sektion beskriver de stödda animationerna och effekterna.

**Ingång**:

| Animeringstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Fade** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Fly In** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Float In** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Split** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Wipe** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Shape** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Wheel** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Random Bars** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Grow & Turn** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Zoom** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Swivel** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Bounce** | ![Stöds](v.png) | ![Stöds](v.png) |

**Betoning**:

| Animeringstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Color Pulse** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Teeter** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Spin** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Grow/Shrink** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Desaturate** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Darken** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Lighten** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Transparency** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Object Color** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Complementary Color** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Line Color** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Fill Color** | ![Ej stöd](x.png) | ![Stöds](v.png) |

**Utgång**:

| Animeringstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Fade** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Fly Out** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Float Out** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Split** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Wipe** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Shape** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Random Bars** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Shrink & Turn** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Zoom** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Swivel** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Bounce** | ![Stöds](v.png) | ![Stöds](v.png) |

**Rörelsebanor**:

| Animeringstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Arcs** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Turns** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Shapes** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Loops** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Custom Path** | ![Stöds](v.png) | ![Stöds](v.png) |

## **Stödda bildövergångseffekter**

Bildövergångseffekter spelar en viktig roll för att skapa smidiga och visuellt tilltalande övergångar mellan bilder i en video. Aspose.Slides för .NET stödjer ett antal vanliga övergångseffekter för att bevara flödet och stilen i din ursprungliga presentation. Denna sektion visar vilka övergångseffekter som stödjs under konverteringen.

**Subtila**:

| Animeringstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Fade** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Push** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Pull** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Wipe** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Split** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Reveal** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Random Bars** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Shape** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Uncover** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Cover** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Flash** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Strips** | ![Stöds](v.png) | ![Stöds](v.png) |

**Spännande**:

| Animeringstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Drape** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Curtains** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Wind** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Prestige** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Fracture** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Crush** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Peel Off** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Page Curl** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Airplane** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Origami** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Dissolve** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Checkerboard** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Blinds** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Clock** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Ripple** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Honeycomb** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Glitter** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Vortex** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Shred** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Switch** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Flip** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Gallery** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Cube** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Doors** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Box** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Comb** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Zoom** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Random** | ![Ej stöd](x.png) | ![Stöds](v.png) |

**Dynamiskt innehåll**:

| Animeringstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Ferris Wheel** | ![Stöds](v.png) | ![Stöds](v.png) |
| **Conveyor** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Rotate** | ![Ej stöd](x.png) | ![Stöds](v.png) |
| **Orbit** | ![Ej stör](x.png) | ![Stöds](v.png) |
| **Fly Through** | ![Stöds](v.png) | ![Stöds](v.png) |

## **Vanliga frågor**

**Är det möjligt att konvertera presentationer som är lösenordsskyddade?**

Ja, Aspose.Slides för .NET tillåter arbete med lösenordsskyddade presentationer. När du bearbetar sådana filer måste du ange rätt lösenord så att biblioteket kan komma åt presentationens innehåll.

**Stöder Aspose.Slides för .NET användning i molnlösningar?**

Ja, Aspose.Slides för .NET kan integreras i molnapplikationer och -tjänster. Biblioteket är designat för att fungera i servermiljöer och säkerställer hög prestanda och skalbarhet för batch‑bearbetning av filer.

**Finns det några storleksbegränsningar för presentationer under konvertering?**

Aspose.Slides för .NET kan hantera presentationer av praktiskt taget alla storlekar. Vid mycket stora filer kan dock extra systemresurser behövas, och det kan ibland rekommenderas att optimera presentationen för att förbättra prestandan.