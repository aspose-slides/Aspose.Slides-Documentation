---
title: Diaátmenetek kezelése prezentációkban JavaScript segítségével
linktitle: Diaátmenet
type: docs
weight: 80
url: /hu/nodejs-java/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- haladó diaátmenet
- Morph átmenet
- átmenet típusa
- átmeneti effektus
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Alkalmazzon diaátmeneteket, állítsa be az automatikus diaelőrehaladást, és testreszabja a Morph és egyéb átmeneti effektusokat az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

A diaátmenetek szabályozzák, hogyan jelennek meg a diák a diavetítés során. Az Aspose.Slides for Node.js via Java segítségével minden diához kiválaszthat egy átmeneti hatást, beállíthatja a haladást egérkattintással vagy időzítővel, és módosíthatja az adott hatásra jellemző opciókat. Ez a cikk JavaScript példákat használ az átmenetek alkalmazására, a pontos átmenet időtartamok beállítására, a diaidőzítés kezelésére, valamint két dia közötti Morph átmenet létrehozására. A példák azt is bemutatják, hogyan menthetők a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

Az átmenet alkalmazásához töltse be a prezentációt a [Prezentáció](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztállyal, majd a dia átmeneti beállításait a [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) metódussal érheti el. Használja a [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) metódust a [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) felsorolt értéke közül, majd mentse a prezentációt.

Az alábbi példa az első diára Circle, a másodikra pedig Comb átmenetet alkalmaz. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

## **Kerék átmenet**

A [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) metódus a [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) osztályban szabályozza, hogy hány sugárirányú szektor fedje fel a céldiat. Állítsa a dia átmeneti típusát Wheel-re a [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) segítségével a [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) metódussal, mielőtt a [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) metódusra hívná, mint [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/).

Ez a példa két azonos diapárt hoz létre: egy fekete diát, amelyet egy arany téglalapos dia követ. A céldiák 1 és 8 sugárszámmal rendelkezik, ugyanazzal a sebességgel, amelyet a [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) metódussal állítottunk be, valamint egy kifejezett 8 000 ms időtartammal, amelyet a [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) metódus ad meg, hogy a különbség könnyen megfigyelhető legyen.

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

Nyissa meg a kimeneti prezentációt a PowerPointban, és indítsa el a diavetítést. Haladjon az 1. diáról a 2. diára, majd a 3. diáról a 4. diára. A PowerPoint lejátszásában az 1-es sugárszám az egymás után járó óramutató járásával megegyező egyetlen szektort mutatja; a 8-as szám nyolc sugárszektorral egyszerre fed le. A cél tartalom és az átmeneti időzítés azonos, így a különbség a felfedési szektorok száma.

## **Fekéren keresztül halványítás a Reveal átmenettel**

Állítsa be a céldiára a Reveal átmeneti típust, majd hívja meg a [setThroughBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/#setThroughBlack) metódust a [RevealTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/) beállításain. Ez a példa egy türkiz forrásdiát és egy korall céldiát hoz létre, majd mindkettőt klónozza. Minden pár ugyanazt a két másodperces Reveal átmenetet használja. Csak a második pár halványul fekéren keresztül.

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
        transition.setSpeed(slides.TransitionSpeed.Slow);
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

Nyissa meg a mentett prezentációt a PowerPointban, és indítsa el a diavetítést. Haladjon az 1. diáról a 2. diára, hogy lássa, a türkiz közvetlenül a korallba olvad. Ezután haladjon a 3. diáról a 4. diára. A képernyő röviden majdnem feketére sötétedik, mielőtt a korall dia megjelenik. Mindkét dia megtartja eredeti háttérszínét.

Az alábbi sorok félszekundumos időközönként mutatják a PowerPoint képkockáit. Hasonlítsa össze az egyes sorok középső képkockáját a hatás megfigyeléséhez.

![PowerPoint lejátszás a fekéren keresztül halványítás ki- (felső) és bekapcsolt (alsó) állapotával. Csak az alsó sor megy keresztül szinte feketén.](reveal-through-black.png)

## **Fejlett diavetítés átmenet hozzáadása**

Beállíthatja, hogy egy dia mennyi ideig maradjon a képernyőn, és hogy egérkattintás vagy időzítő lépteti-e a diavetítést. A következő metódusok szabályozzák ezt a viselkedést:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) lehetővé teszi, hogy a néző egérkattintással lépjen tovább.
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) engedélyezi az automatikus léptetést.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) adja meg a késleltetést (ezredmásodpercben) az automatikus léptetés előtt.

Engedélyezze mind a kattintást, mind az időzített előrehaladást, hogy a néző kattintással vagy a timerrel haladhasson tovább. Ha csak az időzítőt szeretné használni, adja át a `false` értéket a [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) metódusnak. A késleltetés a diavetítés előrehaladásának időpontját irányítja; nem határozza meg a vizuális átmeneti effektus időtartamát.

Ez a példa különböző hatásokat rendel az első három diához, és automatikus előrehaladást állít be 3, 5 és 7 másodperc után. Egérkattintással is léptethetők ezek a diák. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

Az időzített előrehaladás engedélyezve van‑e, azt a [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) metódussal ellenőrizheti. Egy tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelent minden engedélyezett időzítőt, és letiltja az automatikus előrehaladást a két másodpercnél hosszabb késleltetésű diák esetén. Ezekhez a diákhoz engedélyezi az egérkattintást, majd menti a frissített beállításokat.

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

## **Az átmenet időzítésének pontos vezérlése**

Használja a [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) metódust a átmeneti hatás pontos hosszának (ezredmásodpercben) megadásához. A dia [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) metódusa ezen beállításokhoz a [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/) objektumon keresztül fér hozzá:

| Módszer | Cél |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Beállítja az átmeneti hatás önmagának időtartamát ezredmásodpercben. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Beállítja a késleltetést, mielőtt a dia automatikusan előrehalad, ezredmásodpercben. A [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) metódus `true` értékével aktiválható ez az időzítő. |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Kiválaszt egy előre definiált sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) felsorolásból: Slow, Medium vagy Fast. Akkor használjuk, ha nincs megadva konkrét időtartam. |

A [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) csak az átmeneti hatást szabályozza; nem határozza meg, hogy a dia meddig látható. Az automatikus előrehaladási késleltetést külön kell beállítani. Ha nincs kifejezett időtartam megadva, az Aspose.Slides a transition típus és a [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) érték alapján határozza meg a hatás hosszát.

<!-- visual-explanation:slide-transition:start -->
[![Külön oszlopok mutatják a 750 ms átmeneti időtartamot és az 5 000 ms automatikus előrehaladás beállítást.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*A megosztott példa minden diához 750 ms Fade átmenetet ad, és külön engedélyezi a 5 000 ms automatikus előrehaladást. Az átmeneti időtartam a hatást szabályozza; az előrehaladás azt, hogy mikor hagyjuk el a diát. Ezek az oszlopok séma‑beállítások, nem mért kombinált idővonalak.*
<!-- visual-explanation:slide-transition:end -->

### **Azonos időtartam alkalmazása minden diára**

Az egységes ütem érdekében alkalmazzon ugyanazt a hatást és pontos időtartamot minden diára. Ez a példa betölti a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) segítségével Fade‑t választ, és minden átmenetet 750 ms időtartammal lát el. Külön engedélyezi az automatikus előrehaladást 5 000 ms után, és letiltja a kattintással történő előrehaladást, majd menti a PPTX‑et.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Állítsa be az automatikus előrehaladást az effektus időtartamától függetlenül.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Eltérő időtartamok beállítása egyes diáknál**

Különböző diák különböző hatásidőket használhatnak. Például egy címdiára rövid átmenetet, egy szekcióbevezetőre pedig hosszabb atlétet alkalmazhat. Ez a példa 500 ms‑ot állít be az első diához, és 1 200 ms‑ot a másodikhoz. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

### **Az átmenetek összehangolása animált kimenettel**

Amikor [animált GIF](/slides/hu/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 prezentáció](/slides/hu/nodejs-java/export-to-html5/) vagy [videó](/slides/hu/nodejs-java/convert-powerpoint-to-video/) készül, állítsa be a pontos átmeneti időtartamokat az export előtt, hogy a kívánt tempóhoz igazodjanak. Például használjon 600 ms‑os halványítást a jelenetek között, és minden dia előrehaladási késleltetését külön szabályozza, hogy elegendő idő legyen a narrációnak vagy a tartalomnak.

GIF‑ és videó esetén igazítsa a kimeneti képkockasebességet a hatás időtartamához: 600 ms 30 fps‑nél 18 képkockának felel meg. HTML5‑ben engedélyezze a animált átmeneteket az exportbeállításokban. Ellenőrizze a választott exportformátum támogatott hatásait és időzítési lehetőségeit, majd tekintse meg a kimenetet a szinkronizáció megerősítéséhez.

### **Meglévő átmenet időtartamának olvasása**

Módosítás előtt hívja meg a [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) metódust, hogy megállapítsa, tárol-e kifejezett értéket. A `-1` érték azt jelenti, hogy nincs explicit időtartam megadva; a nem negatív érték a tárolt időtartamot ezredmásodpercben adja meg. A be nem állított érték nem a lejátszott időtartam: az Aspose.Slides a transition típust és a [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) értéket használja ennek meghatározásához. Egy transition típus beállítása inicializálhatja az időtartamot, ezért először vizsgálja meg az eredeti beállításokat.

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

## **Morph átmenet**

A Morph átmenet animálja az objektumok változását egymást követő diák között. Egy egyszerű Morph hatás létrehozásához klónozzon egy diát, mozdítsa vagy méretezze át a klónon egy objektumot, majd alkalmazza a Morph átmenetet a második diára. Így a megfelelő objektumok animálódnak az eredeti és a módosított állapot között.

Az alábbi példa egy szöveges téglalappal ellátott diát hoz létre, klónozza, majd a klónon módosítja a téglalap helyzetét és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) felsorolásból a Morph‑ot választja a második diához. Nyissa meg a mentett fájlt olyan megjelenítőben, amely támogatja a Morph‑ot, hogy lássa a hatást diavetítés közben.

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

## **Morph átmenet típusok**

A [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) felsorolás szabályozza, hogy a Morph hogyan illeszt és animál tartalmat:

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) minden alakzatot külön objektumként kezel.
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) szavak szerint animálja a szöveget, ahol lehetséges.
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) karakterek szerint animálja a szöveget, ahol lehetséges.

Használja a [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) metódust a Morph kiválasztásához, mielőtt a [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) metódust hívná. Az érték ekkor egy [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/) objektumot ad, amelynek a [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) metódusa választja ki a megfelelő módot.

Ez a példa megnyitja az előző szekcióban létrehozott prezentációt, és a második diát szó‑alapú Morph animációra állítja be.

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

## **Átmeneti hatások beállítása**

Néhány átmenet további opciókat fed le, például irányt vagy azt, hogy a hatás fekete képernyőn kezdődjön‑e. Az elérhető opciók attól függenek, hogy a [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) segítségével melyik átmenetet választotta. Először állítsa be a típust, majd a [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) által visszaadott megfelelő átmeneti objektumot használja.

Az alábbi példa egy Cut átmenetet alkalmaz az `input.pptx` első diájára. A [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) metódusával állítja be, hogy a átmenet fekete képernyőn induljon.

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

## **GYIK**

**Mikor tudom szabályozni egy diaátmenet lejátszási sebességét?**

Igen. Használja a [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) metódust, ha pontos hatásidőre van szüksége ezredmásodpercben. Használja a [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) metódust, ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) kategória – Slow, Medium vagy Fast – elegendő, és nincs explicit időtartam beállítva. Ezek a beállítások a átmeneti hatást szabályozzák, függetlenül az automatikus előrehaladási késleltetéstől.

**Hozzá tudok-e adni hangot egy átmenethez, és azt ismételni?**

Igen. Az [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound) metódussal adhat beágyazott hangot, a [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) felsorolásból a StartSound értékkel hívja a [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) metódust, és a [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) metódussal `true` értéket ad meg. A hang addig ismétlődik, amíg a diavetítésben a következő hangesemény meg nem történik.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet minden diára alkalmazzam?**

Iteráljon a prezentáció [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) gyűjteményén, és minden diára hívja a [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) metódust ugyanazzal az értékkel. Állítson be minden időzítési és effektus opciót ugyanabban a ciklusban, hogy a viselkedés konzisztens maradjon a diák között.

**Hogyan ellenőrizhetem, hogy milyen átmenet van jelenleg egy dián beállítva?**

Hívja meg a [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) metódust a dia [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) eredményén. Ez a [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) felsorolásból visszaad egy értéket; a None azt jelenti, hogy nincs átmeneti hatás alkalmazva.