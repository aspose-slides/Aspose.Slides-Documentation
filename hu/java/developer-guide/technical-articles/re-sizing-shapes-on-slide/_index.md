---
title: "Alakzatok átméretezése a bemutató diákon Java-ban"
type: docs
weight: 130
url: /hu/java/resizing-shapes-on-slide/
aliases:
  - /java/újraméretezés-alakzatok-dián/
  - /hu/java/re-sizing-shapes-on-slide/
keywords:
  - "alakzat átméretezése"
  - "alakzat méretének módosítása"
  - PowerPoint
  - OpenDocument
  - bemutató
  - Java
  - Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for Java segítségével—automatizálja a diaelrendezés módosítását és növelje a termelékenységet."
---
## **Áttekintés**

Ha megváltoztatja a bemutató dia méretét, előfordulhat, hogy át kell méretezni és újra kell helyezni az alakzatokat az új méretekhez igazodva. Ez a cikk bemutatja, hogyan méretezhetőek kézzel az alakzatok, és hogyan kezelhetők a táblák a diákon, mesterdiákon és elrendezésekben.

## **Alakzatok átméretezése**

Az egyes alakzatok relatív pozíciójának és méretének megőrzése érdekében szorozza meg a vízszintes koordinátákat és a szélességet az új dia szélességének és az eredeti szélességnek az arányával. A megfelelő magasságarányt alkalmazza a függőleges koordinátákra és a magasságra.

Az első példa betölti azt a bemutatót, amely diái nem tartalmaznak táblákat, A4-re változtatja a dia méretét, majd elmenti az eredményt. A [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) metódust használja a [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) értékkel, hogy a későbbi ciklus vezérelje a méretezést. Az arányok mértékegység nélküli értékek; az alakzatok pozíciói és méretei pontokban vannak megadva. A különböző szélesség- és magasságarányok torzíthatják az alakzatokat, és egy alakzat méretének megváltoztatása nem méretezi át a betűméreteket.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Számítsa ki a független vízszintes és függőleges méretezési tényezőket.
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
A táblákat külön kell kezelni: a oszlopok szélességét és a sorok magasságát kell méretezni a tábla teljes szélességének és magasságának hozzárendelése helyett. A sormagasságok nagyobbak lehetnek a kért értéknél, ha a cella tartalma több helyet igényel.
{{% /alert %}}

A második példa támogatja a táblákat, és a mester- és elrendezési dia alakzatait, valamint az egyedi diák alakzatait is feldolgozza az átméretezett bemutató mentése előtt. A segítője minden [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) esetén az oszlopszélességeket a [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) metódussal, a minimális sormagasságokat pedig az [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) metódussal méretezi. Ezután a tábla pozícióját méretezi, anélkül, hogy külön méretezné a teljes dimenziókat.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // A tábla méreteit az oszlopszélességek és sormagasságok határozzák meg.
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
    // Számítsa ki a független vízszintes és függőleges méretezési tényezőket.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // Átméretezze a mesterek és elrendezések, valamint az egyéni diák által definiált alakzatokat.
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

Ha a dia méretét a alakzatok méretezése nélkül változtatja, azok megőrzik eredeti pozíciójukat és méretüket, és a dia határain túlnyúlhatnak. A szélesség és magasság különböző arányokkal való méretezése szintén torzíthatja az alakzatokat.

**A megadott kód minden alakzattípusra működik?**

Az első példa közvetlenül módosítja az alakzatok korlátait, és olyan diákra van szánva, amelyek nem tartalmaznak táblákat. A második példa külön kezeli a táblákat. Ellenőrizze az eredményes elrendezést, különösen a szöveget és a táblákat, mivel ezek a példák nem méreteznek betűméreteket, és a tábla tartalma korlátozhatja a sormagasságokat.

**Hogyan méretezhetem át a táblákat, amikor egy diát átméretezek?**

A szélességarány segítségével méretezze az oszlopszélességeket, a magasságarány segítségével a minimális sormagasságokat, majd a tábla pozícióját méretezze, ahogy a második példában látható.

**Ez az átméretezés működik a mesterdiák és az elrendezésdiák esetén?**

Igen. A második példa végigiterál a [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) és az egyes mesterdiák [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) metódusain, majd ugyanazt az átméretezési logikát alkalmazza az alakzataikra.

**Megváltoztathatom egy dia tájolását (álló/fekvő) az átméretezéssel együtt?**

Igen. Hívja a [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) metódust a dia méretének megváltoztatása után, és a célméretek beolvasása előtt, hogy a méretezési tényezők a végső tájolást tükrözzék.

**Van korláta a beállítható dia méretnek?**

A [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-) metódussal egyedi dia méreteket adhat meg. A támogatott méretek a bemutató formátumától és a fájlt megnyitó alkalmazástól is függenek.

**Hogyan akadályozhatom meg, hogy a rögzített méretarányú alakzatok torzuljanak?**

Használja ugyanazt a méretezési tényezőt a szélességhez és a magassághoz. Az eredeti elrendezés új dia méretekhez való illesztéséhez a szélesség és magasság arányai közül a kisebbet alkalmazza mind a méretekre, mind a pozíciókra. Ez megőrzi az arányokat, de előfordulhat, hogy az egyik élén üres hely marad.