---
title: Beheer dia‑overgangen in presentaties met JavaScript
linktitle: Dia‑overgang
type: docs
weight: 80
url: /nl/nodejs-java/slide-transition/
keywords:
- dia‑overgang
- dia‑overgang toevoegen
- dia‑overgang toepassen
- geavanceerde dia‑overgang
- morph‑overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Pas dia‑overgangen toe, configureer automatische voortzetting van dia’s, en pas Morph en andere overgangseffecten aan met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Dia‑overgangen bepalen hoe dia’s verschijnen tijdens een diavoorstelling. Met Aspose.Slides voor Node.js via Java kunt u een overgangseffect kiezen voor elke dia, de voortgang configureren via muisklik of timer, en opties aanpassen die specifiek zijn voor een effect. Dit artikel gebruikt JavaScript‑voorbeelden om overgangen toe te passen, exacte duur van overgangen in te stellen, diatiming te beheren en een Morph‑overgang tussen twee dia’s te creëren. De voorbeelden tonen ook hoe u de instellingen opslaat naar een PPTX‑bestand.

## **Dia‑overgang toevoegen**

Om een overgang toe te passen, laad een presentatie met de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse en krijg toegang tot de overgangsinstellingen van de dia via [getSlideShowTransition](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Gebruik [setType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setType) met een waarde uit de [TransitionType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/transitiontype/)‑enumeratie, sla daarna de presentatie op.

Het volgende voorbeeld past een Circle‑overgang toe op de eerste dia en een Comb‑overgang op de tweede. Gebruik een `input.pptx`‑bestand met ten minste twee dia’s.

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

## **Geavanceerde dia‑overgang toevoegen**

U kunt configureren hoe lang een dia zichtbaar blijft en of een muisklik de diavoorstelling voortzet. De volgende methoden bepalen dit gedrag:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) laat de kijker de presentatie voortzetten door te klikken met de muis.
- [setAdvanceAfter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) schakelt automatische voortzetting in.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) geeft de vertraging vóór automatische voortzetting op, in milliseconden.

Schakel zowel klik‑ als timer‑voortzetting in zodat de kijker kan doorgaan met een klik of wachten op de timer. Om alleen de timer te gebruiken, geef `false` door aan [setAdvanceOnClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). De vertraging bepaalt wanneer de diavoorstelling wordt voortgezet; hij stelt niet de duur van het visuele overgangseffect in.

Dit voorbeeld kent verschillende effecten toe aan de eerste drie dia’s en schakelt automatische voortzetting in na respectievelijk 3, 5 en 7 seconden. Muisklikken kunnen deze dia’s ook voortzetten. Gebruik een `input.pptx`‑bestand met ten minste drie dia’s.

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

Om te controleren of timer‑voortzetting is ingeschakeld, roep [getAdvanceAfter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) aan. Een opgeslagen vertraging alleen geeft niet aan dat de timer actief is.

Het volgende voorbeeld opent het hierboven opgeslagen bestand, meldt elke ingeschakelde timer en schakelt automatische voortzetting uit voor dia’s met een vertraging groter dan twee seconden. Het zet muisklik‑voortzetting aan voor die dia’s en slaat de bijgewerkte instellingen op.

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

Gebruik [setDuration](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setDuration) om de exacte lengte van een overgangseffect in milliseconden op te geven. De dia‑methode [getSlideShowTransition](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) maakt deze instellingen beschikbaar via [SlideShowTransition](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/) :

| Methode | Doel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Stelt de vertraging vóór automatische voortzetting van de dia in, in milliseconden. Geef `true` door aan [setAdvanceAfter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) om deze timer te activeren. |
| [setSpeed](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Selecteert een vooraf gedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/transitionspeed/) : Slow, Medium of Fast. Wordt gebruikt wanneer geen exacte duur is opgegeven. |

[setDuration](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setDuration) regelt alleen het overgangseffect; hij bepaalt niet hoe lang de dia zichtbaar blijft. Configureer de automatische voortzettings‑vertraging apart. Wanneer geen expliciete duur is ingesteld, bepaalt Aspose.Slides de effectduur aan de hand van het overgangstype en de [getSpeed](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#getSpeed)‑waarde.

### **Dezelfde duur toepassen op elke dia**

Voor een gelijkmatige timing past u hetzelfde effect en dezelfde exacte duur toe op elke dia. Dit voorbeeld laadt `input.pptx`, selecteert Fade uit [TransitionType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/transitiontype/) en geeft elke overgang een duur van 750 milliseconden. Het schakelt daarnaast automatische voortzetting in na 5 000 milliseconden en schakelt voortzetting via muisklik uit, waarna het resultaat als PPTX wordt opgeslagen.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Configureer automatische voortzetting onafhankelijk van de effectduur.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Verschillende duur per afzonderlijke dia**

Verschillende dia’s kunnen verschillende effectduur hebben. Bijvoorbeeld een korte overgang voor een titeldia en een langere overgang voor een sectie‑introductie. Dit voorbeeld stelt 500 milliseconden in voor de eerste dia en 1 200 milliseconden voor de tweede. Gebruik een `input.pptx`‑bestand met ten minste twee dia’s.

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

### **Overgangen afstemmen op geanimeerde uitvoer**

Wanneer u een [animated GIF](/slides/nl/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5‑presentatie](/slides/nl/nodejs-java/export-to-html5/) of [video](/slides/nl/nodejs-java/convert-powerpoint-to-video/) voorbereidt, stelt u exacte overgangsduren in vóór export om de gewenste timing te bereiken. Gebruik bijvoorbeeld een fade van 600 milliseconden tussen scènes en pas elke dia‑voortzettings‑vertraging afzonderlijk aan om tijd te bieden voor de bijbehorende voice‑over of inhoud.

Voor GIF en video stemt u de framesnelheid van de uitvoer af op de effectduur: 600 milliseconden komt overeen met 18 frames bij 30 fps. In HTML5 schakelt u geanimeerde overgangen in de exportinstellingen in. Controleer de ondersteunde effecten en timing‑opties van het gekozen exportformaat en bekijk een preview om synchronisatie te bevestigen.

### **Bestaande overgangsduur uitlezen**

Roep [getDuration](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#getDuration) aan vóór het wijzigen van de overgang om te bepalen of er een expliciete waarde is opgeslagen. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden aan. De niet‑ingestelde waarde is niet de berekende afspeelduur: Aspose.Slides bepaalt die duur aan de hand van het overgangstype en de [getSpeed](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#getSpeed)‑waarde. Het instellen van een overgangstype kan een duur initialiseren, controleer dus eerst de oorspronkelijke instellingen.

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

De Morph‑overgang animeert wijzigingen tussen objecten op opeenvolgende dia’s. Om een eenvoudige Morph‑animatie te maken, kloont u een dia, verplaatst of schaalt u een object op de kloon, en past u de Morph‑overgang toe op de tweede dia. Zo krijgt de overgang de corresponderende objecten om te animeren tussen hun oorspronkelijke en gewijzigde toestand.

Het volgende voorbeeld maakt een dia met een tekst‑rechthoek, kloont de dia en wijzigt de positie en grootte van de rechthoek op de kloon. Vervolgens selecteert het Morph uit de [TransitionType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/transitiontype/)‑enumeratie voor de tweede dia. Open het opgeslagen bestand in een presentatie‑viewer die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

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

De [TransitionMorphType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/transitionmorphtype/)‑enumeratie bepaalt hoe Morph inhoud overeenkomt en animeert:

- [ByObject](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) behandelt elke vorm als één object.
- [ByWord](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) animeert tekst door waar mogelijk woorden overeen te laten komen.
- [ByChar](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) animeert tekst door waar mogelijk tekens overeen te laten komen.

Gebruik [setType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setType) om Morph te selecteren voordat u [getValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#getValue) aanroept. De waarde levert vervolgens een [MorphTransition](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/morphtransition/)‑object, waarvan de [setMorphType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/morphtransition/#setMorphType)‑methode de overeenkomstmethode selecteert.

Dit voorbeeld opent de presentatie die in de vorige sectie is aangemaakt en configureert de tweede dia om een op woorden gebaseerde Morph‑animatie te gebruiken.

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

Sommige overgangen bieden extra opties, zoals richting of of het effect start vanaf een zwart scherm. De beschikbare opties hangen af van de overgang die met [setType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setType) is geselecteerd. Stel eerst het type in en gebruik daarna het juiste overgangsobject via [getValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#getValue).

Het volgende voorbeeld past een Cut‑overgang toe op de eerste dia van `input.pptx`. Het roept [setFromBlack](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) aan via [OptionalBlackTransition](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/optionalblacktransition/) zodat de overgang start vanaf een zwart scherm.

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

Ja. Geef de voorkeur aan [setDuration](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setDuration) wanneer u een exacte effectduur in milliseconden nodig heeft. Gebruik [setSpeed](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) wanneer een vooraf gedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/transitionspeed/)‑categorie – Slow, Medium of Fast – voldoende is en er geen expliciete duur is ingesteld. Deze instellingen beïnvloeden het overgangseffect onafhankelijk van de automatische voortzettings‑vertraging.

**Kan ik audio aan een overgang koppelen en laten herhalen?**

Ja. Wijs ingebedde audio toe met [setSound](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setSound), geef `StartSound` uit de [TransitionSoundMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/transitionsoundmode/)‑enumeratie door aan [setSoundMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode), en activeer [setSoundLoop](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) met `true`. De audio blijft herhalen tot het volgende geluidsevent in de diavoorstelling.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Loop door de [getSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getSlides)‑collectie van de presentatie en roep voor elke dia [setType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#setType) aan met dezelfde waarde. Stel eventuele timing‑ en effectopties in dezelfde lus in om het gedrag consistent te houden over alle dia’s.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Roep [getType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowtransition/#getType) aan op het resultaat van de dia‑[getSlideShowTransition](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Het retourneert een waarde uit de [TransitionType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/transitiontype/)‑enumeratie; None betekent dat er geen overgangseffect is toegepast.