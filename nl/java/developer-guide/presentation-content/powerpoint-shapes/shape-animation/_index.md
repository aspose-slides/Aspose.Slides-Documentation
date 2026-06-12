---
title: Toepassen van vormanimaties in presentaties met Java
linktitle: Vormanimatie
type: docs
weight: 60
url: /nl/java/shape-animation/
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
- Java
- Aspose.Slides
description: "Ontdek hoe u vormanimaties kunt maken en aanpassen in PowerPoint‑presentaties met Aspose.Slides voor Java. Val op!"
---
## **Introductie**

Animaties zijn visuele effecten die kunnen worden toegepast op teksten, afbeeldingen, vormen of [grafieken](https://docs.aspose.com/slides/nl/java/animated-charts/). Ze geven leven aan presentaties of hun onderdelen. 

## **Waarom animaties gebruiken in presentaties?**

Door animaties te gebruiken kun je  

* de stroom van informatie beheersen  
* belangrijke punten benadrukken  
* de interesse of deelname van uw publiek vergroten  
* inhoud gemakkelijker leesbaar, assimileerbaar of verwerkbaar maken  
* de aandacht van uw lezers of kijkers vestigen op belangrijke delen in een presentatie  

PowerPoint biedt vele opties en tools voor animaties en animatie‑effecten binnen de categorieën **entrance**, **exit**, **emphasis** en **motion paths**. 

## **Animaties in Aspose.Slides**

* Aspose.Slides levert de klassen en typen die u nodig hebt om met animaties te werken onder de `Aspose.Slides.Animation` namespace,  
* Aspose.Slides biedt meer dan **150 animatie‑effecten** via de [EffectType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effecttype)‑enumeratie. Deze effecten zijn in wezen dezelfde (of gelijkwaardige) effecten die in PowerPoint worden gebruikt.  

## **Animatie toepassen op een tekstvak**

Aspose.Slides for Java maakt het mogelijk om animatie toe te passen op de tekst in een vorm. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape) toe.  
4. Voeg tekst toe aan [IAutoShape.TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. Haal de hoofdreeks van effecten op.  
6. Voeg een animatie‑effect toe aan [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape).  
7. Stel de `TextAnimation.BuildType` eigenschap in op de waarde uit de `BuildType`‑enumeratie.  
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.  

Deze Java‑code laat zien hoe u het `Fade`‑effect toepast op een AutoShape en de tekstanimatie instelt op de waarde *By 1st Level Paragraphs*:

```java
// Instantieert een presentatieklasse die een presentatiedocument vertegenwoordigt.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Voegt een nieuwe AutoShape met tekst toe.
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Haalt de hoofdreeks van de dia op.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Voegt Fade-animatie-effect toe aan de vorm.
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animeert de vormtekst per paragrafen van het eerste niveau.
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Slaat het PPTX-bestand op naar schijf.
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Naast het toepassen van animaties op tekst, kunt u ook animaties toepassen op een enkele [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph). Zie [**Geanimeerde tekst**](/slides/nl/java/animated-text/).

{{% /alert %}} 

## **Animatie toepassen op een PictureFrame**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Voeg een [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe) toe aan of haal er een op de dia.  
4. Haal de hoofdreeks van effecten op.  
5. Voeg een animatie‑effect toe aan [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe).  
6. Schrijf de presentatie naar schijf als een PPTX‑bestand.  

Deze Java‑code laat zien hoe u het `Fly`‑effect toepast op een picture frame:

```java
// Instantieert een presentatieklasse die een presentatiedocument vertegenwoordigt.
Presentation pres = new Presentation();
try {
    // Laadt afbeelding die wordt toegevoegd aan de afbeeldingscollectie van de presentatie
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Voegt een afbeeldingsframe toe aan de dia
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Haalt de hoofdreeks van de dia op.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Voegt Fly from Left animatie‑effect toe aan het afbeeldingsframe
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Slaat het PPTX-bestand op naar schijf
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animatie toepassen op een vorm**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape) toe.  
4. Voeg een `Bevel` [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape) toe (wanneer dit object wordt aangeklikt, wordt de animatie afgespeeld).  
5. Maak een reeks effecten aan op de bevel‑vorm.  
6. Maak een aangepaste `UserPath`.  
7. Voeg opdrachten toe voor het bewegen naar de `UserPath`.  
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.  

Deze Java‑code laat zien hoe u het `PathFootball`‑effect toepast op een vorm:

```java
// Instantieer een Presentation-klasse die een PPTX-bestand vertegenwoordigt.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Creëert het PathFootball-effect voor een bestaande vorm vanaf nul.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Voegt het PathFootBall-animatie-effect toe
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Creëert een soort "knop".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Creëert een reeks effecten voor deze knop.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Creëert een aangepaste gebruikerspad. Ons object wordt pas verplaatst nadat de knop is aangeklikt.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Voegt opdrachten toe voor verplaatsing omdat het aangemaakte pad leeg is.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Schrijft het PPTX‑bestand naar schijf
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animatie‑effecten ophalen die op een vorm zijn toegepast**

De volgende voorbeelden laten zien hoe u de `getEffectsByShape`‑methode van de [ISequence](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isequence/) interface gebruikt om alle animatie‑effecten op te halen die op een vorm zijn toegepast.  

**Voorbeeld 1: Animatie‑effecten ophalen die op een vorm op een normale dia zijn toegepast**  

Eerder heeft u geleerd hoe u animatie‑effecten aan vormen in PowerPoint‑presentaties toevoegt. De volgende voorbeeldcode laat zien hoe u de effect‑toepassingen op de eerste vorm van de eerste normale dia in de presentatie `AnimExample_out.pptx` ophaalt.

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Haalt de hoofdanimatiesequentie van de dia op.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Haalt de eerste vorm op de eerste dia op.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Haalt de animatie-effecten op die op de vorm zijn toegepast.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Voorbeeld 2: Alle animatie‑effecten ophalen, inclusief die van placeholders**  

Als een vorm op een normale dia placeholders heeft die op de layout‑dia en/of master‑dia staan, en er animatie‑effecten aan deze placeholders zijn toegevoegd, dan worden alle effect‑toepassingen van de vorm afgespeeld tijdens de diavoorstelling, inclusief die die van de placeholders zijn geërfd.  

Stel dat we een PowerPoint‑bestand `sample.pptx` hebben met één dia die alleen een voettekst‑vorm bevat met de tekst “Made with Aspose.Slides” en het **Random Bars**‑effect op die vorm is toegepast.

![Dia‑vorm animatie‑effect](slide-shape-animation.png)

Stel bovendien dat het **Split**‑effect op de voettekst‑placeholder op de **layout**‑dia is toegepast.

![Layout‑vorm animatie‑effect](layout-shape-animation.png)

En tenslotte is het **Fly In**‑effect op de voettekst‑placeholder op de **master**‑dia toegepast.

![Master‑vorm animatie‑effect](master-shape-animation.png)

De volgende voorbeeldcode laat zien hoe u de `getBasePlaceholder`‑methode van de [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) interface gebruikt om de shape‑placeholders te benaderen en de animatie‑effecten op te halen die op de voettekst‑vorm zijn toegepast, inclusief die geërfd van placeholders op layout‑ en master‑dia’s.

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Haal de animatie-effecten van de vorm op op de normale dia.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Haal de animatie-effecten van de placeholder op op de layout-dia.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Haal de animatie-effecten van de placeholder op op de master-dia.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
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

## **Eigenschappen van de timing van animatie‑effecten wijzigen**

Aspose.Slides for Java maakt het mogelijk de timing‑eigenschappen van een animatie‑effect te wijzigen.  

Dit is het Animation Timing‑venster in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Dit zijn de overeenkomsten tussen PowerPoint Timing en de eigenschappen van [Effect.Timing](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IEffect#getTiming--) :

- PowerPoint Timing **Start**‑keuzelijst komt overeen met de eigenschap [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITiming#getTriggerType--).  
- PowerPoint Timing **Duration** komt overeen met de eigenschap [Effect.Timing.Duration](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITiming#getDuration--). De duur van een animatie (in seconden) is de totale tijd die een animatie nodig heeft om één cyclus te voltooien.  
- PowerPoint Timing **Delay** komt overeen met de eigenschap [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITiming#getTriggerDelayTime--).  

Zo wijzigt u de timing‑eigenschappen van een effect:

1. [Pas](#apply-animation-to-shape) het animatie‑effect toe of haal het op.  
2. Stel nieuwe waarden in voor de [Effect.Timing](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IEffect#getTiming--)‑eigenschappen die u nodig hebt.  
3. Sla het gewijzigde PPTX‑bestand op.  

Deze Java‑code demonstreert de bewerking:

```java
// Instantieert een presentatie‑klasse die een presentatiedocument vertegenwoordigt.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Haalt de hoofdreeks van de dia op.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Haalt het eerste effect van de hoofdreeks op.
    IEffect effect = sequence.get_Item(0);

    // Wijzigt het TriggerType van het effect zodat het start bij een klik
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Wijzigt de duur van het effect
    effect.getTiming().setDuration(3f);

    // Wijzigt de TriggerDelayTime van het effect
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Slaat het PPTX‑bestand op naar schijf
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Geluid voor animatie‑effect**

Aspose.Slides biedt deze eigenschappen om met geluiden in animatie‑effecten te werken:  

- [setSound(IAudio value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **Geluid aan een animatie‑effect toevoegen**

Deze Java‑code laat zien hoe u een geluid aan een animatie‑effect toevoegt en stopt wanneer het volgende effect begint:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Voegt audio toe aan de audio-collectie van de presentatie
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Haalt de hoofdreeks van de dia op.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Haalt het eerste effect van de hoofdreeks op
    IEffect firstEffect = sequence.get_Item(0);

    // Controleert of het effect geen geluid heeft
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Voegt geluid toe aan het eerste effect
        firstEffect.setSound(effectSound);
    }

    // Haalt de eerste interactieve reeks van de dia op.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Stelt de vlag "Stop vorige geluid" in voor het effect
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Schrijft het PPTX-bestand naar schijf
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Geluid uit een animatie‑effect extraheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Haal de hoofdreeks van effecten op.  
4. Extraheer het aan elk animatie‑effect gekoppelde [setSound(IAudio value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) geluid.  

Deze Java‑code laat zien hoe u het in een animatie‑effect ingebedde geluid extraheert:

```java
// Instantieert een presentatieklasse die een presentatiedocument vertegenwoordigt.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Haalt de hoofdreeks van de dia op.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extraheert het effectgeluid in een byte array
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Na de animatie**

Aspose.Slides for Java maakt het mogelijk de eigenschap **After animation** van een animatie‑effect te wijzigen.  

Dit is het Animation Effect‑venster en het uitgebreide menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

De keuzelijst **After animation** in PowerPoint komt overeen met deze eigenschappen:  

- eigenschap [setAfterAnimationType(int value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) die het type after‑animation beschrijft:  
  * PowerPoint **More Colors** komt overeen met het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/java/com.aspose.slides/afteranimationtype/#Color);  
  * PowerPoint **Don't Dim** komt overeen met het type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/nl/java/com.aspose.slides/afteranimationtype/#DoNotDim) (standaard after‑animation type);  
  * PowerPoint **Hide After Animation** komt overeen met het type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * PowerPoint **Hide on Next Mouse Click** komt overeen met het type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- eigenschap [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) die een after‑animation‑kleurformaat definieert. Deze eigenschap werkt samen met het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/java/com.aspose.slides/afteranimationtype/#Color). Als u het type wijzigt, wordt de after‑animation‑kleur gewist.  

Deze Java‑code laat zien hoe u een after‑animation‑effect wijzigt:

```java
// Instantieert een presentatieklasse die een presentatiedocument vertegenwoordigt
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Haalt het eerste effect van de hoofdreeks op
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Wijzigt het after animation type naar Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Stelt de after animation dimkleur in
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Schrijft het PPTX-bestand naar schijf
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tekst animeren**

Aspose.Slides biedt deze eigenschappen om met het *Animate text*‑blok van een animatie‑effect te werken:  

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) die het type animatietekst van het effect beschrijft. De vorm‑tekst kan geanimeerd worden:  
  - Alles tegelijk ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/nl/java/com.aspose.slides/animatetexttype/#AllAtOnce))  
  - Per woord ([AnimateTextType.ByWord](https://reference.aspose.com/slides/nl/java/com.aspose.slides/animatetexttype/#ByWord))  
  - Per letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/animatetexttype/#ByLetter))  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) stelt een vertraging in tussen de geanimeerde tekstonderdelen (woorden of letters). Een positieve waarde geeft een percentage van de effectduur aan; een negatieve waarde geeft de vertraging in seconden aan.  

Zo wijzigt u de eigenschappen **Animate text** van een effect:

1. [Pas](#apply-animation-to-shape) het animatie‑effect toe of haal het op.  
2. Stel de eigenschap [setBuildType(int value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextanimation/#setBuildType-int-) in op de waarde [BuildType.AsOneObject](https://reference.aspose.com/slides/nl/java/com.aspose.slides/buildtype/#AsOneObject) om de *By Paragraphs*‑animatiemodus uit te schakelen.  
3. Stel nieuwe waarden in voor de eigenschappen [setAnimateTextType(int value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) en [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).  
4. Sla het gewijzigde PPTX‑bestand op.  

Deze Java‑code demonstreert de bewerking:

```java
// Instantieert een presentatieklasse die een presentatiedocument vertegenwoordigt.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Haalt het eerste effect van de hoofdreeks op
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Wijzigt het effecttekstanimatietype naar "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Wijzigt het effect Animatietekst‑type naar "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Stelt de vertraging tussen woorden in op 20% van de effectduur
    firstEffect.setDelayBetweenTextParts(20f);

    // Schrijft het PPTX‑bestand naar schijf
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Hoe kan ik ervoor zorgen dat animaties behouden blijven bij het publiceren van de presentatie op het web?**  

[Export to HTML5](/slides/nl/java/export-to-html5/) en schakel de [options](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/) in die verantwoordelijk zijn voor [shape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) en [transition](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) animaties. Gewone HTML speelt geen dia‑animaties af, HTML5 wel.  

**Hoe beïnvloedt het wijzigen van de z‑order (laagvolgorde) van vormen de animatie?**  

Animatie‑ en tekenvolgorde zijn onafhankelijk: een effect bepaalt het tijdstip en type van verschijnen/verdwijnen, terwijl [z-order](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getZOrderPosition--) bepaalt wat wat bedekt. Het zichtbare resultaat wordt bepaald door hun combinatie. (Dit is het algemene gedrag van PowerPoint; het Aspose.Slides‑model voor effecten‑en‑vormen volgt dezelfde logica.)  

**Zijn er beperkingen bij het converteren van animaties naar video voor bepaalde effecten?**  

In het algemeen worden [animaties ondersteund](/slides/nl/java/convert-powerpoint-to-video/), maar zeldzame gevallen of specifieke effecten kunnen anders worden gerenderd. Het wordt aangeraden de gebruikte effecten en de bibliotheekversie te testen.