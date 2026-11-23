---
title: Beheer diaovergangen in presentaties in .NET
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
description: "Pas diaovergangen toe, configureer automatische dia-voortzetting, en pas Morph en andere overgangseffecten aan met Aspose.Slides voor .NET."
---
## **Overzicht**

Diaovergangen bepalen hoe dia's verschijnen tijdens een diavoorstelling. Met Aspose.Slides voor .NET kunt u voor elke dia een overgangseffect kiezen, de voortgang instellen via muisklik of timer, en opties aanpassen die specifiek zijn voor een effect. Dit artikel gebruikt C#‑voorbeelden om overgangen toe te passen, exacte overgangsduren in te stellen, diatiming te beheren en een Morph‑overgang tussen twee dia's te maken. De voorbeelden laten ook zien hoe de instellingen worden opgeslagen naar een PPTX‑bestand.

## **Diaovergang toevoegen**

Om een overgang toe te passen, laad een presentatie met de [Presentatie](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse en krijg toegang tot de [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) eigenschap van de dia. Stel de [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) in op een waarde uit de [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) enumeratie, en sla vervolgens de presentatie op.

Het volgende voorbeeld past een Cirkel‑overgang toe op de eerste dia en een Kam‑overgang op de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia's.

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

## **Wiel‑overgang**

De [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) eigenschap van [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) bepaalt het aantal radiale sectoren die de bestemmingsdia onthullen. Stel de overgang [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) van de dia in op Wheel via [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) voordat u [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) benadert als [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/).

Dit voorbeeld maakt twee identieke paar dia's: een zwarte dia gevolgd door een dia met een gouden rechthoek. De bestemmingsdia's gebruiken een aantal spaken van 1 en 8, met dezelfde [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) en een expliciete [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) van 8 000 milliseconden om het verschil goed waar te nemen.

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

Open de uitvoerpresentatie in PowerPoint en start de diavoorstelling. Ga van dia 1 naar dia 2, daarna van dia 3 naar dia 4. In de PowerPoint‑afspeelmodus toont het geverifieerde aantal spaken van 1 de dia met één klokwijzerige beweging; het geverifieerde aantal van 8 onthult deze via acht radiale sectoren tegelijk. De bestemmingsinhoud en overgangstiming zijn identiek, dus het verschil zit in het aantal onthullingssectoren.

## **Vervagen via zwart met de Reveal‑overgang**

Stel het overgangstype van de bestemmingsdia in op Reveal en gebruik vervolgens [IRevealTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/) om [ThroughBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/throughblack/) in te stellen. Het voorbeeld maakt een teal‑brondia en een koraal‑bestemmingsdia, en kloont vervolgens beide zodat u dezelfde tweeseconde‑overgang kunt vergelijken met vervaging uitgeschakeld en ingeschakeld.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var source = presentation.Slides[0];
var destination = presentation.Slides.AddClone(source);
StyleSlide(source, Color.Teal, "Source");
StyleSlide(destination, Color.Coral, "Destination");
presentation.Slides.AddClone(source);
presentation.Slides.AddClone(destination);

foreach (var index in new[] { 1, 3 })
{
    var transition = presentation.Slides[index].SlideShowTransition;
    transition.Type = TransitionType.Reveal;
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 2000;

    var reveal = (IRevealTransition)transition.Value;
    reveal.Direction = TransitionLeftRightDirectionType.Left;
    reveal.ThroughBlack = index == 3;
}

presentation.Save("reveal-transitions.pptx", SaveFormat.Pptx);

void StyleSlide(ISlide slide, Color background, string label)
{
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = background;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
    shape.TextFrame.Text = label;
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 44;
}
```

In een PowerPoint‑diavoorstelling gaat men van dia 1 naar dia 2. Teal vervaagt direct naar koraal. Vervolgens gaat men van dia 3 naar dia 4. Het scherm wordt kort donker tot bijna zwart voordat de koraalde slide verschijnt. Beide dia's behouden hun oorspronkelijke achtergrondkleuren.

De rijen hieronder tonen frames van PowerPoint met intervallen van een halve seconde. Vergelijk het middelste frame in elke rij om het effect van de instelling te zien.

![PowerPoint-afspeelmodus met ThroughBlack uitgeschakeld (boven) en ingeschakeld (onder). Alleen de onderste rij gaat via bijna zwart.](reveal-through-black.png)

## **Geavanceerde diaovergang toevoegen**

U kunt configureren hoe lang een dia op het scherm blijft en of een muisklik de diavoorstelling voortstuwt. De volgende eigenschappen regelen dit gedrag:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) stelt de kijker in staat om door te klikken met de muis.
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) schakelt automatische voortzetting in.
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) specificeert de vertraging vóór automatische voortzetting, in milliseconden.

Schakel zowel klik‑ als tijds‑voortzetting in om de kijker te laten doorgaan met een klik of te wachten op de timer. Om alleen de timer te gebruiken, stel [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) in op `false`. De vertraging bepaalt wanneer de diavoorstelling wordt voortgezet; het stelt niet de duur van het visuele overgangseffect in.

Dit voorbeeld kent verschillende effecten toe aan de eerste drie dia's en schakelt automatische voortzetting in na respectievelijk 3, 5 en 7 seconden. Muisklikken kunnen deze dia's ook voortzetten. Gebruik een `input.pptx`‑bestand met minstens drie dia's.

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

Om te controleren of tijds‑voortzetting is ingeschakeld, lees [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/). Een opgeslagen vertraging alleen geeft niet aan dat de timer actief is.

Het volgende voorbeeld opent het hierboven opgeslagen bestand, meldt elke ingeschakelde timer, en schakelt automatische voortzetting uit voor dia's met een vertraging groter dan twee seconden. Het schakelt muisklikken in voor die dia's en slaat de bijgewerkte instellingen op.

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

## **Precisie‑overgangstiming regelen**

Gebruik [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) om de exacte lengte van een overgangseffect in milliseconden op te geven. De [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) eigenschap van de dia maakt deze instellingen zichtbaar via [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/):

| Eigenschap | Doel |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Stelt de vertraging in vóór de automatische voortzetting van de dia, in milliseconden. Schakel [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) in om deze timer te activeren. |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | Selecteert een vooraf gedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium, of Fast. Het wordt gebruikt wanneer geen exacte duur is opgegeven. |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) regelt alleen het overgangseffect; het bepaalt niet hoe lang de dia zichtbaar blijft. Configureer de vertraging voor automatische voortzetting apart. Wanneer geen expliciete duur is ingesteld, bepaalt Aspose.Slides de effectduur op basis van het overgangstype en de [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) waarde.

### **Dezelfde duur toepassen op elke dia**

Voor een consistent tempo past u hetzelfde effect en exact dezelfde duur toe op elke dia. Dit voorbeeld laadt `input.pptx`, selecteert Fade uit [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/), en geeft elke overgang een duur van 750 milliseconden. Het schakelt bovendien automatische voortzetting in na 5.000 milliseconden en schakelt voortzetting via muisklik uit, waarna het resultaat als PPTX wordt opgeslagen.

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

    // Configureer automatische voortzetting onafhankelijk van de effectduur.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Verschillende duur toewijzen aan individuele dia's**

Verschillende dia's kunnen verschillende effectduren hebben. Gebruik bijvoorbeeld een korte overgang voor een titel‑dia en een langere overgang voor een sectie‑introductie. Dit voorbeeld stelt 500 milliseconden in voor de eerste dia en 1.200 milliseconden voor de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia's.

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

### **Overgangen coördineren met geanimeerde uitvoer**

Bij het voorbereiden van een [animated GIF](/slides/nl/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/nl/net/export-to-html5/), of [video](/slides/nl/net/convert-powerpoint-to-video/), stel exacte overgangsduren in vóór export zodat ze overeenkomen met het beoogde tempo. Gebruik bijvoorbeeld een fade van 600 milliseconden tussen scènes, en pas de voortzettingsvertraging van elke dia apart aan om tijd te geven voor de bijbehorende vertelling of inhoud.

Voor GIF en video stemt u de uitvoer‑frame‑rate af op de effectduur: 600 milliseconden komt overeen met 18 frames bij 30 frames per seconde. In HTML5 schakelt u geanimeerde overgangen in de exportinstellingen in. Controleer welke effecten en timingopties de gekozen exportindeling ondersteunt en bekijk een voorbeeld van de uitvoer om de synchronisatie te bevestigen.

### **Een bestaande overgangsduur uitlezen**

Lees [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) uit voordat u de overgang wijzigt om te bepalen of er een expliciete waarde is opgeslagen. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden aan. De niet‑ingestelde waarde is niet de berekende afspeelduur: Aspose.Slides gebruikt het overgangstype en de [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) om die duur te bepalen. Het instellen van een overgangstype kan een duur initialiseren, dus bekijk eerst de oorspronkelijke instellingen.

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

De Morph‑overgang animeert veranderingen tussen objecten op opeenvolgende dia's. Om een eenvoudige Morph‑effect te creëren, kloont u een dia, verplaatst of vergroot u een object op de kloon, en past u de Morph‑overgang toe op de tweede dia. Hierdoor krijgt de overgang de corresponderende objecten om te animeren tussen hun oorspronkelijke en aangepaste toestand.

Het volgende voorbeeld maakt een dia met een tekst‑rechthoek, kloont de dia, en wijzigt de positie en grootte van de rechthoek op de kloon. Vervolgens selecteert het Morph uit de [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) enumeratie voor de tweede dia. Open het opgeslagen bestand in een presentatieweergave die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

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

De [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) enumeratie bepaalt hoe Morph overeenkomsten vindt en content animeert:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) beschouwt elke vorm als een geheel object.
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door woorden te matchen waar mogelijk.
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door karakters te matchen waar mogelijk.

Stel de overgang [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) in op Morph voordat u de [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) benadert. De waarde levert vervolgens de [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/) interface, waarvan de [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) eigenschap de match‑modus selecteert.

Dit voorbeeld opent de presentatie die in de vorige sectie is gemaakt en configureert de tweede dia om woordgebaseerde Morph‑animatie te gebruiken.

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
[![Morph‑koppelingsonderdelen weergegeven als een volledige vorm, afzonderlijke woorden en afzonderlijke tekens.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph kan, waar mogelijk, hele vormen, woorden of tekens matchen. Deze vakken geven de match‑eenheden aan in plaats van de waargenomen beweging. Het voorbeeld selecteert ByWord op de tweede dia.*
<!-- visual-explanation:slide-transition:end -->

## **Overgangseffecten instellen**

Sommige overgangen bieden extra opties, zoals richting of of het effect start vanaf een zwart scherm. De beschikbare opties hangen af van het gekozen overgangs‑[Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/). Stel eerst het type in, en gebruik vervolgens de juiste interface via de [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/).

Het volgende voorbeeld past een Cut‑overgang toe op de eerste dia van `input.pptx`. Het stelt [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) in via [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/) zodat de overgang start vanaf een zwart scherm.

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

**Kan ik de afspeelsnelheid van een dia‑overgang regelen?**

Ja. Geef de voorkeur aan [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) wanneer u een exacte effectduur in milliseconden nodig hebt. Gebruik [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/), wanneer een vooraf gedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/)‑categorie—Slow, Medium of Fast—voldoende is en er geen expliciete duur is ingesteld. Deze instellingen regelen het overgangseffect onafhankelijk van de vertraging voor automatische voortzetting.

**Kan ik audio aan een overgang toevoegen en laten herhalen?**

Ja. Ken ingesloten audio toe aan [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/), stel [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) in op StartSound vanuit de [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/) enumeratie, en schakel [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/) in. Het geluid herhaalt zich totdat het volgende geluidsevenement in de diavoorstelling optreedt.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Doorloop de [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/)‑collectie van de presentatie en stel voor elke dia de overgangs‑[Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) in op dezelfde waarde. Stel eventuele timing‑ en effectopties in dezelfde lus in om het gedrag consistent te houden over alle dia's.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Lees de eigenschap [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) van de [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) van de dia. Het retourneert een waarde uit de [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) enumeratie; None betekent dat er geen overgangseffect is toegepast.