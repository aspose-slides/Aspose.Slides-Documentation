---
title: Sorok és oszlopok kezelése PowerPoint táblázatokban Java használatával
linktitle: Sorok és oszlopok
type: docs
weight: 20
url: /hu/java/manage-rows-and-columns/
keywords:
- táblázat sor
- táblázat oszlop
- első sor
- táblázat fejléc
- sor klónozása
- oszlop klónozása
- sor másolása
- oszlop másolása
- sor eltávolítása
- oszlop eltávolítása
- sor szövegformázása
- oszlop szövegformázása
- táblázat stílus
- PowerPoint
- bemutató
- Java
- Aspose.Slides
description: "Kezelje a táblázat sorait és oszlopait PowerPoint-ban az Aspose.Slides for Java-val, és gyorsítsa fel a bemutató szerkesztését és az adatok frissítését."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint bemutatóban a táblázat sorait és oszlopait kezelje, ezért biztosítja a [Table](https://reference.aspose.com/slides/hu/java/com.aspose.slides/table/) osztályt, az [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITable) interfészt és sok más típust. 

## **Az első sor beállítása fejlécnek**

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály példányt, és töltse be a bemutatót. 
2. Szerezzen be egy dia hivatkozását az indexe alapján. 
3. Hozzon létre egy [ITable] objektumot, és állítsa nullra. 
4. Iteráljon végig az összes [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) objektumon, hogy megtalálja a megfelelő táblázatot. 
5. Állítsa be a táblázat első sorát fejlécként. 

Ez a Java kód megmutatja, hogyan állítható be a táblázat első sora fejlécként:

```java
// Létrehozza a Presentation osztályt
Presentation pres = new Presentation("table.pptx");
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicializálja a null TableEx-et
    ITable tbl = null;

    // Végigiterál a alakzatokon, és beállít egy hivatkozást a táblázatra
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Beállítja a táblázat első sorát fejlécként
            tbl.setFirstRow(true);
        }
    }
    
    // Elmenti a bemutatót a lemezre
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Táblázat sor vagy oszlop klónozása**

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály példányt, és töltse be a bemutatót, 
2. Szerezzen be egy dia hivatkozását az indexe alapján. 
3. Definiáljon egy `columnWidth` tömböt. 
4. Definiáljon egy `rowHeight` tömböt. 
5. Adjon egy [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITable) objektumot a diára az [addTable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) metódus segítségével. 
6. Klónozza a táblázat sorát. 
7. Klónozza a táblázat oszlopát. 
8. Mentse el a módosított bemutatót. 

Ez a Java kód megmutatja, hogyan klónozható egy PowerPoint táblázat sora vagy oszlopa:

```java
 // Létrehozza a Presentation osztályt
Presentation pres = new Presentation("Test.pptx");
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiálja az oszlopokat szélességgel és a sorokat magassággal
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Táblázat alakzatot ad a diához
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Szöveget ad a 1. sor 1. cellájához
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Szöveget ad a 1. sor 2. cellájához
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Klónozza az 1. sort a táblázat végén
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Szöveget ad a 2. sor 1. cellájához
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Szöveget ad a 2. sor 2. cellájához
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Klónozza a 2. sort a táblázat 4. soraként
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Klónozza az első oszlopot a végén
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Klónozza a 2. oszlopot a 4. oszlop indexén
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Elmenti a bemutatót a lemezre
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sor vagy oszlop eltávolítása a táblázatból**

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály példányt, és töltse be a bemutatót, 
2. Szerezzen be egy dia hivatkozását az indexe alapján. 
3. Definiáljon egy `columnWidth` tömböt. 
4. Definiáljon egy `rowHeight` tömböt. 
5. Adjon egy [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITable) objektumot a diára az [addTable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) metódus segítségével. 
6. Távolítsa el a táblázat sorát. 
7. Távolítsa el a táblázat oszlopát. 
8. Mentse el a módosított bemutatót. 

Ez a Java kód megmutatja, hogyan távolítható el egy sor vagy oszlop a táblázatból:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szövegformázás beállítása táblázat sor szinten**

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály példányt, és töltse be a bemutatót, 
2. Szerezzen be egy dia hivatkozását az indexe alapján. 
3. Érje el a megfelelő [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITable) objektumot a diárról. 
4. Állítsa be az első sor celláinak [setFontHeight(float value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. Állítsa be az első sor celláinak [setAlignment(int value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) és [setMarginRight(float value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) értékeit. 
6. Állítsa be a második sor celláinak [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. Mentse el a módosított bemutatót. 

Ez a Java kód bemutatja a műveletet.

```java
// Létrehozza a Presentation osztály egy példányát
Presentation pres = new Presentation();
try {
    // Tegyük fel, hogy az első dia első alakzata egy táblázat
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Beállítja az első sor celláinak betűmagasságát
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Beállítja az első sor celláinak szövegigazítását és jobb margóját
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Beállítja a második sor celláinak függőleges szövegtípusát
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Elmenti a bemutatót a lemezre
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szövegformázás beállítása táblázat oszlop szinten**

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály példányt, és töltse be a bemutatót, 
2. Szerezzen be egy dia hivatkozását az indexe alapján. 
3. Érje el a megfelelő [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITable) objektumot a diárról. 
4. Állítsa be az első oszlop celláinak [setFontHeight(float value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. Állítsa be az első oszlop celláinak [setAlignment(int value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) és [setMarginRight(float value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) értékeit. 
6. Állítsa be a második oszlop celláinak [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. Mentse el a módosított bemutatót. 

Ez a Java kód bemutatja a műveletet: 

```java
// Létrehozza a Presentation osztály egy példányát
Presentation pres = new Presentation();
try {
    // Tegyük fel, hogy az első dia első alakzata egy táblázat
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Beállítja az első oszlop celláinak betűmagasságát
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Beállítja az első oszlop celláinak szövegigazítását és jobb margóját egy hívással
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Beállítja a második oszlop celláinak függőleges szövegtípusát
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **A táblázat stílustulajdonságainak lekérése**

Aspose.Slides lehetővé teszi, hogy egy táblázat stílustulajdonságait lekérje, így ezeket az adatokat felhasználhatja egy másik táblázatnál vagy más helyen. Ez a Java kód megmutatja, hogyan lehet lekérni egy táblázat előre definiált stílusának tulajdonságait:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // módosítja az alapértelmezett stílus előre beállított témát
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Alkalmazhatok PowerPoint témákat/stílusokat egy már létrehozott táblázatra?**

Igen. A táblázat örökli a dia/elrendezés/mester téma beállításait, és továbbra is felülírhatja a kitöltéseket, szegélyeket és szövegszíneket a téma felett.

**Rendezhetem a táblázat sorait úgy, mint az Excelben?**

Nem, az Aspose.Slides táblázatok nem rendelkeznek beépített rendezéssel vagy szűrőkkel. Először memóriában rendezze az adatokat, majd ebben a sorrendben töltse újra a táblázat sorait.

**Lehetnek csíkos (sávos) oszlopok, miközben egyedi színek maradnak bizonyos cellákon?**

Igen. Kapcsolja be a csíkos oszlopokat, majd felülírja a specifikus cellákat helyi formázással; a cellaszintű formázás felülírja a táblázat stílusát.