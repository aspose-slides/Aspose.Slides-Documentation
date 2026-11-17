---
title: Diaovergangen beheren in presentaties in .NET
linktitle: Diaovergang
type: docs
weight: 90
url: /nl/net/slide-transition/
keywords:
- diaovergang
- diaovergang toevoegen
- diaovergang toepassen
- geavanceerde diaovergang
- Morph-overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas diaovergangen toe, configureer automatische voortgang van dia's, en pas Morph en andere overgangseffecten aan met Aspose.Slides voor .NET."
---
## **Overzicht**

Diaovergangen bepalen hoe dia’s verschijnen tijdens een diavoorstelling. Met Aspose.Slides for .NET kun je een overgangseffect kiezen voor elke dia, de voortgang configureren via muisklik of timer, en opties aanpassen die specifiek zijn voor een effect. Dit artikel gebruikt C#‑voorbeelden om overgangen toe te passen, exacte overgangsduren in te stellen, de timing van dia’s te beheren en een Morph‑overgang tussen twee dia’s te maken. De voorbeelden tonen ook hoe de instellingen op te slaan in een PPTX‑bestand.

## **Diaovergang toevoegen**

Om een overgang toe te passen, laad je een presentatie met de [Presentatie](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑klasse en benader je de dia‑eigenschap [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/). Stel de [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) in op een waarde uit de [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/)-enumeratie en sla vervolgens de presentatie op.

Het volgende voorbeeld past een Circle‑overgang toe op de eerste dia en een Comb‑overgang op de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia’s.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Wheel‑overgang**

De [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/)‑eigenschap van [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) bepaalt het aantal radiale sectoren waarmee de doel­dia wordt onthuld. Stel de dia‑overgangs‑[Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) in op Wheel uit [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) voordat je de [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) benadert als [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/).

Dit voorbeeld maakt twee identieke paren dia’s: een zwarte dia gevolgd door een dia met een gouden rechthoek. De doel­dia’s gebruiken een spook‑aantal van 1 en 8, met dezelfde [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) en een expliciete [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) van 8 000 milliseconden om het verschil duidelijk te maken.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slideWidth = presentation.SlideSize.Size.Width;
var slideHeight = presentation.SlideSize.Size.Height;

var blackSlide = presentation.Slides[0];
blackSlide.Shapes.Clear();
blackSlide.Background.Type = BackgroundType.OwnBackground;
blackSlide.Background.FillFormat.FillType = FillType.Solid;
blackSlide.Background.FillFormat.SolidFillColor.Color = Color.Black;

var destinationSlide = presentation.Slides.AddClone(blackSlide);
var rectangle = destinationSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
rectangle.FillFormat.FillType = FillType.Solid;
rectangle.FillFormat.SolidFillColor.Color = Color.Gold;
rectangle.TextFrame.Text = "Wheel transition";

presentation.Slides.AddClone(blackSlide);
presentation.Slides.AddClone(destinationSlide);

var spokeCounts = new uint[] { 1, 8 };
for (var i = 0; i < spokeCounts.Length; i++)
{
    var transition = presentation.Slides[i * 2 + 1].SlideShowTransition;
    transition.Type = TransitionType.Wheel;
    var wheelTransition = (IWheelTransition)transition.Value;
    wheelTransition.Spokes = spokeCounts[i];
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 8000;
}

presentation.Save("wheel-transitions.pptx", SaveFormat.Pptx);
```

Open de uitvoer‑presentatie in PowerPoint en start de diavoorstelling. Ga van dia 1 naar dia 2 en vervolgens van dia 3 naar dia 4. In PowerPoint‑afspelen onthult het gecontroleerde spook‑aantal van 1 de dia met één klok‑mee beweging; het gecontroleerde aantal van 8 onthult de dia via acht radiale sectoren tegelijk. De doelinhoud en overgangstiming zijn identiek, dus het verschil zit in het aantal onthullings‑sectoren.

## **Geavanceerde diaovergang toevoegen**

Je kunt configureren hoe lang een dia op het scherm blijft en of een muisklik de diavoorstelling voortzet. De volgende eigenschappen regelen dit gedrag:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) laat de gebruiker voortgaan door te klikken.
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) schakelt automatische voortgang in.
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) specificeert de wachttijd vóór automatische voortgang, in milliseconden.

Schakel zowel klik‑ als timer‑voortgang in zodat de gebruiker kan doorgaan met een klik of wachten op de timer. Gebruik alleen de timer door [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) op `false` te zetten. De vertraging bepaalt wanneer de diavoorstelling voortgaat; hij stelt de duur van het visuele overgangseffect niet in.

Dit voorbeeld kent verschillende effecten toe aan de eerste drie dia’s en schakelt automatische voortgang in na respectievelijk 3, 5 en 7 seconden. Muisklikken kunnen deze dia’s ook voortzetten. Gebruik een `input.pptx`‑bestand met minstens drie dia’s.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

Om te controleren of timer‑voortgang is ingeschakeld, lees je [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/). Een opgeslagen vertraging alleen geeft niet aan dat de timer actief is.

Het volgende voorbeeld opent het eerder opgeslagen bestand, meldt elke ingeschakelde timer en schakelt automatische voortgang uit voor dia’s met een vertraging groter dan twee seconden. Het schakelt muisklikken voor die dia’s in en slaat de bijgewerkte instellingen op.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Overgangstiming nauwkeurig regelen**

Gebruik [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) om de exacte lengte van een overgangseffect in milliseconden op te geven. De dia‑eigenschap [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) maakt deze instellingen bloot via [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/):

| Eigenschap | Doel |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Stelt de vertraging vóór automatische voortgang van de dia in, in milliseconden. Schakel [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) in om deze timer te activeren. |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | Selecteert een voorgedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium, of Fast. Wordt gebruikt wanneer geen exacte duur is gespecificeerd. |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) regelt alleen het overgangseffect; hij bepaalt niet hoe lang de dia zichtbaar blijft. Configureer de automatische voortgangs‑vertraging apart. Wanneer geen expliciete duur is ingesteld, bepaalt Aspose.Slides de effectduur aan de hand van het overgangstype en de [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/)‑waarde.

### **Dezelfde duur op elke dia toepassen**

Voor een consistente timing, pas hetzelfde effect en dezelfde exacte duur toe op elke dia. Dit voorbeeld laadt `input.pptx`, selecteert Fade uit [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) en geeft elke overgang een duur van 750 milliseconden. Het schakelt onafhankelijk automatische voortgang in na 5 000 milliseconden en schakelt voortgang via muisklik uit, waarna het resultaat als PPTX wordt opgeslagen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // Stel automatische voortgang in, onafhankelijk van de duur van het effect.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Verschillende duur per individuele dia**

Verschillende dia’s kunnen verschillende effectduur hebben. Bijvoorbeeld, gebruik een korte overgang voor een titeldia en een langere overgang voor een sectie‑introductie. Dit voorbeeld stelt 500 milliseconden in voor de eerste dia en 1 200 milliseconden voor de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia’s.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Overgangen afstemmen op geanimeerde output**

Wanneer je een [animated GIF](/slides/nl/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/nl/net/export-to-html5/) of [video](/slides/nl/net/convert-powerpoint-to-video/) voorbereidt, stel dan exacte overgangsduren in vóór export om de gewenste timing te behalen. Gebruik bijvoorbeeld een fade van 600 milliseconden tussen scènes en pas elke dia‑vervoortgangs‑vertraging apart aan zodat er tijd is voor de voice‑over of inhoud.

Voor GIF‑ en video‑output stem je de frame‑rate af op de effectduur: 600 milliseconden komt overeen met 18 frames bij 30 fps. In HTML5 schakel je geanimeerde overgangen in via de export‑instellingen. Controleer de ondersteunde effecten en timingopties van het gekozen exportformaat en bekijk een preview om synchronisatie te bevestigen.

### **Bestaande overgangsduur lezen**

Lees [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) voordat je de overgang wijzigt om te bepalen of er een expliciete waarde is opgeslagen. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden aan. De niet‑ingestelde waarde is niet de berekende afspeelduur: Aspose.Slides gebruikt het overgangstype en de [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) om die duur te bepalen. Het instellen van een overgangstype kan een duur initialiseren, dus inspecteer eerst de oorspronkelijke instellingen.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Morph‑overgang**

De Morph‑overgang animeert wijzigingen tussen objecten op opeenvolgende dia’s. Om een eenvoudige Morph‑effect te creëren, kloon je een dia, verplaats of wijzig je de grootte van een object op de kloon, en pas je de Morph‑overgang toe op de tweede dia. Dit geeft de overgang corresponderende objecten om te animeren tussen hun originele en aangepaste toestand.

Het volgende voorbeeld maakt een dia met een tekstrechthoek, kloont de dia en verandert de positie en grootte van de rechthoek op de kloon. Daarna selecteert het Morph uit de [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/)‑enumeratie voor de tweede dia. Open het opgeslagen bestand in een presentatieweergave die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Morph‑overgangstypen**

De [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/)‑enumeratie bepaalt hoe Morph inhoud overeenkomt en animeert:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) behandelt elke vorm als één geheel.
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door woorden waar mogelijk te koppelen.
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door tekens waar mogelijk te koppelen.

Stel de overgangs‑[Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) in op Morph voordat je de [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) benadert. De waarde levert vervolgens de [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/)‑interface, waarvan de [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/)‑eigenschap de overeenkomstmodus selecteert.

Dit voorbeeld opent de presentatie die in de vorige sectie is gemaakt en configureert de tweede dia om woord‑gebaseerde Morph‑animatie te gebruiken.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

<!-- visual-explanation:slide-transition:start -->
[![Morph‑matching eenheden weergegeven als geheel vorm, afzonderlijke woorden en afzonderlijke tekens.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph kan waar mogelijk volledige vormen, woorden of tekens overeen laten komen. Deze vakken identificeren overeenkomende eenheden in plaats van waargenomen beweging. Het voorbeeld selecteert ByWord op de tweede dia.*
<!-- visual-explanation:slide-transition:end -->

## **Overgangseffecten instellen**

Sommige overgangen bieden extra opties, zoals richting of of het effect start vanaf een zwart scherm. De beschikbare opties hangen af van het gekozen overgangs‑[Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/). Stel eerst het type in en gebruik vervolgens de juiste interface via de [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/).

Het volgende voorbeeld past een Cut‑overgang toe op de eerste dia van `input.pptx`. Het zet [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) via [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/) zodat de overgang start vanaf een zwart scherm.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**Kan ik de afspeelsnelheid van een diaovergang regelen?**

Ja. Geef de voorkeur aan [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) wanneer je een exacte effectduur in milliseconden nodig hebt. Gebruik [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) wanneer een vooraf gedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/)‑categorie — Slow, Medium of Fast — voldoende is en er geen expliciete duur is ingesteld. Deze instellingen regelen het overgangseffect onafhankelijk van de automatische voortgangs‑vertraging.

**Kan ik audio aan een overgang koppelen en laten herhalen?**

Ja. Koppel ingebedde audio aan [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/), stel [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) in op StartSound vanuit de [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/)‑enumeratie, en schakel [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/) in. De audio wordt herhaald tot het volgende geluidsevenement in de diavoorstelling.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Loop door de [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/)‑collectie van de presentatie en stel voor elke dia de overgangs‑[Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) in op dezelfde waarde. Stel eventuele timing‑ en effectopties in dezelfde lus in om het gedrag consistent te houden over alle dia’s.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Lees de [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/)‑eigenschap van de dia‑[SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/). Deze geeft een waarde uit de [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/)‑enumeratie terug; None betekent dat er geen overgangseffect is toegepast.