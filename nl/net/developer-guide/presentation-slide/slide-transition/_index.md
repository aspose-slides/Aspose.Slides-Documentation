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
description: "Pas diaovergangen toe, configureer automatische dia-voortzetting en pas Morph- en andere overgangseffecten aan met Aspose.Slides voor .NET."
---
## **Overzicht**

Diaovergangen bepalen hoe dia's verschijnen tijdens een diavoorstelling. Met Aspose.Slides for .NET kun je voor elke dia een overgangseffect kiezen, de voortgang per muisklik of timer configureren, en opties die specifiek zijn voor een effect aanpassen. Dit artikel gebruikt C#‑voorbeelden om overgangen toe te passen, exacte overgangsduren in te stellen, diatiming te beheren en een Morph‑overgang tussen twee dia's te creëren. De voorbeelden laten ook zien hoe je de instellingen opslaat in een PPTX‑bestand.

## **Diaovergang toevoegen**

Om een overgang toe te passen, laad je een presentatie met de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse en krijg je toegang tot de [SlideShowTransition](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/slideshowtransition/)‑eigenschap van de dia. Stel de [Type](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/type/) in op een waarde uit de [TransitionType](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/transitiontype/)‑enumeratie en sla vervolgens de presentatie op.

Het volgende voorbeeld past een Circle‑overgang toe op de eerste dia en een Comb‑overgang op de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia's.

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

## **Geavanceerde diaovergang toevoegen**

Je kunt configureren hoe lang een dia op het scherm blijft en of een muisklik de diavoorstelling voortzet. De volgende eigenschappen regelen dit gedrag:

- [AdvanceOnClick](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/advanceonclick/) stelt de kijker in staat om door te gaan met een muisklik.
- [AdvanceAfter](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/advanceafter/) schakelt automatische voortzetting in.
- [AdvanceAfterTime](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/advanceaftertime/) geeft de vertraging vóór automatische voortzetting op, in milliseconden.

Schakel zowel klik‑ als tijdsgebaseerde voortzetting in zodat de kijker kan doorgaan met een klik of wachten op de timer. Gebruik alleen de timer door [AdvanceOnClick](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/advanceonclick/) op `false` te zetten. De vertraging bepaalt wanneer de diavoorstelling verdergaat; hij stelt de duur van het visuele overgangseffect niet in.

Dit voorbeeld kent verschillende effecten toe aan de eerste drie dia's en schakelt automatische voortzetting in na respectievelijk 3, 5 en 7 seconden. Ook muisklikken kunnen deze dia's voortzetten. Gebruik een `input.pptx`‑bestand met minstens drie dia's.

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

Om te controleren of tijdsgebaseerde voortzetting is ingeschakeld, lees je [AdvanceAfter](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/advanceafter/). Een opgeslagen vertraging alleen duidt niet aan dat de timer actief is.

Het volgende voorbeeld opent het hierboven opgeslagen bestand, meldt elke ingestelde timer en schakelt automatische voortzetting uit voor dia's met een vertraging groter dan twee seconden. Het schakelt muisklikken voor die dia's in en slaat de bijgewerkte instellingen op.

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

Gebruik [Duration](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/duration/) om de exacte lengte van een overgangseffect in milliseconden op te geven. De [SlideShowTransition](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/slideshowtransition/)‑eigenschap van de dia maakt deze instellingen toegankelijk via [ISlideShowTransition](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/):

| Eigenschap | Doel |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/duration/) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Stelt de vertraging vóór automatische voortzetting van de dia in, in milliseconden. Schakel [AdvanceAfter](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/advanceafter/) in om deze timer te activeren. |
| [Speed](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/speed/) | Selecteert een vooraf gedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium of Fast. Wordt gebruikt wanneer geen exacte duur is opgegeven. |

[Duration](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/duration/) regelt alleen het overgangseffect; hij bepaalt niet hoe lang de dia zichtbaar blijft. Configureer de vertraging voor automatische voortzetting apart. Wanneer geen expliciete duur is ingesteld, bepaalt Aspose.Slides de effectduur op basis van het overgangstype en de [Speed](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/speed/)‑waarde.

### **Dezelfde duur voor elke dia toepassen**

Voor een gelijkmatig tempo pas je hetzelfde effect en dezelfde exacte duur toe op elke dia. Dit voorbeeld laadt `input.pptx`, selecteert Fade uit [TransitionType](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/transitiontype/) en geeft elke overgang een duur van 750 milliseconden. Het schakelt apart automatische voortzetting in na 5.000 milliseconden en schakelt voortzetting per muisklik uit, waarna het resultaat als PPTX wordt opgeslagen.

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

### **Verschillende duur per individuele dia**

Verschillende dia's kunnen verschillende overgangsduren gebruiken. Bijvoorbeeld een korte overgang voor een titel-dia en een langere overgang voor een sectie‑introductie. Dit voorbeeld stelt 500 milliseconden in voor de eerste dia en 1.200 milliseconden voor de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia's.

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

### **Overgangen afstemmen op geanimeerde uitvoer**

Wanneer je een [animated GIF](/slides/nl/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/nl/net/export-to-html5/) of [video](/slides/nl/net/convert-powerpoint-to-video/) voorbereidt, stel dan exacte overgangsduren in vóór export zodat het tempo overeenkomt met de beoogde weergave. Bijvoorbeeld, gebruik een fade van 600 milliseconden tussen scènes en pas elke dia‑vervolgvertraging apart aan om tijd te geven aan de bijbehorende voice‑over of inhoud.

Voor GIF‑ en video‑output moet je het aantal frames per seconde afstemmen op de effectduur: 600 milliseconden komt overeen met 18 frames bij 30 fps. In HTML5 schakel je geanimeerde overgangen in de exportinstellingen in. Controleer de ondersteunde effecten en timingopties van het gekozen exportformaat en bekijk een voorbeeld om de synchronisatie te bevestigen.

### **Bestaande overgangsduur uitlezen**

Lees [Duration](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/duration/) uit voordat je de overgang aanpast om te bepalen of er een expliciete waarde is opgeslagen. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden weer. De niet‑ingestelde waarde is niet de berekende afspeelduur: Aspose.Slides bepaalt die duur aan de hand van het overgangstype en [Speed](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/speed/). Het instellen van een overgangstype kan een duur initialiseren, dus inspecteer eerst de oorspronkelijke instellingen.

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

De Morph‑overgang animeert veranderingen tussen objecten op opeenvolgende dia's. Om een eenvoudige Morph‑effect te maken, kloon je een dia, verplaats of wijzig je de grootte van een object op de kloon en pas je de Morph‑overgang toe op de tweede dia. Hierdoor krijgen de corresponderende objecten een animatie tussen hun oorspronkelijke en gewijzigde toestand.

Het volgende voorbeeld maakt een dia met een tekst‑rechthoek, kloont de dia en wijzigt de positie en grootte van de rechthoek op de kloon. Vervolgens selecteert het Morph uit de [TransitionType](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/transitiontype/)‑enumeratie voor de tweede dia. Open het opgeslagen bestand in een presentatie‑viewer die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

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

De [TransitionMorphType](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/transitionmorphtype/)‑enumeratie bepaalt hoe Morph overeenkomt en animeert:

- [ByObject](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/transitionmorphtype/) behandelt elke vorm als één geheel.
- [ByWord](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door woorden waar mogelijk te matchen.
- [ByChar](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door tekens waar mogelijk te matchen.

Stel de overgangs‑[Type](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/type/) in op Morph voordat je toegang krijgt tot de [Value](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/value/). De waarde levert vervolgens de [IMorphTransition](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/imorphtransition/)‑interface, waarvan de [MorphType](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/imorphtransition/morphtype/)‑eigenschap de match‑modus selecteert.

Dit voorbeeld opent de presentatie die in de vorige sectie is aangemaakt en configureert de tweede dia om woord‑gebaseerde Morph‑animatie te gebruiken.

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

## **Overgangseffecten instellen**

Sommige overgangen bieden extra opties, zoals richting of of het effect start vanaf een zwart scherm. De beschikbare opties hangen af van het geselecteerde overgangs‑[Type](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/type/). Stel eerst het type in en gebruik vervolgens de juiste interface via zijn [Value](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/value/).

Het volgende voorbeeld past een Cut‑overgang toe op de eerste dia van `input.pptx`. Het stelt [FromBlack](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) in via [IOptionalBlackTransition](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/ioptionalblacktransition/) zodat de overgang start vanaf een zwart scherm.

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

Ja. Geef de voorkeur aan [Duration](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/duration/) wanneer je een exacte effectduur in milliseconden nodig hebt. Gebruik [Speed](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/slideshowtransition/speed/) wanneer een vooraf gedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/transitionspeed/)‑categorie — Slow, Medium of Fast — voldoende is en er geen expliciete duur is ingesteld. Deze instellingen regelen het overgangseffect onafhankelijk van de vertraging voor automatische voortzetting.

**Kan ik audio aan een overgang koppelen en laten loopen?**

Ja. Wijs ingebedde audio toe aan [Sound](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/sound/), stel [SoundMode](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/soundmode/) in op StartSound vanuit de [TransitionSoundMode](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/transitionsoundmode/)‑enumeratie, en schakel [SoundLoop](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/soundloop/) in. De audio loopt tot het volgende geluidsonderdeel in de diavoorstelling.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Loop door de [Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slides/nl/)‑collectie van de presentatie en stel voor elke dia de overgangs‑[Type](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/type/) in op dezelfde waarde. Stel eventuele timing‑ en effectopties in dezelfde lus in om het gedrag consistent te houden over alle dia's.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Lees de [Type](https://reference.aspose.com/slides/nl/net/aspose.slides/islideshowtransition/type/)‑eigenschap van de dia‑[SlideShowTransition](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/slideshowtransition/). Deze retourneert een waarde uit de [TransitionType](https://reference.aspose.com/slides/nl/net/aspose.slides.slideshow/transitiontype/)‑enumeratie; None betekent dat er geen overgangseffect is toegepast.