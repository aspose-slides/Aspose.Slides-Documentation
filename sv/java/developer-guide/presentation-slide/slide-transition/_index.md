---
title: Hantera bildövergångar i presentationer med Java
linktitle: Bildövergång
type: docs
weight: 80
url: /sv/java/slide-transition/
keywords:
- bildövergång
- lägg till bildövergång
- tillämpa bildövergång
- avancerad bildövergång
- morph‑övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Tillämpa bildövergångar, konfigurera automatiskt bildavancemang och anpassa Morph och andra övergångseffekter med Aspose.Slides för Java."
---
## **Översikt**

Bildövergångar styr hur bilder visas under en bildspelsvisning. Med Aspose.Slides för Java kan du välja en övergångseffekt för varje bild, konfigurera avancemang med musklick eller timer och justera alternativ som är specifika för en effekt. Denna artikel använder Java‑exempel för att tillämpa övergångar, ange exakt övergångstid, hantera bildtid och skapa en Morph‑övergång mellan två bilder. Exemplen visar också hur man sparar inställningarna till en PPTX‑fil.

## **Lägg till bildövergång**

För att tillämpa en övergång, läs in en presentation med klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) och nå bildens övergångsinställningar via [getSlideShowTransition](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Använd [setType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setType-int-) med ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/transitiontype/), spara sedan presentationen.

Följande exempel tillämpar en Circle‑övergång på den första bilden och en Comb‑övergång på den andra. Använd en `input.pptx`‑fil med minst två bilder.

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

## **Lägg till avancerad bildövergång**

Du kan konfigurera hur länge en bild förblir på skärmen och om ett musklick avancerar bildspelet. Följande metoder styr detta beteende:

- [setAdvanceOnClick](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) tillåter betraktaren att gå vidare genom att klicka med musen.
- [setAdvanceAfter](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) möjliggör automatiskt avancemang.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) anger fördröjningen innan automatiskt avancemang, i millisekunder.

Aktivera både klick- och tidsbaserat avancemang så att betraktaren kan gå vidare med ett klick eller vänta på timern. För att bara använda timern, skicka `false` till [setAdvanceOnClick](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Fördröjningen styr när bildspelet avancerar; den anger inte varaktigheten för den visuella övergångseffekten.

Detta exempel tilldelar olika effekter till de tre första bilderna och aktiverar automatiskt avancemang efter 3, 5 respektive 7 sekunder. Musklick kan även avancera dessa bilder. Använd en `input.pptx`‑fil med minst tre bilder.

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

För att kontrollera om tidsbaserat avancemang är aktiverat, anropa [getAdvanceAfter](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). En lagrad fördröjning ensam indikerar inte att timern är aktiv.

Nästa exempel öppnar filen som sparades ovan, rapporterar varje aktiverad timer och inaktiverar automatiskt avancemang för bilder med en fördröjning längre än två sekunder. Det aktiverar musklick för dessa bilder och sparar de uppdaterade inställningarna.

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

## **Styr övergångstiming exakt**

Använd [setDuration](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setDuration-int-) för att ange exakt längd på en övergångseffekt i millisekunder. Bildens [getSlideShowTransition](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--)‑metod exponerar dessa inställningar via [ISlideShowTransition](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/):

| Metod | Syfte |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Ställer in varaktigheten för själva övergångseffekten, i millisekunder. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Ställer in fördröjningen innan bilden avancerar automatiskt, i millisekunder. Skicka `true` till [setAdvanceAfter](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) för att aktivera timern. |
| [setSpeed](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Väljer en fördefinierad hastighetskategori från [TransitionSpeed](https://reference.aspose.com/slides/sv/java/com.aspose.slides/transitionspeed/): Slow, Medium eller Fast. Används när ingen exakt varaktighet anges. |

[setDuration] styr endast övergångseffekten; den bestämmer inte hur länge bilden förblir synlig. Konfigurera den automatiska fördröjningen separat. När ingen explicit varaktighet anges, bestämmer Aspose.Slides effektens varaktighet utifrån övergångstypen och värdet från [getSpeed](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#getSpeed--).

### **Tillämpa samma varaktighet på varje bild**

För en enhetlig takt, tillämpa samma effekt och exakt varaktighet på varje bild. Detta exempel läser in `input.pptx`, väljer Fade från [TransitionType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/transitiontype/), och ger varje övergång en varaktighet på 750 millisekunder. Det aktiverar dessutom automatiskt avancemang efter 5 000 millisekunder och inaktiverar avancerande via musklick, för att sedan spara resultatet som PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Konfigurera automatiskt avancemang oberoende av effektens varaktighet.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ange olika varaktigheter för enskilda bilder**

Olika bilder kan ha olika effektvaraktigheter. Till exempel kan en titelbild ha en kort övergång och ett avsnittsinledning en längre. Detta exempel sätter 500 millisekunder för den första bilden och 1 200 millisekunder för den andra. Använd en `input.pptx`‑fil med minst två bilder.

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

### **Koordinera övergångar med animerad utmatning**

När du förbereder en [animated GIF](/slides/sv/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/sv/java/export-to-html5/), eller [video](/slides/sv/java/convert-powerpoint-to-video/), ange exakt övergångstid före export för att matcha den avsedda takten. Till exempel, använd en 600‑millisekunders fade mellan scener och justera varje bilds avancemangsfördröjning separat för att ge tid för narration eller innehåll.

För GIF och video, koordinera utmatningens bildhastighet med effektens varaktighet: 600 millisekunder motsvarar 18 bildrutor vid 30 fps. I HTML5, aktivera animerade övergångar i exportinställningarna. Kontrollera vilka effekter och timing‑alternativ som stöds av det valda exportformatet och förhandsgranska resultatet för att bekräfta synkronisering.

### **Läs en befintlig övergångsvaraktighet**

Anropa [getDuration](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#getDuration--) innan du ändrar övergången för att avgöra om ett explicit värde är lagrat. Ett värde på `-1` betyder att ingen explicit varaktighet är angiven; ett icke‑negativt värde specificerar den lagrade varaktigheten i millisekunder. Det odefinierade värdet är inte den beräknade uppspelningsvaraktigheten: Aspose.Slides använder övergångstypen och värdet från [getSpeed](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#getSpeed--) för att bestämma den varaktigheten. Att sätta en övergångstyp kan initiera en varaktighet, så inspektera de ursprungliga inställningarna först.

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

## **Morph‑övergång**

Morph‑övergången animerar förändringar mellan objekt på på varandra följande bilder. För att skapa en enkel Morph‑effekt, klona en bild, flytta eller ändra storlek på ett objekt i klonen och applicera Morph‑övergången på den andra bilden. Detta ger motsvarande objekt att animera mellan sitt ursprungliga och modifierade tillstånd.

Följande exempel skapar en bild med en textruta, klonar bilden och ändrar rektangelns position och storlek i klonen. Det väljer sedan Morph från [TransitionType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/transitiontype/)‑uppräkningen för den andra bilden. Öppna den sparade filen i en presentationsvisare som stöder Morph för att se effekten under ett bildspel.

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

## **Morph‑övergångstyper**

[TransitionMorphType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/transitionmorphtype/)‑uppräkningen styr hur Morph matchar och animerar innehåll:

- [ByObject](https://reference.aspose.com/slides/sv/java/com.aspose.slides/transitionmorphtype/#ByObject) behandlar varje form som ett helt objekt.
- [ByWord](https://reference.aspose.com/slides/sv/java/com.aspose.slides/transitionmorphtype/#ByWord) animerar text genom att matcha ord där det är möjligt.
- [ByChar](https://reference.aspose.com/slides/sv/java/com.aspose.slides/transitionmorphtype/#ByChar) animerar text genom att matcha tecken där det är möjligt.

Använd [setType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setType-int-) för att välja Morph innan du anropar [getValue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#getValue--). Värdet ger sedan gränssnittet [IMorphTransition](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imorphtransition/), vars metod [setMorphType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imorphtransition/#setMorphType-int-) väljer matchningsläget.

Detta exempel öppnar presentationen som skapades i föregående avsnitt och konfigurerar den andra bilden att använda ordbaserad Morph‑animation.

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

## **Ställ in övergångseffekter**

Vissa övergångar har ytterligare alternativ, t.ex. riktning eller om effekten ska starta från en svart skärm. Tillgängliga alternativ beror på övergången som valts med [setType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setType-int-). Ställ först in typ, och använd sedan lämpligt gränssnitt från [getValue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#getValue--).

Följande exempel tillämpar en Cut‑övergång på den första bilden i `input.pptx`. Det anropar [setFromBlack](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) via [IOptionalBlackTransition](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ioptionalblacktransition/) så att övergången startar från en svart skärm.

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

**Kan jag kontrollera uppspelningshastigheten för en bildövergång?**

Ja. Föredra [setDuration](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setDuration-int-) när du behöver en exakt effektvaraktighet i millisekunder. Använd [setSpeed](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) när en fördefinierad [TransitionSpeed](https://reference.aspose.com/slides/sv/java/com.aspose.slides/transitionspeed/)-kategori — Slow, Medium eller Fast — räcker och ingen explicit varaktighet är angiven. Dessa inställningar styr övergångseffekten oberoende av den automatiska avancemangsfördröjningen.

**Kan jag bifoga ljud till en övergång och få den att loopa?**

Ja. Tilldela inbäddat ljud med [setSound](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), skicka `StartSound` från [TransitionSoundMode](https://reference.aspose.com/slides/sv/java/com.aspose.slides/transitionsoundmode/) till [setSoundMode](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), och aktivera [setSoundLoop](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) med `true`. Ljudet loopas tills nästa ljudhändelse i bildspelet inträffar.

**Vad är det snabbaste sättet att tillämpa samma övergång på varje bild?**

Loop igenom presentationens [getSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSlides--)‑samling och anropa [setType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#setType-int-) med samma värde för varje bilds övergång. Ställ in eventuella timing‑ och effektalternativ i samma loop för att hålla beteendet konsekvent över alla bilder.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Anropa [getType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islideshowtransition/#getType--) på resultatet av bildens [getSlideShowTransition](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Det returnerar ett värde från [TransitionType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/transitiontype/); `None` betyder att ingen övergångseffekt är applicerad.