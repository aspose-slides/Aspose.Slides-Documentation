---
title: Vormanimaties toepassen in presentaties in .NET
linktitle: Vormanimatie
type: docs
weight: 60
url: /nl/net/shape-animation/
keywords:
- vorm
- animatie
- effect
- geanimeerde vorm
- geanimeerde tekst
- animatie toevoegen
- animatie ophalen
- animatie extraheren
- effect toevoegen
- effect ophalen
- effect extraheren
- effectgeluid
- animatie toepassen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u vormanimaties, timing, geluiden, gedrag na animatie en geanimeerde tekst kunt toevoegen, inspecteren en aanpassen met Aspose.Slides voor .NET."
---
## **Overzicht**

Om te werken met de individuele gedragselementen binnen een effect of om motion‑path‑segmenten te bewerken, zie [Aangepaste animatie](/slides/nl/net/custom-animation/).

Aspose.Slides voor .NET vertegenwoordigt dia‑animaties als effecten in een dia‑tijdlijn. Een effect heeft een doelvorm, een animatietype en subtype, een trigger, tijdinstellingen en optionele eigenschappen zoals geluid of gedrag na de animatie.

De tijdlijn bevat twee soorten sequenties:

- De **hoofd­sequentie** wordt afgespeeld terwijl de dia vordert.
- Een **interactieve sequentie** start wanneer de trigger‑vorm wordt aangeklikt.

Omdat tekstvakken, afbeeldingen, grafieken, tabellen en andere dia‑objecten [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) implementeren, gebruik je dezelfde [ISequence.AddEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/isequence/addeffect/)‑methode voor de meeste dia‑inhoud. De beschikbare effecten staan opgesomd in de enumeratie [EffectType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effecttype/).

## **Vormanimaties toevoegen**

Om een animatie toe te voegen, haal je de hoofd­sequentie van de dia op en roep je [ISequence.AddEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/isequence/addeffect/) aan met de doelvorm, het effecttype, subtype en trigger. Voor een effect dat start wanneer een andere vorm wordt aangeklikt, maak je een interactieve sequentie waarvan de trigger die andere vorm is.

Het volgende voorbeeld maakt beide soorten animatie en slaat het resultaat op als `shape-animations.pptx`.

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

De trigger bepaalt wanneer een effect start:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effecttriggertype/) wacht op een klik in de hoofd­sequentie, of op een klik op de trigger‑vorm in een interactieve sequentie.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effecttriggertype/) start gelijktijdig met het voorgaande effect.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effecttriggertype/) start wanneer het voorgaande effect is afgelopen.

Om een afbeelding, grafiek of een ander type vorm te animeren, geef je dat object door aan [ISequence.AddEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/isequence/addeffect/) in plaats van `targetShape`. Voor grafiek‑specifieke groepeermogelijkheden, zie [Geanimeerde grafieken](/slides/nl/net/animated-charts/).

## **Vormanimaties lezen**

Gebruik [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/isequence/geteffectsbyshape/) wanneer je de doelvorm kent. Om elk effect te inspecteren, doorloop je de hoofd­sequentie en elke interactieve sequentie. Enumeratie voorkomt de veronderstelling dat een sequentie een effect bevat op index `0`.

Het volgende voorbeeld maakt een vorm met hoofd‑ en interactieve effecten, haalt de effecten op die de vorm targeten, en doorloopt vervolgens elke sequentie op de dia.

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

Als je alleen de effecten voor één vorm nodig hebt, identificeer dan eerst de vorm op naam, placeholder‑type of een andere stabiele eigenschap; roep vervolgens [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/isequence/geteffectsbyshape/) aan. Ga niet ervan uit dat [IShapeCollection.Item](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/item/) op index `0` altijd het beoogde object is.

## **Werken met geërfde placeholder‑effecten**

Een placeholder op een gewone dia kan animatiegedrag overnemen van de overeenkomstige placeholder op de lay-out‑dia en de master‑dia. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/getbaseplaceholder/) retourneert die bovenliggende placeholder, of `null` wanneer er geen bovenligger bestaat.

In de volgende voorbeeldpresentatie heeft de voettekst **Random Bars** op de gewone dia, **Split** op de lay-out‑dia, en **Fly In** op de master‑dia.

![Voettekst‑animatie‑effect op de gewone dia](slide-shape-animation.png)

![Voettekst‑placeholder‑animatie‑effect op de lay-out‑dia](layout-shape-animation.png)

![Voettekst‑placeholder‑animatie‑effect op de master‑dia](master-shape-animation.png)

Het volgende voorbeeld bouwt de placeholder‑hiërarchie zelf op. Het voegt effecten toe aan een master‑placeholder, een lay-out‑placeholder en de overeenkomstige placeholder op een gewone dia. Elke aanroep van [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/getbaseplaceholder/) wordt gecontroleerd voordat de geretourneerde vorm wordt gebruikt.

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

## **Animatietiming wijzigen**

Het PowerPoint **Timing**‑dialoogvenster correspondeert met de eigenschappen van [ITiming](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/).

![PowerPoint Timing‑dialoogvenster voor een animatie‑effect](shape-animation.png)

- **Start** correspondeert met [ITiming.TriggerType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/triggertype/).
- **Duur** correspondeert met [ITiming.Duration](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/duration/), in seconden.
- **Vertraging** correspondeert met [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/triggerdelaytime/), in seconden.
- **Herhaal** correspondeert met [ITiming.RepeatCount](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatuntilnextclick/) of [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatuntilendslide/).
- **Terugspoelen bij afloop** correspondeert met [ITiming.Rewind](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/rewind/).

Dit zelfstandige voorbeeld voegt een effect toe, wijzigt de timing via het object dat door [ISequence.AddEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/isequence/addeffect/) wordt geretourneerd, en slaat het resultaat op. Het behouden van de geretourneerde [IEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/)‑referentie voorkomt een onnodige collectie‑index.

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

Gebruik opzettelijk één herhaalmodus. Het combineren van een herhaal‑aantal met een “until”‑vlag kan verwarrende resultaten opleveren in verschillende viewers. Wanneer je de herhaalmodi wijzigt, stel je eerst [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatuntilnextclick/) en [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatuntilendslide/) in vóór [ITiming.RepeatCount](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatcount/), omdat het zetten van één van die vlaggen ook de actieve herhaalmodus wijzigt.

## **Animatiegeluiden toevoegen en extraheren**

Een animatie‑effect kan ingebedde audio refereren via [IEffect.Sound](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/sound/). [IEffect.StopPreviousSound](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/stopprevioussound/) instrueert een effect om audio te stoppen die door een eerder effect is gestart.

### **Een geluid toevoegen aan een effect**

Het volgende voorbeeld verwacht een lokaal audiobestand met de naam `animation-sound.wav`. Het maakt twee effecten, embed dit bestand als geluid voor het eerste effect, en configureert het tweede effect om het geluid te stoppen. Het gebruikt de objecten die door [ISequence.AddEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/isequence/addeffect/) worden geretourneerd, zodat er geen sequentie‑index nodig is.

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

### **Ingesloten effectgeluiden extraheren**

Het volgende voorbeeld verwacht een lokale presentatie met de naam `presentation-with-animation-sounds.pptx`. Het scant zowel de hoofd‑ als de interactieve sequenties en schrijft elk ingebed effectgeluid naar de map `extracted-animation-sounds`. De extensie wordt gekozen op basis van het audio‑MIME‑type dat door [IAudio.ContentType](https://reference.aspose.com/slides/nl/net/aspose.slides/iaudio/contenttype/) wordt blootgesteld.

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

Voor grote audio‑objecten, gebruik [IAudio.GetStream](https://reference.aspose.com/slides/nl/net/aspose.slides/iaudio/getstream/) en kopieer de stream naar een bestand in plaats van het volledige object in een byte‑array te laden.

## **Nabewerking‑gedrag instellen**

De optie **After animation** bepaalt wat er met een vorm gebeurt nadat het effect is afgelopen.

![PowerPoint Effect Options‑dialoog die After‑animation‑instellingen toont](shape-after-animation.png)

De enumeratie [AfterAnimationType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/afteranimationtype/) ondersteunt het ongewijzigd laten van de vorm, het veranderen van de kleur, verbergen na de animatie, of verbergen bij de volgende klik. Wanneer het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/afteranimationtype/) is, stel je ook [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/afteranimationcolor/) in.

Dit zelfstandige voorbeeld maakt een effect, stelt het after‑animation‑gedrag in via het geretourneerde effectobject, en slaat het resultaat op.

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

Het wijzigen van het type van [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/afteranimationtype/) wist de after‑animation‑kleurinstelling.

## **Tekst animeren**

Tekstanimatie heeft twee verwante instellingen:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itextanimation/buildtype/) bepaalt of alinea’s samen of per alinea‑niveau verschijnen.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/animatetexttype/) bepaalt of tekst in één keer, per woord of per letter verschijnt. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/delaybetweentextparts/) stelt de vertraging tussen woorden of letters in. Een positieve waarde is een percentage van de effectduur; een negatieve waarde is een vertraging in seconden.

Het volgende zelfstandige voorbeeld animeert de woorden in een tekstvak. [BuildType.AsOneObject](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/buildtype/) schakelt het per‑alinea‑bouwen uit zodat de woordeninstelling van toepassing is op het volledige tekstkader.

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

Om een tekstvak per alinea op te bouwen, stel je [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/buildtype/) (of een ander alinea‑niveau) in. Om een enkele alinea met een eigen effect te targeten, gebruik je de overload van [ISequence.AddEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/isequence/addeffect/) die een [IParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/) accepteert. Zie [Geanimeerde tekst](/slides/nl/net/animated-text/) voor voorbeelden per alinea.

## **Export‑ en compatibiliteitsopmerkingen**

- Het opslaan naar PPT of PPTX behoudt het animatiemodel, maar de uiteindelijke weergave wordt bepaald door de presentatie‑viewer.
- PDF en statische afbeeldingen spelen geen animaties af. Gebruik [HTML5 export](/slides/nl/net/export-to-html5/), geanimeerde GIF, of [video‑conversie](/slides/nl/net/convert-powerpoint-to-video/) wanneer de output beweging moet tonen.
- Schakel voor HTML5 [Html5Options.AnimateShapes] in en, indien nodig, [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/html5options/animatetransitions/).
- Videorendering ondersteunt veel gangbare entrance‑, emphasis‑, exit‑ en motion‑path‑effecten, maar niet elk PowerPoint‑effect wordt ondersteund. Controleer de huidige [supported animations and effects](/slides/nl/net/convert-powerpoint-to-video/#supported-animations-and-effects) en test cruciale presentaties met de beoogde Aspose.Slides‑versie.
- Geavanceerde aangepaste effecten en effecten geïmporteerd uit andere presentatieformaten kunnen in het bestand bewaard blijven maar anders worden gerenderd in PowerPoint, HTML5 of video. Valideer het geëxporteerde resultaat in plaats van alleen op de effectnaam te vertrouwen.

## **FAQ**

**Waarom verschijnt een animatie in PowerPoint maar niet in een PDF?**

PDF is een statisch formaat, waardoor animaties en dia‑overgangen niet worden afgespeeld. Exporteer naar HTML5, een geanimeerde GIF, of video wanneer beweging behouden moet blijven.

**Waarom wordt een effect anders afgespeeld in een video?**

Video‑export rendert animaties in plaats van het oorspronkelijke PowerPoint‑gedrag op te slaan. Sommige geavanceerde effecten worden niet ondersteund of slechts benaderd. Bekijk de tabel met ondersteunde effecten en test de daadwerkelijke presentatie vóór productiegebruik.

**Verandert het naar voren of naar achteren verplaatsen van een vorm de animatievolgorde?**

Nee. De z‑order van vormen bepaalt de overlapping, terwijl de volgorde van sequenties en triggers de animatie‑afspeelvolgorde bepalen. Pas de tijdlijn aan als je een andere afspeelvolgorde nodig hebt.