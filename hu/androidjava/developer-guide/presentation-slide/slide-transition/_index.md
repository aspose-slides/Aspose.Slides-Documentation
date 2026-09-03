---
title: Diavetítések diavetítési áttűnéseinek kezelése Androidon
linktitle: Dia áttűnés
type: docs
weight: 80
url: /hu/androidjava/slide-transition/
keywords:
- dia áttűnés
- dia áttűnés hozzáadása
- dia áttűnés alkalmazása
- speciális dia áttűnés
- Morph áttűnés
- áttűnés típusa
- áttűnés hatása
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alkalmazzon dia áttűnéseket, konfigurálja az automatikus dia előrehaladást, és testreszabja a Morph és egyéb áttűnési hatásokat az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

A diavetítés áttűnések szabályozzák, hogyan jelennek meg a diák a diavetítés során. Az Aspose.Slides for Android via Java segítségével minden diára kiválaszthat egy áttűnési hatást, beállíthatja a haladást egérkattintással vagy időzítővel, valamint módosíthatja a hatáshoz specifikus opciókat. Ez a cikk Java példákat használ az áttűnések alkalmazásához, a pontos áttűnési időtartamok meghatározásához, a diák időzítésének kezeléséhez és egy Morph áttűnés létrehozásához két dia között. A példák azt is bemutatják, hogyan menthetőek a beállítások PPTX fájlba.

## **Diavetítés áttűnés hozzáadása**

Az áttűnés alkalmazásához töltsön be egy prezentációt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztállyal, és érje el a dia áttűnési beállításait a [getSlideShowTransition](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) segítségével. Használja a [setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) metódust a [TransitionType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/transitiontype/) felsorolás egy értékével, majd mentse a prezentációt.

A következő példa kör (Circle) áttűnését alkalmazza az első diára, és comb (Comb) áttűnését a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

## **Speciális diavetítés áttűnés hozzáadása**

Megadhatja, mennyi ideig marad a dia a képernyőn, és hogy egérkattintás előreviszi-e a diavetítést. A következő módszerek szabályozzák ezt a viselkedést:
- [setAdvanceOnClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) lehetővé teszi a nézőnek, hogy egérkattintással lépjen előre.
- [setAdvanceAfter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) engedélyezi az automatikus előrehaladást.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) határozza meg az automatikus előrehaladás késleltetését ezredmásodpercben.

Engedélyezze mind a kattintásos, mind az időzített előrehaladást, hogy a néző kattintással vagy a várakozási idő leteltével folytathassa a diavetítést. Ha csak az időzítőt kívánja használni, adja át a `false` értéket a [setAdvanceOnClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) metódusnak. A késleltetés azt határozza meg, mikor lép tovább a diavetítés; nem állítja be a vizuális áttűnési effektus időtartamát.

Ez a példa különböző hatásokat rendel az első három diára, és automatikus előrehaladást engedélyez 3, 5 és 7 másodperc után, sorrendben. Egérkattintással is lehet előrelépni ezeken a diákon. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

A timed előrehaladás engedélyezésének ellenőrzéséhez hívja meg a [getAdvanceAfter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) metódust. A tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus előrehaladást azoknak a diáknak, amelyek késleltetése több mint két másodperc. Engedélyezi a kattintást ezeknél a diáknál, és elmenti a frissített beállításokat.

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

## **Az áttűnés időzítésének pontos szabályozása**

Használja a [setDuration](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) metódust egy áttűnési effektus pontos hosszának ezredmásodpercben történő megadásához. A dia [getSlideShowTransition](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) metódusa ezeket a beállításokat az [ISlideShowTransition](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/) interfészen keresztül teszi elérhetővé:

| Módszer | Leírás |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Beállítja magának az áttűnési effektusnak az időtartamát ezredmásodpercben. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Beállítja az automatikus dia előrehaladás előtti késleltetést ezredmásodpercben. A [setAdvanceAfter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) metódusnak `true` értéket adva aktiválja ezt az időzítőt. |
| [setSpeed](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Kiválaszt egy előre definiált sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/transitionspeed/) felsorolásból: Slow, Medium vagy Fast. Akkor használják, ha nincs megadva pontos időtartam. |

A [setDuration](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) csak az áttűnési effektust szabályozza; nem határozza meg, mennyi ideig látható a dia. Az automatikus előrehaladás késleltetését külön kell beállítani. Ha nincs explicit időtartam megadva, az Aspose.Slides a effektus időtartamát a áttűnés típusából és a [getSpeed](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) értékből számítja.

### **Azonos időtartam alkalmazása minden diára**

Az egységes ritmus érdekében alkalmazza ugyanazt a hatást és pontos időtartamot minden diára. Ez a példa betölti a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/transitiontype/) enumerációból a Fade-ot választja, és minden áttűnésnek 750 ezredmásodperc időtartamot ad. Külön engedélyezi az automatikus előrehaladást 5 000 ezredmásodperc után, és letiltja a kattintásos előrehaladást, majd elmenti az eredményt PPTX formátumban.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Az automatikus előrehaladást konfigurálja a hatás időtartamától függetlenül.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Különböző időtartamok beállítása egyes diákhoz**

A különböző diák különböző effektus időtartamokat használhatnak. Például egy rövid áttűnést a címdiára, és egy hosszabb áttűnést a szakasz bevezetőjére. Ez a példa 500 ezredmásodpercet állít be az első diára, és 1 200 ezredmásodpercet a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

### **Az áttűnések összehangolása animált kimenettel**

Animált [animated GIF](/slides/hu/androidjava/convert-powerpoint-to-animated-gif/), [HTML5 prezentáció](/slides/hu/androidjava/export-to-html5/) vagy [videó](/slides/hu/androidjava/convert-powerpoint-to-video/) előkészítésekor állítsa be a pontos áttűnési időtartamokat exportálás előtt, hogy egyezzen a kívánt tempóval. Például használjon 600 ezredmásodperces fade-et a jelenetek között, és állítsa be minden dia előrehaladási késleltetését külön, hogy legyen idő a narrációnak vagy tartalomnak.

GIF és videó esetén igazítsa a kimeneti képkockasebességet az effektus időtartamához: 600 ezredmásodperc 18 képkockának felel meg 30 fps mellett. HTML5 esetén engedélyezze az animált áttűnéseket az exportálási beállításokban. Ellenőrizze a választott export formátum által támogatott hatásokat és időzítési lehetőségeket, és tekintse meg az előnézetet a szinkronizáció ellenőrzéséhez.

### **Létező áttűnési időtartam beolvasása**

Hívja meg a [getDuration](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) metódust az áttűnés módosítása előtt, hogy megállapítsa, van-e tárolt explicit érték. A `-1` érték azt jelenti, hogy nincs explicit időtartam beállítva; egy nemnegatív érték a tárolt ezredmásodpercben megadott időt jelzi. A nem beállított érték nem a kiszámított lejátszási időt jelenti: az Aspose.Slides a áttűnés típusát és a [getSpeed](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) értékét használja a időtartam meghatározásához. Egy áttűnési típus beállítása inicializálhat egy időtartamot, ezért először tekintse át az eredeti beállításokat.

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

## **Morph áttűnés**

A Morph áttűnés animálja a változásokat egymás utáni diák objektumai között. Egyszerű Morph hatás létrehozásához klónozzon egy diát, mozdítsa vagy módosítsa méretét egy objektumnak a klónon, és alkalmazza a Morph áttűnést a második diára. Ez lehetővé teszi, hogy az áttűnés a megfelelő objektumokat animálja az eredeti és a módosított állapot között.

A következő példa létrehoz egy diát egy szöveges téglalappal, klónozza a diát, és megváltoztatja a téglalap pozícióját és méretét a klónon. Ezután a [TransitionType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/transitiontype/) felsorolásból a Morph-ot választja a második diára. Nyissa meg a mentett fájlt egy Morph-ot támogató prezentációs megjelenítőben, hogy lássa a hatást a diavetítés során.

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

## **Morph áttűnés típusok**

A [TransitionMorphType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/transitionmorphtype/) felsorolás szabályozza, hogy a Morph hogyan párosítja és animálja a tartalmat:
- [ByObject](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) minden alakzatot egy teljes objektumként kezel.
- [ByWord](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) a szöveget úgy animálja, hogy ahol lehetséges, szavak alapján párosít.
- [ByChar](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) a szöveget karakterek alapján animálja, ahol lehetséges.

Használja a [setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) metódust a Morph kiválasztásához, mielőtt hozzáférne a [getValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#getValue--) metódushoz. Az érték ezután biztosítja az [IMorphTransition](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imorphtransition/) interfészt, amelynek a [setMorphType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) metódusa választja ki a párosítási módot.

Ez a példa megnyitja az előző szakaszban létrehozott prezentációt, és beállítja a második diát úgy, hogy szó-alapú Morph animációt használjon.

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

## **Áttűnési hatások beállítása**

Egyes áttűnések további opciókat kínálnak, például irányt vagy azt, hogy a hatás fekete képernyőről indul-e. Az elérhető opciók a [setType]‑val kiválasztott áttűnéstől függenek. Először állítsa be a típust, majd használja a megfelelő interfészt a [getValue]‑ból.

A következő példa egy Cut áttűnéset alkalmaz az `input.pptx` első diájára. A [setFromBlack](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) metódust a [IOptionalBlackTransition](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioptionalblacktransition/) interfészen keresztül hívja, hogy az áttűnés fekete képernyőről induljon.

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

## **GYIK**

**Le tudom-e szabályozni egy diavetítés áttűnési lejátszási sebességét?**

Igen. Ha pontos effektus időtartamra van szüksége ezredmásodpercben, használja a [setDuration](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) metódust. Ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/transitionspeed/) kategória—Slow, Medium vagy Fast—elég, és nincs explicit időtartam megadva, akkor a [setSpeed](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) használható. Ezek a beállítások az áttűnési hatást szabályozzák az automatikus előrehaladási késleltetéstől függetlenül.

**Csatolhatok-e hangot egy áttűnéshez, és ismételhetem azt?**

Igen. A beágyazott hangot a [setSound](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) metódussal adhatja hozzá, a [TransitionSoundMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/transitionsoundmode/) felsorolásból a StartSound értéket adja át a [setSoundMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-) metódusnak, és a [setSoundLoop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) metódust `true`‑ra állítja. A hang addig ismétlődik, amíg a diavetítésben a következő hangesemény meg nem jelenik.

**Mi a leggyorsabb módja annak, hogy ugyanazt az áttűnést alkalmazzuk minden diára?**

A legegyszerűbb módja, ha végigiterál a prezentáció [getSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSlides--) gyűjteményén, és minden dia áttűnésénél a [setType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) metódust ugyanazzal az értékkel hívja. Az időzítési és effektus beállításokat ugyanabban a ciklusban állítsa be, hogy a viselkedés következetes maradjon a diák között.

**Hogyan ellenőrizhetem, melyik áttűnés van jelenleg beállítva egy dián?**

Hívja meg a [getType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideshowtransition/#getType--) metódust a dia [getSlideShowTransition](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) eredményén. Ez visszaad egy értéket a [TransitionType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/transitiontype/) felsorolásból; a None azt jelenti, hogy nincs áttűnési effektus alkalmazva.