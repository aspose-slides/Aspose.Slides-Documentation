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
description: "Ontdek hoe u vormanimaties kunt maken en aanpassen in PowerPoint-presentaties met Aspose.Slides voor .NET. Val op!"
---
## **Introductie**

Animaties zijn visuele effecten die op teksten, afbeeldingen, vormen of [grafieken](/slides/nl/net/animated-charts/) toegepast kunnen worden. Ze geven leven aan presentaties of hun onderdelen. 

## **Waarom animaties gebruiken in presentaties?**

Met animaties kun je 

* de informatiestroom beheersen
* belangrijke punten benadrukken
* de interesse of deelname van je publiek vergroten
* inhoud makkelijker leesbaar, verteerbaar of verwerkbaar maken
* de aandacht van je lezers of kijkers richten op belangrijke delen in een presentatie

PowerPoint biedt veel opties en tools voor animaties en animatie‑effecten binnen de categorieën **entrance**, **exit**, **emphasis** en **motion paths**. 

## **Animaties in Aspose.Slides**

* Aspose.Slides levert de klassen en typen die je nodig hebt om met animaties te werken onder de [Aspose.Slides.Animation](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/) namespace,
* Aspose.Slides biedt meer dan **150 animatie‑effecten** via de [EffectType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effecttype) enumeratie. Deze effecten zijn in principe dezelfde (of gelijkwaardige) als die in PowerPoint.

## **Animatie toepassen op een TextBox**

Aspose.Slides for .NET maakt het mogelijk om animatie toe te passen op de tekst in een vorm. 

1. Maak een instantie van de [Presentation](http://www.aspose.com/api/net/slides/nl/aspose.slides/) klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape) toe. 
4. Voeg tekst toe aan [IAutoShape.TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/properties/textframe).
5. Haal de hoofd‑sequentie van effecten op.
6. Voeg een animatie‑effect toe aan [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape).
7. Stel de [TextAnimation.BuildType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/textanimation/properties/buildtype) eigenschap in op de waarde uit de [BuildType Enumeration](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/buildtype).
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze C#‑code laat zien hoe je het `Fade`‑effect toepast op een AutoShape en de tekstanimatie instelt op de *By 1st Level Paragraphs* waarde:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instantiëert een presentatieklasse die een presentatiebestand vertegenwoordigt.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Voegt een nieuwe AutoShape met tekst toe
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // Voegt drie alinea's toe zodat de per‑alinea opbouw iets heeft om doorheen te lopen.
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // Haalt de hoofd‑sequentie van de dia op.
    ISequence sequence = sld.Timeline.MainSequence;

    // Voegt een Fade‑animatie‑effect toe aan de vorm
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animeert de vormtekst per eerste‑niveau alinea's
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Slaat het PPTX‑bestand op schijf
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 

Naast het toepassen van animaties op tekst, kun je ook animaties toepassen op een enkel [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph). Zie [**Geanimeerde tekst**](/slides/nl/net/animated-text/).

{{% /alert %}} 

## **Animatie toepassen op een PictureFrame**

1. Maak een instantie van de [Presentation](http://www.aspose.com/api/net/slides/nl/aspose.slides/) klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe) toe of haal er een op de dia. 
5. Haal de hoofd‑sequentie van effecten op.
6. Voeg een animatie‑effect toe aan [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe).
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze C#‑code laat zien hoe je het `Fly`‑effect toepast op een picture frame:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
using (Presentation pres = new Presentation())
{
    // Laadt afbeelding die toegevoegd wordt aan de afbeeldingscollectie van de presentatie
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Voegt een picture frame toe aan de dia
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Haalt de hoofd‑sequentie van de dia op.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Voegt een Fly‑van‑links animatie‑effect toe aan het picture frame
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Slaat het PPTX‑bestand op schijf
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Animatie toepassen op een Shape**

1. Maak een instantie van de [Presentation](http://www.aspose.com/api/net/slides/nl/aspose.slides/) klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape) toe. 
4. Voeg een `Bevel` [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape) toe (wanneer dit object wordt aangeklikt, wordt de animatie afgespeeld).
5. Maak een sequentie van effecten voor de bevelvorm.
6. Maak een aangepaste `UserPath`.
7. Voeg commando’s toe om naar de `UserPath` te bewegen.
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze C#‑code laat zien hoe je het `PathFootball`‑effect (pad‑football) toepast op een vorm:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instantieert een Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Maakt het PathFootball-effect voor de bestaande vorm vanaf nul.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Voegt het PathFootball-animatie-effect toe.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Maakt een soort "knop".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Maakt een sequentie van effecten voor de knop.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Maakt een aangepast gebruikerspad. Het object wordt alleen verplaatst nadat op de knop is geklikt.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Voegt commando's toe voor verplaatsing omdat het aangemaakte pad leeg is.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Schrijft het PPTX-bestand naar de schijf
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **De animatie‑effecten ophalen die op een vorm zijn toegepast**

De onderstaande voorbeelden laten zien hoe je de `GetEffectsByShape`‑methode van de [ISequence](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/isequence/) interface gebruikt om alle animatie‑effecten die op een vorm zijn toegepast op te halen.

**Voorbeeld 1: Animatie‑effecten ophalen die op een vorm op een normale dia zijn toegepast**

Eerder heb je geleerd hoe je animatie‑effecten toevoegt aan vormen in PowerPoint‑presentaties. De volgende voorbeeldcode laat zien hoe je de effect‑toepassingen van de eerste vorm op de eerste normale dia in de presentatie `AnimExample_out.pptx` ophaalt.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Haalt de hoofd‑animatie‑sequentie van de dia op.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Haalt de eerste vorm op de eerste dia op.
    IShape shape = firstSlide.Shapes[0];

    // Haalt de animatie‑effecten op die op de vorm zijn toegepast.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Voorbeeld 2: Alle animatie‑effecten ophalen, inclusief die van plaatsaanduidingen**

Heeft een vorm op een normale dia plaatsaanduidingen die op de layout‑dia en/of master‑dia staan, en zijn er animatie‑effecten aan deze plaatsaanduidingen toegevoegd, dan worden alle effect‑toepassingen van de vorm afgespeeld tijdens de diavoorstelling, inclusief die welke van de plaatsaanduidingen geërfd zijn.

Stel, we hebben een PowerPoint‑bestand `sample.pptx` met één dia die alleen een voettekst‑vorm bevat met de tekst “Made with Aspose.Slides” en het **Random Bars**‑effect is op die vorm toegepast.

![Slide shape animation effect](slide-shape-animation.png)

Stel bovendien dat het **Split**‑effect op de voettekst‑plaatsaanduiding van de **layout**‑dia is toegepast.

![Layout shape animation effect](layout-shape-animation.png)

En tenslotte dat het **Fly In**‑effect op de voettekst‑plaatsaanduiding van de **master**‑dia is toegepast.

![Master shape animation effect](master-shape-animation.png)

De volgende voorbeeldcode laat zien hoe je de `GetBasePlaceholder`‑methode van de [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) interface gebruikt om de plaatsaanduidingen van de vorm te benaderen en de animatie‑effecten op de voettekst‑vorm op te halen, inclusief die geërfd van plaatsaanduidingen op de layout‑ en master‑dia’s.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Haal animatie‑effecten op van de vorm op de normale dia.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Haal animatie‑effecten op van de plaatsaanduiding op de layout‑dia.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Haal animatie‑effecten op van de plaatsaanduiding op de master‑dia.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Timing‑eigenschappen van animatie‑effecten wijzigen**

Aspose.Slides for .NET stelt je in staat de timing‑eigenschappen van een animatie‑effect aan te passen.

Dit is het Animation Timing‑venster en uitgebreide menu in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Dit zijn de overeenkomsten tussen PowerPoint Timing en de [Effect.Timing](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effect/properties/timing) eigenschappen:
- De PowerPoint Timing **Start**‑keuzelijst komt overeen met de [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/properties/triggertype) eigenschap. 
- De PowerPoint Timing **Duration** komt overeen met de [Effect.Timing.Duration](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/properties/duration) eigenschap. De duur van een animatie (in seconden) is de totale tijd die een animatie nodig heeft om één cyclus te voltooien. 
- De PowerPoint Timing **Delay** komt overeen met de [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/properties/triggerdelaytime) eigenschap. 
- De PowerPoint Timing **Repeat**‑keuzelijst komt overeen met deze eigenschappen: 
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatcount) eigenschap die het *aantal* keren beschrijft dat het effect wordt herhaald;
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatuntilendslide) vlag die aangeeft of het effect wordt herhaald tot het einde van de dia;
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatuntilnextclick) vlag die aangeeft of het effect wordt herhaald tot de volgende klik.
- Het PowerPoint Timing **Rewind when done playing** vakje komt overeen met de [Effect.Timing.Rewind](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/rewind/) eigenschap. 

Zo wijzig je de Effect Timing‑eigenschappen:

1. [Apply](#apply-animation-to-shape) of haal het animatie‑effect op.
2. Stel nieuwe waarden in voor de [Effect.Timing](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effect/properties/timing) eigenschappen die je nodig hebt. 
3. Sla het gewijzigde PPTX‑bestand op.

Deze C#‑code demonstreert de bewerking:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Haalt de hoofd‑sequentie van de dia op.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Haalt het eerste effect van de hoofd‑sequentie op.
    IEffect effect = sequence[0];

    // Wijzigt het TriggerType van het effect zodat het start bij klikken
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Wijzigt de duur van het effect
    effect.Timing.Duration = 3f;

    // Wijzigt de TriggerDelayTime van het effect
    effect.Timing.TriggerDelayTime = 0.5f;

    // Als de Repeat‑waarde van het effect "none" is
    if (effect.Timing.RepeatCount == 1f)
    {
        // Wijzigt de Repeat van het effect naar "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Wijzigt de Repeat van het effect naar "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Schakelt Rewind van het effect in
        effect.Timing.Rewind = true;
    
    // Slaat het PPTX‑bestand op schijf
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Geluid bij animatie‑effect**

Aspose.Slides biedt de volgende eigenschappen om geluiden in animatie‑effecten te beheren: 
- [IEffect.Sound](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Een geluid aan een animatie‑effect toevoegen**

Deze C#‑code toont hoe je een geluid aan een animatie‑effect toevoegt en het stopt wanneer het volgende effect start:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Voegt audio toe aan de audio-collectie van de presentatie
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Haalt de hoofd-sequentie van de dia op.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Haalt het eerste effect van de hoofd-sequentie op
	IEffect firstEffect = sequence[0];

	// Controleert het effect op "Geen geluid"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Voegt geluid toe aan het eerste effect
		firstEffect.Sound = effectSound;
	}

	// Haalt de eerste interactieve sequentie van de dia op.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Zet de vlag "Stop previous sound" voor het effect
	interactiveSequence[0].StopPreviousSound = true;

	// Schrijft het PPTX-bestand naar de schijf
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Een geluid uit een animatie‑effect extraheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
2. Verkrijg een referentie naar een dia via de index. 
3. Haal de hoofd‑sequentie van effecten op. 
4. Extraheer het [Sound](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effect/sound/) dat in elk animatie‑effect is ingebed. 

Deze C#‑code laat zien hoe je het geluid dat in een animatie‑effect is ingebed, extraheert:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Haalt de hoofd‑sequentie van de dia op.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Extraheert het effectgeluid in een byte‑array
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **After Animation**

Aspose.Slides for .NET maakt het mogelijk de **After animation** eigenschap van een animatie‑effect te wijzigen.

Dit is het Animation Effect‑venster en uitgebreide menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

De PowerPoint Effect **After animation** keuzelijst komt overeen met deze eigenschappen: 

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/afteranimationtype/) eigenschap die het type After animation beschrijft:
  * PowerPoint **More Colors** correspondeert met het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** correspondeert met het type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/afteranimationtype/) (standaard After animation type);
  * PowerPoint **Hide After Animation** correspondeert met het type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** correspondeert met het type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/afteranimationtype/);
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/afteranimationcolor/) eigenschap die een color‑formaat voor After animation definieert. Deze eigenschap werkt samen met het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/afteranimationtype/). Als je het type verandert, wordt de After animation‑kleur gewist.

Deze C#‑code laat zien hoe je een After animation‑effect wijzigt:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Haalt het eerste effect van de hoofd-sequentie op
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Wijzigt het after animation type naar Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Stelt de after animation dim kleur in
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Schrijft het PPTX bestand naar de schijf
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Tekst animeren**

Aspose.Slides biedt de volgende eigenschappen om met het *Animate text*‑blok van een animatie‑effect te werken:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/animatetexttype/) die het type animatietekst van het effect beschrijft. De tekst van de vorm kan geanimeerd worden:
  - In één keer ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/animatetexttype/) type)
  - Per woord ([AnimateTextType.ByWord](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/animatetexttype/) type)
  - Per letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/animatetexttype/) type)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/delaybetweentextparts/) stelt een vertraging in tussen de geanimeerde tekstonderdelen (woorden of letters). Een positieve waarde geeft een percentage van de effectduur aan. Een negatieve waarde geeft de vertraging in seconden aan.

Zo kun je de Effect Animate text‑eigenschappen wijzigen:

1. [Apply](#apply-animation-to-shape) of haal het animatie‑effect op.
2. Stel de [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itextanimation/buildtype/) eigenschap in op de waarde [BuildType.AsOneObject](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/buildtype/) om de *By Paragraphs*‑animatiemodus uit te schakelen.
3. Stel nieuwe waarden in voor de [IEffect.AnimateTextType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/animatetexttype/) en [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/delaybetweentextparts/) eigenschappen.
4. Sla het gewijzigde PPTX‑bestand op.

Deze C#‑code demonstreert de bewerking:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Haalt het eerste effect van de hoofd‑sequentie op
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Wijzigt het Text‑animatietype van het effect naar "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Wijzigt het Animate text‑type van het effect naar "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Stelt de vertraging tussen woorden in op 20% van de effectduur
    firstEffect.DelayBetweenTextParts = 20f;

    // Schrijft het PPTX‑bestand naar de schijf
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Hoe kan ik ervoor zorgen dat animaties behouden blijven bij het publiceren van de presentatie naar het web?

[Export to HTML5](/slides/nl/net/export-to-html5/) en schakel de [options](https://reference.aspose.com/slides/nl/net/aspose.slides.export/html5options/) in die verantwoordelijk zijn voor [shape](https://reference.aspose.com/slides/nl/net/aspose.slides.export/html5options/animateshapes/) en [transition](https://reference.aspose.com/slides/nl/net/aspose.slides.export/html5options/animatetransitions/) animaties. Standaard HTML speelt diavanimaties niet af, terwijl HTML5 dat wel doet.

### Hoe beïnvloedt het wijzigen van de z‑order (laagvolgorde) van vormen de animatie?

Animatie‑ en tekenvolgorde zijn onafhankelijk: een effect bepaalt de timing en het type verschijnen/verdwijnen, terwijl [z-order](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/zorderposition/) bepaalt wat wat bedekt. Het zichtbare resultaat wordt bepaald door hun combinatie. (Dit is het algemene gedrag in PowerPoint; het Aspose.Slides‑effect‑en‑vormmodel volgt dezelfde logica.)

### Zijn er beperkingen bij het converteren van animaties naar video voor bepaalde effecten?

In het algemeen worden [animaties ondersteund](/slides/nl/net/convert-powerpoint-to-video/), maar zeldzame gevallen of specifieke effecten kunnen anders gerenderd worden. Het wordt aangeraden de gebruikte effecten en de bibliotheekversie te testen.