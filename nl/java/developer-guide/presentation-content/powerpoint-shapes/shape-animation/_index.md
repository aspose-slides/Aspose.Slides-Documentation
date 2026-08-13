---
title: Vormanimaties toepassen in presentaties met Java
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
description: "Ontdek hoe u vormanimaties kunt maken en aanpassen in PowerPoint-presentaties met Aspose.Slides voor Java. Val op!"
---
## **Inleiding**

Animaties zijn visuele effecten die kunnen worden toegepast op tekst, afbeeldingen, vormen of [charts](https://docs.aspose.com/slides/nl/java/animated-charts/). Ze geven leven aan presentaties of hun bestanddelen. 

## **Waarom animaties gebruiken in presentaties?**

Door animaties te gebruiken kunt u 

* de informatiestroom beheersen
* belangrijke punten benadrukken
* de interesse of betrokkenheid van uw publiek vergroten
* inhoud makkelijker leesbaar, verteerbaar of verwerkbaar maken
* de aandacht van uw lezers of toeschouwers vestigen op belangrijke onderdelen van een presentatie

PowerPoint biedt veel opties en tools voor animaties en animatie‑effecten binnen de categorieën **entrance**, **exit**, **emphasis**, en **motion paths**. 

## **Animaties in Aspose.Slides**

* Aspose.Slides biedt de klassen en types die u nodig heeft om met animaties te werken onder de `Aspose.Slides.Animation`‑namespace,
* Aspose.Slides biedt meer dan **150 animatie‑effecten** via de [EffectType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effecttype)‑enumeratie. Deze effecten zijn in wezen dezelfde (of equivalente) effecten die in PowerPoint worden gebruikt.

## **Animatie toepassen op een tekstvak**

Aspose.Slides voor Java stelt u in staat animatie toe te passen op de tekst in een vorm. 

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation).
2. Verkrijg een slide‑referentie via de index.
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape) toe. 
4. Voeg tekst toe aan [IAutoShape.TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Haal de hoofdvolgorde van effecten op.
6. Voeg een animatie‑effect toe aan [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape). 
7. Stel de eigenschap `TextAnimation.BuildType` in op de waarde uit de `BuildType`‑enumeratie.
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze Java‑code laat zien hoe u het `Fade`‑effect toepast op een AutoShape en de tekstananimatie instelt op de *By 1st Level Paragraphs*‑waarde:

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

    // Haalt de hoofdvolgorde van de slide op.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Voegt Fade‑animatie‑effect toe aan de vorm
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animeert de vormtekst per 1e niveau alinea's
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Slaat het PPTX‑bestand op naar schijf
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

Naast het toepassen van animaties op tekst, kunt u ook animaties toepassen op een enkele [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph). Zie [**Animated Text**](/slides/nl/java/animated-text/).

{{% /alert %}} 

## **Animatie toepassen op een PictureFrame**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation).
2. Verkrijg een slide‑referentie via de index.
3. Voeg een [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe) toe aan of haal een bestaande op op de slide. 
4. Haal de hoofdvolgorde van effecten op.
5. Voeg een animatie‑effect toe aan [PictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pictureframe).
6. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze Java‑code laat zien hoe u het `Fly`‑effect toepast op een picture frame:

```java
import com.aspose.slides.*;

// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
Presentation pres = new Presentation();
try {
    // Laad afbeelding die moet worden toegevoegd aan de afbeeldingscollectie van de presentatie
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Voegt een picture frame toe aan de dia
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Haalt de hoofdvolgorde van de slide op.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Voegt Fly from Left‑animatie‑effect toe aan het picture frame
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Slaat het PPTX‑bestand op naar schijf
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animatie toepassen op een vorm**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
2. Verkrijg een slide‑referentie via de index.
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape) toe. 
4. Voeg een `Bevel` [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape) toe (wanneer dit object wordt aangeklikt, wordt de animatie afgespeeld).
5. Maak een volgorde van effecten voor de bevel‑vorm.
6. Maak een aangepaste `UserPath`.
7. Voeg opdrachten toe om naar de `UserPath` te bewegen.
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze Java‑code laat zien hoe u het `PathFootball`‑effect op een vorm toepast:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Instantieert een Presentatie‑klasse die een PPTX‑bestand vertegenwoordigt.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Maakt PathFootball‑effect voor bestaande vorm vanaf nul.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Voegt het PathFootBall‑animatie‑effect toe
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Maakt een soort "knop".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Maakt een reeks effecte voor deze knop.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Maakt een aangepast gebruikerspad. Het object wordt alleen verplaatst nadat de knop is aangeklikt.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Voegt verplaatsings‑commando's toe omdat het aangemaakte pad leeg is.
    IMotionEffect motionBvh = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBvh.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Schrijft het PPTX‑bestand naar schijf
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animatie‑effecten opgehaald van een vorm**

De volgende voorbeelden laten zien hoe u de `getEffectsByShape`‑methode van de [ISequence](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isequence/) interface gebruikt om alle animatie‑effecten op een vorm op te halen.

**Voorbeeld 1: Animatie‑effecten ophalen die op een vorm op een normale slide zijn toegepast**

Eerder hebt u geleerd hoe u animatie‑effecten toevoegt aan vormen in PowerPoint‑presentaties. De volgende voorbeeldcode laat zien hoe u de effect‑toepassingen op de eerste vorm op de eerste normale slide van de presentatie `AnimExample_out.pptx` kunt ophalen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Haal de hoofdanimatievolgorde van de slide op.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Haal de eerste vorm op de eerste slide op.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Haal de animatie‑effecten op die op de vorm zijn toegepast.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Voorbeeld 2: Alle animatie‑effecten ophalen, inclusief diegenen die van placeholders zijn geërfd**

Als een vorm op een normale slide placeholders bevat die zich op de layout‑slide en/of master‑slide bevinden, en er animatie‑effecten aan deze placeholders zijn toegevoegd, dan worden alle effect‑toepassingen van de vorm afgespeeld tijdens de diavoorstelling, inclusief diegenen die van de placeholders zijn geërfd.

Stel dat we een PowerPoint‑presentatiebestand `sample.pptx` hebben met één slide die alleen een voettekst‑vorm bevat met de tekst "Made with Aspose.Slides" en het **Random Bars**‑effect is toegepast op de vorm.

![Dia‑vorm animatie‑effect](slide-shape-animation.png)

Laten we bovendien aannemen dat het **Split**‑effect is toegepast op de voettekst‑placeholder op de **layout**‑slide.

![Layout‑vorm animatie‑effect](layout-shape-animation.png)

En tenslotte is het **Fly In**‑effect toegepast op de voettekst‑placeholder op de **master**‑slide.

![Master‑vorm animatie‑effect](master-shape-animation.png)

De volgende voorbeeldcode laat zien hoe u de `getBasePlaceholder`‑methode van de [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) interface gebruikt om de shape‑placeholders te benaderen en de animatie‑effecten op de voettekst‑vorm op te halen, inclusief diegenen die van placeholders op de layout‑ en master‑slides zijn geërfd.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Haal de animatie-effecten van de vorm op de normale dia op.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Haal de animatie-effecten van de placeholder op de lay-outdia op.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Haal de animatie-effecten van de placeholder op de master-dia op.
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

## **Eigenschappen voor timing van animatie‑effecten wijzigen**

Aspose.Slides voor Java stelt u in staat de timing‑eigenschappen van een animatie‑effect te wijzigen.

Dit is het Animation Timing‑paneel in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Dit zijn de overeenkomsten tussen PowerPoint‑Timing en [Effect.Timing](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IEffect#getTiming--)‑eigenschappen:

- PowerPoint‑Timing **Start**‑keuzelijst komt overeen met de eigenschap [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITiming#getTriggerType--).
- PowerPoint‑Timing **Duration** komt overeen met de eigenschap [Effect.Timing.Duration](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITiming#getDuration--). De duur van een animatie (in seconden) is de totale tijd die de animatie nodig heeft om één cyclus te voltooien.
- PowerPoint‑Timing **Delay** komt overeen met de eigenschap [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITiming#getTriggerDelayTime--).

Zo wijzigt u de Effect‑Timing‑eigenschappen:

1. Pas toe ([Apply](#apply-animation-to-shape)) of haal het animatie‑effect op.
2. Stel nieuwe waarden in voor de benodigde [Effect.Timing](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IEffect#getTiming--)‑eigenschappen.
3. Sla het gewijzigde PPTX‑bestand op.

Deze Java‑code demonstreert de bewerking:

```java
import com.aspose.slides.*;

// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Haalt de hoofdvolgorde van de slide op.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Haalt het eerste effect van de hoofdvolgorde op.
    IEffect effect = sequence.get_Item(0);

    // Wijzigt het TriggerType van het effect zodat het start bij een muisklik
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

## **Geluid van animatie‑effect**

Aspose.Slides biedt deze eigenschappen om geluiden in animatie‑effecten te gebruiken: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Geluid aan een animatie‑effect toevoegen**

Deze Java‑code laat zien hoe u een geluid aan een animatie‑effect toevoegt en stopt wanneer het volgende effect start:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Voegt audio toe aan de audiocollectie van de presentatie
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Haalt de hoofdvolgorde van de slide op.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Haalt het eerste effect van de hoofdvolgorde op.
    IEffect firstEffect = sequence.get_Item(0);

    // Controleert het effect op "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Voegt geluid toe aan het eerste effect
        firstEffect.setSound(effectSound);
    }

    // Haalt de eerste interactieve volgorde van de slide op.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Stelt de vlag "Stop previous sound" van het effect in
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Schrijft het PPTX-bestand naar schijf
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Geluid uit een animatie‑effect extraheren**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/).
2. Verkrijg een slide‑referentie via de index. 
3. Haal de hoofdvolgorde van effecten op. 
4. Haal het ingebedde [setSound(IAudio value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) uit elk animatie‑effect. 

Deze Java‑code laat zien hoe u het geluid dat in een animatie‑effect is ingebed, kunt extraheren:

```java
import com.aspose.slides.*;

// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Haalt de hoofdvolgorde van de slide op.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extraheert het effectgeluid in byte array
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Na animatie**

Aspose.Slides voor Java stelt u in staat de eigenschap After animation van een animatie‑effect te wijzigen.

Dit is het Animation Effect‑paneel en het uitgebreide menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

De PowerPoint‑Effect **After animation**‑keuzelijst komt overeen met deze eigenschappen: 

- De eigenschap [setAfterAnimationType(int value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) beschrijft het type After animation :
  * PowerPoint **More Colors** komt overeen met het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/java/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** komt overeen met het type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/nl/java/com.aspose.slides/afteranimationtype/#DoNotDim) (standaardtype);
  * PowerPoint **Hide After Animation** komt overeen met het type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** komt overeen met het type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- De eigenschap [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) definieert een kleurformaat voor After animation. Deze eigenschap werkt in combinatie met het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/java/com.aspose.slides/afteranimationtype/#Color). Als u het type wijzigt, wordt de After‑animation‑kleur gewist.

Deze Java‑code laat zien hoe u een after‑animation‑effect wijzigt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Haalt het eerste effect van de hoofdvolgorde op
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Wijzigt het after animation type naar Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Stelt de after animation dim kleur in
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Schrijft het PPTX bestand naar schijf
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tekst animeren**

Aspose.Slides biedt deze eigenschappen om met het *Animate text*‑blok van een animatie‑effect te werken:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) die het type animatietekst van het effect beschrijft. De vormtekst kan geanimeerd worden:
  - Allemaal tegelijk ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/nl/java/com.aspose.slides/animatetexttype/#AllAtOnce) type)
  - Per woord ([AnimateTextType.ByWord](https://reference.aspose.com/slides/nl/java/com.aspose.slides/animatetexttype/#ByWord) type)
  - Per letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/animatetexttype/#ByLetter) type)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) stelt een vertraging in tussen de geanimeerde tekstonderdelen (woorden of letters). Een positieve waarde geeft het percentage van de effect‑duur aan. Een negatieve waarde geeft de vertraging in seconden aan.

Zo kunt u de eigenschappen van Effect Animate text wijzigen:

1. Pas toe ([Apply](#apply-animation-to-shape)) of haal het animatie‑effect op.
2. Stel de eigenschap [setBuildType(int value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextanimation/#setBuildType-int-) in op de waarde [BuildType.AsOneObject](https://reference.aspose.com/slides/nl/java/com.aspose.slides/buildtype/#AsOneObject) om de *By Paragraphs*‑animatiemodus uit te schakelen.
3. Stel nieuwe waarden in voor de eigenschappen [setAnimateTextType(int value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) en [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Sla het gewijzigde PPTX‑bestand op.

Deze Java‑code demonstreert de bewerking:

```java
import com.aspose.slides.*;

// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Haalt het eerste effect van de hoofdvolgorde op
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Wijzigt het tekstanimatietype van het effect naar "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Wijzigt het animate text type van het effect naar "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Stelt de vertraging tussen woorden in op 20% van de effectduur
    firstEffect.setDelayBetweenTextParts(20f);

    // Schrijft het PPTX-bestand naar schijf
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Hoe kan ik ervoor zorgen dat animaties behouden blijven bij het publiceren van de presentatie naar het web?

[Export to HTML5](/slides/nl/java/export-to-html5/) en schakel de [opties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/) in die verantwoordelijk zijn voor [shape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-)‑ en [transition](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)‑animaties. Gewone HTML speelt geen slide‑animaties af, terwijl HTML5 dat wel doet.

### Hoe beïnvloedt het wijzigen van de z-order (laagvolgorde) van vormen de animatie?

Animatie‑ en tekenvolgorde zijn onafhankelijk: een effect bepaalt de timing en het type van verschijnen/verdwijnen, terwijl [z-order](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getZOrderPosition--) bepaalt wat wat bedekt. Het zichtbare resultaat wordt bepaald door hun combinatie. (Dit is het algemene PowerPoint‑gedrag; het Aspose.Slides‑effect‑en‑vorm‑model volgt dezelfde logica.)

### Zijn er beperkingen bij het converteren van animaties naar video voor bepaalde effecten?

Over het algemeen worden [animaties ondersteund](/slides/nl/java/convert-powerpoint-to-video/), maar zeldzame gevallen of specifieke effecten kunnen anders worden gerenderd. Het wordt aanbevolen om te testen met de effecten die u gebruikt en met de bibliotheekversie.