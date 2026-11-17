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
- átmenet típusa
- átmeneti effektus
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Alkalmazza a diaátmeneteket, konfigurálja a diák automatikus előrehaladását, és testreszabja a Morph és egyéb átmeneti effektusokat az Aspose.Slides for Java-val."
---
## **Áttekintés**

A diaátmenetek szabályozzák, hogyan jelennek meg a diák a diavetítés során. Az Aspose.Slides for Java segítségével kiválaszthatja az átmenet hatását minden diára, konfigurálhatja a haladást egérkattintással vagy időzítővel, és beállíthatja az effektusra specifikus opciókat. Ez a cikk Java példákat használ az átmenetek alkalmazásához, a pontos átmeneti időtartamok beállításához, a diák időzítésének kezeléséhez, és egy Morph átmenet létrehozásához két dia között. A példák azt is bemutatják, hogyan mentheti el a beállításokat PPTX fájlba.

## **Diaátmenet hozzáadása**

Az átmenet alkalmazásához töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztállyal, és érje el a dia átmenet beállításait a [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) metóduson keresztül. Használja a [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) metódust a [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) felsorolásban szereplő értékkel, majd mentse a prezentációt.

Az alábbi példa kör (Circle) átmenetet alkalmaz az első diához és fűrész (Comb) átmenetet a másodikhoz. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

Az [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) metódus a [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) osztályban szabályozza a sugárirányú szektorok számát, amelyek a cél diát feltárják. Állítsa be a dia átmenet típusát Wheel-re a [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) használatával a [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) metódussal, mielőtt a [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) -t [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/)ként elérné.

Ez a példa két azonos diáspárt hoz létre: egy fekete diát, amelyet egy arany téglalappal ellátott dia követ. A cél diák 1 és 8 sugarú szektor számot használnak, ugyanazzal a sebességgel, amelyet a [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) metódussal állítottunk be, és egy 8 000 milliszekundumos explicit időtartammal a [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) segítségével, hogy a különbség könnyen megfigyelhető legyen.

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

Nyissa meg a kimeneti prezentációt a PowerPointban, és indítsa el a diavetítést. Lépjen az 1. diárról a 2.-re, majd a 3.-ról a 4.-re. A PowerPoint lejátszás során az 1-es szektor szám egy óramutatóval megegyező körvonallal tárja fel a diát; a 8-as szám nyolc sugárirányú szektort egyszerre fed fel. A cél tartalom és az átmenet időzítése azonos, így a különbség a feltáró szektorok száma.

## **Haladó diaátmenet hozzáadása**

Beállíthatja, hogy egy dia a képernyőn mennyi ideig marad, és hogy egérkattintás lépteti-e előre a diavetítést. A következő metódusok szabályozzák ezt a viselkedést:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) lehetővé teszi a nézőnek, hogy a mouse kattintással lépjen előre.
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) engedélyezi a automatikus előrelépést.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) meghatározza az automatikus előrelépés előtti késleltetést milliszekundumban.

Engedélyezze mind a kattintással, mind az időzített előrelépést, hogy a néző vagy kattintással haladhasson, vagy a várakozási idő után. Ha csak az időzítőt kívánja használni, adja át a `false` értéket a [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) metódusnak. A késleltetés szabályozza, mikor halad előre a diavetítés; ez nem állítja be a vizuális átmeneti effektus időtartamát.

Ez a példa különböző effektusokat rendel az első három diához, és automatikus előrelépést engedélyez 3, 5 és 7 másodperc után, sorrendben. Egérkattintással is lehet előrelépni ezen diákon. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

Az időzített előrelépés engedélyezett státuszának ellenőrzéséhez hívja meg a [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) metódust. A tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus előrelépést azokra a diákra, amelyek késleltetése két másodpercnél nagyobb. Ezekhez a diákhoz engedélyezi a kattintást, majd elmenti a frissített beállításokat.

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

## **Az átmeneti időzítés pontos vezérlése**

Használja a [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) metódust a átmeneti effektus pontos hosszának milliszekundumban történő megadásához. A dia [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) metódusa ezen beállításokat az [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/) segítségével teszi láthatóvá:

| Method | Purpose |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Beállítja maga az átmeneti effektus időtartamát milliszekundumban. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Beállítja a késleltetést, mielőtt a dia automatikusan előrehalad, milliszekundumban. A `true` értékkel hívja meg a [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) metódust az időzítő aktiválásához. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Kiválaszt egy előre definiált sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/): Slow, Medium vagy Fast. Akkor használandó, ha nincs megadva konkrét időtartam. |

A [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) csak az átmeneti effektust szabályozza; nem határozza meg, mennyi ideig marad látható a dia. Az automatikus előrehaladás késleltetését külön kell beállítani. Ha nincs explicit időtartam beállítva, az Aspose.Slides a effektus időtartamát a átmenet típusából és a [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) értékéből számítja.

<!-- visual-explanation:slide-transition:start -->
[![A különálló sávok a 750 ms-os átmeneti időtartamot és az 5 000 ms-os automatikus előrelépési beállítást jelölik.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Az érintett példa minden dia számára 750 ms Fade átmenetet ad, és külön engedélyezi az automatikus előrelépést 5 000 ms-nál. Az átmeneti időtartam az effektust szabályozza; az előrelépés azt, hogy mikor hagyja el a diát. Ezek a sávok vázlatos beállítások, nem egy mérő kombinált idővonal.*
<!-- visual-explanation:slide-transition:end -->

### **Ugyanaz a időtartam alkalmazása minden diára**

A konzisztens tempó érdekében alkalmazzon ugyanazt az effektust és pontos időtartamot minden diára. Ez a példa betölti a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) listából a Fade-et választja, és minden átmenetnek 750 milliszekundumos időtartamot ad. Külön engedélyezi az automatikus előrelépést 5 000 milliszekundum után, és letiltja az egérkattintással történő előrelépést, majd PPTX‑ként elmenti az eredményt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Az automatikus előrehaladást a hatás időtartamától függetlenül konfigurálja.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Különböző időtartamok beállítása egyéni diákra**

A különböző diák különböző effektus időtartamokat használhatnak. Például egy rövid átmenetet alkalmazhat a cím diany, és egy hosszabb átmenetet a szekció bevezetőjére. Ez a példa 500 ms-ot állít be az első diára, és 1 200 ms-ot a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

Animált [GIF](/slides/hu/java/convert-powerpoint-to-animated-gif/), [HTML5 prezentáció](/slides/hu/java/export-to-html5/) vagy [videó](/slides/hu/java/convert-powerpoint-to-video/) elkészítésekor állítsa be a pontos átmeneti időtartamokat exportálás előtt, hogy egyezzen a kívánt tempóval. Például használjon 600 ms-os fade‑átmenetet a jelenetek között, és állítsa be minden dia előrelépési késleltetését külön, hogy legyen idő a narrációra vagy a tartalomra.

GIF és videó esetén koordinálja a kimeneti képkockasebességet az effektus időtartamával: 600 ms 18 képkockának felel meg 30 fps‑nél. HTML5-ben engedélyezze az animált átmeneteket az exportbeállításokban. Ellenőrizze a kiválasztott exportformátum által támogatott effektusokat és időzítési opciókat, és tekintse meg a kimenetet, hogy megerősítse a szinkronizációt.

### **Létező átmeneti időtartam olvasása**

Hívja meg a [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) metódust az átmenet módosítása előtt, hogy megállapítsa, van-e explicit tárolt érték. A `-1` érték azt jelenti, hogy nincs explicit időtartam beállítva; egy nem negatív érték a tárolt időtartamot adja meg milliszekundumban. A be nem állított érték nem a számított lejátszási időtartam: az Aspose.Slides a átmenet típusa és a [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) értéke alapján határozza meg azt. Egy átmenet típus beállítása inicializálhat időtartamot, ezért először ellenőrizze az eredeti beállításokat.

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

A Morph átmenet animálja az objektumok változását egymást követő diákon. Egy egyszerű Morph effektus létrehozásához klónozzon egy diát, mozgassa vagy méretezze át egy objektumot a klónon, majd alkalmazza a Morph átmenetet a második diára. Ez lehetővé teszi, hogy az átmenet a megfelelő objektumokat animálja az eredeti és a módosított állapot között.

Az alábbi példa egy szöveges téglalappal rendelkező diát hoz létre, klónozza a diát, és a klónon módosítja a téglalap pozícióját és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) felsorolásból a Morph-et választja a második diára. Nyissa meg a mentett fájlt egy olyan prezentációs megjelenítőben, amely támogatja a Morph-ot, hogy lássa az effektust a diavetítés során.

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

A [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) felsorolás szabályozza, hogyan párosítja és animálja a Morph a tartalmat:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) minden alakzatot egy teljes objektumként kezel.
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) szöveget úgy animál, hogy ahol lehetséges, szavakat párosít.
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) szöveget úgy animál, hogy ahol lehetséges, karaktereket párosít.

Használja a [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) metódust a Morph kiválasztásához, mielőtt a [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) metódust meghívná. Az érték ezután hozzáférést biztosít az [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/) interfészhez, amelynek a [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) metódusa választja ki a párosítási módot.

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

Néhány átmenet további opciókat kínál, például irányt vagy azt, hogy az effektus fekete képernyőről indul-e. Az elérhető opciók a [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-)‑val kiválasztott átmenettől függnek. Először állítsa be a típust, majd használja a megfelelő interfészt a [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--)‑ból.

Az alábbi példa egy Cut átmenetet alkalmaz az `input.pptx` első diájára. A [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) metódust az [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) segítségével hívja, hogy az átmenet fekete képernyőről induljon.

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

**Megg lehet határozni egy diaátmenet lejátszási sebességét?**

Igen. Használja a [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) metódust, ha pontos effektus időtartamot szeretne milliszekundumban. Használja a [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) metódust, ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) kategória – Slow, Medium vagy Fast – elegendő, és nincs explicit időtartam beállítva. Ezek a beállítások az átmeneti effektust szabályozzák az automatikus előrelépési késleltetéstől függetlenül.

**Csatolhatok hangot egy átmenethez, és beállíthatom a hurkálást?**

Igen. Beágyazott hangot rendelhet a [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) metódussal, a [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) felsorolásból a StartSound értéket adja át a [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-) metódusnak, és a [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-)‑t `true`‑ra állítja. A hang amíg a diavetítésben a következő hangesemény meg nem jelenik, addig ismétlődik.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzuk minden diára?**

Iteráljon a prezentáció [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) gyűjteményén, és hívja meg a [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) metódust ugyanazzal az értékkel minden dia átmenetéhez. Állítson be minden időzítési és effektus opciót ugyanabban a ciklusban, hogy a viselkedés konzisztens legyen a diák között.

**Hogyan ellenőrizhetem, melyik átmenet van jelenleg beállítva egy dián?**

Hívja meg a [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) metódust a dia [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) eredményén. Ez a [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) felsorolásból egy értéket ad vissza; a None azt jelenti, hogy nincs alkalmazva átmeneti effektus.