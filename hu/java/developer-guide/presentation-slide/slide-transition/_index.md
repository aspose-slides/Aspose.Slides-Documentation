---
title: Diaátmenetek kezelése bemutatókban Java-val
linktitle: Diaátmenet
type: docs
weight: 80
url: /hu/java/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- speciális diaátmenet
- Morph átmenet
- átmenet típusa
- átmeneti hatás
- PowerPoint
- OpenDocument
- bemutató
- Java
- Aspose.Slides
description: "Alkalmazzon diaátmeneteket, konfigurálja a diák automatikus előrehaladását, és testre szabja a Morph és egyéb átmeneti hatásokat az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

A diaátmenetek szabályozzák, hogyan jelennek meg a diák egy diavetítés során. Az Aspose.Slides for Java segítségével minden diára kiválaszthat egy átmeneti hatást, beállíthatja a haladást egérkattintással vagy időzítővel, és módosíthatja a hatáshoz specifikus beállításokat. Ez a cikk Java példákat használ az átmenetek alkalmazásához, pontos átmeneti időtartamok megadásához, diaidőzítés kezeléséhez és egy Morph átmenet létrehozásához két dia között. A példák bemutatják, hogyan menthetőek a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

Az átmenet alkalmazásához töltse be a bemutatót a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztállyal, és érje el a dia átmeneti beállításait a [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) segítségével. Használja a [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) metódust a [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) felsorolásból származó értékkel, majd mentse a bemutatót.

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

Az [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) metódusa szabályozza, hány radiális szektor fedje fel a cél diát. Állítsa a dia átmeneti típusát Wheel-re a [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) használatával a [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) hívása előtt, majd érje el a [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) metódust az [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) példányán.

Ez a példa két azonos dia párost hoz létre: egy fekete diát, majd egy arany téglalapú diát. A cél diák 1 és 8 spur számot használnak, ugyanazzal a sebességgel, amelyet a [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) ad meg, valamint egy 8 000 ms explicit időtartamot a [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) segítségével, hogy a különbség könnyen megfigyelhető legyen.

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

Nyissa meg a kimeneti bemutatót a PowerPointban, és indítsa el a diavetítést. Haladjon a 1. diáról a 2.-re, majd a 3.-ról a 4.-re. A PowerPoint lejátszásában az 1-es spur szám az egyrészes óramutató járásával megegyező seprést mutat; a 8-as szám nyolc radiális szektort fed le egyszerre. A tartalom és az átmenet időzítése azonos, ezért a különbség a feltáró szektorok száma.

## **Feketen keresztüli halványítás Reveal átmenettel**

Állítsa a cél dia átmeneti típusát Reveal-re, majd hívja meg a [setThroughBlack](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) metódust az [IRevealTransition](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/) beállításain. A példa egy türkiz forrás diát és egy korall cél diát hoz létre, majd mindkettőt klónozza. Minden pár ugyanazt a két másodperces Reveal átmenetet használja. Csak a második pár halványul feketen keresztül.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    Color[] backgrounds = { new Color(0, 128, 128), new Color(255, 127, 80) };
    String[] labels = { "Source", "Destination" };

    for (int i = 0; i < slides.length; i++) {
        ISlide slide = slides[i];
        slide.getBackground().setType(BackgroundType.OwnBackground);
        slide.getBackground().getFillFormat().setFillType(FillType.Solid);
        slide.getBackground().getFillFormat().getSolidFillColor().setColor(backgrounds[i]);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
        shape.getTextFrame().setText(labels[i]);
        shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    ISlide clonedDestination = presentation.getSlides().addClone(destination);
    for (ISlide slide : new ISlide[] { destination, clonedDestination }) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Reveal);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(2000);

        IRevealTransition reveal = (IRevealTransition) transition.getValue();
        reveal.setDirection(TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide == clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nyissa meg a mentett bemutatót a PowerPointban, és indítsa el a diavetítést. Haladjon a 1. diáról a 2.-re, hogy a türkiz közvetlenül a korall színbe halványuljon. Ezután haladjon a 3. diáról a 4.-re. A képernyő rövid időre szinte feketére sötétedik, mielőtt a korall dia megjelenik. Mindkét dia megtartja eredeti háttérszínét.

Az alábbi sorok a PowerPoint képkockáit mutatják fél másodperces intervallummal. Hasonlítsa össze az egyes sorok középső képkockáját a hatás megfigyeléséhez.

![A PowerPoint lejátszás különböző feketen keresztüli halványítással (felül) és engedélyezett (alul). Csak az alsó sor megy át a közel feketébe.](reveal-through-black.png)

## **Speciális diaátmenet hozzáadása**

Beállíthatja, mennyi ideig marad egy dia a képernyőn, és hogy egérkattintás vagy időzítő haladja-e a diavetítést. Az alábbi metódusok szabályozzák ezt a viselkedést:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) lehetővé teszi, hogy a néző kattintással lépjen tovább.
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) engedélyezi az automatikus haladást.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) adja meg a késleltetést az automatikus haladás előtt, ezredmásodpercben.

Kapcsolja be mind a kattintást, mind az időzített haladást, hogy a néző kattintással vagy a váróidő letelte után léphessen tovább. Ha csak az időzítőt szeretné használni, adja át a `false` értéket a [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) metódusnak. A késleltetés szabályozza, mikor lép tovább a diavetítés; nem a vizuális átmenet hatás időtartamát állítja be.

Ez a példa különböző hatásokat rendel az első három diára, és 3, 5 és 7 másodperces automatikus haladást engedélyez mindegyiknél. Egérkattintással is léphet tovább ezeken a diákon. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

Az időzített haladás engedélyezettségének ellenőrzéséhez hívja meg a [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) metódust. Egy tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelent minden engedélyezett időzítőt, és letiltja az automatikus haladást azoknál a diák esetén, ahol a késleltetés meghaladja a két másodpercet. Ezekhez a diákhoz engedélyezi a kattintást, majd elmenti a frissített beállításokat.

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

Használja a [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) metódust egy átmeneti hatás pontos hosszának megadásához ezredmásodpercben. A dia [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) metódusa ezeket a beállításokat az [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/) interfészen keresztül exponálja:

| Metódus | Cél |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Beállítja az átmeneti hatás tényleges időtartamát ezredmásodpercben. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Beállítja a késleltetést, mielőtt a dia automatikusan továbbhalad, ezredmásodpercben. A [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) hívásával aktiválható ez az időzítő. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Kiválaszt egy előre definiált sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) felsorolásból: Slow, Medium vagy Fast. Akkor használatos, ha nincs megadva pontos időtartam. |

A [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) csak az átmeneti hatást szabályozza; nem határozza meg, mennyi ideig marad a dia látható. Az automatikus haladási késleltetést külön kell beállítani. Ha nincs explicit időtartam megadva, az Aspose.Slides a hatás időtartamát a átmenet típusából és a [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) értékéből számítja.

<!-- visual-explanation:slide-transition:start -->
[![Az elkülönített sávok a 750 ms átmeneti időtartamot és az 5 000 ms automatikus haladási beállítást azonosítják.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*A megosztott példa minden diára 750 ms Fade átmenetet ad, és külön engedélyezi az automatikus haladást 5 000 ms után. Az átmeneti időtartam a hatást szabályozza; a haladás azt, mikor hagyja el a diát. Ezek a sávok séma beállítások, nem mérhető kombinált idővonal.*  
<!-- visual-explanation:slide-transition:end -->

### **Azonos időtartam alkalmazása minden diára**

Az egységes ritmus érdekében alkalmazzon ugyanazt a hatást és pontos időtartamot minden diára. Ez a példa betölti a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/)‑ből a Fade‑t választja, és minden átmenetnek 750 ms időtartamot ad. Külön engedélyezi az automatikus haladást 5 000 ms után, és letiltja a kattintásos haladást, majd PPTX‑ként menti az eredményt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Állítsa be az automatikus előrehaladást függetlenül az effektus időtartamától.
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

Különböző diák használhatnak eltérő hatásidőtartamokat. Például egy címdiára rövid átmenetet, egy szakasz bevezető diára hosszabbat alkalmazhat. Ez a példa 500 ms időtartamot állít az első diára és 1 200 ms‑t a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

### **Az átmenetek összehangolása animált kimenettel**

Amikor egy [animated GIF](/slides/hu/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hu/java/export-to-html5/) vagy [video](/slides/hu/java/convert-powerpoint-to-video/) készül, állítsa be a pontos átmeneti időtartamokat export előtt, hogy megfeleljenek a kívánt tempónak. Például használjon 600 ms-os fade‑et a jelenetek között, és minden dia haladási késleltetését külön állítsa be, hogy elég idő álljon rendelkezésre a narrációhoz vagy a tartalomhoz.

GIF‑nél és videónál az kimeneti képkockasebességet egyeztesse a hatás időtartamával: 600 ms 30 fps‑nél 18 képkockának felel meg. HTML5‑ben engedélyezze az animált átmeneteket az export beállításaiban. Ellenőrizze a kiválasztott exportformátum által támogatott hatásokat és időzítési lehetőségeket, majd ellenőrizze a kimenetet a szinkronizáció megerősítéséhez.

### **Meglévő átmeneti időtartam olvasása**

Módosítás előtt hívja meg a [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) metódust, hogy megállapítsa, tárolt‑e explicit érték. A `-1` érték azt jelzi, hogy nincs explicit időtartam; egy nem negatív érték a tárolt időtartamot ezredmásodpercben adja vissza. A be nem állított érték nem a lejátszási időt jelenti: az Aspose.Slides a átmenet típusát és a [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) értékét használja a hossz meghatározásához. Egy átmeneti típus beállítása inicializálhat egy időtartamot, ezért először vizsgálja meg az eredeti beállításokat.

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

A Morph átmenet animálja az objektumok változását egymást követő diákon. Egy egyszerű Morph hatás létrehozásához klónozzon egy diát, módosítsa egy objektum helyét vagy méretét a klónon, majd alkalmazza a Morph átmenetet a második diára. Ez lehetővé teszi, hogy az átmenet a megfelelő objektumok között animálja az eredeti és módosított állapotot.

Az alábbi példa egy szöveges téglalappal ellátott diát hoz létre, klónozza azt, majd a klónon megváltoztatja a téglalap helyzetét és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) felsorolásból a Morph‑t választja a második diára. Nyissa meg a mentett fájlt egy Morph‑ot támogató bemutató‑megtekintőben, hogy a diavetítés során lássa a hatást.

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

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) minden alakzatot egy egész objektumként kezel.
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) szavak alapján animálja a szöveget, ahol lehetséges.
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) karakterek alapján animálja a szöveget, ahol lehetséges.

Használja a [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) metódust a Morph kiválasztásához, mielőtt meghívná a [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) metódust. Az érték ezután hozzáférést biztosít az [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/) interfészhez, amelynek a [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) metódusa választja ki a párosítási módot.

Ez a példa megnyitja az előző szekcióban létrehozott bemutatót, és a második diát szóalapú Morph animációra állítja be.

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

Néhány átmenet további opciókat kínál, például irányt vagy azt, hogy a hatás fekete képernyőből induljon. A rendelkezésre álló opciók a [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) által kiválasztott átmenettől függenek. Állítsa be először a típust, majd használja a megfelelő interfészt a [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) metódusából.

Az alábbi példa egy Cut átmenetet alkalmaz az `input.pptx` első diájára. A [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) segítségével meghívja a [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) metódust, hogy az átmenet fekete képernyőből induljon.

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

**Módosíthatom a diaátmenet lejátszási sebességét?**

Igen. Használja a [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) metódust, ha pontos hatásidőt ezredmásodpercben kell megadni. Használja a [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) metódust, ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) kategória – Slow, Medium vagy Fast – elegendő, és nincs explicit időtartam megadva. Ezek a beállítások az átmeneti hatást szabályozzák az automatikus haladási késleltetéstől függetlenül.

**Csatolhatok hangot az átmenethez, és hagyhatom, hogy ismétlődjön?**

Igen. Rendeljen beágyazott hangot a [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) segítségével, adja át a [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) felsorolásból a StartSound értéket a [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-) metódusnak, és engedélyezze a [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) beállítást `true`‑val. A hang a következő hangeseményig ismétlődik a diavetítésben.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet minden diára alkalmazzam?**

Iteráljon a prezentáció [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) gyűjteményén, és minden dia átmenetéhez hívja meg a [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) metódust ugyanazzal az értékkel. A időzítést és a hatás opciókat ugyanabban a ciklusban állítsa be, hogy a viselkedés minden dián konzisztens legyen.

**Hogyan ellenőrizhetem, hogy milyen átmenet van jelenleg beállítva egy dián?**

Hívja meg a [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) metódust a dia [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) eredményén. Ez a [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) felsorolásból egy értéket ad vissza; a None azt jelenti, hogy nincs átmeneti hatás alkalmazva.