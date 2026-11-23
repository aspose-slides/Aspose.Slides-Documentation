---
title: Beheer dia‑overgangen in presentaties op Android
linktitle: Dia‑overgang
type: docs
weight: 80
url: /nl/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "Pas dia‑overgangen toe, configureer automatische voortzetting van dia's, en pas Morph en andere overgangseffecten aan met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Dia‑overgangen bepalen hoe dia's verschijnen tijdens een diavoorstelling. Met Aspose.Slides voor Android via Java kunt u een overgangseffect kiezen voor elke dia, de voortgang instellen via muisklik of timer, en opties aanpassen die specifiek zijn voor een effect. Dit artikel gebruikt Java‑voorbeelden om overgangen toe te passen, exacte overgangsduren in te stellen, de timing van dia's te beheren en een Morph‑overgang tussen twee dia's te maken. De voorbeelden laten ook zien hoe u de instellingen opslaat in een PPTX‑bestand.

## **Dia‑overgang toevoegen**

Om een overgang toe te passen, laadt u een presentatie met de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑klasse en krijgt u via [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) toegang tot de overgangsinstellingen van de dia. Gebruik [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) met een waarde uit de enumeratie [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/), en sla vervolgens de presentatie op.

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

## **Wiel‑overgang**

De [setSpokes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/#setSpokes-long-)‑methode van [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) bepaalt het aantal radiale sectoren dat de doel‑dia onthult. Stel het overgangstype van de dia in op Wheel via [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) met [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) voordat u via [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) toegang krijgt tot [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/).

Dit voorbeeld maakt twee identieke paren van dia's: een zwarte dia gevolgd door een dia met een gouden rechthoek. De doel‑dia's gebruiken spreekwaarden van 1 en 8, met dezelfde snelheid ingesteld via [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) en een expliciete duur van 8 000 milliseconden ingesteld via [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) om het verschil goed waar te nemen.

```java
import android.graphics.Color;
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
    int gold = Color.rgb(255, 215, 0);
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

Open de uitvoerpresentatie in PowerPoint en start de diavoorstelling. Ga van dia 1 naar dia 2, vervolgens van dia 3 naar dia 4. In PowerPoint‑afspelen onthult de geverifieerde spreekwaarde van 1 de dia met één klokwijzerzinbeweging; de geverifieerde waarde van 8 onthult deze via acht radiale sectoren tegelijk. De inhoud van de doel‑dia en de overgangstiming zijn identiek, dus het verschil zit in het aantal onthullingssectoren.

## **Fade naar zwart met de Reveal‑overgang**

Stel het overgangstype van de doel‑dia in op Reveal en roep vervolgens [setThroughBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) aan op de instellingen van [IRevealTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/). Het voorbeeld maakt een teal‑brondia en een coral‑doeldia, klont vervolgens beide. Elk paar gebruikt dezelfde twee‑seconden‑Reveal‑overgang. Alleen het tweede paar vervaagt via zwart.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    int[] backgrounds = { Color.rgb(0, 128, 128), Color.rgb(255, 127, 80) };
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

Open de opgeslagen presentatie in PowerPoint en start de diavoorstelling. Ga van dia 1 naar dia 2 om teal rechtstreeks in coral te laten vervagen. Ga vervolgens van dia 3 naar dia 4. Het scherm verduistert kort tot bijna zwart voordat de coral‑dia verschijnt. Beide dia's behouden hun oorspronkelijke achtergrondkleuren.

De rijen hieronder tonen frames uit PowerPoint met intervallen van een halve seconde. Vergelijk het middelste frame in elke rij om het effect te zien.

![PowerPoint‑weergave met het faden door zwart uitgeschakeld (boven) en ingeschakeld (onder). Alleen de onderste rij gaat door bijna zwart.](reveal-through-black.png)

## **Geavanceerde dia‑overgang toevoegen**

U kunt configureren hoe lang een dia op het scherm blijft en of een muisklik de diavoorstelling voortzet. De volgende methoden bepalen dit gedrag:

- [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) laat de kijker de diavoorstelling voortzetten door te klikken.
- [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) schakelt automatische voortzetting in.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) specificeert de wachttijd vóór automatische voortzetting, in milliseconden.

Schakel zowel klik‑ als timer‑voortzetting in zodat de kijker kan doorgaan met een klik of moet wachten op de timer. Om alleen de timer te gebruiken, geef `false` door aan [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). De vertraging bepaalt wanneer de diavoorstelling voortzet; hij stelt de duur van het visuele overgangseffect niet in.

Dit voorbeeld kent verschillende effecten toe aan de eerste drie dia's en schakelt automatische voortzetting in na respectievelijk 3, 5 en 7 seconden. Muisklikken kunnen deze dia's ook voortzetten. Gebruik een `input.pptx`‑bestand met ten minste drie dia's.

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

Om te controleren of timer‑voortzetting ingeschakeld is, roep [getAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) aan. Een opgeslagen vertraging op zich geeft niet aan dat de timer actief is.

Het volgende voorbeeld opent het hierboven opgeslagen bestand, meldt elke ingeschakelde timer, en schakelt automatische voortzetting uit voor dia's met een vertraging groter dan twee seconden. Het schakelt muisklikken voor die dia's in en slaat de bijgewerkte instellingen op.

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

Gebruik [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) om de exacte lengte van een overgangseffect in milliseconden te specificeren. De [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--)‑methode van de dia maakt deze instellingen beschikbaar via [ISlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/):

| Methode | Doel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Stelt de vertraging in vóór automatische voortzetting van de dia, in milliseconden. Geef `true` door aan [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) om deze timer te activeren. |
| [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Selecteert een voorgedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/): Slow, Medium of Fast. Wordt gebruikt wanneer geen exacte duur is opgegeven. |

[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) beïnvloedt alleen het overgangseffect; hij bepaalt niet hoe lang de dia zichtbaar blijft. Configureer de automatische voortzetting apart. Wanneer geen expliciete duur is ingesteld, bepaalt Aspose.Slides de effectduur aan de hand van het overgangstype en de waarde van [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Het gedeelde voorbeeld geeft elke dia een Fade‑overgang van 750 ms en schakelt automatisch voortzetten in na 5 000 ms. De duur van de overgang bepaalt het effect; de voortzetting bepaalt wanneer de dia wordt verlaten. Deze balken zijn schematische instellingen, geen gemeten gecombineerde tijdlijn.*
<!-- visual-explanation:slide-transition:end -->

### **Dezelfde duur toepassen op elke dia**

Voor een gelijk tempo past u hetzelfde effect en dezelfde exacte duur toe op elke dia. Dit voorbeeld laadt `input.pptx`, selecteert Fade uit [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/), en geeft elke overgang een duur van 750 milliseconden. Het schakelt automatisch voortzetten in na 5 000 milliseconden en schakelt voortzetting via muisklik uit, waarna het resultaat als PPTX wordt opgeslagen.

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

### **Verschillende duur instellen voor individuele dia's**

Dia's kunnen verschillende effectduren gebruiken. Bijvoorbeeld een korte overgang voor een titel‑dia en een langere overgang voor een sectie‑introductie. Dit voorbeeld stelt 500 milliseconden in voor de eerste dia en 1 200 milliseconden voor de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia's.

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

Wanneer u een [animated GIF](/slides/nl/androidjava/convert-powerpoint-to-animated-gif/), een [HTML5‑presentatie](/slides/nl/androidjava/export-to-html5/) of een [video](/slides/nl/androidjava/convert-powerpoint-to-video/) voorbereidt, stelt u exacte overgangsduren in vóór export zodat de timing overeenkomt met de gewenste pacing. Gebruik bijvoorbeeld een fade van 600 milliseconden tussen scènes, en stel de voortzettingstijd van elke dia apart in om voldoende tijd te geven voor de narratie of inhoud.

Voor GIF‑ en video‑output stemt u de framesnelheid af op de effectduur: 600 milliseconden komt overeen met 18 frames bij 30 fps. In HTML5 schakelt u geanimeerde overgangen in de export‑instellingen in. Controleer welke effecten en timing‑opties door het gekozen exportformaat worden ondersteund en bekijk een voorbeeld om de synchronisatie te verifiëren.

### **Bestaande overgangsduur lezen**

Roep [getDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) aan vóór het aanpassen van de overgang om te bepalen of er een expliciete waarde is opgeslagen. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden weer. De oningestelde waarde is niet de berekende afspeelduur: Aspose.Slides gebruikt het overgangstype en de waarde van [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) om die duur te bepalen. Het instellen van een overgangstype kan een duur initialiseren, dus inspecteer eerst de oorspronkelijke instellingen.

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

De Morph‑overgang animeert wijzigingen tussen objecten op opeenvolgende dia's. Om een eenvoudige Morph‑effect te maken, kloont u een dia, verplaatst of schaalt u een object op de kloon, en past u de Morph‑overgang toe op de tweede dia. Dit geeft de overgang de bijbehorende objecten om te animeren tussen hun oorspronkelijke en gewijzigde status.

Het volgende voorbeeld maakt een dia met een tekst‑rechthoek, kloont de dia, en wijzigt positie en grootte van de rechthoek op de kloon. Vervolgens selecteert het Morph uit de [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/)‑enumeratie voor de tweede dia. Open het opgeslagen bestand in een presentatieweergave die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

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

De enumeratie [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/) bepaalt hoe Morph inhoud overeenkomt en animeert:

- [ByObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) behandelt elke vorm als één geheel object.
- [ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) animeert tekst door woorden te matchen waar mogelijk.
- [ByChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) animeert tekst door karakters te matchen waar mogelijk.

Gebruik [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) om Morph te selecteren voordat u [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) aanspreekt. De verkregen waarde levert de [IMorphTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/)‑interface, waarvan de [setMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-)‑methode de overeenkomende modus kiest.

Dit voorbeeld opent de presentatie die in de vorige sectie werd gemaakt en configureert de tweede dia om woordgebaseerde Morph‑animatie te gebruiken.

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

Sommige overgangen bieden extra opties, zoals richting of of het effect start vanaf een zwart scherm. De beschikbare opties hangen af van de overgang die met [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) is geselecteerd. Stel eerst het type in en gebruik daarna de juiste interface via [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--).

Het volgende voorbeeld past een Cut‑overgang toe op de eerste dia van `input.pptx`. Het roept [setFromBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) aan via [IOptionalBlackTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/) zodat de overgang start vanaf een zwart scherm.

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

Ja. Geef de voorkeur aan [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) wanneer u een exacte effectduur in milliseconden nodig heeft. Gebruik [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) wanneer een vooraf gedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/)‑categorie—Slow, Medium of Fast—voldoende is en er geen expliciete duur is ingesteld. Deze instellingen regelen het overgangseffect onafhankelijk van de automatische voortzettingstimer.

**Kan ik audio aan een overgang toevoegen en laten herhalen?**

Ja. Koppel ingebedde audio met [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), geef **StartSound** uit de [TransitionSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionsoundmode/)‑enumeratie door aan [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-), en schakel [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) in met `true`. Het geluid blijft herhalen tot het volgende geluidsevenement in de diavoorstelling.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Loop door de collectie van de presentatie via [getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) en roep [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) aan met dezelfde waarde voor elke dia‑overgang. Stel eventuele timing‑ en effectopties in dezelfde lus in om het gedrag consistent te houden over alle dia's.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Roep [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getType--) aan op het resultaat van [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) van de dia. Het retourneert een waarde uit de enumeratie [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/); **None** betekent dat er geen overgangseffect is toegepast.