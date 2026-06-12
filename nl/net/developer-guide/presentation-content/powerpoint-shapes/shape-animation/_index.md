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
## **Inleiding**

Animaties zijn visuele effecten die kunnen worden toegepast op tekst, afbeeldingen, vormen of [grafieken](/slides/nl/net/animated-charts/). Ze geven leven aan presentaties of hun onderdelen. 

## **Waarom animaties gebruiken in presentaties?**

Met animaties kun je  

* de informatiestroom beheersen  
* belangrijke punten benadrukken  
* de interesse of deelname van je publiek vergroten  
* inhoud makkelijker leesbaar, assimileerbaar of verwerkbaar maken  
* de aandacht van je lezers of kijkers vestigen op belangrijke delen in een presentatie  

PowerPoint biedt veel opties en hulpmiddelen voor animaties en animatie‑effecten binnen de categorieën **invoer**, **verwijdering**, **accent** en **bewegingspaden**. 

## **Animaties in Aspose.Slides**

* Aspose.Slides levert de klassen en types die je nodig hebt om met animaties te werken onder de namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/) ,  
* Aspose.Slides biedt meer dan **150 animatie‑effecten** via de enumeratie [EffectType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effecttype). Deze effecten zijn in wezen dezelfde (of equivalente) effecten die in PowerPoint worden gebruikt.  

## **Animatie toepassen op een TextBox**

Aspose.Slides voor .NET maakt het mogelijk om een animatie toe te passen op de tekst in een vorm. 

1. Maak een instantie van de [Presentation](http://www.aspose.com/api/net/slides/nl/aspose.slides/)‑klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape) toe.  
4. Voeg tekst toe aan [IAutoShape.TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/properties/textframe).  
5. Haal de hoofdreeks van effecten op.  
6. Voeg een animatie‑effect toe aan [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape).  
7. Stel de eigenschap [TextAnimation.BuildType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/textanimation/properties/buildtype) in op de waarde uit de [BuildType‑enumeratie](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/buildtype).  
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.  

Deze C#‑code laat zien hoe je het `Fade`‑effect toepast op een AutoShape en de tekstaniminatie instelt op de *By 1st Level Paragraphs*‑waarde:

```c#
// Maakt een presentatieklasse aan die een presentatiedocument vertegenwoordigt.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Voegt een nieuwe AutoShape toe met tekst
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // Haal de hoofdreeks van de dia op.
    ISequence sequence = sld.Timeline.MainSequence;

    // Voegt het Fade‑animatie‑effect toe aan de vorm
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animeert de vormtekst per paragrafen van het eerste niveau
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Sla het PPTX‑bestand op schijf
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

Naast het toepassen van animaties op tekst, kun je ook animaties toepassen op een enkel [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph). Zie [**Animated Text**](/slides/nl/net/animated-text/).  

{{% /alert %}} 

## **Animatie toepassen op een PictureFrame**

1. Maak een instantie van de [Presentation](http://www.aspose.com/api/net/slides/nl/aspose.slides/)‑klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Voeg een [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe) toe aan of haal deze op van de dia.  
5. Haal de hoofdreeks van effecten op.  
6. Voeg een animatie‑effect toe aan [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe).  
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.  

Deze C#‑code laat zien hoe je het `Fly`‑effect toepast op een picture frame:

```c#
// Maakt een presentatie‑klasse aan die een presentatiedocument vertegenwoordigt.
using (Presentation pres = new Presentation())
{
    // Laad afbeelding die aan de afbeeldingcollectie van de presentatie wordt toegevoegd
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Voegt een picture frame toe aan de dia
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Haalt de hoofdreeks van de dia op.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Voegt het Fly‑from‑Left‑animatie‑effect toe aan picture frame
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Sla het PPTX‑bestand op schijf
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Animatie toepassen op een Shape**

1. Maak een instantie van de [Presentation](http://www.aspose.com/api/net/slides/nl/aspose.slides/)‑klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape) toe.  
4. Voeg een `Bevel` [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape) toe (wanneer op dit object wordt geklikt, wordt de animatie afgespeeld).  
5. Maak een reeks effecten voor de bevel‑vorm.  
6. Maak een aangepaste `UserPath`.  
7. Voeg opdrachten toe om naar de `UserPath` te bewegen.  
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.  

Deze C#‑code laat zien hoe je het `PathFootball`‑effect toepast op een vorm:

```c#
 // Instantieert een Presentation-klasse die een presentatiedocument vertegenwoordigt.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Maakt het PathFootball-effect voor een bestaande vorm vanaf nul.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Voegt het PathFootball-animatie-effect toe.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Creëert een soort "knop".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Maakt een reeks effecten voor de knop.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Creëert een aangepast gebruikerspad. Ons object wordt pas verplaatst nadat de knop is aangeklikt.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Voegt verplaatsingsopdrachten toe omdat het aangemaakte pad leeg is.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Schrijft het PPTX-bestand naar schijf
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **De animatie‑effecten op een vorm ophalen**

De volgende voorbeelden tonen hoe je de methode `GetEffectsByShape` van de interface [ISequence](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/isequence/) gebruikt om alle animatie‑effecten op een vorm op te halen.  

**Voorbeeld 1: Animatie‑effecten ophalen die op een vorm zijn toegepast op een normale dia**  

Eerder leerde je hoe je animatie‑effecten toevoegt aan vormen in PowerPoint‑presentaties. De onderstaande voorbeeldcode laat zien hoe je de effecten ophaalt die op de eerste vorm van de eerste normale dia in de presentatie `AnimExample_out.pptx` zijn toegepast.

```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Haalt de hoofdanimatierij van de dia op.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Haalt de eerste vorm op van de eerste dia.
    IShape shape = firstSlide.Shapes[0];

    // Haalt de animatie-effecten op die op de vorm zijn toegepast.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Voorbeeld 2: Alle animatie‑effecten ophalen, inclusief die welke zijn geërfd van placeholders**  

Als een vorm op een normale dia placeholders heeft die zich op de lay‑out‑dia en/of master‑dia bevinden, en er zijn animatie‑effecten aan deze placeholders toegevoegd, dan worden alle effecten van de vorm afgespeeld tijdens de diavoorstelling, inclusief de geërfde effecten.  

Stel, we hebben een PowerPoint‑presentatie `sample.pptx` met één dia die alleen een voettekst‑vorm bevat met de tekst “Made with Aspose.Slides” en het **Random Bars**‑effect is op die vorm toegepast.  

![Slide shape animation effect](slide-shape-animation.png)  

Stel bovendien dat het **Split**‑effect op de voettekst‑placeholder van de **lay‑out**‑dia is toegepast.  

![Layout shape animation effect](layout-shape-animation.png)  

En tenslotte is het **Fly In**‑effect op de voettekst‑placeholder van de **master**‑dia toegepast.  

![Master shape animation effect](master-shape-animation.png)  

De onderstaande voorbeeldcode toont hoe je de methode `GetBasePlaceholder` van de interface [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) gebruikt om toegang te krijgen tot de shape‑placeholders en de animatie‑effecten op de voettekst‑vorm op te halen, inclusief de geërfde effecten van de placeholders op de lay‑out‑ en master‑dia’s.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Haal de animatie‑effecten van de vorm op de normale dia op.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Haal de animatie‑effecten van de placeholder op de lay‑outdia op.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Haal de animatie‑effecten van de placeholder op de master‑dia op.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```
```cs
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

## **Timing‑eigenschappen van animatie‑effecten aanpassen**

Aspose.Slides voor .NET stelt je in staat de timing‑eigenschappen van een animatie‑effect te wijzigen.  

Dit is het Animation Timing‑paneel en het uitgebreide menu in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Dit zijn de overeenkomsten tussen PowerPoint‑Timing en de eigenschappen van [Effect.Timing](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effect/properties/timing):  
- De vervolgkeuzelijst **Start** in PowerPoint‑Timing komt overeen met de eigenschap [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/properties/triggertype).  
- **Duration** in PowerPoint‑Timing komt overeen met de eigenschap [Effect.Timing.Duration](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/properties/duration). De duur van een animatie (in seconden) is de totale tijd die de animatie nodig heeft om één cyclus te voltooien.  
- **Delay** in PowerPoint‑Timing komt overeen met de eigenschap [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/properties/triggerdelaytime).  
- De vervolgkeuzelijst **Repeat** in PowerPoint‑Timing komt overeen met de volgende eigenschappen:  
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatcount) – geeft het *aantal* keren aan dat het effect wordt herhaald;  
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatuntilendslide) – geeft aan of het effect wordt herhaald tot het einde van de dia;  
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatuntilnextclick) – geeft aan of het effect wordt herhaald tot de volgende klik.  
- Het selectievakje **Rewind when done playing** in PowerPoint‑Timing komt overeen met de eigenschap [Effect.Timing.Rewind](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/rewind/).  

Zo wijzig je de Effect‑Timing‑eigenschappen:  

1. [Pas](#apply-animation-to-shape) het animatie‑effect toe of haal het op.  
2. Stel nieuwe waarden in voor de [Effect.Timing](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effect/properties/timing)‑eigenschappen die je nodig hebt.  
3. Sla het aangepaste PPTX‑bestand op.  

Deze C#‑code demonstreert de bewerking:

```c#
// Instantieert een presentatie‑klasse die een presentatiedocument vertegenwoordigt.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Haalt de hoofdreeks van de dia op.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Haalt het eerste effect van de hoofdreeks op.
    IEffect effect = sequence[0];

    // Wijzigt het TriggerType van het effect zodat het start bij een klik
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Wijzigt de duur van het effect
    effect.Timing.Duration = 3f;

    // Wijzigt de TriggerDelayTime van het effect
    effect.Timing.TriggerDelayTime = 0.5f;

    // Als de Repeat‑waarde van het effect "none" is
    if (effect.Timing.RepeatCount == 1f)
    {
        // Wijzigt het Repeat‑attribuut van het effect naar "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Wijzigt het Repeat‑attribuut van het effect naar "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Schakelt het Rewind‑effect in
        effect.Timing.Rewind = true;
    
    // Slaat het PPTX‑bestand op schijf
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Geluid van animatie‑effect**

Aspose.Slides biedt de volgende eigenschappen om met geluiden in animatie‑effecten te werken:  
- [IEffect.Sound](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effect/sound/)  
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effect/stopprevioussound/)  

### **Geluid aan een animatie‑effect toevoegen**

Deze C#‑code toont hoe je een geluid aan een animatie‑effect toevoegt en stopt wanneer het volgende effect start:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Voegt audio toe aan de audio-collectie van de presentatie
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Haalt de hoofdreeks van de dia op.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Haalt het eerste effect van de hoofdreeks op
	IEffect firstEffect = sequence[0];

	// Controleert of het effect \"No Sound\" is
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Voegt geluid toe aan het eerste effect
		firstEffect.Sound = effectSound;
	}

	// Haalt de eerste interactieve reeks van de dia op.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Stelt de vlag \"Stop previous sound\" van het effect in
	interactiveSequence[0].StopPreviousSound = true;

	// Schrijft het PPTX-bestand naar schijf
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Geluid uit een animatie‑effect extraheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Haal de hoofdreeks van effecten op.  
4. Extraheer het [Sound](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effect/sound/) dat in elk animatie‑effect is ingebed.  

Deze C#‑code toont hoe je het ingebedde geluid uit een animatie‑effect extraheert:

```c#
// Instantieert een presentatie‑klasse die een presentatiedocument vertegenwoordigt.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Haalt de hoofdreeks van de dia op.
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

Aspose.Slides voor .NET maakt het mogelijk de **After animation**‑eigenschap van een animatie‑effect te wijzigen.  

Dit is het Animation Effect‑paneel en het uitgebreide menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

De vervolgkeuzelijst **After animation** in PowerPoint komt overeen met de volgende eigenschappen:  

- De eigenschap [IEffect.AfterAnimationType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/afteranimationtype/) beschrijft het type after‑animation:  
  * **More Colors** in PowerPoint komt overeen met het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/afteranimationtype/) ;  
  * **Don't Dim** komt overeen met [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/afteranimationtype/) (standaard after‑animation type);  
  * **Hide After Animation** komt overeen met [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/afteranimationtype/) ;  
  * **Hide on Next Mouse Click** komt overeen met [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/afteranimationtype/) ;  
- De eigenschap [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/afteranimationcolor/) definieert een kleurformaat voor after‑animation. Deze eigenschap werkt in combinatie met het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/afteranimationtype/). Als je het type wijzigt, wordt de after‑animation‑kleur gewist.  

Deze C#‑code laat zien hoe je een after‑animation‑effect wijzigt:

```c#
// Instantieert een presentatie‑klasse die een presentatiedocument vertegenwoordigt
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Haalt het eerste effect van de hoofdreeks op
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Wijzigt het after‑animation‑type naar Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Stelt de after‑animation dim‑kleur in
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Schrijft het PPTX‑bestand naar schijf
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Tekst animeren**

Aspose.Slides biedt de volgende eigenschappen om met het *Animate text*‑blok van een animatie‑effect te werken:  

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/animatetexttype/) beschrijft het type tekstaniminatie van het effect. De tekst van een vorm kan worden geanimeerd:  
  - Alles tegelijk ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/animatetexttype/) )  
  - Per woord ([AnimateTextType.ByWord](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/animatetexttype/) )  
  - Per letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/animatetexttype/) )  
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/delaybetweentextparts/) stelt een vertraging in tussen de geanimeerde tekstdelen (woorden of letters). Een positieve waarde geeft een percentage van de effectduur aan; een negatieve waarde geeft de vertraging in seconden aan.  

Zo kun je de eigenschappen van Effect Animate text aanpassen:  

1. [Pas](#apply-animation-to-shape) het animatie‑effect toe of haal het op.  
2. Stel de eigenschap [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itextanimation/buildtype/) in op de waarde [BuildType.AsOneObject](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/buildtype/) om de *By Paragraphs*‑animatiemodus uit te schakelen.  
3. Stel nieuwe waarden in voor de eigenschappen [IEffect.AnimateTextType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/animatetexttype/) en [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/delaybetweentextparts/).  
4. Sla het aangepaste PPTX‑bestand op.  

Deze C#‑code demonstreert de bewerking:

```c#
// Instantieert een presentatie‑klasse die een presentatiedocument vertegenwoordigt.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Haalt het eerste effect van de hoofdreeks op
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Wijzigt het effect Tekstanimatie‑type naar "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Wijzigt het effect Animeren‑tekst‑type naar "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Stelt de vertraging tussen woorden in op 20% van de effectduur
    firstEffect.DelayBetweenTextParts = 20f;

    // Schrijft het PPTX‑bestand naar schijf
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Hoe kan ik ervoor zorgen dat animaties behouden blijven bij het publiceren van de presentatie op het web?**  

[Export to HTML5](/slides/nl/net/export-to-html5/) en schakel de [opties](https://reference.aspose.com/slides/nl/net/aspose.slides.export/html5options/) in die verantwoordelijk zijn voor animaties van [shapes](https://reference.aspose.com/slides/nl/net/aspose.slides.export/html5options/animateshapes/) en [transitions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/html5options/animatetransitions/). Eenvoudige HTML speelt geen dia‑animaties af, terwijl HTML5 dat wel doet.  

**Hoe beïnvloedt het wijzigen van de z‑order (laagvolgorde) van vormen de animatie?**  

Animatie‑ en tekenvolgorde zijn onafhankelijk: een effect bepaalt wanneer en hoe iets verschijnt of verdwijnt, terwijl de [z‑order](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/zorderposition/) bepaalt wat wat bedekt. Het zichtbare resultaat wordt bepaald door hun combinatie. (Dit is het algemene gedrag van PowerPoint; het model van Aspose.Slides voor effecten en vormen volgt dezelfde logica.)  

**Zijn er beperkingen bij het converteren van animaties naar video voor bepaalde effecten?**  

In het algemeen worden [animaties ondersteund](/slides/nl/net/convert-powerpoint-to-video/), maar zeldzame gevallen of specifieke effecten kunnen anders worden gerenderd. Het wordt aangeraden de gebruikte effecten en de versie van de bibliotheek te testen.