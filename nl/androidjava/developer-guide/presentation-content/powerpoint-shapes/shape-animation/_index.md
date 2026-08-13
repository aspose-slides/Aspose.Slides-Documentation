---
title: Toepassen van vormanimaties in presentaties op Android
linktitle: Vormanimatie
type: docs
weight: 60
url: /nl/androidjava/shape-animation/
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
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe u vormanimaties kunt maken en aanpassen in PowerPoint-presentaties met Aspose.Slides voor Android via Java. Val op!"
---
## **Inleiding**

Animaties zijn visuele effecten die toegepast kunnen worden op teksten, afbeeldingen, vormen of [grafieken](https://docs.aspose.com/slides/nl/androidjava/animated-charts/). Ze geven leven aan presentaties of hun onderdelen.

## **Waarom animaties gebruiken in presentaties?**

Met animaties kun je

* de informatiestroom sturen
* belangrijke punten benadrukken
* de interesse of participatie van je publiek verhogen
* de inhoud makkelijker leesbaar, verteerbaar of verwerkbaar maken
* de aandacht van lezers of kijkers richten op belangrijke delen in een presentatie

PowerPoint biedt veel opties en gereedschappen voor animaties en animatie‑effecten binnen de categorieën **invoer**, **verlaten**, **accentuering** en **bewegingsbanen**.

## **Animaties in Aspose.Slides**

* Aspose.Slides levert de klassen en types die je nodig hebt om met animaties te werken onder de `Aspose.Slides.Animation` namespace,
* Aspose.Slides biedt meer dan **150 animatie‑effecten** via de [EffectType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/effecttype) enumeratie. Deze effecten zijn in wezen dezelfde (of equivalente) die in PowerPoint gebruikt worden.

## **Animatie toepassen op een TextBox**

Aspose.Slides for Android via Java staat je toe een animatie toe te passen op de tekst in een vorm.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
2. Verkrijg een slide‑referentie via de index.
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape) toe.
4. Voeg tekst toe aan [IAutoShape.TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Haal de hoofd‑sequentie van effecten op.
6. Voeg een animatie‑effect toe aan [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape).
7. Stel de eigenschap `TextAnimation.BuildType` in op de waarde uit de `BuildType` enumeratie.
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze Java‑code laat zien hoe je het `Fade`‑effect toepast op een AutoShape en de tekstanimatie instelt op *By 1st Level Paragraphs*:

```java
import com.aspose.slides.*;

// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Voegt een nieuwe AutoShape toe met tekst
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Haalt de hoofdsequentie van de dia op.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Voegt een Fade-animatie-effect toe aan de vorm
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animeert de tekst van de vorm per alinea op het eerste niveau
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Slaat het PPTX-bestand op naar schijf
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

Naast het toepassen van animaties op tekst, kun je ook animaties toepassen op een enkele [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph). Zie [**Animated Text**](/slides/nl/androidjava/animated-text/).

{{% /alert %}} 

## **Animatie toepassen op een PictureFrame**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
2. Verkrijg een slide‑referentie via de index.
3. Voeg een [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe) toe aan of haal er een op van de slide.
4. Haal de hoofd‑sequentie van effecten op.
5. Voeg een animatie‑effect toe aan [PictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pictureframe).
6. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze Java‑code laat zien hoe je het `Fly`‑effect toepast op een picture frame:

```java
import com.aspose.slides.*;

// Instantieert een presentatieklasse die een presentiebestand representeert.
Presentation pres = new Presentation();
try {
    // Laad afbeelding die toegevoegd moet worden aan de afbeeldingscollectie van de presentatie
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Voegt een picture frame toe aan de dia
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Haalt de hoofdsequentie van de dia op.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Voegt Fly-from-Left animatie-effect toe aan het picture frame
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Slaat het PPTX-bestand op naar schijf
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animatie toepassen op een Shape**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
2. Verkrijg een slide‑referentie via de index.
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape) toe.
4. Voeg een `Bevel` [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape) toe (wanneer dit object aangeklikt wordt, wordt de animatie afgespeeld).
5. Creëer een sequentie van effecten op de bevel‑vorm.
6. Creëer een aangepaste `UserPath`.
7. Voeg commando’s toe voor het verplaatsen naar de `UserPath`.
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze Java‑code laat zien hoe je het `PathFootball`‑effect toepast op een vorm:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Instantieert een Presentation-klasse die een PPTX-bestand representeert.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Maakt een PathFootball-effect voor een bestaande vorm vanaf nul.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Voegt het PathFootBall-animatie-effect toe
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Maakt een soort "button".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Maakt een sequentie van effecten voor deze button.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Creëert een aangepast gebruikerspad. Ons object wordt alleen verplaatst nadat op de button geklikt is.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Voegt commando's toe voor beweging omdat het aangemaakte pad leeg is.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Schrijft het PPTX-bestand naar schijf
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **De animatie‑effecten op een vorm opvragen**

De volgende voorbeelden laten zien hoe je de `getEffectsByShape`‑methode van de [ISequence](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isequence/) interface gebruikt om alle animatie‑effecten die op een vorm toegepast zijn op te halen.

**Voorbeeld 1: Animatie‑effecten opvragen die op een vorm op een normale slide zijn toegepast**

Eerder heb je geleerd hoe je animatie‑effecten toevoegt aan vormen in PowerPoint‑presentaties. De volgende voorbeeldcode laat zien hoe je de effecten ophaalt die op de eerste vorm van de eerste normale slide in de presentatie `AnimExample_out.pptx` zijn toegepast.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Haalt de hoofdanimatie-sequentie van de dia op.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Haalt de eerste vorm op de eerste dia op.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Haalt de op de vorm toegepaste animatie-effecten op.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Voorbeeld 2: Alle animatie‑effecten opvragen, inclusief die afkomstig van placeholders**

Als een vorm op een normale slide placeholders heeft die op de layout‑slide en/of master‑slide staan, en er animatie‑effecten aan deze placeholders zijn toegevoegd, dan worden alle effecten van de vorm afgespeeld tijdens de diavoorstelling, inclusief die geërfd van de placeholders.

Stel, we hebben een PowerPoint‑presentatie `sample.pptx` met één slide die alleen een voettekst‑vorm bevat met de tekst “Made with Aspose.Slides” en het **Random Bars**‑effect is op die vorm toegepast.

![Slide shape animation effect](slide-shape-animation.png)

Stel ook dat het **Split**‑effect op de voettekst‑placeholder van de **layout**‑slide toegepast is.

![Layout shape animation effect](layout-shape-animation.png)

En tenslotte dat het **Fly In**‑effect op de voettekst‑placeholder van de **master**‑slide toegepast is.

![Master shape animation effect](master-shape-animation.png)

De volgende voorbeeldcode laat zien hoe je de `getBasePlaceholder`‑methode van de [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) interface gebruikt om de shape‑placeholders te benaderen en de animatie‑effecten op de voettekst‑vorm op te halen, inclusief die geërfd van placeholders op de layout‑ en master‑slides.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

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

## **Timing‑eigenschappen van animatie‑effecten wijzigen**

Aspose.Slides for Android via Java stelt je in staat de timing‑eigenschappen van een animatie‑effect te wijzigen.

Dit is het Animation Timing‑venster in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Dit zijn de overeenkomsten tussen PowerPoint Timing en de [Effect.Timing](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IEffect#getTiming--) eigenschappen:

- De keuzelijst **Start** in PowerPoint komt overeen met de eigenschap [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITiming#getTriggerType--) .
- **Duration** in PowerPoint komt overeen met de eigenschap [Effect.Timing.Duration](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITiming#getDuration--) . De duur van een animatie (in seconden) is de totale tijd die de animatie nodig heeft voor één cyclus.
- **Delay** in PowerPoint komt overeen met de eigenschap [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) .

Zo wijzig je de Effect Timing‑eigenschappen:

1. [Pas](#apply-animation-to-shape) of haal het animatie‑effect op.
2. Stel nieuwe waarden in voor de [Effect.Timing](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IEffect#getTiming--) eigenschappen die je nodig hebt.
3. Sla het aangepaste PPTX‑bestand op.

Deze Java‑code demonstreert de werking:

```java
import com.aspose.slides.*;

// Instantieert een presentatieklasse die een presentiebestand vertegenwoordigt.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Haalt de hoofdsequentie van de dia op.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Haalt het eerste effect van de hoofdsequentie op.
    IEffect effect = sequence.get_Item(0);

    // Wijzigt het TriggerType van het effect zodat het start bij een klik
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Wijzigt de duur van het effect
    effect.getTiming().setDuration(3f);

    // Wijzigt de TriggerDelayTime van het effect
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Slaat het PPTX-bestand op naar schijf
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Geluid voor een animatie‑effect**

Aspose.Slides biedt deze eigenschappen om met geluiden in animatie‑effecten te werken:

- [setSound(IAudio value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Een geluid aan een animatie‑effect toevoegen**

Deze Java‑code laat zien hoe je een geluid aan een animatie‑effect toevoegt en stopt wanneer het volgende effect start:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Voegt audio toe aan de audio-collectie van de presentatie
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Haalt de hoofdsequentie van de dia op.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Haalt het eerste effect van de hoofdsequentie op.
    IEffect firstEffect = sequence.get_Item(0);

    // Controleert het effect op "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Voegt geluid toe aan het eerste effect
        firstEffect.setSound(effectSound);
    }

    // Haalt de eerste interactieve sequentie van de dia op.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Stelt de vlag "Stop previous sound" van het effect in
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Schrijft het PPTX-bestand naar schijf
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Een geluid uit een animatie‑effect extraheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
2. Verkrijg een slide‑referentie via de index.
3. Haal de hoofd‑sequentie van effecten op.
4. Extraheer het [setSound(IAudio value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) dat aan elk animatie‑effect is ingebed.

Deze Java‑code laat zien hoe je het geluid dat in een animatie‑effect is ingebed, extraheert:

```java
import com.aspose.slides.*;

// Instantieert een presentatieklasse die een presentiebestand vertegenwoordigt.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Haalt de hoofdsequentie van de dia op.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extraheert het effectgeluid in een byte-array
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **After Animation**

Aspose.Slides for Android via Java maakt het mogelijk de After‑animation‑eigenschap van een animatie‑effect te wijzigen.

Dit is het Animation Effect‑paneel en het uitgebreide menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

De keuzelijst **After animation** in PowerPoint komt overeen met deze eigenschappen:

- Eigenschap [setAfterAnimationType(int value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) die het type After‑animation beschrijft :
  * **More Colors** in PowerPoint komt overeen met het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/afteranimationtype/#Color);
  * **Don't Dim** in PowerPoint komt overeen met het type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (standaard after‑animation‑type);
  * **Hide After Animation** in PowerPoint komt overeen met het type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * **Hide on Next Mouse Click** in PowerPoint komt overeen met het type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Eigenschap [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) die een kleurformaat voor after‑animation definieert. Deze eigenschap werkt samen met het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/afteranimationtype/#Color). Als je het type wijzigt, wordt de after‑animation‑kleur gewist.

Deze Java‑code laat zien hoe je een after‑animation‑effect wijzigt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieert een presentatieklasse die een presentiebestand vertegenwoordigt.
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Haalt het eerste effect van de hoofdsequentie op.
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Wijzigt het after animation type naar Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Stelt de after animation dim color in
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Schrijft het PPTX bestand naar schijf
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tekst animeren**

Aspose.Slides biedt deze eigenschappen om met het *Animate text*‑blok van een animatie‑effect te werken:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) beschrijft het type animeren van tekst van het effect. De tekst van de vorm kan geanimeerd worden:
  - Alles tegelijk ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) type)
  - Per woord ([AnimateTextType.ByWord](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/animatetexttype/#ByWord) type)
  - Per letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/animatetexttype/#ByLetter) type)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) stelt een vertraging in tussen de geanimeerde tekstonderdelen (woorden of letters). Een positieve waarde geeft een percentage van de effectduur aan. Een negatieve waarde geeft de vertraging in seconden aan.

Zo wijzig je de Effect Animate‑text‑eigenschappen:

1. [Pas](#apply-animation-to-shape) of haal het animatie‑effect op.
2. Stel de eigenschap [setBuildType(int value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) in op de waarde [BuildType.AsOneObject](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/buildtype/#AsOneObject) om de *By Paragraphs*‑animatiemodus uit te schakelen.
3. Stel nieuwe waarden in voor de eigenschappen [setAnimateTextType(int value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) en [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) .
4. Sla het aangepaste PPTX‑bestand op.

Deze Java‑code demonstreert de werking:

```java
import com.aspose.slides.*;

// Instantieert een presentatieklasse die een presentiebestand vertegenwoordigt.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Haalt het eerste effect van de hoofdsequentie op.
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Wijzigt het type tekstanimatie van het effect naar "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Wijzigt het type Animate text van het effect naar "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Stelt de vertraging tussen woorden in op 20% van de effectduur
    firstEffect.setDelayBetweenTextParts(20f);

    // Schrijft het PPTX bestand naar schijf
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Hoe kan ik ervoor zorgen dat animaties behouden blijven bij het publiceren van de presentatie naar het web?

[Export to HTML5](/slides/nl/androidjava/export-to-html5/) en schakel de [opties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/html5options/) in die verantwoordelijk zijn voor animaties van [shape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) en [transition](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Gewone HTML speelt geen slide‑animaties af, terwijl HTML5 dat wel doet.

### Hoe beïnvloedt het wijzigen van de z‑order (laagvolgorde) van vormen de animatie?

Animatie‑ en tekenvolgorde zijn onafhankelijk: een effect bepaalt het moment en het type verschijnen/verdwijnen, terwijl [z‑order](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getZOrderPosition--) bepaalt wat wat bedekt. Het zichtbare resultaat wordt gedefinieerd door hun combinatie. (Dit is het algemene gedrag van PowerPoint; het Aspose.Slides‑effect‑en‑vormmodel volgt dezelfde logica.)

### Zijn er beperkingen bij het converteren van animaties naar video voor bepaalde effecten?

In het algemeen worden [animaties ondersteund](/slides/nl/androidjava/convert-powerpoint-to-video/), maar zeldzame gevallen of specifieke effecten kunnen anders gerenderd worden. Het wordt aangeraden de gebruikte effecten en de versie van de bibliotheek te testen.