---
title: Alakzatok átméretezése a prezentációs diákon
type: docs
weight: 110
url: /hu/java/re-sizing-shapes-on-slide/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat a PowerPoint és OpenDocument diákon az Aspose.Slides for Java segítségével—automatizálja a diákelrendezés módosítását és növelje a hatékonyságot."
---
## **Áttekintés**

Az Aspose.Slides for Java ügyfelei leggyakrabban felteszik a kérdést, hogyan lehet átméretezni az alakzatokat úgy, hogy a diaméret változásakor az adatok ne vágódjanak le. Ez a rövid technikai cikk megmutatja, hogyan kell ezt megtenni.

## **Alakzatok átméretezése**

Az alakzatok elcsúszásának elkerülése érdekében a diaméret változásakor frissíteni kell minden alakzat pozícióját és méretét, hogy illeszkedjenek az új diaelrendezéshez.

```java
import com.aspose.slides.*;

// A prezentációfájl betöltése.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Az eredeti dia méretének lekérése.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // A dia méretének módosítása a meglévő alakzatok méretezése nélkül.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Az új dia méretének lekérése.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Alakzatok átméretezése és újrapozicionálása minden dián.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Az alakzat méretének méretezése.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Az alakzat pozíciójának méretezése.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" %}} 
A táblázatoknak nincs szükség külön kezelésre: a tábla szélességének és magasságának beállítása arányosan átméretezi az oszlopokat és sorokat, így a sormagasságok és oszlopszélességek újbóli méretezése a arányt kétszer alkalmazná.
{{% /alert %}} 

A fenti kód csak a diákon lévő alakzatokat módosítja. A mesterdiák és a layout diák saját alakzatokkal rendelkeznek, ezért ezeket is méretezze, ha azt szeretné, hogy az egész prezentáció kövesse az új diaméretet:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Az eredeti dia méretének lekérése.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // A dia méretének módosítása a meglévő alakzatok méretezése nélkül.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Az új dia méretének lekérése.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Az alakzat méretének méretezése.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Az alakzat pozíciójának méretezése.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Az alakzat méretének méretezése.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Az alakzat pozíciójának méretezése.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Az alakzat méretének méretezése.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Az alakzat pozíciójának méretezése.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **GYIK**

### Miért torzulnak vagy vágódnak le az alakzatok a dia átméretezése után?

Dia átméretezésekor az alakzatok megtartják eredeti pozíciójukat és méretüket, hacsak a méretezést nem módosítják kifeexplicit módon. Ennek következtében a tartalom levágódhat vagy az alakzatok elcsúszhatnak.

### Működik a megadott kód minden alakzat típusra?

Igen. A magasság és szélesség beállítása mind a szövegdobozokra, képekre, diagramokra, mind a táblázatokra alkalmazható.

### Hogyan méretezzem át a táblázatokat a dia átméretezésekor?

Méretezze a táblázat alakzatát közvetlenül, ugyanúgy, mint bármely más alakzatot. A sorok és oszlopok arányosan követik a változást, ezért ne méretezze őket újra később.

### Működik ez az átméretezés mesterdiák és layout diák esetén is?

Igen, de át kell iterálni a [Mesterdiák](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getMasters--) és a [Elrendezési diák](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getLayoutSlides--) között, és ugyanazt a méretezési logikát alkalmazni kell az alakzataikra a prezentáció egységességének biztosítása érdekében.

### Megváltoztathatom a dia orientációját (álló/fekvő) az átméretezés közben?

Igen. Használhatja a [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidesize/#setOrientation-int-) metódust az orientáció megváltoztatásához. Ügyeljen arra, hogy a méretezési logikát ennek megfelelően állítsa be a layout megőrzése érdekében.

### Van korlátja a beállítható diaméretnek?

Az Aspose.Slides egyedi méreteket támogat, de a nagyon nagy méretek befolyásolhatják a teljesítményt vagy a kompatibilitást bizonyos PowerPoint verziókkal.

### Hogyan akadályozhatom meg, hogy a rögzített képarányú alakzatok torzuljanak?

Ellenőrizheti az alakzat `getAspectRatioLocked` metódusát a méretezés előtt. Ha a képarány rögzítve van, a szélességet vagy magasságot arányosan módosítsa, ahelyett, hogy önállóan méretezné őket.