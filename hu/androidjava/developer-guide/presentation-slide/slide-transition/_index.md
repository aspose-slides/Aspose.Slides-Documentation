---
title: Diaátmenetek kezelése Androidon a prezentációkban
linktitle: Diaátmenet
type: docs
weight: 80
url: /hu/androidjava/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- speciális diaátmenet
- Morph átmenet
- átmenettípus
- átmeneti effektus
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alkalmazzon diaátmeneteket, állítsa be a diák automatikus előrehaladását, és testreszabja a Morph valamint más átmeneti effektusokat az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

A diaátmenetek szabályozzák, hogyan jelennek meg a diák a diavetítés során. Az Aspose.Slides for Android via Java segítségével minden dia számára kiválaszthat egy átmenet‑effektust, beállíthatja a továbbhaladást egérkattintással vagy időzítővel, valamint az effektusra jellemző beállításokat is módosíthatja. Ez a cikk Java‑példákkal mutatja be az átmenetek alkalmazását, a pontos átmeneti időtartamok beállítását, a diaidőzítés kezelését és egy Morph átmenet létrehozását két dia között. A példák azt is bemutatják, hogyan menthetőek a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

Átmenet alkalmazásához töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztállyal, majd a dia átmenetbeállításait érje el a [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) metódussal. Használja a [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) metódust a [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) enumeráció egy értékével, majd mentse a prezentációt.

Az alábbi példa a Circle átmenetet alkalmazza az első diára, a Comb átmenetet a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

## **Kerék átmenet**

Az [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) [setSpokes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/#setSpokes-long-) metódusa szabályozza a sugárirányú szektorok számát, amelyek felfedik a cél diát. Állítsa a dia átmenettípusát Wheel‑re a [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) segítségével a [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) hívásával, mielőtt a [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) metódushoz férne hozzá az [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) interfészen keresztül.

Ez a példa két azonos pár diát hoz létre: egy fekete diát, amelyet egy arany téglalappal rendelkező dia követ. A cél diák 1 és 8 szektorral rendelkeznek, ugyanazzal a [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) sebességgel és egy 8 000 ms explicit időtartammal, amelyet a [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) állít be, hogy a különbség könnyen megfigyelhető legyen.

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

Nyissa meg a kimeneti prezentációt a PowerPointban, és indítsa el a diavetítést. Haladjon 1‑ről 2‑re, majd 3‑ról 4‑re. A PowerPoint lejátszásban az 1-es szektor egy óramutató járásával megegyező mozdulattal fed fel egy diát; a 8‑as szám nyolc sugárirányú szektort fed fel egyszerre. A cél tartalom és az átmeneti időzítés azonos, így a különbség kizárólag a felfedési szektorok száma.

## **Speciális diaátmenet hozzáadása**

Beállíthatja, mennyi ideig marad a dia a képernyőn, és hogy egérkattintás továbbvigye‑e a diavetítést. A következő metódusok szabályozzák ezt a viselkedést:

- [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) engedélyezi a felhasználó számára, hogy egérkattintással lépjen tovább.
- [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) lehetővé teszi az automatikus továbbhaladást.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) adja meg az automatikus továbbhaladás késleltetését ezredmásodpercben.

Engedélyezze mind a kattintás, mind az időzített továbbhaladást, hogy a felhasználó kattintással vagy időzítővel haladhasson tovább. Ha csak az időzítőt szeretné használni, adja át a `false` értéket a [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) metódusnak. A késleltetés azt szabályozza, mikor lép tovább a diavetítés; nem határozza meg a vizuális átmenet effektus időtartamát.

Ez a példa különböző effektusokat rendel az első három diához, és automatikus továbbhaladást állít be 3, 5 és 7 másodperc után. Egérkattintással is léphet tovább ezeken a diákon. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

Az időzített továbbhaladás engedélyezésének ellenőrzéséhez hívja meg a [getAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) metódust. Egy tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus továbbhaladást azoknál a diákon, ahol a késleltetés több mint két másodperc. Az ezeknél a diáknál engedélyezi az egérkattintást, majd elmenti a frissített beállításokat.

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

## **Az átmeneti időzítés pontos szabályozása**

Használja a [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) metódust, hogy pontosan megadja egy átmenet effektus hosszát ezredmásodpercben. A dia [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) metódusa ezeken a beállításokon keresztül érhető el az [ISlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/) interfészen keresztül:

| Metódus | Leírás |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Beállítja magának az átmeneti effektusnak a időtartamát ezredmásodpercben. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Beállítja a késleltetést, mielőtt a dia automatikusan továbbhalad, ezredmásodpercben. A [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) `true` értékével aktiválja az időzítőt. |
| [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | A [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) enumeráció egyik előre definiált sebességkategóriáját választja: Slow, Medium vagy Fast. Akkor használatos, ha nincs megadva pontos időtartam. |

A [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) csak az átmeneti effektust szabályozza; nem határozza meg, mennyi ideig marad a dia látható. Az automatikus továbbhaladási késleltetést külön kell beállítani. Ha nincs explicit időtartam megadva, az Aspose.Slides a átmenettípusból és a [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) értékből számolja ki az effektus hosszát.

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **Azonos időtartam alkalmazása minden diára**

Egységes ritmus érdekében alkalmazzon ugyanazt az effektust és ugyanazt a pontos időtartamot minden diára. Ez a példa betölti a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) enumerációból a Fade‑t választja, és minden átmenethez 750 ms időtartamot ad. Automatikus továbbhaladást 5 000 ms után külön engedélyez, a kattintásos továbbhaladást letiltja, majd az eredményt PPTX‑ként menti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Konfigurálja az automatikus előrehaladást az effektus időtartamától függetlenül.
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

Eltérő diák különböző effektus‑időtartamokat használhatnak. Például egy címdiára rövid átmenetet, egy szakasz bevezetőjére hosszabb átmenetet állíthat be. Ez a példa 500 ms‑ot ad az első diának, 1 200 ms‑ot a másodiknak. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

### **Átmenetek összehangolása animált kimenettel**

Animált GIF ([animated GIF](/slides/hu/androidjava/convert-powerpoint-to-animated-gif/)), HTML5 prezentáció ([HTML5 presentation](/slides/hu/androidjava/export-to-html5/)) vagy videó ([video](/slides/hu/androidjava/convert-powerpoint-to-video/)) exportálása esetén állítsa be a pontos átmeneti időtartamokat az export előtt, hogy a kívánt ritmusnak megfelelőek legyenek. Például használjon 600 ms‑os elhalványulást a jelenetek között, és külön állítsa be minden dia előrehaladási késleltetését a narráció vagy a tartalom időtartamához igazítva.

GIF‑ és videó esetén kooperáljon a kimeneti képkockasebességgel: 600 ms 30 fps‑nél 18 képkockának felel meg. HTML5 esetén engedélyezze az animált átmeneteket az exportbeállításokban. Ellenőrizze a választott exportformátum által támogatott effektusokat és időzítési lehetőségeket, és tekintse meg a kimenetet a szinkronizáció megerősítéséhez.

### **Létező átmeneti időtartam beolvasása**

Módosítás előtt hívja meg a [getDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) metódust, hogy megállapítsa, van‑e explicit érték tárolva. A `-1` érték azt jelenti, hogy nincs explicit időtartam; egy nemnegatív érték a tárolt ezredmásodperc‑időt jelöli. A nem beállított érték nem a számított lejátszási időtartam: az Aspose.Slides az átmenettípusból és a [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) értékből számolja ki azt. Egy átmenettípus beállítása inicializálhat egy időtartamot, ezért először ellenőrizze az eredeti beállításokat.

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

A Morph átmenet animálja az objektumok változását egymást követő diákon. Egy egyszerű Morph hatás létrehozásához klónozzon egy diát, módosítsa a klónon egy objektum helyzetét vagy méretét, majd alkalmazza a Morph átmenetet a második diára. Így a két dia közötti eredeti és módosított állapotok között animálódik a megfelelő objektum.

Az alábbi példa egy szöveges téglalapot tartalmazó diát hoz létre, klónozza azt, majd a klónon megváltoztatja a téglalap pozícióját és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) enumerációból a Morph‑t választja a második diára. Nyissa meg a mentett fájlt egy olyan prezentációs nézőben, amely támogatja a Morph‑ot, hogy lássa a hatást a diavetítés során.

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

## **Morph átmenet típusai**

A [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/) enumeráció szabályozza, hogyan párosítja és animálja a Morph a tartalmat:

- [ByObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) minden alakzatot egyetlen objektumként kezel.
- [ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) szöveget animál, ahol lehetséges, szavak alapján párosítva.
- [ByChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) szöveget animál, ahol lehetséges, karakterek alapján párosítva.

Használja a [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) metódust a Morph kiválasztásához, mielőtt a [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) hívásával megkapná az [IMorphTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/) interfészt; ennek a [setMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) metódusa választja ki a párosítási módot.

Ez a példa megnyitja az előző részben létrehozott prezentációt, és a második diát szó alapú Morph animációra állítja be.

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

## **Átmeneti effektusok beállítása**

Néhány átmenet további beállításokat tesz elérhetővé, például irányt vagy azt, hogy az effektus fekete képernyőről indul‑e. A rendelkezésre álló beállítások attól függenek, hogy melyik átmenetet választotta a [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) metódussal. Először állítsa be a típust, majd használja a megfelelő interfészt a [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) hívásával.

Az alábbi példa a Cut átmenetet alkalmazza a `input.pptx` első diájára. A [IOptionalBlackTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/) [setFromBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) metódusával állítja be, hogy az átmenet fekete képernyőről induljon.

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

**Vezethető-e a diaátmenet lejátszási sebessége?**

Igen. Használja a [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) metódust, ha pontos effektus‑időt szeretne megadni ezredmásodpercben. Ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) kategória – Slow, Medium vagy Fast – elegendő, és nincs explicit időtartam megadva, akkor a [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) megfelelő.

**Csatolhatok‑e hangot egy átmenethez, és lehet‑e azt hurkolni?**

Igen. A beágyazott hangot a [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) metódussal állíthatja be, a [TransitionSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionsoundmode/) enumerációból a StartSound‑t adja át a [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-) hívásnak, és a [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) `true` értékével engedélyezheti a hurkot. A hang a következő hangeseményig ismétlődik a diavetítésben.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet minden diára alkalmazzam?**

Iteráljon a prezentáció [getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) gyűjteményén, és hívja meg a [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) metódust ugyanazzal az értékkel minden dia átmenetéhez. Állítson be minden időzítési és effektus‑opciót ugyanabban a ciklusban, hogy a viselkedés konzisztens maradjon.

**Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?**

Hívja meg a [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getType--) metódust a dia [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) eredményén. Ez egy értéket ad vissza a [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) enumerációból; a None azt jelenti, hogy nincs átmenet effektus alkalmazva.