---
title: Hantera bildövergångar i presentationer med JavaScript
linktitle: Bildövergång
type: docs
weight: 80
url: /sv/nodejs-java/slide-transition/
keywords:
- bildövergång
- lägg till bildövergång
- tillämpa bildövergång
- avancerad bildövergång
- Morph‑övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Applicera bildövergångar, konfigurera automatisk bildfortsättning och anpassa Morph och andra övergångseffekter med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Bildövergångar styr hur bilder visas under en bildspelspresentation. Med Aspose.Slides for Node.js via Java kan du välja en övergångseffekt för varje bild, konfigurera vidaregång med mus‑klick eller timer och justera alternativ som är specifika för en effekt. Denna artikel använder JavaScript‑exempel för att tillämpa övergångar, ange exakt övergångstid, hantera bildtid och skapa en Morph‑övergång mellan två bilder. Exemplet visar också hur inställningarna sparas till en PPTX‑fil.

## **Lägg till bildövergång**

För att lägga till en övergång, ladda en presentation med klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och kom åt bildens övergångsinställningar via [getSlideShowTransition](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Använd [setType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setType) med ett värde från enum‑typen [TransitionType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/transitiontype/), spara sedan presentationen.

Följande exempel använder en Circle‑övergång på den första bilden och en Comb‑övergång på den andra. Använd en `input.pptx`‑fil med minst två bilder.

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

## **Lägg till avancerad bildövergång**

Du kan konfigurera hur länge en bild förblir på skärmen och om ett musklick går vidare i bildspel. Följande metoder styr detta beteende:

- [setAdvanceOnClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) låter användaren gå vidare genom att klicka med musen.
- [setAdvanceAfter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) möjliggör automatisk vidaregång.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) anger fördröjningen innan automatisk vidaregång, i millisekunder.

Aktivera både klick‑ och tidsstyrd vidaregång så att tittaren kan gå vidare med ett klick eller vänta på timern. För att endast använda timern, skicka `false` till [setAdvanceOnClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Fördröjningen styr när bildspelet går vidare; den bestämmer inte varaktigheten för den visuella övergångseffekten.

Detta exempel tilldelar olika effekter till de tre första bilderna och aktiverar automatisk vidaregång efter 3, 5 respektive 7 sekunder. Mus‑klick kan också gå vidare på dessa bilder. Använd en `input.pptx`‑fil med minst tre bilder.

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

För att kontrollera om tidsstyrd vidaregång är aktiverad, anropa [getAdvanceAfter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Ett lagrat fördröjningsvärde indikerar ensam inte att timern är aktiv.

Nästa exempel öppnar filen som sparades ovan, rapporterar varje aktiverad timer och inaktiverar automatisk vidaregång för bilder med en fördröjning längre än två sekunder. Det aktiverar mus‑klick för dessa bilder och sparar de uppdaterade inställningarna.

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

## **Styr övergångstiming exakt**

Använd [setDuration](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setDuration) för att ange exakt längd på en övergångseffekt i millisekunder. Bildens [getSlideShowTransition](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition)‑metod exponerar dessa inställningar via [SlideShowTransition](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/):

| Metod | Syfte |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Anger varaktigheten för själva övergångseffekten, i millisekunder. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Anger fördröjningen innan bilden automatiskt går vidare, i millisekunder. Skicka `true` till [setAdvanceAfter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) för att aktivera timern. |
| [setSpeed](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Väljer en fördefinierad hastighetskategori från [TransitionSpeed](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium eller Fast. Används när ingen exakt varaktighet är angiven. |

[setDuration](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setDuration) styr endast övergångseffekten; den avgör inte hur länge bilden förblir synlig. Konfigurera den automatiska fördröjningen separat. När ingen explicit varaktighet har angetts bestämmer Aspose.Slides effektens varaktighet utifrån övergångstypen och värdet i [getSpeed](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

### **Tillämpa samma varaktighet på varje bild**

För ett jämnt tempo, applicera samma effekt och exakt varaktighet på varje bild. Detta exempel laddar `input.pptx`, väljer Fade från [TransitionType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/transitiontype/), och ger varje övergång en varaktighet på 750 ms. Det aktiverar dessutom automatisk vidaregång efter 5 000 ms och inaktiverar vidaregång via mus‑klick, för att sedan spara resultatet som PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Konfigurera automatisk vidaregång oberoende av effektens varaktighet.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ange olika varaktigheter för enskilda bilder**

Olika bilder kan ha olika varaktigheter för övergångseffekten. Till exempel kan en titelbild ha en kort övergång och en sektionsintroduktion en längre. Detta exempel sätter 500 ms för den första bilden och 1 200 ms för den andra. Använd en `input.pptx`‑fil med minst två bilder.

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

### **Koordinera övergångar med animerad export**

När du förbereder en [animerad GIF](/slides/sv/nodejs-java/convert-powerpoint-to-animated-gif/), en [HTML5‑presentation](/slides/sv/nodejs-java/export-to-html5/) eller en [video](/slides/sv/nodejs-java/convert-powerpoint-to-video/), ange exakt övergångstid innan export så att tempoet matchar det önskade. Till exempel, använd en 600 ms fade mellan scener och justera varje bilds vidaregångsfördröjning separat för att ge tid för berättelse eller innehåll.

För GIF och video, koordinera bildhastigheten med effektens varaktighet: 600 ms motsvarar 18 ramar vid 30 fps. I HTML5, aktivera animerade övergångar i exportinställningarna. Kontrollera vilka övergångar och tidsalternativ som stöds av det valda formatet och förhandsgranska resultatet för att bekräfta synkronisering.

### **Läs en befintlig övergångsvaraktighet**

Anropa [getDuration](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#getDuration) innan du ändrar övergången för att avgöra om ett explicit värde är lagrat. Värdet `-1` betyder att ingen explicit varaktighet är satt; ett icke‑negativt värde anger den lagrade varaktigheten i millisekunder. Det odefinierade värdet är inte den beräknade uppspelningsvaraktigheten: Aspose.Slides använder övergångstypen och värdet i [getSpeed](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) för att bestämma den varaktigheten. Att sätta en övergångstyp kan initiera en varaktighet, så inspektera de ursprungliga inställningarna först.

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

## **Morph‑övergång**

Morph‑övergången animerar förändringar mellan objekt på på varandra följande bilder. För att skapa en enkel Morph‑effekt, klona en bild, flytta eller ändra storlek på ett objekt på klonen och applicera Morph‑övergången på den andra bilden. Detta ger övergången motsvarande objekt att animeras mellan deras ursprungliga och modifierade tillstånd.

Följande exempel skapar en bild med en textruta, klonar bilden och ändrar rektangelns position och storlek på klonen. Därefter väljer det Morph från [TransitionType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/transitiontype/)‑enumerationen för den andra bilden. Öppna den sparade filen i en presentationsvisare som stödjer Morph för att se effekten under bildspelet.

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

## **Morph‑övergångstyper**

[TransitionMorphType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/transitionmorphtype/)-enumerationen styr hur Morph matchar och animerar innehåll:

- [ByObject](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) behandlar varje form som ett helt objekt.
- [ByWord](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) animerar text genom att matcha ord där det är möjligt.
- [ByChar](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) animerar text genom att matcha tecken där det är möjligt.

Använd [setType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setType) för att välja Morph innan du anropar [getValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#getValue). Värdet ger då ett [MorphTransition](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/morphtransition/)-objekt vars [setMorphType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/morphtransition/#setMorphType)-metod väljer matchningsläget.

Detta exempel öppnar presentationen som skapades i föregående sektion och konfigurerar den andra bilden att använda ord‑baserad Morph‑animation.

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

## **Ange övergångseffekter**

Vissa övergångar exponerar ytterligare alternativ, såsom riktning eller om effekten ska starta från en svart skärm. Tillgängliga alternativ beror på den övergång som valts med [setType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setType). Ställ in typen först, och använd sedan lämpligt övergångsobjekt från [getValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#getValue).

Följande exempel använder en Cut‑övergång på den första bilden i `input.pptx`. Det anropar [setFromBlack](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) via [OptionalBlackTransition](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/optionalblacktransition/) så att övergången startar från en svart skärm.

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

## **Vanliga frågor**

**Kan jag kontrollera uppspelningshastigheten för en bildövergång?**

Ja. Använd [setDuration](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setDuration) när du behöver en exakt effektvaraktighet i millisekunder. Använd [setSpeed](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) när en fördefinierad [TransitionSpeed](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/transitionspeed/)-kategori – Slow, Medium eller Fast – är tillräcklig och ingen explicit varaktighet har satts. Dessa inställningar styr övergångseffekten oberoende av timern för automatisk vidaregång.

**Kan jag bifoga ljud till en övergång och få den att loopa?**

Ja. Tilldela inbäddat ljud med [setSound](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setSound), skicka `StartSound` från [TransitionSoundMode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/transitionsoundmode/)-enumerationen till [setSoundMode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) och aktivera [setSoundLoop](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) med `true`. Ljudet loopar tills nästa ljudhändelse i bildspelet inträffar.

**Vad är det snabbaste sättet att tillämpa samma övergång på varje bild?**

Iterera igenom presentationens [getSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getSlides)-samling och anropa [setType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#setType) med samma värde för varje bilds övergång. Ställ in timing‑ och effektalternativ i samma loop för att hålla beteendet enhetligt över alla bilder.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Anropa [getType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideshowtransition/#getType) på bildens [getSlideShowTransition](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition)-resultat. Den returnerar ett värde från [TransitionType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/transitiontype/)-enumerationen; None betyder att ingen övergångseffekt är applicerad.