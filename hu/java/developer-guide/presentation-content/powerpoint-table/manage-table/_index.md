---
title: Prezentációs táblázatok kezelése Java-ban
linktitle: Táblázat kezelése
type: docs
weight: 10
url: /hu/java/manage-table/
keywords:
- táblázat hozzáadása
- táblázat létrehozása
- táblázathoz hozzáférés
- méretarány
- szöveg igazítása
- szövegformázás
- táblázat stílusa
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Hozzon létre és szerkesszen táblázatokat PowerPoint diákkal az Aspose.Slides for Java segítségével. Fedezzen fel egyszerű kódrészleteket, hogy felgyorsítsa a táblázati munkafolyamatait."
---
## **Bevezetés**

A PowerPoint táblázat hatékony módja az információk megjelenítésének és ábrázolásának. Egy cellákból (sorok és oszlopok szerint rendezett) álló rácsban lévő adatok egyértelműek és könnyen érthetők.

Az Aspose.Slides biztosítja a [Table](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Table) osztályt, a [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITable) interfészt, a [Cell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cell/) osztályt, a [ICell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icell/) interfészt és más típusokat, amelyek lehetővé teszik táblázatok létrehozását, frissítését és kezelését mindenféle prezentációban.

## **Táblázat létrehozása a semmiből**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Definiáljon egy `columnWidth` tömböt.  
4. Definiáljon egy `rowHeight` tömböt.  
5. Adjon hozzá egy [ITable] objektumot a diára a [addTable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) metódus segítségével.  
6. Iteráljon minden [ICell] elemen, és alkalmazza a formázást a felső, alsó, jobb és bal szegélyekre.  
7. Egyesítse a táblázat első sorának első két celláját.  
8. Érje el egy [ICell] [TextFrame]-jét.  
9. Adjon szöveget a [TextFrame]-hez.  
10. Mentse a módosított prezentációt.

```java
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Táblázat alakzatot ad a diához
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Beállítja a szegély formátumát minden cellához
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
    // Egyesíti az 1. sor 1. és 2. celláit
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Szöveget ad a egyesített cellához
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Mentés a prezentációt a lemezre
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Számozás egy szabványos táblázatban**

Egy szabványos táblázatban a cellák számozása egyszerű és nullára indexált. Az első cella a táblázatban 0,0 indexű (oszlop 0, sor 0).

Például egy 4 oszlopos és 4 soros táblázat cellái a következőképpen vannak számozva:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a Java kód megmutatja, hogyan adható meg a cellák számozása egy táblázatban:

```java
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Táblázat alakzatot ad a diához
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Beállítja a szegély formátumát minden cellához
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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg a táblázatot tartalmazó dia hivatkozását az indexe alapján.  
3. Hozzon létre egy [ITable] objektumot, és állítsa null értékre.  
4. Iteráljon az összes [IShape] objektumon, amíg meg nem találja a táblázatot.  

   Ha úgy gondolja, hogy a feldolgozott dia egyetlen táblázatot tartalmaz, egyszerűen ellenőrizheti az összes benne lévő alakzatot. Amikor egy alakzatot táblázatként azonosít, átkonvertálhatja [Table] objektummá. Ha a dián több táblázat is van, akkor célszerűbb a kívánt táblázatot a [setAlternativeText(String value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) segítségével keresni.  

5. Használja az [ITable] objektumot a táblázattal való munkához. Az alábbi példában egy új sort adtunk hozzá a táblázathoz.  
6. Mentse a módosított prezentációt.

```java
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicializálja a TableEx-et null értékkel
    ITable tbl = null;

    // Iterál a alakzatokon, és beállítja a megtalált táblára a hivatkozást
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Beállítja a szöveget a második sor első oszlopában
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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy [ITable] objektumot a diára.  
4. Érje el a táblázatból egy [ITextFrame] objektumot.  
5. Érje el a [ITextFrame] [IParagraph] elemét.  
6. Igazítsa a szöveget függőlegesen.  
7. Mentse a módosított prezentációt.

```java
// Létrehozza a Presentation osztály egy példányát
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
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
    
    // Mentés a prezentációt a lemezre
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szövegformázás beállítása táblázati szinten**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Érje el a diából egy [ITable] objektumot.  
4. Állítsa be a [setFontHeight(float value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) értékét a szöveghez.  
5. Állítsa be a [setAlignment(int value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) és a [setMarginRight(float value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) értékeket.  
6. Állítsa be a [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) opciót.  
7. Mentse a módosított prezentációt.

```java
// Létrehozza a Presentation osztály egy példányát
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Tegyük fel, hogy az első dia első alakzata egy táblázat
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
    
    // Beállítja a táblázat celláinak függőleges szövegtípust
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Táblázat stílus tulajdonságainak lekérdezése**

Az Aspose.Slides lehetővé teszi a táblázat stílus tulajdonságainak lekérdezését, így ezeket felhasználhatja egy másik táblázathoz vagy máshová. Ez a Java kód megmutatja, hogyan lehet lekérni egy táblázat előre beállított stílusának tulajdonságait:

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

## **Táblázat méretarányának zárolása**

A geometriai alakzat méretaránya a különböző dimenziók méreteinek aránya. Az Aspose.Slides a **setAspectRatioLocked**[**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-)** tulajdonságot biztosítja, amely lehetővé teszi a méretarány beállításának zárolását táblázatok és más alakzatok esetén.

Ez a Java kód megmutatja, hogyan zárolható egy táblázat méretaránya:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // invertál

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Engedélyezhetek jobbról balra (RTL) olvasási irányt egy teljes táblázatban és a cellákban lévő szövegben?**

Igen. A táblázat a [setRightToLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/table/#setRightToLeft-boolean-) metódust biztosítja, a bekezdések pedig a [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) metódust. Mindkettő használata biztosítja a helyes RTL sorrendet és megjelenítést a cellákon belül.

**Hogyan tudom megakadályozni, hogy a felhasználók elmozdítsák vagy átméretezzék a táblázatot a végleges fájlban?**

Használjon [shape locks](/slides/hu/java/applying-protection-to-presentation/) funkciót a mozgatás, átméretezés, kiválasztás stb. letiltásához. Ezek a zárolások a táblázatokra is vonatkoznak.

**Támogatott-e egy kép beillesztése egy cellába háttérként?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/hu/java/com.aspose.slides/picturefillformat/) formátumot egy cellához; a kép a választott mód szerint (nyújtás vagy csempézés) fed le minden cellaterületet.