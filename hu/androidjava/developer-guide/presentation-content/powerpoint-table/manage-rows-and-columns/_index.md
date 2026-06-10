---
title: Sorok és oszlopok kezelése PowerPoint táblázatokban Androidon
linktitle: Sorok és oszlopok
type: docs
weight: 20
url: /hu/androidjava/manage-rows-and-columns/
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
- sor szövegformázás
- oszlop szövegformázás
- táblázat stílus
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Kezelje a táblázatok sorait és oszlopait PowerPointban az Aspose.Slides for Android segítségével Java nyelven, és gyorsítsa fel a bemutató szerkesztését és az adatok frissítését."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint‑prezentációban kezelje egy táblázat sorait és oszlopait, és biztosítja a [Table](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/table/) osztályt, a [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) interfészt, valamint számos egyéb típust.

## **Az első sort fejlécként beállítása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból, és töltse be a prezentációt.  
2. Szerezze meg egy dia referenciáját az indexével.  
3. Hozzon létre egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) objektumot, és állítsa null értékre.  
4. Iteráljon az összes [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) objektumon, hogy megtalálja a megfelelő táblát.  
5. Állítsa a táblázat első sorát fejlécként.  

Ez a Java kód bemutatja, hogyan állítható be a táblázat első sorát fejlécként:

```java
// Létrehozza a Presentation osztályt
Presentation pres = new Presentation("table.pptx");
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicializálja a null TableEx-et
    ITable tbl = null;

    // Végig iterál a formákon és beállít egy hivatkozást a táblázatra
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Beállítja a táblázat első sorát fejlécként
            tbl.setFirstRow(true);
        }
    }
    
    // Mentse a prezentációt a lemezen
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Táblázatsor vagy -oszlop klónozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból, és töltse be a prezentációt,  
2. Szerezze meg egy dia referenciáját az indexével.  
3. Határozzon meg egy `columnWidth` tömböt.  
4. Határozzon meg egy `rowHeight` tömböt.  
5. Adjon egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) objektumot a diára az [addTable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) metódus segítségével.  
6. Klónozza a táblázatsort.  
7. Klónozza a táblázatoszlopot.  
8. Mentse a módosított prezentációt.  

Ez a Java kód bemutatja, hogyan klónozható egy PowerPoint táblázat sorát vagy oszlopát:

```java
 // Létrehozza a Presentation osztályt
Presentation pres = new Presentation("Test.pptx");
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Meghatározza az oszlopok szélességét és a sorok magasságát
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Táblázat alakzatot ad a diára
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Szöveget ad a 1. sor 1. cellájába
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Szöveget ad a 1. sor 2. cellájába
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Klónozza az 1. sort a táblázat végén
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Szöveget ad a 2. sor 1. cellájába
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Szöveget ad a 2. sor 2. cellájába
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Klónozza a 2. sort a táblázat 4. soraként
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Klónozza az első oszlopot a végén
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Klónozza a 2. oszlopot a 4. oszlop indexén
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Mentse a prezentációt a lemezen
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sor vagy oszlop eltávolítása a táblázatból**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból, és töltse be a prezentációt,  
2. Szerezze meg egy dia referenciáját az indexével.  
3. Határozzon meg egy `columnWidth` tömböt.  
4. Határozzon meg egy `rowHeight` tömböt.  
5. Adjon egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) objektumot a diára az [addTable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) metódus segítségével.  
6. Távolítsa el a táblázat sorát.  
7. Távolítsa el a táblázat oszlopát.  
8. Mentse a módosított prezentációt.  

Ez a Java kód bemutatja, hogyan távolítható el egy sor vagy oszlop a táblázatból:

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

## **Szövegformázás beállítása a táblázatsor szintjén**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból, és töltse be a prezentációt,  
2. Szerezze meg egy dia referenciáját az indexével.  
3. Hozzáférés a megfelelő [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) objektumhoz a diáról.  
4. Állítsa be az első sor celláinak [setFontHeight(float value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Állítsa be az első sor celláinak [setAlignment(int value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) és [setMarginRight(float value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) attribútumait.  
6. Állítsa be a második sor celláinak [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Mentse a módosított prezentációt.  

Ez a Java kód demonstrálja a műveletet.

```java
// Létrehozza a Presentation osztály egy példányát
Presentation pres = new Presentation();
try {
    // Tegyük fel, hogy az első dián az első alakzat egy táblázat
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
    
    // Beállítja a második sor celláinak függőleges szövegtípust
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Mentse a prezentációt a lemezen
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szövegformázás beállítása a táblázatoszlop szintjén**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból, és töltse be a prezentációt,  
2. Szerezze meg egy dia referenciáját az indexével.  
3. Hozzáférés a megfelelő [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) objektumhoz a diáról.  
4. Állítsa be az első oszlop celláinak [setFontHeight(float value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Állítsa be az első oszlop celláinak [setAlignment(int value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) és [setMarginRight(float value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) attribútumait.  
6. Állítsa be a második oszlop celláinak [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Mentse a módosított prezentációt.  

Ez a Java kód demonstrálja a műveletet: 

```java
// Létrehozza a Presentation osztály egy példányát
Presentation pres = new Presentation();
try {
    // Tegyük fel, hogy az első dián az első alakzat egy táblázat
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Beállítja az első oszlop celláinak betűmagasságát
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Beállítja az első oszlop celláinak szövegigazítását és jobb margóját egy hívásban
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Beállítja a második oszlop celláinak függőleges szövegtípust
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **A táblázat stílusjellemzőinek lekérése**

Az Aspose.Slides lehetővé teszi, hogy egy táblázat stílusjellemzőit lekérje, így ezeket az adatokat egy másik táblázatnál vagy máshol felhasználhatja. Ez a Java kód bemutatja, hogyan lehet a táblázat előre beállított stílusából lekérni a stílusjellemzőket:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // módosítja az alapértelmezett stíluselőre beállított témát
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Alkalmazhatok PowerPoint témákat/stílusokat egy már létrehozott táblázatra?**

Igen. A táblázat örökli a dia/elrendezés/mester téma beállításait, és továbbra is felülírhatja a kitöltéseket, szegélyeket és szövegszíneket a téma felett.

**Rendezhetem-e a táblázat sorait úgy, mint Excelben?**

Nem, az Aspose.Slides táblázatokban nincs beépített rendezés vagy szűrő. Először rendezze az adatokat a memóriában, majd töltse újra a táblázat sorait a kívánt sorrendben.

**Lehet-e csíkozott (csíkozott) oszlopokat alkalmazni, miközben egyedi színeket tartok meg bizonyos cellákban?**

Igen. Kapcsolja be a csíkozott oszlopokat, majd felülírja a konkrét cellákat helyi formázással; a cellaszintű formázás felülbírálja a táblázat stílusát.