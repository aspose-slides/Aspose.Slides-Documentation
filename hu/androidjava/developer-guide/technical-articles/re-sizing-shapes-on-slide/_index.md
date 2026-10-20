---
title: Alakzatok átméretezése prezentációs diákon Androidon
type: docs
weight: 130
url: /hu/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/alakzatok-atmeretezese-dian/
  - /hu/androidjava/re-sizing-shapes-on-slide/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for Android Java segítségével—automatizálja a dia elrendezésének módosítását és növelje a hatékonyságot."
---
## **Áttekintés**

Amikor módosítja a bemutató dia méretét, előfordulhat, hogy át kell méretezni és újra kell pozicionálni az alakzatokat, hogy illeszkedjenek az új méretekhez. Ez a cikk bemutatja, hogyan lehet kézzel méretezni az alakzatokat, és hogyan kell kezelni a táblázatokat diákon, mester diákon és elrendezéseken.

## **Alakzatok átméretezése**

A minden alakzat relatív pozíciójának és méretének megőrzéséhez szorozza meg a vízszintes koordinátákat és a szélességet az új dia szélessége és az eredeti szélesség arányával. A megfelelő magasságarányt alkalmazza a függőleges koordinátákra és a magasságra.

Az első példa betölt egy bemutatót, amely diái nem tartalmaznak táblázatokat, A4-re változtatja a dia méretét, és elmenti az eredményt. A [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) metódust a [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) értékkel használja, hogy a későbbi ciklus szabályozza a méretezést. Az arányok dimenzió nélküli értékek; az alakzat pozíciói és méretei pontban vannak mérve. A különböző szélesség- és magasságarányok torzíthatják az alakzatokat, és egy alakzat méretének megváltoztatása nem méretezi át a betűméreteket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Számolja ki a független vízszintes és függőleges méretezési tényezőket.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Táblázatokat külön kell kezelni: oszlopszélességeket és sormagasságokat kell méretezni a táblázat teljes szélességének és magasságának megadásának helyett. A sormagasságok nagyobbak lehetnek a kért méretnél, ha a cella tartalma több helyet igényel.
{{% /alert %}}

A második példa támogatja a táblázatokat, és a méretezett bemutató mentése előtt a mestereken, elrendezéseken és az egyedi diákon lévő alakzatokat is feldolgozza. Segédfüggvénye minden [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) elemet úgy kezel, hogy az oszlopszélességeket a [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) metódussal, a minimális sormagasságokat pedig a [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) metódussal méretezi. Ezután a táblázat pozícióját méretezi anélkül, hogy külön méretezné a táblázat teljes méreteit.

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // A táblázat méreteit az oszlopszélességek és a sormagasságok szabályozzák.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Számolja ki a független vízszintes és függőleges méretezési tényezőket.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // A mestereken és elrendezéseken, valamint az egyedi diákon definiált alakzatok átméretezése.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **GYIK**

**Miért torzulnak vagy vágódnak le az alakzatok egy dia átméretezése után?**  
Ha a dia méretét az alakzatok méretezése nélkül változtatja, azok megtartják eredeti pozíciójukat és méretüket, és túlnyúlhatnak a diához. A szélesség és magasság eltérő arányokkal való méretezése szintén torzíthatja az alakzatokat.

**Működik a megadott kód minden alakzattípus esetén?**  
Az első példa közvetlenül módosítja az alakzat határait, és olyan diákra vonatkozik, amelyek nem tartalmaznak táblázatokat. A második példa külön kezeli a táblázatokat. Ellenőrizze a kapott elrendezést, különösen a szöveget és a táblázatokat, mivel ezek a példák nem méretezik át a betűméreteket, és a táblázat tartalma korlátozhatja a sormagasságokat.

**Hogyan méretezzem át a táblázatokat egy dia átméretezésekor?**  
Méretezze az oszlopszélességeket a szélességarány szerint, a minimális sormagasságokat a magasságarány szerint, majd méretezze a táblázat pozícióját, ahogy a második példában látható.

**Ez az átméretezés működik-e a mesterdiákon és elrendezésdiákon?**  
Igen. A második példa bejárja a [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) és minden mester [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) elemeit, és ugyanazt az átméretezési logikát alkalmazza az alakzatokra.

**Megváltoztathatom a dia orientációját (álló/fekvő) az átméretezés során?**  
Igen. Hívja meg a [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) metódust a dia méretének módosítása után és a célméretek beolvasása előtt, hogy a méretezési tényezők tükrözzék a végső orientációt.

**Van korlát a beállítható dia méretre?**  
Az egyéni dia méreteket a [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) metódussal adhatja meg. A támogatott méretek a bemutató formátumától és a fájlt megnyitó alkalmazástól is függenek.

**Hogyan akadályozhatom meg, hogy a rögzített képarányú alakzatok torzuljanak?**  
Használja ugyanazt a méretezési tényezőt a szélességre és a magasságra. Az eredeti elrendezés új dia méretekhez való igazításához a szélesség- és magasságarányok közül a kisebbet alkalmazza mindkét dimenzióra és pozícióra. Ez megőrzi az arányokat, de egyes széleken üres helyet hagyhat.