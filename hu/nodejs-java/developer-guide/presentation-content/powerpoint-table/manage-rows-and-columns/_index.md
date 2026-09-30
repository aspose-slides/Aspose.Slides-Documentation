---
title: PowerPoint táblázatok sorainak és oszlopainak kezelése JavaScript használatával
linktitle: Sorok és oszlopok
type: docs
weight: 20
url: /hu/nodejs-java/manage-rows-and-columns/
keywords:
- táblázatsor
- táblázatoszlop
- első sor
- táblázatfejléc
- sor klónozása
- oszlop klónozása
- sor másolása
- oszlop másolása
- sor eltávolítása
- oszlop eltávolítása
- sor szövegformázás
- oszlop szövegformázás
- táblázat stílus
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezeled a PowerPoint táblázatok sorait és oszlopait JavaScript és az Aspose.Slides for Node.js via Java segítségével, és felgyorsítod a prezentáció szerkesztését és az adatok frissítését."
---
## **Bevezetés**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy a táblázat szerkezetét és formázását kezelje PowerPoint‑prezentációkban a [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) osztályon keresztül. Kijelölhet egy fejléces sort, másolhat vagy eltávolíthat sorokat és oszlopokat, és alkalmazhat szövegformázást egy teljes sorra vagy oszlopra.

Ez a cikk bemutatja ezeket a műveleteket JavaScript‑példákkal. Emellett megmutatja, hogyan lehet lekérni egy táblázat stílus‑előbeállítását, hogy újra felhasználhassa azt. A táblázat sor- és oszlopszámai nullával kezdődnek.

## **Sor magasságának szabályozása**

Használja a [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) metódust a sor minimális magasságának pontban történő beállításához. Ez egy alsó határ, nem rögzített magasság. A [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) a tényleges magasságot adja vissza. A sort a [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--) segítségével érheti el.

Az példa betölti a [row-height-input.pptx](row-height-input.pptx) fájlt, amely első dián az első alakzatként táblázatot tartalmaz. Az első sor 70 ponttal kezdődik. A cellák 18 pontos Arial szöveget, sortörést és 6 pontos felső és alsó margót használnak; a második oszlopban lévő hosszabb szöveg több sorba törik. A példa növeli a minimumot 100 pontra, majd csökkenti 20 pontra, minden változtatás után kiírja a tényleges magasságot, és elmenti mindkét eredményt.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A biztosított prezentáció esetén a minimum növelése helyet ad a sornak. A csökkentés eltávolítja ezt a plusz helyet, de a tényleges magasság továbbra is nagyobb, mint 20 pont, mivel a szövegnek és a cella margóknak több helyre van szükségük. A minimum önmagában való csökkentése nem tudja a sort a tartalma által igényelt hely alá szorítani.

Több tényező befolyásolja a tényleges magasságot:
- **Szöveg és betűméret:** a hosszabb szöveg, a kifejezett sortörések vagy egy nagyobb betűméret több függőleges helyet igényelhet.
- **Sortörés és oszlopszélesség:** a sortörés engedélyezésekor az oszlopszélesség csökkentése a [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) metódussal több sor keletkezik. Egy szélesebb oszlop csökkentheti a függőleges helyigényt.
- **Cella margók:** a [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) és a [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) függőleges helyet adnak. A [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) és a [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) csökkentik a szöveg számára rendelkezésre álló szélességet, és további sortörést eredményezhetnek.

Ebben a táblázatban, amelyben nincsenek egyesített cellák, a legmagasabb függőleges helyet igénylő cella határozza meg a sor tartalom által meghatározott alsó határát. A sor rövidebbé tételéhez szükség lehet a szöveg rövidítésére, a betűméret vagy a margók csökkentésére, vagy egy oszlop szélesítésére.

Az alábbi képek ugyanazt a táblázatot ugyanabban a méretarányban mutatják. A bemutatott eredményekben a tényleges magasságok 70, 100 és 55.2 pont voltak: az utolsó sor magasabb maradt a 20 pontos minimumnál. A pontos szövegméretezés változhat a környezetben elérhető betűkészletektől. Töltse le a mentett eredményeket: [növelt minimum](row-height-increased.pptx) és [csökkentett minimum](row-height-decreased.pptx).

| Eredeti: minimum 70 pt, tényleges 70 pt | Növelt: minimum 100 pt, tényleges 100 pt | Csökkentett: minimum 20 pt, tényleges 55.2 pt |
| --- | --- | --- |
| ![Eredeti táblázat 70 pontos első sorral.](row-height-before.png) | ![Táblázat a első sor minimumának 100 pontra növelése után.](row-height-increased.png) | ![Táblázat a első sor minimumának 20 pontra csökkentése után; a sortörés a sort a minimumnál magasabban tartja.](row-height-decreased.png) |

## **Az első sor beállítása fejlécnek**

Használja a [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) metódust, hogy az első sort fejlécformázásra jelölje. Megjelenése a táblára alkalmazott táblázatstílustól függ.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztállyal.
2. Érje el az első diát.
3. Érje el a dián az első alakzatként tárolt táblázatot.
4. Engedélyezze a fejlécformázást az első sor számára.
5. Mentse a módosított prezentációt.

A példa a `table.pptx` fájlt igényli, amely első dián az első alakzatként táblázatot tartalmaz. Engedélyezi a fejlécformázást az első sorra, és elmenti a `First_row_header.pptx` fájlt.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Táblázat sor vagy oszlop klónozása**

Klónozza a sorokat vagy oszlopokat, hogy újra felhasználja azok tartalmát és formázását. Egy másolatot a táblázat végéhez fűzhet vagy egy adott pozícióba beillesztheti.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztállyal.
2. Érje el az első diát.
3. Határozza meg az oszlopszélességeket és a sormagasságokat.
4. Adjon hozzá egy táblázatot a [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) metódussal.
5. Klónozza a szükséges sorokat.
6. Klónozza a szükséges oszlopokat.
7. Mentse a módosított prezentációt.

A példa a `Test.pptx` fájlt igényli, amely legalább egy diát tartalmaz. Létrehoz egy táblázatot három oszloppal és öt sorral, a méreteket pontban megadva. Hozzáfűzi az első sor és oszlop másolatait, majd a második sor és oszlop másolatait a 3-as indexre (a negyedik pozíció) illeszti. Az eredő táblázat hét sort és öt oszlopot tartalmaz. A `false` argumentum letiltja a klónozást szomszédos egyesített sorokba vagy oszlopokba; ez a táblázat nem tartalmaz egyesített cellákat.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sor vagy oszlop eltávolítása a táblázatból**

Távolítson el sorokat vagy oszlopokat, amelyekre már nincs szükség a táblázatban. Egy elem eltávolítása eltolja a mögötte lévő sorok vagy oszlopok indexeit.

1. Hozzon létre egy prezentációt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztállyal.
2. Érje el az első diát.
3. Határozza meg az oszlopszélességeket és a sormagasságokat.
4. Adjon hozzá egy táblázatot a [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) metódussal.
5. Távolítsa el a második sort és a második oszlopot.
6. Mentse a módosított prezentációt.

Ez a példa egy három‑háromas táblázatot hoz létre, és eltávolítja az 1‑es indexű sort és oszlopot, így egy két‑kétas táblázat marad a `TestTable_out.pptx` fájlban. A méretek pontban vannak megadva. A `false` argumentum letiltja a szomszédos egyesített sorok vagy oszlopok eltávolítását; ez a táblázat nem tartalmaz egyesített cellákat.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Szövegformázás beállítása a táblázatsor szintjén**

Alkalmazzon szövegformázást egy teljes sorra, hogy a cellák egységesek legyenek. Betűtulajdonságokat, bekezdésformázást és szövegirányt állíthat be anélkül, hogy egyesével formázná a cellákat.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztállyal.
2. Érje el a táblázatot az első dián.
3. Használja a [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) metódust az első sorra.
4. Használja a [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) és a [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) metódusokat az első sorra.
5. Használja a [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) metódust a második sorra.
6. Mentse a módosított prezentációt.

A példa a `table.pptx` fájlt igényli, amely első dián az első alakzatként táblázatot tartalmaz és legalább két sort tartalmaz. Az első sorra 25 pontos szöveget, jobb igazítást és 20 pontos jobb bekezdésmargót alkalmaz, majd a második sorra függőleges szöveget állít be.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Szövegformázás beállítása a táblázatoszlop szintjén**

Alkalmazzon szövegformázást egy teljes oszlopra, hogy a cellák egységesek legyenek. Betűtulajdonságokat, bekezdésformázást és szövegirányt állíthat be anélkül, hogy egyesével formázná a cellákat.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztállyal.
2. Érje el a táblázatot az első dián.
3. Használja a [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) metódust az első oszlopra.
4. Használja a [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) és a [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) metódusokat az első oszlopra.
5. Használja a [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) metódust a második oszlopra.
6. Mentse a módosított prezentációt.

A példa a `table.pptx` fájlt igényli, amely első dián az első alakzatként táblázatot tartalmaz és legalább két oszlopot tartalmaz. Az első oszlopra 25 pontos szöveget, jobb igazítást és 20 pontos jobb bekezdésmargót alkalmaz, majd a második oszlopra függőleges szöveget állít be.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Táblázat stílus tulajdonságainak lekérdezése**

Használja a [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) metódust, hogy lekérje egy táblázatra alkalmazott előbeállítást, és újra felhasználja egy másik táblázaton. Ez az előbeállítást azonosítja, nem pedig az egyedi cellaformázási felülírásokat.

A példa létrehoz egy táblázatot, alkalmazza a [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1) előbeállítást, majd visszaolvassa azt. Kiírja a `DarkStyle1`‑nek megfelelő egész értéket, és elmenti a táblázatot a `table.pptx` fájlba.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Alkalmazhatok PowerPoint‑témákat/stílusokat egy már létrehozott táblázatra?**

Igen. A táblázat örökli a dia/oldal/elrendezés/mester téma beállításait, és továbbra is felülírhatja a kitöltéseket, szegélyeket és a szövegszíneket ezen a témán.

**Rendezhetem a táblázat sorait, mint az Excel‑ben?**

Nem, az Aspose.Slides táblázatok nem rendelkeznek beépített rendezéssel vagy szűrőkkel. Először rendezze az adatokat a memóriában, majd töltse újra a táblázat sorait ebben a sorrendben.

**Lehet-e csíkozott (csíkozott) oszlopok, miközben egyes cellák egyéni színeit megtartom?**

Igen. Kapcsolja be a csíkozott oszlopokat, majd felülírja a konkrét cellákat helyi formázással; a cellaszintű formázás előnyben részesül a táblázat stílusával szemben.