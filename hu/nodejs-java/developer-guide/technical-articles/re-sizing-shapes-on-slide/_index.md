---
title: Alakzatok átméretezése a bemutató diákokon Node.js-ben
type: docs
weight: 130
url: /hu/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for Node.js segítségével Java—automatizálja a diaelrendezés módosításait és növelje a termelékenységet."
---
## **Áttekintés**

Amikor megváltoztatja egy bemutató diák méretét, előfordulhat, hogy át kell méreteznie és újra kell helyeznie az alakzatokat, hogy illeszkedjenek az új méretekhez. Ez a cikk bemutatja, hogyan lehet kézzel méretezni az alakzatokat, és hogyan kell kezelni a táblázatokat diákon, mesteroldalakon és elrendezéseken.

## **Alakzatok átméretezése**

Az egyes alakzatok relatív pozíciójának és méretének megtartásához szorozza meg a vízszintes koordinátákat és a szélességet az új diakép szélessége és az eredeti szélesség arányával. A megfelelő magasságharccsal alkalmazza a függőleges koordinátákat és a magasságot.

Az első példa betölti azt a bemutatót, amelynek diái nem tartalmaznak táblázatokat, A4-re módosítja a diaméretet, és elmenti az eredményt. A [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) hívást a [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) értékkel használja, hogy a későbbi ciklus vezérelje a méretezést. Az arányok mértékegység nélküli értékek; az alakzatok pozíciói és méretei pontban vannak megadva. A különböző szélesség- és magasságharcsok torzíthatják az alakzatokat, és az alakzat méretének megváltoztatása nem méretezi át a betűméreteket.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Számítsa ki a független vízszintes és függőleges méretezési tényezőket.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
A táblázatok külön kezelést igényelnek: oszlopszélességeiket és sormagasságaikat a teljes táblázat szélességének és magasságának hozzárendelése helyett kell méretezni. A sormagasságok nagyobbak maradhatnak a kért értéknél, ha a cella tartalom több helyet igényel.
{{% /alert %}}

A második példa támogatja a táblázatokat, és a mesteroldalakon és elrendezéseken, valamint az egyedi diákon lévő alakzatokat is feldolgozza, mielőtt elmenti az átméretezett bemutatót. A segédprogram minden egyes [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) elemet úgy kezel, hogy az oszlopszélességeket a [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) metódussal, a minimális sormagasságokat pedig a [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight) metódussal méretezi. Ezután a táblázat pozícióját méretezi anélkül, hogy külön méretezné a teljes méreteket.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // A táblázat méretei az oszlopszélességek és a sormagasságok által vannak szabályozva.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // Számítsa ki a független vízszintes és függőleges méretezési tényezőket.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Átméretezni a mesteroldalakon, elrendezéseken és egyedi diákon definiált alakzatokat.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **GYIK**

**Miért torzulnak vagy vágódnak le az alakzatok a dia átméretezése után?**

Ha a diaméretet módosítja az alakzatok méretezése nélkül, azok megtartják eredeti pozíciójukat és méretüket, és túlnyúlhatnak a diáron. A szélesség és magasság különböző arányokkal való méretezése szintén torzíthatja az alakzatokat.

**Működik a megadott kód minden alakzattípusra?**

Az első példa közvetlenül módosítja az alakzat határait, és olyan diákra van tervezve, amelyek nem tartalmaznak táblázatokat. A második példa külön kezeli a táblázatokat. Ellenőrizze a kapott elrendezést, különösen a szöveget és a táblázatokat, mivel ezek a példák nem méretezik át a betűméreteket, és a táblázattartalom korlátozhatja a sormagasságokat.

**Hogyan méretezhetem át a táblázatokat a dia átméretezésekor?**

Méretelje az oszlopszélességeket a szélességi aránnyal és a minimális sormagasságokat a magassági aránnyal, majd a táblázat pozícióját méretezi, ahogy a második példában látható.

**Ez az átméretezés működik a mesterdiákon és elrendezés diákon is?**

Igen. A második példa végig iterál a [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) és minden mester [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) elemein, és ugyanazt az átméretezési logikát alkalmazza az alakzataikra.

**Módosíthatom a dia tájolását (álló/fekvő) az átméretezéssel együtt?**

Igen. Hívja meg a [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) metódust a diaméret módosítása után és a célméretek beolvasása előtt, hogy a skálázási tényezők a végső tájolást tükrözzék.

**Van korlátozás a beállítható diaméretre?**

A [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) metódussal egyedi diaméreteket adhat meg. A támogatott méretek szintén a bemutató formátumától és a fájlt megnyitó alkalmazástól függenek.

**Hogyan akadályozhatom meg, hogy a rögzített méretarányú alakzatok torzuljanak?**

Használja ugyanazt a skálafaktort a szélességhez és a magassághoz. Az eredeti elrendezés új diaméretekbe való illesztéséhez mindkét mérethez és pozícióhoz a szélességi és magassági arányok közül kisebbet vegye. Ez megőrzi az arányokat, de előfordulhat, hogy egy oldal mentén üres hely marad.