---
title: Alakzatok átméretezése prezentációs diákon Java-ban
type: docs
weight: 130
url: /hu/java/resizing-shapes-on-slide/
aliases:
  - /hu/java/re-sizing-shapes-on-slide/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for Java segítségével—automatizálja a diaelrendezés módosítását és növelje a hatékonyságot."
---
## **Áttekintés**

Ha megváltoztatja egy prezentáció dia méretét, előfordulhat, hogy át kell méreteznie és újrarendeznie az alakzatokat, hogy illeszkedjenek az új méretekhez. Ez a cikk bemutatja, hogyan lehet manuálisan méretezni az alakzatokat, valamint hogyan kell kezelni a táblázatokat a diákon, a mester- és elrendezési diákon.

## **Alakzatok átméretezése**

Az egyes alakzatok relatív pozíciójának és méretének megőrzéséhez szorozza meg a vízszintes koordinátákat és a szélességet az új dia szélességének és az eredeti szélességnek az arányával. Alkalmazza a megfelelő magasságarányt a függőleges koordinátákra és a magasságra.

Az első példa betölt egy prezentációt, amelynek diái nem tartalmaznak táblázatot, A4-re változtatja a dia méretét, majd elmenti az eredményt. A [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) metódust használja a [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) beállítással, hogy a későbbi ciklus szabályozza a méretezést. Az arányok egység nélküli értékek; az alakzatok pozíciói és méretei pontban vannak mérve. A különböző szélesség‑ és magasságarányok torzíthatják az alakzatokat, és az alakzat méretének megváltoztatása nem méretezi át a betűméreteket.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Számolja ki a független vízszintes és függőleges méretezési tényezőket.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

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
Táblázatok külön kezelést igényelnek: a oszlopszélességeket és a sormagasságokat kell méretezni a táblázat teljes szélességének és magasságának beállítása helyett. A sormagasságok nagyobbak maradhatnak a kért méretnél, ha a cella tartalma több helyet igényel.
{{% /alert %}}

A második példa támogatja a táblázatokat, és a mester‑ és elrendezési diákon, valamint az egyedi diákon lévő alakzatokat is feldolgozza, mielőtt elmenti a méretezett prezentációt. A segédfüggvénye minden [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) objektumot úgy kezel, hogy az oszlopszélességeket a [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) metódussal, a minimális sormagasságokat pedig a [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) metódussal méretezi. Ezután a táblázat pozícióját méretezi anélkül, hogy külön méretezné a teljes méreteket.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // A táblázat méreteit az oszlopszélességek és a sormagasságok hatázzák meg.
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
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // Átméretezi a mesterek és elrendezési diák, valamint az egyedi diák alakzatait.
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

Ha a dia méretét anélkül változtatja meg, hogy az alakzatokat méretezi, azok megtartják eredeti pozíciójukat és méretüket, és a dia határain túlra nyúlhatnak. A szélesség és magasság különböző arányokkal való méretezése szintén torzíthatja az alakzatokat.

**Működik a megadott kód minden alakzattípusra?**

Az első példa közvetlenül módosítja az alakzat határait, és olyan diákra van szánva, amelyek nem tartalmaznak táblázatot. A második példa a táblázatokat külön kezeli. Ellenőrizze a kapott elrendezést, különösen a szöveget és a táblázatokat, mert ezek a példák nem méretezik át a betűméreteket, és a táblázattartalom korlátozhatja a sormagasságokat.

**Hogyan méretezhetem át a táblázatokat egy dia átméretezésekor?**

Az oszlopszélességeket a szélességarány, a minimális sormagasságokat a magasságarány szerint méretezi, majd a táblázat pozícióját méretezi, ahogyan a második példában is látható.

**Működik ez az átméretezés a mester‑ és elrendezési diákon is?**

Igen. A második példa bejárja a [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) és minden mester [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) elemet, és ugyanazt az átméretezési logikát alkalmazza az ottani alakzatokra.

**Megváltoztathatom a dia tájolását (álló/fekvő) az átméretezés közben?**

Igen. Hívja meg a [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) metódust a dia méretének megváltoztatása után és a céldimenziók beolvasása előtt, így a méretezési tényezők a végső tájolást tükrözik.

**Van korlátja a beállítható dia méretnek?**

Egyedi dia méreteket adhat meg a [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-) metódussal. A támogatott méretek továbbá a prezentáció formátumától és az fájlt megnyitó alkalmazástól függenek.

**Hogyan kerülhetem el, hogy a rögzített képarányú alakzatok torzuljanak?**

Használja ugyanazt a méretezési tényezőt a szélességhez és a magassághoz. Az eredeti elrendezés új dia méretekhez való illesztéséhez a kisebbik, szélesség‑ vagy magasságarány alapján méretezze mindkét dimenziót és pozíciót. Ez megőrzi az arányokat, de előfordulhat, hogy az egyik szélén üres hely marad.