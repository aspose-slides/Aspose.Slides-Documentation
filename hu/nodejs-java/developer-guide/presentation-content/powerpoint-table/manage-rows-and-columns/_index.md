---
title: PowerPoint táblázatok sorainak és oszlopainak kezelése JavaScript használatával
linktitle: Sorok és oszlopok
type: docs
weight: 20
url: /hu/nodejs-java/manage-rows-and-columns/
keywords:
- táblázat sor
- táblázat oszlop
- első sor
- táblázat fejléce
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
description: "Kezelje a táblázat sorait és oszlopait PowerPointban JavaScript és Aspose.Slides for Node.js segítségével Java-n keresztül, és gyorsítsa fel a prezentáció szerkesztését és az adatfrissítéseket."
---
## **Bevezetés**

Annak érdekében, hogy kezelni tudja a táblázat sorait és oszlopait egy PowerPoint-prezentációban, az Aspose.Slides a [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/table/) osztályt és egyéb típusokat biztosít.

## **Első sor beállítása fejlécként**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból, és töltse be a prezentációt.  
2. Szerezze be a dia hivatkozását az indexe alapján.  
3. Hozzon létre egy [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektumot, és állítsa null értékre.  
4. Iteráljon végig az összes [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) objektumon, hogy megtalálja a megfelelő táblázatot.  
5. Állítsa be a táblázat első sorát fejlécként.  

Ez a JavaScript kód megmutatja, hogyan állítható be egy táblázat első sora fejlécként:

```javascript
// Példányosítja a Presentation osztályt
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // Eléri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Inicializálja a null TableEx-et
    var tbl = null;
    // Iterál a formákon, és beállít egy hivatkozást a táblázatra
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Beállítja a táblázat első sorát fejlécként
            tbl.setFirstRow(true);
        }
    }
    // A prezentációt lemezre menti
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Táblázat sorának vagy oszlopának klónozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból, és töltse be a prezentációt,  
2. Szerezze be a dia hivatkozását az indexe alapján.  
3. Definiáljon egy `columnWidth` tömböt.  
4. Definiáljon egy `rowHeight` tömböt.  
5. Adjon egy [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektumot a diára a [addTable](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) metódus segítségével.  
6. Klónozza a táblázat sorát.  
7. Klónozza a táblázat oszlopát.  
8. Mentse el a módosított prezentációt.  

Ez a JavaScript kód megmutatja, hogyan klónozhatja egy PowerPoint táblázat sorát vagy oszlopát:

```javascript
// Példányosítja a Presentation osztályt
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // Eléri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Definiálja az oszlopokat szélességekkel és a sorokat magasságokkal
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Táblázat alakzatot ad a diára
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Szöveget ad hozzá az 1. sor 1. cellájához
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // Szöveget ad hozzá az 1. sor 2. cellájához
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // Klónozza az 1. sort a táblázat végén
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // Szöveget ad hozzá a 2. sor 1. cellájához
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // Szöveget ad hozzá a 2. sor 2. cellájához
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // Klónozza a 2. sort a táblázat 4. soraként
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // Klónozza az első oszlopot a végén
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // Klónozza a 2. oszlopot a 4. oszlop indexén
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // Mentse a prezentációt lemezre
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sor vagy oszlop eltávolítása a táblázatból**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból, és töltse be a prezentációt,  
2. Szerezze be a dia hivatkozását az indexe alapján.  
3. Definiáljon egy `columnWidth` tömböt.  
4. Definiáljon egy `rowHeight` tömböt.  
5. Adjon egy [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektumot a diára a [addTable](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) metódus segítségével.  
6. Távolítsa el a táblázat sorát.  
7. Távolítsa el a táblázat oszlopát.  
8. Mentse el a módosított prezentációt.  

Ez a JavaScript kód megmutatja, hogyan távolíthat el egy sort vagy oszlopot egy táblázatból:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Szövegformázás beállítása a táblázat sor szintjén**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból, és töltse be a prezentációt,  
2. Szerezze be a dia hivatkozását az indexe alapján.  
3. Érje el a megfelelő [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektumot a diáról.  
4. Állítsa be az első sor celláinak [setFontHeight(float value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Állítsa be az első sor celláinak [setAlignment(int value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) és [setMarginRight(float value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) értékeit.  
6. Állítsa be a második sor celláinak [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Mentse el a módosított prezentációt.  

Ez a JavaScript kód demonstrálja a műveletet.

```javascript
// Létrehozza a Presentation osztály egy példányát
var pres = new aspose.slides.Presentation();
try {
    // Tegyük fel, hogy a első dián az első alakzat egy táblázat
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Beállítja az első sor celláinak betűmagasságát
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // Beállítja az első sor celláinak szövegigazítását és jobb margóját
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // Beállítja a második sor celláinak függőleges szöveg típusát
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // Mentse a prezentációt lemezre
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Szövegformázás beállítása a táblázat oszlop szintjén**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból, és töltse be a prezentációt,  
2. Szerezze be a dia hivatkozását az indexe alapján.  
3. Érje el a megfelelő [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Table) objektumot a diáról.  
4. Állítsa be az első oszlop celláinak [setFontHeight(float value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Állítsa be az első oszlop celláinak [setAlignment(int value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) és [setMarginRight(float value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) értékeit.  
6. Állítsa be a második oszlop celláinak [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Mentse el a módosított prezentációt.  

Ez a JavaScript kód demonstrálja a műveletet:

```javascript
// Létrehozza a Presentation osztály egy példányát
var pres = new aspose.slides.Presentation();
try {
    // Tegyük fel, hogy az első dián az első alakzat egy táblázat
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Beállítja az első oszlop celláinak betűmagasságát
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // Beállítja az első oszlop celláinak szövegigazítását és jobb margóját egy hívásban
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // Beállítja a második oszlop celláinak függőleges szövegtípusát
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Táblázat stílus tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy táblázat stílus tulajdonságait, hogy ezeket az adatokat egy másik táblázathoz vagy máshová felhasználhassa. Ez a JavaScript kód megmutatja, hogyan lehet lekérni a stílus tulajdonságokat egy előre beállított táblázat stílusból:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// az alapértelmezett stílus előre beállított témáját módosítja
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Alkalmazhatok PowerPoint témákat/stílusokat egy már létrehozott táblázatra?**

Igen. A táblázat örökli a dia/lekép/mester téma beállításait, és továbbra is felülbírálhatja a kitöltéseket, szegélyeket és szövegszíneket ezen a témán.

**Rendezhetem a táblázat sorait, mint az Excelben?**

Nem, az Aspose.Slides táblázatok nem rendelkeznek beépített rendezéssel vagy szűrőkkel. Először rendezze az adatokat a memóriában, majd töltse újra a táblázat sorait ebben a sorrendben.

**Lehet sávos (csíkozott) oszlopokat használni, miközben egyedi színeket tartok meg bizonyos cellákon?**

Igen. Kapcsolja be a sávos oszlopokat, majd felülbírálja a meghatározott cellákat helyi formázással; a cellaszintű formázás előnyt élvez a táblázat stílussal szemben.