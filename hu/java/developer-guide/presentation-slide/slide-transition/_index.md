---
title: Diaátmenetek kezelése prezentációkban Java-val
linktitle: Diaátmenet
type: docs
weight: 80
url: /hu/java/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- haladó diaátmenet
- Morph átmenet
- átmenettípus
- átmeneti hatás
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Alkalmazza a diaátmeneteket, konfigurálja az automatikus dialépést, és testreszabja a Morph és egyéb átmeneti hatásokat az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

A diák áttűnései szabályozzák, hogyan jelennek meg a diák a diavetítés során. Az Aspose.Slides for Java segítségével minden diához kiválaszthat egy átmeneti hatást, beállíthatja a léptetést egérkattintással vagy időzítővel, és módosíthatja az adott hatáshoz tartozó beállításokat. Ez a cikk Java példákkal mutatja be az átmenetek alkalmazását, a pontos átmeneti időtartam megadását, a diák időzítésének kezelését, valamint egy Morph átmenet létrehozását két dia között. A példák azt is bemutatják, hogyan menthetők a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

Az átmenet alkalmazásához töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztállyal, és a dia átmeneti beállításaihoz férjen hozzá a [getSlideShowTransition](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) metóduson keresztül. Használja a [setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setType-int-) metódust a [TransitionType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/transitiontype/) felsorolásból származó értékkel, majd mentse a prezentációt.

A következő példa Circle átmenetet alkalmaz az első diára és Comb átmenetet a másodikra. Használjon egy legalább két diát tartalmazó `input.pptx` fájlt.

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

## **Haladó diaátmenet hozzáadása**

Beállíthatja, hogy egy dia mennyi ideig marad a képernyőn, valamint hogy egérkattintás lépteti-e a diavetítést. A következő metódusok szabályozzák ezt a viselkedést:

- [setAdvanceOnClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) lehetővé teszi, hogy a néző egérkattintással léptessen.
- [setAdvanceAfter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) engedélyezi az automatikus léptetést.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) megadja az automatikus léptetés késleltetését ezredmásodpercben.

Engedélyezze mind a kattintás, mind az időzített léptetést, hogy a néző kattintással vagy a timerrel léphessen tovább. A csak időzítő használatához adjon át `false` értéket a [setAdvanceOnClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) metódusnak. A késleltetés azt szabályozza, mikor lép tovább a diavetítés; nem határozza meg a vizuális átmenet hatás időtartamát.

A következő példa különböző hatásokat rendel az első három diára, és automatikus léptetést engedélyez 3, 5 és 7 másodperc után. Egérkattintással is léphet ezeken a diákon. Használjon egy legalább három diát tartalmazó `input.pptx` fájlt.

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

A timed léptetés engedélyezésének ellenőrzéséhez hívja a [getAdvanceAfter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) metódust. A tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus léptetést azoknál a diáknál, ahol a késleltetés több mint két másodperc. Engedélyezi a nézőknek az egérkattintást ezeken a diákon, majd elmenti a frissített beállításokat.

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

## **Az átmeneti időzítés pontos irányítása**

A [setDuration](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setDuration-int-) metódus segítségével adhatja meg az átmeneti hatás pontos hosszát ezredmásodpercben. A dia [getSlideShowTransition](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) metódusa ezen beállításokat a [ISlideShowTransition](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/) interfészen keresztül teszi elérhetővé:

| Metódus | Leírás |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Beállítja magának az átmeneti hatás időtartamát ezredmásodpercben. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Beállítja az automatikus léptetés késleltetését ezredmásodpercben. A [setAdvanceAfter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) metódus `true` értékével aktiválja az időzítőt. |
| [setSpeed](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Kiválaszt egy előre definiált sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/hu/java/com.aspose.slides/transitionspeed/) felsorolásból: Slow, Medium vagy Fast. Akkor használatos, ha nincs megadva pontos időtartam. |

[setDuration] csak az átmeneti hatást szabályozza; nem határozza meg, mennyi ideig látható a dia. Az automatikus léptetés késleltetését külön kell konfigurálni. Ha nincs explicit időtartam megadva, az Aspose.Slides az átmeneti típus és a [getSpeed](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#getSpeed--) érték alapján számítja ki a hatás időtartamát.

### **Azonos időtartam alkalmazása minden diára**

Az egységes tempó érdekében alkalmazzon ugyanazt a hatást és pontos időtartamot minden diára. Ez a példa betölti a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/transitiontype/) közül a Fade értéket választja, és minden átmenetnek 750 ezredmásodperc időtartamot ad. Külön engedélyezi az automatikus léptetést 5 000 ezredmásodperc után, és letiltja az egérkattintásos léptetést, majd eredményt PPTX formátumban menti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Állítsa be az automatikus léptetést, az effektus időtartamától függetlenül.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Különböző időtartamok beállítása egyedi diákhoz**

A különböző diák eltérő hatásidőket használhatnak. Például egy rövid átmenetet a címdiára, és hosszabb átmenetet egy szakasz bevezetőjére. Ez a példa 500 ezredmásodpercet állít be az első diára, és 1 200 ezredmásodpercet a másodikra. Használjon egy legalább két diát tartalmazó `input.pptx` fájlt.

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

### **Az átmenetek koordinálása animált kimenettel**

Animált GIF, HTML5 bemutató vagy videó előkészítésekor állítsa be a pontos átmeneti időtartamokat az exportálás előtt, hogy megfeleljenek a kívánt tempónak. Például 600 ezredmásodperces fade-t használjon a jelenetek között, és állítsa be minden dia léptetési késleltetését külön, hogy időt biztosítson a narrációnak vagy a tartalomnak. A GIF és videó esetében koordinálja a kimeneti képkockasebességet az effektus időtartamával: 600 ezredmásodperc 18 képkockának felel meg 30 fps-nél. HTML5-ben engedélyezze az animált átmeneteket az exportálási beállításokban. Ellenőrizze a választott exportformátum támogatott hatásait és időzítési beállításait, majd előnézete a kimenetnek a szinkronizáció ellenőrzéséhez.

### **Létező átmeneti időtartam beolvasása**

Hívja a [getDuration](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#getDuration--) metódust az átmenet módosítása előtt, hogy megállapítsa, van-e explicit érték tárolva. A `-1` érték azt jelenti, hogy nincs explicit időtartam megadva; egy nem negatív érték a tárolt időtartamot ezredmásodpercben adja meg. A be nem állított érték nem a számított lejátszási időtartam: az Aspose.Slides a átmeneti típus és a [getSpeed](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#getSpeed--) érték alapján határozza meg azt. Egy átmeneti típus beállítása inicializálhat egy időtartamot, ezért először ellenőrizze az eredeti beállításokat.

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

## **Morph átmenet**

A Morph átmenet animálja az egymást követő diákon lévő objektumok közötti változásokat. Egy egyszerű Morph hatás létrehozásához klónozzon egy diát, mozdítsa vagy méretezze át egy objektumot a klónon, majd alkalmazza a Morph átmenetet a második diára. Így a megfelelő objektumok animálódnak az eredeti és a módosított állapot között.

A következő példa egy szöveges téglalappal ellátott diát hoz létre, klónozza a diát, majd a klónon módosítja a téglalap pozícióját és méretét. Ezután a második diához a [TransitionType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/transitiontype/) felsorolásból a Morph-ot választja. Nyissa meg a mentett fájlt egy Morph-ot támogató prezentációs nézőben, hogy lássa az effektust a diavetítés alatt.

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

## **Morph átmenet típusok**

A [TransitionMorphType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/transitionmorphtype/) felsorolás szabályozza, hogyan párosítja és animálja a Morph a tartalmat:

- [ByObject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/transitionmorphtype/#ByObject) minden alakzatot egy egységes objektumnak tekint.
- [ByWord](https://reference.aspose.com/slides/hu/java/com.aspose.slides/transitionmorphtype/#ByWord) szöveget animál a szavak egyeztetése alapján, ha lehetséges.
- [ByChar](https://reference.aspose.com/slides/hu/java/com.aspose.slides/transitionmorphtype/#ByChar) szöveget animál a karakterek egyeztetése alapján, ha lehetséges.

Használja a [setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setType-int-) metódust a Morph kiválasztásához, mielőtt a [getValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#getValue--) metódust hívná. Az így kapott érték a [IMorphTransition](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imorphtransition/) interfészt adja, amelynek a [setMorphType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imorphtransition/#setMorphType-int-) metódusa választja ki a párosítási módot.

Ez a példa megnyitja az előző szakaszban létrehozott prezentációt, és a második diát úgy konfigurálja, hogy szóalapú Morph animációt használjon.

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

## **Átmeneti hatások beállítása**

Egyes átmenetek további beállítási lehetőségeket kínálnak, például irányt vagy azt, hogy a hatás fekete képernyőről indul-e. Az elérhető opciók a [setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setType-int-) metódussal kiválasztott átmenettől függnek. Először állítsa be a típust, majd a [getValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#getValue--) metódusból kapott megfelelő interfészt használja.

A következő példa a `input.pptx` első diájára Cut átmenetet alkalmaz. A [setFromBlack](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) metódust az [IOptionalBlackTransition](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ioptionalblacktransition/) interfészen keresztül hívja, hogy az átmenet fekete képernyőről induljon.

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

**Le tudom-e szabályozni egy diaátmenet lejátszási sebességét?**

Igen. Ha pontos hatásidőt kell megadni ezredmásodpercben, használja a [setDuration](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setDuration-int-) metódust. Ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/hu/java/com.aspose.slides/transitionspeed/) kategória – Slow, Medium vagy Fast – elegendő, és nincs explicit időtartam megadva, használja a [setSpeed](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) metódust. Ezek a beállítások az átmeneti hatást szabályozzák, függetlenül az automatikus léptetés késleltetésétől.

**Csatolhatok hangot egy átmenethez, és ismételhetem?**

Igen. Beágyazott hangot a [setSound](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) metódussal rendelhet, a [TransitionSoundMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/transitionsoundmode/) felsorolásból a StartSound értéket adja a [setSoundMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-) metódusnak, és a [setSoundLoop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) metódust `true`-val engedélyezi. A hang addig ismétlődik, amíg a diavetítésben a következő hangesemény meg nem jelenik.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzam minden diára?**

Iteráljon a prezentáció [getSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSlides--) gyűjteményén, és hívja a [setType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#setType-int-) metódust ugyanazzal az értékkel minden dia átmenetéhez. Állítsa be a időzítési és effektus beállításokat ugyanabban a ciklusban, hogy a viselkedés minden dián konzisztens legyen.

**Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?**

Hívja a [getType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideshowtransition/#getType--) metódust a dia [getSlideShowTransition](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) eredményén. A metódus a [TransitionType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/transitiontype/) felsorolás egy értékét adja vissza; a None azt jelenti, hogy nincs átmeneti hatás alkalmazva.