---
title: Beheer diaovergangen in presentaties met Java
linktitle: Diaovergang
type: docs
weight: 80
url: /nl/java/slide-transition/
keywords:
- diaovergang
- diaovergang toevoegen
- diaovergang toepassen
- geavanceerde diaovergang
- Morph‑overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Diaovergangen toepassen, automatische dia‑voortzetting configureren en Morph‑ en andere overgangseffecten aanpassen met Aspose.Slides voor Java."
---
## **Overzicht**

Diaovergangen bepalen hoe dia's verschijnen tijdens een diavoorstelling. Met Aspose.Slides for Java kun je voor elke dia een overgangseffect kiezen, de voortgang per muisklik of timer configureren en opties die specifiek zijn voor een effect aanpassen. Dit artikel gebruikt Java‑voorbeelden om overgangen toe te passen, exacte overgangsduren in te stellen, diatiming te beheren en een Morph‑overgang tussen twee dia's te maken. De voorbeelden laten ook zien hoe je de instellingen opslaat in een PPTX‑bestand.

## **Diaovergang toevoegen**

Om een overgang toe te passen, laad je een presentatie met de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse en krijg je via [getSlideShowTransition](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) toegang tot de overgangsinstellingen van de dia. Gebruik [setType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setType-int-) met een waarde uit de [TransitionType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/transitiontype/)-enumeratie, daarna sla je de presentatie op.

Het volgende voorbeeld past een Circle‑overgang toe op de eerste dia en een Comb‑overgang op de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia's.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Geavanceerde diaovergang toevoegen**

Je kunt configureren hoe lang een dia op het scherm blijft en of een muisklik de diavoorstelling voortzet. De volgende methoden regelen dit gedrag:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) laat de kijker de diavoorstelling voortzetten door te klikken.
- [setAdvanceAfter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) schakelt automatisch voortzetten in.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) geeft de vertraging vóór automatisch voortzetten op, in milliseconden.

Schakel zowel klikken als timer‑voortzetting in zodat de kijker kan doorgaan met een klik of kan wachten op de timer. Om alleen de timer te gebruiken, geef `false` door aan [setAdvanceOnClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). De vertraging bepaalt wanneer de diavoorstelling voortzet; hij stelt de duur van het visuele overgangseffect niet in.

Dit voorbeeld kent verschillende effecten toe aan de eerste drie dia's en schakelt automatisch voortzetten in na respectievelijk 3, 5 en 7 seconden. Muisklikken kunnen deze dia's ook voortzetten. Gebruik een `input.pptx`‑bestand met minstens drie dia's.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Om te controleren of timer‑voortzetting ingeschakeld is, roep je [getAdvanceAfter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) aan. Een opgeslagen vertraging alleen duidt niet aan dat de timer actief is.

Het volgende voorbeeld opent het hierboven opgeslagen bestand, meldt elke ingeschakelde timer en schakelt automatisch voortzetten uit voor dia's met een vertraging langer dan twee seconden. Voor die dia's wordt klikken ingeschakeld en worden de bijgewerkte instellingen opgeslagen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Overgangstiming nauwkeurig regelen**

Gebruik [setDuration](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setDuration-int-) om de exacte lengte van een overgangseffect in milliseconden op te geven. De [getSlideShowTransition](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--)‑methode van de dia maakt deze instellingen beschikbaar via [ISlideShowTransition](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/):

| Methode | Doel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Stelt de vertraging vóór automatisch voortzetten in, in milliseconden. Geef `true` door aan [setAdvanceAfter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) om deze timer te activeren. |
| [setSpeed](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Selecteert een voorgedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/nl/java/com.aspose.slides/transitionspeed/): Slow, Medium of Fast. Wordt gebruikt wanneer geen exacte duur is gespecificeerd. |

[setDuration](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setDuration-int-) beïnvloedt alleen het overgangseffect; hij bepaalt niet hoe lang de dia zichtbaar blijft. Configureer de automatische voortzettingsvertraging afzonderlijk. Wanneer geen expliciete duur is opgegeven, bepaalt Aspose.Slides de effectduur op basis van het overgangstype en de waarde van [getSpeed](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#getSpeed--).

### **Zelfde duur toepassen op elke dia**

Voor een gelijkmatig tempo pas je hetzelfde effect en dezelfde exacte duur toe op elke dia. Dit voorbeeld laadt `input.pptx`, selecteert Fade uit [TransitionType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/transitiontype/) en geeft elke overgang een duur van 750 milliseconden. Het schakelt automatisch voortzetten in na 5 000 milliseconden en schakelt voortzetten per muisklik uit, daarna slaat het resultaat op als PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Configureer automatische voortzetting onafhankelijk van de effectduur.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Verschillende duur per dia instellen**

Verschillende dia's kunnen verschillende effectduren hebben. Bijvoorbeeld een korte overgang voor een titel-dia en een langere overgang voor een sectie‑introductie. Dit voorbeeld stelt 500 milliseconden in voor de eerste dia en 1 200 milliseconden voor de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia's.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Overgangen coördineren met geanimeerde uitvoer**

Bij het voorbereiden van een [animated GIF](/slides/nl/java/convert-powerpoint-to-animated-gif/), een [HTML5 presentation](/slides/nl/java/export-to-html5/) of een [video](/slides/nl/java/convert-powerpoint-to-video/), stel je exacte overgangsduren in vóór export zodat ze overeenkomen met het gewenste tempo. Gebruik bijvoorbeeld een fade van 600 milliseconden tussen scènes en pas elke dia‑vervolgvertraging afzonderlijk aan om tijd te geven aan de bijbehorende voice‑over of inhoud.

Voor GIF en video stem je de frame‑rate af op de effectduur: 600 milliseconden komt overeen met 18 frames bij 30 fps. In HTML5 schakel je geanimeerde overgangen in de exportinstellingen in. Controleer de ondersteunde effecten en timingopties van het gekozen exportformaat en bekijk een preview om synchronisatie te bevestigen.

### **Bestaande overgangsduur lezen**

Roep [getDuration](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#getDuration--) aan vóór je de overgang wijzigt om te bepalen of er een expliciete waarde is opgeslagen. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden weer. De niet‑ingestelde waarde is niet de berekende afspeelduur: Aspose.Slides bepaalt de duur aan de hand van het overgangstype en de waarde van [getSpeed](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#getSpeed--). Het instellen van een overgangstype kan een duur initialiseren, dus inspecteer eerst de oorspronkelijke instellingen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph‑overgang**

De Morph‑overgang animeert wijzigingen tussen objecten op opeenvolgende dia's. Om een eenvoudige Morph‑effect te creëren, kloon je een dia, verplaats of wijzig je de grootte van een object op de kloon, en pas je de Morph‑overgang toe op de tweede dia. Hierdoor krijgt de overgang de overeenkomstige objecten om te animeren tussen hun oorspronkelijke en gewijzigde staat.

Het volgende voorbeeld maakt een dia met een tekst‑rechthoek, kloont de dia en wijzigt de positie en grootte van de rechthoek op de kloon. Vervolgens selecteert het Morph uit de [TransitionType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/transitiontype/)‑enumeratie voor de tweede dia. Open het opgeslagen bestand in een presentatieweergave die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph‑overgangstypen**

De [TransitionMorphType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/transitionmorphtype/)‑enumeratie bepaalt hoe Morph overeenkomt en animeert:

- [ByObject](https://reference.aspose.com/slides/nl/java/com.aspose.slides/transitionmorphtype/#ByObject) behandelt elke vorm als één geheel.
- [ByWord](https://reference.aspose.com/slides/nl/java/com.aspose.slides/transitionmorphtype/#ByWord) animeert tekst door woorden waar mogelijk te koppelen.
- [ByChar](https://reference.aspose.com/slides/nl/java/com.aspose.slides/transitionmorphtype/#ByChar) animeert tekst door tekens waar mogelijk te koppelen.

Gebruik [setType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setType-int-) om Morph te selecteren voordat je [getValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#getValue--) aanroept. De verkregen waarde levert de [IMorphTransition](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imorphtransition/)‑interface, waarvan de [setMorphType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imorphtransition/#setMorphType-int-)‑methode de koppelingsmodus kiest.

Dit voorbeeld opent de presentatie die in de vorige sectie is gemaakt en configureert de tweede dia om woordgebaseerde Morph‑animatie te gebruiken.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Overgangseffecten instellen**

Sommige overgangen bieden extra opties, zoals richting of of het effect start vanaf een zwart scherm. De beschikbare opties hangen af van de overgang die met [setType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setType-int-) is gekozen. Stel eerst het type in en gebruik vervolgens de juiste interface via [getValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#getValue--).

Het volgende voorbeeld past een Cut‑overgang toe op de eerste dia van `input.pptx`. Het roept [setFromBlack](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) aan via [IOptionalBlackTransition](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ioptionalblacktransition/) zodat de overgang start vanaf een zwart scherm.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **Veelgestelde vragen**

**Kan ik de afspeelsnelheid van een diaovergang regelen?**

Ja. Geef de voorkeur aan [setDuration](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setDuration-int-) wanneer je een exacte effectduur in milliseconden nodig hebt. Gebruik [setSpeed](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) wanneer een voorgedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/nl/java/com.aspose.slides/transitionspeed/)-categorie – Slow, Medium of Fast – volstaat en er geen expliciete duur is ingesteld. Deze instellingen regelen het overgangseffect onafhankelijk van de timer‑voortzettingsvertraging.

**Kan ik audio aan een overgang koppelen en laten loopen?**

Ja. Wijs ingesloten audio toe met [setSound](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), geef `StartSound` uit de [TransitionSoundMode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/transitionsoundmode/)-enumeratie door aan [setSoundMode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), en schakel [setSoundLoop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) in met `true`. Het geluid blijft loopen tot het volgende geluid‑event in de diavoorstelling.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Loop door de presentatie‑collectie [getSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSlides--) en roep voor elke dia [setType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#setType-int-) aan met dezelfde waarde. Stel eventuele timing‑ en effectopties binnen dezelfde lus in om het gedrag consistent te houden over alle dia's.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Roep [getType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islideshowtransition/#getType--) aan op het resultaat van de dia‑[getSlideShowTransition](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) methode. Het retourneert een waarde uit de [TransitionType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/transitiontype/)-enumeratie; `None` betekent dat er geen overgangseffect is toegepast.