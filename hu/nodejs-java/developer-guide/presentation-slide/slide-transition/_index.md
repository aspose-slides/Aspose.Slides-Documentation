---
title: Diavetítések diáátmeneteinek kezelése JavaScript használatával
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
- átmeneti hatás
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Alkalmazzon diaátmeneteket, konfigurálja a automatikus dia előrehaladást, és testreszabja a Morph és egyéb átmeneti hatásokat az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Diavetítés-átmenetek szabályozzák, hogyan jelennek meg a diák egy diavetítés során. Az Aspose.Slides for Node.js via Java segítségével kiválaszthat egy átmenet‑effektust minden diára, beállíthatja a léptetést egérkattintás vagy időzítő alapján, és módosíthatja az effektusra jellemző beállításokat. Ez a cikk JavaScript példákat használ az átmenetek alkalmazásához, a pontos átmeneti időtartamok beállításához, a dia időzítésének kezeléséhez, és egy Morph átmenet létrehozásához két dia között. A példák azt is bemutatják, hogyan menthető el a beállítás egy PPTX fájlba.

## **Diavetítés-átmenet hozzáadása**

Az átmenet alkalmazásához töltsön be egy prezentációt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztállyal, majd érje el a dia átmenet beállításait a [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) metódussal. Használja a [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) metódust a [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) felsorolás egy értékével, majd mentse a prezentációt.

Az alábbi példa a Circle átmenetet alkalmazza az első diára, a Comb átmenetet a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diával rendelkezik.

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

A [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) metódus a [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) osztályban szabályozza a cél dia felfedéséhez szükséges radiális szektorok számát. Állítsa a dia átmenet típusát Wheel-re a [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) segítségével a [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) hívásával, mielőtt a [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) metódust [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) példányként elérné.

Ez a példa két azonos diapárt hoz létre: egy fekete diát, amelyet egy arany téglalappal rendelkező dia követ. A cél diák 1 és 8 szektoros kerekekkel rendelkeznek, ugyanazzal a sebességgel, amelyet a [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) állít be, valamint egyértelműen 8 000 milliszekundumos időtartammal, amelyet a [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) állít be, hogy a különbség könnyen megfigyelhető legyen.

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

Nyissa meg a kimeneti prezentációt a PowerPointban, és indítsa el a diavetítést. Lépjen az 1. diáról a 2.-re, majd a 3.-ról a 4.-re. PowerPoint lejátszás közben az 1-es szektorok számával a dia egy óramutató járásával megegyező letapogatással jelenik meg; a 8-as számú szektorokkal egyszerre nyolc radiális szektor nyílik ki. A tartalom és az időzítés azonos, így a különbség a felfedési szektorok számában rejlik.

## **Haladó diavetítés-átmenet hozzáadása**

Az alábbi módszerek szabályozzák, mennyi ideig marad egy dia a képernyőn, és hogy egérkattintás-e lépteti-e a diavetítést:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) lehetővé teszi a nézőnek, hogy kattintással léptessen.
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) engedélyezi az automatikus előrehaladást.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) a késleltetést adja meg automatikus előrehaladás előtt, ezredmásodpercben.

Engedélyezze mind a kattintást, mind az időzített előrehaladást, hogy a néző kattintással vagy a várakozással léphessen tovább. Ha csak az időzítőt szeretné használni, adja át a `false` értéket a [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) metódusnak. A késleltetés azt szabályozza, mikor lép tovább a diavetítés; nem határozza meg a vizuális átmenet időtartamát.

Ez a példa különböző effektusokat rendel az első három diához, és automatikus előrehaladást engedélyez 3, 5 és 7 másodperc után. Egérkattintással is léptethetők ezek a diák. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

A timed előrehaladás engedélyezésének ellenőrzéséhez hívja meg a [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) metódust. A tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus előrehaladást azoknál a diákánál, amelyek késleltetése két másodpercnél nagyobb. Ezeknek a diáknak engedélyezi az egérkattintást, majd elmenti a módosított beállításokat.

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

Használja a [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) metódust a pontos átmeneti effektus időtartamának ezredmásodpercben történő megadásához. A dia [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) metódusa ezeket a beállításokat a [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/) objektumon keresztül tárja fel:

| Method | Purpose |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Beállítja magának az átmeneti effektus időtartamát, ezredmásodpercben. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Beállítja a késleltetést, mielőtt a dia automatikusan továbblép, ezredmásodpercben. Az időzítést a [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) hívásával aktiválja. |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Kiválaszt egy előre definiált sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) felsorolásból: Slow, Medium vagy Fast. Akkor használatos, ha nincs megadva pontos időtartam. |

A [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) csak az átmeneti effektust szabályozza; nem határozza meg, mennyi ideig marad a dia látható. Az automatikus előrehaladási késleltetést külön kell beállítani. Ha nincs explicit időtartam megadva, az Aspose.Slides a átmenet típusából és a [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) értékből számítja ki az effektus időtartamát.

<!-- visual-explanation:slide-transition:start -->
[![A különálló sávok a 750 ms-ás átmeneti időtartamot és az 5 000 ms-ás automatikus előrehaladási beállítást jelölik.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Az együttes példa minden diára 750 ms-ás Fade átmenetet ad, és külön engedélyezi az automatikus előrehaladást 5 000 ms után. Az átmenet időtartama a hatást szabályozza; az előrehaladás határozza meg, mikor hagyja el a diát. Ezek a sávok séma beállítások, nem mérhető kombinált idővonal.*
<!-- visual-explanation:slide-transition:end -->

### **Ugyanazon időtartam alkalmazása minden diára**

Az egységes tempó érdekében alkalmazzon ugyanazt az effektust és pontos időtartamot minden diára. Ez a példa betölti a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) segítségével Fade‑et választ, és minden átmenethez 750 milliszekundumos időtartamot ad. Külön engedélyezi az automatikus előrehaladást 5 000 milliszekundum után, és letiltja az egérkattintásos előrehaladást, majd menti az eredményt PPTX‑ként.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Konfigurálja az automatikus előrehaladást a hatás időtartamától függetlenül.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Különböző időtartamok beállítása egyedi diákhoz**

Különböző diák különböző effektus időtartammal rendelkezhetnek. Például használjon egy rövid átmenetet a cím diára és egy hosszabbat a szakasz bevezetőjére. Ez a példa 500 milliszekundumot állít be az első diára, és 1 200 milliszekundumot a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

### **Átmenetek összehangolása animált kimenettel**

Amikor egy [animált GIF](/slides/hu/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 prezentáció](/slides/hu/nodejs-java/export-to-html5/) vagy [videó](/slides/hu/nodejs-java/convert-powerpoint-to-video/) elkészítéséről van szó, állítsa be a pontos átmeneti időtartamokat export előtt, hogy megfeleljenek a kívánt tempónak. Például használjon 600 milliszekundumos fade‑et a jelenetek között, és minden dia előrehaladási késleltetését külön szabályozza, hogy elegendő hely legyen a narrációnak vagy a tartalomnak.

GIF‑ és videó esetén az output képkockasebességet hangolja a effektus időtartamához: 600 ms 30 fps‑nél 18 képkockának felel meg. HTML5 esetén engedélyezze az animált átmeneteket az export beállításaiban. Ellenőrizze, hogy a választott export formátum támogatja‑e az adott effektusokat és időzítési beállításokat, és tekintse meg az előnézetet a szinkronizáció megerősítéséhez.

### **Meglévő átmeneti időtartam beolvasása**

Módosítás előtt hívja meg a [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) metódust, hogy meghatározza, tárolt‑e explicit érték. A `-1` érték azt jelenti, hogy nincs explicit időtartam megadva; egy nem negatív érték a tárolt ezredmásodpercben mért időtartamot adja meg. A nem beállított érték nem a számított lejátszási időtartam: az Aspose.Slides a átmenet típusából és a [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) értékéből számítja ki azt. Egy átmenet típus beállítása inicializálhat egy időtartamot, ezért előbb ellenőrizze az eredeti beállításokat.

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

A Morph átmenet animálja a változásokat a szomszédos diák objektumai között. Egy egyszerű Morph effektus létrehozásához klónozzon egy diát, mozdítsa vagy méretezze át az objektumot a klónon, majd alkalmazza a Morph átmenetet a második diára. Így a megfelelő objektumok animálódnak az eredeti és módosított állapotuk között.

Az alábbi példa egy szöveges téglalappal rendelkező diát hoz létre, klónozza a diát, majd a klónon megváltoztatja a téglalap pozícióját és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) felsorolásból a Morph‑ot választja a második diára. Nyissa meg a mentett fájlt egy Morph‑ot támogató prezentációs nézőben, hogy lássa az effektust a diavetítés során.

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

A [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) felsorolás szabályozza, hogyan párosítja és animálja a Morph a tartalmat:

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) minden alakzatot egészként kezel.
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) a szöveget szavak szerint párosítja, ahol lehetséges.
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) a szöveget karakterek szerint párosítja, ahol lehetséges.

Használja a [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) metódust a Morph kiválasztásához, mielőtt a [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) hívásra kerülne. Az érték ezután egy [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/) objektumot ad, amelynek a [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) metódusa a párosítási módot választja ki.

Ez a példa megnyitja az előző szakaszban létrehozott prezentációt, és a második diát szó‑alapú Morph animációra konfigurálja.

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

## **Átmeneti effektusok beállítása**

Néhány átmenet további opciókat tesz elérhetővé, például irányt vagy azt, hogy az effektus feketékből indul-e. Az elérhető opciók az [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) segítségével kiválasztott átmenettől függenek. Először állítsa be a típust, majd használja a megfelelő átmenet objektumot a [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) hívásból.

Az alábbi példa a Cut átmenetet alkalmazza a `input.pptx` első diájára. A [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) osztályon keresztül a [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) hívásával úgy állítja be, hogy az átmenet feketéből induljon.

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

**Le tudom-e szabályozni egy diavetítés‑átmenet lejátszási sebességét?**

Igen. Használja a [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) metódust, ha pontos hatásidőt szeretne megadni ezredmásodpercben. Ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) kategória – Slow, Medium vagy Fast – elegendő, és nincs explicit időtartam megadva, akkor a [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) megfelelő. Ezek a beállítások az átmeneti effektust szabályozzák az automatikus előrehaladási késleltetéstől függetlenül.

**Csatolhatok hangot egy átmenethez, és hagyhatom, hogy ismétlődjön?**

Igen. A [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound) metódussal rendelje hozzá a beágyazott hangot, adja át a [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) felsorolásból a StartSound értéket a [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) metódusnak, és állítsa a [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) értékét **true**‑ra. A hang addig ismétlődik, amíg a diavetítésben a következő hangesemény meg nem jelenik.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet minden diára alkalmazzam?**

Iteráljon végig a prezentáció [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) gyűjteményén, és minden dia átmenetére hívja meg a [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) metódust ugyanazzal az értékkel. Állítson be minden időzítési és effektus opciót ugyanabban a ciklusban, hogy a viselkedés konzisztens maradjon a diák között.

**Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?**

Hívja meg a [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) metódust a dia [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) eredményén. Ez a [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) felsorolás egy értékét adja vissza; a None azt jelenti, hogy nincs átmeneti effektus alkalmazva.