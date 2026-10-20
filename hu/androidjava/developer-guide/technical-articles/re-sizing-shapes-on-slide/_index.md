---
title: Alakzatok átméretezése a bemutató diákon Androidon
type: docs
weight: 130
url: /hu/androidjava/resizing-shapes-on-slide/
aliases:
  /androidjava/alakzatok-átméretezése-dialapon/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- bemutató
- Android
- Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for Android Java-n keresztül—automatizálja a diák elrendezésének módosítását és növelje a termelékenységet."
---
## **Áttekintés**

Amikor megváltoztatja a bemutató diák méretét, előfordulhat, hogy át kell méretezni és át kell helyezni az alakzatokat, hogy illeszkedjenek az új méretekhez. Ez a cikk bemutatja, hogyan lehet kézzel méretezni az alakzatokat, és hogyan kell kezelni a táblázatokat a diákon, a mesteroldalakon és az elrendezéseken.

## **Alakzatok átméretezése**

Az egyes alakzatok relatív pozíciójának és méretének megtartásához szorozza meg a vízszintes koordinátákat és a szélességet az új dia szélességének és az eredeti szélességnek arányával. Alkalmazza a megfelelő magasságarányt a függőleges koordinátákra és a magasságra.

Az első példa betölt egy olyan bemutatót, amelynek diái nem tartalmaznak táblázatot, A4-re változtatja a dia méretét, és elmenti az eredményt. A [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) metódust használja a [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) értékkel, így a következő ciklus vezérli a méretezést. Az arányok egységmentesek; az alakzatok pozíciói és méretei pontban vannak megadva. A különböző szélesség- és magasságarányok torzíthatják az alakzatokat, és az alakzat méretének megváltoztatása nem méretezi a betűméreteket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Számítsa ki a független vízszintes és függőleges méretezési tényezőket.
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
A táblázatok külön kezelést igényelnek: az oszlopszélességeket és sormagasságokat kell méretezni a táblázat teljes szélessége és magassága helyett. A sormagasságok nagyobbak lehetnek a kért értéknél, ha a cella tartalma több helyet igényel.
{{% /alert %}}

A második példa támogatja a táblázatokat, és a mestereken és elrendezéseken, valamint az egyedi diákon lévő alakzatokat is feldolgozza, mielőtt elmenti a méretezett bemutatót. Az segítője minden egyes [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) elemet úgy kezel, hogy méretezi az oszlopszélességeket az [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) metódussal, és a minimális sormagasságokat az [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) metódussal. Ezután méretezi a táblázat pozícióját anélkül, hogy külön méretnézi a teljes méreteket.

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // A táblázat mérete az oszlopszélességek és a sormagasságok által van szabályozva.
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
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Átméretezze a mestereken és elrendezéseken, valamint az egyedi diákon definiált alakzatokat.
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

Ha a dia méretét a alakzatok méretezése nélkül változtatja meg, azok megtartják eredeti pozícióikat és méreteiket, és kilóghatnak a diához. A szélesség és magasság különböző arányokkal történő méretezése szintén torzíthatja az alakzatokat.

**Működik a megadott kód minden alakzattípusra?**

Az első példa közvetlenül módosítja az alakzat határait, és olyan diákra vonatkozik, amelyek nem tartalmaznak táblázatot. A második példa külön kezeli a táblázatokat. Ellenőrizze a létrejött elrendezést, különösen a szöveget és a táblázatokat, mivel ezek a példák nem méretezik a betűméreteket, és a táblázat tartalma korlátozhatja a sorok magasságát.

**Hogyan méretezem át a táblázatokat egy dia átméretezésekor?**

Méretezze az oszlopszélességeket a szélesség arányával, a minimális sormagasságokat a magasság arányával, majd méretezze a táblázat pozícióját, ahogyan azt a második példában láthatja.

**Ez az átméretezés működik a mesterdiákon és az elrendezési diákon is?**

Igen. A második példa végigiterál a [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) és minden mester [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) elemein, majd ugyanazt az átméretezési logikát alkalmazza az azokban lévő alakzatokra.

**Meg tudom változtatni egy dia tájolását (álló/fekvő) az átméretezés közben?**

Igen. Hívja meg a [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) metódust a dia méretének megváltoztatása után és a célméretek lekérdezése előtt, hogy a méretezési tényezők a végső tájolást tükrözzék.

**Van korlátja a beállítható dia méretnek?**

Egyedi dia méreteket adhat meg a [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) metódussal. A támogatott méretek a bemutató formátumától és a fájlt megnyitó alkalmazástól is függenek.

**Hogyan akadályozhatom meg, hogy a rögzített képarányú alakzatok torzuljanak?**

Használjon ugyanazt a méretezési tényezőt a szélességhez és a magassághoz. Az eredeti elrendezés új dia méretekbe való illesztéséhez a szélesség és magasság arányai közül a kisebbet alkalmazza mindkét dimenzióra és pozícióra. Ez megőrzi az arányokat, de előfordulhat, hogy egy oldal mentén üres hely marad.