---
title: Toepassen van Shape-animaties in presentaties met JavaScript
linktitle: Shape-animatie
type: docs
weight: 60
url: /nl/nodejs-java/shape-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek hoe u shape-animaties kunt maken en aanpassen in PowerPoint-presentaties met JavaScript en Aspose.Slides voor Node.js via Java. Val op!"
---
## **Inleiding**

Animaties zijn visuele effecten die kunnen worden toegepast op tekst, afbeeldingen, vormen, of [grafieken](/slides/nl/nodejs-java/animated-charts/). Ze geven leven aan presentaties of hun onderdelen.

## **Waarom animaties gebruiken in presentaties?**

Met animaties kun je

* de informatiestroom beheersen
* belangrijke punten benadrukken
* de interesse of participatie van je publiek vergroten
* de inhoud makkelijker leesbaar, begrijpelijk of verwerkbaar maken
* de aandacht van je lezers of kijkers vestigen op belangrijke delen in een presentatie

PowerPoint biedt veel opties en hulpmiddelen voor animaties en animatie‑effecten binnen de categorieën **ingang**, **exit**, **accent** en **bewegingspaden**.

## **Animaties in Aspose.Slides**

* Aspose.Slides levert de klassen en types die je nodig hebt om met animaties te werken onder de `Aspose.Slides.Animation` namespace,
* Aspose.Slides biedt meer dan **150 animatie‑effecten** via de [EffectType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effecttype) enumeratie. Deze effecten zijn in principe dezelfde (of equivalente) effecten die in PowerPoint worden gebruikt.

## **Animatie toepassen op TextBox**

Aspose.Slides voor Node.js via Java stelt je in staat om animatie toe te passen op de tekst in een vorm.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
2. Verkrijg een verwijzing naar een dia via de index.
3. Voeg een `rectangle` [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape) toe.
4. Voeg tekst toe met [AutoShape.addTextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-).
5. Haal de hoofd‑reeks van effecten op.
6. Voeg een animatie‑effect toe aan [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape).
7. Roep de `TextAnimation.setBuildType` methode aan met de waarde uit de `BuildType` enumeratie.
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze Javascript‑code laat zien hoe je het `Fade`‑effect toepast op AutoShape en de tekstanimatie instelt op *By 1st Level Paragraphs* waarde:

```javascript
// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Voegt een nieuwe AutoShape toe met tekst
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // Haalt de hoofd‑reeks van de dia op.
    var sequence = sld.getTimeline().getMainSequence();
    // Voegt Fade‑animatie‑effect toe aan de shape
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Animeert de shape‑tekst per alinea van het eerste niveau
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // Sla het PPTX‑bestand op schijf
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert color="primary"  %}} 

Naast het toepassen van animaties op tekst kun je ook animaties toepassen op een enkele [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph). Zie [**Animated Text**](/slides/nl/nodejs-java/animated-text/).

{{% /alert %}} 

## **Animatie toepassen op PictureFrame**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
2. Verkrijg een verwijzing naar een dia via de index.
3. Voeg een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe) toe aan of haal er een op de dia.
4. Haal de hoofd‑reeks van effecten op.
5. Voeg een animatie‑effect toe aan [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe).
6. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze Javascript‑code laat zien hoe je het `Fly`‑effect toepast op een picture frame:

```javascript
// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
var pres = new aspose.slides.Presentation();
try {
    // Laadt afbeelding die moet worden toegevoegd aan de presentatie-afbeeldingsverzameling
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Voegt picture frame toe aan dia
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // Haalt de hoofd-reeks van de dia op.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Voegt Fly-van-links animatie-effect toe aan picture frame
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // Sla het PPTX-bestand op schijf
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animatie toepassen op Shape**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
2. Verkrijg een verwijzing naar een dia via de index.
3. Voeg een `rectangle` [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape) toe.
4. Voeg een `Bevel` [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape) toe (wanneer dit object wordt aangeklikt, wordt de animatie afgespeeld).
5. Maak een reeks effecten op de bevel‑vorm.
6. Maak een aangepaste `UserPath`.
7. Voeg opdrachten toe om naar de `UserPath` te bewegen.
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze Javascript‑code laat zien hoe je het `PathFootball` (pad football) effect toepast op een shape:

```javascript
// Instantieer een Presentation-klasse die een PPTX-bestand vertegenwoordigt.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Creëert een PathFootball-effect voor een bestaande shape vanaf nul.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // Voegt het PathFootball-animatie-effect toe
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Creëert een soort "knop".
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // Creëert een reeks effecte voor deze knop.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // Creëert een aangepast gebruikerspad. Ons object wordt alleen verplaatst nadat de knop is aangeklikt.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Voegt verplaatsingscommando’s toe omdat het aangemaakte pad leeg is.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // Schrijft het PPTX-bestand naar schijf
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animatie‑effecten ophalen die op een shape zijn toegepast**

De volgende voorbeelden laten zien hoe je de `getEffectsByShape`‑methode van de [Sequence](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/) klasse gebruikt om alle animatie‑effecten die op een shape zijn toegepast op te halen.

**Voorbeeld 1: Animatie‑effecten ophalen die op een shape op een normale dia zijn toegepast**

Eerder leerde je hoe je animatie‑effecten toevoegt aan shapes in PowerPoint‑presentaties. De volgende voorbeeldcode toont hoe je de effecten kunt ophalen die op de eerste shape op de eerste normale dia van de presentatie `AnimExample_out.pptx` zijn toegepast.

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // Haalt de hoofd-animatie-reeks van de dia op.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // Haalt de eerste shape op van de eerste dia.
    var shape = firstSlide.getShapes().get_Item(0);

    // Haalt de animatie-effecten op die op de shape zijn toegepast.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

**Voorbeeld 2: Alle animatie‑effecten ophalen, inclusief die geërfd van placeholders**

Als een shape op een normale dia placeholders heeft die zich op de lay‑outdia en/of master‑dia bevinden, en er zijn animatie‑effecten aan deze placeholders toegevoegd, dan worden alle effecten van de shape afgespeeld tijdens de diavoorstelling, inclusief die welke geërfd zijn van de placeholders.

Laten we aannemen dat we een PowerPoint‑presentatiebestand `sample.pptx` hebben met één dia die alleen een footer‑shape bevat met de tekst "Made with Aspose.Slides" en waarop het **Random Bars**‑effect is toegepast.

![Dia shape animatie‑effect](slide-shape-animation.png)

Laten we ook veronderstellen dat het **Split**‑effect is toegepast op de footer‑placeholder op de **layout**‑dia.

![Layout shape animatie‑effect](layout-shape-animation.png)

En tot slot is het **Fly In**‑effect toegepast op de footer‑placeholder op de **master**‑dia.

![Master shape animatie‑effect](master-shape-animation.png)

De volgende voorbeeldcode laat zien hoe je de `getBasePlaceholder`‑methode van de [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/) klasse gebruikt om de shape‑placeholders te benaderen en de animatie‑effecten op te halen die op de footer‑shape zijn toegepast, inclusief die die geërfd zijn van placeholders op de layout‑ en master‑dia's.

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Haal de animatie‑effecten van de shape op de normale dia op.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Haal de animatie‑effecten van de placeholder op de lay‑outdia op.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Haal de animatie‑effecten van de placeholder op de master‑dia op.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```

```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Vliegen, Bodem
Type: 134, subtype: 45            // Splitsen, VerticaalIn
Type: 126, subtype: 22            // WillekeurigeStrepen, Horizontaal
```

## **Timing‑eigenschappen van animatie‑effecten wijzigen**

Aspose.Slides voor Node.js via Java stelt je in staat de Timing‑eigenschappen van een animatie‑effect te wijzigen.

Dit is het paneel Animatie‑Timing in Microsoft PowerPoint:

![voorbeeld1_afbeelding](shape-animation.png)

Dit zijn de overeenkomsten tussen PowerPoint Timing en [Effect.Timing](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Effect#getTiming--) eigenschappen:

- PowerPoint Timing **Start** vervolgkeuzelijst komt overeen met de [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Timing#getTriggerType--) eigenschap.
- PowerPoint Timing **Duration** komt overeen met de [Effect.Timing.Duration](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Timing#getDuration--) eigenschap. De duur van een animatie (in seconden) is de totale tijd die de animatie nodig heeft om één cyclus te voltooien.
- PowerPoint Timing **Delay** komt overeen met de [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--) eigenschap.

Zo wijzig je de Effect‑Timing‑eigenschappen:

1. [Apply](#apply-animation-to-shape) or get the animation effect.
2. Set new values for the [Effect.Timing](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Effect#getTiming--) properties you need.
3. Save the modified PPTX file.

```javascript
// Instantieert een presentatieklasse die een presentatiedocument vertegenwoordigt.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Haalt de hoofdreeks van de dia op.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Haalt het eerste effect van de hoofdreeks op.
    var effect = sequence.get_Item(0);
    // Wijzigt het effect TriggerType naar start bij klik
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // Wijzigt de duur van het effect
    effect.getTiming().setDuration(3.0);
    // Wijzigt het TriggerDelayTime van het effect
    effect.getTiming().setTriggerDelayTime(0.5);
    // Slaat het PPTX-bestand op schijf
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Geluid voor animatie‑effect**

Aspose.Slides biedt deze eigenschappen om met geluiden in animatie‑effecten te werken:

- [setSound(IAudio value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Geluid aan animatie‑effect toevoegen**

Deze Javascript‑code laat zien hoe je een animatie‑effectgeluid toevoegt en stopt wanneer het volgende effect start:

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Voeg audio toe aan de audiocollectie van de presentatie
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // Haalt de hoofdreeks van de dia op.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // Haalt het eerste effect van de hoofdreeks op.
    var firstEffect = sequence.get_Item(0);
    // Controleert het effect op "No Sound"
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // Voeg geluid toe voor het eerste effect
        firstEffect.setSound(effectSound);
    }
    // Haalt de eerste interactieve reeks van de dia op.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // Stelt de vlag "Stop previous sound" van het effect in
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // Schrijft het PPTX-bestand naar schijf
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Animatie‑effectgeluid extraheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Haal de hoofd‑reeks van effecten op.
4. Extraheer de [setSound(IAudio value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) die aan elk animatie‑effect is ingebed.

Deze Javascript‑code laat zien hoe je het geluid dat in een animatie‑effect is ingebed, kunt extraheren:

```javascript
// Instantieert een presentatieklasse die een presentatiedocument vertegenwoordigt.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Haalt de hoofdreeks van de dia op.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // Extraheert het effectgeluid in een byte-array
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Na animatie**

Aspose.Slides voor Node.js via Java stelt je in staat de After‑animation‑eigenschap van een animatie‑effect te wijzigen.

Dit is het paneel Animation Effect en het uitgebreide menu in Microsoft PowerPoint:

![voorbeeld1_afbeelding](shape-after-animation.png)

PowerPoint Effect **After animation** vervolgkeuzelijst komt overeen met deze eigenschappen:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) methode die het type After‑animation beschrijft;  
  * PowerPoint **More Colors** komt overeen met het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** komt overeen met het type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (standaard after‑animation type);
  * PowerPoint **Hide After Animation** komt overeen met het type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** komt overeen met het type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) methode die een after‑animation‑kleuropmaak definieert. Deze methode werkt in combinatie met het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/afteranimationtype/#Color). Als je het type wijzigt, wordt de after‑animation‑kleur gewist.

```javascript
// Instantieert een presentatieklasse die een presentatiedocument vertegenwoordigt
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Haalt het eerste effect van de hoofdreeks op
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Wijzigt het after‑animation type naar Kleur
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // Stelt de after‑animation dim‑kleur in
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Schrijft het PPTX‑bestand naar schijf
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tekst animeren**

Aspose.Slides biedt deze eigenschappen om te werken met het *Animate text*‑blok van een animatie‑effect:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) die het type tekstanimatie van het effect beschrijft. De shape‑tekst kan geanimeerd worden:
  - Alles tegelijk ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce) type)
  - Per woord ([AnimateTextType.ByWord](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/animatetexttype/#ByWord) type)
  - Per letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/animatetexttype/#ByLetter) type)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) stelt een vertraging in tussen de geanimeerde tekstonderdelen (woorden of letters). Een positieve waarde geeft het percentage van de effectduur aan. Een negatieve waarde geeft de vertraging in seconden aan.

Zo kun je de Effect‑Animate‑text‑eigenschappen wijzigen:

1. [Apply](#apply-animation-to-shape) or get the animation effect.
2. Stel de `setBuildType(int value)`‑methode in op de `BuildType.AsOneObject`‑waarde om de *By Paragraphs*‑animatiemodus uit te schakelen.
3. Stel nieuwe waarden in voor de [setAnimateTextType(int value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) en [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) eigenschappen.
4. Save the modified PPTX file.

```javascript
// Instantieert een presentatieklasse die een presentatiedocument vertegenwoordigt.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Haalt het eerste effect van de hoofdreeks op
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Wijzigt het effect Text animation type naar "As One Object"
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // Wijzigt het effect Animate text type naar "By word"
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // Stelt de vertraging tussen woorden in op 20% van de effectduur
    firstEffect.setDelayBetweenTextParts(20.0);
    // Schrijft het PPTX‑bestand naar schijf
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Hoe zorg ik ervoor dat animaties behouden blijven bij het publiceren van de presentatie op het web?**

[Export to HTML5](/slides/nl/nodejs-java/export-to-html5/) en schakel de [options](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/html5options/) die verantwoordelijk zijn voor [shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/html5options/setanimateshapes/) en [transition](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/html5options/setanimatetransitions/) animaties in. Gewone HTML speelt dia‑animaties niet af, terwijl HTML5 dat wel doet.

**Hoe beïnvloedt het wijzigen van de z-order (laagvolgorde) van shapes animatie?**

Animatie‑ en tekenvolgorde zijn onafhankelijk: een effect bepaalt het moment en type van verschijnen/verdwijnen, terwijl [z-order](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getzorderposition/) bepaalt wat wat bedekt. Het zichtbare resultaat wordt gedefinieerd door hun combinatie. (Dit is het algemene gedrag van PowerPoint; het Aspose.Slides‑model voor effecten‑en‑shapes volgt dezelfde logica.)

**Zijn er beperkingen bij het converteren van animaties naar video voor bepaalde effecten?**

In het algemeen worden [animaties ondersteund](/slides/nl/nodejs-java/convert-powerpoint-to-video/), maar zeldzame gevallen of specifieke effecten kunnen anders worden gerenderd. Het wordt aanbevolen de gebruikte effecten en de bibliotheekversie te testen.