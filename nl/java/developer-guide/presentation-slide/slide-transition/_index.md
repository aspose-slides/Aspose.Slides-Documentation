---
title: Diaovergangen beheren in presentaties met Java
linktitle: Diaovergang
type: docs
weight: 80
url: /nl/java/slide-transition/
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
- Java
- Aspose.Slides
description: "Pas diaovergangen toe, configureer automatische dia-voortzetting en pas Morph en andere overgangseffecten aan met Aspose.Slides voor Java."
---
## **Overzicht**

Diaovergangen bepalen hoe dia's verschijnen tijdens een diavoorstelling. Met Aspose.Slides voor Java kunt u een overgangseffect voor elke dia kiezen, de voortgang per muisklik of timer configureren, en opties die specifiek zijn voor een effect aanpassen. Dit artikel gebruikt Java‑voorbeelden om overgangen toe te passen, exacte overdrachtsduur in te stellen, diatiming te beheren en een Morph‑overgang tussen twee dia's te creëren. De voorbeelden tonen ook hoe de instellingen naar een PPTX‑bestand kunnen worden opgeslagen.

## **Diaovergang toevoegen**

Om een overgang toe te passen, laadt u een presentatie met de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑klasse en benadert u de overgangsinstellingen van de dia via [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Gebruik [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) met een waarde uit de [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/)-enumeratie, sla daarna de presentatie op.

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

## **Wheel‑overgang**

De [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-)‑methode van [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) bepaalt het aantal radiale sectoren dat de doel-dia onthult. Stel het overgangstype van de dia in op Wheel via [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) met [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) vóór toegang tot [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) als [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/).

Dit voorbeeld maakt twee identieke dia‑paren: een zwarte dia gevolgd door een dia met een gouden rechthoek. De doel-dia’s gebruiken respectievelijk 1 en 8 spokes, met dezelfde snelheid ingesteld via [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) en een expliciete duur van 8 000 milliseconden ingesteld via [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) om het verschil duidelijk te maken.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    Color gold = new Color(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Open de uitvoerpresentatie in PowerPoint en start de diavoorstelling. Ga van dia 1 naar dia 2 en daarna van dia 3 naar dia 4. In de PowerPoint‑afspeelmethode onthult de gecontroleerde spoke‑waarde van 1 de dia met één klokwijzer‑beweging; de waarde van 8 onthult de dia via acht radiale sectoren tegelijk. De inhoud en overgangstiming van de doel‑dia’s zijn identiek, dus het verschil zit in het aantal onthullingssectoren.

## **Fade Through Black met de Reveal‑overgang**

Stel het overgangstype van de doel‑dia in op Reveal en roep vervolgens [setThroughBlack](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) aan op de [IRevealTransition](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/)‑instellingen. Het voorbeeld maakt een teal‑bron‑dia en een coral‑doel‑dia, en kloont beide. Elk paar gebruikt dezelfde twee‑seconden Reveal‑overgang. Alleen het tweede paar vervaagt via zwart.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    Color[] backgrounds = { new Color(0, 128, 128), new Color(255, 127, 80) };
    String[] labels = { "Source", "Destination" };

    for (int i = 0; i < slides.length; i++) {
        ISlide slide = slides[i];
        slide.getBackground().setType(BackgroundType.OwnBackground);
        slide.getBackground().getFillFormat().setFillType(FillType.Solid);
        slide.getBackground().getFillFormat().getSolidFillColor().setColor(backgrounds[i]);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
        shape.getTextFrame().setText(labels[i]);
        shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    ISlide clonedDestination = presentation.getSlides().addClone(destination);
    for (ISlide slide : new ISlide[] { destination, clonedDestination }) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Reveal);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(2000);

        IRevealTransition reveal = (IRevealTransition) transition.getValue();
        reveal.setDirection(TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide == clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Open de opgeslagen presentatie in PowerPoint en start de diavoorstelling. Ga van dia 1 naar dia 2 om teal direct in coral te laten vervagen. Ga vervolgens van dia 3 naar dia 4. Het scherm verduistert kort naar bijna zwart voordat de coral‑dia verschijnt. Beide dia’s behouden hun oorspronkelijke achtergrondkleur.

De rijen hieronder tonen frames uit PowerPoint met intervallen van een halve seconde. Vergelijk het middelste frame in elke rij om het effect te zien.

![PowerPoint‑afspeelmethode met de fade through black uitgeschakeld (boven) en ingeschakeld (onder). Alleen de onderste rij gaat door een bijna zwarte fase.](reveal-through-black.png)

## **Geavanceerde dia‑overgang toevoegen**

U kunt configureren hoe lang een dia op het scherm blijft en of een muisklik de diavoorstelling voortzet. De volgende methoden regelen dit gedrag:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) laat de kijker de presentatie voortzetten door te klikken.
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) schakelt automatische voortzetting in.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) specificeert de vertraging vóór automatische voortzetting, in milliseconden.

Schakel zowel klikken als timer‑voortzetting in zodat de kijker kan doorgaan met een klik of wachten op de timer. Om alleen de timer te gebruiken, geef `false` door aan [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). De vertraging bepaalt wanneer de diavoorstelling voortzet; hij stelt de duur van het visuele overgangseffect niet in.

Dit voorbeeld kent verschillende effecten toe aan de eerste drie dia’s en schakelt automatische voortzetting in na respectievelijk 3, 5 en 7 seconden. Muisklikken kunnen deze dia’s ook voortzetten. Gebruik een `input.pptx`‑bestand met minstens drie dia’s.

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

Om te controleren of timer‑voortzetting is ingeschakeld, roep [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) aan. Een opgeslagen vertraging op zich geeft niet aan dat de timer actief is.

Het volgende voorbeeld opent het hierboven opgeslagen bestand, meldt elke ingeschakelde timer, en schakelt automatische voortzetting uit voor dia’s met een vertraging groter dan twee seconden. Het schakelt muisklikken in voor die dia’s en slaat de bijgewerkte instellingen op.

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

Gebruik [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) om de exacte lengte van een overgangseffect in milliseconden op te geven. De [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--)‑methode van de dia exposeert deze instellingen via [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/):

| Methode | Doel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Stelt de vertraging in voordat de dia automatisch wordt voortgezet, in milliseconden. Geef `true` door aan [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) om deze timer te activeren. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Selecteert een vooraf gedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/): Slow, Medium of Fast. Wordt gebruikt wanneer geen exacte duur is opgegeven. |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) regelt alleen het overgangseffect; hij bepaalt niet hoe lang de dia zichtbaar blijft. Configureer de automatische voortzettingsvertraging apart. Wanneer geen expliciete duur is ingesteld, bepaalt Aspose.Slides de effectduur aan de hand van het overgangstype en de [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--)‑waarde.

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Het gedeelde voorbeeld geeft elke dia een 750‑ms Fade‑overgang en schakelt afzonderlijk automatische voortzetting in na 5 000 ms. De overgangsdduur beheert het effect; de voortzetting bepaalt wanneer de dia wordt verlaten. Deze balken zijn schematische instellingen, geen gemeten gecombineerde tijdlijn.*
<!-- visual-explanation:slide-transition:end -->

### **Dezelfde duur op elke dia toepassen**

Voor een consistente timing, pas hetzelfde effect en exact dezelfde duur toe op elke dia. Dit voorbeeld laadt `input.pptx`, selecteert Fade uit [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/), en geeft elke overgang een duur van 750 milliseconden. Het schakelt bovendien automatische voortzetting in na 5 000 milliseconden en schakelt voortzetting per muisklik uit, en slaat het resultaat op als PPTX.

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

### **Verschillende duur per individuele dia instellen**

Dia’s kunnen verschillende effectduren gebruiken. Bijvoorbeeld: gebruik een korte overgang voor een titel‑dia en een langere overgang voor een sectie‑introductie. Dit voorbeeld stelt 500 milliseconden in voor de eerste dia en 1 200 milliseconden voor de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia’s.

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

### **Overgangen coördineren met geanimeerde output**

Bij het voorbereiden van een [animated GIF](/slides/nl/java/convert-powerpoint-to-animated-gif/), een [HTML5 presentation](/slides/nl/java/export-to-html5/), of een [video](/slides/nl/java/convert-powerpoint-to-video/), stel exacte overgangsduren in vóór export zodat het tempo overeenkomt met de bedoeling. Bijvoorbeeld: gebruik een fade van 600 ms tussen scènes, en pas elke dia‑voortzettingsvertraging apart aan om tijd te geven voor de bijbehorende voice‑over of inhoud.

Voor GIF en video stemt u de uitvoer‑frame‑rate af op de effectduur: 600 ms komt overeen met 18 frames bij 30 fps. In HTML5 schakelt u geanimeerde overgangen in via de exportinstellingen. Controleer de ondersteunde effecten en timingopties van het gekozen exportformaat en bekijk een voorbeeld om synchronisatie te bevestigen.

### **Bestaande overgangsduur uitlezen**

Roep [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) aan vóór u de overgang wijzigt om te bepalen of er een expliciete waarde is opgeslagen. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden weer. De niet‑ingestelde waarde is niet de berekende afspeelduur: Aspose.Slides gebruikt het overgangstype en de [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--)‑waarde om die duur te bepalen. Het instellen van een overgangstype kan een duur initialiseren, dus inspecteer eerst de oorspronkelijke instellingen.

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

De Morph‑overgang animeert wijzigingen tussen objecten op opeenvolgende dia’s. Om een eenvoudige Morph‑effect te maken, kloont u een dia, verplaatst of schaalt u een object op de kloon, en past u de Morph‑overgang toe op de tweede dia. Hierdoor worden de corresponderende objecten geanimeerd tussen hun oorspronkelijke en gewijzigde toestand.

Het volgende voorbeeld maakt een dia met een tekstrechthoek, kloont de dia, en wijzigt de positie en grootte van de rechthoek op de kloon. Het selecteert vervolgens Morph uit de [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/)‑enumeratie voor de tweede dia. Open het opgeslagen bestand in een presentatie‑viewer die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

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

De [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/)‑enumeratie bepaalt hoe Morph overeenkomt en animeert:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) behandelt elke vorm als één object.
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) animeert tekst door woorden waar mogelijk te koppelen.
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) animeert tekst door tekens waar mogelijk te koppelen.

Gebruik [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) om Morph te selecteren vóór toegang tot [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--). De verkregen waarde levert de [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/)‑interface, waarvan de [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-)‑methode de koppelmethode kiest.

Dit voorbeeld opent de presentatie die in de vorige sectie is gemaakt en configureert de tweede dia om woord‑gebaseerde Morph‑animatie te gebruiken.

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

Sommige overgangen bieden extra opties, zoals richting of of het effect start vanaf een zwart scherm. De beschikbare opties hangen af van de overgang die met [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) is gekozen. Stel eerst het type in, en gebruik daarna de juiste interface via [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--).

Het volgende voorbeeld past een Cut‑overgang toe op de eerste dia van `input.pptx`. Het roept [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) aan via [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) zodat de overgang start vanaf een zwart scherm.

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

## **FAQ**

**Kan ik de afspeelsnelheid van een dia‑overgang regelen?**

Ja. Geef de voorkeur aan [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) wanneer u een exacte effectduur in milliseconden nodig heeft. Gebruik [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) wanneer een vooraf gedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/)‑categorie – Slow, Medium of Fast – voldoende is en er geen expliciete duur is ingesteld. Deze instellingen regelen het overgangseffect onafhankelijk van de automatische voortzettingsvertraging.

**Kan ik audio aan een overgang koppelen en laten herhalen?**

Ja. Ken een ingebedde audio toe met [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), geef StartSound uit de [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/)‑enumeratie door aan [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), en schakel [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) in met `true`. Het geluid blijft herhalen tot het volgende geluidsevenement in de diavoorstelling.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Loop door de [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--)‑collectie van de presentatie en roep [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) aan met dezelfde waarde voor de overgang van elke dia. Stel eventuele timing‑ en effectopties in dezelfde loop in om het gedrag consistent te houden over alle dia’s.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Roep [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) aan op het resultaat van [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) van de dia. Het retourneert een waarde uit de [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/)‑enumeratie; None betekent dat er geen overgangseffect is toegepast.