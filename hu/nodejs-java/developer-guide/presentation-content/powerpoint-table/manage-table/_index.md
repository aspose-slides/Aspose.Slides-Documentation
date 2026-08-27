---
title: PowerPoint táblázatok kezelése JavaScript-ben
linktitle: Táblázat kezelése
type: docs
weight: 10
url: /hu/nodejs-java/manage-table/
keywords:
- táblázat hozzáadása
- táblázat létrehozása
- táblázat elérése
- méretarány
- szöveg igazítása
- szövegformázás
- táblázat stílus
- PowerPoint
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Hozzon létre és szerkesszen táblázatokat PowerPoint diákkal JavaScript és a Node.js‑hez készült Aspose.Slides segítségével. Fedezzen fel egyszerű kódpéldákat, amelyek egyszerűsítik a táblázatkezelési folyamatait."
---
## **Bevezetés**

A PowerPoint táblázat hatékony módja az információ megjelenítésének és ábrázolásának. A sorokba és oszlopokba rendezett cellahálóban lévő információ egyszerű és könnyen érthető.

Az Aspose.Slides biztosítja a [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) osztályt, a [Cell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cell/) osztályt és egyéb típusokat, amelyek segítségével létrehozhat, frissíthet és kezelhet táblázatokat mindenféle bemutatóban.

## **Táblázat létrehozása az alapoktól**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg a dia hivatkozását az indexén keresztül. 
3. Határozzon meg egy `columnWidth` tömböt.
4. Határozzon meg egy `rowHeight` tömböt.
5. Adjon egy [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektumot a diára a [addTable](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) metódus segítségével.
6. Iteráljon végig minden [Cell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cell/) objektumon, és alkalmazza a formázást a felső, alsó, jobb és bal szegélyekre.
7. Egyesítse a táblázat bal felső sarkában található négy cellát (az első két oszlop az első két sorból) egyetlen cellává. 
8. Szerezze meg egy [Cell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cell/) [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)-jét.
9. Adjon szöveget a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)-hez.
10. Mentse el a módosított bemutatót.

Ez a JavaScript kód bemutatja, hogyan hozhat létre táblázatot egy bemutatóban:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Eléri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Meghatározza az oszlopok szélességét és a sorok magasságát
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Táblázat alakzatot ad a diára
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Beállítja a szegély formátumát minden cellához
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Összevonja a bal felső 2x2-es cellablokkot egy cellává
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Szöveget ad a összevont cellához
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Mentse a bemutatót a lemezre
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Számozás szabványos táblázatban**

Egy szabványos táblázatban a cellák számozása egyszerű és nullától indul. Az első cella indexe 0,0 (oszlop 0, sor 0). 

Például egy 4 oszlopból és 4 sorból álló táblázat celláit a következőképpen számozzák:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a JavaScript kód bemutatja, hogyan adhatja meg a cellák számozását egy táblázatban:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Eléri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Meghatározza az oszlopok szélességét és a sorok magasságát
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Táblázat alakzatot ad a diára
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Beállítja a szegély formátumát minden cellához
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Mentse a bemutatót a lemezre
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Meglévő táblázat elérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg a táblázatot tartalmazó dia hivatkozását az indexén keresztül. 
3. Hozzon létre egy [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektumot, és állítsa null-ra.
4. Iteráljon végig az összes [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) objektumon, amíg meg nem találja a táblázatot.

   Ha úgy gondolja, hogy a vizsgálandó dia egyetlen táblázatot tartalmaz, egyszerűen ellenőrizheti az összes benne lévő alakzatot. Ha egy alakzatot táblázatként azonosít, típuscastolhatja [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektummá. Ha viszont a dia több táblázatot tartalmaz, jobban jár, ha a szükséges táblázatot a [setAlternativeText(String value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-) metódussal keresi.
5. Használja a [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektumot a táblázat kezelésére. Az alábbi példában egy cella szövegét állítjuk be a táblázatban.
6. Mentse el a módosított bemutatót.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Eléri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Inicializálja a null TableEx-et
    var tbl = null;
    // Iterál a shape-eken, és beállít egy hivatkozást a megtalált táblázatra
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Beállítja a szöveget a második sor első oszlopában
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Mentse a módosított bemutatót a lemezre
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Keresse meg a TextFrame-et tartalmazó cellát**

Amikor egy általános szövegfeldolgozó kód egy [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) objektumot kap egy táblázatból, használja a [TextFrame.getParentCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getParentCell--) metódust a tulajdonos [Cell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cell/) lekéréséhez. Egy táblázatcellás szövegkeret esetén a [TextFrame.getParentCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getParentCell--) visszaadja a tulajdonost, míg a [TextFrame.getParentShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getParentShape--) `null`-t ad, bár a táblázat maga is egy shape.

Az cella koordinátái a csak olvasható [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) és [Cell.getFirstRowIndex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) metódusokon keresztül érhetők el. A [TextFrame.getParentCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getParentCell--) szintén csak olvasható navigációt biztosít: visszaadja a tulajdonost, de nem változtatja meg a tulajdonosi viszonyt. Mindig ellenőrizze a visszakapott cellát `null`-ra, mielőtt felhasználja.

Egy teljes példáért, amely azonosítja a táblázatcellák és shape-ok tulajdonosait, beleértve a SmartArt csomópontokhoz kapcsolódó shape-okat, lásd a [Search and Replace Text](/slides/hu/nodejs-java/search-and-replace-text/) oldalt.

## **Szöveg igazítása a táblázatban**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg a dia hivatkozását az indexén keresztül. 
3. Adjon egy [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektumot a diára.
4. Szerezze meg a táblázatból egy [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) objektumot.
5. Szerezze meg a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/)-ját.
6. Igazítsa a szöveget függőlegesen.
7. Mentse el a módosított bemutatót.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Létrehozza a Presentation osztály egy példányát
var pres = new aspose.slides.Presentation();
try {
    // Lekéri az első diát
    var slide = pres.getSlides().get_Item(0);
    // Meghatározza az oszlopok szélességét és a sorok magasságát
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Hozzáadja a táblázat alakzatot a diához
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Eléri a szövegkeretet
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Létrehozza a Paragraph objektumot a szövegkerethez
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Létrehozza a Portion objektumot a bekezdéshez
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Függőlegesen igazítja a szöveget
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // Mentse a bemutatót a lemezre
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Szövegformázás beállítása táblázatszinten**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg a dia hivatkozását az indexén keresztül. 
3. Szerezze meg a [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektumot a diáról.
4. Állítsa be a [setFontHeight(float value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) értéket a szöveghez.
5. Állítsa be a [setAlignment(int value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) és a [setMarginRight(float value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) értékeket.
6. Állítsa be a [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) értéket.
7. Mentse el a módosított bemutatót. 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Létrehozza a Presentation osztály egy példányát
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Tegyük fel, hogy az első dia első alakzata egy táblázat
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Beállítja a táblázat celláinak betűmagasságát
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Beállítja a táblázat celláinak szövegigazítását és jobb margóját egy hívásban
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Beállítja a táblázat celláinak szöveg függőleges típusát
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Táblázat stílus előbeállításának beállítása**

Az Aspose.Slides a beépített PowerPoint táblázatstílusokat a [TableStylePreset](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tablestylepreset/) felsorolásként biztosítja, így bármely táblázatra alkalmazhatja ugyanazt a megjelenést. Ez a JavaScript kód bemutatja, hogyan cserélje le egy táblázat alapértelmezett stílusát egy előre definiált stílusra:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// módosítja az alapértelmezett stílus előbeállítás témát
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Táblázat méretarányának zárolása**

A geometriai alakzat méretaránya a méretei különböző dimenziókban való aránya. Az Aspose.Slides a [**setAspectRatioLocked**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) tulajdonságot biztosítja, amely lehetővé teszi a táblázatok és egyéb alakzatok méretarányának zárolását.

Ez a JavaScript kód bemutatja, hogyan zárolja a méretarányt egy táblázat esetén:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invertálja
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Engedélyezhetem a jobbról balra (RTL) olvasási irányt egy egész táblázat és a celláiban lévő szöveg esetén?**

Igen. A táblázat rendelkezik a [setRightToLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/table/setrighttoleft/) metódussal, és a bekezdéseknek van a [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/) metódusa. Mindkettő használata biztosítja a helyes RTL sorrendet és megjelenítést a cellákban.

**Hogyan akadályozhatom meg, hogy a felhasználók áthelyezzék vagy átméretezzék a táblázatot a végleges fájlban?**

Használjon alakzatzárakat a mozgatás, átméretezés, kiválasztás stb. letiltásához. Ezek a zárak a táblázatokra is érvényesek.

**Támogatott-e egy kép beillesztése egy cellába háttérként?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/) típusú kitöltést egy cellához; a kép a kiválasztott mód (nyújtás vagy csempézés) szerint lefedi a cellaterületet.