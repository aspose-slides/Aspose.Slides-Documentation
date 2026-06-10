---
title: Androidon a prezentációs táblázatok kezelése
linktitle: Táblázat kezelése
type: docs
weight: 10
url: /hu/androidjava/manage-table/
keywords:
- tábla hozzáadása
- tábla létrehozása
- tábla elérése
- képarány
- szöveg igazítása
- szövegformázás
- tábla stílus
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Táblák létrehozása és szerkesztése PowerPoint diákon az Aspose.Slides for Android segítségével. Fedezze fel az egyszerű Java kódrészleteket, hogy hatékonyabb legyen a táblázatkezelés."
---
## **Bevezetés**

A PowerPoint táblázata hatékony módja az információ megjelenítésének és ábrázolásának. A cellák rácsában (sorokba és oszlopokba rendezve) szereplő információ egyértelmű és könnyen érthető.

Aspose.Slides a [Table](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Table) osztályt, az [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) interfészt, a [Cell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cell/) osztályt, az [ICell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icell/) interfészt, valamint egyéb típusokat biztosít, amelyekkel táblázatokat hozhat létre, frissíthet és kezelhet különféle bemutatókban.

## **Táblázat létrehozása nulláról**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg a diára való hivatkozást az indexe alapján.  
3. Határozzon meg egy `columnWidth` tömböt.  
4. Határozzon meg egy `rowHeight` tömböt.  
5. Adjon hozzá egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) objektumot a diára az [addTable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) metódussal.  
6. Iteráljon végig minden [ICell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icell/) elemen, hogy formázza a felső, alsó, jobb és bal szegélyeket.  
7. Egyesítse a táblázat első sorának első két celláját.  
8. Hozzon hozzá egy [ICell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icell/) [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/) objektumához.  
9. Adjon szöveget a [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/) objektumhoz.  
10. Mentse el a módosított bemutatót.

Ez a Java kód bemutatja, hogyan hozhat létre egy táblázatot a bemutatóban:

```java
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiálja az oszlopokat szélességekkel és a sorokat magasságokkal
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Táblázat alakzatot ad a diára
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Beállítja a szegélyformátumot minden cellához
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Egyesíti az 1. sor első és második celláját
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Szöveget ad a egyesített cellához
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Mentés a prezentáció a lemezre
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Számozás egy szabványos táblázatban**

Egy szabványos táblázatban a cellák számozása egyértelmű és nullától indul. Az első cella indexe 0,0 (oszlop 0, sor 0).

Például egy 4 oszlopos és 4 soros táblázat cellái így vannak számozva:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a Java kód bemutatja, hogyan adható meg a cellák számozása egy táblázatban:

```java
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt reprezentál
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Táblázat alakzatot ad a diához
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Beállítja a szegélyformátumot minden cellához
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Mentés a prezentációt a lemezre
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Meglévő táblázat elérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  

2. Szerezze meg a táblázatot tartalmazó dia hivatkozását az indexe alapján.  

3. Hozzon létre egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) objektumot, és állítsa null értékre.  

4. Iteráljon végig az összes [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) objektumon, amíg meg nem találja a táblázatot.  
   Ha azt gyanítja, hogy a kezelendő dia egyetlen táblázatot tartalmaz, egyszerűen ellenőrizheti az összes benne lévő alakzatot. Ha egy alakzatot táblázatként azonosít, típuskényszerítéssel [Table](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Table) objektummá alakíthatja. Ha azonban a dia több táblázatot tartalmaz, célszerűbb a keresett táblázatot a [setAlternativeText(String value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) metódus segítségével megtalálni.  

5. Használja az [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) objektumot a táblázattal való munkához. Az alábbi példában egy új sort adtunk hozzá a táblázathoz.  

6. Mentse el a módosított bemutatót.

Ez a Java kód bemutatja, hogyan érheti el és dolgozhat egy meglévő táblázattal:

```java
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt reprezentál
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicializálja a null TableEx-et
    ITable tbl = null;

    // Iterál a formákon és beállít egy hivatkozást a megtalált táblázatra
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Beállítja a szöveget a második sor első oszlopához
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Mentés a módosított prezentációt a lemezre
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szöveg igazítása egy táblázatban**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg a diára való hivatkozást az indexe alapján.  
3. Adjon hozzá egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) objektumot a diára.  
4. Hozzon hozzá egy [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) objektumot a táblázatból.  
5. Hozzon hozzá a [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) objektumhoz.  
6. Igazítsa a szöveget függőlegesen.  
7. Mentse el a módosított bemutatót.

Ez a Java kód bemutatja, hogyan igazíthatja a szöveget egy táblázatban:

```java
// Létrehoz egy példányt a Presentation osztályból
Presentation pres = new Presentation();
try {
    // Eléri az első diát 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Hozzáadja a táblázat alakzatot a diához
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Eléri a szövegkeretet
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Létrehozza a Paragraph objektumot a szövegkerethez
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Létrehozza a Portion objektumot a bekezdéshez
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Függőlegesen igazítja a szöveget
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Elmenti a prezentációt a lemezre
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szövegformázás beállítása táblázatszinten**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg a diára való hivatkozást az indexe alapján.  
3. Hozzon hozzá egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) objektumot a diához.  
4. Állítsa be a [setFontHeight(float value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) értéket a szöveghez.  
5. Állítsa be a [setAlignment(int value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) és a [setMarginRight(float value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) értékeket.  
6. Állítsa be a [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) értéket.  
7. Mentse el a módosított bemutatót.  

Ez a Java kód bemutatja, hogyan alkalmazhatja a kívánt formázási beállításokat a táblázatban lévő szövegre:

```java
// Létrehozza a Presentation osztály egy példányát
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Tegyük fel, hogy az első dián az első forma egy táblázat
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Beállítja a táblázat celláinak betűmagasságát
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Beállítja a táblázat celláinak szövegigazítását és jobb margóját egy hívásban
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Beállítja a táblázat celláinak függőleges szövegtípusát
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Táblázat stílus tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy táblázat stílus tulajdonságait, hogy azokat egy másik táblázathoz vagy más helyen felhasználhassa. Ez a Java kód bemutatja, hogyan lehet lekérni a stílus tulajdonságokat egy táblázat előre beállított stílusából:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // az alapértelmezett stílus előre beállított témájának módosítása
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Táblázat képarányának zárolása**

A geometriai alakzat képaránya a méretei aránya különböző dimenziókban. Az Aspose.Slides a [**setAspectRatioLocked**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) tulajdonságot biztosítja, amely lehetővé teszi a képarány zárolását táblázatok és egyéb alakzatok esetén.

Ez a Java kód bemutatja, hogyan zárolható le egy táblázat képaránya:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // invertálja

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Engedélyezhetem a jobbról balra (RTL) olvasási irányt a teljes táblázatban és a cellák szövegében?**

Igen. A táblázat a [setRightToLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) metódust, a bekezdések pedig a [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) metódust biztosítják. Mindkettő használata garantálja a helyes RTL sorrendet és megjelenítést a cellákon belül.

**Hogyan akadályozhatom meg, hogy a felhasználók a végleges fájlban mozgatni vagy átméretezni a táblázatot?**

Használjon alakzat zárolásokat a mozgatás, átméretezés, kijelölés stb. letiltásához. Ezek a zárolások a táblázatokra is érvényesek.

**Támogatott-e egy kép cellába való háttérként történő beszúrása?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/picturefillformat/) kitöltést a cellához; a kép a cellaterületet lefedi a választott móddal (nyújtás vagy csempe).