---
title: Táblacellák kezelése prezentációkban JavaScript használatával
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/nodejs-java/manage-cells/
keywords:
- táblacella
- cellák egyesítése
- szegély eltávolítása
- cella felosztása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezelje a táblacellákat PowerPointban az Aspose.Slides for Node.js segítségével. Tanulja meg a cellák gyors elérését, módosítását és formázását a zökkenőmentes diák automatizálásához."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi a táblázatcellák elérését és módosítását PowerPoint‑prezentációkban. Ebben a cikkben bemutatjuk, hogyan azonosítsuk a egyesített táblázatcellákat, hogyan távolítsuk el a cellaszegélyeket, hogyan kezeljük a cellaszámozást egyesítés vagy felosztás után, hogyan változtassuk meg egy cella háttérszínét, és hogyan adjunk képet egy táblázatcellához. A példák bemutatják, hogyan hozzunk létre vagy nyissunk meg egy prezentációt, hogyan szerezzünk be egy táblát egy diából, hogyan frissítsük a cella formázását a cella tulajdonságai alapján, és hogyan mentjük a módosított prezentációt PPTX fájlként.

## **Egyesített táblázatcella azonosítása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze be a táblát az első diáról.
3. Iteráljon a tábla sorain és oszlopain, hogy megtalálja az egyesített cellákat.
4. Írjon ki üzenetet, amikor egyesített cellákat talál.

Ez a JavaScript kód bemutatja, hogyan azonosítsa az egyesített táblázatcellákat egy prezentációban:

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// feltételezve, hogy a Slide#0.Shape#0 egy táblázat
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Táblacellák szegélyének eltávolítása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezzen referenciát egy diára az indexével.
3. Határozzon meg egy oszlopok szélességét tartalmazó tömböt.
4. Határozzon meg egy sorok magasságát tartalmazó tömböt.
5. Adjon hozzá egy táblát a diához a [addTable](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) metódussal.
6. Iteráljon minden cellán, hogy törölje a felső, alsó, jobb és bal szegélyeket.
7. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript kód bemutatja, hogyan távolítsa el a szegélyeket a táblacellákról:

```javascript
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Eléri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Táblázat alakzatot ad hozzá a diához
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Beállítja a szegély formátumát minden cellához
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // A PPTX fájlt lemezre írja
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Számozás egyesített cellákban**

Ha két cellapárt egyesítünk (1,1) x (2,1) és (1,2) x (2,2), a kapott tábla számozott lesz. Ez a JavaScript kód bemutatja a folyamatot:

```javascript
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Eléri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
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
    // Egyesíti a cellákat (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Egyesíti a cellákat (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ezután tovább egyesítjük a cellákat (1,1) és (1,2) összevonásával. Az eredmény egy középen nagy egyesített cellát tartalmazó tábla:

```javascript
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Eléri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Táblázat alakzatot ad a diához
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
    // Egyesíti a cellákat (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Egyesíti a cellákat (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Egyesíti a cellákat (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // A PPTX fájlt lemezre írja
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Számozás felosztott cellában**

Az előző példákban, amikor a táblacellákat egyesítették, a többi cellában a számozás vagy számrendszer nem változott.

Ezúttal egy szabályos táblát (azaz egy olyan táblát, amelyben nincsenek egyesített cellák) veszünk, és megpróbáljuk felosztani a (1,1) cellát, hogy egy speciális táblát kapjunk. Érdemes figyelni a tábla számozására, amely furcsának tűnhet. Ennek azonban a Microsoft PowerPoint táblacellák számozásának módja, és az Aspose.Slides is ugyanezt teszi.

Ez a JavaScript kód bemutatja a leírt folyamatot:

```javascript
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Eléri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Táblázat alakzatot ad a diához
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
    // Egyesíti a cellákat (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Egyesíti a cellákat (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Felosztja a (1, 1) cellát
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // A PPTX fájlt lemezre írja
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Táblacellák háttérszínének módosítása**

Ez a JavaScript kód bemutatja, hogyan változtassa meg egy táblacella háttérszínét:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // új táblát hoz létre
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // beállítja egy cella háttérszínét
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Kép hozzáadása a táblacellán belül**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezzen referenciát egy diára az indexével.
3. Határozzon meg egy oszlopok szélességét tartalmazó tömböt.
4. Határozzon meg egy sorok magasságát tartalmazó tömböt.
5. Adjon hozzá egy táblát a diához a [addTable](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) metódussal.
6. Hozzon létre egy `Images` objektumot a képfájl tárolásához.
7. Adja hozzá az `IImage` képet a `PPImage` objektumhoz.
8. Állítsa be a táblacellához a `FillFormat` értékét `Picture`-re.
9. Adja hozzá a képet a tábla első cellájához.
10. Mentse a módosított prezentációt PPTX fájlként

Ez a JavaScript kód bemutatja, hogyan helyezzen el egy képet egy táblacellán belül táblát létrehozva:

```javascript
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Eléri az első diát
    var islide = pres.getSlides().get_Item(0);
    // Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // Táblázat alakzatot ad a diához
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // PPImage objektumot hoz létre a képfájl használatával
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Hozzáadja a képet az első táblacellához
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // A PPTX fájlt lemezre menti
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Beállíthatok-e különböző vonalvastagságot és stílust a cella egyes oldalain?**

Igen. A [felső](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellformat/getbordertop/)/[alsó](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[bal](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellformat/getborderleft/)/[jobb](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellformat/getborderright/) szegélyek különálló tulajdonságokkal rendelkeznek, így minden oldal vastagsága és stílusa eltérő lehet. Ez logikusan következik a cikkben bemutatott, cellánkénti oldalra vonatkozó szegélyvezérlésből.

**Mi történik a képpel, ha a háttérként beállított kép után megváltoztatom az oszlop/sor méretét?**

A viselkedés a [kitöltési mód](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillmode/) (nyújtás/csempézés) függvénye. Nyújtás esetén a kép alkalmazkodik az új cellához; csempézés esetén a csempéket újraszámítják. A cikk említi a kép megjelenítési módjait egy cellában.

**Hozzá lehet-e rendelni hiperhivatkozást a cella teljes tartalmához?**

[Hyperlinks](/slides/hu/nodejs-java/manage-hyperlinks/) a cella szövegkeretén belül a szöveg (részlet) szintjén vagy az egész táblán/alakzat szintjén állítható be. Gyakorlatban a hivatkozást egy részlethez vagy a cella teljes szövegéhez rendeli.

**Beállíthatok-e különböző betűtípusokat egyetlen cellán belül?**

Igen. A cella szövegkerete támogatja a [részleteket](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) (futtatások) független formázással – betűcsalád, stílus, méret és szín.