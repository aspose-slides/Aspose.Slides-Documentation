---
title: Beheer dia-overgangen in presentaties met JavaScript
linktitle: Dia-overgang
type: docs
weight: 80
url: /nl/nodejs-java/slide-transition/
keywords:
- dia-overgang
- dia-overgang toevoegen
- dia-overgang toepassen
- geavanceerde dia-overgang
- Morph-overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Pas dia-overgangen toe, configureer automatische voortgang van dia's en pas Morph en andere overgangseffecten aan met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Dia‑overgangen bepalen hoe dia's verschijnen tijdens een diavoorstelling. Met Aspose.Slides voor Node.js via Java kun je voor elke dia een overgangseffect kiezen, de voortgang via muisklik of timer configureren en opties aanpassen die specifiek zijn voor een effect. Dit artikel gebruikt JavaScript‑voorbeelden om overgangen toe te passen, exacte overgangsduren in te stellen, de timing van dia's te beheren en een Morph‑overgang tussen twee dia's te maken. De voorbeelden laten ook zien hoe je de instellingen opslaat in een PPTX‑bestand.

## **Dia‑overgang toevoegen**

Om een overgang toe te passen, laad je een presentatie met de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑klasse en krijg je toegang tot de overgangsinstellingen van de dia via [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Gebruik [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) met een waarde uit de [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/)‑enumeratie en sla vervolgens de presentatie op.

Het volgende voorbeeld past een Circle‑overgang toe op de eerste dia en een Comb‑overgang op de tweede. Gebruik een `input.pptx`‑bestand met minimaal twee dia's.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Wiel‑overgang**

De [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes)‑methode van [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) bepaalt het aantal radiale sectoren dat de doel‑dia onthult. Stel het overgangstype van de dia in op Wheel via [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) met behulp van [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) voordat je [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) benadert als [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/).

Dit voorbeeld maakt twee identieke paren dia's: een zwarte dia gevolgd door een dia met een gouden rechthoek. De doel‑dia's gebruiken respectievelijk 1 en 8 spaken, met dezelfde snelheid ingesteld via [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) en een expliciete duur van 8000 milliseconden ingesteld via [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) zodat het verschil gemakkelijk waarneembaar is.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Open de gegenereerde presentatie in PowerPoint en start de diavoorstelling. Ga van dia 1 naar dia 2, vervolgens van dia 3 naar dia 4. In de weergave van PowerPoint onthult het gecontroleerde aantal spaken van 1 de dia met één klokwijzerbeweging; het gecontroleerde aantal van 8 onthult deze via acht radiale sectoren tegelijk. De doelinhoud en de overgangstiming zijn identiek, dus het verschil zit in het aantal onthullingssectoren.

## **Vervagen naar zwart met de Reveal‑overgang**

Stel het overgangstype van de doel‑dia in op Reveal en roep vervolgens [setThroughBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/#setThroughBlack) aan op de [RevealTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/)‑instellingen. Dit voorbeeld maakt een teal bron‑dia en een koraal‑doel‑dia, waarna beide worden gekloond. Elk paar gebruikt dezelfde twee‑seconde Reveal‑overgang. Alleen het tweede paar vervaagt via zwart.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const source = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addClone(source);
    const teal = java.newInstanceSync("java.awt.Color", 0, 128, 128);
    const coral = java.newInstanceSync("java.awt.Color", 255, 127, 80);

    for (const [slide, color, label] of [[source, teal, "Source"], [destination, coral, "Destination"]]) {
        slide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
        const fill = slide.getBackground().getFillFormat();
        fill.setFillType(java.newByte(slides.FillType.Solid));
        fill.getSolidFillColor().setColor(color);

        const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 160, 180, 400, 130);
        const textFrame = shape.getTextFrame();
        textFrame.setText(label);
        textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    const clonedDestination = presentation.getSlides().addClone(destination);
    for (const slide of [destination, clonedDestination]) {
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Reveal);
        transition.setSpeed(slides.Transiti

onSpeed.Slow);
        transition.setDuration(2000);

        const reveal = transition.getValue();
        reveal.setDirection(slides.TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide === clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Open de opgeslagen presentatie in PowerPoint en start de diavoorstelling. Ga van dia 1 naar dia 2 om teal direct in coral te laten vervagen. Ga vervolgens van dia 3 naar dia 4. Het scherm wordt kort donker tot bijna zwart voordat de coral‑dia verschijnt. Beide dia's behouden hun oorspronkelijke achtergrondkleuren.

De onderstaande rijen tonen frames uit PowerPoint met intervallen van een halve seconde. Vergelijk het middelste frame in elke rij om het effect te zien.

![PowerPoint‑afspeel​weergave met de fade‑through‑black uitgeschakeld (boven) en ingeschakeld (onder). Alleen de onderste rij passeert bijna zwart.](reveal-through-black.png)

## **Geavanceerde dia‑overgang toevoegen**

Je kunt configureren hoe lang een dia op het scherm blijft en of een muisklik de diavoorstelling voortzet. De volgende methoden regelen dit gedrag:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) stelt de kijker in staat om door op de muis te klikken vooruit te gaan.
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) schakelt automatische voortgang in.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) geeft de vertraging vóór automatische voortgang op, in milliseconden.

Schakel zowel klikken als tijdsgebonden voortgang in zodat de kijker kan doorgaan met een klik of wachten op de timer. Om alleen de timer te gebruiken, geef `false` door aan [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). De vertraging bepaalt wanneer de diavoorstelling voortschrijdt; hij stelt niet de duur van het visuele overgangseffect in.

Dit voorbeeld kent verschillende effecten toe aan de eerste drie dia's en schakelt automatische voortgang in na respectievelijk 3, 5 en 7 seconden. Muisklikken kunnen deze dia's ook vooruit laten gaan. Gebruik een `input.pptx`‑bestand met minimaal drie dia's.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Om te controleren of tijdsgebonden voortgang is ingeschakeld, roep je [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) aan. Een opgeslagen vertraging alleen geeft niet aan dat de timer actief is.

Het volgende voorbeeld opent het hierboven opgeslagen bestand, meldt elke ingeschakelde timer en schakelt automatische voortgang uit voor dia's met een vertraging groter dan twee seconden. Het schakelt muiskliks in voor die dia's en slaat de bijgewerkte instellingen op.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Overgangstiming nauwkeurig regelen**

Gebruik [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) om de exacte lengte van een overgangseffect in milliseconden op te geven. De [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition)‑methode van de dia maakt deze instellingen toegankelijk via [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/):

| Methode | Doel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Stelt de vertraging in voordat de dia automatisch wordt voortgezet, in milliseconden. Geef `true` door aan [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) om deze timer te activeren. |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Selecteert een vooraf gedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium of Fast. Wordt gebruikt wanneer geen exacte duur is gespecificeerd. |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) beïnvloedt alleen het overgangseffect; hij bepaalt niet hoe lang de dia zichtbaar blijft. Configureer de automatische voortgangsvertraging apart. Wanneer geen expliciete duur is ingesteld, bepaalt Aspose.Slides de effectduur op basis van het overgangstype en de [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed)‑waarde.

<!-- visual-explanation:slide-transition:start -->
[![Aparte balken geven de 750‑ms overgangsduur en de 5000‑ms automatische voortgangsinstelling weer.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Het gedeelde voorbeeld geeft elke dia een 750‑ms Fade‑overgang en schakelt apart automatische voortgang in na 5000 ms in. De duur van de overgang bepaalt het effect; voortgang bepaalt wanneer de dia wordt verlaten. Deze balken zijn schematische instellingen, geen gemeten gecombineerde tijdlijn.*
<!-- visual-explanation:slide-transition:end -->

### **Dezelfde duur op elke dia toepassen**

Voor een consistente timing kun je hetzelfde effect en dezelfde exacte duur op elke dia toepassen. Dit voorbeeld laadt `input.pptx`, selecteert Fade uit [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) en geeft elke overgang een duur van 750 milliseconden. Het schakelt apart automatische voortgang in na 5000 milliseconden en schakelt voortgang via muisklik uit, waarna het resultaat wordt opgeslagen als PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Configureer automatische voortgang onafhankelijk van de effectduur.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Verschillende duurwaarden voor individuele dia's instellen**

Verschillende dia's kunnen verschillende effectduren hebben. Gebruik bijvoorbeeld een korte overgang voor een titeldia en een langere overgang voor een sectie‑introductie. Dit voorbeeld stelt 500 milliseconden in voor de eerste dia en 1200 milliseconden voor de tweede. Gebruik een `input.pptx`‑bestand met minimaal twee dia's.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Overgangen coördineren met geanimeerde output**

Bij het voorbereiden van een [animated GIF](/slides/nl/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/nl/nodejs-java/export-to-html5/), of [video](/slides/nl/nodejs-java/convert-powerpoint-to-video/), stel je exacte overgangsduren in vóór export om de beoogde timing te evenaren. Gebruik bijvoorbeeld een fade van 600 milliseconden tussen scènes en stel elke dia’s voortgangsvertraging apart in zodat er tijd is voor de bijbehorende voice‑over of inhoud.

Voor GIF en video stem je de uitvoer‑frame‑rate af op de effectduur: 600 milliseconden komt overeen met 18 frames bij 30 fps. In HTML5 schakel je geanimeerde overgangen in de exportinstellingen in. Controleer welke effecten en timingopties door het gekozen exportformaat worden ondersteund en bekijk een voorbeeld om de synchronisatie te bevestigen.

### **Een bestaande overgangsduur lezen**

Roep [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) aan voordat je de overgang wijzigt om te bepalen of er een expliciete waarde is opgeslagen. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden aan. De oningestelde waarde is niet de berekende afspeelduur: Aspose.Slides gebruikt het overgangstype en de [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed)‑waarde om die duur te bepalen. Het instellen van een overgangstype kan een duur initialiseren, dus inspecteer eerst de oorspronkelijke instellingen.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph‑overgang**

De Morph‑overgang animeert wijzigingen tussen objecten op opeenvolgende dia's. Om een eenvoudige Morph‑effect te maken, kloon je een dia, verplaats of wijzig je de grootte van een object op de kloon, en pas je de Morph‑overgang toe op de tweede dia. Dit geeft de overgang overeenkomstige objecten om te animeren tussen hun oorspronkelijke en gewijzigde toestand.

Het volgende voorbeeld maakt een dia met een tekst‑rechthoek, kloont de dia en wijzigt de positie en grootte van de rechthoek op de kloon. Vervolgens selecteert het Morph uit de [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/)‑enumeratie voor de tweede dia. Open het opgeslagen bestand in een presentatiewiewer die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph‑overgangstypen**

De [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/)‑enumeratie bepaalt hoe Morph inhoud koppelt en animeert:

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) behandelt elke vorm als een geheel object.
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) animeert tekst door woorden te koppelen waar mogelijk.
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) animeert tekst door tekens te koppelen waar mogelijk.

Gebruik [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) om Morph te selecteren voordat je [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) aanroept. De waarde levert vervolgens een [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/)‑object, waarvan de [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType)‑methode de koppelingsmodus selecteert.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Overgangseffecten instellen**

Sommige overgangen bieden extra opties, zoals richting of of het effect start vanaf een zwart scherm. De beschikbare opties hangen af van de overgang die met [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) is geselecteerd. Stel eerst het type in en gebruik vervolgens het juiste overgangsobject via [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue).

Het volgende voorbeeld past een Cut‑overgang toe op de eerste dia van `input.pptx`. Het roept [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) aan via [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) zodat de overgang start vanaf een zwart scherm.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan ik de afspeelsnelheid van een dia‑overgang regelen?**

Ja. Geef de voorkeur aan [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) wanneer je een exacte effectduur in milliseconden nodig hebt. Gebruik [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) wanneer een vooraf gedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/)‑categorie — Slow, Medium of Fast — voldoende is en er geen expliciete duur is ingesteld. Deze instellingen regelen het overgangseffect onafhankelijk van de automatische voortgangsvertraging.

**Kan ik audio aan een overgang toevoegen en laten herhalen?**

Ja. Ken ingesloten audio toe met [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound), geef `StartSound` uit de [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/)‑enumeratie door aan [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) en schakel [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) in met `true`. De audio blijft herhalen tot het volgende geluidsevenement in de diavoorstelling.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Loop door de [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides)‑collectie van de presentatie en roep voor elke dia [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) aan met dezelfde waarde. Stel eventuele timing‑ en effectopties in dezelfde lus in om het gedrag consistent te houden over alle dia's.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Roep [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) aan op het resultaat van [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) van de dia. Het retourneert een waarde uit de [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/)‑enumeratie; `None` betekent dat er geen overgangseffect is toegepast.