---
title: Hantera bildövergångar i presentationer med Java
linktitle: Bildövergång
type: docs
weight: 80
url: /sv/java/slide-transition/
keywords:
- bildövergång
- lägga till bildövergång
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
description: "Tillämpa bildövergångar, konfigurera automatiskt bildframsteg och anpassa Morph och andra övergångseffekter med Aspose.Slides för Java."
---
## **Översikt**

Bildövergångar styr hur bilder visas under ett bildspel. Med Aspose.Slides för Java kan du välja en övergångseffekt för varje bild, konfigurera avancerande via mus‑klick eller timer och justera alternativ som är specifika för en effekt. Denna artikel använder Java‑exempel för att tillämpa övergångar, sätta exakta övergångsvaraktigheter, hantera bildtidpunkter och skapa en Morph‑övergång mellan två bilder. Exemplen visar också hur man sparar inställningarna till en PPTX‑fil.

## **Lägg till bildövergång**

För att tillämpa en övergång, läs in en presentation med klassen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) och kom åt bildens övergångsinställningar via [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Använd [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) med ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/), spara sedan presentationen.

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

## **Hjulövergång**

Metoden [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) i [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) styr antalet radiala sektorer som avslöjar målbilden. Ställ in bildens övergångstyp till Wheel från [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) med [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) innan du får åtkomst till [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) som [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/).

Detta exempel skapar två identiska bildpar: en svart bild följd av en bild med en gul rektangel. Målbilderna använder spokräkningar på 1 respektive 8, med samma hastighet inställd via [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) och en explicit varaktighet på 8 000 ms satt med [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) för att göra skillnaden lätt att observera.

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

Öppna den sparade presentationen i PowerPoint och kör bildspelet. Gå från bild 1 till bild 2, sedan från bild 3 till bild 4. I PowerPoint‑uppspelning visar den verifierade spokräkningen 1 bilden med en medurs svepning; den verifierade räknaren 8 visar den genom åtta radiala sektorer samtidigt. Bildinnehållet och övergångstiden är identiska, så skillnaden är antalet avslöjande sektorer.

## **Lägg till avancerad bildövergång**

Du kan konfigurera hur länge en bild förblir på skärmen och om ett musklick avancerar bildspelet. Följande metoder styr detta beteende:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) låter visaren gå vidare genom att klicka med musen.
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) möjliggör automatisk avancemang.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) anger fördröjningen innan automatisk avancemang, i millisekunder.

Aktivera både klick‑ och tidsbaserat avancemang så att visaren kan gå vidare med ett klick eller vänta på timern. För att enbart använda timern, skicka `false` till [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Fördröjningen styr när bildspelet avancerar; den anger inte varaktigheten för den visuella övergångseffekten.

Detta exempel tilldelar olika effekter till de tre första bilderna och aktiverar automatiskt avancemang efter 3, 5 respektive 7 sekunder. Mus‑klick kan också gå vidare på dessa bilder. Använd en `input.pptx`‑fil med minst tre bilder.

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

För att kontrollera om tidsbaserat avancemang är aktiverat, anropa [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Ett lagrat fördröjningsvärde betyder inte att timern är aktiv.

Nästa exempel öppnar filen som sparades ovan, rapporterar varje aktiverad timer och inaktiverar automatiskt avancemang för bilder med en fördröjning större än två sekunder. Det aktiverar mus‑klick för dessa bilder och sparar de uppdaterade inställningarna.

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

## **Styr övergångstiden exakt**

Använd [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) för att ange exakt längd på en övergångseffekt i millisekunder. Bildens [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--)‑metod exponerar dessa inställningar via [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/):

| Metod | Syfte |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Anger varaktigheten för själva övergångseffekten, i millisekunder. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Anger fördröjningen innan bilden avancerar automatiskt, i millisekunder. Skicka `true` till [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) för att aktivera timern. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Väljer en fördefinierad hastighetskategori från [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/): Slow, Medium eller Fast. Används när ingen exakt varaktighet har angetts. |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) styr endast övergångseffekten; den bestämmer inte hur länge bilden förblir synlig. Konfigurera fördröjningen för automatiskt avancemang separat. När ingen explicit varaktighet anges bestämmer Aspose.Slides effektens varaktighet utifrån övergångstypen och värdet från [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Det delade exemplet ger varje bild en 750 ms Fade‑övergång och aktiverar separat automatisk avancemang efter 5 000 ms. Övergångens varaktighet styr effekten; avancemanget styr när bilden lämnas. Dessa staplar är schematiska inställningar, inte en uppmätt kombinerad tidslinje.*  
<!-- visual-explanation:slide-transition:end -->

### **Applicera samma varaktighet på varje bild**

För konsekvent tempo, applicera samma effekt och exakt varaktighet på varje bild. Detta exempel läser in `input.pptx`, väljer Fade från [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) och ger varje övergång en varaktighet på 750 ms. Det aktiverar separat automatisk avancemang efter 5 000 ms och inaktiverar avancemang via musklick, sedan sparas resultatet som PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Konfigurera automatisk avancemang oberoende av effektens varaktighet.
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

Olika bilder kan ha olika effektvaraktigheter. Till exempel kan du använda en kort övergång för en titelsida och en längre övergång för ett avsnittsinledning. Detta exempel sätter 500 ms för den första bilden och 1 200 ms för den andra. Använd en `input.pptx`‑fil med minst två bilder.

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

### **Koordinera övergångar med animerad utdata**

När du förbereder en [animated GIF](/slides/sv/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/sv/java/export-to-html5/), eller [video](/slides/sv/java/convert-powerpoint-to-video/), sätt exakta övergångsvaraktigheter innan export för att matcha önskat tempo. Till exempel, använd en 600 ms fade mellan scener och justera varje bilds avancemangsfördröjning separat för att ge tid åt dess berättarröst eller innehåll.

För GIF och video, koordinera utdata‑bilder per sekund med effektens varaktighet: 600 ms motsvarar 18 bildrutor vid 30 fps. I HTML5, aktivera animerade övergångar i exportinställningarna. Kontrollera vilka effekter och tidsalternativ som stöds av det valda exportformatet och förhandsgranska utdata för att bekräfta synkronisering.

### **Läs en befintlig övergångsvaraktighet**

Anropa [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) innan du ändrar övergången för att avgöra om ett explicit värde är lagrat. Ett värde på `-1` betyder att ingen explicit varaktighet är satt; ett icke‑negativt värde anger den lagrade varaktigheten i millisekunder. Det otilldelade värdet är inte den beräknade uppspelningsvaraktigheten: Aspose.Slides använder övergångstypen och värdet från [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) för att bestämma den varaktigheten. Att sätta en övergångstyp kan initiera en varaktighet, så inspektera de ursprungliga inställningarna först.

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

## **Morph-övergång**

Morph‑övergången animerar förändringar mellan objekt på på varandra följande bilder. För att skapa en enkel Morph‑effekt, klona en bild, flytta eller ändra storlek på ett objekt på klonen och tillämpa Morph‑övergången på den andra bilden. Detta ger övergången motsvarande objekt att animera mellan deras ursprungliga och modifierade tillstånd.

Följande exempel skapar en bild med en textruta, klonar bilden och ändrar rektangelns position och storlek på klonen. Sedan väljer den Morph från uppräkningen [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) för den andra bilden. Öppna den sparade filen i en presentationsvisare som stöder Morph för att se effekten under ett bildspel.

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

## **Morph-övergångstyper**

Uppräkningen [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) styr hur Morph matchar och animerar innehåll:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) behandlar varje form som ett helt objekt.
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) animerar text genom att matcha ord där det är möjligt.
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) animerar text genom att matcha tecken där det är möjligt.

Använd [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) för att välja Morph innan du får åtkomst till [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--). Värdet ger sedan gränssnittet [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/), vars metod [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) väljer matchningsläget.

Detta exempel öppnar presentationen som skapades i föregående avsnitt och konfigurerar den andra bilden att använda ord‑baserad Morph‑animation.

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

## **Ange övergångseffekter**

Vissa övergångar exponerar ytterligare alternativ, som riktning eller om effekten ska starta från en svart skärm. Tillgängliga alternativ beror på den övergång som valts med [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-). Ställ in typen först, och använd sedan rätt gränssnitt från [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--).

Följande exempel applicerar en Cut‑övergång på den första bilden i `input.pptx`. Det anropar [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) via [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) så att övergången startar från en svart skärm.

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

## **Vanliga frågor**

**Kan jag styra uppspelningshastigheten för en bildövergång?**

Ja. Prioritera [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) när du behöver en exakt effektvaraktighet i millisekunder. Använd [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) när en fördefinierad kategori från [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) – Slow, Medium eller Fast – är tillräcklig och ingen explicit varaktighet har satts. Dessa inställningar styr övergångseffekten oberoende av fördröjningen för automatiskt avancerat.

**Kan jag bifoga ljud till en övergång och låta det loopa?**

Ja. Tilldela inbäddat ljud med [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), skicka StartSound från uppräkningen [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) till [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), och aktivera [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) med `true`. Ljudet loopar tills nästa ljudhändelse i bildspelet.

**Vad är det snabbaste sättet att tillämpa samma övergång på varje bild?**

Loop igenom presentationens [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--)‑samling och anropa [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) med samma värde för varje bilds övergång. Ställ in tids- och effektalternativ i samma loop för att hålla beteendet enhetligt över alla bilder.

**Hur kan jag kontrollera vilken övergång som för närvarande är satt på en bild?**

Anropa [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) på resultatet från bildens [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Den returnerar ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/); None betyder att ingen övergångseffekt är tillämpad.