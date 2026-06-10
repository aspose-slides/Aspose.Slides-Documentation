---
title: Prezentációs táblázatok kezelése JavaScriptben
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
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Táblázatok létrehozása és szerkesztése PowerPoint diáknak JavaScript és Aspose.Slides for Node.js segítségével. Fedezze fel az egyszerű kódpéldákat, amelyek egyszerűsítik a táblázat munkafolyamatait."
---
## **Bevezetés**

A PowerPoint táblázat hatékony módja az információ megjelenítésének és ábrázolásának. A cellák rácsában (sorokba és oszlopokba rendezve) lévő információ egyértelmű és könnyen érthető.

Az Aspose.Slides biztosítja a [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) osztályt, a [Cell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cell/) osztályt, és egyéb típusokat, amelyek lehetővé teszik, hogy táblákat hozzon létre, frissítsen és kezeljen különféle bemutatókban.

## **Új tábla létrehozása az alapoktól**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Határozzon meg egy `columnWidth` tömböt.  
4. Határozzon meg egy `rowHeight` tömböt.  
5. Adjon hozzá egy [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektumot a diára a [addTable](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) metódussal.  
6. Iteráljon minden [Cell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cell/) elem felett, hogy alkalmazza a formázást a felső, alsó, jobb és bal szegélyekre.  
7. Fűzze össze a táblázat első sorának első két celláját.  
8. Érje el egy [Cell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) objektumát.  
9. Adjon szöveget a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)-hez.  
10. Mentse el a módosított bemutatót.

Ez a JavaScript kód megmutatja, hogyan hozhat létre egy táblát egy bemutatóban:

```javascript
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Eléri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Meghatározza az oszlopok szélességét és a sorok magasságát
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Táblázat alakzatot ad hozzá a diához
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
    // Egyesíti az első sor 1. és 2. celláit
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Szöveget ad a egyesített cellához
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Mentse a prezentációt a lemezre
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Számozás a szabványos táblában**

Egy szabványos táblában a cellák számozása egyszerű és nullától indul. A táblázat első cellájának indexe 0,0 (oszlop 0, sor 0).

Például egy 4 oszlopból és 4 sorból álló táblázat celláit így számozzák:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a JavaScript kód megmutatja, hogyan adhatja meg a cellák számozását egy táblában:

```javascript
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Eléri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Meghatározza az oszlopok szélességét és a sorok magasságát
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Táblázat alakzatot ad hozzá a diához
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
    // Mentse a prezentációt a lemezre
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Meglévő tábla elérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg a táblát tartalmazó dia hivatkozását az indexe alapján.  
3. Hozzon létre egy [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektumot, és állítsa null értékre.  
4. Iteráljon az összes [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) objektumon, amíg megtalálja a táblát.  
   Ha úgy gondolja, hogy a kezelni kívánt dia egyetlen táblát tartalmaz, egyszerűen ellenőrizheti az összes benne lévő alakzatot. Ha egy alakzatot táblaként azonosítanak, típusként átkonvertálhatja [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektummá. Ha azonban a dia több táblát tartalmaz, akkor célszerűbb a szükséges táblát a [setAlternativeText(String value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-) segítségével keresni.  
5. Használja a [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektumot a táblával való munkához. Az alábbi példában egy új sort adtunk a táblához.  
6. Mentse el a módosított bemutatót.

Ez a JavaScript kód megmutatja, hogyan érheti el és dolgozhat egy meglévő táblával:

```javascript
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Eléri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Null értékkel inicializálja a TableEx-et
    var tbl = null;
    // Végigiterál az alakzatokon és beállítja a megtalált táblára a hivatkozást
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Beállítja a szöveget a második sor első oszlopához
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Elmenti a módosított prezentációt a lemezre
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Szöveg igazítása a táblában**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektumot a diára.  
4. Hozzáférhet egy [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) objektumhoz a táblából.  
5. Érje el a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) elemet.  
6. Igazítsa a szöveget függőlegesen.  
7. Mentse el a módosított bemutatót.

Ez a JavaScript kód megmutatja, hogyan igazítható a szöveg egy táblában:

```javascript
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
    // Létrehozza a bekezdés objektumot a szövegkerethez
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Létrehozza a részlet objektumot a bekezdéshez
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Függőlegesen igazítja a szöveget
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Elmenti a prezentációt a lemezre
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Szövegformázás beállítása táblaszinten**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Érje el egy [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektumot a diákról.  
4. Állítsa be a szöveg [setFontHeight(float value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) értékét.  
5. Állítsa be a [setAlignment(int value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) és a [setMarginRight(float value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) értékeket.  
6. Állítsa be a [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) értéket.  
7. Mentse el a módosított bemutatót.

Ez a JavaScript kód megmutatja, hogyan alkalmazhatja a kívánt formázási beállításokat a táblában lévő szövegre:

```javascript
// Létrehozza a Presentation osztály egy példányát
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Tegyük fel, hogy az első dia első alakzata egy táblázat
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Beállítja a táblacellák betűmagasságát
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Beállítja a táblacellák szövegigazítását és jobb margóját egy hívásban
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Beállítja a táblacellák szöveg függőleges típusát
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Táblastílus tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi, hogy egy táblához tartozó stílustulajdonságokat lekérje, így ezeket a részleteket felhasználhatja egy másik táblához vagy máshová. Ez a JavaScript kód megmutatja, hogyan kaphatja meg a stílustulajdonságokat egy táblázat előre beállított stílusából:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// megváltoztatja az alapértelmezett stílus előre beállított témát
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Táblázat méretarányának zárolása**

Egy geometriai alakzat méretaránya annak különböző dimenziókban mért méreteinek aránya. Az Aspose.Slides a [**setAspectRatioLocked**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) tulajdonságot biztosítja, amely lehetővé teszi a táblák és egyéb alakzatok méretarány beállításának zárolását.

Ez a JavaScript kód megmutatja, hogyan zárolható a táblázat méretaránya:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Engedélyezhetem a jobbról balra (RTL) olvasási irányt egy teljes táblázat és annak celláiban lévő szöveg számára?**

Igen. A táblázat rendelkezik egy [setRightToLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/table/setrighttoleft/) módszerrel, és a bekezdéseknek [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/) metódusa van. Mindkettő használata biztosítja a helyes RTL sorrendet és megjelenítést a cellákon belül.

**Hogyan akadályozhatom meg, hogy a felhasználók a végleges fájlban mozgassák vagy átméretezzék a táblát?**

Használjon alakzatzárolókat a mozgatás, átméretezés, kijelölés stb. letiltásához. Ezek a zárolások a táblákra is érvényesek.

**Támogatott-e egy kép cellába háttérként történő beillesztése?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/) kitöltést egy cellához; a kép a választott mód (nyújtás vagy csempezés) szerint lefedi a cella területét.