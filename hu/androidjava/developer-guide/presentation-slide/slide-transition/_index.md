---
title: Diaátmenetek kezelése Android bemutatókban
linktitle: Diaátmenet
type: docs
weight: 80
url: /hu/androidjava/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- haladó diaátmenet
- Morph átmenet
- átmenettípus
- átmeneti effektus
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Alkalmazzon diaátmeneteket, állítsa be az automatikus dia előrelépést, és testreszabja a Morph és egyéb átmeneti effekteket az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

A diaátmenetek szabályozzák, hogyan jelennek meg a diák egy diavetítés során. Az Aspose.Slides for Android via Java segítségével minden diára választhat á

tmenet‑effektust, konfigurálhatja a léptetést egérkattintással vagy időzítővel, és beállíthatja az egyes effektusokra jellemző opciókat. Ez a cikk Java‑példákat használ az átmenetek alkalmazására, a pontos átmeneti időtartamok beállítására, a diaidőzítés kezelésére, valamint két dia közötti Morph átmenet létrehozására. A példák azt is bemutatják, hogyan menthetők a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

Átmenet alkalmazásához töltse be a bemutatót a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztállyal, és érje el a dia átmenet beállításait a [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) metódussal. Használja a [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) metódust a [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) felsorolásból választott értékkel, majd mentse a bemutatót.

Az alábbi példa a Circle átmenetet alkalmazza az első diára és a Comb átmenetet a másodikra. Használjon egy `input.pptx` fájlt, amelyben legalább két dia található.

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

## **Kerékátmenet**

Az [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) [setSpokes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/#setSpokes-long-) metódusa szabályozza a radiális szektorok számát, amelyek felfedik a céldiat. Állítsa be a dia átmenet típusát a [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) Wheel‑re a [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) segítségével, mielőtt a [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) metódusához férne hozzá.

Ez a példa két azonos páros diát hoz létre: egy fekete diát, amelyet egy arany téglalappal rendelkező dia követ. A céldiákok 1 és 8 szektoros beállítással rendelkeznek, ugyanazzal a sebességgel, amelyet a [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) metódussal adunk meg, valamint 8 000 ms explicit időtartammal a [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) segítségével, hogy a különbség könnyen megfigyelhető legyen.

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

Nyissa meg a kimeneti bemutatót a PowerPointban, és indítsa el a diavetítést. Lépjen az 1. diaból a 2.-be, majd a 3.-ból a 4.-be. A PowerPoint lejátszásban az 1-es szektor ellenőrzött számú egy óramutató járásával megegyező sweeppel fedi fel a diát; a 8-as számú szektor egyszerre nyolc radiális szektort használ. A céltartalom és az átmenet időzítése azonos, így a különbség a felfedési szektorok száma.

## **Feketénen keresztüli halványítás a Reveal átmenettel**

Állítsa a céldia átmenet típusát Reveal‑ra, majd hívja meg a [setThroughBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) metódust az [IRevealTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/) beállításain. A példa egy türkiz forrásdiát és egy korall céldiát hoz létre, majd mindkettőt klónozza. Minden pár ugyanazt a kétmásodperces Reveal átmenetet használja. Csak a második pár halványít a feketénen keresztül.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    int[] backgrounds = { Color.rgb(0, 128, 128), Color.rgb(255, 127, 80) };
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

Nyissa meg a mentett bemutatót a PowerPointban, és indítsa el a diavetítést. Lépjen az 1. diaból a 2.-be, hogy lássa, a türkiz közvetlenül a korallra halványít. Ezután lépjen a 3. diaból a 4.-be. A képernyő röviden majdnem fekete lesz, mielőtt a korall dia megjelenik. Mindkét dia megtartja eredeti háttérszínét.

Az alábbi sorok a PowerPoint képkockáit mutatják félmásodperces intervallumokban. Hasonlítsa össze a sorok középső képkockáját, hogy lássa a hatást.

![PowerPoint lejátszás a fekete általi halványítás kikapcsolásával (felül) és bekapcsolásával (alul). Csak az alsó sor halad át közel feketén.](reveal-through-black.png)

## **Speciális diaátmenet hozzáadása**

Konfigurálhatja, mennyi ideig marad egy dia a képernyőn, és hogy egy egérkattintás lépteti-e a diavetítést. Az alábbi metódusok szabályozzák ezt a viselkedést:

- [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) lehetővé teszi a nézőnek, hogy az egér kattintásával lépjen tovább.
- [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) engedélyezi az automatikus előrehaladást.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) megadja a késleltetést az automatikus előrehaladás előtt, ezredmásodpercben.

Engedélyezze mind a kattintásos, mind az időzített előrehaladást, hogy a néző kattintással vagy a várakozással haladhasson tovább. Ha csak az időzítőt szeretné használni, adjon `false` értéket a [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) metódusnak. A késleltetés szabályozza, mikor lép előre a diavetítés; nem határozza meg a vizuális átmeneti effektus időtartamát.

Ez a példa különböző effektusokat rendel az első három diához, és 3, 5 és 7 másodperc után engedélyezi az automatikus előrehaladást. Az egérkattintás is léptetheti ezeket a diákat. Használjon egy `input.pptx` fájlt, amelyben legalább három dia van.

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

Annak ellenőrzéséhez, hogy az időzített előrehaladás engedélyezve van‑e, hívja meg a [getAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) metódust. Egy tárolt késleltetés önmagában nem jelzi, hogy a timer aktív.

A következő példa megnyitja a fenti fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus előrehaladást azoknál a diáknál, amelyeknél a késleltetés több mint két másodperc. Ezeknél a diáknál engedélyezi az egérkattintást, majd elmenti a frissített beállításokat.

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

## **Az átmenet időzítésének pontos szabályozása**

Használja a [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) metódust, hogy pontosan meghatározza egy átmeneti effektus időtartamát ezredmásodpercben. A dia [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) metódusa ezen beállításokat a [ISlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/) interfészen keresztül teszi elérhetővé:

| Metódus | Cél |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Beállítja az átmeneti effektus időtartamát ezredmásodpercben. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Beállítja a késleltetést, mielőtt a dia automatikusan előrehalad, ezredmásodpercben. A timer aktiválásához adja meg a `true` értéket a [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) metódusnak. |
| [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Kiválaszt egy előre meghatározott sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) felsorolásból: Slow, Medium vagy Fast. Akkor használatos, ha nincs megadva pontos időtartam. |

A [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) csak az átmeneti effektust szabályozza; nem határozza meg, mennyi ideig marad a dia látható. Az automatikus előrehaladási késleltetést külön kell beállítani. Ha nincs explicit időtartam megadva, az Aspose.Slides a tranzíció típusából és a [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) értékből számítja ki az effektus időtartamát.

<!-- visual-explanation:slide-transition:start -->
[![Az elkülönített sávok jelzik a 750 ms átmenet időtartamát és az 5 000 ms automatikus előrehaladási beállítást.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Az itt bemutatott példa minden diának 750 ms Fade átmenetet ad, és külön engedélyezi az automatikus előrehaladást 5 000 ms után. Az átmenet időtartama az effektust szabályozza; az előrehaladás azt, mikor lépünk a diáról. Ezek a sávok vázlatos beállítások, nem mérhető kombinált idővonalak.*
<!-- visual-explanation:slide-transition:end -->

### **Ugyanaz a időtartam alkalmazása minden diára**

Az egységes tempó érdekében alkalmazza ugyanazt az effektust és pontos időtartamot minden diára. Ez a példa betölti a `input.pptx`‑et, a [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) Fade‑ját választja, és minden átmenethez 750 ms időtartamot ad. Külön engedélyezi az automatikus előrehaladást 5 000 ms után, és letiltja a kattintásos előrehaladást, majd PPTX‑ként menti az eredményt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Állítsa be az automatikus előrehaladást az effektus időtartamától függetlenül.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Különböző időtartamok beállítása egyéni diákhoz**

Különböző diák különböző effektus időtartamot használhatnak. Például egy cím diához rövid átmenetet, egy szekcióbevezetőhöz hosszabbat állíthat be. Ez a példa 500 ms‑ot ad az első diához és 1 200 ms‑ot a másodikhoz. Használjon egy `input.pptx` fájlt, amelyben legalább két dia van.

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

Ha [animált GIF](/slides/hu/androidjava/convert-powerpoint-to-animated-gif/), [HTML5 prezentáció](/slides/hu/androidjava/export-to-html5/) vagy [videó](/slides/hu/androidjava/convert-powerpoint-to-video/) készül, állítsa be a pontos átmeneti időtartamokat exportálás előtt, hogy a kívánt tempót tükrözzék. Például használjon 600 ms‑os halványítást a jelenetek között, és állítsa be minden dia előrehaladási késleltetését külön-külön, hogy elegendő idő legyen a narrációra vagy a tartalomra.

GIF‑ és videó esetén a kimeneti képkocka‑ráta összehangolható az effektus időtartamával: 600 ms 18 képkockának felel meg 30 fps‑nél. HTML5‑ben engedélyezze az animált átmeneteket az export beállításokban. Ellenőrizze a választott export formátum által támogatott effektusokat és időzítési opciókat, és tekintse meg az előzetes megjelenítést a szinkronizáció megerősítésére.

### **Meglévő átmenet időtartamának beolvasása**

Módosítás előtt hívja meg a [getDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) metódust, hogy megállapítsa, van‑e explicit érték tárolva. A `-1` érték azt jelenti, hogy nincs explicit időtartam megadva; a nem negatív érték a tárolt időtartamot ezredmásodpercben adja meg. A nem beállított érték nem a számított lejátszási idő: az Aspose.Slides a tranzíció típusából és a [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) értékből határozza meg azt. Egy tranzíció típus beállítása inicializálhat időtartamot, ezért előbb ellenőrizze az eredeti beállításokat.

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

A Morph átmenet animálja az objektumok változását egymást követő diákon. Egyszerű Morph effektus létrehozásához klónozzon egy diát, mozgassa vagy méretezze át az objektumot a klónon, és alkalmazza a Morph átmenetet a második diára. Ez megadja az átmenetnek a megfelelő objektumokat az eredeti és a módosított állapot között.

Az alábbi példa egy szöveges téglalappal ellátott diát hoz létre, klónozza a diát, és a klónon megváltoztatja a téglalap pozícióját és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) felsorolásból a Morph‑ot választja a második diára. Nyissa meg a mentett fájlt egy Morph‑ot támogató megjelenítőben, hogy lássa a hatást a diavetítés során.

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

A [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/) felsorolás szabályozza, hogyan egyezteti és animálja a Morph a tartalmat:

- [ByObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) minden alakzatot egész objektumként kezel.
- [ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) a szöveget szavak szerint animálja, ahol lehetséges.
- [ByChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) a szöveget karakterek szerint animálja, ahol lehetséges.

Használja a [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) metódust a Morph kiválasztásához, mielőtt a [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) metódushoz férne hozzá. Az érték ezután a [IMorphTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/) interfészt adja, amelynek a [setMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) metódusa választja ki a megfelelő módot.

Ez a példa megnyitja az előző szakaszban létrehozott bemutatót, és a második diát szó‑alapú Morph animációra konfigurálja.

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

Néhány átmenet további opciókat tár fel, például irányt vagy azt, hogy az effektus egy fekete képernyőből indul-e. Az elérhető opciók a [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-)‑vel kiválasztott átmenettől függenek. Először állítsa be a típust, majd használja a megfelelő interfészt a [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) segítségével.

Az alábbi példa a Cut átmenetet alkalmazza a `input.pptx` első diájára. A [IOptionalBlackTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/) [setFromBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) metódusát hívja meg, hogy az átmenet fekete képernyőből induljon.

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

**Szabályozhatom-e a diaátmenet lejátszási sebességét?**

Igen. Használja a [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) metódust, ha pontos effektus időtartamra van szüksége ezredmásodpercben. A [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) metódus akkor megfelelő, ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) kategória (Slow, Medium vagy Fast) elegendő, és nincs explicit időtartam megadva. Ezek a beállítások függetlenül szabályozzák az átmeneti effektust és az automatikus előrehaladási késleltetést.

**Csatolhatok-e hangot egy átmenethez, és beállíthatom-e, hogy ismétlődjön?**

Igen. A [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) metódussal rendelje hozzá a beágyazott hangot, adja meg a [TransitionSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionsoundmode/) felsorolásból a `StartSound` értéket a [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-) metódusnak, és engedélyezze a [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) metódust `true`‑val. A hang addig ismétlődik, amíg a diavetítésben a következő hangesemény nem következik be.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzam minden dián?**

Iteráljon a bemutató [getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) gyűjteményén, és minden dia [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) metódusával ugyanazt az értéket állítsa be. Az időzítési és effektus opciókat ugyanabban a ciklusban állítsa be, hogy a viselkedés konzisztens maradjon minden dián.

**Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?**

Hívja meg a [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getType--) metódust a dia [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) eredményén. Ez a [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) felsorolás egy értékét adja vissza; a None azt jelenti, hogy nincs alkalmazva átmeneti effektus.