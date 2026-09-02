---
title: Tillämpa formanimationer i presentationer i .NET
linktitle: Formanimation
type: docs
weight: 60
url: /sv/net/shape-animation/
keywords:
- form
- animation
- effekt
- animerad form
- animerad text
- lägga till animation
- hämta animation
- extrahera animation
- lägga till effekt
- hämta effekt
- extrahera effekt
- effektljud
- tillämpa animation
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du lägger till, granskar och anpassar formanimationer, timing, ljud, efter-animationbeteende och animerad text med Aspose.Slides för .NET."
---
## **Översikt**

Aspose.Slides for .NET representerar bildanimationer som effekter i en bilds tidslinje. En effekt har en målform, en animationstyp och undertyp, en utlösare, tidsinställningar och valfria egenskaper såsom ljud eller beteende efter animationen.

Tidslinjen innehåller två typer av sekvenser:

- **Huvudsekvensen** spelas när bilden avancerar.
- En **interaktiv sekvens** startar när dess utlösande form klickas.

Eftersom textrutor, bilder, diagram, tabeller och andra bildobjekt implementerar [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/), använder du samma [ISequence.AddEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/isequence/addeffect/) metod för de flesta bildinnehåll. De tillgängliga effekterna listas i uppräkningen [EffectType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effecttype/).

## **Lägg till formanimationer**

För att lägga till en animation, hämta bildens huvudsekvens och anropa [ISequence.AddEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/isequence/addeffect/) med målformen, effekttypen, undertypen och utlösaren. För en effekt som startar när en annan form klickas, skapa en interaktiv sekvens vars utlösare är den andra formen.

Följande exempel skapar båda typerna av animation och sparar resultatet till `shape-animations.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

Utlösaren styr när en effekt startar:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effecttriggertype/) väntar på ett klick i huvudsekvensen, eller på ett klick på utlösningsformen i en interaktiv sekvens.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effecttriggertype/) startar med den föregående effekten.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effecttriggertype/) startar när den föregående effekten avslutas.

För att animera en bild, ett diagram eller en annan formtyp, skicka det objektet till [ISequence.AddEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/isequence/addeffect/) i stället för `targetShape`. För diagramspecifika grupperingalternativ, se [Animated Charts](/slides/sv/net/animated-charts/).

## **Läs formanimationer**

Använd [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/isequence/geteffectsbyshape/) när du känner till målformen. För att inspektera varje effekt, iterera över huvudsekvensen och varje interaktiv sekvens. Enumeration undviker att anta att en sekvens innehåller en effekt på index `0`.

Följande exempel skapar en form med huvudsekvens- och interaktiva effekter, hämtar effekterna som riktar sig mot formen och itererar sedan över varje sekvens på bilden.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

Om du bara behöver effekterna för en form, identifiera först formen efter namn, platshållartyp eller en annan stabil egenskap; anropa sedan [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/isequence/geteffectsbyshape/). Anta inte att [IShapeCollection.Item](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/item/) på index `0` alltid är det avsedda objektet.

## **Arbeta med ärvda platshållareffekter**

En platshållare på en normal bild kan ärva animationsbeteende från motsvarande platshållare på dess layoutbild och mastern. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/getbaseplaceholder/) returnerar den föräldraplatshållaren, eller `null` när ingen förälder finns.

I följande exempelpresentation har sidfoten **Random Bars** på den normala bilden, **Split** på layoutbilden och **Fly In** på mastern.

![Sidfotens animationseffekt på den normala bilden](slide-shape-animation.png)
![Sidfotens platshållaranimationseffekt på layoutbilden](layout-shape-animation.png)
![Sidfotens platshållaranimationseffekt på mastern](master-shape-animation.png)

Nästa exempel bygger platshållarhierarkin själv. Det lägger till effekter på en master-platshållare, en layout-platshållare och motsvarande platshållare på en normal bild. Varje anrop till [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/getbaseplaceholder/) kontrolleras innan den returnerade formen används.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **Ändra animationstiming**

PowerPoint **Timing**-dialogen motsvarar egenskaperna i [ITiming](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/).

![PowerPoint Timing-dialog för en animationseffekt](shape-animation.png)

- **Start** motsvarar [ITiming.TriggerType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/triggertype/).
- **Duration** motsvarar [ITiming.Duration](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/duration/), i sekunder.
- **Delay** motsvarar [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/triggerdelaytime/), i sekunder.
- **Repeat** motsvarar [ITiming.RepeatCount](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatuntilnextclick/), eller [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatuntilendslide/).
- **Spola tillbaka när uppspelning är klar** motsvarar [ITiming.Rewind](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/rewind/).

Detta fristående exempel lägger till en effekt, ändrar dess timing via objektet som returneras av [ISequence.AddEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/isequence/addeffect/), och sparar resultatet. Att behålla den returnerade [IEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/)‑referensen undviker ett onödigt samlingsindex.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

Använd ett upprepningsläge med avsikt. Att kombinera ett upprepningsantal med ett "tills"‑flagga kan ge förvirrande resultat i olika visare. När du ändrar upprepningslägen, sätt [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatuntilnextclick/) och [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatuntilendslide/) innan [ITiming.RepeatCount](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatcount/), eftersom inställning av någon av flaggorna också ändrar det aktiva upprepningsläget.

## **Lägg till och extrahera animationsljud**

En animationseffekt kan referera till inbäddat ljud via [IEffect.Sound](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/sound/). [IEffect.StopPreviousSound](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/stopprevioussound/) instruerar en effekt att stoppa ljud som startats av en tidigare effekt.

### **Lägg till ett ljud till en effekt**

Följande exempel förväntar sig en lokal ljudfil med namnet `animation-sound.wav`. Det skapar två effekter, bäddar in den filen som ljud för den första effekten och konfigurerar den andra effekten att stoppa ljudet. Det använder objekten som returneras av [ISequence.AddEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/isequence/addeffect/), så inget sekvensindex krävs.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **Extrahera inbäddade effektljud**

Följande exempel förväntar sig en lokal presentation med namnet `presentation-with-animation-sounds.pptx`. Det genomsöker både huvud- och interaktiva sekvenser och skriver varje inbäddat effektljud till katalogen `extracted-animation-sounds`. Filändelsen väljs utifrån ljud‑MIME‑typen som exponeras av [IAudio.ContentType](https://reference.aspose.com/slides/sv/net/aspose.slides/iaudio/contenttype/).

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

För stora ljudobjekt, använd [IAudio.GetStream](https://reference.aspose.com/slides/sv/net/aspose.slides/iaudio/getstream/) och kopiera strömmen till en fil istället för att läsa in hela objektet i en byte‑array.

## **Ställ in efter‑animationsbeteende**

**After animation**‑alternativet styr vad som händer med en form efter att dess effekt är klar.

![PowerPoint Effektalternativ‑dialog som visar efter‑animationsinställningar](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/afteranimationtype/)‑uppsättningen stöder att lämna formen oförändrad, ändra dess färg, dölja den efter animationen, eller dölja den vid nästa klick. När typen är [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/afteranimationtype/), sätt även [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/afteranimationcolor/).

Detta fristående exempel skapar en effekt, sätter dess efter‑animationsbeteende via det returnerade effektobjektet, och sparar resultatet.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

Att byta typen från [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/afteranimationtype/) rensar efter‑animationsfärgsinställningen.

## **Animera text**

Textanimation har två relaterade kontroller:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itextanimation/buildtype/) styr om stycken visas tillsammans eller per stycknivå.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/animatetexttype/) styr om text visas på en gång, per ord eller per bokstav. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/delaybetweentextparts/) anger fördröjningen mellan ord eller bokstäver. Ett positivt värde är en procentsats av effektens varaktighet; ett negativt värde är en fördröjning i sekunder.

Följande fristående exempel animera orden i en textruta. [BuildType.AsOneObject](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/buildtype/) inaktiverar byggning stycke för stycke så att ordinställningen gäller för hela textramen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

För att bygga en textruta stycke för stycke, sätt [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/buildtype/) (eller en annan stycknivå). För att rikta en enskild stycke med sin egen effekt, använd den [ISequence.AddEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/isequence/addeffect/)‑överladdning som accepterar ett [IParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/). Se [Animated Text](/slides/sv/net/animated-text/) för exempel på stycknivå.

## **Export- och kompatibilitetsanteckningar**

- Att spara till PPT eller PPTX bevarar animationsmodellen, men den slutgiltiga uppspelningen styrs av presentationsvisaren.
- PDF och statiska bilder spelar inte upp animationer. Använd [HTML5 export](/slides/sv/net/export-to-html5/), animerad GIF eller [video conversion](/slides/sv/net/convert-powerpoint-to-video/) när utdata måste visa rörelse.
- För HTML5, aktivera [Html5Options.AnimateShapes](https://reference.aspose.com/slides/sv/net/aspose.slides.export/html5options/animateshapes/) och, vid behov, [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/html5options/animatetransitions/).
- Video‑rendering stödjer många vanliga ingångs‑, betoning‑, utgångs‑ och rörelse‑ban‑effekter, men inte alla PowerPoint‑effekter stöds. Kontrollera den aktuella [supported animations and effects](/slides/sv/net/convert-powerpoint-to-video/#supported-animations-and-effects) och testa kritiska presentationer med din mål‑Aspose.Slides‑version.
- Avancerade anpassade effekter och effekter som importeras från andra presentationsformat kan bevaras i filen men renderas olika i PowerPoint, HTML5 eller video. Validera det exporterade resultatet i stället för att enbart förlita sig på effektens namn.

## **FAQ**

**Varför visas en animation i PowerPoint men inte i en PDF?**

PDF är ett statiskt format, så animationer och bildövergångar spelas inte upp. Exportera till HTML5, animerad GIF eller video när rörelse måste bevaras.

**Varför spelas en effekt annorlunda i en video?**

Video‑export renderar animationer istället för att lagra det ursprungliga PowerPoint‑beteendet. Vissa avancerade effekter stöds inte eller approximeras. Granska tabellen med stödda effekter och testa den faktiska presentationen innan produktionsanvändning.

**Ändrar flyttning av en form framåt eller bakåt dess animationsordning?**

Nej. Formens z‑ordning styr överlappning, medan sekvensordning och utlösare styr animationsuppspelning. Ändra tidslinjen om du behöver en annan uppspelningsordning.