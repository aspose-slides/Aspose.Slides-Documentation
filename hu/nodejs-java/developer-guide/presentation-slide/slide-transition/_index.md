---
title: Diák átmenetének kezelése prezentációkban JavaScript-tel
linktitle: Dia átmenet
type: docs
weight: 80
url: /hu/nodejs-java/slide-transition/
keywords:
- dia átmenet
- dia átmenet hozzáadása
- dia átmenet alkalmazása
- speciális dia átmenet
- Morph átmenet
- átmenet típusa
- átmenet effektus
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Diaátmenetek alkalmazása, automatikus diaelőrehaladás konfigurálása, és a Morph valamint egyéb átmeneti effektusok testreszabása az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

A diaátmenetek szabályozzák, hogyan jelennek meg a diák a diavetítés során. Az Aspose.Slides for Node.js via Java segítségével kiválaszthat egy átmenet hatást minden egyes diára, beállíthatja a haladást egérkattintással vagy időzítővel, és módosíthatja az egyes hatásokra jellemző beállításokat. Ez a cikk JavaScript példákat használ az átmenetek alkalmazására, a pontos átmenet időtartam megadására, a diák időzítésének kezelésére és egy Morph átmenet létrehozására két dia között. A példák bemutatják, hogyan menthetők a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

Az átmenet alkalmazásához töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztállyal, és a dia átmenet beállításaihoz férjen hozzá a [getSlideShowTransition](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) segítségével. Használja a [setType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setType) metódust a [TransitionType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/transitiontype/) felsorolt értékével, majd mentse a prezentációt.

Az alábbi példa egy Circle átmenetet alkalmaz az első diára és egy Comb átmenetet a másodikra. Használjon egy legalább két diát tartalmazó `input.pptx` fájlt.

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

## **Speciális diaátmenet hozzáadása**

Beállíthatja, hogy a dia mennyi ideig marad a képernyőn, és hogy egérkattintás váltja-e elő a diavetítést. A következő metódusok szabályozzák ezt a viselkedést:

- [setAdvanceOnClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) lehetővé teszi a néző számára, hogy kattintással lépjen tovább.
- [setAdvanceAfter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) engedi az automatikus előrehaladást.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) megadja az automatikus előrehaladás késleltetését ezredmásodpercben.

Engedélyezze a kattintást és az időzített előrehaladást, hogy a néző kattintással vagy a várakozással léphessen tovább. A csak időzítő használatához adja át a `false` értéket a [setAdvanceOnClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) metódusnak. A késleltetés azt szabályozza, mikor lép tovább a diavetítés; nem állítja be a vizuális átmenet effektus időtartamát.

Ez a példa különböző effektusokat rendel az első három diához, és automatikus előrehaladást engedélyez 3, 5 és 7 másodperc után, mindegyiknél. Egérkattintással is léphet előre ezekkel a diákkal. Használjon egy legalább három diát tartalmazó `input.pptx` fájlt.

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

Az időzített előrehaladás engedélyezésének ellenőrzéséhez hívja meg a [getAdvanceAfter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) metódust. Egy tárolt késleltetés önmagában nem jelenti, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus előrehaladást azoknál a diáknál, ahol a késleltetés több mint két másodperc. Engedélyezi a kattintást ezeknél a diáknál, majd elmenti a frissített beállításokat.

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

## **Az átmenet időzítésének pontos szabályozása**

Használja a [setDuration](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setDuration) metódust, hogy pontosan megadja az átmenet hatás időtartamát ezredmásodpercben. A dia [getSlideShowTransition](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) metódusa ezeket a beállításokat a [SlideShowTransition](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/) objektumon keresztül teszi elérhetővé:

| Metódus | Cél |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Beállítja magának az átmenet hatás időtartamát ezredmásodpercben. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Beállítja a késleltetést, mielőtt a dia automatikusan továbbhaladna, ezredmásodpercben. A [setAdvanceAfter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) hívásával `true` értéket adva aktiválja ezt az időzítőt. |
| [setSpeed](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Kiválaszt egy előre definiált sebesség kategóriát a [TransitionSpeed](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium vagy Fast. Akkor használatos, ha nincs pontos időtartam megadva. |

[setDuration](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setDuration) csak az átmenet hatását szabályozza; nem határozza meg, mennyi ideig marad látható a dia. A automatikus előrehaladási késleltetést külön kell beállítani. Ha nincs explicit időtartam megadva, az Aspose.Slides a hatás időtartamát a transition type és a [getSpeed](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) érték alapján határozza meg.

### **Azonos időtartam alkalmazása minden diára**

Az egységes tempó érdekében alkalmazzon ugyanazt a hatást és pontos időtartamot minden diára. Ez a példa betölti a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/transitiontype/) enumerációból a Fade értéket választja, és minden átmenethez 750 ms időtartamot ad. Külön engedélyezi az automatikus előrehaladást 5 000 ms után, és letiltja a kattintással történő előrehaladást, majd az eredményt PPTX‑ként elmenti.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Állítsa be az automatikus előrehaladást a hatás időtartamától függetlenül.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Különböző időtartamok beállítása egyes diákhoz**

Különböző diák különböző hatás időtartamokat használhatnak. Például egy címdia esetén rövid átmenetet, egy szekcióbevezetőnél hosszabbat alkalmazhat. Ez a példa 500 ms‑ot állít be az első diára és 1 200 ms‑ot a másodikra. Használjon egy legalább két diát tartalmazó `input.pptx` fájlt.

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

Animált GIF ([animated GIF]), HTML5 prezentáció ([HTML5 presentation]) vagy videó ([video]) előkészítésekor állítsa be a pontos átmenet időtartamokat az exportálás előtt, hogy megfeleljenek a kívánt tempónak. Például használjon 600 ms‑es elhalványulást a jelenetek között, és állítsa be minden dia előrehaladási késleltetését külön, hogy elegendő idő legyen a narrációra vagy a tartalomra. GIF‑nél és videónál koordinálja a kimeneti képkockasebességet a hatás időtartamával: 600 ms 18 képkockának felel meg 30 fps‑nél. HTML5‑ben engedélyezze az animált átmeneteket az exportbeállításokban. Ellenőrizze a választott exportformátum által támogatott effektusokat és időzítési lehetőségeket, és előzetesen tekintse meg a kimenetet, hogy megbizonyosodjon a szinkronról.

### **Meglévő átmenet időtartam beolvasása**

Hívja meg a [getDuration](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#getDuration) metódust az átmenet módosítása előtt, hogy megállapítsa, tárolt‑e explicit érték. A `-1` érték azt jelenti, hogy nincs explicit időtartam megadva; egy nem negatív érték a tárolt időtartamot adja meg ezredmásodpercben. A beállítatlan érték nem a számított lejátszási időtartam: az Aspose.Slides a transition type és a [getSpeed](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) érték alapján határozza meg azt. Egy transition type beállítása inicializálhat egy időtartamot, ezért először vizsgálja meg az eredeti beállításokat.

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

A Morph átmenet animálja a szomszédos diákon lévő objektumok közötti változásokat. Egy egyszerű Morph hatás létrehozásához klónozzon egy diát, mozgassa vagy méretezze át az objektumot a klónon, majd alkalmazza a Morph átmenetet a második diára. Ez a transition a megfelelő objektumokat animálja az eredeti és a módosított állapot között.

Az alábbi példa egy szövegrácsot tartalmazó diát hoz létre, klónozza a diát, és a klónon megváltoztatja a rács helyzetét és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/transitiontype/) enumerációból a Morph értéket választja a második diára. Nyissa meg a mentett fájlt egy Morph‑ot támogató prezentációs nézőben, hogy lássa a hatást a diavetítés során.

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

A [TransitionMorphType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/transitionmorphtype/) enumeráció szabályozza, hogy a Morph hogyan egyezteti és animálja a tartalmat:

- [ByObject](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) minden alakzatot egy egységes objektumnak tekint.
- [ByWord](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) szöveget animál szavak egyeztetésével, ahol lehetséges.
- [ByChar](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) szöveget karakterek egyeztetésével animál, ahol lehetséges.

Használja a [setType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setType) metódust a Morph kiválasztásához, mielőtt elérné a [getValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#getValue) eredményt. Az érték egy [MorphTransition](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/morphtransition/) objektumot ad, amelynek a [setMorphType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/morphtransition/#setMorphType) metódusa kiválasztja a megfelelő egyeztetési módot.

Ez a példa megnyitja az előző részben létrehozott prezentációt, és a második diát úgy konfigurálja, hogy szóbazis Morph animációt használjon.

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

Néhány átmenet extra opciókat tesz elérhetővé, például irányt vagy azt, hogy a hatás fekete képernyőről indul-e. Az elérhető opciók attól függenek, hogy melyik átmenetet választotta a [setType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setType) metódussal. Először állítsa be a típust, majd használja a megfelelő átmenet objektumot a [getValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#getValue) metódusból.

Az alábbi példa egy Cut átmenetet alkalmaz az `input.pptx` első diájára. A [setFromBlack](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) metódust az [OptionalBlackTransition](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/optionalblacktransition/) segítségével hívja meg, így a transition fekete képernyőről indul.

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

**Szabályozhatom a diaátmenet lejátszási sebességét?**

Igen. Használja a [setDuration](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setDuration) metódust, ha pontos hatásidőt kell megadnia ezredmásodpercben. Használja a [setSpeed](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) metódust, ha elegendő egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/transitionspeed/) kategória (Slow, Medium vagy Fast), és nincs explicit időtartam megadva. Ezek a beállítások az átmenet hatását szabályozzák, függetlenül az automatikus előrehaladási késleltetéstől.

**Csatolhatok hangot egy átmenethez, és legyen az ismétlődő?**

Igen. A beágyazott hangot a [setSound](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setSound) metódussal adhatja meg, a [TransitionSoundMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/transitionsoundmode/) enumerációból a StartSound értéket adja át a [setSoundMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) metódusnak, és a [setSoundLoop](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) metódussal `true` értéket állít be. A hang addig ismétlődik, amíg a következő hangesemény a diavetítésben nem következik be.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzam minden diára?**

Iteráljon végig a prezentáció [getSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getSlides) gyűjteményén, és minden dia átmenetén hívja meg a [setType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#setType) metódust ugyanazzal az értékkel. A ugyanabban a ciklusban állítson be minden időzítési és effektus opciót, hogy a viselkedés minden dián konzisztens legyen.

**Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?**

Hívja meg a [getType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/#getType) metódust a dia [getSlideShowTransition](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) eredményén. A metódus a [TransitionType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/transitiontype/) enumeráció egy értékét adja vissza; a None azt jelenti, hogy nincs átmenet effektus alkalmazva.